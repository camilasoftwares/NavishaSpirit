Imports AIMS.Author

Public Class FrmAccountGroups

#Region "Local variables and Constants"

    Dim editRow As DataGridViewRow = Nothing
    Dim flagChange As Boolean = False

    Private Const lcAssets As String = "Assets"
    Private Const lcExpenditure As String = "Expenditure"
    Private Const lcLiabilities As String = "Liabilities"
    Private Const lcRevenue As String = "Revenue"
    Private Const lcCategory As String = "Category"
    Private Const lcGroupCode As String = "Group Code"


    Enum Index
        GrpAccountGroup
        TxtGroupCode
        TxtName
        CmbCategory
        BtnAdd
        BtnUpdate
        BtnCancel
        BtnClose
        GrpSearch
        CmbSearchOption
        TxtSearchValue
        GrdAccountGroup
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

    Private Sub FrmAccountGroups_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.AccountGroup_NoAdd) = True Then Exit Sub
            If ValidateValues() = False Then Exit Sub

            If NameExistInGrid(TxtName.Text) = True Then
                ErrorInData("Name already exist in list.", TxtName)
                Exit Sub
            End If

            Dim accountGroup As New ClsAccountGroup
            With accountGroup
                .Name = TxtName.Text
                .AvailableIn = CmbCategory.Text
                .UserId = gUser.LoginName
                .DateOn = Now
            End With

            Dim id As Integer = InsertIntoAccountGroup(Me.Name, accountGroup)
            If id > 0 Then
                flagChange = True
                accountGroup = GetAccountGroup(Me.Name, id)
                InsertIntoGrid(accountGroup)
                MsgBox("Added successfully.", , "Added")
            End If

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
            If AndedTheString(gUser.AuthorizationNo, Authorization.AccountGroup_NoUpdate) = True Then Exit Sub
            If editRow Is Nothing Then Exit Try
            If ValidateValues() = False Then Exit Sub

            Dim accountGroup As New ClsAccountGroup
            With accountGroup
                .Id = editRow.Cells(cId).Value
                .GroupCode = editRow.Cells(cGroupCode).Value
                .Name = TxtName.Text
                .AvailableIn = CmbCategory.Text
                .UserId = gUser.LoginName
                .DateOn = Now
            End With

            If AccountGroupUpdatable(Me.Name, accountGroup) = False Then
                ErrorInData("Already exist with other id.", TxtName)
                Exit Sub
            End If

            If UpdateAccountGroup(Me.Name, accountGroup) <> EnResult.Change Then Exit Sub

            flagChange = True
            With editRow
                .Cells(cName).Value = accountGroup.Name
                .Cells(cAvailableIn).Value = accountGroup.AvailableIn
                .Cells(cUserId).Value = accountGroup.UserId
                .Cells(cDateOn).Value = accountGroup.DateOn
            End With

            MsgBox("Updated successfully.", , "Updated")

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNew()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub CmbSearchOption_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbSearchOption.SelectedIndexChanged
        TxtSearchValue.Text = ""
    End Sub

    Private Sub TxtSearchValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSearchValue.TextChanged
        LoadGridValuesForSearch()
    End Sub

    Private Sub GrdAccountGroup_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdAccountGroup.CellDoubleClick
        Try
            If e.RowIndex < 0 Then Exit Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.AccountGroup_NoUpdate) = True Then Exit Sub

            editRow = GrdAccountGroup.Rows(e.RowIndex)
            With editRow
                'To update Account group disbable if block code. After update enable this code again
                If .Cells(cId).Value < 25 Then
                    MsgBox("Updation is not allowed on this group.", , "Restricted")
                    ResetControlsToAddNew()
                    Exit Try
                End If

                TxtGroupCode.Text = .Cells(cGroupCode).Value
                TxtName.Text = .Cells(cName).Value
                CmbCategory.Text = .Cells(cAvailableIn).Value
            End With

            BtnAdd.Enabled = False
            BtnUpdate.Enabled = True
            BtnCancel.Enabled = True
            GrpSearch.Enabled = False

            TxtName.Focus()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub GrdAccountGroup_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdAccountGroup.KeyDown
        If e.KeyCode = Keys.Tab Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSearchValue.KeyDown, TxtName.KeyDown, TxtGroupCode.KeyDown, CmbSearchOption.KeyDown, CmbCategory.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

#End Region

