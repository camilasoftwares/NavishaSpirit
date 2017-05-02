<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmExpiry
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
        Me.GrdItems = New System.Windows.Forms.DataGridView
        Me.GrpItem = New System.Windows.Forms.GroupBox
        Me.BtnReloadItems = New System.Windows.Forms.Button
        Me.DtPkrItemsExpiryDate = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtRemark = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.BtnAdd = New System.Windows.Forms.Button
        Me.CmbItem = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtQuantity = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.GrpButtons = New System.Windows.Forms.GroupBox
        Me.BtnRemove = New System.Windows.Forms.Button
        Me.BtnUpdate = New System.Windows.Forms.Button
        Me.BtnClose = New System.Windows.Forms.Button
        Me.BtnCancel = New System.Windows.Forms.Button
        Me.GrdItemsOnSlip = New System.Windows.Forms.DataGridView
        Me.GrpItemsOnSlip = New System.Windows.Forms.GroupBox
        CType(Me.GrdItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpItem.SuspendLayout()
        Me.GrpButtons.SuspendLayout()
        CType(Me.GrdItemsOnSlip, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpItemsOnSlip.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrdItems
        '
        Me.GrdItems.AllowUserToAddRows = False
        Me.GrdItems.AllowUserToDeleteRows = False
        Me.GrdItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdItems.Location = New System.Drawing.Point(10, 76)
        Me.GrdItems.Name = "GrdItems"
        Me.GrdItems.ReadOnly = True
        Me.GrdItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdItems.Size = New System.Drawing.Size(1041, 202)
        Me.GrdItems.TabIndex = 48
        '
        'GrpItem
        '
        Me.GrpItem.Controls.Add(Me.BtnReloadItems)
        Me.GrpItem.Controls.Add(Me.DtPkrItemsExpiryDate)
        Me.GrpItem.Controls.Add(Me.Label1)
        Me.GrpItem.Controls.Add(Me.TxtRemark)
        Me.GrpItem.Controls.Add(Me.Label16)
        Me.GrpItem.Controls.Add(Me.GrdItems)
        Me.GrpItem.Controls.Add(Me.BtnAdd)
        Me.GrpItem.Controls.Add(Me.CmbItem)
        Me.GrpItem.Controls.Add(Me.Label7)
        Me.GrpItem.Controls.Add(Me.TxtQuantity)
        Me.GrpItem.Controls.Add(Me.Label10)
        Me.GrpItem.Location = New System.Drawing.Point(11, 12)
        Me.GrpItem.Name = "GrpItem"
        Me.GrpItem.Size = New System.Drawing.Size(1057, 289)
        Me.GrpItem.TabIndex = 17
        Me.GrpItem.TabStop = False
        '
        'BtnReloadItems
        '
        Me.BtnReloadItems.Location = New System.Drawing.Point(222, 16)
        Me.BtnReloadItems.Name = "BtnReloadItems"
        Me.BtnReloadItems.Size = New System.Drawing.Size(92, 26)
        Me.BtnReloadItems.TabIndex = 53
        Me.BtnReloadItems.Text = "Reloa&d Items"
        Me.BtnReloadItems.UseVisualStyleBackColor = True
        '
        'DtPkrItemsExpiryDate
        '
        Me.DtPkrItemsExpiryDate.CustomFormat = "MMM-yyyy"
        Me.DtPkrItemsExpiryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtPkrItemsExpiryDate.Location = New System.Drawing.Point(132, 19)
        Me.DtPkrItemsExpiryDate.Name = "DtPkrItemsExpiryDate"
        Me.DtPkrItemsExpiryDate.Size = New System.Drawing.Size(84, 20)
        Me.DtPkrItemsExpiryDate.TabIndex = 52
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 13)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = "Items expired on/before"
        '
        'TxtRemark
        '
        Me.TxtRemark.Location = New System.Drawing.Point(588, 48)
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(377, 20)
        Me.TxtRemark.TabIndex = 49
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(533, 51)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(49, 13)
        Me.Label16.TabIndex = 50
        Me.Label16.Text = "Remarks"
        '
        'BtnAdd
        '
        Me.BtnAdd.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnAdd.Location = New System.Drawing.Point(971, 45)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(73, 26)
        Me.BtnAdd.TabIndex = 46
        Me.BtnAdd.Text = "&Add"
        Me.BtnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'CmbItem
        '
        Me.CmbItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CmbItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbItem.FormattingEnabled = True
        Me.CmbItem.Location = New System.Drawing.Point(75, 48)
        Me.CmbItem.Name = "CmbItem"
        Me.CmbItem.Size = New System.Drawing.Size(332, 21)
        Me.CmbItem.Sorted = True
        Me.CmbItem.TabIndex = 33
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 52)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Item Name*"
        '
        'TxtQuantity
        '
        Me.TxtQuantity.Location = New System.Drawing.Point(465, 49)
        Me.TxtQuantity.Name = "TxtQuantity"
        Me.TxtQuantity.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtQuantity.Size = New System.Drawing.Size(62, 20)
        Me.TxtQuantity.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(413, 51)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Quantity"
        '
        'GrpButtons
        '
        Me.GrpButtons.Controls.Add(Me.BtnRemove)
        Me.GrpButtons.Controls.Add(Me.BtnUpdate)
        Me.GrpButtons.Controls.Add(Me.BtnClose)
        Me.GrpButtons.Controls.Add(Me.BtnCancel)
        Me.GrpButtons.Location = New System.Drawing.Point(11, 612)
        Me.GrpButtons.Name = "GrpButtons"
        Me.GrpButtons.Size = New System.Drawing.Size(1058, 51)
        Me.GrpButtons.TabIndex = 19
        Me.GrpButtons.TabStop = False
        '
        'BtnRemove
        '
        Me.BtnRemove.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnRemove.Location = New System.Drawing.Point(736, 16)
        Me.BtnRemove.Name = "BtnRemove"
        Me.BtnRemove.Size = New System.Drawing.Size(72, 26)
        Me.BtnRemove.TabIndex = 63
        Me.BtnRemove.Text = "&Remove"
        Me.BtnRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnRemove.UseVisualStyleBackColor = True
        '
        'BtnUpdate
        '
        Me.BtnUpdate.Location = New System.Drawing.Point(815, 16)
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Size = New System.Drawing.Size(72, 26)
        Me.BtnUpdate.TabIndex = 62
        Me.BtnUpdate.Text = "&Update"
        Me.BtnUpdate.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(972, 16)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(72, 26)
        Me.BtnClose.TabIndex = 61
        Me.BtnClose.Text = "&Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(893, 16)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(72, 26)
        Me.BtnCancel.TabIndex = 60
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'GrdItemsOnSlip
        '
        Me.GrdItemsOnSlip.AllowUserToAddRows = False
        Me.GrdItemsOnSlip.AllowUserToDeleteRows = False
        Me.GrdItemsOnSlip.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdItemsOnSlip.Location = New System.Drawing.Point(10, 19)
        Me.GrdItemsOnSlip.Name = "GrdItemsOnSlip"
        Me.GrdItemsOnSlip.ReadOnly = True
        Me.GrdItemsOnSlip.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdItemsOnSlip.Size = New System.Drawing.Size(1041, 274)
        Me.GrdItemsOnSlip.TabIndex = 48
        '
        'GrpItemsOnSlip
        '
        Me.GrpItemsOnSlip.Controls.Add(Me.GrdItemsOnSlip)
        Me.GrpItemsOnSlip.Location = New System.Drawing.Point(11, 307)
        Me.GrpItemsOnSlip.Name = "GrpItemsOnSlip"
        Me.GrpItemsOnSlip.Size = New System.Drawing.Size(1057, 299)
        Me.GrpItemsOnSlip.TabIndex = 18
        Me.GrpItemsOnSlip.TabStop = False
        Me.GrpItemsOnSlip.Text = "Items Expired Details"
        '
        'FrmExpiry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(1082, 679)
        Me.ControlBox = False
        Me.Controls.Add(Me.GrpItem)
        Me.Controls.Add(Me.GrpButtons)
        Me.Controls.Add(Me.GrpItemsOnSlip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmExpiry"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Expiry"
        CType(Me.GrdItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpItem.ResumeLayout(False)
        Me.GrpItem.PerformLayout()
        Me.GrpButtons.ResumeLayout(False)
        CType(Me.GrdItemsOnSlip, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpItemsOnSlip.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrdItems As System.Windows.Forms.DataGridView
    Friend WithEvents GrpItem As System.Windows.Forms.GroupBox
    Friend WithEvents TxtRemark As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents CmbItem As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GrpButtons As System.Windows.Forms.GroupBox
    Friend WithEvents BtnRemove As System.Windows.Forms.Button
    Friend WithEvents BtnUpdate As System.Windows.Forms.Button
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents GrdItemsOnSlip As System.Windows.Forms.DataGridView
    Friend WithEvents GrpItemsOnSlip As System.Windows.Forms.GroupBox
    Friend WithEvents DtPkrItemsExpiryDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnReloadItems As System.Windows.Forms.Button

End Class
