<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmStorageMaster
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
        Me.GrpStorageDetails = New System.Windows.Forms.GroupBox
        Me.GrdStorageDetails = New System.Windows.Forms.DataGridView
        Me.GrpStorage = New System.Windows.Forms.GroupBox
        Me.TxtStorage = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtSNo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GrpButton.SuspendLayout()
        Me.GrpStorageDetails.SuspendLayout()
        CType(Me.GrdStorageDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpStorage.SuspendLayout()
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
        Me.GrpButton.Size = New System.Drawing.Size(417, 52)
        Me.GrpButton.TabIndex = 9
        Me.GrpButton.TabStop = False
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(261, 19)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(72, 26)
        Me.BtnCancel.TabIndex = 3
        Me.BtnCancel.Text = "Cance&l"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnUpdate
        '
        Me.BtnUpdate.Location = New System.Drawing.Point(183, 19)
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Size = New System.Drawing.Size(72, 26)
        Me.BtnUpdate.TabIndex = 2
        Me.BtnUpdate.Text = "&Update"
        Me.BtnUpdate.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(339, 19)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(72, 26)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "&Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnAdd
        '
        Me.BtnAdd.Location = New System.Drawing.Point(105, 19)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(72, 26)
        Me.BtnAdd.TabIndex = 0
        Me.BtnAdd.Text = "&Add"
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'GrpStorageDetails
        '
        Me.GrpStorageDetails.Controls.Add(Me.GrdStorageDetails)
        Me.GrpStorageDetails.Location = New System.Drawing.Point(12, 125)
        Me.GrpStorageDetails.Name = "GrpStorageDetails"
        Me.GrpStorageDetails.Size = New System.Drawing.Size(417, 375)
        Me.GrpStorageDetails.TabIndex = 8
        Me.GrpStorageDetails.TabStop = False
        Me.GrpStorageDetails.Text = "Storage Details"
        '
        'GrdStorageDetails
        '
        Me.GrdStorageDetails.AllowUserToAddRows = False
        Me.GrdStorageDetails.AllowUserToDeleteRows = False
        Me.GrdStorageDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdStorageDetails.Location = New System.Drawing.Point(6, 19)
        Me.GrdStorageDetails.Name = "GrdStorageDetails"
        Me.GrdStorageDetails.ReadOnly = True
        Me.GrdStorageDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdStorageDetails.Size = New System.Drawing.Size(405, 350)
        Me.GrdStorageDetails.TabIndex = 5
        '
        'GrpStorage
        '
        Me.GrpStorage.Controls.Add(Me.TxtStorage)
        Me.GrpStorage.Controls.Add(Me.Label2)
        Me.GrpStorage.Controls.Add(Me.TxtSNo)
        Me.GrpStorage.Controls.Add(Me.Label1)
        Me.GrpStorage.Location = New System.Drawing.Point(12, 12)
        Me.GrpStorage.Name = "GrpStorage"
        Me.GrpStorage.Size = New System.Drawing.Size(417, 49)
        Me.GrpStorage.TabIndex = 7
        Me.GrpStorage.TabStop = False
        Me.GrpStorage.Text = "Storage"
        '
        'TxtStorage
        '
        Me.TxtStorage.Location = New System.Drawing.Point(166, 19)
        Me.TxtStorage.Name = "TxtStorage"
        Me.TxtStorage.Size = New System.Drawing.Size(232, 20)
        Me.TxtStorage.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(104, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Storage*"
        '
        'TxtSNo
        '
        Me.TxtSNo.BackColor = System.Drawing.Color.White
        Me.TxtSNo.Enabled = False
        Me.TxtSNo.Location = New System.Drawing.Point(49, 19)
        Me.TxtSNo.Name = "TxtSNo"
        Me.TxtSNo.ReadOnly = True
        Me.TxtSNo.Size = New System.Drawing.Size(49, 20)
        Me.TxtSNo.TabIndex = 1
        Me.TxtSNo.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "S. No."
        '
        'FrmStorageMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(443, 512)
        Me.ControlBox = False
        Me.Controls.Add(Me.GrpButton)
        Me.Controls.Add(Me.GrpStorageDetails)
        Me.Controls.Add(Me.GrpStorage)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmStorageMaster"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Storage Master"
        Me.GrpButton.ResumeLayout(False)
        Me.GrpStorageDetails.ResumeLayout(False)
        CType(Me.GrdStorageDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpStorage.ResumeLayout(False)
        Me.GrpStorage.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpButton As System.Windows.Forms.GroupBox
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnUpdate As System.Windows.Forms.Button
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents GrpStorageDetails As System.Windows.Forms.GroupBox
    Friend WithEvents GrdStorageDetails As System.Windows.Forms.DataGridView
    Friend WithEvents GrpStorage As System.Windows.Forms.GroupBox
    Friend WithEvents TxtStorage As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtSNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
