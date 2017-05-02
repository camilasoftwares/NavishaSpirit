<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVendorMaster
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
        Me.GrpVendor = New System.Windows.Forms.GroupBox
        Me.GrpManufacturers = New System.Windows.Forms.GroupBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.BtnAdd = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.CmbManufacturers = New System.Windows.Forms.ComboBox
        Me.GrdManufacturers = New System.Windows.Forms.DataGridView
        Me.TxtVendorCode = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.TxtTinNo = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.TxtUpttNo = New System.Windows.Forms.TextBox
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
        Me.GrpButton = New System.Windows.Forms.GroupBox
        Me.BtnCancel = New System.Windows.Forms.Button
        Me.BtnUpdate = New System.Windows.Forms.Button
        Me.BtnClose = New System.Windows.Forms.Button
        Me.BtnSave = New System.Windows.Forms.Button
        Me.GrpSearch = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.CmbFieldToSearch = New System.Windows.Forms.ComboBox
        Me.TxtLikeValue = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.GrpVendorDetail = New System.Windows.Forms.GroupBox
        Me.GrdVendorDetail = New System.Windows.Forms.DataGridView
        Me.GrpVendor.SuspendLayout()
        Me.GrpManufacturers.SuspendLayout()
        CType(Me.GrdManufacturers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpButton.SuspendLayout()
        Me.GrpSearch.SuspendLayout()
        Me.GrpVendorDetail.SuspendLayout()
        CType(Me.GrdVendorDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpVendor
        '
        Me.GrpVendor.Controls.Add(Me.GrpManufacturers)
        Me.GrpVendor.Controls.Add(Me.TxtVendorCode)
        Me.GrpVendor.Controls.Add(Me.Label14)
        Me.GrpVendor.Controls.Add(Me.TxtTinNo)
        Me.GrpVendor.Controls.Add(Me.Label13)
        Me.GrpVendor.Controls.Add(Me.TxtUpttNo)
        Me.GrpVendor.Controls.Add(Me.Label10)
        Me.GrpVendor.Controls.Add(Me.TxtEmail)
        Me.GrpVendor.Controls.Add(Me.Label9)
        Me.GrpVendor.Controls.Add(Me.TxtPhoneO)
        Me.GrpVendor.Controls.Add(Me.Label8)
        Me.GrpVendor.Controls.Add(Me.TxtPhoneR)
        Me.GrpVendor.Controls.Add(Me.Label7)
        Me.GrpVendor.Controls.Add(Me.TxtMobile)
        Me.GrpVendor.Controls.Add(Me.Label6)
        Me.GrpVendor.Controls.Add(Me.TxtPin)
        Me.GrpVendor.Controls.Add(Me.Label5)
        Me.GrpVendor.Controls.Add(Me.TxtCity)
        Me.GrpVendor.Controls.Add(Me.Label3)
        Me.GrpVendor.Controls.Add(Me.TxtAddress)
        Me.GrpVendor.Controls.Add(Me.Label2)
        Me.GrpVendor.Controls.Add(Me.TxtName)
        Me.GrpVendor.Controls.Add(Me.Label1)
        Me.GrpVendor.Location = New System.Drawing.Point(12, 12)
        Me.GrpVendor.Name = "GrpVendor"
        Me.GrpVendor.Size = New System.Drawing.Size(805, 232)
        Me.GrpVendor.TabIndex = 6
        Me.GrpVendor.TabStop = False
        Me.GrpVendor.Text = "Vendor"
        '
        'GrpManufacturers
        '
        Me.GrpManufacturers.Controls.Add(Me.Label15)
        Me.GrpManufacturers.Controls.Add(Me.BtnAdd)
        Me.GrpManufacturers.Controls.Add(Me.Label12)
        Me.GrpManufacturers.Controls.Add(Me.CmbManufacturers)
        Me.GrpManufacturers.Controls.Add(Me.GrdManufacturers)
        Me.GrpManufacturers.Location = New System.Drawing.Point(535, 0)
        Me.GrpManufacturers.Name = "GrpManufacturers"
        Me.GrpManufacturers.Size = New System.Drawing.Size(268, 232)
        Me.GrpManufacturers.TabIndex = 28
        Me.GrpManufacturers.TabStop = False
        Me.GrpManufacturers.Text = "Manufacturers"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.Red
        Me.Label15.Location = New System.Drawing.Point(7, 216)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(205, 13)
        Me.Label15.TabIndex = 37
        Me.Label15.Text = "**Double Click row to delete Manufacturer"
        '
        'BtnAdd
        '
        Me.BtnAdd.Location = New System.Drawing.Point(208, 15)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(46, 26)
        Me.BtnAdd.TabIndex = 36
        Me.BtnAdd.Text = "&Add"
        Me.BtnAdd.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(7, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(70, 13)
        Me.Label12.TabIndex = 35
        Me.Label12.Text = "Manufacturer"
        '
        'CmbManufacturers
        '
        Me.CmbManufacturers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CmbManufacturers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CmbManufacturers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbManufacturers.FormattingEnabled = True
        Me.CmbManufacturers.Location = New System.Drawing.Point(83, 19)
        Me.CmbManufacturers.Name = "CmbManufacturers"
        Me.CmbManufacturers.Size = New System.Drawing.Size(121, 21)
        Me.CmbManufacturers.Sorted = True
        Me.CmbManufacturers.TabIndex = 34
        '
        'GrdManufacturers
        '
        Me.GrdManufacturers.AllowUserToAddRows = False
        Me.GrdManufacturers.AllowUserToDeleteRows = False
        Me.GrdManufacturers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdManufacturers.Location = New System.Drawing.Point(7, 47)
        Me.GrdManufacturers.Name = "GrdManufacturers"
        Me.GrdManufacturers.ReadOnly = True
        Me.GrdManufacturers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdManufacturers.Size = New System.Drawing.Size(247, 166)
        Me.GrdManufacturers.TabIndex = 5
        '
        'TxtVendorCode
        '
        Me.TxtVendorCode.BackColor = System.Drawing.Color.White
        Me.TxtVendorCode.Enabled = False
        Me.TxtVendorCode.Location = New System.Drawing.Point(108, 19)
        Me.TxtVendorCode.Name = "TxtVendorCode"
        Me.TxtVendorCode.ReadOnly = True
        Me.TxtVendorCode.Size = New System.Drawing.Size(92, 20)
        Me.TxtVendorCode.TabIndex = 27
        Me.TxtVendorCode.TabStop = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 22)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(69, 13)
        Me.Label14.TabIndex = 26
        Me.Label14.Text = "Vendor Code"
        '
        'TxtTinNo
        '
        Me.TxtTinNo.Location = New System.Drawing.Point(108, 201)
        Me.TxtTinNo.Name = "TxtTinNo"
        Me.TxtTinNo.Size = New System.Drawing.Size(284, 20)
        Me.TxtTinNo.TabIndex = 25
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 204)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(42, 13)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "Tin No."
        '
        'TxtUpttNo
        '
        Me.TxtUpttNo.Location = New System.Drawing.Point(108, 175)
        Me.TxtUpttNo.Name = "TxtUpttNo"
        Me.TxtUpttNo.Size = New System.Drawing.Size(284, 20)
        Me.TxtUpttNo.TabIndex = 19
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 178)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(47, 13)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "S.T. No."
        '
        'TxtEmail
        '
        Me.TxtEmail.Location = New System.Drawing.Point(108, 149)
        Me.TxtEmail.Name = "TxtEmail"
        Me.TxtEmail.Size = New System.Drawing.Size(284, 20)
        Me.TxtEmail.TabIndex = 17
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 152)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(36, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "E-Mail"
        '
        'TxtPhoneO
        '
        Me.TxtPhoneO.Location = New System.Drawing.Point(364, 123)
        Me.TxtPhoneO.Name = "TxtPhoneO"
        Me.TxtPhoneO.Size = New System.Drawing.Size(151, 20)
        Me.TxtPhoneO.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(279, 126)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Phone No.(Off)"
        '
        'TxtPhoneR
        '
        Me.TxtPhoneR.Location = New System.Drawing.Point(108, 123)
        Me.TxtPhoneR.Name = "TxtPhoneR"
        Me.TxtPhoneR.Size = New System.Drawing.Size(165, 20)
        Me.TxtPhoneR.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 126)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Phone No.(Res)"
        '
        'TxtMobile
        '
        Me.TxtMobile.Location = New System.Drawing.Point(384, 97)
        Me.TxtMobile.Name = "TxtMobile"
        Me.TxtMobile.Size = New System.Drawing.Size(131, 20)
        Me.TxtMobile.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(340, 100)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Mobile"
        '
        'TxtPin
        '
        Me.TxtPin.Location = New System.Drawing.Point(247, 97)
        Me.TxtPin.Name = "TxtPin"
        Me.TxtPin.Size = New System.Drawing.Size(87, 20)
        Me.TxtPin.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(219, 100)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(22, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Pin"
        '
        'TxtCity
        '
        Me.TxtCity.Location = New System.Drawing.Point(108, 97)
        Me.TxtCity.Name = "TxtCity"
        Me.TxtCity.Size = New System.Drawing.Size(105, 20)
        Me.TxtCity.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "City*"
        '
        'TxtAddress
        '
        Me.TxtAddress.Location = New System.Drawing.Point(108, 71)
        Me.TxtAddress.Name = "TxtAddress"
        Me.TxtAddress.Size = New System.Drawing.Size(407, 20)
        Me.TxtAddress.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Complete Address*"
        '
        'TxtName
        '
        Me.TxtName.Location = New System.Drawing.Point(108, 45)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(241, 20)
        Me.TxtName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Vendor Name*"
        '
        'GrpButton
        '
        Me.GrpButton.Controls.Add(Me.BtnCancel)
        Me.GrpButton.Controls.Add(Me.BtnUpdate)
        Me.GrpButton.Controls.Add(Me.BtnClose)
        Me.GrpButton.Controls.Add(Me.BtnSave)
        Me.GrpButton.Location = New System.Drawing.Point(823, 12)
        Me.GrpButton.Name = "GrpButton"
        Me.GrpButton.Size = New System.Drawing.Size(103, 232)
        Me.GrpButton.TabIndex = 7
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
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(15, 19)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(72, 26)
        Me.BtnSave.TabIndex = 0
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'GrpSearch
        '
        Me.GrpSearch.Controls.Add(Me.Label4)
        Me.GrpSearch.Controls.Add(Me.CmbFieldToSearch)
        Me.GrpSearch.Controls.Add(Me.TxtLikeValue)
        Me.GrpSearch.Controls.Add(Me.Label11)
        Me.GrpSearch.Location = New System.Drawing.Point(12, 250)
        Me.GrpSearch.Name = "GrpSearch"
        Me.GrpSearch.Size = New System.Drawing.Size(914, 50)
        Me.GrpSearch.TabIndex = 9
        Me.GrpSearch.TabStop = False
        Me.GrpSearch.Text = "Search By"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(549, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "Search In"
        '
        'CmbFieldToSearch
        '
        Me.CmbFieldToSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbFieldToSearch.FormattingEnabled = True
        Me.CmbFieldToSearch.Location = New System.Drawing.Point(608, 19)
        Me.CmbFieldToSearch.Name = "CmbFieldToSearch"
        Me.CmbFieldToSearch.Size = New System.Drawing.Size(121, 21)
        Me.CmbFieldToSearch.Sorted = True
        Me.CmbFieldToSearch.TabIndex = 32
        '
        'TxtLikeValue
        '
        Me.TxtLikeValue.Location = New System.Drawing.Point(810, 19)
        Me.TxtLikeValue.Name = "TxtLikeValue"
        Me.TxtLikeValue.Size = New System.Drawing.Size(88, 20)
        Me.TxtLikeValue.TabIndex = 31
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(735, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(69, 13)
        Me.Label11.TabIndex = 30
        Me.Label11.Text = "Starting From"
        '
        'GrpVendorDetail
        '
        Me.GrpVendorDetail.Controls.Add(Me.GrdVendorDetail)
        Me.GrpVendorDetail.Location = New System.Drawing.Point(12, 306)
        Me.GrpVendorDetail.Name = "GrpVendorDetail"
        Me.GrpVendorDetail.Size = New System.Drawing.Size(914, 289)
        Me.GrpVendorDetail.TabIndex = 10
        Me.GrpVendorDetail.TabStop = False
        Me.GrpVendorDetail.Text = "Vendors"
        '
        'GrdVendorDetail
        '
        Me.GrdVendorDetail.AllowUserToAddRows = False
        Me.GrdVendorDetail.AllowUserToDeleteRows = False
        Me.GrdVendorDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GrdVendorDetail.Location = New System.Drawing.Point(7, 19)
        Me.GrdVendorDetail.Name = "GrdVendorDetail"
        Me.GrdVendorDetail.ReadOnly = True
        Me.GrdVendorDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdVendorDetail.Size = New System.Drawing.Size(901, 264)
        Me.GrdVendorDetail.TabIndex = 5
        '
        'FrmVendorMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.BtnClose
        Me.ClientSize = New System.Drawing.Size(939, 607)
        Me.ControlBox = False
        Me.Controls.Add(Me.GrpVendorDetail)
        Me.Controls.Add(Me.GrpSearch)
        Me.Controls.Add(Me.GrpButton)
        Me.Controls.Add(Me.GrpVendor)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmVendorMaster"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Vendor Master"
        Me.GrpVendor.ResumeLayout(False)
        Me.GrpVendor.PerformLayout()
        Me.GrpManufacturers.ResumeLayout(False)
        Me.GrpManufacturers.PerformLayout()
        CType(Me.GrdManufacturers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpButton.ResumeLayout(False)
        Me.GrpSearch.ResumeLayout(False)
        Me.GrpSearch.PerformLayout()
        Me.GrpVendorDetail.ResumeLayout(False)
        CType(Me.GrdVendorDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpVendor As System.Windows.Forms.GroupBox
    Friend WithEvents TxtVendorCode As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TxtTinNo As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtUpttNo As System.Windows.Forms.TextBox
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
    Friend WithEvents GrpManufacturers As System.Windows.Forms.GroupBox
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CmbManufacturers As System.Windows.Forms.ComboBox
    Friend WithEvents GrdManufacturers As System.Windows.Forms.DataGridView
    Friend WithEvents GrpButton As System.Windows.Forms.GroupBox
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnUpdate As System.Windows.Forms.Button
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents GrpSearch As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CmbFieldToSearch As System.Windows.Forms.ComboBox
    Friend WithEvents TxtLikeValue As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GrpVendorDetail As System.Windows.Forms.GroupBox
    Friend WithEvents GrdVendorDetail As System.Windows.Forms.DataGridView
    Friend WithEvents Label15 As System.Windows.Forms.Label

End Class
