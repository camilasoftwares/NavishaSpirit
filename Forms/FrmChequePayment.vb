Imports AIMS.Author

Public Class FrmChequePayment

#Region "Local variables and Constants"

    Dim editRow As DataGridViewRow = Nothing
    Dim flagLedgerChanged As Boolean = False

    Private Const lcVoucherNo As String = "Voucher No"

    Enum Index
        GrpCashHead
        TxtVoucherNo
        CmbBankHead
        DtPkrPaymentDate
        GrpPaymentDetails
        CmbLedger
        CmbBill
        TxtInvoiceAmount
        TxtAmount
        TxtChequeNo
        DtPkrChequeDate
        TxtRemark
        BtnAdd
        GrdPayments
        GrpButtons
        BtnUpdate
        BtnCancel
        BtnRemove
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

    Private Sub FrmChequePayment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

    Private Sub CmbCashHead_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbBankHead.KeyPress
        'AutoComplete(sender, e)
    End Sub

    Private Sub CmbLedger_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbLedger.KeyPress
        'AutoComplete(sender, e)
        flagLedgerChanged = True
    End Sub

    Private Sub CmbLedger_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbLedger.LostFocus
        If flagLedgerChanged = False Then Exit Sub

        flagLedgerChanged = False
        LoadComboBoxValuesForBillNo()
    End Sub

    Private Sub CmbLedger_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbLedger.SelectedIndexChanged
        flagLedgerChanged = True
    End Sub

    Private Sub CmbBill_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbBill.SelectedIndexChanged
        Try
            If CmbBill.Text = "" Then
                TxtInvoiceAmount.Text = "0"
                Exit Try
            End If

            Dim amount As Double = GetTransactionAccountBalanceForVoucherNo(Me.Name, CmbBill.Text)
            TxtInvoiceAmount.Text = Format(amount, "0.00")

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub TxtAmount_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAmount.KeyPress
        e.Handled = Check_DecimalAllow(e.KeyChar, sender.text)
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.ChequePayment_NoAdd) = True Then Exit Sub
            If ValidateValues() = False Then Exit Sub

            Dim chequePayment As New ClsChequePayment
            With chequePayment
                .Amount = Val(TxtAmount.Text)
                .BillNo = CmbBill.Text
                .DateOn = Now
                .FromHeadId = GetSelectedItemId(CmbBankHead)
                .PaymentDate = DtPkrPaymentDate.Value
                .Remark = TxtRemark.Text
                .ToHeadId = GetSelectedItemId(CmbLedger)
                .ChequeNo = TxtChequeNo.Text
                .ChequeDate = DtPkrChequeDate.Value
                .UserId = gUser.LoginName
            End With

            Dim id As Long = InsertIntoChequePayment(Me.Name, chequePayment)
            If id <= 0 Then Exit Try

            chequePayment.Id = id
            InsertIntoGrid(chequePayment)
            MsgBox("Successfully Added")

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNewItem()
    End Sub

    Private Sub GrdPayments_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdPayments.CellClick
        Try
            If e.RowIndex < 0 Then Exit Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.ChequePayment_NoRemove) = True Then Exit Sub

            BtnRemove.Enabled = True
            BtnCancel.Enabled = True
            BtnAdd.Enabled = False
            BtnUpdate.Enabled = False

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub GrdPayments_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdPayments.CellDoubleClick
        Try
            If e.RowIndex < 0 Then Exit Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.ChequePayment_NoUpdate) = True Then Exit Sub

            editRow = GrdPayments.Rows(e.RowIndex)
            With editRow
                TxtVoucherNo.Text = .Cells(lcVoucherNo).Value
                CmbBankHead.Text = GetBankHeadItemName(.Cells(cFromHeadId).Value)
                DtPkrPaymentDate.Value = .Cells(cPaymentDate).Value
                TxtInvoiceAmount.Text = "0"
                CmbLedger.Text = GetItemNameForHeadId(.Cells(cToHeadId).Value)
                CmbBill.Text = .Cells(cBillNo).Value
                TxtAmount.Text = .Cells(cAmount).Value
                TxtRemark.Text = .Cells(cRemark).Value
                TxtChequeNo.Text = .Cells(cChequeNo).Value
                DtPkrChequeDate.Value = .Cells(cChequeDate).Value
            End With

            BtnRemove.Enabled = False
            BtnCancel.Enabled = True
            BtnAdd.Enabled = False
            BtnUpdate.Enabled = True

            CmbBankHead.Focus()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub GrdPayments_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdPayments.KeyDown
        If e.KeyCode = Keys.Tab Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub BtnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemove.Click
        Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.ChequePayment_NoRemove) = True Then Exit Sub

            If MsgBox("Deleted record can't be recovered. Do you want to delete this record?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.No Then Exit Sub

            Dim row As DataGridViewRow = GrdPayments.SelectedRows(0)
            If row Is Nothing Then Exit Try

            Dim id As Long = row.Cells(cId).Value
            If DeleteChequePayment(Me.Name, id) <> EnResult.Change Then Exit Sub

            GrdPayments.Rows.Remove(row)

            MsgBox("Record deleted successfully")
            ResetControlsToAddNewItem()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        ResetControlsToAddNewItem()
    End Sub

    Private Sub BtnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUpdate.Click
        Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.ChequePayment_NoUpdate) = True Then Exit Sub
            If editRow Is Nothing Then Exit Try
            If ValidateValues() = False Then Exit Sub

            Dim chequePaymentObj As New ClsChequePayment
            With chequePaymentObj
                .Id = editRow.Cells(cId).Value
                .Amount = Val(TxtAmount.Text)
                .BillNo = CmbBill.Text
                .DateOn = Now
                .FromHeadId = GetSelectedItemId(CmbBankHead)
                .PaymentDate = DtPkrPaymentDate.Value
                .Remark = TxtRemark.Text
                .ChequeNo = TxtChequeNo.Text
                .ChequeDate = DtPkrChequeDate.Value
                .ToHeadId = GetSelectedItemId(CmbLedger)
                .UserId = gUser.LoginName
            End With

            If UpdateChequePayment(Me.Name, chequePaymentObj) <> EnResult.Change Then Exit Sub

            With editRow
                .Cells(cPaymentDate).Value = chequePaymentObj.PaymentDate
                .Cells(cToHeadId).Value = chequePaymentObj.ToHeadId
                .Cells(cUserId).Value = chequePaymentObj.UserId
                .Cells(cFromHeadId).Value = chequePaymentObj.FromHeadId
                .Cells(cAmount).Value = chequePaymentObj.Amount
                .Cells(cBillNo).Value = chequePaymentObj.BillNo
                .Cells(cRemark).Value = chequePaymentObj.Remark
                .Cells(cChequeDate).Value = chequePaymentObj.ChequeDate
                .Cells(cChequeNo).Value = chequePaymentObj.ChequeNo
                .Cells(cDateOn).Value = chequePaymentObj.DateOn
                .Cells(cName).Value = GetHeadName(.Cells(cToHeadId).Value)
            End With

            ResetControlsToAddNewItem()
            MsgBox("Successfully Updated")

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtVoucherNo.KeyDown, TxtRemark.KeyDown, TxtInvoiceAmount.KeyDown, TxtChequeNo.KeyDown, TxtAmount.KeyDown, DtPkrPaymentDate.KeyDown, DtPkrChequeDate.KeyDown, CmbLedger.KeyDown, CmbBill.KeyDown, CmbBankHead.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch.Click
        Try
            Dim frm As New ClsSearchChequePaymentForm
            If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Dim id As Long = frm.GetSelectedId
                If id > 0 Then
                    RemoveRowWithId(id)
                    Dim chequePayment As ClsChequePayment = GetChequePayment(Me.Name, id)
                    InsertIntoGrid(chequePayment)
                End If
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Try
            Dim row As DataGridViewRow = GrdPayments.SelectedRows(0)
            If row Is Nothing Then
                MsgBox("Please select row to print slip.", , "Slip")
                Exit Try
            End If

            Dim id As Long = row.Cells(cId).Value
            If id <= 0 Then
                MsgBox("No record present or Selection is not proper. Please select row to print slip.", , "Slip")
                Exit Try
            End If

            Dim ds As DataSet = GetChequePaymentDataset(Me.Name, id)

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
            Dim rpt As New RptChequePayment
            rpt.SetDataSource(ds.Tables(0))
            Dim dlg As New DiagReport
            dlg.RptViewer.ReportSource = rpt
            dlg.ShowDialog(Me)

        Catch ex As Exception
            AddToLog(ex)
        End Try

        SetDefaultCursor()
    End Sub