#Region "Private Functions"

    Private Sub SetControls()
        SetTabIndex()
        SetGrid()
        LoadComboBoxValues()
        LoadGridValues()

        ResetControlsToAddNew()
    End Sub

    Private Sub SetTabIndex()
        GrpAccountGroup.TabIndex = Index.GrpAccountGroup
        TxtGroupCode.TabIndex = Index.TxtGroupCode
        TxtName.TabIndex = Index.TxtName
        CmbCategory.TabIndex = Index.CmbCategory
        BtnAdd.TabIndex = Index.BtnAdd
        BtnUpdate.TabIndex = Index.BtnUpdate
        BtnCancel.TabIndex = Index.BtnCancel
        BtnClose.TabIndex = Index.BtnClose
        GrpSearch.TabIndex = Index.GrpSearch
        CmbSearchOption.TabIndex = Index.CmbSearchOption
        TxtSearchValue.TabIndex = Index.TxtSearchValue
        GrdAccountGroup.TabIndex = Index.GrdAccountGroup
    End Sub

    Private Sub SetGrid()
        With GrdAccountGroup
            Dim colCount As Integer = 5
            .RowHeadersVisible = False
            Dim x As Integer
            For x = 0 To colCount
                Select Case x
                    Case 0
                        Dim index As Integer = .Columns.Add(cId, cId)
                        .Columns(index).Visible = False

                    Case 1
                        Dim index As Integer = .Columns.Add(cGroupCode, "Grp. Code")
                        .Columns(index).Width = 90

                    Case 2
                        Dim index As Integer = .Columns.Add(cName, cName)
                        .Columns(index).Width = 240

                    Case 3
                        Dim index As Integer = .Columns.Add(cAvailableIn, "Category")
                        .Columns(index).Width = 150

                    Case 4
                        Dim index As Integer = .Columns.Add(cUserId, cUserId)
                        .Columns(index).Visible = False

                    Case 5
                        Dim index As Integer = .Columns.Add(cDateOn, cDateOn)
                        .Columns(index).Visible = False

                End Select
            Next
        End With
    End Sub

    Private Sub LoadComboBoxValues()
        With CmbCategory.Items
            .Clear()

            .Add(lcAssets)
            .Add(lcExpenditure)
            .Add(lcLiabilities)
            .Add(lcRevenue)
        End With

        CmbCategory.SelectedIndex = 0

        With CmbSearchOption.Items
            .Clear()

            .Add(lcGroupCode)
            .Add(lcCategory)
            .Add(cName)
        End With

        CmbSearchOption.SelectedIndex = 0
    End Sub

    Private Sub LoadGridValues()
        Try
            GrdAccountGroup.Rows.Clear()
            Dim accountGroups() As ClsAccountGroup = GetAllAccountGroups(Me.Name)
            If accountGroups Is Nothing Then Exit Try

            Dim accountGroup As ClsAccountGroup
            For Each accountGroup In accountGroups
                InsertIntoGrid(accountGroup)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub InsertIntoGrid(ByRef accountGroupObj As ClsAccountGroup)
        Try
            If accountGroupObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdAccountGroup.Rows.Add
            With GrdAccountGroup.Rows(rowIndex)
                .Cells(cId).Value = accountGroupObj.Id
                .Cells(cGroupCode).Value = accountGroupObj.GroupCode
                .Cells(cName).Value = accountGroupObj.Name
                .Cells(cAvailableIn).Value = accountGroupObj.AvailableIn
                .Cells(cUserId).Value = accountGroupObj.UserId
                .Cells(cDateOn).Value = accountGroupObj.DateOn
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Function ValidateValues() As Boolean
        Dim result As Boolean = False
        Try
            RemoveErrorIcon()

            If TxtName.Text.Trim = "" Then
                ErrorInData("Please enter group name.", TxtName)
                Exit Try
            End If

            If CmbCategory.Text.Trim = "" Then
                ErrorInData("Please select category.", CmbCategory)
                Exit Try
            End If

            result = True

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Sub ResetControlsToAddNew()
        TxtGroupCode.Text = ""
        TxtName.Text = ""
        If CmbCategory.Items.Count > 0 Then CmbCategory.SelectedIndex = 0

        BtnAdd.Enabled = True
        BtnUpdate.Enabled = False
        BtnCancel.Enabled = False
        GrpSearch.Enabled = True
        RemoveErrorIcon()

        editRow = Nothing

        TxtName.Focus()
    End Sub

    Private Function NameExistInGrid(ByVal name As String) As Boolean
        Dim result As Boolean = False
        Try
            name = name.Trim
            If name = "" Then Exit Try

            Dim row As DataGridViewRow
            For Each row In GrdAccountGroup.Rows
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

    Private Sub LoadGridValuesForSearch()
        Try
            Dim search As String = TxtSearchValue.Text.Trim
            Dim fieldToSearch As String = CmbSearchOption.Text.Trim
            Dim accountGroups() As ClsAccountGroup = Nothing

            If search = "" Then
                LoadGridValues()
                Exit Try
            ElseIf fieldToSearch = lcGroupCode Then
                accountGroups = GetAllAccountGroupCodeLike(Me.Name, search)
            ElseIf fieldToSearch = lcCategory Then
                accountGroups = GetAllAccountGroupCategoryLike(Me.Name, search)
            ElseIf fieldToSearch = cName Then
                accountGroups = GetAllAccountGroupNameLike(Me.Name, search)
            Else
                LoadGridValues()
                Exit Try
            End If

            GrdAccountGroup.Rows.Clear()
            If accountGroups Is Nothing Then Exit Try

            Dim accountGroup As ClsAccountGroup
            For Each accountGroup In accountGroups
                InsertIntoGrid(accountGroup)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

#End Region

#Region "Public Functions"

    Public Function Change() As Boolean
        Return flagChange
    End Function

#End Region

End Class