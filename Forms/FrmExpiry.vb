Imports System.Windows.Forms
Imports AIMS.Author

Public Class FrmExpiry

#Region "Local variables and Constants"

    Dim editRow As DataGridViewRow = Nothing
    Dim lStorages() As ClsStorageMaster = Nothing
    Dim lCurrentStocks() As ClsCurrentStock = Nothing
    Dim lItems() As ClsItemMaster = Nothing

    Enum Index
        GrpItem
        DtPkrItemsExpiryDate
        BtnReloadItems
        CmbItem
        TxtQuantity
        TxtRemark
        BtnAdd
        GrdItems
        GrpItemsOnSlip
        GrdItemsOnSlip
        GrpButtons
        BtnRemove
        BtnUpdate
        BtnCancel
        BtnClose
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

    Private Sub FrmExpiry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

    Private Sub CmbItem_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbItem.TextChanged
        LoadGridValuesForItems()
    End Sub

    Private Sub TxtQuantity_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtQuantity.KeyPress
        e.Handled = Check_DecimalAllow(e.KeyChar, sender.text)
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.ExpirySlips_NoAdd) = True Then Exit Sub
            If ValidateValues() = False Then Exit Sub

            'Saving Detail
            Dim expiryDetailObj As New ClsExpiryDetail
            With expiryDetailObj
                Dim currentStock As ClsCurrentStock = CmbItem.SelectedItem
                If currentStock Is Nothing Then
                    MsgBox("Item is not selected or Batch doesn't exist", , "Item")
                    Exit Sub
                End If

                .ItemId = currentStock.ItemId
                .Batch = currentStock.Batch
                .ExpiryDate = currentStock.ExpiryDate
                .PackQuantity = currentStock.PackQuantity
                .PricePurchase = currentStock.PricePurchase
                .PriceSale = 0 'currentStock.PriceSale
                .Quantity = Val(TxtQuantity.Text)
                .StorageId = currentStock.StorageId
                .Remark = TxtRemark.Text
                .UserId = gUser.LoginName
                .DateOn = Now
                SetTaxAndDiscountAmount(.TaxAmount, .DiscountAmount, .Quantity, .ItemId, .Batch)
            End With

            Dim id As Long = InsertIntoExpiryDetail(Me.Name, expiryDetailObj)
            If id > 0 Then
                expiryDetailObj.Id = id
                InsertIntoExpiryGrid(expiryDetailObj)
            End If

            MsgBox("Successfully Added", , "Added")

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNewItem()
    End Sub

    Private Sub GrdItems_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdItems.CellClick
        Try
            If e.RowIndex < 0 Then Exit Try

            With GrdItems.Rows(e.RowIndex)
                If .Cells(cName).Value.ToString.Trim = "" Or .Cells(cBatch).Value.ToString.Trim = "" Then Exit Try

                TxtQuantity.Text = .Cells(cCurrentQuantity).Value
                CmbItem.Text = .Cells(cName).Value '+ "[" + .Cells(cBatch).Value + "]"
            End With

            CmbItem.Focus()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub GrdItems_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdItems.KeyDown
        If e.KeyCode = Keys.Tab Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub GrdItemsOnSlip_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdItemsOnSlip.CellClick
        If e.RowIndex < 0 Then Exit Sub
        If AndedTheString(gUser.AuthorizationNo, Authorization.ExpirySlips_NoRemove) = True Then Exit Sub

        BtnRemove.Enabled = True
        BtnCancel.Enabled = True
        BtnAdd.Enabled = False
        BtnReloadItems.Enabled = False
        BtnUpdate.Enabled = False
    End Sub

    Private Sub GrdItemsOnSlip_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdItemsOnSlip.CellDoubleClick
        Try
            If e.RowIndex < 0 Then Exit Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.ExpirySlips_NoUpdate) = True Then Exit Sub

            BtnRemove.Enabled = False
            LoadComboBoxValuesForItems(False)
            editRow = GrdItemsOnSlip.Rows(e.RowIndex)
            With editRow
                Dim str As String = .Cells(cName).Value '+ "[" + .Cells(cBatch).Value + "]"
                CmbItem.Text = str
                TxtQuantity.Text = .Cells(cQuantity).Value
            End With

            BtnRemove.Enabled = False
            BtnCancel.Enabled = True
            BtnAdd.Enabled = False
            BtnReloadItems.Enabled = False
            BtnUpdate.Enabled = True

            CmbItem.Focus()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub GrdItemsOnSlip_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdItemsOnSlip.KeyDown
        If e.KeyCode = Keys.Tab Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub BtnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemove.Click
        Try
            Dim row As DataGridViewRow = GrdItemsOnSlip.SelectedRows(0)
            If row Is Nothing Then Exit Try

            If AndedTheString(gUser.AuthorizationNo, Authorization.ExpirySlips_NoRemove) = True Then Exit Sub

            Dim id As Long = row.Cells(cId).Value
            If id <= 0 Then Exit Try

            If MsgBox("Do you really wants to remove selected record? Removed records can't be recovered.", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                If DeleteExpiryDetail(Me.Name, id) <> EnResult.Change Then Exit Sub

                GrdItemsOnSlip.Rows.Remove(row)
                MsgBox("Successfully Removed", , "Removed")
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNewItem()
    End Sub

    Private Sub BtnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUpdate.Click
        Try
            If editRow Is Nothing Then Exit Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.ExpirySlips_NoUpdate) = True Then Exit Sub

            If ValidateValues() = False Then Exit Sub

            Dim currentStock As ClsCurrentStock = GetSelectedItem(CmbItem)
            If currentStock Is Nothing Then Exit Try

            'Updating Detail
            Dim expiryDetailObj As New ClsExpiryDetail
            With expiryDetailObj
                .Id = editRow.Cells(cId).Value
                .ItemId = currentStock.ItemId
                .PriceSale = 0 'currentStock.PriceSale
                .Quantity = Val(TxtQuantity.Text)
                .Batch = currentStock.Batch
                .ExpiryDate = currentStock.ExpiryDate
                .PricePurchase = currentStock.PricePurchase
                .PackQuantity = currentStock.PackQuantity
                .StorageId = currentStock.StorageId
                .Remark = TxtRemark.Text
                .UserId = gUser.LoginName
                .DateOn = Now
                SetTaxAndDiscountAmount(.TaxAmount, .DiscountAmount, .Quantity, .ItemId, .Batch)
            End With

            If UpdateExpiryDetail(Me.Name, expiryDetailObj) <> EnResult.Change Then Exit Sub

            With editRow
                .Cells(cItemId).Value = expiryDetailObj.ItemId
                .Cells(cStorageId).Value = expiryDetailObj.StorageId
                .Cells(cBatch).Value = expiryDetailObj.Batch
                .Cells(cExpiryDate).Value = expiryDetailObj.ExpiryDate
                .Cells(cQuantity).Value = expiryDetailObj.Quantity
                .Cells(cPriceSale).Value = expiryDetailObj.PriceSale
                .Cells(cPackQuantity).Value = expiryDetailObj.PackQuantity
                .Cells(cTaxPercent).Value = expiryDetailObj.TaxPercent
                .Cells(cTaxAmount).Value = expiryDetailObj.TaxAmount
                .Cells(cDiscountPercent).Value = expiryDetailObj.DiscountPercent
                .Cells(cDiscountAmount).Value = expiryDetailObj.DiscountAmount
                .Cells(cTotal).Value = expiryDetailObj.GetTotal
                .Cells(cStorage).Value = GetStorageName(.Cells(cStorageId).Value)
                .Cells(cName).Value = GetItemMasterName(.Cells(cItemId).Value)
                .Cells(cPricePurchase).Value = expiryDetailObj.PricePurchase
                .Cells(cRemark).Value = expiryDetailObj.Remark
                .Cells(cUserId).Value = expiryDetailObj.UserId
                .Cells(cDateOn).Value = expiryDetailObj.DateOn
            End With

            MsgBox("Successfully Updated", , "Updated")

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNewItem()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        ResetControlsToAddNewItem()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub BtnReloadItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReloadItems.Click
        LoadComboBoxValues()
        LoadStorages()
        LoadGridValuesForItems()
    End Sub

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtRemark.KeyDown, TxtQuantity.KeyDown, CmbItem.KeyDown, DtPkrItemsExpiryDate.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

