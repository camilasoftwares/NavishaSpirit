Imports System.Windows.Forms
Imports AIMS.Author

Public Class FrmPurchaseReturnPartywise

#Region "Private Variables"

    Dim lStorages() As ClsStorageMaster = Nothing
    Dim lItems() As ClsItemMaster = Nothing
    Dim lPurchase() As ClsPurchaseMaster = Nothing
    Dim lPurchaseReturnObj As ClsPurchaseReturnMaster = Nothing
    Dim currentRow As DataGridViewRow = Nothing
    Dim editRow As DataGridViewRow = Nothing
    Dim flagOldObject As Boolean = False

    Private Const lcUpdate As String = "&Update"
    Private Const lcCancel As String = "Cance&l"

#End Region

#Region "Control Functions"

    Private Sub Help(ByVal sender As Object, ByVal hlpEvent As System.Windows.Forms.HelpEventArgs) Handles MyBase.HelpRequested
        Try
            Dim obj As Object = Me.Owner
            obj.ShowHelp()
        Catch ex As Exception
        End Try

        hlpEvent.Handled = True
    End Sub

    Private Sub FrmPurchaseReturnPartywise_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not (lPurchaseReturnObj Is Nothing) Then
            If lPurchaseReturnObj.NotClosed = True Then
                If MsgBox("Purchase Return Master is not updated." + vbCrLf + vbCrLf + "To update click save button." + vbCrLf + vbCrLf + "Do you want to update Purchase Return master?", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub FrmPurchaseReturnPartywise_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

    Private Sub BtnSearchPurchase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearchPurchase.Click
        LoadGridValuesForPurchaseItems()
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
                    flagOldObject = True
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

            Dim purchaseReturnId As Long = lPurchaseReturnObj.Id
            Dim ds As DataSet = GetPurchaseReturn(Me.Name, purchaseReturnId)

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
            If flagOldObject = False Then
                If AndedTheString(gUser.AuthorizationNo, Authorization.PurchaseReturn_Current_NoUpdate) = True Then Exit Sub
            Else
                If AndedTheString(gUser.AuthorizationNo, Authorization.PurchaseReturn_Old_NoUpdate) = True Then Exit Sub
            End If

            'Updating Master
            Dim purchaseReturnMasterObj As New ClsPurchaseReturnMaster
            With purchaseReturnMasterObj
                .Id = lPurchaseReturnObj.Id
                .PurchaseId = lPurchaseReturnObj.PurchaseId
                .PurchaseReturnCode = lPurchaseReturnObj.PurchaseReturnCode
                .VendorId = GetSelectedItemId(CmbVendor)
                .DiscountAmount = Val(TxtDiscountOnBillReturn.Text)
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

    Private Sub BtnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemove.Click
        Try
            Dim row As DataGridViewRow = GrdItemsReturn.SelectedRows(0)
            If row Is Nothing Then Exit Try

            If flagOldObject = False Then
                If AndedTheString(gUser.AuthorizationNo, Authorization.PurchaseReturn_Current_NoRemove) = True Then Exit Sub
            Else
                If AndedTheString(gUser.AuthorizationNo, Authorization.PurchaseReturn_Old_NoRemove) = True Then Exit Sub
            End If

            Dim id As Long = row.Cells(cId).Value
            If id <= 0 Then Exit Try

            If MsgBox("Do you really wants to remove selected record? Removed records can't be recovered.", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                If DeletePurchaseReturnDetail(Me.Name, id) <> EnResult.Change Then Exit Sub

                GrdItemsReturn.Rows.Remove(row)
                lPurchaseReturnObj.NotClosed = True
                CalculateTotalsForPurchaseItemsReturn()
                MsgBox("Successfully Removed", , "Removed")
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNewItem()
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Try
            If BtnAdd.Text = lcUpdate Then
                UpdatePurchaseReturnDetailObject()
                Exit Sub
            End If

            If flagOldObject = False Then
                If AndedTheString(gUser.AuthorizationNo, Authorization.PurchaseReturn_Current_NoAdd) = True Then Exit Sub
            Else
                If AndedTheString(gUser.AuthorizationNo, Authorization.PurchaseReturn_Old_NoAdd) = True Then Exit Sub
            End If

            If ValidateValues() = False Then Exit Sub

            'Saving Master if virtual
            If lPurchaseReturnObj Is Nothing Then
                Dim purchaseReturnMasterObj As New ClsPurchaseReturnMaster
                With purchaseReturnMasterObj
                    .VendorId = GetSelectedItemId(CmbVendor)
                    .DiscountAmount = Val(TxtDiscountOnBillReturn.Text)
                    .Mode = cStatusCredit   'lPurchaseObj.Mode
                    .Remark = TxtRemark.Text
                    .ReturnDate = DtPkrReturnDate.Value
                    .PurchaseId = cInvalidId 'TxtPurchaseCode.Text
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
                .PurchaseId = currentRow.Cells(cPurchaseId).Value
                .PurchaseReturnId = lPurchaseReturnObj.Id
                Dim item As ClsItemMaster = CmbItem.SelectedItem
                .ItemId = item.Id
                .Batch = currentRow.Cells(cBatch).Value
                .ExpiryDate = currentRow.Cells(cExpiryDate).Value
                .PackQuantity = currentRow.Cells(cPackQuantity).Value
                .PricePurchase = currentRow.Cells(cPricePurchase).Value
                .PricePurchase = Val(TxtPurchasePrice.Text)
                .DiscountPercent = currentRow.Cells(cDiscountPercent).Value
                .ReturnQuantity = Val(TxtQuantity.Text)
                .NonSaleable = ChkNonSaleable.Checked
                .StorageId = currentRow.Cells(cStorageId).Value
                .Remark = TxtRemark.Text
                .UserId = gUser.LoginName
                .DateOn = Now
                .TaxAmount = currentRow.Cells(cTaxAmount).Value
                .DiscountAmount = currentRow.Cells(cDiscountAmount).Value
                Dim purchaseObj As ClsPurchaseMaster = GetPurchaseObj(currentRow.Cells(cPurchaseId).Value)
                If purchaseObj IsNot Nothing Then
                    .TaxPercent = purchaseObj.TaxPercent
                End If
            End With

            Dim id As Long = InsertPurchaseReturnDetail(Me.Name, purchaseReturnDetailObj)
            If id > 0 Then
                purchaseReturnDetailObj.Id = id
                InsertIntoPurchaseItemReturnGrid(purchaseReturnDetailObj)
                CalculateTotalsForPurchaseItemsReturn()
                lPurchaseReturnObj.NotClosed = True
                CmbVendor.Enabled = False

                MsgBox("Successfully Added", , "Added")
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNewItem()
    End Sub

    Private Sub TxtDiscountOnBillReturn_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDiscountOnBillReturn.TextChanged
        CalculateTotalsForPurchaseItemsReturn()
    End Sub

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtTotalReturn.KeyDown, TxtPurchaseReturnCode.KeyDown, TxtPurchasePrice.KeyDown, TxtRoundOffReturn.KeyDown, TxtRemark.KeyDown, TxtQuantity.KeyDown, TxtNetAmountReturn.KeyDown, TxtDiscountOnBillReturn.KeyDown, DtPkrReturnDate.KeyDown, CmbItem.KeyDown, CmbPurchases.KeyDown, CmbVendor.KeyDown, ChkNonSaleable.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub DecimalKeyPressEvent(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTotalReturn.KeyPress, TxtPurchasePrice.KeyPress, TxtRoundOffReturn.KeyPress, TxtQuantity.KeyPress, TxtNetAmountReturn.KeyPress, TxtDiscountOnBillReturn.KeyPress
        e.Handled = Check_DecimalAllow(e.KeyChar, sender.text)
    End Sub

    Private Sub GrdInvoiceDetail_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdInvoiceDetail.CellClick
        Try
            currentRow = Nothing
            If e.RowIndex < 0 Then Exit Try

            currentRow = GrdInvoiceDetail.Rows(e.RowIndex)

            Dim purchaseId As Long = currentRow.Cells(cPurchaseId).Value
            Dim itemId As Integer = currentRow.Cells(cItemId).Value
            'TxtBatchReturn.Text = currentRow.Cells(cBatch).Value
            TxtQuantity.Text = currentRow.Cells(cPurchaseQuantity).Value
            TxtPurchasePrice.Text = currentRow.Cells(cPricePurchase).Value

            LoadComboBoxValuesForInvoices(purchaseId)
            LoadComboBoxValuesForItems(itemId)

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub GrdItemsReturn_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdItemsReturn.CellClick
        Try
            If e.RowIndex < 0 Then Exit Try
            If flagOldObject = False Then
                If AndedTheString(gUser.AuthorizationNo, Authorization.PurchaseReturn_Current_NoRemove) = True Then Exit Sub
            Else
                If AndedTheString(gUser.AuthorizationNo, Authorization.PurchaseReturn_Old_NoRemove) = True Then Exit Sub
            End If

            BtnRemove.Enabled = True
            BtnAdd.Enabled = False
            BtnNew.Text = lcCancel

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub GrdItemsReturn_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdItemsReturn.CellDoubleClick
        Try
            BtnRemove.Enabled = False
            If e.RowIndex < 0 Then Exit Try
            If flagOldObject = False Then
                If AndedTheString(gUser.AuthorizationNo, Authorization.PurchaseReturn_Current_NoUpdate) = True Then Exit Sub
            Else
                If AndedTheString(gUser.AuthorizationNo, Authorization.PurchaseReturn_Old_NoUpdate) = True Then Exit Sub
            End If

            editRow = GrdItemsReturn.Rows(e.RowIndex)
            With editRow
                Dim purchaseId As Long = .Cells(cPurchaseId).Value
                Dim itemId As Integer = .Cells(cItemId).Value
                'TxtBatchReturn.Text = .Cells(cBatch).Value
                TxtQuantity.Text = .Cells(cReturnQuantity).Value
                TxtPurchasePrice.Text = .Cells(cPricePurchase).Value
                ChkNonSaleable.Checked = .Cells(cNonSaleable).Value

                LoadComboBoxValuesForInvoices(purchaseId)
                LoadComboBoxValuesForItems(itemId)
            End With

            BtnAdd.Text = lcUpdate
            BtnNew.Text = lcCancel
            BtnAdd.Enabled = True
            TxtQuantity.Focus()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub TabKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdItemsReturn.KeyDown, GrdInvoiceDetail.KeyDown
        If e.KeyCode = Keys.Tab Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

#End Region

#Region "Private Functions"

    Private Sub SetControls()
        SetGridInvoiceDetail()
        SetGridItemsReturn()

        LoadStorages()
        LoadItems()
        LoadPurchase()

        LoadComboBoxValuesForVendor()

        ''Load Grid values after ComboBox Values
        SetObjectsForCurrentLogin()
        LoadGridValuesForPurchaseItemsReturn()
        CalculateTotalsForPurchaseItemsReturn()
    End Sub

    Private Sub SetGridInvoiceDetail()
        With GrdInvoiceDetail
            Dim colCount As Integer = 20
            .RowHeadersVisible = False
            Dim defaultCellWidth As Integer = 80
            Dim x As Integer
            For x = 0 To colCount
                Select Case x
                    Case 0
                        Dim index As Integer = .Columns.Add(cPurchaseCode, "Pur. Code")
                        .Columns(index).Width = defaultCellWidth + 50

                    Case 1
                        Dim index As Integer = .Columns.Add(cName, cName)
                        .Columns(index).Width = defaultCellWidth + 100

                    Case 2
                        Dim index As Integer = .Columns.Add(cBatch, cBatch)
                        .Columns(index).Width = defaultCellWidth + 50
                        .Columns(index).Visible = False

                    Case 3
                        Dim index As Integer = .Columns.Add(cExpiryDate, "Exp. Date")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "MMM-yyyy"

                    Case 4
                        Dim index As Integer = .Columns.Add(cPurchaseQuantity, "Pur. Qty")
                        .Columns(index).Width = defaultCellWidth
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
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns(index).Visible = False

                    Case 8
                        Dim index As Integer = .Columns.Add(cTaxAmount, "Tax")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns(index).Visible = False

                    Case 9
                        Dim index As Integer = .Columns.Add(cDiscountPercent, "Dis. %")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns(index).Visible = False

                    Case 10
                        Dim index As Integer = .Columns.Add(cDiscountAmount, "Discount")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns(index).Visible = False

                    Case 11
                        Dim index As Integer = .Columns.Add(cStorage, cStorage)
                        .Columns(index).Width = defaultCellWidth

                    Case 12
                        'Dim index As Integer = .Columns.Add(cTotal, cTotal)
                        '.Columns(index).Width = defaultCellWidth
                        '.Columns(index).DefaultCellStyle.Format = "0.00"
                        '.Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 13
                        Dim index As Integer = .Columns.Add(cItemId, cItemId)
                        .Columns(index).Visible = False

                    Case 14
                        Dim index As Integer = .Columns.Add(cStorageId, cStorageId)
                        .Columns(index).Visible = False

                    Case 15
                        Dim index As Integer = .Columns.Add(cPurchaseId, cPurchaseId)
                        .Columns(index).Visible = False

                    Case 16
                        Dim index As Integer = .Columns.Add(cPriceSale, cPriceSale)
                        .Columns(index).Visible = False

                    Case 17
                        Dim index As Integer = .Columns.Add(cRemark, cRemark)
                        .Columns(index).Visible = False

                    Case 18
                        Dim index As Integer = .Columns.Add(cForCashOut, cForCashOut)
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

    Private Sub SetGridItemsReturn()
        With GrdItemsReturn
            Dim colCount As Integer = 21
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
                        .Columns(index).Width = defaultCellWidth + 100

                    Case 2
                        Dim index As Integer = .Columns.Add(cBatch, cBatch)
                        .Columns(index).Width = defaultCellWidth + 30
                        .Columns(index).Visible = False

                    Case 3
                        Dim index As Integer = .Columns.Add(cExpiryDate, "Exp. Date")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "MMM-yyyy"

                    Case 4
                        Dim index As Integer = .Columns.Add(cReturnQuantity, "Return Qty")
                        .Columns(index).Width = defaultCellWidth + 20
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
                        .Columns(index).Visible = False

                    Case 8
                        Dim index As Integer = .Columns.Add(cTaxAmount, "Tax")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns(index).Visible = False

                    Case 9
                        Dim index As Integer = .Columns.Add(cDiscountPercent, "Dis. %")
                        .Columns(index).Width = defaultCellWidth - 10
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns(index).Visible = False

                    Case 10
                        Dim index As Integer = .Columns.Add(cDiscountAmount, "Discount")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns(index).Visible = False

                    Case 11
                        Dim index As Integer = .Columns.Add(cStorage, cStorage)
                        .Columns(index).Width = defaultCellWidth

                    Case 12
                        Dim index As Integer = .Columns.Add(cTotal, cTotal)
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 13
                        Dim index As Integer = .Columns.Add(cItemId, cItemId)
                        .Columns(index).Visible = False

                    Case 14
                        Dim index As Integer = .Columns.Add(cStorageId, cStorageId)
                        .Columns(index).Visible = False

                    Case 15
                        Dim index As Integer = .Columns.Add(cPurchaseId, cPurchaseId)
                        .Columns(index).Visible = False

                    Case 16
                        Dim index As Integer = .Columns.Add(cPriceSale, cPriceSale)
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

                    Case 21
                        Dim index As Integer = .Columns.Add(cNonSaleable, "Non Saleable")
                        .Columns(index).Width = defaultCellWidth + 20

                End Select
            Next
        End With
    End Sub

    Private Sub LoadComboBoxValuesForVendor()
        Try
            With CmbVendor
                .DataSource = GetAllVendorMaster(Me.Name)
                .DisplayMember = cName
                .ValueMember = cId
                If .Items.Count > 0 Then .SelectedIndex = 0
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadComboBoxValuesForInvoices(ByVal id As Long)
        Try
            With CmbPurchases
                .DataSource = Nothing
                .Items.Clear()
                .Text = ""

                Dim purchase As ClsPurchaseMaster = GetPurchaseMaster(Me.Name, id)
                Dim purchaseList As New List(Of ClsPurchaseMaster)
                purchaseList.Add(purchase)

                .DataSource = purchaseList
                .DisplayMember = cPurchaseCode
                .ValueMember = cId
                If .Items.Count > 0 Then .SelectedIndex = 0
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadComboBoxValuesForItems(ByVal id As Integer)
        Try
            With CmbItem
                .DataSource = Nothing
                .Items.Clear()
                .Text = ""

                Dim item As ClsItemMaster = GetItemMaster(id)
                Dim itemsList As New List(Of ClsItemMaster)
                itemsList.Add(item)

                .DataSource = itemsList
                .DisplayMember = cName
                .ValueMember = cId
                If .Items.Count > 0 Then .SelectedIndex = 0
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadGridValuesForPurchaseItemsReturn()
        Try
            GrdItemsReturn.Rows.Clear()

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

    Private Sub InsertIntoPurchaseItemReturnGrid(ByRef purchaseReturnDetailObj As ClsPurchaseReturnDetail)
        Try
            If purchaseReturnDetailObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdItemsReturn.Rows.Add
            With GrdItemsReturn.Rows(rowIndex)
                .Cells(cId).Value = purchaseReturnDetailObj.Id
                .Cells(cItemId).Value = purchaseReturnDetailObj.ItemId
                .Cells(cStorageId).Value = purchaseReturnDetailObj.StorageId
                .Cells(cBatch).Value = purchaseReturnDetailObj.Batch
                .Cells(cExpiryDate).Value = purchaseReturnDetailObj.ExpiryDate
                .Cells(cReturnQuantity).Value = purchaseReturnDetailObj.ReturnQuantity
                .Cells(cPricePurchase).Value = purchaseReturnDetailObj.PricePurchase
                .Cells(cPackQuantity).Value = purchaseReturnDetailObj.PackQuantity
                .Cells(cTaxPercent).Value = purchaseReturnDetailObj.TaxPercent
                .Cells(cTaxAmount).Value = purchaseReturnDetailObj.TaxAmount
                .Cells(cDiscountPercent).Value = purchaseReturnDetailObj.DiscountPercent
                .Cells(cDiscountAmount).Value = purchaseReturnDetailObj.DiscountAmount
                .Cells(cTotal).Value = purchaseReturnDetailObj.GetTotal
                .Cells(cStorage).Value = GetStorageName(.Cells(cStorageId).Value)
                .Cells(cName).Value = GetItemName(.Cells(cItemId).Value)
                .Cells(cPurchaseId).Value = purchaseReturnDetailObj.PurchaseId
                .Cells(cPriceSale).Value = purchaseReturnDetailObj.PriceSale
                .Cells(cRemark).Value = purchaseReturnDetailObj.Remark
                .Cells(cPurchaseReturnId).Value = purchaseReturnDetailObj.PurchaseReturnId
                .Cells(cUserId).Value = purchaseReturnDetailObj.UserId
                .Cells(cDateOn).Value = purchaseReturnDetailObj.DateOn
                .Cells(cNonSaleable).Value = purchaseReturnDetailObj.NonSaleable
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadGridValuesForPurchaseItems()
        Try
            GrdInvoiceDetail.Rows.Clear()

            Dim vendorId As Integer = GetSelectedItemId(CmbVendor)
            If vendorId = cInvalidId Then Exit Try

            Dim batch As String = cBatchDefault 'TxtBatch.Text.Trim
            If batch = "" Then Exit Try

            Dim purchaseDetails() As ClsPurchaseDetail = GetAllPurchaseDetailForVendorIdAndBatch(Me.Name, vendorId, batch)
            If purchaseDetails Is Nothing Then Exit Try

            Dim purchaseDetail As ClsPurchaseDetail
            For Each purchaseDetail In purchaseDetails
                InsertIntoPurchaseItemGrid(purchaseDetail)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub InsertIntoPurchaseItemGrid(ByRef purchaseDetailObj As ClsPurchaseDetail)
        Try
            If purchaseDetailObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdInvoiceDetail.Rows.Add
            With GrdInvoiceDetail.Rows(rowIndex)
                .Cells(cItemId).Value = purchaseDetailObj.ItemId
                .Cells(cStorageId).Value = purchaseDetailObj.StorageId
                .Cells(cBatch).Value = purchaseDetailObj.Batch
                .Cells(cExpiryDate).Value = purchaseDetailObj.ExpiryDate
                .Cells(cPurchaseQuantity).Value = purchaseDetailObj.PurchaseQuantity
                .Cells(cPricePurchase).Value = purchaseDetailObj.PricePurchase
                .Cells(cPackQuantity).Value = purchaseDetailObj.PackQuantity
                .Cells(cTaxAmount).Value = purchaseDetailObj.TaxAmount
                .Cells(cDiscountPercent).Value = purchaseDetailObj.DiscountPercent
                .Cells(cDiscountAmount).Value = purchaseDetailObj.DiscountAmount
                '.Cells(cTotal).Value = purchaseDetailObj.GetTotal
                .Cells(cStorage).Value = GetStorageName(.Cells(cStorageId).Value)
                .Cells(cName).Value = GetItemName(.Cells(cItemId).Value)
                .Cells(cPurchaseId).Value = purchaseDetailObj.PurchaseId
                .Cells(cPriceSale).Value = 0 'purchaseDetailObj.Pricesale
                .Cells(cRemark).Value = purchaseDetailObj.Remark
                .Cells(cForCashOut).Value = False
                .Cells(cUserId).Value = purchaseDetailObj.UserId
                .Cells(cDateOn).Value = purchaseDetailObj.DateOn
                Dim purchaseObj As ClsPurchaseMaster = GetPurchaseObj(purchaseDetailObj.PurchaseId)
                If purchaseObj IsNot Nothing Then
                    .Cells(cPurchaseCode).Value = purchaseObj.PurchaseCode
                    .Cells(cTaxPercent).Value = purchaseObj.TaxPercent
                End If
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

    Private Sub LoadPurchase()
        Try
            lPurchase = GetAllPurchaseMaster(Me.Name)

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Function GetVendorName(ByVal id As Integer) As String
        Dim result As String = ""
        Try
            For Each vendor As ClsVendorMaster In CmbVendor.Items
                If vendor.Id = id Then
                    result = vendor.Name
                    Exit Try
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

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

    Private Function GetPurchaseObj(ByVal id As Long) As ClsPurchaseMaster
        Dim result As ClsPurchaseMaster = Nothing
        Try
            For Each purchase As ClsPurchaseMaster In lPurchase
                If purchase.Id = id Then
                    result = purchase
                    Exit Try
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Function GetPurchaseCode(ByVal id As Long) As String
        Dim result As String = ""
        Try
            Dim purchase As ClsPurchaseMaster = GetPurchaseObj(id)
            If purchase IsNot Nothing Then
                result = purchase.PurchaseCode
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Sub ResetControlsToAddNewItem()
        editRow = Nothing
        currentRow = Nothing

        CmbItem.Text = ""
        'TxtBatchReturn.Text = ""
        TxtQuantity.Text = "0"
        TxtPurchasePrice.Text = "0"
        ChkNonSaleable.Checked = False

        BtnAdd.Text = "&Add"
        BtnNew.Text = "&New"
        BtnAdd.Enabled = True
        BtnRemove.Enabled = False

        GrdInvoiceDetail.Focus()
    End Sub

    Private Sub ResetControlsToAddNew()
        DtPkrReturnDate.Value = Now.Date
        TxtPurchaseReturnCode.Text = ""
        CmbVendor.Text = ""
        'TxtBatch.Text = ""
        TxtRemark.Text = ""

        TxtTotalReturn.Text = "0"
        TxtRoundOffReturn.Text = "0"
        TxtNetAmountReturn.Text = "0"
        TxtDiscountOnBillReturn.Text = "0"
        lPurchaseReturnObj = Nothing
        CmbVendor.Enabled = True
        flagOldObject = False

        GrdInvoiceDetail.Rows.Clear()
        GrdItemsReturn.Rows.Clear()

        ResetControlsToAddNewItem()

        DtPkrReturnDate.Focus()
    End Sub

    Private Sub UpdatePurchaseReturnDetailObject()
        Try
            If lPurchaseReturnObj Is Nothing Then
                MsgBox("Purchase Return Code doesn't found. Unable to Update.", MsgBoxStyle.Critical, "Error")
                Exit Sub
            End If

            If editRow Is Nothing Then Exit Try

            If flagOldObject = False Then
                If AndedTheString(gUser.AuthorizationNo, Authorization.PurchaseReturn_Current_NoUpdate) = True Then Exit Sub
            Else
                If AndedTheString(gUser.AuthorizationNo, Authorization.PurchaseReturn_Old_NoUpdate) = True Then Exit Sub
            End If

            If ValidateValues() = False Then Exit Sub

            'Updating Detail
            Dim purchaseReturnDetailObj As New ClsPurchaseReturnDetail
            With purchaseReturnDetailObj
                .Id = editRow.Cells(cId).Value
                .PurchaseId = editRow.Cells(cPurchaseId).Value
                .PurchaseReturnId = editRow.Cells(cPurchaseReturnId).Value
                .ItemId = GetSelectedItemId(CmbItem)
                .PricePurchase = Val(TxtPurchasePrice.Text)
                .ReturnQuantity = Val(TxtQuantity.Text)
                .NonSaleable = ChkNonSaleable.Checked
                .TaxPercent = editRow.Cells(cTaxPercent).Value
                .DiscountPercent = editRow.Cells(cDiscountPercent).Value
                .Batch = editRow.Cells(cBatch).Value
                .ExpiryDate = editRow.Cells(cExpiryDate).Value
                .PricePurchase = editRow.Cells(cPricePurchase).Value
                .PackQuantity = editRow.Cells(cPackQuantity).Value
                .StorageId = editRow.Cells(cStorageId).Value
                .Remark = TxtRemark.Text
                .UserId = gUser.LoginName
                .DateOn = Now
                .TaxAmount = editRow.Cells(cTaxAmount).Value
                .DiscountAmount = editRow.Cells(cDiscountAmount).Value
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
                .Cells(cNonSaleable).Value = purchaseReturnDetailObj.NonSaleable
                .Cells(cPurchaseId).Value = purchaseReturnDetailObj.PurchaseId
            End With

            CalculateTotalsForPurchaseItemsReturn()
            lPurchaseReturnObj.NotClosed = True
            MsgBox("Successfully Updated", , "Updated")

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNewItem()
    End Sub

    Private Function ValidateValues() As Boolean
        Dim result As Boolean = False
        Try
            RemoveErrorIcon()

            If CmbVendor.Text.Trim = "" Then
                ErrorInData("Please select vendor.", CmbVendor)
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

            'If TxtBatchReturn.Text.Trim = "" Then
            '    ErrorInData("Please enter batch.", TxtBatchReturn)
            '    Exit Try
            'End If

            If TxtQuantity.Text.Trim = "" Then
                ErrorInData("Please enter purchase return quantity.", TxtQuantity)
                Exit Try
            End If

            If Val(TxtQuantity.Text) <= 0 Then
                ErrorInData("Please enter purchase return quantity greater then 0.", TxtQuantity)
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

            Dim itemId As Integer = GetSelectedItemId(CmbItem)
            Dim purchaseId As Integer = GetSelectedItemId(CmbPurchases)
            Dim batch As String = cBatchDefault 'TxtBatchReturn.Text
            Dim row As DataGridViewRow = GetRowForValues(itemId, batch, purchaseId)
            If Not (row Is Nothing) Then
                If row.Cells(cPurchaseQuantity).Value < Val(TxtQuantity.Text) Then
                    ErrorInData("Qauntity is more then the sold quantity.", TxtQuantity)
                    Exit Try
                End If
            End If

            result = True

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Function GetRowForValues(ByVal itemId As Integer, ByVal batch As String, ByVal purchaseId As Long) As DataGridViewRow
        Dim result As DataGridViewRow = Nothing
        Try
            If GrdInvoiceDetail.Rows.Count = 0 Then Exit Try

            Dim row As DataGridViewRow
            For Each row In GrdInvoiceDetail.Rows
                If row.Cells(cItemId).Value = itemId And row.Cells(cBatch).Value = batch And row.Cells(cPurchaseId).Value = purchaseId Then
                    result = row
                    Exit Try
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Sub CalculateTotalsForPurchaseItemsReturn()
        Try
            TxtTotalReturn.Text = "0"
            TxtRoundOffReturn.Text = "0"
            TxtNetAmountReturn.Text = "0"

            If GrdItemsReturn.Rows.Count = 0 Then Exit Try

            Dim totalAmount As Double = 0
            Dim taxTotal As Double = 0
            Dim discountTotal As Double = 0
            Dim roundOff As Double = 0
            Dim netAmount As Double = 0

            Dim row As DataGridViewRow
            For Each row In GrdItemsReturn.Rows
                With row
                    Dim total As Double = Val(.Cells(cTotal).Value) 'Val(.Cells(cPricePurchase).Value) * Val(.Cells(cReturnQuantity).Value)
                    'taxTotal = taxTotal + Val(.Cells(cTaxAmount).Value)
                    'discountTotal = discountTotal + total * Val(.Cells(cDiscountPercent).Value) / 100
                    totalAmount = totalAmount + total
                End With
            Next

            TxtTotalReturn.Text = Format(totalAmount, "0.00")

            Dim temp As Double = totalAmount + taxTotal - discountTotal - Val(TxtDiscountOnBillReturn.Text)
            netAmount = GetSqlRound(Me.Name, temp)

            TxtRoundOffReturn.Text = Format(netAmount - temp, "0.00")
            TxtNetAmountReturn.Text = Format(netAmount, "0.00")

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub SetObjectsForCurrentLogin()
        Try
            lPurchaseReturnObj = Nothing

            Dim purchaseReturnMaster As ClsPurchaseReturnMaster = GetPurchaseReturnMasterNotClosedForLogin(Me.Name, gUser.LoginName)
            If purchaseReturnMaster Is Nothing Then Exit Try

            lPurchaseReturnObj = purchaseReturnMaster

            With purchaseReturnMaster
                With purchaseReturnMaster
                    TxtPurchaseReturnCode.Text = .PurchaseReturnCode
                    DtPkrReturnDate.Value = .ReturnDate
                    TxtRemark.Text = .Remark
                    TxtDiscountOnBillReturn.Text = Format(.DiscountAmount, "0.00")
                    CmbVendor.Text = GetVendorName(.VendorId)
                    CmbVendor.Enabled = False
                    flagOldObject = False
                End With
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub SetPurchaseReturnForPurchaseReturnId(ByVal id As Long)
        Try
            lPurchaseReturnObj = Nothing

            If id <= 0 Then Exit Try
            flagOldObject = True

            Dim purchaseReturnMaster As ClsPurchaseReturnMaster = GetPurchaseReturnMasterById(Me.Name, id)
            If purchaseReturnMaster Is Nothing Then Exit Try

            lPurchaseReturnObj = purchaseReturnMaster

            With purchaseReturnMaster
                TxtPurchaseReturnCode.Text = .PurchaseReturnCode
                DtPkrReturnDate.Value = .ReturnDate
                TxtRemark.Text = .Remark
                TxtDiscountOnBillReturn.Text = Format(.DiscountAmount, "0.00")
                CmbVendor.Text = GetVendorName(.VendorId)
                CmbVendor.Enabled = False
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        LoadGridValuesForPurchaseItemsReturn()
        CalculateTotalsForPurchaseItemsReturn()
    End Sub

#End Region

End Class
