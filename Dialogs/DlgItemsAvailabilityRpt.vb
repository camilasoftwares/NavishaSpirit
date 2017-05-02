Public Class DlgItemsAvailabilityRpt

    Private Sub Help(ByVal sender As Object, ByVal hlpEvent As System.Windows.Forms.HelpEventArgs) Handles MyBase.HelpRequested
        Try
            Dim obj As Object = Me.Owner
            obj.ShowHelp()
        Catch ex As Exception
        End Try

        hlpEvent.Handled = True
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub DlgItemAvailability_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'OptAllGeneric.Checked = True
        OptManufacturer.Checked = True
        CmbItems.DataSource = GetAllItemMaster(Me.Name, True)
        CmbItems.DisplayMember = cName
        CmbItems.ValueMember = cId
    End Sub

    Private Sub BtnShowReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShowReport.Click
        Try
            RemoveErrorIcon()

            If CmbItems.Text.Trim = "" Then
                ErrorInData("Please Select An Item", CmbItems)
                Exit Try
            End If

            Dim manufacturerId As Integer = cInvalidId
            Dim categoryId As Integer = cInvalidId
            Dim scheduleId As Integer = cInvalidId
            Dim genericId1 As Integer = cInvalidId
            Dim genericId2 As Integer = cInvalidId
            Dim genericId3 As Integer = cInvalidId
            Dim flagExceptZeroQuantity As Boolean = False

            If OptAllGeneric.Checked = True Then
                genericId1 = CmbItems.SelectedItem.GenericId1
                genericId2 = CmbItems.SelectedItem.GenericId2
                genericId3 = CmbItems.SelectedItem.GenericId3
                If genericId1 = cInvalidId Then genericId1 = cInvalidId - 1
                If genericId2 = cInvalidId Then genericId2 = cInvalidId - 1
                If genericId3 = cInvalidId Then genericId3 = cInvalidId - 1
            ElseIf OptGeneric1.Checked = True Then
                genericId1 = CmbItems.SelectedItem.GenericId1
                If genericId1 = cInvalidId Then genericId1 = cInvalidId - 1
            ElseIf OptGeneric2.Checked = True Then
                genericId2 = CmbItems.SelectedItem.GenericId2
                If genericId2 = cInvalidId Then genericId2 = cInvalidId - 1
            ElseIf OptGeneric3.Checked = True Then
                genericId3 = CmbItems.SelectedItem.GenericId3
                If genericId3 = cInvalidId Then genericId3 = cInvalidId - 1
            ElseIf OptManufacturer.Checked = True Then
                manufacturerId = CmbItems.SelectedItem.ManufacturerId
                If manufacturerId = cInvalidId Then manufacturerId = cInvalidId - 1
            ElseIf OptCategory.Checked = True Then
                categoryId = CmbItems.SelectedItem.CategoryId
                If categoryId = cInvalidId Then categoryId = cInvalidId - 1
            ElseIf OptSchedule.Checked = True Then
                scheduleId = CmbItems.SelectedItem.ScheduleId
                If scheduleId = cInvalidId Then scheduleId = cInvalidId - 1
            End If

            If ChkOnlyAvailableStock.Checked = True Then
                flagExceptZeroQuantity = True
            End If

            Dim ds As DataSet = GetItemsAvailability(Me.Name, flagExceptZeroQuantity, genericId1, genericId2, genericId3, manufacturerId, categoryId, scheduleId)
            If ds Is Nothing Then
                MsgBox("Error in generating report.", MsgBoxStyle.Critical, "Error")
                Exit Try
            End If

            If ds.Tables(0).Rows.Count = 0 Then
                MsgBox("No record is present for this selection.", MsgBoxStyle.Information, "No Record")
                Exit Try
            End If

            Dim itemName As String = CmbItems.Text.Trim

            'Opening Report
            SetWaitCursor()
            Dim rpt As New RptItemsAvailability
            rpt.SetDataSource(ds.Tables(0))
            rpt.SetParameterValue(0, itemName)
            Dim dlg As New DiagReport
            dlg.RptViewer.ReportSource = rpt
            dlg.ShowDialog(Me)

        Catch ex As Exception
            AddToLog(ex)
        End Try

        SetDefaultCursor()
    End Sub

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles OptSchedule.KeyDown, OptManufacturer.KeyDown, OptGeneric3.KeyDown, OptGeneric2.KeyDown, OptGeneric1.KeyDown, OptCategory.KeyDown, OptAllGeneric.KeyDown, CmbItems.KeyDown, ChkOnlyAvailableStock.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

End Class