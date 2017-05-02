<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPurchaseOrder
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPurchaseOrder))
        Me.Label16 = New System.Windows.Forms.Label
        Me.BtnRemove = New System.Windows.Forms.Button
        Me.BtnAdd = New System.Windows.Forms.Button
        Me.CmbVendor = New System.Windows.Forms.ComboBox
        Me.CmbItem = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.BtnClose = New System.Windows.Forms.Button
        Me.BtnSave = New System.Windows.Forms.Button
        Me.TxtRemark = New System.Windows.Forms.TextBox
        Me.BtnSearch = New System.Windows.Forms.Button
        Me.GrpButtons = New System.Windows.Forms.GroupBox
        Me.BtnPrint = New System.Windows.Forms.Button
        Me.BtnNew = New System.Windows.Forms.Button
        Me.GrpItem = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtOrderPrice = New System.Windows.Forms.TextBox
        Me.LblAddManufacturer = New System.Windows.Forms.Label
        Me.LblAddVendor = New System.Windows.Forms.Label
        Me.LblAddItem = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtPurchaseOrderNo = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtPackType = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtPricePurchasePrevious = New System.Windows.Forms.TextBox
        Me.CmbManufacturer = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.TxtOrderQuantity = New System.Windows.Forms.TextBox
        Me.GrdItems = New System.Windows.Forms.DataGridView
        Me.GrpButtons.SuspendLayout()
        Me.GrpItem.SuspendLayout()
        CType(Me.GrdItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 22)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(49, 13)
        Me.Label16.TabIndex = 46
        Me.Label16.Text = "Remarks"
        '
        'BtnRemove
        '
        Me.BtnRemove.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnRemove.Location = New System.Drawing.Point(725, 71)
        Me.BtnRemove.Name = "BtnRemove"
        Me.BtnRemove.Size = New System.Drawing.Size(73, 26)
        Me.BtnRemove.TabIndex = 62
        Me.BtnRemove.Text = "&Remove"
        Me.BtnRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnRemove.UseVisualStyleBackColor = True
        '
        'BtnAdd
        '
        Me.BtnAdd.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnAdd.Location = New System.Drawing.Point(646, 71)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(73, 26)
        Me.BtnAdd.TabIndex = 61
        Me.BtnAdd.Text = "&Add"
        Me.BtnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'CmbVendor
        '
        Me.CmbVendor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbVendor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbVendor.FormattingEnabled = True
        Me.CmbVendor.Location = New System.Drawing.Point(530, 31)
        Me.CmbVendor.Name = "CmbVendor"
        Me.CmbVendor.Size = New System.Drawing.Size(240, 21)
        Me.CmbVendor.Sorted = True
        Me.CmbVendor.TabIndex = 34
        '
        'CmbItem
        '
        Me.CmbItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CmbItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbItem.FormattingEnabled = True
        Me.CmbItem.Location = New System.Drawing.Point(144, 32)
        Me.CmbItem.Name = "CmbItem"
        Me.CmbItem.Size = New System.Drawing.Size(268, 21)
        Me.CmbItem.Sorted = True
        Me.CmbItem.TabIndex = 33
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(527, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Vendor*"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(141, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Item Name*"
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(724, 15)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(72, 26)
        Me.BtnClose.TabIndex = 61
        Me.BtnClose.Text = "&Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(488, 15)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(72, 26)
        Me.BtnSave.TabIndex = 60
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'TxtRemark
        '
        Me.TxtRemark.Location = New System.Drawing.Point(61, 19)
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(341, 20)
        Me.TxtRemark.TabIndex = 45
        '
        'BtnSearch
        '
        Me.BtnSearch.Location = New System.Drawing.Point(645, 15)
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(72, 26)
        Me.BtnSearch.TabIndex = 64
        Me.BtnSearch.Text = "Searc&h"
        Me.BtnSearch.UseVisualStyleBackColor = True
        '
        'GrpButtons
        '
        Me.GrpButtons.Controls.Add(Me.BtnSearch)
        Me.GrpButtons.Controls.Add(Me.BtnPrint)
        Me.GrpButtons.Controls.Add(Me.BtnNew)
        Me.GrpButtons.Controls.Add(Me.BtnClose)
        Me.GrpButtons.Controls.Add(Me.BtnSave)
        Me.GrpButtons.Controls.Add(Me.TxtRemark)
        Me.GrpButtons.Controls.Add(Me.Label16)
        Me.GrpButtons.Location = New System.Drawing.Point(12, 474)
        Me.GrpButtons.Name = "GrpButtons"
        Me.GrpButtons.Size = New System.Drawing.Size(807, 53)
        Me.GrpButtons.TabIndex = 19
        Me.GrpButtons.TabStop = False
        '
        'BtnPrint
        '
        Me.BtnPrint.Location = New System.Drawing.Point(566, 14)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(72, 26)
        Me.BtnPrint.TabIndex = 63
        Me.BtnPrint.Text = "&Print"
        Me.BtnPrint.UseVisualStyleBackColor = True
        '
        'BtnNew
        '
        Me.BtnNew.Location = New System.Drawing.Point(410, 15)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(72, 26)
        Me.BtnNew.TabIndex = 62
        Me.BtnNew.Text = "&New"
        Me.BtnNew.UseVisualStyleBackColor = True
        '
        'GrpItem
        '
        Me.GrpItem.Controls.Add(Me.Label6)
        Me.GrpItem.Controls.Add(Me.TxtOrderPrice)
        Me.GrpItem.Controls.Add(Me.LblAddManufacturer)
        Me.GrpItem.Controls.Add(Me.LblAddVendor)
        Me.GrpItem.Controls.Add(Me.LblAddItem)
        Me.GrpItem.Controls.Add(Me.Label5)
        Me.GrpItem.Controls.Add(Me.TxtPurchaseOrderNo)
        Me.GrpItem.Controls.Add(Me.Label3)
        Me.GrpItem.Controls.Add(Me.TxtPackType)
        Me.GrpItem.Controls.Add(Me.Label2)
        Me.GrpItem.Controls.Add(Me.TxtPricePurchasePrevious)
        Me.GrpItem.Controls.Add(Me.CmbManufacturer)
        Me.GrpItem.Controls.Add(Me.Label1)
        Me.GrpItem.Controls.Add(Me.Label10)
        Me.GrpItem.Controls.Add(Me.TxtOrderQuantity)
        Me.GrpItem.Controls.Add(Me.BtnRemove)
        Me.GrpItem.Controls.Add(Me.BtnAdd)
        Me.GrpItem.Controls.Add(Me.GrdItems)
        Me.GrpItem.Controls.Add(Me.CmbVendor)
        Me.GrpItem.Controls.Add(Me.CmbItem)
        Me.GrpItem.Controls.Add(Me.Label4)
        Me.GrpItem.Controls.Add(Me.Label7)
        Me.GrpItem.Location = New System.Drawing.Point(11, 12)
        Me.GrpItem.Name = "GrpItem"
        Me.GrpItem.Size = New System.Drawing.Size(808, 456)
        Me.GrpItem.TabIndex = 17
        Me.GrpItem.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(218, 60)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 13)
        Me.Label6.TabIndex = 102
        Me.Label6.Text = "Order Price"
        '
        'TxtOrderPrice
        '
        Me.TxtOrderPrice.BackColor = System.Drawing.Color.White
        Me.TxtOrderPrice.Location = New System.Drawing.Point(216, 77)
        Me.TxtOrderPrice.Name = "TxtOrderPrice"
        Me.TxtOrderPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtOrderPrice.Size = New System.Drawing.Size(77, 20)
        Me.TxtOrderPrice.TabIndex = 103
        '
        'LblAddManufacturer
        '
        Me.LblAddManufacturer.BackColor = System.Drawing.Color.Transparent
        Me.LblAddManufacturer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblAddManufacturer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblAddManufacturer.Image = CType(resources.GetObject("LblAddManufacturer.Image"), System.Drawing.Image)
        Me.LblAddManufacturer.Location = New System.Drawing.Point(609, 75)
        Me.LblAddManufacturer.Name = "LblAddManufacturer"
        Me.LblAddManufacturer.Size = New System.Drawing.Size(21, 21)
        Me.LblAddManufacturer.TabIndex = 101
        Me.LblAddManufacturer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblAddVendor
        '
        Me.LblAddVendor.BackColor = System.Drawing.Color.Transparent
        Me.LblAddVendor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblAddVendor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblAddVendor.Image = CType(resources.GetObject("LblAddVendor.Image"), System.Drawing.Image)
        Me.LblAddVendor.Location = New System.Drawing.Point(776, 32)
        Me.LblAddVendor.Name = "LblAddVendor"
        Me.LblAddVendor.Size = New System.Drawing.Size(21, 21)
        Me.LblAddVendor.TabIndex = 100
        Me.LblAddVendor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblAddItem
        '
        Me.LblAddItem.BackColor = System.Drawing.Color.Transparent
        Me.LblAddItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblAddItem.Image = CType(resources.GetObject("LblAddItem.Image"), System.Drawing.Image)
        Me.LblAddItem.Location = New System.Drawing.Point(418, 33)
        Me.LblAddItem.Name = "LblAddItem"
        Me.LblAddItem.Size = New System.Drawing.Size(21, 21)
        Me.LblAddItem.TabIndex = 99
        Me.LblAddItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 87
        Me.Label5.Text = "Order No."
        '
        'TxtPurchaseOrderNo
        '
        Me.TxtPurchaseOrderNo.BackColor = System.Drawing.Color.White
        Me.TxtPurchaseOrderNo.Enabled = False
        Me.TxtPurchaseOrderNo.Location = New System.Drawing.Point(10, 33)
        Me.TxtPurchaseOrderNo.Name = "TxtPurchaseOrderNo"
        Me.TxtPurchaseOrderNo.ReadOnly = True
        Me.TxtPurchaseOrderNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtPurchaseOrderNo.Size = New System.Drawing.Size(128, 20)
        Me.TxtPurchaseOrderNo.TabIndex = 88
        Me.TxtPurchaseOrderNo.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 85
        Me.Label3.Text = "Pack Type"
        '
        'TxtPackType
        '
        Me.TxtPackType.BackColor = System.Drawing.Color.White
        Me.TxtPackType.Enabled = False
        Me.TxtPackType.Location = New System.Drawing.Point(10, 77)
        Me.TxtPackType.Name = "TxtPackType"
        Me.TxtPackType.ReadOnly = True
        Me.TxtPackType.Size = New System.Drawing.Size(117, 20)
        Me.TxtPackType.TabIndex = 86
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(135, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 83
        Me.Label2.Text = "Prv. Pur. Price"
        '
        'TxtPricePurchasePrevious
        '
        Me.TxtPricePurchasePrevious.BackColor = System.Drawing.Color.White
        Me.TxtPricePurchasePrevious.Enabled = False
        Me.TxtPricePurchasePrevious.Location = New System.Drawing.Point(133, 77)
        Me.TxtPricePurchasePrevious.Name = "TxtPricePurchasePrevious"
        Me.TxtPricePurchasePrevious.ReadOnly = True
        Me.TxtPricePurchasePrevious.Size = New System.Drawing.Size(77, 20)
        Me.TxtPricePurchasePrevious.TabIndex = 84
        '
        'CmbManufacturer
        '
        Me.CmbManufacturer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbManufacturer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbManufacturer.FormattingEnabled = True
        Me.CmbManufacturer.Location = New System.Drawing.Point(299, 75)
        Me.CmbManufacturer.Name = "CmbManufacturer"
        Me.CmbManufacturer.Size = New System.Drawing.Size(304, 21)
        Me.CmbManufacturer.Sorted = True
        Me.CmbManufacturer.TabIndex = 82
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(296, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 81
        Me.Label1.Text = "Manufacturer"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(450, 15)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(55, 13)
        Me.Label10.TabIndex = 79
        Me.Label10.Text = "Order Qty."
        '
        'TxtOrderQuantity
        '
        Me.TxtOrderQuantity.Location = New System.Drawing.Point(448, 32)
        Me.TxtOrderQuantity.Name = "TxtOrderQuantity"
        Me.TxtOrderQuantity.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtOrderQuantity.Size = New System.Drawing.Size(72, 20)
        Me.TxtOrderQuantity.TabIndex = 80
        '
        'GrdItems
        '
        Me.GrdItems.AllowUserToAddRows = False
        Me.GrdItems.AllowUserToDeleteRows = False
        Me.GrdItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdItems.Location = New System.Drawing.Point(10, 103)
        Me.GrdItems.Name = "GrdItems"
        Me.GrdItems.ReadOnly = True
        Me.GrdItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdItems.Size = New System.Drawing.Size(788, 347)
        Me.GrdItems.TabIndex = 48
        '
        'FrmPurchaseOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(835, 545)
        Me.ControlBox = False
        Me.Controls.Add(Me.GrpButtons)
        Me.Controls.Add(Me.GrpItem)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPurchaseOrder"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Purchase Order"
        Me.GrpButtons.ResumeLayout(False)
        Me.GrpButtons.PerformLayout()
        Me.GrpItem.ResumeLayout(False)
        Me.GrpItem.PerformLayout()
        CType(Me.GrdItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents BtnRemove As System.Windows.Forms.Button
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents CmbVendor As System.Windows.Forms.ComboBox
    Friend WithEvents CmbItem As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents TxtRemark As System.Windows.Forms.TextBox
    Friend WithEvents BtnSearch As System.Windows.Forms.Button
    Friend WithEvents GrpButtons As System.Windows.Forms.GroupBox
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents BtnNew As System.Windows.Forms.Button
    Friend WithEvents GrpItem As System.Windows.Forms.GroupBox
    Friend WithEvents GrdItems As System.Windows.Forms.DataGridView
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtOrderQuantity As System.Windows.Forms.TextBox
    Friend WithEvents CmbManufacturer As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtPackType As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtPricePurchasePrevious As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtPurchaseOrderNo As System.Windows.Forms.TextBox
    Friend WithEvents LblAddManufacturer As System.Windows.Forms.Label
    Friend WithEvents LblAddVendor As System.Windows.Forms.Label
    Friend WithEvents LblAddItem As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtOrderPrice As System.Windows.Forms.TextBox
End Class
