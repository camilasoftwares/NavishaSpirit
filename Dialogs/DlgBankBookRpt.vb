Imports System.Windows.Forms

Public Class DlgBankBookRpt

#Region "Local variables and Constants"

    Dim dsChequePayment As DataSet = Nothing
    Dim dsChequeReceipt As DataSet = Nothing
    Dim dsCashPayment As DataSet = Nothing
    Dim dsCashReceipt As DataSet = Nothing

    Enum Index
        GrpHead
        CmbHeads
        GrpCondition
        OptAll
        OptOnDate
        OptBetweenDates
        DtPkrDateFrom
        DtPkrDateTo
        BtnShow
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

    Private Sub DlgBankBookRpt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

    Private Sub OptAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptAll.CheckedChanged
        SetEnabilityForOptions()
    End Sub

    Private Sub OptOnDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptOnDate.CheckedChanged
        SetEnabilityForOptions()
    End Sub

    Private Sub OptBetweenDates_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptBetweenDates.CheckedChanged
        SetEnabilityForOptions()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub BtnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShow.Click
        ShowReport()
    End Sub

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles OptOnDate.KeyDown, OptBetweenDates.KeyDown, OptAll.KeyDown, DtPkrDateTo.KeyDown, DtPkrDateFrom.KeyDown, CmbHeads.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

#End Region

