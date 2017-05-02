Imports AIMS.Author

Public Class FrmAccountHeads

#Region "Local variables and Constants"

    Dim editRow As DataGridViewRow = Nothing

    Private Const lcHeadCode As String = "A/c Head Code"
    Private Const lcHeadName As String = "A/c Head Name"
    Private Const lcGroupName As String = "A/c Group Name"

    Enum Index
        GrpAccountHead
        TxtHeadCode
        TxtName
        CmbGroup
        TxtOpeningBalance
        CmbCrDr
        BtnAdd
        BtnUpdate
        BtnCancel
        BtnClose
        GrpSearch
        CmbSearchOption
        TxtSearchValue
        GrdAccountHead
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

    Private Sub FrmAccountHeads_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

    Private Sub TxtOpeningBalance_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtOpeningBalance.KeyPress
        e.Handled = Check_DecimalAllow(e.KeyChar, sender.text)
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        ResetControlsToAddNew()
    End Sub

    Private Sub BtnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUpdate.Click
        Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.AccountHead_NoUpdate) = True Then Exit Sub
            If editRow Is Nothing Then Exit Try
            If ValidateValues() = False Then Exit Sub

            Dim accountHead As New ClsAccountHead
            With accountHead
                .Id = editRow.Cells(cId).Value
                .HeadCode = editRow.Cells(cHeadCode).Value
                .Name = TxtName.Text
                .CrDr = CmbCrDr.Text
                .GroupId = GetSelectedItemId(CmbGroup)
                .OpeningBalance = Val(TxtOpeningBalance.Text)
                .UserId = gUser.LoginName
                .DateOn = Now
            End With

            If AccountHeadUpdatable(Me.Name, accountHead) = False Then
                ErrorInData("Already exist with other id.", TxtName)
                Exit Sub
            End If

            If UpdateAccountHead(Me.Name, accountHead) <> EnResult.Change Then Exit Sub

            With editRow
                .Cells(cName).Value = accountHead.Name
                .Cells(cCrDr).Value = accountHead.CrDr
                .Cells(cUserId).Value = accountHead.UserId
                .Cells(cDateOn).Value = accountHead.DateOn
                .Cells(cGroupId).Value = accountHead.GroupId
                .Cells(cOpeningBalance).Value = accountHead.OpeningBalance
                .Cells(cGroupName).Value = GetTextForValue(CmbGroup, .Cells(cGroupId).Value)
            End With

            MsgBox("Updated successfully.", , "Updated")

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNew()
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.AccountHead_NoAdd) = True Then Exit Sub
            If ValidateValues() = False Then Exit Sub

            If NameExistInGrid(TxtName.Text) = True Then
                ErrorInData("Name already exist in list.", TxtName)
                Exit Sub
            End If

            Dim accountHead As New ClsAccountHead
            With accountHead
                .Name = TxtName.Text
                .CrDr = CmbCrDr.Text
                .GroupId = GetSelectedItemId(CmbGroup)
                .OpeningBalance = Val(TxtOpeningBalance.Text)
                .UserId = gUser.LoginName
                .DateOn = Now
            End With

            Dim id As Integer = InsertIntoAccountHead(Me.Name, accountHead)
            If id > 0 Then
                accountHead = GetAccountHead(Me.Name, id)
                InsertIntoGrid(accountHead)
                MsgBox("Added successfully.", , "Added")
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNew()
    End Sub

    Private Sub CmbSearchOption_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbSearchOption.SelectedIndexChanged
        TxtSearchValue.Text = ""
    End Sub

    Private Sub TxtSearchValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSearchValue.TextChanged
        LoadGridValuesForSearch()
    End Sub

    Private Sub GrdAccountHead_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdAccountHead.CellDoubleClick
        Try
            If e.RowIndex < 0 Then Exit Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.AccountHead_NoUpdate) = True Then Exit Sub

            editRow = GrdAccountHead.Rows(e.RowIndex)
            With editRow
                'To update Account Head disable if block code. After update enable this code again
                If .Cells(cId).Value <= 30 Then
                    MsgBox("Updation is not allowed on this Head.", , "Restricted")
                    ResetControlsToAddNew()
                    Exit Try
                End If

                TxtHeadCode.Text = .Cells(cHeadCode).Value
                TxtName.Text = .Cells(cName).Value
                CmbGroup.Text = .Cells(cGroupName).Value
                TxtOpeningBalance.Text = .Cells(cOpeningBalance).Value
                CmbCrDr.Text = .Cells(cCrDr).Value
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

    Private Sub GrdAccountHead_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdAccountHead.KeyDown
        If e.KeyCode = Keys.Tab Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSearchValue.KeyDown, TxtOpeningBalance.KeyDown, TxtName.KeyDown, TxtHeadCode.KeyDown, CmbSearchOption.KeyDown, CmbGroup.KeyDown, CmbCrDr.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

