Public Class FrmSaleCashOut

#Region "Local variables and Constants"

    Dim lRowIndex As Integer = cInvalidId

    Dim lStorages() As ClsStorageMaster = Nothing
    Dim lItems() As ClsItemMaster = Nothing
    Dim lCustomers() As ClsCustomerMaster = Nothing
    Dim lDoctors() As ClsDoctorMaster = Nothing

    Enum Index
        GrpBills
        GrdBills
        GrpItems
        GrdItems
        TxtTotal
        TxtTax
        TxtDiscount
        TxtRoundOff
        TxtNetAmount
        TxtPreviousCashOutAmount
        TxtPreviousAdjustmentAmount
        TxtBalanceAmount
        TxtCashOutAmount
        TxtAdjustment
        BtnCashOut
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

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub GrdBills_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles GrdBills.RowsAdded
        GrdBills.Rows(e.RowIndex).Cells(cId).Value = cInvalidId
    End Sub

    Private Sub GrdBills_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GrdBills.SelectionChanged
        Try
            If GrdBills.SelectedRows.Count = 0 Then Exit Try

            lRowIndex = GrdBills.SelectedRows(0).Index

            LoadGridValuesForItems()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub GrdBills_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdBills.KeyDown
        If e.KeyCode = Keys.Tab Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub GrdItems_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdItems.KeyDown
        If e.KeyCode = Keys.Tab Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub CheckDecimalForKeyPressEvent(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTotal.KeyPress, TxtTax.KeyPress, TxtRoundOff.KeyPress, TxtPreviousCashOutAmount.KeyPress, TxtPreviousAdjustmentAmount.KeyPress, TxtNetAmount.KeyPress, TxtDiscount.KeyPress, TxtCashOutAmount.KeyPress, TxtBalanceAmount.KeyPress, TxtAdjustment.KeyPress
        e.Handled = Check_DecimalAllow(e.KeyChar, sender.text)
    End Sub

    Private Sub BtnCashOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCashOut.Click
        Try
            RemoveErrorIcon()
            If lRowIndex < 0 Then Exit Try

            Dim id As Long = GrdBills.Rows(lRowIndex).Cells(cId).Value
            If id <= 0 Then Exit Try

            If TxtCashOutAmount.Text.Trim = "" Then
                ErrorInData("Please enter cashout amount.", TxtCashOutAmount)
                Exit Try
            End If

            Dim cashOut As Double = Val(TxtCashOutAmount.Text)
            Dim adjustedAmount As Double = Val(TxtAdjustment.Text)

            Dim saleObj As ClsSalesMaster = GetSalesMaster(Me.Name, id)
            If saleObj Is Nothing Then Exit Try

            With saleObj
                .CashOutAmount = .CashOutAmount + cashOut
                .AdjustedAmount = adjustedAmount

                Dim totalCashout As Double = .CashOutAmount
                Dim bal As Double = Val(TxtNetAmount.Text) - totalCashout
                If bal - adjustedAmount < 1 Or bal + adjustedAmount < 1 Then
                    .CashMemo = False    'Close to cash out
                Else
                    .CashMemo = True     'Open to cash out
                End If
                .ForCashOut = True
            End With

            If UpdateSalesMaster(Me.Name, saleObj) <> EnResult.Change Then Exit Sub

            TxtCashOutAmount.Text = ""
            TxtAdjustment.Text = ""

            MsgBox("Cashed Out successfully.", , "Done")
            LoadGridValuesForBills()
            LoadGridValuesForItems()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub FrmSaleCashOut_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtTotal.KeyDown, TxtTax.KeyDown, TxtRoundOff.KeyDown, TxtPreviousCashOutAmount.KeyDown, TxtPreviousAdjustmentAmount.KeyDown, TxtNetAmount.KeyDown, TxtDiscount.KeyDown, TxtCashOutAmount.KeyDown, TxtBalanceAmount.KeyDown, TxtAdjustment.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

#End Region

#Region "Private Functions"

    Private Sub SetControls()
        SetTabIndex()
        SetGridForBills()
        SetGridForItems()
        LoadStorages()
        LoadItems()
        LoadCustomers()
        LoadDoctors()

        LoadGridValuesForBills()
        LoadGridValuesForItems()
    End Sub

    Private Sub SetTabIndex()
        GrpBills.TabIndex = Index.GrpBills
        GrdBills.TabIndex = Index.GrdBills
        GrpItems.TabIndex = Index.GrpItems
        GrdItems.TabIndex = Index.GrdItems
        TxtTotal.TabIndex = Index.TxtTotal
        TxtTax.TabIndex = Index.TxtTax
        TxtDiscount.TabIndex = Index.TxtDiscount
        TxtRoundOff.TabIndex = Index.TxtRoundOff
        TxtNetAmount.TabIndex = Index.TxtNetAmount
        TxtPreviousCashOutAmount.TabIndex = Index.TxtPreviousCashOutAmount
        TxtPreviousAdjustmentAmount.TabIndex = Index.TxtPreviousAdjustmentAmount
        TxtBalanceAmount.TabIndex = Index.TxtBalanceAmount
        TxtCashOutAmount.TabIndex = Index.TxtCashOutAmount
        TxtAdjustment.TabIndex = Index.TxtAdjustment
        BtnCashOut.TabIndex = Index.BtnCashOut
        BtnClose.TabIndex = Index.BtnClose
    End Sub

    Private Sub SetGridForBills()
        With GrdBills
            Dim colCount As Integer = 11
            .RowHeadersVisible = False
            Dim defaultCellWidth As Integer = 100
            Dim x As Integer
            For x = 0 To colCount
                Select Case x
                    Case 0
                        Dim index As Integer = .Columns.Add(cId, cId)
                        .Columns(index).Visible = False

                    Case 1
                        Dim index As Integer = .Columns.Add(cSaleCode, "Sale Code")
                        .Columns(index).Width = 90

                    Case 2
                        Dim index As Integer = .Columns.Add(cSaleDate, "Sale Date")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "dd-MM-yyyy"

                    Case 3
                        Dim index As Integer = .Columns.Add(cCustomerId, cCustomerId)
                        .Columns(index).Visible = False

                    Case 4
                        'Dim index As Integer = .Columns.Add(cDoctorId, cDoctorId)
                        '.Columns(index).Visible = False

                    Case 5
                        Dim index As Integer = .Columns.Add(cCustomerName, "Customer Name")
                        .Columns(index).Width = 140

                    Case 6
                        'Dim index As Integer = .Columns.Add(cDoctorName, "Doctor Name")
                        '.Columns(index).Width = 140

                    Case 7
                        Dim index As Integer = .Columns.Add(cMode, "Status")
                        .Columns(index).Width = defaultCellWidth

                    Case 8
                        Dim index As Integer = .Columns.Add(cTotal, "Net Sale")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 9
                        Dim index As Integer = .Columns.Add(cCashOutAmount, "Net CashOut")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 10
                        Dim index As Integer = .Columns.Add(cBalance, cBalance)
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 11
                        Dim index As Integer = .Columns.Add(cAdjustedAmount, cAdjustedAmount)
                        .Columns(index).Visible = False

                End Select
            Next
        End With
    End Sub

    Private Sub SetGridForItems()
        With GrdItems
            Dim colCount As Integer = 18
            .RowHeadersVisible = False
            Dim defaultCellWidth As Integer = 83
            Dim x As Integer
            For x = 0 To colCount
                Select Case x
                    Case 0
                        Dim index As Integer = .Columns.Add(cId, cId)
                        .Columns(index).Visible = False

                    Case 1
                        Dim index As Integer = .Columns.Add(cName, cName)
                        .Columns(index).Width = 120

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
                        Dim index As Integer = .Columns.Add(cSaleQuantity, "Sale Qty")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 5
                        Dim index As Integer = .Columns.Add(cPriceSale, "S. Price")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 6
                        Dim index As Integer = .Columns.Add(cPackQuantity, "Pack Qty.")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 7
                        Dim index As Integer = .Columns.Add(cUserId, cUserId)
                        .Columns(index).Visible = False

                    Case 8
                        Dim index As Integer = .Columns.Add(cTaxAmount, "Tax")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 9
                        Dim index As Integer = .Columns.Add(cDateOn, cDateOn)
                        .Columns(index).Visible = False

                    Case 10
                        Dim index As Integer = .Columns.Add(cDiscountAmount, "Discount")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 11
                        Dim index As Integer = .Columns.Add(cStorage, cStorage)
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

                End Select
            Next
        End With
    End Sub

    Private Sub LoadGridValuesForBills()
        Try
            GrdBills.Rows.Clear()
            lRowIndex = cInvalidId

            Dim sales() As ClsSalesMaster = GetAllSalesMasterForCashOut(Me.Name)
            If sales Is Nothing Then Exit Try

            Dim sale As ClsSalesMaster
            For Each sale In sales
                InsertIntoBillGrid(sale)
            Next

            If GrdBills.Rows.Count > 0 Then lRowIndex = 0

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub InsertIntoBillGrid(ByRef salesObj As ClsSalesMaster)
        Try
            If salesObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdBills.Rows.Add
            With GrdBills.Rows(rowIndex)
                .Cells(cId).Value = salesObj.Id
                .Cells(cSaleCode).Value = salesObj.SaleCode
                .Cells(cSaleDate).Value = salesObj.SaleDate
                .Cells(cCustomerId).Value = salesObj.CustomerId
                '.Cells(cDoctorId).Value = salesObj.DoctorId
                .Cells(cMode).Value = salesObj.Mode
                .Cells(cCashOutAmount).Value = salesObj.CashOutAmount
                .Cells(cAdjustedAmount).Value = salesObj.AdjustedAmount
                .Cells(cTotal).Value = GetSalesMasterNetAmount(Me.Name, .Cells(cId).Value)
                .Cells(cBalance).Value = Val(.Cells(cTotal).Value) - Val(.Cells(cCashOutAmount).Value)
                .Cells(cCustomerName).Value = GetCustomerName(.Cells(cCustomerId).Value)
                '.Cells(cDoctorName).Value = GetDoctorName(.Cells(cDoctorId).Value)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadGridValuesForItems()
        Try
            GrdItems.Rows.Clear()

            If lRowIndex < 0 Then Exit Try

            Dim id As Long = GrdBills.Rows(lRowIndex).Cells(cId).Value
            If id <= 0 Then Exit Try

            Dim saleDetails() As ClsSalesDetail = GetAllSalesDetailForSalesId(Me.Name, id)
            If saleDetails Is Nothing Then Exit Try

            Dim saleDetail As ClsSalesDetail
            For Each saleDetail In saleDetails
                InsertIntoItemGrid(saleDetail)
            Next

            CalculateTotals()
            TxtCashOutAmount.Focus()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub InsertIntoItemGrid(ByRef saleDetailObj As ClsSalesDetail)
        Try
            If saleDetailObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdItems.Rows.Add
            With GrdItems.Rows(rowIndex)
                .Cells(cId).Value = saleDetailObj.Id
                .Cells(cItemId).Value = saleDetailObj.ItemId
                .Cells(cStorageId).Value = saleDetailObj.StorageId
                .Cells(cBatch).Value = saleDetailObj.Batch
                .Cells(cExpiryDate).Value = saleDetailObj.ExpiryDate
                .Cells(cSaleQuantity).Value = saleDetailObj.SaleQuantity
                .Cells(cPriceSale).Value = saleDetailObj.PriceSale
                .Cells(cPackQuantity).Value = saleDetailObj.PackQuantity
                .Cells(cTaxAmount).Value = saleDetailObj.TaxAmount
                .Cells(cDiscountAmount).Value = saleDetailObj.DiscountAmount
                .Cells(cTotal).Value = saleDetailObj.GetTotal
                .Cells(cStorage).Value = GetStorageName(.Cells(cStorageId).Value)
                .Cells(cName).Value = GetItemName(.Cells(cItemId).Value)
                .Cells(cSaleId).Value = saleDetailObj.SaleId
                .Cells(cPricePurchase).Value = saleDetailObj.PricePurchase
                .Cells(cRemark).Value = saleDetailObj.Remark
                .Cells(cForCashOut).Value = True
                .Cells(cUserId).Value = saleDetailObj.UserId
                .Cells(cDateOn).Value = saleDetailObj.DateOn
            End With

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

    Private Sub LoadItems()
        Try
            lItems = GetAllItemMaster(Me.Name, False)

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadCustomers()
        Try
            lCustomers = GetAllCustomerMaster(Me.Name)

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadDoctors()
        Try
            lDoctors = GetAllDoctorMaster(Me.Name)

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

    Private Function GetCustomerName(ByVal id As Integer) As String
        Dim result As String = ""
        Try
            If lCustomers Is Nothing Then Exit Try

            Dim customer As ClsCustomerMaster
            For Each customer In lCustomers
                If customer.Id = id Then
                    result = customer.Name
                    Exit Try
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Function GetDoctorName(ByVal id As Integer) As String
        Dim result As String = ""
        Try
            If lDoctors Is Nothing Then Exit Try

            Dim doctor As ClsDoctorMaster
            For Each doctor In lDoctors
                If doctor.Id = id Then
                    result = doctor.Name
                    Exit Try
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Sub CalculateTotals()
        Try
            TxtTotal.Text = ""
            TxtTax.Text = ""
            TxtDiscount.Text = ""
            TxtRoundOff.Text = ""
            TxtNetAmount.Text = ""
            TxtPreviousCashOutAmount.Text = ""
            TxtPreviousAdjustmentAmount.Text = ""
            TxtBalanceAmount.Text = ""

            If GrdItems.Rows.Count = 0 Then Exit Try
            If lRowIndex < 0 Then Exit Try

            With GrdBills.Rows(lRowIndex)
                TxtNetAmount.Text = Format(.Cells(cTotal).Value, "0.00")
                TxtPreviousCashOutAmount.Text = Format(.Cells(cCashOutAmount).Value, "0.00")
                TxtPreviousAdjustmentAmount.Text = Format(.Cells(cAdjustedAmount).Value, "0.00")
            End With

            Dim total As Double = 0
            Dim tax As Double = 0
            Dim discount As Double = 0
            Dim row As DataGridViewRow
            For Each row In GrdItems.Rows
                With row
                    total += Val(.Cells(cSaleQuantity).Value) * Val(.Cells(cPriceSale).Value)
                    tax += Val(.Cells(cTaxAmount).Value)
                    discount += Val(.Cells(cDiscountAmount).Value)
                End With
            Next

            TxtTotal.Text = Format(total, "0.00")
            TxtTax.Text = Format(tax, "0.00")
            TxtDiscount.Text = Format(discount, "0.00")

            Dim temp As Double = Val(TxtTotal.Text) + Val(TxtTax.Text) - Val(TxtDiscount.Text)
            Dim netAmount As Double = GetSqlRound(Me.Name, temp)
            TxtRoundOff.Text = Format(netAmount - temp, "0.00")
            TxtNetAmount.Text = Format(netAmount, "0.00")
            TxtBalanceAmount.Text = Format(Val(TxtNetAmount.Text) - Val(TxtPreviousCashOutAmount.Text), "0.00")

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

#End Region

End Class