Imports System.Windows.Forms
Imports AIMS.Author

Public Class FrmItemMaster

#Region "Local variables and Constants"

    Dim editRow As DataGridViewRow = Nothing
    Dim flagChange As Boolean = False

    'Private Const lcGeneric1 As String = "Generic1"
    'Private Const lcGeneric2 As String = "Generic2"
    'Private Const lcGeneric3 As String = "Generic3"
    'Private Const lcPIName As String = "PI Name"
    Private Const lcManufacturer As String = "Manufacturer"
    Private Const lcCategory As String = "Category"

    Enum Index
        GrpItem = 0
        TxtItemCode
        TxtName
        CmbCategory
        TxtVATRate
        CmbPackType
        CmbSchedule
        CmbGeneric1
        CmbGeneric2
        CmbGeneric3
        CmbManufacturer
        CmbStorage
        'CmbPI
        TxtMin
        BtnAdd
        BtnUpdate
        BtnCancel
        BtnClose
        GrpSearch
        CmbFieldToSearch
        TxtLikeValue
        GrpItems
        GrdItems
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

    Private Sub FrmItemMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

    Private Sub TxtVATRate_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtVATRate.KeyPress
        e.Handled = Check_DecimalAllow(e.KeyChar, sender.text)
    End Sub

    Private Sub CmbPackType_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbPackType.KeyPress
        'AutoComplete(CmbPackType, e)
    End Sub

    Private Sub TxtMin_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtMin.KeyPress
        e.Handled = Check_DecimalAllow(e.KeyChar, sender.text)
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.Items_NoAdd) = True Then Exit Sub
            If ValidateValues() = False Then Exit Sub

            Dim categoryId As Integer = GetSelectedItemId(CmbCategory)
            If NameExistInGrid(TxtName.Text, categoryId) = True Then
                ErrorInData("Item name already present.", TxtName)
                Exit Sub
            End If

            Dim item As New ClsItemMaster
            With item
                .CategoryId = categoryId
                .DateOn = Now
                .GenericId1 = GetSelectedItemId(CmbGeneric1)
                .GenericId2 = GetSelectedItemId(CmbGeneric2)
                .GenericId3 = GetSelectedItemId(CmbGeneric3)
                .ItemCode = TxtItemCode.Text
                .ManufacturerId = GetSelectedItemId(CmbManufacturer)
                .Minimum = Val(TxtMin.Text)
                .Name = GetName()
                .NameFirst = TxtName.Text.Trim
                .PackType = CmbPackType.Text
                '.PIId = GetSelectedItemId(CmbPI)
                .ScheduleId = GetSelectedItemId(CmbSchedule)
                .StorageId = GetSelectedItemId(CmbStorage)
                .UserId = gUser.LoginName
                .VAT = Val(TxtVATRate.Text)
            End With

            Dim id As Integer = InsertIntoItemMaster(Me.Name, item)
            If id > 0 Then
                LoadGridValues()
                flagChange = True
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
            If AndedTheString(gUser.AuthorizationNo, Authorization.Items_NoUpdate) = True Then Exit Sub
            If editRow Is Nothing Then Exit Try
            If ValidateValues() = False Then Exit Sub

            Dim item As New ClsItemMaster
            With item
                .CategoryId = GetSelectedItemId(CmbCategory)
                .DateOn = editRow.Cells(cDateOn).Value
                .GenericId1 = GetSelectedItemId(CmbGeneric1)
                .GenericId2 = GetSelectedItemId(CmbGeneric2)
                .GenericId3 = GetSelectedItemId(CmbGeneric3)
                .ItemCode = TxtItemCode.Text
                .ManufacturerId = GetSelectedItemId(CmbManufacturer)
                .Minimum = Val(TxtMin.Text)
                .Name = GetName()
                .NameFirst = TxtName.Text.Trim
                .PackType = CmbPackType.Text
                '.PIId = GetSelectedItemId(CmbPI)
                .ScheduleId = GetSelectedItemId(CmbSchedule)
                .StorageId = GetSelectedItemId(CmbStorage)
                .UserId = editRow.Cells(cUserId).Value
                .VAT = Val(TxtVATRate.Text)
                .Id = editRow.Cells(cId).Value
            End With

            If ItemMasterUpdatable(Me.Name, item) = False Then
                ErrorInData("Item name already present with other id.", TxtName)
                Exit Sub
            End If

            If UpdateItemMaster(Me.Name, item) <> EnResult.Change Then Exit Sub

            flagChange = True
            With editRow
                .Cells(cCategoryId).Value = GetSelectedItemId(CmbCategory)
                '.Cells(cGenericId1).Value = GetSelectedItemId(CmbGeneric1)
                '.Cells(cGenericId2).Value = GetSelectedItemId(CmbGeneric2)
                '.Cells(cGenericId3).Value = GetSelectedItemId(CmbGeneric3)
                .Cells(cCategory).Value = CmbCategory.Text
                '.Cells(lcGeneric1).Value = CmbGeneric1.Text
                '.Cells(lcGeneric2).Value = CmbGeneric2.Text
                '.Cells(lcGeneric3).Value = CmbGeneric3.Text
                .Cells(cItemCode).Value = TxtItemCode.Text
                .Cells(cManufacturerId).Value = GetSelectedItemId(CmbManufacturer)
                .Cells(cManufacturer).Value = CmbManufacturer.Text
                .Cells(cMinimum).Value = Val(TxtMin.Text)
                .Cells(cName).Value = GetName()
                .Cells(cNameFirst).Value = TxtName.Text.Trim
                .Cells(cPackType).Value = CmbPackType.Text
                '.Cells(cPIId).Value = GetSelectedItemId(CmbPI)
                '.Cells(cScheduleId).Value = GetSelectedItemId(CmbSchedule)
                .Cells(cStorageId).Value = GetSelectedItemId(CmbStorage)
                '.Cells(cPI).Value = CmbPI.Text
                '.Cells(cSchedule).Value = CmbSchedule.Text
                .Cells(cStorage).Value = CmbStorage.Text
                .Cells(cVAT).Value = Val(TxtVATRate.Text)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNew()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub CmbFieldToSearch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbFieldToSearch.SelectedIndexChanged
        TxtLikeValue.Text = ""
    End Sub

    Private Sub TxtLikeValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLikeValue.TextChanged
        Dim valueLike As String = TxtLikeValue.Text.Trim
        If valueLike = "" Then
            LoadGridValues()
        Else
            LoadGridValuesWithSearchLike(valueLike)
        End If
    End Sub

    Private Sub GrdItems_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdItems.CellDoubleClick
        Try
            If e.RowIndex < 0 Then Exit Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.Items_NoUpdate) = True Then Exit Sub

            editRow = GrdItems.Rows(e.RowIndex)
            With editRow
                TxtItemCode.Text = .Cells(cItemCode).Value
                TxtName.Text = .Cells(cNameFirst).Value
                TxtVATRate.Text = .Cells(cVAT).Value
                CmbPackType.Text = .Cells(cPackType).Value
                'CmbGeneric1.Text = .Cells(lcGeneric1).Value
                'CmbGeneric2.Text = .Cells(lcGeneric2).Value
                'CmbGeneric3.Text = .Cells(lcGeneric3).Value
                'CmbPI.Text = .Cells(cPI).Value
                CmbManufacturer.Text = .Cells(cManufacturer).Value
                CmbCategory.Text = .Cells(cCategory).Value
                'CmbSchedule.Text = .Cells(cSchedule).Value
                CmbStorage.Text = .Cells(cStorage).Value
                TxtMin.Text = .Cells(cMinimum).Value
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

    Private Sub GrdItems_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdItems.KeyDown
        If e.KeyCode = Keys.Tab Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtVATRate.KeyDown, TxtName.KeyDown, TxtMin.KeyDown, TxtLikeValue.KeyDown, TxtItemCode.KeyDown, CmbStorage.KeyDown, CmbSchedule.KeyDown, CmbPackType.KeyDown, CmbManufacturer.KeyDown, CmbGeneric3.KeyDown, CmbGeneric2.KeyDown, CmbGeneric1.KeyDown, CmbFieldToSearch.KeyDown, CmbCategory.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

