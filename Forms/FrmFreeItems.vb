Imports System.Windows.Forms

Public Class FrmFreeItems

#Region "Local variables and Constants"

    Dim editRow As DataGridViewRow = Nothing
    Dim flagItemChanged As Boolean = False
    Dim lPurchaseObj As ClsPurchaseMaster = Nothing
    Dim lCurrentBatch As ClsCurrentStock = Nothing

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

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub CmbItem_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbItem.SelectedIndexChanged
        flagItemChanged = True
    End Sub

    Private Sub CmbItem_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbItem.KeyPress
        flagItemChanged = True
    End Sub

    Private Sub CmbItem_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbItem.LostFocus
        Try
            If flagItemChanged = False Then Exit Try

            flagItemChanged = False
            TxtPackType.Text = ""
            If CmbItem.FindStringExact(CmbItem.Text.Trim) < 0 Then Exit Try

            Dim item As ClsItemMaster = CmbItem.SelectedItem
            If item Is Nothing Then Exit Try

            With item
                TxtPackType.Text = .PackType
            End With

            LoadComboBoxValuesForBatch()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub CmbBatch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        e.KeyChar = UCase(e.KeyChar)
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Try
            If ValidateValues() = False Then Exit Sub

            'Saving Detail
            Dim freeItemDetailObj As New ClsFreeItemDetail
            With freeItemDetailObj
                .PurchaseId = lPurchaseObj.Id
                .ItemId = GetSelectedItemId(CmbItem)
                .Batch = cBatchDefault 'CmbBatch.Text
                .FreeQuantity = Val(TxtFreeQuantity.Text)
                .PackQuantity = Val(TxtPackQty.Text)
                .Remark = TxtRemark.Text
                .UserId = gUser.LoginName
                .DateOn = Now
            End With

            Dim id As Long = InsertIntoFreeItemDetail(Me.Name, freeItemDetailObj)
            If id > 0 Then
                freeItemDetailObj.Id = id
                InsertIntoGrid(freeItemDetailObj)
                lPurchaseObj.NotClosed = True
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
            If editRow Is Nothing Or lPurchaseObj Is Nothing Then Exit Try

            If ValidateValues() = False Then Exit Sub

            'Updating Detail
            Dim freeItemDetailObj As New ClsFreeItemDetail
            With freeItemDetailObj
                .Id = editRow.Cells(cId).Value
                .PurchaseId = lPurchaseObj.Id
                .ItemId = GetSelectedItemId(CmbItem)
                .Batch = cBatchDefault ' CmbBatch.Text
                .FreeQuantity = Val(TxtFreeQuantity.Text)
                .PackQuantity = Val(TxtPackQty.Text)
                .Remark = TxtRemark.Text
                .UserId = gUser.LoginName
                .DateOn = Now
            End With

            If UpdateFreeItemDetail(Me.Name, freeItemDetailObj) <> EnResult.Change Then Exit Sub

            With editRow
                .Cells(cPurchaseId).Value = freeItemDetailObj.PurchaseId
                .Cells(cItemId).Value = freeItemDetailObj.ItemId
                .Cells(cName).Value = CmbItem.Text
                .Cells(cBatch).Value = freeItemDetailObj.Batch
                .Cells(cFreeQuantity).Value = freeItemDetailObj.FreeQuantity
                .Cells(cUserId).Value = freeItemDetailObj.UserId
                .Cells(cDateOn).Value = freeItemDetailObj.DateOn
                .Cells(cPackQuantity).Value = freeItemDetailObj.PackQuantity
            End With

            lPurchaseObj.NotClosed = True
            MsgBox("Successfully Updated", , "Updated")

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNewItem()
    End Sub

    Private Sub BtnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemove.Click
        Try
            Dim row As DataGridViewRow = GrdItems.SelectedRows(0)
            If row Is Nothing Then Exit Try

            Dim id As Long = row.Cells(cId).Value
            If id <= 0 Then Exit Try

            If MsgBox("Do you really wants to remove selected record? Removed records can't be recovered.", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                If DeletePurchaseDetail(Me.Name, id) <> EnResult.Change Then Exit Sub

                lPurchaseObj.NotClosed = True
                GrdItems.Rows.Remove(row)
                MsgBox("Successfully Removed", , "Removed")
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNewItem()
    End Sub

    Private Sub GrdItems_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdItems.CellClick
        If e.RowIndex < 0 Then Exit Sub
        '        If AndedTheString(gUser.AuthorizationNo, Authorization.Purchase_NoRemove) = True Then Exit Sub

        BtnRemove.Enabled = True
        BtnAdd.Enabled = False
        BtnCancel.Enabled = True
    End Sub

    Private Sub GrdItems_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdItems.CellDoubleClick
        Try
            BtnRemove.Enabled = False
            If e.RowIndex < 0 Then Exit Try
            'If AndedTheString(gUser.AuthorizationNo, Authorization.Purchase_NoUpdate) = True Then Exit Sub

            editRow = GrdItems.Rows(e.RowIndex)
            With editRow
                CmbItem.Text = ""       'This will set packtype
                CmbItem.Text = .Cells(cName).Value
                'CmbBatch.Text = .Cells(cBatch).Value
                TxtFreeQuantity.Text = .Cells(cFreeQuantity).Value
                TxtPackQty.Text = .Cells(cPackQuantity).Value
            End With

            BtnUpdate.Enabled = True
            BtnCancel.Enabled = True
            BtnAdd.Enabled = False
            'CmbBatch.Enabled = False
            CmbItem.Focus()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub GrdItems_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdItems.KeyDown
        If e.KeyCode = Keys.Tab Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub TxtPackQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPackQty.TextChanged
        CalculateTotalQuantity()
    End Sub

    Private Sub TxtFreeQuantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFreeQuantity.TextChanged
        CalculateTotalQuantity()
    End Sub

    Private Sub TxtPackQty_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPackQty.KeyPress
        e.Handled = Check_Numeric(e.KeyChar)
    End Sub

    Private Sub TxtFreeQuantity_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtFreeQuantity.KeyPress
        e.Handled = Check_Numeric(e.KeyChar)
    End Sub

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtTotalQunatity.KeyDown, TxtRemark.KeyDown, TxtPurchaseCode.KeyDown, TxtPackType.KeyDown, TxtPackQty.KeyDown, TxtFreeQuantity.KeyDown, CmbItem.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

#End Region

#Region "Other Form Functionality"

    Private Sub LblAddItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblAddItem.Click
        'If AndedTheString(gUser.AuthorizationNo, Authorization.Cus) = False Then Exit Sub
        Try
            Dim frm As New FrmItemMaster
            frm.ShowDialog(Me)
            If frm.Change = True Then
                LoadComboBoxValuesForItem()
            End If

            frm.Dispose()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

#End Region

#Region "Private Function"

    Private Sub SetControls()
        LoadComboBoxValues()

        SetGrid()
    End Sub

    Private Sub SetGrid()
        With GrdItems
            Dim colCount As Integer = 8
            .RowHeadersVisible = False
            Dim defaultCellWidth As Integer = 100
            Dim x As Integer
            For x = 0 To colCount
                Select Case x
                    Case 0
                        Dim index As Integer = .Columns.Add(cId, cId)
                        .Columns(index).Visible = False

                    Case 1
                        Dim index As Integer = .Columns.Add(cPurchaseId, cPurchaseId)
                        .Columns(index).Visible = False

                    Case 2
                        Dim index As Integer = .Columns.Add(cName, "Item Name")
                        .Columns(index).Width = 260

                    Case 3
                        Dim index As Integer = .Columns.Add(cItemId, cItemId)
                        .Columns(index).Visible = False

                    Case 4
                        Dim index As Integer = .Columns.Add(cBatch, cBatch)
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).Visible = False

                    Case 5
                        Dim index As Integer = .Columns.Add(cUserId, cUserId)
                        .Columns(index).Visible = False

                    Case 6
                        Dim index As Integer = .Columns.Add(cDateOn, cDateOn)
                        .Columns(index).Visible = False

                    Case 7
                        Dim index As Integer = .Columns.Add(cPackQuantity, "Pack Qty.")
                        .Columns(index).Width = defaultCellWidth

                    Case 8
                        Dim index As Integer = .Columns.Add(cFreeQuantity, "Free Qty.")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                End Select
            Next
        End With
    End Sub

    Private Sub LoadGridValuesForFreeItems()
        Try
            GrdItems.Rows.Clear()

            If lPurchaseObj Is Nothing Then Exit Try

            Dim freeItemDetails() As ClsFreeItemDetail = GetAllFreeItemDetailForPurchaseId(Me.Name, lPurchaseObj.Id)
            If freeItemDetails Is Nothing Then Exit Try

            Dim freeItemDetail As ClsFreeItemDetail
            For Each freeItemDetail In freeItemDetails
                InsertIntoGrid(freeItemDetail)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub InsertIntoGrid(ByRef freeItemDetailObj As ClsFreeItemDetail)
        Try
            If freeItemDetailObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdItems.Rows.Add
            With GrdItems.Rows(rowIndex)
                .Cells(cId).Value = freeItemDetailObj.Id
                .Cells(cPurchaseId).Value = freeItemDetailObj.PurchaseId
                .Cells(cItemId).Value = freeItemDetailObj.ItemId
                .Cells(cName).Value = GetItemName(.Cells(cItemId).Value)
                .Cells(cBatch).Value = freeItemDetailObj.Batch
                .Cells(cPackQuantity).Value = freeItemDetailObj.PackQuantity
                .Cells(cUserId).Value = freeItemDetailObj.UserId
                .Cells(cDateOn).Value = freeItemDetailObj.DateOn
                .Cells(cFreeQuantity).Value = freeItemDetailObj.FreeQuantity
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadComboBoxValuesForItem()
        Try
            CmbItem.DataSource = Nothing
            CmbItem.Items.Clear()
            CmbItem.Text = ""

            Dim items() As ClsItemMaster = GetAllItemMaster(Me.Name, True)
            If items Is Nothing Then Exit Try

            CmbItem.DataSource = items
            CmbItem.DisplayMember = cName
            CmbItem.ValueMember = cId
            CmbItem.Text = ""

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadComboBoxValuesForBatch()
        Try
            'CmbBatch.DataSource = Nothing
            'CmbBatch.Items.Clear()
            'CmbBatch.Text = ""

            Dim itemId As Integer = GetSelectedItemId(CmbItem)
            If itemId <= 0 Then Exit Try

            Dim currentStocks() As ClsCurrentStock = GetAllCurrentStockForItemId(Me.Name, itemId, True)
            If currentStocks Is Nothing Then Exit Try

            lCurrentBatch = currentStocks(0)

            'CmbBatch.DataSource = currentStocks
            'CmbBatch.DisplayMember = cBatchX
            'CmbBatch.ValueMember = cId
            'CmbBatch.Text = ""

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadComboBoxValues()
        Try
            LoadComboBoxValuesForItem()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Function GetItemName(ByVal id As Integer) As String
        Dim result As String = ""
        Try
            Dim item As ClsItemMaster
            For Each item In CmbItem.Items
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

            If lPurchaseObj Is Nothing Then
                ErrorInData("Purchase Code not Set.", TxtPurchaseCode)
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

            'If CmbBatch.Text.Trim = "" Then
            '    ErrorInData("Please enter batch.", CmbBatch)
            '    Exit Try
            'End If

            If TxtPackQty.Text.Trim = "" Then
                ErrorInData("Please enter pack quantity.", TxtPackQty)
                Exit Try
            End If

            If Val(TxtPackQty.Text) <= 0 Then
                ErrorInData("Please enter pack quantity greater then 0.", TxtPackQty)
                Exit Try
            End If

            If TxtFreeQuantity.Text.Trim = "" Then
                ErrorInData("Please enter free quantity.", TxtFreeQuantity)
                Exit Try
            End If

            If Val(TxtFreeQuantity.Text) <= 0 Then
                ErrorInData("Please enter free quantity greater then 0.", TxtFreeQuantity)
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
        'CmbBatch.Text = ""
        TxtPackType.Text = ""
        TxtPackQty.Text = "0"
        TxtFreeQuantity.Text = "0"
        TxtRemark.Text = ""

        'CmbBatch.Enabled = True
        BtnAdd.Enabled = True
        BtnUpdate.Enabled = False
        BtnCancel.Enabled = False
        BtnRemove.Enabled = False
        flagItemChanged = False

        CmbItem.Focus()
    End Sub

    Private Sub ResetControlsToAddNew()
        TxtPurchaseCode.Text = ""

        GrdItems.Rows.Clear()

        ResetControlsToAddNewItem()

        lPurchaseObj = Nothing
    End Sub

    Public Sub SetPurchaseObject(ByRef purchaseObj As ClsPurchaseMaster)
        Try
            ResetControlsToAddNew()

            If purchaseObj Is Nothing Then Exit Try

            lPurchaseObj = purchaseObj
            TxtPurchaseCode.Text = lPurchaseObj.PurchaseCode

        Catch ex As Exception
            AddToLog(ex)
        End Try

        LoadGridValuesForFreeItems()
    End Sub

    Private Sub CalculateTotalQuantity()
        Try
            TxtTotalQunatity.Text = "0"
            If TxtPackQty.Text.Trim = "" Then Exit Try
            If TxtFreeQuantity.Text.Trim = "" Then Exit Try

            TxtTotalQunatity.Text = Val(TxtPackQty.Text) * Val(TxtFreeQuantity.Text)

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

#End Region

End Class
