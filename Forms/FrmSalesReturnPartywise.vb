Imports System.Windows.Forms
Imports AIMS.Author

Public Class FrmSalesReturnPartywise

#Region "Private Variables"

    Dim lStorages() As ClsStorageMaster = Nothing
    Dim lItems() As ClsItemMaster = Nothing
    Dim lSales() As ClsSalesMaster = Nothing
    Dim lSalesReturnObj As ClsSalesReturnMaster = Nothing
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

    Private Sub FrmSalesReturnPartywise_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not (lSalesReturnObj Is Nothing) Then
            If lSalesReturnObj.NotClosed = True Then
                If MsgBox("Sales Return Master is not updated." + vbCrLf + vbCrLf + "To update click save button." + vbCrLf + vbCrLf + "Do you want to update Sales Return master?", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub FrmSalesReturnPartywise_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

    Private Sub BtnSearchInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearchInvoice.Click
        LoadGridValuesForSaleItems()
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
                    flagOldObject = True
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

            'Opening Report
            SetWaitCursor()
            Dim rpt As New RptSalesReturn
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
            If lSalesReturnObj Is Nothing Then Exit Try
            If flagOldObject = False Then
                If AndedTheString(gUser.AuthorizationNo, Authorization.SalesReturn_Current_NoUpdate) = True Then Exit Sub
            Else
                If AndedTheString(gUser.AuthorizationNo, Authorization.SalesReturn_Old_NoUpdate) = True Then Exit Sub
            End If


            'Updating Master
            Dim saleReturnMasterObj As New ClsSalesReturnMaster
            With saleReturnMasterObj
                .Id = lSalesReturnObj.Id
                .SaleId = lSalesReturnObj.SaleId
                .SalesReturnCode = lSalesReturnObj.SalesReturnCode
                .CustomerId = GetSelectedItemId(CmbCustomer)
                .DoctorId = cInvalidId  'GetSelectedItemId(CmbDoctor)
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

    Private Sub BtnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemove.Click
        Try
            Dim row As DataGridViewRow = GrdItemsReturn.SelectedRows(0)
            If row Is Nothing Then Exit Try

            If flagOldObject = False Then
                If AndedTheString(gUser.AuthorizationNo, Authorization.SalesReturn_Current_NoRemove) = True Then Exit Sub
            Else
                If AndedTheString(gUser.AuthorizationNo, Authorization.SalesReturn_Old_NoRemove) = True Then Exit Sub
            End If

            Dim id As Long = row.Cells(cId).Value
            If id <= 0 Then Exit Try

            If MsgBox("Do you really wants to remove selected record? Removed records can't be recovered.", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                If DeleteSalesReturnDetail(Me.Name, id) <> EnResult.Change Then Exit Sub

                GrdItemsReturn.Rows.Remove(row)
                lSalesReturnObj.NotClosed = True
                CalculateTotalsForSaleItemsReturn()
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
                UpdateSaleReturnDetailObject()
                Exit Sub
            End If

            If flagOldObject = False Then
                If AndedTheString(gUser.AuthorizationNo, Authorization.SalesReturn_Current_NoAdd) = True Then Exit Sub
            Else
                If AndedTheString(gUser.AuthorizationNo, Authorization.SalesReturn_Old_NoAdd) = True Then Exit Sub
            End If

            If ValidateValues() = False Then Exit Sub

            'Saving Master if virtual
            If lSalesReturnObj Is Nothing Then
                Dim saleReturnMasterObj As New ClsSalesReturnMaster
                With saleReturnMasterObj
                    .CustomerId = GetSelectedItemId(CmbCustomer)
                    .DoctorId = cInvalidId
                    .DiscountAmount = Val(TxtDiscountOnBillReturn.Text)
                    .Status = cStatusCredit   'lSaleObj.Mode
                    .Remark = TxtRemark.Text
                    .ReturnDate = DtPkrReturnDate.Value
                    .SaleId = cInvalidId 'TxtSaleCode.Text
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
                .SaleId = currentRow.Cells(cSaleId).Value
                .SalesReturnId = lSalesReturnObj.Id
                Dim item As ClsItemMaster = CmbItem.SelectedItem
                .ItemId = item.Id
                .Batch = currentRow.Cells(cBatch).Value
                .ExpiryDate = currentRow.Cells(cExpiryDate).Value
                .PackQuantity = currentRow.Cells(cPackQuantity).Value
                .PricePurchase = currentRow.Cells(cPricePurchase).Value
                .PriceSale = Val(TxtSalePrice.Text)
                .DiscountPercent = currentRow.Cells(cDiscountPercent).Value
                .ReturnQuantity = Val(TxtQuantity.Text)
                .NonSaleable = ChkNonSaleable.Checked
                .StorageId = currentRow.Cells(cStorageId).Value
                .Remark = TxtRemark.Text
                .UserId = gUser.LoginName
                .DateOn = Now
                .TaxAmount = currentRow.Cells(cTaxAmount).Value
                .DiscountAmount = currentRow.Cells(cDiscountAmount).Value
                Dim saleObj As ClsSalesMaster = GetSaleObj(currentRow.Cells(cSaleId).Value)
                If saleObj IsNot Nothing Then
                    .TaxPercent = saleObj.TaxPercent
                End If
            End With

            Dim id As Long = InsertIntoSalesReturnDetail(Me.Name, saleReturnDetailObj)
            If id > 0 Then
                saleReturnDetailObj.Id = id
                InsertIntoSaleItemReturnGrid(saleReturnDetailObj)
                CalculateTotalsForSaleItemsReturn()
                lSalesReturnObj.NotClosed = True
                CmbCustomer.Enabled = False

                MsgBox("Successfully Added", , "Added")
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNewItem()
    End Sub

    Private Sub TxtDiscountOnBillReturn_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDiscountOnBillReturn.TextChanged
        CalculateTotalsForSaleItemsReturn()
    End Sub

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtTotalReturn.KeyDown, TxtSalesReturnCode.KeyDown, TxtSalePrice.KeyDown, TxtRoundOffReturn.KeyDown, TxtRemark.KeyDown, TxtQuantity.KeyDown, TxtNetAmountReturn.KeyDown, TxtDiscountOnBillReturn.KeyDown, DtPkrReturnDate.KeyDown, CmbItem.KeyDown, CmbInvoice.KeyDown, CmbCustomer.KeyDown, ChkNonSaleable.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub DecimalKeyPressEvent(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTotalReturn.KeyPress, TxtSalePrice.KeyPress, TxtRoundOffReturn.KeyPress, TxtQuantity.KeyPress, TxtNetAmountReturn.KeyPress, TxtDiscountOnBillReturn.KeyPress
        e.Handled = Check_DecimalAllow(e.KeyChar, sender.text)
    End Sub

    Private Sub GrdInvoiceDetail_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdInvoiceDetail.CellClick
        Try
            currentRow = Nothing
            If e.RowIndex < 0 Then Exit Try

            currentRow = GrdInvoiceDetail.Rows(e.RowIndex)

            Dim saleId As Long = currentRow.Cells(cSaleId).Value
            Dim itemId As Integer = currentRow.Cells(cItemId).Value
            'TxtBatchReturn.Text = currentRow.Cells(cBatch).Value
            TxtQuantity.Text = currentRow.Cells(cSaleQuantity).Value
            TxtSalePrice.Text = currentRow.Cells(cPriceSale).Value

            LoadComboBoxValuesForInvoices(saleId)
            LoadComboBoxValuesForItems(itemId)

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub GrdItemsReturn_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdItemsReturn.CellClick
        Try
            If e.RowIndex < 0 Then Exit Try
            If flagOldObject = False Then
                If AndedTheString(gUser.AuthorizationNo, Authorization.SalesReturn_Current_NoRemove) = True Then Exit Sub
            Else
                If AndedTheString(gUser.AuthorizationNo, Authorization.SalesReturn_Old_NoRemove) = True Then Exit Sub
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
                If AndedTheString(gUser.AuthorizationNo, Authorization.SalesReturn_Current_NoUpdate) = True Then Exit Sub
            Else
                If AndedTheString(gUser.AuthorizationNo, Authorization.SalesReturn_Old_NoUpdate) = True Then Exit Sub
            End If

            editRow = GrdItemsReturn.Rows(e.RowIndex)
            With editRow
                Dim saleId As Long = .Cells(cSaleId).Value
                Dim itemId As Integer = .Cells(cItemId).Value
                'TxtBatchReturn.Text = .Cells(cBatch).Value
                TxtQuantity.Text = .Cells(cReturnQuantity).Value
                TxtSalePrice.Text = .Cells(cPriceSale).Value
                ChkNonSaleable.Checked = .Cells(cNonSaleable).Value

                LoadComboBoxValuesForInvoices(saleId)
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
        LoadSales()

        LoadComboBoxValuesForCustomer()

        ResetControlsToAddNew()

        ''Load Grid values after ComboBox Values
        SetObjectsForCurrentLogin()
        LoadGridValuesForSaleItemsReturn()
        CalculateTotalsForSaleItemsReturn()
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
                        Dim index As Integer = .Columns.Add(cSaleCode, "Inv. No.")
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
                        .Columns(index).Visible = False

                    Case 4
                        Dim index As Integer = .Columns.Add(cSaleQuantity, "Sale Qty")
                        .Columns(index).Width = defaultCellWidth
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
                        .Columns(index).Visible = False

                    Case 4
                        Dim index As Integer = .Columns.Add(cReturnQuantity, "Return Qty")
                        .Columns(index).Width = defaultCellWidth + 20
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

                    Case 21
                        Dim index As Integer = .Columns.Add(cNonSaleable, "Non Saleable")
                        .Columns(index).Width = defaultCellWidth + 20

                End Select
            Next
        End With
    End Sub

    Private Sub LoadComboBoxValuesForCustomer()
        Try
            With CmbCustomer
                .DataSource = GetAllCustomerMaster(Me.Name)
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
            With CmbInvoice
                .DataSource = Nothing
                .Items.Clear()
                .Text = ""

                Dim sales As ClsSalesMaster = GetSalesMaster(Me.Name, id)
                Dim salesList As New List(Of ClsSalesMaster)
                salesList.Add(sales)

                .DataSource = salesList
                .DisplayMember = cSaleCode
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

    Private Sub LoadGridValuesForSaleItemsReturn()
        Try
            GrdItemsReturn.Rows.Clear()

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

            Dim rowIndex As Integer = GrdItemsReturn.Rows.Add
            With GrdItemsReturn.Rows(rowIndex)
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
                .Cells(cNonSaleable).Value = salesReturnDetailObj.NonSaleable
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadGridValuesForSaleItems()
        Try
            GrdInvoiceDetail.Rows.Clear()

            Dim customerId As Integer = GetSelectedItemId(CmbCustomer)
            If customerId = cInvalidId Then Exit Try

            Dim batch As String = cBatchDefault 'txtBatch.Text.Trim
            If batch = "" Then Exit Try

            Dim saleDetails() As ClsSalesDetail = GetAllSalesDetailForCustomerIdAndBatch(Me.Name, customerId, batch)
            If saleDetails Is Nothing Then Exit Try

            Dim saleDetail As ClsSalesDetail
            For Each saleDetail In saleDetails
                InsertIntoSaleItemGrid(saleDetail)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub InsertIntoSaleItemGrid(ByRef saleDetailObj As ClsSalesDetail)
        Try
            If saleDetailObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdInvoiceDetail.Rows.Add
            With GrdInvoiceDetail.Rows(rowIndex)
                .Cells(cItemId).Value = saleDetailObj.ItemId
                .Cells(cStorageId).Value = saleDetailObj.StorageId
                .Cells(cBatch).Value = saleDetailObj.Batch
                .Cells(cExpiryDate).Value = saleDetailObj.ExpiryDate
                .Cells(cSaleQuantity).Value = saleDetailObj.SaleQuantity
                .Cells(cPriceSale).Value = saleDetailObj.PriceSale
                .Cells(cPackQuantity).Value = saleDetailObj.PackQuantity
                .Cells(cTaxAmount).Value = saleDetailObj.TaxAmount
                .Cells(cDiscountPercent).Value = saleDetailObj.DiscountPercent
                .Cells(cDiscountAmount).Value = saleDetailObj.DiscountAmount
                .Cells(cTotal).Value = saleDetailObj.GetTotal
                .Cells(cStorage).Value = GetStorageName(.Cells(cStorageId).Value)
                .Cells(cName).Value = GetItemName(.Cells(cItemId).Value)
                .Cells(cSaleId).Value = saleDetailObj.SaleId
                .Cells(cPricePurchase).Value = saleDetailObj.PricePurchase
                .Cells(cRemark).Value = saleDetailObj.Remark
                .Cells(cForCashOut).Value = False
                .Cells(cUserId).Value = saleDetailObj.UserId
                .Cells(cDateOn).Value = saleDetailObj.DateOn
                Dim saleObj As ClsSalesMaster = GetSaleObj(saleDetailObj.SaleId)
                If saleObj IsNot Nothing Then
                    .Cells(cSaleCode).Value = saleObj.SaleCode
                    .Cells(cTaxPercent).Value = saleObj.TaxPercent
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

    Private Sub LoadSales()
        Try
            lSales = GetAllSalesMaster(Me.Name)

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Function GetCustomerName(ByVal id As Integer) As String
        Dim result As String = ""
        Try
            For Each customer As ClsCustomerMaster In CmbCustomer.Items
                If customer.Id = id Then
                    result = customer.Name
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

    Private Function GetSaleObj(ByVal id As Long) As ClsSalesMaster
        Dim result As ClsSalesMaster = Nothing
        Try
            For Each sale As ClsSalesMaster In lSales
                If sale.Id = id Then
                    result = sale
                    Exit Try
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Function GetSaleCode(ByVal id As Long) As String
        Dim result As String = ""
        Try
            Dim sale As ClsSalesMaster = GetSaleObj(id)
            If sale IsNot Nothing Then
                result = sale.SaleCode
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
        TxtSalePrice.Text = "0"
        ChkNonSaleable.Checked = False

        BtnAdd.Text = "&Add"
        BtnNew.Text = "&New"
        BtnAdd.Enabled = True
        BtnRemove.Enabled = False

        GrdInvoiceDetail.Focus()
    End Sub

    Private Sub ResetControlsToAddNew()
        DtPkrReturnDate.Value = Now.Date
        TxtSalesReturnCode.Text = ""
        CmbCustomer.Text = ""
        'TxtBatch.Text = ""
        TxtRemark.Text = ""

        TxtTotalReturn.Text = "0"
        TxtRoundOffReturn.Text = "0"
        TxtNetAmountReturn.Text = "0"
        TxtDiscountOnBillReturn.Text = "0"
        lSalesReturnObj = Nothing
        CmbCustomer.Enabled = True
        flagOldObject = False

        GrdInvoiceDetail.Rows.Clear()
        GrdItemsReturn.Rows.Clear()

        ResetControlsToAddNewItem()

        DtPkrReturnDate.Focus()
    End Sub

    Private Sub UpdateSaleReturnDetailObject()
        Try
            If lSalesReturnObj Is Nothing Then
                MsgBox("Sale Return Code doesn't found. Unable to Update.", MsgBoxStyle.Critical, "Error")
                Exit Sub
            End If

            If editRow Is Nothing Then Exit Try

            If flagOldObject = False Then
                If AndedTheString(gUser.AuthorizationNo, Authorization.SalesReturn_Current_NoUpdate) = True Then Exit Sub
            Else
                If AndedTheString(gUser.AuthorizationNo, Authorization.SalesReturn_Old_NoUpdate) = True Then Exit Sub
            End If

            If ValidateValues() = False Then Exit Sub

            'Updating Detail
            Dim saleReturnDetailObj As New ClsSalesReturnDetail
            With saleReturnDetailObj
                .Id = editRow.Cells(cId).Value
                .SaleId = editRow.Cells(cSaleId).Value
                .SalesReturnId = editRow.Cells(cSalesReturnId).Value
                .ItemId = GetSelectedItemId(CmbItem)
                .PriceSale = Val(TxtSalePrice.Text)
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
                .Cells(cNonSaleable).Value = saleReturnDetailObj.NonSaleable
                .Cells(cSaleId).Value = saleReturnDetailObj.SaleId
            End With

            CalculateTotalsForSaleItemsReturn()
            lSalesReturnObj.NotClosed = True
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

            If CmbCustomer.Text.Trim = "" Then
                ErrorInData("Please select customer.", CmbCustomer)
                Exit Try
            End If

            If CmbCustomer.FindStringExact(CmbCustomer.Text.Trim) < 0 Then
                ErrorInData("Please select valid customer from customer list.", CmbCustomer)
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

            Dim itemId As Integer = GetSelectedItemId(CmbItem)
            Dim saleId As Integer = GetSelectedItemId(CmbInvoice)
            Dim batch As String = cBatchDefault 'TxtBatchReturn.Text
            Dim row As DataGridViewRow = GetRowForValues(itemId, batch, saleId)
            If Not (row Is Nothing) Then
                If row.Cells(cSaleQuantity).Value < Val(TxtQuantity.Text) Then
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

    Private Function GetRowForValues(ByVal itemId As Integer, ByVal batch As String, ByVal saleId As Long) As DataGridViewRow
        Dim result As DataGridViewRow = Nothing
        Try
            If GrdInvoiceDetail.Rows.Count = 0 Then Exit Try

            Dim row As DataGridViewRow
            For Each row In GrdInvoiceDetail.Rows
                If row.Cells(cItemId).Value = itemId And row.Cells(cBatch).Value = batch And row.Cells(cSaleId).Value = saleId Then
                    result = row
                    Exit Try
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Sub CalculateTotalsForSaleItemsReturn()
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
                    Dim total As Double = Val(.Cells(cTotal).Value) 'Val(.Cells(cPriceSale).Value) * Val(.Cells(cReturnQuantity).Value)
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
            lSalesReturnObj = Nothing

            Dim salesReturnMaster As ClsSalesReturnMaster = GetSalesReturnMasterNotClosedForLogin(Me.Name, gUser.LoginName)
            If salesReturnMaster Is Nothing Then Exit Try

            lSalesReturnObj = salesReturnMaster

            With salesReturnMaster
                With salesReturnMaster
                    TxtSalesReturnCode.Text = .SalesReturnCode
                    DtPkrReturnDate.Value = .ReturnDate
                    TxtRemark.Text = .Remark
                    TxtDiscountOnBillReturn.Text = Format(.DiscountAmount, "0.00")
                    CmbCustomer.Text = GetCustomerName(.CustomerId)
                    CmbCustomer.Enabled = False

                    flagOldObject = False
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

            lSalesReturnObj = salesReturnMaster

            With salesReturnMaster
                TxtSalesReturnCode.Text = .SalesReturnCode
                DtPkrReturnDate.Value = .ReturnDate
                TxtRemark.Text = .Remark
                TxtDiscountOnBillReturn.Text = Format(.DiscountAmount, "0.00")
                CmbCustomer.Text = GetCustomerName(.CustomerId)
                CmbCustomer.Enabled = False

                flagOldObject = True
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        LoadGridValuesForSaleItemsReturn()
        CalculateTotalsForSaleItemsReturn()
    End Sub

#End Region

End Class
