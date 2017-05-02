Imports System.Windows.Forms
Imports AIMS.Author

Public Class FrmProfileMaster

#Region "Local variables and Constants"

    Dim editRow As DataGridViewRow = Nothing
    Dim flagChange As Boolean = False

    Enum Index
        GrpProfile = 0
        TxtName
        TrVwMenuList
        BtnAdd
        BtnUpdate
        BtnCancel
        BtnClose
        GrpProfiles
        GrdProfiles
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

    Private Sub GrdProfiles_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdProfiles.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub

        Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.ProfileMaster_NoUpdate) = True Then Exit Sub

            editRow = GrdProfiles.Rows(e.RowIndex)
            With editRow
                TxtName.Text = .Cells(cName).Value
                CheckTreeViewMenuListCheckBoxesForValue(TrVwMenuList, .Cells(cAuthorizationNo).Value)
            End With

            BtnAdd.Enabled = False
            BtnUpdate.Enabled = True
            BtnCancel.Enabled = True

            TxtName.Focus()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub GrdProfiles_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdProfiles.KeyDown
        If e.KeyCode = Keys.Tab Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub FrmProfileMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.ProfileMaster_NoAdd) = True Then Exit Sub
            If ValidateValues() = False Then Exit Sub

            Dim name As String = TxtName.Text.Trim
            If ItemExistForName(name) = True Then
                ErrorInData("This profile name is alreay exist.", TxtName)
                Exit Sub
            End If

            Dim authorizationNo As String = SumOfTreeViewMenuListValue(TrVwMenuList)
            If authorizationNo.Trim = "" Then
                ErrorInData("There is no selection of menu item. Please select menu items.", TrVwMenuList)
                Exit Sub
            End If

            Dim profile As New ClsProfileMaster
            With profile
                .Name = name
                .AuthorizationNo = authorizationNo
            End With

            Dim id As Integer = InsertIntoProfileMaster(Me.Name, profile)
            If id <= 0 Then Exit Try

            flagChange = True
            profile.Id = id
            InsertIntoGrid(profile)
            GrdProfiles.Sort(GrdProfiles.Columns(cName), System.ComponentModel.ListSortDirection.Ascending)

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNew()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        ResetControlsToAddNew()
    End Sub

    Private Sub BtnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUpdate.Click
        Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.ProfileMaster_NoUpdate) = True Then Exit Sub
            If editRow Is Nothing Then Exit Try
            If ValidateValues() = False Then Exit Sub

            Dim name As String = TxtName.Text.Trim
            Dim authorizationNo As String = SumOfTreeViewMenuListValue(TrVwMenuList)
            If authorizationNo.Trim = "" Then
                ErrorInData("There is no selection of menu item. Please select menu items.", TrVwMenuList)
                Exit Sub
            End If

            Dim profile As New ClsProfileMaster
            With profile
                .Id = editRow.Cells(cId).Value
                .Name = name
                .AuthorizationNo = authorizationNo
            End With

            If ProfileMasterUpdatable(Me.Name, profile) = False Then
                ErrorInData("This profile name already exist with other id.", TxtName)
                Exit Sub
            End If

            If UpdateProfileMaster(Me.Name, profile) <> EnResult.Change Then Exit Sub

            flagChange = True
            With editRow
                .Cells(cName).Value = name
                .Cells(cAuthorizationNo).Value = authorizationNo
            End With
            GrdProfiles.Sort(GrdProfiles.Columns(cName), System.ComponentModel.ListSortDirection.Ascending)

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNew()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub TrVwMenuList_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TrVwMenuList.AfterCheck
        Try
            Dim node As TreeNode = e.Node
            If node Is Nothing Then Exit Try

            If node.Checked = True Then
                CheckParent(node)
            Else
                UnCheckChild(node)
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtName.KeyDown, TrVwMenuList.KeyDown
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
        SetTreeForMenuList()
        SetGrid()
        LoadGridValues()

        ResetControlsToAddNew()
    End Sub

    Private Sub SetTabIndex()
        GrpProfile.TabIndex = Index.GrpProfile
        TxtName.TabIndex = Index.TxtName
        TrVwMenuList.TabIndex = Index.TrVwMenuList
        BtnAdd.TabIndex = Index.BtnAdd
        BtnUpdate.TabIndex = Index.BtnUpdate
        BtnCancel.TabIndex = Index.BtnCancel
        BtnClose.TabIndex = Index.BtnClose
        GrpProfiles.TabIndex = Index.GrpProfile
        GrdProfiles.TabIndex = Index.GrdProfiles
    End Sub

    Private Sub SetTreeForMenuList()
        Try
            SetTreeViewMenuList(TrVwMenuList)
            With TrVwMenuList
                If .Nodes.Count = 0 Then Exit Try
                .ExpandAll()
                .SelectedNode = .Nodes(0)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub SetGrid()
        With GrdProfiles
            Dim colCount As Integer = 2
            .RowHeadersVisible = False
            Dim x As Integer
            For x = 0 To colCount
                Select Case x
                    Case 0
                        Dim index As Integer = .Columns.Add(cId, cId)
                        .Columns(index).Visible = False

                    Case 1
                        Dim index As Integer = .Columns.Add(cName, "Profile Name")
                        .Columns(index).Width = 210

                    Case 2
                        Dim index As Integer = .Columns.Add(cAuthorizationNo, cAuthorizationNo)
                        .Columns(index).Visible = False

                End Select
            Next
        End With
    End Sub

    Private Sub LoadGridValues()
        Try
            GrdProfiles.Rows.Clear()
            Dim profiles() As ClsProfileMaster = GetAllProfileMaster(Me.Name)
            If profiles Is Nothing Then Exit Try

            Dim profile As ClsProfileMaster
            For Each profile In profiles
                InsertIntoGrid(profile)
            Next

            GrdProfiles.Sort(GrdProfiles.Columns(cName), System.ComponentModel.ListSortDirection.Ascending)

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub InsertIntoGrid(ByRef profile As ClsProfileMaster)
        Try
            Dim rowIndex As Integer = GrdProfiles.Rows.Add
            With GrdProfiles.Rows(rowIndex)
                .Cells(cId).Value = profile.Id
                .Cells(cName).Value = profile.Name
                .Cells(cAuthorizationNo).Value = profile.AuthorizationNo

                If .Cells(cId).Value = 1 Then .Visible = False 'This is admin
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub ResetControlsToAddNew()
        TxtName.Text = ""

        BtnAdd.Enabled = True
        BtnUpdate.Enabled = False
        BtnCancel.Enabled = False
        BtnClose.Enabled = True
        editRow = Nothing
        RemoveTreeViewMenuListCheckBoxes(TrVwMenuList)

        TxtName.Focus()
    End Sub

    Private Function ValidateValues() As Boolean
        Dim result As Boolean = False
        Try
            RemoveErrorIcon()

            If TxtName.Text.Trim = "" Then
                ErrorInData("Profile Name can't be blank. Please enter profile name.", TxtName)
                Exit Try
            End If

            result = True

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Function ItemExistForName(ByVal name As String) As Boolean
        Dim result As Boolean = False
        Try
            Dim row As DataGridViewRow
            For Each row In GrdProfiles.Rows
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
