Imports System.Windows.Forms

Public Class FrmTrialBalance

#Region "Local variables and Constants"

    Dim flagDifferenceRowAdded As Boolean = False

    Private Const lcAll As String = "All"
    Private Const lcSNo As String = "S.No."
    Private Const lcId As String = "HId"
    Private Const lcName As String = "HName"
    Private Const lcAddress As String = "HAddress"
    Private Const lcContactPerson As String = "HContactPerson"
    Private Const lcPhone As String = "HPhone"
    Private Const lcFax As String = "HFax"
    Private Const lcEmail As String = "HEmail"
    Private Const lcCity As String = "HCity"
    Private Const lcState As String = "HState"
    Private Const lcPin As String = "HPin"
    Private Const lcUpTtNo As String = "HUpTtNo"
    Private Const lcCstNo As String = "HCstNo"
    Private Const lcDlNo As String = "HDlNo"
    Private Const lcTinNo As String = "HTinNo"

    Enum Index
        DtPkrDate
        OptDetailed
        OptCondensed
        CmbGroups
        BtnShow
        BtnPrint
        BtnClose
        GrpTrialBalance
        GrdTrialBalance
    End Enum

#End Region

#Region "Control Functions"

    Private Sub Help(ByVal sender As Object, ByVal hlpEvent As System.Windows.Forms.HelpEventArgs) Handles MyBase.HelpRequested
        Try
            Dim obj As Object = Me.Owner
            obj.ShowHelp()
        Catch ex As Exception
        End Try

        hlpEvent.Handled = True
    End Sub

    Private Sub FrmTrialBalance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

    Private Sub BtnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShow.Click
        Try
            flagDifferenceRowAdded = False
            Dim dateTo As Date = DtPkrDate.Value.Date.AddDays(1).AddMilliseconds(-1)
            If FillTempAccountForDate(Me.Name, dateTo) <> EnResult.Change Then Exit Sub

            FillGrid()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Try
            Dim ds As DataSet = GetCompany(Me.Name)
            If ds Is Nothing Then
                MsgBox("Error in generating report.", MsgBoxStyle.Critical, "Error")
                Exit Try
            End If

            Dim dt As DataTable = GetTrialBalanceDataTable(ds)
            If dt.Rows.Count = 0 Then
                MsgBox("No record is present for this selection.", MsgBoxStyle.Information, "No Record")
                Exit Try
            End If

            Dim title As String = GetTitleForReport()

            'Opening Report
            SetWaitCursor()
            Dim rpt As New RptTrialBalance
            rpt.SetDataSource(dt)
            rpt.SetParameterValue("Title", title)
            Dim dlg As New DiagReport
            dlg.RptViewer.ReportSource = rpt
            dlg.ShowDialog(Me)

        Catch ex As Exception
            AddToLog(ex)
        End Try

        SetDefaultCursor()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub GrdTrialBalance_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdTrialBalance.KeyDown
        If e.KeyCode = Keys.Tab Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles OptDetailed.KeyDown, OptCondensed.KeyDown, DtPkrDate.KeyDown, CmbGroups.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

#End Region

