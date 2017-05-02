Imports System.Windows.Forms

Public Class FrmBranchMaster

#Region "Local variables and Constants"

    Dim editRow As DataGridViewRow = Nothing

    Enum Index
        GrpBranch
        TxtBranchCode
        TxtName
        TxtAddress
        TxtCity
        TxtState
        TxtPin
        TxtContactPerson
        TxtPhone
        TxtFax
        TxtEmail
        TxtUpttNo
        TxtTinNo
        GrpButton
        BtnAdd
        BtnUpdate
        BtnCancel
        BtnClose
        GrpBranchDetails
        GrdBranchDetails
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

    Private Sub FrmBranchMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetControls()
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub GrdBranchDetails_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GrdBranchDetails.CellDoubleClick
        Try
            If e.RowIndex < 0 Then Exit Try

            editRow = GrdBranchDetails.Rows(e.RowIndex)
            With editRow
                TxtBranchCode.Text = .Cells(cBranchCode).Value
                TxtName.Text = .Cells(cName).Value
                TxtAddress.Text = .Cells(cAddress).Value
                TxtCity.Text = .Cells(cCity).Value
                TxtPin.Text = .Cells(cPin).Value
                TxtContactPerson.Text = .Cells(cContactPerson).Value
                TxtPhone.Text = .Cells(cPhone).Value
                TxtFax.Text = .Cells(cFax).Value
                TxtEmail.Text = .Cells(cEmail).Value
                TxtState.Text = .Cells(cState).Value
                TxtUpttNo.Text = .Cells(cUpTtNo).Value
                TxtTinNo.Text = .Cells(cTinNo).Value
            End With

            BtnAdd.Enabled = False
            BtnUpdate.Enabled = True
            BtnCancel.Enabled = True

            TxtName.Focus()

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub GrdBranchDetails_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GrdBranchDetails.KeyDown
        If e.KeyCode = Keys.Tab Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Try
            If ValidateValues() = False Then Exit Sub

            Dim branch As New ClsBranchMaster
            With branch
                .Name = TxtName.Text
                .Address = TxtAddress.Text
                .City = TxtCity.Text
                .State = TxtState.Text
                .Pin = TxtPin.Text
                .ContactPerson = TxtContactPerson.Text
                .Phone = TxtPhone.Text
                .Fax = TxtFax.Text
                .EMail = TxtEmail.Text
                .UpTtNo = TxtUpttNo.Text
                .TinNo = TxtTinNo.Text
                .UserId = gUser.LoginName
                .DateOn = Now
            End With

            InsertIntoBranchMaster(Me.Name, branch)
            LoadGridValues()

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNew()
    End Sub

    Private Sub BtnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUpdate.Click
        Try
            If editRow Is Nothing Then Exit Try
            If ValidateValues() = False Then Exit Sub

            Dim branch As New ClsBranchMaster
            With branch
                .Id = editRow.Cells(cId).Value
                .UserId = editRow.Cells(cUserId).Value
                .DateOn = editRow.Cells(cDateOn).Value
                .BranchCode = TxtBranchCode.Text
                .Name = TxtName.Text
                .Address = TxtAddress.Text
                .City = TxtCity.Text
                .Pin = TxtPin.Text
                .ContactPerson = TxtContactPerson.Text
                .Phone = TxtPhone.Text
                .Fax = TxtFax.Text
                .EMail = TxtEmail.Text
                .State = TxtState.Text
                .UpTtNo = TxtUpttNo.Text
                .TinNo = TxtTinNo.Text
            End With

            If UpdateBranchMaster(Me.Name, branch) <> EnResult.Change Then Exit Sub

            With editRow
                .Cells(cBranchCode).Value = TxtBranchCode.Text
                .Cells(cName).Value = TxtName.Text
                .Cells(cAddress).Value = TxtAddress.Text
                .Cells(cCity).Value = TxtCity.Text
                .Cells(cPin).Value = TxtPin.Text
                .Cells(cContactPerson).Value = TxtContactPerson.Text
                .Cells(cPhone).Value = TxtPhone.Text
                .Cells(cFax).Value = TxtFax.Text
                .Cells(cEmail).Value = TxtEmail.Text
                .Cells(cState).Value = TxtState.Text
                .Cells(cUpTtNo).Value = TxtUpttNo.Text
                .Cells(cTinNo).Value = TxtTinNo.Text
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        ResetControlsToAddNew()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        ResetControlsToAddNew()
    End Sub

    Private Sub TxtPin_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPin.KeyPress
        e.Handled = Check_Numeric(e.KeyChar)
    End Sub

    Private Sub EnterKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtUpttNo.KeyDown, TxtTinNo.KeyDown, TxtState.KeyDown, TxtPin.KeyDown, TxtPhone.KeyDown, TxtName.KeyDown, TxtFax.KeyDown, TxtEmail.KeyDown, TxtContactPerson.KeyDown, TxtCity.KeyDown, TxtBranchCode.KeyDown, TxtAddress.KeyDown
        If e.KeyCode = Keys.Enter Then Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
    End Sub

#End Region

