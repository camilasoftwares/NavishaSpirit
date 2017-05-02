Imports System.Windows.Forms
Imports AIMS.Author

Public Class FrmPurchaseReturn

#Region "Local variables and Constants"

    Dim editRow As DataGridViewRow = Nothing
    Dim lPurchaseObj As ClsPurchaseMaster = Nothing
    Dim lPurchaseReturnObj As ClsPurchaseReturnMaster = Nothing
    Dim lStorages() As ClsStorageMaster = Nothing
    Dim lItems() As ClsItemMaster = Nothing
    Dim flagPurchaseCodeChanged As Boolean = False
    Dim lCurrentBatch As ClsCurrentStock = Nothing

    Private Const lcUpdate As String = "&Update"
    Private Const lcCancel As String = "Cance&l"

    Enum Index
        GrpPurchaseDetail
        TxtPurchaseReturnCode
        DtPkrReturnDate
        TxtPurchaseCode
        DtPkrPurchaseDate
        CmbVendor
        GrdItemsPurchase
        TxtTotalAmountPurchase
        TxtTaxTotalPurchase
        TxtDiscountTotalPurchase
        TxtRoundOffPurchase
        TxtNetAmountPurchase
        GrpItemReturn
        CmbItem
        'CmbBatch
        PnlQuantity
        TxtPackQty
        TxtReturnQuantity
        TxtPackSize
        TxtFreeQuantity
        TxtTotalQunatity
        TxtPurchasePrice
        TxtTax
        CmbTaxType
        TxtDiscount
        CmbDiscountType
        TxtTotal
        BtnAdd
        BtnRemove
        GrdItemsPurchaseReturn
        TxtTotalReturn
        TxtTaxReturn
        TxtDiscountReturn
        TxtRoundOffReturn
        TxtNetAmountReturn
        GrpButtons
        TxtRemark
        BtnNew
        BtnSave
        BtnPrint
        BtnSearch
        BtnClose
    End Enum

#End Region

