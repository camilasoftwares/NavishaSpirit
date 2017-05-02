Imports System.Windows.Forms
Imports AIMS.Author

Public Class FrmUserMaster

#Region "Local variables and Constants"

    Dim editRow As DataGridViewRow = Nothing
    Dim flagProfileIndexChange As Boolean = False
    Private Const lcProfile As String = "Profile"

    Enum Index
        GrpUser = 0
        TxtLoginId
        TxtPassword
        TxtPasswordReType
        CmbProfile
        TxtName
        ChkIgnorePassword
        TrVwMenuList
        BtnAdd
        BtnUpdate
        BtnCancel
        BtnClose
        GrpUsers
        GrdUsers
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

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub CmbProfile_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbProfile.LostFocus
        Try
            If flagProfileIndexChange = False Then Exit Sub

            flagProfileIndexChange = False
            Dim profile As ClsProfileMaster = CmbProfile.SelectedItem
            If profile Is Nothing Then Exit Sub

            CheckTreeViewMenuListCheckBoxesForValue(TrVwMenuList, profile.AuthorizationNo)

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub CmbProfile_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbProfile.SelectedIndexChanged
        flagProfileIndexChange = True
    End Sub

    Private Sub GrdUsers_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdUsers.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.UserMaster_NoUpdate) = True Then Exit Sub

            editRow = GrdUsers.Rows(e.RowIndex)
            With editRow
                TxtLoginId.Text = .Cells(cLoginName).Value
                TxtName.Text = .Cells(cName).Value
                CmbProfile.Text = .Cells(lcProfile).Value
                CheckTreeViewMenuListCheckBoxesForValue(TrVwMenuList, .Cells(cAuthorizationNo).Value)
                TxtPassword.Text = ""
                TxtPasswordReType.Text = ""
            End With

            ChkIgnorePassword.Checked = True
            BtnAdd.Enabled = False
            BtnUpdate.Enabled = True
            BtnCancel.Enabled = True
            TxtLoginId.ReadOnly = True
            ChkIgnorePassword.Enabled = True
            TxtPassword.Focus()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub GrdUsers_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdUsers.KeyDown
        If e.KeyCode = Keys.Tab Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.UserMaster_NoAdd) = True Then Exit Sub
            If ValidateValues() = False Then Exit Sub

            Dim loginId As String = TxtLoginId.Text.Trim
            If ItemExistForLoginId(loginId) = True Then
                ErrorInData("Login Id already exist.", TxtLoginId)
                Exit Sub
            End If

            Dim authorizationNo As String = SumOfTreeViewMenuListValue(TrVwMenuList)
            If authorizationNo.Trim = "" Then
                ErrorInData("There is no selection found for menu items.", TrVwMenuList)
                Exit Sub
            End If

            Dim user As New ClsUserMaster
            With user
                .AuthorizationNo = authorizationNo
                .LoginName = loginId
                .Name = TxtName.Text
                .Password = TxtPassword.Text
                .ProfileId = GetSelectedItemId(CmbProfile)
            End With

            Dim id As Integer = InsertIntoUserMaster(Me.Name, user)
            If id <= 0 Then Exit Try

            user.Id = id
            InsertIntoGrid(user)
            GrdUsers.Sort(GrdUsers.Columns(cLoginName), System.ComponentModel.ListSortDirection.Ascending)

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlToAddNew()
    End Sub

    Private Sub BtnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUpdate.Click
        Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.UserMaster_NoUpdate) = True Then Exit Sub
            If editRow Is Nothing Then Exit Try
            If ValidateValues() = False Then Exit Sub

            Dim authorizationNo As String = SumOfTreeViewMenuListValue(TrVwMenuList)
            If authorizationNo.Trim = "" Then
                ErrorInData("There is no selection found for menu items.", TrVwMenuList)
                Exit Sub
            End If

            Dim ignorePassword As Boolean = ChkIgnorePassword.Checked
            Dim user As New ClsUserMaster
            With user
                .Id = editRow.Cells(cId).Value
                .AuthorizationNo = authorizationNo
                .LoginName = editRow.Cells(cLoginName).Value
                .Name = TxtName.Text
                If ignorePassword = False Then .Password = TxtPassword.Text
                .ProfileId = GetSelectedItemId(CmbProfile)
            End With

            If UpdateUserMaster(Me.Name, user, ignorePassword) <> EnResult.Change Then Exit Sub

            With editRow
                .Cells(cAuthorizationNo).Value = authorizationNo
                .Cells(cName).Value = TxtName.Text
                .Cells(cPassword).Value = TxtPassword.Text
                .Cells(cProfileId).Value = GetSelectedItemId(CmbProfile)
                .Cells(lcProfile).Value = GetNameForProfileId(.Cells(cProfileId).Value)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlToAddNew()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        ResetControlToAddNew()
    End Sub

    Private Sub FrmUserMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetControls()
    End Sub

    Private Sub ChkIgnorePassword_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkIgnorePassword.CheckedChanged
        Dim flag As Boolean = Not ChkIgnorePassword.Checked
        TxtPassword.Enabled = flag
        TxtPasswordReType.Enabled = flag
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

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPasswordReType.KeyDown, TxtPassword.KeyDown, TxtName.KeyDown, TxtLoginId.KeyDown, TrVwMenuList.KeyDown, CmbProfile.KeyDown, ChkIgnorePassword.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

