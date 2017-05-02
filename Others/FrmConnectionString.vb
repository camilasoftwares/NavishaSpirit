Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Configuration

Public Class FrmConnectionString

    Private Sub BtnTestConnection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTestConnection.Click
        Try
            Dim connStr As String = GetCustomConnectionString()

            Dim sql As String = "Select * from temp"

            Dim conn As SqlConnection = New SqlConnection(connStr)
            Dim retVal As Object = 0
            Dim cmd As New SqlCommand(sql, conn)
            cmd.Connection.Open()
            retVal = cmd.ExecuteScalar()
            cmd.Connection.Close()

            If retVal Is Nothing Then
                MsgBox("Connection values are not correct or check your connection.", MsgBoxStyle.Critical, "Fail")
            Else
                MsgBox("Connection Successfull", MsgBoxStyle.Information, "Successfull")
            End If

        Catch ex As Exception
            MsgBox("Connection values are not correct or check your connection.", MsgBoxStyle.Critical, "Fail")
        End Try
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            'Dim dlg As New DlgInputBox("Password", "Please enter security password to change connection string.", True)
            'If dlg.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            '    Dim str As String = dlg.EnteredText
            '    If str <> "2010" Then
            '        MsgBox("Illegal Password. Please provide a valid password to update connection string.", MsgBoxStyle.Critical, "Invalid")
            '        Exit Try
            '    End If
            'Else
            '    Exit Try
            'End If

            Dim config As System.Configuration.Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
            If config Is Nothing Then
                MsgBox("Unable to set config file.", MsgBoxStyle.Critical, "File")
                Exit Try
            End If

            Dim connStrings As System.Configuration.ConnectionStringsSection = config.ConnectionStrings
            If connStrings Is Nothing Then
                MsgBox("Unable to find connection strings in config file.", MsgBoxStyle.Critical, "Connection String")
                Exit Try
            End If

            Dim conString As String = config.ConnectionStrings.ConnectionStrings.Item(cmbTradingPoint.SelectedItem.ToString()).ConnectionString  'GetCustomConnectionString()
            Dim b() As Byte = System.Text.ASCIIEncoding.ASCII.GetBytes(conString)
            conString = Convert.ToBase64String(b)

            Dim conStrSetting As System.Configuration.ConnectionStringSettings = connStrings.ConnectionStrings(cConnectionStringKey)
            If conStrSetting.ConnectionString <> conString Then
                If conStrSetting IsNot Nothing Then
                    config.ConnectionStrings.ConnectionStrings.Remove(conStrSetting)
                End If
                conStrSetting = New System.Configuration.ConnectionStringSettings
                conStrSetting.ConnectionString = conString
                conStrSetting.ProviderName = "System.Data.SqlClient"
                conStrSetting.Name = cConnectionStringKey
                config.ConnectionStrings.ConnectionStrings.Add(conStrSetting)
                ClsDBFunctions.GetInstance.ConnectionStringValue = ""
            Else
                conStrSetting.ConnectionString = conString
                conStrSetting.ProviderName = "System.Data.SqlClient"
                conStrSetting.Name = cConnectionStringKey
            End If

            config.Save()
            System.Configuration.ConfigurationManager.RefreshSection("connectionStrings")

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

    Private Function GetCustomConnectionString() As String
        Dim connStr As String = ""
        connStr = "Data Source=" + TxtDatasource.Text.Trim + "; "
        connStr = connStr + "Initial Catalog=" + TxtCatalog.Text.Trim + "; "
        If ChkIntegratedSecurity.Checked = False Then
            connStr = connStr + "User ID=" + TxtUserId.Text.Trim + "; "
            connStr = connStr + "Password=" + TxtPassword.Text.Trim
        Else
            connStr = connStr + "Integrated Security = True; "
        End If
        connStr = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='E:\Projects\Shobhit\backup\Account Inventory Management System(Sanny)\AIMS-Local.mdf';Integrated Security=True"
        Return connStr
    End Function

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtUserId.KeyDown, TxtPassword.KeyDown, TxtDatasource.KeyDown, TxtCatalog.KeyDown, ChkIntegratedSecurity.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub ChkIntegratedSecurity_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkIntegratedSecurity.CheckedChanged
        Dim flag As Boolean = Not ChkIntegratedSecurity.Checked

        TxtUserId.Enabled = flag
        TxtPassword.Enabled = flag
    End Sub

    Private Sub FrmConnectionString_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim config As System.Configuration.Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
        If config Is Nothing Then
            MsgBox("Unable to set config file.", MsgBoxStyle.Critical, "File")
        End If

        Dim connStrings As System.Configuration.ConnectionStringsSection = config.ConnectionStrings
        If connStrings Is Nothing Then
            MsgBox("Unable to find connection strings in config file.", MsgBoxStyle.Critical, "Connection String")
        End If
        cmbTradingPoint.Items.Clear()
        For Each con As ConnectionStringSettings In connStrings.ConnectionStrings
            cmbTradingPoint.Items.Add(con.Name)
        Next
    End Sub
End Class
