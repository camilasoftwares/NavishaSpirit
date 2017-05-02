Public Class FrmLogin

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click

        RemoveErrorIcon()

        'TODO: Remove this in full Copy
        'Dim dateObj As New Date(2010, 12, 1)
        'If Now.CompareTo(dateObj) > 0 Then
        '    MsgBox("This is trial version. Please buy full copy.")
        '    Me.DialogResult = Windows.Forms.DialogResult.Cancel
        '    Me.Close()
        '    Exit Sub
        'End If

        If TxtUser.Text.Trim = "" Then
            ErrorInData("Enter User Name.", TxtUser)
            Exit Sub
        End If

        If TxtPass.Text.Trim = "" Then
            ErrorInData("Enter Password.", TxtPass)
            Exit Sub
        End If

        Dim user As ClsUserMaster = GetUserMaster(Me.Name, TxtUser.Text.Trim, TxtPass.Text.Trim)
        If user Is Nothing Then
            ErrorInData("User Name Or Password is Incorrect.", TxtUser)
        Else
            user.Password = ""
            gUser = user
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtUser.KeyDown, TxtPass.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

End Class
