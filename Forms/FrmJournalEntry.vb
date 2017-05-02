Imports AIMS.Author

Public Class FrmJournalEntry

#Region "Local variables and Constants"

    Dim editRow As DataGridViewRow = Nothing
    Dim flagLedgerChanged As Boolean = False
    Dim flagNewJournal As Boolean = False

    Private Const lcUpdate As String = "&Update"
    Private Const lcCancel As String = "Cance&l"

    Enum Index
        GrpJournal
        TxtJournalNo
        DtPkrJournalDate
        GrpLedger
        CmbLedger
        CmbBill
        TxtInvoiceAmount
        TxtAmount
        CmbDrCr
        TxtRemark
        BtnAdd
        BtnRemove
        GrdLedgers
        GrpJournals
        CmbJournals
        BtnNew
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

    Private Sub FrmJournalEntry_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Balanced() = False Then
            MsgBox("Journal is not Balanced.", , "Not Balanced")
            e.Cancel = True
        End If
    End Sub

    Private Sub FrmJournalEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

    Private Sub CmbLedger_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbLedger.KeyPress
        'AutoComplete(sender, e)
        flagLedgerChanged = True
    End Sub

    Private Sub CmbLedger_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbLedger.LostFocus
        If flagLedgerChanged = False Then Exit Sub

        flagLedgerChanged = False
        LoadComboBoxValuesForBillNo()
    End Sub

    Private Sub CmbLedger_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbLedger.SelectedIndexChanged
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
            If BtnAdd.Text = lcUpdate Then
                UpdateJournalObject()
                Exit Sub
            End If

            If AndedTheString(gUser.AuthorizationNo, Authorization.JournalEntry_NoAdd) = True Then Exit Sub
            If ValidateValues() = False Then Exit Sub

            Dim journalEntry As New ClsJournalEntry
            With journalEntry
                .DateOn = Now
                .HeadId = GetSelectedItemId(CmbLedger)
                .InvoiceNo = CmbBill.Text
                .Journaldate = DtPkrJournalDate.Value
                .JournalNo = TxtJournalNo.Text
                .Remark = TxtRemark.Text
                .UserId = gUser.LoginName
                If CmbDrCr.Text = cCr Then
                    .CrAmount = Val(TxtAmount.Text)
                Else
                    .DrAmount = Val(TxtAmount.Text)
                End If

                If MsgBox("This record will add to " + .JournalNo + vbCrLf + "Want to continue?", MsgBoxStyle.YesNo, "New Journal") = MsgBoxResult.No Then
                    Exit Sub
                End If
            End With

            Dim id As Long = InsertIntoJournalEntry(Me.Name, journalEntry)
            If id <= 0 Then Exit Try

            journalEntry.Id = id
            InsertIntoGrid(journalEntry)
            MsgBox("Added Sucessfully.")
            If flagNewJournal = True Then
                LoadComboBoxValuesForJournals()
                flagNewJournal = False
            End If

            CalculateGridValues()

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNewItem()
    End Sub

    Private Sub BtnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemove.Click
        Try
            If BtnRemove.Text = lcCancel Then
                BtnRemove.Enabled = False
                ResetControlsToAddNewItem()
                Exit Try
            End If

            If AndedTheString(gUser.AuthorizationNo, Authorization.JournalEntry_NoRemove) = True Then Exit Sub

            If MsgBox("Deleted record can't be recovered. Do you want to delete this record?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.No Then Exit Sub

            Dim row As DataGridViewRow = GrdLedgers.SelectedRows(0)
            If row Is Nothing Then Exit Try

            Dim id As Long = row.Cells(cId).Value
            If DeleteJournalEntry(Me.Name, id) <> EnResult.Change Then Exit Sub

            GrdLedgers.Rows.Remove(row)
            CalculateGridValues()
            MsgBox("Record deleted successfully")

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub GrdLedgers_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdLedgers.CellClick
        Try
            If e.RowIndex < 0 Then Exit Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.JournalEntry_NoRemove) = True Then Exit Sub

            ResetControlsToAddNewItem()
            BtnAdd.Enabled = False
            BtnRemove.Enabled = True

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub GrdLedgers_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdLedgers.CellDoubleClick
        Try
            If e.RowIndex < 0 Then Exit Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.JournalEntry_NoUpdate) = True Then Exit Sub

            editRow = GrdLedgers.Rows(e.RowIndex)
            With editRow
                CmbLedger.Text = GetItemNameForHeadId(.Cells(cHeadId).Value)
                LoadComboBoxValuesForBillNo()
                CmbBill.Text = .Cells(cInvoiceNo).Value
                TxtRemark.Text = .Cells(cRemark).Value
                If .Cells(cDrAmount).Value > 0 Then
                    TxtAmount.Text = .Cells(cDrAmount).Value
                    CmbDrCr.Text = cDr
                Else
                    TxtAmount.Text = .Cells(cCrAmount).Value
                    CmbDrCr.Text = cCr
                End If
            End With

            BtnAdd.Text = lcUpdate
            BtnRemove.Text = lcCancel
            BtnAdd.Enabled = True
            BtnRemove.Enabled = True
            CmbJournals.Enabled = False

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub GrdLedgers_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdLedgers.KeyDown
        If e.KeyCode = Keys.Tab Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub CmbJournals_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbJournals.KeyPress
        'AutoComplete(sender, e)
    End Sub

    Private Sub CmbJournals_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbJournals.SelectedIndexChanged
        Try
            If Balanced() = False Then
                MsgBox("Journal is not Balanced.", , "Not Balanced")
                Exit Try
            End If

            TxtJournalNo.Text = ""
            If CmbJournals.Text.Trim = "" Then Exit Try

            TxtJournalNo.Text = CmbJournals.Text.Trim
            LoadGridValuesForSelectedJournal()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        If Balanced() = False Then
            MsgBox("Journal is not Balanced.", , "Not Balanced")
            Exit Sub
        End If

        ResetControlsToAddNew()
    End Sub

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtRemark.KeyDown, TxtJournalNo.KeyDown, TxtInvoiceAmount.KeyDown, TxtAmount.KeyDown, DtPkrJournalDate.KeyDown, CmbLedger.KeyDown, CmbJournals.KeyDown, CmbDrCr.KeyDown, CmbBill.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

