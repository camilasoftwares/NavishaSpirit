Public Class DlgGrossPurchaseRpt

    Private Sub Help(ByVal sender As Object, ByVal hlpEvent As System.Windows.Forms.HelpEventArgs) Handles MyBase.HelpRequested
        Try
            Dim obj As Object = Me.Owner
            obj.ShowHelp()
        Catch ex As Exception
        End Try

        hlpEvent.Handled = True
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub DlgGrossPurchase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CmbVendor.DataSource = GetAllVendorMaster(Me.Name)
        CmbVendor.DisplayMember = cName
        CmbVendor.ValueMember = cId
        CmbVendor.SelectedIndex = -1
        OptAllRecords.Checked = True
    End Sub

    Private Sub OptAllRecords_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptAllRecords.CheckedChanged
        If OptAllRecords.Checked = True Then
            DtPkrDateFrom.Visible = False
            DtPkrDateTo.Visible = False
        End If
    End Sub

    Private Sub OptSpecific_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptSpecific.CheckedChanged
        DtPkrDateFrom.Visible = False
        DtPkrDateTo.Visible = False
        If OptSpecific.Checked = True Then DtPkrDateFrom.Visible = True
    End Sub

    Private Sub OptBetween_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptBetween.CheckedChanged
        If OptBetween.Checked = True Then
            DtPkrDateFrom.Visible = True
            DtPkrDateTo.Visible = True
        Else
            DtPkrDateFrom.Visible = False
            DtPkrDateTo.Visible = False
        End If
    End Sub

    Private Sub BtnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShow.Click
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

            Dim vendorId As Integer = cInvalidId
            If CmbVendor.Text.Trim <> "" Then vendorId = GetSelectedItemId(CmbVendor)
            Dim ds As DataSet = GetGrossPurchase(Me.Name, dateFrom, dateTo, vendorId)

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
            Dim rpt As New RptGrossPurchase
            rpt.SetDataSource(ds.Tables(0))
            Dim dlg As New DiagReport
            dlg.RptViewer.ReportSource = rpt
            dlg.ShowDialog(Me)

        Catch ex As Exception
            AddToLog(ex)
        End Try

        SetDefaultCursor()
    End Sub

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles OptSpecific.KeyDown, OptBetween.KeyDown, OptAllRecords.KeyDown, DtPkrDateTo.KeyDown, DtPkrDateFrom.KeyDown, CmbVendor.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    
End Class