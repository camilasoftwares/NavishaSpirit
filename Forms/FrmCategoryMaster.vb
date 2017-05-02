Imports System.Windows.Forms
Imports AIMS.Author

Public Class FrmCategoryMaster

#Region "Local variables and Constants"

    Dim editRow As DataGridViewRow = Nothing
    Dim flagChange As Boolean = False

    Enum Index
        GrpCategory = 0
        TxtCategory
        'CmbPI
        GrpButton
        BtnAdd
        BtnUpdate
        BtnCancel
        BtnClose
        GrpCategoryDetails
        GrdCategoryDetails
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

    Private Sub FrmCategoryMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.Category_NoAdd) = True Then Exit Sub
            If ValidateValues() = False Then Exit Sub

            If NameExistInGrid(TxtCategory.Text) = True Then
                ErrorInData("Category name already present.", TxtCategory)
                Exit Sub
            End If

            Dim category As New ClsCategoryMaster
            With category
                .Name = TxtCategory.Text
                '.PIId = GetSelectedItemId(CmbPI)
                .UserId = gUser.LoginName
                .DateOn = Now
            End With

            Dim id As Integer = InsertIntoCategoryMaster(Me.Name, category)
            If id > 0 Then
                flagChange = True
                category.Id = id
                InsertIntoGrid(category)
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNew()
    End Sub

    Private Sub BtnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUpdate.Click
        Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.Category_NoUpdate) = True Then Exit Sub
            If editRow Is Nothing Then Exit Try
            If ValidateValues() = False Then Exit Sub

            Dim category As New ClsCategoryMaster
            With category
                .Id = editRow.Cells(cId).Value
                .Name = TxtCategory.Text
                '.PIId = GetSelectedItemId(CmbPI)
                .UserId = editRow.Cells(cUserId).Value
                .DateOn = editRow.Cells(cDateOn).Value
            End With

            If CategoryMasterUpdatable(Me.Name, category) = False Then
                ErrorInData("Category name already present with other id.", TxtCategory)
                Exit Sub
            End If

            If UpdateCategoryMaster(Me.Name, category) <> EnResult.Change Then Exit Sub

            With editRow
                flagChange = True
                .Cells(cName).Value = TxtCategory.Text
                '.Cells(cPI).Value = CmbPI.Text
                '.Cells(cPIId).Value = GetSelectedItemId(CmbPI)
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

    Private Sub GrdCategoryDetails_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdCategoryDetails.CellDoubleClick
        Try
            If e.RowIndex < 0 Then Exit Try

            If AndedTheString(gUser.AuthorizationNo, Authorization.Category_NoUpdate) = True Then Exit Sub

            editRow = GrdCategoryDetails.Rows(e.RowIndex)
            With editRow
                TxtCategory.Text = .Cells(cName).Value
                'CmbPI.Text = .Cells(cPI).Value
            End With

            BtnAdd.Enabled = False
            BtnUpdate.Enabled = True
            BtnCancel.Enabled = True

            TxtCategory.Focus()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub GrdCategoryDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdCategoryDetails.KeyDown
        If e.KeyCode = Keys.Tab Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCategory.KeyDown
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
        'LoadComboBoxValuesForPI()
        LoadGridValues()

        ResetControlsToAddNew()
    End Sub

    Private Sub SetTabIndex()
        GrpCategory.TabIndex = Index.GrpCategory
        TxtCategory.TabIndex = Index.TxtCategory
        'CmbPI.TabIndex = Index.CmbPI
        GrpButton.TabIndex = Index.GrpButton
        BtnAdd.TabIndex = Index.BtnAdd
        BtnUpdate.TabIndex = Index.BtnUpdate
        BtnCancel.TabIndex = Index.BtnCancel
        BtnClose.TabIndex = Index.BtnClose
        GrpCategoryDetails.TabIndex = Index.GrpCategoryDetails
        GrdCategoryDetails.TabIndex = Index.GrdCategoryDetails
    End Sub

    Private Sub SetGrid()
        With GrdCategoryDetails
            Dim colCount As Integer = 5
            .RowHeadersVisible = False
            Dim x As Integer
            For x = 0 To colCount
                Select Case x
                    Case 0
                        Dim index As Integer = .Columns.Add(cId, "S. No.")
                        .Columns(index).Visible = False

                    Case 1
                        Dim index As Integer = .Columns.Add(cName, "Category")
                        .Columns(index).Width = 280

                    Case 2
                        Dim index As Integer = .Columns.Add(cUserId, cUserId)
                        .Columns(index).Visible = False

                    Case 3
                        Dim index As Integer = .Columns.Add(cDateOn, cDateOn)
                        .Columns(index).Visible = False

                    Case 4
                        'Dim index As Integer = .Columns.Add(cPI, cPI)
                        '.Columns(index).Width = 100

                    Case 5
                        'Dim index As Integer = .Columns.Add(cPIId, cPIId)
                        '.Columns(index).Visible = False

                End Select
            Next
        End With
    End Sub

    Private Sub LoadGridValues()
        Try
            GrdCategoryDetails.Rows.Clear()
            Dim categorys() As ClsCategoryMaster = GetAllCategoryMaster(Me.Name)
            If categorys Is Nothing Then Exit Try

            Dim category As ClsCategoryMaster
            For Each category In categorys
                InsertIntoGrid(category)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub InsertIntoGrid(ByRef categoryObj As ClsCategoryMaster)
        Try
            If categoryObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdCategoryDetails.Rows.Add
            With GrdCategoryDetails.Rows(rowIndex)
                .Cells(cId).Value = categoryObj.Id
                .Cells(cName).Value = categoryObj.Name
                '.Cells(cPIId).Value = categoryObj.PIId
                .Cells(cUserId).Value = categoryObj.UserId
                .Cells(cDateOn).Value = categoryObj.DateOn
                '.Cells(cPI).Value = GetTextForValue(CmbPI, .Cells(cPIId).Value)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    'Private Sub LoadComboBoxValuesForPI()
    '    Try
    '        CmbPI.Items.Clear()

    '        Dim pis() As ClsPIMaster = GetAllPIMaster(Me.Name)
    '        If pis Is Nothing Then Exit Try

    '        Dim pi As ClsPIMaster
    '        For Each pi In pis
    '            With pi
    '                AddItemToComboBox(.Name, .Id, CmbPI)
    '            End With
    '        Next

    '        If CmbPI.Items.Count > 0 Then CmbPI.SelectedIndex = 0

    '    Catch ex As Exception
    '        AddToLog(ex)
    '    End Try
    'End Sub

    Private Function ValidateValues() As Boolean
        Dim result As Boolean = False
        Try
            RemoveErrorIcon()

            If TxtCategory.Text.Trim = "" Then
                ErrorInData("Please enter category.", TxtCategory)
                Exit Try
            End If

            'If CmbPI.Text.Trim = "" Then
            '    ErrorInData("Please select PI.", CmbPI)
            '    Exit Try
            'End If

            result = True

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Sub ResetControlsToAddNew()
        TxtCategory.Text = ""
        'If CmbPI.Items.Count > 0 Then CmbPI.SelectedIndex = 0
        BtnAdd.Enabled = True
        BtnUpdate.Enabled = False
        BtnCancel.Enabled = False
        RemoveErrorIcon()

        editRow = Nothing

        TxtCategory.Focus()
    End Sub

    Private Function NameExistInGrid(ByVal name As String) As Boolean
        Dim result As Boolean = False
        Try
            name = name.Trim
            If GrdCategoryDetails.RowCount = 0 Then Exit Try

            If name = "" Then Exit Try

            Dim row As DataGridViewRow
            For Each row In GrdCategoryDetails.Rows
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