#End Region

#Region "Private Function"

    Private Sub SetControls()
        SetTabIndex()
        SetGrid()
        LoadComboBoxValues()
        ResetControlsToAddNew()
    End Sub

    Private Sub SetTabIndex()
        GrpJournal.TabIndex = Index.GrpJournal
        DtPkrJournalDate.TabIndex = Index.DtPkrJournalDate
        TxtJournalNo.TabIndex = Index.TxtJournalNo
        GrpLedger.TabIndex = Index.GrpLedger
        GrdLedgers.TabIndex = Index.GrdLedgers
        BtnRemove.TabIndex = Index.BtnRemove
        BtnAdd.TabIndex = Index.BtnAdd
        TxtRemark.TabIndex = Index.TxtRemark
        CmbDrCr.TabIndex = Index.CmbDrCr
        TxtAmount.TabIndex = Index.TxtAmount
        TxtInvoiceAmount.TabIndex = Index.TxtInvoiceAmount
        CmbBill.TabIndex = Index.CmbBill
        CmbLedger.TabIndex = Index.CmbLedger
        GrpJournals.TabIndex = Index.GrpJournals
        CmbJournals.TabIndex = Index.CmbJournals
        BtnClose.TabIndex = Index.BtnClose
        BtnNew.TabIndex = Index.BtnNew
    End Sub

    Private Sub SetGrid()
        With GrdLedgers
            Dim colCount As Integer = 10
            .RowHeadersVisible = False
            Dim defaultCellWidth As Integer = 90
            Dim x As Integer
            For x = 0 To colCount
                Select Case x
                    Case 0
                        Dim index As Integer = .Columns.Add(cId, cId)
                        .Columns(index).Visible = False

                    Case 1
                        Dim index As Integer = .Columns.Add(cJournalNo, cJournalNo)
                        .Columns(index).Visible = False

                    Case 2
                        Dim index As Integer = .Columns.Add(cName, "Ledger Name")
                        .Columns(index).Width = 190

                    Case 3
                        Dim index As Integer = .Columns.Add(cJournaldate, cJournaldate)
                        .Columns(index).Visible = False

                    Case 4
                        Dim index As Integer = .Columns.Add(cHeadId, cHeadId)
                        .Columns(index).Visible = False

                    Case 5
                        Dim index As Integer = .Columns.Add(cUserId, cUserId)
                        .Columns(index).Visible = False

                    Case 6
                        Dim index As Integer = .Columns.Add(cDrAmount, "Dr. Amount")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 7
                        Dim index As Integer = .Columns.Add(cCrAmount, "Cr. Amount")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 8
                        Dim index As Integer = .Columns.Add(cInvoiceNo, "Invoice No")
                        .Columns(index).Width = defaultCellWidth

                    Case 9
                        Dim index As Integer = .Columns.Add(cRemark, cRemark)
                        .Columns(index).Width = 250

                    Case 10
                        Dim index As Integer = .Columns.Add(cDateOn, cDateOn)
                        .Columns(index).Visible = False

                End Select
            Next
        End With
    End Sub

    Private Sub LoadGridValuesForSelectedJournal()
        Try
            GrdLedgers.Rows.Clear()

            If TxtJournalNo.Text.Trim = "" Then Exit Try

            Dim journalEntrys() As ClsJournalEntry = GetAllJournalEntryForJournal(Me.Name, TxtJournalNo.Text)
            If journalEntrys Is Nothing Then Exit Try

            Dim journalEntry As ClsJournalEntry
            For Each journalEntry In journalEntrys
                InsertIntoGrid(journalEntry)
            Next

            CalculateGridValues()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub InsertIntoGrid(ByRef journalEntryObj As ClsJournalEntry)
        Try
            If journalEntryObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdLedgers.Rows.Add
            With GrdLedgers.Rows(rowIndex)
                .Cells(cId).Value = journalEntryObj.Id
                .Cells(cJournalNo).Value = journalEntryObj.JournalNo
                .Cells(cJournaldate).Value = journalEntryObj.Journaldate
                .Cells(cHeadId).Value = journalEntryObj.HeadId
                .Cells(cUserId).Value = journalEntryObj.UserId
                .Cells(cDrAmount).Value = journalEntryObj.DrAmount
                .Cells(cCrAmount).Value = journalEntryObj.CrAmount
                .Cells(cInvoiceNo).Value = journalEntryObj.InvoiceNo
                .Cells(cRemark).Value = journalEntryObj.Remark
                .Cells(cDateOn).Value = journalEntryObj.DateOn
                .Cells(cName).Value = GetHeadName(.Cells(cHeadId).Value)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadComboBoxValuesForJournals()
        Try
            CmbJournals.Items.Clear()

            Dim journals() As String = GetAllJournalEntryWithDistinctJournalNo(Me.Name)
            If journals Is Nothing Then Exit Try

            Dim journal As String
            For Each journal In journals
                CmbJournals.Items.Add(journal)
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
            With CmbDrCr.Items
                .Clear()

                .Add(cCr)
                .Add(cDr)
            End With
            CmbDrCr.Text = cCr

            LoadComboBoxValuesForJournals()
            LoadComboBoxValuesForLedger()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

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

            If TxtJournalNo.Text.Trim = "" Then
                ErrorInData("Select or create new journal.", TxtJournalNo)
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

            result = True

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Sub ResetControlsToAddNewItem()
        editRow = Nothing

        CmbLedger.Text = ""
        CmbBill.Items.Clear()
        TxtInvoiceAmount.Text = "0"
        TxtAmount.Text = "0"
        CmbDrCr.Text = cCr
        TxtRemark.Text = ""

        flagLedgerChanged = False
        BtnAdd.Text = "&Add"
        BtnRemove.Text = "&Remove"
        BtnAdd.Enabled = True
        BtnRemove.Enabled = False
        CmbJournals.Enabled = True

        CmbLedger.Focus()
    End Sub

    Private Sub ResetControlsToAddNew()
        TxtJournalNo.Text = GetNewJournalNo()
        DtPkrJournalDate.Value = Now.Date
        DtPkrJournalDate.MaxDate = Now.Date
        CmbJournals.Text = ""
        LblCredit.Text = "0.00"
        LblDebit.Text = "0.00"
        GrdLedgers.Rows.Clear()
        flagNewJournal = True

        ResetControlsToAddNewItem()
    End Sub

    Private Sub UpdateJournalObject()
        Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.JournalEntry_NoUpdate) = True Then Exit Sub
            If editRow Is Nothing Then Exit Try
            If ValidateValues() = False Then Exit Sub

            Dim journalEntryObj As New ClsJournalEntry
            With journalEntryObj
                .Id = editRow.Cells(cId).Value
                .DateOn = Now
                .HeadId = GetSelectedItemId(CmbLedger)
                .InvoiceNo = CmbBill.Text
                .Journaldate = DtPkrJournalDate.Value
                .JournalNo = TxtJournalNo.Text
                .Remark = TxtRemark.Text
                .UserId = gUser.LoginName
                If CmbDrCr.Text = cCr Then
                    .CrAmount = Val(TxtAmount.Text)
                Else
                    .DrAmount = Val(TxtAmount.Text)
                End If
            End With

            If UpdateJournalEntry(Me.Name, journalEntryObj) <> EnResult.Change Then Exit Sub

            With editRow
                .Cells(cJournalNo).Value = journalEntryObj.JournalNo
                .Cells(cJournaldate).Value = journalEntryObj.Journaldate
                .Cells(cHeadId).Value = journalEntryObj.HeadId
                .Cells(cUserId).Value = journalEntryObj.UserId
                .Cells(cDrAmount).Value = journalEntryObj.DrAmount
                .Cells(cCrAmount).Value = journalEntryObj.CrAmount
                .Cells(cInvoiceNo).Value = journalEntryObj.InvoiceNo
                .Cells(cRemark).Value = journalEntryObj.Remark
                .Cells(cDateOn).Value = journalEntryObj.DateOn
                .Cells(cName).Value = GetHeadName(.Cells(cHeadId).Value)
            End With

            MsgBox("Updated Sucessfully.")
            CalculateGridValues()

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNewItem()
    End Sub

    Private Sub CalculateGridValues()
        Try
            LblCredit.Text = "0"
            LblDebit.Text = "0"

            Dim credit As Double = 0
            Dim debit As Double = 0
            Dim row As DataGridViewRow
            For Each row In GrdLedgers.Rows
                With row
                    debit = debit + Val(.Cells(cDrAmount).Value)
                    credit = credit + Val(.Cells(cCrAmount).Value)
                End With
            Next

            LblCredit.Text = Format(credit, "0.00")
            LblDebit.Text = Format(debit, "0.00")

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Function Balanced() As Boolean
        Dim result As Boolean = False

        result = (Val(LblCredit.Text) = Val(LblDebit.Text))

        Return result
    End Function

#End Region

End Class