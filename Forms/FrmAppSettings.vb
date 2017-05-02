Imports System.Windows.Forms
Imports AIMS.Author

Public Class FrmAppSettings

#Region "Control Functions"

    Private Sub FrmAppSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

#End Region

#Region "Private Functions"

    Private Sub SetControls()
        FillAndSetTax()
        SetTaxOnFree()
    End Sub

#End Region

#Region "Tax Functions"

    Private Sub BtnUpdateTaxOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUpdateTaxOn.Click
        Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.ApplicationSettings_NoUpdate) = True Then Exit Sub
            Dim dlg As New DlgInputBox("Password", "Please enter security password to update tax on field.", True)
            If dlg.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Dim str As String = dlg.EnteredText
                If str <> "2010" Then
                    MsgBox("Illegal Password. Please provide a valid password to update tax on field.", MsgBoxStyle.Critical, "Invalid")
                    Exit Try
                End If
            Else
                Exit Try
            End If

            Dim taxOn As Integer = GetSelectedItemId(CmbTaxOn)
            Dim updatedTax As Integer = UpdateTaxOn(taxOn)

            If taxOn = updatedTax Then
                MsgBox("Tax On field is updated.", , "Updated")
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub FillAndSetTax()
        Try
            CmbTaxOn.Items.Clear()
            Dim def As String = "Default"

            Dim obj As New ClsIdName
            With obj
                .Id = 0
                .Name = def
            End With
            CmbTaxOn.Items.Add(obj)

            obj = New ClsIdName
            With obj
                .Id = EnFields.MRP
                .Name = cMRP
            End With
            CmbTaxOn.Items.Add(obj)

            obj = New ClsIdName
            With obj
                .Id = EnFields.PTR
                .Name = cPTR
            End With
            CmbTaxOn.Items.Add(obj)

            obj = New ClsIdName
            With obj
                .Id = EnFields.PTS
                .Name = cPTS
            End With
            CmbTaxOn.Items.Add(obj)

            obj = New ClsIdName
            With obj
                .Id = EnFields.PTD
                .Name = cRate3
            End With
            CmbTaxOn.Items.Add(obj)

            obj = New ClsIdName
            With obj
                .Id = EnFields.Rate1
                .Name = cRate1
            End With
            CmbTaxOn.Items.Add(obj)

            obj = New ClsIdName
            With obj
                .Id = EnFields.Rate2
                .Name = cRate2
            End With
            CmbTaxOn.Items.Add(obj)


            CmbTaxOn.DisplayMember = cName
            CmbTaxOn.ValueMember = cId

            Dim taxOn As Integer = GetTaxOn()
            CmbTaxOn.Text = GetFieldName(taxOn)

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Function GetFieldName(ByVal id As Integer) As String
        Dim result As String = ""
        Try
            For Each obj As ClsIdName In CmbTaxOn.Items
                If obj.Id = id Then
                    result = obj.Name
                    Exit Try
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

#End Region

#Region "Tax On Free"

    Private Sub SetTaxOnFree()
        ChkTaxOnFree.Checked = GetTaxOnFree()
    End Sub

    Private Sub BtnUpdateTaxOnFree_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUpdateTaxOnFree.Click
        Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.AccountHead_NoUpdate) = True Then Exit Sub
            Dim dlg As New DlgInputBox("Password", "Please enter security password to update tax on free.", True)
            If dlg.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Dim str As String = dlg.EnteredText
                If str <> "2010" Then
                    MsgBox("Illegal Password. Please provide a valid password to update tax on free.", MsgBoxStyle.Critical, "Invalid")
                    Exit Try
                End If
            Else
                Exit Try
            End If

            UpdateTaxOnFree(ChkTaxOnFree.Checked)

            MsgBox("Tax On free is updated.", , "Updated")

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

#End Region

End Class
