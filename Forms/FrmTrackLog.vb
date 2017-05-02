Imports System.Windows.Forms

Public Class FrmTrackLog

#Region "Private variables"

    Private Const lcSales As String = "Sales"
    Private Const lcPurchase As String = "Purchase"
    Private Const lcDestruction As String = "Destruction"

    Dim lStorages() As ClsStorageMaster = Nothing
    Dim lItems() As ClsItemMaster = Nothing

    Dim lRecordsFor As String = ""

#End Region

#Region "Control Functions"

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub FrmTrackLog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

    Private Sub BtnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShow.Click
        Dim trackLogs() As ClsTrackLog = Nothing

        If CmbTransactionType.Text = lcSales Then
            lRecordsFor = lcSales
            trackLogs = GetAllTrackLogForSales(Me.Name, DtPkrAfter.Value)

        ElseIf CmbTransactionType.Text = lcDestruction Then
            lRecordsFor = lcDestruction
            trackLogs = GetAllTrackLogForDestructionSlip(Me.Name, DtPkrAfter.Value)

        ElseIf CmbTransactionType.Text = lcPurchase Then
            lRecordsFor = lcPurchase
            trackLogs = GetAllTrackLogForPurchase(Me.Name, DtPkrAfter.Value)

        End If

        FillGrid(trackLogs)
    End Sub

    Private Sub GrdMasterLog_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdMasterLog.CellDoubleClick
        Try
            If lRecordsFor = "" Then Exit Try
            If e.RowIndex < 0 Then Exit Try

            Dim code As String = GrdMasterLog.Rows(e.RowIndex).Cells(cBillNo).Value
            If code.Trim = "" Then Exit Try

            If lRecordsFor = lcSales Then
                SetGridForSale()
                LoadGridValuesForSale(code)

            ElseIf lRecordsFor = lcDestruction Then
                SetGridForDestructionSlip()
                LoadGridValuesForDestructionSlip(code)

            ElseIf lRecordsFor = lcPurchase Then
                SetGridForPurchase()
                LoadGridValuesForPurchase(code)

            End If

            TabLog.SelectedTab = TabLogDetail

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

#End Region

#Region "Private Functions"

    Private Sub SetControls()
        With CmbTransactionType
            .Items.Add(lcSales)
            .Items.Add(lcPurchase)
            .Items.Add(lcDestruction)

            .SelectedIndex = 0
        End With

        DtPkrAfter.Value = Now.Date
        SetMasterGrid()
        LoadItems()
        LoadStorages()
    End Sub

    Private Sub SetMasterGrid()
        With GrdMasterLog
            Dim colCount As Integer = 3
            .RowHeadersVisible = False
            Dim defaultCellWidth As Integer = 150
            Dim x As Integer
            For x = 0 To colCount
                Select Case x
                    Case 0
                        Dim index As Integer = .Columns.Add(cDiff, "Difference in hrs")
                        .Columns(index).Width = defaultCellWidth

                    Case 1
                        Dim index As Integer = .Columns.Add(cBillNo, "Bill/Inv. Etc.")
                        .Columns(index).Width = defaultCellWidth + 50

                    Case 2
                        Dim index As Integer = .Columns.Add(cUserId, "Login")
                        .Columns(index).Width = defaultCellWidth + 80

                    Case 3
                        Dim index As Integer = .Columns.Add(cDateOn, "Date Time")
                        .Columns(index).Width = defaultCellWidth + 50
                        .Columns(index).DefaultCellStyle.Format = "dd/MM/yyyy hh:mm tt"

                End Select
            Next
        End With
    End Sub

    Private Sub FillGrid(ByRef trackLogs() As ClsTrackLog)
        Try
            GrdMasterLog.Rows.Clear()

            If trackLogs Is Nothing Then Exit Try

            For Each trackLog As ClsTrackLog In trackLogs
                InsertIntoMasterGrid(trackLog)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub InsertIntoMasterGrid(ByRef trackLog As ClsTrackLog)
        Try
            If trackLog Is Nothing Then Exit Try

            Dim index As Integer = GrdMasterLog.Rows.Add
            With GrdMasterLog.Rows(index)
                .Cells(cBillNo).Value = trackLog.BillNo
                .Cells(cDateOn).Value = trackLog.DateOn
                .Cells(cDiff).Value = trackLog.Diff
                .Cells(cUserId).Value = trackLog.UserId
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

#End Region

#Region "Common Functions"

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

#End Region

