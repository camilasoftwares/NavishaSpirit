<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTaxMaster
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
        Me.GrpTax = New System.Windows.Forms.GroupBox
        Me.TxtPercent = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtDisplayName = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GrpButton = New System.Windows.Forms.GroupBox
        Me.BtnCancel = New System.Windows.Forms.Button
        Me.BtnUpdate = New System.Windows.Forms.Button
        Me.BtnClose = New System.Windows.Forms.Button
        Me.BtnAdd = New System.Windows.Forms.Button
        Me.GrpTaxDetails = New System.Windows.Forms.GroupBox
        Me.GrdTaxDetails = New System.Windows.Forms.DataGridView
        Me.Label3 = New System.Windows.Forms.Label
        Me.GrpTax.SuspendLayout()
        Me.GrpButton.SuspendLayout()
        Me.GrpTaxDetails.SuspendLayout()
        CType(Me.GrdTaxDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpTax
        '
        Me.GrpTax.Controls.Add(Me.Label3)
        Me.GrpTax.Controls.Add(Me.TxtPercent)
        Me.GrpTax.Controls.Add(Me.Label5)
        Me.GrpTax.Controls.Add(Me.TxtDisplayName)
        Me.GrpTax.Controls.Add(Me.Label2)
        Me.GrpTax.Controls.Add(Me.TxtName)
        Me.GrpTax.Controls.Add(Me.Label1)
        Me.GrpTax.Location = New System.Drawing.Point(12, 12)
        Me.GrpTax.Name = "GrpTax"
        Me.GrpTax.Size = New System.Drawing.Size(602, 92)
        Me.GrpTax.TabIndex = 6
        Me.GrpTax.TabStop = False
        Me.GrpTax.Text = "Tax"
        '
        'TxtPercent
        '
        Me.TxtPercent.Location = New System.Drawing.Point(256, 32)
        Me.TxtPercent.Name = "TxtPercent"
        Me.TxtPercent.Size = New System.Drawing.Size(87, 20)
        Me.TxtPercent.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(253, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Tax Percent*"
        '
        'TxtDisplayName
        '
        Me.TxtDisplayName.Location = New System.Drawing.Point(349, 32)
        Me.TxtDisplayName.Name = "TxtDisplayName"
        Me.TxtDisplayName.Size = New System.Drawing.Size(241, 20)
        Me.TxtDisplayName.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(346, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Display Name*"
        '
        'TxtName
        '
        Me.TxtName.Location = New System.Drawing.Point(9, 32)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(241, 20)
        Me.TxtName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tax Name*"
        '
        'GrpButton
        '
        Me.GrpButton.Controls.Add(Me.BtnCancel)
        Me.GrpButton.Controls.Add(Me.BtnUpdate)
        Me.GrpButton.Controls.Add(Me.BtnClose)
        Me.GrpButton.Controls.Add(Me.BtnAdd)
        Me.GrpButton.Location = New System.Drawing.Point(12, 110)
        Me.GrpButton.Name = "GrpButton"
        Me.GrpButton.Size = New System.Drawing.Size(602, 55)
        Me.GrpButton.TabIndex = 10
        Me.GrpButton.TabStop = False
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(440, 19)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(72, 26)
        Me.BtnCancel.TabIndex = 3
        Me.BtnCancel.Text = "Cance&l"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnUpdate
        '
        Me.BtnUpdate.Location = New System.Drawing.Point(362, 19)
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Size = New System.Drawing.Size(72, 26)
        Me.BtnUpdate.TabIndex = 2
        Me.BtnUpdate.Text = "&Update"
        Me.BtnUpdate.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(518, 19)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(72, 26)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "&Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnAdd
        '
        Me.BtnAdd.Location = New System.Drawing.Point(284, 19)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(72, 26)
        Me.BtnAdd.TabIndex = 0
        Me.BtnAdd.Text = "&Add"
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'GrpTaxDetails
        '
        Me.GrpTaxDetails.Controls.Add(Me.GrdTaxDetails)
        Me.GrpTaxDetails.Location = New System.Drawing.Point(12, 171)
        Me.GrpTaxDetails.Name = "GrpTaxDetails"
        Me.GrpTaxDetails.Size = New System.Drawing.Size(602, 381)
        Me.GrpTaxDetails.TabIndex = 11
        Me.GrpTaxDetails.TabStop = False
        Me.GrpTaxDetails.Text = "Tax Details"
        '
        'GrdTaxDetails
        '
        Me.GrdTaxDetails.AllowUserToAddRows = False
        Me.GrdTaxDetails.AllowUserToDeleteRows = False
        Me.GrdTaxDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdTaxDetails.Location = New System.Drawing.Point(6, 19)
        Me.GrdTaxDetails.Name = "GrdTaxDetails"
        Me.GrdTaxDetails.ReadOnly = True
        Me.GrdTaxDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdTaxDetails.Size = New System.Drawing.Size(590, 356)
        Me.GrdTaxDetails.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(6, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(551, 26)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Display Name is used on Reports or bills." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Two display name can be same with diff" & _
            "erent tax percent but the tax name can not be same and avoid to change it."
        '
        'FrmTaxMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(628, 566)
        Me.ControlBox = False
        Me.Controls.Add(Me.GrpTaxDetails)
        Me.Controls.Add(Me.GrpButton)
        Me.Controls.Add(Me.GrpTax)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmTaxMaster"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Tax Master"
        Me.GrpTax.ResumeLayout(False)
        Me.GrpTax.PerformLayout()
        Me.GrpButton.ResumeLayout(False)
        Me.GrpTaxDetails.ResumeLayout(False)
        CType(Me.GrdTaxDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpTax As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPercent As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtDisplayName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GrpButton As System.Windows.Forms.GroupBox
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnUpdate As System.Windows.Forms.Button
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents GrpTaxDetails As System.Windows.Forms.GroupBox
    Friend WithEvents GrdTaxDetails As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
