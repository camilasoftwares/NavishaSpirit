Imports System.Windows.Forms
Imports AIMS.Author

Public Class FrmSpecialityMaster

#Region "Local variables and Constants"

    Dim editRow As DataGridViewRow = Nothing
    Dim flagChange As Boolean = False

    Enum Index
        GrpSpeciality = 0
        TxtSNo
        TxtSpeciality
        GrpButton
        BtnAdd
        BtnUpdate
        BtnCancel
        BtnClose
        GrpSpecialityDetails
        GrdSpecialityDetails
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

    Private Sub FrmSpecialityMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

    Private Sub GrdSpecialityDetails_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdSpecialityDetails.CellDoubleClick
        Try
            If e.RowIndex < 0 Then Exit Try
            'If AndedTheString(gUser.AuthorizationNo, Authorization.Speciality_NoUpdate) = True Then Exit Sub

            editRow = GrdSpecialityDetails.Rows(e.RowIndex)
            With editRow
                TxtSNo.Text = .Cells(cId).Value
                TxtSpeciality.Text = .Cells(cName).Value
            End With

            BtnAdd.Enabled = False
            BtnUpdate.Enabled = True
            BtnCancel.Enabled = True

            TxtSpeciality.Focus()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub GrdSpecialityDetails_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdSpecialityDetails.KeyDown
        If e.KeyCode = Keys.Tab Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Try
            If ValidateValues() = False Then Exit Sub

            If Not (GetRowForFieldAndValue(GrdSpecialityDetails, cName, TxtSpeciality.Text.Trim) Is Nothing) Then
                ErrorInData("Name already exist in list", TxtSpeciality)
                Exit Sub
            End If

            Dim speciality As New ClsSpecialityMaster
            With speciality
                .Name = TxtSpeciality.Text
                .UserId = gUser.LoginName
                .DateOn = Now
            End With

            Dim id As Integer = InsertIntoSpecialityMaster(Me.Name, speciality)
            If id > 0 Then
                flagChange = True
                speciality.Id = id
                InsertIntoGrid(speciality)
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

            Dim speciality As New ClsSpecialityMaster
            With speciality
                .Id = editRow.Cells(cId).Value
                .Name = TxtSpeciality.Text
                .UserId = editRow.Cells(cUserId).Value
                .DateOn = editRow.Cells(cDateOn).Value
            End With

            If SpecialityMasterUpdatable(Me.Name, speciality) = False Then
                ErrorInData("This name is already exist with other id.", TxtSpeciality)
                Exit Sub
            End If

            If UpdateSpecialityMaster(Me.Name, speciality) <> EnResult.Change Then Exit Sub

            flagChange = True
            With editRow
                .Cells(cName).Value = TxtSpeciality.Text
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

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSpeciality.KeyDown, TxtSNo.KeyDown
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
        GrpSpeciality.TabIndex = Index.GrpSpeciality
        TxtSNo.TabIndex = Index.TxtSNo
        TxtSpeciality.TabIndex = Index.TxtSpeciality
        GrpButton.TabIndex = Index.GrpButton
        BtnAdd.TabIndex = Index.BtnAdd
        BtnUpdate.TabIndex = Index.BtnUpdate
        BtnCancel.TabIndex = Index.BtnCancel
        BtnClose.TabIndex = Index.BtnClose
        GrpSpecialityDetails.TabIndex = Index.GrpSpecialityDetails
        GrdSpecialityDetails.TabIndex = Index.GrdSpecialityDetails
    End Sub

    Private Sub SetGrid()
        With GrdSpecialityDetails
            Dim colCount As Integer = 3
            .RowHeadersVisible = False
            Dim x As Integer
            For x = 0 To colCount
                Select Case x
                    Case 0
                        Dim index As Integer = .Columns.Add(cId, "S. No.")
                        .Columns(index).Width = 80

                    Case 1
                        Dim index As Integer = .Columns.Add(cName, "Speciality")
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
            GrdSpecialityDetails.Rows.Clear()
            Dim specialities() As ClsSpecialityMaster = GetAllSpecialityMaster(Me.Name)
            If specialities Is Nothing Then Exit Try

            Dim speciality As ClsSpecialityMaster
            For Each speciality In specialities
                InsertIntoGrid(speciality)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub InsertIntoGrid(ByRef specialityObj As ClsSpecialityMaster)
        Try
            If specialityObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdSpecialityDetails.Rows.Add
            With GrdSpecialityDetails.Rows(rowIndex)
                .Cells(cId).Value = specialityObj.Id
                .Cells(cName).Value = specialityObj.Name
                .Cells(cUserId).Value = specialityObj.UserId
                .Cells(cDateOn).Value = specialityObj.DateOn
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Function ValidateValues() As Boolean
        Dim result As Boolean = False
        Try
            RemoveErrorIcon()

            If TxtSpeciality.Text.Trim = "" Then
                ErrorInData("Please enter speciality.", TxtSpeciality)
                Exit Try
            End If

            result = True

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Sub ResetControlsToAddNew()
        TxtSpeciality.Text = ""
        TxtSNo.Text = ""
        BtnAdd.Enabled = True
        BtnUpdate.Enabled = False
        BtnCancel.Enabled = False
        RemoveErrorIcon()

        editRow = Nothing

        TxtSpeciality.Focus()
    End Sub

#End Region

#Region "Public Functions"

    Public Function Change() As Boolean
        Return flagChange
    End Function

#End Region

End Class