#Region "Sales"

    Private Sub SetGridForSale()
        With GrdLogDetail
            .Columns.Clear()
            Dim colCount As Integer = 20
            .RowHeadersVisible = False
            Dim defaultCellWidth As Integer = 80
            Dim x As Integer
            For x = 0 To colCount
                Select Case x
                    Case 0
                        Dim index As Integer = .Columns.Add(cUserId, "Login Id")
                        .Columns(index).Width = defaultCellWidth + 60

                    Case 1
                        Dim index As Integer = .Columns.Add(cDateOn, "Date On")
                        .Columns(index).Width = defaultCellWidth + 50
                        .Columns(index).DefaultCellStyle.Format = "dd/MM/yyyy hh:mm tt"

                    Case 2
                        Dim index As Integer = .Columns.Add(cId, cId)
                        .Columns(index).Visible = False

                    Case 3
                        Dim index As Integer = .Columns.Add(cName, cName)
                        .Columns(index).Width = defaultCellWidth + 90

                    Case 4
                        Dim index As Integer = .Columns.Add(cBatch, cBatch)
                        .Columns(index).Width = defaultCellWidth + 30
                        .Columns(index).Visible = False

                    Case 5
                        Dim index As Integer = .Columns.Add(cExpiryDate, "Exp. Date")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "MMM-yyyy"
                        .Columns(index).Visible = False

                    Case 6
                        Dim index As Integer = .Columns.Add(cSaleQuantity, "Sale Qty")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 7
                        Dim index As Integer = .Columns.Add(cPriceSale, "S. Price")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 8
                        Dim index As Integer = .Columns.Add(cPackQuantity, "Pack Qty.")
                        .Columns(index).Visible = False
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 9
                        Dim index As Integer = .Columns.Add(cTaxPercent, "Tax %")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns(index).Visible = False

                    Case 10
                        Dim index As Integer = .Columns.Add(cTaxAmount, "Tax")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns(index).Visible = False

                    Case 11
                        Dim index As Integer = .Columns.Add(cDiscountPercent, "Dis. %")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns(index).Visible = False

                    Case 12
                        Dim index As Integer = .Columns.Add(cDiscountAmount, "Discount")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns(index).Visible = False

                    Case 13
                        Dim index As Integer = .Columns.Add(cStorage, cStorage)
                        .Columns(index).Visible = False
                        .Columns(index).Width = defaultCellWidth

                    Case 14
                        Dim index As Integer = .Columns.Add(cTotal, cTotal)
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 15
                        Dim index As Integer = .Columns.Add(cSaleId, cSaleId)
                        .Columns(index).Visible = False

                    Case 16
                        Dim index As Integer = .Columns.Add(cPricePurchase, cPricePurchase)
                        .Columns(index).Visible = False

                    Case 17
                        Dim index As Integer = .Columns.Add(cRemark, cRemark)
                        .Columns(index).Visible = False

                    Case 18
                        Dim index As Integer = .Columns.Add(cForCashOut, cForCashOut)
                        .Columns(index).Visible = False

                    Case 19
                        Dim index As Integer = .Columns.Add(cItemId, cItemId)
                        .Columns(index).Visible = False

                    Case 20
                        Dim index As Integer = .Columns.Add(cStorageId, cStorageId)
                        .Columns(index).Visible = False

                End Select
            Next
        End With
    End Sub

    Private Sub LoadGridValuesForSale(ByVal code As String)
        Try
            GrdLogDetail.Rows.Clear()

            Dim saleDetails() As ClsSalesDetail = GetAllSalesDetailForSalesCode(Me.Name, code)
            If saleDetails Is Nothing Then Exit Try

            Dim saleDetail As ClsSalesDetail
            For Each saleDetail In saleDetails
                InsertIntoSaleGrid(saleDetail)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub InsertIntoSaleGrid(ByRef saleDetailObj As ClsSalesDetail)
        Try
            If saleDetailObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdLogDetail.Rows.Add
            With GrdLogDetail.Rows(rowIndex)
                .Cells(cId).Value = saleDetailObj.Id
                .Cells(cItemId).Value = saleDetailObj.ItemId
                .Cells(cStorageId).Value = saleDetailObj.StorageId
                .Cells(cBatch).Value = saleDetailObj.Batch
                .Cells(cExpiryDate).Value = saleDetailObj.ExpiryDate
                .Cells(cSaleQuantity).Value = saleDetailObj.SaleQuantity
                .Cells(cPriceSale).Value = saleDetailObj.PriceSale
                .Cells(cPackQuantity).Value = saleDetailObj.PackQuantity
                .Cells(cTaxPercent).Value = saleDetailObj.TaxPercent
                .Cells(cTaxAmount).Value = saleDetailObj.TaxAmount
                .Cells(cDiscountPercent).Value = saleDetailObj.DiscountPercent
                .Cells(cDiscountAmount).Value = saleDetailObj.DiscountAmount
                .Cells(cTotal).Value = saleDetailObj.GetTotal
                .Cells(cStorage).Value = GetStorageName(.Cells(cStorageId).Value)
                .Cells(cName).Value = GetItemName(.Cells(cItemId).Value)
                .Cells(cSaleId).Value = saleDetailObj.SaleId
                .Cells(cPricePurchase).Value = saleDetailObj.PricePurchase
                .Cells(cRemark).Value = saleDetailObj.Remark
                .Cells(cForCashOut).Value = False
                .Cells(cUserId).Value = saleDetailObj.UserId
                .Cells(cDateOn).Value = saleDetailObj.DateOn
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

