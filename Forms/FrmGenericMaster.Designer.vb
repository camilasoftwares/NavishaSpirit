<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGenericMaster
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
        Me.GrpGenericDetails = New System.Windows.Forms.GroupBox
        Me.GrdGenericDetails = New System.Windows.Forms.DataGridView
        Me.GrpGeneric = New System.Windows.Forms.GroupBox
        Me.CmbStatus = New System.Windows.Forms.ComboBox
        Me.TxtGeneric = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GrpButton.SuspendLayout()
        Me.GrpGenericDetails.SuspendLayout()
        CType(Me.GrdGenericDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpGeneric.SuspendLayout()
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
        Me.GrpButton.TabIndex = 12
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
        'GrpGenericDetails
        '
        Me.GrpGenericDetails.Controls.Add(Me.GrdGenericDetails)
        Me.GrpGenericDetails.Location = New System.Drawing.Point(12, 125)
        Me.GrpGenericDetails.Name = "GrpGenericDetails"
        Me.GrpGenericDetails.Size = New System.Drawing.Size(417, 375)
        Me.GrpGenericDetails.TabIndex = 11
        Me.GrpGenericDetails.TabStop = False
        Me.GrpGenericDetails.Text = "Generic Details"
        '
        'GrdGenericDetails
        '
        Me.GrdGenericDetails.AllowUserToAddRows = False
        Me.GrdGenericDetails.AllowUserToDeleteRows = False
        Me.GrdGenericDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdGenericDetails.Location = New System.Drawing.Point(6, 19)
        Me.GrdGenericDetails.Name = "GrdGenericDetails"
        Me.GrdGenericDetails.ReadOnly = True
        Me.GrdGenericDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdGenericDetails.Size = New System.Drawing.Size(405, 350)
        Me.GrdGenericDetails.TabIndex = 5
        '
        'GrpGeneric
        '
        Me.GrpGeneric.Controls.Add(Me.CmbStatus)
        Me.GrpGeneric.Controls.Add(Me.TxtGeneric)
        Me.GrpGeneric.Controls.Add(Me.Label2)
        Me.GrpGeneric.Controls.Add(Me.Label1)
        Me.GrpGeneric.Location = New System.Drawing.Point(12, 12)
        Me.GrpGeneric.Name = "GrpGeneric"
        Me.GrpGeneric.Size = New System.Drawing.Size(417, 49)
        Me.GrpGeneric.TabIndex = 10
        Me.GrpGeneric.TabStop = False
        Me.GrpGeneric.Text = "Generic"
        '
        'CmbStatus
        '
        Me.CmbStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbStatus.FormattingEnabled = True
        Me.CmbStatus.Location = New System.Drawing.Point(308, 18)
        Me.CmbStatus.Name = "CmbStatus"
        Me.CmbStatus.Size = New System.Drawing.Size(88, 21)
        Me.CmbStatus.Sorted = True
        Me.CmbStatus.TabIndex = 33
        '
        'TxtGeneric
        '
        Me.TxtGeneric.Location = New System.Drawing.Point(60, 19)
        Me.TxtGeneric.Name = "TxtGeneric"
        Me.TxtGeneric.Size = New System.Drawing.Size(199, 20)
        Me.TxtGeneric.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Generic*"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(265, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Status*"
        '
        'FrmGenericMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(442, 512)
        Me.ControlBox = False
        Me.Controls.Add(Me.GrpButton)
        Me.Controls.Add(Me.GrpGenericDetails)
        Me.Controls.Add(Me.GrpGeneric)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmGenericMaster"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Generic Master"
        Me.GrpButton.ResumeLayout(False)
        Me.GrpGenericDetails.ResumeLayout(False)
        CType(Me.GrdGenericDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpGeneric.ResumeLayout(False)
        Me.GrpGeneric.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpButton As System.Windows.Forms.GroupBox
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnUpdate As System.Windows.Forms.Button
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents GrpGenericDetails As System.Windows.Forms.GroupBox
    Friend WithEvents GrdGenericDetails As System.Windows.Forms.DataGridView
    Friend WithEvents GrpGeneric As System.Windows.Forms.GroupBox
    Friend WithEvents TxtGeneric As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmbStatus As System.Windows.Forms.ComboBox

End Class
