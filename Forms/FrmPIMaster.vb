Imports System.Windows.Forms

Public Class FrmPIMaster

#Region "Local variables and Constants"

    Dim editRow As DataGridViewRow = Nothing

    Enum Index
        GrpPI = 0
        TxtSNo
        TxtPI
        GrpButton
        BtnAdd
        BtnUpdate
        BtnCancel
        BtnClose
        GrpPIDetails
        GrdPIDetails
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

    Private Sub FrmPIMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Try
            If ValidateValues() = False Then Exit Sub

            Dim pi As New ClsPIMaster
            With pi
                .Name = TxtPI.Text
                .UserId = gUser.LoginName
                .DateOn = Now
            End With

            Dim id As Integer = InsertIntoPIMaster(Me.Name, pi)
            If id > 0 Then
                pi.Id = id
                InsertIntoGrid(pi)
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

            Dim pi As New ClsPIMaster
            With pi
                .Id = editRow.Cells(cId).Value
                .Name = TxtPI.Text
                .UserId = editRow.Cells(cUserId).Value
                .DateOn = editRow.Cells(cDateOn).Value
            End With

            If UpdatePIMaster(Me.Name, pi) <> EnResult.Change Then Exit Sub

            With editRow
                .Cells(cName).Value = TxtPI.Text
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

    Private Sub GrdPIDetails_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdPIDetails.CellDoubleClick
        Try
            If e.RowIndex < 0 Then Exit Try

            editRow = GrdPIDetails.Rows(e.RowIndex)
            With editRow
                TxtSNo.Text = .Cells(cId).Value
                TxtPI.Text = .Cells(cName).Value
            End With

            BtnAdd.Enabled = False
            BtnUpdate.Enabled = True
            BtnCancel.Enabled = True

            TxtPI.Focus()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub GrdPIDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdPIDetails.KeyDown
        If e.KeyCode = Keys.Tab Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSNo.KeyDown, TxtPI.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

#End Region

#Region "Private Functions"

    Private Sub SetControls()
        SetTabIndex()
        SetGrid()
        LoadGridValues()

        ResetControlsToAddNew()
    End Sub

    Private Sub SetTabIndex()
        GrpPI.TabIndex = Index.GrpPI
        TxtSNo.TabIndex = Index.TxtSNo
        TxtPI.TabIndex = Index.TxtPI
        GrpButton.TabIndex = Index.GrpButton
        BtnAdd.TabIndex = Index.BtnAdd
        BtnUpdate.TabIndex = Index.BtnUpdate
        BtnCancel.TabIndex = Index.BtnCancel
        BtnClose.TabIndex = Index.BtnClose
        GrpPIDetails.TabIndex = Index.GrpPIDetails
        GrdPIDetails.TabIndex = Index.GrdPIDetails
    End Sub

    Private Sub SetGrid()
        With GrdPIDetails
            Dim colCount As Integer = 3
            .RowHeadersVisible = False
            Dim x As Integer
            For x = 0 To colCount
                Select Case x
                    Case 0
                        Dim index As Integer = .Columns.Add(cId, "S. No.")
                        .Columns(index).Width = 80

                    Case 1
                        Dim index As Integer = .Columns.Add(cName, "PI")
                        .Columns(index).Width = 300

                    Case 2
                        Dim index As Integer = .Columns.Add(cUserId, cUserId)
                        .Columns(index).Visible = False

                    Case 3
                        Dim index As Integer = .Columns.Add(cDateOn, cDateOn)
                        .Columns(index).Visible = False

                End Select
            Next
        End With
    End Sub

    Private Sub LoadGridValues()
        Try
            GrdPIDetails.Rows.Clear()
            Dim pis() As ClsPIMaster = GetAllPIMaster(Me.Name)
            If pis Is Nothing Then Exit Try

            Dim pi As ClsPIMaster
            For Each pi In pis
                InsertIntoGrid(pi)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub InsertIntoGrid(ByRef piObj As ClsPIMaster)
        Try
            If piObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdPIDetails.Rows.Add
            With GrdPIDetails.Rows(rowIndex)
                .Cells(cId).Value = piObj.Id
                .Cells(cName).Value = piObj.Name
                .Cells(cUserId).Value = piObj.UserId
                .Cells(cDateOn).Value = piObj.DateOn
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Function ValidateValues() As Boolean
        Dim result As Boolean = False
        Try
            RemoveErrorIcon()

            If TxtPI.Text.Trim = "" Then
                ErrorInData("Please enter pi.", TxtPI)
                Exit Try
            End If

            result = True

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Sub ResetControlsToAddNew()
        TxtPI.Text = ""
        TxtSNo.Text = ""
        BtnAdd.Enabled = True
        BtnUpdate.Enabled = False
        BtnCancel.Enabled = False

        editRow = Nothing

        TxtPI.Focus()
    End Sub

#End Region

End Class
