<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSearchToAll
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
        Me.GrpCondition = New System.Windows.Forms.GroupBox
        Me.PnlDate = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtMaskDate = New System.Windows.Forms.MaskedTextBox
        Me.GrdItems = New System.Windows.Forms.DataGridView
        Me.BtnClose = New System.Windows.Forms.Button
        Me.BtnShowDetails = New System.Windows.Forms.Button
        Me.TxtSearchValue = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.CmbSearchOnField = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GrpCondition.SuspendLayout()
        Me.PnlDate.SuspendLayout()
        CType(Me.GrdItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpCondition
        '
        Me.GrpCondition.Controls.Add(Me.PnlDate)
        Me.GrpCondition.Controls.Add(Me.GrdItems)
        Me.GrpCondition.Controls.Add(Me.BtnClose)
        Me.GrpCondition.Controls.Add(Me.BtnShowDetails)
        Me.GrpCondition.Controls.Add(Me.TxtSearchValue)
        Me.GrpCondition.Controls.Add(Me.Label2)
        Me.GrpCondition.Controls.Add(Me.CmbSearchOnField)
        Me.GrpCondition.Controls.Add(Me.Label1)
        Me.GrpCondition.Location = New System.Drawing.Point(12, 12)
        Me.GrpCondition.Name = "GrpCondition"
        Me.GrpCondition.Size = New System.Drawing.Size(948, 652)
        Me.GrpCondition.TabIndex = 0
        Me.GrpCondition.TabStop = False
        '
        'PnlDate
        '
        Me.PnlDate.Controls.Add(Me.Label3)
        Me.PnlDate.Controls.Add(Me.TxtMaskDate)
        Me.PnlDate.Location = New System.Drawing.Point(489, 17)
        Me.PnlDate.Name = "PnlDate"
        Me.PnlDate.Size = New System.Drawing.Size(159, 26)
        Me.PnlDate.TabIndex = 60
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(85, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 59
        Me.Label3.Text = "dd/mm/yyyy"
        '
        'TxtMaskDate
        '
        Me.TxtMaskDate.Location = New System.Drawing.Point(3, 3)
        Me.TxtMaskDate.Mask = "00/00/0000"
        Me.TxtMaskDate.Name = "TxtMaskDate"
        Me.TxtMaskDate.Size = New System.Drawing.Size(76, 20)
        Me.TxtMaskDate.TabIndex = 58
        Me.TxtMaskDate.ValidatingType = GetType(Date)
        '
        'GrdItems
        '
        Me.GrdItems.AllowUserToAddRows = False
        Me.GrdItems.AllowUserToDeleteRows = False
        Me.GrdItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdItems.Location = New System.Drawing.Point(9, 57)
        Me.GrdItems.Name = "GrdItems"
        Me.GrdItems.ReadOnly = True
        Me.GrdItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdItems.Size = New System.Drawing.Size(929, 585)
        Me.GrdItems.TabIndex = 57
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(820, 17)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(118, 23)
        Me.BtnClose.TabIndex = 56
        Me.BtnClose.Text = "&Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnShowDetails
        '
        Me.BtnShowDetails.Location = New System.Drawing.Point(680, 17)
        Me.BtnShowDetails.Name = "BtnShowDetails"
        Me.BtnShowDetails.Size = New System.Drawing.Size(127, 23)
        Me.BtnShowDetails.TabIndex = 55
        Me.BtnShowDetails.Text = "&Show Details"
        Me.BtnShowDetails.UseVisualStyleBackColor = True
        '
        'TxtSearchValue
        '
        Me.TxtSearchValue.Location = New System.Drawing.Point(489, 20)
        Me.TxtSearchValue.Name = "TxtSearchValue"
        Me.TxtSearchValue.Size = New System.Drawing.Size(185, 20)
        Me.TxtSearchValue.TabIndex = 37
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(409, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "Search Value"
        '
        'CmbSearchOnField
        '
        Me.CmbSearchOnField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbSearchOnField.FormattingEnabled = True
        Me.CmbSearchOnField.Location = New System.Drawing.Point(95, 19)
        Me.CmbSearchOnField.Name = "CmbSearchOnField"
        Me.CmbSearchOnField.Size = New System.Drawing.Size(308, 21)
        Me.CmbSearchOnField.Sorted = True
        Me.CmbSearchOnField.TabIndex = 35
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Search on field"
        '
        'FrmSearchToAll
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(976, 677)
        Me.ControlBox = False
        Me.Controls.Add(Me.GrpCondition)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSearchToAll"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Search"
        Me.GrpCondition.ResumeLayout(False)
        Me.GrpCondition.PerformLayout()
        Me.PnlDate.ResumeLayout(False)
        Me.PnlDate.PerformLayout()
        CType(Me.GrdItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpCondition As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtSearchValue As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmbSearchOnField As System.Windows.Forms.ComboBox
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents BtnShowDetails As System.Windows.Forms.Button
    Friend WithEvents GrdItems As System.Windows.Forms.DataGridView
    Friend WithEvents PnlDate As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtMaskDate As System.Windows.Forms.MaskedTextBox
End Class
