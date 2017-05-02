<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAppSettings
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
        Me.GrpTaxOn = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.BtnUpdateTaxOn = New System.Windows.Forms.Button
        Me.CmbTaxOn = New System.Windows.Forms.ComboBox
        Me.BtnClose = New System.Windows.Forms.Button
        Me.GrpTaxOnFree = New System.Windows.Forms.GroupBox
        Me.ChkTaxOnFree = New System.Windows.Forms.CheckBox
        Me.BtnUpdateTaxOnFree = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.GrpTaxOn.SuspendLayout()
        Me.GrpTaxOnFree.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpTaxOn
        '
        Me.GrpTaxOn.Controls.Add(Me.Label1)
        Me.GrpTaxOn.Controls.Add(Me.BtnUpdateTaxOn)
        Me.GrpTaxOn.Controls.Add(Me.CmbTaxOn)
        Me.GrpTaxOn.Location = New System.Drawing.Point(12, 12)
        Me.GrpTaxOn.Name = "GrpTaxOn"
        Me.GrpTaxOn.Size = New System.Drawing.Size(356, 69)
        Me.GrpTaxOn.TabIndex = 0
        Me.GrpTaxOn.TabStop = False
        Me.GrpTaxOn.Text = "Tax On"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(6, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(299, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "*Change from 'Default' tax on assumed as 'Tax Inclusive' price"
        '
        'BtnUpdateTaxOn
        '
        Me.BtnUpdateTaxOn.Location = New System.Drawing.Point(257, 15)
        Me.BtnUpdateTaxOn.Name = "BtnUpdateTaxOn"
        Me.BtnUpdateTaxOn.Size = New System.Drawing.Size(89, 27)
        Me.BtnUpdateTaxOn.TabIndex = 1
        Me.BtnUpdateTaxOn.Text = "Update"
        Me.BtnUpdateTaxOn.UseVisualStyleBackColor = True
        '
        'CmbTaxOn
        '
        Me.CmbTaxOn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbTaxOn.FormattingEnabled = True
        Me.CmbTaxOn.Location = New System.Drawing.Point(6, 19)
        Me.CmbTaxOn.Name = "CmbTaxOn"
        Me.CmbTaxOn.Size = New System.Drawing.Size(232, 21)
        Me.CmbTaxOn.TabIndex = 0
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(-67, 125)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(27, 22)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.TabStop = False
        Me.BtnClose.Text = "&X"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'GrpTaxOnFree
        '
        Me.GrpTaxOnFree.Controls.Add(Me.Label2)
        Me.GrpTaxOnFree.Controls.Add(Me.ChkTaxOnFree)
        Me.GrpTaxOnFree.Controls.Add(Me.BtnUpdateTaxOnFree)
        Me.GrpTaxOnFree.Location = New System.Drawing.Point(12, 87)
        Me.GrpTaxOnFree.Name = "GrpTaxOnFree"
        Me.GrpTaxOnFree.Size = New System.Drawing.Size(356, 76)
        Me.GrpTaxOnFree.TabIndex = 1
        Me.GrpTaxOnFree.TabStop = False
        Me.GrpTaxOnFree.Text = "Tax On Free"
        '
        'ChkTaxOnFree
        '
        Me.ChkTaxOnFree.AutoSize = True
        Me.ChkTaxOnFree.Location = New System.Drawing.Point(9, 19)
        Me.ChkTaxOnFree.Name = "ChkTaxOnFree"
        Me.ChkTaxOnFree.Size = New System.Drawing.Size(157, 17)
        Me.ChkTaxOnFree.TabIndex = 0
        Me.ChkTaxOnFree.Text = "Apply tax on free items also."
        Me.ChkTaxOnFree.UseVisualStyleBackColor = True
        '
        'BtnUpdateTaxOnFree
        '
        Me.BtnUpdateTaxOnFree.Location = New System.Drawing.Point(257, 15)
        Me.BtnUpdateTaxOnFree.Name = "BtnUpdateTaxOnFree"
        Me.BtnUpdateTaxOnFree.Size = New System.Drawing.Size(89, 27)
        Me.BtnUpdateTaxOnFree.TabIndex = 1
        Me.BtnUpdateTaxOnFree.Text = "Update"
        Me.BtnUpdateTaxOnFree.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(6, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(289, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "*Can be only apply when other then 'Default' tax is selected."
        '
        'FrmAppSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(382, 175)
        Me.Controls.Add(Me.GrpTaxOnFree)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.GrpTaxOn)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAppSettings"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Application Settings"
        Me.GrpTaxOn.ResumeLayout(False)
        Me.GrpTaxOn.PerformLayout()
        Me.GrpTaxOnFree.ResumeLayout(False)
        Me.GrpTaxOnFree.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpTaxOn As System.Windows.Forms.GroupBox
    Friend WithEvents BtnUpdateTaxOn As System.Windows.Forms.Button
    Friend WithEvents CmbTaxOn As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents GrpTaxOnFree As System.Windows.Forms.GroupBox
    Friend WithEvents ChkTaxOnFree As System.Windows.Forms.CheckBox
    Friend WithEvents BtnUpdateTaxOnFree As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
