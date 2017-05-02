Imports System.Windows.Forms
Imports AIMS.Author

Public Class FrmGenericMaster

#Region "Local variables and Constants"

    Dim editRow As DataGridViewRow = Nothing
    Dim flagChange As Boolean = False

    Enum Index
        GrpGeneric = 0
        TxtGeneric
        CmbStatus
        GrpButton
        BtnAdd
        BtnUpdate
        BtnCancel
        BtnClose
        GrpGenericDetails
        GrdGenericDetails
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

    Private Sub FrmGenericMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Try
            If ValidateValues() = False Then Exit Sub

            Dim generic As New ClsGenericMaster
            With generic
                .Name = TxtGeneric.Text
                .Status = CmbStatus.Text
                .UserId = gUser.LoginName
                .DateOn = Now
            End With

            If Not (GetRowForFieldAndValue(GrdGenericDetails, cName, TxtGeneric.Text.Trim) Is Nothing) Then
                ErrorInData("Name already exist in list", TxtGeneric)
                Exit Sub
            End If

            Dim id As Integer = InsertIntoGenericMaster(Me.Name, generic)
            If id > 0 Then
                flagChange = True
                generic.Id = id
                InsertIntoGrid(generic)
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

            Dim generic As New ClsGenericMaster
            With generic
                .Id = editRow.Cells(cId).Value
                .Name = TxtGeneric.Text
                .Status = CmbStatus.Text
                .UserId = editRow.Cells(cUserId).Value
                .DateOn = editRow.Cells(cDateOn).Value
            End With

            If GenericMasterUpdatable(Me.Name, generic) = False Then
                ErrorInData("This name is already exist with other id.", TxtGeneric)
                Exit Sub
            End If

            If UpdateGenericMaster(Me.Name, generic) <> EnResult.Change Then Exit Sub

            flagChange = True
            With editRow
                .Cells(cName).Value = TxtGeneric.Text
                .Cells(cStatus).Value = CmbStatus.Text
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

    Private Sub GrdGenericDetails_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdGenericDetails.CellDoubleClick
        Try
            If e.RowIndex < 0 Then Exit Try
            'If AndedTheString(gUser.AuthorizationNo, Authorization.Generics_NoUpdate) = True Then Exit Sub

            editRow = GrdGenericDetails.Rows(e.RowIndex)
            With editRow
                TxtGeneric.Text = .Cells(cName).Value
                CmbStatus.Text = .Cells(cStatus).Value
            End With

            BtnAdd.Enabled = False
            BtnUpdate.Enabled = True
            BtnCancel.Enabled = True

            TxtGeneric.Focus()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub GrdGenericDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdGenericDetails.KeyDown
        If e.KeyCode = Keys.Tab Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtGeneric.KeyDown, CmbStatus.KeyDown
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
        With CmbStatus
            .Items.Clear()
            .Items.Add(cPermitted)
            .Items.Add(cBanned)

            .SelectedIndex = 0
        End With

        SetTabIndex()
        SetGrid()
        LoadGridValues()

        ResetControlsToAddNew()
    End Sub

    Private Sub SetTabIndex()
        GrpGeneric.TabIndex = Index.GrpGeneric
        TxtGeneric.TabIndex = Index.TxtGeneric
        CmbStatus.TabIndex = Index.CmbStatus
        GrpButton.TabIndex = Index.GrpButton
        BtnAdd.TabIndex = Index.BtnAdd
        BtnUpdate.TabIndex = Index.BtnUpdate
        BtnCancel.TabIndex = Index.BtnCancel
        BtnClose.TabIndex = Index.BtnClose
        GrpGenericDetails.TabIndex = Index.GrpGenericDetails
        GrdGenericDetails.TabIndex = Index.GrdGenericDetails
    End Sub

    Private Sub SetGrid()
        With GrdGenericDetails
            Dim colCount As Integer = 4
            .RowHeadersVisible = False
            Dim x As Integer
            For x = 0 To colCount
                Select Case x
                    Case 0
                        Dim index As Integer = .Columns.Add(cId, "S. No.")
                        .Columns(index).Visible = False

                    Case 1
                        Dim index As Integer = .Columns.Add(cName, "Generic")
                        .Columns(index).Width = 280

                    Case 2
                        Dim index As Integer = .Columns.Add(cUserId, cUserId)
                        .Columns(index).Visible = False

                    Case 3
                        Dim index As Integer = .Columns.Add(cDateOn, cDateOn)
                        .Columns(index).Visible = False

                    Case 4
                        Dim index As Integer = .Columns.Add(cStatus, cStatus)
                        .Columns(index).Width = 100

                End Select
            Next
        End With
    End Sub

    Private Sub LoadGridValues()
        Try
            GrdGenericDetails.Rows.Clear()
            Dim generics() As ClsGenericMaster = GetAllGenericMaster(Me.Name)
            If generics Is Nothing Then Exit Try

            Dim generic As ClsGenericMaster
            For Each generic In generics
                InsertIntoGrid(generic)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub InsertIntoGrid(ByRef genericObj As ClsGenericMaster)
        Try
            If genericObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdGenericDetails.Rows.Add
            With GrdGenericDetails.Rows(rowIndex)
                .Cells(cId).Value = genericObj.Id
                .Cells(cName).Value = genericObj.Name
                .Cells(cStatus).Value = genericObj.Status
                .Cells(cUserId).Value = genericObj.UserId
                .Cells(cDateOn).Value = genericObj.DateOn
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Function ValidateValues() As Boolean
        Dim result As Boolean = False
        Try
            RemoveErrorIcon()

            If TxtGeneric.Text.Trim = "" Then
                ErrorInData("Please enter generic.", TxtGeneric)
                Exit Try
            End If

            If CmbStatus.Text.Trim = "" Then
                ErrorInData("Please select status.", CmbStatus)
                Exit Try
            End If

            result = True

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Sub ResetControlsToAddNew()
        TxtGeneric.Text = ""
        CmbStatus.Text = cPermitted
        BtnAdd.Enabled = True
        BtnUpdate.Enabled = False
        BtnCancel.Enabled = False
        RemoveErrorIcon()

        editRow = Nothing

        TxtGeneric.Focus()
    End Sub

#End Region

End Class
