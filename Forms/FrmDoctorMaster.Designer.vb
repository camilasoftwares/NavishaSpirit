<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDoctorMaster
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDoctorMaster))
        Me.GrpDoctor = New System.Windows.Forms.GroupBox
        Me.LblAddSpeciality = New System.Windows.Forms.Label
        Me.CmbSpeciality = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.TxtEmail = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TxtPhoneO = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TxtPhoneR = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtMobile = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtPin = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtCity = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtAddress = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GrpSearch = New System.Windows.Forms.GroupBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.CmbFieldToSearch = New System.Windows.Forms.ComboBox
        Me.TxtLikeValue = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.GrpButton = New System.Windows.Forms.GroupBox
        Me.BtnCancel = New System.Windows.Forms.Button
        Me.BtnUpdate = New System.Windows.Forms.Button
        Me.BtnClose = New System.Windows.Forms.Button
        Me.BtnAdd = New System.Windows.Forms.Button
        Me.GrpDoctorDetails = New System.Windows.Forms.GroupBox
        Me.GrdDoctorDetails = New System.Windows.Forms.DataGridView
        Me.GrpDoctor.SuspendLayout()
        Me.GrpSearch.SuspendLayout()
        Me.GrpButton.SuspendLayout()
        Me.GrpDoctorDetails.SuspendLayout()
        CType(Me.GrdDoctorDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpDoctor
        '
        Me.GrpDoctor.Controls.Add(Me.LblAddSpeciality)
        Me.GrpDoctor.Controls.Add(Me.CmbSpeciality)
        Me.GrpDoctor.Controls.Add(Me.Label10)
        Me.GrpDoctor.Controls.Add(Me.TxtEmail)
        Me.GrpDoctor.Controls.Add(Me.Label9)
        Me.GrpDoctor.Controls.Add(Me.TxtPhoneO)
        Me.GrpDoctor.Controls.Add(Me.Label8)
        Me.GrpDoctor.Controls.Add(Me.TxtPhoneR)
        Me.GrpDoctor.Controls.Add(Me.Label7)
        Me.GrpDoctor.Controls.Add(Me.TxtMobile)
        Me.GrpDoctor.Controls.Add(Me.Label6)
        Me.GrpDoctor.Controls.Add(Me.TxtPin)
        Me.GrpDoctor.Controls.Add(Me.Label5)
        Me.GrpDoctor.Controls.Add(Me.TxtCity)
        Me.GrpDoctor.Controls.Add(Me.Label3)
        Me.GrpDoctor.Controls.Add(Me.TxtAddress)
        Me.GrpDoctor.Controls.Add(Me.Label2)
        Me.GrpDoctor.Controls.Add(Me.TxtName)
        Me.GrpDoctor.Controls.Add(Me.Label1)
        Me.GrpDoctor.Location = New System.Drawing.Point(12, 12)
        Me.GrpDoctor.Name = "GrpDoctor"
        Me.GrpDoctor.Size = New System.Drawing.Size(624, 153)
        Me.GrpDoctor.TabIndex = 6
        Me.GrpDoctor.TabStop = False
        Me.GrpDoctor.Text = "Doctor"
        '
        'LblAddSpeciality
        '
        Me.LblAddSpeciality.BackColor = System.Drawing.Color.Transparent
        Me.LblAddSpeciality.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LblAddSpeciality.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LblAddSpeciality.Image = CType(resources.GetObject("LblAddSpeciality.Image"), System.Drawing.Image)
        Me.LblAddSpeciality.Location = New System.Drawing.Point(590, 17)
        Me.LblAddSpeciality.Name = "LblAddSpeciality"
        Me.LblAddSpeciality.Size = New System.Drawing.Size(21, 21)
        Me.LblAddSpeciality.TabIndex = 99
        Me.LblAddSpeciality.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LblAddSpeciality.Visible = False
        '
        'CmbSpeciality
        '
        Me.CmbSpeciality.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbSpeciality.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbSpeciality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbSpeciality.FormattingEnabled = True
        Me.CmbSpeciality.Location = New System.Drawing.Point(417, 18)
        Me.CmbSpeciality.Name = "CmbSpeciality"
        Me.CmbSpeciality.Size = New System.Drawing.Size(167, 21)
        Me.CmbSpeciality.Sorted = True
        Me.CmbSpeciality.TabIndex = 33
        Me.CmbSpeciality.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(355, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 13)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Speciality*"
        Me.Label10.Visible = False
        '
        'TxtEmail
        '
        Me.TxtEmail.Location = New System.Drawing.Point(108, 123)
        Me.TxtEmail.Name = "TxtEmail"
        Me.TxtEmail.Size = New System.Drawing.Size(270, 20)
        Me.TxtEmail.TabIndex = 17
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 126)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(36, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "E-Mail"
        '
        'TxtPhoneO
        '
        Me.TxtPhoneO.Location = New System.Drawing.Point(417, 97)
        Me.TxtPhoneO.Name = "TxtPhoneO"
        Me.TxtPhoneO.Size = New System.Drawing.Size(181, 20)
        Me.TxtPhoneO.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(315, 100)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Phone No.(Off)"
        '
        'TxtPhoneR
        '
        Me.TxtPhoneR.Location = New System.Drawing.Point(108, 97)
        Me.TxtPhoneR.Name = "TxtPhoneR"
        Me.TxtPhoneR.Size = New System.Drawing.Size(179, 20)
        Me.TxtPhoneR.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 100)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Phone No.(Res)"
        '
        'TxtMobile
        '
        Me.TxtMobile.Location = New System.Drawing.Point(417, 71)
        Me.TxtMobile.Name = "TxtMobile"
        Me.TxtMobile.Size = New System.Drawing.Size(181, 20)
        Me.TxtMobile.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(355, 74)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Mobile"
        '
        'TxtPin
        '
        Me.TxtPin.Location = New System.Drawing.Point(262, 71)
        Me.TxtPin.Name = "TxtPin"
        Me.TxtPin.Size = New System.Drawing.Size(87, 20)
        Me.TxtPin.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(234, 74)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(22, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Pin"
        '
        'TxtCity
        '
        Me.TxtCity.Location = New System.Drawing.Point(108, 71)
        Me.TxtCity.Name = "TxtCity"
        Me.TxtCity.Size = New System.Drawing.Size(120, 20)
        Me.TxtCity.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "City*"
        '
        'TxtAddress
        '
        Me.TxtAddress.Location = New System.Drawing.Point(108, 45)
        Me.TxtAddress.Name = "TxtAddress"
        Me.TxtAddress.Size = New System.Drawing.Size(490, 20)
        Me.TxtAddress.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Complete Address*"
        '
        'TxtName
        '
        Me.TxtName.Location = New System.Drawing.Point(108, 19)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(241, 20)
        Me.TxtName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Doctor Name*"
        '
        'GrpSearch
        '
        Me.GrpSearch.Controls.Add(Me.Label12)
        Me.GrpSearch.Controls.Add(Me.CmbFieldToSearch)
        Me.GrpSearch.Controls.Add(Me.TxtLikeValue)
        Me.GrpSearch.Controls.Add(Me.Label4)
        Me.GrpSearch.Location = New System.Drawing.Point(12, 171)
        Me.GrpSearch.Name = "GrpSearch"
        Me.GrpSearch.Size = New System.Drawing.Size(733, 50)
        Me.GrpSearch.TabIndex = 9
        Me.GrpSearch.TabStop = False
        Me.GrpSearch.Text = "Search By"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(368, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(53, 13)
        Me.Label12.TabIndex = 33
        Me.Label12.Text = "Search In"
        '
        'CmbFieldToSearch
        '
        Me.CmbFieldToSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbFieldToSearch.FormattingEnabled = True
        Me.CmbFieldToSearch.Location = New System.Drawing.Point(427, 19)
        Me.CmbFieldToSearch.Name = "CmbFieldToSearch"
        Me.CmbFieldToSearch.Size = New System.Drawing.Size(121, 21)
        Me.CmbFieldToSearch.Sorted = True
        Me.CmbFieldToSearch.TabIndex = 32
        '
        'TxtLikeValue
        '
        Me.TxtLikeValue.Location = New System.Drawing.Point(629, 19)
        Me.TxtLikeValue.Name = "TxtLikeValue"
        Me.TxtLikeValue.Size = New System.Drawing.Size(88, 20)
        Me.TxtLikeValue.TabIndex = 31
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(554, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Starting From"
        '
        'GrpButton
        '
        Me.GrpButton.Controls.Add(Me.BtnCancel)
        Me.GrpButton.Controls.Add(Me.BtnUpdate)
        Me.GrpButton.Controls.Add(Me.BtnClose)
        Me.GrpButton.Controls.Add(Me.BtnAdd)
        Me.GrpButton.Location = New System.Drawing.Point(642, 12)
        Me.GrpButton.Name = "GrpButton"
        Me.GrpButton.Size = New System.Drawing.Size(103, 153)
        Me.GrpButton.TabIndex = 10
        Me.GrpButton.TabStop = False
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(15, 83)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(72, 26)
        Me.BtnCancel.TabIndex = 3
        Me.BtnCancel.Text = "Cance&l"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnUpdate
        '
        Me.BtnUpdate.Location = New System.Drawing.Point(15, 51)
        Me.BtnUpdate.Name = "BtnUpdate"
        Me.BtnUpdate.Size = New System.Drawing.Size(72, 26)
        Me.BtnUpdate.TabIndex = 2
        Me.BtnUpdate.Text = "&Update"
        Me.BtnUpdate.UseVisualStyleBackColor = True
        '
        'BtnClose
        '
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(15, 115)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(72, 26)
        Me.BtnClose.TabIndex = 1
        Me.BtnClose.Text = "&Close"
        Me.BtnClose.UseVisualStyleBackColor = True
        '
        'BtnAdd
        '
        Me.BtnAdd.Location = New System.Drawing.Point(15, 19)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(72, 26)
        Me.BtnAdd.TabIndex = 0
        Me.BtnAdd.Text = "&Add"
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'GrpDoctorDetails
        '
        Me.GrpDoctorDetails.Controls.Add(Me.GrdDoctorDetails)
        Me.GrpDoctorDetails.Location = New System.Drawing.Point(12, 227)
        Me.GrpDoctorDetails.Name = "GrpDoctorDetails"
        Me.GrpDoctorDetails.Size = New System.Drawing.Size(733, 381)
        Me.GrpDoctorDetails.TabIndex = 11
        Me.GrpDoctorDetails.TabStop = False
        Me.GrpDoctorDetails.Text = "Doctor Details"
        '
        'GrdDoctorDetails
        '
        Me.GrdDoctorDetails.AllowUserToAddRows = False
        Me.GrdDoctorDetails.AllowUserToDeleteRows = False
        Me.GrdDoctorDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdDoctorDetails.Location = New System.Drawing.Point(6, 19)
        Me.GrdDoctorDetails.Name = "GrdDoctorDetails"
        Me.GrdDoctorDetails.ReadOnly = True
        Me.GrdDoctorDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdDoctorDetails.Size = New System.Drawing.Size(721, 356)
        Me.GrdDoctorDetails.TabIndex = 5
        '
        'FrmDoctorMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(760, 620)
        Me.ControlBox = False
        Me.Controls.Add(Me.GrpDoctorDetails)
        Me.Controls.Add(Me.GrpButton)
        Me.Controls.Add(Me.GrpSearch)
        Me.Controls.Add(Me.GrpDoctor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmDoctorMaster"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Doctor Master"
        Me.GrpDoctor.ResumeLayout(False)
        Me.GrpDoctor.PerformLayout()
        Me.GrpSearch.ResumeLayout(False)
        Me.GrpSearch.PerformLayout()
        Me.GrpButton.ResumeLayout(False)
        Me.GrpDoctorDetails.ResumeLayout(False)
        CType(Me.GrdDoctorDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpDoctor As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtPhoneO As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtPhoneR As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtMobile As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtPin As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtCity As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtAddress As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CmbSpeciality As System.Windows.Forms.ComboBox
    Friend WithEvents GrpSearch As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CmbFieldToSearch As System.Windows.Forms.ComboBox
    Friend WithEvents TxtLikeValue As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GrpButton As System.Windows.Forms.GroupBox
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnUpdate As System.Windows.Forms.Button
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents GrpDoctorDetails As System.Windows.Forms.GroupBox
    Friend WithEvents GrdDoctorDetails As System.Windows.Forms.DataGridView
    Friend WithEvents LblAddSpeciality As System.Windows.Forms.Label

End Class
