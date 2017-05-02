Imports AIMS.Author

Public Class FrmCashReceipt

#Region "Local variables and Constants"

    Dim editRow As DataGridViewRow = Nothing

    Private Const lcVoucherNo As String = "Voucher No"

    Enum Index
        GrpCashHead
        TxtVoucherNo
        CmbCashHead
        DtPkrReceiptDate
        GrpReceiptDetails
        CmbLedger
        TxtAmount
        TxtInvoiceNo
        TxtRemark
        BtnAdd
        GrdReceipts
        GrpButtons
        BtnUpdate
        BtnCancel
        BtnRemove
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

    Private Sub FrmCashReceipt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

    Private Sub CmbCashHead_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbCashHead.KeyPress
        'AutoComplete(sender, e)
    End Sub

    Private Sub CmbLedger_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbLedger.KeyPress
        'AutoComplete(sender, e)
    End Sub

    Private Sub TxtAmount_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAmount.KeyPress
        e.Handled = Check_DecimalAllow(e.KeyChar, sender.text)
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.CashReceipt_NoAdd) = True Then Exit Sub
            If ValidateValues() = False Then Exit Sub

            Dim cashReceipt As New ClsCashReceipt
            With cashReceipt
                .Amount = Val(TxtAmount.Text)
                .InvoiceNo = TxtInvoiceNo.Text
                .DateOn = Now
                .ToHeadId = GetSelectedItemId(CmbCashHead)
                .ReceiptDate = DtPkrReceiptDate.Value
                .Remark = TxtRemark.Text
                .FromHeadId = GetSelectedItemId(CmbLedger)
                .UserId = gUser.LoginName
            End With

            Dim id As Long = InsertIntoCashReceipt(Me.Name, cashReceipt)
            If id <= 0 Then Exit Try

            cashReceipt.Id = id
            InsertIntoGrid(cashReceipt)
            MsgBox("Successfully Added")

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNewItem()
    End Sub

    Private Sub GrdReceipts_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdReceipts.CellClick
        Try
            If e.RowIndex < 0 Then Exit Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.CashReceipt_NoRemove) = True Then Exit Sub

            BtnRemove.Enabled = True
            BtnCancel.Enabled = True
            BtnAdd.Enabled = False
            BtnUpdate.Enabled = False

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub GrdReceipts_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdReceipts.CellDoubleClick
        Try
            If e.RowIndex < 0 Then Exit Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.CashReceipt_NoUpdate) = True Then Exit Sub

            editRow = GrdReceipts.Rows(e.RowIndex)
            With editRow
                TxtVoucherNo.Text = .Cells(lcVoucherNo).Value
                CmbCashHead.Text = GetCashHeadItemName(.Cells(cToHeadId).Value)
                DtPkrReceiptDate.Value = .Cells(cReceiptDate).Value
                TxtInvoiceNo.Text = .Cells(cInvoiceNo).Value
                CmbLedger.Text = GetItemNameForHeadId(.Cells(cFromHeadId).Value)
                TxtAmount.Text = .Cells(cAmount).Value
                TxtRemark.Text = .Cells(cRemark).Value
            End With

            BtnRemove.Enabled = False
            BtnCancel.Enabled = True
            BtnAdd.Enabled = False
            BtnUpdate.Enabled = True

            CmbCashHead.Focus()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub GrdReceipts_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdReceipts.KeyDown
        If e.KeyCode = Keys.Tab Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub BtnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemove.Click
        Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.CashReceipt_NoRemove) = True Then Exit Sub

            If MsgBox("Deleted record can't be recovered. Do you want to delete this record?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.No Then Exit Sub

            Dim row As DataGridViewRow = GrdReceipts.SelectedRows(0)
            If row Is Nothing Then Exit Try

            Dim id As Long = row.Cells(cId).Value
            If DeleteCashReceipt(Me.Name, id) <> EnResult.Change Then Exit Sub

            GrdReceipts.Rows.Remove(row)

            MsgBox("Record deleted successfully")
            ResetControlsToAddNewItem()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        ResetControlsToAddNewItem()
    End Sub

    Private Sub BtnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUpdate.Click
        Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.CashReceipt_NoUpdate) = True Then Exit Sub
            If editRow Is Nothing Then Exit Try
            If ValidateValues() = False Then Exit Sub

            Dim cashReceiptObj As New ClsCashReceipt
            With cashReceiptObj
                .Id = editRow.Cells(cId).Value
                .Amount = Val(TxtAmount.Text)
                .InvoiceNo = TxtInvoiceNo.Text
                .DateOn = Now
                .ToHeadId = GetSelectedItemId(CmbCashHead)
                .ReceiptDate = DtPkrReceiptDate.Value
                .Remark = TxtRemark.Text
                .FromHeadId = GetSelectedItemId(CmbLedger)
                .UserId = gUser.LoginName
            End With

            If UpdateCashReceipt(Me.Name, cashReceiptObj) <> EnResult.Change Then Exit Sub

            With editRow
                .Cells(cReceiptDate).Value = cashReceiptObj.ReceiptDate
                .Cells(cFromHeadId).Value = cashReceiptObj.FromHeadId
                .Cells(cUserId).Value = cashReceiptObj.UserId
                .Cells(cToHeadId).Value = cashReceiptObj.ToHeadId
                .Cells(cAmount).Value = cashReceiptObj.Amount
                .Cells(cInvoiceNo).Value = cashReceiptObj.InvoiceNo
                .Cells(cRemark).Value = cashReceiptObj.Remark
                .Cells(cDateOn).Value = cashReceiptObj.DateOn
                .Cells(cName).Value = GetHeadName(.Cells(cFromHeadId).Value)
            End With

            ResetControlsToAddNewItem()
            MsgBox("Successfully Updated")

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtVoucherNo.KeyDown, TxtRemark.KeyDown, TxtInvoiceNo.KeyDown, TxtAmount.KeyDown, DtPkrReceiptDate.KeyDown, CmbLedger.KeyDown, CmbCashHead.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub BtnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSearch.Click
        Try
            Dim frm As New ClsSearchCashReceiptForm
            If frm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Dim id As Long = frm.GetSelectedId
                If id > 0 Then
                    RemoveRowWithId(id)
                    Dim cashReceipt As ClsCashReceipt = GetCashReceipt(Me.Name, id)
                    InsertIntoGrid(cashReceipt)
                End If
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Try
            Dim row As DataGridViewRow = GrdReceipts.SelectedRows(0)
            If row Is Nothing Then
                MsgBox("Please select row to print slip.", , "Slip")
                Exit Try
            End If

            Dim id As Long = row.Cells(cId).Value
            If id <= 0 Then
                MsgBox("No record present or Selection is not proper. Please select row to print slip.", , "Slip")
                Exit Try
            End If

            Dim ds As DataSet = GetCashReceiptDataset(Me.Name, id)

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
            Dim rpt As New RptCashReceipt
            rpt.SetDataSource(ds.Tables(0))
            Dim dlg As New DiagReport
            dlg.RptViewer.ReportSource = rpt
            dlg.ShowDialog(Me)

        Catch ex As Exception
            AddToLog(ex)
        End Try

        SetDefaultCursor()
    End Sub

