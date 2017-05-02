Imports System.Windows.Forms
Imports AIMS.Author

Public Class FrmTaxMaster

#Region "Local variables and Constants"

    Dim editRow As DataGridViewRow = Nothing
    Dim flagChange As Boolean = False

    Enum Index
        GrpTax = 0
        TxtName
        TxtPercent
        TxtDisplayName
        GrpButton
        BtnAdd
        BtnUpdate
        BtnCancel
        BtnClose
        GrpTaxDetails
        GrdTaxDetails
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

    Private Sub FrmTaxMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.Tax_NoAdd) = True Then Exit Sub
            If ValidateValues() = False Then Exit Sub

            If NameExistInGrid(TxtName.Text) = True Then
                ErrorInData("Name already exist in list.", TxtName)
                Exit Sub
            End If

            Dim tax As New ClsTaxMaster
            With tax
                .Name = TxtName.Text
                .TaxPercent = Val(TxtPercent.Text)
                .DisplayName = TxtDisplayName.Text
            End With

            Dim id As Integer = InsertIntoTaxMaster(Me.Name, tax)
            If id > 0 Then
                flagChange = True
                tax.Id = id
                InsertIntoGrid(tax)
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNew()
    End Sub

    Private Sub BtnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUpdate.Click
        Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.Tax_NoUpdate) = True Then Exit Sub
            If editRow Is Nothing Then Exit Try
            If ValidateValues() = False Then Exit Sub

            Dim tax As New ClsTaxMaster
            With tax
                .Id = editRow.Cells(cId).Value
                .Name = TxtName.Text
                .DisplayName = TxtDisplayName.Text
                .TaxPercent = Val(TxtPercent.Text)
            End With

            If TaxMasterUpdatable(Me.Name, tax) = False Then
                ErrorInData("Already exist with other id.", TxtName)
                Exit Sub
            End If

            If UpdateTaxMaster(Me.Name, tax) <> EnResult.Change Then Exit Sub

            flagChange = True
            With editRow
                .Cells(cName).Value = TxtName.Text
                .Cells(cDisplayName).Value = TxtDisplayName.Text
                .Cells(cTaxPercent).Value = tax.TaxPercent
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNew()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        ResetControlsToAddNew()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub GrdTaxDetails_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdTaxDetails.CellDoubleClick
        Try
            If e.RowIndex < 0 Then Exit Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.Tax_NoUpdate) = True Then Exit Sub

            editRow = GrdTaxDetails.Rows(e.RowIndex)
            With editRow
                TxtName.Text = .Cells(cName).Value
                TxtDisplayName.Text = .Cells(cDisplayName).Value
                TxtPercent.Text = .Cells(cTaxPercent).Value
            End With

            BtnAdd.Enabled = False
            BtnUpdate.Enabled = True
            BtnCancel.Enabled = True

            TxtName.Focus()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub GrdTaxDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdTaxDetails.KeyDown
        If e.KeyCode = Keys.Tab Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub TxtPercent_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPercent.KeyPress
        e.Handled = Check_DecimalAllow(e.KeyChar, sender.text)
    End Sub

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPercent.KeyDown, TxtName.KeyDown, TxtDisplayName.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

#End Region

#Region "Public Functions"

    Public Function Change() As Boolean
        Return flagChange
    End Function

#End Region

#Region "Private Functions"

    Private Sub SetControls()
        SetTabIndex()
        SetGrid()
        LoadGridValues()

        ResetControlsToAddNew()
    End Sub

    Private Sub SetTabIndex()
        GrpTax.TabIndex = Index.GrpTax
        TxtName.TabIndex = Index.TxtName
        TxtDisplayName.TabIndex = Index.TxtDisplayName
        TxtPercent.TabIndex = Index.TxtPercent
        GrpButton.TabIndex = Index.GrpButton
        BtnAdd.TabIndex = Index.BtnAdd
        BtnUpdate.TabIndex = Index.BtnUpdate
        BtnCancel.TabIndex = Index.BtnCancel
        BtnClose.TabIndex = Index.BtnClose
        GrpTaxDetails.TabIndex = Index.GrpTaxDetails
        GrdTaxDetails.TabIndex = Index.GrdTaxDetails
    End Sub

    Private Sub SetGrid()
        With GrdTaxDetails
            Dim colCount As Integer = 3
            .RowHeadersVisible = False
            Dim defaultCellWidth As Integer = 90
            Dim x As Integer
            For x = 0 To colCount
                Select Case x
                    Case 0
                        Dim index As Integer = .Columns.Add(cId, cId)
                        .Columns(index).Visible = False

                    Case 1
                        Dim index As Integer = .Columns.Add(cName, cName)
                        .Columns(index).Width = defaultCellWidth + 100

                    Case 2
                        Dim index As Integer = .Columns.Add(cTaxPercent, "Percent")
                        .Columns(index).Width = defaultCellWidth

                    Case 3
                        Dim index As Integer = .Columns.Add(cDisplayName, "Display Name")
                        .Columns(index).Width = defaultCellWidth + 190

                End Select
            Next
        End With
    End Sub

    Private Sub LoadGridValues()
        Try
            GrdTaxDetails.Rows.Clear()
            Dim taxs() As ClsTaxMaster = GetAllTaxMasters(Me.Name)
            If taxs Is Nothing Then Exit Try

            Dim tax As ClsTaxMaster
            For Each tax In taxs
                InsertIntoGrid(tax)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub InsertIntoGrid(ByRef taxObj As ClsTaxMaster)
        Try
            If taxObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdTaxDetails.Rows.Add
            With GrdTaxDetails.Rows(rowIndex)
                .Cells(cId).Value = taxObj.Id
                .Cells(cName).Value = taxObj.Name
                .Cells(cTaxPercent).Value = taxObj.TaxPercent
                .Cells(cDisplayName).Value = taxObj.DisplayName
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Function NameExistInGrid(ByVal name As String) As Boolean
        Dim result As Boolean = False
        Try
            name = name.Trim
            If name = "" Then Exit Try

            Dim row As DataGridViewRow
            For Each row In GrdTaxDetails.Rows
                If UCase(row.Cells(cName).Value) = UCase(name) Then
                    result = True
                    Exit Try
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Function ValidateValues() As Boolean
        Dim result As Boolean = False
        Try
            RemoveErrorIcon()

            If TxtName.Text.Trim = "" Then
                ErrorInData("Please enter Tax name.", TxtName)
                Exit Try
            End If

            If TxtDisplayName.Text.Trim = "" Then
                ErrorInData("Please enter display name.", TxtDisplayName)
                Exit Try
            End If

            If TxtPercent.Text.Trim = "" Then
                ErrorInData("Please enter Tax Percent.", TxtPercent)
                Exit Try
            End If

            result = True

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Sub ResetControlsToAddNew()
        TxtName.Text = ""
        TxtDisplayName.Text = ""
        TxtPercent.Text = ""

        BtnAdd.Enabled = True
        BtnUpdate.Enabled = False
        BtnCancel.Enabled = False
        RemoveErrorIcon()

        editRow = Nothing

        TxtName.Focus()
    End Sub

#End Region

End Class