#Region "Private Functions"

    Private Sub SetControls()
        SetTabIndex()
        SetGrid()
        FillComboBoxValuesForGroups()
        DtPkrDate.Value = Now.Date
        DtPkrDate.Focus()
    End Sub

    Private Sub SetTabIndex()
        GrpTrialBalance.TabIndex = Index.GrpTrialBalance
        GrdTrialBalance.TabIndex = Index.GrdTrialBalance
        DtPkrDate.TabIndex = Index.DtPkrDate
        OptDetailed.TabIndex = Index.OptDetailed
        OptCondensed.TabIndex = Index.OptCondensed
        CmbGroups.TabIndex = Index.CmbGroups
        BtnPrint.TabIndex = Index.BtnPrint
        BtnClose.TabIndex = Index.BtnClose
        BtnShow.TabIndex = Index.BtnShow
    End Sub

    Private Sub SetGrid()
        With GrdTrialBalance
            Dim colCount As Integer = 3
            .RowHeadersVisible = False
            Dim defaultCellWidth As Integer = 100
            Dim x As Integer
            For x = 0 To colCount
                Select Case x
                    Case 0
                        Dim index As Integer = .Columns.Add(lcSNo, lcSNo)
                        .Columns(index).Width = defaultCellWidth

                    Case 1
                        Dim index As Integer = .Columns.Add(cName, cName)
                        .Columns(index).Width = 290

                    Case 2
                        Dim index As Integer = .Columns.Add(cDr, "Debit")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                    Case 3
                        Dim index As Integer = .Columns.Add(cCr, "Credit")
                        .Columns(index).Width = defaultCellWidth
                        .Columns(index).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                End Select
            Next
        End With
    End Sub

    Private Sub FillGrid()
        Try
            GrdTrialBalance.Rows.Clear()

            Dim flagDetailed As Boolean = OptDetailed.Checked
            Dim tempAccounts() As ClsTempAccount = Nothing
            Dim grpId As Integer = cInvalidId
            If CmbGroups.Text = lcAll Then
                If flagDetailed = True Then
                    tempAccounts = GetAllTempAccountForTrialBalanceInDetail(Me.Name)
                Else
                    tempAccounts = GetAllTempAccountForTrialBalanceInCondensed(Me.Name)
                End If
            Else
                grpId = GetSelectedItemId(CmbGroups)
                If grpId <= 0 Then Exit Try

                If flagDetailed = True Then
                    tempAccounts = GetAllTempAccountForTrialBalanceInDetail(Me.Name, grpId)
                Else
                    tempAccounts = GetAllTempAccountForTrialBalanceInCondensed(Me.Name, grpId)
                End If
            End If

            If tempAccounts Is Nothing Then Exit Try

            Dim tempAccount As ClsTempAccount
            For Each tempAccount In tempAccounts
                InsertIntoGrid(tempAccount)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        CalculateValues()
    End Sub

    Private Sub InsertIntoGrid(ByRef tempAccountObj As ClsTempAccount)
        Try
            If tempAccountObj Is Nothing Then Exit Try
            
            Dim rowIndex As Integer = GrdTrialBalance.Rows.Add()
            With GrdTrialBalance.Rows(rowIndex)
                .Cells(lcSNo).Value = rowIndex + 1
                .Cells(cName).Value = tempAccountObj.Name
                .Cells(cDr).Value = 0
                .Cells(cCr).Value = 0

                Dim total As Double = Format(tempAccountObj.Total, "0.00")
                If total > 0 Then
                    .Cells(cDr).Value = total
                ElseIf total < 0 Then
                    .Cells(cCr).Value = -(total)
                End If
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub FillComboBoxValuesForGroups()
        Try
            CmbGroups.Items.Clear()

            Dim groups() As ClsAccountGroup = GetAllAccountGroups(Me.Name)
            If groups Is Nothing Then Exit Try

            Dim group As ClsAccountGroup
            CmbGroups.DisplayMember = cName
            CmbGroups.ValueMember = cId
            For Each group In groups
                CmbGroups.Items.Add(group)
            Next

            CmbGroups.Items.Add(lcAll)
            CmbGroups.Text = lcAll

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub CalculateValues()
        Try
            Dim debit As Double = 0
            Dim credit As Double = 0

            Dim row As DataGridViewRow
            For Each row In GrdTrialBalance.Rows
                With row
                    debit += Val(.Cells(cDr).Value)
                    credit += Val(.Cells(cCr).Value)
                End With
            Next

            If debit = 0 And credit = 0 Then flagDifferenceRowAdded = True

            If flagDifferenceRowAdded = False Then
                flagDifferenceRowAdded = True
                Dim tempAccountObj As New ClsTempAccount
                With tempAccountObj
                    .Id = 0
                    .Name = "Difference Adjustment"
                    Dim diff As Double = debit - credit
                    If diff > 0 Then
                        .CrAmount = diff
                        credit += diff
                    Else
                        diff = -(diff)
                        .DrAmount = diff
                        debit += diff
                    End If
                End With

                InsertIntoGrid(tempAccountObj)
            End If

            LblCredit.Text = Format(credit, "0.00")
            LblDebit.Text = Format(debit, "0.00")

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Function GetTrialBalanceDataTable(ByRef companyDataSet As DataSet) As DataTable
        Dim dt As New DataTable
        Try
            If GrdTrialBalance.Rows.Count = 0 Then Exit Try
            If companyDataSet Is Nothing Then Exit Try

            Dim intType As System.Type = Type.GetType("system.Int32", True, True)
            Dim strType As System.Type = Type.GetType("system.String", True, True)
            Dim singType As System.Type = Type.GetType("system.Double", True, True)

            dt.Columns.Add(New DataColumn(cId, intType))
            dt.Columns.Add(New DataColumn(cName, strType))
            dt.Columns.Add(New DataColumn(cDrAmount, singType))
            dt.Columns.Add(New DataColumn(cCrAmount, singType))
            dt.Columns.Add(New DataColumn(lcId, intType))
            dt.Columns.Add(New DataColumn(lcName, strType))
            dt.Columns.Add(New DataColumn(lcAddress, strType))
            dt.Columns.Add(New DataColumn(lcContactPerson, strType))
            dt.Columns.Add(New DataColumn(lcPhone, strType))
            dt.Columns.Add(New DataColumn(lcFax, strType))
            dt.Columns.Add(New DataColumn(lcEmail, strType))
            dt.Columns.Add(New DataColumn(lcCity, strType))
            dt.Columns.Add(New DataColumn(lcState, strType))
            dt.Columns.Add(New DataColumn(lcPin, strType))
            dt.Columns.Add(New DataColumn(lcUpTtNo, strType))
            dt.Columns.Add(New DataColumn(lcCstNo, strType))
            dt.Columns.Add(New DataColumn(lcDlNo, strType))
            dt.Columns.Add(New DataColumn(lcTinNo, strType))

            Dim compRow As DataRow = companyDataSet.Tables(0).Rows(0)

            Dim row As DataGridViewRow
            For Each row In GrdTrialBalance.Rows
                Dim dtRow As DataRow = dt.NewRow
                With dtRow
                    .Item(cId) = row.Cells(lcSNo).Value
                    .Item(cName) = row.Cells(cName).Value
                    .Item(cDrAmount) = row.Cells(cDr).Value
                    .Item(cCrAmount) = row.Cells(cCr).Value
                    .Item(lcId) = compRow.Item(lcId)
                    .Item(lcName) = compRow.Item(lcName)
                    .Item(lcAddress) = compRow.Item(lcAddress)
                    .Item(lcContactPerson) = compRow.Item(lcContactPerson)
                    .Item(lcPhone) = compRow.Item(lcPhone)
                    .Item(lcFax) = compRow.Item(lcFax)
                    .Item(lcEmail) = compRow.Item(lcEmail)
                    .Item(lcCity) = compRow.Item(lcCity)
                    .Item(lcState) = compRow.Item(lcState)
                    .Item(lcPin) = compRow.Item(lcPin)
                    .Item(lcUpTtNo) = compRow.Item(lcUpTtNo)
                    .Item(lcCstNo) = compRow.Item(lcCstNo)
                    .Item(lcDlNo) = compRow.Item(lcDlNo)
                    .Item(lcTinNo) = compRow.Item(lcTinNo)
                End With

                dt.Rows.Add(dtRow)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return dt
    End Function

    Private Function GetTitleForReport() As String
        Dim result As String = ""
        Try
            If OptCondensed.Checked = True Then
                result = result + " Condensed"
            ElseIf OptDetailed.Checked = True Then
                result = result + " Detailed"
            End If

            result = result + " Trial Balance"

            If CmbGroups.Text.Trim <> "" Then
                result = result + " for " + CmbGroups.Text.Trim
            End If

            result = result + " on " + Format(DtPkrDate.Value, "dd-MMMM-yyyy")

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

#End Region

End Class
