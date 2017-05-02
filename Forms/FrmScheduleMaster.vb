Imports System.Windows.Forms
Imports AIMS.Author

Public Class FrmScheduleMaster

#Region "Local variables and Constants"

    Dim editRow As DataGridViewRow = Nothing
    Dim flagChange As Boolean = False

    Enum Index
        GrpSchedule = 0
        TxtSchedule
        TxtColor
        CmbPrompt
        GrpButton
        BtnAdd
        BtnUpdate
        BtnCancel
        BtnClose
        GrpScheduleDetails
        GrdScheduleDetails
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

    Private Sub FrmScheduleMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

    Private Sub TxtColor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtColor.Click
        DlgColor.Color = TxtColor.BackColor
        DlgColor.ShowDialog()
        TxtColor.BackColor = DlgColor.Color
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Try
            If ValidateValues() = False Then Exit Sub

            If ExistInGrid(TxtSchedule.Text.Trim, TxtColor.BackColor) = True Then
                ErrorInData("Name or Color already exist in list", TxtSchedule)
                Exit Sub
            End If

            Dim schedule As New ClsScheduleMaster
            With schedule
                .Name = TxtSchedule.Text
                .Prompt = CmbPrompt.Text
                .Color = TxtColor.BackColor.ToArgb.ToString
                .UserId = gUser.LoginName
                .DateOn = Now
            End With

            Dim id As Integer = InsertIntoScheduleMaster(Me.Name, schedule)
            If id > 0 Then
                flagChange = True
                schedule.Id = id
                InsertIntoGrid(schedule)
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNew()
    End Sub

    Private Sub BtnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUpdate.Click
        Try
            If editRow Is Nothing Then Exit Try
            If ValidateValues() = False Then Exit Sub

            Dim schedule As New ClsScheduleMaster
            With schedule
                .Id = editRow.Cells(cId).Value
                .Name = TxtSchedule.Text
                .Prompt = CmbPrompt.Text
                .Color = TxtColor.BackColor.ToArgb.ToString
                .UserId = editRow.Cells(cUserId).Value
                .DateOn = editRow.Cells(cDateOn).Value
            End With

            If ScheduleMasterUpdatable(Me.Name, schedule) = False Then
                ErrorInData("Name or Color already exist with other id", TxtSchedule)
                Exit Sub
            End If

            If UpdateScheduleMaster(Me.Name, schedule) <> EnResult.Change Then Exit Sub

            flagChange = True
            With editRow
                .Cells(cName).Value = TxtSchedule.Text
                .Cells(cPrompt).Value = CmbPrompt.Text
                .Cells(cColor).Style.BackColor = TxtColor.BackColor
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNew()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        ResetControlsToAddNew()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub GrdScheduleDetails_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdScheduleDetails.CellDoubleClick
        Try
            If e.RowIndex < 0 Then Exit Try
            'If AndedTheString(gUser.AuthorizationNo, Authorization.Schedule_NoUpdate) = True Then Exit Sub

            editRow = GrdScheduleDetails.Rows(e.RowIndex)
            With editRow
                TxtSchedule.Text = .Cells(cName).Value
                CmbPrompt.Text = .Cells(cPrompt).Value
                TxtColor.BackColor = .Cells(cColor).Style.BackColor
            End With

            BtnAdd.Enabled = False
            BtnUpdate.Enabled = True
            BtnCancel.Enabled = True

            TxtSchedule.Focus()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub GrdScheduleDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdScheduleDetails.KeyDown
        If e.KeyCode = Keys.Tab Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub GrdScheduleDetails_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdScheduleDetails.SelectionChanged
        GrdScheduleDetails.ClearSelection()
    End Sub

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSchedule.KeyDown, CmbPrompt.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub TxtColor_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtColor.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
        If e.KeyCode = Keys.Space Then TxtColor_Click(Me, New System.EventArgs())
    End Sub

#End Region

#Region "Public Functions"

    Public Function Change() As Boolean
        Return flagChange
    End Function

#End Region

