Imports System.Windows.Forms
Imports AIMS.Author

Public Class FrmDoctorMaster

#Region "Local variables and Constants"

    Dim editRow As DataGridViewRow = Nothing
    Dim flagChange As Boolean = False

    Private Const lcName As String = "Name"
    Private Const lcAddress As String = "Address"
    Private Const lcCity As String = "City"
    Private Const lcMobile As String = "Mobile"
    Private Const lcPhoneR As String = "Phone Res."
    Private Const lcPhoneO As String = "Phone Off."
    'Private Const lcSpeciality As String = "Speciality"

    Enum Index
        GrpDoctor = 0
        TxtName
        CmbSpeciality
        TxtAddress
        TxtCity
        TxtPin
        TxtMobile
        TxtPhoneR
        TxtPhoneO
        TxtEmail
        GrpButton
        BtnAdd
        BtnUpdate
        BtnCancel
        BtnClose
        GrpSearch
        CmbFieldToSearch
        TxtLikeValue
        GrpDoctorDetails
        GrdDoctorDetails
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

    Private Sub FrmDoctorMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

    Private Sub CmbFieldToSearch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbFieldToSearch.SelectedIndexChanged
        TxtLikeValue.Text = ""
    End Sub

    Private Sub TxtLikeValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLikeValue.TextChanged
        Dim valueLike As String = TxtLikeValue.Text.Trim
        If valueLike = "" Then
            LoadGridValues()
        Else
            LoadGridValuesWithSearchLike(valueLike)
        End If
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Try
            If ValidateValues() = False Then Exit Sub

            Dim doctor As New ClsDoctorMaster
            With doctor
                .Name = TxtName.Text
                .SpecialityId = GetSelectedItemId(CmbSpeciality)
                .Address = TxtAddress.Text
                .City = TxtCity.Text
                .Pin = TxtPin.Text
                .Mobile = TxtMobile.Text
                .PhoneR = TxtPhoneR.Text
                .PhoneO = TxtPhoneO.Text
                .EMail = TxtEmail.Text
                .UserId = gUser.LoginName
                .DateOn = Now
            End With

            Dim id As Integer = InsertIntoDoctorMaster(Me.Name, doctor)
            If id > 0 Then
                flagChange = True
                doctor.Id = id
                InsertIntoGrid(doctor)
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNew()
    End Sub

    Private Sub BtnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUpdate.Click
        Try
            If editRow Is Nothing Then Exit Try
            If ValidateValues() = False Then Exit Sub

            Dim doctor As New ClsDoctorMaster
            With doctor
                .Id = editRow.Cells(cId).Value
                .UserId = editRow.Cells(cUserId).Value
                .DateOn = editRow.Cells(cDateOn).Value
                .SpecialityId = GetSelectedItemId(CmbSpeciality)
                .Name = TxtName.Text
                .Address = TxtAddress.Text
                .City = TxtCity.Text
                .Pin = TxtPin.Text
                .Mobile = TxtMobile.Text
                .PhoneR = TxtPhoneR.Text
                .PhoneO = TxtPhoneO.Text
                .EMail = TxtEmail.Text
            End With

            If UpdateDoctorMaster(Me.Name, doctor) <> EnResult.Change Then Exit Sub

            flagChange = True
            With editRow
                '.Cells(cSpecialityIdX).Value = GetSelectedItemId(CmbSpeciality)
                '.Cells(lcSpeciality).Value = CmbSpeciality.Text.Trim
                .Cells(cName).Value = TxtName.Text
                .Cells(cAddress).Value = TxtAddress.Text
                .Cells(cCity).Value = TxtCity.Text
                .Cells(cPin).Value = TxtPin.Text
                .Cells(cMobile).Value = TxtMobile.Text
                .Cells(cPhoneR).Value = TxtPhoneR.Text
                .Cells(cPhoneO).Value = TxtPhoneO.Text
                .Cells(cEmail).Value = TxtEmail.Text
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNew()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        ResetControlsToAddNew()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub GrdDoctorDetails_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdDoctorDetails.CellDoubleClick
        Try
            If e.RowIndex < 0 Then Exit Try
            'If AndedTheString(gUser.AuthorizationNo, Authorization.Doctors_NoUpdate) = True Then Exit Sub

            editRow = GrdDoctorDetails.Rows(e.RowIndex)
            With editRow
                'CmbSpeciality.Text = .Cells(lcSpeciality).Value
                TxtName.Text = .Cells(cName).Value
                TxtAddress.Text = .Cells(cAddress).Value
                TxtCity.Text = .Cells(cCity).Value
                TxtPin.Text = .Cells(cPin).Value
                TxtMobile.Text = .Cells(cMobile).Value
                TxtPhoneR.Text = .Cells(cPhoneR).Value
                TxtPhoneO.Text = .Cells(cPhoneO).Value
                TxtEmail.Text = .Cells(cEmail).Value
            End With

            BtnAdd.Enabled = False
            BtnUpdate.Enabled = True
            BtnCancel.Enabled = True
            GrpSearch.Enabled = False

            TxtName.Focus()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub GrdDoctorDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdDoctorDetails.KeyDown
        If e.KeyCode = Keys.Tab Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub TxtPin_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPin.KeyPress
        e.Handled = Check_Numeric(e.KeyChar)
    End Sub

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPin.KeyDown, TxtPhoneR.KeyDown, TxtPhoneO.KeyDown, TxtName.KeyDown, TxtMobile.KeyDown, TxtLikeValue.KeyDown, TxtEmail.KeyDown, TxtCity.KeyDown, TxtAddress.KeyDown, CmbSpeciality.KeyDown, CmbFieldToSearch.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

