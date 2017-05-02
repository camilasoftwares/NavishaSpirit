<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAccountGroups
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
        Me.GrpSearch = New System.Windows.Forms.GroupBox
        Me.TxtSearchValue = New System.Windows.Forms.TextBox
        Me.GrdAccountGroup = New System.Windows.Forms.DataGridView
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.CmbSearchOption = New System.Windows.Forms.ComboBox
        Me.GrpAccountGroup = New System.Windows.Forms.GroupBox
        Me.BtnCancel = New System.Windows.Forms.Button
        Me.BtnUpdate = New System.Windows.Forms.Button
        Me.BtnClose = New System.Windows.Forms.Button
        Me.BtnAdd = New System.Windows.Forms.Button
        Me.TxtGroupCode = New System.Windows.Forms.TextBox
        Me.TxtName = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.CmbCategory = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.GrpSearch.SuspendLayout()
        CType(Me.GrdAccountGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpAccountGroup.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpSearch
        '
        Me.GrpSearch.Controls.Add(Me.TxtSearchValue)
        Me.GrpSearch.Controls.Add(Me.GrdAccountGroup)
        Me.GrpSearch.Controls.Add(Me.Label2)
        Me.GrpSearch.Controls.Add(Me.Label3)
        Me.GrpSearch.Controls.Add(Me.CmbSearchOption)
        Me.GrpSearch.Location = New System.Drawing.Point(12, 124)
        Me.GrpSearch.Name = "GrpSearch"
        Me.GrpSearch.Size = New System.Drawing.Size(519, 512)
        Me.GrpSearch.TabIndex = 78
        Me.GrpSearch.TabStop = False
        Me.GrpSearch.Text = "Search"
        '
        'TxtSearchValue
        '
        Me.TxtSearchValue.Location = New System.Drawing.Point(366, 16)
        Me.TxtSearchValue.Name = "TxtSearchValue"
        Me.TxtSearchValue.Size = New System.Drawing.Size(145, 20)
        Me.TxtSearchValue.TabIndex = 88
        '
        'GrdAccountGroup
        '
        Me.GrdAccountGroup.AllowUserToAddRows = False
        Me.GrdAccountGroup.AllowUserToDeleteRows = False
        Me.GrdAccountGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdAccountGroup.Location = New System.Drawing.Point(6, 46)
        Me.GrdAccountGroup.Name = "GrdAccountGroup"
        Me.GrdAccountGroup.ReadOnly = True
        Me.GrdAccountGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdAccountGroup.Size = New System.Drawing.Size(505, 462)
        Me.GrdAccountGroup.TabIndex = 83
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(289, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 82
        Me.Label2.Text = "Search Value"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(36, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 13)
        Me.Label3.TabIndex = 81
        Me.Label3.Text = "Search Option"
        '
        'CmbSearchOption
        '
        Me.CmbSearchOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbSearchOption.FormattingEnabled = True
        Me.CmbSearchOption.Location = New System.Drawing.Point(115, 16)
        Me.CmbSearchOption.Name = "CmbSearchOption"
        Me.CmbSearchOption.Size = New System.Drawing.Size(168, 21)
        Me.CmbSearchOption.TabIndex = 72
        '
        'GrpAccountGroup
        '
        Me.GrpAccountGroup.Controls.Add(Me.BtnCancel)
        Me.GrpAccountGroup.Controls.Add(Me.BtnUpdate)
        Me.GrpAccountGroup.Controls.Add(Me.BtnClose)
        Me.GrpAccountGroup.Controls.Add(Me.BtnAdd)
        Me.GrpAccountGroup.Controls.Add(Me.TxtGroupCode)
        Me.GrpAccountGroup.Controls.Add(Me.TxtName)
        Me.GrpAccountGroup.Controls.Add(Me.Label4)
        Me.GrpAccountGroup.Controls.Add(Me.CmbCategory)
        Me.GrpAccountGroup.Controls.Add(Me.Label1)
        Me.GrpAccountGroup.Controls.Add(Me.Label9)
        Me.GrpAccountGroup.Location = New System.Drawing.Point(12, 12)
        Me.GrpAccountGroup.Name = "GrpAccountGroup"
        Me.GrpAccountGroup.Size = New System.Drawing.Size(519, 106)
        Me.GrpAccountGroup.TabIndex = 79
        Me.GrpAccountGroup.TabStop = False
        Me.GrpAccountGroup.Text = "Account Group"
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(340, 66)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(80, 26)
        Me.BtnCancel.TabIndex = 91
        Me.BtnCancel.Text = "Cance&l"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnUpdate
        '
        Me.BtnUpdate.Location = New System.Drawing.Point(426, 34)
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Size = New System.Drawing.Size(80, 26)
        Me.BtnUpdate.TabIndex = 90
        Me.BtnUpdate.Text = "&Update"
        Me.BtnUpdate.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(426, 66)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(80, 26)
        Me.BtnClose.TabIndex = 89
        Me.BtnClose.Text = "&Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnAdd
        '
        Me.BtnAdd.Location = New System.Drawing.Point(340, 34)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(80, 26)
        Me.BtnAdd.TabIndex = 88
        Me.BtnAdd.Text = "&Add"
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'TxtGroupCode
        '
        Me.TxtGroupCode.BackColor = System.Drawing.Color.White
        Me.TxtGroupCode.Enabled = False
        Me.TxtGroupCode.Location = New System.Drawing.Point(88, 19)
        Me.TxtGroupCode.Name = "TxtGroupCode"
        Me.TxtGroupCode.ReadOnly = True
        Me.TxtGroupCode.Size = New System.Drawing.Size(92, 20)
        Me.TxtGroupCode.TabIndex = 87
        Me.TxtGroupCode.TabStop = False
        '
        'TxtName
        '
        Me.TxtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtName.Location = New System.Drawing.Point(88, 45)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(246, 20)
        Me.TxtName.TabIndex = 86
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(24, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 85
        Me.Label4.Text = "Category *"
        '
        'CmbCategory
        '
        Me.CmbCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCategory.FormattingEnabled = True
        Me.CmbCategory.Location = New System.Drawing.Point(88, 71)
        Me.CmbCategory.Name = "CmbCategory"
        Me.CmbCategory.Size = New System.Drawing.Size(246, 21)
        Me.CmbCategory.TabIndex = 83
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 84
        Me.Label1.Text = "Group Name *"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 13)
        Me.Label9.TabIndex = 82
        Me.Label9.Text = "Group Code"
        '
        'FrmAccountGroups
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(547, 648)
        Me.ControlBox = False
        Me.Controls.Add(Me.GrpAccountGroup)
        Me.Controls.Add(Me.GrpSearch)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAccountGroups"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Account Groups"
        Me.GrpSearch.ResumeLayout(False)
        Me.GrpSearch.PerformLayout()
        CType(Me.GrdAccountGroup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpAccountGroup.ResumeLayout(False)
        Me.GrpAccountGroup.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpSearch As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CmbSearchOption As System.Windows.Forms.ComboBox
    Friend WithEvents GrdAccountGroup As System.Windows.Forms.DataGridView
    Friend WithEvents GrpAccountGroup As System.Windows.Forms.GroupBox
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnUpdate As System.Windows.Forms.Button
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents TxtGroupCode As System.Windows.Forms.TextBox
    Friend WithEvents TxtName As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CmbCategory As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtSearchValue As System.Windows.Forms.TextBox
End Class