#End Region

#Region "Private Function"

    Private Sub SetControls()
        SetTabIndex()
        SetGrid()
        LoadComboBoxValues()
        ResetControlsToAddNewItem()
    End Sub

    Private Sub SetTabIndex()
        GrpReceiptDetails.TabIndex = Index.GrpReceiptDetails
        GrdReceipts.TabIndex = Index.GrdReceipts
        BtnAdd.TabIndex = Index.BtnAdd
        TxtRemark.TabIndex = Index.TxtRemark
        TxtAmount.TabIndex = Index.TxtAmount
        CmbLedger.TabIndex = Index.CmbLedger
        GrpCashHead.TabIndex = Index.GrpCashHead
        TxtVoucherNo.TabIndex = Index.TxtVoucherNo
        CmbCashHead.TabIndex = Index.CmbCashHead
        DtPkrReceiptDate.TabIndex = Index.DtPkrReceiptDate
        GrpButtons.TabIndex = Index.GrpButtons
        BtnCancel.TabIndex = Index.BtnCancel
        BtnUpdate.TabIndex = Index.BtnUpdate
        BtnClose.TabIndex = Index.BtnClose
        BtnRemove.TabIndex = Index.BtnRemove
        TxtInvoiceNo.TabIndex = Index.TxtInvoiceNo
        BtnSearch.TabIndex = Index.BtnSearch
        BtnPrint.TabIndex = Index.BtnPrint
    End Sub

    Private Sub SetGrid()
        With GrdReceipts
            Dim colCount As Integer = 10
            .RowHeadersVisible = False
            Dim defaultCellWidth As Integer = 85
            Dim x As Integer
            For x = 0 To colCount
                Select Case x
                    Case 0
                        Dim index As Integer = .Columns.Add(cId, cId)
                        .Columns(index).Visible = False

                    Case 1
                        Dim index As Integer = .Columns.Add(lcVoucherNo, lcVoucherNo)
                        .Columns(index).Visible = True
                        .Columns(index).Width = defaultCellWidth + 5

                    Case 2
                        Dim index As Integer = .Columns.Add(cName, "Ledger Name")
                        .Columns(index).Width = 190

                    Case 3
                        Dim index As Integer = .Columns.Add(cReceiptDate, cReceiptDate)
                        .Columns(index).Visible = False

                    Case 4
                        Dim index As Integer = .Columns.Add(cToHeadId, cToHeadId)
                        .Columns(index).Visible = False

                    Case 5
                        Dim index As Integer = .Columns.Add(cUserId, cUserId)
                        .Columns(index).Visible = False

                    Case 6
                        Dim index As Integer = .Columns.Add(cFromHeadId, cFromHeadId)
                        .Columns(index).Visible = False

                    Case 7
                        Dim index As Integer = .Columns.Add(cAmount, cAmount)
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 8
                        Dim index As Integer = .Columns.Add(cInvoiceNo, "Invoice No")
                        .Columns(index).Width = defaultCellWidth

                    Case 9
                        Dim index As Integer = .Columns.Add(cRemark, cRemark)
                        .Columns(index).Width = 190

                    Case 10
                        Dim index As Integer = .Columns.Add(cDateOn, cDateOn)
                        .Columns(index).Visible = False

                End Select
            Next
        End With
    End Sub

    Private Sub InsertIntoGrid(ByRef cashReceiptObj As ClsCashReceipt)
        Try
            If cashReceiptObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdReceipts.Rows.Add
            With GrdReceipts.Rows(rowIndex)
                .Cells(cId).Value = cashReceiptObj.Id
                .Cells(lcVoucherNo).Value = cCAR + CStr(.Cells(cId).Value)
                .Cells(cReceiptDate).Value = cashReceiptObj.ReceiptDate
                .Cells(cFromHeadId).Value = cashReceiptObj.FromHeadId
                .Cells(cUserId).Value = cashReceiptObj.UserId
                .Cells(cToHeadId).Value = cashReceiptObj.ToHeadId
                .Cells(cAmount).Value = cashReceiptObj.Amount
                .Cells(cInvoiceNo).Value = cashReceiptObj.InvoiceNo
                .Cells(cRemark).Value = cashReceiptObj.Remark
                .Cells(cDateOn).Value = cashReceiptObj.DateOn
                .Cells(cName).Value = GetHeadName(.Cells(cFromHeadId).Value)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub RemoveRowWithId(ByVal id As Long)
        Try
            For Each row As DataGridViewRow In GrdReceipts.Rows
                If row.Cells(cId).Value = id Then
                    GrdReceipts.Rows.Remove(row)
                    Exit Try
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadComboBoxValuesForLedger()
        Try
            CmbLedger.Items.Clear()

            Dim accountHeads() As ClsAccountHead = GetAllAccountHead(Me.Name)
            If accountHeads Is Nothing Then Exit Try

            CmbLedger.DisplayMember = cItemName
            CmbLedger.ValueMember = cId
            Dim accountHead As ClsAccountHead
            For Each accountHead In accountHeads
                CmbLedger.Items.Add(accountHead)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadComboBoxValues()
        Try
            LoadComboBoxValuesForCashHead()
            LoadComboBoxValuesForLedger()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadComboBoxValuesForCashHead()
        Try
            CmbCashHead.Items.Clear()

            Dim accountHeads() As ClsAccountHead = GetAllAccountHeadForCashInHand(Me.Name)
            If accountHeads Is Nothing Then Exit Try

            CmbCashHead.DisplayMember = cItemName
            CmbCashHead.ValueMember = cId
            Dim accountHead As ClsAccountHead
            For Each accountHead In accountHeads
                CmbCashHead.Items.Add(accountHead)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Function GetCashHeadItemName(ByVal id As Integer) As String
        Dim result As String = ""
        Try
            Dim head As ClsAccountHead
            For Each head In CmbCashHead.Items
                If head.Id = id Then
                    result = head.ItemName
                    Exit Try
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Function GetHeadName(ByVal id As Integer) As String
        Dim result As String = ""
        Try
            Dim head As ClsAccountHead
            For Each head In CmbLedger.Items
                If head.Id = id Then
                    result = head.Name
                    Exit Try
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Function GetItemNameForHeadId(ByVal headId As Integer) As String
        Dim result As String = ""
        Try
            Dim head As ClsAccountHead
            For Each head In CmbLedger.Items
                If head.Id = headId Then
                    result = head.ItemName
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

            If CmbCashHead.Text.Trim = "" Then
                ErrorInData("Please select Cash Head.", CmbCashHead)
                Exit Try
            End If

            If CmbCashHead.FindStringExact(CmbCashHead.Text.Trim) < 0 Then
                ErrorInData("Please select valid Cash Head from Cash Head list.", CmbCashHead)
                Exit Try
            End If

            If CmbLedger.Text.Trim = "" Then
                ErrorInData("Please select Ledger.", CmbLedger)
                Exit Try
            End If

            If CmbLedger.FindStringExact(CmbLedger.Text.Trim) < 0 Then
                ErrorInData("Please select valid Ledger from Ledger list.", CmbLedger)
                Exit Try
            End If

            If TxtAmount.Text.Trim = "" Then
                ErrorInData("Please enter amount.", TxtAmount)
                Exit Try
            End If

            If Val(TxtAmount.Text) <= 0 Then
                ErrorInData("Please enter amount. It should be greater then 0.", TxtAmount)
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

        TxtVoucherNo.Text = ""
        DtPkrReceiptDate.Value = Now.Date
        CmbLedger.Text = ""
        TxtInvoiceNo.Text = ""
        TxtAmount.Text = ""
        TxtRemark.Text = ""

        BtnAdd.Enabled = True
        BtnUpdate.Enabled = False
        BtnCancel.Enabled = False
        BtnRemove.Enabled = False

        CmbLedger.Focus()
    End Sub

#End Region

End Class