#End Region

#Region "Other Form Functionality"

    Private Sub LblAddProfile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblAddProfile.Click
        If AndedTheString(gUser.AuthorizationNo, Authorization.ProfileMaster) = False Then Exit Sub
        Try
            Dim frm As New FrmProfileMaster
            frm.ShowDialog(Me)
            If frm.Change = True Then LoadComboBoxValuesProfile()

            frm.Dispose()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

#End Region

#Region "Private Functions"

    Private Sub SetControls()
        SetTabIndex()
        SetTreeForMenuList()
        LoadComboBoxValuesProfile()
        SetGrid()
        LoadGridValues()

        ResetControlToAddNew()
    End Sub

    Private Sub SetTabIndex()
        GrpUser.TabIndex = Index.GrpUser
        TxtLoginId.TabIndex = Index.TxtLoginId
        TxtPassword.TabIndex = Index.TxtPassword
        TxtPasswordReType.TabIndex = Index.TxtPasswordReType
        CmbProfile.TabIndex = Index.CmbProfile
        TxtName.TabIndex = Index.TxtName
        ChkIgnorePassword.TabIndex = Index.ChkIgnorePassword
        TrVwMenuList.TabIndex = Index.TrVwMenuList
        BtnAdd.TabIndex = Index.BtnAdd
        BtnUpdate.TabIndex = Index.BtnUpdate
        BtnCancel.TabIndex = Index.BtnCancel
        BtnClose.TabIndex = Index.BtnClose
        GrpUsers.TabIndex = Index.GrpUsers
        GrdUsers.TabIndex = Index.GrdUsers
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

    Private Sub LoadComboBoxValuesProfile()
        Try
            CmbProfile.Items.Clear()

            Dim profiles() As ClsProfileMaster = GetAllProfileMaster(Me.Name)
            If profiles Is Nothing Then Exit Try

            With CmbProfile
                .DisplayMember = cName
                .ValueMember = cId

                Dim profile As ClsProfileMaster
                For Each profile In profiles
                    If profile.Id = 1 Then Continue For 'Skip Admin

                    .Items.Add(profile)
                Next

                If .Items.Count > 0 Then .SelectedIndex = 0
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub SetGrid()
        With GrdUsers
            Dim colCount As Integer = 6
            .RowHeadersVisible = False
            Dim x As Integer
            For x = 0 To colCount
                Select Case x
                    Case 0
                        Dim index As Integer = .Columns.Add(cId, cId)
                        .Columns(index).Visible = False

                    Case 1
                        Dim index As Integer = .Columns.Add(cLoginName, "Login Id")
                        .Columns(index).Width = 170

                    Case 2
                        Dim index As Integer = .Columns.Add(cPassword, cPassword)
                        .Columns(index).Visible = False

                    Case 3
                        Dim index As Integer = .Columns.Add(cAuthorizationNo, cAuthorizationNo)
                        .Columns(index).Visible = False

                    Case 4
                        Dim index As Integer = .Columns.Add(cProfileId, cProfileId)
                        .Columns(index).Visible = False

                    Case 5
                        Dim index As Integer = .Columns.Add(lcProfile, lcProfile)
                        .Columns(index).Width = 110

                    Case 6
                        Dim index As Integer = .Columns.Add(cName, "User Name")
                        .Columns(index).Width = 160

                End Select
            Next
        End With
    End Sub

    Private Sub LoadGridValues()
        Try
            GrdUsers.Rows.Clear()
            Dim users() As ClsUserMaster = GetAllUserMaster(Me.Name)
            If users Is Nothing Then Exit Try

            Dim user As ClsUserMaster
            For Each user In users
                InsertIntoGrid(user)
            Next

            GrdUsers.Sort(GrdUsers.Columns(cLoginName), System.ComponentModel.ListSortDirection.Ascending)

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub InsertIntoGrid(ByRef user As ClsUserMaster)
        Try
            Dim rowIndex As Integer = GrdUsers.Rows.Add
            With GrdUsers.Rows(rowIndex)
                .Cells(cId).Value = user.Id
                .Cells(cLoginName).Value = user.LoginName
                .Cells(cPassword).Value = user.Password
                .Cells(cAuthorizationNo).Value = user.AuthorizationNo
                .Cells(cProfileId).Value = user.ProfileId
                .Cells(lcProfile).Value = GetNameForProfileId(user.ProfileId)
                .Cells(cName).Value = user.Name

                If .Cells(cProfileId).Value = 1 Then .Visible = False
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Function GetNameForProfileId(ByVal id As Integer) As String
        Dim result As String = ""
        Try
            Dim profile As ClsProfileMaster
            For Each profile In CmbProfile.Items
                If profile.Id = id Then
                    result = profile.Name
                    Exit Try
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Sub ResetControlToAddNew()
        On Error Resume Next

        TxtLoginId.Text = ""
        TxtPassword.Text = ""
        TxtPasswordReType.Text = ""
        TxtName.Text = ""
        RemoveTreeViewMenuListCheckBoxes(TrVwMenuList)
        Dim x As Integer = CmbProfile.SelectedIndex
        If CmbProfile.Items.Count > 0 Then
            CmbProfile.SelectedIndex = 0
            If x = CmbProfile.SelectedIndex Then
                Dim profile As ClsProfileMaster = CmbProfile.SelectedItem
                CheckTreeViewMenuListCheckBoxesForValue(TrVwMenuList, profile.AuthorizationNo)
                flagProfileIndexChange = False
            End If
        End If

        TxtPassword.Enabled = True
        TxtPasswordReType.Enabled = True
        ChkIgnorePassword.Checked = False
        BtnAdd.Enabled = True
        BtnUpdate.Enabled = False
        BtnCancel.Enabled = False
        ChkIgnorePassword.Enabled = False
        RemoveErrorIcon()

        TxtLoginId.ReadOnly = False
        editRow = Nothing

        TxtLoginId.Focus()
    End Sub

    Private Function ValidateValues() As Boolean
        Dim result As Boolean = False
        Try
            RemoveErrorIcon()

            If TxtLoginId.Text.Trim = "" Then
                ErrorInData("Login Id can't be blank. Please enter login id.", TxtLoginId)
                Exit Try
            End If

            If ChkIgnorePassword.Checked = False Then
                If TxtPassword.Text.Trim = "" Then
                    ErrorInData("Password can't be blank. Please enter password.", TxtPassword)
                    Exit Try
                End If

                If TxtPassword.Text <> TxtPasswordReType.Text Then
                    ErrorInData("Password doesn't match. Please enter password carefully.", TxtPassword)
                    Exit Try
                End If
            End If

            If CmbProfile.Text.Trim = "" Then
                ErrorInData("Profile can't be blank. Please select profile.", CmbProfile)
                Exit Try
            End If

            If TxtName.Text.Trim = "" Then
                ErrorInData("User Name can't be blank. Please enter name.", TxtName)
                Exit Try
            End If

            result = True

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Function ItemExistForLoginId(ByVal loginId As String) As Boolean
        Dim result As Boolean = False
        Try
            Dim row As DataGridViewRow
            For Each row In GrdUsers.Rows
                If row.Cells(cLoginName).Value = loginId Then
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
