Imports System.Windows.Forms
Imports AIMS.Author

Public Class FrmStorageMaster

#Region "Local variables and Constants"

    Dim editRow As DataGridViewRow = Nothing
    Dim flagChange As Boolean = False

    Enum Index
        GrpStorage = 0
        TxtSNo
        TxtStorage
        GrpButton
        BtnAdd
        BtnUpdate
        BtnCancel
        BtnClose
        GrpStorageDetails
        GrdStorageDetails
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

    Private Sub FrmStorageMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.StoragePoint_NoAdd) = True Then Exit Sub
            If ValidateValues() = False Then Exit Sub

            If Not (GetRowForFieldAndValue(GrdStorageDetails, cName, TxtStorage.Text.Trim) Is Nothing) Then
                ErrorInData("Storage already exist in list", TxtStorage)
                Exit Sub
            End If

            Dim storage As New ClsStorageMaster
            With storage
                .Name = TxtStorage.Text
                .UserId = gUser.LoginName
                .DateOn = Now
            End With

            Dim id As Integer = InsertIntoStorageMaster(Me.Name, storage)
            If id > 0 Then
                flagChange = True
                storage.Id = id
                InsertIntoGrid(storage)
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNew()
    End Sub

    Private Sub BtnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUpdate.Click
        Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.StoragePoint_NoUpdate) = True Then Exit Sub
            If editRow Is Nothing Then Exit Try
            If ValidateValues() = False Then Exit Sub

            Dim storage As New ClsStorageMaster
            With storage
                .Id = editRow.Cells(cId).Value
                .Name = TxtStorage.Text
                .UserId = editRow.Cells(cUserId).Value
                .DateOn = editRow.Cells(cDateOn).Value
            End With

            If StorageMasterUpdatable(Me.Name, storage) = False Then
                ErrorInData("This Storage name is already exist with other id.", TxtStorage)
                Exit Sub
            End If

            If UpdateStorageMaster(Me.Name, storage) <> EnResult.Change Then Exit Sub

            flagChange = True
            With editRow
                .Cells(cName).Value = TxtStorage.Text
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

    Private Sub GrdStorageDetails_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdStorageDetails.CellDoubleClick
        Try
            If e.RowIndex < 0 Then Exit Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.StoragePoint_NoUpdate) = True Then Exit Sub

            editRow = GrdStorageDetails.Rows(e.RowIndex)
            With editRow
                TxtSNo.Text = .Cells(cId).Value
                TxtStorage.Text = .Cells(cName).Value
            End With

            BtnAdd.Enabled = False
            BtnUpdate.Enabled = True
            BtnCancel.Enabled = True

            TxtStorage.Focus()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub GrdStorageDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdStorageDetails.KeyDown
        If e.KeyCode = Keys.Tab Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtStorage.KeyDown, TxtSNo.KeyDown
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
        GrpStorage.TabIndex = Index.GrpStorage
        TxtSNo.TabIndex = Index.TxtSNo
        TxtStorage.TabIndex = Index.TxtStorage
        GrpButton.TabIndex = Index.GrpButton
        BtnAdd.TabIndex = Index.BtnAdd
        BtnUpdate.TabIndex = Index.BtnUpdate
        BtnCancel.TabIndex = Index.BtnCancel
        BtnClose.TabIndex = Index.BtnClose
        GrpStorageDetails.TabIndex = Index.GrpStorageDetails
        GrdStorageDetails.TabIndex = Index.GrdStorageDetails
    End Sub

    Private Sub SetGrid()
        With GrdStorageDetails
            Dim colCount As Integer = 3
            .RowHeadersVisible = False
            Dim x As Integer
            For x = 0 To colCount
                Select Case x
                    Case 0
                        Dim index As Integer = .Columns.Add(cId, "S. No.")
                        .Columns(index).Width = 80

                    Case 1
                        Dim index As Integer = .Columns.Add(cName, "Storage")
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
            GrdStorageDetails.Rows.Clear()
            Dim storages() As ClsStorageMaster = GetAllStorageMaster(Me.Name)
            If storages Is Nothing Then Exit Try

            Dim storage As ClsStorageMaster
            For Each storage In storages
                InsertIntoGrid(storage)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub InsertIntoGrid(ByRef storageObj As ClsStorageMaster)
        Try
            If storageObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdStorageDetails.Rows.Add
            With GrdStorageDetails.Rows(rowIndex)
                .Cells(cId).Value = storageObj.Id
                .Cells(cName).Value = storageObj.Name
                .Cells(cUserId).Value = storageObj.UserId
                .Cells(cDateOn).Value = storageObj.DateOn
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Function ValidateValues() As Boolean
        Dim result As Boolean = False
        Try
            RemoveErrorIcon()

            If TxtStorage.Text.Trim = "" Then
                ErrorInData("Please enter storage.", TxtStorage)
                Exit Try
            End If

            result = True

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Sub ResetControlsToAddNew()
        TxtStorage.Text = ""
        TxtSNo.Text = ""
        BtnAdd.Enabled = True
        BtnUpdate.Enabled = False
        BtnCancel.Enabled = False
        RemoveErrorIcon()

        editRow = Nothing

        TxtStorage.Focus()
    End Sub

#End Region

End Class
