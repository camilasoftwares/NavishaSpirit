<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DlgStockLedger
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.CmbItemName = New System.Windows.Forms.ComboBox
        Me.BtnDisplay = New System.Windows.Forms.Button
        Me.BtnClose = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Select Item Name"
        '
        'CmbItemName
        '
        Me.CmbItemName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbItemName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbItemName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.CmbItemName.FormattingEnabled = True
        Me.CmbItemName.Location = New System.Drawing.Point(12, 32)
        Me.CmbItemName.Name = "CmbItemName"
        Me.CmbItemName.Size = New System.Drawing.Size(284, 21)
        Me.CmbItemName.Sorted = True
        Me.CmbItemName.TabIndex = 1
        '
        'BtnDisplay
        '
        Me.BtnDisplay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.BtnDisplay.Location = New System.Drawing.Point(130, 59)
        Me.BtnDisplay.Name = "BtnDisplay"
        Me.BtnDisplay.Size = New System.Drawing.Size(78, 27)
        Me.BtnDisplay.TabIndex = 2
        Me.BtnDisplay.Text = "Display"
        Me.BtnDisplay.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.BtnClose.Location = New System.Drawing.Point(215, 59)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(81, 27)
        Me.BtnClose.TabIndex = 3
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'DlgStockLedger
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(311, 96)
        Me.ControlBox = False
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.BtnDisplay)
        Me.Controls.Add(Me.CmbItemName)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DlgStockLedger"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock Ledger"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmbItemName As System.Windows.Forms.ComboBox
    Friend WithEvents BtnDisplay As System.Windows.Forms.Button
    Friend WithEvents BtnClose As System.Windows.Forms.Button
End Class
