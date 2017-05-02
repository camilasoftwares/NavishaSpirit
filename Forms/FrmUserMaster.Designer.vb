<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUserMaster
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmUserMaster))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GrpUser = New System.Windows.Forms.GroupBox
        Me.LblAddProfile = New System.Windows.Forms.Label
        Me.ChkIgnorePassword = New System.Windows.Forms.CheckBox
        Me.TrVwMenuList = New System.Windows.Forms.TreeView
        Me.TxtName = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtPasswordReType = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtPassword = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.CmbProfile = New System.Windows.Forms.ComboBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.BtnClose = New System.Windows.Forms.Button
        Me.BtnCancel = New System.Windows.Forms.Button
        Me.BtnUpdate = New System.Windows.Forms.Button
        Me.BtnAdd = New System.Windows.Forms.Button
        Me.TxtLoginId = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GrpUsers = New System.Windows.Forms.GroupBox
        Me.GrdUsers = New System.Windows.Forms.DataGridView
        Me.GrpUser.SuspendLayout()
        Me.GrpUsers.SuspendLayout()
        CType(Me.GrdUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpUser
        '
        Me.GrpUser.Controls.Add(Me.LblAddProfile)
        Me.GrpUser.Controls.Add(Me.ChkIgnorePassword)
        Me.GrpUser.Controls.Add(Me.TrVwMenuList)
        Me.GrpUser.Controls.Add(Me.TxtName)
        Me.GrpUser.Controls.Add(Me.Label4)
        Me.GrpUser.Controls.Add(Me.TxtPasswordReType)
        Me.GrpUser.Controls.Add(Me.Label3)
        Me.GrpUser.Controls.Add(Me.TxtPassword)
        Me.GrpUser.Controls.Add(Me.Label2)
        Me.GrpUser.Controls.Add(Me.CmbProfile)
        Me.GrpUser.Controls.Add(Me.Label18)
        Me.GrpUser.Controls.Add(Me.BtnClose)
        Me.GrpUser.Controls.Add(Me.BtnCancel)
        Me.GrpUser.Controls.Add(Me.BtnUpdate)
        Me.GrpUser.Controls.Add(Me.BtnAdd)
        Me.GrpUser.Controls.Add(Me.TxtLoginId)
        Me.GrpUser.Controls.Add(Me.Label1)
        Me.GrpUser.Location = New System.Drawing.Point(10, 12)
        Me.GrpUser.Name = "GrpUser"
        Me.GrpUser.Size = New System.Drawing.Size(299, 430)
        Me.GrpUser.TabIndex = 8
        Me.GrpUser.TabStop = False
        Me.GrpUser.Text = "User"
        '
        'LblAddProfile
        '
        Me.LblAddProfile.BackColor = System.Drawing.Color.Transparent
        Me.LblAddProfile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblAddProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblAddProfile.Image = CType(resources.GetObject("LblAddProfile.Image"), System.Drawing.Image)
        Me.LblAddProfile.Location = New System.Drawing.Point(257, 96)
        Me.LblAddProfile.Name = "LblAddProfile"
        Me.LblAddProfile.Size = New System.Drawing.Size(18, 21)
        Me.LblAddProfile.TabIndex = 99
        Me.LblAddProfile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ChkIgnorePassword
        '
        Me.ChkIgnorePassword.AutoSize = True
        Me.ChkIgnorePassword.Location = New System.Drawing.Point(111, 150)
        Me.ChkIgnorePassword.Name = "ChkIgnorePassword"
        Me.ChkIgnorePassword.Size = New System.Drawing.Size(164, 17)
        Me.ChkIgnorePassword.TabIndex = 33
        Me.ChkIgnorePassword.Text = "Ignore Password for updation"
        Me.ChkIgnorePassword.UseVisualStyleBackColor = True
        '
        'TrVwMenuList
        '
        Me.TrVwMenuList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TrVwMenuList.Location = New System.Drawing.Point(9, 173)
        Me.TrVwMenuList.Name = "TrVwMenuList"
        Me.TrVwMenuList.Size = New System.Drawing.Size(284, 216)
        Me.TrVwMenuList.TabIndex = 32
        '
        'TxtName
        '
        Me.TxtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtName.Location = New System.Drawing.Point(63, 124)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(212, 20)
        Me.TxtName.TabIndex = 31
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(5, 127)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Name"
        '
        'TxtPasswordReType
        '
        Me.TxtPasswordReType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPasswordReType.Location = New System.Drawing.Point(63, 71)
        Me.TxtPasswordReType.Name = "TxtPasswordReType"
        Me.TxtPasswordReType.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPasswordReType.Size = New System.Drawing.Size(212, 20)
        Me.TxtPasswordReType.TabIndex = 29
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Re-Type*"
        '
        'TxtPassword
        '
        Me.TxtPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPassword.Location = New System.Drawing.Point(63, 45)
        Me.TxtPassword.Name = "TxtPassword"
        Me.TxtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPassword.Size = New System.Drawing.Size(212, 20)
        Me.TxtPassword.TabIndex = 27
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Password*"
        '
        'CmbProfile
        '
        Me.CmbProfile.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbProfile.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbProfile.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbProfile.FormattingEnabled = True
        Me.CmbProfile.Location = New System.Drawing.Point(63, 97)
        Me.CmbProfile.Name = "CmbProfile"
        Me.CmbProfile.Size = New System.Drawing.Size(189, 21)
        Me.CmbProfile.TabIndex = 25
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(5, 100)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(40, 13)
        Me.Label18.TabIndex = 24
        Me.Label18.Text = "Profile*"
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(230, 395)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(63, 26)
        Me.BtnClose.TabIndex = 16
        Me.BtnClose.Text = "&Close"
        Me.BtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(162, 395)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(63, 26)
        Me.BtnCancel.TabIndex = 11
        Me.BtnCancel.Text = "Cance&l"
        Me.BtnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnUpdate
        '
        Me.BtnUpdate.Location = New System.Drawing.Point(94, 395)
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
        Me.BtnAdd.Location = New System.Drawing.Point(26, 395)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(63, 26)
        Me.BtnAdd.TabIndex = 9
        Me.BtnAdd.Text = "&Add"
        Me.BtnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'TxtLoginId
        '
        Me.TxtLoginId.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLoginId.Location = New System.Drawing.Point(63, 19)
        Me.TxtLoginId.Name = "TxtLoginId"
        Me.TxtLoginId.Size = New System.Drawing.Size(212, 20)
        Me.TxtLoginId.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Login Id*"
        '
        'GrpUsers
        '
        Me.GrpUsers.Controls.Add(Me.GrdUsers)
        Me.GrpUsers.Location = New System.Drawing.Point(315, 12)
        Me.GrpUsers.Name = "GrpUsers"
        Me.GrpUsers.Size = New System.Drawing.Size(394, 430)
        Me.GrpUsers.TabIndex = 10
        Me.GrpUsers.TabStop = False
        Me.GrpUsers.Text = "Users"
        '
        'GrdUsers
        '
        Me.GrdUsers.AllowUserToAddRows = False
        Me.GrdUsers.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.GrdUsers.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.GrdUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.GrdUsers.DefaultCellStyle = DataGridViewCellStyle2
        Me.GrdUsers.Location = New System.Drawing.Point(6, 19)
        Me.GrdUsers.Name = "GrdUsers"
        Me.GrdUsers.ReadOnly = True
        Me.GrdUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdUsers.Size = New System.Drawing.Size(381, 402)
        Me.GrdUsers.TabIndex = 10
        '
        'FrmUserMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(717, 457)
        Me.ControlBox = False
        Me.Controls.Add(Me.GrpUsers)
        Me.Controls.Add(Me.GrpUser)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmUserMaster"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "User Master"
        Me.GrpUser.ResumeLayout(False)
        Me.GrpUser.PerformLayout()
        Me.GrpUsers.ResumeLayout(False)
        CType(Me.GrdUsers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpUser As System.Windows.Forms.GroupBox
    Friend WithEvents CmbProfile As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnUpdate As System.Windows.Forms.Button
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents TxtLoginId As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtPasswordReType As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GrpUsers As System.Windows.Forms.GroupBox
    Friend WithEvents GrdUsers As System.Windows.Forms.DataGridView
    Friend WithEvents TrVwMenuList As System.Windows.Forms.TreeView
    Friend WithEvents ChkIgnorePassword As System.Windows.Forms.CheckBox
    Friend WithEvents LblAddProfile As System.Windows.Forms.Label

End Class
