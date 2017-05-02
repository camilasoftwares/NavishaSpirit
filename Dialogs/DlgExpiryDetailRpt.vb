Imports System.Windows.Forms

Public Class DlgExpiryDetailRpt

#Region "Controls Function"

    Private Sub DlgExpiryDetailRpt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

    Private Sub OptOnDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptOnDate.CheckedChanged
        SetEnabilityForOptions()
    End Sub

    Private Sub OptAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptAll.CheckedChanged
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

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles OptOnDate.KeyDown, OptBetweenDates.KeyDown, OptAll.KeyDown, DtPkrDateTo.KeyDown, DtPkrDateFrom.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

#End Region

#Region "Private Functions"

    Private Sub SetControls()
        OptAll.Checked = True
        DtPkrDateFrom.Value = Now.Date
        DtPkrDateTo.Value = Now.Date
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
            Dim dateFrom As Date = DateDefault
            Dim dateTo As Date = Now

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

            Dim ds As DataSet = Nothing
                ds = GetExpiryDetails(Me.Name, dateFrom, dateTo)
            
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
            Dim rpt As New RptExpiryDetail
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
