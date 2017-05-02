Imports AIMS.Author

Public Class FrmSalesReturnWithoutBill

#Region "Local variables and Constants"

    Dim editRow As DataGridViewRow = Nothing
    Dim lSalesReturnObj As ClsSalesReturnMaster = Nothing
    Dim lStorages() As ClsStorageMaster = Nothing

    Private Const lcUpdate As String = "&Update"
    Private Const lcCancel As String = "Cance&l"

    Enum Index
        GrpSaleDetail
        TxtSalesReturnCode
        DtPkrReturnDate
        GrpItemReturn
        CmbItem
        CmbBatch
        TxtQuantity
        TxtSalePrice
        TxtTotal
        BtnAdd
        BtnRemove
        GrdItemsSaleReturn
        TxtTotalReturn
        TxtDiscountOnBillReturn
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

#Region "Control Functions"

    Private Sub Help(ByVal sender As Object, ByVal hlpEvent As System.Windows.Forms.HelpEventArgs) Handles MyBase.HelpRequested
        Try
            Dim obj As Object = Me.Owner
            obj.ShowHelp()
        Catch ex As Exception
        End Try

        hlpEvent.Handled = True
    End Sub

    Private Sub FrmSalesReturnWithoutBill_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not (lSalesReturnObj Is Nothing) Then
            If lSalesReturnObj.NotClosed = True Then
                If MsgBox("Sales Return Master is not updated." + vbCrLf + vbCrLf + "To update click save button." + vbCrLf + vbCrLf + "Do you want to update Sales Return master?", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub FrmSalesReturnWithoutBill_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

    Private Sub TxtQuantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtQuantity.TextChanged
        CalculateTotal()
    End Sub

    Private Sub DecimalKeyPressEvent(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtQuantity.KeyPress, TxtDiscountOnBillReturn.KeyPress
        e.Handled = Check_DecimalAllow(e.KeyChar, sender.text)
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Try
            If BtnAdd.Text = lcUpdate Then
                UpdateSaleReturnDetailObject()
                Exit Sub
            End If

            If ValidateValues() = False Then Exit Sub

            'Saving Master if virtual
            If lSalesReturnObj Is Nothing Then
                Dim saleReturnMasterObj As New ClsSalesReturnMaster
                With saleReturnMasterObj
                    .CustomerId = cCashCustomerId
                    .DoctorId = cInvalidId
                    .DiscountAmount = Val(TxtDiscountOnBillReturn.Text)
                    .Status = cStatusCash
                    .Remark = TxtRemark.Text
                    .ReturnDate = DtPkrReturnDate.Value
                    .SaleId = cInvalidId
                    .UserId = gUser.LoginName
                    .DateOn = Now
                    .NotClosed = True
                End With

                Dim saleReturnId As Long = InsertIntoSalesReturnMaster(Me.Name, saleReturnMasterObj)
                If saleReturnId <= 0 Then Exit Try

                saleReturnMasterObj.Id = saleReturnId
                lSalesReturnObj = saleReturnMasterObj

                saleReturnMasterObj = GetSalesReturnMaster(Me.Name, saleReturnId)
                If Not (saleReturnMasterObj Is Nothing) Then
                    lSalesReturnObj = saleReturnMasterObj
                    TxtSalesReturnCode.Text = lSalesReturnObj.SalesReturnCode
                End If
            End If

            If lSalesReturnObj Is Nothing Then
                MsgBox("Sale Return Code doesn't found. Unable to Add.", MsgBoxStyle.Critical, "Error")
                Exit Sub
            End If

            'Saving Detail
            Dim saleReturnDetailObj As New ClsSalesReturnDetail
            With saleReturnDetailObj
                .SaleId = cInvalidId
                .SalesReturnId = lSalesReturnObj.Id
                Dim item As ClsItemMaster = CmbItem.SelectedItem
                .ItemId = item.Id
                Dim currentStock As ClsCurrentStock = CmbBatch.SelectedItem
                If currentStock Is Nothing Then
                    MsgBox("Batch is not selected or Batch doesn't exist", , "Batch")
                    Exit Sub
                End If

                .Batch = currentStock.Batch
                .ExpiryDate = currentStock.ExpiryDate
                .PackQuantity = currentStock.PackQuantity
                .PricePurchase = currentStock.PricePurchase
                .PriceSale = Val(TxtSalePrice.Text)
                .TaxPercent = 0
                .DiscountPercent = 0
                .ReturnQuantity = Val(TxtQuantity.Text)
                .NonSaleable = False
                .StorageId = currentStock.StorageId
                .Remark = TxtRemark.Text
                .UserId = gUser.LoginName
                .DateOn = Now
                CalculateTotal(.TaxAmount, .DiscountAmount)
            End With

            Dim id As Long = InsertIntoSalesReturnDetail(Me.Name, saleReturnDetailObj)
            If id > 0 Then
                saleReturnDetailObj.Id = id
                InsertIntoSaleItemReturnGrid(saleReturnDetailObj)
                CalculateTotalsForSaleItemsReturn()
                lSalesReturnObj.NotClosed = True
            End If

            MsgBox("Successfully Added", , "Added")

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNewItem()
    End Sub

    Private Sub BtnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemove.Click
        Try
            Dim row As DataGridViewRow = GrdItemsSaleReturn.SelectedRows(0)
            If row Is Nothing Then Exit Try

            Dim id As Long = row.Cells(cId).Value
            If id <= 0 Then Exit Try

            If MsgBox("Do you really wants to remove selected record? Removed records can't be recovered.", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                If DeleteSalesReturnDetail(Me.Name, id) <> EnResult.Change Then Exit Sub

                GrdItemsSaleReturn.Rows.Remove(row)
                lSalesReturnObj.NotClosed = True
                CalculateTotalsForSaleItemsReturn()
                MsgBox("Successfully Removed", , "Removed")
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNewItem()
    End Sub

    Private Sub GrdItemsSaleReturn_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdItemsSaleReturn.KeyDown
        If e.KeyCode = Keys.Tab Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub GrdItemsSaleReturn_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdItemsSaleReturn.CellClick
        Try
            If e.RowIndex < 0 Then Exit Try
            'If AndedTheString(gUser.AuthorizationNo, Authorization.SalesReturn_NoRemove) = True Then Exit Sub

            BtnRemove.Enabled = True
            BtnAdd.Enabled = False
            BtnNew.Text = lcCancel

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub GrdItemsSaleReturn_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdItemsSaleReturn.CellDoubleClick
        Try
            BtnRemove.Enabled = False
            If e.RowIndex < 0 Then Exit Try
            'If AndedTheString(gUser.AuthorizationNo, Authorization.SalesReturn_NoUpdate) = True Then Exit Sub

            editRow = GrdItemsSaleReturn.Rows(e.RowIndex)
            With editRow
                CmbItem.Text = .Cells(cName).Value
                CmbBatch.SelectedText = .Cells(cBatch).Value
                TxtSalePrice.Text = .Cells(cPriceSale).Value
                TxtQuantity.Text = .Cells(cReturnQuantity).Value
            End With

            BtnAdd.Text = lcUpdate
            BtnNew.Text = lcCancel
            BtnAdd.Enabled = True
            TxtQuantity.Focus()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch.Click
        Try
            Dim frm As New ClsSearchSaleReturnForm
            If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Dim id As Long = frm.GetSelectedId
                If id > 0 Then
                    SetSaleReturnForSaleReturnId(id)
                End If
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Try
            If lSalesReturnObj Is Nothing Then
                MsgBox("There is no Sale Return selected. Please create or select Sales Return.", , "Sale Return")
                Exit Try
            End If

            If lSalesReturnObj.Id <= 0 Then
                MsgBox("There is no Sale Return selected. Please create or select Sales Return.", , "Sale Return")
                Exit Try
            End If

            Dim saleReturnId As Long = lSalesReturnObj.Id
            Dim ds As DataSet = GetSalesReturn(Me.Name, saleReturnId)

            If ds Is Nothing Then
                MsgBox("Error in generating report.", MsgBoxStyle.Critical, "Error")
                Exit Try
            End If

            If ds.Tables(0).Rows.Count = 0 Then
                MsgBox("No record is present for this selection.", MsgBoxStyle.Information, "No Record")
                Exit Try
            End If

            Dim rof As Double = GetTransactionAccountRoundOffForVoucherNo(Me.Name, lSalesReturnObj.SalesReturnCode)
            Dim discountAmt As Double = GetSalesReturnMasterDiscountAmount(Me.Name, lSalesReturnObj.Id)

            'Opening Report
            SetWaitCursor()
            Dim rpt As New RptSalesReturn
            rpt.SetDataSource(ds.Tables(0))
            rpt.SetParameterValue("ROF", rof)
            rpt.SetParameterValue("DiscountAmount", discountAmt)
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
            If lSalesReturnObj Is Nothing Then Exit Try

            'Updating Master
            Dim saleReturnMasterObj As New ClsSalesReturnMaster
            With saleReturnMasterObj
                .Id = lSalesReturnObj.Id
                .SaleId = lSalesReturnObj.SaleId
                .SalesReturnCode = lSalesReturnObj.SalesReturnCode
                .CustomerId = cCashCustomerId
                .DoctorId = cInvalidId
                .DiscountAmount = Val(TxtDiscountOnBillReturn.Text)
                .Status = lSalesReturnObj.Status
                .Remark = TxtRemark.Text
                .ReturnDate = DtPkrReturnDate.Value
                .UserId = gUser.LoginName
                .DateOn = Now
                .NotClosed = False
            End With

            If UpdateSalesReturnMaster(Me.Name, saleReturnMasterObj) <> EnResult.Change Then Exit Sub
            lSalesReturnObj = saleReturnMasterObj

            MsgBox("Successfully Saved", , "Saved")

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        If BtnNew.Text = lcCancel Then
            ResetControlsToAddNewItem()
        Else
            If Not (lSalesReturnObj Is Nothing) Then
                If lSalesReturnObj.NotClosed = True Then
                    If MsgBox("Sale Return Master is not updated." + vbCrLf + vbCrLf + "To update click save button." + vbCrLf + vbCrLf + "Do you want to update Sale Return Master?", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                        Exit Sub
                    End If
                End If
            End If

            ResetControlsToAddNew()
        End If
    End Sub

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtTotalReturn.KeyDown, TxtTotal.KeyDown, TxtSalesReturnCode.KeyDown, TxtSalePrice.KeyDown, TxtRoundOffReturn.KeyDown, TxtRemark.KeyDown, TxtQuantity.KeyDown, TxtNetAmountReturn.KeyDown, DtPkrReturnDate.KeyDown, CmbItem.KeyDown, CmbBatch.KeyDown, TxtDiscountOnBillReturn.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub TxtDiscountOnBillReturn_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDiscountOnBillReturn.TextChanged
        CalculateTotalsForSaleItemsReturn()
    End Sub

    Private Sub CmbItem_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbItem.SelectedIndexChanged
        LoadComboBoxValuesForBatch()
        FindSalePrice()
    End Sub

    Private Sub CmbBatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbBatch.SelectedIndexChanged
        FindSalePrice()
    End Sub

#End Region

#Region "Private Function"

    Private Sub SetControls()
        SetTabIndex()
        SetGridForItemsSaleReturn()
        ResetControlsToAddNew()
        LoadComboBoxValues()
        LoadStorages()

        ''Load Grid values after ComboBox Values
        SetObjectsForCurrentLogin()
        LoadGridValuesForSaleItemsReturn()
        CalculateTotalsForSaleItemsReturn()
    End Sub

    Private Sub SetTabIndex()
        GrpSaleDetail.TabIndex = Index.GrpSaleDetail
        TxtSalesReturnCode.TabIndex = Index.TxtSalesReturnCode
        DtPkrReturnDate.TabIndex = Index.DtPkrReturnDate
        GrpItemReturn.TabIndex = Index.GrpItemReturn
        TxtSalePrice.TabIndex = Index.TxtSalePrice
        TxtTotal.TabIndex = Index.TxtTotal
        GrdItemsSaleReturn.TabIndex = Index.GrdItemsSaleReturn
        BtnRemove.TabIndex = Index.BtnRemove
        BtnAdd.TabIndex = Index.BtnAdd
        CmbBatch.TabIndex = Index.CmbBatch
        CmbItem.TabIndex = Index.CmbItem
        TxtQuantity.TabIndex = Index.TxtQuantity
        TxtRoundOffReturn.TabIndex = Index.TxtRoundOffReturn
        TxtDiscountOnBillReturn.TabIndex = Index.TxtDiscountOnBillReturn
        TxtTotalReturn.TabIndex = Index.TxtTotalReturn
        TxtNetAmountReturn.TabIndex = Index.TxtNetAmountReturn
        GrpButtons.TabIndex = Index.GrpButtons
        BtnSearch.TabIndex = Index.BtnSearch
        BtnPrint.TabIndex = Index.BtnPrint
        BtnNew.TabIndex = Index.BtnNew
        BtnClose.TabIndex = Index.BtnClose
        BtnSave.TabIndex = Index.BtnSave
        TxtRemark.TabIndex = Index.TxtRemark
    End Sub

    Private Sub SetGridForItemsSaleReturn()
        With GrdItemsSaleReturn
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
                        .Columns(index).Width = defaultCellWidth + 120
                        .Columns(index).Visible = False

                    Case 2
                        Dim index As Integer = .Columns.Add(cBatch, cBatch)
                        .Columns(index).Width = defaultCellWidth + 30

                    Case 3
                        Dim index As Integer = .Columns.Add(cExpiryDate, "Exp. Date")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "MMM-yyyy"
                        .Columns(index).Visible = False

                    Case 4
                        Dim index As Integer = .Columns.Add(cReturnQuantity, "Ret. Qty")
                        .Columns(index).Width = defaultCellWidth - 10
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 5
                        Dim index As Integer = .Columns.Add(cPriceSale, "S. Price")
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
                        Dim index As Integer = .Columns.Add(cSaleId, cSaleId)
                        .Columns(index).Visible = False

                    Case 16
                        Dim index As Integer = .Columns.Add(cPricePurchase, cPricePurchase)
                        .Columns(index).Visible = False

                    Case 17
                        Dim index As Integer = .Columns.Add(cRemark, cRemark)
                        .Columns(index).Visible = False

                    Case 18
                        Dim index As Integer = .Columns.Add(cSalesReturnId, cSalesReturnId)
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

    Private Sub LoadGridValuesForSaleItemsReturn()
        Try
            GrdItemsSaleReturn.Rows.Clear()

            If lSalesReturnObj Is Nothing Then Exit Try

            Dim saleReturnDetails() As ClsSalesReturnDetail = GetAllSalesReturnDetailForSalesReturnId(Me.Name, lSalesReturnObj.Id)
            If saleReturnDetails Is Nothing Then Exit Try

            Dim saleReturnDetail As ClsSalesReturnDetail
            For Each saleReturnDetail In saleReturnDetails
                InsertIntoSaleItemReturnGrid(saleReturnDetail)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub InsertIntoSaleItemReturnGrid(ByRef salesReturnDetailObj As ClsSalesReturnDetail)
        Try
            If salesReturnDetailObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdItemsSaleReturn.Rows.Add
            With GrdItemsSaleReturn.Rows(rowIndex)
                .Cells(cId).Value = salesReturnDetailObj.Id
                .Cells(cItemId).Value = salesReturnDetailObj.ItemId
                .Cells(cStorageId).Value = salesReturnDetailObj.StorageId
                .Cells(cBatch).Value = salesReturnDetailObj.Batch
                .Cells(cExpiryDate).Value = salesReturnDetailObj.ExpiryDate
                .Cells(cReturnQuantity).Value = salesReturnDetailObj.ReturnQuantity
                .Cells(cPriceSale).Value = salesReturnDetailObj.PriceSale
                .Cells(cPackQuantity).Value = salesReturnDetailObj.PackQuantity
                .Cells(cTaxPercent).Value = salesReturnDetailObj.TaxPercent
                .Cells(cTaxAmount).Value = salesReturnDetailObj.TaxAmount
                .Cells(cDiscountPercent).Value = salesReturnDetailObj.DiscountPercent
                .Cells(cDiscountAmount).Value = salesReturnDetailObj.DiscountAmount
                .Cells(cTotal).Value = salesReturnDetailObj.GetTotal
                .Cells(cStorage).Value = GetStorageName(.Cells(cStorageId).Value)
                .Cells(cName).Value = GetItemName(.Cells(cItemId).Value)
                .Cells(cSaleId).Value = salesReturnDetailObj.SaleId
                .Cells(cPricePurchase).Value = salesReturnDetailObj.PricePurchase
                .Cells(cRemark).Value = salesReturnDetailObj.Remark
                .Cells(cSalesReturnId).Value = salesReturnDetailObj.SalesReturnId
                .Cells(cUserId).Value = salesReturnDetailObj.UserId
                .Cells(cDateOn).Value = salesReturnDetailObj.DateOn
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadComboBoxValues()
        LoadComboBoxValuesForItems()
        LoadBatch()
    End Sub

    Private Sub LoadComboBoxValuesForItems()
        Try
            CmbItem.DataSource = Nothing
            CmbItem.Items.Clear()
            CmbItem.Text = ""

            Dim items() As ClsItemMaster = GetAllItemMaster(Me.Name, True)
            If items Is Nothing Then Exit Try

            CmbItem.DataSource = items
            CmbItem.DisplayMember = cName
            CmbItem.ValueMember = cId
            CmbItem.Text = ""

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadBatch()
        Try
            GetAllCurrentStock(Me.Name)

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadComboBoxValuesForBatch()
        Try
            CmbBatch.DataSource = Nothing
            CmbBatch.Items.Clear()
            CmbBatch.Text = ""

            Dim itemId As Integer = GetSelectedItemId(CmbItem)
            If itemId <= 0 Then Exit Try

            Dim currentStocks() As ClsCurrentStock = GetAllCurrentStockForItemId(Me.Name, itemId, False)

            CmbBatch.DataSource = currentStocks
            CmbBatch.DisplayMember = cBatch
            CmbBatch.ValueMember = cId
            CmbBatch.Text = ""

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
            For Each item In CmbItem.Items
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

    Private Function ValidateValues() As Boolean
        Dim result As Boolean = False
        Try
            RemoveErrorIcon()

            If CmbItem.Text.Trim = "" Then
                ErrorInData("Please select item.", CmbItem)
                Exit Try
            End If

            If CmbItem.FindStringExact(CmbItem.Text.Trim) < 0 Then
                ErrorInData("Please select valid item from item list.", CmbItem)
                Exit Try
            End If

            If CmbBatch.Text.Trim = "" Then
                ErrorInData("Please enter batch.", CmbBatch)
                Exit Try
            End If

            If CmbBatch.FindStringExact(CmbBatch.Text.Trim) < 0 Then
                ErrorInData("Please select valid Batch from Batch list.", CmbBatch)
                Exit Try
            End If

            If TxtQuantity.Text.Trim = "" Then
                ErrorInData("Please enter sale return quantity.", TxtQuantity)
                Exit Try
            End If

            If Val(TxtQuantity.Text) <= 0 Then
                ErrorInData("Please enter sale return quantity greater then 0.", TxtQuantity)
                Exit Try
            End If

            If TxtSalePrice.Text.Trim = "" Then
                ErrorInData("Please enter sale price.", TxtSalePrice)
                Exit Try
            End If

            If Val(TxtSalePrice.Text) <= 0 Then
                ErrorInData("Please enter sale price greater then 0.", TxtSalePrice)
                Exit Try
            End If

            result = True

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Sub UpdateSaleReturnDetailObject()
        Try
            If lSalesReturnObj Is Nothing Then
                MsgBox("Sale Return Code doesn't found. Unable to Update.", MsgBoxStyle.Critical, "Error")
                Exit Sub
            End If

            If editRow Is Nothing Then Exit Try

            If ValidateValues() = False Then Exit Sub

            Dim currentStock As ClsCurrentStock = GetSelectedItem(CmbBatch)
            If currentStock Is Nothing Then Exit Try

            'Updating Detail
            Dim saleReturnDetailObj As New ClsSalesReturnDetail
            With saleReturnDetailObj
                .Id = editRow.Cells(cId).Value
                .SaleId = lSalesReturnObj.SaleId
                .SalesReturnId = editRow.Cells(cSalesReturnId).Value
                .ItemId = GetSelectedItemId(CmbItem)
                .PriceSale = Val(TxtSalePrice.Text)
                .ReturnQuantity = Val(TxtQuantity.Text)
                .NonSaleable = False
                .TaxPercent = 0
                .DiscountPercent = 0
                .Batch = currentStock.Batch
                .ExpiryDate = currentStock.ExpiryDate
                .PricePurchase = currentStock.PricePurchase
                .PackQuantity = currentStock.PackQuantity
                .StorageId = currentStock.StorageId
                .Remark = TxtRemark.Text
                .UserId = gUser.LoginName
                .DateOn = Now
                CalculateTotal(.TaxAmount, .DiscountAmount)
            End With

            If UpdateSalesReturnDetail(Me.Name, saleReturnDetailObj) <> EnResult.Change Then Exit Sub

            With editRow
                .Cells(cItemId).Value = saleReturnDetailObj.ItemId
                .Cells(cStorageId).Value = saleReturnDetailObj.StorageId
                .Cells(cBatch).Value = saleReturnDetailObj.Batch
                .Cells(cExpiryDate).Value = saleReturnDetailObj.ExpiryDate
                .Cells(cReturnQuantity).Value = saleReturnDetailObj.ReturnQuantity
                .Cells(cPriceSale).Value = saleReturnDetailObj.PriceSale
                .Cells(cPackQuantity).Value = saleReturnDetailObj.PackQuantity
                .Cells(cTaxPercent).Value = saleReturnDetailObj.TaxPercent
                .Cells(cTaxAmount).Value = saleReturnDetailObj.TaxAmount
                .Cells(cDiscountPercent).Value = saleReturnDetailObj.DiscountPercent
                .Cells(cDiscountAmount).Value = saleReturnDetailObj.DiscountAmount
                .Cells(cTotal).Value = saleReturnDetailObj.GetTotal
                .Cells(cStorage).Value = GetStorageName(.Cells(cStorageId).Value)
                .Cells(cName).Value = GetItemName(.Cells(cItemId).Value)
                .Cells(cPricePurchase).Value = saleReturnDetailObj.PricePurchase
                .Cells(cRemark).Value = saleReturnDetailObj.Remark
                .Cells(cUserId).Value = saleReturnDetailObj.UserId
                .Cells(cDateOn).Value = saleReturnDetailObj.DateOn
            End With

            CalculateTotalsForSaleItemsReturn()
            lSalesReturnObj.NotClosed = True
            MsgBox("Successfully Updated", , "Updated")

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNewItem()
    End Sub

    Private Sub ResetControlsToAddNewItem()
        editRow = Nothing

        CmbItem.Text = ""
        CmbBatch.Text = ""
        TxtQuantity.Text = "0"
        TxtSalePrice.Text = "0"
        TxtTotal.Text = "0"

        BtnAdd.Text = "&Add"
        BtnNew.Text = "&New"
        BtnAdd.Enabled = True
        BtnRemove.Enabled = False

        CmbItem.Focus()
    End Sub

    Private Sub ResetControlsToAddNew()
        DtPkrReturnDate.Value = Now.Date
        TxtSalesReturnCode.Text = ""
        TxtRemark.Text = ""

        TxtTotalReturn.Text = "0"
        TxtRoundOffReturn.Text = "0"
        TxtNetAmountReturn.Text = "0"
        TxtDiscountOnBillReturn.Text = "0"


        GrdItemsSaleReturn.Rows.Clear()
        lSalesReturnObj = Nothing
        ResetControlsToAddNewItem()

        DtPkrReturnDate.Focus()
    End Sub

    Private Sub CalculateTotalsForSaleItemsReturn()
        Try
            TxtTotalReturn.Text = "0"
            TxtRoundOffReturn.Text = "0"
            TxtNetAmountReturn.Text = "0"

            If GrdItemsSaleReturn.Rows.Count = 0 Then Exit Try

            Dim totalAmount As Double = 0
            Dim taxTotal As Double = 0
            Dim discountTotal As Double = 0
            Dim roundOff As Double = 0
            Dim netAmount As Double = 0

            Dim row As DataGridViewRow
            For Each row In GrdItemsSaleReturn.Rows
                With row
                    taxTotal = taxTotal + Val(.Cells(cTaxAmount).Value)
                    discountTotal = discountTotal + Val(.Cells(cDiscountAmount).Value)
                    totalAmount = totalAmount + (Val(.Cells(cPriceSale).Value) * Val(.Cells(cReturnQuantity).Value))
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

    Private Sub CalculateTotal(Optional ByRef taxAmount As Double = 0, Optional ByRef discountAmount As Double = 0)
        Try
            If TxtQuantity.Text.Trim = "" Then Exit Try
            If TxtSalePrice.Text.Trim = "" Then Exit Try

            Dim saleQuantity As Double = Val(TxtQuantity.Text)
            Dim salePrice As Double = Val(TxtSalePrice.Text)
            Dim total As Double = salePrice * saleQuantity

            taxAmount = 0

            'Adding tax in total
            total = total + taxAmount

            discountAmount = 0

            'Deducting discount
            total = total - discountAmount

            TxtTotal.Text = Format(total, "0.00")

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub SetObjectsForCurrentLogin()
        Try
            lSalesReturnObj = Nothing

            Dim salesReturnMaster As ClsSalesReturnMaster = GetSalesReturnMasterNotClosedForLogin(Me.Name, gUser.LoginName)
            If salesReturnMaster Is Nothing Then Exit Try

            'Dim salesMaster As ClsSalesMaster = GetSalesMaster(Me.Name, salesReturnMaster.SaleId)
            'If salesMaster Is Nothing Then Exit Try

            lSalesReturnObj = salesReturnMaster

            With salesReturnMaster
                With salesReturnMaster
                    TxtSalesReturnCode.Text = .SalesReturnCode
                    DtPkrReturnDate.Value = .ReturnDate
                    TxtRemark.Text = .Remark
                    TxtDiscountOnBillReturn.Text = Format(.DiscountAmount, "0.00")
                End With
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub SetSaleReturnForSaleReturnId(ByVal id As Long)
        Try
            lSalesReturnObj = Nothing

            If id <= 0 Then Exit Try

            Dim salesReturnMaster As ClsSalesReturnMaster = GetSalesReturnMaster(Me.Name, id)
            If salesReturnMaster Is Nothing Then Exit Try

            'Dim salesMaster As ClsSalesMaster = GetSalesMaster(Me.Name, salesReturnMaster.SaleId)
            'If salesMaster Is Nothing Then Exit Try

            lSalesReturnObj = salesReturnMaster

            With salesReturnMaster
                TxtSalesReturnCode.Text = .SalesReturnCode
                DtPkrReturnDate.Value = .ReturnDate
                TxtRemark.Text = .Remark
                TxtDiscountOnBillReturn.Text = Format(.DiscountAmount, "0.00")
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        LoadGridValuesForSaleItemsReturn()
        CalculateTotalsForSaleItemsReturn()
    End Sub

    Private Sub FindSalePrice()
        Try
            TxtSalePrice.Text = 0
            Dim itemId As Integer = GetSelectedItemId(CmbItem)
            Dim batch As String = CmbBatch.Text

            If itemId <= 0 Then Exit Try
            If batch.Trim = "" Then Exit Try

            Dim currentStock As ClsCurrentStock = GetCurrentStock(itemId, batch)
            If currentStock Is Nothing Then Exit Try

            Dim salePrice As Double = 0

            Select Case GetSaleOn()
                Case cPTS
                    salePrice = currentStock.PTS

                Case cPTR
                    salePrice = currentStock.PTR

                Case cMRP
                    salePrice = currentStock.MRP

                Case cRate1
                    salePrice = currentStock.Rate1

                Case cRate2
                    salePrice = currentStock.Rate2

                Case cRate3
                    salePrice = currentStock.Rate3

            End Select

            TxtSalePrice.Text = salePrice

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Function GetCurrentStock(ByVal itemId As Integer, ByVal batch As String) As ClsCurrentStock
        Dim currentStock As ClsCurrentStock = Nothing
        Try
            batch = batch.Trim
            If CmbBatch.Items.Count = 0 Then Exit Try
            If itemId <= 0 Then Exit Try
            If batch.Trim = "" Then Exit Try

            For Each current As ClsCurrentStock In CmbBatch.Items
                If current.ItemId = itemId And UCase(current.Batch) = UCase(batch) Then
                    currentStock = current
                    Exit Try
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return currentStock
    End Function

#End Region

End Class