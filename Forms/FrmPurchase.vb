Imports AIMS.Author

Public Class FrmPurchase

#Region "Local variables and Constants"

    Dim editRow As DataGridViewRow = Nothing
    Dim flagSupplierChanged As Boolean = False
    Dim flagItemChanged As Boolean = False
    '    Dim lPurchaseId As Integer = cInvalidId
    Dim lPurchaseObj As ClsPurchaseMaster = Nothing
    Dim lItems() As ClsItemMaster = Nothing
    Dim flagCategoryChange As EnLoading = EnLoading.None
    Dim flagBatchChange As EnLoading = EnLoading.None
    Dim lItemsDataSet As DataSet = Nothing
    Dim lFlagTaxNot As EnLoading = EnLoading.None
    Dim flagOldObject As Boolean = False
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

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FrmPurchase_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not (lPurchaseObj Is Nothing) Then
            If lPurchaseObj.NotClosed = True Then
                If MsgBox("Purchase Master is not updated." + vbCrLf + vbCrLf + "To update click save button." + vbCrLf + vbCrLf + "Do you want to update Purchase master?", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub FrmPurchase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

    Private Sub CmbSupplier_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbSupplier.SelectedIndexChanged
        flagSupplierChanged = True
    End Sub

    Private Sub CmbSupplier_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbSupplier.KeyPress
        'AutoComplete(sender, e)
        flagSupplierChanged = True
    End Sub

    Private Sub CmbSupplier_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbSupplier.LostFocus
        Try
            If flagSupplierChanged = False Then Exit Try

            flagSupplierChanged = False
            TxtTINNo.Text = ""
            If CmbSupplier.FindStringExact(CmbSupplier.Text.Trim) < 0 Then Exit Try

            Dim supplier As ClsVendorMaster = CmbSupplier.SelectedItem
            If supplier Is Nothing Then Exit Try

            TxtTINNo.Text = supplier.TinNo

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub CmbItem_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbItem.SelectedIndexChanged
        flagItemChanged = True
    End Sub

    Private Sub CmbItem_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbItem.KeyPress
        'AutoComplete(sender, e)
        flagItemChanged = True
    End Sub

    Private Sub CmbItem_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbItem.LostFocus
        Try
            If flagItemChanged = False Then Exit Try

            flagItemChanged = False
            If CmbStorage.Items.Count > 0 Then CmbStorage.SelectedIndex = 0
            If CmbItem.FindStringExact(CmbItem.Text.Trim) < 0 Then Exit Try

            Dim item As ClsItemMaster = CmbItem.SelectedItem
            If item Is Nothing Then Exit Try

            With item
                SelectItemForSelectValue(CmbStorage, .StorageId)
            End With

            LoadComboBoxValuesForBatch()
            FillExistingValuesForSelectedItemAndBatch()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub CmbBatch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Try
            If BtnAdd.Text = lcUpdate Then
                UpdatePurchaseDetailObject()
                Exit Sub
            End If

            If flagOldObject = False Then
                If AndedTheString(gUser.AuthorizationNo, Authorization.Purchase_Current_NoAdd) = True Then Exit Sub
            Else
                If AndedTheString(gUser.AuthorizationNo, Authorization.Purchase_Old_NoAdd) = True Then Exit Sub
            End If


            If ValidateValues() = False Then Exit Sub

            'Saving Master if virtual
            If lPurchaseObj Is Nothing Then
                Dim purchaseMasterObj As New ClsPurchaseMaster
                With purchaseMasterObj
                    .Mode = CmbStatus.Text
                    .NotClosed = True
                    .OrderId = GetSelectedItemId(CmbAgainstOrder)
                    .PurchaseDate = DtPkrPurchaseDate.Value
                    .Remark = TxtRemark.Text
                    .UserId = gUser.LoginName
                    .DateOn = Now
                    .VendorId = GetSelectedItemId(CmbSupplier)
                    .VoucherNo = TxtVoucher.Text
                    .DiscountAmount = Val(TxtDiscountOnBill.Text)
                    .CreditAdjust = Val(TxtCreditAdj.Text)
                    .DebitAdjust = Val(TxtDebitAdj.Text)
                    .PreExciseAmount = Val(TxtPreExciseAmount.Text)
                    SetTaxIdAndTax(.TaxId, .TaxPercent)
                End With

                Dim purchaseId As Integer = InsertIntoPurchaseMaster(Me.Name, purchaseMasterObj)
                If purchaseId <= 0 Then Exit Try

                purchaseMasterObj.Id = purchaseId
                lPurchaseObj = purchaseMasterObj

                purchaseMasterObj = GetPurchaseMaster(Me.Name, purchaseId)
                If Not (purchaseMasterObj Is Nothing) Then
                    lPurchaseObj = purchaseMasterObj
                    TxtPurchaseCode.Text = lPurchaseObj.PurchaseCode
                End If
            End If

            'Saving Detail
            Dim purchaseDetailObj As New ClsPurchaseDetail
            With purchaseDetailObj
                .PurchaseId = lPurchaseObj.Id
                Dim item As ClsItemMaster = GetSelectedItem(CmbItem)
                .ItemId = item.Id 'GetSelectedItemId(CmbItem)
                .ManufacturerId = item.ManufacturerId
                .Batch = cBatchDefault 'CmbBatch.Text
                .ExpiryDate = DateDefault 'GetExpiryDate()
                .ManufactureDate = DateDefault 'GetManufactureDate()
                .PricePurchase = Val(TxtPurchasePrice.Text) / Val(TxtPackQty.Text)
                .MRP = Val(TxtMRP.Text) / Val(TxtPackQty.Text)
                .PTR = Val(TxtPTR.Text) / Val(TxtPackQty.Text)
                .PTS = Val(TxtPTS.Text) / Val(TxtPackQty.Text)
                .Rate1 = Val(TxtRate1.Text) / Val(TxtPackQty.Text)
                .Rate2 = Val(TxtRate2.Text) / Val(TxtPackQty.Text)
                .Rate3 = Val(TxtRate3.Text) / Val(TxtPackQty.Text)
                .TaxPercent = 0 'item.VAT
                .DiscountPercent = Val(TxtDiscountPercent.Text)
                .PurchaseQuantity = Val(TxtPurchaseQuantity.Text) * Val(TxtPackQty.Text)
                .FreeQuantity = Val(TxtFreeQuantity.Text)
                .PackQuantity = Val(TxtPackQty.Text)
                .StorageId = GetSelectedItemId(CmbStorage)
                .Remark = TxtRemark.Text
                .UserId = gUser.LoginName
                .DateOn = Now
                .TaxAmount = 0 'Val(item.VAT) * (Val(TxtPurchasePrice.Text) / Val(TxtPackQty.Text)) * (Val(TxtPurchaseQuantity.Text) * Val(TxtPackQty.Text))
                .DiscountAmount = 0
            End With

            Dim id As Long = InsertIntoPurchaseDetail(Me.Name, purchaseDetailObj)
            If id > 0 Then
                purchaseDetailObj.Id = id
                InsertIntoGrid(purchaseDetailObj)
                CalculateTotals()
                lPurchaseObj.NotClosed = True
            End If

            MsgBox("Successfully Added", , "Added")

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNewItem()
    End Sub

    Private Sub BtnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemove.Click
        Try
            Dim row As DataGridViewRow = GrdItems.SelectedRows(0)
            If row Is Nothing Then Exit Try

            If flagOldObject = False Then
                If AndedTheString(gUser.AuthorizationNo, Authorization.Purchase_Current_NoRemove) = True Then Exit Sub
            Else
                If AndedTheString(gUser.AuthorizationNo, Authorization.Purchase_Old_NoRemove) = True Then Exit Sub
            End If

            Dim id As Long = row.Cells(cId).Value
            If id <= 0 Then Exit Try

            If MsgBox("Do you really wants to remove selected record? Removed records can't be recovered.", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                If DeletePurchaseDetail(Me.Name, id) <> EnResult.Change Then Exit Sub

                CalculateTotals()
                lPurchaseObj.NotClosed = True
                GrdItems.Rows.Remove(row)
                MsgBox("Successfully Removed", , "Removed")
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNewItem()
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        If BtnNew.Text = lcCancel Then
            ResetControlsToAddNewItem()
        Else
            If Not (lPurchaseObj Is Nothing) Then
                If lPurchaseObj.NotClosed = True Then
                    If MsgBox("Purchase Master is not updated." + vbCrLf + vbCrLf + "To update click save button." + vbCrLf + vbCrLf + "Do you want to update Purchase master?", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                        Exit Sub
                    End If
                End If
            End If

            ResetControlsToAddNew()
        End If
    End Sub

    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch.Click
        Try
            Dim frm As New ClsSearchPurchaseForm
            If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Dim id As Integer = frm.GetSelectedId
                If id > 0 Then
                    SetPurchaseForPurchaseId(id)
                    flagOldObject = True
                End If
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Try
            If lPurchaseObj Is Nothing Then
                MsgBox("There is no Purchase selected. Please create or select Purchase.", , "Purchase")
                Exit Try
            End If

            If lPurchaseObj.Id <= 0 Then
                MsgBox("There is no Purchase selected. Please create or select Purchase.", , "Purchase")
                Exit Try
            End If

            Dim purchaseId As Long = lPurchaseObj.Id
            Dim ds As DataSet = GetPurchase(Me.Name, purchaseId)

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
            Dim rpt As New RptPurchase
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
            If lPurchaseObj Is Nothing Then Exit Try

            If flagOldObject = False Then
                If AndedTheString(gUser.AuthorizationNo, Authorization.Purchase_Current_NoUpdate) = True Then Exit Sub
            Else
                If AndedTheString(gUser.AuthorizationNo, Authorization.Purchase_Old_NoUpdate) = True Then Exit Sub
            End If


            'Updating Master
            Dim purchaseMasterObj As New ClsPurchaseMaster
            With purchaseMasterObj
                .Id = lPurchaseObj.Id
                .PurchaseCode = lPurchaseObj.PurchaseCode
                .Mode = CmbStatus.Text
                .NotClosed = False
                .OrderId = GetSelectedItemId(CmbAgainstOrder)
                .PurchaseDate = DtPkrPurchaseDate.Value
                .Remark = TxtRemark.Text
                .UserId = gUser.LoginName
                .DateOn = Now
                .VendorId = GetSelectedItemId(CmbSupplier)
                .VoucherNo = TxtVoucher.Text
                .DiscountAmount = Val(TxtDiscountOnBill.Text)
                .CreditAdjust = Val(TxtCreditAdj.Text)
                .DebitAdjust = Val(TxtDebitAdj.Text)
                .PreExciseAmount = Val(TxtPreExciseAmount.Text)
                .FreightCharge = Val(TxtFreightCharge.Text)
                SetTaxIdAndTax(.TaxId, .TaxPercent)

            End With

            If UpdatePurchaseMaster(Me.Name, purchaseMasterObj) <> EnResult.Change Then Exit Sub
            lPurchaseObj = purchaseMasterObj

            MsgBox("Successfully Saved", , "Saved")

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub GrdItems_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdItems.CellClick
        If e.RowIndex < 0 Then Exit Sub

        If flagOldObject = False Then
            If AndedTheString(gUser.AuthorizationNo, Authorization.Purchase_Current_NoRemove) = True Then Exit Sub
        Else
            If AndedTheString(gUser.AuthorizationNo, Authorization.Purchase_Old_NoRemove) = True Then Exit Sub
        End If

        BtnRemove.Enabled = True
        BtnAdd.Enabled = False
        BtnNew.Text = lcCancel
    End Sub

    Private Sub GrdItems_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdItems.CellDoubleClick
        Try
            BtnRemove.Enabled = False
            If e.RowIndex < 0 Then Exit Try

            If flagOldObject = False Then
                If AndedTheString(gUser.AuthorizationNo, Authorization.Purchase_Current_NoUpdate) = True Then Exit Sub
            Else
                If AndedTheString(gUser.AuthorizationNo, Authorization.Purchase_Old_NoUpdate) = True Then Exit Sub
            End If

            editRow = GrdItems.Rows(e.RowIndex)
            With editRow
                flagCategoryChange = EnLoading.LoadOnChange
                CmbCategory.Text = GetCategoryForItemId(.Cells(cItemId).Value)
                flagCategoryChange = EnLoading.None

                CmbItem.Text = .Cells(cName).Value
                'CmbBatch.Text = .Cells(cBatch).Value
                TxtExpiryDate.Text = DateDefault 'Format(.Cells(cExpiryDateX).Value, "MMyyyy")
                TxtManufactureDate.Text = DateDefault 'Format(.Cells(cManufactureDateX).Value, "MMyyyy")
                TxtPurchasePrice.Text = .Cells(cPricePurchase).Value * .Cells(cPackQuantity).Value
                TxtMRP.Text = Math.Ceiling(.Cells(cMRP).Value * .Cells(cPackQuantity).Value)
                TxtPTR.Text = Math.Ceiling(.Cells(cPTR).Value * .Cells(cPackQuantity).Value)
                TxtPTS.Text = Math.Ceiling(.Cells(cPTS).Value * .Cells(cPackQuantity).Value)
                TxtRate3.Text = Math.Ceiling(.Cells(cPTD).Value * .Cells(cPackQuantity).Value)
                TxtRate1.Text = Math.Ceiling(.Cells(cRate1).Value * .Cells(cPackQuantity).Value)
                TxtRate2.Text = Math.Ceiling(.Cells(cRate2).Value * .Cells(cPackQuantity).Value)
                TxtPurchaseQuantity.Text = .Cells(cPurchaseQuantity).Value / .Cells(cPackQuantity).Value
                CmbStorage.Text = .Cells(cStorage).Value
                TxtPackQty.Text = .Cells(cPackQuantity).Value
                TxtFreeQuantity.Text = .Cells(cFreeQuantity).Value
                TxtDiscountPercent.Text = .Cells(cDiscountPercent).Value
            End With

            BtnAdd.Text = lcUpdate
            BtnNew.Text = lcCancel
            BtnAdd.Enabled = True
            flagItemChanged = False
            'CmbBatch.Enabled = False
            CmbCategory.Focus()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub GrdItems_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdItems.KeyDown
        If e.KeyCode = Keys.Tab Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub TxtPurchasePrice_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPurchasePrice.TextChanged
        If TxtPurchasePrice.Text.Trim = "" Then Exit Sub
    End Sub

    Private Sub Deicmal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMRP.KeyPress, TxtPTR.KeyPress, TxtRate3.KeyPress, TxtRate2.KeyPress, TxtRate1.KeyPress, TxtPurchaseQuantity.KeyPress, TxtPurchasePrice.KeyPress, TxtPTS.KeyPress, TxtPackQty.KeyPress, TxtFreeQuantity.KeyPress, TxtDiscountPercent.KeyPress, TxtTaxAmt.KeyPress, TxtTaxableAmount.KeyPress, TxtOverAllDiscount.KeyPress, TxtGrossAmount.KeyPress, TxtDiscountOnBill.KeyPress, TxtDiscount.KeyPress, TxtDebitAdj.KeyPress, TxtCreditAdj.KeyPress, TxtBillRoundOff.KeyPress, TxtBillNetAmount.KeyPress, TxtPreExciseAmount.KeyPress, TxtFreightCharge.KeyPress
        e.Handled = Check_DecimalAllow(e.KeyChar, sender.text)
    End Sub

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtTINNo.KeyDown, TxtPurchaseCode.KeyDown, DtPkrPurchaseDate.KeyDown, CmbSupplier.KeyDown, CmbStorage.KeyDown, CmbStatus.KeyDown, CmbItem.KeyDown, CmbAgainstOrder.KeyDown, TxtPurchaseQuantity.KeyDown, TxtPurchasePrice.KeyDown, TxtPackQty.KeyDown, TxtExpiryDate.KeyDown, CmbCategory.KeyDown, TxtManufactureDate.KeyDown, TxtMRP.KeyDown, TxtPTR.KeyDown, TxtRate3.KeyDown, TxtRate2.KeyDown, TxtRate1.KeyDown, TxtPTS.KeyDown, TxtTaxAmt.KeyDown, TxtTaxableAmount.KeyDown, TxtOverAllDiscount.KeyDown, TxtGrossAmount.KeyDown, TxtFreeQuantity.KeyDown, TxtDiscountPercent.KeyDown, TxtDiscountOnBill.KeyDown, TxtDiscount.KeyDown, TxtDebitAdj.KeyDown, TxtCreditAdj.KeyDown, TxtBillRoundOff.KeyDown, TxtBillNetAmount.KeyDown, TxtRemark.KeyDown, TxtPreExciseAmount.KeyDown, CmbTax.KeyDown, TxtFreightCharge.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub TxtVoucher_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtVoucher.KeyDown
        If e.KeyCode = Keys.Enter Then CmbAgainstOrder.Focus()
    End Sub

    Private Sub CmbCategory_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbCategory.LostFocus
        Try
            If flagCategoryChange <> EnLoading.LoadOnLostFocus Then Exit Try

            flagCategoryChange = EnLoading.None
            LoadComboBoxValuesForItem()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub CmbCategory_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbCategory.SelectedIndexChanged
        Try
            If flagCategoryChange = EnLoading.None Then flagCategoryChange = EnLoading.LoadOnLostFocus
            If flagCategoryChange <> EnLoading.LoadOnChange Then Exit Try

            LoadComboBoxValuesForItem()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    'Private Sub CmbBatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try
    '        If flagBatchChange = EnLoading.None Then flagBatchChange = EnLoading.LoadOnLostFocus
    '        If flagBatchChange <> EnLoading.LoadOnChange Then Exit Try

    '    Catch ex As Exception
    '        AddToLog(ex)
    '    End Try
    'End Sub

    'Private Sub CmbBatch_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try
    '        If flagBatchChange <> EnLoading.LoadOnLostFocus Then Exit Try

    '        FillExistingValuesForSelectedItemAndBatch()

    '    Catch ex As Exception
    '        AddToLog(ex)
    '    End Try
    'End Sub

    Private Sub TxtCreditAdj_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCreditAdj.TextChanged
        CalculateBillTotal()
    End Sub

    Private Sub TxtDebitAdj_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDebitAdj.TextChanged
        CalculateBillTotal()
    End Sub

    Private Sub CmbTax_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbTax.SelectedIndexChanged
        If lFlagTaxNot = EnLoading.LoadOnChange Then lFlagTaxNot = EnLoading.None
        CalculateTax()
    End Sub

    Private Sub TxtTaxAmt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtTaxAmt.TextChanged
        CalculateBillTotal()
    End Sub

    Private Sub TxtGrossAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtGrossAmount.TextChanged
        CalculateTaxableAmount()
        CalculateBillTotal()
    End Sub

    Private Sub TxtDiscount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDiscount.TextChanged
        CalculateTotalDiscount()
    End Sub

    Private Sub TxtDiscountOnBill_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDiscountOnBill.TextChanged
        CalculateTaxableAmount()
        CalculateTotalDiscount()
    End Sub

    Private Sub TxtTaxableAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtTaxableAmount.TextChanged
        CalculateTax()
    End Sub

    Private Sub TxtOverAllDiscount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtOverAllDiscount.TextChanged
        CalculateBillTotal()
    End Sub

    Private Sub TxtFreightCharge_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFreightCharge.TextChanged
        CalculateBillTotal()
    End Sub
#End Region

#Region "Other Form Functionality"

    Private Sub LblAddItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblAddItem.Click
        If AndedTheString(gUser.AuthorizationNo, Authorization.Items) = False Then Exit Sub
        Try
            Dim frm As New FrmItemMaster
            frm.ShowDialog(Me)
            If frm.Change = True Then
                lItemsDataSet = Nothing
                LoadItems()
                LoadComboBoxValuesForItem()
            End If

            frm.Dispose()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LblAddVendor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblAddVendor.Click
        If AndedTheString(gUser.AuthorizationNo, Authorization.Vendors) = False Then Exit Sub
        Try
            Dim frm As New FrmVendorMaster
            frm.ShowDialog(Me)
            If frm.Change = True Then LoadComboBoxValuesForSupplier()

            frm.Dispose()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LblCustomerTypePrice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblCustomerTypePrice.Click
        Try
            Dim itemId As Integer = GetSelectedItemId(CmbItem)
            Dim itemName As String = GetItemName(itemId)
            Dim batch As String = cBatchDefault 'CmbBatch.Text

            RemoveErrorIcon()
            If itemId <= 0 Then
                ErrorInData("Please select item and then enter price.", CmbItem)
                Exit Try
                'ElseIf batch.Trim = "" Then
                '    ErrorInData("Please select/enter batch and then enter price.", CmbBatch)
                '    Exit Try
            End If

            Dim frm As New FrmCustomerTypePrice
            frm.SetValues(itemId, itemName, batch)
            frm.ShowDialog(Me)

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

#End Region

#Region "Private Function"

    Private Sub SetControls()
        LoadItems()
        LoadComboBoxValues()

        SetGrid()
        ResetControlsToAddNew()
        LoadComboBoxValuesForCategory()

        'This will open last unsaved work
        SetPurchaseIdForCurrentLogin()
        LoadGridValuesForPurchaseDetail()
        CalculateTotals()
    End Sub

    Private Sub SetGrid()
        With GrdItems
            Dim colCount As Integer = 24
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
                        .Columns(index).Width = 260

                    Case 3
                        Dim index As Integer = .Columns.Add(cItemId, cItemId)
                        .Columns(index).Visible = False

                    Case 4
                        Dim index As Integer = .Columns.Add(cBatch, cBatch)
                        .Columns(index).Width = defaultCellWidth + 40
                        .Columns(index).Visible = False

                    Case 5
                        Dim index As Integer = .Columns.Add(cStorage, cStorage)
                        .Columns(index).Width = defaultCellWidth

                    Case 6
                        Dim index As Integer = .Columns.Add(cExpiryDate, "Exp. Date")
                        .Columns(index).Width = defaultCellWidth + 10
                        .Columns(index).DefaultCellStyle.Format = "MMM-yyyy"
                        .Columns(index).Visible = False

                    Case 7
                        Dim index As Integer = .Columns.Add(cManufactureDate, "Mfg. Date")
                        .Columns(index).Width = defaultCellWidth + 10
                        .Columns(index).DefaultCellStyle.Format = "MMM-yyyy"
                        .Columns(index).Visible = False

                    Case 8
                        Dim index As Integer = .Columns.Add(cPackQuantity, "Pack Qty.")
                        .Columns(index).Width = defaultCellWidth

                    Case 9
                        Dim index As Integer = .Columns.Add(cPurchaseQuantity, "Pur. Qty.")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 10
                        Dim index As Integer = .Columns.Add(cPricePurchase, "Pur. Price")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 11
                        Dim index As Integer = .Columns.Add(cMRP, cMRP)
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 12
                        Dim index As Integer = .Columns.Add(cPTS, cPTS)
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 13
                        Dim index As Integer = .Columns.Add(cPTD, cPTD)
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 14
                        Dim index As Integer = .Columns.Add(cPTR, cPTR)
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 15
                        Dim index As Integer = .Columns.Add(cRate1, cRate1)
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 16
                        Dim index As Integer = .Columns.Add(cRate2, cRate2)
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 17
                        Dim index As Integer = .Columns.Add(cTaxPercent, "Tax %")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns(index).Visible = False

                    Case 18
                        Dim index As Integer = .Columns.Add(cTaxAmount, "Tax Amt.")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns(index).Visible = False

                    Case 19
                        Dim index As Integer = .Columns.Add(cDiscountPercent, "Dis. %")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 20
                        Dim index As Integer = .Columns.Add(cDiscountAmount, "Dis. Amt.")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns(index).Visible = False

                    Case 21
                        Dim index As Integer = .Columns.Add(cUserId, cUserId)
                        .Columns(index).Visible = False

                    Case 22
                        Dim index As Integer = .Columns.Add(cDateOn, cDateOn)
                        .Columns(index).Visible = False

                    Case 23
                        Dim index As Integer = .Columns.Add(cFreeQuantity, "Free Qty.")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 24
                        Dim index As Integer = .Columns.Add(cStorageId, cStorageId)
                        .Columns(index).Visible = False

                End Select
            Next
        End With
    End Sub

    Private Sub LoadGridValuesForPurchaseDetail()
        Try
            GrdItems.Rows.Clear()

            If lPurchaseObj Is Nothing Then Exit Try

            Dim purchaseDetails() As ClsPurchaseDetail = GetAllPurchaseDetailForPurchaseId(Me.Name, lPurchaseObj.Id)
            If purchaseDetails Is Nothing Then Exit Try

            Dim purchaseDetail As ClsPurchaseDetail
            For Each purchaseDetail In purchaseDetails
                InsertIntoGrid(purchaseDetail)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub InsertIntoGrid(ByRef purchaseDetailObj As ClsPurchaseDetail)
        Try
            If purchaseDetailObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdItems.Rows.Add
            With GrdItems.Rows(rowIndex)
                .Cells(cId).Value = purchaseDetailObj.Id
                .Cells(cPurchaseId).Value = purchaseDetailObj.PurchaseId
                .Cells(cItemId).Value = purchaseDetailObj.ItemId
                .Cells(cName).Value = GetItemName(.Cells(cItemId).Value)
                .Cells(cBatch).Value = purchaseDetailObj.Batch
                .Cells(cExpiryDate).Value = purchaseDetailObj.ExpiryDate
                .Cells(cManufactureDate).Value = purchaseDetailObj.ManufactureDate
                .Cells(cPricePurchase).Value = purchaseDetailObj.PricePurchase
                .Cells(cMRP).Value = purchaseDetailObj.MRP
                .Cells(cPTR).Value = purchaseDetailObj.PTR
                .Cells(cPTS).Value = purchaseDetailObj.PTS
                .Cells(cPTD).Value = purchaseDetailObj.Rate3
                .Cells(cRate1).Value = purchaseDetailObj.Rate1
                .Cells(cRate2).Value = purchaseDetailObj.Rate2
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
                .Cells(cStorage).Value = GetTextForValue(CmbStorage, .Cells(cStorageId).Value)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

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

    Private Sub LoadComboBoxValuesForSupplier()
        Try
            CmbSupplier.Items.Clear()

            Dim suppliers() As ClsVendorMaster = GetAllVendorMaster(Me.Name)
            If suppliers Is Nothing Then Exit Try

            CmbSupplier.DisplayMember = cName
            CmbSupplier.ValueMember = cId
            Dim supplier As ClsVendorMaster
            For Each supplier In suppliers
                CmbSupplier.Items.Add(supplier)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadComboBoxValuesForItem()
        Try
            CmbItem.DataSource = Nothing
            CmbItem.Items.Clear()
            CmbItem.Text = ""
            If CmbCategory.Items.Count = 0 Then Exit Try
            Dim categoryId As Integer = GetSelectedItemId(CmbCategory)
            If categoryId <= 0 Then Exit Try

            Dim items() As ClsItemMaster = GetAllItemMasterForCategoryId(Me.Name, categoryId, False)

            CmbItem.DataSource = items
            CmbItem.DisplayMember = cName
            CmbItem.ValueMember = cId
            CmbItem.Text = ""

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadComboBoxValuesForCategory()
        Try
            CmbCategory.Items.Clear()

            Dim categories() As ClsCategoryMaster = GetAllCategoryMaster(Me.Name)
            If categories Is Nothing Then Exit Try

            CmbCategory.DisplayMember = cName
            CmbCategory.ValueMember = cId
            Dim category As ClsCategoryMaster
            For Each category In categories
                CmbCategory.Items.Add(category)
            Next

            flagCategoryChange = EnLoading.LoadOnChange
            If CmbCategory.Items.Count > 0 Then CmbCategory.SelectedIndex = 0
            flagCategoryChange = EnLoading.None

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadComboBoxValuesForOrder()
        Try
            CmbAgainstOrder.Items.Clear()

            Dim purchaseOrders() As ClsPurchaseOrderMaster = GetAllPurchaseOrderMaster(Me.Name)
            If purchaseOrders Is Nothing Then Exit Try

            CmbAgainstOrder.DisplayMember = cId
            CmbAgainstOrder.ValueMember = cId
            Dim purchaseOrder As ClsPurchaseOrderMaster
            For Each purchaseOrder In purchaseOrders
                CmbAgainstOrder.Items.Add(purchaseOrder)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadComboBoxValuesForStorage()
        Try
            CmbStorage.Items.Clear()

            Dim storages() As ClsStorageMaster = GetAllStorageMaster(Me.Name)
            If storages Is Nothing Then Exit Try

            Dim storage As ClsStorageMaster
            For Each storage In storages
                AddItemToComboBox(storage.Name, storage.Id, CmbStorage)
            Next

            If CmbStorage.Items.Count > 0 Then CmbStorage.SelectedIndex = 0

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadComboBoxValuesForBatch()
        Try
            'CmbBatch.DataSource = Nothing
            'CmbBatch.Items.Clear()
            'CmbBatch.Text = ""

            Dim itemId As Integer = GetSelectedItemId(CmbItem)
            If itemId <= 0 Then Exit Try

            Dim currentStocks() As ClsCurrentStock = GetAllCurrentStockForItemId(Me.Name, itemId, True)
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

    Private Sub LoadComboBoxValues()
        Try
            With CmbStatus.Items
                .Clear()
                .Add(cStatusCash)
                .Add(cStatusCredit)
            End With

            CmbStatus.Text = cStatusCash

            LoadComboBoxValuesForTax()

            LoadComboBoxValuesForSupplier()
            LoadComboBoxValuesForOrder()
            LoadComboBoxValuesForStorage()

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

    Private Function GetVendor(ByVal id As Integer) As ClsVendorMaster
        Dim result As ClsVendorMaster = Nothing
        Try
            Dim vendor As ClsVendorMaster
            For Each vendor In CmbSupplier.Items
                If vendor.Id = id Then
                    result = vendor
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

            If CmbStatus.Text.Trim = "" Then
                ErrorInData("Please select status.", CmbStatus)
                Exit Try
            End If

            If CmbSupplier.Text.Trim = "" Then
                ErrorInData("Please select supplier.", CmbSupplier)
                Exit Try
            End If

            If CmbSupplier.FindStringExact(CmbSupplier.Text.Trim) < 0 Then
                ErrorInData("Please select valid supplier from supplier list.", CmbSupplier)
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

            If TxtPackQty.Text.Trim = "" Then
                ErrorInData("Please enter pack quantity.", TxtPackQty)
                Exit Try
            End If

            If Val(TxtPackQty.Text) <= 0 Then
                ErrorInData("Please enter pack quantity greater then 0.", TxtPackQty)
                Exit Try
            End If

            If TxtPurchaseQuantity.Text.Trim = "" Then
                ErrorInData("Please enter purchase quantity.", TxtPurchaseQuantity)
                Exit Try
            End If

            If Val(TxtPurchaseQuantity.Text) <= 0 Then
                ErrorInData("Please enter purchase quantity greater then 0.", TxtPurchaseQuantity)
                Exit Try
            End If

            If TxtPurchasePrice.Text.Trim = "" Then
                ErrorInData("Please enter purchase price.", TxtPurchasePrice)
                Exit Try
            End If

            'If Val(TxtPurchasePrice.Text) <= 0 Then
            '    ErrorInData("Please enter purchase price greater then 0.", TxtPurchasePrice)
            '    Exit Try
            'End If

            If GetSaleOn() = cPTS Then
                If TxtPTS.Text.Trim = "" Then
                    ErrorInData("Please enter PTS.", TxtPTS)
                    Exit Try
                End If

                'If Val(TxtPTS.Text) <= 0 Then
                '    ErrorInData("Please enter PTS greater then 0.", TxtPTS)
                '    Exit Try
                'End If
            End If

            If GetSaleOn() = cMRP Then
                If TxtMRP.Text.Trim = "" Then
                    ErrorInData("Please enter MRP.", TxtMRP)
                    Exit Try
                End If

                'If Val(TxtMRP.Text) <= 0 Then
                '    ErrorInData("Please enter MRP greater then 0.", TxtMRP)
                '    Exit Try
                'End If
            End If

            If GetSaleOn() = cPTR Then
                If TxtPTR.Text.Trim = "" Then
                    ErrorInData("Please enter PTR.", TxtPTR)
                    Exit Try
                End If

                'If Val(TxtPTR.Text) <= 0 Then
                '    ErrorInData("Please enter PTR greater then 0.", TxtPTR)
                '    Exit Try
                'End If
            End If

            If GetSaleOn() = cPTD Then
                If TxtRate3.Text.Trim = "" Then
                    ErrorInData("Please enter PTD.", TxtRate3)
                    Exit Try
                End If

                'If Val(TxtRate1.Text) <= 0 Then
                '    ErrorInData("Please enter Rate1 greater then 0.", TxtRate1)
                '    Exit Try
                'End If
            End If

            If GetSaleOn() = cRate1 Then
                If TxtRate1.Text.Trim = "" Then
                    ErrorInData("Please enter Rate1.", TxtRate1)
                    Exit Try
                End If

                'If Val(TxtRate2.Text) <= 0 Then
                '    ErrorInData("Please enter Rate2 greater then 0.", TxtRate2)
                '    Exit Try
                'End If
            End If

            If GetSaleOn() = cRate2 Then
                If TxtRate2.Text.Trim = "" Then
                    ErrorInData("Please enter Rate2.", TxtRate2)
                    Exit Try
                End If

                'If Val(TxtRate3.Text) <= 0 Then
                '    ErrorInData("Please enter Rate3 greater then 0.", TxtRate3)
                '    Exit Try
                'End If
            End If

            result = True

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Sub ResetControlsToAddNewItem()
        editRow = Nothing

        CmbItem.Text = ""
        'CmbBatch.Text = ""
        If CmbStorage.Items.Count > 0 Then CmbStorage.SelectedIndex = 0
        TxtExpiryDate.Text = ""
        TxtPackQty.Text = ""
        TxtPurchaseQuantity.Text = ""
        TxtPurchasePrice.Text = ""
        TxtMRP.Text = ""
        TxtPTR.Text = ""
        TxtPTS.Text = ""
        TxtRate1.Text = ""
        TxtRate2.Text = ""
        TxtRate3.Text = ""
        TxtManufactureDate.Text = ""
        TxtFreeQuantity.Text = ""
        TxtDiscountPercent.Text = ""
        flagBatchChange = EnLoading.None

        'CmbBatch.Enabled = True
        BtnAdd.Text = "&Add"
        BtnNew.Text = "&New"
        BtnAdd.Enabled = True
        BtnRemove.Enabled = False
        flagItemChanged = False

        CmbCategory.Focus()
    End Sub

    Private Sub ResetControlsToAddNew()
        lFlagTaxNot = EnLoading.None
        TxtPurchaseCode.Text = ""
        DtPkrPurchaseDate.Value = Now
        CmbStatus.Text = cStatusCash
        CmbSupplier.Text = ""
        TxtTINNo.Text = ""
        TxtVoucher.Text = ""
        CmbAgainstOrder.Text = ""
        TxtDiscountOnBill.Text = ""
        TxtBillRoundOff.Text = ""
        TxtBillNetAmount.Text = ""
        TxtOverAllDiscount.Text = ""
        CmbTax.Text = cVAT
        TxtDiscount.Text = ""
        TxtCreditAdj.Text = ""
        TxtDebitAdj.Text = ""
        TxtPreExciseAmount.Text = ""
        TxtGrossAmount.Text = ""
        TxtFreightCharge.Text = ""
        TxtRemark.Text = ""

        GrdItems.Rows.Clear()

        ResetControlsToAddNewItem()

        lPurchaseObj = Nothing
        flagSupplierChanged = False
        flagOldObject = False

        DtPkrPurchaseDate.Focus()
    End Sub

    Private Sub SetPurchaseIdForCurrentLogin()
        Try
            lPurchaseObj = Nothing
            Dim purchaseMaster As ClsPurchaseMaster = GetPurchaseMasterNotClosedForLogin(Me.Name, gUser.LoginName)
            If purchaseMaster Is Nothing Then Exit Try

            lPurchaseObj = purchaseMaster
            With purchaseMaster
                TxtPurchaseCode.Text = .PurchaseCode
                DtPkrPurchaseDate.Value = .PurchaseDate
                CmbStatus.Text = .Mode
                TxtVoucher.Text = .VoucherNo
                TxtRemark.Text = .Remark
                TxtDiscountOnBill.Text = Format(.DiscountAmount, "0.00")
                TxtCreditAdj.Text = .CreditAdjust
                TxtDebitAdj.Text = .DebitAdjust
                TxtPreExciseAmount.Text = .PreExciseAmount
                CmbTax.Text = GetTaxName(.TaxId)

                If .OrderId > 0 Then CmbAgainstOrder.Text = .OrderId

                Dim vendor As ClsVendorMaster = GetVendor(.VendorId)
                If Not (vendor Is Nothing) Then
                    CmbSupplier.Text = vendor.Name
                    TxtTINNo.Text = vendor.TinNo
                End If

                flagOldObject = False
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub SetPurchaseForPurchaseId(ByVal id As Integer)
        Try
            lPurchaseObj = Nothing
            If id <= 0 Then Exit Try

            Dim purchaseMaster As ClsPurchaseMaster = GetPurchaseMaster(Me.Name, id)
            If purchaseMaster Is Nothing Then Exit Try

            lPurchaseObj = purchaseMaster
            With purchaseMaster
                lFlagTaxNot = EnLoading.LoadOnLostFocus
                TxtPurchaseCode.Text = .PurchaseCode
                DtPkrPurchaseDate.Value = .PurchaseDate
                CmbStatus.Text = .Mode
                TxtVoucher.Text = .VoucherNo
                TxtRemark.Text = .Remark
                TxtDiscountOnBill.Text = Format(.DiscountAmount, "0.00")
                TxtCreditAdj.Text = .CreditAdjust
                TxtDebitAdj.Text = .DebitAdjust
                TxtPreExciseAmount.Text = .PreExciseAmount
                TxtFreightCharge.Text = .FreightCharge
                CmbTax.Text = GetTaxName(.TaxId)

                If .OrderId > 0 Then CmbAgainstOrder.Text = .OrderId

                Dim vendor As ClsVendorMaster = GetVendor(.VendorId)
                If Not (vendor Is Nothing) Then
                    CmbSupplier.Text = vendor.Name
                    TxtTINNo.Text = vendor.TinNo
                End If

                flagOldObject = True
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        lFlagTaxNot = EnLoading.LoadOnChange
        LoadGridValuesForPurchaseDetail()
        CalculateTotals()
    End Sub

    Private Sub UpdatePurchaseDetailObject()
        Try
            If editRow Is Nothing Or lPurchaseObj Is Nothing Then Exit Try

            If flagOldObject = False Then
                If AndedTheString(gUser.AuthorizationNo, Authorization.Purchase_Current_NoUpdate) = True Then Exit Sub
            Else
                If AndedTheString(gUser.AuthorizationNo, Authorization.Purchase_Old_NoUpdate) = True Then Exit Sub
            End If

            If ValidateValues() = False Then Exit Sub

            'Updating Detail

            Dim purchaseDetailObj As New ClsPurchaseDetail
            With purchaseDetailObj
                .Id = editRow.Cells(cId).Value
                .PurchaseId = lPurchaseObj.Id
                Dim item As ClsItemMaster = GetSelectedItem(CmbItem)
                .ItemId = item.Id  'GetSelectedItemId(CmbItem)
                .ManufacturerId = item.ManufacturerId
                .Batch = cBatchDefault 'CmbBatch.Text
                .ExpiryDate = DateDefault 'GetExpiryDate()
                .ManufactureDate = DateDefault 'GetManufactureDate()
                .PricePurchase = Val(TxtPurchasePrice.Text) / Val(TxtPackQty.Text)
                'Dim x1 As Double = Val(TxtMRP.Text) / Val(TxtPackQty.Text)
                .MRP = Val(TxtMRP.Text) / Val(TxtPackQty.Text)

                .PTR = Val(TxtPTR.Text) / Val(TxtPackQty.Text)
                .PTS = Val(TxtPTS.Text) / Val(TxtPackQty.Text)
                .Rate1 = Val(TxtRate1.Text) / Val(TxtPackQty.Text)
                .Rate2 = Val(TxtRate2.Text) / Val(TxtPackQty.Text)
                .Rate3 = Val(TxtRate3.Text) / Val(TxtPackQty.Text)
                .TaxPercent = 0
                .DiscountPercent = Val(TxtDiscountPercent.Text)
                .PurchaseQuantity = Val(TxtPurchaseQuantity.Text) * Val(TxtPackQty.Text)
                .FreeQuantity = Val(TxtFreeQuantity.Text)
                .PackQuantity = Val(TxtPackQty.Text)
                .StorageId = GetSelectedItemId(CmbStorage)
                .Remark = TxtRemark.Text
                .UserId = gUser.LoginName
                .DateOn = Now
                .TaxAmount = 0
                .DiscountAmount = 0
            End With

            If UpdatePurchaseDetail(Me.Name, purchaseDetailObj) <> EnResult.Change Then Exit Sub

            With editRow
                .Cells(cPurchaseId).Value = purchaseDetailObj.PurchaseId
                .Cells(cItemId).Value = purchaseDetailObj.ItemId
                .Cells(cName).Value = CmbItem.Text
                .Cells(cBatch).Value = purchaseDetailObj.Batch
                .Cells(cExpiryDate).Value = purchaseDetailObj.ExpiryDate
                .Cells(cManufactureDate).Value = purchaseDetailObj.ManufactureDate
                .Cells(cMRP).Value = purchaseDetailObj.MRP
                .Cells(cPTR).Value = purchaseDetailObj.PTR
                .Cells(cPricePurchase).Value = purchaseDetailObj.PricePurchase
                .Cells(cPTS).Value = purchaseDetailObj.PTS
                .Cells(cPTD).Value = purchaseDetailObj.Rate3
                .Cells(cRate1).Value = purchaseDetailObj.Rate1
                .Cells(cRate2).Value = purchaseDetailObj.Rate2
                .Cells(cPurchaseQuantity).Value = purchaseDetailObj.PurchaseQuantity
                .Cells(cFreeQuantity).Value = purchaseDetailObj.FreeQuantity
                .Cells(cStorageId).Value = purchaseDetailObj.StorageId
                .Cells(cUserId).Value = purchaseDetailObj.UserId
                .Cells(cDateOn).Value = purchaseDetailObj.DateOn
                .Cells(cTaxAmount).Value = purchaseDetailObj.TaxAmount
                .Cells(cDiscountAmount).Value = purchaseDetailObj.DiscountAmount
                .Cells(cPackQuantity).Value = purchaseDetailObj.PackQuantity
                .Cells(cTaxPercent).Value = purchaseDetailObj.TaxPercent
                .Cells(cDiscountPercent).Value = purchaseDetailObj.DiscountPercent
                .Cells(cStorage).Value = CmbStorage.Text
            End With

            CalculateTotals()
            lPurchaseObj.NotClosed = True
            MsgBox("Successfully Updated", , "Updated")

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNewItem()
    End Sub

    'Private Sub CalculateTotals()
    '    Try
    '        TxtTotalAmount.Text = "0"
    '        TxtRoundOff.Text = "0"
    '        TxtNetAmount.Text = "0"

    '        If GrdItems.Rows.Count = 0 Then Exit Try

    '        Dim totalAmount As Double = 0
    '        Dim taxTotal As Double = 0
    '        Dim discountTotal As Double = 0
    '        Dim roundOff As Double = 0
    '        Dim netAmount As Double = 0

    '        Dim row As DataGridViewRow
    '        For Each row In GrdItems.Rows
    '            With row
    '                taxTotal = taxTotal + Val(.Cells(cTaxAmount).Value)
    '                discountTotal = discountTotal + Val(.Cells(cDiscountAmount).Value)
    '                totalAmount = totalAmount + (Val(.Cells(cPricePurchase).Value) * Val(.Cells(cPurchaseQuantity).Value))
    '            End With
    '        Next

    '        TxtTotalAmount.Text = Format(totalAmount, "0.00")

    '        Dim temp As Double = totalAmount + taxTotal - discountTotal
    '        netAmount = GetSqlRound(Me.Name, temp)

    '        TxtRoundOff.Text = Format(netAmount - temp, "0.00")
    '        TxtNetAmount.Text = Format(netAmount, "0.00")

    '    Catch ex As Exception
    '        AddToLog(ex)
    '    End Try
    'End Sub

    Private Sub CalculateTotals()
        Try
            TxtGrossAmount.Text = ""
            TxtDiscount.Text = ""

            'If GrdSale.Rows.Count = 0 Then Exit Try

            Dim totalAmount As Double = 0
            Dim taxTotal As Double = 0
            Dim discountTotal As Double = 0

            Dim row As DataGridViewRow
            For Each row In GrdItems.Rows
                With row
                    taxTotal = taxTotal + Val(.Cells(cTaxAmount).Value)
                    Dim total As Double = (Val(.Cells(cPricePurchase).Value) * Val(.Cells(cPurchaseQuantity).Value))
                    Dim discount As Double = total * Val(.Cells(cDiscountPercent).Value) / 100
                    discountTotal = discountTotal + discount
                    totalAmount = totalAmount + total '- discount
                End With
            Next

            TxtDiscount.Text = Format(discountTotal, "0.00")
            TxtGrossAmount.Text = Format(totalAmount, "0.00")

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Function GetExpiryDate() As Date
        Dim result As Date = Nothing
        Try
            RemoveErrorIcon()

            Dim sep As String = System.Globalization.DateTimeFormatInfo.CurrentInfo.DateSeparator

            Dim str() As String = TxtExpiryDate.Text.Split(sep)
            If Val(str(0)) <= 0 Or Val(str(0)) > 12 Then
                ErrorInData("Please enter expiry date properly.", TxtExpiryDate)
                Exit Try
            End If

            If Val(str(1)) < Now.Year Then
                ErrorInData("Please enter expiry date properly.", TxtExpiryDate)
                TxtExpiryDate.Focus()
                Exit Try
            End If

            result = New Date(Val(str(1)), Val(str(0)), 1)

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Function GetManufactureDate() As Date
        Dim result As Date = Nothing
        Try
            RemoveErrorIcon()

            Dim sep As String = System.Globalization.DateTimeFormatInfo.CurrentInfo.DateSeparator

            Dim str() As String = TxtManufactureDate.Text.Split(sep)
            If Val(str(0)) <= 0 Or Val(str(0)) > 12 Then
                ErrorInData("Please enter Manufacture date properly.", TxtManufactureDate)
                Exit Try
            End If

            If Val(str(1)) < Now.Year Then
                ErrorInData("Please enter Manufacture date properly.", TxtManufactureDate)
                TxtManufactureDate.Focus()
                Exit Try
            End If

            result = New Date(Val(str(1)), Val(str(0)), 1)

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

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

    Private Sub FillExistingValuesForSelectedItemAndBatch()
        Try
            TxtExpiryDate.Text = ""
            TxtPackQty.Text = ""
            TxtPurchasePrice.Text = ""
            TxtPTS.Text = ""
            TxtMRP.Text = ""
            TxtPTR.Text = ""
            TxtRate1.Text = ""
            TxtRate2.Text = ""
            TxtRate3.Text = ""

            Dim currentStock As ClsCurrentStock = lCurrentBatch 'GetSelectedItem(CmbBatch)
            If currentStock Is Nothing Then Exit Try

            With currentStock
                TxtExpiryDate.Text = Format(.ExpiryDate, "MMyyyy")
                TxtManufactureDate.Text = Format(.ManufactureDate, "MMyyyy")
                TxtPurchasePrice.Text = .PricePurchase
                TxtPTS.Text = .PTS
                TxtMRP.Text = .MRP
                TxtPTR.Text = .PTR
                TxtRate1.Text = .Rate2 ' For Lable Rate 1 Price
                TxtRate2.Text = .Rate1 ' For Lable Rate 2 Price
                TxtRate3.Text = .Rate3 ' For Lable PTD Price
                TxtPackQty.Text = .PackQuantity
            End With

            TxtPurchaseQuantity.Focus()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub SetTaxIdAndTax(ByRef taxId As Integer, ByRef tax As Double)
        If lFlagTaxNot <> EnLoading.None Then
            If lPurchaseObj Is Nothing Then
                taxId = cInvalidId
                tax = 0
            Else
                taxId = lPurchaseObj.TaxId
                tax = lPurchaseObj.TaxPercent
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

            TxtTaxableAmount.Text = Format(grossAmt - discountAmt, "0.00")
            'TxtTaxableAmount.Text = Format(grossAmt, "0.00")

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

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
            Dim taxAmt As Double = taxableAmt * tax / 100

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
            Dim freightCharge As Double = Val(TxtFreightCharge.Text)

            Dim totalWithoutROF As Double = grossAmt + tax - discount - creditAdj + debitAdj + freightCharge
            Dim netAmount As Double = GetSqlRound(Me.Name, totalWithoutROF)

            TxtBillRoundOff.Text = Format(netAmount - totalWithoutROF, "0.00")
            TxtBillNetAmount.Text = Format(netAmount, "0.00")

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

#End Region

    Private Sub GrpItem_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GrpItem.Enter

    End Sub
End Class