#End Region

#Region "Other Form Functionality"

    Private Sub LblAddStorage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblAddStorage.Click
        'If AndedTheString(gUser.AuthorizationNo, Authorization.Storage) = False Then Exit Sub
        Try
            Dim frm As New FrmStorageMaster
            frm.ShowDialog(Me)
            If frm.Change = True Then LoadComboBoxValuesForStorage()

            frm.Dispose()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LblAddGeneric_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblAddGeneric.Click
        'If AndedTheString(gUser.AuthorizationNo, Authorization.Generics) = False Then Exit Sub
        Try
            Dim frm As New FrmGenericMaster
            frm.ShowDialog(Me)
            If frm.Change = True Then
                LoadComboBoxValuesForGeneric1()
                LoadComboBoxValuesForGeneric2()
                LoadComboBoxValuesForGeneric3()
            End If

            frm.Dispose()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LblAddManufacturer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblAddManufacturer.Click
        If AndedTheString(gUser.AuthorizationNo, Authorization.Manufacturers) = False Then Exit Sub
        Try
            Dim frm As New FrmManufacturerMaster
            frm.ShowDialog(Me)
            If frm.Change = True Then LoadComboBoxValuesForManufacturer()

            frm.Dispose()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LblAddSchedule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblAddSchedule.Click
        'If AndedTheString(gUser.AuthorizationNo, Authorization.Schedule) = False Then Exit Sub
        Try
            Dim frm As New FrmScheduleMaster
            frm.ShowDialog(Me)
            If frm.Change = True Then LoadComboBoxValuesForSchedule()

            frm.Dispose()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LblAddCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblAddCategory.Click
        If AndedTheString(gUser.AuthorizationNo, Authorization.Category) = False Then Exit Sub
        Try
            Dim frm As New FrmCategoryMaster
            frm.ShowDialog(Me)
            If frm.Change = True Then LoadComboBoxValuesForCategory()

            frm.Dispose()

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

