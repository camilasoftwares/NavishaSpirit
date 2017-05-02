Imports System.Windows.Forms

Public Class FrmFreeStockTransaction

#Region "Local variables and Constants"

    Dim editRow As DataGridViewRow = Nothing
    Dim lSalesObj As ClsSalesMaster = Nothing
    Dim lCurrentFreeStocks() As ClsCurrentFreeStock = Nothing
    Dim lItems() As ClsItemMaster = Nothing
    Dim flagItemChanged As Boolean = False
    Dim flagBatchChanged As Boolean = False
    Dim flagLoadForUpdate As Boolean = False

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

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        SetControls()
    End Sub

    Private Sub Event_AllowDecimalOnKeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtQuantity.KeyPress
        e.Handled = Check_DecimalAllow(e.KeyChar, sender.text)
    End Sub

    Private Sub CmbItem_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbItem.TextChanged
        flagItemChanged = True
        LoadGridValuesForFreeItems()
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Try
            If ValidateValues() = False Then Exit Sub

            'Saving Detail
            Dim freeStockTransactionObj As New ClsFreeStockTransaction
            With freeStockTransactionObj
                .SaleId = lSalesObj.Id
                Dim currentFreeStock As ClsCurrentFreeStock = CmbItem.SelectedItem
                If currentFreeStock Is Nothing Then
                    MsgBox("Item is not selected or Batch doesn't exist", , "Item")
                    Exit Sub
                End If

                .ItemId = currentFreeStock.ItemId
                .Batch = currentFreeStock.Batch
                .PackQuantity = currentFreeStock.PackQuantity
                .FreeQuantity = Val(TxtQuantity.Text)
                .Remark = TxtRemark.Text
                .UserId = gUser.LoginName
                .DateOn = Now
            End With

            Dim id As Long = InsertIntoFreeStockTransaction(Me.Name, freeStockTransactionObj)
            If id > 0 Then
                freeStockTransactionObj.Id = id
                InsertIntoFreeItemsOnBill(freeStockTransactionObj)
                lSalesObj.NotClosed = True
            End If

            MsgBox("Successfully Added", , "Added")

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNewItem()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        ResetControlsToAddNewItem()
    End Sub

    Private Sub BtnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUpdate.Click
        Try
            If editRow Is Nothing Or lSalesObj Is Nothing Then Exit Try

            If ValidateValues() = False Then Exit Sub

            Dim currentFreeStock As ClsCurrentFreeStock = GetSelectedItem(CmbItem)
            If currentFreeStock Is Nothing Then Exit Try

            'Updating Detail
            Dim freeStockTransactionObj As New ClsFreeStockTransaction
            With freeStockTransactionObj
                .Id = editRow.Cells(cId).Value
                .SaleId = lSalesObj.Id
                .ItemId = currentFreeStock.ItemId
                .FreeQuantity = Val(TxtQuantity.Text)
                .Batch = currentFreeStock.Batch
                .PackQuantity = currentFreeStock.PackQuantity
                .Remark = TxtRemark.Text
                .UserId = gUser.LoginName
                .DateOn = Now
            End With

            If UpdateFreeStockTransaction(Me.Name, freeStockTransactionObj) <> EnResult.Change Then Exit Sub

            With editRow
                .Cells(cItemId).Value = freeStockTransactionObj.ItemId
                .Cells(cBatch).Value = freeStockTransactionObj.Batch
                .Cells(cFreeQuantity).Value = freeStockTransactionObj.FreeQuantity
                .Cells(cPackQuantity).Value = freeStockTransactionObj.PackQuantity
                .Cells(cName).Value = GetItemName(.Cells(cItemId).Value)
                .Cells(cRemark).Value = freeStockTransactionObj.Remark
                .Cells(cUserId).Value = freeStockTransactionObj.UserId
                .Cells(cDateOn).Value = freeStockTransactionObj.DateOn
            End With

            lSalesObj.NotClosed = True
            MsgBox("Successfully Updated", , "Updated")

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNewItem()
    End Sub

    Private Sub BtnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemove.Click
        Try
            Dim row As DataGridViewRow = GrdFreeItemsOnBill.SelectedRows(0)
            If row Is Nothing Then Exit Try

            Dim id As Long = row.Cells(cId).Value
            If id <= 0 Then Exit Try

            If MsgBox("Do you really wants to remove selected record? Removed records can't be recovered.", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                If DeleteFreeStockTransaction(Me.Name, id) <> EnResult.Change Then Exit Sub

                lSalesObj.NotClosed = True
                GrdFreeItemsOnBill.Rows.Remove(row)
                MsgBox("Successfully Removed", , "Removed")
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNewItem()
    End Sub

    Private Sub GrdFreeItems_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdFreeItems.CellClick
        Try
            If e.RowIndex < 0 Then Exit Try

            With GrdFreeItems.Rows(e.RowIndex)
                If .Cells(cName).Value.ToString.Trim = "" Or .Cells(cBatch).Value.ToString.Trim = "" Then Exit Try

                CmbItem.Text = .Cells(cName).Value '+ "[" + .Cells(cBatch).Value + "]"
            End With

            CmbItem.Focus()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub GrdFreeItemsOnBill_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdFreeItemsOnBill.CellClick
        If e.RowIndex < 0 Then Exit Sub
        'If AndedTheString(gUser.AuthorizationNo, Authorization.Sales_NoRemove) = True Then Exit Sub

        BtnRemove.Enabled = True
        BtnAdd.Enabled = False
        BtnCancel.Enabled = True
        BtnUpdate.Enabled = False
    End Sub

    Private Sub GrdFreeItemsOnBill_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdFreeItemsOnBill.CellDoubleClick
        Try
            BtnRemove.Enabled = False
            If e.RowIndex < 0 Then Exit Try
            'If AndedTheString(gUser.AuthorizationNo, Authorization.Sales_NoUpdate) = True Then Exit Sub

            editRow = GrdFreeItemsOnBill.Rows(e.RowIndex)
            flagLoadForUpdate = True
            LoadComboBoxValuesForItemsWithUpdateItem()
            With editRow
                Dim str As String = .Cells(cName).Value '+ "[" + .Cells(cBatch).Value + "]"
                CmbItem.Text = str
                TxtQuantity.Text = .Cells(cFreeQuantity).Value
            End With

            BtnAdd.Enabled = False
            BtnCancel.Enabled = True
            BtnUpdate.Enabled = True
            BtnRemove.Enabled = False

            CmbItem.Focus()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub GrdFreeItemsOnBill_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdFreeItemsOnBill.KeyDown
        If e.KeyCode = Keys.Tab Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub GrdFreeItems_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdFreeItems.KeyDown
        If e.KeyCode = Keys.Tab Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSaleCode.KeyDown, TxtRemark.KeyDown, TxtQuantity.KeyDown, CmbItem.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

#End Region

#Region "Private Function"

    Private Sub SetControls()
        SetGridForFreeItemsOnBill()
        SetGridForItems()
        LoadItems()
        LoadComboBoxValues()
        ResetControlsToAddNew()
        'Load Grid values after ComboBox Values

        LoadGridValuesForFreeItemsOnBill()
    End Sub

    Private Sub SetGridForFreeItemsOnBill()
        With GrdFreeItemsOnBill
            Dim colCount As Integer = 9
            .RowHeadersVisible = False
            Dim defaultCellWidth As Integer = 80
            Dim x As Integer
            For x = 0 To colCount
                Select Case x
                    Case 0
                        Dim index As Integer = .Columns.Add(cId, cId)
                        .Columns(index).Visible = False

                    Case 1
                        Dim index As Integer = .Columns.Add(cName, cName)
                        .Columns(index).Width = 240

                    Case 2
                        Dim index As Integer = .Columns.Add(cBatch, cBatch)
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).Visible = False

                    Case 3
                        Dim index As Integer = .Columns.Add(cItemId, cItemId)
                        .Columns(index).Visible = False

                    Case 4
                        Dim index As Integer = .Columns.Add(cPackQuantity, "Pack Qty.")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 5
                        Dim index As Integer = .Columns.Add(cFreeQuantity, "Free Qty")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 6
                        Dim index As Integer = .Columns.Add(cSaleId, cSaleId)
                        .Columns(index).Visible = False

                    Case 7
                        Dim index As Integer = .Columns.Add(cRemark, cRemark)
                        .Columns(index).Width = defaultCellWidth + 100

                    Case 8
                        Dim index As Integer = .Columns.Add(cUserId, cUserId)
                        .Columns(index).Visible = False

                    Case 9
                        Dim index As Integer = .Columns.Add(cDateOn, cDateOn)
                        .Columns(index).Visible = False

                End Select
            Next
        End With
    End Sub

    Private Sub SetGridForItems()
        With GrdFreeItems
            Dim colCount As Integer = 8
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
                        .Columns(index).Width = 325

                    Case 2
                        Dim index As Integer = .Columns.Add(cBatch, cBatch)
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).Visible = False

                    Case 3
                        Dim index As Integer = .Columns.Add(cPackQuantity, "Pack Qty.")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 4
                        Dim index As Integer = .Columns.Add(cCurrentQuantity, "Quantity")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                End Select
            Next
        End With
    End Sub

    Private Sub LoadGridValuesForFreeItemsOnBill()
        Try
            GrdFreeItemsOnBill.Rows.Clear()

            If lSalesObj Is Nothing Then Exit Try

            Dim freeStockTransactions() As ClsFreeStockTransaction = GetAllFreeStockTransactionForSalesId(Me.Name, lSalesObj.Id)
            If freeStockTransactions Is Nothing Then Exit Try

            Dim freeStockTransaction As ClsFreeStockTransaction
            For Each freeStockTransaction In freeStockTransactions
                InsertIntoFreeItemsOnBill(freeStockTransaction)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadGridValuesForFreeItems()
        Try
            GrdFreeItems.Rows.Clear()
            If lItems Is Nothing Then Exit Try

            Dim str As String = CmbItem.Text.Trim
            Dim i As Integer = str.IndexOf("[")
            If i <= 0 Then
                str = ""
            Else
                str = str.Remove(i).Trim
            End If
            If str = "" Then
                Dim item As ClsItemMaster
                For Each item In lItems
                    InsertIntoFreeItemGrid(item)
                Next
            Else
                Dim item As ClsItemMaster
                For Each item In lItems
                    If UCase(item.Name).StartsWith(UCase(str)) = True Then
                        InsertIntoFreeItemGrid(item)
                    End If
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub InsertIntoFreeItemsOnBill(ByRef freeStockTransactionObj As ClsFreeStockTransaction)
        Try
            If freeStockTransactionObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdFreeItemsOnBill.Rows.Add
            With GrdFreeItemsOnBill.Rows(rowIndex)
                .Cells(cId).Value = freeStockTransactionObj.Id
                .Cells(cItemId).Value = freeStockTransactionObj.ItemId
                .Cells(cBatch).Value = freeStockTransactionObj.Batch
                .Cells(cFreeQuantity).Value = freeStockTransactionObj.FreeQuantity
                .Cells(cPackQuantity).Value = freeStockTransactionObj.PackQuantity
                .Cells(cName).Value = GetItemName(.Cells(cItemId).Value)
                .Cells(cSaleId).Value = freeStockTransactionObj.SaleId
                .Cells(cRemark).Value = freeStockTransactionObj.Remark
                .Cells(cUserId).Value = freeStockTransactionObj.UserId
                .Cells(cDateOn).Value = freeStockTransactionObj.DateOn
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub InsertIntoFreeItemGrid(ByRef itemObj As ClsItemMaster)
        Try
            If itemObj Is Nothing Then Exit Try

            Dim currentFreeStockLst As List(Of ClsCurrentFreeStock) = GetAllCurrentFreeStockForItemId(itemObj.Id)
            If currentFreeStockLst.Count = 0 Then Exit Try

            Dim currentFreeStock As ClsCurrentFreeStock
            For Each currentFreeStock In currentFreeStockLst
                If flagLoadForUpdate = True Then
                    If editRow Is Nothing Then Continue For
                    If editRow.Cells(cItemId).Value <> currentFreeStock.ItemId And currentFreeStock.CurrentQuantity <= 0 Then Continue For

                ElseIf currentFreeStock.CurrentQuantity <= 0 Then
                    Continue For
                End If

                Dim rowIndex As Integer = GrdFreeItems.Rows.Add
                With GrdFreeItems.Rows(rowIndex)
                    .Cells(cId).Value = itemObj.Id
                    .Cells(cName).Value = itemObj.Name
                    .Cells(cBatch).Value = currentFreeStock.Batch
                    .Cells(cCurrentQuantity).Value = currentFreeStock.CurrentQuantity
                    .Cells(cPackQuantity).Value = currentFreeStock.PackQuantity
                End With
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadComboBoxValues()
        LoadComboBoxValuesForItems()
    End Sub

    Private Sub LoadComboBoxValuesForItems()
        Try
            CmbItem.Items.Clear()

            Dim currentFreeStocks() As ClsCurrentFreeStock = GetAllCurrentFreeStock(Me.Name, True)
            If currentFreeStocks Is Nothing Then Exit Try

            CmbItem.DisplayMember = cItemName
            CmbItem.ValueMember = cId
            Dim currentFreeStock As ClsCurrentFreeStock
            For Each currentFreeStock In currentFreeStocks
                With currentFreeStock
                    .SetName(GetItemName(.ItemId))
                End With

                CmbItem.Items.Add(currentFreeStock)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadComboBoxValuesForItemsWithUpdateItem()
        Try
            LoadComboBoxValuesForItems()

            If flagLoadForUpdate = False Then Exit Try
            If editRow Is Nothing Then Exit Try

            Dim itemId As Integer = editRow.Cells(cItemId).Value
            Dim batch As String = editRow.Cells(cBatch).Value

            Dim obj As ClsCurrentFreeStock
            For Each obj In CmbItem.Items
                If obj.ItemId = itemId And obj.Batch = batch Then Exit Try
            Next

            Dim currentFreeStock As ClsCurrentFreeStock = GetCurrentFreeStockForItemIdAndBatch(Me.Name, itemId, batch)
            If currentFreeStock Is Nothing Then Exit Try

            With currentFreeStock
                .SetName(GetItemName(.ItemId))
            End With

            CmbItem.Items.Add(currentFreeStock)

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

    Private Sub LoadCurrentFreeStocks()
        Try
            lCurrentFreeStocks = GetAllCurrentFreeStock(Me.Name)

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Function GetAllCurrentFreeStockForItemId(ByVal itemId As Integer) As List(Of ClsCurrentFreeStock)
        Dim lst As New List(Of ClsCurrentFreeStock)
        Try
            If itemId <= 0 Or lCurrentFreeStocks Is Nothing Then Exit Try

            Dim currentFreeStock As ClsCurrentFreeStock
            For Each currentFreeStock In lCurrentFreeStocks
                If currentFreeStock.ItemId = itemId Then
                    lst.Add(currentFreeStock)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return lst
    End Function

    Private Function GetItemName(ByVal id As Integer) As String
        Dim result As String = ""
        Try
            If lItems Is Nothing Then Exit Try

            Dim item As ClsItemMaster
            For Each item In lItems
                If item.Id = id Then
                    result = item.Name
                    Exit Try
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Function ValidateValues() As Boolean
        Dim result As Boolean = False
        Try
            RemoveErrorIcon()

            If lSalesObj Is Nothing Then
                ErrorInData("Sale Code not set.", TxtSaleCode)
                Exit Try
            End If

            If CmbItem.Text.Trim = "" Then
                ErrorInData("Please select item.", CmbItem)
                Exit Try
            End If

            If CmbItem.FindStringExact(CmbItem.Text.Trim) < 0 Then
                ErrorInData("Please select valid item from item list.", CmbItem)
                Exit Try
            End If

            If TxtQuantity.Text.Trim = "" Then
                ErrorInData("Please enter free quantity.", TxtQuantity)
                Exit Try
            End If

            If Val(TxtQuantity.Text) <= 0 Then
                ErrorInData("Please enter free quantity greater then 0.", TxtQuantity)
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
        BtnRemove.Enabled = False
        BtnCancel.Enabled = False
        BtnUpdate.Enabled = False

        flagItemChanged = False
        flagBatchChanged = False
        flagLoadForUpdate = False

        LoadCurrentFreeStocks()
        LoadGridValuesForFreeItems()

        CmbItem.Focus()
    End Sub

    Private Sub ResetControlsToAddNew()
        TxtSaleCode.Text = ""

        GrdFreeItemsOnBill.Rows.Clear()
        ResetControlsToAddNewItem()
        lSalesObj = Nothing
    End Sub

    Public Sub SetSaleObject(ByRef saleObj As ClsSalesMaster)
        Try
            lSalesObj = Nothing
            If saleObj Is Nothing Then Exit Try

            lSalesObj = saleObj
            With lSalesObj
                TxtSaleCode.Text = .SaleCode
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        LoadGridValuesForFreeItemsOnBill()
    End Sub

#End Region

End Class
