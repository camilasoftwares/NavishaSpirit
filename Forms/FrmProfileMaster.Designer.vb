<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmProfileMaster
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GrpProfiles = New System.Windows.Forms.GroupBox
        Me.GrdProfiles = New System.Windows.Forms.DataGridView
        Me.GrpProfile = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TrVwMenuList = New System.Windows.Forms.TreeView
        Me.TxtName = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.BtnClose = New System.Windows.Forms.Button
        Me.BtnCancel = New System.Windows.Forms.Button
        Me.BtnUpdate = New System.Windows.Forms.Button
        Me.BtnAdd = New System.Windows.Forms.Button
        Me.GrpProfiles.SuspendLayout()
        CType(Me.GrdProfiles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpProfile.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpProfiles
        '
        Me.GrpProfiles.Controls.Add(Me.GrdProfiles)
        Me.GrpProfiles.Location = New System.Drawing.Point(297, 12)
        Me.GrpProfiles.Name = "GrpProfiles"
        Me.GrpProfiles.Size = New System.Drawing.Size(217, 324)
        Me.GrpProfiles.TabIndex = 12
        Me.GrpProfiles.TabStop = False
        Me.GrpProfiles.Text = "Profiles"
        '
        'GrdProfiles
        '
        Me.GrdProfiles.AllowUserToAddRows = False
        Me.GrdProfiles.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GrdProfiles.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.GrdProfiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GrdProfiles.DefaultCellStyle = DataGridViewCellStyle2
        Me.GrdProfiles.Location = New System.Drawing.Point(5, 19)
        Me.GrdProfiles.Name = "GrdProfiles"
        Me.GrdProfiles.ReadOnly = True
        Me.GrdProfiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdProfiles.Size = New System.Drawing.Size(205, 297)
        Me.GrdProfiles.TabIndex = 10
        '
        'GrpProfile
        '
        Me.GrpProfile.Controls.Add(Me.Label1)
        Me.GrpProfile.Controls.Add(Me.TrVwMenuList)
        Me.GrpProfile.Controls.Add(Me.TxtName)
        Me.GrpProfile.Controls.Add(Me.Label4)
        Me.GrpProfile.Controls.Add(Me.BtnClose)
        Me.GrpProfile.Controls.Add(Me.BtnCancel)
        Me.GrpProfile.Controls.Add(Me.BtnUpdate)
        Me.GrpProfile.Controls.Add(Me.BtnAdd)
        Me.GrpProfile.Location = New System.Drawing.Point(10, 12)
        Me.GrpProfile.Name = "GrpProfile"
        Me.GrpProfile.Size = New System.Drawing.Size(281, 324)
        Me.GrpProfile.TabIndex = 11
        Me.GrpProfile.TabStop = False
        Me.GrpProfile.Text = "Profile"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Default Access:"
        '
        'TrVwMenuList
        '
        Me.TrVwMenuList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TrVwMenuList.Location = New System.Drawing.Point(98, 45)
        Me.TrVwMenuList.Name = "TrVwMenuList"
        Me.TrVwMenuList.Size = New System.Drawing.Size(176, 239)
        Me.TrVwMenuList.TabIndex = 32
        '
        'TxtName
        '
        Me.TxtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtName.Location = New System.Drawing.Point(98, 19)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(176, 20)
        Me.TxtName.TabIndex = 31
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(5, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 13)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Profile Name"
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(211, 290)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(63, 26)
        Me.BtnClose.TabIndex = 16
        Me.BtnClose.Text = "&Close"
        Me.BtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(143, 290)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(63, 26)
        Me.BtnCancel.TabIndex = 11
        Me.BtnCancel.Text = "Cance&l"
        Me.BtnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnUpdate
        '
        Me.BtnUpdate.Location = New System.Drawing.Point(75, 290)
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Size = New System.Drawing.Size(63, 26)
        Me.BtnUpdate.TabIndex = 10
        Me.BtnUpdate.Text = "&Update"
        Me.BtnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnUpdate.UseVisualStyleBackColor = True
        '
        'BtnAdd
        '
        Me.BtnAdd.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnAdd.Location = New System.Drawing.Point(8, 290)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(63, 26)
        Me.BtnAdd.TabIndex = 9
        Me.BtnAdd.Text = "&Add"
        Me.BtnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'FrmProfileMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(522, 346)
        Me.ControlBox = False
        Me.Controls.Add(Me.GrpProfiles)
        Me.Controls.Add(Me.GrpProfile)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmProfileMaster"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Profile Master"
        Me.GrpProfiles.ResumeLayout(False)
        CType(Me.GrdProfiles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpProfile.ResumeLayout(False)
        Me.GrpProfile.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpProfiles As System.Windows.Forms.GroupBox
    Friend WithEvents GrdProfiles As System.Windows.Forms.DataGridView
    Friend WithEvents GrpProfile As System.Windows.Forms.GroupBox
    Friend WithEvents TrVwMenuList As System.Windows.Forms.TreeView
    Friend WithEvents TxtName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnUpdate As System.Windows.Forms.Button
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
