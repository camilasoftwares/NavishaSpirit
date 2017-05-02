<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAccountHeads
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAccountHeads))
        Me.GrpAccountHead = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.CmbCrDr = New System.Windows.Forms.ComboBox
        Me.TxtOpeningBalance = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.BtnCancel = New System.Windows.Forms.Button
        Me.BtnUpdate = New System.Windows.Forms.Button
        Me.BtnClose = New System.Windows.Forms.Button
        Me.BtnAdd = New System.Windows.Forms.Button
        Me.TxtHeadCode = New System.Windows.Forms.TextBox
        Me.TxtName = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.CmbGroup = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.TxtSearchValue = New System.Windows.Forms.TextBox
        Me.GrdAccountHead = New System.Windows.Forms.DataGridView
        Me.GrpSearch = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.CmbSearchOption = New System.Windows.Forms.ComboBox
        Me.LblAddGroup = New System.Windows.Forms.Label
        Me.GrpAccountHead.SuspendLayout()
        CType(Me.GrdAccountHead, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpSearch.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpAccountHead
        '
        Me.GrpAccountHead.Controls.Add(Me.LblAddGroup)
        Me.GrpAccountHead.Controls.Add(Me.Label6)
        Me.GrpAccountHead.Controls.Add(Me.CmbCrDr)
        Me.GrpAccountHead.Controls.Add(Me.TxtOpeningBalance)
        Me.GrpAccountHead.Controls.Add(Me.Label5)
        Me.GrpAccountHead.Controls.Add(Me.BtnCancel)
        Me.GrpAccountHead.Controls.Add(Me.BtnUpdate)
        Me.GrpAccountHead.Controls.Add(Me.BtnClose)
        Me.GrpAccountHead.Controls.Add(Me.BtnAdd)
        Me.GrpAccountHead.Controls.Add(Me.TxtHeadCode)
        Me.GrpAccountHead.Controls.Add(Me.TxtName)
        Me.GrpAccountHead.Controls.Add(Me.Label4)
        Me.GrpAccountHead.Controls.Add(Me.CmbGroup)
        Me.GrpAccountHead.Controls.Add(Me.Label1)
        Me.GrpAccountHead.Controls.Add(Me.Label9)
        Me.GrpAccountHead.Location = New System.Drawing.Point(12, 12)
        Me.GrpAccountHead.Name = "GrpAccountHead"
        Me.GrpAccountHead.Size = New System.Drawing.Size(603, 134)
        Me.GrpAccountHead.TabIndex = 81
        Me.GrpAccountHead.TabStop = False
        Me.GrpAccountHead.Text = "Account Head"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(315, 102)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 13)
        Me.Label6.TabIndex = 95
        Me.Label6.Text = "Cr/Dr"
        '
        'CmbCrDr
        '
        Me.CmbCrDr.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbCrDr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbCrDr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCrDr.FormattingEnabled = True
        Me.CmbCrDr.Location = New System.Drawing.Point(354, 98)
        Me.CmbCrDr.Name = "CmbCrDr"
        Me.CmbCrDr.Size = New System.Drawing.Size(68, 21)
        Me.CmbCrDr.TabIndex = 94
        '
        'TxtOpeningBalance
        '
        Me.TxtOpeningBalance.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtOpeningBalance.Location = New System.Drawing.Point(126, 98)
        Me.TxtOpeningBalance.Name = "TxtOpeningBalance"
        Me.TxtOpeningBalance.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtOpeningBalance.Size = New System.Drawing.Size(141, 20)
        Me.TxtOpeningBalance.TabIndex = 93
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 102)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 13)
        Me.Label5.TabIndex = 92
        Me.Label5.Text = "Opening Balance"
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(432, 71)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(80, 26)
        Me.BtnCancel.TabIndex = 91
        Me.BtnCancel.Text = "Cance&l"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnUpdate
        '
        Me.BtnUpdate.Location = New System.Drawing.Point(518, 34)
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Size = New System.Drawing.Size(80, 26)
        Me.BtnUpdate.TabIndex = 90
        Me.BtnUpdate.Text = "&Update"
        Me.BtnUpdate.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(518, 71)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(80, 26)
        Me.BtnClose.TabIndex = 89
        Me.BtnClose.Text = "&Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnAdd
        '
        Me.BtnAdd.Location = New System.Drawing.Point(432, 34)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(80, 26)
        Me.BtnAdd.TabIndex = 88
        Me.BtnAdd.Text = "&Add"
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'TxtHeadCode
        '
        Me.TxtHeadCode.BackColor = System.Drawing.Color.White
        Me.TxtHeadCode.Enabled = False
        Me.TxtHeadCode.Location = New System.Drawing.Point(126, 19)
        Me.TxtHeadCode.Name = "TxtHeadCode"
        Me.TxtHeadCode.ReadOnly = True
        Me.TxtHeadCode.Size = New System.Drawing.Size(92, 20)
        Me.TxtHeadCode.TabIndex = 87
        Me.TxtHeadCode.TabStop = False
        '
        'TxtName
        '
        Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtName.Location = New System.Drawing.Point(126, 45)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(296, 20)
        Me.TxtName.TabIndex = 86
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(114, 13)
        Me.Label4.TabIndex = 85
        Me.Label4.Text = "Account Group Name*"
        '
        'CmbGroup
        '
        Me.CmbGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbGroup.FormattingEnabled = True
        Me.CmbGroup.Location = New System.Drawing.Point(126, 71)
        Me.CmbGroup.Name = "CmbGroup"
        Me.CmbGroup.Size = New System.Drawing.Size(269, 21)
        Me.CmbGroup.TabIndex = 83
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 13)
        Me.Label1.TabIndex = 84
        Me.Label1.Text = "Account Head Name*"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 13)
        Me.Label9.TabIndex = 82
        Me.Label9.Text = "Account Head Code"
        '
        'TxtSearchValue
        '
        Me.TxtSearchValue.Location = New System.Drawing.Point(452, 16)
        Me.TxtSearchValue.Name = "TxtSearchValue"
        Me.TxtSearchValue.Size = New System.Drawing.Size(145, 20)
        Me.TxtSearchValue.TabIndex = 88
        '
        'GrdAccountHead
        '
        Me.GrdAccountHead.AllowUserToAddRows = False
        Me.GrdAccountHead.AllowUserToDeleteRows = False
        Me.GrdAccountHead.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdAccountHead.Location = New System.Drawing.Point(6, 46)
        Me.GrdAccountHead.Name = "GrdAccountHead"
        Me.GrdAccountHead.ReadOnly = True
        Me.GrdAccountHead.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdAccountHead.Size = New System.Drawing.Size(591, 462)
        Me.GrdAccountHead.TabIndex = 83
        '
        'GrpSearch
        '
        Me.GrpSearch.Controls.Add(Me.TxtSearchValue)
        Me.GrpSearch.Controls.Add(Me.GrdAccountHead)
        Me.GrpSearch.Controls.Add(Me.Label2)
        Me.GrpSearch.Controls.Add(Me.Label3)
        Me.GrpSearch.Controls.Add(Me.CmbSearchOption)
        Me.GrpSearch.Location = New System.Drawing.Point(12, 152)
        Me.GrpSearch.Name = "GrpSearch"
        Me.GrpSearch.Size = New System.Drawing.Size(603, 512)
        Me.GrpSearch.TabIndex = 80
        Me.GrpSearch.TabStop = False
        Me.GrpSearch.Text = "Search"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(375, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 82
        Me.Label2.Text = "Search Value"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(122, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 13)
        Me.Label3.TabIndex = 81
        Me.Label3.Text = "Search Option"
        '
        'CmbSearchOption
        '
        Me.CmbSearchOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbSearchOption.FormattingEnabled = True
        Me.CmbSearchOption.Location = New System.Drawing.Point(201, 16)
        Me.CmbSearchOption.Name = "CmbSearchOption"
        Me.CmbSearchOption.Size = New System.Drawing.Size(168, 21)
        Me.CmbSearchOption.TabIndex = 72
        '
        'LblAddGroup
        '
        Me.LblAddGroup.BackColor = System.Drawing.Color.Transparent
        Me.LblAddGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblAddGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblAddGroup.Image = CType(resources.GetObject("LblAddGroup.Image"), System.Drawing.Image)
        Me.LblAddGroup.Location = New System.Drawing.Point(401, 71)
        Me.LblAddGroup.Name = "LblAddGroup"
        Me.LblAddGroup.Size = New System.Drawing.Size(21, 21)
        Me.LblAddGroup.TabIndex = 99
        Me.LblAddGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmAccountHeads
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(629, 676)
        Me.ControlBox = False
        Me.Controls.Add(Me.GrpAccountHead)
        Me.Controls.Add(Me.GrpSearch)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAccountHeads"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Account Heads"
        Me.GrpAccountHead.ResumeLayout(False)
        Me.GrpAccountHead.PerformLayout()
        CType(Me.GrdAccountHead, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpSearch.ResumeLayout(False)
        Me.GrpSearch.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpAccountHead As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CmbCrDr As System.Windows.Forms.ComboBox
    Friend WithEvents TxtOpeningBalance As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnUpdate As System.Windows.Forms.Button
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents TxtHeadCode As System.Windows.Forms.TextBox
    Friend WithEvents TxtName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CmbGroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtSearchValue As System.Windows.Forms.TextBox
    Friend WithEvents GrdAccountHead As System.Windows.Forms.DataGridView
    Friend WithEvents GrpSearch As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CmbSearchOption As System.Windows.Forms.ComboBox
    Friend WithEvents LblAddGroup As System.Windows.Forms.Label
End Class
