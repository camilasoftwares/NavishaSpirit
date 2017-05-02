<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCategoryMaster
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
        Me.GrpCategoryDetails = New System.Windows.Forms.GroupBox
        Me.GrdCategoryDetails = New System.Windows.Forms.DataGridView
        Me.GrpCategory = New System.Windows.Forms.GroupBox
        Me.TxtCategory = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GrpButton.SuspendLayout()
        Me.GrpCategoryDetails.SuspendLayout()
        CType(Me.GrdCategoryDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpCategory.SuspendLayout()
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
        'GrpCategoryDetails
        '
        Me.GrpCategoryDetails.Controls.Add(Me.GrdCategoryDetails)
        Me.GrpCategoryDetails.Location = New System.Drawing.Point(12, 125)
        Me.GrpCategoryDetails.Name = "GrpCategoryDetails"
        Me.GrpCategoryDetails.Size = New System.Drawing.Size(325, 375)
        Me.GrpCategoryDetails.TabIndex = 14
        Me.GrpCategoryDetails.TabStop = False
        Me.GrpCategoryDetails.Text = "Category Details"
        '
        'GrdCategoryDetails
        '
        Me.GrdCategoryDetails.AllowUserToAddRows = False
        Me.GrdCategoryDetails.AllowUserToDeleteRows = False
        Me.GrdCategoryDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdCategoryDetails.Location = New System.Drawing.Point(6, 19)
        Me.GrdCategoryDetails.Name = "GrdCategoryDetails"
        Me.GrdCategoryDetails.ReadOnly = True
        Me.GrdCategoryDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdCategoryDetails.Size = New System.Drawing.Size(309, 350)
        Me.GrdCategoryDetails.TabIndex = 5
        '
        'GrpCategory
        '
        Me.GrpCategory.Controls.Add(Me.TxtCategory)
        Me.GrpCategory.Controls.Add(Me.Label2)
        Me.GrpCategory.Location = New System.Drawing.Point(12, 12)
        Me.GrpCategory.Name = "GrpCategory"
        Me.GrpCategory.Size = New System.Drawing.Size(325, 49)
        Me.GrpCategory.TabIndex = 13
        Me.GrpCategory.TabStop = False
        Me.GrpCategory.Text = "Category"
        '
        'TxtCategory
        '
        Me.TxtCategory.Location = New System.Drawing.Point(65, 19)
        Me.TxtCategory.Name = "TxtCategory"
        Me.TxtCategory.Size = New System.Drawing.Size(240, 20)
        Me.TxtCategory.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Category*"
        '
        'FrmCategoryMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(352, 511)
        Me.ControlBox = False
        Me.Controls.Add(Me.GrpButton)
        Me.Controls.Add(Me.GrpCategoryDetails)
        Me.Controls.Add(Me.GrpCategory)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCategoryMaster"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Category Master"
        Me.GrpButton.ResumeLayout(False)
        Me.GrpCategoryDetails.ResumeLayout(False)
        CType(Me.GrdCategoryDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpCategory.ResumeLayout(False)
        Me.GrpCategory.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpButton As System.Windows.Forms.GroupBox
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnUpdate As System.Windows.Forms.Button
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents GrpCategoryDetails As System.Windows.Forms.GroupBox
    Friend WithEvents GrdCategoryDetails As System.Windows.Forms.DataGridView
    Friend WithEvents GrpCategory As System.Windows.Forms.GroupBox
    Friend WithEvents TxtCategory As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
