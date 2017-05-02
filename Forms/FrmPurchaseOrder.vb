Imports AIMS.Author

Public Class FrmPurchaseOrder

#Region "Local variables and Constants"

    Dim editRow As DataGridViewRow = Nothing
    Dim lPurchaseOrderObj As ClsPurchaseOrderMaster = Nothing
    Dim flagItemChanged As Boolean = False
    Dim flagOldObject As Boolean = False

    Private Const lcUpdate As String = "&Update"
    Private Const lcCancel As String = "Cance&l"

    Enum Index
        GrpItem
        TxtPurchaseOrderNo
        CmbItem
        TxtOrderQuantity
        CmbVendor
        TxtPackType
        TxtPricePurchasePrevious
        TxtOrderPrice
        CmbManufacturer
        BtnAdd
        BtnRemove
        GrdItems
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

    Private Sub FrmPurchaseOrder_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Not (lPurchaseOrderObj Is Nothing) Then
            If lPurchaseOrderObj.NotClosed = True Then
                If MsgBox("Purchase Order Master is not updated." + vbCrLf + vbCrLf + "To update click save button." + vbCrLf + vbCrLf + "Do you want to update Purchase order master?", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub FrmPurchaseOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

    Private Sub CmbItem_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbItem.KeyPress
        'AutoComplete(sender, e)
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
                Dim prvPrice As Double = GetPurchaseDetailLastPriceForItemId(Me.Name, .Id)
                TxtPricePurchasePrevious.Text = Format(prvPrice, "0.00")
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub CmbItem_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbItem.SelectedIndexChanged
        flagItemChanged = True
    End Sub

    Private Sub TxtOrderQuantity_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtOrderQuantity.KeyPress
        e.Handled = Check_Numeric(e.KeyChar)
    End Sub

    Private Sub CmbVendor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbVendor.KeyPress
        'AutoComplete(sender, e)
    End Sub

    Private Sub CmbManufacturer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbManufacturer.KeyPress
        'AutoComplete(sender, e)
    End Sub

    Private Sub BtnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemove.Click
        Try
            Dim row As DataGridViewRow = GrdItems.SelectedRows(0)
            If row Is Nothing Then Exit Try

            If flagOldObject = False Then
                If AndedTheString(gUser.AuthorizationNo, Authorization.PurchaseOrder_Current_NoRemove) = True Then Exit Sub
            Else
                If AndedTheString(gUser.AuthorizationNo, Authorization.PurchaseOrder_Old_NoRemove) = True Then Exit Sub
            End If

            Dim id As Long = row.Cells(cId).Value
            If id <= 0 Then Exit Try

            If MsgBox("Do you really wants to remove selected record? Removed records can't be recovered.", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                If DeletePurchaseOrderDetail(Me.Name, id) <> EnResult.Change Then Exit Sub

                lPurchaseOrderObj.NotClosed = True
                GrdItems.Rows.Remove(row)
                MsgBox("Successfully Removed", , "Removed")
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNewItem()
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Try
            If BtnAdd.Text = lcUpdate Then
                UpdatePurchaseOrderDetailObject()
                Exit Sub
            End If

            If flagOldObject = False Then
                If AndedTheString(gUser.AuthorizationNo, Authorization.PurchaseOrder_Current_NoAdd) = True Then Exit Sub
            Else
                If AndedTheString(gUser.AuthorizationNo, Authorization.PurchaseOrder_Old_NoAdd) = True Then Exit Sub
            End If

            If ValidateValues() = False Then Exit Sub

            'Saving Master if virtual
            If lPurchaseOrderObj Is Nothing Then
                Dim purchaseOrderMasterObj As New ClsPurchaseOrderMaster
                With purchaseOrderMasterObj
                    .NotClosed = True
                    .OrderDate = Now.Date
                    .Remark = TxtRemark.Text
                    .UserId = gUser.LoginName
                    .DateOn = Now
                End With

                Dim purchaseOrderId As Integer = InsertIntoPurchaseOrderMaster(Me.Name, purchaseOrderMasterObj)
                If purchaseOrderId <= 0 Then Exit Try

                purchaseOrderMasterObj.Id = purchaseOrderId
                lPurchaseOrderObj = purchaseOrderMasterObj

                purchaseOrderMasterObj = GetPurchaseOrderMaster(Me.Name, purchaseOrderId)
                If Not (purchaseOrderMasterObj Is Nothing) Then
                    lPurchaseOrderObj = purchaseOrderMasterObj
                    TxtPurchaseOrderNo.Text = lPurchaseOrderObj.Id
                End If
            End If

            'Saving Detail
            Dim purchaseOrderDetailObj As New ClsPurchaseOrderDetail
            With purchaseOrderDetailObj
                .OrderId = lPurchaseOrderObj.Id
                .ItemId = GetSelectedItemId(CmbItem)
                .ManufacturerId = GetSelectedItemId(CmbManufacturer)
                .OrderQuantity = Val(TxtOrderQuantity.Text)
                .OrderPrice = Val(TxtOrderPrice.Text)
                .PricePurchasePrevious = Val(TxtPricePurchasePrevious.Text)
                .VendorId = GetSelectedItemId(CmbVendor)
            End With

            Dim id As Long = InsertIntoPurchaseOrderDetail(Me.Name, purchaseOrderDetailObj)
            If id > 0 Then
                purchaseOrderDetailObj.Id = id
                InsertIntoGrid(purchaseOrderDetailObj)
                lPurchaseOrderObj.NotClosed = True
            End If

            MsgBox("Successfully Added", , "Added")

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNewItem()
    End Sub

    Private Sub GrdItems_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdItems.CellClick
        If e.RowIndex < 0 Then Exit Sub
        If flagOldObject = False Then
            If AndedTheString(gUser.AuthorizationNo, Authorization.PurchaseOrder_Current_NoRemove) = True Then Exit Sub
        Else
            If AndedTheString(gUser.AuthorizationNo, Authorization.PurchaseOrder_Old_NoRemove) = True Then Exit Sub
        End If

        BtnRemove.Enabled = True
        BtnAdd.Enabled = False
        BtnNew.Text = lcCancel
    End Sub

    Private Sub GrdItems_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdItems.CellDoubleClick
        Try
            BtnRemove.Enabled = False
            If e.RowIndex < 0 Then Exit Try

            If flagOldObject = False Then
                If AndedTheString(gUser.AuthorizationNo, Authorization.PurchaseOrder_Current_NoUpdate) = True Then Exit Sub
            Else
                If AndedTheString(gUser.AuthorizationNo, Authorization.PurchaseOrder_Old_NoUpdate) = True Then Exit Sub
            End If

            editRow = GrdItems.Rows(e.RowIndex)
            With editRow
                CmbItem.SelectedIndex = -1    'This will reset values
                CmbItem.Text = " "
                CmbItem.Text = .Cells(cName).Value
                TxtOrderQuantity.Text = .Cells(cOrderQuantity).Value
                TxtOrderPrice.Text = .Cells(cOrderPrice).Value
                CmbManufacturer.Text = .Cells(cManufacturer).Value
                CmbVendor.Text = .Cells(cVendor).Value
            End With

            BtnAdd.Text = lcUpdate
            BtnNew.Text = lcCancel
            BtnAdd.Enabled = True
            CmbItem.Focus()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub GrdItems_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdItems.KeyDown
        If e.KeyCode = Keys.Tab Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub BtnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNew.Click
        If BtnNew.Text = lcCancel Then
            ResetControlsToAddNewItem()
        Else
            If Not (lPurchaseOrderObj Is Nothing) Then
                If lPurchaseOrderObj.NotClosed = True Then
                    If MsgBox("Purchase Order Master is not updated." + vbCrLf + vbCrLf + "To update click save button." + vbCrLf + vbCrLf + "Do you want to update Purchase order master?", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                        Exit Sub
                    End If
                End If
            End If

            ResetControlsToAddNew()
        End If
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            If lPurchaseOrderObj Is Nothing Then Exit Try

            If flagOldObject = False Then
                If AndedTheString(gUser.AuthorizationNo, Authorization.PurchaseOrder_Current_NoUpdate) = True Then Exit Sub
            Else
                If AndedTheString(gUser.AuthorizationNo, Authorization.PurchaseOrder_Old_NoUpdate) = True Then Exit Sub
            End If

            'Updating Master
            Dim purchaseOrderMasterObj As New ClsPurchaseOrderMaster
            With purchaseOrderMasterObj
                .Id = lPurchaseOrderObj.Id
                .NotClosed = False
                .OrderDate = Now.Date
                .Remark = TxtRemark.Text
                .UserId = gUser.LoginName
                .DateOn = Now
            End With

            If UpdatePurchaseOrderMaster(Me.Name, purchaseOrderMasterObj) <> EnResult.Change Then Exit Sub
            lPurchaseOrderObj = purchaseOrderMasterObj

            MsgBox("Successfully Saved", , "Saved")

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Try
            If lPurchaseOrderObj Is Nothing Then
                MsgBox("There is no Purchase Order selected. Please create or select Purchase Order.", , "Purchase Order")
                Exit Try
            End If

            If lPurchaseOrderObj.Id <= 0 Then
                MsgBox("There is no Purchase Order selected. Please create or select Purchase Order.", , "Purchase Order")
                Exit Try
            End If

            Dim purchaseOrderId As Long = lPurchaseOrderObj.Id
            Dim ds As DataSet = GetPurchaseOrder(Me.Name, purchaseOrderId)

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
            Dim rpt As New RptPurchaseOrder
            rpt.SetDataSource(ds.Tables(0))
            Dim dlg As New DiagReport
            dlg.RptViewer.ReportSource = rpt
            dlg.ShowDialog(Me)

        Catch ex As Exception
            AddToLog(ex)
        End Try

        SetDefaultCursor()
    End Sub

    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch.Click
        Try
            Dim frm As New ClsSearchPurchaseOrderForm
            If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Dim id As Integer = frm.GetSelectedId
                If id > 0 Then
                    SetPurchaseOrderForPurchaseOrderId(id)
                    flagOldObject = True
                End If
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtRemark.KeyDown, TxtPricePurchasePrevious.KeyDown, TxtPackType.KeyDown, TxtOrderQuantity.KeyDown, CmbVendor.KeyDown, CmbManufacturer.KeyDown, CmbItem.KeyDown, TxtOrderPrice.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub DecimalAllow_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtOrderPrice.KeyPress, TxtPricePurchasePrevious.KeyPress
        e.Handled = Check_DecimalAllow(e.KeyChar, sender.text)
    End Sub

#End Region

#Region "Other Form Functionality"

    Private Sub LblAddVendor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblAddVendor.Click
        If AndedTheString(gUser.AuthorizationNo, Authorization.Vendors) = False Then Exit Sub
        Try
            Dim frm As New FrmVendorMaster
            frm.ShowDialog(Me)
            If frm.Change = True Then LoadComboBoxValuesForVendor()

            frm.Dispose()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LblAddItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblAddItem.Click
        If AndedTheString(gUser.AuthorizationNo, Authorization.Items) = False Then Exit Sub
        Try
            Dim frm As New FrmItemMaster
            frm.ShowDialog(Me)
            GetAllItemMaster(Me.Name)
            If frm.Change = True Then LoadComboBoxValuesForItem()

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

#End Region

#Region "Private Function"

    Private Sub SetControls()
        SetTabIndex()
        LoadComboBoxValues()

        SetGrid()
        ResetControlsToAddNew()

        ''This will open last unsaved work
        SetPurchaseOrderIdForCurrentLogin()
        LoadGridValuesForPurchaseOrderDetail()
    End Sub

    Private Sub SetTabIndex()
        BtnRemove.TabIndex = Index.BtnRemove
        BtnAdd.TabIndex = Index.BtnAdd
        CmbVendor.TabIndex = Index.CmbVendor
        CmbItem.TabIndex = Index.CmbItem
        BtnClose.TabIndex = Index.BtnClose
        BtnSave.TabIndex = Index.BtnSave
        TxtRemark.TabIndex = Index.TxtRemark
        BtnSearch.TabIndex = Index.BtnSearch
        GrpButtons.TabIndex = Index.GrpButtons
        BtnPrint.TabIndex = Index.BtnPrint
        BtnNew.TabIndex = Index.BtnNew
        GrpItem.TabIndex = Index.GrpItem
        TxtPackType.TabIndex = Index.TxtPackType
        TxtPricePurchasePrevious.TabIndex = Index.TxtPricePurchasePrevious
        TxtOrderPrice.TabIndex = Index.TxtOrderPrice
        CmbManufacturer.TabIndex = Index.CmbManufacturer
        TxtOrderQuantity.TabIndex = Index.TxtOrderQuantity
        GrdItems.TabIndex = Index.GrdItems
        TxtPurchaseOrderNo.TabIndex = Index.TxtPurchaseOrderNo
    End Sub

    Private Sub SetGrid()
        With GrdItems
            Dim colCount As Integer = 10
            .RowHeadersVisible = False
            Dim defaultCellWidth As Integer = 90
            Dim x As Integer
            For x = 0 To colCount
                Select Case x
                    Case 0
                        Dim index As Integer = .Columns.Add(cId, cId)
                        .Columns(index).Visible = False

                    Case 1
                        Dim index As Integer = .Columns.Add(cOrderId, cOrderId)
                        .Columns(index).Visible = False

                    Case 2
                        Dim index As Integer = .Columns.Add(cName, "Item Name")
                        .Columns(index).Width = defaultCellWidth + 70

                    Case 3
                        Dim index As Integer = .Columns.Add(cItemId, cItemId)
                        .Columns(index).Visible = False

                    Case 4
                        Dim index As Integer = .Columns.Add(cOrderQuantity, "Order Qty.")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 5
                        Dim index As Integer = .Columns.Add(cPricePurchasePrevious, "Prv. Pur. Price")
                        .Columns(index).Width = defaultCellWidth + 10
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 6
                        Dim index As Integer = .Columns.Add(cOrderPrice, "Order Price")
                        .Columns(index).Width = defaultCellWidth + 10
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 7
                        Dim index As Integer = .Columns.Add(cVendorId, cVendorId)
                        .Columns(index).Visible = False

                    Case 8
                        Dim index As Integer = .Columns.Add(cManufacturer, cManufacturer)
                        .Columns(index).Width = defaultCellWidth + 70

                    Case 9
                        Dim index As Integer = .Columns.Add(cVendor, cVendor)
                        .Columns(index).Width = defaultCellWidth + 70
                    Case 10
                        Dim index As Integer = .Columns.Add(cManufacturerId, cManufacturerId)
                        .Columns(index).Visible = False

                End Select
            Next
        End With
    End Sub

    Private Sub LoadGridValuesForPurchaseOrderDetail()
        Try
            GrdItems.Rows.Clear()

            If lPurchaseOrderObj Is Nothing Then Exit Try

            Dim purchaseOrderDetails() As ClsPurchaseOrderDetail = GetAllPurchaseOrderDetailForPurchaseOrderId(Me.Name, lPurchaseOrderObj.Id)
            If purchaseOrderDetails Is Nothing Then Exit Try

            Dim purchaseOrderDetail As ClsPurchaseOrderDetail
            For Each purchaseOrderDetail In purchaseOrderDetails
                InsertIntoGrid(purchaseOrderDetail)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub InsertIntoGrid(ByRef purchaseOrderDetailObj As ClsPurchaseOrderDetail)
        Try
            If purchaseOrderDetailObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdItems.Rows.Add
            With GrdItems.Rows(rowIndex)
                .Cells(cId).Value = purchaseOrderDetailObj.Id
                .Cells(cOrderId).Value = purchaseOrderDetailObj.OrderId
                .Cells(cItemId).Value = purchaseOrderDetailObj.ItemId
                .Cells(cOrderQuantity).Value = purchaseOrderDetailObj.OrderQuantity
                .Cells(cOrderPrice).Value = purchaseOrderDetailObj.OrderPrice
                .Cells(cManufacturerId).Value = purchaseOrderDetailObj.ManufacturerId
                .Cells(cPricePurchasePrevious).Value = purchaseOrderDetailObj.PricePurchasePrevious
                .Cells(cVendorId).Value = purchaseOrderDetailObj.VendorId
                .Cells(cManufacturer).Value = GetManufacturerName(.Cells(cManufacturerId).Value)
                .Cells(cVendor).Value = GetVendorName(.Cells(cVendorId).Value)
                .Cells(cName).Value = GetItemName(.Cells(cItemId).Value)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadComboBoxValuesForVendor()
        Try
            CmbVendor.Items.Clear()

            Dim vendors() As ClsVendorMaster = GetAllVendorMaster(Me.Name)
            If vendors Is Nothing Then Exit Try

            CmbVendor.DisplayMember = cName
            CmbVendor.ValueMember = cId
            Dim vendor As ClsVendorMaster
            For Each vendor In vendors
                CmbVendor.Items.Add(vendor)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Function GetVendorName(ByVal id As Integer) As String
        Dim result As String = ""
        Try
            Dim vendor As ClsVendorMaster
            For Each vendor In CmbVendor.Items
                If vendor.Id = id Then
                    result = vendor.Name
                    Exit Try
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Sub LoadComboBoxValuesForManufacturer()
        Try
            CmbManufacturer.Items.Clear()

            Dim manufacturers() As ClsManufacturerMaster = GetAllManufacturerMaster(Me.Name)
            If manufacturers Is Nothing Then Exit Try

            CmbManufacturer.DisplayMember = cName
            CmbManufacturer.ValueMember = cId
            Dim manufacturer As ClsManufacturerMaster
            For Each manufacturer In manufacturers
                CmbManufacturer.Items.Add(manufacturer)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Function GetManufacturerName(ByVal id As Integer) As String
        Dim result As String = ""
        Try
            Dim manufacturer As ClsManufacturerMaster
            For Each manufacturer In CmbManufacturer.Items
                If manufacturer.Id = id Then
                    result = manufacturer.Name
                    Exit Try
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Sub LoadComboBoxValuesForItem()
        Try
            CmbItem.DataSource = Nothing
            CmbItem.Items.Clear()
            CmbItem.Text = ""

            Dim items() As ClsItemMaster = GetAllItemMaster(Me.Name, False)
            If items Is Nothing Then Exit Try

            CmbItem.DataSource = items
            CmbItem.DisplayMember = cName
            CmbItem.ValueMember = cId
            CmbItem.Text = ""
            
        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadComboBoxValues()
        Try
            LoadComboBoxValuesForVendor()
            LoadComboBoxValuesForManufacturer()
            GetAllItemMaster(Me.Name)
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

            If CmbItem.Text.Trim = "" Then
                ErrorInData("Please select item.", CmbItem)
                Exit Try
            End If

            If CmbItem.FindStringExact(CmbItem.Text.Trim) < 0 Then
                ErrorInData("Please select valid item from item list.", CmbItem)
                Exit Try
            End If

            If TxtOrderQuantity.Text.Trim = "" Then
                ErrorInData("Please enter purchase order quantity.", TxtOrderQuantity)
                Exit Try
            End If

            If Val(TxtOrderQuantity.Text) <= 0 Then
                ErrorInData("Please enter purchase order quantity greater then zero.", TxtOrderQuantity)
                Exit Try
            End If

            If CmbVendor.Text.Trim = "" Then
                ErrorInData("Please select vendor.", CmbVendor)
                Exit Try
            End If

            If CmbVendor.FindStringExact(CmbVendor.Text.Trim) < 0 Then
                ErrorInData("Please select valid vendor from vendor list.", CmbVendor)
                Exit Try
            End If

            If CmbManufacturer.Text.Trim <> "" Then
                If CmbManufacturer.FindStringExact(CmbManufacturer.Text.Trim) < 0 Then
                    ErrorInData("Please select valid manufacturer from manufacturer list.", CmbManufacturer)
                    Exit Try
                End If
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
        TxtOrderQuantity.Text = ""
        CmbVendor.Text = ""
        TxtPackType.Text = ""
        TxtPricePurchasePrevious.Text = ""
        TxtOrderPrice.Text = ""
        CmbManufacturer.Text = ""
        BtnAdd.Text = "&Add"
        BtnNew.Text = "&New"
        BtnAdd.Enabled = True
        BtnRemove.Enabled = False
        flagItemChanged = False

        CmbItem.Focus()
    End Sub

    Private Sub ResetControlsToAddNew()
        GrdItems.Rows.Clear()

        TxtRemark.Text = ""
        TxtPurchaseOrderNo.Text = ""
        ResetControlsToAddNewItem()
        lPurchaseOrderObj = Nothing
        flagOldObject = False
    End Sub

    Private Sub SetPurchaseOrderIdForCurrentLogin()
        Try
            lPurchaseOrderObj = Nothing
            TxtPurchaseOrderNo.Text = ""

            Dim purchaseOrderMaster As ClsPurchaseOrderMaster = GetPurchaseOrderMasterNotClosedForLogin(Me.Name, gUser.LoginName)
            If purchaseOrderMaster Is Nothing Then Exit Try

            lPurchaseOrderObj = purchaseOrderMaster
            TxtRemark.Text = lPurchaseOrderObj.Remark
            TxtPurchaseOrderNo.Text = lPurchaseOrderObj.Id

            flagOldObject = False

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub SetPurchaseOrderForPurchaseOrderId(ByVal id As Integer)
        Try
            lPurchaseOrderObj = Nothing
            TxtPurchaseOrderNo.Text = ""

            If id <= 0 Then Exit Try

            Dim purchaseOrderMaster As ClsPurchaseOrderMaster = GetPurchaseOrderMaster(Me.Name, id)
            If purchaseOrderMaster Is Nothing Then Exit Try

            lPurchaseOrderObj = purchaseOrderMaster
            With purchaseOrderMaster
                TxtRemark.Text = .Remark
                TxtPurchaseOrderNo.Text = .Id
            End With

            flagOldObject = True

        Catch ex As Exception
            AddToLog(ex)
        End Try

        LoadGridValuesForPurchaseOrderDetail()
    End Sub

    Private Sub UpdatePurchaseOrderDetailObject()
        Try
            If editRow Is Nothing Or lPurchaseOrderObj Is Nothing Then Exit Try

            If flagOldObject = False Then
                If AndedTheString(gUser.AuthorizationNo, Authorization.PurchaseOrder_Current_NoUpdate) = True Then Exit Sub
            Else
                If AndedTheString(gUser.AuthorizationNo, Authorization.PurchaseOrder_Old_NoUpdate) = True Then Exit Sub
            End If

            If ValidateValues() = False Then Exit Sub

            'Updating Detail
            Dim purchaseOrderDetailObj As New ClsPurchaseOrderDetail
            With purchaseOrderDetailObj
                .Id = editRow.Cells(cId).Value
                .OrderId = lPurchaseOrderObj.Id
                .ItemId = GetSelectedItemId(CmbItem)
                .ManufacturerId = GetSelectedItemId(CmbManufacturer)
                .OrderQuantity = Val(TxtOrderQuantity.Text)
                .OrderPrice = Val(TxtOrderPrice.Text)
                .PricePurchasePrevious = Val(TxtPricePurchasePrevious.Text)
                .VendorId = GetSelectedItemId(CmbVendor)
            End With

            If UpdatePurchaseOrderDetail(Me.Name, purchaseOrderDetailObj) <> EnResult.Change Then Exit Sub

            With editRow
                .Cells(cOrderId).Value = purchaseOrderDetailObj.OrderId
                .Cells(cItemId).Value = purchaseOrderDetailObj.ItemId
                .Cells(cOrderQuantity).Value = purchaseOrderDetailObj.OrderQuantity
                .Cells(cOrderPrice).Value = purchaseOrderDetailObj.OrderPrice
                .Cells(cManufacturerId).Value = purchaseOrderDetailObj.ManufacturerId
                .Cells(cPricePurchasePrevious).Value = purchaseOrderDetailObj.PricePurchasePrevious
                .Cells(cVendorId).Value = purchaseOrderDetailObj.VendorId
                .Cells(cManufacturer).Value = GetManufacturerName(.Cells(cManufacturerId).Value)
                .Cells(cVendor).Value = GetVendorName(.Cells(cVendorId).Value)
                .Cells(cName).Value = GetItemName(.Cells(cItemId).Value)
            End With

            lPurchaseOrderObj.NotClosed = True
            MsgBox("Successfully Updated", , "Updated")

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNewItem()
    End Sub

#End Region

End Class