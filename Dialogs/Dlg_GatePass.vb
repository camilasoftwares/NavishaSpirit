Public Class Dlg_GatePass
    Private Sub Help(ByVal sender As Object, ByVal hlpEvent As System.Windows.Forms.HelpEventArgs) Handles MyBase.HelpRequested
        Try
            Dim obj As Object = Me.Owner
            obj.ShowHelp()
        Catch ex As Exception
        End Try

        hlpEvent.Handled = True
    End Sub
    Private Sub BtnShow_Click(sender As Object, e As EventArgs) Handles BtnShow.Click
        Try
            Dim str As String

            Dim dateFrom As Date = Nothing
            Dim dateTo As Date = Nothing
            If OptSpecific.Checked = True Then
                dateFrom = DtPkrDateFrom.Value.Date
                dateTo = DtPkrDateFrom.Value.Date.AddDays(1).AddMilliseconds(-1)
                Str = "For " + DtPkrDateFrom.Value.ToString("dd/MM/yyyy")
            ElseIf OptBetween.Checked = True Then
                dateFrom = DtPkrDateFrom.Value.Date
                dateTo = DtPkrDateTo.Value.Date.AddDays(1).AddMilliseconds(-1)
                str = "Between " + DtPkrDateFrom.Value.ToString("dd/MM/yyyy") + " - " + DtPkrDateTo.Value.ToString("dd/MM/yyyy")
            End If

            Dim itemId As Integer = cInvalidId
            ''If CmbItem.Text.Trim <> "" Then itemId = GetSelectedItemId(CmbItem)
            Dim ds As DataSet = GetBunchRpt(Me.Name, dateFrom, dateTo)
            If ds Is Nothing Then
                MsgBox("Error in generating report.", MsgBoxStyle.Critical, "Error")
                Exit Try
            End If

            If ds.Tables(0).Rows.Count = 0 Then
                MsgBox("No record is present for this selection.", MsgBoxStyle.Information, "No Record")
                Exit Try
            End If

            'Opening Report
            'SetWaitCursor()
            Dim rpt As New GetPassBunch
            rpt.SetDataSource(ds.Tables(0))
            Dim dlg As New DiagReport
            dlg.RptViewer.ReportSource = rpt
            rpt.SetParameterValue("Title", str)
            dlg.ShowDialog(Me)

        Catch ex As Exception
            AddToLog(ex)
        End Try

        SetDefaultCursor()
    End Sub

    Private Sub Dlg_GatePass_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OptAll.Checked = True
    End Sub

    Private Sub OptBetween_CheckedChanged(sender As Object, e As EventArgs) Handles OptBetween.CheckedChanged
        DtPkrDateFrom.Visible = True
        DtPkrDateTo.Visible = True
    End Sub

    Private Sub OptSpecific_CheckedChanged(sender As Object, e As EventArgs) Handles OptSpecific.CheckedChanged
        DtPkrDateFrom.Visible = True
        DtPkrDateTo.Visible = False
    End Sub

    Private Sub OptAll_CheckedChanged(sender As Object, e As EventArgs) Handles OptAll.CheckedChanged
        DtPkrDateFrom.Visible = False
        DtPkrDateTo.Visible = False
    End Sub
End Class