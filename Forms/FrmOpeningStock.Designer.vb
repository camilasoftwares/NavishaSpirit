<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOpeningStock
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmOpeningStock))
        Me.CmbItem = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GrpItem = New System.Windows.Forms.GroupBox()
        Me.BtnDelete = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.TxtPTD = New System.Windows.Forms.TextBox()
        Me.TxtRate2 = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TxtRate1 = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.TxtPTS = New System.Windows.Forms.TextBox()
        Me.TxtPTR = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TxtMRP = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CmbCategory = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.LblAddItem = New System.Windows.Forms.Label()
        Me.PnlQuantity = New System.Windows.Forms.Panel()
        Me.TxtFreeQuantity = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtPurchaseQuantity = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.TxtPackQty = New System.Windows.Forms.TextBox()
        Me.TxtPurchasePrice = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.CmbStorage = New System.Windows.Forms.ComboBox()
        Me.BtnUpdate = New System.Windows.Forms.Button()
        Me.BtnAdd = New System.Windows.Forms.Button()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.GrpGrid = New System.Windows.Forms.GroupBox()
        Me.GrdItems = New System.Windows.Forms.DataGridView()
        Me.GrpItem.SuspendLayout()
        Me.PnlQuantity.SuspendLayout()
        Me.GrpGrid.SuspendLayout()
        CType(Me.GrdItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CmbItem
        '
        Me.CmbItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CmbItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbItem.FormattingEnabled = True
        Me.CmbItem.Location = New System.Drawing.Point(131, 32)
        Me.CmbItem.Name = "CmbItem"
        Me.CmbItem.Size = New System.Drawing.Size(301, 21)
        Me.CmbItem.Sorted = True
        Me.CmbItem.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(128, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Item Name*"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(488, 71)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(28, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "PTS"
        Me.Label8.Visible = False
        '
        'GrpItem
        '
        Me.GrpItem.Controls.Add(Me.BtnDelete)
        Me.GrpItem.Controls.Add(Me.BtnCancel)
        Me.GrpItem.Controls.Add(Me.BtnClose)
        Me.GrpItem.Controls.Add(Me.TxtPTD)
        Me.GrpItem.Controls.Add(Me.TxtRate2)
        Me.GrpItem.Controls.Add(Me.Label21)
        Me.GrpItem.Controls.Add(Me.TxtRate1)
        Me.GrpItem.Controls.Add(Me.Label24)
        Me.GrpItem.Controls.Add(Me.Label25)
        Me.GrpItem.Controls.Add(Me.TxtPTS)
        Me.GrpItem.Controls.Add(Me.TxtPTR)
        Me.GrpItem.Controls.Add(Me.Label13)
        Me.GrpItem.Controls.Add(Me.TxtMRP)
        Me.GrpItem.Controls.Add(Me.Label3)
        Me.GrpItem.Controls.Add(Me.CmbCategory)
        Me.GrpItem.Controls.Add(Me.Label14)
        Me.GrpItem.Controls.Add(Me.Label12)
        Me.GrpItem.Controls.Add(Me.LblAddItem)
        Me.GrpItem.Controls.Add(Me.PnlQuantity)
        Me.GrpItem.Controls.Add(Me.CmbStorage)
        Me.GrpItem.Controls.Add(Me.BtnUpdate)
        Me.GrpItem.Controls.Add(Me.BtnAdd)
        Me.GrpItem.Controls.Add(Me.Label26)
        Me.GrpItem.Controls.Add(Me.CmbItem)
        Me.GrpItem.Controls.Add(Me.Label7)
        Me.GrpItem.Controls.Add(Me.Label8)
        Me.GrpItem.Location = New System.Drawing.Point(9, 12)
        Me.GrpItem.Name = "GrpItem"
        Me.GrpItem.Size = New System.Drawing.Size(884, 166)
        Me.GrpItem.TabIndex = 0
        Me.GrpItem.TabStop = False
        '
        'BtnDelete
        '
        Me.BtnDelete.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnDelete.Location = New System.Drawing.Point(438, 129)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(73, 26)
        Me.BtnDelete.TabIndex = 14
        Me.BtnDelete.Text = "&Delete"
        Me.BtnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnDelete.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnCancel.Location = New System.Drawing.Point(517, 129)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(72, 26)
        Me.BtnCancel.TabIndex = 15
        Me.BtnCancel.Text = "Cance&l"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(595, 129)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(72, 26)
        Me.BtnClose.TabIndex = 16
        Me.BtnClose.Text = "&Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'TxtPTD
        '
        Me.TxtPTD.Location = New System.Drawing.Point(518, 88)
        Me.TxtPTD.Name = "TxtPTD"
        Me.TxtPTD.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtPTD.Size = New System.Drawing.Size(59, 20)
        Me.TxtPTD.TabIndex = 8
        Me.TxtPTD.Visible = False
        '
        'TxtRate2
        '
        Me.TxtRate2.Location = New System.Drawing.Point(401, 87)
        Me.TxtRate2.Name = "TxtRate2"
        Me.TxtRate2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtRate2.Size = New System.Drawing.Size(60, 20)
        Me.TxtRate2.TabIndex = 11
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(401, 69)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(36, 13)
        Me.Label21.TabIndex = 24
        Me.Label21.Text = "Rate2"
        '
        'TxtRate1
        '
        Me.TxtRate1.Location = New System.Drawing.Point(336, 87)
        Me.TxtRate1.Name = "TxtRate1"
        Me.TxtRate1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtRate1.Size = New System.Drawing.Size(59, 20)
        Me.TxtRate1.TabIndex = 10
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(333, 70)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(36, 13)
        Me.Label24.TabIndex = 22
        Me.Label24.Text = "Rate1"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(521, 71)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(29, 13)
        Me.Label25.TabIndex = 18
        Me.Label25.Text = "PTD"
        Me.Label25.Visible = False
        '
        'TxtPTS
        '
        Me.TxtPTS.Location = New System.Drawing.Point(491, 88)
        Me.TxtPTS.Name = "TxtPTS"
        Me.TxtPTS.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtPTS.Size = New System.Drawing.Size(59, 20)
        Me.TxtPTS.TabIndex = 7
        Me.TxtPTS.Visible = False
        '
        'TxtPTR
        '
        Me.TxtPTR.Location = New System.Drawing.Point(544, 88)
        Me.TxtPTR.Name = "TxtPTR"
        Me.TxtPTR.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtPTR.Size = New System.Drawing.Size(59, 20)
        Me.TxtPTR.TabIndex = 9
        Me.TxtPTR.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(548, 72)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(29, 13)
        Me.Label13.TabIndex = 20
        Me.Label13.Text = "PTR"
        Me.Label13.Visible = False
        '
        'TxtMRP
        '
        Me.TxtMRP.Location = New System.Drawing.Point(271, 87)
        Me.TxtMRP.Name = "TxtMRP"
        Me.TxtMRP.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtMRP.Size = New System.Drawing.Size(59, 20)
        Me.TxtMRP.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(268, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "MRP"
        '
        'CmbCategory
        '
        Me.CmbCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbCategory.FormattingEnabled = True
        Me.CmbCategory.Location = New System.Drawing.Point(17, 32)
        Me.CmbCategory.Name = "CmbCategory"
        Me.CmbCategory.Size = New System.Drawing.Size(108, 21)
        Me.CmbCategory.Sorted = True
        Me.CmbCategory.TabIndex = 0
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(14, 16)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(49, 13)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Category"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.AliceBlue
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Red
        Me.Label12.Location = New System.Drawing.Point(467, 81)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(34, 26)
        Me.Label12.TabIndex = 27
        Me.Label12.Text = "(Per " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Unit)"
        '
        'LblAddItem
        '
        Me.LblAddItem.BackColor = System.Drawing.Color.Transparent
        Me.LblAddItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblAddItem.Image = CType(resources.GetObject("LblAddItem.Image"), System.Drawing.Image)
        Me.LblAddItem.Location = New System.Drawing.Point(438, 32)
        Me.LblAddItem.Name = "LblAddItem"
        Me.LblAddItem.Size = New System.Drawing.Size(21, 21)
        Me.LblAddItem.TabIndex = 2
        Me.LblAddItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnlQuantity
        '
        Me.PnlQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlQuantity.Controls.Add(Me.TxtFreeQuantity)
        Me.PnlQuantity.Controls.Add(Me.Label33)
        Me.PnlQuantity.Controls.Add(Me.Label11)
        Me.PnlQuantity.Controls.Add(Me.Label10)
        Me.PnlQuantity.Controls.Add(Me.TxtPurchaseQuantity)
        Me.PnlQuantity.Controls.Add(Me.Label28)
        Me.PnlQuantity.Controls.Add(Me.TxtPackQty)
        Me.PnlQuantity.Controls.Add(Me.TxtPurchasePrice)
        Me.PnlQuantity.Controls.Add(Me.Label23)
        Me.PnlQuantity.Location = New System.Drawing.Point(17, 64)
        Me.PnlQuantity.Name = "PnlQuantity"
        Me.PnlQuantity.Size = New System.Drawing.Size(248, 49)
        Me.PnlQuantity.TabIndex = 5
        '
        'TxtFreeQuantity
        '
        Me.TxtFreeQuantity.Location = New System.Drawing.Point(136, 22)
        Me.TxtFreeQuantity.Name = "TxtFreeQuantity"
        Me.TxtFreeQuantity.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtFreeQuantity.Size = New System.Drawing.Size(59, 20)
        Me.TxtFreeQuantity.TabIndex = 3
        Me.TxtFreeQuantity.Text = "0"
        Me.TxtFreeQuantity.Visible = False
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(122, 25)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(50, 13)
        Me.Label33.TabIndex = 7
        Me.Label33.Text = "Free Qty."
        Me.Label33.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 26)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(24, 13)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "1 x "
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(87, 5)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 13)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Pur. Qty."
        '
        'TxtPurchaseQuantity
        '
        Me.TxtPurchaseQuantity.Location = New System.Drawing.Point(85, 22)
        Me.TxtPurchaseQuantity.Name = "TxtPurchaseQuantity"
        Me.TxtPurchaseQuantity.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtPurchaseQuantity.Size = New System.Drawing.Size(61, 20)
        Me.TxtPurchaseQuantity.TabIndex = 1
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(6, 5)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(55, 13)
        Me.Label28.TabIndex = 0
        Me.Label28.Text = "Pack Size"
        '
        'TxtPackQty
        '
        Me.TxtPackQty.Enabled = False
        Me.TxtPackQty.Location = New System.Drawing.Point(32, 22)
        Me.TxtPackQty.Name = "TxtPackQty"
        Me.TxtPackQty.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtPackQty.Size = New System.Drawing.Size(47, 20)
        Me.TxtPackQty.TabIndex = 0
        Me.TxtPackQty.Text = "1"
        '
        'TxtPurchasePrice
        '
        Me.TxtPurchasePrice.Location = New System.Drawing.Point(152, 22)
        Me.TxtPurchasePrice.Name = "TxtPurchasePrice"
        Me.TxtPurchasePrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtPurchasePrice.Size = New System.Drawing.Size(87, 20)
        Me.TxtPurchasePrice.TabIndex = 2
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(149, 6)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(77, 13)
        Me.Label23.TabIndex = 5
        Me.Label23.Text = "Pur. Price/Qty."
        '
        'CmbStorage
        '
        Me.CmbStorage.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CmbStorage.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbStorage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbStorage.FormattingEnabled = True
        Me.CmbStorage.Location = New System.Drawing.Point(468, 33)
        Me.CmbStorage.Name = "CmbStorage"
        Me.CmbStorage.Size = New System.Drawing.Size(199, 21)
        Me.CmbStorage.Sorted = True
        Me.CmbStorage.TabIndex = 4
        '
        'BtnUpdate
        '
        Me.BtnUpdate.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnUpdate.Location = New System.Drawing.Point(359, 129)
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Size = New System.Drawing.Size(73, 26)
        Me.BtnUpdate.TabIndex = 13
        Me.BtnUpdate.Text = "&Update"
        Me.BtnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnUpdate.UseVisualStyleBackColor = True
        '
        'BtnAdd
        '
        Me.BtnAdd.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnAdd.Location = New System.Drawing.Point(280, 129)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(73, 26)
        Me.BtnAdd.TabIndex = 12
        Me.BtnAdd.Text = "&Add"
        Me.BtnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(465, 16)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(44, 13)
        Me.Label26.TabIndex = 7
        Me.Label26.Text = "Storage"
        '
        'GrpGrid
        '
        Me.GrpGrid.Controls.Add(Me.GrdItems)
        Me.GrpGrid.Location = New System.Drawing.Point(11, 184)
        Me.GrpGrid.Name = "GrpGrid"
        Me.GrpGrid.Size = New System.Drawing.Size(882, 355)
        Me.GrpGrid.TabIndex = 1
        Me.GrpGrid.TabStop = False
        '
        'GrdItems
        '
        Me.GrdItems.AllowUserToAddRows = False
        Me.GrdItems.AllowUserToDeleteRows = False
        Me.GrdItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdItems.Location = New System.Drawing.Point(15, 18)
        Me.GrdItems.Name = "GrdItems"
        Me.GrdItems.ReadOnly = True
        Me.GrdItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdItems.Size = New System.Drawing.Size(851, 331)
        Me.GrdItems.TabIndex = 0
        '
        'FrmOpeningStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(913, 551)
        Me.ControlBox = False
        Me.Controls.Add(Me.GrpGrid)
        Me.Controls.Add(Me.GrpItem)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmOpeningStock"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Opening Stock"
        Me.GrpItem.ResumeLayout(False)
        Me.GrpItem.PerformLayout()
        Me.PnlQuantity.ResumeLayout(False)
        Me.PnlQuantity.PerformLayout()
        Me.GrpGrid.ResumeLayout(False)
        CType(Me.GrdItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CmbItem As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GrpItem As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPurchaseQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TxtPurchasePrice As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents TxtPackQty As System.Windows.Forms.TextBox
    Friend WithEvents BtnUpdate As System.Windows.Forms.Button
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents CmbStorage As System.Windows.Forms.ComboBox
    Friend WithEvents PnlQuantity As System.Windows.Forms.Panel
    Friend WithEvents LblAddItem As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CmbCategory As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TxtPTR As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtMRP As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtPTS As System.Windows.Forms.TextBox
    Friend WithEvents TxtPTD As System.Windows.Forms.TextBox
    Friend WithEvents TxtRate2 As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents TxtRate1 As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents TxtFreeQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnDelete As System.Windows.Forms.Button
    Friend WithEvents GrpGrid As System.Windows.Forms.GroupBox
    Friend WithEvents GrdItems As System.Windows.Forms.DataGridView
End Class
