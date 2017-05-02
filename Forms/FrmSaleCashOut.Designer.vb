<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSaleCashOut
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
        Me.GrpItems = New System.Windows.Forms.GroupBox
        Me.GrdItems = New System.Windows.Forms.DataGridView
        Me.TxtRoundOff = New System.Windows.Forms.TextBox
        Me.TxtTax = New System.Windows.Forms.TextBox
        Me.TxtDiscount = New System.Windows.Forms.TextBox
        Me.TxtTotal = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.TxtNetAmount = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.GrpBills = New System.Windows.Forms.GroupBox
        Me.GrdBills = New System.Windows.Forms.DataGridView
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtCashOutAmount = New System.Windows.Forms.TextBox
        Me.TxtAdjustment = New System.Windows.Forms.TextBox
        Me.TxtBalanceAmount = New System.Windows.Forms.TextBox
        Me.TxtPreviousAdjustmentAmount = New System.Windows.Forms.TextBox
        Me.TxtPreviousCashOutAmount = New System.Windows.Forms.TextBox
        Me.BtnClose = New System.Windows.Forms.Button
        Me.BtnCashOut = New System.Windows.Forms.Button
        Me.GrpItems.SuspendLayout()
        CType(Me.GrdItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpBills.SuspendLayout()
        CType(Me.GrdBills, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpItems
        '
        Me.GrpItems.Controls.Add(Me.GrdItems)
        Me.GrpItems.Location = New System.Drawing.Point(11, 226)
        Me.GrpItems.Name = "GrpItems"
        Me.GrpItems.Size = New System.Drawing.Size(910, 217)
        Me.GrpItems.TabIndex = 15
        Me.GrpItems.TabStop = False
        Me.GrpItems.Text = "Medicines on Bill"
        '
        'GrdItems
        '
        Me.GrdItems.AllowUserToAddRows = False
        Me.GrdItems.AllowUserToDeleteRows = False
        Me.GrdItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdItems.Location = New System.Drawing.Point(10, 19)
        Me.GrdItems.Name = "GrdItems"
        Me.GrdItems.ReadOnly = True
        Me.GrdItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdItems.Size = New System.Drawing.Size(894, 191)
        Me.GrdItems.TabIndex = 48
        Me.GrdItems.TabStop = False
        '
        'TxtRoundOff
        '
        Me.TxtRoundOff.BackColor = System.Drawing.Color.White
        Me.TxtRoundOff.Enabled = False
        Me.TxtRoundOff.Location = New System.Drawing.Point(602, 473)
        Me.TxtRoundOff.Name = "TxtRoundOff"
        Me.TxtRoundOff.ReadOnly = True
        Me.TxtRoundOff.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtRoundOff.Size = New System.Drawing.Size(166, 20)
        Me.TxtRoundOff.TabIndex = 10
        Me.TxtRoundOff.TabStop = False
        '
        'TxtTax
        '
        Me.TxtTax.BackColor = System.Drawing.Color.White
        Me.TxtTax.Enabled = False
        Me.TxtTax.Location = New System.Drawing.Point(214, 473)
        Me.TxtTax.Name = "TxtTax"
        Me.TxtTax.ReadOnly = True
        Me.TxtTax.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtTax.Size = New System.Drawing.Size(178, 20)
        Me.TxtTax.TabIndex = 11
        Me.TxtTax.TabStop = False
        '
        'TxtDiscount
        '
        Me.TxtDiscount.BackColor = System.Drawing.Color.White
        Me.TxtDiscount.Enabled = False
        Me.TxtDiscount.Location = New System.Drawing.Point(401, 473)
        Me.TxtDiscount.Name = "TxtDiscount"
        Me.TxtDiscount.ReadOnly = True
        Me.TxtDiscount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtDiscount.Size = New System.Drawing.Size(188, 20)
        Me.TxtDiscount.TabIndex = 12
        Me.TxtDiscount.TabStop = False
        '
        'TxtTotal
        '
        Me.TxtTotal.BackColor = System.Drawing.Color.White
        Me.TxtTotal.Enabled = False
        Me.TxtTotal.Location = New System.Drawing.Point(20, 473)
        Me.TxtTotal.Name = "TxtTotal"
        Me.TxtTotal.ReadOnly = True
        Me.TxtTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtTotal.Size = New System.Drawing.Size(185, 20)
        Me.TxtTotal.TabIndex = 13
        Me.TxtTotal.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(63, 457)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 13)
        Me.Label9.TabIndex = 44
        Me.Label9.Text = "Total"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(463, 457)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(49, 13)
        Me.Label14.TabIndex = 41
        Me.Label14.Text = "Discount"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(289, 457)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(25, 13)
        Me.Label15.TabIndex = 37
        Me.Label15.Text = "Tax"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(648, 457)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(56, 13)
        Me.Label18.TabIndex = 4
        Me.Label18.Text = "Round-Off"
        '
        'TxtNetAmount
        '
        Me.TxtNetAmount.BackColor = System.Drawing.Color.White
        Me.TxtNetAmount.Enabled = False
        Me.TxtNetAmount.Location = New System.Drawing.Point(780, 473)
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
        Me.Label19.Location = New System.Drawing.Point(814, 457)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(63, 13)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "Net Amount"
        '
        'GrpBills
        '
        Me.GrpBills.Controls.Add(Me.GrdBills)
        Me.GrpBills.Location = New System.Drawing.Point(10, 8)
        Me.GrpBills.Name = "GrpBills"
        Me.GrpBills.Size = New System.Drawing.Size(910, 217)
        Me.GrpBills.TabIndex = 16
        Me.GrpBills.TabStop = False
        Me.GrpBills.Text = "Select Sale Bill For CashOut"
        '
        'GrdBills
        '
        Me.GrdBills.AllowUserToAddRows = False
        Me.GrdBills.AllowUserToDeleteRows = False
        Me.GrdBills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdBills.Location = New System.Drawing.Point(10, 16)
        Me.GrdBills.Name = "GrdBills"
        Me.GrdBills.ReadOnly = True
        Me.GrdBills.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdBills.Size = New System.Drawing.Size(894, 192)
        Me.GrdBills.TabIndex = 48
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(38, 507)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(131, 13)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "Previous CashOut Amount"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(231, 507)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(142, 13)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "Prevoius Adjustment Amount"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(425, 507)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(141, 13)
        Me.Label3.TabIndex = 47
        Me.Label3.Text = "Balance Amount to CashOut"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(648, 507)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 13)
        Me.Label4.TabIndex = 48
        Me.Label4.Text = "CashOut Amount"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(814, 507)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 49
        Me.Label5.Text = "Adjustment"
        '
        'TxtCashOutAmount
        '
        Me.TxtCashOutAmount.BackColor = System.Drawing.Color.White
        Me.TxtCashOutAmount.Location = New System.Drawing.Point(602, 523)
        Me.TxtCashOutAmount.Name = "TxtCashOutAmount"
        Me.TxtCashOutAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtCashOutAmount.Size = New System.Drawing.Size(166, 20)
        Me.TxtCashOutAmount.TabIndex = 51
        '
        'TxtAdjustment
        '
        Me.TxtAdjustment.BackColor = System.Drawing.Color.White
        Me.TxtAdjustment.Location = New System.Drawing.Point(780, 523)
        Me.TxtAdjustment.Name = "TxtAdjustment"
        Me.TxtAdjustment.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtAdjustment.Size = New System.Drawing.Size(140, 20)
        Me.TxtAdjustment.TabIndex = 50
        '
        'TxtBalanceAmount
        '
        Me.TxtBalanceAmount.BackColor = System.Drawing.Color.White
        Me.TxtBalanceAmount.Enabled = False
        Me.TxtBalanceAmount.Location = New System.Drawing.Point(401, 523)
        Me.TxtBalanceAmount.Name = "TxtBalanceAmount"
        Me.TxtBalanceAmount.ReadOnly = True
        Me.TxtBalanceAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtBalanceAmount.Size = New System.Drawing.Size(188, 20)
        Me.TxtBalanceAmount.TabIndex = 53
        Me.TxtBalanceAmount.TabStop = False
        '
        'TxtPreviousAdjustmentAmount
        '
        Me.TxtPreviousAdjustmentAmount.BackColor = System.Drawing.Color.White
        Me.TxtPreviousAdjustmentAmount.Enabled = False
        Me.TxtPreviousAdjustmentAmount.Location = New System.Drawing.Point(214, 523)
        Me.TxtPreviousAdjustmentAmount.Name = "TxtPreviousAdjustmentAmount"
        Me.TxtPreviousAdjustmentAmount.ReadOnly = True
        Me.TxtPreviousAdjustmentAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtPreviousAdjustmentAmount.Size = New System.Drawing.Size(178, 20)
        Me.TxtPreviousAdjustmentAmount.TabIndex = 52
        Me.TxtPreviousAdjustmentAmount.TabStop = False
        '
        'TxtPreviousCashOutAmount
        '
        Me.TxtPreviousCashOutAmount.BackColor = System.Drawing.Color.White
        Me.TxtPreviousCashOutAmount.Enabled = False
        Me.TxtPreviousCashOutAmount.Location = New System.Drawing.Point(21, 523)
        Me.TxtPreviousCashOutAmount.Name = "TxtPreviousCashOutAmount"
        Me.TxtPreviousCashOutAmount.ReadOnly = True
        Me.TxtPreviousCashOutAmount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TxtPreviousCashOutAmount.Size = New System.Drawing.Size(184, 20)
        Me.TxtPreviousCashOutAmount.TabIndex = 54
        Me.TxtPreviousCashOutAmount.TabStop = False
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnClose.Location = New System.Drawing.Point(780, 566)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(140, 26)
        Me.BtnClose.TabIndex = 58
        Me.BtnClose.Text = "&Close"
        Me.BtnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnCashOut
        '
        Me.BtnCashOut.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnCashOut.Location = New System.Drawing.Point(602, 568)
        Me.BtnCashOut.Name = "BtnCashOut"
        Me.BtnCashOut.Size = New System.Drawing.Size(166, 26)
        Me.BtnCashOut.TabIndex = 57
        Me.BtnCashOut.Text = "Cash&Out"
        Me.BtnCashOut.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.BtnCashOut.UseVisualStyleBackColor = True
        '
        'FrmSaleCashOut
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(933, 609)
        Me.ControlBox = False
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.BtnCashOut)
        Me.Controls.Add(Me.TxtCashOutAmount)
        Me.Controls.Add(Me.TxtAdjustment)
        Me.Controls.Add(Me.TxtBalanceAmount)
        Me.Controls.Add(Me.TxtPreviousAdjustmentAmount)
        Me.Controls.Add(Me.TxtPreviousCashOutAmount)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtRoundOff)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.TxtNetAmount)
        Me.Controls.Add(Me.GrpBills)
        Me.Controls.Add(Me.TxtDiscount)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.TxtTax)
        Me.Controls.Add(Me.GrpItems)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.TxtTotal)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label15)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSaleCashOut"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sale CashOut"
        Me.GrpItems.ResumeLayout(False)
        CType(Me.GrdItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpBills.ResumeLayout(False)
        CType(Me.GrdBills, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GrpItems As System.Windows.Forms.GroupBox
    Friend WithEvents TxtRoundOff As System.Windows.Forms.TextBox
    Friend WithEvents TxtTax As System.Windows.Forms.TextBox
    Friend WithEvents TxtDiscount As System.Windows.Forms.TextBox
    Friend WithEvents TxtTotal As System.Windows.Forms.TextBox
    Friend WithEvents GrdItems As System.Windows.Forms.DataGridView
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TxtNetAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents GrpBills As System.Windows.Forms.GroupBox
    Friend WithEvents GrdBills As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtCashOutAmount As System.Windows.Forms.TextBox
    Friend WithEvents TxtAdjustment As System.Windows.Forms.TextBox
    Friend WithEvents TxtBalanceAmount As System.Windows.Forms.TextBox
    Friend WithEvents TxtPreviousAdjustmentAmount As System.Windows.Forms.TextBox
    Friend WithEvents TxtPreviousCashOutAmount As System.Windows.Forms.TextBox
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents BtnCashOut As System.Windows.Forms.Button
End Class