#Region "Control Function"

    Private Sub Help(ByVal sender As Object, ByVal hlpEvent As System.Windows.Forms.HelpEventArgs) Handles MyBase.HelpRequested
        Try
            Dim obj As Object = Me.Owner
            obj.ShowHelp()
        Catch ex As Exception
        End Try

        hlpEvent.Handled = True
    End Sub

    Private Sub FrmPurchaseReturn_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not (lPurchaseReturnObj Is Nothing) Then
            If lPurchaseReturnObj.NotClosed = True Then
                If MsgBox("Purchase Return Master is not updated." + vbCrLf + vbCrLf + "To update click save button." + vbCrLf + vbCrLf + "Do you want to update Purchase Return master?", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub FrmPurchaseReturn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

    Private Sub KeyPressNumeric(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtReturnQuantity.KeyPress, TxtFreeQuantity.KeyPress
        e.Handled = Check_Numeric(e.KeyChar)
    End Sub

    Private Sub KeyPressDecimal(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTax.KeyPress, TxtDiscount.KeyPress
        e.Handled = Check_DecimalAllow(e.KeyChar, sender.text)
    End Sub

    Private Sub GrdItemsPurchaseReturn_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdItemsPurchaseReturn.CellClick
        Try
            If e.RowIndex < 0 Then Exit Try
            'If AndedTheString(gUser.AuthorizationNo, Authorization.PurchaseReturn_NoRemove) = True Then Exit Sub

            BtnRemove.Enabled = True
            BtnAdd.Enabled = False
            BtnNew.Text = lcCancel

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub GrdItemsPurchaseReturn_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdItemsPurchaseReturn.CellDoubleClick
        Try
            BtnRemove.Enabled = False
            If e.RowIndex < 0 Then Exit Try
            'If AndedTheString(gUser.AuthorizationNo, Authorization.PurchaseReturn_NoUpdate) = True Then Exit Sub

            editRow = GrdItemsPurchaseReturn.Rows(e.RowIndex)
            With editRow
                CmbItem.Text = .Cells(cName).Value
                'CmbBatch.SelectedText = .Cells(cBatch).Value
                TxtPurchasePrice.Text = .Cells(cPricePurchase).Value
                TxtReturnQuantity.Text = .Cells(cReturnQuantity).Value
                TxtFreeQuantity.Text = .Cells(cFreeQuantity).Value
                TxtPackQty.Text = .Cells(cPackQuantity).Value

                If .Cells(cTaxPercent).Value > 0 Then
                    TxtTax.Text = .Cells(cTaxPercent).Value
                    CmbTaxType.Text = cTypePercentage
                Else
                    TxtTax.Text = .Cells(cTaxAmount).Value
                    CmbTaxType.Text = cTypeAmountRs
                End If
                If .Cells(cDiscountPercent).Value > 0 Then
                    TxtDiscount.Text = .Cells(cDiscountPercent).Value
                    CmbDiscountType.Text = cTypePercentage
                Else
                    TxtDiscount.Text = .Cells(cDiscountAmount).Value
                    CmbDiscountType.Text = cTypeAmountRs
                End If
            End With

            BtnAdd.Text = lcUpdate
            BtnNew.Text = lcCancel
            BtnAdd.Enabled = True
            TxtReturnQuantity.Focus()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub KeyDownTab(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdItemsPurchaseReturn.KeyDown, GrdItemsPurchase.KeyDown
        If e.KeyCode = Keys.Tab Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub TxtPurchaseCode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPurchaseCode.KeyPress
        e.Handled = Check_Numeric(e.KeyChar)
        flagPurchaseCodeChanged = True
    End Sub

    Private Sub TxtPurchaseCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPurchaseCode.TextChanged
        Try
            If flagPurchaseCodeChanged = False Then Exit Try

            flagPurchaseCodeChanged = False
            If Not (lPurchaseReturnObj Is Nothing) Then
                MsgBox("It is not possible to add items from other purchase code." + vbCrLf + vbCrLf + "Please click new to generate new Purchase Return code for this.", , "Not Possible")
                Exit Try
            End If

            GrdItemsPurchase.Rows.Clear()
            CalculateTotalsForPurchaseItems()   'Clears all values
            If TxtPurchaseCode.Text.Trim = "" Then Exit Try

            Dim str As String = TxtPurchaseCode.Text    'Text get reset due to purchase object set.
            Dim purchaseId As Long = Val(TxtPurchaseCode.Text)
            If purchaseId <= 0 Then Exit Try

            SetPurchaseObject(GetPurchaseMaster(Me.Name, purchaseId))
            TxtPurchaseCode.Text = str
            TxtPurchaseCode.SelectionStart = str.Length

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub TxtPackQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPackQty.TextChanged
        TxtPackSize.Text = TxtPackQty.Text
        CalculateTotalQuantity()
    End Sub

    Private Sub TxtReturnQuantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtReturnQuantity.TextChanged
        CalculateTotalQuantity()
        CalculateTotal()
    End Sub

    Private Sub TxtFreeQuantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFreeQuantity.TextChanged
        CalculateTotalQuantity()
    End Sub

    Private Sub TxtTax_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtTax.TextChanged
        CalculateTotal()
    End Sub

    Private Sub CmbTaxType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbTaxType.SelectedIndexChanged
        CalculateTotal()
    End Sub

    Private Sub TxtDiscount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDiscount.TextChanged
        CalculateTotal()
    End Sub

    Private Sub CmbDiscountType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbDiscountType.SelectedIndexChanged
        CalculateTotal()
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Try
            If BtnAdd.Text = lcUpdate Then
                UpdatePurchaseReturnDetailObject()
                Exit Sub
            End If

            If ValidateValues() = False Then Exit Sub

            'Saving Master if virtual
            If lPurchaseReturnObj Is Nothing Then
                Dim purchaseReturnMasterObj As New ClsPurchaseReturnMaster
                With purchaseReturnMasterObj
                    .VendorId = GetSelectedItemId(CmbVendor)
                    .Mode = lPurchaseObj.Mode
                    .Remark = TxtRemark.Text
                    .ReturnDate = DtPkrReturnDate.Value
                    .PurchaseId = TxtPurchaseCode.Text
                    .DiscountAmount = Val(TxtDiscountReturn.Text)
                    .UserId = gUser.LoginName
                    .DateOn = Now
                    .NotClosed = True
                End With

                Dim purchaseReturnId As Long = InsertPurchaseReturnMaster(Me.Name, purchaseReturnMasterObj)
                If purchaseReturnId <= 0 Then Exit Try

                purchaseReturnMasterObj.Id = purchaseReturnId
                lPurchaseReturnObj = purchaseReturnMasterObj

                purchaseReturnMasterObj = GetPurchaseReturnMasterById(Me.Name, purchaseReturnId)
                If Not (purchaseReturnMasterObj Is Nothing) Then
                    lPurchaseReturnObj = purchaseReturnMasterObj
                    TxtPurchaseReturnCode.Text = lPurchaseReturnObj.PurchaseReturnCode
                End If
            End If

            If lPurchaseReturnObj Is Nothing Then
                MsgBox("Purchase Return Code doesn't found. Unable to Add.", MsgBoxStyle.Critical, "Error")
                Exit Sub
            End If

            'Saving Detail
            Dim purchaseReturnDetailObj As New ClsPurchaseReturnDetail
            With purchaseReturnDetailObj
                .PurchaseReturnId = lPurchaseReturnObj.Id
                Dim item As ClsItemMaster = CmbItem.SelectedItem
                .ItemId = item.Id
                Dim currentStock As ClsCurrentStock = lCurrentBatch 'CmbBatch.SelectedItem
                If currentStock Is Nothing Then
                    MsgBox("Batch is not selected or Batch doesn't exist", , "Batch")
                    Exit Sub
                End If

                .Batch = currentStock.Batch
                .ExpiryDate = currentStock.ExpiryDate
                .PackQuantity = currentStock.PackQuantity
                .PriceSale = 0 'currentStock.PriceSale
                .PricePurchase = Val(TxtPurchasePrice.Text)

                If CmbTaxType.Text = cTypePercentage Then
                    .TaxPercent = Val(TxtTax.Text)
                End If

                If CmbDiscountType.Text = cTypePercentage Then
                    .DiscountPercent = Val(TxtDiscount.Text)
                End If

                .ReturnQuantity = Val(TxtReturnQuantity.Text)
                .PurchaseId = lPurchaseObj.Id
                .NonSaleable = False
                .FreeQuantity = Val(TxtFreeQuantity.Text)
                .StorageId = currentStock.StorageId
                .Remark = TxtRemark.Text
                .UserId = gUser.LoginName
                .DateOn = Now
                CalculateTotal(.TaxAmount, .DiscountAmount)
            End With

            Dim id As Long = InsertPurchaseReturnDetail(Me.Name, purchaseReturnDetailObj)
            If id > 0 Then
                purchaseReturnDetailObj.Id = id
                InsertIntoPurchaseItemReturnGrid(purchaseReturnDetailObj)
                CalculateTotalsForPurchaseItemsReturn()
                lPurchaseReturnObj.NotClosed = True
            End If

            MsgBox("Successfully Added", , "Added")

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNewItem()
    End Sub

    Private Sub BtnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemove.Click
        Try
            Dim row As DataGridViewRow = GrdItemsPurchaseReturn.SelectedRows(0)
            If row Is Nothing Then Exit Try

            Dim id As Long = row.Cells(cId).Value
            If id <= 0 Then Exit Try

            If MsgBox("Do you really wants to remove selected record? Removed records can't be recovered.", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                If DeletePurchaseReturnDetail(Me.Name, id) <> EnResult.Change Then Exit Sub

                GrdItemsPurchaseReturn.Rows.Remove(row)
                lPurchaseReturnObj.NotClosed = True
                CalculateTotalsForPurchaseItemsReturn()
                MsgBox("Successfully Removed", , "Removed")
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNewItem()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch.Click
        Try
            Dim frm As New ClsSearchPurchaseReturnForm
            If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Dim id As Long = frm.GetSelectedId
                If id > 0 Then
                    SetPurchaseReturnForPurchaseReturnId(id)
                End If
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Try
            If lPurchaseReturnObj Is Nothing Then
                MsgBox("There is no Purchase Return selected. Please create or select Purchase Return.", , "Purchase Return")
                Exit Try
            End If

            If lPurchaseReturnObj.Id <= 0 Then
                MsgBox("There is no Purchase Return selected. Please create or select Purchase Return.", , "Purchase Return")
                Exit Try
            End If

            Dim saleReturnId As Long = lPurchaseReturnObj.Id
            Dim ds As DataSet = GetPurchaseReturn(Me.Name, saleReturnId)

            If ds Is Nothing Then
                MsgBox("Error in generating report.", MsgBoxStyle.Critical, "Error")
                Exit Try
            End If

            If ds.Tables(0).Rows.Count = 0 Then
                MsgBox("No record is present for this selection.", MsgBoxStyle.Information, "No Record")
                Exit Try
            End If

            'Opening Report
            SetWaitCursor()
            Dim rpt As New RptPurchaseReturn
            rpt.SetDataSource(ds.Tables(0))
            Dim dlg As New DiagReport
            dlg.RptViewer.ReportSource = rpt
            dlg.ShowDialog(Me)

        Catch ex As Exception
            AddToLog(ex)
        End Try

        SetDefaultCursor()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            If lPurchaseReturnObj Is Nothing Then Exit Try

            'Updating Master
            Dim purchaseReturnMasterObj As New ClsPurchaseReturnMaster
            With purchaseReturnMasterObj
                .Id = lPurchaseReturnObj.Id
                .PurchaseId = lPurchaseReturnObj.PurchaseId
                .PurchaseReturnCode = lPurchaseReturnObj.PurchaseReturnCode
                .VendorId = GetSelectedItemId(CmbVendor)
                .DiscountAmount = Val(TxtDiscountReturn.Text)
                .Mode = lPurchaseReturnObj.Mode
                .Remark = TxtRemark.Text
                .ReturnDate = DtPkrReturnDate.Value
                .UserId = gUser.LoginName
                .DateOn = Now
                .NotClosed = False
            End With

            If UpdatePurchaseReturnMaster(Me.Name, purchaseReturnMasterObj) <> EnResult.Change Then Exit Sub
            lPurchaseReturnObj = purchaseReturnMasterObj

            MsgBox("Successfully Saved", , "Saved")

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        If BtnNew.Text = lcCancel Then
            ResetControlsToAddNewItem()
        Else
            If Not (lPurchaseReturnObj Is Nothing) Then
                If lPurchaseReturnObj.NotClosed = True Then
                    If MsgBox("Purchase Return Master is not updated." + vbCrLf + vbCrLf + "To update click save button." + vbCrLf + vbCrLf + "Do you want to update Purchase Return Master?", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                        Exit Sub
                    End If
                End If
            End If

            ResetControlsToAddNew()
        End If
    End Sub

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtTotalReturn.KeyDown, TxtTotalQunatity.KeyDown, TxtTotalAmountPurchase.KeyDown, TxtTotal.KeyDown, TxtTaxTotalPurchase.KeyDown, TxtTaxReturn.KeyDown, TxtTax.KeyDown, TxtRoundOffReturn.KeyDown, TxtRoundOffPurchase.KeyDown, TxtReturnQuantity.KeyDown, TxtRemark.KeyDown, TxtPurchaseReturnCode.KeyDown, TxtPurchasePrice.KeyDown, TxtPurchaseCode.KeyDown, TxtPackSize.KeyDown, TxtPackQty.KeyDown, TxtNetAmountReturn.KeyDown, TxtNetAmountPurchase.KeyDown, TxtFreeQuantity.KeyDown, TxtDiscountTotalPurchase.KeyDown, TxtDiscountReturn.KeyDown, TxtDiscount.KeyDown, DtPkrReturnDate.KeyDown, DtPkrPurchaseDate.KeyDown, CmbVendor.KeyDown, CmbTaxType.KeyDown, CmbItem.KeyDown, CmbDiscountType.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub GrdItemsPurchase_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdItemsPurchase.CellClick
        Try
            If e.RowIndex < 0 Then Exit Try

            With GrdItemsPurchase.Rows(e.RowIndex)
                CmbItem.Text = .Cells(cName).Value
                'CmbBatch.Text = .Cells(cBatch).Value
                TxtPurchasePrice.Text = .Cells(cPricePurchase).Value
                TxtPackQty.Text = .Cells(cPackQuantity).Value
                TxtReturnQuantity.Text = .Cells(cPurchaseQuantity).Value
                TxtTotal.Text = "0"

                If .Cells(cTaxPercent).Value > 0 Then
                    TxtTax.Text = .Cells(cTaxPercent).Value
                    CmbTaxType.Text = cTypePercentage
                Else
                    TxtTax.Text = .Cells(cTaxAmount).Value
                    CmbTaxType.Text = cTypeAmountRs
                End If

                If .Cells(cDiscountPercent).Value > 0 Then
                    TxtDiscount.Text = .Cells(cDiscountPercent).Value
                    CmbDiscountType.Text = cTypePercentage
                Else
                    TxtDiscount.Text = .Cells(cDiscountAmount).Value
                    CmbDiscountType.Text = cTypeAmountRs
                End If

            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

#End Region

#Region "Private Function"

    Private Sub SetControls()
        SetTabIndex()
        SetGridForItemPurchase()
        SetGridForItemsPurchaseReturn()
        ResetControlsToAddNew()
        LoadComboBoxValues()
        LoadStorages()
        LoadItems()

        'Load Grid values after ComboBox Values
        SetObjectsForCurrentLogin()
        LoadGridValuesForPurchaseItemsReturn()
        CalculateTotalsForPurchaseItemsReturn()
    End Sub

    Private Sub SetTabIndex()
        GrpPurchaseDetail.TabIndex = Index.GrpPurchaseDetail
        TxtRoundOffPurchase.TabIndex = Index.TxtRoundOffPurchase
        TxtTaxTotalPurchase.TabIndex = Index.TxtTaxTotalPurchase
        TxtDiscountTotalPurchase.TabIndex = Index.TxtDiscountTotalPurchase
        TxtTotalAmountPurchase.TabIndex = Index.TxtTotalAmountPurchase
        TxtNetAmountPurchase.TabIndex = Index.TxtNetAmountPurchase
        GrdItemsPurchase.TabIndex = Index.GrdItemsPurchase
        CmbVendor.TabIndex = Index.CmbVendor
        DtPkrPurchaseDate.TabIndex = Index.DtPkrPurchaseDate
        TxtPurchaseCode.TabIndex = Index.TxtPurchaseCode
        DtPkrReturnDate.TabIndex = Index.DtPkrReturnDate
        TxtPurchaseReturnCode.TabIndex = Index.TxtPurchaseReturnCode
        GrpButtons.TabIndex = Index.GrpButtons
        BtnSearch.TabIndex = Index.BtnSearch
        BtnPrint.TabIndex = Index.BtnPrint
        BtnNew.TabIndex = Index.BtnNew
        BtnClose.TabIndex = Index.BtnClose
        BtnSave.TabIndex = Index.BtnSave
        TxtRemark.TabIndex = Index.TxtRemark
        GrpItemReturn.TabIndex = Index.GrpItemReturn
        TxtRoundOffReturn.TabIndex = Index.TxtRoundOffReturn
        TxtTaxReturn.TabIndex = Index.TxtTaxReturn
        TxtDiscountReturn.TabIndex = Index.TxtDiscountReturn
        TxtTotalReturn.TabIndex = Index.TxtTotalReturn
        TxtNetAmountReturn.TabIndex = Index.TxtNetAmountReturn
        TxtPurchasePrice.TabIndex = Index.TxtPurchasePrice
        TxtTax.TabIndex = Index.TxtTax
        TxtDiscount.TabIndex = Index.TxtDiscount
        TxtTotal.TabIndex = Index.TxtTotal
        GrdItemsPurchaseReturn.TabIndex = Index.GrdItemsPurchaseReturn
        BtnRemove.TabIndex = Index.BtnRemove
        BtnAdd.TabIndex = Index.BtnAdd
        CmbDiscountType.TabIndex = Index.CmbDiscountType
        CmbTaxType.TabIndex = Index.CmbTaxType
        'CmbBatch.TabIndex = Index.CmbBatch
        CmbItem.TabIndex = Index.CmbItem
        PnlQuantity.TabIndex = Index.PnlQuantity
        TxtTotalQunatity.TabIndex = Index.TxtTotalQunatity
        TxtReturnQuantity.TabIndex = Index.TxtReturnQuantity
        TxtFreeQuantity.TabIndex = Index.TxtFreeQuantity
        TxtPackQty.TabIndex = Index.TxtPackQty
        TxtPackSize.TabIndex = Index.TxtPackSize
    End Sub

    Private Sub SetGridForItemPurchase()
        With GrdItemsPurchase
            Dim colCount As Integer = 18
            .RowHeadersVisible = False
            Dim defaultCellWidth As Integer = 80
            Dim x As Integer
            For x = 0 To colCount
                Select Case x
                    Case 0
                        Dim index As Integer = .Columns.Add(cId, cId)
                        .Columns(index).Visible = False

                    Case 1
                        Dim index As Integer = .Columns.Add(cPurchaseId, cPurchaseId)
                        .Columns(index).Visible = False

                    Case 2
                        Dim index As Integer = .Columns.Add(cName, "Item Name")
                        .Columns(index).Width = 160

                    Case 3
                        Dim index As Integer = .Columns.Add(cItemId, cItemId)
                        .Columns(index).Visible = False

                    Case 4
                        Dim index As Integer = .Columns.Add(cBatch, cBatch)
                        .Columns(index).Width = 90
                        .Columns(index).Visible = False

                    Case 5
                        Dim index As Integer = .Columns.Add(cExpiryDate, "Exp. Date")
                        .Columns(index).Width = 90
                        .Columns(index).DefaultCellStyle.Format = "MMM-yyyy"
                        .Columns(index).Visible = False

                    Case 6
                        Dim index As Integer = .Columns.Add(cPricePurchase, "Pur. Price")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 7
                        Dim index As Integer = .Columns.Add(cPriceSale, "Sale Price")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 8
                        Dim index As Integer = .Columns.Add(cTaxPercent, "Tax %")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 9
                        Dim index As Integer = .Columns.Add(cTaxAmount, "Tax Amt.")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 10
                        Dim index As Integer = .Columns.Add(cDiscountPercent, "Dis. %")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 11
                        Dim index As Integer = .Columns.Add(cDiscountAmount, "Dis. Amt.")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 12
                        Dim index As Integer = .Columns.Add(cPurchaseQuantity, "Pur. Qty.")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 13
                        Dim index As Integer = .Columns.Add(cUserId, cUserId)
                        .Columns(index).Visible = False

                    Case 14
                        Dim index As Integer = .Columns.Add(cDateOn, cDateOn)
                        .Columns(index).Visible = False

                    Case 15
                        Dim index As Integer = .Columns.Add(cFreeQuantity, "Free Qty.")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 16
                        Dim index As Integer = .Columns.Add(cStorageId, cStorageId)
                        .Columns(index).Visible = False

                    Case 17
                        Dim index As Integer = .Columns.Add(cStorage, cStorage)
                        .Columns(index).Visible = False

                    Case 18
                        Dim index As Integer = .Columns.Add(cPackQuantity, "Pack Qty.")
                        .Columns(index).Width = defaultCellWidth

                End Select
            Next
        End With
    End Sub

    Private Sub SetGridForItemsPurchaseReturn()
        With GrdItemsPurchaseReturn
            Dim colCount As Integer = 20
            .RowHeadersVisible = False
            Dim defaultCellWidth As Integer = 80
            Dim x As Integer
            For x = 0 To colCount
                Select Case x
                    Case 0
                        Dim index As Integer = .Columns.Add(cId, cId)
                        .Columns(index).Visible = False

                    Case 1
                        Dim index As Integer = .Columns.Add(cName, cName)
                        .Columns(index).Width = 140

                    Case 2
                        Dim index As Integer = .Columns.Add(cBatch, cBatch)
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).Visible = False

                    Case 3
                        Dim index As Integer = .Columns.Add(cExpiryDate, "Exp. Date")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "MMM-yyyy"
                        .Columns(index).Visible = False

                    Case 4
                        Dim index As Integer = .Columns.Add(cReturnQuantity, "Return Qty")
                        .Columns(index).Width = defaultCellWidth + 10
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 5
                        Dim index As Integer = .Columns.Add(cPricePurchase, "Pur. Price")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 6
                        Dim index As Integer = .Columns.Add(cPackQuantity, "Pack Qty.")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 7
                        Dim index As Integer = .Columns.Add(cTaxPercent, "Tax %")
                        .Columns(index).Width = defaultCellWidth - 10
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 8
                        Dim index As Integer = .Columns.Add(cTaxAmount, "Tax")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 9
                        Dim index As Integer = .Columns.Add(cDiscountPercent, "Dis. %")
                        .Columns(index).Width = defaultCellWidth - 10
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 10
                        Dim index As Integer = .Columns.Add(cDiscountAmount, "Discount")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 11
                        Dim index As Integer = .Columns.Add(cFreeQuantity, "Free Qty.")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 12
                        Dim index As Integer = .Columns.Add(cStorage, cStorage)
                        .Columns(index).Width = defaultCellWidth

                    Case 13
                        Dim index As Integer = .Columns.Add(cTotal, cTotal)
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 14
                        Dim index As Integer = .Columns.Add(cItemId, cItemId)
                        .Columns(index).Visible = False

                    Case 15
                        Dim index As Integer = .Columns.Add(cStorageId, cStorageId)
                        .Columns(index).Visible = False

                    Case 16
                        Dim index As Integer = .Columns.Add(cPriceSale, "S. Price")
                        .Columns(index).Visible = False

                    Case 17
                        Dim index As Integer = .Columns.Add(cRemark, cRemark)
                        .Columns(index).Visible = False

                    Case 18
                        Dim index As Integer = .Columns.Add(cPurchaseReturnId, cPurchaseReturnId)
                        .Columns(index).Visible = False

                    Case 19
                        Dim index As Integer = .Columns.Add(cUserId, cUserId)
                        .Columns(index).Visible = False

                    Case 20
                        Dim index As Integer = .Columns.Add(cDateOn, cDateOn)
                        .Columns(index).Visible = False

                End Select
            Next
        End With
    End Sub

    Private Sub LoadGridValuesForPurchaseDetail()
        Try
            GrdItemsPurchase.Rows.Clear()

            If lPurchaseObj Is Nothing Then Exit Try

            Dim purchaseDetails() As ClsPurchaseDetail = GetAllPurchaseDetailForPurchaseId(Me.Name, lPurchaseObj.Id)
            If purchaseDetails Is Nothing Then Exit Try

            Dim purchaseDetail As ClsPurchaseDetail
            For Each purchaseDetail In purchaseDetails
                InsertIntoPurchaseGrid(purchaseDetail)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub InsertIntoPurchaseGrid(ByRef purchaseDetailObj As ClsPurchaseDetail)
        Try
            If purchaseDetailObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdItemsPurchase.Rows.Add
            With GrdItemsPurchase.Rows(rowIndex)
                .Cells(cId).Value = purchaseDetailObj.Id
                .Cells(cPurchaseId).Value = purchaseDetailObj.PurchaseId
                .Cells(cItemId).Value = purchaseDetailObj.ItemId
                .Cells(cName).Value = GetItemName(.Cells(cItemId).Value)
                .Cells(cBatch).Value = purchaseDetailObj.Batch
                .Cells(cExpiryDate).Value = purchaseDetailObj.ExpiryDate
                .Cells(cPricePurchase).Value = purchaseDetailObj.PricePurchase
                .Cells(cPriceSale).Value = 0 ' purchaseDetailObj.PriceSale
                .Cells(cTaxPercent).Value = purchaseDetailObj.TaxPercent
                .Cells(cTaxAmount).Value = purchaseDetailObj.TaxAmount
                .Cells(cDiscountPercent).Value = purchaseDetailObj.DiscountPercent
                .Cells(cDiscountAmount).Value = purchaseDetailObj.DiscountAmount
                .Cells(cPackQuantity).Value = purchaseDetailObj.PackQuantity
                .Cells(cPurchaseQuantity).Value = purchaseDetailObj.PurchaseQuantity
                .Cells(cUserId).Value = purchaseDetailObj.UserId
                .Cells(cDateOn).Value = purchaseDetailObj.DateOn
                .Cells(cFreeQuantity).Value = purchaseDetailObj.FreeQuantity
                .Cells(cStorageId).Value = purchaseDetailObj.StorageId
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Function GetItemName(ByVal id As Integer) As String
        Dim result As String = ""
        Try
            Dim item As ClsItemMaster
            For Each item In lItems
                If item.Id = id Then
                    result = item.Name
                    Exit Try
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Sub CalculateTotalsForPurchaseItems()
        Try
            TxtTotalAmountPurchase.Text = "0"
            TxtTaxTotalPurchase.Text = "0"
            TxtDiscountTotalPurchase.Text = "0"
            TxtRoundOffPurchase.Text = "0"
            TxtNetAmountPurchase.Text = "0"

            If GrdItemsPurchase.Rows.Count = 0 Then Exit Try

            Dim totalAmount As Double = 0
            Dim taxTotal As Double = 0
            Dim discountTotal As Double = 0
            Dim roundOff As Double = 0
            Dim netAmount As Double = 0

            Dim row As DataGridViewRow
            For Each row In GrdItemsPurchase.Rows
                With row
                    taxTotal = taxTotal + Val(.Cells(cTaxAmount).Value)
                    discountTotal = discountTotal + Val(.Cells(cDiscountAmount).Value)
                    totalAmount = totalAmount + (Val(.Cells(cPricePurchase).Value) * Val(.Cells(cPurchaseQuantity).Value))
                End With
            Next

            TxtTotalAmountPurchase.Text = Format(totalAmount, "0.00")
            TxtTaxTotalPurchase.Text = Format(taxTotal, "0.00")
            TxtDiscountTotalPurchase.Text = Format(discountTotal, "0.00")

            Dim temp As Double = totalAmount + taxTotal - discountTotal
            netAmount = GetSqlRound(Me.Name, temp)

            TxtRoundOffPurchase.Text = Format(netAmount - temp, "0.00")
            TxtNetAmountPurchase.Text = Format(netAmount, "0.00")

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub SetPurchaseObject(ByRef purchaseObj As ClsPurchaseMaster)
        Try
            lPurchaseObj = purchaseObj
            If lPurchaseObj Is Nothing Then
                TxtPurchaseCode.Text = ""
                DtPkrPurchaseDate.Value = Now.Date
                DtPkrReturnDate.Value = Now.Date
                TxtPurchaseReturnCode.Text = ""
                CmbVendor.Text = ""
                TxtRemark.Text = ""
            Else
                With lPurchaseObj
                    TxtPurchaseCode.Text = .Id
                    DtPkrPurchaseDate.Value = .PurchaseDate
                    CmbVendor.Text = GetVendorName(.VendorId)
                    TxtRemark.Text = .Remark
                End With
            End If

            LoadGridValuesForPurchaseDetail()
            LoadComboBoxValuesForItems()
            CalculateTotalsForPurchaseItems()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Function GetVendorName(ByVal id As Integer) As String
        Dim result As String = ""
        Try
            Dim vendor As ClsVendorMaster
            For Each vendor In CmbVendor.Items
                If vendor.Id = id Then
                    result = vendor.Name
                    Exit For
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Sub LoadGridValuesForPurchaseItemsReturn()
        Try
            GrdItemsPurchaseReturn.Rows.Clear()

            If lPurchaseReturnObj Is Nothing Then Exit Try

            Dim purchaseReturnDetails() As ClsPurchaseReturnDetail = GetAllPurchaseReturnDetailForPurchaseReturnId(Me.Name, lPurchaseReturnObj.Id)
            If purchaseReturnDetails Is Nothing Then Exit Try

            Dim purchaseReturnDetail As ClsPurchaseReturnDetail
            For Each purchaseReturnDetail In purchaseReturnDetails
                InsertIntoPurchaseItemReturnGrid(purchaseReturnDetail)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub InsertIntoPurchaseItemReturnGrid(ByRef purchasesReturnDetailObj As ClsPurchaseReturnDetail)
        Try
            If purchasesReturnDetailObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdItemsPurchaseReturn.Rows.Add
            With GrdItemsPurchaseReturn.Rows(rowIndex)
                .Cells(cId).Value = purchasesReturnDetailObj.Id
                .Cells(cItemId).Value = purchasesReturnDetailObj.ItemId
                .Cells(cStorageId).Value = purchasesReturnDetailObj.StorageId
                .Cells(cBatch).Value = purchasesReturnDetailObj.Batch
                .Cells(cExpiryDate).Value = purchasesReturnDetailObj.ExpiryDate
                .Cells(cReturnQuantity).Value = purchasesReturnDetailObj.ReturnQuantity
                .Cells(cPricePurchase).Value = purchasesReturnDetailObj.PricePurchase
                .Cells(cPackQuantity).Value = purchasesReturnDetailObj.PackQuantity
                .Cells(cTaxPercent).Value = purchasesReturnDetailObj.TaxPercent
                .Cells(cTaxAmount).Value = purchasesReturnDetailObj.TaxAmount
                .Cells(cDiscountPercent).Value = purchasesReturnDetailObj.DiscountPercent
                .Cells(cDiscountAmount).Value = purchasesReturnDetailObj.DiscountAmount
                .Cells(cTotal).Value = purchasesReturnDetailObj.GetTotal
                .Cells(cStorage).Value = GetStorageName(.Cells(cStorageId).Value)
                .Cells(cName).Value = GetItemName(.Cells(cItemId).Value)
                .Cells(cFreeQuantity).Value = purchasesReturnDetailObj.FreeQuantity
                .Cells(cPriceSale).Value = purchasesReturnDetailObj.PriceSale
                .Cells(cRemark).Value = purchasesReturnDetailObj.Remark
                .Cells(cPurchaseReturnId).Value = purchasesReturnDetailObj.PurchaseReturnId
                .Cells(cUserId).Value = purchasesReturnDetailObj.UserId
                .Cells(cDateOn).Value = purchasesReturnDetailObj.DateOn
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadStorages()
        Try
            lStorages = GetAllStorageMaster(Me.Name)

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadItems()
        Try
            lItems = GetAllItemMaster(Me.Name, True)

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Function GetStorageName(ByVal id As Integer) As String
        Dim result As String = ""
        Try
            If lStorages Is Nothing Then Exit Try

            Dim storage As ClsStorageMaster
            For Each storage In lStorages
                If storage.Id = id Then
                    result = storage.Name
                    Exit Try
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Sub LoadComboBoxValues()
        With CmbTaxType.Items
            .Clear()
            .Add(cTypeAmountRs)
            .Add(cTypePercentage)
        End With

        CmbTaxType.Text = cTypePercentage

        With CmbDiscountType.Items
            .Clear()
            .Add(cTypeAmountRs)
            .Add(cTypePercentage)
        End With

        CmbDiscountType.Text = cTypePercentage

        LoadComboBoxValuesForVendors()
        LoadComboBoxValuesForBatch()
    End Sub

    Private Sub LoadComboBoxValuesForVendors()
        Try
            CmbVendor.Items.Clear()

            Dim vendors() As ClsVendorMaster = GetAllVendorMaster(Me.Name)
            If vendors Is Nothing Then Exit Try

            CmbVendor.DisplayMember = cName
            CmbVendor.ValueMember = cId
            Dim vendor As ClsVendorMaster
            For Each vendor In vendors
                CmbVendor.Items.Add(vendor)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadComboBoxValuesForItems()
        Try
            CmbItem.DataSource = Nothing
            CmbItem.Items.Clear()
            CmbItem.Text = ""

            Dim ids As String = GetItemIdsFromPurchaseGrid()
            If ids.Trim = "" Then Exit Try

            Dim items() As ClsItemMaster = GetAllItemMaster(Me.Name, ids, False)
            If items Is Nothing Then Exit Try

            CmbItem.DataSource = items
            CmbItem.DisplayMember = cName
            CmbItem.ValueMember = cId
            CmbItem.Text = ""

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Function GetItemIdsFromPurchaseGrid() As String
        Dim result As String = ""
        Try
            If GrdItemsPurchase.Rows.Count = 0 Then Exit Try

            Dim row As DataGridViewRow
            For Each row In GrdItemsPurchase.Rows
                If result.Trim <> "" Then result = result + ","

                result = result + CStr(row.Cells(cItemId).Value)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Sub LoadComboBoxValuesForBatch()
        Try
            'CmbBatch.DataSource = Nothing
            'CmbBatch.Items.Clear()
            'CmbBatch.Text = ""

            Dim currentStocks() As ClsCurrentStock = GetAllCurrentStock(Me.Name, True)
            If currentStocks Is Nothing Then Exit Try

            lCurrentBatch = currentStocks(0)

            'CmbBatch.DataSource = currentStocks
            'CmbBatch.DisplayMember = cBatch
            'CmbBatch.ValueMember = cId
            'CmbBatch.Text = ""

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub CalculateTotalsForPurchaseItemsReturn()
        Try
            TxtTotalReturn.Text = "0"
            TxtTaxReturn.Text = "0"
            TxtDiscountReturn.Text = "0"
            TxtRoundOffReturn.Text = "0"
            TxtNetAmountReturn.Text = "0"

            If GrdItemsPurchaseReturn.Rows.Count = 0 Then Exit Try

            Dim totalAmount As Double = 0
            Dim taxTotal As Double = 0
            Dim discountTotal As Double = 0
            Dim roundOff As Double = 0
            Dim netAmount As Double = 0

            Dim row As DataGridViewRow
            For Each row In GrdItemsPurchaseReturn.Rows
                With row
                    taxTotal = taxTotal + Val(.Cells(cTaxAmount).Value)
                    discountTotal = discountTotal + Val(.Cells(cDiscountAmount).Value)
                    totalAmount = totalAmount + (Val(.Cells(cPricePurchase).Value) * Val(.Cells(cReturnQuantity).Value))
                End With
            Next

            TxtTotalReturn.Text = Format(totalAmount, "0.00")
            TxtTaxReturn.Text = Format(taxTotal, "0.00")
            TxtDiscountReturn.Text = Format(discountTotal, "0.00")

            Dim temp As Double = totalAmount + taxTotal - discountTotal
            netAmount = GetSqlRound(Me.Name, temp)

            TxtRoundOffReturn.Text = Format(netAmount - temp, "0.00")
            TxtNetAmountReturn.Text = Format(netAmount, "0.00")

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub CalculateTotal(Optional ByRef taxAmount As Double = 0, Optional ByRef discountAmount As Double = 0)
        Try
            If TxtReturnQuantity.Text.Trim = "" Then Exit Try
            If TxtPurchasePrice.Text.Trim = "" Then Exit Try
            If TxtDiscount.Text.Trim = "" Then Exit Try
            If TxtTax.Text.Trim = "" Then Exit Try

            Dim returnQuantity As Double = Val(TxtReturnQuantity.Text)
            Dim purchasePrice As Double = Val(TxtPurchasePrice.Text)
            Dim total As Double = purchasePrice * returnQuantity

            If CmbTaxType.Text = cTypePercentage Then
                Dim tempTaxPercent As Double = Val(TxtTax.Text)
                taxAmount = (total * tempTaxPercent) / 100
            Else
                taxAmount = Val(TxtTax.Text)
            End If

            'Adding tax in total
            total = total + taxAmount

            If CmbDiscountType.Text = cTypePercentage Then
                Dim tempDiscountPercent As Double = Val(TxtDiscount.Text)
                discountAmount = (total * tempDiscountPercent) / 100
            Else
                discountAmount = Val(TxtDiscount.Text)
            End If

            'Deducting discount
            total = total - discountAmount

            TxtTotal.Text = Format(total, "0.00")

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub CalculateTotalQuantity()
        Try
            If TxtPackQty.Text.Trim = "" Then Exit Try
            If TxtReturnQuantity.Text.Trim = "" Then Exit Try
            If TxtFreeQuantity.Text.Trim = "" Then Exit Try

            Dim packQty As Double = Val(TxtPackQty.Text)
            Dim returnQty As Double = Val(TxtReturnQuantity.Text)
            Dim freeQty As Double = Val(TxtFreeQuantity.Text)
            Dim total As Double = 0

            total = packQty * returnQty + packQty * freeQty

            TxtTotalQunatity.Text = total

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub SetObjectsForCurrentLogin()
        Try
            SetPurchaseObject(Nothing)
            lPurchaseReturnObj = Nothing

            Dim PurchaseReturnMaster As ClsPurchaseReturnMaster = GetPurchaseReturnMasterNotClosedForLogin(Me.Name, gUser.LoginName)
            If PurchaseReturnMaster Is Nothing Then Exit Try

            Dim purchaseMaster As ClsPurchaseMaster = GetPurchaseMaster(Me.Name, PurchaseReturnMaster.PurchaseId)
            If purchaseMaster Is Nothing Then Exit Try

            SetPurchaseObject(purchaseMaster)
            lPurchaseReturnObj = PurchaseReturnMaster
            TxtPurchaseCode.Enabled = False

            With PurchaseReturnMaster
                With PurchaseReturnMaster
                    TxtPurchaseReturnCode.Text = .PurchaseReturnCode
                    DtPkrReturnDate.Value = .ReturnDate
                    TxtRemark.Text = .Remark
                End With
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub ResetControlsToAddNewItem()
        editRow = Nothing

        CmbItem.Text = ""
        'CmbBatch.Text = ""
        TxtPackQty.Text = "0"
        TxtReturnQuantity.Text = "0"
        TxtPackSize.Text = "0"
        TxtFreeQuantity.Text = "0"
        TxtTotalQunatity.Text = "0"
        TxtPurchasePrice.Text = "0"
        TxtTax.Text = "0"
        CmbTaxType.Text = cTypePercentage
        TxtDiscount.Text = "0"
        CmbDiscountType.Text = cTypePercentage
        TxtTotal.Text = "0"

        BtnAdd.Text = "&Add"
        BtnNew.Text = "&New"
        BtnAdd.Enabled = True
        BtnRemove.Enabled = False

        CmbItem.Focus()
    End Sub

    Private Sub ResetControlsToAddNew()
        TxtPurchaseCode.Text = ""
        DtPkrPurchaseDate.Value = Now.Date
        DtPkrReturnDate.Value = Now.Date
        TxtPurchaseReturnCode.Text = ""
        CmbVendor.Text = ""
        TxtRemark.Text = ""

        TxtTotalAmountPurchase.Text = "0"
        TxtTaxTotalPurchase.Text = "0"
        TxtDiscountTotalPurchase.Text = "0"
        TxtRoundOffPurchase.Text = "0"
        TxtNetAmountPurchase.Text = "0"
        TxtTotalReturn.Text = "0"
        TxtTaxReturn.Text = "0"
        TxtDiscountReturn.Text = "0"
        TxtRoundOffReturn.Text = "0"
        TxtNetAmountReturn.Text = "0"

        flagPurchaseCodeChanged = False

        TxtPurchaseCode.Enabled = True
        GrdItemsPurchase.Rows.Clear()
        GrdItemsPurchaseReturn.Rows.Clear()
        lPurchaseObj = Nothing
        lPurchaseReturnObj = Nothing
        ResetControlsToAddNewItem()

        DtPkrReturnDate.Focus()
    End Sub

    Private Function ValidateValues() As Boolean
        Dim result As Boolean = False
        Try
            RemoveErrorIcon()

            If TxtPurchaseCode.Text.Trim = "" Then
                ErrorInData("Please enter purchase code.", TxtPurchaseCode)
                Exit Try
            End If

            If CmbVendor.Text.Trim = "" Then
                ErrorInData("Please select Vendor.", CmbVendor)
                Exit Try
            End If

            If CmbVendor.FindStringExact(CmbVendor.Text.Trim) < 0 Then
                ErrorInData("Please select valid vendor from vendor list.", CmbVendor)
                Exit Try
            End If

            If CmbItem.Text.Trim = "" Then
                ErrorInData("Please select item.", CmbItem)
                Exit Try
            End If

            If CmbItem.FindStringExact(CmbItem.Text.Trim) < 0 Then
                ErrorInData("Please select valid item from item list.", CmbItem)
                Exit Try
            End If

            'If CmbBatch.Text.Trim = "" Then
            '    ErrorInData("Please enter batch.", CmbBatch)
            '    Exit Try
            'End If

            'If CmbBatch.FindStringExact(CmbBatch.Text.Trim) < 0 Then
            '    ErrorInData("Please select valid Batch from Batch list.", CmbBatch)
            '    Exit Try
            'End If

            If TxtPackQty.Text.Trim = "" Then
                ErrorInData("Pack size should not be blank.", TxtPackQty)
                Exit Try
            End If

            If Val(TxtPackQty.Text) <= 0 Then
                ErrorInData("Pack size should be greater then 0.", TxtPackQty)
                Exit Try
            End If

            If TxtReturnQuantity.Text.Trim = "" Then
                ErrorInData("Please enter purchase return quantity.", TxtReturnQuantity)
                Exit Try
            End If

            If Val(TxtReturnQuantity.Text) <= 0 Then
                ErrorInData("Please enter purchase return quantity greater then 0.", TxtReturnQuantity)
                Exit Try
            End If

            If TxtPurchasePrice.Text.Trim = "" Then
                ErrorInData("Please enter purchase price.", TxtPurchasePrice)
                Exit Try
            End If

            If Val(TxtPurchasePrice.Text) <= 0 Then
                ErrorInData("Please enter purchase price greater then 0.", TxtPurchasePrice)
                Exit Try
            End If

            If TxtTax.Text.Trim = "" Then
                ErrorInData("Please enter tax.", TxtTax)
                Exit Try
            End If

            If TxtDiscount.Text.Trim = "" Then
                ErrorInData("Please enter discount.", TxtDiscount)
                Exit Try
            End If

            Dim itemId As Integer = GetSelectedItemId(CmbItem)
            Dim batch As String = cBatchDefault 'CmbBatch.Text
            Dim row As DataGridViewRow = GetRowForValues(GrdItemsPurchase, itemId, batch)
            If Not (row Is Nothing) Then
                If row.Cells(cPurchaseQuantity).Value < Val(TxtReturnQuantity.Text) Then
                    ErrorInData("Quantity is more then the purchase quantity.", TxtReturnQuantity)
                    Exit Try
                End If
            End If

            result = True

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Sub UpdatePurchaseReturnDetailObject()
        Try
            If lPurchaseReturnObj Is Nothing Then
                MsgBox("Purchase Return Code doesn't found. Unable to Update.", MsgBoxStyle.Critical, "Error")
                Exit Sub
            End If

            If editRow Is Nothing Then Exit Try

            If ValidateValues() = False Then Exit Sub

            Dim currentStock As ClsCurrentStock = lCurrentBatch 'GetSelectedItem(CmbBatch)
            If currentStock Is Nothing Then Exit Try

            'Updating Detail
            Dim purchaseReturnDetailObj As New ClsPurchaseReturnDetail
            With purchaseReturnDetailObj
                .Id = editRow.Cells(cId).Value
                .PurchaseReturnId = editRow.Cells(cPurchaseReturnId).Value
                .ItemId = GetSelectedItemId(CmbItem)
                .PricePurchase = Val(TxtPurchasePrice.Text)
                .ReturnQuantity = Val(TxtReturnQuantity.Text)
                .FreeQuantity = Val(TxtFreeQuantity.Text)

                If CmbTaxType.Text = cTypePercentage Then
                    .TaxPercent = Val(TxtTax.Text)
                End If

                If CmbDiscountType.Text = cTypePercentage Then
                    .DiscountPercent = Val(TxtDiscount.Text)
                End If

                .Batch = currentStock.Batch
                .ExpiryDate = currentStock.ExpiryDate
                .PriceSale = 0 'currentStock.PriceSale
                .PackQuantity = currentStock.PackQuantity
                .StorageId = currentStock.StorageId
                .Remark = TxtRemark.Text
                .UserId = gUser.LoginName
                .DateOn = Now
                CalculateTotal(.TaxAmount, .DiscountAmount)
            End With

            If UpdatePurchaseReturnDetail(Me.Name, purchaseReturnDetailObj) <> EnResult.Change Then Exit Sub

            With editRow
                .Cells(cItemId).Value = purchaseReturnDetailObj.ItemId
                .Cells(cStorageId).Value = purchaseReturnDetailObj.StorageId
                .Cells(cBatch).Value = purchaseReturnDetailObj.Batch
                .Cells(cExpiryDate).Value = purchaseReturnDetailObj.ExpiryDate
                .Cells(cReturnQuantity).Value = purchaseReturnDetailObj.ReturnQuantity
                .Cells(cPricePurchase).Value = purchaseReturnDetailObj.PricePurchase
                .Cells(cPackQuantity).Value = purchaseReturnDetailObj.PackQuantity
                .Cells(cFreeQuantity).Value = purchaseReturnDetailObj.FreeQuantity
                .Cells(cTaxPercent).Value = purchaseReturnDetailObj.TaxPercent
                .Cells(cTaxAmount).Value = purchaseReturnDetailObj.TaxAmount
                .Cells(cDiscountPercent).Value = purchaseReturnDetailObj.DiscountPercent
                .Cells(cDiscountAmount).Value = purchaseReturnDetailObj.DiscountAmount
                .Cells(cTotal).Value = purchaseReturnDetailObj.GetTotal
                .Cells(cStorage).Value = GetStorageName(.Cells(cStorageId).Value)
                .Cells(cName).Value = GetItemName(.Cells(cItemId).Value)
                .Cells(cPriceSale).Value = purchaseReturnDetailObj.PriceSale
                .Cells(cRemark).Value = purchaseReturnDetailObj.Remark
                .Cells(cUserId).Value = purchaseReturnDetailObj.UserId
                .Cells(cDateOn).Value = purchaseReturnDetailObj.DateOn
            End With

            CalculateTotalsForPurchaseItemsReturn()
            lPurchaseReturnObj.NotClosed = True
            MsgBox("Successfully Updated", , "Updated")

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNewItem()
    End Sub

    Private Sub SetPurchaseReturnForPurchaseReturnId(ByVal id As Long)
        Try
            SetPurchaseObject(Nothing)
            lPurchaseReturnObj = Nothing

            If id <= 0 Then Exit Try

            Dim purchaseReturnMaster As ClsPurchaseReturnMaster = GetPurchaseReturnMasterById(Me.Name, id)
            If purchaseReturnMaster Is Nothing Then Exit Try

            Dim purchaseMaster As ClsPurchaseMaster = GetPurchaseMaster(Me.Name, purchaseReturnMaster.PurchaseId)
            If purchaseMaster Is Nothing Then Exit Try

            lPurchaseReturnObj = purchaseReturnMaster
            SetPurchaseObject(purchaseMaster)
            TxtPurchaseCode.Enabled = False

            With purchaseReturnMaster
                TxtPurchaseReturnCode.Text = .PurchaseReturnCode
                DtPkrReturnDate.Value = .ReturnDate
                TxtRemark.Text = .Remark
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        LoadGridValuesForPurchaseItemsReturn()
        CalculateTotalsForPurchaseItemsReturn()
    End Sub

#End Region

End Class
