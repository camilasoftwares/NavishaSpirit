Imports System.Windows.Forms

Public Class DlgHQWiseSaleRpt

#Region "Control Functions"

    Private Sub DlgHQWiseSale_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

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

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles OptSpecific.KeyDown, OptBetween.KeyDown, OptAll.KeyDown, DtPkrDateTo.KeyDown, DtPkrDateFrom.KeyDown, CmbHQName.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
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

            Dim taxId As Integer = GetSelectedItemId(CmbTax)

            Dim hqId As Integer = cInvalidId
            If CmbHQName.Text.Trim <> "" Then hqId = GetSelectedItemId(CmbHQName)
            Dim ds As DataSet = GetHQWiseSale(Me.Name, dateFrom, dateTo, hqId, taxId)
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
            Dim rpt As New RptHQWiseSale
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
#End Region

#Region "Private Functions"

    Private Sub SetControls()
        OptAll.Checked = True

        FillComboBoxHeadQuarter()
        LoadComboBoxValuesForTax()
    End Sub

    Private Sub FillComboBoxHeadQuarter()
        Try
            CmbHQName.Items.Clear()
            Dim hqs() As ClsHQMaster = GetAllHQMaster(Me.Name)

            If hqs Is Nothing Then Exit Try
            With CmbHQName
                .DataSource = hqs
                .DisplayMember = cName
                .ValueMember = cId
                .SelectedIndex = -1
            End With

        Catch ex As Exception
            AddtoLog(ex)
        End Try
    End Sub

    Private Sub LoadComboBoxValuesForTax()
        With CmbTax
            .DataSource = GetAllTaxMasters(Me.Name)
            .DisplayMember = cName
            .ValueMember = cId
            .SelectedIndex = -1
        End With
    End Sub

#End Region

End Class
