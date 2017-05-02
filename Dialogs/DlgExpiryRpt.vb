Imports System.Windows.Forms

Public Class DlgExpiryRpt

#Region "Controls Function"

    Private Sub DlgExpiryRpt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

    Private Sub OptDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptDate.CheckedChanged
        SetEnabilityForOptions()
    End Sub

    Private Sub OptAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptAll.CheckedChanged
        SetEnabilityForOptions()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub BtnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShow.Click
        ShowReport()
    End Sub

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles OptDate.KeyDown, OptAll.KeyDown, DtPkrDateFrom.KeyDown, NmrMonths.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

#End Region

#Region "Private Functions"

    Private Sub SetControls()
        OptAll.Checked = True
        DtPkrDateFrom.Value = GetMonthDate(Now.Date)
    End Sub

    Private Sub SetEnabilityForOptions()
        If OptAll.Checked = True Then
            DtPkrDateFrom.Enabled = False
            NmrMonths.Enabled = False
        ElseIf OptDate.Checked = True Then
            DtPkrDateFrom.Enabled = True
            NmrMonths.Enabled = True
        End If
    End Sub

    Private Sub ShowReport()
        Try
            Dim dateFrom As Date = DateDefault
            Dim dateTo As Date = dateFrom.AddYears(999)

            Dim dateStr As String = "For ALL Stock"
            If OptDate.Checked = True Then
                dateFrom = DtPkrDateFrom.Value.Date
                dateTo = DtPkrDateFrom.Value.Date.AddMonths(NmrMonths.Value).AddDays(1).AddMilliseconds(-1)
                dateStr = "Between : " + Format(dateFrom, "MMM-yyyy") + " - " + Format(dateTo, "MMM-yyyy")
            End If

            Dim ds As DataSet = GetCurrentStockExpiringBetweenDates(Me.Name, dateFrom, dateTo)

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
            Dim rpt As New RptStockExpiry
            rpt.SetDataSource(ds.Tables(0))
            rpt.SetParameterValue("Title", dateStr)
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
