Imports System.Windows.Forms

Public Class FrmNewPassword

#Region "Local variables and Constants"

    Enum Index
        GrpPassword = 0
        TxtPasswordOld
        TxtPassword
        TxtPasswordReType
        BtnUpdate
        BtnClose
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

    Private Sub FrmNewPassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

    Private Sub BtnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUpdate.Click
        Try
            If ValidateValues() = False Then Exit Try

            If UpdateUserMasterPassword(Me.Name, gUser.Id, TxtPassword.Text.Trim) <> EnResult.Change Then Exit Sub

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPasswordReType.KeyDown, TxtPasswordOld.KeyDown, TxtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

#End Region

#Region "Private functions"

    Private Sub SetControls()
        SetTabIndex()
        ResetControls()
    End Sub

    Private Sub SetTabIndex()
        GrpPassword.TabIndex = Index.GrpPassword
        TxtPasswordOld.TabIndex = Index.TxtPasswordOld
        TxtPassword.TabIndex = Index.TxtPassword
        TxtPasswordReType.TabIndex = Index.TxtPasswordReType
        BtnUpdate.TabIndex = Index.BtnUpdate
        BtnClose.TabIndex = Index.BtnClose
    End Sub

    Private Sub ResetControls()
        TxtPasswordOld.Text = ""
        TxtPassword.Text = ""
        TxtPasswordReType.Text = ""

        TxtPasswordOld.Focus()
    End Sub

    Private Function ValidateValues() As Boolean
        Dim result As Boolean = False
        Try
            RemoveErrorIcon()

            If TxtPasswordOld.Text.Trim = "" Then
                ErrorInData("Please enter Old Password.", TxtPasswordOld)
                Exit Try
            End If

            If TxtPassword.Text.Trim = "" Then
                ErrorInData("Please enter new Password. Password can't be blank.", TxtPassword)
                Exit Try
            End If

            If TxtPassword.Text <> TxtPasswordReType.Text Then
                ErrorInData("Please enter password carefuly. Password mismatch.", TxtPassword)
                Exit Try
            End If

            If gUser Is Nothing Or ValidateUserMaster(Me.Name, gUser.Id, TxtPasswordOld.Text.Trim) = False Then
                ErrorInData("Please enter Old Password carefuly. It doen't match.", TxtPasswordOld)
                Exit Try
            End If

            result = True

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

#End Region

End Class
