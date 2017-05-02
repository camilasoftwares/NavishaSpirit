Imports System.Windows.Forms
Imports AIMS.Author

Public Class FrmSample

#Region "Local variables and Constants"

    Dim lCurrentBatch As ClsCurrentStock = Nothing
    Dim editRow As DataGridViewRow = Nothing
    Dim lSampleObj As ClsSampleMaster = Nothing
    Dim lStorages() As ClsStorageMaster = Nothing
    Dim lCurrentStocks() As ClsCurrentStock = Nothing
    Dim lItems() As ClsItemMaster = Nothing
    Dim lManufacturers() As ClsManufacturerMaster = Nothing
    Dim flagCardNoChanged As Boolean = False
    Dim flagCustomerChanged As EnLoading = EnLoading.None
    Dim flagItemChanged As EnLoading = EnLoading.None
    Dim flagBatchChanged As EnLoading = EnLoading.None
    Dim flagLoadForUpdate As Boolean = False
    Dim lSamplePrice As Double = 0
    Dim flagOldObject As Boolean = False
    Dim flagCategoryChange As EnLoading = EnLoading.None
    Dim lVAT As Double = 0
    Dim lCST As Double = 0
    Dim lCSTFormC As Double = 0
    Dim lCSTFormF As Double = 0
    Dim lFlagTaxNot As EnLoading = EnLoading.None

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

    Private Sub FrmSample_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not (lSampleObj Is Nothing) Then
            If lSampleObj.NotClosed = True Then
                If MsgBox("Sample Master is not updated." + vbCrLf + vbCrLf + "To update click save button." + vbCrLf + vbCrLf + "Do you want to update Sample master?", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub FrmSample_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

    Private Sub Event_AllowDecimalOnKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtQuantity.KeyPress
        e.Handled = Check_DecimalAllow(e.KeyChar, sender.text)
    End Sub

    Private Sub CmbCardNo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbCardNo.LostFocus
        Try
            If flagCardNoChanged = False Then Exit Try
            flagCardNoChanged = False

            TxtTinNo.Text = ""
            TxtDLNo.Text = ""
            If CmbCardNo.Text.Trim = "" Then
                CmbCustomer.Text = ""
                Exit Try
            End If

            Dim x As Integer = CmbCardNo.FindStringExact(CmbCardNo.Text.Trim)
            If x < 0 Then
                CmbCustomer.Text = ""
                Exit Try
            End If

            Dim customer As ClsCustomerMaster = CmbCardNo.Items(x)
            If customer Is Nothing Then Exit Try

            CmbCustomer.Text = customer.Name
            TxtTinNo.Text = customer.TinNo
            'TxtDLNo.Text = customer.DlNo

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub CmbCardNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbCardNo.TextChanged
        flagCardNoChanged = True
    End Sub

    Private Sub CmbCustomer_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbCustomer.KeyPress
        'AutoComplete(sender, e)
    End Sub

    Private Sub CmbCustomer_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbCustomer.LostFocus
        Try
            If flagCustomerChanged <> EnLoading.LoadOnLostFocus Then Exit Try
            flagCustomerChanged = EnLoading.None

            TxtTinNo.Text = ""
            TxtDLNo.Text = ""
            If CmbCustomer.Text.Trim = "" Or CmbCustomer.FindStringExact(CmbCustomer.Text.Trim) < 0 Then
                CmbCardNo.Text = ""
                DtPkrDueDate.Value = Now.Date
                Exit Try
            End If

            Dim customer As ClsCustomerMaster = CmbCustomer.SelectedItem
            If customer Is Nothing Then Exit Try

            'CmbCardNo.Text = customer.CardNo
            DtPkrDueDate.Value = Now.Date.AddDays(customer.DueDays)
            TxtTinNo.Text = customer.TinNo
            'TxtDLNo.Text = customer.DlNo

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

    'Private Sub CmbBatch_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbBatch.LostFocus
    '    Try
    '        If flagBatchChanged <> EnLoading.LoadOnLostFocus Then Exit Sub
    '        flagBatchChanged = EnLoading.None

    '        'SetCurrentPrice()

    '    Catch ex As Exception
    '        AddToLog(ex)
    '    End Try
    'End Sub

    'Private Sub CmbBatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbBatch.SelectedIndexChanged
    '    If flagBatchChanged = EnLoading.None Then flagBatchChanged = EnLoading.LoadOnLostFocus
    '    If flagBatchChanged <> EnLoading.LoadOnChange Then Exit Sub

    '    'SetCurrentPrice()
    'End Sub

    'Private Sub SetCurrentPrice()
    '    Try
    '        Dim currentStock As ClsCurrentStock = CmbBatch.SelectedItem
    '        If currentStock Is Nothing Then
    '            TxtSamplePrice.Text = ""
    '            lSamplePrice = 0
    '            Exit Try
    '        End If

    '        Dim samplePrice As Double = 0

    '        Select Case CmbSampleOn.Text
    '            Case cPTS
    '                samplePrice = currentStock.PTS

    '            Case cPTR
    '                samplePrice = currentStock.PTR

    '            Case cMRP
    '                samplePrice = currentStock.MRP

    '            Case cRate1
    '                samplePrice = currentStock.Rate1

    '            Case cRate2
    '                samplePrice = currentStock.Rate2

    '            Case cRate3
    '                samplePrice = currentStock.Rate3

    '        End Select

    '        lSamplePrice = samplePrice
    '        TxtSamplePrice.Text = Format(samplePrice, "0.00")

    '        Dim customerId As Integer = GetSelectedItemId(CmbCustomer)
    '        Dim price As Double = GetPrice(currentStock.ItemId, currentStock.Batch, customerId)
    '        If price <= 0 Then Exit Try

    '        lSamplePrice = price
    '        TxtSamplePrice.Text = Format(price, "0.00")

    '    Catch ex As Exception
    '        AddToLog(ex)
    '    End Try
    'End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Try
            If BtnAdd.Text = lcUpdate Then
                UpdateSampleDetailObject()
                Exit Sub
            End If

            If flagOldObject = False Then
                If AndedTheString(gUser.AuthorizationNo, Authorization.IssueSample_Current_NoAdd) = True Then Exit Sub
            Else
                If AndedTheString(gUser.AuthorizationNo, Authorization.IssueSample_Old_NoAdd) = True Then Exit Sub
            End If

            If ValidateValues() = False Then Exit Sub

            'Saving Master if virtual
            If lSampleObj Is Nothing Then
                Dim sampleMasterObj As New ClsSampleMaster
                With sampleMasterObj
                    .CustomerId = GetSelectedItemId(CmbCustomer)
                    .DoctorId = cInvalidId
                    .Mode = cStatusCash ' CmbMode.Text
                    .DiscountAmount = 0 'Val(TxtDiscountOnBill.Text)
                    '.Remark= TxtReference.Text
                    .Prescription = ""
                    .CashOutAmount = 0
                    .AdjustedAmount = 0
                    .SampleDate = DtPkrSampleDate.Value
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
                    .CreditAdjust = 0 'Val(TxtCreditAdj.Text)
                    .DebitAdjust = 0 'Val(TxtDebitAdj.Text)
                    .PreExciseAmount = 0 'Val(TxtPreExciseAmount.Text)
                    'SetTaxNameAndTax(.TaxName, .TaxPercent)
                End With

                Dim sampleId As Integer = InsertIntoSampleMaster(Me.Name, sampleMasterObj)
                If sampleId <= 0 Then Exit Try

                sampleMasterObj.Id = sampleId
                lSampleObj = sampleMasterObj
                SetCustomerEnability(False)

                sampleMasterObj = GetSampleMaster(Me.Name, sampleId)
                If Not (sampleMasterObj Is Nothing) Then
                    lSampleObj = sampleMasterObj
                    TxtSampleCode.Text = lSampleObj.SampleCode
                End If
            End If

            'Saving Detail
            Dim sampleDetailObj As New ClsSampleDetail
            With sampleDetailObj
                .SampleId = lSampleObj.Id

                Dim currentStock As ClsCurrentStock = lCurrentBatch ' CmbBatch.SelectedItem

                If currentStock Is Nothing Then
                    MsgBox("Item is not selected or Batch doesn't exist", , "Item")
                    Exit Sub
                End If

                .ItemId = currentStock.ItemId
                .Batch = currentStock.Batch
                .ExpiryDate = currentStock.ExpiryDate
                .ManufacturerId = currentStock.ManufacturerId
                .PriceSample = lSamplePrice 'Val(TxtSamplePrice.Text)
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
                .TaxPercent = 0
                .DiscountPercent = 0 'Val(TxtDiscountPercent.Text)
                .SampleQuantity = Val(TxtQuantity.Text)
                .FreeQuantity = 0 'Val(TxtFreeQuantity.Text)
                .StorageId = currentStock.StorageId
                '.Remark = TxtReference.Text
                .UserId = gUser.LoginName
                .DateOn = Now
                'CalculateTotal(.TaxAmount, .DiscountAmount)
            End With

            Dim id As Long = InsertIntoSampleDetail(Me.Name, sampleDetailObj)
            If id > 0 Then
                sampleDetailObj.Id = id
                InsertIntoSampleGrid(sampleDetailObj)
                'UpdateCurrentStockForItemIdBatch(sampleDetailObj.ItemId, sampleDetailObj.Batch)
                GetAllCurrentStock(Me.Name)
                'CalculateTotals()
                lSampleObj.NotClosed = True
            End If

            MsgBox("Successfully Added", , "Added")

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNewItem()
    End Sub

    Private Sub BtnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemove.Click
        Try
            Dim row As DataGridViewRow = GrdSample.SelectedRows(0)
            If row Is Nothing Then Exit Try

            If flagOldObject = False Then
                If AndedTheString(gUser.AuthorizationNo, Authorization.IssueSample_Current_NoRemove) = True Then Exit Sub
            Else
                If AndedTheString(gUser.AuthorizationNo, Authorization.IssueSample_Old_NoRemove) = True Then Exit Sub
            End If

            Dim id As Long = row.Cells(cId).Value
            If id <= 0 Then Exit Try

            If MsgBox("Do you really wants to remove selected record? Removed records can't be recovered.", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                If DeleteSampleDetail(Me.Name, id) <> EnResult.Change Then Exit Sub

                lSampleObj.NotClosed = True
                'UpdateCurrentStockForItemIdBatch(row.Cells(cItemId).Value, row.Cells(cBatchX).Value)
                GetAllCurrentStock(Me.Name)
                GrdSample.Rows.Remove(row)
                'CalculateTotals()
                MsgBox("Successfully Removed", , "Removed")
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNewItem()
    End Sub

    Private Sub GrdSample_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdSample.CellClick
        If e.RowIndex < 0 Then Exit Sub
        If flagOldObject = False Then
            If AndedTheString(gUser.AuthorizationNo, Authorization.IssueSample_Current_NoRemove) = True Then Exit Sub
        Else
            If AndedTheString(gUser.AuthorizationNo, Authorization.IssueSample_Old_NoRemove) = True Then Exit Sub
        End If


        BtnRemove.Enabled = True
        BtnAddFreeItems.Enabled = False
        BtnAdd.Enabled = False
        BtnNew.Text = lcCancel
    End Sub

    Private Sub GrdSample_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdSample.CellDoubleClick
        Try
            BtnRemove.Enabled = False
            If e.RowIndex < 0 Then Exit Try
            If flagOldObject = False Then
                If AndedTheString(gUser.AuthorizationNo, Authorization.IssueSample_Current_NoUpdate) = True Then Exit Sub
            Else
                If AndedTheString(gUser.AuthorizationNo, Authorization.IssueSample_Old_NoUpdate) = True Then Exit Sub
            End If

            editRow = GrdSample.Rows(e.RowIndex)
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
                'TxtSamplePrice.Text = Format(.Cells(cPriceSample).Value, "0.00")
                lSamplePrice = .Cells(cPriceSample).Value
                TxtQuantity.Text = .Cells(cSampleQuantity).Value
                'TxtFreeQuantity.Text = .Cells(cFreeQuantity).Value
                'TxtDiscountPercent.Text = .Cells(cDiscountPercent).Value
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

    Private Sub GrdSample_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdSample.KeyDown
        If e.KeyCode = Keys.Tab Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        If BtnNew.Text = lcCancel Then
            ResetControlsToAddNewItem()
        Else
            If Not (lSampleObj Is Nothing) Then
                If lSampleObj.NotClosed = True Then
                    If MsgBox("Sample Master is not updated." + vbCrLf + vbCrLf + "To update click save button." + vbCrLf + vbCrLf + "Do you want to update Sample master?", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                        Exit Sub
                    End If
                End If
            End If

            ResetControlsToAddNew()
        End If
    End Sub

    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch.Click
        Try
            Dim frm As New ClsSearchSampleForm
            If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Dim id As Long = frm.GetSelectedId
                If id > 0 Then
                    SetSampleForSampleId(id)
                    flagOldObject = True
                End If
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Try
            If lSampleObj Is Nothing Then
                MsgBox("There is no Sample selected. Please create or select Sample.", , "Sample")
                Exit Try
            End If

            If lSampleObj.Id <= 0 Then
                MsgBox("There is no Sample selected. Please create or select Sample.", , "Sample")
                Exit Try
            End If

            If lSampleObj.NotClosed = True Then
                MsgBox("Sample not saved. Please save your sample then print.", MsgBoxStyle.Information, "Not Saved.")
                Exit Try
            End If

            Dim sampleId As Long = lSampleObj.Id
            Dim ds As DataSet = GetSample(Me.Name, sampleId)

            If ds Is Nothing Then
                MsgBox("Error in generating report.", MsgBoxStyle.Critical, "Error")
                Exit Try
            End If

            If ds.Tables(0).Rows.Count = 0 Then
                MsgBox("No record is present for this selection.", MsgBoxStyle.Information, "No Record")
                Exit Try
            End If

            Dim remark As String = ""
            If lSampleObj.NotClosed = True Then
                remark = "## This is temporary. ##"
            End If

            ' Dim rof As Double = GetTransactionAccountRoundOffForVoucherNo(Me.Name, lSampleObj.SampleCode)

            'Opening Report
            SetWaitCursor()
            Dim rpt As New RptSample
            rpt.SetDataSource(ds.Tables(0))
            ' rpt.SetParameterValue("ROF", -rof)
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
            If lSampleObj Is Nothing Then Exit Try

            If flagOldObject = False Then
                If AndedTheString(gUser.AuthorizationNo, Authorization.IssueSample_Current_NoUpdate) = True Then Exit Sub
            Else
                If AndedTheString(gUser.AuthorizationNo, Authorization.IssueSample_Old_NoUpdate) = True Then Exit Sub
            End If

            'Dim netAmount As Double = Val(TxtBillNetAmount.Text)

            'Updating Master
            Dim sampleMasterObj As New ClsSampleMaster
            With sampleMasterObj
                .Id = lSampleObj.Id
                .SampleCode = lSampleObj.SampleCode
                .CustomerId = GetSelectedItemId(CmbCustomer)
                .DoctorId = cInvalidId
                .Mode = cStatusCash ' CmbMode.Text
                .DiscountAmount = 0 'Val(TxtDiscountOnBill.Text)
                '.Remark = TxtReference.Text
                .Prescription = lSampleObj.Prescription
                .CashOutAmount = lSampleObj.CashOutAmount
                .AdjustedAmount = lSampleObj.AdjustedAmount
                .SampleDate = DtPkrSampleDate.Value
                'If netAmount > 0 Then
                '    Dim bal As Double = netAmount - lSampleObj.CashOutAmount
                '    If bal > 1 Then
                '        .CashOut = True     'Open to cash out
                '    Else
                '        .CashOut = False    'Close to cash out
                '    End If
                'Else
                '    .CashOut = lSampleObj.CashOut
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
                .CreditAdjust = 0 'Val(TxtCreditAdj.Text)
                .DebitAdjust = 0 'Val(TxtDebitAdj.Text)
                .PreExciseAmount = 0 'Val(TxtPreExciseAmount.Text)
                'SetTaxNameAndTax(.TaxName, .TaxPercent)
            End With

            If UpdateSampleMaster(Me.Name, sampleMasterObj) <> EnResult.Change Then Exit Sub
            lSampleObj = sampleMasterObj

            MsgBox("Successfully Saved", , "Saved")

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    'Private Sub TxtQuantity_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtQuantity.TextChanged
    '    If TxtQuantity.Text.Trim = "" Then Exit Sub

    '    CalculateTotal()
    'End Sub

    'Private Sub TxtSamplePrice_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSamplePrice.TextChanged
    '    If TxtSamplePrice.Text.Trim = "" Then Exit Sub

    '    CalculateTotal()
    'End Sub

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSampleCode.KeyDown, TxtReference.KeyDown, TxtQuantity.KeyDown, DtPkrSampleDate.KeyDown, CmbItem.KeyDown, CmbCustomer.KeyDown, CmbCategory.KeyDown, TxtTinNo.KeyDown, TxtPickSlipNo.KeyDown, TxtOrderNo.KeyDown, TxtLRNo.KeyDown, TxtDLNo.KeyDown, TxtDestination.KeyDown, TxtChequeNo.KeyDown, TxtCases.KeyDown, DtPkrOrderDate.KeyDown, DtPkrLRDate.KeyDown, DtPkrDueDate.KeyDown, CmbTransporter.KeyDown, CmbHQ.KeyDown, CmbDivision.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub CmbCardNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbCardNo.KeyDown
        If e.KeyCode = Keys.Enter Then CmbCustomer.Focus()
    End Sub

    'Private Sub BtnAddFreeItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddFreeItems.Click
    '    Try
    '        Dim frm As New FrmFreeStockTransaction
    '        frm.SetSampleObject(lSampleObj)
    '        frm.ShowDialog(Me)

    '    Catch ex As Exception
    '        AddToLog(ex)
    '    End Try
    'End Sub

    'Private Sub TxtDiscountOnBill_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDiscountOnBill.TextChanged
    '    CalculateTaxableAmount()
    '    CalculateTotalDiscount()
    'End Sub

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

    'Private Sub CmbTax_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbTax.SelectedIndexChanged
    '    If lFlagTaxNot = EnLoading.LoadOnChange Then lFlagTaxNot = EnLoading.None
    '    CalculateTax()
    'End Sub

    'Private Sub CmbSampleOn_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbSampleOn.SelectedIndexChanged
    '    SetCurrentPrice()
    'End Sub

    'Private Sub TxtDiscountPercent_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDiscountPercent.TextChanged
    '    CalculateTotal()
    'End Sub

    'Private Sub TxtGrossAmount_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtGrossAmount.TextChanged
    '    CalculateTaxableAmount()
    '    CalculateBillTotal()
    'End Sub

    'Private Sub TxtDiscount_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDiscount.TextChanged
    '    CalculateTotalDiscount()
    'End Sub

    'Private Sub TxtTaxableAmount_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtTaxableAmount.TextChanged
    '    CalculateTax()
    'End Sub

    'Private Sub TxtTaxAmt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtTaxAmt.TextChanged
    '    CalculateBillTotal()
    'End Sub

    'Private Sub TxtOverAllDiscount_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtOverAllDiscount.TextChanged
    '    CalculateBillTotal()
    'End Sub

    'Private Sub TxtCreditAdj_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCreditAdj.TextChanged
    '    CalculateBillTotal()
    'End Sub

    'Private Sub TxtDebitAdj_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDebitAdj.TextChanged
    '    CalculateBillTotal()
    'End Sub

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
                LoadComboBoxValuesForCardNo()
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
        SetGridForSample()
        GetAllItemMaster(Me.Name)
        GetAllCurrentStock(Me.Name)
        LoadItems()
        LoadComboBoxValues()
        LoadStorages()
        ResetControlsToAddNew()
        'Load Grid values after ComboBox Values

        SetSampleIdForCurrentLogin()
        LoadGridValuesForSample()
        'CalculateTotals()
    End Sub

    Private Sub SetGridForSample()
        With GrdSample
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
                        .Columns(index).Width = defaultCellWidth + 150

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

                    Case 6
                        Dim index As Integer = .Columns.Add(cManufactureDate, "Mfg Dt.")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "MMM-yyyy"
                        .Columns(index).Visible = False

                    Case 7
                        Dim index As Integer = .Columns.Add(cExpiryDate, "Exp. Date")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "MMM-yyyy"
                        .Columns(index).Visible = False

                    Case 8
                        Dim index As Integer = .Columns.Add(cSampleQuantity, "Unit")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 9
                        Dim index As Integer = .Columns.Add(cFreeQuantity, "Free")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns(index).Visible = False

                    Case 10
                        Dim index As Integer = .Columns.Add(cPriceSample, "Price Sample")
                        .Columns(index).Width = defaultCellWidth + 20
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns(index).Visible = False

                    Case 11
                        Dim index As Integer = .Columns.Add(cPTS, cPTS)
                        .Columns(index).Width = defaultCellWidth + 20
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

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

                    Case 14
                        Dim index As Integer = .Columns.Add(cRate1, cRate1)
                        .Columns(index).Width = defaultCellWidth + 20
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 15
                        Dim index As Integer = .Columns.Add(cRate2, cRate2)
                        .Columns(index).Width = defaultCellWidth + 20
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 16
                        Dim index As Integer = .Columns.Add(cRate3, cRate3)
                        .Columns(index).Width = defaultCellWidth + 20
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

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
                        .Columns(index).Visible = False

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
                        .Columns(index).Visible = False

                    Case 23
                        Dim index As Integer = .Columns.Add(cItemId, cItemId)
                        .Columns(index).Visible = False

                    Case 24
                        Dim index As Integer = .Columns.Add(cStorageId, cStorageId)
                        .Columns(index).Visible = False

                    Case 25
                        Dim index As Integer = .Columns.Add(cSampleId, cSampleId)
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

    Private Sub LoadGridValuesForSample()
        Try
            GrdSample.Rows.Clear()

            If lSampleObj Is Nothing Then Exit Try

            Dim sampleDetails() As ClsSampleDetail = GetAllSampleDetailForSampleId(Me.Name, lSampleObj.Id)
            If sampleDetails Is Nothing Then Exit Try

            Dim sampleDetail As ClsSampleDetail
            For Each sampleDetail In sampleDetails
                InsertIntoSampleGrid(sampleDetail)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub InsertIntoSampleGrid(ByRef sampleDetailObj As ClsSampleDetail)
        Try
            If sampleDetailObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdSample.Rows.Add
            With GrdSample.Rows(rowIndex)
                .Cells(cId).Value = sampleDetailObj.Id
                .Cells(cItemId).Value = sampleDetailObj.ItemId
                .Cells(cStorageId).Value = sampleDetailObj.StorageId
                .Cells(cBatch).Value = sampleDetailObj.Batch
                .Cells(cExpiryDate).Value = sampleDetailObj.ExpiryDate
                .Cells(cManufacturerId).Value = sampleDetailObj.ManufacturerId
                .Cells(cManufacturer).Value = GetManufacturer(.Cells(cManufacturerId).Value)
                .Cells(cPriceSample).Value = sampleDetailObj.PriceSample
                .Cells(cMRP).Value = sampleDetailObj.MRP
                .Cells(cPTR).Value = sampleDetailObj.PTR
                .Cells(cPTS).Value = sampleDetailObj.PTS
                .Cells(cRate1).Value = sampleDetailObj.Rate1
                .Cells(cRate2).Value = sampleDetailObj.Rate2
                .Cells(cRate3).Value = sampleDetailObj.Rate3
                .Cells(cManufactureDate).Value = sampleDetailObj.ManufactureDate
                .Cells(cSampleQuantity).Value = sampleDetailObj.SampleQuantity
                .Cells(cFreeQuantity).Value = sampleDetailObj.FreeQuantity
                .Cells(cPackQuantity).Value = sampleDetailObj.PackQuantity
                .Cells(cTaxPercent).Value = sampleDetailObj.TaxPercent
                .Cells(cTaxAmount).Value = sampleDetailObj.TaxAmount
                .Cells(cDiscountPercent).Value = sampleDetailObj.DiscountPercent
                .Cells(cDiscountAmount).Value = sampleDetailObj.DiscountAmount
                .Cells(cTotal).Value = sampleDetailObj.GetTotal
                .Cells(cStorage).Value = GetStorageName(.Cells(cStorageId).Value)
                .Cells(cName).Value = GetItemName(.Cells(cItemId).Value)
                .Cells(cSampleId).Value = sampleDetailObj.SampleId
                .Cells(cPricePurchase).Value = sampleDetailObj.PricePurchase
                .Cells(cRemark).Value = sampleDetailObj.Remark
                .Cells(cForCashOut).Value = False
                .Cells(cUserId).Value = sampleDetailObj.UserId
                .Cells(cDateOn).Value = sampleDetailObj.DateOn
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadComboBoxValues()
        'With CmbMode.Items
        '    .Clear()
        '    .Add(cStatusCash)
        '    .Add(cStatusCredit)
        'End With

        'CmbMode.Text = cStatusCash

        'With CmbSampleOn.Items
        '    .Clear()
        '    .Add(cMRP)
        '    .Add(cPTR)
        '    .Add(cPTS)
        '    .Add(cRate1)
        '    .Add(cRate2)
        '    .Add(cRate3)
        'End With

        'CmbSampleOn.Text = cPTS

        'LoadTaxes()

        'With CmbTax.Items
        '    .Clear()
        '    .Add(cVAT)
        '    .Add(cCST)
        '    .Add(cCSTFormC)
        '    .Add(cCSTFormF)
        'End With

        'CmbTax.Text = cVAT

        LoadManufacturers()
        LoadComboBoxValuesForCategory()
        LoadComboBoxValuesForCustomers()
        LoadComboBoxValuesForDoctors()
        LoadComboBoxValuesForDivision()
        LoadComboBoxValuesForTransporter()
        LoadComboBoxValuesForHQ()
        LoadComboBoxValuesForCardNo()
    End Sub

    Private Sub LoadTaxes()
        Try
            Dim taxes() As ClsTaxMaster = GetAllTaxMasters(Me.Name)
            lVAT = GetTaxPercent(taxes, cVAT)
            lCST = GetTaxPercent(taxes, cCST)
            lCSTFormC = GetTaxPercent(taxes, cCSTFormC)
            lCSTFormF = GetTaxPercent(taxes, cTransferFormF)

        Catch ex As Exception
            AddToLog(ex)
        End Try
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

    Private Sub LoadComboBoxValuesForDoctors()
        'Try
        '    CmbDoctor.DataSource = Nothing
        '    CmbDoctor.Items.Clear()
        '    CmbDoctor.Text = ""

        '    Dim doctors() As ClsDoctorMaster = GetAllDoctorMaster(Me.Name)
        '    If doctors Is Nothing Then Exit Try

        '    CmbDoctor.DataSource = doctors
        '    CmbDoctor.DisplayMember = cName
        '    CmbDoctor.ValueMember = cId
        '    If CmbDoctor.Items.Count > 0 Then CmbDoctor.SelectedIndex = 0

        'Catch ex As Exception
        '    AddToLog(ex)
        'End Try
    End Sub

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

    Private Sub LoadComboBoxValuesForCardNo()
        Try
            CmbCardNo.Items.Clear()

            Dim customers() As ClsCustomerMaster = GetAllCustomerMaster(Me.Name)
            If customers Is Nothing Then Exit Try

            CmbCardNo.DisplayMember = cCardNo
            CmbCardNo.ValueMember = cId
            Dim customer As ClsCustomerMaster
            For Each customer In customers
                'If customer.CardNo = "" Then Continue For

                CmbCardNo.Items.Add(customer)
            Next

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
                ErrorInData("Please enter sample quantity.", TxtQuantity)
                Exit Try
            End If

            If Val(TxtQuantity.Text) <= 0 Then
                ErrorInData("Please enter sample quantity greater then 0.", TxtQuantity)
                Exit Try
            End If

            'If TxtSamplePrice.Text.Trim = "" Or lSamplePrice = 0 Then
            '    ErrorInData("Please enter sample price.", TxtSamplePrice)
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
    ''            Dim sampleQtyPrv As Double = editRow.Cells(cSampleQuantity).Value
    ''            Dim diffQty As Double = qty - sampleQtyPrv
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

    Private Sub UpdateSampleDetailObject()
        Try
            If editRow Is Nothing Or lSampleObj Is Nothing Then Exit Try

            If flagOldObject = False Then
                If AndedTheString(gUser.AuthorizationNo, Authorization.IssueSample_Current_NoUpdate) = True Then Exit Sub
            Else
                If AndedTheString(gUser.AuthorizationNo, Authorization.IssueSample_Old_NoUpdate) = True Then Exit Sub
            End If

            If ValidateValues() = False Then Exit Sub

            Dim currentStock As ClsCurrentStock = lCurrentBatch 'GetSelectedItem(CmbBatch)
            If currentStock Is Nothing Then Exit Try

            'Updating Detail
            Dim sampleDetailObj As New ClsSampleDetail
            With sampleDetailObj
                .Id = editRow.Cells(cId).Value
                .SampleId = lSampleObj.Id
                .ItemId = currentStock.ItemId
                .PriceSample = lSamplePrice 'Val(TxtSamplePrice.Text)
                .SampleQuantity = Val(TxtQuantity.Text)
                .FreeQuantity = 0 'Val(TxtFreeQuantity.Text)
                .TaxPercent = 0
                .DiscountPercent = 0 'Val(TxtDiscountPercent.Text)
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
                'CalculateTotal(.TaxAmount, .DiscountAmount)
            End With

            If UpdateSampleDetail(Me.Name, sampleDetailObj) <> EnResult.Change Then Exit Sub

            With editRow
                .Cells(cItemId).Value = sampleDetailObj.ItemId
                .Cells(cStorageId).Value = sampleDetailObj.StorageId
                .Cells(cBatch).Value = sampleDetailObj.Batch
                .Cells(cExpiryDate).Value = sampleDetailObj.ExpiryDate
                .Cells(cManufacturerId).Value = sampleDetailObj.ManufacturerId
                .Cells(cManufacturer).Value = GetManufacturer(.Cells(cManufacturerId).Value)
                .Cells(cManufactureDate).Value = sampleDetailObj.ManufactureDate
                .Cells(cPriceSample).Value = sampleDetailObj.PriceSample
                .Cells(cMRP).Value = sampleDetailObj.MRP
                .Cells(cPTR).Value = sampleDetailObj.PTR
                .Cells(cPTS).Value = sampleDetailObj.PTS
                .Cells(cRate1).Value = sampleDetailObj.Rate1
                .Cells(cRate2).Value = sampleDetailObj.Rate2
                .Cells(cRate3).Value = sampleDetailObj.Rate3
                .Cells(cSampleQuantity).Value = sampleDetailObj.SampleQuantity
                .Cells(cFreeQuantity).Value = sampleDetailObj.FreeQuantity
                .Cells(cPackQuantity).Value = sampleDetailObj.PackQuantity
                .Cells(cTaxPercent).Value = sampleDetailObj.TaxPercent
                .Cells(cTaxAmount).Value = sampleDetailObj.TaxAmount
                .Cells(cDiscountPercent).Value = sampleDetailObj.DiscountPercent
                .Cells(cDiscountAmount).Value = sampleDetailObj.DiscountAmount
                .Cells(cTotal).Value = sampleDetailObj.GetTotal
                .Cells(cStorage).Value = GetStorageName(.Cells(cStorageId).Value)
                .Cells(cName).Value = GetItemName(.Cells(cItemId).Value)
                .Cells(cPricePurchase).Value = sampleDetailObj.PricePurchase
                .Cells(cRemark).Value = sampleDetailObj.Remark
                .Cells(cForCashOut).Value = sampleDetailObj.ForCashOut
                .Cells(cUserId).Value = sampleDetailObj.UserId
                .Cells(cDateOn).Value = sampleDetailObj.DateOn
            End With

            'UpdateCurrentStockForItemIdBatch(sampleDetailObj.ItemId, sampleDetailObj.Batch)
            GetAllCurrentStock(Me.Name)

            'CalculateTotals()
            lSampleObj.NotClosed = True
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
        'TxtSamplePrice.Text = ""
        lSamplePrice = 0
        'TxtTotal.Text = ""
        'TxtDiscountPercent.Text = ""
        'TxtFreeQuantity.Text = ""

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
        TxtSampleCode.Text = ""
        DtPkrSampleDate.Value = Now
        CmbCardNo.Text = ""
        CmbCustomer.Text = ""
        TxtTinNo.Text = ""
        TxtDLNo.Text = ""
        'CmbDoctor.Text = ""
        'ChkCashMemo.Checked = False
        TxtReference.Text = ""
        'TxtDiscountOnBill.Text = ""
        'TxtBillRoundOff.Text = ""
        'TxtBillNetAmount.Text = ""
        'TxtOverAllDiscount.Text = ""
        'CmbMode.Text = cStatusCash
        'CmbTax.Text = cVAT
        'CmbSampleOn.Text = GetSampleOn()
        'TxtDiscount.Text = ""
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
        'TxtCreditAdj.Text = ""
        'TxtDebitAdj.Text = ""
        'TxtPreExciseAmount.Text = ""
        'TxtGrossAmount.Text = ""

        flagOldObject = False
        GrdSample.Rows.Clear()
        ResetControlsToAddNewItem()
        lSampleObj = Nothing
        flagCategoryChange = EnLoading.None

        CmbCardNo.Focus()
    End Sub

    'Private Sub CalculateTotals()
    '    Try
    '        TxtGrossAmount.Text = ""
    '        TxtDiscount.Text = ""

    '        'If GrdSample.Rows.Count = 0 Then Exit Try

    '        Dim totalAmount As Double = 0
    '        ' Dim taxTotal As Double = 0
    '        Dim discountTotal As Double = 0

    '        Dim row As DataGridViewRow
    '        For Each row In GrdSample.Rows
    '            With row
    '                'taxTotal = taxTotal + Val(.Cells(cTaxAmount).Value)
    '                Dim total As Double = (Val(.Cells(cPriceSample).Value) * Val(.Cells(cSampleQuantity).Value))
    '                Dim discount As Double = total * Val(.Cells(cDiscountPercent).Value) / 100
    '                discountTotal = discountTotal + discount
    '                totalAmount = totalAmount + total '- discount
    '            End With
    '        Next

    '        TxtDiscount.Text = Format(discountTotal, "0.00")
    '        TxtGrossAmount.Text = Format(totalAmount, "0.00")

    '    Catch ex As Exception
    '        AddToLog(ex)
    '    End Try
    'End Sub

    'Private Sub CalculateTotal(Optional ByRef taxAmount As Double = 0, Optional ByRef discountAmount As Double = 0)
    '    Try
    '        If TxtQuantity.Text.Trim = "" Then Exit Try
    '        If TxtSamplePrice.Text.Trim = "" Then Exit Try

    '        Dim discountPercent As Double = Val(TxtDiscountPercent.Text)
    '        Dim sampleQuantity As Double = Val(TxtQuantity.Text)
    '        Dim samplePrice As Double = lSamplePrice 'Val(TxtSamplePrice.Text)
    '        Dim total As Double = samplePrice * sampleQuantity

    '        discountAmount = total * discountPercent / 100

    '        'Deducting discount
    '        total = total '- discountAmount

    '        taxAmount = 0

    '        'Adding tax in total
    '        total = total + taxAmount

    '        TxtTotal.Text = Format(total, "0.00")

    '    Catch ex As Exception
    '        AddToLog(ex)
    '    End Try
    'End Sub

    Private Sub SetSampleIdForCurrentLogin()
        Try
            lSampleObj = Nothing
            SetCustomerEnability(True)
            Dim sampleMaster As ClsSampleMaster = GetSampleMasterNotClosedForLogin(Me.Name, gUser.LoginName)
            If sampleMaster Is Nothing Then Exit Try

            SetCustomerEnability(False)
            lSampleObj = sampleMaster
            With sampleMaster
                TxtSampleCode.Text = .SampleCode
                DtPkrSampleDate.Value = .SampleDate
                'CmbMode.Text = .Mode
                'TxtDiscountOnBill.Text = Format(.DiscountAmount, "0.00")
                'CmbDoctor.Text = GetDoctorName(.DoctorId)
                Dim customer As ClsCustomerMaster = GetCustomer(.CustomerId)
                If customer Is Nothing Then
                    lSampleObj = Nothing
                    SetCustomerEnability(True)
                    Exit Try
                End If

                'ChkCashMemo.Checked = lSampleObj.CashMemo
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
                'TxtCreditAdj.Text = .CreditAdjust
                'TxtDebitAdj.Text = .DebitAdjust
                'TxtPreExciseAmount.Text = .PreExciseAmount
                'CmbTax.Text = .TaxName
            End With

            flagOldObject = False

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub SetSampleForSampleId(ByVal id As Long)
        Try
            lSampleObj = Nothing
            SetCustomerEnability(True)
            If id <= 0 Then Exit Try

            Dim sampleMaster As ClsSampleMaster = GetSampleMaster(Me.Name, id)
            If sampleMaster Is Nothing Then Exit Try

            SetCustomerEnability(False)
            lSampleObj = sampleMaster
            With sampleMaster
                TxtSampleCode.Text = .SampleCode
                DtPkrSampleDate.Value = .SampleDate
                'CmbMode.Text = .Mode
                'TxtDiscountOnBill.Text = Format(.DiscountAmount, "0.00")
                'CmbDoctor.Text = GetDoctorName(.DoctorId)
                Dim customer As ClsCustomerMaster = GetCustomer(.CustomerId)
                If customer Is Nothing Then
                    lSampleObj = Nothing
                    SetCustomerEnability(True)
                    Exit Try
                End If

                lFlagTaxNot = EnLoading.LoadOnLostFocus
                'ChkCashMemo.Checked = lSampleObj.CashMemo
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
                'TxtCreditAdj.Text = .CreditAdjust
                'TxtDebitAdj.Text = .DebitAdjust
                'TxtPreExciseAmount.Text = .PreExciseAmount
                'CmbTax.Text = .TaxName
            End With

            flagOldObject = True

        Catch ex As Exception
            AddToLog(ex)
        End Try

        lFlagTaxNot = EnLoading.LoadOnChange
        LoadGridValuesForSample()
        'CalculateTotals()
    End Sub

    Private Sub SetCustomerEnability(ByVal flag As Boolean)
        CmbCustomer.Enabled = flag
        CmbCardNo.Enabled = flag
        LblAddCustomer.Enabled = flag
    End Sub

    'Private Function GetPrice(ByVal itemId As Integer, ByVal batch As String, ByVal customerId As Integer) As Double
    '    Dim result As Double = 0
    '    Try
    '        If itemId <= 0 Then Exit Try
    '        If batch.Trim = "" Then Exit Try
    '        If customerId <= 0 Then Exit Try

    '        result = GetCustomerTypePrice(Me.Name, itemId, batch, customerId)

    '    Catch ex As Exception
    '        AddToLog(ex)
    '    End Try

    '    Return result
    'End Function

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

    Private Sub LoadBatchForSelectedItem()
        Try
            'CmbBatch.DataSource = Nothing
            'CmbBatch.Items.Clear()
            'CmbBatch.SelectedIndex = -1

            Dim itemId As Integer = GetSelectedItemId(CmbItem)
            If itemId < 0 Then Exit Try

            Dim currentStocks() As ClsCurrentStock = GetAllCurrentStockForItemId(Me.Name, itemId, False, flagLoadForUpdate)
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

    'Private Sub SetTaxNameAndTax(ByRef taxName As String, ByRef tax As Double)
    '    If lFlagTaxNot <> EnLoading.None Then
    '        If lSampleObj Is Nothing Then
    '            taxName = ""
    '            tax = 0
    '        Else
    '            taxName = lSampleObj.TaxName
    '            tax = lSampleObj.TaxPercent
    '        End If
    '    ElseIf CmbTax.Text = cVAT Then
    '        taxName = cVAT
    '        tax = lVAT
    '    ElseIf CmbTax.Text = cCST Then
    '        taxName = cCST
    '        tax = lCST
    '    ElseIf CmbTax.Text = cCSTFormC Then
    '        taxName = cCSTFormC
    '        tax = lCSTFormC
    '    ElseIf CmbTax.Text = cCSTFormF Then
    '        taxName = cCSTFormF
    '        tax = lCSTFormF
    '    End If
    'End Sub

    'Private Sub CalculateTaxableAmount()
    '    Try
    '        TxtTaxableAmount.Text = ""
    '        Dim grossAmt As Double = Val(TxtGrossAmount.Text)
    '        'Dim discountAmt As Double = Val(TxtDiscountOnBill.Text)
    '        Dim discountAmt As Double = Val(TxtDiscount.Text)

    '        TxtTaxableAmount.Text = Format(grossAmt - discountAmt, "0.00")
    '        'TxtTaxableAmount.Text = Format(grossAmt, "0.00")

    '    Catch ex As Exception
    '        AddToLog(ex)
    '    End Try
    'End Sub

    'Private Sub CalculateTotalDiscount()
    '    Try
    '        TxtOverAllDiscount.Text = ""

    '        Dim discountAmt As Double = Val(TxtDiscountOnBill.Text)
    '        Dim discount As Double = Val(TxtDiscount.Text)

    '        TxtOverAllDiscount.Text = Format(discount + discountAmt, "0.00")

    '    Catch ex As Exception
    '        AddToLog(ex)
    '    End Try
    'End Sub

    'Private Sub CalculateTax()
    '    Try
    '        TxtTaxAmt.Text = ""

    '        Dim taxName As String = ""
    '        Dim tax As Double = 0
    '        SetTaxNameAndTax(taxName, tax)

    '        LblTaxPercent.Text = Format(tax, "0.00") + "%"

    '        Dim taxableAmt As Double = Val(TxtTaxableAmount.Text)
    '        Dim taxAmt As Double = taxableAmt * tax / 100

    '        TxtTaxAmt.Text = Format(taxAmt, "0.00")

    '    Catch ex As Exception
    '        AddToLog(ex)
    '    End Try
    'End Sub

    'Private Sub CalculateBillTotal()
    '    Try
    '        Dim grossAmt As Double = Val(TxtGrossAmount.Text)
    '        Dim tax As Double = Val(TxtTaxAmt.Text)
    '        Dim discount As Double = Val(TxtOverAllDiscount.Text) ' Val(TxtDiscountOnBill.Text) 'Val(TxtOverAllDiscount.Text)
    '        Dim creditAdj As Double = Val(TxtCreditAdj.Text)
    '        Dim debitAdj As Double = Val(TxtDebitAdj.Text)

    '        Dim totalWithoutROF As Double = grossAmt + tax - discount - creditAdj + debitAdj
    '        Dim netAmount As Double = GetSqlRound(Me.Name, totalWithoutROF)

    '        TxtBillRoundOff.Text = Format(netAmount - totalWithoutROF, "0.00")
    '        TxtBillNetAmount.Text = Format(netAmount, "0.00")

    '    Catch ex As Exception
    '        AddToLog(ex)
    '    End Try
    'End Sub

#End Region

End Class