#End Region

#Region "Other Form Functionality"

    Private Sub LblAddSpeciality_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LblAddSpeciality.Click
        'If AndedTheString(gUser.AuthorizationNo, Authorization.Speciality) = False Then Exit Sub
        Try
            Dim frm As New FrmSpecialityMaster
            frm.ShowDialog(Me)
            If frm.Change = True Then LoadComboBoxValuesForSpeciality()

            frm.Dispose()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

#End Region

#Region "Public Functions"

    Public Function Change() As Boolean
        Return flagChange
    End Function

#End Region

#Region "Private Functions"

    Private Sub SetControls()
        With CmbFieldToSearch
            .Items.Clear()
            '.Items.Add(lcSpeciality)
            .Items.Add(lcName)
            .Items.Add(lcAddress)
            .Items.Add(lcCity)
            .Items.Add(lcMobile)
            .Items.Add(lcPhoneR)
            .Items.Add(lcPhoneO)
            .SelectedIndex = 0
        End With

        SetTabIndex()
        SetGrid()
        LoadComboBoxValuesForSpeciality()
        LoadGridValues()

        ResetControlsToAddNew()
    End Sub

    Private Sub SetTabIndex()
        GrpDoctor.TabIndex = Index.GrpDoctor
        CmbSpeciality.TabIndex = Index.CmbSpeciality
        TxtName.TabIndex = Index.TxtName
        TxtAddress.TabIndex = Index.TxtAddress
        TxtCity.TabIndex = Index.TxtCity
        TxtPin.TabIndex = Index.TxtPin
        TxtMobile.TabIndex = Index.TxtMobile
        TxtPhoneR.TabIndex = Index.TxtPhoneR
        TxtPhoneO.TabIndex = Index.TxtPhoneO
        TxtEmail.TabIndex = Index.TxtEmail
        GrpButton.TabIndex = Index.GrpButton
        BtnAdd.TabIndex = Index.BtnAdd
        BtnUpdate.TabIndex = Index.BtnUpdate
        BtnCancel.TabIndex = Index.BtnCancel
        BtnClose.TabIndex = Index.BtnClose
        GrpSearch.TabIndex = Index.GrpSearch
        CmbFieldToSearch.TabIndex = Index.CmbFieldToSearch
        TxtLikeValue.TabIndex = Index.TxtLikeValue
        GrpDoctorDetails.TabIndex = Index.GrpDoctorDetails
        GrdDoctorDetails.TabIndex = Index.GrdDoctorDetails
    End Sub

    Private Sub SetGrid()
        With GrdDoctorDetails
            Dim colCount As Integer = 12
            .RowHeadersVisible = False
            Dim x As Integer
            For x = 0 To colCount
                Select Case x
                    Case 0
                        Dim index As Integer = .Columns.Add(cId, cId)
                        .Columns(index).Visible = False

                    Case 1
                        Dim index As Integer = .Columns.Add(cName, cName)
                        .Columns(index).Width = 140

                    Case 2
                        'Dim index As Integer = .Columns.Add(cSpecialityId, cSpecialityId)
                        '.Columns(index).Visible = False

                    Case 3
                        'Dim index As Integer = .Columns.Add(lcSpeciality, lcSpeciality)
                        '.Columns(index).Width = 90

                    Case 4
                        Dim index As Integer = .Columns.Add(cAddress, cAddress)
                        .Columns(index).Width = 200

                    Case 5
                        Dim index As Integer = .Columns.Add(cCity, cCity)
                        .Columns(index).Width = 90

                    Case 6
                        Dim index As Integer = .Columns.Add(cPin, cPin)
                        .Columns(index).Width = 90

                    Case 7
                        Dim index As Integer = .Columns.Add(cMobile, cMobile)
                        .Columns(index).Width = 120

                    Case 8
                        Dim index As Integer = .Columns.Add(cPhoneR, "Phone Res.")
                        .Columns(index).Width = 120

                    Case 9
                        Dim index As Integer = .Columns.Add(cPhoneO, "Phone Off.")
                        .Columns(index).Width = 120

                    Case 10
                        Dim index As Integer = .Columns.Add(cEmail, "E-Mail")
                        .Columns(index).Width = 120

                    Case 11
                        Dim index As Integer = .Columns.Add(cUserId, cUserId)
                        .Columns(index).Visible = False

                    Case 12
                        Dim index As Integer = .Columns.Add(cDateOn, cDateOn)
                        .Columns(index).Visible = False

                End Select
            Next
        End With
    End Sub

    Private Sub LoadGridValues()
        Try
            GrdDoctorDetails.Rows.Clear()
            Dim doctors() As ClsDoctorMaster = GetAllDoctorMaster(Me.Name)
            If doctors Is Nothing Then Exit Try

            Dim doctor As ClsDoctorMaster
            For Each doctor In doctors
                InsertIntoGrid(doctor)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadGridValuesWithSearchLike(ByVal txtLike As String)
        Try
            GrdDoctorDetails.Rows.Clear()
            Dim doctors() As ClsDoctorMaster = Nothing
            Dim flagWithField As Boolean = True
            Dim field As String = ""
            If CmbFieldToSearch.Text = lcAddress Then
                field = cAddress
            ElseIf CmbFieldToSearch.Text = lcName Then
                field = cName
            ElseIf CmbFieldToSearch.Text = lcCity Then
                field = cCity
            ElseIf CmbFieldToSearch.Text = lcMobile Then
                field = cMobile
            ElseIf CmbFieldToSearch.Text = lcPhoneR Then
                field = cPhoneR
            ElseIf CmbFieldToSearch.Text = lcPhoneO Then
                field = cPhoneO
                'ElseIf CmbFieldToSearch.Text = lcSpeciality Then
                '    flagWithField = False
                '    doctors = GetAllDoctorMasterSpecialityLike(Me.Name, txtLike)
            End If

            If flagWithField = True Then doctors = GetAllDoctorMasterLike(Me.Name, field, txtLike)
            If doctors Is Nothing Then Exit Try

            Dim doctor As ClsdoctorMaster
            For Each doctor In doctors
                InsertIntoGrid(doctor)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub InsertIntoGrid(ByRef doctorObj As ClsDoctorMaster)
        Try
            If doctorObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrddoctorDetails.Rows.Add
            With GrddoctorDetails.Rows(rowIndex)
                .Cells(cId).Value = doctorObj.Id
                '.Cells(cSpecialityId).Value = doctorObj.SpecialityId
                .Cells(cName).Value = doctorObj.Name
                .Cells(cAddress).Value = doctorObj.Address
                .Cells(cCity).Value = doctorObj.City
                .Cells(cPin).Value = doctorObj.Pin
                .Cells(cMobile).Value = doctorObj.Mobile
                .Cells(cPhoneR).Value = doctorObj.PhoneR
                .Cells(cPhoneO).Value = doctorObj.PhoneO
                .Cells(cEmail).Value = doctorObj.EMail
                .Cells(cUserId).Value = doctorObj.UserId
                .Cells(cDateOn).Value = doctorObj.DateOn
                '.Cells(lcSpeciality).Value = GetTextForValue(CmbSpeciality, doctorObj.SpecialityId)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadComboBoxValuesForSpeciality()
        Try
            CmbSpeciality.Items.Clear()

            Dim specialities() As ClsSpecialityMaster = GetAllSpecialityMaster(Me.Name)
            If specialities Is Nothing Then Exit Try

            Dim speciality As ClsSpecialityMaster
            For Each speciality In specialities
                AddItemToComboBox(speciality.Name, speciality.Id, CmbSpeciality)
            Next

            If CmbSpeciality.Items.Count > 0 Then CmbSpeciality.SelectedIndex = 0

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Function ValidateValues() As Boolean
        Dim result As Boolean = False
        Try
            RemoveErrorIcon()

            If TxtName.Text.Trim = "" Then
                ErrorInData("Please enter Doctor name.", TxtName)
                Exit Try
            End If

            If CmbSpeciality.Text.Trim = "" Then
                ErrorInData("Please enter speciality.", CmbSpeciality)
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

    Private Sub ResetControlsToAddNew()
        If CmbFieldToSearch.Items.Count > 0 Then CmbFieldToSearch.SelectedIndex = 0
        If CmbSpeciality.Items.Count > 0 Then CmbSpeciality.SelectedIndex = 0
        TxtName.Text = ""
        TxtAddress.Text = ""
        TxtCity.Text = ""
        TxtPin.Text = ""
        TxtLikeValue.Text = ""
        TxtPhoneO.Text = ""
        TxtPhoneR.Text = ""
        TxtMobile.Text = ""
        TxtEmail.Text = ""
        BtnAdd.Enabled = True
        BtnUpdate.Enabled = False
        BtnCancel.Enabled = False
        GrpSearch.Enabled = True
        RemoveErrorIcon()

        editRow = Nothing

        TxtName.Focus()
    End Sub

#End Region

End Class
