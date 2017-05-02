<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConnectionString
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtDatasource = New System.Windows.Forms.TextBox()
        Me.TxtCatalog = New System.Windows.Forms.TextBox()
        Me.TxtUserId = New System.Windows.Forms.TextBox()
        Me.TxtPassword = New System.Windows.Forms.TextBox()
        Me.BtnTestConnection = New System.Windows.Forms.Button()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.ChkIntegratedSecurity = New System.Windows.Forms.CheckBox()
        Me.cmbTradingPoint = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(133, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Datasource (Server Name)"
        Me.Label1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Catalog (Database)"
        Me.Label2.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "User Id"
        Me.Label3.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Password"
        Me.Label4.Visible = False
        '
        'TxtDatasource
        '
        Me.TxtDatasource.Location = New System.Drawing.Point(51, 58)
        Me.TxtDatasource.Name = "TxtDatasource"
        Me.TxtDatasource.Size = New System.Drawing.Size(90, 20)
        Me.TxtDatasource.TabIndex = 4
        Me.TxtDatasource.Visible = False
        '
        'TxtCatalog
        '
        Me.TxtCatalog.Location = New System.Drawing.Point(51, 58)
        Me.TxtCatalog.Name = "TxtCatalog"
        Me.TxtCatalog.Size = New System.Drawing.Size(90, 20)
        Me.TxtCatalog.TabIndex = 5
        Me.TxtCatalog.Visible = False
        '
        'TxtUserId
        '
        Me.TxtUserId.Location = New System.Drawing.Point(51, 58)
        Me.TxtUserId.Name = "TxtUserId"
        Me.TxtUserId.Size = New System.Drawing.Size(90, 20)
        Me.TxtUserId.TabIndex = 6
        Me.TxtUserId.Visible = False
        '
        'TxtPassword
        '
        Me.TxtPassword.Location = New System.Drawing.Point(51, 58)
        Me.TxtPassword.Name = "TxtPassword"
        Me.TxtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPassword.Size = New System.Drawing.Size(90, 20)
        Me.TxtPassword.TabIndex = 7
        Me.TxtPassword.Visible = False
        '
        'BtnTestConnection
        '
        Me.BtnTestConnection.Location = New System.Drawing.Point(26, 55)
        Me.BtnTestConnection.Name = "BtnTestConnection"
        Me.BtnTestConnection.Size = New System.Drawing.Size(118, 25)
        Me.BtnTestConnection.TabIndex = 9
        Me.BtnTestConnection.Text = "&Test Connection"
        Me.BtnTestConnection.UseVisualStyleBackColor = True
        Me.BtnTestConnection.Visible = False
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(202, 55)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(85, 25)
        Me.BtnSave.TabIndex = 10
        Me.BtnSave.Text = "&OK"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(293, 55)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(85, 25)
        Me.BtnClose.TabIndex = 11
        Me.BtnClose.Text = "&Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'ChkIntegratedSecurity
        '
        Me.ChkIntegratedSecurity.AutoSize = True
        Me.ChkIntegratedSecurity.Location = New System.Drawing.Point(51, 60)
        Me.ChkIntegratedSecurity.Name = "ChkIntegratedSecurity"
        Me.ChkIntegratedSecurity.Size = New System.Drawing.Size(115, 17)
        Me.ChkIntegratedSecurity.TabIndex = 8
        Me.ChkIntegratedSecurity.Text = "Integrated Security"
        Me.ChkIntegratedSecurity.UseVisualStyleBackColor = True
        Me.ChkIntegratedSecurity.Visible = False
        '
        'cmbTradingPoint
        '
        Me.cmbTradingPoint.FormattingEnabled = True
        Me.cmbTradingPoint.Location = New System.Drawing.Point(163, 12)
        Me.cmbTradingPoint.Name = "cmbTradingPoint"
        Me.cmbTradingPoint.Size = New System.Drawing.Size(215, 21)
        Me.cmbTradingPoint.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(25, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Select Trading Point"
        '
        'FrmConnectionString
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(395, 95)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmbTradingPoint)
        Me.Controls.Add(Me.ChkIntegratedSecurity)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.BtnTestConnection)
        Me.Controls.Add(Me.TxtPassword)
        Me.Controls.Add(Me.TxtUserId)
        Me.Controls.Add(Me.TxtCatalog)
        Me.Controls.Add(Me.TxtDatasource)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmConnectionString"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Trading Point"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtDatasource As System.Windows.Forms.TextBox
    Friend WithEvents TxtCatalog As System.Windows.Forms.TextBox
    Friend WithEvents TxtUserId As System.Windows.Forms.TextBox
    Friend WithEvents TxtPassword As System.Windows.Forms.TextBox
    Friend WithEvents BtnTestConnection As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents ChkIntegratedSecurity As System.Windows.Forms.CheckBox
    Friend WithEvents cmbTradingPoint As ComboBox
    Friend WithEvents Label5 As Label
End Class
