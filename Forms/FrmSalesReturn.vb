Imports AIMS.Author

Public Class FrmSalesReturn

#Region "Local variables and Constants"

    Dim editRow As DataGridViewRow = Nothing
    Dim lSaleObj As ClsSalesMaster = Nothing
    Dim lSalesReturnObj As ClsSalesReturnMaster = Nothing
    Dim lStorages() As ClsStorageMaster = Nothing
    Dim flagSaleCodeChanged As Boolean = False
    Dim lCurrentBatch As ClsCurrentStock = Nothing

    Private Const lcUpdate As String = "&Update"
    Private Const lcCancel As String = "Cance&l"

    Enum Index
        GrpSaleDetail
        TxtSalesReturnCode
        DtPkrReturnDate
        TxtSaleCode
        DtPkrSaleDate
        CmbCustomer
        CmbDoctor
        GrdItemsSale
        TxtTotalAmountSale
        TxtDiscountOnBill
        TxtRoundOffSale
        TxtNetAmountSale
        GrpItemReturn
        CmbItem
        'CmbBatch
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

    Private Sub FrmSalesReturn_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not (lSalesReturnObj Is Nothing) Then
            If lSalesReturnObj.NotClosed = True Then
                If MsgBox("Sales Return Master is not updated." + vbCrLf + vbCrLf + "To update click save button." + vbCrLf + vbCrLf + "Do you want to update Sales Return master?", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub FrmSalesReturn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

    Private Sub TxtSaleCode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSaleCode.KeyPress
        e.Handled = Check_Numeric(e.KeyChar)
        flagSaleCodeChanged = True
    End Sub

    Private Sub GrdItemsSale_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdItemsSale.CellClick
        Try
            If e.RowIndex < 0 Then Exit Try

            With GrdItemsSale.Rows(e.RowIndex)
                CmbItem.Text = .Cells(cName).Value
                'CmbBatch.Text = .Cells(cBatch).Value
                TxtSalePrice.Text = .Cells(cPriceSale).Value
                TxtTotal.Text = "0"
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub TxtSaleCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSaleCode.TextChanged
        Try
            If flagSaleCodeChanged = False Then Exit Try

            flagSaleCodeChanged = False
            If Not (lSalesReturnObj Is Nothing) Then
                MsgBox("It is not possible to add items from other sale code." + vbCrLf + vbCrLf + "Please click new to generate new Sale Return code for this.", , "Not Possible")
                Exit Try
            End If

            GrdItemsSale.Rows.Clear()
            CalculateTotalsForSaleItems()   'Clears all values
            If TxtSaleCode.Text.Trim = "" Then Exit Try

            Dim str As String = TxtSaleCode.Text    'Text get reset due to sales object set.
            Dim saleId As Long = Val(TxtSaleCode.Text)
            If saleId <= 0 Then Exit Try

            SetSalesObject(GetSalesMaster(Me.Name, saleId))
            TxtSaleCode.Text = str
            TxtSaleCode.SelectionStart = str.Length

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub TxtQuantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtQuantity.TextChanged
        CalculateTotal()
    End Sub

    Private Sub TxtTax_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CalculateTotal()
    End Sub

    Private Sub CmbTaxType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CalculateTotal()
    End Sub

    Private Sub TxtDiscount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CalculateTotal()
    End Sub

    Private Sub CmbDiscountType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
                    .CustomerId = GetSelectedItemId(CmbCustomer)
                    .DoctorId = GetSelectedItemId(CmbDoctor)
                    .DiscountAmount = Val(TxtDiscountOnBillReturn.Text)
                    .Status = lSaleObj.Mode
                    .Remark = TxtRemark.Text
                    .ReturnDate = DtPkrReturnDate.Value
                    .SaleId = TxtSaleCode.Text
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
                .SaleId = TxtSaleCode.Text
                .SalesReturnId = lSalesReturnObj.Id
                Dim item As ClsItemMaster = CmbItem.SelectedItem
                .ItemId = item.Id
                Dim currentStock As ClsCurrentStock = lCurrentBatch  'CmbBatch.SelectedItem
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

    Private Sub GrdItemsSale_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdItemsSale.KeyDown
        If e.KeyCode = Keys.Tab Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
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
                'CmbBatch.SelectedText = .Cells(cBatch).Value
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
                .CustomerId = GetSelectedItemId(CmbCustomer)
                .DoctorId = GetSelectedItemId(CmbDoctor)
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

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtTotalReturn.KeyDown, TxtTotalAmountSale.KeyDown, TxtTotal.KeyDown, TxtSalesReturnCode.KeyDown, TxtSalePrice.KeyDown, TxtSaleCode.KeyDown, TxtRoundOffSale.KeyDown, TxtRoundOffReturn.KeyDown, TxtRemark.KeyDown, TxtQuantity.KeyDown, TxtNetAmountSale.KeyDown, TxtNetAmountReturn.KeyDown, DtPkrSaleDate.KeyDown, DtPkrReturnDate.KeyDown, CmbItem.KeyDown, CmbDoctor.KeyDown, CmbCustomer.KeyDown, TxtDiscountOnBillReturn.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub TxtDiscountOnBillReturn_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDiscountOnBillReturn.TextChanged
        CalculateTotalsForSaleItemsReturn()
    End Sub

    Private Sub BgWorker_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BgWorker.DoWork
        GetAllItemMaster(Me.Name)
        GetAllCurrentStock(Me.Name)
    End Sub

    Private Sub BgWorker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BgWorker.RunWorkerCompleted
        LoadComboBoxValuesAsync()
    End Sub

#End Region

#Region "Private Function"

    Private Sub SetControls()
        SetTabIndex()
        SetGridForItemSale()
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
        TxtSaleCode.TabIndex = Index.TxtSaleCode
        DtPkrSaleDate.TabIndex = Index.DtPkrSaleDate
        CmbCustomer.TabIndex = Index.CmbCustomer
        CmbDoctor.TabIndex = Index.CmbDoctor
        GrdItemsSale.TabIndex = Index.GrdItemsSale
        TxtRoundOffSale.TabIndex = Index.TxtRoundOffSale
        TxtTotalAmountSale.TabIndex = Index.TxtTotalAmountSale
        TxtNetAmountSale.TabIndex = Index.TxtNetAmountSale
        GrpItemReturn.TabIndex = Index.GrpItemReturn
        TxtSalePrice.TabIndex = Index.TxtSalePrice
        TxtTotal.TabIndex = Index.TxtTotal
        GrdItemsSaleReturn.TabIndex = Index.GrdItemsSaleReturn
        BtnRemove.TabIndex = Index.BtnRemove
        BtnAdd.TabIndex = Index.BtnAdd
        'CmbBatch.TabIndex = Index.CmbBatch
        CmbItem.TabIndex = Index.CmbItem
        TxtQuantity.TabIndex = Index.TxtQuantity
        TxtRoundOffReturn.TabIndex = Index.TxtRoundOffReturn
        TxtDiscountOnBill.TabIndex = Index.TxtDiscountOnBill
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

    Private Sub SetGridForItemSale()
        With GrdItemsSale
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

                End Select
            Next
        End With
    End Sub

    Private Sub LoadGridValuesForSaleItems()
        Try
            GrdItemsSale.Rows.Clear()

            If lSaleObj Is Nothing Then Exit Try

            Dim saleDetails() As ClsSalesDetail = GetAllSalesDetailForSalesId(Me.Name, lSaleObj.Id)
            If saleDetails Is Nothing Then Exit Try

            Dim saleDetail As ClsSalesDetail
            For Each saleDetail In saleDetails
                InsertIntoSaleItemGrid(saleDetail)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
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

    Private Sub InsertIntoSaleItemGrid(ByRef saleDetailObj As ClsSalesDetail)
        Try
            If saleDetailObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdItemsSale.Rows.Add
            With GrdItemsSale.Rows(rowIndex)
                .Cells(cId).Value = saleDetailObj.Id
                .Cells(cItemId).Value = saleDetailObj.ItemId
                .Cells(cStorageId).Value = saleDetailObj.StorageId
                .Cells(cBatch).Value = saleDetailObj.Batch
                .Cells(cExpiryDate).Value = saleDetailObj.ExpiryDate
                .Cells(cSaleQuantity).Value = saleDetailObj.SaleQuantity
                .Cells(cPriceSale).Value = saleDetailObj.PriceSale
                .Cells(cPackQuantity).Value = saleDetailObj.PackQuantity
                .Cells(cTaxPercent).Value = saleDetailObj.TaxPercent
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
            End With

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
        LoadComboBoxValuesForCustomers()
        LoadComboBoxValuesForDoctors()
        BgWorker.RunWorkerAsync()
    End Sub

    Private Sub LoadComboBoxValuesForCustomers()
        Try
            CmbCustomer.Items.Clear()

            Dim customers() As ClsCustomerMaster = GetAllCustomerMaster(Me.Name)
            If customers Is Nothing Then Exit Try

            CmbCustomer.DisplayMember = cName
            CmbCustomer.ValueMember = cId
            Dim customer As ClsCustomerMaster
            For Each customer In customers
                CmbCustomer.Items.Add(customer)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadComboBoxValuesForDoctors()
        Try
            CmbDoctor.Items.Clear()

            Dim doctors() As ClsDoctorMaster = GetAllDoctorMaster(Me.Name)
            If doctors Is Nothing Then Exit Try

            CmbDoctor.DisplayMember = cName
            CmbDoctor.ValueMember = cId
            Dim doctor As ClsDoctorMaster
            For Each doctor In doctors
                CmbDoctor.Items.Add(doctor)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadComboBoxValuesAsync()
        LoadComboBoxValuesForItems()
        LoadComboBoxValuesForBatch()
    End Sub

    Private Sub LoadComboBoxValuesForItems()
        Try
            CmbItem.DataSource = Nothing
            CmbItem.Items.Clear()
            CmbItem.Text = ""

            Dim items() As ClsItemMaster = GetAllItemMaster(Me.Name, False)
            If items Is Nothing Then Exit Try

            CmbItem.DataSource = items
            CmbItem.DisplayMember = cName
            CmbItem.ValueMember = cId
            CmbItem.Text = ""

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadComboBoxValuesForBatch()
        Try
            'CmbBatch.DataSource = Nothing
            'CmbBatch.Items.Clear()
            'CmbBatch.Text = ""

            Dim currentStocks() As ClsCurrentStock = GetAllCurrentStock(Me.Name, False)
            If currentStocks Is Nothing Then Exit Try

            lCurrentBatch = currentStocks(0)

            'CmbBatch.DataSource = currentStocks
            'CmbBatch.DisplayMember = cBatchX
            'CmbBatch.ValueMember = cId
            'CmbBatch.Text = ""

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

    Private Function GetCustomer(ByVal id As Integer) As ClsCustomerMaster
        Dim result As ClsCustomerMaster = Nothing
        Try
            Dim customer As ClsCustomerMaster
            For Each customer In CmbCustomer.Items
                If customer.Id = id Then
                    result = customer
                    Exit Try
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Function GetDoctorName(ByVal id As Integer) As String
        Dim result As String = ""
        Try
            Dim doctor As ClsDoctorMaster
            For Each doctor In CmbDoctor.Items
                If doctor.Id = id Then
                    result = doctor.Name
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

            If TxtSaleCode.Text.Trim = "" Then
                ErrorInData("Please enter sale code.", TxtSaleCode)
                Exit Try
            End If

            If CmbCustomer.Text.Trim = "" Then
                ErrorInData("Please select customer.", CmbCustomer)
                Exit Try
            End If

            If CmbCustomer.FindStringExact(CmbCustomer.Text.Trim) < 0 Then
                ErrorInData("Please select valid customer from customer list.", CmbCustomer)
                Exit Try
            End If

            'If CmbDoctor.Text.Trim = "" Then
            '    ErrorInData("Please select doctor.", CmbDoctor)
            '    Exit Try
            'End If

            'If CmbDoctor.FindStringExact(CmbDoctor.Text.Trim) < 0 Then
            '    ErrorInData("Please select valid doctor from doctor list.", CmbDoctor)
            '    Exit Try
            'End If

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
            Dim batch As String = cBatchDefault 'CmbBatch.Text
            Dim row As DataGridViewRow = GetRowForValues(GrdItemsSale, itemId, batch)
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

    Private Sub UpdateSaleReturnDetailObject()
        Try
            If lSalesReturnObj Is Nothing Then
                MsgBox("Sale Return Code doesn't found. Unable to Update.", MsgBoxStyle.Critical, "Error")
                Exit Sub
            End If

            If editRow Is Nothing Then Exit Try

            If ValidateValues() = False Then Exit Sub

            Dim currentStock As ClsCurrentStock = lCurrentBatch 'GetSelectedItem(CmbBatch)
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
        'CmbBatch.Text = ""
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
        TxtSaleCode.Text = ""
        DtPkrSaleDate.Value = Now.Date
        DtPkrReturnDate.Value = Now.Date
        TxtSalesReturnCode.Text = ""
        CmbCustomer.Text = ""
        CmbDoctor.Text = ""
        TxtRemark.Text = ""

        TxtTotalAmountSale.Text = "0"
        TxtRoundOffSale.Text = "0"
        TxtNetAmountSale.Text = "0"
        TxtTotalReturn.Text = "0"
        TxtRoundOffReturn.Text = "0"
        TxtNetAmountReturn.Text = "0"
        TxtDiscountOnBill.Text = "0"
        TxtDiscountOnBillReturn.Text = "0"

        flagSaleCodeChanged = False

        TxtSaleCode.Enabled = True
        GrdItemsSale.Rows.Clear()
        GrdItemsSaleReturn.Rows.Clear()
        lSaleObj = Nothing
        lSalesReturnObj = Nothing
        ResetControlsToAddNewItem()

        DtPkrReturnDate.Focus()
    End Sub

    Private Sub CalculateTotalsForSaleItems()
        Try
            TxtTotalAmountSale.Text = "0"
            TxtRoundOffSale.Text = "0"
            TxtNetAmountSale.Text = "0"

            If GrdItemsSale.Rows.Count = 0 Then Exit Try

            Dim totalAmount As Double = 0
            Dim taxTotal As Double = 0
            Dim discountTotal As Double = 0
            Dim roundOff As Double = 0
            Dim netAmount As Double = 0

            Dim row As DataGridViewRow
            For Each row In GrdItemsSale.Rows
                With row
                    taxTotal = taxTotal + Val(.Cells(cTaxAmount).Value)
                    discountTotal = discountTotal + Val(.Cells(cDiscountAmount).Value)
                    totalAmount = totalAmount + (Val(.Cells(cPriceSale).Value) * Val(.Cells(cSaleQuantity).Value))
                End With
            Next

            TxtTotalAmountSale.Text = Format(totalAmount, "0.00")

            Dim temp As Double = totalAmount + taxTotal - discountTotal - Val(TxtDiscountOnBill.Text)
            netAmount = GetSqlRound(Me.Name, temp)

            TxtRoundOffSale.Text = Format(netAmount - temp, "0.00")
            TxtNetAmountSale.Text = Format(netAmount, "0.00")

        Catch ex As Exception
            AddToLog(ex)
        End Try
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
            SetSalesObject(Nothing)
            lSalesReturnObj = Nothing

            Dim salesReturnMaster As ClsSalesReturnMaster = GetSalesReturnMasterNotClosedForLogin(Me.Name, gUser.LoginName)
            If salesReturnMaster Is Nothing Then Exit Try

            Dim salesMaster As ClsSalesMaster = GetSalesMaster(Me.Name, salesReturnMaster.SaleId)
            If salesMaster Is Nothing Then Exit Try

            SetSalesObject(salesMaster)
            lSalesReturnObj = salesReturnMaster
            TxtSaleCode.Enabled = False

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
            SetSalesObject(Nothing)
            lSalesReturnObj = Nothing

            If id <= 0 Then Exit Try

            Dim salesReturnMaster As ClsSalesReturnMaster = GetSalesReturnMaster(Me.Name, id)
            If salesReturnMaster Is Nothing Then Exit Try

            Dim salesMaster As ClsSalesMaster = GetSalesMaster(Me.Name, salesReturnMaster.SaleId)
            If salesMaster Is Nothing Then Exit Try

            lSalesReturnObj = salesReturnMaster
            SetSalesObject(salesMaster)
            TxtSaleCode.Enabled = False

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

    Private Sub SetSalesObject(ByRef salesObj As ClsSalesMaster)
        Try
            lSaleObj = salesObj
            If lSaleObj Is Nothing Then
                TxtSaleCode.Text = ""
                DtPkrSaleDate.Value = Now.Date
                DtPkrReturnDate.Value = Now.Date
                TxtSalesReturnCode.Text = ""
                CmbCustomer.Text = ""
                CmbDoctor.Text = ""
                TxtRemark.Text = ""
                TxtDiscountOnBill.Text = "0"
            Else
                With lSaleObj
                    TxtSaleCode.Text = .Id
                    DtPkrSaleDate.Value = .SaleDate
                    TxtDiscountOnBill.Text = Format(.DiscountAmount, "0.00")
                    Dim customer As ClsCustomerMaster = GetCustomer(.CustomerId)
                    If Not (customer Is Nothing) Then CmbCustomer.Text = customer.Name
                    CmbDoctor.Text = GetDoctorName(.DoctorId)
                End With
            End If

            LoadGridValuesForSaleItems()
            CalculateTotalsForSaleItems()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

#End Region

End Class