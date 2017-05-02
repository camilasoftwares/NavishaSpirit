<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFreeStockTransaction
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
        Me.GrpFreeItemsOnBill = New System.Windows.Forms.GroupBox
        Me.GrdFreeItemsOnBill = New System.Windows.Forms.DataGridView
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtQuantity = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.CmbItem = New System.Windows.Forms.ComboBox
        Me.BtnClose = New System.Windows.Forms.Button
        Me.GrpFreeItem = New System.Windows.Forms.GroupBox
        Me.BtnCancel = New System.Windows.Forms.Button
        Me.BtnUpdate = New System.Windows.Forms.Button
        Me.TxtRemark = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.GrdFreeItems = New System.Windows.Forms.DataGridView
        Me.BtnRemove = New System.Windows.Forms.Button
        Me.BtnAdd = New System.Windows.Forms.Button
        Me.GrpSale = New System.Windows.Forms.GroupBox
        Me.TxtSaleCode = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GrpFreeItemsOnBill.SuspendLayout()
        CType(Me.GrdFreeItemsOnBill, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpFreeItem.SuspendLayout()
        CType(Me.GrdFreeItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpSale.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpFreeItemsOnBill
        '
        Me.GrpFreeItemsOnBill.Controls.Add(Me.GrdFreeItemsOnBill)
        Me.GrpFreeItemsOnBill.Location = New System.Drawing.Point(11, 379)
        Me.GrpFreeItemsOnBill.Name = "GrpFreeItemsOnBill"
        Me.GrpFreeItemsOnBill.Size = New System.Drawing.Size(700, 227)
        Me.GrpFreeItemsOnBill.TabIndex = 2
        Me.GrpFreeItemsOnBill.TabStop = False
        Me.GrpFreeItemsOnBill.Text = "Free Items On Bill"
        '
        'GrdFreeItemsOnBill
        '
        Me.GrdFreeItemsOnBill.AllowUserToAddRows = False
        Me.GrdFreeItemsOnBill.AllowUserToDeleteRows = False
        Me.GrdFreeItemsOnBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdFreeItemsOnBill.Location = New System.Drawing.Point(10, 19)
        Me.GrdFreeItemsOnBill.Name = "GrdFreeItemsOnBill"
        Me.GrdFreeItemsOnBill.ReadOnly = True
        Me.GrdFreeItemsOnBill.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdFreeItemsOnBill.Size = New System.Drawing.Size(679, 196)
        Me.GrdFreeItemsOnBill.TabIndex = 0
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
        'TxtQuantity
        '
        Me.TxtQuantity.Location = New System.Drawing.Point(282, 33)
        Me.TxtQuantity.Name = "TxtQuantity"
        Me.TxtQuantity.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtQuantity.Size = New System.Drawing.Size(62, 20)
        Me.TxtQuantity.TabIndex = 3
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(279, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 13)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Quantity"
        '
        'CmbItem
        '
        Me.CmbItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CmbItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbItem.FormattingEnabled = True
        Me.CmbItem.Location = New System.Drawing.Point(10, 32)
        Me.CmbItem.Name = "CmbItem"
        Me.CmbItem.Size = New System.Drawing.Size(266, 21)
        Me.CmbItem.Sorted = True
        Me.CmbItem.TabIndex = 1
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(617, 59)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(72, 26)
        Me.BtnClose.TabIndex = 10
        Me.BtnClose.Text = "&Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'GrpFreeItem
        '
        Me.GrpFreeItem.Controls.Add(Me.BtnClose)
        Me.GrpFreeItem.Controls.Add(Me.BtnCancel)
        Me.GrpFreeItem.Controls.Add(Me.BtnUpdate)
        Me.GrpFreeItem.Controls.Add(Me.TxtRemark)
        Me.GrpFreeItem.Controls.Add(Me.Label16)
        Me.GrpFreeItem.Controls.Add(Me.GrdFreeItems)
        Me.GrpFreeItem.Controls.Add(Me.BtnRemove)
        Me.GrpFreeItem.Controls.Add(Me.BtnAdd)
        Me.GrpFreeItem.Controls.Add(Me.CmbItem)
        Me.GrpFreeItem.Controls.Add(Me.Label7)
        Me.GrpFreeItem.Controls.Add(Me.TxtQuantity)
        Me.GrpFreeItem.Controls.Add(Me.Label10)
        Me.GrpFreeItem.Location = New System.Drawing.Point(11, 70)
        Me.GrpFreeItem.Name = "GrpFreeItem"
        Me.GrpFreeItem.Size = New System.Drawing.Size(700, 303)
        Me.GrpFreeItem.TabIndex = 1
        Me.GrpFreeItem.TabStop = False
        '
        'BtnCancel
        '
        Me.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnCancel.Location = New System.Drawing.Point(459, 59)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(73, 26)
        Me.BtnCancel.TabIndex = 8
        Me.BtnCancel.Text = "&Cancel"
        Me.BtnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnUpdate
        '
        Me.BtnUpdate.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnUpdate.Location = New System.Drawing.Point(380, 59)
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Size = New System.Drawing.Size(73, 26)
        Me.BtnUpdate.TabIndex = 7
        Me.BtnUpdate.Text = "&Update"
        Me.BtnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnUpdate.UseVisualStyleBackColor = True
        '
        'TxtRemark
        '
        Me.TxtRemark.Location = New System.Drawing.Point(350, 33)
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(339, 20)
        Me.TxtRemark.TabIndex = 5
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(347, 16)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(49, 13)
        Me.Label16.TabIndex = 4
        Me.Label16.Text = "Remarks"
        '
        'GrdFreeItems
        '
        Me.GrdFreeItems.AllowUserToAddRows = False
        Me.GrdFreeItems.AllowUserToDeleteRows = False
        Me.GrdFreeItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdFreeItems.Location = New System.Drawing.Point(10, 91)
        Me.GrdFreeItems.Name = "GrdFreeItems"
        Me.GrdFreeItems.ReadOnly = True
        Me.GrdFreeItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdFreeItems.Size = New System.Drawing.Size(679, 202)
        Me.GrdFreeItems.TabIndex = 11
        '
        'BtnRemove
        '
        Me.BtnRemove.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnRemove.Location = New System.Drawing.Point(538, 59)
        Me.BtnRemove.Name = "BtnRemove"
        Me.BtnRemove.Size = New System.Drawing.Size(73, 26)
        Me.BtnRemove.TabIndex = 9
        Me.BtnRemove.Text = "&Remove"
        Me.BtnRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnRemove.UseVisualStyleBackColor = True
        '
        'BtnAdd
        '
        Me.BtnAdd.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnAdd.Location = New System.Drawing.Point(301, 59)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(73, 26)
        Me.BtnAdd.TabIndex = 6
        Me.BtnAdd.Text = "&Add"
        Me.BtnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'GrpSale
        '
        Me.GrpSale.Controls.Add(Me.TxtSaleCode)
        Me.GrpSale.Controls.Add(Me.Label1)
        Me.GrpSale.Location = New System.Drawing.Point(12, 12)
        Me.GrpSale.Name = "GrpSale"
        Me.GrpSale.Size = New System.Drawing.Size(699, 52)
        Me.GrpSale.TabIndex = 0
        Me.GrpSale.TabStop = False
        '
        'TxtSaleCode
        '
        Me.TxtSaleCode.BackColor = System.Drawing.Color.White
        Me.TxtSaleCode.Enabled = False
        Me.TxtSaleCode.Location = New System.Drawing.Point(68, 19)
        Me.TxtSaleCode.Name = "TxtSaleCode"
        Me.TxtSaleCode.ReadOnly = True
        Me.TxtSaleCode.Size = New System.Drawing.Size(126, 20)
        Me.TxtSaleCode.TabIndex = 1
        Me.TxtSaleCode.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Sale Code"
        '
        'FrmFreeStockTransaction
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(728, 617)
        Me.ControlBox = False
        Me.Controls.Add(Me.GrpFreeItemsOnBill)
        Me.Controls.Add(Me.GrpFreeItem)
        Me.Controls.Add(Me.GrpSale)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmFreeStockTransaction"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Free Items"
        Me.GrpFreeItemsOnBill.ResumeLayout(False)
        CType(Me.GrdFreeItemsOnBill, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpFreeItem.ResumeLayout(False)
        Me.GrpFreeItem.PerformLayout()
        CType(Me.GrdFreeItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpSale.ResumeLayout(False)
        Me.GrpSale.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpFreeItemsOnBill As System.Windows.Forms.GroupBox
    Friend WithEvents GrdFreeItemsOnBill As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CmbItem As System.Windows.Forms.ComboBox
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents GrpFreeItem As System.Windows.Forms.GroupBox
    Friend WithEvents GrdFreeItems As System.Windows.Forms.DataGridView
    Friend WithEvents BtnRemove As System.Windows.Forms.Button
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents GrpSale As System.Windows.Forms.GroupBox
    Friend WithEvents TxtSaleCode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnUpdate As System.Windows.Forms.Button
    Friend WithEvents TxtRemark As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label

End Class
