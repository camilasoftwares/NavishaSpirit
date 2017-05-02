Imports AIMS.Author

Public Class FrmDestructionSlip

#Region "Local variables and Constants"

    Dim editRow As DataGridViewRow = Nothing
    Dim lDestructionSlipObj As ClsDestructionSlipMaster = Nothing
    Dim lStorages() As ClsStorageMaster = Nothing
    Dim lCurrentStocks() As ClsCurrentStock = Nothing
    Dim lItems() As ClsItemMaster = Nothing
    Dim flagOldObject As Boolean = False

    Private Const lcUpdate As String = "&Update"
    Private Const lcCancel As String = "Cance&l"

    Enum Index
        GrpDestructionSlip
        TxtDestructionSlipCode
        DtPkrDestructionSlipDate
        GrpItem
        CmbItem
        TxtQuantity
        BtnAdd
        BtnRemove
        GrdItems
        GrpItemsOnSlip
        GrdItemsOnSlip
        TxtNetAmount
        GrpButtons
        TxtRemark
        BtnNew
        BtnSave
        BtnPrint
        BtnSearch
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

    Private Sub FrmDestructionSlip_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not (lDestructionSlipObj Is Nothing) Then
            If lDestructionSlipObj.NotClosed = True Then
                If MsgBox("Destruction Slip Master is not updated." + vbCrLf + vbCrLf + "To update click save button." + vbCrLf + vbCrLf + "Do you want to update Destruction Slip master?", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub FrmDestructionSlip_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

    Private Sub CmbItem_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbItem.TextChanged
        LoadGridValuesForItems()
    End Sub

    Private Sub TxtQuantity_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtQuantity.KeyPress
        e.Handled = Check_DecimalAllow(e.KeyChar, sender.text)
    End Sub

    Private Sub BtnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemove.Click
        Try
            Dim row As DataGridViewRow = GrdItemsOnSlip.SelectedRows(0)
            If row Is Nothing Then Exit Try

            If flagOldObject = False Then
                If AndedTheString(gUser.AuthorizationNo, Authorization.DestructionSlips_Current_NoRemove) = True Then Exit Sub
            Else
                If AndedTheString(gUser.AuthorizationNo, Authorization.DestructionSlips_Old_NoRemove) = True Then Exit Sub
            End If

            Dim id As Long = row.Cells(cId).Value
            If id <= 0 Then Exit Try

            If MsgBox("Do you really wants to remove selected record? Removed records can't be recovered.", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                If DeleteDestructionSlipDetail(Me.Name, id) <> EnResult.Change Then Exit Sub

                lDestructionSlipObj.NotClosed = True
                GrdItemsOnSlip.Rows.Remove(row)
                MsgBox("Successfully Removed", , "Removed")
                CalculateTotals()
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNewItem()
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Try
            If BtnAdd.Text = lcUpdate Then
                UpdateDestructionSlipDetailObject()
                Exit Sub
            End If

            If flagOldObject = False Then
                If AndedTheString(gUser.AuthorizationNo, Authorization.DestructionSlips_Current_NoAdd) = True Then Exit Sub
            Else
                If AndedTheString(gUser.AuthorizationNo, Authorization.DestructionSlips_Old_NoAdd) = True Then Exit Sub
            End If

            If ValidateValues() = False Then Exit Sub

            'Saving Master if virtual
            If lDestructionSlipObj Is Nothing Then
                Dim destructionSlipMasterObj As New ClsDestructionSlipMaster
                With destructionSlipMasterObj
                    .DestructionSlipDate = DtPkrDestructionSlipDate.Value
                    .Remark = TxtRemark.Text
                    .UserId = gUser.LoginName
                    .DateOn = Now
                    .NotClosed = True
                End With

                Dim destructionSlipId As Integer = InsertIntoDestructionSlipMaster(Me.Name, destructionSlipMasterObj)
                If destructionSlipId <= 0 Then Exit Try

                destructionSlipMasterObj.Id = destructionSlipId
                lDestructionSlipObj = destructionSlipMasterObj

                destructionSlipMasterObj = GetDestructionSlipMaster(Me.Name, destructionSlipId)
                If Not (destructionSlipMasterObj Is Nothing) Then
                    lDestructionSlipObj = destructionSlipMasterObj
                    TxtDestructionSlipCode.Text = lDestructionSlipObj.DestructionSlipCode
                End If
            End If

            'Saving Detail
            Dim destructionSlipDetailObj As New ClsDestructionSlipDetail
            With destructionSlipDetailObj
                .DestructionSlipId = lDestructionSlipObj.Id
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
                .DestructionQuantity = Val(TxtQuantity.Text)
                .StorageId = currentStock.StorageId
                .Remark = TxtRemark.Text
                .UserId = gUser.LoginName
                .DateOn = Now
                SetTaxAndDiscountAmount(.TaxAmount, .DiscountAmount, .DestructionQuantity, .ItemId, .Batch)
            End With

            Dim id As Long = InsertIntoDestructionSlipDetail(Me.Name, destructionSlipDetailObj)
            If id > 0 Then
                destructionSlipDetailObj.Id = id
                InsertIntoDestructionSlipGrid(destructionSlipDetailObj)
                CalculateTotals()
                lDestructionSlipObj.NotClosed = True
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
        If flagOldObject = False Then
            If AndedTheString(gUser.AuthorizationNo, Authorization.DestructionSlips_Current_NoRemove) = True Then Exit Sub
        Else
            If AndedTheString(gUser.AuthorizationNo, Authorization.DestructionSlips_Old_NoRemove) = True Then Exit Sub
        End If

        BtnRemove.Enabled = True
        BtnAdd.Enabled = False
        BtnNew.Text = lcCancel
    End Sub

    Private Sub GrdItemsOnSlip_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdItemsOnSlip.CellDoubleClick
        Try
            BtnRemove.Enabled = False
            If e.RowIndex < 0 Then Exit Try
            If flagOldObject = False Then
                If AndedTheString(gUser.AuthorizationNo, Authorization.DestructionSlips_Current_NoUpdate) = True Then Exit Sub
            Else
                If AndedTheString(gUser.AuthorizationNo, Authorization.DestructionSlips_Old_NoUpdate) = True Then Exit Sub
            End If

            editRow = GrdItemsOnSlip.Rows(e.RowIndex)
            With editRow
                Dim str As String = .Cells(cName).Value '+ "[" + .Cells(cBatch).Value + "]"
                CmbItem.Text = str
                TxtQuantity.Text = .Cells(cDestructionQuantity).Value
            End With

            BtnAdd.Text = lcUpdate
            BtnNew.Text = lcCancel
            BtnAdd.Enabled = True
            CmbItem.Focus()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub GrdItemsOnSlip_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdItemsOnSlip.KeyDown
        If e.KeyCode = Keys.Tab Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch.Click
        Try
            Dim frm As New ClsSearchDestructionSlipForm
            If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Dim id As Long = frm.GetSelectedId
                If id > 0 Then
                    SetDestructionSlipForDestructionSlipId(id)
                    flagOldObject = True
                End If
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Try
            If lDestructionSlipObj Is Nothing Then
                MsgBox("There is no Destruction Slip selected. Please create or select Destruction Slip.", , "Destruction")
                Exit Try
            End If

            If lDestructionSlipObj.Id <= 0 Then
                MsgBox("There is no Destruction Slip selected. Please create or select Destruction Slip.", , "Destruction")
                Exit Try
            End If

            Dim destructionSlipId As Long = lDestructionSlipObj.Id
            Dim ds As DataSet = GetDestructionSlip(Me.Name, destructionSlipId)

            If ds Is Nothing Then
                MsgBox("Error in generating report.", MsgBoxStyle.Critical, "Error")
                Exit Try
            End If

            If ds.Tables(0).Rows.Count = 0 Then
                MsgBox("No record is present for this selection.", MsgBoxStyle.Information, "No Record")
                Exit Try
            End If

            'Opening Report
            SetWaitCursor()
            Dim rpt As New RptDestructionSlip
            rpt.SetDataSource(ds.Tables(0))
            Dim dlg As New DiagReport
            dlg.RptViewer.ReportSource = rpt
            dlg.ShowDialog(Me)

        Catch ex As Exception
            AddToLog(ex)
        End Try

        SetDefaultCursor()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            If lDestructionSlipObj Is Nothing Then Exit Try
            If flagOldObject = False Then
                If AndedTheString(gUser.AuthorizationNo, Authorization.DestructionSlips_Current_NoUpdate) = True Then Exit Sub
            Else
                If AndedTheString(gUser.AuthorizationNo, Authorization.DestructionSlips_Old_NoUpdate) = True Then Exit Sub
            End If

            'Updating Master
            Dim destructionSlipMasterObj As New ClsDestructionSlipMaster
            With destructionSlipMasterObj
                .Id = lDestructionSlipObj.Id
                .DestructionSlipCode = lDestructionSlipObj.DestructionSlipCode
                .Remark = TxtRemark.Text
                .DestructionSlipDate = DtPkrDestructionSlipDate.Value
                .UserId = gUser.LoginName
                .DateOn = Now
                .NotClosed = False
            End With

            If UpdateDestructionSlipMaster(Me.Name, destructionSlipMasterObj) <> EnResult.Change Then Exit Sub
            lDestructionSlipObj = destructionSlipMasterObj

            MsgBox("Successfully Saved", , "Saved")

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        If BtnNew.Text = lcCancel Then
            ResetControlsToAddNewItem()
        Else
            If Not (lDestructionSlipObj Is Nothing) Then
                If lDestructionSlipObj.NotClosed = True Then
                    If MsgBox("Destruction Slip Master is not updated." + vbCrLf + vbCrLf + "To update click save button." + vbCrLf + vbCrLf + "Do you want to update Destruction Slip master?", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                        Exit Sub
                    End If
                End If
            End If

            ResetControlsToAddNew()
        End If
    End Sub

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtRemark.KeyDown, TxtQuantity.KeyDown, TxtNetAmount.KeyDown, TxtDestructionSlipCode.KeyDown, DtPkrDestructionSlipDate.KeyDown, CmbItem.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

#End Region

#Region "Private Function"

    Private Sub SetControls()
        SetTabIndex()
        SetGridForDestructionSlip()
        SetGridForItems()
        ResetControlsToAddNew()
        LoadItems()
        LoadComboBoxValues()
        LoadStorages()
        'Load Grid values after ComboBox Values

        LoadGridValuesForItems()
        SetDestructionSlipIdForCurrentLogin()
        LoadGridValuesForDestructionSlip()
        CalculateTotals()
    End Sub

    Private Sub SetTabIndex()
        GrpDestructionSlip.TabIndex = Index.GrpDestructionSlip
        TxtDestructionSlipCode.TabIndex = Index.TxtDestructionSlipCode
        DtPkrDestructionSlipDate.TabIndex = Index.DtPkrDestructionSlipDate
        GrpItem.TabIndex = Index.GrpItem
        CmbItem.TabIndex = Index.CmbItem
        TxtQuantity.TabIndex = Index.TxtQuantity
        BtnAdd.TabIndex = Index.BtnAdd
        BtnRemove.TabIndex = Index.BtnRemove
        GrdItems.TabIndex = Index.GrdItems
        GrpItemsOnSlip.TabIndex = Index.GrpItemsOnSlip
        GrdItemsOnSlip.TabIndex = Index.GrdItemsOnSlip
        TxtNetAmount.TabIndex = Index.TxtNetAmount
        GrpButtons.TabIndex = Index.GrpButtons
        TxtRemark.TabIndex = Index.TxtRemark
        BtnNew.TabIndex = Index.BtnNew
        BtnSave.TabIndex = Index.BtnSave
        BtnPrint.TabIndex = Index.BtnPrint
        BtnSearch.TabIndex = Index.BtnSearch
        BtnClose.TabIndex = Index.BtnClose
    End Sub

    Private Sub SetGridForDestructionSlip()
        With GrdItemsOnSlip
            Dim colCount As Integer = 19
            .RowHeadersVisible = False
            Dim defaultCellWidth As Integer = 90
            Dim x As Integer
            For x = 0 To colCount
                Select Case x
                    Case 0
                        Dim index As Integer = .Columns.Add(cId, cId)
                        .Columns(index).Visible = False

                    Case 1
                        Dim index As Integer = .Columns.Add(cName, cName)
                        .Columns(index).Width = defaultCellWidth + 220

                    Case 2
                        Dim index As Integer = .Columns.Add(cBatch, cBatch)
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).Visible = False

                    Case 3
                        Dim index As Integer = .Columns.Add(cExpiryDate, "Exp. Date")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "MMM-yyyy"
                        .Columns(index).Visible = False

                    Case 4
                        Dim index As Integer = .Columns.Add(cDestructionQuantity, "Des. Qty")
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
                        Dim index As Integer = .Columns.Add(cDestructionSlipId, cDestructionSlipId)
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

                    Case 19
                        Dim index As Integer = .Columns.Add(cUserId, cUserId)
                        .Columns(index).Visible = False

                End Select
            Next
        End With
    End Sub

    Private Sub SetGridForItems()
        With GrdItems
            Dim colCount As Integer = 9
            .RowHeadersVisible = False
            Dim defaultCellWidth As Integer = 90
            Dim x As Integer
            For x = 0 To colCount
                Select Case x
                    Case 0
                        Dim index As Integer = .Columns.Add(cId, cId)
                        .Columns(index).Visible = False

                    Case 1
                        Dim index As Integer = .Columns.Add(cName, cName)
                        .Columns(index).Width = defaultCellWidth + 220

                    Case 2
                        Dim index As Integer = .Columns.Add(cBatch, cBatch)
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).Visible = False

                    Case 3
                        Dim index As Integer = .Columns.Add(cExpiryDate, "Expiry Date")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "MMM-yyyy"
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

    Private Sub LoadGridValuesForDestructionSlip()
        Try
            GrdItemsOnSlip.Rows.Clear()

            If lDestructionSlipObj Is Nothing Then Exit Try

            Dim destructionSlipDetails() As ClsDestructionSlipDetail = GetAllDestructionSlipDetailForDestructionSlipId(Me.Name, lDestructionSlipObj.Id)
            If destructionSlipDetails Is Nothing Then Exit Try

            Dim destructionSlipDetail As ClsDestructionSlipDetail
            For Each destructionSlipDetail In destructionSlipDetails
                InsertIntoDestructionSlipGrid(destructionSlipDetail)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadGridValuesForItems()
        Try
            GrdItems.Rows.Clear()

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
                    InsertIntoItemGrid(item)
                Next
            Else
                Dim item As ClsItemMaster
                For Each item In lItems
                    If UCase(item.Name).StartsWith(UCase(str)) = True Then
                        InsertIntoItemGrid(item)
                    End If
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub InsertIntoDestructionSlipGrid(ByRef destructionSlipDetailObj As ClsDestructionSlipDetail)
        Try
            If destructionSlipDetailObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdItemsOnSlip.Rows.Add
            With GrdItemsOnSlip.Rows(rowIndex)
                .Cells(cId).Value = destructionSlipDetailObj.Id
                .Cells(cItemId).Value = destructionSlipDetailObj.ItemId
                .Cells(cStorageId).Value = destructionSlipDetailObj.StorageId
                .Cells(cBatch).Value = destructionSlipDetailObj.Batch
                .Cells(cExpiryDate).Value = destructionSlipDetailObj.ExpiryDate
                .Cells(cDestructionQuantity).Value = destructionSlipDetailObj.DestructionQuantity
                .Cells(cPriceSale).Value = destructionSlipDetailObj.PriceSale
                .Cells(cPackQuantity).Value = destructionSlipDetailObj.PackQuantity
                .Cells(cTaxPercent).Value = destructionSlipDetailObj.TaxPercent
                .Cells(cTaxAmount).Value = destructionSlipDetailObj.TaxAmount
                .Cells(cDiscountPercent).Value = destructionSlipDetailObj.DiscountPercent
                .Cells(cDiscountAmount).Value = destructionSlipDetailObj.DiscountAmount
                .Cells(cTotal).Value = destructionSlipDetailObj.GetTotal
                .Cells(cStorage).Value = GetStorageName(.Cells(cStorageId).Value)
                .Cells(cName).Value = GetItemName(.Cells(cItemId).Value)
                .Cells(cDestructionSlipId).Value = destructionSlipDetailObj.DestructionSlipId
                .Cells(cPricePurchase).Value = destructionSlipDetailObj.PricePurchase
                .Cells(cRemark).Value = destructionSlipDetailObj.Remark
                .Cells(cUserId).Value = destructionSlipDetailObj.UserId
                .Cells(cDateOn).Value = destructionSlipDetailObj.DateOn
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub InsertIntoItemGrid(ByRef itemObj As ClsItemMaster)
        Try
            If itemObj Is Nothing Then Exit Try

            Dim currentStock As ClsCurrentStock = GetCurrentStockForItemId(itemObj.Id)
            If currentStock Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdItems.Rows.Add
            With GrdItems.Rows(rowIndex)
                .Cells(cId).Value = itemObj.Id
                .Cells(cName).Value = itemObj.Name
                .Cells(cStorageId).Value = itemObj.StorageId
                .Cells(cStorage).Value = GetStorageName(.Cells(cStorageId).Value)
                .Cells(cBatch).Value = currentStock.Batch
                .Cells(cExpiryDate).Value = currentStock.ExpiryDate
                .Cells(cCurrentQuantity).Value = currentStock.CurrentQuantity
                .Cells(cPriceSale).Value = 0 'currentStock.PriceSale
                .Cells(cPricePurchase).Value = currentStock.PricePurchase
                .Cells(cPackQuantity).Value = currentStock.PackQuantity
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadComboBoxValues()
        LoadCurrentStocks()
        LoadComboBoxValuesForItems()
    End Sub

    Private Sub LoadComboBoxValuesForItems()
        Try
            CmbItem.DataSource = Nothing
            CmbItem.Items.Clear()
            CmbItem.Text = ""

            Dim currentStocks() As ClsCurrentStock = GetAllCurrentStock(Me.Name, False, True)
            If currentStocks Is Nothing Then Exit Try

            Dim currentStock As ClsCurrentStock
            For Each currentStock In currentStocks
                With currentStock
                    .SetName(GetItemName(.ItemId))
                End With
            Next

            CmbItem.DataSource = currentStocks
            CmbItem.DisplayMember = cItemName
            CmbItem.ValueMember = cId
            CmbItem.Text = ""

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

    Private Function GetCurrentStockForItemId(ByVal itemId As Integer) As ClsCurrentStock
        Dim result As ClsCurrentStock = Nothing
        Try
            If itemId <= 0 Or lCurrentStocks Is Nothing Then Exit Try

            Dim currentStock As ClsCurrentStock
            For Each currentStock In lCurrentStocks
                If currentStock.ItemId = itemId Then
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

            If CmbItem.Text.Trim = "" Then
                ErrorInData("Please select item.", CmbItem)
                Exit Try
            End If

            If CmbItem.FindStringExact(CmbItem.Text.Trim) < 0 Then
                ErrorInData("Please select valid item from item list.", CmbItem)
                Exit Try
            End If

            If TxtQuantity.Text.Trim = "" Then
                ErrorInData("Please enter destruction quantity.", TxtQuantity)
                Exit Try
            End If

            If Val(TxtQuantity.Text) <= 0 Then
                ErrorInData("Please enter destruction quantity greater then 0.", TxtQuantity)
                Exit Try
            End If

            result = True

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Sub UpdateDestructionSlipDetailObject()
        Try
            If editRow Is Nothing Or lDestructionSlipObj Is Nothing Then Exit Try

            If flagOldObject = False Then
                If AndedTheString(gUser.AuthorizationNo, Authorization.DestructionSlips_Current_NoUpdate) = True Then Exit Sub
            Else
                If AndedTheString(gUser.AuthorizationNo, Authorization.DestructionSlips_Old_NoUpdate) = True Then Exit Sub
            End If

            If ValidateValues() = False Then Exit Sub

            Dim currentStock As ClsCurrentStock = GetSelectedItem(CmbItem)
            If currentStock Is Nothing Then Exit Try

            'Updating Detail
            Dim destructionSlipDetailObj As New ClsDestructionSlipDetail
            With destructionSlipDetailObj
                .Id = editRow.Cells(cId).Value
                .DestructionSlipId = lDestructionSlipObj.Id
                .ItemId = currentStock.ItemId
                .PriceSale = 0 'currentStock.PriceSale
                .DestructionQuantity = Val(TxtQuantity.Text)
                .Batch = currentStock.Batch
                .ExpiryDate = currentStock.ExpiryDate
                .PricePurchase = currentStock.PricePurchase
                .PackQuantity = currentStock.PackQuantity
                .StorageId = currentStock.StorageId
                .Remark = TxtRemark.Text
                .UserId = gUser.LoginName
                .DateOn = Now
                SetTaxAndDiscountAmount(.TaxAmount, .DiscountAmount, .DestructionQuantity, .ItemId, .Batch)
            End With

            If UpdateDestructionSlipDetail(Me.Name, destructionSlipDetailObj) <> EnResult.Change Then Exit Sub

            With editRow
                .Cells(cItemId).Value = destructionSlipDetailObj.ItemId
                .Cells(cStorageId).Value = destructionSlipDetailObj.StorageId
                .Cells(cBatch).Value = destructionSlipDetailObj.Batch
                .Cells(cExpiryDate).Value = destructionSlipDetailObj.ExpiryDate
                .Cells(cDestructionQuantity).Value = destructionSlipDetailObj.DestructionQuantity
                .Cells(cPriceSale).Value = destructionSlipDetailObj.PriceSale
                .Cells(cPackQuantity).Value = destructionSlipDetailObj.PackQuantity
                .Cells(cTaxPercent).Value = destructionSlipDetailObj.TaxPercent
                .Cells(cTaxAmount).Value = destructionSlipDetailObj.TaxAmount
                .Cells(cDiscountPercent).Value = destructionSlipDetailObj.DiscountPercent
                .Cells(cDiscountAmount).Value = destructionSlipDetailObj.DiscountAmount
                .Cells(cTotal).Value = destructionSlipDetailObj.GetTotal
                .Cells(cStorage).Value = GetStorageName(.Cells(cStorageId).Value)
                .Cells(cName).Value = GetItemName(.Cells(cItemId).Value)
                .Cells(cPricePurchase).Value = destructionSlipDetailObj.PricePurchase
                .Cells(cRemark).Value = destructionSlipDetailObj.Remark
                .Cells(cUserId).Value = destructionSlipDetailObj.UserId
                .Cells(cDateOn).Value = destructionSlipDetailObj.DateOn
            End With

            CalculateTotals()
            lDestructionSlipObj.NotClosed = True
            MsgBox("Successfully Updated", , "Updated")

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNewItem()
    End Sub

    Private Sub ResetControlsToAddNewItem()
        editRow = Nothing

        CmbItem.Text = ""
        TxtQuantity.Text = "0"

        BtnAdd.Text = "&Add"
        BtnNew.Text = "&New"
        BtnAdd.Enabled = True
        BtnRemove.Enabled = False

        CmbItem.Focus()
    End Sub

    Private Sub ResetControlsToAddNew()
        ResetControlsToAddNewItem()
        lDestructionSlipObj = Nothing

        flagOldObject = False
        TxtNetAmount.Text = "0"
        TxtRemark.Text = ""
        GrdItemsOnSlip.Rows.Clear()
        TxtDestructionSlipCode.Text = ""
        DtPkrDestructionSlipDate.Value = Now.Date

        DtPkrDestructionSlipDate.Focus()
    End Sub

    Private Sub CalculateTotals()
        Try
            TxtNetAmount.Text = "0"

            If GrdItemsOnSlip.Rows.Count = 0 Then Exit Try

            Dim totalAmount As Double = 0
            Dim taxTotal As Double = 0
            Dim discountTotal As Double = 0
            Dim netAmount As Double = 0

            Dim row As DataGridViewRow
            For Each row In GrdItemsOnSlip.Rows
                With row
                    taxTotal = taxTotal + Val(.Cells(cTaxAmount).Value)
                    discountTotal = discountTotal + Val(.Cells(cDiscountAmount).Value)
                    totalAmount = totalAmount + (Val(.Cells(cPricePurchase).Value) * Val(.Cells(cDestructionQuantity).Value))
                End With
            Next

            netAmount = totalAmount + taxTotal - discountTotal

            TxtNetAmount.Text = Format(netAmount, "0.00")

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub SetDestructionSlipIdForCurrentLogin()
        Try
            lDestructionSlipObj = Nothing
            Dim destructionSlipMaster As ClsDestructionSlipMaster = GetDestructionSlipMasterNotClosedForLogin(Me.Name, gUser.LoginName)
            If destructionSlipMaster Is Nothing Then Exit Try

            lDestructionSlipObj = destructionSlipMaster
            With destructionSlipMaster
                TxtDestructionSlipCode.Text = .DestructionSlipCode
                DtPkrDestructionSlipDate.Value = .DestructionSlipDate
                TxtRemark.Text = .Remark
            End With

            flagOldObject = False

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub SetDestructionSlipForDestructionSlipId(ByVal id As Long)
        Try
            lDestructionSlipObj = Nothing
            If id <= 0 Then Exit Try

            Dim destructionSlipMaster As ClsDestructionSlipMaster = GetDestructionSlipMaster(Me.Name, id)
            If destructionSlipMaster Is Nothing Then Exit Try

            lDestructionSlipObj = destructionSlipMaster
            With destructionSlipMaster
                TxtDestructionSlipCode.Text = .DestructionSlipCode
                DtPkrDestructionSlipDate.Value = .DestructionSlipDate
                TxtRemark.Text = .Remark
            End With

            flagOldObject = True

        Catch ex As Exception
            AddToLog(ex)
        End Try

        LoadGridValuesForDestructionSlip()
        CalculateTotals()
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