#End Region

#Region "Private Function"

    Private Sub SetControls()
        SetTabIndex()
        SetGrid()
        LoadComboBoxValues()
        ResetControlsToAddNewItem()
    End Sub

    Private Sub SetTabIndex()
        GrpPaymentDetails.TabIndex = Index.GrpPaymentDetails
        GrdPayments.TabIndex = Index.GrdPayments
        BtnAdd.TabIndex = Index.BtnAdd
        TxtRemark.TabIndex = Index.TxtRemark
        TxtAmount.TabIndex = Index.TxtAmount
        TxtInvoiceAmount.TabIndex = Index.TxtInvoiceAmount
        CmbBill.TabIndex = Index.CmbBill
        CmbLedger.TabIndex = Index.CmbLedger
        GrpCashHead.TabIndex = Index.GrpCashHead
        TxtVoucherNo.TabIndex = Index.TxtVoucherNo
        CmbBankHead.TabIndex = Index.CmbBankHead
        DtPkrPaymentDate.TabIndex = Index.DtPkrPaymentDate
        GrpButtons.TabIndex = Index.GrpButtons
        BtnCancel.TabIndex = Index.BtnCancel
        BtnUpdate.TabIndex = Index.BtnUpdate
        BtnClose.TabIndex = Index.BtnClose
        BtnRemove.TabIndex = Index.BtnRemove
        TxtChequeNo.TabIndex = Index.TxtChequeNo
        DtPkrChequeDate.TabIndex = Index.DtPkrChequeDate
        BtnSearch.TabIndex = Index.BtnSearch
        BtnPrint.TabIndex = Index.BtnPrint
    End Sub

    Private Sub SetGrid()
        With GrdPayments
            Dim colCount As Integer = 12
            .RowHeadersVisible = False
            Dim defaultCellWidth As Integer = 85
            Dim x As Integer
            For x = 0 To colCount
                Select Case x
                    Case 0
                        Dim index As Integer = .Columns.Add(cId, cId)
                        .Columns(index).Visible = False

                    Case 1
                        Dim index As Integer = .Columns.Add(lcVoucherNo, lcVoucherNo)
                        .Columns(index).Visible = True
                        .Columns(index).Width = defaultCellWidth + 5

                    Case 2
                        Dim index As Integer = .Columns.Add(cName, "Ledger Name")
                        .Columns(index).Width = 160

                    Case 3
                        Dim index As Integer = .Columns.Add(cPaymentDate, cPaymentDate)
                        .Columns(index).Visible = False

                    Case 4
                        Dim index As Integer = .Columns.Add(cToHeadId, cToHeadId)
                        .Columns(index).Visible = False

                    Case 5
                        Dim index As Integer = .Columns.Add(cUserId, cUserId)
                        .Columns(index).Visible = False

                    Case 6
                        Dim index As Integer = .Columns.Add(cFromHeadId, cFromHeadId)
                        .Columns(index).Visible = False

                    Case 7
                        Dim index As Integer = .Columns.Add(cAmount, cAmount)
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 8
                        Dim index As Integer = .Columns.Add(cChequeNo, "Cheque No")
                        .Columns(index).Width = defaultCellWidth

                    Case 9
                        Dim index As Integer = .Columns.Add(cChequeDate, "Chq. Date")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "dd/MM/yyyy"

                    Case 10
                        Dim index As Integer = .Columns.Add(cBillNo, "Bill No")
                        .Columns(index).Width = defaultCellWidth

                    Case 11
                        Dim index As Integer = .Columns.Add(cDateOn, cDateOn)
                        .Columns(index).Visible = False

                    Case 12
                        Dim index As Integer = .Columns.Add(cRemark, cRemark)
                        .Columns(index).Width = 170

                End Select
            Next
        End With
    End Sub

    Private Sub InsertIntoGrid(ByRef chequePaymentObj As ClsChequePayment)
        Try
            If chequePaymentObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdPayments.Rows.Add
            With GrdPayments.Rows(rowIndex)
                .Cells(cId).Value = chequePaymentObj.Id
                .Cells(lcVoucherNo).Value = cCHP + CStr(.Cells(cId).Value)
                .Cells(cPaymentDate).Value = chequePaymentObj.PaymentDate
                .Cells(cToHeadId).Value = chequePaymentObj.ToHeadId
                .Cells(cUserId).Value = chequePaymentObj.UserId
                .Cells(cFromHeadId).Value = chequePaymentObj.FromHeadId
                .Cells(cAmount).Value = chequePaymentObj.Amount
                .Cells(cBillNo).Value = chequePaymentObj.BillNo
                .Cells(cRemark).Value = chequePaymentObj.Remark
                .Cells(cDateOn).Value = chequePaymentObj.DateOn
                .Cells(cChequeDate).Value = chequePaymentObj.ChequeDate
                .Cells(cChequeNo).Value = chequePaymentObj.ChequeNo
                .Cells(cName).Value = GetHeadName(.Cells(cToHeadId).Value)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub RemoveRowWithId(ByVal id As Long)
        Try
            For Each row As DataGridViewRow In GrdPayments.Rows
                If row.Cells(cId).Value = id Then
                    GrdPayments.Rows.Remove(row)
                    Exit Try
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadComboBoxValuesForLedger()
        Try
            CmbLedger.Items.Clear()

            Dim accountHeads() As ClsAccountHead = GetAllAccountHead(Me.Name)
            If accountHeads Is Nothing Then Exit Try

            CmbLedger.DisplayMember = cItemName
            CmbLedger.ValueMember = cId
            Dim accountHead As ClsAccountHead
            For Each accountHead In accountHeads
                CmbLedger.Items.Add(accountHead)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadComboBoxValuesForBillNo()
        Try
            CmbBill.Items.Clear()

            Dim accountHeadObj As ClsAccountHead = GetSelectedItem(CmbLedger)
            If accountHeadObj Is Nothing Then Exit Try

            Dim code As String = accountHeadObj.HeadCode
            If code.Substring(0, 2) = "CU" Then
                Dim sales() As ClsSalesMaster = GetAllSalesMasterForCustomerCode(Me.Name, code)
                If sales Is Nothing Then Exit Try

                CmbBill.DisplayMember = cSaleCode
                CmbBill.ValueMember = cId
                Dim sale As ClsSalesMaster
                For Each sale In sales
                    CmbBill.Items.Add(sale)
                Next

            ElseIf code.Substring(0, 2) = "VN" Then
                Dim purchases() As ClsPurchaseMaster = GetAllPurchaseMasterForVendorCode(Me.Name, code)
                If purchases Is Nothing Then Exit Try

                CmbBill.DisplayMember = cPurchaseCode
                CmbBill.ValueMember = cId
                Dim purchase As ClsPurchaseMaster
                For Each purchase In purchases
                    CmbBill.Items.Add(purchase)
                Next

            Else
                Exit Try
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadComboBoxValues()
        Try
            LoadComboBoxValuesForBankHead()
            LoadComboBoxValuesForLedger()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadComboBoxValuesForBankHead()
        Try
            CmbBankHead.Items.Clear()

            Dim accountHeads() As ClsAccountHead = GetAllAccountHeadForBankAccount(Me.Name)
            If accountHeads Is Nothing Then Exit Try

            CmbBankHead.DisplayMember = cItemName
            CmbBankHead.ValueMember = cId
            Dim accountHead As ClsAccountHead
            For Each accountHead In accountHeads
                CmbBankHead.Items.Add(accountHead)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Function GetBankHeadItemName(ByVal id As Integer) As String
        Dim result As String = ""
        Try
            Dim head As ClsAccountHead
            For Each head In CmbBankHead.Items
                If head.Id = id Then
                    result = head.ItemName
                    Exit Try
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Function GetHeadName(ByVal id As Integer) As String
        Dim result As String = ""
        Try
            Dim head As ClsAccountHead
            For Each head In CmbLedger.Items
                If head.Id = id Then
                    result = head.Name
                    Exit Try
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Function GetItemNameForHeadId(ByVal headId As Integer) As String
        Dim result As String = ""
        Try
            Dim head As ClsAccountHead
            For Each head In CmbLedger.Items
                If head.Id = headId Then
                    result = head.ItemName
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

            If CmbBankHead.Text.Trim = "" Then
                ErrorInData("Please select Bank Head.", CmbBankHead)
                Exit Try
            End If

            If CmbBankHead.FindStringExact(CmbBankHead.Text.Trim) < 0 Then
                ErrorInData("Please select valid Bank Head from Bank Head list.", CmbBankHead)
                Exit Try
            End If

            If CmbLedger.Text.Trim = "" Then
                ErrorInData("Please select Ledger.", CmbLedger)
                Exit Try
            End If

            If CmbLedger.FindStringExact(CmbLedger.Text.Trim) < 0 Then
                ErrorInData("Please select valid Ledger from Ledger list.", CmbLedger)
                Exit Try
            End If

            If TxtAmount.Text.Trim = "" Then
                ErrorInData("Please enter amount.", TxtAmount)
                Exit Try
            End If

            If Val(TxtAmount.Text) <= 0 Then
                ErrorInData("Please enter amount. It should be greater then 0.", TxtAmount)
                Exit Try
            End If

            If TxtChequeNo.Text.Trim = "" Then
                ErrorInData("Please enter cheque no.", TxtChequeNo)
                Exit Try
            End If

            result = True

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Sub ResetControlsToAddNewItem()
        editRow = Nothing

        TxtVoucherNo.Text = ""
        DtPkrPaymentDate.Value = Now.Date
        DtPkrChequeDate.Value = Now.Date
        TxtChequeNo.Text = ""
        CmbLedger.Text = ""
        CmbBill.Items.Clear()
        TxtInvoiceAmount.Text = ""
        TxtAmount.Text = ""
        TxtRemark.Text = ""

        BtnAdd.Enabled = True
        BtnUpdate.Enabled = False
        BtnCancel.Enabled = False
        BtnRemove.Enabled = False
        flagLedgerChanged = False

        CmbLedger.Focus()
    End Sub

#End Region

End Class