<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSpecialityMaster
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
        Me.GrpSpeciality = New System.Windows.Forms.GroupBox
        Me.TxtSpeciality = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtSNo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GrdSpecialityDetails = New System.Windows.Forms.DataGridView
        Me.GrpSpecialityDetails = New System.Windows.Forms.GroupBox
        Me.GrpButton = New System.Windows.Forms.GroupBox
        Me.BtnCancel = New System.Windows.Forms.Button
        Me.BtnUpdate = New System.Windows.Forms.Button
        Me.BtnClose = New System.Windows.Forms.Button
        Me.BtnAdd = New System.Windows.Forms.Button
        Me.GrpSpeciality.SuspendLayout()
        CType(Me.GrdSpecialityDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpSpecialityDetails.SuspendLayout()
        Me.GrpButton.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpSpeciality
        '
        Me.GrpSpeciality.Controls.Add(Me.TxtSpeciality)
        Me.GrpSpeciality.Controls.Add(Me.Label2)
        Me.GrpSpeciality.Controls.Add(Me.TxtSNo)
        Me.GrpSpeciality.Controls.Add(Me.Label1)
        Me.GrpSpeciality.Location = New System.Drawing.Point(12, 12)
        Me.GrpSpeciality.Name = "GrpSpeciality"
        Me.GrpSpeciality.Size = New System.Drawing.Size(417, 49)
        Me.GrpSpeciality.TabIndex = 3
        Me.GrpSpeciality.TabStop = False
        Me.GrpSpeciality.Text = "Speciality"
        '
        'TxtSpeciality
        '
        Me.TxtSpeciality.Location = New System.Drawing.Point(166, 19)
        Me.TxtSpeciality.Name = "TxtSpeciality"
        Me.TxtSpeciality.Size = New System.Drawing.Size(232, 20)
        Me.TxtSpeciality.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(104, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Speciality*"
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
        'GrdSpecialityDetails
        '
        Me.GrdSpecialityDetails.AllowUserToAddRows = False
        Me.GrdSpecialityDetails.AllowUserToDeleteRows = False
        Me.GrdSpecialityDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdSpecialityDetails.Location = New System.Drawing.Point(6, 19)
        Me.GrdSpecialityDetails.Name = "GrdSpecialityDetails"
        Me.GrdSpecialityDetails.ReadOnly = True
        Me.GrdSpecialityDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdSpecialityDetails.Size = New System.Drawing.Size(405, 350)
        Me.GrdSpecialityDetails.TabIndex = 5
        '
        'GrpSpecialityDetails
        '
        Me.GrpSpecialityDetails.Controls.Add(Me.GrdSpecialityDetails)
        Me.GrpSpecialityDetails.Location = New System.Drawing.Point(12, 125)
        Me.GrpSpecialityDetails.Name = "GrpSpecialityDetails"
        Me.GrpSpecialityDetails.Size = New System.Drawing.Size(417, 375)
        Me.GrpSpecialityDetails.TabIndex = 5
        Me.GrpSpecialityDetails.TabStop = False
        Me.GrpSpecialityDetails.Text = "Speciality Details"
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
        Me.GrpButton.TabIndex = 6
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
        'FrmSpecialityMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(443, 512)
        Me.ControlBox = False
        Me.Controls.Add(Me.GrpButton)
        Me.Controls.Add(Me.GrpSpecialityDetails)
        Me.Controls.Add(Me.GrpSpeciality)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSpecialityMaster"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Speciality Master"
        Me.GrpSpeciality.ResumeLayout(False)
        Me.GrpSpeciality.PerformLayout()
        CType(Me.GrdSpecialityDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpSpecialityDetails.ResumeLayout(False)
        Me.GrpButton.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpSpeciality As System.Windows.Forms.GroupBox
    Friend WithEvents TxtSpeciality As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtSNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GrdSpecialityDetails As System.Windows.Forms.DataGridView
    Friend WithEvents GrpSpecialityDetails As System.Windows.Forms.GroupBox
    Friend WithEvents GrpButton As System.Windows.Forms.GroupBox
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnUpdate As System.Windows.Forms.Button
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents BtnAdd As System.Windows.Forms.Button

End Class