#End Region

#Region "Purchase"

    Private Sub SetGridForPurchase()
        With GrdLogDetail
            .Columns.Clear()
            Dim colCount As Integer = 18
            .RowHeadersVisible = False
            Dim defaultCellWidth As Integer = 80
            Dim x As Integer
            For x = 0 To colCount
                Select Case x
                    Case 0
                        Dim index As Integer = .Columns.Add(cUserId, "Login Id")
                        .Columns(index).Width = defaultCellWidth

                    Case 1
                        Dim index As Integer = .Columns.Add(cDateOn, "Date On")
                        .Columns(index).Width = defaultCellWidth + 50
                        .Columns(index).DefaultCellStyle.Format = "dd/MM/yyyy hh:mm tt"

                    Case 2
                        Dim index As Integer = .Columns.Add(cName, "Item Name")
                        .Columns(index).Width = defaultCellWidth + 40

                    Case 3
                        Dim index As Integer = .Columns.Add(cItemId, cItemId)
                        .Columns(index).Visible = False

                    Case 4
                        Dim index As Integer = .Columns.Add(cBatch, cBatch)
                        .Columns(index).Width = defaultCellWidth + 40
                        .Columns(index).Visible = False

                    Case 5
                        Dim index As Integer = .Columns.Add(cStorage, cStorage)
                        .Columns(index).Width = defaultCellWidth

                    Case 6
                        Dim index As Integer = .Columns.Add(cExpiryDate, "Exp. Date")
                        .Columns(index).Width = defaultCellWidth + 10
                        .Columns(index).DefaultCellStyle.Format = "MMM-yyyy"
                        .Columns(index).Visible = False

                    Case 7
                        Dim index As Integer = .Columns.Add(cPackQuantity, "Pack Qty.")
                        .Columns(index).Width = defaultCellWidth

                    Case 8
                        Dim index As Integer = .Columns.Add(cPurchaseQuantity, "Pur. Qty.")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 9
                        Dim index As Integer = .Columns.Add(cPricePurchase, "Pur. Price")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 10
                        Dim index As Integer = .Columns.Add(cPriceSale, "Sale Price")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 11
                        Dim index As Integer = .Columns.Add(cTaxPercent, "Tax %")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns(index).Visible = False

                    Case 12
                        Dim index As Integer = .Columns.Add(cTaxAmount, "Tax Amt.")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns(index).Visible = False

                    Case 13
                        Dim index As Integer = .Columns.Add(cDiscountPercent, "Dis. %")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns(index).Visible = False

                    Case 14
                        Dim index As Integer = .Columns.Add(cDiscountAmount, "Dis. Amt.")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns(index).Visible = False

                    Case 15
                        Dim index As Integer = .Columns.Add(cId, cId)
                        .Columns(index).Visible = False

                    Case 16
                        Dim index As Integer = .Columns.Add(cPurchaseId, cPurchaseId)
                        .Columns(index).Visible = False

                    Case 17
                        Dim index As Integer = .Columns.Add(cFreeQuantity, "Free Qty.")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns(index).Visible = False

                    Case 18
                        Dim index As Integer = .Columns.Add(cStorageId, cStorageId)
                        .Columns(index).Visible = False

                End Select
            Next
        End With
    End Sub

    Private Sub LoadGridValuesForPurchase(ByVal code As String)
        Try
            GrdLogDetail.Rows.Clear()

            Dim purchaseDetails() As ClsPurchaseDetail = GetAllPurchaseDetailForPurchaseCode(Me.Name, code)
            If purchaseDetails Is Nothing Then Exit Try

            Dim purchaseDetail As ClsPurchaseDetail
            For Each purchaseDetail In purchaseDetails
                InsertIntoGrid(purchaseDetail)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub InsertIntoGrid(ByRef purchaseDetailObj As ClsPurchaseDetail)
        Try
            If purchaseDetailObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdLogDetail.Rows.Add
            With GrdLogDetail.Rows(rowIndex)
                .Cells(cId).Value = purchaseDetailObj.Id
                .Cells(cPurchaseId).Value = purchaseDetailObj.PurchaseId
                .Cells(cItemId).Value = purchaseDetailObj.ItemId
                .Cells(cName).Value = GetItemName(.Cells(cItemId).Value)
                .Cells(cBatch).Value = purchaseDetailObj.Batch
                .Cells(cExpiryDate).Value = purchaseDetailObj.ExpiryDate
                .Cells(cPricePurchase).Value = purchaseDetailObj.PricePurchase
                .Cells(cPriceSale).Value = 0 'purchaseDetailObj.PriceSale
                .Cells(cTaxPercent).Value = purchaseDetailObj.TaxPercent
                .Cells(cTaxAmount).Value = purchaseDetailObj.TaxAmount
                .Cells(cDiscountPercent).Value = purchaseDetailObj.DiscountPercent
                .Cells(cDiscountAmount).Value = purchaseDetailObj.DiscountAmount
                .Cells(cPackQuantity).Value = purchaseDetailObj.PackQuantity
                .Cells(cPurchaseQuantity).Value = purchaseDetailObj.PurchaseQuantity
                .Cells(cUserId).Value = purchaseDetailObj.UserId
                .Cells(cDateOn).Value = purchaseDetailObj.DateOn
                .Cells(cFreeQuantity).Value = purchaseDetailObj.FreeQuantity
                .Cells(cStorageId).Value = purchaseDetailObj.StorageId
                .Cells(cStorage).Value = GetStorageName(.Cells(cStorageId).Value)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

