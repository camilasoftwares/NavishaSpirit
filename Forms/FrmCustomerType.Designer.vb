<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCustomerType
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
        Me.GrpCustomerType = New System.Windows.Forms.GroupBox
        Me.BtnCancel = New System.Windows.Forms.Button
        Me.BtnUpdate = New System.Windows.Forms.Button
        Me.BtnClose = New System.Windows.Forms.Button
        Me.BtnAdd = New System.Windows.Forms.Button
        Me.TxtName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GrdCustomerType = New System.Windows.Forms.DataGridView
        Me.GrpCustomerTypes = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GrpCustomerType.SuspendLayout()
        CType(Me.GrdCustomerType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpCustomerTypes.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpCustomerType
        '
        Me.GrpCustomerType.Controls.Add(Me.BtnCancel)
        Me.GrpCustomerType.Controls.Add(Me.BtnUpdate)
        Me.GrpCustomerType.Controls.Add(Me.BtnClose)
        Me.GrpCustomerType.Controls.Add(Me.BtnAdd)
        Me.GrpCustomerType.Controls.Add(Me.TxtName)
        Me.GrpCustomerType.Controls.Add(Me.Label1)
        Me.GrpCustomerType.Location = New System.Drawing.Point(12, 12)
        Me.GrpCustomerType.Name = "GrpCustomerType"
        Me.GrpCustomerType.Size = New System.Drawing.Size(348, 92)
        Me.GrpCustomerType.TabIndex = 81
        Me.GrpCustomerType.TabStop = False
        Me.GrpCustomerType.Text = "Customer Type"
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(188, 58)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(70, 26)
        Me.BtnCancel.TabIndex = 91
        Me.BtnCancel.Text = "Cance&l"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnUpdate
        '
        Me.BtnUpdate.Location = New System.Drawing.Point(112, 58)
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Size = New System.Drawing.Size(70, 26)
        Me.BtnUpdate.TabIndex = 90
        Me.BtnUpdate.Text = "&Update"
        Me.BtnUpdate.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(264, 58)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(70, 26)
        Me.BtnClose.TabIndex = 89
        Me.BtnClose.Text = "&Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnAdd
        '
        Me.BtnAdd.Location = New System.Drawing.Point(36, 58)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(70, 26)
        Me.BtnAdd.TabIndex = 88
        Me.BtnAdd.Text = "&Add"
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'TxtName
        '
        Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtName.Location = New System.Drawing.Point(90, 19)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(244, 20)
        Me.TxtName.TabIndex = 86
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 84
        Me.Label1.Text = "Customer Type"
        '
        'GrdCustomerType
        '
        Me.GrdCustomerType.AllowUserToAddRows = False
        Me.GrdCustomerType.AllowUserToDeleteRows = False
        Me.GrdCustomerType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdCustomerType.Location = New System.Drawing.Point(6, 19)
        Me.GrdCustomerType.Name = "GrdCustomerType"
        Me.GrdCustomerType.ReadOnly = True
        Me.GrdCustomerType.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdCustomerType.Size = New System.Drawing.Size(336, 262)
        Me.GrdCustomerType.TabIndex = 83
        '
        'GrpCustomerTypes
        '
        Me.GrpCustomerTypes.Controls.Add(Me.GrdCustomerType)
        Me.GrpCustomerTypes.Location = New System.Drawing.Point(12, 110)
        Me.GrpCustomerTypes.Name = "GrpCustomerTypes"
        Me.GrpCustomerTypes.Size = New System.Drawing.Size(348, 291)
        Me.GrpCustomerTypes.TabIndex = 80
        Me.GrpCustomerTypes.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(99, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(187, 13)
        Me.Label2.TabIndex = 85
        Me.Label2.Text = "Please do not add 'General' Customer."
        '
        'FrmCustomerType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(376, 413)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GrpCustomerType)
        Me.Controls.Add(Me.GrpCustomerTypes)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCustomerType"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Customer Type"
        Me.GrpCustomerType.ResumeLayout(False)
        Me.GrpCustomerType.PerformLayout()
        CType(Me.GrdCustomerType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpCustomerTypes.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GrpCustomerType As System.Windows.Forms.GroupBox
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnUpdate As System.Windows.Forms.Button
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents TxtName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GrdCustomerType As System.Windows.Forms.DataGridView
    Friend WithEvents GrpCustomerTypes As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
