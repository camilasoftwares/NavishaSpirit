<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmItemMaster
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmItemMaster))
        Me.GrpItem = New System.Windows.Forms.GroupBox
        Me.LblAddCategory = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.CmbCategory = New System.Windows.Forms.ComboBox
        Me.LblAddStorage = New System.Windows.Forms.Label
        Me.LblAddManufacturer = New System.Windows.Forms.Label
        Me.LblAddGeneric = New System.Windows.Forms.Label
        Me.LblAddSchedule = New System.Windows.Forms.Label
        Me.BtnCancel = New System.Windows.Forms.Button
        Me.BtnUpdate = New System.Windows.Forms.Button
        Me.BtnClose = New System.Windows.Forms.Button
        Me.BtnAdd = New System.Windows.Forms.Button
        Me.TxtMin = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.CmbStorage = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.CmbManufacturer = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.CmbGeneric3 = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.CmbGeneric2 = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.CmbGeneric1 = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.CmbSchedule = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.CmbPackType = New System.Windows.Forms.ComboBox
        Me.TxtVATRate = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtItemCode = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.TxtName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GrpItems = New System.Windows.Forms.GroupBox
        Me.GrdItems = New System.Windows.Forms.DataGridView
        Me.GrpSearch = New System.Windows.Forms.GroupBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.CmbFieldToSearch = New System.Windows.Forms.ComboBox
        Me.TxtLikeValue = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.GrpItem.SuspendLayout()
        Me.GrpItems.SuspendLayout()
        CType(Me.GrdItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpSearch.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpItem
        '
        Me.GrpItem.Controls.Add(Me.LblAddCategory)
        Me.GrpItem.Controls.Add(Me.Label10)
        Me.GrpItem.Controls.Add(Me.CmbCategory)
        Me.GrpItem.Controls.Add(Me.LblAddStorage)
        Me.GrpItem.Controls.Add(Me.LblAddManufacturer)
        Me.GrpItem.Controls.Add(Me.LblAddGeneric)
        Me.GrpItem.Controls.Add(Me.LblAddSchedule)
        Me.GrpItem.Controls.Add(Me.BtnCancel)
        Me.GrpItem.Controls.Add(Me.BtnUpdate)
        Me.GrpItem.Controls.Add(Me.BtnClose)
        Me.GrpItem.Controls.Add(Me.BtnAdd)
        Me.GrpItem.Controls.Add(Me.TxtMin)
        Me.GrpItem.Controls.Add(Me.Label11)
        Me.GrpItem.Controls.Add(Me.Label7)
        Me.GrpItem.Controls.Add(Me.CmbStorage)
        Me.GrpItem.Controls.Add(Me.Label9)
        Me.GrpItem.Controls.Add(Me.CmbManufacturer)
        Me.GrpItem.Controls.Add(Me.Label6)
        Me.GrpItem.Controls.Add(Me.CmbGeneric3)
        Me.GrpItem.Controls.Add(Me.Label5)
        Me.GrpItem.Controls.Add(Me.CmbGeneric2)
        Me.GrpItem.Controls.Add(Me.Label4)
        Me.GrpItem.Controls.Add(Me.CmbGeneric1)
        Me.GrpItem.Controls.Add(Me.Label3)
        Me.GrpItem.Controls.Add(Me.CmbSchedule)
        Me.GrpItem.Controls.Add(Me.Label12)
        Me.GrpItem.Controls.Add(Me.CmbPackType)
        Me.GrpItem.Controls.Add(Me.TxtVATRate)
        Me.GrpItem.Controls.Add(Me.Label2)
        Me.GrpItem.Controls.Add(Me.TxtItemCode)
        Me.GrpItem.Controls.Add(Me.Label14)
        Me.GrpItem.Controls.Add(Me.TxtName)
        Me.GrpItem.Controls.Add(Me.Label1)
        Me.GrpItem.Location = New System.Drawing.Point(12, 12)
        Me.GrpItem.Name = "GrpItem"
        Me.GrpItem.Size = New System.Drawing.Size(854, 112)
        Me.GrpItem.TabIndex = 7
        Me.GrpItem.TabStop = False
        Me.GrpItem.Text = "Item"
        '
        'LblAddCategory
        '
        Me.LblAddCategory.BackColor = System.Drawing.Color.Transparent
        Me.LblAddCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblAddCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblAddCategory.Image = CType(resources.GetObject("LblAddCategory.Image"), System.Drawing.Image)
        Me.LblAddCategory.Location = New System.Drawing.Point(691, 18)
        Me.LblAddCategory.Name = "LblAddCategory"
        Me.LblAddCategory.Size = New System.Drawing.Size(21, 21)
        Me.LblAddCategory.TabIndex = 105
        Me.LblAddCategory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(528, 21)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 13)
        Me.Label10.TabIndex = 104
        Me.Label10.Text = "Category*"
        '
        'CmbCategory
        '
        Me.CmbCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CmbCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCategory.FormattingEnabled = True
        Me.CmbCategory.Location = New System.Drawing.Point(587, 18)
        Me.CmbCategory.Name = "CmbCategory"
        Me.CmbCategory.Size = New System.Drawing.Size(98, 21)
        Me.CmbCategory.Sorted = True
        Me.CmbCategory.TabIndex = 103
        '
        'LblAddStorage
        '
        Me.LblAddStorage.BackColor = System.Drawing.Color.Transparent
        Me.LblAddStorage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblAddStorage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblAddStorage.Image = CType(resources.GetObject("LblAddStorage.Image"), System.Drawing.Image)
        Me.LblAddStorage.Location = New System.Drawing.Point(641, 45)
        Me.LblAddStorage.Name = "LblAddStorage"
        Me.LblAddStorage.Size = New System.Drawing.Size(21, 21)
        Me.LblAddStorage.TabIndex = 102
        Me.LblAddStorage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblAddManufacturer
        '
        Me.LblAddManufacturer.BackColor = System.Drawing.Color.Transparent
        Me.LblAddManufacturer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblAddManufacturer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblAddManufacturer.Image = CType(resources.GetObject("LblAddManufacturer.Image"), System.Drawing.Image)
        Me.LblAddManufacturer.Location = New System.Drawing.Point(424, 45)
        Me.LblAddManufacturer.Name = "LblAddManufacturer"
        Me.LblAddManufacturer.Size = New System.Drawing.Size(21, 21)
        Me.LblAddManufacturer.TabIndex = 101
        Me.LblAddManufacturer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblAddGeneric
        '
        Me.LblAddGeneric.BackColor = System.Drawing.Color.Transparent
        Me.LblAddGeneric.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblAddGeneric.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblAddGeneric.Image = CType(resources.GetObject("LblAddGeneric.Image"), System.Drawing.Image)
        Me.LblAddGeneric.Location = New System.Drawing.Point(0, 0)
        Me.LblAddGeneric.Name = "LblAddGeneric"
        Me.LblAddGeneric.Size = New System.Drawing.Size(21, 21)
        Me.LblAddGeneric.TabIndex = 100
        Me.LblAddGeneric.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LblAddGeneric.Visible = False
        '
        'LblAddSchedule
        '
        Me.LblAddSchedule.BackColor = System.Drawing.Color.Transparent
        Me.LblAddSchedule.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblAddSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblAddSchedule.Image = CType(resources.GetObject("LblAddSchedule.Image"), System.Drawing.Image)
        Me.LblAddSchedule.Location = New System.Drawing.Point(0, 0)
        Me.LblAddSchedule.Name = "LblAddSchedule"
        Me.LblAddSchedule.Size = New System.Drawing.Size(21, 21)
        Me.LblAddSchedule.TabIndex = 99
        Me.LblAddSchedule.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LblAddSchedule.Visible = False
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(698, 78)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(72, 26)
        Me.BtnCancel.TabIndex = 59
        Me.BtnCancel.Text = "Cance&l"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnUpdate
        '
        Me.BtnUpdate.Location = New System.Drawing.Point(620, 78)
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Size = New System.Drawing.Size(72, 26)
        Me.BtnUpdate.TabIndex = 58
        Me.BtnUpdate.Text = "&Update"
        Me.BtnUpdate.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(776, 78)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(72, 26)
        Me.BtnClose.TabIndex = 57
        Me.BtnClose.Text = "&Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnAdd
        '
        Me.BtnAdd.Location = New System.Drawing.Point(542, 78)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(72, 26)
        Me.BtnAdd.TabIndex = 56
        Me.BtnAdd.Text = "&Add"
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'TxtMin
        '
        Me.TxtMin.Location = New System.Drawing.Point(776, 48)
        Me.TxtMin.Name = "TxtMin"
        Me.TxtMin.Size = New System.Drawing.Size(61, 20)
        Me.TxtMin.TabIndex = 55
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(670, 51)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 13)
        Me.Label11.TabIndex = 54
        Me.Label11.Text = "Low Stock Quantity"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(464, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 13)
        Me.Label7.TabIndex = 51
        Me.Label7.Text = "Storage"
        '
        'CmbStorage
        '
        Me.CmbStorage.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CmbStorage.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbStorage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbStorage.FormattingEnabled = True
        Me.CmbStorage.Location = New System.Drawing.Point(514, 45)
        Me.CmbStorage.Name = "CmbStorage"
        Me.CmbStorage.Size = New System.Drawing.Size(121, 21)
        Me.CmbStorage.Sorted = True
        Me.CmbStorage.TabIndex = 50
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(194, 48)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 13)
        Me.Label9.TabIndex = 47
        Me.Label9.Text = "Manufacturer"
        '
        'CmbManufacturer
        '
        Me.CmbManufacturer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CmbManufacturer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbManufacturer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbManufacturer.FormattingEnabled = True
        Me.CmbManufacturer.Location = New System.Drawing.Point(274, 45)
        Me.CmbManufacturer.Name = "CmbManufacturer"
        Me.CmbManufacturer.Size = New System.Drawing.Size(144, 21)
        Me.CmbManufacturer.Sorted = True
        Me.CmbManufacturer.TabIndex = 46
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(0, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 45
        Me.Label6.Text = "Generic 3"
        Me.Label6.Visible = False
        '
        'CmbGeneric3
        '
        Me.CmbGeneric3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CmbGeneric3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbGeneric3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbGeneric3.FormattingEnabled = True
        Me.CmbGeneric3.Location = New System.Drawing.Point(0, 0)
        Me.CmbGeneric3.Name = "CmbGeneric3"
        Me.CmbGeneric3.Size = New System.Drawing.Size(113, 21)
        Me.CmbGeneric3.Sorted = True
        Me.CmbGeneric3.TabIndex = 44
        Me.CmbGeneric3.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(0, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 43
        Me.Label5.Text = "Generic 2"
        Me.Label5.Visible = False
        '
        'CmbGeneric2
        '
        Me.CmbGeneric2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CmbGeneric2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbGeneric2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbGeneric2.FormattingEnabled = True
        Me.CmbGeneric2.Location = New System.Drawing.Point(0, 0)
        Me.CmbGeneric2.Name = "CmbGeneric2"
        Me.CmbGeneric2.Size = New System.Drawing.Size(110, 21)
        Me.CmbGeneric2.Sorted = True
        Me.CmbGeneric2.TabIndex = 42
        Me.CmbGeneric2.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "Generic 1"
        Me.Label4.Visible = False
        '
        'CmbGeneric1
        '
        Me.CmbGeneric1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CmbGeneric1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbGeneric1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbGeneric1.FormattingEnabled = True
        Me.CmbGeneric1.Location = New System.Drawing.Point(0, 0)
        Me.CmbGeneric1.Name = "CmbGeneric1"
        Me.CmbGeneric1.Size = New System.Drawing.Size(121, 21)
        Me.CmbGeneric1.Sorted = True
        Me.CmbGeneric1.TabIndex = 40
        Me.CmbGeneric1.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "Schedule"
        Me.Label3.Visible = False
        '
        'CmbSchedule
        '
        Me.CmbSchedule.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CmbSchedule.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbSchedule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbSchedule.FormattingEnabled = True
        Me.CmbSchedule.Location = New System.Drawing.Point(0, 0)
        Me.CmbSchedule.Name = "CmbSchedule"
        Me.CmbSchedule.Size = New System.Drawing.Size(144, 21)
        Me.CmbSchedule.Sorted = True
        Me.CmbSchedule.TabIndex = 38
        Me.CmbSchedule.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 48)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(63, 13)
        Me.Label12.TabIndex = 37
        Me.Label12.Text = "Pack Type*"
        '
        'CmbPackType
        '
        Me.CmbPackType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CmbPackType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbPackType.FormattingEnabled = True
        Me.CmbPackType.Location = New System.Drawing.Point(75, 45)
        Me.CmbPackType.Name = "CmbPackType"
        Me.CmbPackType.Size = New System.Drawing.Size(113, 21)
        Me.CmbPackType.Sorted = True
        Me.CmbPackType.TabIndex = 36
        '
        'TxtVATRate
        '
        Me.TxtVATRate.Location = New System.Drawing.Point(792, 19)
        Me.TxtVATRate.Name = "TxtVATRate"
        Me.TxtVATRate.Size = New System.Drawing.Size(45, 20)
        Me.TxtVATRate.TabIndex = 29
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(718, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "VAT Rate(%)"
        '
        'TxtItemCode
        '
        Me.TxtItemCode.BackColor = System.Drawing.Color.White
        Me.TxtItemCode.Enabled = False
        Me.TxtItemCode.Location = New System.Drawing.Point(75, 19)
        Me.TxtItemCode.Name = "TxtItemCode"
        Me.TxtItemCode.ReadOnly = True
        Me.TxtItemCode.Size = New System.Drawing.Size(113, 20)
        Me.TxtItemCode.TabIndex = 27
        Me.TxtItemCode.TabStop = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 22)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(55, 13)
        Me.Label14.TabIndex = 26
        Me.Label14.Text = "Item Code"
        '
        'TxtName
        '
        Me.TxtName.Location = New System.Drawing.Point(274, 19)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(248, 20)
        Me.TxtName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(202, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Item Name*"
        '
        'GrpItems
        '
        Me.GrpItems.Controls.Add(Me.GrdItems)
        Me.GrpItems.Location = New System.Drawing.Point(12, 186)
        Me.GrpItems.Name = "GrpItems"
        Me.GrpItems.Size = New System.Drawing.Size(854, 344)
        Me.GrpItems.TabIndex = 12
        Me.GrpItems.TabStop = False
        Me.GrpItems.Text = "Items"
        '
        'GrdItems
        '
        Me.GrdItems.AllowUserToAddRows = False
        Me.GrdItems.AllowUserToDeleteRows = False
        Me.GrdItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdItems.Location = New System.Drawing.Point(7, 19)
        Me.GrdItems.Name = "GrdItems"
        Me.GrdItems.ReadOnly = True
        Me.GrdItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdItems.Size = New System.Drawing.Size(841, 319)
        Me.GrdItems.TabIndex = 5
        '
        'GrpSearch
        '
        Me.GrpSearch.Controls.Add(Me.Label13)
        Me.GrpSearch.Controls.Add(Me.CmbFieldToSearch)
        Me.GrpSearch.Controls.Add(Me.TxtLikeValue)
        Me.GrpSearch.Controls.Add(Me.Label15)
        Me.GrpSearch.Location = New System.Drawing.Point(12, 130)
        Me.GrpSearch.Name = "GrpSearch"
        Me.GrpSearch.Size = New System.Drawing.Size(854, 50)
        Me.GrpSearch.TabIndex = 11
        Me.GrpSearch.TabStop = False
        Me.GrpSearch.Text = "Search By"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(499, 22)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 13)
        Me.Label13.TabIndex = 33
        Me.Label13.Text = "Search In"
        '
        'CmbFieldToSearch
        '
        Me.CmbFieldToSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbFieldToSearch.FormattingEnabled = True
        Me.CmbFieldToSearch.Location = New System.Drawing.Point(558, 19)
        Me.CmbFieldToSearch.Name = "CmbFieldToSearch"
        Me.CmbFieldToSearch.Size = New System.Drawing.Size(121, 21)
        Me.CmbFieldToSearch.Sorted = True
        Me.CmbFieldToSearch.TabIndex = 32
        '
        'TxtLikeValue
        '
        Me.TxtLikeValue.Location = New System.Drawing.Point(760, 19)
        Me.TxtLikeValue.Name = "TxtLikeValue"
        Me.TxtLikeValue.Size = New System.Drawing.Size(88, 20)
        Me.TxtLikeValue.TabIndex = 31
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(685, 22)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(69, 13)
        Me.Label15.TabIndex = 30
        Me.Label15.Text = "Starting From"
        '
        'FrmItemMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(882, 542)
        Me.ControlBox = False
        Me.Controls.Add(Me.GrpItems)
        Me.Controls.Add(Me.GrpSearch)
        Me.Controls.Add(Me.GrpItem)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmItemMaster"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Item Master"
        Me.GrpItem.ResumeLayout(False)
        Me.GrpItem.PerformLayout()
        Me.GrpItems.ResumeLayout(False)
        CType(Me.GrdItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpSearch.ResumeLayout(False)
        Me.GrpSearch.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpItem As System.Windows.Forms.GroupBox
    Friend WithEvents TxtItemCode As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TxtName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtVATRate As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CmbPackType As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CmbSchedule As System.Windows.Forms.ComboBox
    Friend WithEvents TxtMin As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CmbStorage As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents CmbManufacturer As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CmbGeneric3 As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CmbGeneric2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CmbGeneric1 As System.Windows.Forms.ComboBox
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnUpdate As System.Windows.Forms.Button
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents GrpItems As System.Windows.Forms.GroupBox
    Friend WithEvents GrdItems As System.Windows.Forms.DataGridView
    Friend WithEvents GrpSearch As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents CmbFieldToSearch As System.Windows.Forms.ComboBox
    Friend WithEvents TxtLikeValue As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents LblAddGeneric As System.Windows.Forms.Label
    Friend WithEvents LblAddSchedule As System.Windows.Forms.Label
    Friend WithEvents LblAddStorage As System.Windows.Forms.Label
    Friend WithEvents LblAddManufacturer As System.Windows.Forms.Label
    Friend WithEvents LblAddCategory As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CmbCategory As System.Windows.Forms.ComboBox

End Class
