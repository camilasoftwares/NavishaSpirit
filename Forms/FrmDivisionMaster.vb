Imports System.Windows.Forms
Imports AIMS.Author

Public Class FrmDivisionMaster

#Region "Local variables and Constants"

    Dim editRow As DataGridViewRow = Nothing
    Dim flagChange As Boolean = False

    Enum Index
        GrpDivision = 0
        TxtDivision
        GrpButton
        BtnAdd
        BtnUpdate
        BtnCancel
        BtnClose
        GrpDivisionDetails
        GrdDivisionDetails
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

    Private Sub FrmDivisionMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.Division_NoAdd) = True Then Exit Sub
            If ValidateValues() = False Then Exit Sub

            If NameExistInGrid(TxtDivision.Text) = True Then
                ErrorInData("Division name already present.", TxtDivision)
                Exit Sub
            End If

            Dim division As New ClsDivisionMaster
            With division
                .Name = TxtDivision.Text
                .UserId = gUser.LoginName
                .DateOn = Now
            End With

            Dim id As Integer = InsertIntoDivisionMaster(Me.Name, division)
            If id > 0 Then
                flagChange = True
                division.Id = id
                InsertIntoGrid(division)
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNew()
    End Sub

    Private Sub BtnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUpdate.Click
        Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.Division_NoUpdate) = True Then Exit Sub
            If editRow Is Nothing Then Exit Try
            If ValidateValues() = False Then Exit Sub

            Dim division As New ClsDivisionMaster
            With division
                .Id = editRow.Cells(cId).Value
                .Name = TxtDivision.Text
                .UserId = editRow.Cells(cUserId).Value
                .DateOn = editRow.Cells(cDateOn).Value
            End With

            If DivisionMasterUpdatable(Me.Name, division) = False Then
                ErrorInData("Division name already present with other id.", TxtDivision)
                Exit Sub
            End If

            If UpdateDivisionMaster(Me.Name, division) <> EnResult.Change Then Exit Sub

            With editRow
                flagChange = True
                .Cells(cName).Value = TxtDivision.Text
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

    Private Sub GrdDivisionDetails_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdDivisionDetails.CellDoubleClick
        Try
            If e.RowIndex < 0 Then Exit Try

            If AndedTheString(gUser.AuthorizationNo, Authorization.Division_NoUpdate) = True Then Exit Sub

            editRow = GrdDivisionDetails.Rows(e.RowIndex)
            With editRow
                TxtDivision.Text = .Cells(cName).Value
            End With

            BtnAdd.Enabled = False
            BtnUpdate.Enabled = True
            BtnCancel.Enabled = True

            TxtDivision.Focus()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub GrdDivisionDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdDivisionDetails.KeyDown
        If e.KeyCode = Keys.Tab Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDivision.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

#End Region

#Region "Public Functions"

    Public Function Change() As Boolean
        Return flagChange
    End Function

#End Region

#Region "Private Functions"

    Private Sub SetControls()
        SetTabIndex()
        SetGrid()
        LoadGridValues()

        ResetControlsToAddNew()
    End Sub

    Private Sub SetTabIndex()
        GrpDivision.TabIndex = Index.GrpDivision
        TxtDivision.TabIndex = Index.TxtDivision
        GrpButton.TabIndex = Index.GrpButton
        BtnAdd.TabIndex = Index.BtnAdd
        BtnUpdate.TabIndex = Index.BtnUpdate
        BtnCancel.TabIndex = Index.BtnCancel
        BtnClose.TabIndex = Index.BtnClose
        GrpDivisionDetails.TabIndex = Index.GrpDivisionDetails
        GrdDivisionDetails.TabIndex = Index.GrdDivisionDetails
    End Sub

    Private Sub SetGrid()
        With GrdDivisionDetails
            Dim colCount As Integer = 3
            .RowHeadersVisible = False
            Dim x As Integer
            For x = 0 To colCount
                Select Case x
                    Case 0
                        Dim index As Integer = .Columns.Add(cId, "S. No.")
                        .Columns(index).Visible = False

                    Case 1
                        Dim index As Integer = .Columns.Add(cName, "Division")
                        .Columns(index).Width = 280

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
            GrdDivisionDetails.Rows.Clear()
            Dim divisions() As ClsDivisionMaster = GetAllDivisionMaster(Me.Name)
            If divisions Is Nothing Then Exit Try

            Dim division As ClsDivisionMaster
            For Each division In divisions
                InsertIntoGrid(division)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub InsertIntoGrid(ByRef divisionObj As ClsDivisionMaster)
        Try
            If divisionObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdDivisionDetails.Rows.Add
            With GrdDivisionDetails.Rows(rowIndex)
                .Cells(cId).Value = divisionObj.Id
                .Cells(cName).Value = divisionObj.Name
                .Cells(cUserId).Value = divisionObj.UserId
                .Cells(cDateOn).Value = divisionObj.DateOn
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Function ValidateValues() As Boolean
        Dim result As Boolean = False
        Try
            RemoveErrorIcon()

            If TxtDivision.Text.Trim = "" Then
                ErrorInData("Please enter division.", TxtDivision)
                Exit Try
            End If

            result = True

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Sub ResetControlsToAddNew()
        TxtDivision.Text = ""
        BtnAdd.Enabled = True
        BtnUpdate.Enabled = False
        BtnCancel.Enabled = False
        RemoveErrorIcon()

        editRow = Nothing

        TxtDivision.Focus()
    End Sub

    Private Function NameExistInGrid(ByVal name As String) As Boolean
        Dim result As Boolean = False
        Try
            name = name.Trim
            If GrdDivisionDetails.RowCount = 0 Then Exit Try

            If name = "" Then Exit Try

            Dim row As DataGridViewRow
            For Each row In GrdDivisionDetails.Rows
                If row.Cells(cName).Value = name Then
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
