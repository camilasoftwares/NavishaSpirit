Public Class DlgItemwiseSaleRpt

    Private Sub Help(ByVal sender As Object, ByVal hlpEvent As System.Windows.Forms.HelpEventArgs) Handles MyBase.HelpRequested
        Try
            Dim obj As Object = Me.Owner
            obj.ShowHelp()
        Catch ex As Exception
        End Try

        hlpEvent.Handled = True
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

    Private Sub DlgItemwiseSaleRpt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CmbItem.DataSource = GetAllItemMaster(Me.Name, True)
        CmbItem.DisplayMember = cName
        CmbItem.ValueMember = cId
        CmbItem.SelectedIndex = -1

        cmb_Categary.DataSource = GetAllCategoryMaster(Me.Name)
        cmb_Categary.DisplayMember = cName
        cmb_Categary.ValueMember = cId
        cmb_Categary.SelectedIndex = -1



        OptAll.Checked = True
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
            Dim ds As DataSet
            Dim itemId As Integer = cInvalidId
            If CmbItem.Text.Trim <> "" Then
                itemId = GetSelectedItemId(CmbItem)
                ds = GetItemWiseSale(Me.Name, dateFrom, dateTo, itemId)

            End If
            Dim CatId As Integer = cInvalidId
            If cmb_Categary.Text.Trim <> "" Then
                CatId = GetSelectedItemId(cmb_Categary)
                ds = GetItemCatWiseSale(Me.Name, dateFrom, dateTo, CatId)

            End If

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
            Dim rpt As New RptItemwiseSale
            rpt.SetDataSource(ds.Tables(0))
            Dim dlg As New DiagReport
            dlg.RptViewer.ReportSource = rpt
            dlg.ShowDialog(Me)

        Catch ex As Exception
            AddToLog(ex)
        End Try

        SetDefaultCursor()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles OptSpecific.KeyDown, OptBetween.KeyDown, OptAll.KeyDown, DtPkrDateTo.KeyDown, DtPkrDateFrom.KeyDown, CmbItem.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    
End Class