#Region "Private Functions"

    Private Sub SetControls()
        SetTabIndex()
        FillComboBoxValuesForHeads()
        DtPkrDateFrom.Value = Now.Date
        DtPkrDateTo.Value = Now.Date

        CmbHeads.Focus()
    End Sub

    Private Sub SetTabIndex()
        GrpHead.TabIndex = Index.GrpHead
        CmbHeads.TabIndex = Index.CmbHeads
        GrpCondition.TabIndex = Index.GrpCondition
        OptAll.TabIndex = Index.OptAll
        OptOnDate.TabIndex = Index.OptOnDate
        OptBetweenDates.TabIndex = Index.OptBetweenDates
        DtPkrDateFrom.TabIndex = Index.DtPkrDateFrom
        DtPkrDateTo.TabIndex = Index.DtPkrDateTo
        BtnClose.TabIndex = Index.BtnClose
        BtnShow.TabIndex = Index.BtnShow
    End Sub

    Private Sub FillComboBoxValuesForHeads()
        Try
            CmbHeads.Items.Clear()

            Dim heads() As ClsAccountHead = GetAllAccountHeadForBankAccount(Me.Name)
            If heads Is Nothing Then Exit Try

            CmbHeads.DisplayMember = cName
            CmbHeads.ValueMember = cId
            Dim head As ClsAccountHead
            For Each head In heads
                CmbHeads.Items.Add(head)
            Next

            If CmbHeads.Items.Count > 0 Then CmbHeads.SelectedIndex = 0

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub SetEnabilityForOptions()
        If OptAll.Checked = True Then
            DtPkrDateFrom.Enabled = False
            DtPkrDateTo.Enabled = False
        ElseIf OptOnDate.Checked = True Then
            DtPkrDateFrom.Enabled = True
            DtPkrDateTo.Enabled = False
        ElseIf OptBetweenDates.Checked = True Then
            DtPkrDateFrom.Enabled = True
            DtPkrDateTo.Enabled = True
        End If
    End Sub

    Private Sub ShowReport()
        Try
            RemoveErrorIcon()

            Dim dateFrom As Date = DateDefault
            Dim dateTo As Date = Now
            Dim headId As Integer = GetSelectedItemId(CmbHeads)
            If headId <= 0 Then
                ErrorInData("Please select Account/Ledger Head.", CmbHeads)
                Exit Try
            End If

            Dim dateStr As String = "ALL DATES"
            If OptOnDate.Checked = True Then
                dateFrom = DtPkrDateFrom.Value.Date
                dateTo = DtPkrDateFrom.Value.Date.AddDays(1).AddMilliseconds(-1)
                dateStr = Format(dateFrom, "dd/MM/yyyy")
            ElseIf OptBetweenDates.Checked = True Then
                dateFrom = DtPkrDateFrom.Value.Date
                dateTo = DtPkrDateTo.Value.Date.AddDays(1).AddMilliseconds(-1)
                dateStr = Format(dateFrom, "dd/MM/yyyy") + " - " + Format(dateTo, "dd/MM/yyyy")
            End If

            Dim ds As DataSet = GetBankBookForHeadId(Me.Name, headId, dateFrom, dateTo)

            If ds Is Nothing Then
                MsgBox("Error in generating report.", MsgBoxStyle.Critical, "Error")
                Exit Try
            End If

            If ds.Tables(0).Rows.Count = 0 Then
                MsgBox("No record is present for this selection.", MsgBoxStyle.Information, "No Record")
                Exit Try
            End If

            'Finding Exact Opening balance
            Dim OpBalance As Double = 0
            Dim OpCr As Double = 0
            Dim OpDr As Double = 0
            Dim dt As DataSet = GetCrDrOpeningBalance(Me.Name, headId, dateFrom)
            If Not (dt Is Nothing) Then
                With dt.Tables(0).Rows(0)
                    OpCr = Val(.Item(cCrAmount))
                    OpDr = Val(.Item(cDrAmount))
                    OpBalance = Val(.Item(cOpeningBalance))
                    If OpBalance > 0 Then
                        OpDr = OpDr + OpBalance
                    ElseIf OpBalance < 0 Then
                        OpCr = OpCr + OpBalance
                    End If

                    OpBalance = OpDr - OpCr
                    If OpBalance > 0 Then
                        OpDr = OpBalance
                        OpCr = 0
                    Else
                        OpCr = -OpBalance
                        OpDr = 0
                    End If
                End With
            End If

            LoadDataSetsForHeadId(headId)
            SetDataSetNameFieldsValue(ds)

            Dim titleName As String = CmbHeads.Text.Trim

            'Opening Report
            SetWaitCursor()
            Dim rpt As New RptBankBook
            rpt.SetDataSource(ds.Tables(0))
            rpt.SetParameterValue("TitleName", titleName)
            rpt.SetParameterValue("OpBalance", OpBalance)
            rpt.SetParameterValue("OpCr", OpCr)
            rpt.SetParameterValue("OpDr", OpDr)
            rpt.SetParameterValue("DateStr", dateStr)
            Dim dlg As New DiagReport
            dlg.RptViewer.ReportSource = rpt
            dlg.ShowDialog(Me)

        Catch ex As Exception
            AddToLog(ex)
        End Try

        SetDefaultCursor()
    End Sub

    Private Sub LoadDataSetsForHeadId(ByVal headId As Integer)
        dsChequePayment = GetIdNameFromChequePaymentForHeadId(Me.Name, headId)
        dsChequeReceipt = GetIdNameFromChequeReceiptForHeadId(Me.Name, headId)
        dsCashPayment = GetIdNameFromCashPaymentForHeadId(Me.Name, headId)
        dsCashReceipt = GetIdNameFromCashReceiptForHeadId(Me.Name, headId)
    End Sub

    Private Sub SetDataSetNameFieldsValue(ByRef ds As DataSet)
        Try
            If ds Is Nothing Then Exit Try

            Dim dtRow As DataRow
            For Each dtRow In ds.Tables(0).Rows
                With dtRow
                    Dim strVoucher As String = .Item(cVoucherNo)
                    Dim code As String = strVoucher.Substring(0, 3)
                    Dim id As Long = Val(strVoucher.Substring(3))
                    Dim name As String = ""
                    Select Case code
                        Case cCHP
                            name = GetNameForChequePaymentId(id)
                        Case cCHR
                            name = GetNameForChequeReceiptId(id)
                        Case cCAP
                            name = GetNameForCashPaymentId(id)
                        Case cCAR
                            name = GetNameForCashReceiptId(id)
                    End Select

                    If name.Trim <> "" Then .Item(cName) = name
                End With
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Function GetNameForChequePaymentId(ByVal id As Long) As String
        Dim result As String = ""
        Try
            If dsChequePayment Is Nothing Then Exit Try

            Dim dtRow As DataRow
            For Each dtRow In dsChequePayment.Tables(0).Rows
                With dtRow
                    If id = .Item(cId) Then
                        result = .Item(cName)
                        Exit Try
                    End If
                End With
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Function GetNameForChequeReceiptId(ByVal id As Long) As String
        Dim result As String = ""
        Try
            If dsChequeReceipt Is Nothing Then Exit Try

            Dim dtRow As DataRow
            For Each dtRow In dsChequeReceipt.Tables(0).Rows
                With dtRow
                    If id = .Item(cId) Then
                        result = .Item(cName)
                        Exit Try
                    End If
                End With
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Function GetNameForCashPaymentId(ByVal id As Long) As String
        Dim result As String = ""
        Try
            If dsCashPayment Is Nothing Then Exit Try

            Dim dtRow As DataRow
            For Each dtRow In dsCashPayment.Tables(0).Rows
                With dtRow
                    If id = .Item(cId) Then
                        result = .Item(cName)
                        Exit Try
                    End If
                End With
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Function GetNameForCashReceiptId(ByVal id As Long) As String
        Dim result As String = ""
        Try
            If dsCashReceipt Is Nothing Then Exit Try

            Dim dtRow As DataRow
            For Each dtRow In dsCashReceipt.Tables(0).Rows
                With dtRow
                    If id = .Item(cId) Then
                        result = .Item(cName)
                        Exit Try
                    End If
                End With
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

#End Region

End Class
