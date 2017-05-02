<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDivisionMaster
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
        Me.GrpButton = New System.Windows.Forms.GroupBox
        Me.BtnCancel = New System.Windows.Forms.Button
        Me.BtnUpdate = New System.Windows.Forms.Button
        Me.BtnClose = New System.Windows.Forms.Button
        Me.BtnAdd = New System.Windows.Forms.Button
        Me.GrpDivisionDetails = New System.Windows.Forms.GroupBox
        Me.GrdDivisionDetails = New System.Windows.Forms.DataGridView
        Me.GrpDivision = New System.Windows.Forms.GroupBox
        Me.TxtDivision = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GrpButton.SuspendLayout()
        Me.GrpDivisionDetails.SuspendLayout()
        CType(Me.GrdDivisionDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpDivision.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpButton
        '
        Me.GrpButton.Controls.Add(Me.BtnCancel)
        Me.GrpButton.Controls.Add(Me.BtnUpdate)
        Me.GrpButton.Controls.Add(Me.BtnClose)
        Me.GrpButton.Controls.Add(Me.BtnAdd)
        Me.GrpButton.Location = New System.Drawing.Point(12, 67)
        Me.GrpButton.Name = "GrpButton"
        Me.GrpButton.Size = New System.Drawing.Size(325, 52)
        Me.GrpButton.TabIndex = 15
        Me.GrpButton.TabStop = False
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(165, 19)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(72, 26)
        Me.BtnCancel.TabIndex = 3
        Me.BtnCancel.Text = "Cance&l"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnUpdate
        '
        Me.BtnUpdate.Location = New System.Drawing.Point(87, 19)
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Size = New System.Drawing.Size(72, 26)
        Me.BtnUpdate.TabIndex = 2
        Me.BtnUpdate.Text = "&Update"
        Me.BtnUpdate.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(243, 19)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(72, 26)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "&Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnAdd
        '
        Me.BtnAdd.Location = New System.Drawing.Point(9, 19)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(72, 26)
        Me.BtnAdd.TabIndex = 0
        Me.BtnAdd.Text = "&Add"
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'GrpDivisionDetails
        '
        Me.GrpDivisionDetails.Controls.Add(Me.GrdDivisionDetails)
        Me.GrpDivisionDetails.Location = New System.Drawing.Point(12, 125)
        Me.GrpDivisionDetails.Name = "GrpDivisionDetails"
        Me.GrpDivisionDetails.Size = New System.Drawing.Size(325, 375)
        Me.GrpDivisionDetails.TabIndex = 14
        Me.GrpDivisionDetails.TabStop = False
        Me.GrpDivisionDetails.Text = "Division Details"
        '
        'GrdDivisionDetails
        '
        Me.GrdDivisionDetails.AllowUserToAddRows = False
        Me.GrdDivisionDetails.AllowUserToDeleteRows = False
        Me.GrdDivisionDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdDivisionDetails.Location = New System.Drawing.Point(6, 19)
        Me.GrdDivisionDetails.Name = "GrdDivisionDetails"
        Me.GrdDivisionDetails.ReadOnly = True
        Me.GrdDivisionDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdDivisionDetails.Size = New System.Drawing.Size(309, 350)
        Me.GrdDivisionDetails.TabIndex = 5
        '
        'GrpDivision
        '
        Me.GrpDivision.Controls.Add(Me.TxtDivision)
        Me.GrpDivision.Controls.Add(Me.Label2)
        Me.GrpDivision.Location = New System.Drawing.Point(12, 12)
        Me.GrpDivision.Name = "GrpDivision"
        Me.GrpDivision.Size = New System.Drawing.Size(325, 49)
        Me.GrpDivision.TabIndex = 13
        Me.GrpDivision.TabStop = False
        Me.GrpDivision.Text = "Division"
        '
        'TxtDivision
        '
        Me.TxtDivision.Location = New System.Drawing.Point(65, 19)
        Me.TxtDivision.Name = "TxtDivision"
        Me.TxtDivision.Size = New System.Drawing.Size(240, 20)
        Me.TxtDivision.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Division*"
        '
        'FrmDivisionMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(352, 511)
        Me.ControlBox = False
        Me.Controls.Add(Me.GrpButton)
        Me.Controls.Add(Me.GrpDivisionDetails)
        Me.Controls.Add(Me.GrpDivision)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmDivisionMaster"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Division Master"
        Me.GrpButton.ResumeLayout(False)
        Me.GrpDivisionDetails.ResumeLayout(False)
        CType(Me.GrdDivisionDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpDivision.ResumeLayout(False)
        Me.GrpDivision.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpButton As System.Windows.Forms.GroupBox
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnUpdate As System.Windows.Forms.Button
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents GrpDivisionDetails As System.Windows.Forms.GroupBox
    Friend WithEvents GrdDivisionDetails As System.Windows.Forms.DataGridView
    Friend WithEvents GrpDivision As System.Windows.Forms.GroupBox
    Friend WithEvents TxtDivision As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
