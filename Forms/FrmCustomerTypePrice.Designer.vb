<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCustomerTypePrice
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtItemName = New System.Windows.Forms.TextBox
        Me.GrdCustomerTypePrice = New System.Windows.Forms.DataGridView
        Me.BtnUpdate = New System.Windows.Forms.Button
        Me.BtnCancel = New System.Windows.Forms.Button
        CType(Me.GrdCustomerTypePrice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Item Name"
        '
        'TxtItemName
        '
        Me.TxtItemName.BackColor = System.Drawing.Color.White
        Me.TxtItemName.Enabled = False
        Me.TxtItemName.Location = New System.Drawing.Point(76, 12)
        Me.TxtItemName.Name = "TxtItemName"
        Me.TxtItemName.ReadOnly = True
        Me.TxtItemName.Size = New System.Drawing.Size(302, 20)
        Me.TxtItemName.TabIndex = 1
        '
        'GrdCustomerTypePrice
        '
        Me.GrdCustomerTypePrice.AllowUserToAddRows = False
        Me.GrdCustomerTypePrice.AllowUserToDeleteRows = False
        Me.GrdCustomerTypePrice.AllowUserToResizeColumns = False
        Me.GrdCustomerTypePrice.AllowUserToResizeRows = False
        Me.GrdCustomerTypePrice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdCustomerTypePrice.Location = New System.Drawing.Point(15, 66)
        Me.GrdCustomerTypePrice.Name = "GrdCustomerTypePrice"
        Me.GrdCustomerTypePrice.Size = New System.Drawing.Size(363, 243)
        Me.GrdCustomerTypePrice.TabIndex = 4
        '
        'BtnUpdate
        '
        Me.BtnUpdate.Location = New System.Drawing.Point(242, 38)
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Size = New System.Drawing.Size(65, 25)
        Me.BtnUpdate.TabIndex = 5
        Me.BtnUpdate.Text = "&Update"
        Me.BtnUpdate.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnCancel.Location = New System.Drawing.Point(313, 38)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(65, 25)
        Me.BtnCancel.TabIndex = 6
        Me.BtnCancel.Text = "&Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'FrmCustomerTypePrice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnCancel
        Me.ClientSize = New System.Drawing.Size(393, 321)
        Me.ControlBox = False
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnUpdate)
        Me.Controls.Add(Me.GrdCustomerTypePrice)
        Me.Controls.Add(Me.TxtItemName)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCustomerTypePrice"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Item Sale Price According To Customer Type"
        CType(Me.GrdCustomerTypePrice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtItemName As System.Windows.Forms.TextBox
    Friend WithEvents GrdCustomerTypePrice As System.Windows.Forms.DataGridView
    Friend WithEvents BtnUpdate As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button

End Class
