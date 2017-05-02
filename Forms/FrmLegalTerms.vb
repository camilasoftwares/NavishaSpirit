Imports System.Windows.Forms
Imports AIMS.Author

Public Class FrmLegalTerms

#Region "Local variables"
    Dim editRow As DataGridViewRow = Nothing
#End Region

#Region "Control Functions"

    Private Sub FrmLegalTerms_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.LegalTerms_NoAdd) = True Then Exit Sub
            If ValidateValues() = False Then Exit Try

            Dim term As New ClsLegalTerms
            With term
                .Name = TxtTerm.Text
            End With

            Dim id As Integer = InsertIntoLegalTerms(Me.Name, term)
            If id <= 0 Then Exit Try

            term.Id = id
            InsertIntoGrid(term)

            MsgBox("Added Successfully.", MsgBoxStyle.Information, "Successfully")
            ResetControlsToAddNew()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        ResetControlsToAddNew()
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.LegalTerms_NoRemove) = True Then Exit Sub
            If editRow Is Nothing Then Exit Try

            If MsgBox("Want to delete selected row?", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.No Then Exit Sub

            Dim id As Integer = editRow.Cells(cId).Value
            If DeleteLegalTerms(Me.Name, id) <> EnResult.Change Then
                MsgBox("Fail to delete.", MsgBoxStyle.Information, "Fail")
                Exit Sub
            End If

            GrdTerms.Rows.Remove(editRow)
            MsgBox("Successfully Deleted.", MsgBoxStyle.Information, "Successfully")

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNew()
    End Sub

    Private Sub BtnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUpdate.Click
        Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.LegalTerms_NoUpdate) = True Then Exit Sub
            If editRow Is Nothing Then Exit Try
            If ValidateValues() = False Then Exit Sub

            Dim term As New ClsLegalTerms
            With term
                .Id = editRow.Cells(cId).Value
                .Name = TxtTerm.Text
            End With

            If UpdateLegalTerms(Me.Name, term) <> EnResult.Change Then
                MsgBox("Fail to Update.", MsgBoxStyle.Information, "Fail")
                Exit Sub
            End If

            With editRow
                .Cells(cName).Value = term.Name
            End With

            MsgBox("Successfully Updated.", MsgBoxStyle.Information, "Updated")

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNew()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub GrdTerms_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdTerms.CellClick
        Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.LegalTerms_NoUpdate) = True Then Exit Sub
            If e.RowIndex < 0 Then Exit Try

            editRow = GrdTerms.Rows(e.RowIndex)

            BtnAdd.Enabled = False
            BtnUpdate.Enabled = False
            BtnDelete.Enabled = True
            BtnCancel.Enabled = True

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub GrdTerms_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdTerms.CellDoubleClick
        Try
            If e.RowIndex < 0 Then Exit Try

            editRow = GrdTerms.Rows(e.RowIndex)

            TxtTerm.Text = editRow.Cells(cName).Value

            BtnAdd.Enabled = False
            BtnUpdate.Enabled = True
            BtnDelete.Enabled = False
            BtnCancel.Enabled = True

            TxtTerm.Focus()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

#End Region

#Region "Private Functions"

    Private Sub SetControls()
        SetGrid()
        LoadGridValues()

        ResetControlsToAddNew()
    End Sub

    Private Sub SetGrid()
        With GrdTerms
            Dim colCount As Integer = 1
            .RowHeadersVisible = False
            Dim x As Integer
            For x = 0 To colCount
                Select Case x
                    Case 0
                        Dim index As Integer = .Columns.Add(cId, cId)
                        .Columns(index).Visible = False

                    Case 1
                        Dim index As Integer = .Columns.Add(cName, "Terms")
                        .Columns(index).Width = 570

                End Select
            Next
        End With
    End Sub

    Private Sub LoadGridValues()
        Try
            GrdTerms.Rows.Clear()
            Dim legalTerms() As ClsLegalTerms = GetAllLegalTerms(Me.Name)
            If legalTerms Is Nothing Then Exit Try

            Dim legalTerm As ClsLegalTerms
            For Each legalTerm In legalTerms
                InsertIntoGrid(legalTerm)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub InsertIntoGrid(ByRef legalTermObj As ClsLegalTerms)
        Try
            If legalTermObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdTerms.Rows.Add
            With GrdTerms.Rows(rowIndex)
                .Cells(cId).Value = legalTermObj.Id
                .Cells(cName).Value = legalTermObj.Name
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Function ValidateValues() As Boolean
        Dim result As Boolean = False
        Try
            RemoveErrorIcon()

            If TxtTerm.Text.Trim = "" Then
                ErrorInData("Please enter term.", TxtTerm)
                Exit Try
            End If

            result = True

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Sub ResetControlsToAddNew()
        RemoveErrorIcon()

        TxtTerm.Text = ""

        BtnAdd.Enabled = True
        BtnUpdate.Enabled = False
        BtnCancel.Enabled = False
        BtnDelete.Enabled = False

        editRow = Nothing

        TxtTerm.Focus()
    End Sub

#End Region

End Class
