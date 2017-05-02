Imports System.Windows.Forms
Imports AIMS.Author

Public Class FrmCompanyInfo

#Region "Local variables and Constants"

    Enum Index
        GrpInfo
        TxtName
        TxtSubTitle
        TxtAddress
        TxtCity
        TxtState
        TxtPin
        TxtContactPerson
        TxtPhone
        TxtFax
        TxtEmail
        TxtUpttNo
        TxtCstNo
        TxtDlNo
        TxtTinNo
        GrpButton
        BtnOk
        BtnClose
    End Enum

#End Region

#Region "Control Functions"

    Private Sub Help(ByVal sender As Object, ByVal hlpEvent As System.Windows.Forms.HelpEventArgs) Handles MyBase.HelpRequested
        Try
            Dim obj As Object = Me.Owner
            obj.ShowHelp()
        Catch ex As Exception
        End Try

        hlpEvent.Handled = True
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Try
            If AndedTheString(gUser.AuthorizationNo, Authorization.CompanyInformation_NoUpdate) = True Then Exit Sub
            If ValidateValues() = False Then Exit Try

            Dim compInfo As New ClsCompanyInfo

            With compInfo
                .TinNo = TxtTinNo.Text
                .DlNo = cInvalidId 'TxtDlNo.Text
                .CstNo = TxtCstNo.Text
                .UpTtNo = TxtUpttNo.Text
                .EMail = TxtEmail.Text
                .Fax = TxtFax.Text
                .Phone = TxtPhone.Text
                .ContactPerson = TxtContactPerson.Text
                .Pin = TxtPin.Text
                .State = TxtState.Text
                .City = TxtCity.Text
                .Address = TxtAddress.Text
                .SubTitle = TxtSubTitle.Text
                .Name = TxtName.Text
                .Logo = PicLogo.Image
            End With

            If UpdateCompanyInfo(Me.Name, compInfo) <> EnResult.Change Then Exit Sub

            MsgBox("Successfully Updated.", MsgBoxStyle.Information, "Updated")

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub FrmCompanyInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

    Private Sub TxtPin_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPin.KeyPress
        e.Handled = Check_Numeric(e.KeyChar)
    End Sub

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtUpttNo.KeyDown, TxtTinNo.KeyDown, TxtState.KeyDown, TxtPin.KeyDown, TxtPhone.KeyDown, TxtName.KeyDown, TxtFax.KeyDown, TxtEmail.KeyDown, TxtCstNo.KeyDown, TxtContactPerson.KeyDown, TxtCity.KeyDown, TxtAddress.KeyDown, TxtSubTitle.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub PicLogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicLogo.Click
        Dim flDlg As New OpenFileDialog
        flDlg.InitialDirectory = "c:\"
        flDlg.Filter = "Image File (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif"
        If flDlg.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim imagePath As String = flDlg.FileName
            If imagePath.Trim = "" Then Exit Sub

            Dim newImg As Bitmap = New Bitmap(imagePath)
            PicLogo.SizeMode = PictureBoxSizeMode.StretchImage
            PicLogo.Image = newImg

        End If

        flDlg = Nothing
    End Sub

#End Region

#Region "Private Functions"

    Private Sub SetControls()
        PicLogo.SizeMode = PictureBoxSizeMode.StretchImage
        SetTabIndex()
        LoadValues()
    End Sub

    Private Sub SetTabIndex()
        GrpInfo.TabIndex = Index.GrpInfo
        TxtTinNo.TabIndex = Index.TxtTinNo
        'TxtDlNo.TabIndex = Index.TxtDlNo
        TxtCstNo.TabIndex = Index.TxtCstNo
        TxtUpttNo.TabIndex = Index.TxtUpttNo
        TxtEmail.TabIndex = Index.TxtEmail
        TxtFax.TabIndex = Index.TxtFax
        TxtPhone.TabIndex = Index.TxtPhone
        TxtContactPerson.TabIndex = Index.TxtContactPerson
        TxtPin.TabIndex = Index.TxtPin
        TxtState.TabIndex = Index.TxtState
        TxtCity.TabIndex = Index.TxtCity
        TxtAddress.TabIndex = Index.TxtAddress
        TxtSubTitle.TabIndex = Index.TxtSubTitle
        TxtName.TabIndex = Index.TxtName
        GrpButton.TabIndex = Index.GrpButton
        BtnClose.TabIndex = Index.BtnClose
        BtnOk.TabIndex = Index.BtnOk
    End Sub

    Private Sub LoadValues()
        Try
            Dim compInfo As ClsCompanyInfo = GetCompanyInfo(Me.Name)
            If compInfo Is Nothing Then Exit Try

            With compInfo
                TxtTinNo.Text = .TinNo
                'TxtDlNo.Text = .DlNo
                TxtCstNo.Text = .CstNo
                TxtUpttNo.Text = .UpTtNo
                TxtEmail.Text = .EMail
                TxtFax.Text = .Fax
                TxtPhone.Text = .Phone
                TxtContactPerson.Text = .ContactPerson
                TxtPin.Text = .Pin
                TxtState.Text = .State
                TxtCity.Text = .City
                TxtAddress.Text = .Address
                TxtSubTitle.Text = .SubTitle
                TxtName.Text = .Name
                PicLogo.Image = .Logo
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Function ValidateValues() As Boolean
        Dim result As Boolean = False
        Try
            RemoveErrorIcon()

            If TxtName.Text.Trim = "" Then
                ErrorInData("Please enter company name.", TxtName)
                Exit Try
            End If

            If TxtAddress.Text.Trim = "" Then
                ErrorInData("Please enter address.", TxtAddress)
                Exit Try
            End If

            If TxtCity.Text.Trim = "" Then
                ErrorInData("Please enter city.", TxtCity)
                Exit Try
            End If

            If TxtEmail.Text.Trim <> "" And CheckEmailAddress(TxtEmail.Text.Trim) = False Then
                ErrorInData("Please enter E-Mail correctly.", TxtEmail)
                Exit Try
            End If

            result = True

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

#End Region

End Class