#End Region

#Region "Private Function"

    Private Sub SetControls()
        DtPkrItemsExpiryDate.Value = GetMonthDate(Now)
        SetTabIndex()
        SetGridForExpirySlip()
        SetGridForItems()
        ResetControlsToAddNewItem()
        LoadItems()
        LoadComboBoxValues()
        LoadStorages()

        'Load Grid values after ComboBox Values
        LoadGridValuesForItems()
        LoadGridValuesForExpiry()
    End Sub

    Private Sub SetTabIndex()
        GrpItem.TabIndex = Index.GrpItem
        DtPkrItemsExpiryDate.TabIndex = Index.DtPkrItemsExpiryDate
        BtnReloadItems.TabIndex = Index.BtnReloadItems
        CmbItem.TabIndex = Index.CmbItem
        TxtQuantity.TabIndex = Index.TxtQuantity
        BtnAdd.TabIndex = Index.BtnAdd
        BtnRemove.TabIndex = Index.BtnRemove
        GrdItems.TabIndex = Index.GrdItems
        GrpItemsOnSlip.TabIndex = Index.GrpItemsOnSlip
        GrdItemsOnSlip.TabIndex = Index.GrdItemsOnSlip
        GrpButtons.TabIndex = Index.GrpButtons
        TxtRemark.TabIndex = Index.TxtRemark
        BtnUpdate.TabIndex = Index.BtnUpdate
        BtnCancel.TabIndex = Index.BtnCancel
        BtnClose.TabIndex = Index.BtnClose
    End Sub

    Private Sub SetGridForExpirySlip()
        With GrdItemsOnSlip
            Dim colCount As Integer = 18
            .RowHeadersVisible = False
            Dim defaultCellWidth As Integer = 110
            Dim x As Integer
            For x = 0 To colCount
                Select Case x
                    Case 0
                        Dim index As Integer = .Columns.Add(cId, cId)
                        .Columns(index).Visible = False

                    Case 1
                        Dim index As Integer = .Columns.Add(cName, cName)
                        .Columns(index).Width = 330

                    Case 2
                        Dim index As Integer = .Columns.Add(cBatch, cBatch)
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).Visible = False

                    Case 3
                        Dim index As Integer = .Columns.Add(cExpiryDate, "Expiry Date")
                        .Columns(index).Width = defaultCellWidth + 30
                        .Columns(index).DefaultCellStyle.Format = "yyyy-MMM"
                        .Columns(index).Visible = False

                    Case 4
                        Dim index As Integer = .Columns.Add(cQuantity, "Expiry Qty")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 5
                        Dim index As Integer = .Columns.Add(cPricePurchase, "Pur. Price")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 6
                        Dim index As Integer = .Columns.Add(cPackQuantity, "Pack Qty.")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 7
                        Dim index As Integer = .Columns.Add(cTaxPercent, "Tax %")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns(index).Visible = False

                    Case 8
                        Dim index As Integer = .Columns.Add(cTaxAmount, "Tax")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns(index).Visible = False

                    Case 9
                        Dim index As Integer = .Columns.Add(cDiscountPercent, "Dis. %")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns(index).Visible = False

                    Case 10
                        Dim index As Integer = .Columns.Add(cDiscountAmount, "Discount")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns(index).Visible = False

                    Case 11
                        Dim index As Integer = .Columns.Add(cStorage, cStorage)
                        .Columns(index).Visible = False
                        .Columns(index).Width = defaultCellWidth

                    Case 12
                        Dim index As Integer = .Columns.Add(cTotal, cTotal)
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 13
                        Dim index As Integer = .Columns.Add(cItemId, cItemId)
                        .Columns(index).Visible = False

                    Case 14
                        Dim index As Integer = .Columns.Add(cStorageId, cStorageId)
                        .Columns(index).Visible = False

                    Case 15
                        Dim index As Integer = .Columns.Add(cUserId, cUserId)
                        .Columns(index).Visible = False

                    Case 16
                        Dim index As Integer = .Columns.Add(cPriceSale, "S. Price")
                        .Columns(index).Visible = False

                    Case 17
                        Dim index As Integer = .Columns.Add(cRemark, cRemark)
                        .Columns(index).Visible = False

                    Case 18
                        Dim index As Integer = .Columns.Add(cDateOn, cDateOn)
                        .Columns(index).Visible = False

                End Select
            Next
        End With
    End Sub

    Private Sub SetGridForItems()
        With GrdItems
            Dim colCount As Integer = 9
            .RowHeadersVisible = False
            Dim defaultCellWidth As Integer = 110
            Dim x As Integer
            For x = 0 To colCount
                Select Case x
                    Case 0
                        Dim index As Integer = .Columns.Add(cId, cId)
                        .Columns(index).Visible = False

                    Case 1
                        Dim index As Integer = .Columns.Add(cName, cName)
                        .Columns(index).Width = 330

                    Case 2
                        Dim index As Integer = .Columns.Add(cBatch, cBatch)
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).Visible = False

                    Case 3
                        Dim index As Integer = .Columns.Add(cExpiryDate, "Expiry Date")
                        .Columns(index).Width = defaultCellWidth + 30
                        .Columns(index).DefaultCellStyle.Format = "yyyy-MMM"
                        .Columns(index).Visible = False

                    Case 4
                        Dim index As Integer = .Columns.Add(cCurrentQuantity, "Quantity")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 5
                        Dim index As Integer = .Columns.Add(cPricePurchase, "Pur. Price")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


                    Case 6
                        Dim index As Integer = .Columns.Add(cPackQuantity, "Pack Qty.")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 7
                        Dim index As Integer = .Columns.Add(cStorage, cStorage)
                        .Columns(index).Width = defaultCellWidth

                    Case 8
                        Dim index As Integer = .Columns.Add(cStorageId, cStorageId)
                        .Columns(index).Visible = False

                    Case 9
                        Dim index As Integer = .Columns.Add(cPriceSale, "S. Price")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns(index).Visible = False

                End Select
            Next
        End With
    End Sub

    Private Sub LoadGridValuesForExpiry()
        Try
            GrdItemsOnSlip.Rows.Clear()

            Dim expiryDetails() As ClsExpiryDetail = GetAllExpiryDetailBetweenDates(Me.Name, Now, Now)
            If expiryDetails Is Nothing Then Exit Try

            Dim expiryDetail As ClsExpiryDetail
            For Each expiryDetail In expiryDetails
                InsertIntoExpiryGrid(expiryDetail)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadGridValuesForItems()
        Try
            GrdItems.Rows.Clear()

            Dim str As String = CmbItem.Text.Trim
            Dim i As Integer = str.IndexOf("[")
            If i >= 0 Then
                str = str.Remove(i).Trim
            End If

            If str = "" Then
                Dim currentStock As ClsCurrentStock
                For Each currentStock In CmbItem.Items
                    InsertIntoItemGrid(currentStock)
                Next
            Else
                Dim currentStock As ClsCurrentStock
                For Each currentStock In CmbItem.Items
                    If UCase(currentStock.ItemName).StartsWith(UCase(str)) = True Then
                        InsertIntoItemGrid(currentStock)
                    End If
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub InsertIntoExpiryGrid(ByRef expiryDetailObj As ClsExpiryDetail)
        Try
            If expiryDetailObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdItemsOnSlip.Rows.Add
            With GrdItemsOnSlip.Rows(rowIndex)
                .Cells(cId).Value = expiryDetailObj.Id
                .Cells(cItemId).Value = expiryDetailObj.ItemId
                .Cells(cStorageId).Value = expiryDetailObj.StorageId
                .Cells(cBatch).Value = expiryDetailObj.Batch
                .Cells(cExpiryDate).Value = expiryDetailObj.ExpiryDate
                .Cells(cQuantity).Value = expiryDetailObj.Quantity
                .Cells(cPriceSale).Value = expiryDetailObj.PriceSale
                .Cells(cPackQuantity).Value = expiryDetailObj.PackQuantity
                .Cells(cTaxPercent).Value = expiryDetailObj.TaxPercent
                .Cells(cTaxAmount).Value = expiryDetailObj.TaxAmount
                .Cells(cDiscountPercent).Value = expiryDetailObj.DiscountPercent
                .Cells(cDiscountAmount).Value = expiryDetailObj.DiscountAmount
                .Cells(cTotal).Value = expiryDetailObj.GetTotal
                .Cells(cStorage).Value = GetStorageName(.Cells(cStorageId).Value)
                .Cells(cName).Value = GetItemMasterName(.Cells(cItemId).Value)
                .Cells(cPricePurchase).Value = expiryDetailObj.PricePurchase
                .Cells(cRemark).Value = expiryDetailObj.Remark
                .Cells(cUserId).Value = expiryDetailObj.UserId
                .Cells(cDateOn).Value = expiryDetailObj.DateOn
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub InsertIntoItemGrid(ByRef currentStockObj As ClsCurrentStock)
        Try
            If currentStockObj Is Nothing Then Exit Try

            Dim currentStock As ClsCurrentStock = GetCurrentStockForItemId(currentStockObj.ItemId, currentStockObj.Batch)
            If currentStock Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdItems.Rows.Add
            With GrdItems.Rows(rowIndex)
                .Cells(cId).Value = currentStockObj.ItemId
                .Cells(cName).Value = GetItemMasterName(currentStockObj.ItemId)
                .Cells(cStorageId).Value = currentStockObj.StorageId
                .Cells(cStorage).Value = GetStorageName(.Cells(cStorageId).Value)
                .Cells(cBatch).Value = currentStock.Batch
                .Cells(cExpiryDate).Value = currentStock.ExpiryDate
                .Cells(cCurrentQuantity).Value = currentStock.CurrentQuantity
                .Cells(cPriceSale).Value = 0 ' currentStock.PriceSale
                .Cells(cPricePurchase).Value = currentStock.PricePurchase
                .Cells(cPackQuantity).Value = currentStock.PackQuantity
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadComboBoxValues()
        LoadCurrentStocks()
        LoadComboBoxValuesForItems(True)
    End Sub

    Private Sub LoadComboBoxValuesForItems(ByVal ignoreExpiry As Boolean)
        Try
            CmbItem.Items.Clear()

            Dim currentStocks() As ClsCurrentStock = Nothing
            If ignoreExpiry = False Then
                currentStocks = GetAllCurrentStock(Me.Name, False, False)
            Else
                currentStocks = GetAllCurrentStockForExpiry(Me.Name, DtPkrItemsExpiryDate.Value)
            End If

            If currentStocks Is Nothing Then Exit Try

            CmbItem.DisplayMember = cItemName
            CmbItem.ValueMember = cId
            Dim currentStock As ClsCurrentStock
            For Each currentStock In currentStocks
                With currentStock
                    .SetName(GetItemMasterName(.ItemId))
                End With

                CmbItem.Items.Add(currentStock)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadItems()
        Try
            lItems = GetAllItemMaster(Me.Name, True)

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadStorages()
        Try
            lStorages = GetAllStorageMaster(Me.Name)

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadCurrentStocks()
        Try
            lCurrentStocks = GetAllCurrentStock(Me.Name, True)

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Function GetCurrentStockForItemId(ByVal itemId As Integer, ByVal batch As String) As ClsCurrentStock
        Dim result As ClsCurrentStock = Nothing
        Try
            If itemId <= 0 Or lCurrentStocks Is Nothing Then Exit Try

            batch = batch.Trim
            Dim currentStock As ClsCurrentStock
            For Each currentStock In lCurrentStocks
                If currentStock.ItemId = itemId And currentStock.Batch = batch Then
                    result = currentStock
                    Exit Try
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Function GetStorageName(ByVal id As Integer) As String
        Dim result As String = ""
        Try
            If lStorages Is Nothing Then Exit Try

            Dim storage As ClsStorageMaster
            For Each storage In lStorages
                If storage.Id = id Then
                    result = storage.Name
                    Exit Try
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    'Private Function GetItemName(ByVal id As Integer) As String
    '    Dim result As String = ""
    '    Try
    '        If lItems Is Nothing Then Exit Try

    '        Dim item As ClsItemMaster
    '        For Each item In lItems
    '            If item.Id = id Then
    '                result = item.Name
    '                Exit Try
    '            End If
    '        Next

    '    Catch ex As Exception
    '        AddToLog(ex)
    '    End Try

    '    Return result
    'End Function

    Private Function ValidateValues() As Boolean
        Dim result As Boolean = False
        Try
            RemoveErrorIcon()

            If CmbItem.Text.Trim = "" Then
                ErrorInData("Please select item.", CmbItem)
                Exit Try
            End If

            If CmbItem.FindStringExact(CmbItem.Text.Trim) < 0 Then
                ErrorInData("Please select valid item from item list.", CmbItem)
                Exit Try
            End If

            If TxtQuantity.Text.Trim = "" Then
                ErrorInData("Please enter quantity.", TxtQuantity)
                Exit Try
            End If

            If Val(TxtQuantity.Text) <= 0 Then
                ErrorInData("Please enter expiry quantity greater then 0.", TxtQuantity)
                Exit Try
            End If

            result = True

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Sub ResetControlsToAddNewItem()
        editRow = Nothing

        CmbItem.Text = ""
        TxtQuantity.Text = "0"
        TxtRemark.Text = ""

        BtnAdd.Enabled = True
        BtnReloadItems.Enabled = True
        BtnUpdate.Enabled = False
        BtnCancel.Enabled = False
        BtnRemove.Enabled = False

        CmbItem.Focus()
    End Sub

    Private Sub SetTaxAndDiscountAmount(ByRef tax As Double, ByRef discount As Double, ByVal forQuantity As Double, ByVal forItemId As Integer, ByVal batch As String)
        Try
            tax = 0
            discount = 0

            If forQuantity <= 0 Or forItemId <= 0 Then Exit Try

            Dim purchaseDetail As ClsPurchaseDetail = GetPurchaseDetailLastForItemId(Me.Name, forItemId, batch)
            If purchaseDetail Is Nothing Then Exit Try

            Dim taxAvg As Double = 0
            Dim discountAvg As Double = 0
            Dim qty As Double = 0
            With purchaseDetail
                qty = (.PurchaseQuantity + .FreeQuantity) * .PackQuantity
                taxAvg = .TaxAmount / qty
                discountAvg = .DiscountAmount / qty
            End With

            tax = taxAvg * forQuantity
            discount = discountAvg * forQuantity

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

#End Region

End Class
