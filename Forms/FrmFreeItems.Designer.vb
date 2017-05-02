<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFreeItems
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFreeItems))
        Me.GrpPurchase = New System.Windows.Forms.GroupBox
        Me.TxtPurchaseCode = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GrpItem = New System.Windows.Forms.GroupBox
        Me.BtnCancel = New System.Windows.Forms.Button
        Me.BtnUpdate = New System.Windows.Forms.Button
        Me.LblAddItem = New System.Windows.Forms.Label
        Me.PnlQuantity = New System.Windows.Forms.Panel
        Me.TxtTotalQunatity = New System.Windows.Forms.TextBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.TxtFreeQuantity = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.TxtPackQty = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtRemark = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.TxtPackType = New System.Windows.Forms.TextBox
        Me.BtnRemove = New System.Windows.Forms.Button
        Me.BtnAdd = New System.Windows.Forms.Button
        Me.Label25 = New System.Windows.Forms.Label
        Me.GrdItems = New System.Windows.Forms.DataGridView
        Me.CmbItem = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.GrpButtons = New System.Windows.Forms.GroupBox
        Me.BtnClose = New System.Windows.Forms.Button
        Me.GrpPurchase.SuspendLayout()
        Me.GrpItem.SuspendLayout()
        Me.PnlQuantity.SuspendLayout()
        CType(Me.GrdItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpButtons.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpPurchase
        '
        Me.GrpPurchase.Controls.Add(Me.TxtPurchaseCode)
        Me.GrpPurchase.Controls.Add(Me.Label1)
        Me.GrpPurchase.Location = New System.Drawing.Point(12, 12)
        Me.GrpPurchase.Name = "GrpPurchase"
        Me.GrpPurchase.Size = New System.Drawing.Size(597, 50)
        Me.GrpPurchase.TabIndex = 0
        Me.GrpPurchase.TabStop = False
        '
        'TxtPurchaseCode
        '
        Me.TxtPurchaseCode.BackColor = System.Drawing.Color.White
        Me.TxtPurchaseCode.Enabled = False
        Me.TxtPurchaseCode.Location = New System.Drawing.Point(89, 19)
        Me.TxtPurchaseCode.Name = "TxtPurchaseCode"
        Me.TxtPurchaseCode.ReadOnly = True
        Me.TxtPurchaseCode.Size = New System.Drawing.Size(160, 20)
        Me.TxtPurchaseCode.TabIndex = 1
        Me.TxtPurchaseCode.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Purchase Code"
        '
        'GrpItem
        '
        Me.GrpItem.Controls.Add(Me.BtnCancel)
        Me.GrpItem.Controls.Add(Me.BtnUpdate)
        Me.GrpItem.Controls.Add(Me.LblAddItem)
        Me.GrpItem.Controls.Add(Me.PnlQuantity)
        Me.GrpItem.Controls.Add(Me.TxtRemark)
        Me.GrpItem.Controls.Add(Me.Label16)
        Me.GrpItem.Controls.Add(Me.TxtPackType)
        Me.GrpItem.Controls.Add(Me.BtnRemove)
        Me.GrpItem.Controls.Add(Me.BtnAdd)
        Me.GrpItem.Controls.Add(Me.Label25)
        Me.GrpItem.Controls.Add(Me.GrdItems)
        Me.GrpItem.Controls.Add(Me.CmbItem)
        Me.GrpItem.Controls.Add(Me.Label7)
        Me.GrpItem.Location = New System.Drawing.Point(12, 68)
        Me.GrpItem.Name = "GrpItem"
        Me.GrpItem.Size = New System.Drawing.Size(597, 447)
        Me.GrpItem.TabIndex = 1
        Me.GrpItem.TabStop = False
        '
        'BtnCancel
        '
        Me.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnCancel.Location = New System.Drawing.Point(436, 114)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(73, 26)
        Me.BtnCancel.TabIndex = 12
        Me.BtnCancel.Text = "&Cancel"
        Me.BtnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnUpdate
        '
        Me.BtnUpdate.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnUpdate.Location = New System.Drawing.Point(357, 114)
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Size = New System.Drawing.Size(73, 26)
        Me.BtnUpdate.TabIndex = 11
        Me.BtnUpdate.Text = "&Update"
        Me.BtnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnUpdate.UseVisualStyleBackColor = True
        '
        'LblAddItem
        '
        Me.LblAddItem.BackColor = System.Drawing.Color.Transparent
        Me.LblAddItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblAddItem.Image = CType(resources.GetObject("LblAddItem.Image"), System.Drawing.Image)
        Me.LblAddItem.Location = New System.Drawing.Point(307, 32)
        Me.LblAddItem.Name = "LblAddItem"
        Me.LblAddItem.Size = New System.Drawing.Size(21, 21)
        Me.LblAddItem.TabIndex = 2
        Me.LblAddItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnlQuantity
        '
        Me.PnlQuantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlQuantity.Controls.Add(Me.TxtTotalQunatity)
        Me.PnlQuantity.Controls.Add(Me.Label31)
        Me.PnlQuantity.Controls.Add(Me.Label32)
        Me.PnlQuantity.Controls.Add(Me.TxtFreeQuantity)
        Me.PnlQuantity.Controls.Add(Me.Label24)
        Me.PnlQuantity.Controls.Add(Me.Label28)
        Me.PnlQuantity.Controls.Add(Me.TxtPackQty)
        Me.PnlQuantity.Controls.Add(Me.Label3)
        Me.PnlQuantity.Location = New System.Drawing.Point(12, 59)
        Me.PnlQuantity.Name = "PnlQuantity"
        Me.PnlQuantity.Size = New System.Drawing.Size(190, 81)
        Me.PnlQuantity.TabIndex = 7
        '
        'TxtTotalQunatity
        '
        Me.TxtTotalQunatity.Enabled = False
        Me.TxtTotalQunatity.Location = New System.Drawing.Point(104, 48)
        Me.TxtTotalQunatity.Name = "TxtTotalQunatity"
        Me.TxtTotalQunatity.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtTotalQunatity.Size = New System.Drawing.Size(73, 20)
        Me.TxtTotalQunatity.TabIndex = 5
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(4, 51)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(13, 13)
        Me.Label31.TabIndex = 77
        Me.Label31.Text = "="
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(18, 51)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(73, 13)
        Me.Label32.TabIndex = 4
        Me.Label32.Text = "Total Quantity"
        '
        'TxtFreeQuantity
        '
        Me.TxtFreeQuantity.Location = New System.Drawing.Point(104, 22)
        Me.TxtFreeQuantity.Name = "TxtFreeQuantity"
        Me.TxtFreeQuantity.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtFreeQuantity.Size = New System.Drawing.Size(73, 20)
        Me.TxtFreeQuantity.TabIndex = 3
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(101, 5)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(50, 13)
        Me.Label24.TabIndex = 2
        Me.Label24.Text = "Free Qty."
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
        Me.TxtPackQty.Location = New System.Drawing.Point(6, 22)
        Me.TxtPackQty.Name = "TxtPackQty"
        Me.TxtPackQty.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtPackQty.Size = New System.Drawing.Size(77, 20)
        Me.TxtPackQty.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(86, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(12, 13)
        Me.Label3.TabIndex = 70
        Me.Label3.Text = "x"
        '
        'TxtRemark
        '
        Me.TxtRemark.Location = New System.Drawing.Point(208, 84)
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(380, 20)
        Me.TxtRemark.TabIndex = 9
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(208, 65)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(49, 13)
        Me.Label16.TabIndex = 8
        Me.Label16.Text = "Remarks"
        '
        'TxtPackType
        '
        Me.TxtPackType.BackColor = System.Drawing.Color.White
        Me.TxtPackType.Enabled = False
        Me.TxtPackType.Location = New System.Drawing.Point(336, 33)
        Me.TxtPackType.Name = "TxtPackType"
        Me.TxtPackType.ReadOnly = True
        Me.TxtPackType.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtPackType.Size = New System.Drawing.Size(151, 20)
        Me.TxtPackType.TabIndex = 6
        Me.TxtPackType.TabStop = False
        '
        'BtnRemove
        '
        Me.BtnRemove.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnRemove.Location = New System.Drawing.Point(515, 114)
        Me.BtnRemove.Name = "BtnRemove"
        Me.BtnRemove.Size = New System.Drawing.Size(73, 26)
        Me.BtnRemove.TabIndex = 13
        Me.BtnRemove.Text = "&Remove"
        Me.BtnRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnRemove.UseVisualStyleBackColor = True
        '
        'BtnAdd
        '
        Me.BtnAdd.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnAdd.Location = New System.Drawing.Point(278, 114)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(73, 26)
        Me.BtnAdd.TabIndex = 10
        Me.BtnAdd.Text = "&Add"
        Me.BtnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(333, 16)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(59, 13)
        Me.Label25.TabIndex = 5
        Me.Label25.Text = "Pack Type"
        '
        'GrdItems
        '
        Me.GrdItems.AllowUserToAddRows = False
        Me.GrdItems.AllowUserToDeleteRows = False
        Me.GrdItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdItems.Location = New System.Drawing.Point(10, 146)
        Me.GrdItems.Name = "GrdItems"
        Me.GrdItems.ReadOnly = True
        Me.GrdItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdItems.Size = New System.Drawing.Size(578, 291)
        Me.GrdItems.TabIndex = 14
        '
        'CmbItem
        '
        Me.CmbItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CmbItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbItem.FormattingEnabled = True
        Me.CmbItem.Location = New System.Drawing.Point(10, 32)
        Me.CmbItem.Name = "CmbItem"
        Me.CmbItem.Size = New System.Drawing.Size(291, 21)
        Me.CmbItem.Sorted = True
        Me.CmbItem.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Item Name*"
        '
        'GrpButtons
        '
        Me.GrpButtons.Controls.Add(Me.BtnClose)
        Me.GrpButtons.Location = New System.Drawing.Point(13, 521)
        Me.GrpButtons.Name = "GrpButtons"
        Me.GrpButtons.Size = New System.Drawing.Size(596, 51)
        Me.GrpButtons.TabIndex = 2
        Me.GrpButtons.TabStop = False
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(515, 16)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(72, 26)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "&Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'FrmFreeItems
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(621, 580)
        Me.ControlBox = False
        Me.Controls.Add(Me.GrpButtons)
        Me.Controls.Add(Me.GrpItem)
        Me.Controls.Add(Me.GrpPurchase)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmFreeItems"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Free Items"
        Me.GrpPurchase.ResumeLayout(False)
        Me.GrpPurchase.PerformLayout()
        Me.GrpItem.ResumeLayout(False)
        Me.GrpItem.PerformLayout()
        Me.PnlQuantity.ResumeLayout(False)
        Me.PnlQuantity.PerformLayout()
        CType(Me.GrdItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpButtons.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpPurchase As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPurchaseCode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GrpItem As System.Windows.Forms.GroupBox
    Friend WithEvents LblAddItem As System.Windows.Forms.Label
    Friend WithEvents PnlQuantity As System.Windows.Forms.Panel
    Friend WithEvents TxtTotalQunatity As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents TxtFreeQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents TxtPackQty As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtPackType As System.Windows.Forms.TextBox
    Friend WithEvents BtnRemove As System.Windows.Forms.Button
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents GrdItems As System.Windows.Forms.DataGridView
    Friend WithEvents CmbItem As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GrpButtons As System.Windows.Forms.GroupBox
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents TxtRemark As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnUpdate As System.Windows.Forms.Button

End Class