#End Region

#Region "Destruction"

    Private Sub SetGridForDestructionSlip()
        With GrdLogDetail
            .Columns.Clear()
            Dim colCount As Integer = 19
            .RowHeadersVisible = False
            Dim defaultCellWidth As Integer = 90
            Dim x As Integer
            For x = 0 To colCount
                Select Case x
                    Case 0
                        Dim index As Integer = .Columns.Add(cUserId, cUserId)
                        .Columns(index).Width = defaultCellWidth

                    Case 1
                        Dim index As Integer = .Columns.Add(cDateOn, cDateOn)
                        .Columns(index).Width = defaultCellWidth + 50
                        .Columns(index).DefaultCellStyle.Format = "dd/MM/yyyy hh:mm tt"

                    Case 2
                        Dim index As Integer = .Columns.Add(cName, cName)
                        .Columns(index).Width = defaultCellWidth + 50

                    Case 3
                        Dim index As Integer = .Columns.Add(cBatch, cBatch)
                        .Columns(index).Width = defaultCellWidth

                    Case 4
                        Dim index As Integer = .Columns.Add(cExpiryDate, "Exp. Date")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "MMM-yyyy"
                        .Columns(index).Visible = False

                    Case 5
                        Dim index As Integer = .Columns.Add(cDestructionQuantity, "Des. Qty")
                        .Columns(index).Width = defaultCellWidth - 10
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 6
                        Dim index As Integer = .Columns.Add(cPricePurchase, "Pur. Price")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 7
                        Dim index As Integer = .Columns.Add(cPackQuantity, "Pack Qty.")
                        .Columns(index).Width = defaultCellWidth - 10
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

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
                        Dim index As Integer = .Columns.Add(cTaxPercent, "Tax %")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Columns(index).Visible = False

                    Case 19
                        Dim index As Integer = .Columns.Add(cId, cId)
                        .Columns(index).Visible = False

                End Select
            Next
        End With
    End Sub

    Private Sub LoadGridValuesForDestructionSlip(ByVal code As String)
        Try
            GrdLogDetail.Rows.Clear()

            Dim destructionSlipDetails() As ClsDestructionSlipDetail = GetAllDestructionSlipDetailForDestructionSlipCode(Me.Name, code)
            If destructionSlipDetails Is Nothing Then Exit Try

            Dim destructionSlipDetail As ClsDestructionSlipDetail
            For Each destructionSlipDetail In destructionSlipDetails
                InsertIntoDestructionSlipGrid(destructionSlipDetail)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub InsertIntoDestructionSlipGrid(ByRef destructionSlipDetailObj As ClsDestructionSlipDetail)
        Try
            If destructionSlipDetailObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdLogDetail.Rows.Add
            With GrdLogDetail.Rows(rowIndex)
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

#End Region

End Class
