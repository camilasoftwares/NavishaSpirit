Public Class DlgJournalBookRpt

    Private Sub Help(ByVal sender As Object, ByVal hlpEvent As System.Windows.Forms.HelpEventArgs) Handles MyBase.HelpRequested
        Try
            Dim obj As Object = Me.Owner
            obj.ShowHelp()
        Catch ex As Exception
        End Try

        hlpEvent.Handled = True
    End Sub

    Private Sub Dlg_JournalBook_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OptAll.Checked = True
        DtPkrDateFrom.Visible = False
        DtPkrDateTo.Visible = False
    End Sub

    Private Sub OptAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptAll.CheckedChanged
        DtPkrDateFrom.Visible = False
        DtPkrDateTo.Visible = False
    End Sub

    Private Sub OptSpecific_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptSpecific.CheckedChanged
        DtPkrDateFrom.Visible = True
        DtPkrDateTo.Visible = False
    End Sub

    Private Sub OptBetween_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptBetween.CheckedChanged
        DtPkrDateFrom.Visible = True
        DtPkrDateTo.Visible = True
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub BtnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDisplay.Click
        Try
            Dim dateFrom As Date = Nothing
            Dim dateTo As Date = Nothing
            If OptSpecific.Checked = True Then
                dateFrom = DtPkrDateFrom.Value.Date
                dateTo = DtPkrDateFrom.Value.Date.AddDays(1).AddMilliseconds(-1)
            ElseIf OptBetween.Checked = True Then
                dateFrom = DtPkrDateFrom.Value.Date
                dateTo = DtPkrDateTo.Value.Date.AddDays(1).AddMilliseconds(-1)
            End If

            Dim ds As DataSet = GetJournals(Me.Name, dateFrom, dateTo)
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
            Dim rpt As New RptJournalBook
            rpt.SetDataSource(ds.Tables(0))
            Dim dlg As New DiagReport
            dlg.RptViewer.ReportSource = rpt
            dlg.ShowDialog(Me)

        Catch ex As Exception
            AddToLog(ex)
        End Try

        SetDefaultCursor()
    End Sub

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles OptSpecific.KeyDown, OptBetween.KeyDown, OptAll.KeyDown, DtPkrDateTo.KeyDown, DtPkrDateFrom.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

End Class