#Region "Private Functions"

    Private Sub SetControls()
        With CmbFieldToSearch
            .Items.Clear()
            .Items.Add(cName)
            .Items.Add(cPackType)
            '.Items.Add(lcGeneric1)
            '.Items.Add(lcGeneric2)
            '.Items.Add(lcGeneric3)
            '.Items.Add(lcPIName)
            .Items.Add(lcManufacturer)
            .Items.Add(lcCategory)
            .SelectedIndex = 0
        End With

        SetTabIndex()
        SetGrid()
        LoadComboBoxValuesForManufacturer()
        LoadComboBoxValuesForCategory()
        LoadComboBoxValuesForGeneric1()
        LoadComboBoxValuesForGeneric2()
        LoadComboBoxValuesForGeneric3()
        LoadComboBoxValuesForSchedule()
        LoadComboBoxValuesForStorage()
        'LoadComboBoxValuesForPI()

        LoadGridValues()

        ResetControlsToAddNew()
    End Sub

    Private Sub SetTabIndex()
        GrpItem.TabIndex = Index.GrpItem
        TxtItemCode.TabIndex = Index.TxtItemCode
        TxtName.TabIndex = Index.TxtName
        TxtVATRate.TabIndex = Index.TxtVATRate
        CmbPackType.TabIndex = Index.CmbPackType
        CmbSchedule.TabIndex = Index.CmbSchedule
        CmbGeneric1.TabIndex = Index.CmbGeneric1
        CmbGeneric2.TabIndex = Index.CmbGeneric2
        CmbGeneric3.TabIndex = Index.CmbGeneric3
        CmbManufacturer.TabIndex = Index.CmbManufacturer
        CmbCategory.TabIndex = Index.CmbCategory
        CmbStorage.TabIndex = Index.CmbStorage
        'CmbPI.TabIndex = Index.CmbPI
        TxtMin.TabIndex = Index.TxtMin
        BtnAdd.TabIndex = Index.BtnAdd
        BtnUpdate.TabIndex = Index.BtnUpdate
        BtnCancel.TabIndex = Index.BtnCancel
        BtnClose.TabIndex = Index.BtnClose
        GrpSearch.TabIndex = Index.GrpSearch
        CmbFieldToSearch.TabIndex = Index.CmbFieldToSearch
        TxtLikeValue.TabIndex = Index.TxtLikeValue
        GrpItems.TabIndex = Index.GrpItems
        GrdItems.TabIndex = Index.GrdItems
    End Sub

    Private Sub SetGrid()
        With GrdItems
            Dim colCount As Integer = 23
            Dim defaultColWidth As Integer = 85
            .RowHeadersVisible = False
            Dim x As Integer
            For x = 0 To colCount
                Select Case x
                    Case 0
                        Dim index As Integer = .Columns.Add(cId, cId)
                        .Columns(index).Visible = False

                    Case 1
                        Dim index As Integer = .Columns.Add(cItemCode, "Code")
                        .Columns(index).Width = 90

                    Case 2
                        Dim index As Integer = .Columns.Add(cNameFirst, cName)
                        .Columns(index).Width = 125

                    Case 3
                        Dim index As Integer = .Columns.Add(cCategory, cCategory)
                        .Columns(index).Width = defaultColWidth

                    Case 4
                        Dim index As Integer = .Columns.Add(cVAT, cVAT)
                        .Columns(index).Width = defaultColWidth

                    Case 5
                        Dim index As Integer = .Columns.Add(cPackType, "P. Type")
                        .Columns(index).Width = defaultColWidth

                        'Case 6
                        '    Dim index As Integer = .Columns.Add(lcGeneric1, lcGeneric1)
                        '    .Columns(index).Width = defaultColWidth

                        'Case 7
                        '    Dim index As Integer = .Columns.Add(lcGeneric2, lcGeneric2)
                        '    .Columns(index).Width = defaultColWidth

                        'Case 8
                        '    Dim index As Integer = .Columns.Add(lcGeneric3, lcGeneric3)
                        '    .Columns(index).Width = defaultColWidth

                        'Case 9
                        '    Dim index As Integer = .Columns.Add(cGenericId1, cGenericId1)
                        '    .Columns(index).Visible = False

                        'Case 10
                        '    Dim index As Integer = .Columns.Add(cGenericId2, cGenericId2)
                        '    .Columns(index).Visible = False

                        'Case 11
                        '    Dim index As Integer = .Columns.Add(cGenericId3, cGenericId3)
                        '    .Columns(index).Visible = False

                    Case 12
                        Dim index As Integer = .Columns.Add(cName, cName)
                        .Columns(index).Visible = False
                        'Dim index As Integer = .Columns.Add(cPIId, cPIId)
                        '.Columns(index).Visible = False

                    Case 16
                        'Dim index As Integer = .Columns.Add(cPI, cPI)
                        '.Columns(index).Width = defaultColWidth

                    Case 13
                        Dim index As Integer = .Columns.Add(cManufacturerId, cManufacturerId)
                        .Columns(index).Visible = False

                    Case 14
                        Dim index As Integer = .Columns.Add(cManufacturer, cManufacturer)
                        .Columns(index).Width = defaultColWidth

                    Case 15
                        Dim index As Integer = .Columns.Add(cCategoryId, cCategoryId)
                        .Columns(index).Visible = False

                        'Case 17
                        '    Dim index As Integer = .Columns.Add(cScheduleId, cScheduleId)
                        '    .Columns(index).Visible = False

                        'Case 18
                        '    Dim index As Integer = .Columns.Add(cSchedule, cSchedule)
                        '    .Columns(index).Width = defaultColWidth

                    Case 19
                        Dim index As Integer = .Columns.Add(cStorageId, cStorageId)
                        .Columns(index).Visible = False

                    Case 20
                        Dim index As Integer = .Columns.Add(cStorage, cStorage)
                        .Columns(index).Width = defaultColWidth

                    Case 21
                        Dim index As Integer = .Columns.Add(cMinimum, cMinimum)
                        .Columns(index).Width = defaultColWidth

                    Case 22
                        Dim index As Integer = .Columns.Add(cUserId, cUserId)
                        .Columns(index).Visible = False

                    Case 23
                        Dim index As Integer = .Columns.Add(cDateOn, cDateOn)
                        .Columns(index).Visible = False

                End Select
            Next
        End With
    End Sub

    Private Sub LoadGridValues()
        Try
            GrdItems.Rows.Clear()
            Dim items() As ClsItemMaster = GetAllItemMaster(Me.Name, True)
            If items Is Nothing Then Exit Try

            Dim item As ClsItemMaster
            For Each item In items
                InsertIntoGrid(item)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadGridValuesWithSearchLike(ByVal txtLike As String)
        Try
            GrdItems.Rows.Clear()

            Dim field As String = ""
            If CmbFieldToSearch.Text = cPackType Then
                field = cPackType
            ElseIf CmbFieldToSearch.Text = cName Then
                field = cNameFirst
                'ElseIf CmbFieldToSearch.Text = lcGeneric1 Then
                '    field = cGenericId1
                'ElseIf CmbFieldToSearch.Text = lcGeneric2 Then
                '    field = cGenericId2
                'ElseIf CmbFieldToSearch.Text = lcGeneric3 Then
                '    field = cGenericId3
                'ElseIf CmbFieldToSearch.Text = lcPIName Then
                '    field = cPIId
            ElseIf CmbFieldToSearch.Text = lcManufacturer Then
                field = cManufacturerId
            ElseIf CmbFieldToSearch.Text = lcCategory Then
                field = cCategoryId
            End If

            Dim items() As ClsItemMaster = GetAllItemMasterLike(Me.Name, field, txtLike)
            If items Is Nothing Then Exit Try

            Dim item As ClsItemMaster
            For Each item In items
                InsertIntoGrid(item)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadComboBoxValuesForManufacturer()
        Try
            CmbManufacturer.Items.Clear()

            Dim manufacturers() As ClsManufacturerMaster = GetAllManufacturerMaster(Me.Name)
            If manufacturers Is Nothing Then Exit Try

            Dim manufacturer As ClsManufacturerMaster
            For Each manufacturer In manufacturers
                AddItemToComboBox(manufacturer.Name, manufacturer.Id, CmbManufacturer)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadComboBoxValuesForSchedule()
        Try
            CmbSchedule.Items.Clear()

            Dim schedules() As ClsScheduleMaster = GetAllScheduleMaster(Me.Name)
            If schedules Is Nothing Then Exit Try

            Dim schedule As ClsScheduleMaster
            For Each schedule In schedules
                AddItemToComboBox(schedule.Name, schedule.Id, CmbSchedule)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadComboBoxValuesForCategory()
        Try
            CmbCategory.Items.Clear()

            Dim categories() As ClsCategoryMaster = GetAllCategoryMaster(Me.Name)
            If categories Is Nothing Then Exit Try

            Dim category As ClsCategoryMaster
            For Each category In categories
                AddItemToComboBox(category.Name, category.Id, CmbCategory)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadComboBoxValuesForStorage()
        Try
            CmbStorage.Items.Clear()

            Dim storages() As ClsStorageMaster = GetAllStorageMaster(Me.Name)
            If storages Is Nothing Then Exit Try

            Dim storage As ClsStorageMaster
            For Each storage In storages
                AddItemToComboBox(storage.Name, storage.Id, CmbStorage)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadComboBoxValuesForGeneric1()
        Try
            CmbGeneric1.Items.Clear()

            Dim generics() As ClsGenericMaster = GetAllGenericMaster(Me.Name)
            If generics Is Nothing Then Exit Try

            Dim generic As ClsGenericMaster
            For Each generic In generics
                AddItemToComboBox(generic.Name, generic.Id, CmbGeneric1)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadComboBoxValuesForGeneric2()
        Try
            CmbGeneric2.Items.Clear()

            Dim generics() As ClsGenericMaster = GetAllGenericMaster(Me.Name)
            If generics Is Nothing Then Exit Try

            Dim generic As ClsGenericMaster
            For Each generic In generics
                AddItemToComboBox(generic.Name, generic.Id, CmbGeneric2)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadComboBoxValuesForGeneric3()
        Try
            CmbGeneric3.Items.Clear()

            Dim generics() As ClsGenericMaster = GetAllGenericMaster(Me.Name)
            If generics Is Nothing Then Exit Try

            Dim generic As ClsGenericMaster
            For Each generic In generics
                AddItemToComboBox(generic.Name, generic.Id, CmbGeneric3)
            Next

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
    '            AddItemToComboBox(pi.Name, pi.Id, CmbPI)
    '        Next

    '    Catch ex As Exception
    '        AddToLog(ex)
    '    End Try
    'End Sub

    Private Sub InsertIntoPackType(ByVal packType As String)
        Try
            packType = packType.Trim

            If packType = "" Then Exit Try
            If CmbPackType.FindStringExact(packType) >= 0 Then Exit Try

            CmbPackType.Items.Add(packType)

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub InsertIntoGrid(ByRef itemObj As ClsItemMaster)
        Try
            If itemObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdItems.Rows.Add
            With GrdItems.Rows(rowIndex)
                .Cells(cId).Value = itemObj.Id
                .Cells(cName).Value = itemObj.Name
                .Cells(cNameFirst).Value = itemObj.NameFirst
                .Cells(cUserId).Value = itemObj.UserId
                .Cells(cDateOn).Value = itemObj.DateOn
                .Cells(cItemCode).Value = itemObj.ItemCode
                .Cells(cVAT).Value = itemObj.VAT
                .Cells(cPackType).Value = itemObj.PackType
                '.Cells(cGenericId1).Value = itemObj.GenericId1
                '.Cells(cGenericId2).Value = itemObj.GenericId2
                '.Cells(cGenericId3).Value = itemObj.GenericId3
                '.Cells(cPIId).Value = itemObj.PIId
                .Cells(cManufacturerId).Value = itemObj.ManufacturerId
                .Cells(cCategoryId).Value = itemObj.CategoryId
                '.Cells(cScheduleId).Value = itemObj.ScheduleId
                .Cells(cStorageId).Value = itemObj.StorageId
                .Cells(cMinimum).Value = itemObj.Minimum
                .Cells(cStorage).Value = GetTextForValue(CmbStorage, .Cells(cStorageId).Value)
                '.Cells(cSchedule).Value = GetTextForValue(CmbSchedule, .Cells(cScheduleId).Value)
                .Cells(cCategory).Value = GetTextForValue(CmbCategory, .Cells(cCategoryId).Value)
                .Cells(cManufacturer).Value = GetTextForValue(CmbManufacturer, .Cells(cManufacturerId).Value)
                '.Cells(cPI).Value = GetTextForValue(CmbPI, .Cells(cPIId).Value)
                '.Cells(lcGeneric1).Value = GetTextForValue(CmbGeneric1, .Cells(cGenericId1).Value)
                '.Cells(lcGeneric2).Value = GetTextForValue(CmbGeneric2, .Cells(cGenericId2).Value)
                '.Cells(lcGeneric3).Value = GetTextForValue(CmbGeneric3, .Cells(cGenericId3).Value)

                InsertIntoPackType(.Cells(cPackType).Value)
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
                ErrorInData("Please enter Item name.", TxtName)
                Exit Try
            End If

            If CmbCategory.Text.Trim = "" Then
                ErrorInData("Please select Category.", CmbCategory)
                Exit Try
            End If

            If CmbPackType.Text.Trim = "" Then
                ErrorInData("Please select Pack Type.", CmbPackType)
                Exit Try
            End If

            'If CmbSchedule.Text.Trim = "" Then
            '    ErrorInData("Please select Schedule.", CmbSchedule)
            '    Exit Try
            'End If

            'If CmbGeneric1.Text.Trim = "" Then
            '    ErrorInData("Please select generic.", CmbGeneric1)
            '    Exit Try
            'End If

            'If CmbManufacturer.Text.Trim = "" Then
            '    ErrorInData("Please select Manufacturer.", CmbManufacturer)
            '    Exit Try
            'End If

            result = True

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Sub ResetControlsToAddNew()
        TxtItemCode.Text = ""
        TxtName.Text = ""
        TxtVATRate.Text = ""
        CmbPackType.Text = ""
        RefillComboBox(CmbSchedule)
        RefillComboBox(CmbGeneric1)
        RefillComboBox(CmbGeneric2)
        RefillComboBox(CmbGeneric3)
        RefillComboBox(CmbManufacturer)
        RefillComboBox(CmbCategory)
        RefillComboBox(CmbStorage)
        'RefillComboBox(CmbPI)
        TxtMin.Text = ""
        CmbFieldToSearch.SelectedIndex = 0
        TxtLikeValue.Text = ""
        RemoveErrorIcon()

        BtnAdd.Enabled = True
        BtnUpdate.Enabled = False
        BtnCancel.Enabled = False
        GrpSearch.Enabled = True

        editRow = Nothing

        TxtName.Focus()
    End Sub

    Private Function NameExistInGrid(ByVal name As String, ByVal forCategoryId As Integer) As Boolean
        Dim result As Boolean = False
        Try
            name = name.Trim
            If GrdItems.RowCount = 0 Then Exit Try

            If name = "" Then Exit Try

            Dim row As DataGridViewRow
            For Each row In GrdItems.Rows
                If row.Cells(cNameFirst).Value = name And row.Cells(cCategoryId).Value = forCategoryId Then
                    result = True
                    Exit Try
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Function GetName() As String
        Return TxtName.Text.Trim + " " + CmbCategory.Text
    End Function

#End Region

End Class
