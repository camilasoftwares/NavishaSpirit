Imports System.Windows.Forms
Imports AIMS.Author

Public Class FrmDebitNote

#Region "Private Variables"

    Dim lDebitNote As ClsDebitNote = Nothing
    Dim flagOldObject As Boolean = False

#End Region

#Region "Control Functions"

    Private Sub FrmDebitNote_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        ResetControlsToAddNew()
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Try
            If lDebitNote Is Nothing Then
                MsgBox("There is no Debit Note selected. Please create or select Debit Note.", , "Debit Note")
                Exit Try
            End If

            If lDebitNote.Id <= 0 Then
                MsgBox("There is no Debit Note selected. Please create or select Debit Note.", , "Debit Note")
                Exit Try
            End If

            Dim debitNoteId As Long = lDebitNote.Id
            Dim ds As DataSet = GetDebitNoteForReport(Me.Name, debitNoteId)

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
            Dim rpt As New RptDebitNote
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
            Dim frm As New ClsSearchDebitNoteForm
            If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Dim id As Long = frm.GetSelectedId
                If id > 0 Then
                    Dim debitObj As ClsDebitNote = GetDebitNote(Me.Name, id)
                    SetDebitNoteObj(debitObj)
                End If
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            If ValidateValues() = False Then Exit Try

            If lDebitNote Is Nothing Then
                If flagOldObject = False Then
                    If AndedTheString(gUser.AuthorizationNo, Authorization.DebitNote_Current_NoAdd) = True Then Exit Sub
                Else
                    If AndedTheString(gUser.AuthorizationNo, Authorization.DebitNote_Old_NoAdd) = True Then Exit Sub
                End If

                'New note
                Dim debitNote As New ClsDebitNote
                With debitNote
                    .Amount = Val(TxtAmount.Text)
                    .AgainstCode = GetSelectedAgainstCode()
                    .VendorCode = GetSelectedVendorCode()
                    .DateOn = Now
                    .NoteDate = DtPkrNoteDate.Value
                    .Remark = TxtRemark.Text
                    .Narration = TxtNarration.Text
                    .UserId = gUser.LoginName
                End With

                Dim id As Long = InsertIntoDebitNote(Me.Name, debitNote)
                If id <= 0 Then Exit Try

                lDebitNote = GetDebitNote(Me.Name, id)
                With lDebitNote
                    TxtDebitCode.Text = .Code
                End With

            Else
                If flagOldObject = False Then
                    If AndedTheString(gUser.AuthorizationNo, Authorization.DebitNote_Current_NoUpdate) = True Then Exit Sub
                Else
                    If AndedTheString(gUser.AuthorizationNo, Authorization.DebitNote_Old_NoUpdate) = True Then Exit Sub
                End If

                'Old note
                Dim debitNote As New ClsDebitNote
                With debitNote
                    .Id = lDebitNote.Id
                    .Code = lDebitNote.Code
                    .Amount = Val(TxtAmount.Text)
                    .AgainstCode = GetSelectedAgainstCode()
                    .VendorCode = GetSelectedVendorCode()
                    .DateOn = Now
                    .NoteDate = DtPkrNoteDate.Value
                    .Remark = TxtRemark.Text
                    .Narration = TxtNarration.Text
                    .UserId = gUser.LoginName
                End With

                If UpdateDebitNote(Me.Name, debitNote) <> EnResult.Change Then Exit Try

                lDebitNote = debitNote
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

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDebitCode.KeyDown, TxtAmount.KeyDown, DtPkrNoteDate.KeyDown, CmbVendor.KeyDown, TxtRemark.KeyDown, CmbAgainstHead.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

#End Region

#Region "Private Controls"

    Private Sub SetControls()
        LoadComboBoxValuesForVendors()
        LoadComboBoxValuesForAgainstHeads()

        ResetControlsToAddNew()
    End Sub

    Private Sub LoadComboBoxValuesForVendors()
        Try
            CmbVendor.DataSource = Nothing
            CmbVendor.Items.Clear()
            CmbVendor.Text = ""

            Dim vendors() As ClsVendorMaster = GetAllVendorMaster(Me.Name)
            If vendors Is Nothing Then Exit Try

            CmbVendor.DataSource = vendors
            CmbVendor.DisplayMember = cName
            CmbVendor.ValueMember = cId
            CmbVendor.Text = ""

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
        TxtDebitCode.Text = ""
        CmbVendor.Text = ""
        DtPkrNoteDate.Value = Now.Date
        TxtAmount.Text = ""
        CmbAgainstHead.Text = ""
        TxtRemark.Text = ""
        TxtNarration.Text = ""

        flagOldObject = False
        lDebitNote = Nothing

        CmbVendor.Focus()
    End Sub

    Private Function GetSelectedVendorCode() As String
        Dim result As String = ""
        Try
            result = CmbVendor.SelectedItem.AccountId
        Catch ex As Exception
        End Try

        Return result
    End Function

    Private Function GetVendorName(ByVal code As String) As String
        Dim result As String = ""
        Try
            code = code.Trim
            If code = "" Then Exit Try

            For Each vendor As ClsVendorMaster In CmbVendor.Items
                If UCase(vendor.AccountId) = UCase(code) Then
                    result = vendor.Name
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

    Private Sub SetDebitNoteObj(ByRef debitNoteObj As ClsDebitNote)
        Try
            TxtNarration.Text = ""
            TxtAmount.Text = ""
            TxtDebitCode.Text = ""
            DtPkrNoteDate.Value = Now.Date
            TxtRemark.Text = ""
            CmbAgainstHead.SelectedIndex = -1
            CmbVendor.SelectedIndex = -1
            CmbAgainstHead.Text = ""
            CmbVendor.Text = ""

            lDebitNote = debitNoteObj
            If lDebitNote Is Nothing Then Exit Try
            flagOldObject = True

            With lDebitNote
                TxtNarration.Text = .Narration
                TxtAmount.Text = .Amount
                TxtDebitCode.Text = .Code
                DtPkrNoteDate.Value = .NoteDate
                TxtRemark.Text = .Remark
                CmbAgainstHead.Text = GetHeadName(.AgainstCode)
                CmbVendor.Text = GetVendorName(.VendorCode)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
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