#End Region

#Region "Other Form Functionality"

    Private Sub LblAddGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblAddGroup.Click
        If AndedTheString(gUser.AuthorizationNo, Authorization.AccountGroup) = False Then Exit Sub
        Try
            Dim frm As New FrmAccountGroups
            frm.ShowDialog(Me)
            If frm.Change = True Then LoadComboBoxValuesForGroups()

            frm.Dispose()

        Catch ex As Exception
            AddToLog(ex)
        End Try
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
        GrpAccountHead.TabIndex = Index.GrpAccountHead
        TxtHeadCode.TabIndex = Index.TxtHeadCode
        TxtName.TabIndex = Index.TxtName
        CmbGroup.TabIndex = Index.CmbGroup
        TxtOpeningBalance.TabIndex = Index.TxtOpeningBalance
        CmbCrDr.TabIndex = Index.CmbCrDr
        BtnAdd.TabIndex = Index.BtnAdd
        BtnUpdate.TabIndex = Index.BtnUpdate
        BtnCancel.TabIndex = Index.BtnCancel
        BtnClose.TabIndex = Index.BtnClose
        GrpSearch.TabIndex = Index.GrpSearch
        CmbSearchOption.TabIndex = Index.CmbSearchOption
        TxtSearchValue.TabIndex = Index.TxtSearchValue
        GrdAccountHead.TabIndex = Index.GrdAccountHead
    End Sub

    Private Sub SetGrid()
        With GrdAccountHead
            Dim colCount As Integer = 8
            .RowHeadersVisible = False
            Dim x As Integer
            For x = 0 To colCount
                Select Case x
                    Case 0
                        Dim index As Integer = .Columns.Add(cId, cId)
                        .Columns(index).Visible = False

                    Case 1
                        Dim index As Integer = .Columns.Add(cHeadCode, "Head Code")
                        .Columns(index).Width = 90

                    Case 2
                        Dim index As Integer = .Columns.Add(cName, "Account Head Name")
                        .Columns(index).Width = 220

                    Case 3
                        Dim index As Integer = .Columns.Add(cGroupName, "Group Name")
                        .Columns(index).Width = 150

                    Case 4
                        Dim index As Integer = .Columns.Add(cCrDr, "Cr/Dr")
                        .Columns(index).Width = 50

                    Case 5
                        Dim index As Integer = .Columns.Add(cOpeningBalance, "Opening Balance")
                        .Columns(index).Width = 120

                    Case 6
                        Dim index As Integer = .Columns.Add(cGroupId, cGroupId)
                        .Columns(index).Visible = False

                    Case 7
                        Dim index As Integer = .Columns.Add(cUserId, cUserId)
                        .Columns(index).Visible = False

                    Case 8
                        Dim index As Integer = .Columns.Add(cDateOn, cDateOn)
                        .Columns(index).Visible = False

                End Select
            Next
        End With
    End Sub

    Private Sub LoadComboBoxValues()
        With CmbSearchOption.Items
            .Clear()

            .Add(lcHeadCode)
            .Add(lcGroupName)
            .Add(lcHeadName)
        End With

        CmbSearchOption.SelectedIndex = 0

        With CmbCrDr.Items
            .Clear()

            .Add(cCr)
            .Add(cDr)
        End With

        CmbCrDr.SelectedIndex = 0

        LoadComboBoxValuesForGroups()
    End Sub

    Private Sub LoadComboBoxValuesForGroups()
        Try
            CmbGroup.Items.Clear()

            Dim groups() As ClsAccountGroup = GetAllAccountGroups(Me.Name)
            If groups Is Nothing Then Exit Try

            Dim group As ClsAccountGroup
            For Each group In groups
                AddItemToComboBox(group.Name, group.Id, CmbGroup)
            Next

            If CmbGroup.Items.Count > 0 Then CmbGroup.SelectedIndex = 0

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadGridValues()
        Try
            GrdAccountHead.Rows.Clear()
            Dim accountHeads() As ClsAccountHead = GetAllAccountHead(Me.Name)
            If accountHeads Is Nothing Then Exit Try

            Dim accountHead As ClsAccountHead
            For Each accountHead In accountHeads
                InsertIntoGrid(accountHead)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub InsertIntoGrid(ByRef accountHeadObj As ClsAccountHead)
        Try
            If accountHeadObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdAccountHead.Rows.Add
            With GrdAccountHead.Rows(rowIndex)
                .Cells(cId).Value = accountHeadObj.Id
                .Cells(cHeadCode).Value = accountHeadObj.HeadCode
                .Cells(cName).Value = accountHeadObj.Name
                .Cells(cOpeningBalance).Value = accountHeadObj.OpeningBalance
                .Cells(cCrDr).Value = accountHeadObj.CrDr
                .Cells(cGroupId).Value = accountHeadObj.GroupId
                .Cells(cUserId).Value = accountHeadObj.UserId
                .Cells(cDateOn).Value = accountHeadObj.DateOn
                .Cells(cGroupName).Value = GetTextForValue(CmbGroup, .Cells(cGroupId).Value)
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
                ErrorInData("Please enter account head name.", TxtName)
                Exit Try
            End If

            If CmbGroup.Text.Trim = "" Then
                ErrorInData("Please select group name.", CmbGroup)
                Exit Try
            End If

            If TxtOpeningBalance.Text.Trim = "" Then
                ErrorInData("Please enter opening balance. It can't be blank.", TxtOpeningBalance)
                Exit Try
            End If

            If CmbCrDr.Text.Trim = "" Then
                ErrorInData("Please select Cr/Dr.", CmbCrDr)
                Exit Try
            End If

            result = True

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Sub ResetControlsToAddNew()
        TxtHeadCode.Text = ""
        TxtName.Text = ""
        TxtOpeningBalance.Text = "0"
        If CmbGroup.Items.Count > 0 Then CmbGroup.SelectedIndex = 0

        BtnAdd.Enabled = True
        BtnUpdate.Enabled = False
        BtnCancel.Enabled = False
        GrpSearch.Enabled = True

        editRow = Nothing

        TxtName.Focus()
    End Sub

    Private Function NameExistInGrid(ByVal name As String) As Boolean
        Dim result As Boolean = False
        Try
            name = name.Trim
            If name = "" Then Exit Try

            Dim row As DataGridViewRow
            For Each row In GrdAccountHead.Rows
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
            Dim accountHeads() As ClsAccountHead = Nothing

            If search = "" Then
                LoadGridValues()
                Exit Try
            ElseIf fieldToSearch = lcHeadCode Then
                accountHeads = GetAllAccountHeadCodeLike(Me.Name, search)
            ElseIf fieldToSearch = lcHeadName Then
                accountHeads = GetAllAccountHeadNameLike(Me.Name, search)
            ElseIf fieldToSearch = lcGroupName Then
                accountHeads = GetAllAccountHeadGroupNameLike(Me.Name, search)
            Else
                LoadGridValues()
                Exit Try
            End If

            GrdAccountHead.Rows.Clear()
            If accountHeads Is Nothing Then Exit Try

            Dim accountHead As ClsAccountHead
            For Each accountHead In accountHeads
                InsertIntoGrid(accountHead)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

#End Region

End Class