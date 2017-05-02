<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLegalTerms
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
        Me.GrpTerm = New System.Windows.Forms.GroupBox
        Me.BtnClose = New System.Windows.Forms.Button
        Me.BtnCancel = New System.Windows.Forms.Button
        Me.BtnDelete = New System.Windows.Forms.Button
        Me.BtnUpdate = New System.Windows.Forms.Button
        Me.BtnAdd = New System.Windows.Forms.Button
        Me.TxtTerm = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GrpTerms = New System.Windows.Forms.GroupBox
        Me.GrdTerms = New System.Windows.Forms.DataGridView
        Me.GrpTerm.SuspendLayout()
        Me.GrpTerms.SuspendLayout()
        CType(Me.GrdTerms, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpTerm
        '
        Me.GrpTerm.Controls.Add(Me.BtnClose)
        Me.GrpTerm.Controls.Add(Me.BtnCancel)
        Me.GrpTerm.Controls.Add(Me.BtnDelete)
        Me.GrpTerm.Controls.Add(Me.BtnUpdate)
        Me.GrpTerm.Controls.Add(Me.BtnAdd)
        Me.GrpTerm.Controls.Add(Me.TxtTerm)
        Me.GrpTerm.Controls.Add(Me.Label1)
        Me.GrpTerm.Location = New System.Drawing.Point(12, 12)
        Me.GrpTerm.Name = "GrpTerm"
        Me.GrpTerm.Size = New System.Drawing.Size(614, 80)
        Me.GrpTerm.TabIndex = 0
        Me.GrpTerm.TabStop = False
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(519, 45)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(89, 27)
        Me.BtnClose.TabIndex = 6
        Me.BtnClose.Text = "&Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(424, 45)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(89, 27)
        Me.BtnCancel.TabIndex = 5
        Me.BtnCancel.Text = "Cance&l"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnDelete
        '
        Me.BtnDelete.Location = New System.Drawing.Point(329, 45)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(89, 27)
        Me.BtnDelete.TabIndex = 4
        Me.BtnDelete.Text = "&Delete"
        Me.BtnDelete.UseVisualStyleBackColor = True
        '
        'BtnUpdate
        '
        Me.BtnUpdate.Location = New System.Drawing.Point(234, 45)
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Size = New System.Drawing.Size(89, 27)
        Me.BtnUpdate.TabIndex = 3
        Me.BtnUpdate.Text = "&Update"
        Me.BtnUpdate.UseVisualStyleBackColor = True
        '
        'BtnAdd
        '
        Me.BtnAdd.Location = New System.Drawing.Point(139, 45)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(89, 27)
        Me.BtnAdd.TabIndex = 2
        Me.BtnAdd.Text = "&Add"
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'TxtTerm
        '
        Me.TxtTerm.Location = New System.Drawing.Point(43, 19)
        Me.TxtTerm.Name = "TxtTerm"
        Me.TxtTerm.Size = New System.Drawing.Size(565, 20)
        Me.TxtTerm.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Term"
        '
        'GrpTerms
        '
        Me.GrpTerms.Controls.Add(Me.GrdTerms)
        Me.GrpTerms.Location = New System.Drawing.Point(12, 98)
        Me.GrpTerms.Name = "GrpTerms"
        Me.GrpTerms.Size = New System.Drawing.Size(614, 394)
        Me.GrpTerms.TabIndex = 1
        Me.GrpTerms.TabStop = False
        Me.GrpTerms.Text = "Terms"
        '
        'GrdTerms
        '
        Me.GrdTerms.AllowUserToAddRows = False
        Me.GrdTerms.AllowUserToDeleteRows = False
        Me.GrdTerms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdTerms.Location = New System.Drawing.Point(9, 19)
        Me.GrdTerms.Name = "GrdTerms"
        Me.GrdTerms.ReadOnly = True
        Me.GrdTerms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdTerms.Size = New System.Drawing.Size(599, 369)
        Me.GrdTerms.TabIndex = 6
        '
        'FrmLegalTerms
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(637, 504)
        Me.ControlBox = False
        Me.Controls.Add(Me.GrpTerms)
        Me.Controls.Add(Me.GrpTerm)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmLegalTerms"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Legal Terms for Report"
        Me.GrpTerm.ResumeLayout(False)
        Me.GrpTerm.PerformLayout()
        Me.GrpTerms.ResumeLayout(False)
        CType(Me.GrdTerms, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpTerm As System.Windows.Forms.GroupBox
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnDelete As System.Windows.Forms.Button
    Friend WithEvents BtnUpdate As System.Windows.Forms.Button
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents TxtTerm As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GrpTerms As System.Windows.Forms.GroupBox
    Friend WithEvents GrdTerms As System.Windows.Forms.DataGridView

End Class
