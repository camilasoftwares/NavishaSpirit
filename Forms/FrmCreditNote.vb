Imports System.Windows.Forms
Imports AIMS.Author

Public Class FrmCreditNote

#Region "Private Variables"

    Dim lCreditNote As ClsCreditNote = Nothing
    Dim flagOldObject As Boolean = False

#End Region

#Region "Control Functions"

    Private Sub FrmCreditNote_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        ResetControlsToAddNew()
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Try
            If lCreditNote Is Nothing Then
                MsgBox("There is no Credit Note selected. Please create or select Credit Note.", , "Credit Note")
                Exit Try
            End If

            If lCreditNote.Id <= 0 Then
                MsgBox("There is no Credit Note selected. Please create or select Credit Note.", , "Credit Note")
                Exit Try
            End If

            Dim creditNoteId As Long = lCreditNote.Id
            Dim ds As DataSet = GetCreditNoteForReport(Me.Name, creditNoteId)

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
            Dim rpt As New RptCreditNote
            rpt.SetDataSource(ds.Tables(0))
            Dim dlg As New DiagReport
            dlg.RptViewer.ReportSource = rpt
            dlg.ShowDialog(Me)

        Catch ex As Exception
            AddToLog(ex)
        End Try

        SetDefaultCursor()
    End Sub

    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch.Click
        Try
            Dim frm As New ClsSearchCreditNoteForm
            If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Dim id As Long = frm.GetSelectedId
                If id > 0 Then
                    Dim creditObj As ClsCreditNote = GetCreditNote(Me.Name, id)
                    SetCreditNoteObj(creditObj)
                End If
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            If ValidateValues() = False Then Exit Try

            If lCreditNote Is Nothing Then
                If flagOldObject = False Then
                    If AndedTheString(gUser.AuthorizationNo, Authorization.CreditNote_Current_NoAdd) = True Then Exit Sub
                Else
                    If AndedTheString(gUser.AuthorizationNo, Authorization.CreditNote_Old_NoAdd) = True Then Exit Sub
                End If

                'New note
                Dim creditNote As New ClsCreditNote
                With creditNote
                    .Amount = Val(TxtAmount.Text)
                    .AgainstCode = GetSelectedAgainstCode()
                    .CustomerCode = GetSelectedCustomerCode()
                    .DateOn = Now
                    .NoteDate = DtPkrNoteDate.Value
                    .Remark = TxtRemark.Text
                    .Narration = TxtNarration.Text
                    .UserId = gUser.LoginName
                End With

                Dim id As Long = InsertIntoCreditNote(Me.Name, creditNote)
                If id <= 0 Then Exit Try

                lCreditNote = GetCreditNote(Me.Name, id)
                With lCreditNote
                    TxtCreditCode.Text = .Code
                End With

            Else
                If flagOldObject = False Then
                    If AndedTheString(gUser.AuthorizationNo, Authorization.CreditNote_Current_NoUpdate) = True Then Exit Sub
                Else
                    If AndedTheString(gUser.AuthorizationNo, Authorization.CreditNote_Old_NoUpdate) = True Then Exit Sub
                End If

                'Old note
                Dim creditNote As New ClsCreditNote
                With creditNote
                    .Id = lCreditNote.Id
                    .Code = lCreditNote.Code
                    .Amount = Val(TxtAmount.Text)
                    .AgainstCode = GetSelectedAgainstCode()
                    .CustomerCode = GetSelectedCustomerCode()
                    .DateOn = Now
                    .NoteDate = DtPkrNoteDate.Value
                    .Remark = TxtRemark.Text
                    .Narration = TxtNarration.Text
                    .UserId = gUser.LoginName
                End With

                If UpdateCreditNote(Me.Name, creditNote) <> EnResult.Change Then Exit Try

                lCreditNote = creditNote
            End If

            MsgBox("Successfully Saved.", , "Saved")

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Event_AllowDecimalOnKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAmount.KeyPress
        e.Handled = Check_DecimalAllow(e.KeyChar, sender.text)
    End Sub

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCreditCode.KeyDown, TxtAmount.KeyDown, DtPkrNoteDate.KeyDown, CmbCustomer.KeyDown, TxtRemark.KeyDown, CmbAgainstHead.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

#End Region