#Region "Private Functions"

    Private Sub SetControls()
        With CmbPrompt
            .Items.Clear()
            .Items.Add(True)
            .Items.Add(False)

            .SelectedIndex = 0
        End With

        SetTabIndex()
        SetGrid()
        LoadGridValues()

        ResetControlsToAddNew()
    End Sub

    Private Sub SetTabIndex()
        GrpSchedule.TabIndex = Index.GrpSchedule
        TxtSchedule.TabIndex = Index.TxtSchedule
        TxtColor.TabIndex = Index.TxtColor
        CmbPrompt.TabIndex = Index.CmbPrompt
        GrpButton.TabIndex = Index.GrpButton
        BtnAdd.TabIndex = Index.BtnAdd
        BtnUpdate.TabIndex = Index.BtnUpdate
        BtnCancel.TabIndex = Index.BtnCancel
        BtnClose.TabIndex = Index.BtnClose
        GrpScheduleDetails.TabIndex = Index.GrpScheduleDetails
        GrdScheduleDetails.TabIndex = Index.GrdScheduleDetails
    End Sub

    Private Sub SetGrid()
        With GrdScheduleDetails
            Dim colCount As Integer = 5
            .RowHeadersVisible = False
            Dim x As Integer
            For x = 0 To colCount
                Select Case x
                    Case 0
                        Dim index As Integer = .Columns.Add(cId, "S. No.")
                        .Columns(index).Visible = False

                    Case 1
                        Dim index As Integer = .Columns.Add(cName, "Schedule")
                        .Columns(index).Width = 310

                    Case 2
                        Dim index As Integer = .Columns.Add(cUserId, cUserId)
                        .Columns(index).Visible = False

                    Case 3
                        Dim index As Integer = .Columns.Add(cDateOn, cDateOn)
                        .Columns(index).Visible = False

                    Case 4
                        Dim index As Integer = .Columns.Add(cColor, cColor)
                        .Columns(index).Width = 100

                    Case 5
                        Dim index As Integer = .Columns.Add(cPrompt, cPrompt)
                        .Columns(index).Width = 100

                End Select
            Next
        End With
    End Sub

    Private Sub LoadGridValues()
        Try
            GrdScheduleDetails.Rows.Clear()
            Dim schedules() As ClsScheduleMaster = GetAllScheduleMaster(Me.Name)
            If schedules Is Nothing Then Exit Try

            Dim schedule As ClsScheduleMaster
            For Each schedule In schedules
                InsertIntoGrid(schedule)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub InsertIntoGrid(ByRef scheduleObj As ClsScheduleMaster)
        Try
            If scheduleObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdScheduleDetails.Rows.Add
            With GrdScheduleDetails.Rows(rowIndex)
                .Cells(cId).Value = scheduleObj.Id
                .Cells(cName).Value = scheduleObj.Name
                .Cells(cPrompt).Value = scheduleObj.Prompt
                .Cells(cColor).Style.BackColor = (GetColorFromArgb(CInt(scheduleObj.Color)))
                .Cells(cUserId).Value = scheduleObj.UserId
                .Cells(cDateOn).Value = scheduleObj.DateOn
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Function ValidateValues() As Boolean
        Dim result As Boolean = False
        Try
            RemoveErrorIcon()

            If TxtSchedule.Text.Trim = "" Then
                ErrorInData("Please enter schedule.", TxtSchedule)
                Exit Try
            End If

            If TxtColor.BackColor = Control.DefaultBackColor Then
                ErrorInData("Please select color.", TxtColor)
                Exit Try
            End If

            result = True

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Sub ResetControlsToAddNew()
        TxtSchedule.Text = ""
        CmbPrompt.Text = False
        TxtColor.BackColor = Control.DefaultBackColor
        BtnAdd.Enabled = True
        BtnUpdate.Enabled = False
        BtnCancel.Enabled = False
        RemoveErrorIcon()

        editRow = Nothing

        TxtSchedule.Focus()
    End Sub

    Private Function GetColorFromArgb(ByVal argb As Integer) As Color
        Dim result As Color
        result = Color.FromArgb(argb)

        Return result
    End Function

    Private Function ExistInGrid(ByVal schedule As String, ByVal clr As Color) As Boolean
        Dim result As Boolean = False
        Try
            If GrdScheduleDetails.Rows.Count = 0 Then Exit Try

            Dim row As DataGridViewRow
            For Each row In GrdScheduleDetails.Rows
                If row.Cells(cName).Value = schedule Or row.Cells(cColor).Style.BackColor = clr Then
                    result = True
                    Exit Try
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

#End Region

End Class
