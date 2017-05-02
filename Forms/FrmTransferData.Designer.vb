<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTransferData
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
        Me.GrpControl = New System.Windows.Forms.GroupBox
        Me.LblTransferred = New System.Windows.Forms.Label
        Me.LblToTransfer = New System.Windows.Forms.Label
        Me.LblMsg = New System.Windows.Forms.Label
        Me.PgBar = New System.Windows.Forms.ProgressBar
        Me.BtnClose = New System.Windows.Forms.Button
        Me.BtnTransferData = New System.Windows.Forms.Button
        Me.GrpControl.SuspendLayout()
        Me.SuspendLayout()
        '
        'GrpControl
        '
        Me.GrpControl.Controls.Add(Me.LblTransferred)
        Me.GrpControl.Controls.Add(Me.LblToTransfer)
        Me.GrpControl.Controls.Add(Me.LblMsg)
        Me.GrpControl.Controls.Add(Me.PgBar)
        Me.GrpControl.Controls.Add(Me.BtnClose)
        Me.GrpControl.Controls.Add(Me.BtnTransferData)
        Me.GrpControl.Location = New System.Drawing.Point(12, 12)
        Me.GrpControl.Name = "GrpControl"
        Me.GrpControl.Size = New System.Drawing.Size(339, 135)
        Me.GrpControl.TabIndex = 0
        Me.GrpControl.TabStop = False
        '
        'LblTransferred
        '
        Me.LblTransferred.AutoSize = True
        Me.LblTransferred.Location = New System.Drawing.Point(177, 91)
        Me.LblTransferred.Name = "LblTransferred"
        Me.LblTransferred.Size = New System.Drawing.Size(39, 13)
        Me.LblTransferred.TabIndex = 5
        Me.LblTransferred.Text = "Label2"
        '
        'LblToTransfer
        '
        Me.LblToTransfer.AutoSize = True
        Me.LblToTransfer.Location = New System.Drawing.Point(6, 91)
        Me.LblToTransfer.Name = "LblToTransfer"
        Me.LblToTransfer.Size = New System.Drawing.Size(39, 13)
        Me.LblToTransfer.TabIndex = 4
        Me.LblToTransfer.Text = "Label2"
        '
        'LblMsg
        '
        Me.LblMsg.AutoSize = True
        Me.LblMsg.Location = New System.Drawing.Point(6, 71)
        Me.LblMsg.Name = "LblMsg"
        Me.LblMsg.Size = New System.Drawing.Size(41, 13)
        Me.LblMsg.TabIndex = 3
        Me.LblMsg.Text = "LblMsg"
        '
        'PgBar
        '
        Me.PgBar.Location = New System.Drawing.Point(6, 107)
        Me.PgBar.Name = "PgBar"
        Me.PgBar.Size = New System.Drawing.Size(322, 22)
        Me.PgBar.Step = 1
        Me.PgBar.TabIndex = 2
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(241, 25)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(87, 26)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "&Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnTransferData
        '
        Me.BtnTransferData.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTransferData.Location = New System.Drawing.Point(6, 19)
        Me.BtnTransferData.Name = "BtnTransferData"
        Me.BtnTransferData.Size = New System.Drawing.Size(204, 38)
        Me.BtnTransferData.TabIndex = 0
        Me.BtnTransferData.Text = "Transfer &Data"
        Me.BtnTransferData.UseVisualStyleBackColor = True
        '
        'FrmTransferData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(364, 159)
        Me.ControlBox = False
        Me.Controls.Add(Me.GrpControl)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmTransferData"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Transfer Data"
        Me.GrpControl.ResumeLayout(False)
        Me.GrpControl.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpControl As System.Windows.Forms.GroupBox
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents BtnTransferData As System.Windows.Forms.Button
    Friend WithEvents LblMsg As System.Windows.Forms.Label
    Friend WithEvents PgBar As System.Windows.Forms.ProgressBar
    Friend WithEvents LblToTransfer As System.Windows.Forms.Label
    Friend WithEvents LblTransferred As System.Windows.Forms.Label

End Class