#Region "Private Controls"

    Private Sub SetControls()
        LoadComboBoxValuesForCustomers()
        LoadComboBoxValuesForAgainstHeads()

        ResetControlsToAddNew()
    End Sub

    Private Sub LoadComboBoxValuesForCustomers()
        Try
            CmbCustomer.DataSource = Nothing
            CmbCustomer.Items.Clear()
            CmbCustomer.Text = ""

            Dim customers() As ClsCustomerMaster = GetAllCustomerMaster(Me.Name)
            If customers Is Nothing Then Exit Try

            CmbCustomer.DataSource = customers
            CmbCustomer.DisplayMember = cName
            CmbCustomer.ValueMember = cId
            CmbCustomer.Text = ""

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadComboBoxValuesForAgainstHeads()
        Try
            CmbAgainstHead.DataSource = Nothing
            CmbAgainstHead.Items.Clear()
            CmbAgainstHead.Text = ""

            Dim againstHeads() As ClsAccountHead = GetAllAccountHead(Me.Name)
            If againstHeads Is Nothing Then Exit Try

            CmbAgainstHead.DataSource = againstHeads
            CmbAgainstHead.DisplayMember = cName
            CmbAgainstHead.ValueMember = cId
            CmbAgainstHead.Text = ""

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub ResetControlsToAddNew()
        TxtCreditCode.Text = ""
        CmbCustomer.Text = ""
        DtPkrNoteDate.Value = Now.Date
        TxtAmount.Text = ""
        CmbAgainstHead.Text = ""
        TxtRemark.Text = ""
        TxtNarration.Text = ""

        flagOldObject = False
        lCreditNote = Nothing

        CmbCustomer.Focus()
    End Sub

    Private Function GetSelectedCustomerCode() As String
        Dim result As String = ""
        Try
            result = CmbCustomer.SelectedItem.AccountId
        Catch ex As Exception
        End Try

        Return result
    End Function

    Private Function GetCustomerName(ByVal code As String) As String
        Dim result As String = ""
        Try
            code = code.Trim
            If code = "" Then Exit Try

            For Each customer As ClsCustomerMaster In CmbCustomer.Items
                If UCase(customer.AccountId) = UCase(code) Then
                    result = customer.Name
                    Exit Try
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Function GetHeadName(ByVal code As String) As String
        Dim result As String = ""
        Try
            code = code.Trim
            If code = "" Then Exit Try

            For Each accountHead As ClsAccountHead In CmbAgainstHead.Items
                If UCase(accountHead.HeadCode) = UCase(code) Then
                    result = accountHead.Name
                    Exit Try
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Function GetSelectedAgainstCode() As String
        Dim result As String = ""
        Try
            result = CmbAgainstHead.SelectedItem.HeadCode
        Catch ex As Exception
        End Try

        Return result
    End Function

    Private Sub SetCreditNoteObj(ByRef creditNoteObj As ClsCreditNote)
        Try
            TxtNarration.Text = ""
            TxtAmount.Text = ""
            TxtCreditCode.Text = ""
            DtPkrNoteDate.Value = Now.Date
            TxtRemark.Text = ""
            CmbAgainstHead.SelectedIndex = -1
            CmbCustomer.SelectedIndex = -1
            CmbAgainstHead.Text = ""
            CmbCustomer.Text = ""

            lCreditNote = creditNoteObj
            If lCreditNote Is Nothing Then Exit Try

            flagOldObject = True
            With lCreditNote
                TxtNarration.Text = .Narration
                TxtAmount.Text = .Amount
                TxtCreditCode.Text = .Code
                DtPkrNoteDate.Value = .NoteDate
                TxtRemark.Text = .Remark
                CmbAgainstHead.Text = GetHeadName(.AgainstCode)
                CmbCustomer.Text = GetCustomerName(.CustomerCode)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
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

            If TxtAmount.Text.Trim = "" Then
                ErrorInData("Please enter amount.", TxtAmount)
                Exit Try
            End If

            If Val(TxtAmount.Text) <= 0 Then
                ErrorInData("Please enter amount greater then 0.", TxtAmount)
                Exit Try
            End If

            If CmbAgainstHead.Text.Trim = "" Then
                ErrorInData("Please select Head to debit.", CmbAgainstHead)
                Exit Try
            End If

            If CmbAgainstHead.FindStringExact(CmbAgainstHead.Text.Trim) < 0 Then
                ErrorInData("Please select valid Head to debit from Head to debit list.", CmbAgainstHead)
                Exit Try
            End If

            result = True

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

#End Region

End Class
