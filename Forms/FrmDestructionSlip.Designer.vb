<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDestructionSlip
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
        Me.BtnSearch = New System.Windows.Forms.Button
        Me.GrpItemsOnSlip = New System.Windows.Forms.GroupBox
        Me.GrdItemsOnSlip = New System.Windows.Forms.DataGridView
        Me.TxtNetAmount = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.BtnPrint = New System.Windows.Forms.Button
        Me.TxtQuantity = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.CmbItem = New System.Windows.Forms.ComboBox
        Me.BtnNew = New System.Windows.Forms.Button
        Me.TxtRemark = New System.Windows.Forms.TextBox
        Me.BtnSave = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.BtnClose = New System.Windows.Forms.Button
        Me.GrpItem = New System.Windows.Forms.GroupBox
        Me.GrdItems = New System.Windows.Forms.DataGridView
        Me.BtnRemove = New System.Windows.Forms.Button
        Me.BtnAdd = New System.Windows.Forms.Button
        Me.GrpButtons = New System.Windows.Forms.GroupBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.DtPkrDestructionSlipDate = New System.Windows.Forms.DateTimePicker
        Me.GrpDestructionSlip = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtDestructionSlipCode = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GrpItemsOnSlip.SuspendLayout()
        CType(Me.GrdItemsOnSlip, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpItem.SuspendLayout()
        CType(Me.GrdItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpButtons.SuspendLayout()
        Me.GrpDestructionSlip.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnSearch
        '
        Me.BtnSearch.Location = New System.Drawing.Point(734, 16)
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(72, 26)
        Me.BtnSearch.TabIndex = 64
        Me.BtnSearch.Text = "Searc&h"
        Me.BtnSearch.UseVisualStyleBackColor = True
        '
        'GrpItemsOnSlip
        '
        Me.GrpItemsOnSlip.Controls.Add(Me.GrdItemsOnSlip)
        Me.GrpItemsOnSlip.Controls.Add(Me.TxtNetAmount)
        Me.GrpItemsOnSlip.Controls.Add(Me.Label19)
        Me.GrpItemsOnSlip.Location = New System.Drawing.Point(10, 345)
        Me.GrpItemsOnSlip.Name = "GrpItemsOnSlip"
        Me.GrpItemsOnSlip.Size = New System.Drawing.Size(894, 261)
        Me.GrpItemsOnSlip.TabIndex = 14
        Me.GrpItemsOnSlip.TabStop = False
        Me.GrpItemsOnSlip.Text = "Items On Destruction Slip"
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
        Me.GrdItemsOnSlip.Size = New System.Drawing.Size(877, 196)
        Me.GrdItemsOnSlip.TabIndex = 48
        '
        'TxtNetAmount
        '
        Me.TxtNetAmount.BackColor = System.Drawing.Color.White
        Me.TxtNetAmount.Enabled = False
        Me.TxtNetAmount.Location = New System.Drawing.Point(737, 231)
        Me.TxtNetAmount.Name = "TxtNetAmount"
        Me.TxtNetAmount.ReadOnly = True
        Me.TxtNetAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtNetAmount.Size = New System.Drawing.Size(140, 20)
        Me.TxtNetAmount.TabIndex = 1
        Me.TxtNetAmount.TabStop = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(668, 234)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(63, 13)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "Net Amount"
        '
        'BtnPrint
        '
        Me.BtnPrint.Location = New System.Drawing.Point(655, 15)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(72, 26)
        Me.BtnPrint.TabIndex = 63
        Me.BtnPrint.Text = "&Print"
        Me.BtnPrint.UseVisualStyleBackColor = True
        '
        'TxtQuantity
        '
        Me.TxtQuantity.Location = New System.Drawing.Point(362, 33)
        Me.TxtQuantity.Name = "TxtQuantity"
        Me.TxtQuantity.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtQuantity.Size = New System.Drawing.Size(62, 20)
        Me.TxtQuantity.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(359, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Quantity"
        '
        'CmbItem
        '
        Me.CmbItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CmbItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbItem.FormattingEnabled = True
        Me.CmbItem.Location = New System.Drawing.Point(10, 32)
        Me.CmbItem.Name = "CmbItem"
        Me.CmbItem.Size = New System.Drawing.Size(337, 21)
        Me.CmbItem.Sorted = True
        Me.CmbItem.TabIndex = 33
        '
        'BtnNew
        '
        Me.BtnNew.Location = New System.Drawing.Point(499, 16)
        Me.BtnNew.Name = "BtnNew"
        Me.BtnNew.Size = New System.Drawing.Size(72, 26)
        Me.BtnNew.TabIndex = 62
        Me.BtnNew.Text = "&New"
        Me.BtnNew.UseVisualStyleBackColor = True
        '
        'TxtRemark
        '
        Me.TxtRemark.Location = New System.Drawing.Point(61, 19)
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(422, 20)
        Me.TxtRemark.TabIndex = 45
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(577, 16)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(72, 26)
        Me.BtnSave.TabIndex = 60
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(7, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Item Name*"
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(813, 16)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(72, 26)
        Me.BtnClose.TabIndex = 61
        Me.BtnClose.Text = "&Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'GrpItem
        '
        Me.GrpItem.Controls.Add(Me.GrdItems)
        Me.GrpItem.Controls.Add(Me.BtnRemove)
        Me.GrpItem.Controls.Add(Me.BtnAdd)
        Me.GrpItem.Controls.Add(Me.CmbItem)
        Me.GrpItem.Controls.Add(Me.Label7)
        Me.GrpItem.Controls.Add(Me.TxtQuantity)
        Me.GrpItem.Controls.Add(Me.Label10)
        Me.GrpItem.Location = New System.Drawing.Point(10, 71)
        Me.GrpItem.Name = "GrpItem"
        Me.GrpItem.Size = New System.Drawing.Size(893, 268)
        Me.GrpItem.TabIndex = 13
        Me.GrpItem.TabStop = False
        '
        'GrdItems
        '
        Me.GrdItems.AllowUserToAddRows = False
        Me.GrdItems.AllowUserToDeleteRows = False
        Me.GrdItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdItems.Location = New System.Drawing.Point(10, 60)
        Me.GrdItems.Name = "GrdItems"
        Me.GrdItems.ReadOnly = True
        Me.GrdItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdItems.Size = New System.Drawing.Size(877, 202)
        Me.GrdItems.TabIndex = 48
        '
        'BtnRemove
        '
        Me.BtnRemove.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnRemove.Location = New System.Drawing.Point(814, 29)
        Me.BtnRemove.Name = "BtnRemove"
        Me.BtnRemove.Size = New System.Drawing.Size(73, 26)
        Me.BtnRemove.TabIndex = 47
        Me.BtnRemove.Text = "&Remove"
        Me.BtnRemove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnRemove.UseVisualStyleBackColor = True
        '
        'BtnAdd
        '
        Me.BtnAdd.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnAdd.Location = New System.Drawing.Point(735, 29)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(73, 26)
        Me.BtnAdd.TabIndex = 46
        Me.BtnAdd.Text = "&Add"
        Me.BtnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnAdd.UseVisualStyleBackColor = True
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
        Me.GrpButtons.Location = New System.Drawing.Point(11, 612)
        Me.GrpButtons.Name = "GrpButtons"
        Me.GrpButtons.Size = New System.Drawing.Size(892, 51)
        Me.GrpButtons.TabIndex = 15
        Me.GrpButtons.TabStop = False
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
        'DtPkrDestructionSlipDate
        '
        Me.DtPkrDestructionSlipDate.CustomFormat = "dd/MM/yyyy"
        Me.DtPkrDestructionSlipDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtPkrDestructionSlipDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtPkrDestructionSlipDate.Location = New System.Drawing.Point(326, 18)
        Me.DtPkrDestructionSlipDate.Name = "DtPkrDestructionSlipDate"
        Me.DtPkrDestructionSlipDate.Size = New System.Drawing.Size(86, 20)
        Me.DtPkrDestructionSlipDate.TabIndex = 35
        '
        'GrpDestructionSlip
        '
        Me.GrpDestructionSlip.Controls.Add(Me.DtPkrDestructionSlipDate)
        Me.GrpDestructionSlip.Controls.Add(Me.Label2)
        Me.GrpDestructionSlip.Controls.Add(Me.TxtDestructionSlipCode)
        Me.GrpDestructionSlip.Controls.Add(Me.Label1)
        Me.GrpDestructionSlip.Location = New System.Drawing.Point(11, 12)
        Me.GrpDestructionSlip.Name = "GrpDestructionSlip"
        Me.GrpDestructionSlip.Size = New System.Drawing.Size(893, 53)
        Me.GrpDestructionSlip.TabIndex = 12
        Me.GrpDestructionSlip.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(213, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Destruction Slip Date"
        '
        'TxtDestructionSlipCode
        '
        Me.TxtDestructionSlipCode.BackColor = System.Drawing.Color.White
        Me.TxtDestructionSlipCode.Enabled = False
        Me.TxtDestructionSlipCode.Location = New System.Drawing.Point(121, 19)
        Me.TxtDestructionSlipCode.Name = "TxtDestructionSlipCode"
        Me.TxtDestructionSlipCode.ReadOnly = True
        Me.TxtDestructionSlipCode.Size = New System.Drawing.Size(86, 20)
        Me.TxtDestructionSlipCode.TabIndex = 1
        Me.TxtDestructionSlipCode.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Destruction Slip Code"
        '
        'FrmDestructionSlip
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(919, 678)
        Me.ControlBox = False
        Me.Controls.Add(Me.GrpItemsOnSlip)
        Me.Controls.Add(Me.GrpItem)
        Me.Controls.Add(Me.GrpButtons)
        Me.Controls.Add(Me.GrpDestructionSlip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmDestructionSlip"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Destruction Slip"
        Me.GrpItemsOnSlip.ResumeLayout(False)
        Me.GrpItemsOnSlip.PerformLayout()
        CType(Me.GrdItemsOnSlip, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpItem.ResumeLayout(False)
        Me.GrpItem.PerformLayout()
        CType(Me.GrdItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpButtons.ResumeLayout(False)
        Me.GrpButtons.PerformLayout()
        Me.GrpDestructionSlip.ResumeLayout(False)
        Me.GrpDestructionSlip.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnSearch As System.Windows.Forms.Button
    Friend WithEvents GrpItemsOnSlip As System.Windows.Forms.GroupBox
    Friend WithEvents GrdItemsOnSlip As System.Windows.Forms.DataGridView
    Friend WithEvents TxtNetAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents BtnPrint As System.Windows.Forms.Button
    Friend WithEvents TxtQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CmbItem As System.Windows.Forms.ComboBox
    Friend WithEvents BtnNew As System.Windows.Forms.Button
    Friend WithEvents TxtRemark As System.Windows.Forms.TextBox
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents GrpItem As System.Windows.Forms.GroupBox
    Friend WithEvents GrdItems As System.Windows.Forms.DataGridView
    Friend WithEvents BtnRemove As System.Windows.Forms.Button
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents GrpButtons As System.Windows.Forms.GroupBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents DtPkrDestructionSlipDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents GrpDestructionSlip As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtDestructionSlipCode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
