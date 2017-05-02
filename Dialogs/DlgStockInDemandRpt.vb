Public Class DlgStockInDemandRpt

    Dim lFlagStockInDemand As Boolean = False

    Private Sub Help(ByVal sender As Object, ByVal hlpEvent As System.Windows.Forms.HelpEventArgs) Handles MyBase.HelpRequested
        Try
            Dim obj As Object = Me.Owner
            obj.ShowHelp()
        Catch ex As Exception
        End Try

        hlpEvent.Handled = True
    End Sub

    Private Sub OptAllItems_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptAllItems.CheckedChanged
        If OptAllItems.Checked = True Then
            DisableAllCombo()
        End If
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub DlgStockInDemandRpt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillComboBoxValues()
        OptAllItems.Checked = True
        DisableAllCombo()
    End Sub

    Private Sub FillComboBoxValues()
        'to fill Items in combo
        CmbItems.DataSource = GetAllItemMaster(Me.Name, True)
        CmbItems.DisplayMember = cName
        CmbItems.ValueMember = cId
        'end to fill items in combo

        'to Fill Category in combo
        CmbCategory.DataSource = GetAllCategoryMaster(Me.ToString())
        CmbCategory.DisplayMember = cName
        CmbCategory.ValueMember = cId
        'end to fill category in combo

        'to fill Manufacturers in combo
        CmbManufacturer.DataSource = GetAllManufacturerMaster(Me.ToString())
        CmbManufacturer.DisplayMember = cName
        CmbManufacturer.ValueMember = cId
        'end to fill Manufacturers in combo

        'to Fill Schedule in combo
        CmbSchedule.DataSource = GetAllScheduleMaster(Me.ToString())
        CmbSchedule.DisplayMember = cName
        CmbSchedule.ValueMember = cId
        'end to fill schedule in combo

        'to fill Rack in combo
        CmbRack.DataSource = GetAllStorageMaster(Me.ToString())
        CmbRack.DisplayMember = cName
        CmbRack.ValueMember = cId
        'end to fill Rack in combo
    End Sub

    Private Sub DisableAllCombo()
        CmbCategory.Enabled = False
        CmbItems.Enabled = False
        CmbManufacturer.Enabled = False
        CmbItems.Enabled = False
        CmbManufacturer.Enabled = False
        CmbRack.Enabled = False
        CmbSchedule.Enabled = False

        CmbCategory.SelectedIndex = -1
        CmbItems.SelectedIndex = -1
        CmbManufacturer.SelectedIndex = -1
        CmbItems.SelectedIndex = -1
        CmbManufacturer.SelectedIndex = -1
        CmbRack.SelectedIndex = -1
        CmbSchedule.SelectedIndex = -1
    End Sub

    Private Sub OptItemWise_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptItemWise.CheckedChanged
        If OptItemWise.Checked = True Then
            DisableAllCombo()
            CmbItems.Enabled = True
        End If
    End Sub

    Private Sub OptManufacturerWise_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptManufacturerWise.CheckedChanged
        If OptManufacturerWise.Checked = True Then
            DisableAllCombo()
            CmbManufacturer.Enabled = True
        End If
    End Sub

    Private Sub OptCategoryWise_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptCategoryWise.CheckedChanged
        If OptCategoryWise.Checked = True Then
            DisableAllCombo()
            CmbCategory.Enabled = True
        End If
    End Sub

    Private Sub OptScheduleWise_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptScheduleWise.CheckedChanged
        If OptScheduleWise.Checked = True Then
            DisableAllCombo()
            CmbSchedule.Enabled = True
        End If
    End Sub

    Private Sub OptRackWise_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptRackWise.CheckedChanged
        If OptRackWise.Checked = True Then
            DisableAllCombo()
            CmbRack.Enabled = True
        End If
    End Sub

    Private Function ValidateValues() As Boolean
        Dim result As Boolean = False
        Try
            RemoveErrorIcon()

            If OptCategoryWise.Checked = True And CmbCategory.Text = "" Then
                ErrorInData("Plese Select An Category", CmbCategory)
                Exit Try
            End If

            If OptItemWise.Checked = True And CmbItems.Text = "" Then
                ErrorInData("Plese Select An Item", CmbItems)
                Exit Try
            End If

            If OptManufacturerWise.Checked = True And CmbManufacturer.Text = "" Then
                ErrorInData("Plese Select A Manufacturer", CmbManufacturer)
                Exit Try
            End If

            If OptRackWise.Checked = True And CmbRack.Text = "" Then
                ErrorInData("Plese Select A Rack", CmbRack)
                Exit Try
            End If

            If OptScheduleWise.Checked = True And CmbSchedule.Text = "" Then
                ErrorInData("Plese Select A Schedule", CmbSchedule)
                Exit Try
            End If

            result = True

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Sub BtnShowReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShowReport.Click
        Try
            If ValidateValues() = False Then Exit Try

            Dim categoryId As Integer = cInvalidId
            Dim itemId As Integer = cInvalidId
            Dim manufacturerId As Integer = cInvalidId
            Dim storageId As Integer = cInvalidId
            Dim scheduleId As Integer = cInvalidId

            Dim strParValue As String = ""
            If OptAllItems.Checked = True Then
                strParValue = "All Items"
            ElseIf OptCategoryWise.Checked = True Then
                strParValue = "Category Wise"
                categoryId = GetSelectedItemId(CmbCategory)
            ElseIf OptItemWise.Checked = True Then
                strParValue = "Item Wise"
                itemId = GetSelectedItemId(CmbItems)
            ElseIf OptManufacturerWise.Checked = True Then
                strParValue = "Manufacturer Wise"
                manufacturerId = GetSelectedItemId(CmbManufacturer)
            ElseIf OptRackWise.Checked = True Then
                strParValue = "Rack Wise"
                storageId = GetSelectedItemId(CmbRack)
            ElseIf OptScheduleWise.Checked = True Then
                strParValue = "Schedule Wise"
                scheduleId = GetSelectedItemId(CmbSchedule)
            End If

            If manufacturerId = cInvalidId Then manufacturerId = cInvalidId - 1
            If categoryId = cInvalidId Then categoryId = cInvalidId - 1
            If scheduleId = cInvalidId Then scheduleId = cInvalidId - 1
            If storageId = cInvalidId Then storageId = cInvalidId - 1
            If itemId = cInvalidId Then itemId = cInvalidId - 1

            Dim ds As DataSet = GetStock(Me.Name, True, categoryId, itemId, manufacturerId, storageId, scheduleId)

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
            Dim rpt As New RptStockInDemand
            rpt.SetDataSource(ds.Tables(0))
            rpt.SetParameterValue(0, strParValue)
            Dim dlg As New DiagReport
            dlg.RptViewer.ReportSource = rpt
            dlg.ShowDialog(Me)

        Catch ex As Exception
            AddToLog(ex)
        End Try

        SetDefaultCursor()
    End Sub

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles OptScheduleWise.KeyDown, OptRackWise.KeyDown, OptManufacturerWise.KeyDown, OptItemWise.KeyDown, OptCategoryWise.KeyDown, OptAllItems.KeyDown, CmbSchedule.KeyDown, CmbRack.KeyDown, CmbManufacturer.KeyDown, CmbItems.KeyDown, CmbCategory.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

#Region "Public Function"

    Public Sub SetStockInDemand()
        lFlagStockInDemand = True
    End Sub

#End Region

End Class
