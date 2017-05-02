Imports System.Windows.Forms

Public Class DlgLedgerBookRpt

#Region "Local variables and Constants"

    Dim flagGroupChanged As Boolean = False
    Private Const lcAll As String = "All"

    Enum Index
        GrpGroup
        CmbGroups
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

    Private Sub DlgLedgerBookRpt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

    Private Sub BtnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShow.Click
        ShowReport()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub OptBetweenDates_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptBetweenDates.CheckedChanged
        SetEnabilityForOptions()
    End Sub

    Private Sub OptOnDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptOnDate.CheckedChanged
        SetEnabilityForOptions()
    End Sub

    Private Sub OptAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptAll.CheckedChanged
        SetEnabilityForOptions()
    End Sub

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles OptOnDate.KeyDown, OptBetweenDates.KeyDown, OptAll.KeyDown, DtPkrDateTo.KeyDown, DtPkrDateFrom.KeyDown, CmbHeads.KeyDown, CmbGroups.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub CmbGroups_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbGroups.LostFocus
        Try
            If flagGroupChanged = False Then Exit Try

            flagGroupChanged = False
            FillComboBoxValuesForHeads()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub CmbGroups_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmbGroups.SelectedIndexChanged
        flagGroupChanged = True
    End Sub

#End Region

#Region "Private Functions"

    Private Sub SetControls()
        SetTabIndex()
        FillComboBoxValuesForGroups()
        DtPkrDateFrom.Value = Now.Date
        DtPkrDateTo.Value = Now.Date

        CmbGroups.Focus()
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
        GrpGroup.TabIndex = Index.GrpGroup
        CmbGroups.TabIndex = Index.CmbGroups
    End Sub

    Private Sub FillComboBoxValuesForGroups()
        Try
            CmbGroups.Items.Clear()

            Dim groups() As ClsAccountGroup = GetAllAccountGroups(Me.Name)
            If groups Is Nothing Then Exit Try

            CmbGroups.DisplayMember = cName
            CmbGroups.ValueMember = cId
            Dim group As ClsAccountGroup
            For Each group In groups
                CmbGroups.Items.Add(group)
            Next

            Dim groupObj As New ClsAccountGroup
            With groupObj
                .Id = cInvalidId
                .Name = lcAll
            End With
            CmbGroups.Items.Add(groupObj)

            If CmbGroups.Items.Count > 0 Then CmbGroups.Text = lcAll

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub FillComboBoxValuesForHeads()
        Try
            CmbHeads.Items.Clear()

            Dim heads() As ClsAccountHead = Nothing
            If CmbGroups.Text.Trim = lcAll Then
                heads = GetAllAccountHead(Me.Name)
            Else
                heads = GetAllAccountHeadForGroupId(Me.Name, GetSelectedItemId(CmbGroups))
            End If

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

            Dim ds As DataSet = GetLedgerForHeadId(Me.Name, headId, dateFrom, dateTo)
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

            'Opening Report
            SetWaitCursor()
            Dim rpt As New RptLedger
            rpt.SetDataSource(ds.Tables(0))
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

#End Region

End Class
