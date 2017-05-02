Imports System.Windows.Forms
Imports AIMS.Author

Public Class FrmSales

#Region "Local variables and Constants"

    Dim editRow As DataGridViewRow = Nothing
    Dim lSalesObj As ClsSalesMaster = Nothing
    Dim lStorages() As ClsStorageMaster = Nothing
    Dim lCurrentStocks() As ClsCurrentStock = Nothing
    Dim lItems() As ClsItemMaster = Nothing
    Dim lManufacturers() As ClsManufacturerMaster = Nothing
    Dim flagCardNoChanged As Boolean = False
    Dim flagCustomerChanged As EnLoading = EnLoading.None
    Dim flagItemChanged As EnLoading = EnLoading.None
    Dim flagBatchChanged As EnLoading = EnLoading.None
    Dim flagLoadForUpdate As Boolean = False
    Dim lSalePrice As Double = 0
    Dim flagOldObject As Boolean = False
    Dim flagCategoryChange As EnLoading = EnLoading.None
    Dim lFlagTaxNot As EnLoading = EnLoading.None
    Dim lCurrentBatch As ClsCurrentStock = Nothing

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

    Private Sub FrmSales_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not (lSalesObj Is Nothing) Then
            If lSalesObj.NotClosed = True Then
                If MsgBox("Sales Master is not updated." + vbCrLf + vbCrLf + "To update click save button." + vbCrLf + vbCrLf + "Do you want to update Sales master?", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub FrmSales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

    Private Sub Event_AllowDecimalOnKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSalePrice.KeyPress, TxtQuantity.KeyPress, TxtDiscountOnBill.KeyPress, TxtTaxAmt.KeyPress, TxtTaxableAmount.KeyPress, TxtPreExciseAmount.KeyPress, TxtOverAllDiscount.KeyPress, TxtGrossAmount.KeyPress, TxtDebitAdj.KeyPress, TxtCreditAdj.KeyPress, TxtBillRoundOff.KeyPress, TxtBillNetAmount.KeyPress, TxtDiscount.KeyPress, TxtFrieght.KeyPress
        e.Handled = Check_DecimalAllow(e.KeyChar, sender.text)
    End Sub

    'Private Sub CmbCardNo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try
    '        If flagCardNoChanged = False Then Exit Try
    '        flagCardNoChanged = False

    '        TxtTinNo.Text = ""
    '        TxtDLNo.Text = ""
    '        If CmbCardNo.Text.Trim = "" Then
    '            CmbCustomer.Text = ""
    '            Exit Try
    '        End If

    '        Dim x As Integer = CmbCardNo.FindStringExact(CmbCardNo.Text.Trim)
    '        If x < 0 Then
    '            CmbCustomer.Text = ""
    '            Exit Try
    '        End If

    '        Dim customer As ClsCustomerMaster = CmbCardNo.Items(x)
    '        If customer Is Nothing Then Exit Try

    '        CmbCustomer.Text = customer.Name
    '        TxtTinNo.Text = customer.TinNo
    '        'TxtDLNo.Text = customer.DlNo
    '        CmbHQ.Text = GetHQ(customer.HQId)
    '        CmbTax.Text = GetTaxName(customer.TaxId)

    '    Catch ex As Exception
    '        AddToLog(ex)
    '    End Try
    'End Sub

    'Private Sub CmbCardNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    flagCardNoChanged = True
    'End Sub

    Private Sub CmbCustomer_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbCustomer.KeyPress
        'AutoComplete(sender, e)
    End Sub

    Private Sub CmbCustomer_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbCustomer.LostFocus
        Try
            If flagCustomerChanged <> EnLoading.LoadOnLostFocus Then Exit Try
            flagCustomerChanged = EnLoading.None

            TxtTinNo.Text = ""
            TxtAddress.Text = ""
            If CmbCustomer.Text.Trim = "" Or CmbCustomer.FindStringExact(CmbCustomer.Text.Trim) < 0 Then
                'CmbCardNo.Text = ""
                DtPkrDueDate.Value = Now.Date
                Exit Try
            End If

            Dim customer As ClsCustomerMaster = CmbCustomer.SelectedItem
            If customer Is Nothing Then Exit Try

            'CmbCardNo.Text = customer.CardNo
            DtPkrDueDate.Value = DtPkrLRDate.Value.Date.AddDays(customer.DueDays)
            TxtTinNo.Text = customer.TinNo
            TxtAddress.Text = customer.Address
            'TxtDLNo.Text = customer.DlNo
            CmbHQ.Text = GetHQ(customer.HQId)
            CmbTax.Text = GetTaxName(customer.TaxId)

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub CmbCustomer_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbCustomer.TextChanged
        If flagCustomerChanged = EnLoading.None Then flagCustomerChanged = EnLoading.LoadOnLostFocus
        If flagCustomerChanged <> EnLoading.LoadOnChange Then Exit Sub

    End Sub

    Private Sub CmbItem_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbItem.LostFocus
        Try
            If flagItemChanged <> EnLoading.LoadOnLostFocus Then Exit Try

            flagItemChanged = EnLoading.None

            LoadBatchForSelectedItem()

            SetCurrentPrice()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub CmbItem_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbItem.SelectedIndexChanged
        Try
            If flagItemChanged = EnLoading.None Then flagItemChanged = EnLoading.LoadOnLostFocus
            If flagItemChanged <> EnLoading.LoadOnChange Then Exit Sub

            LoadBatchForSelectedItem()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    'Private Sub CmbItem_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbItem.TextChanged
    '    Try
    '        If flagItemChanged = EnLoading.None Then flagItemChanged = EnLoading.LoadOnLostFocus
    '        If flagItemChanged <> EnLoading.LoadOnChange Then Exit Sub

    '        LoadBatchForSelectedItem()

    '    Catch ex As Exception
    '        AddToLog(ex)
    '    End Try
    'End Sub

    'Private Sub CmbBatch_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try
    '        If flagBatchChanged <> EnLoading.LoadOnLostFocus Then Exit Sub
    '        flagBatchChanged = EnLoading.None

    '        SetCurrentPrice()

    '    Catch ex As Exception
    '        AddToLog(ex)
    '    End Try
    'End Sub

    'Private Sub CmbBatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If flagBatchChanged = EnLoading.None Then flagBatchChanged = EnLoading.LoadOnLostFocus
    '    If flagBatchChanged <> EnLoading.LoadOnChange Then Exit Sub

    '    SetCurrentPrice()
    'End Sub

    Private Sub SetCurrentPrice()
        Try
            Dim currentStock As ClsCurrentStock = lCurrentBatch 'CmbBatch.SelectedItem
            If currentStock Is Nothing Then
                TxtSalePrice.Text = ""
                lSalePrice = 0
                Exit Try
            End If

            Dim salePrice As Double = 0

            Select Case CmbSaleOn.Text
                Case cPTS
                    salePrice = currentStock.PTS

                Case cPTR
                    salePrice = currentStock.PTR

                Case cMRP
                    salePrice = currentStock.MRP

                Case cPTD
                    salePrice = currentStock.Rate3

                Case cRate1
                    salePrice = currentStock.Rate1

                Case cRate2
                    salePrice = currentStock.Rate2

            End Select

            lSalePrice = salePrice
            TxtSalePrice.Text = Format(salePrice, "0.00")

            Dim customerId As Integer = GetSelectedItemId(CmbCustomer)
            Dim price As Double = GetPrice(currentStock.ItemId, currentStock.Batch, customerId)
            If price <= 0 Then Exit Try

            lSalePrice = price
            TxtSalePrice.Text = Format(price, "0.00")

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Try
            If BtnAdd.Text = lcUpdate Then
                UpdateSaleDetailObject()
                Exit Sub
            End If

            If flagOldObject = False Then
                If AndedTheString(gUser.AuthorizationNo, Authorization.Sales_Current_NoAdd) = True Then Exit Sub
            Else
                If AndedTheString(gUser.AuthorizationNo, Authorization.Sales_Old_NoAdd) = True Then Exit Sub
            End If

            If ValidateValues() = False Then Exit Sub

            'Saving Master if virtual
            If lSalesObj Is Nothing Then
                Dim saleMasterObj As New ClsSalesMaster
                With saleMasterObj
                    .CustomerId = GetSelectedItemId(CmbCustomer)
                    .DoctorId = cInvalidId
                    .Mode = CmbMode.Text
                    .DiscountAmount = Val(TxtDiscountOnBill.Text)
                    '.Remark= TxtReference.Text
                    .Prescription = ""
                    .CashOutAmount = 0
                    .AdjustedAmount = 0
                    .SaleDate = DtPkrSaleDate.Value
                    .CashMemo = False
                    .ForCashOut = False
                    .UserId = gUser.LoginName
                    .DateOn = Now
                    .NotClosed = True
                    .DivisionId = GetSelectedItemId(CmbDivision)
                    .TransporterId = GetSelectedItemId(CmbTransporter)
                    .HQId = GetSelectedItemId(CmbHQ)
                    .PickSlipNo = TxtPickSlipNo.Text
                    .OrderNo = TxtOrderNo.Text
                    .Reference = TxtReference.Text
                    .Destination = TxtDestination.Text
                    .LRNo = TxtLRNo.Text
                    .ChequeNo = TxtChequeNo.Text
                    .Cases = TxtCases.Text
                    .LRDate = DtPkrLRDate.Value
                    .DueDate = DtPkrDueDate.Value
                    .OrderDate = DtPkrOrderDate.Value
                    .CreditAdjust = Val(TxtCreditAdj.Text)
                    .DebitAdjust = Val(TxtDebitAdj.Text)
                    .PreExciseAmount = Val(TxtPreExciseAmount.Text)
                    SetTaxIdAndTax(.TaxId, .TaxPercent)
                    .Cancelled = ChkCancel.Checked
                End With

                Dim saleId As Integer = InsertIntoSalesMaster(Me.Name, saleMasterObj)
                If saleId <= 0 Then Exit Try

                saleMasterObj.Id = saleId
                lSalesObj = saleMasterObj
                SetCustomerEnability(False)

                saleMasterObj = GetSalesMaster(Me.Name, saleId)
                If Not (saleMasterObj Is Nothing) Then
                    lSalesObj = saleMasterObj
                    TxtSaleCode.Text = lSalesObj.SaleCode

                    If lSalesObj.Cancelled = True Then ChkCancel.Enabled = False
                End If
            End If

            'Saving Detail
            Dim saleDetailObj As New ClsSalesDetail
            With saleDetailObj
                .SaleId = lSalesObj.Id
                Dim currentStock As ClsCurrentStock = lCurrentBatch 'CmbBatch.SelectedItem
                If currentStock Is Nothing Then
                    MsgBox("Item is not selected or Batch doesn't exist", , "Item")
                    Exit Sub
                End If
                Dim TaxId As Decimal

                Dim item As ClsItemMaster = GetSelectedItem(CmbItem)
                .ItemId = currentStock.ItemId
                .Batch = currentStock.Batch
                .ExpiryDate = currentStock.ExpiryDate
                .ManufacturerId = currentStock.ManufacturerId
                .PriceSale = lSalePrice 'Val(TxtSalePrice.Text)
                .PTS = currentStock.PTS
                .MRP = currentStock.MRP
                .PTR = currentStock.PTR
                .Rate1 = currentStock.Rate1
                .Rate2 = currentStock.Rate2
                .Rate3 = currentStock.Rate3
                .ManufactureDate = currentStock.ManufactureDate
                .PackQuantity = currentStock.PackQuantity
                .PricePurchase = currentStock.PricePurchase
                .ForCashOut = False
                '.TaxPercent = item.VAT
                SetTaxIdAndTax(TaxId, .TaxPercent)
                .DiscountPercent = Val(TxtDiscountPercent.Text)
                .SaleQuantity = Val(TxtQuantity.Text)
                .FreeQuantity = Val(TxtFreeQuantity.Text)
                .StorageId = currentStock.StorageId
                '.Remark = TxtReference.Text
                .UserId = gUser.LoginName
                .DateOn = Now
                .TaxAmount = .SaleQuantity * .PriceSale * .TaxPercent / 100
                CalculateTotal(.TaxAmount, .DiscountAmount)
            End With

            Dim id As Long = InsertIntoSalesDetail(Me.Name, saleDetailObj)
            If id > 0 Then
                saleDetailObj.Id = id
                InsertIntoSaleGrid(saleDetailObj)
                'UpdateCurrentStockForItemIdBatch(saleDetailObj.ItemId, saleDetailObj.Batch)
                GetAllCurrentStock(Me.Name)
                CalculateTotals()
                lSalesObj.NotClosed = True
            End If

            MsgBox("Successfully Added", , "Added")

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNewItem()
    End Sub

    Private Sub BtnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemove.Click
        Try
            Dim row As DataGridViewRow = GrdSale.SelectedRows(0)
            If row Is Nothing Then Exit Try

            If flagOldObject = False Then
                If AndedTheString(gUser.AuthorizationNo, Authorization.Sales_Current_NoRemove) = True Then Exit Sub
            Else
                If AndedTheString(gUser.AuthorizationNo, Authorization.Sales_Old_NoRemove) = True Then Exit Sub
            End If

            Dim id As Long = row.Cells(cId).Value
            If id <= 0 Then Exit Try

            If MsgBox("Do you really wants to remove selected record? Removed records can't be recovered.", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                If DeleteSalesDetail(Me.Name, id) <> EnResult.Change Then Exit Sub

                lSalesObj.NotClosed = True
                'UpdateCurrentStockForItemIdBatch(row.Cells(cItemId).Value, row.Cells(cBatchX).Value)
                GetAllCurrentStock(Me.Name)
                GrdSale.Rows.Remove(row)
                CalculateTotals()
                MsgBox("Successfully Removed", , "Removed")
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNewItem()
    End Sub

    Private Sub GrdSale_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdSale.CellClick
        If e.RowIndex < 0 Then Exit Sub
        If flagOldObject = False Then
            If AndedTheString(gUser.AuthorizationNo, Authorization.Sales_Current_NoRemove) = True Then Exit Sub
        Else
            If AndedTheString(gUser.AuthorizationNo, Authorization.Sales_Old_NoRemove) = True Then Exit Sub
        End If

        BtnRemove.Enabled = True
        BtnAddFreeItems.Enabled = False
        BtnAdd.Enabled = False
        BtnNew.Text = lcCancel
    End Sub

    Private Sub GrdSale_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdSale.CellDoubleClick
        Try
            BtnRemove.Enabled = False
            If e.RowIndex < 0 Then Exit Try
            If flagOldObject = False Then
                If AndedTheString(gUser.AuthorizationNo, Authorization.Sales_Current_NoUpdate) = True Then Exit Sub
            Else
                If AndedTheString(gUser.AuthorizationNo, Authorization.Sales_Old_NoUpdate) = True Then Exit Sub
            End If

            editRow = GrdSale.Rows(e.RowIndex)
            flagLoadForUpdate = True
            ' LoadComboBoxValuesForItemsWithUpdateItem()
            With editRow
                flagCategoryChange = EnLoading.LoadOnChange
                CmbCategory.Text = GetCategoryForItemId(.Cells(cItemId).Value)
                flagCategoryChange = EnLoading.None
                'Dim str As String = .Cells(cName).Value + "[" + .Cells(cBatchX).Value + "]"

                CmbItem.SelectedIndex = -1
                flagItemChanged = EnLoading.LoadOnChange
                CmbItem.Text = .Cells(cName).Value
                'SelectItemInBatchComboBox(.Cells(cBatch).Value)
                'CmbItem.Text = str
                TxtSalePrice.Text = Format(.Cells(cPriceSale).Value, "0.00")
                lSalePrice = .Cells(cPriceSale).Value
                TxtQuantity.Text = .Cells(cSaleQuantity).Value
                TxtFreeQuantity.Text = .Cells(cFreeQuantity).Value
                TxtDiscountPercent.Text = .Cells(cDiscountPercent).Value
            End With

            flagBatchChanged = EnLoading.None
            flagItemChanged = EnLoading.None
            BtnAdd.Text = lcUpdate
            BtnNew.Text = lcCancel
            BtnAddFreeItems.Enabled = False
            BtnAdd.Enabled = True
            CmbCategory.Focus()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub GrdSale_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdSale.KeyDown
        If e.KeyCode = Keys.Tab Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        If BtnNew.Text = lcCancel Then
            ResetControlsToAddNewItem()
        Else
            If Not (lSalesObj Is Nothing) Then
                If lSalesObj.NotClosed = True Then
                    If MsgBox("Sale Master is not updated." + vbCrLf + vbCrLf + "To update click save button." + vbCrLf + vbCrLf + "Do you want to update Sale master?", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                        Exit Sub
                    End If
                End If
            End If

            ResetControlsToAddNew()
        End If
    End Sub

    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch.Click
        Try
            Dim frm As New ClsSearchSaleForm
            If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Dim id As Long = frm.GetSelectedId
                If id > 0 Then
                    SetSaleForSaleId(id)
                    flagOldObject = True
                End If
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Try
            If lSalesObj Is Nothing Then
                MsgBox("There is no Sale selected. Please create or select Sales.", , "Sale")
                Exit Try
            End If

            If lSalesObj.Id <= 0 Then
                MsgBox("There is no Sale selected. Please create or select Sales.", , "Sale")
                Exit Try
            End If

            If lSalesObj.NotClosed = True Then
                MsgBox("Sales not saved. Please save your sales then print.", MsgBoxStyle.Information, "Not Saved.")
                Exit Try
            End If

            Dim saleId As Long = lSalesObj.Id
            Dim ds As DataSet = GetSales(Me.Name, saleId)

            If ds Is Nothing Then
                MsgBox("Error in generating report.", MsgBoxStyle.Critical, "Error")
                Exit Try
            End If

            If ds.Tables(0).Rows.Count = 0 Then
                MsgBox("No record is present for this selection.", MsgBoxStyle.Information, "No Record")
                Exit Try
            End If

            Dim remark As String = ""
            If lSalesObj.NotClosed = True Then
                remark = "## This is temporary bill. ##"
            End If

            'ds2.Tables(0).Columns(a
            'Dim dsLogo As DataSet = GetCompanyLogo(Me.Name)
            Dim rof As Double = Val(TxtBillRoundOff.Text) 'GetTransactionAccountRoundOffForVoucherNo(Me.Name, lSalesObj.SaleCode)
            'Dim discountAmt As Double = GetSalesMasterDiscountAmount(Me.Name, lSalesObj.Id)

            Dim dsFree As DataSet = GetFreeStockTransactionForSaleId(Me.Name, saleId)
            Dim dsLegalTerms As DataSet = GetLegalTermsForReport(Me.Name)

            'Opening Report
            SetWaitCursor()
            Dim rpt As New RptSales
            'If dsFree IsNot Nothing Then
            '    Dim subReport As CrystalDecisions.CrystalReports.Engine.ReportDocument = rpt.Subreports("RptFreeItemsSale")
            '    subReport.SetDataSource(dsFree.Tables(0))
            'End If
            'If dsLogo IsNot Nothing Then
            '    Dim subReport As CrystalDecisions.CrystalReports.Engine.ReportDocument = rpt.Subreports("RptCompanyLogo")
            '    subReport.SetDataSource(dsLogo.Tables(0))
            'End If
            'If dsLegalTerms IsNot Nothing Then
            '    Dim subReport As CrystalDecisions.CrystalReports.Engine.ReportDocument = rpt.Subreports("RptLegalTerms")
            '    subReport.SetDataSource(dsLegalTerms.Tables(0))
            'End If

            'Dim finalds As DataSet = CopyDataSet(ds)

            rpt.SetDataSource(ds.Tables(0))
            rpt.SetParameterValue("ROF", rof)
            'rpt.SetParameterValue("Remark", remark)
            'rpt.SetParameterValue("DiscountAmount", discountAmt)
            Dim dlg As New DiagReport
            dlg.RptViewer.ReportSource = rpt
            'dlg.SetPrint()
            dlg.ShowDialog(Me)
        Catch ex As Exception
            AddToLog(ex)
        End Try

        SetDefaultCursor()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            If flagOldObject = False Then
                If AndedTheString(gUser.AuthorizationNo, Authorization.Sales_Current_NoUpdate) = True Then Exit Sub
            Else
                If AndedTheString(gUser.AuthorizationNo, Authorization.Sales_Old_NoUpdate) = True Then Exit Sub
            End If

            If lSalesObj Is Nothing Then Exit Try

            If lSalesObj.Cancelled <> ChkCancel.Checked Then
                If CheckToCancelQuantity() = True Then
                    UpdateSaleDetailObjectForCancel()
                End If

                TxtDiscountOnBill.Text = ""
                TxtCreditAdj.Text = ""
                TxtDebitAdj.Text = ""
                TxtPreExciseAmount.Text = ""
            End If

            Dim netAmount As Double = Val(TxtBillNetAmount.Text)

            'Updating Master
            Dim saleMasterObj As New ClsSalesMaster
            With saleMasterObj
                .Id = lSalesObj.Id
                .SaleCode = lSalesObj.SaleCode
                .CustomerId = GetSelectedItemId(CmbCustomer)
                .DoctorId = cInvalidId
                .Mode = CmbMode.Text
                .DiscountAmount = Val(TxtDiscountOnBill.Text)
                '.Remark = TxtReference.Text
                .Prescription = lSalesObj.Prescription
                .CashOutAmount = lSalesObj.CashOutAmount
                .AdjustedAmount = lSalesObj.AdjustedAmount
                .SaleDate = DtPkrSaleDate.Value
                'If netAmount > 0 Then
                '    Dim bal As Double = netAmount - lSalesObj.CashOutAmount
                '    If bal > 1 Then
                '        .CashOut = True     'Open to cash out
                '    Else
                '        .CashOut = False    'Close to cash out
                '    End If
                'Else
                '    .CashOut = lSalesObj.CashOut
                'End If
                .CashMemo = False
                .ForCashOut = False
                .UserId = gUser.LoginName
                .DateOn = Now
                .NotClosed = False
                .DivisionId = GetSelectedItemId(CmbDivision)
                .TransporterId = GetSelectedItemId(CmbTransporter)
                .HQId = GetSelectedItemId(CmbHQ)
                .PickSlipNo = TxtPickSlipNo.Text
                .OrderNo = TxtOrderNo.Text
                .Reference = TxtReference.Text
                .Destination = TxtDestination.Text
                .LRNo = TxtLRNo.Text
                .ChequeNo = TxtChequeNo.Text
                .Cases = TxtCases.Text
                .LRDate = DtPkrLRDate.Value
                .DueDate = DtPkrDueDate.Value
                .OrderDate = DtPkrOrderDate.Value
                .CreditAdjust = Val(TxtCreditAdj.Text)
                .DebitAdjust = Val(TxtDebitAdj.Text)
                .PreExciseAmount = Val(TxtPreExciseAmount.Text)
                .FreightCharge = Val(TxtFrieght.Text)
                SetTaxIdAndTax(.TaxId, .TaxPercent)
                .Cancelled = ChkCancel.Checked
            End With

            If UpdateSalesMaster(Me.Name, saleMasterObj) <> EnResult.Change Then Exit Sub
            lSalesObj = saleMasterObj
            If lSalesObj.Cancelled = True Then ChkCancel.Enabled = False

            MsgBox("Successfully Saved", , "Saved")

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub TxtQuantity_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtQuantity.TextChanged
        If TxtQuantity.Text.Trim = "" Then Exit Sub

        CalculateTotal()
    End Sub

    Private Sub TxtSalePrice_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSalePrice.TextChanged
        If TxtSalePrice.Text.Trim = "" Then Exit Sub

        CalculateTotal()
    End Sub

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtTotal.KeyDown, TxtSalePrice.KeyDown, TxtSaleCode.KeyDown, TxtReference.KeyDown, TxtQuantity.KeyDown, TxtGrossAmount.KeyDown, TxtBillRoundOff.KeyDown, TxtBillNetAmount.KeyDown, DtPkrSaleDate.KeyDown, CmbItem.KeyDown, CmbCustomer.KeyDown, CmbMode.KeyDown, TxtDiscountOnBill.KeyDown, CmbCategory.KeyDown, TxtTinNo.KeyDown, TxtPickSlipNo.KeyDown, TxtOrderNo.KeyDown, TxtLRNo.KeyDown, TxtDestination.KeyDown, TxtChequeNo.KeyDown, TxtCases.KeyDown, DtPkrOrderDate.KeyDown, DtPkrLRDate.KeyDown, DtPkrDueDate.KeyDown, CmbTransporter.KeyDown, CmbHQ.KeyDown, CmbDivision.KeyDown, TxtTaxAmt.KeyDown, TxtTaxableAmount.KeyDown, TxtPreExciseAmount.KeyDown, TxtFreeQuantity.KeyDown, TxtDiscountPercent.KeyDown, TxtDebitAdj.KeyDown, TxtCreditAdj.KeyDown, CmbTax.KeyDown, CmbSaleOn.KeyDown, TxtOverAllDiscount.KeyDown, TxtDiscount.KeyDown, TxtFrieght.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub CmbCardNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then CmbCustomer.Focus()
    End Sub

    Private Sub BtnAddFreeItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddFreeItems.Click
        Try
            Dim frm As New FrmFreeStockTransaction
            frm.SetSaleObject(lSalesObj)
            frm.ShowDialog(Me)

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub TxtDiscountOnBill_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDiscountOnBill.TextChanged
        CalculateTaxableAmount()
        CalculateTotalDiscount()
    End Sub

    Private Sub CmbCategory_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbCategory.LostFocus
        Try
            If flagCategoryChange <> EnLoading.LoadOnLostFocus Then Exit Try

            flagCategoryChange = EnLoading.None
            LoadComboBoxValuesForItems()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub CmbCategory_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbCategory.SelectedIndexChanged
        Try
            If flagCategoryChange = EnLoading.None Then flagCategoryChange = EnLoading.LoadOnLostFocus
            If flagCategoryChange <> EnLoading.LoadOnChange Then Exit Try

            LoadComboBoxValuesForItems()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub CmbTax_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbTax.SelectedIndexChanged
        If lFlagTaxNot = EnLoading.LoadOnChange Then lFlagTaxNot = EnLoading.None
        CalculateTax()
    End Sub

    Private Sub CmbSaleOn_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbSaleOn.SelectedIndexChanged
        SetCurrentPrice()
    End Sub

    Private Sub TxtDiscountPercent_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDiscountPercent.TextChanged
        CalculateTotal()
    End Sub

    Private Sub TxtGrossAmount_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtGrossAmount.TextChanged
        CalculateTaxableAmount()
        CalculateBillTotal()
    End Sub

    Private Sub TxtDiscount_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDiscount.TextChanged
        CalculateTotalDiscount()
    End Sub

    Private Sub TxtTaxableAmount_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtTaxableAmount.TextChanged
        CalculateTax()
    End Sub

    Private Sub TxtTaxAmt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtTaxAmt.TextChanged
        CalculateBillTotal()
    End Sub

    Private Sub TxtOverAllDiscount_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtOverAllDiscount.TextChanged
        CalculateBillTotal()
    End Sub

    Private Sub TxtCreditAdj_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCreditAdj.TextChanged
        CalculateBillTotal()
    End Sub

    Private Sub TxtDebitAdj_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDebitAdj.TextChanged
        CalculateBillTotal()
    End Sub

    Private Sub TxtFrieght_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFrieght.TextChanged
        CalculateBillTotal()
    End Sub

    Private Sub DtPkrLRDate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtPkrLRDate.TextChanged
        Try
            Dim customer As ClsCustomerMaster = CmbCustomer.SelectedItem
            If customer Is Nothing Then Exit Try

            DtPkrDueDate.Value = DtPkrLRDate.Value.Date.AddDays(customer.DueDays)

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

#End Region

#Region "Other Form Functionality"

    'Private Sub LblAddDoctor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If AndedTheString(gUser.AuthorizationNo, Authorization.Doctors) = False Then Exit Sub
    '    Try
    '        Dim frm As New FrmDoctorMaster
    '        frm.ShowDialog(Me)
    '        If frm.Change = True Then LoadComboBoxValuesForDoctors()

    '        frm.Dispose()

    '    Catch ex As Exception
    '        AddToLog(ex)
    '    End Try
    'End Sub

    Private Sub LblAddCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblAddCustomer.Click
        If AndedTheString(gUser.AuthorizationNo, Authorization.Customers) = False Then Exit Sub
        Try
            Dim frm As New FrmCustomerMaster
            frm.ShowDialog(Me)
            If frm.Change = True Then
                'LoadComboBoxValuesForCardNo()
                LoadComboBoxValuesForCustomers()
            End If

            frm.Dispose()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LblAddHQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblAddHQ.Click
        'If AndedTheString(gUser.AuthorizationNo, Authorization.HQ) = False Then Exit Sub
        Try
            Dim frm As New FrmHQMaster
            frm.ShowDialog(Me)
            If frm.Change = True Then LoadComboBoxValuesForHQ()

            frm.Dispose()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LblAddTransporter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblAddTransporter.Click
        'If AndedTheString(gUser.AuthorizationNo, Authorization.Transporter) = False Then Exit Sub
        Try
            Dim frm As New FrmTransporter
            frm.ShowDialog(Me)
            If frm.Change = True Then LoadComboBoxValuesForTransporter()

            frm.Dispose()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LblAddDivision_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblAddDivision.Click
        'If AndedTheString(gUser.AuthorizationNo, Authorization.Division) = False Then Exit Sub
        Try
            Dim frm As New FrmDivisionMaster
            frm.ShowDialog(Me)
            If frm.Change = True Then LoadComboBoxValuesForDivision()

            frm.Dispose()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

#End Region

#Region "Private Function"

    Private Sub SetControls()
        SetGridForSale()
        GetAllItemMaster(Me.Name)
        GetAllCurrentStock(Me.Name)
        LoadItems()
        LoadComboBoxValues()
        LoadStorages()
        ResetControlsToAddNew()
        'Load Grid values after ComboBox Values

        SetSaleIdForCurrentLogin()
        LoadGridValuesForSale()
        CalculateTotals()
    End Sub

    Private Sub SetGridForSale()
        With GrdSale
            Dim colCount As Integer = 30
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
                        .Columns(index).Width = defaultCellWidth + 250

                    Case 2
                        Dim index As Integer = .Columns.Add(cPackQuantity, "Pack Qty.")
                        .Columns(index).Visible = False
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 3
                        Dim index As Integer = .Columns.Add(cBatch, cBatch)
                        .Columns(index).Width = defaultCellWidth + 60
                        .Columns(index).Visible = False

                    Case 4
                        Dim index As Integer = .Columns.Add(cManufacturerId, cManufacturerId)
                        .Columns(index).Visible = False

                    Case 5
                        Dim index As Integer = .Columns.Add(cManufacturer, "Mfg By")
                        .Columns(index).Width = defaultCellWidth + 60
                        .Columns(index).Visible = False

                    Case 6
                        Dim index As Integer = .Columns.Add(cManufactureDate, "Mfg Dt.")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "MMM-yyyy"
                        .Columns(index).Visible = False
                        .Columns(index).Visible = False

                    Case 7
                        Dim index As Integer = .Columns.Add(cExpiryDate, "Exp. Date")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "MMM-yyyy"
                        .Columns(index).Visible = False
                        .Columns(index).Visible = False

                    Case 8
                        Dim index As Integer = .Columns.Add(cSaleQuantity, "Unit")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        '.Columns(index).Visible = False
                    Case 9
                        Dim index As Integer = .Columns.Add(cFreeQuantity, "Free")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns(index).Visible = False
                    Case 10
                        Dim index As Integer = .Columns.Add(cPriceSale, "Price Sale")
                        .Columns(index).Width = defaultCellWidth + 20
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns(index).Visible = False
                    Case 11
                        Dim index As Integer = .Columns.Add(cPTS, cPTS)
                        .Columns(index).Width = defaultCellWidth + 20
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns(index).Visible = False
                    Case 12
                        Dim index As Integer = .Columns.Add(cMRP, cMRP)
                        .Columns(index).Width = defaultCellWidth + 20
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 13
                        Dim index As Integer = .Columns.Add(cPTR, cPTR)
                        .Columns(index).Width = defaultCellWidth + 20
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns(index).Visible = False
                    Case 14
                        Dim index As Integer = .Columns.Add(cPTD, cPTD)
                        .Columns(index).Width = defaultCellWidth + 20
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns(index).Visible = False
                        'Case 15
                        '    Dim index As Integer = .Columns.Add(cRate1, cRate1)
                        '    .Columns(index).Width = defaultCellWidth + 20
                        '    .Columns(index).DefaultCellStyle.Format = "0.00"
                        '    .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                        'Case 16
                        '    Dim index As Integer = .Columns.Add(cRate2, cRate2)
                        '    .Columns(index).Width = defaultCellWidth + 20
                        '    .Columns(index).DefaultCellStyle.Format = "0.00"
                        '    .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 17
                        Dim index As Integer = .Columns.Add(cTaxPercent, "Tax %")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns(index).Visible = False

                    Case 18
                        Dim index As Integer = .Columns.Add(cTaxAmount, "Tax")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        '.Columns(index).Visible = False

                    Case 19
                        Dim index As Integer = .Columns.Add(cDiscountPercent, "Dis. %")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns(index).Visible = False
                    Case 20
                        Dim index As Integer = .Columns.Add(cDiscountAmount, "Discount")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns(index).Visible = False

                    Case 21
                        Dim index As Integer = .Columns.Add(cStorage, cStorage)
                        .Columns(index).Visible = False
                        .Columns(index).Width = defaultCellWidth

                    Case 22
                        Dim index As Integer = .Columns.Add(cTotal, "Amount")
                        .Columns(index).Width = defaultCellWidth + 20
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                        'Case 23
                        '    Dim index As Integer = .Columns.Add(cTotal, "Gross Amount")
                        '    .Columns(index).Width = defaultCellWidth + 20
                        '    .Columns(index).DefaultCellStyle.Format = "0.00"
                        '    .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


                    Case 23
                        Dim index As Integer = .Columns.Add(cItemId, cItemId)
                        .Columns(index).Visible = False

                    Case 24
                        Dim index As Integer = .Columns.Add(cStorageId, cStorageId)
                        .Columns(index).Visible = False

                    Case 25
                        Dim index As Integer = .Columns.Add(cSaleId, cSaleId)
                        .Columns(index).Visible = False

                    Case 26
                        Dim index As Integer = .Columns.Add(cPricePurchase, cPricePurchase)
                        .Columns(index).Visible = False

                    Case 27
                        Dim index As Integer = .Columns.Add(cRemark, cRemark)
                        .Columns(index).Visible = False

                    Case 28
                        Dim index As Integer = .Columns.Add(cForCashOut, cForCashOut)
                        .Columns(index).Visible = False

                    Case 29
                        Dim index As Integer = .Columns.Add(cUserId, cUserId)
                        .Columns(index).Visible = False

                    Case 30
                        Dim index As Integer = .Columns.Add(cDateOn, cDateOn)
                        .Columns(index).Visible = False

                End Select
            Next
        End With
    End Sub

    Private Sub LoadGridValuesForSale()
        Try
            GrdSale.Rows.Clear()

            If lSalesObj Is Nothing Then Exit Try

            Dim saleDetails() As ClsSalesDetail = GetAllSalesDetailForSalesId(Me.Name, lSalesObj.Id)
            If saleDetails Is Nothing Then Exit Try

            Dim saleDetail As ClsSalesDetail
            For Each saleDetail In saleDetails
                InsertIntoSaleGrid(saleDetail)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub InsertIntoSaleGrid(ByRef saleDetailObj As ClsSalesDetail)
        Try
            If saleDetailObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdSale.Rows.Add
            With GrdSale.Rows(rowIndex)
                .Cells(cId).Value = saleDetailObj.Id
                .Cells(cItemId).Value = saleDetailObj.ItemId
                .Cells(cStorageId).Value = saleDetailObj.StorageId
                .Cells(cBatch).Value = saleDetailObj.Batch
                .Cells(cExpiryDate).Value = saleDetailObj.ExpiryDate
                .Cells(cManufacturerId).Value = saleDetailObj.ManufacturerId
                .Cells(cManufacturer).Value = GetManufacturer(.Cells(cManufacturerId).Value)
                .Cells(cPriceSale).Value = saleDetailObj.PriceSale
                .Cells(cMRP).Value = saleDetailObj.MRP
                .Cells(cPTR).Value = saleDetailObj.PTR
                .Cells(cPTS).Value = saleDetailObj.PTS
                .Cells(cPTD).Value = saleDetailObj.Rate3
                '.Cells(cRate1).Value = saleDetailObj.Rate1
                '.Cells(cRate2).Value = saleDetailObj.Rate2
                .Cells(cManufactureDate).Value = saleDetailObj.ManufactureDate
                .Cells(cSaleQuantity).Value = saleDetailObj.SaleQuantity
                .Cells(cFreeQuantity).Value = saleDetailObj.FreeQuantity
                .Cells(cPackQuantity).Value = saleDetailObj.PackQuantity
                .Cells(cTaxPercent).Value = saleDetailObj.TaxPercent
                .Cells(cTaxAmount).Value = saleDetailObj.TaxAmount
                .Cells(cDiscountPercent).Value = saleDetailObj.DiscountPercent
                .Cells(cDiscountAmount).Value = saleDetailObj.DiscountAmount
                .Cells(cTotal).Value = saleDetailObj.GetTotal
                '.Cells(cTotal1).Value = saleDetailObj.GetTotal1
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

    Private Sub LoadComboBoxValues()
        With CmbMode.Items
            .Clear()
            .Add(cStatusCash)
            .Add(cStatusCredit)
        End With

        CmbMode.Text = cStatusCash

        With CmbSaleOn.Items
            .Clear()
            .Add(cMRP)
            '.Add(cPTR)
            '.Add(cPTS)
            '.Add(cPTD)
            .Add(cRate1)
            .Add(cRate2)
        End With

        CmbSaleOn.Text = cMRP

        LoadComboBoxValuesForTax()
        LoadManufacturers()
        LoadComboBoxValuesForCategory()
        LoadComboBoxValuesForCustomers()
        'LoadComboBoxValuesForDoctors()
        LoadComboBoxValuesForDivision()
        LoadComboBoxValuesForTransporter()
        LoadComboBoxValuesForHQ()
        'LoadComboBoxValuesForCardNo()
    End Sub

    Private Sub LoadComboBoxValuesForCategory()
        Try
            CmbCategory.DataSource = Nothing
            CmbCategory.Items.Clear()
            CmbCategory.Text = ""

            Dim categories() As ClsCategoryMaster = GetAllCategoryMaster(Me.Name)
            If categories Is Nothing Then Exit Try

            flagCategoryChange = EnLoading.LoadOnChange
            CmbCategory.DataSource = categories
            CmbCategory.DisplayMember = cName
            CmbCategory.ValueMember = cId

            If CmbCategory.Items.Count > 0 Then CmbCategory.SelectedIndex = 0
            flagCategoryChange = EnLoading.None

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadComboBoxValuesForCustomers()
        Try
            CmbCustomer.DataSource = Nothing
            CmbCustomer.Items.Clear()
            CmbCustomer.Text = ""

            Dim customers() As ClsCustomerMaster = GetAllCustomerMaster(Me.Name)
            If customers Is Nothing Then Exit Try

            flagCustomerChanged = EnLoading.None
            CmbCustomer.DataSource = customers
            CmbCustomer.DisplayMember = cName
            CmbCustomer.ValueMember = cId
            CmbCustomer.Text = ""
            flagCustomerChanged = EnLoading.None

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadComboBoxValuesForDivision()
        Try
            CmbDivision.DataSource = Nothing
            CmbDivision.Items.Clear()
            CmbDivision.Text = ""

            Dim divisions() As ClsDivisionMaster = GetAllDivisionMaster(Me.Name)
            If divisions Is Nothing Then Exit Try

            CmbDivision.DataSource = divisions
            CmbDivision.DisplayMember = cName
            CmbDivision.ValueMember = cId
            CmbDivision.Text = ""
            'If CmbDivision.Items.Count > 0 Then CmbDivision.SelectedIndex = 0

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadComboBoxValuesForTransporter()
        Try
            CmbTransporter.DataSource = Nothing
            CmbTransporter.Items.Clear()
            CmbTransporter.Text = ""

            Dim transporters() As ClsTransporter = GetAllTransporter(Me.Name)
            If transporters Is Nothing Then Exit Try

            CmbTransporter.DataSource = transporters
            CmbTransporter.DisplayMember = cName
            CmbTransporter.ValueMember = cId
            CmbTransporter.Text = ""
            'If CmbTransporter.Items.Count > 0 Then CmbTransporter.SelectedIndex = 0

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadComboBoxValuesForHQ()
        Try
            CmbHQ.DataSource = Nothing
            CmbHQ.Items.Clear()
            CmbHQ.Text = ""

            Dim hqs() As ClsHQMaster = GetAllHQMaster(Me.Name)
            If hqs Is Nothing Then Exit Try

            CmbHQ.DataSource = hqs
            CmbHQ.DisplayMember = cName
            CmbHQ.ValueMember = cId
            CmbHQ.Text = ""
            'If CmbHQ.Items.Count > 0 Then CmbHQ.SelectedIndex = 0

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    'Private Sub LoadComboBoxValuesForDoctors()
    '    Try
    '        CmbDoctor.DataSource = Nothing
    '        CmbDoctor.Items.Clear()
    '        CmbDoctor.Text = ""

    '        Dim doctors() As ClsDoctorMaster = GetAllDoctorMaster(Me.Name)
    '        If doctors Is Nothing Then Exit Try

    '        CmbDoctor.DataSource = doctors
    '        CmbDoctor.DisplayMember = cName
    '        CmbDoctor.ValueMember = cId
    '        If CmbDoctor.Items.Count > 0 Then CmbDoctor.SelectedIndex = 0

    '    Catch ex As Exception
    '        AddToLog(ex)
    '    End Try
    'End Sub

    Private Sub LoadComboBoxValuesForItems()
        Try
            CmbItem.DataSource = Nothing
            CmbItem.Items.Clear()
            CmbItem.Text = ""

            Dim categoryId As Integer = GetSelectedItemId(CmbCategory)
            If categoryId <= 0 Then Exit Try

            Dim items() As ClsItemMaster = GetAllItemMasterForCategoryId(Me.Name, categoryId, False)
            If items Is Nothing Then Exit Try

            CmbItem.DataSource = items
            CmbItem.DisplayMember = cName
            CmbItem.ValueMember = cId
            CmbItem.SelectedIndex = -1

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    'Private Sub LoadComboBoxValuesForItemsWithUpdateItem()
    '    Try
    '        LoadComboBoxValuesForItems()

    '        If flagLoadForUpdate = False Then Exit Try
    '        If editRow Is Nothing Then Exit Try

    '        Dim itemId As Integer = editRow.Cells(cItemId).Value
    '        Dim batch As String = editRow.Cells(cBatchX).Value

    '        Dim obj As ClsCurrentStock
    '        For Each obj In CmbItem.Items
    '            If obj.ItemId = itemId And obj.Batch = batch Then Exit Try
    '        Next

    '        Dim currentStock As ClsCurrentStock = GetCurrentStockForItemIdAndBatch(Me.Name, itemId, batch)
    '        If currentStock Is Nothing Then Exit Try

    '        With currentStock
    '            .SetName(GetItemName(.ItemId))
    '        End With

    '        CmbItem.Items.Add(currentStock)

    '    Catch ex As Exception
    '        AddToLog(ex)
    '    End Try
    'End Sub

    Private Sub LoadItems()
        Try
            lItems = GetAllItemMaster(Me.Name, False)

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    'Private Sub LoadComboBoxValuesForCardNo()
    '    Try
    '        CmbCardNo.Items.Clear()

    '        Dim customers() As ClsCustomerMaster = GetAllCustomerMaster(Me.Name)
    '        If customers Is Nothing Then Exit Try

    '        CmbCardNo.DisplayMember = cCardNo
    '        CmbCardNo.ValueMember = cId
    '        Dim customer As ClsCustomerMaster
    '        For Each customer In customers
    '            'If customer.CardNo = "" Then Continue For

    '            CmbCardNo.Items.Add(customer)
    '        Next

    '    Catch ex As Exception
    '        AddToLog(ex)
    '    End Try
    'End Sub

    Private Sub LoadStorages()
        Try
            lStorages = GetAllStorageMaster(Me.Name)

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadManufacturers()
        Try
            lManufacturers = GetAllManufacturerMaster(Me.Name)

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Function GetManufacturer(ByVal id As Integer) As String
        Dim result As String = ""
        Try
            If lManufacturers Is Nothing Then Exit Try

            Dim manufacturer As ClsManufacturerMaster
            For Each manufacturer In lManufacturers
                If manufacturer.Id = id Then
                    result = manufacturer.Name
                    Exit Try
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    'Private Sub LoadCurrentStocks()
    '    Try
    '        lCurrentStocks = GetAllCurrentStock(Me.Name)

    '    Catch ex As Exception
    '        AddToLog(ex)
    '    End Try
    'End Sub

    'Private Function GetAllCurrentStockForItemId(ByVal itemId As Integer) As List(Of ClsCurrentStock)
    '    Dim lst As New List(Of ClsCurrentStock)
    '    Try
    '        If itemId <= 0 Or lCurrentStocks Is Nothing Then Exit Try

    '        Dim currentStock As ClsCurrentStock
    '        For Each currentStock In lCurrentStocks
    '            If currentStock.ItemId = itemId Then
    '                lst.Add(currentStock)
    '            End If
    '        Next

    '    Catch ex As Exception
    '        AddToLog(ex)
    '    End Try

    '    Return lst
    'End Function

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
            If lItems Is Nothing Then Exit Try

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

    'Private Function GetItemName(ByVal id As Integer, ByRef categoryId As Integer) As String
    '    Dim result As String = ""
    '    Try
    '        If lItems Is Nothing Then Exit Try

    '        Dim item As ClsItemMaster
    '        For Each item In lItems
    '            If item.Id = id Then
    '                result = item.Name
    '                categoryId = item.CategoryId
    '                Exit Try
    '            End If
    '        Next

    '    Catch ex As Exception
    '        AddToLog(ex)
    '    End Try

    '    Return result
    'End Function

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

    Private Function GetDivision(ByVal id As Integer) As String
        Dim result As String = ""
        Try
            Dim division As ClsDivisionMaster
            For Each division In CmbDivision.Items
                If division.Id = id Then
                    result = division.Name
                    Exit Try
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Function GetTransporter(ByVal id As Integer) As String
        Dim result As String = ""
        Try
            Dim transporter As ClsTransporter
            For Each transporter In CmbTransporter.Items
                If transporter.Id = id Then
                    result = transporter.Name
                    Exit Try
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Function GetHQ(ByVal id As Integer) As String
        Dim result As String = ""
        Try
            Dim hq As ClsHQMaster
            For Each hq In CmbHQ.Items
                If hq.Id = id Then
                    result = hq.Name
                    Exit Try
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Function GetTaxName(ByVal id As Integer) As String
        Dim result As String = ""
        Try
            If id = cInvalidId Then Exit Try

            For Each tax As ClsTaxMaster In CmbTax.Items
                If tax.Id = id Then
                    result = tax.Name
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
            'Dim doctor As ClsDoctorMaster
            'For Each doctor In CmbDoctor.Items
            '    If doctor.Id = id Then
            '        result = doctor.Name
            '        Exit Try
            '    End If
            'Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Function ValidateValues() As Boolean
        Dim result As Boolean = False
        Try
            RemoveErrorIcon()

            If CmbCustomer.Text.Trim = "" Then
                ErrorInData("Please select customer.", CmbCustomer)
                Exit Try
            End If

            'SaveVirtualCustomer()

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
            '    ErrorInData("Please select Batch.", CmbBatch)
            '    Exit Try
            'End If

            'If CmbBatch.FindStringExact(CmbBatch.Text.Trim) < 0 Then
            '    ErrorInData("Please select valid batch from batch list.", CmbBatch)
            '    Exit Try
            'End If

            If TxtQuantity.Text.Trim = "" Then
                ErrorInData("Please enter sale quantity.", TxtQuantity)
                Exit Try
            End If

            'If Val(TxtQuantity.Text) <= 0 Then
            '    ErrorInData("Please enter sale quantity greater then 0.", TxtQuantity)
            '    Exit Try
            'End If

            'If TxtSalePrice.Text.Trim = "" Or lSalePrice = 0 Then
            '    ErrorInData("Please enter sale price.", TxtSalePrice)
            '    Exit Try
            'End If

            'If ValidateForQuantity() = False Then Exit Try

            result = True

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    ''Private Function ValidateForQuantity() As Boolean
    ''    Dim result As Boolean = False
    ''    Try
    ''        Dim qty As Double = Val(TxtQuantity.Text)
    ''        If qty = 0 Then Exit Try

    ''        Dim currentStock As ClsCurrentStock = GetSelectedItem(CmbItem)
    ''        If currentStock Is Nothing Then Exit Try

    ''        Dim row As DataGridViewRow = GetRowForValues(GrdItems, currentStock.ItemId, currentStock.Batch, cId)
    ''        If row Is Nothing Then Exit Try

    ''        Dim currentQty As Double = row.Cells(cCurrentQuantity).Value
    ''        If editRow Is Nothing Then
    ''            If currentQty < qty Then
    ''                ErrorInData("Quantity should not be greater then available quantity.", TxtQuantity)
    ''                result = False
    ''                Exit Try
    ''            End If
    ''        Else
    ''            Dim saleQtyPrv As Double = editRow.Cells(cSaleQuantity).Value
    ''            Dim diffQty As Double = qty - saleQtyPrv
    ''            If currentQty < diffQty Then
    ''                ErrorInData("Quantity not available.", TxtQuantity)
    ''                result = False
    ''                Exit Try
    ''            End If
    ''        End If

    ''        result = True

    ''    Catch ex As Exception
    ''        AddToLog(ex)
    ''    End Try

    ''    Return result
    ''End Function

    Private Sub UpdateSaleDetailObject()
        Try
            If editRow Is Nothing Or lSalesObj Is Nothing Then Exit Try
            If flagOldObject = False Then
                If AndedTheString(gUser.AuthorizationNo, Authorization.Sales_Current_NoUpdate) = True Then Exit Sub
            Else
                If AndedTheString(gUser.AuthorizationNo, Authorization.Sales_Old_NoUpdate) = True Then Exit Sub
            End If


            If ValidateValues() = False Then Exit Sub

            Dim currentStock As ClsCurrentStock = lCurrentBatch '(CmbBatch)
            If currentStock Is Nothing Then Exit Try

            'Updating Detail
            Dim saleDetailObj As New ClsSalesDetail
            With saleDetailObj
                Dim item As ClsItemMaster = GetSelectedItem(CmbItem)
                .Id = editRow.Cells(cId).Value
                .SaleId = lSalesObj.Id
                .ItemId = currentStock.ItemId
                .PriceSale = lSalePrice 'Val(TxtSalePrice.Text)
                .SaleQuantity = Val(TxtQuantity.Text)
                .FreeQuantity = Val(TxtFreeQuantity.Text)
                .TaxPercent = item.VAT
                .DiscountPercent = Val(TxtDiscountPercent.Text)
                .Batch = currentStock.Batch
                .ExpiryDate = currentStock.ExpiryDate
                .ManufacturerId = currentStock.ManufacturerId
                .MRP = currentStock.MRP
                .PTR = currentStock.PTR
                .PTS = currentStock.PTS
                .Rate1 = currentStock.Rate1
                .Rate2 = currentStock.Rate2
                .Rate3 = currentStock.Rate3
                .ManufactureDate = currentStock.ManufactureDate
                .PricePurchase = currentStock.PricePurchase
                .PackQuantity = currentStock.PackQuantity
                .StorageId = currentStock.StorageId
                '.Remark = TxtReference.Text
                .UserId = gUser.LoginName
                .DateOn = Now
                .ForCashOut = False
                .TaxAmount = .SaleQuantity * .PriceSale * .TaxPercent / 100
                CalculateTotal(.TaxAmount, .DiscountAmount)
            End With

            If UpdateSalesDetail(Me.Name, saleDetailObj) <> EnResult.Change Then Exit Sub

            With editRow
                .Cells(cItemId).Value = saleDetailObj.ItemId
                .Cells(cStorageId).Value = saleDetailObj.StorageId
                .Cells(cBatch).Value = saleDetailObj.Batch
                .Cells(cExpiryDate).Value = saleDetailObj.ExpiryDate
                .Cells(cManufacturerId).Value = saleDetailObj.ManufacturerId
                .Cells(cManufacturer).Value = GetManufacturer(.Cells(cManufacturerId).Value)
                .Cells(cManufactureDate).Value = saleDetailObj.ManufactureDate
                .Cells(cPriceSale).Value = saleDetailObj.PriceSale
                .Cells(cMRP).Value = saleDetailObj.MRP
                .Cells(cPTR).Value = saleDetailObj.PTR
                .Cells(cPTS).Value = saleDetailObj.PTS
                .Cells(cPTD).Value = saleDetailObj.Rate3
                '.Cells(cRate1).Value = saleDetailObj.Rate1
                '.Cells(cRate2).Value = saleDetailObj.Rate2
                .Cells(cSaleQuantity).Value = saleDetailObj.SaleQuantity
                .Cells(cFreeQuantity).Value = saleDetailObj.FreeQuantity
                .Cells(cPackQuantity).Value = saleDetailObj.PackQuantity
                .Cells(cTaxPercent).Value = saleDetailObj.TaxPercent
                .Cells(cTaxAmount).Value = saleDetailObj.TaxAmount
                .Cells(cDiscountPercent).Value = saleDetailObj.DiscountPercent
                .Cells(cDiscountAmount).Value = saleDetailObj.DiscountAmount
                .Cells(cTotal).Value = saleDetailObj.GetTotal
                .Cells(cStorage).Value = GetStorageName(.Cells(cStorageId).Value)
                .Cells(cName).Value = GetItemName(.Cells(cItemId).Value)
                .Cells(cPricePurchase).Value = saleDetailObj.PricePurchase
                .Cells(cRemark).Value = saleDetailObj.Remark
                .Cells(cForCashOut).Value = saleDetailObj.ForCashOut
                .Cells(cUserId).Value = saleDetailObj.UserId
                .Cells(cDateOn).Value = saleDetailObj.DateOn
            End With

            'UpdateCurrentStockForItemIdBatch(saleDetailObj.ItemId, saleDetailObj.Batch)
            GetAllCurrentStock(Me.Name)

            CalculateTotals()
            lSalesObj.NotClosed = True
            MsgBox("Successfully Updated", , "Updated")

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNewItem()
    End Sub

    Private Sub ResetControlsToAddNewItem()
        editRow = Nothing

        flagItemChanged = EnLoading.LoadOnChange
        CmbItem.SelectedIndex = -1
        'CmbBatch.Text = ""
        TxtQuantity.Text = ""
        TxtSalePrice.Text = ""
        lSalePrice = 0
        TxtTotal.Text = ""
        TxtDiscountPercent.Text = ""
        TxtFreeQuantity.Text = ""

        BtnAdd.Text = "&Add"
        BtnNew.Text = "&New"
        BtnAdd.Enabled = True
        BtnRemove.Enabled = False
        BtnAddFreeItems.Enabled = True
        flagCardNoChanged = False
        flagCustomerChanged = EnLoading.None
        flagItemChanged = EnLoading.None
        flagBatchChanged = EnLoading.None
        flagBatchChanged = False
        flagLoadForUpdate = False

        'LoadCurrentStocks()

        CmbCategory.Focus()
    End Sub

    Private Sub ResetControlsToAddNew()
        lFlagTaxNot = EnLoading.None
        ChkCancel.Enabled = True
        ChkCancel.Checked = False
        TxtSaleCode.Text = ""
        DtPkrSaleDate.Value = Now
        'CmbCardNo.Text = ""
        CmbCustomer.Text = ""
        TxtAddress.Text = ""
        TxtTinNo.Text = ""
        'TxtDLNo.Text = ""
        'CmbDoctor.Text = ""
        'ChkCashMemo.Checked = False
        TxtReference.Text = ""
        TxtDiscountOnBill.Text = ""
        TxtBillRoundOff.Text = ""
        TxtFrieght.Text = ""
        TxtBillNetAmount.Text = ""
        TxtOverAllDiscount.Text = ""
        CmbMode.Text = cStatusCash
        CmbTax.Text = cVAT
        CmbSaleOn.Text = GetSaleOn()
        TxtDiscount.Text = ""
        SetCustomerEnability(True)

        'CmbDivision.Text = ""
        CmbTransporter.Text = ""
        CmbHQ.Text = ""
        TxtPickSlipNo.Text = ""
        TxtOrderNo.Text = ""
        TxtReference.Text = ""
        TxtDestination.Text = ""
        TxtLRNo.Text = ""
        TxtChequeNo.Text = ""
        TxtCases.Text = ""
        DtPkrLRDate.Value = Now.Date
        DtPkrDueDate.Value = Now.Date
        DtPkrOrderDate.Value = Now.Date
        TxtCreditAdj.Text = ""
        TxtDebitAdj.Text = ""
        TxtPreExciseAmount.Text = ""
        TxtGrossAmount.Text = ""

        flagOldObject = False

        GrdSale.Rows.Clear()
        ResetControlsToAddNewItem()
        lSalesObj = Nothing
        flagCategoryChange = EnLoading.None

        CmbCustomer.Focus()
    End Sub

    Private Sub CalculateTotals()
        Try
            TxtGrossAmount.Text = ""
            TxtDiscount.Text = ""

            'If GrdSale.Rows.Count = 0 Then Exit Try

            Dim totalAmount As Double = 0
            Dim taxTotal As Double = 0
            Dim discountTotal As Double = 0

            Dim row As DataGridViewRow
            For Each row In GrdSale.Rows
                With row
                    taxTotal = taxTotal + Val(.Cells(cTaxAmount).Value)
                    Dim total As Double = (Val(.Cells(cPriceSale).Value) * Val(.Cells(cSaleQuantity).Value))
                    Dim discount As Double = total * Val(.Cells(cDiscountPercent).Value) / 100
                    discountTotal = discountTotal + discount
                    totalAmount = totalAmount + total - discount '+ taxTotal
                End With
            Next

            Dim tax As Double = 0
            Dim taxId As Integer = cInvalidId

            Dim taxableAmt As Double = totalAmount
            Dim taxAmt As Double = 0
            SetTaxIdAndTax(taxId, tax)

            'If GetTaxOn() = 0 Then
            '    taxAmt = taxableAmt * tax / 100
            'Else
            taxAmt = taxableAmt * tax / (100 + tax)
            'End If

            discountTotal = discountTotal
            TxtDiscount.Text = Format(discountTotal, "0.00")
            TxtGrossAmount.Text = Format(totalAmount, "0.00")
            txt_tot_tax.Text = taxTotal
            Txt_GroceAmt.Text = Val(TxtBillNetAmount.Text) + taxTotal





        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    'Private Sub CalculateTotals()
    '    Try
    '        TxtGrossAmount.Text = ""
    '        TxtDiscount.Text = ""

    '        'If GrdSale.Rows.Count = 0 Then Exit Try

    '        Dim totalAmount As Double = 0
    '        ' Dim taxTotal As Double = 0
    '        Dim discountTotal As Double = 0

    '        Dim row As DataGridViewRow
    '        For Each row In GrdSale.Rows
    '            With row
    '                'taxTotal = taxTotal + Val(.Cells(cTaxAmount).Value)
    '                Dim total As Double = (Val(.Cells(cPriceSale).Value) * Val(.Cells(cSaleQuantity).Value))
    '                Dim discount As Double = total * Val(.Cells(cDiscountPercent).Value) / 100
    '                Dim discountPer As Double = (100 + Val(.Cells(cDiscountPercent).Value) / 100)
    '                discountTotal = discountTotal + discount + discountPer
    '                totalAmount = totalAmount + total '- discount
    '            End With
    '        Next

    '        TxtDiscount.Text = Format(discountTotal, "0.00")
    '        TxtGrossAmount.Text = Format(totalAmount, "0.00")

    '    Catch ex As Exception
    '        AddToLog(ex)
    '    End Try
    'End Sub

    Private Sub CalculateTotal(Optional ByRef taxAmount As Double = 0, Optional ByRef discountAmount As Double = 0)
        Try
            If TxtQuantity.Text.Trim = "" Then Exit Try
            If TxtSalePrice.Text.Trim = "" Then Exit Try

            Dim discountPercent As Double = Val(TxtDiscountPercent.Text)
            Dim saleQuantity As Double = Val(TxtQuantity.Text)
            Dim salePrice As Double = lSalePrice 'Val(TxtSalePrice.Text)
            Dim total As Double = salePrice * saleQuantity

            discountAmount = total * discountPercent / 100

            'Deducting discount
            total = total - discountAmount

            'taxAmount = 0

            'Adding tax in total
            total = total '+ taxAmount

            TxtTotal.Text = Format(total, "0.00")

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub SetSaleIdForCurrentLogin()
        Try
            ChkCancel.Enabled = True
            lSalesObj = Nothing
            SetCustomerEnability(True)
            Dim salesMaster As ClsSalesMaster = GetSalesMasterNotClosedForLogin(Me.Name, gUser.LoginName)
            If salesMaster Is Nothing Then Exit Try

            SetCustomerEnability(False)
            lSalesObj = salesMaster
            With salesMaster
                TxtSaleCode.Text = .SaleCode
                DtPkrSaleDate.Value = .SaleDate
                CmbMode.Text = .Mode
                TxtDiscountOnBill.Text = Format(.DiscountAmount, "0.00")
                'CmbDoctor.Text = GetDoctorName(.DoctorId)
                Dim customer As ClsCustomerMaster = GetCustomer(.CustomerId)
                If customer Is Nothing Then
                    lSalesObj = Nothing
                    SetCustomerEnability(True)
                    Exit Try
                End If

                'ChkCashMemo.Checked = lSalesObj.CashMemo
                'CmbCardNo.Text = customer.CardNo
                CmbCustomer.Text = customer.Name
                TxtTinNo.Text = customer.TinNo
                'TxtDLNo.Text = customer.DlNo

                'TxtReference.Text = .Remark

                CmbDivision.Text = GetDivision(.DivisionId)
                CmbTransporter.Text = GetTransporter(.TransporterId)
                CmbHQ.Text = GetHQ(.HQId)
                TxtPickSlipNo.Text = .PickSlipNo
                TxtOrderNo.Text = .OrderNo
                TxtReference.Text = .Reference
                TxtDestination.Text = .Destination
                TxtLRNo.Text = .LRNo
                TxtChequeNo.Text = .ChequeNo
                TxtCases.Text = .Cases
                DtPkrLRDate.Value = .LRDate
                DtPkrDueDate.Value = .DueDate
                DtPkrOrderDate.Value = .OrderDate
                TxtCreditAdj.Text = .CreditAdjust
                TxtDebitAdj.Text = .DebitAdjust
                TxtPreExciseAmount.Text = .PreExciseAmount
                CmbTax.Text = GetTaxName(.TaxId)
                ChkCancel.Checked = .Cancelled

                If lSalesObj.Cancelled = True Then ChkCancel.Enabled = False
                flagOldObject = False
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub SetSaleForSaleId(ByVal id As Long)
        Try
            ChkCancel.Enabled = True
            lSalesObj = Nothing
            SetCustomerEnability(True)
            If id <= 0 Then Exit Try

            Dim salesMaster As ClsSalesMaster = GetSalesMaster(Me.Name, id)
            If salesMaster Is Nothing Then Exit Try

            SetCustomerEnability(False)
            lSalesObj = salesMaster
            With salesMaster
                TxtSaleCode.Text = .SaleCode
                DtPkrSaleDate.Value = .SaleDate
                CmbMode.Text = .Mode
                TxtDiscountOnBill.Text = Format(.DiscountAmount, "0.00")
                'CmbDoctor.Text = GetDoctorName(.DoctorId)
                Dim customer As ClsCustomerMaster = GetCustomer(.CustomerId)
                If customer Is Nothing Then
                    lSalesObj = Nothing
                    SetCustomerEnability(True)
                    Exit Try
                End If

                lFlagTaxNot = EnLoading.LoadOnLostFocus
                'ChkCashMemo.Checked = lSalesObj.CashMemo
                'CmbCardNo.Text = customer.CardNo
                CmbCustomer.Text = customer.Name
                TxtTinNo.Text = customer.TinNo
                'TxtDLNo.Text = customer.DlNo

                'TxtReference.Text = .Remark

                CmbDivision.Text = GetDivision(.DivisionId)
                CmbTransporter.Text = GetTransporter(.TransporterId)
                CmbHQ.Text = GetHQ(.HQId)
                TxtPickSlipNo.Text = .PickSlipNo
                TxtOrderNo.Text = .OrderNo
                TxtReference.Text = .Reference
                TxtDestination.Text = .Destination
                TxtLRNo.Text = .LRNo
                TxtChequeNo.Text = .ChequeNo
                TxtCases.Text = .Cases
                DtPkrLRDate.Value = .LRDate
                DtPkrDueDate.Value = .DueDate
                DtPkrOrderDate.Value = .OrderDate
                TxtCreditAdj.Text = .CreditAdjust
                TxtDebitAdj.Text = .DebitAdjust
                TxtPreExciseAmount.Text = .PreExciseAmount
                CmbTax.Text = GetTaxName(.TaxId)
                TxtFrieght.Text = .FreightCharge
                ChkCancel.Checked = .Cancelled
                If lSalesObj.Cancelled = True Then ChkCancel.Enabled = False

                flagOldObject = True
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        lFlagTaxNot = EnLoading.LoadOnChange
        LoadGridValuesForSale()
        CalculateTotals()
    End Sub

    Private Sub SetCustomerEnability(ByVal flag As Boolean)
        'CmbCustomer.Enabled = flag
        'CmbCardNo.Enabled = flag
        'LblAddCustomer.Enabled = flag
    End Sub

    Private Function GetPrice(ByVal itemId As Integer, ByVal batch As String, ByVal customerId As Integer) As Double
        Dim result As Double = 0
        Try
            If itemId <= 0 Then Exit Try
            If batch.Trim = "" Then Exit Try
            If customerId <= 0 Then Exit Try

            result = GetCustomerTypePrice(Me.Name, itemId, batch, customerId)

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Sub SaveVirtualCustomer()
        Try
            Dim name As String = CmbCustomer.Text.Trim
            Dim customerId As Integer = GetSelectedItemId(CmbCustomer)
            If customerId > 0 Then Exit Try

            Dim customer As New ClsCustomerMaster
            customer.Name = name

            Dim id As Integer = InsertIntoCustomerMaster(Me.Name, customer)
            If id <= 0 Then Exit Try

            customer = GetCustomerMaster(Me.Name, id)
            If customer Is Nothing Then Exit Try

            LoadComboBoxValuesForCustomers()
            CmbCustomer.Text = name
            flagCustomerChanged = EnLoading.None

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    'Private Sub SelectItemInBatchComboBox(ByVal batch As String)
    '    Try
    '        batch = batch.Trim
    '        If batch = "" Then Exit Try

    '        For Each currentStock As ClsCurrentStock In CmbBatch.Items
    '            If UCase(currentStock.Batch) = UCase(batch) Then
    '                CmbBatch.Text = currentStock.BatchWithQuantity
    '                Exit Try
    '            End If
    '        Next

    '    Catch ex As Exception
    '        AddToLog(ex)
    '    End Try
    'End Sub

    Private Function GetCategoryForItemId(ByVal itemId As Integer) As String
        Dim result As String = ""
        Try
            If itemId <= 0 Then Exit Try

            Dim categoryId As Integer = GetCategoryIdForItemId(itemId)
            If categoryId <= 0 Then Exit Try

            For Each category As ClsCategoryMaster In CmbCategory.Items
                If category.Id = categoryId Then
                    result = category.Name
                    Exit Try
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Function GetCategoryIdForItemId(ByVal itemId As Integer) As Integer
        Dim result As Integer = cInvalidId
        Try
            If itemId <= 0 Then Exit Try

            For Each item As ClsItemMaster In lItems
                If item.Id = itemId Then
                    result = item.CategoryId
                    Exit Try
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    'Private Sub UpdateCurrentStockForItemIdBatch(ByVal itemId As Integer, ByVal batch As String)
    '    Try
    '        If itemId <= 0 Then Exit Try
    '        batch = batch.Trim
    '        If batch = "" Then Exit Try

    '        Dim currentStock As ClsCurrentStock = GetCurrentStockForItemIdAndBatch(Me.Name, itemId, batch)
    '        If currentStock Is Nothing Then Exit Try

    '        Dim curStk As ClsCurrentStock = Nothing
    '        For Each curStk In lCurrentStocks
    '            If curStk.ItemId = currentStock.ItemId And UCase(curStk.Batch) = UCase(currentStock.Batch) Then
    '                curStk.CurrentQuantity = currentStock.CurrentQuantity
    '                Exit For
    '            End If
    '        Next

    '    Catch ex As Exception
    '        AddToLog(ex)
    '    End Try
    'End Sub

    Private Sub LoadComboBoxValuesForTax()
        Try
            CmbTax.DataSource = Nothing
            CmbTax.Items.Clear()
            CmbTax.Text = ""

            Dim taxs() As ClsTaxMaster = GetAllTaxMasters(Me.Name)

            CmbTax.DataSource = taxs
            CmbTax.DisplayMember = cName
            CmbTax.ValueMember = cId
            If CmbTax.Items.Count > 0 Then CmbTax.SelectedIndex = 0

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadBatchForSelectedItem()
        Try
            'CmbBatch.DataSource = Nothing
            'CmbBatch.Items.Clear()
            'CmbBatch.SelectedIndex = -1

            Dim itemId As Integer = GetSelectedItemId(CmbItem)
            If itemId < 0 Then Exit Try

            Dim currentStocks() As ClsCurrentStock = GetAllCurrentStockForItemId(Me.Name, itemId, False, flagLoadForUpdate, True)
            If currentStocks Is Nothing Then Exit Try

            lCurrentBatch = currentStocks(0)

            'CmbBatch.DataSource = currentStocks
            'CmbBatch.DisplayMember = cBatchWithQuantity
            'CmbBatch.ValueMember = cId
            'If CmbBatch.Items.Count > 0 Then CmbBatch.SelectedIndex = 0

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub SetTaxIdAndTax(ByRef taxId As Integer, ByRef tax As Double)
        If lFlagTaxNot <> EnLoading.None Then
            If lSalesObj Is Nothing Then
                taxId = cInvalidId
                tax = 0
            Else
                taxId = lSalesObj.TaxId
                tax = lSalesObj.TaxPercent
            End If
        Else
            If CmbTax.SelectedIndex < 0 Then
                taxId = cInvalidId
                tax = 0
            Else
                Dim taxObj As ClsTaxMaster = CmbTax.SelectedItem
                taxId = taxObj.Id
                tax = taxObj.TaxPercent
            End If
        End If

    End Sub

    Private Sub CalculateTaxableAmount()
        Try
            TxtTaxableAmount.Text = ""
            Dim grossAmt As Double = Val(TxtGrossAmount.Text)
            'Dim discountAmt As Double = Val(TxtDiscountOnBill.Text)
            Dim discountAmt As Double = Val(TxtDiscount.Text)

            If GetTaxOn() = 0 Then
                TxtTaxableAmount.Text = Format(grossAmt - discountAmt, "0.00")
            Else
                TxtTaxableAmount.Text = Format(GetTaxableAmount, "0.00")
            End If

            'TxtTaxableAmount.Text = Format(grossAmt, "0.00")

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Function GetTaxableAmount() As Double
        Dim result As Double = 0
        Try
            If GrdSale.Rows.Count = 0 Then Exit Try

            Dim taxOn As Integer = GetTaxOn()
            Dim fieldName As String = ""
            Select Case taxOn
                Case EnFields.MRP
                    fieldName = cMRP

                Case EnFields.PTR
                    fieldName = cPTR

                Case EnFields.PTS
                    fieldName = cPTS

                Case EnFields.PTD
                    fieldName = cPTD

                Case EnFields.Rate1
                    fieldName = cRate1

                Case EnFields.Rate2
                    fieldName = cRate2

            End Select

            Dim totalAmount As Double = 0
            Dim flagFree As Boolean = GetTaxOnFree()
            Dim row As DataGridViewRow
            For Each row In GrdSale.Rows
                With row
                    Dim total As Double = 0
                    If fieldName <> "" Then
                        total = (Val(.Cells(fieldName).Value) * Val(.Cells(cSaleQuantity).Value))
                        If flagFree = True Then total = total + (Val(.Cells(fieldName).Value) * Val(.Cells(cFreeQuantity).Value))
                    Else
                        total = (Val(.Cells(cPriceSale).Value) * Val(.Cells(cSaleQuantity).Value))
                        If flagFree = True Then total = total + (Val(.Cells(cPriceSale).Value) * Val(.Cells(cFreeQuantity).Value))
                    End If

                    totalAmount = totalAmount + total
                End With
            Next

            result = totalAmount

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Sub CalculateTotalDiscount()
        Try
            TxtOverAllDiscount.Text = ""

            Dim discountAmt As Double = Val(TxtDiscountOnBill.Text)
            Dim discount As Double = Val(TxtDiscount.Text)

            TxtOverAllDiscount.Text = Format(discount + discountAmt, "0.00")

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub CalculateTax()
        Try
            TxtTaxAmt.Text = ""

            Dim taxId As Integer = cInvalidId
            Dim tax As Double = 0
            SetTaxIdAndTax(taxId, tax)

            LblTaxPercent.Text = Format(tax, "0.00") + "%"

            Dim taxableAmt As Double = Val(TxtTaxableAmount.Text)
            Dim taxAmt As Double = 0

            If GetTaxOn() = 0 Then
                taxAmt = taxableAmt * tax / 100
            Else
                taxAmt = taxableAmt * tax / (100 + tax)
            End If

            TxtTaxAmt.Text = Format(taxAmt, "0.00")

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub CalculateBillTotal()
        Try
            Dim grossAmt As Double = Val(TxtGrossAmount.Text)
            Dim tax As Double = Val(TxtTaxAmt.Text)
            Dim discount As Double = Val(TxtOverAllDiscount.Text) ' Val(TxtDiscountOnBill.Text) 'Val(TxtOverAllDiscount.Text)
            Dim creditAdj As Double = Val(TxtCreditAdj.Text)
            Dim debitAdj As Double = Val(TxtDebitAdj.Text)
            Dim freightCharge As Double = Val(TxtFrieght.Text)

            Dim totalWithoutROF As Double = grossAmt '+ tax - discount ' - creditAdj + debitAdj - freightCharge
            Dim netAmount As Double = GetSqlRound(Me.Name, totalWithoutROF)

            TxtBillRoundOff.Text = Format(netAmount - totalWithoutROF, "0.00")
            TxtBillNetAmount.Text = Format(netAmount, "0.00")

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Function CheckToCancelQuantity() As Boolean
        Dim result As Boolean = False
        Try
            For Each row As DataGridViewRow In GrdSale.Rows
                If row.Cells(cSaleQuantity).Value <> 0 Or row.Cells(cFreeQuantity).Value <> 0 Then
                    result = True
                    Exit Try
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Sub UpdateSaleDetailObjectForCancel()
        Try
            For Each row As DataGridViewRow In GrdSale.Rows
                'Updating Detail
                Dim saleDetailObj As New ClsSalesDetail
                With saleDetailObj
                    .Id = row.Cells(cId).Value
                    .SaleId = lSalesObj.Id
                    .ItemId = row.Cells(cItemId).Value
                    .PriceSale = lSalePrice 'Val(TxtSalePrice.Text)
                    .SaleQuantity = 0
                    .FreeQuantity = 0
                    .TaxPercent = 0
                    .DiscountPercent = Val(TxtDiscountPercent.Text)
                    .Batch = row.Cells(cBatch).Value
                    .ExpiryDate = row.Cells(cExpiryDate).Value
                    .ManufacturerId = row.Cells(cManufacturerId).Value
                    .MRP = row.Cells(cMRP).Value
                    .PTR = row.Cells(cPTR).Value
                    .PTS = row.Cells(cPTS).Value
                    .Rate3 = row.Cells(cPTD).Value
                    '.Rate1 = row.Cells(cRate1).Value
                    '.Rate2 = row.Cells(cRate2).Value
                    .ManufactureDate = row.Cells(cManufactureDate).Value
                    .PricePurchase = row.Cells(cPricePurchase).Value
                    .PackQuantity = row.Cells(cPackQuantity).Value
                    .StorageId = row.Cells(cStorageId).Value
                    '.Remark = TxtReference.Text
                    .UserId = gUser.LoginName
                    .DateOn = Now
                    .ForCashOut = False
                    CalculateTotal(.TaxAmount, .DiscountAmount)
                End With

                If UpdateSalesDetail(Me.Name, saleDetailObj) <> EnResult.Change Then Exit Sub

                With row
                    .Cells(cItemId).Value = saleDetailObj.ItemId
                    .Cells(cStorageId).Value = saleDetailObj.StorageId
                    .Cells(cBatch).Value = saleDetailObj.Batch
                    .Cells(cExpiryDate).Value = saleDetailObj.ExpiryDate
                    .Cells(cManufacturerId).Value = saleDetailObj.ManufacturerId
                    .Cells(cManufacturer).Value = GetManufacturer(.Cells(cManufacturerId).Value)
                    .Cells(cManufactureDate).Value = saleDetailObj.ManufactureDate
                    .Cells(cPriceSale).Value = saleDetailObj.PriceSale
                    .Cells(cMRP).Value = saleDetailObj.MRP
                    .Cells(cPTR).Value = saleDetailObj.PTR
                    .Cells(cPTS).Value = saleDetailObj.PTS
                    .Cells(cPTD).Value = saleDetailObj.Rate3
                    '.Cells(cRate1).Value = saleDetailObj.Rate1
                    '.Cells(cRate2).Value = saleDetailObj.Rate2
                    .Cells(cSaleQuantity).Value = saleDetailObj.SaleQuantity
                    .Cells(cFreeQuantity).Value = saleDetailObj.FreeQuantity
                    .Cells(cPackQuantity).Value = saleDetailObj.PackQuantity
                    .Cells(cTaxPercent).Value = saleDetailObj.TaxPercent
                    .Cells(cTaxAmount).Value = saleDetailObj.TaxAmount
                    .Cells(cDiscountPercent).Value = saleDetailObj.DiscountPercent
                    .Cells(cDiscountAmount).Value = saleDetailObj.DiscountAmount
                    .Cells(cTotal).Value = saleDetailObj.GetTotal
                    .Cells(cStorage).Value = GetStorageName(.Cells(cStorageId).Value)
                    .Cells(cName).Value = GetItemName(.Cells(cItemId).Value)
                    .Cells(cPricePurchase).Value = saleDetailObj.PricePurchase
                    .Cells(cRemark).Value = saleDetailObj.Remark
                    .Cells(cForCashOut).Value = saleDetailObj.ForCashOut
                    .Cells(cUserId).Value = saleDetailObj.UserId
                    .Cells(cDateOn).Value = saleDetailObj.DateOn
                End With
            Next

            GetAllCurrentStock(Me.Name)

            CalculateTotals()
            lSalesObj.NotClosed = True

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNewItem()
    End Sub

#End Region

#Region "Dataset Function "

    Private Function CopyDataSet(ByRef ds As DataSet) As DataSet
        Dim newDataset As New DataSet
        Try
            Dim colName As String = "CopyNo"
            Dim ds1 As DataSet = Nothing
            Dim ds2 As DataSet = Nothing
            Dim ds3 As DataSet = Nothing

            ds1 = ds.Copy
            ds2 = ds.Copy
            ds3 = ds.Copy

            Dim a1 As New DataColumn
            Dim a2 As New DataColumn
            Dim a3 As New DataColumn
            a1.ColumnName = colName
            a2.ColumnName = colName
            a3.ColumnName = colName

            ds1.Tables(0).Columns.Add(a1)
            ds2.Tables(0).Columns.Add(a2)
            ds3.Tables(0).Columns.Add(a3)

            Dim x As Integer
            For x = 0 To ds.Tables(0).Rows.Count - 1
                ds1.Tables(0).Rows(x)(colName) = 1
                ds2.Tables(0).Rows(x)(colName) = 2
                ds3.Tables(0).Rows(x)(colName) = 3
            Next

            newDataset.Merge(ds1)
            newDataset.Merge(ds2)
            newDataset.Merge(ds3)

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return newDataSet
    End Function
#End Region

    Private Sub Label19_Click(sender As Object, e As EventArgs) Handles Label19.Click

    End Sub

    Private Sub GrdSale_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GrdSale.CellContentClick

    End Sub
End Class