#Region "Private Functions"

    Private Sub SetControls()
        SetTabIndex()
        SetGrid()
        LoadGridValues()

        ResetControlsToAddNew()
    End Sub

    Private Sub SetTabIndex()
        GrpBranch.TabIndex = Index.GrpBranch
        TxtBranchCode.TabIndex = Index.TxtBranchCode
        TxtTinNo.TabIndex = Index.TxtTinNo
        TxtUpttNo.TabIndex = Index.TxtUpttNo
        TxtEmail.TabIndex = Index.TxtEmail
        TxtFax.TabIndex = Index.TxtFax
        TxtPhone.TabIndex = Index.TxtPhone
        TxtContactPerson.TabIndex = Index.TxtContactPerson
        TxtPin.TabIndex = Index.TxtPin
        TxtState.TabIndex = Index.TxtState
        TxtCity.TabIndex = Index.TxtCity
        TxtAddress.TabIndex = Index.TxtAddress
        TxtName.TabIndex = Index.TxtName
        GrpButton.TabIndex = Index.GrpButton
        BtnAdd.TabIndex = Index.BtnAdd
        BtnUpdate.TabIndex = Index.BtnUpdate
        BtnCancel.TabIndex = Index.BtnCancel
        BtnClose.TabIndex = Index.BtnClose
        GrpBranchDetails.TabIndex = Index.GrpBranchDetails
        GrdBranchDetails.TabIndex = Index.GrdBranchDetails
    End Sub

    Private Sub SetGrid()
        With GrdBranchDetails
            Dim colCount As Integer = 14
            .RowHeadersVisible = False
            Dim x As Integer
            For x = 0 To colCount
                Select Case x
                    Case 0
                        Dim index As Integer = .Columns.Add(cId, cId)
                        .Columns(index).Visible = False

                    Case 1
                        Dim index As Integer = .Columns.Add(cBranchCode, "B. Code")
                        .Columns(index).Width = 70

                    Case 2
                        Dim index As Integer = .Columns.Add(cName, cName)
                        .Columns(index).Width = 160

                    Case 3
                        Dim index As Integer = .Columns.Add(cAddress, cAddress)
                        .Columns(index).Width = 200

                    Case 4
                        Dim index As Integer = .Columns.Add(cCity, cCity)
                        .Columns(index).Width = 90

                    Case 5
                        Dim index As Integer = .Columns.Add(cPin, cPin)
                        .Columns(index).Width = 90

                    Case 6
                        Dim index As Integer = .Columns.Add(cContactPerson, "Contact Person")
                        .Columns(index).Width = 120

                    Case 7
                        Dim index As Integer = .Columns.Add(cPhone, cPhone)
                        .Columns(index).Width = 120

                    Case 8
                        Dim index As Integer = .Columns.Add(cFax, cFax)
                        .Columns(index).Width = 120

                    Case 9
                        Dim index As Integer = .Columns.Add(cEmail, "E-Mail")
                        .Columns(index).Width = 120

                    Case 10
                        Dim index As Integer = .Columns.Add(cState, cState)
                        .Columns(index).Width = 120

                    Case 11
                        Dim index As Integer = .Columns.Add(cUpTtNo, "S.T. No.")
                        .Columns(index).Width = 120

                    Case 12
                        Dim index As Integer = .Columns.Add(cTinNo, "Tin No.")
                        .Columns(index).Width = 120

                    Case 13
                        Dim index As Integer = .Columns.Add(cUserId, cUserId)
                        .Columns(index).Visible = False

                    Case 14
                        Dim index As Integer = .Columns.Add(cDateOn, cDateOn)
                        .Columns(index).Visible = False

                End Select
            Next
        End With
    End Sub

    Private Sub LoadGridValues()
        Try
            GrdBranchDetails.Rows.Clear()
            Dim branches() As ClsBranchMaster = GetAllBranchMaster(Me.Name)
            If branches Is Nothing Then Exit Try

            Dim branch As ClsBranchMaster
            For Each branch In branches
                InsertIntoGrid(branch)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub InsertIntoGrid(ByRef branchObj As ClsBranchMaster)
        Try
            If branchObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdBranchDetails.Rows.Add
            With GrdBranchDetails.Rows(rowIndex)
                .Cells(cId).Value = branchObj.Id
                .Cells(cBranchCode).Value = branchObj.BranchCode
                .Cells(cName).Value = branchObj.Name
                .Cells(cAddress).Value = branchObj.Address
                .Cells(cCity).Value = branchObj.City
                .Cells(cPin).Value = branchObj.Pin
                .Cells(cContactPerson).Value = branchObj.ContactPerson
                .Cells(cPhone).Value = branchObj.Phone
                .Cells(cFax).Value = branchObj.Fax
                .Cells(cEmail).Value = branchObj.EMail
                .Cells(cState).Value = branchObj.State
                .Cells(cUpTtNo).Value = branchObj.UpTtNo
                .Cells(cTinNo).Value = branchObj.TinNo
                .Cells(cUserId).Value = branchObj.UserId
                .Cells(cDateOn).Value = branchObj.DateOn
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
                ErrorInData("Please enter branch name.", TxtName)
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
        TxtBranchCode.Text = ""
        TxtName.Text = ""
        TxtAddress.Text = ""
        TxtCity.Text = ""
        TxtState.Text = ""
        TxtPin.Text = ""
        TxtContactPerson.Text = ""
        TxtPhone.Text = ""
        TxtFax.Text = ""
        TxtEmail.Text = ""
        TxtUpttNo.Text = ""
        TxtTinNo.Text = ""
        BtnAdd.Enabled = True
        BtnUpdate.Enabled = False
        BtnCancel.Enabled = False

        editRow = Nothing

        TxtName.Focus()
    End Sub

#End Region

End Class
