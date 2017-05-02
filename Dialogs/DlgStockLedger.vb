
Public Class DlgStockLedger

    Private Sub Help(ByVal sender As Object, ByVal hlpEvent As System.Windows.Forms.HelpEventArgs) Handles MyBase.HelpRequested
        Try
            Dim obj As Object = Me.Owner
            obj.ShowHelp()
        Catch ex As Exception
        End Try

        hlpEvent.Handled = True
    End Sub

    Private Sub DlgStockLedger_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadComboBoxValuesForItems()
    End Sub

    Private Sub LoadComboBoxValuesForItems()
        Try
            CmbItemName.DataSource = Nothing
            CmbItemName.Items.Clear()

            Dim items() As ClsItemMaster = GetAllItemMaster(Me.Name, True)
            If items Is Nothing Then Exit Try

            CmbItemName.DataSource = items
            CmbItemName.DisplayMember = cName
            CmbItemName.ValueMember = cId

            If CmbItemName.Items.Count > 0 Then CmbItemName.SelectedIndex = 0

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub BtnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDisplay.Click
        Try
            Dim ds As New DataSet
            ds = GetStockLedgerForItemId(Me.Name, GetSelectedItemId(CmbItemName))

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
            Dim rpt As New RptStockLedger
            rpt.SetDataSource(ds.Tables(0))
            Dim dlg As New DiagReport
            dlg.RptViewer.ReportSource = rpt
            dlg.ShowDialog(Me)
            
        Catch ex As Exception
            AddToLog(ex)
        End Try

        SetDefaultCursor()
    End Sub

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CmbItemName.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

End Class