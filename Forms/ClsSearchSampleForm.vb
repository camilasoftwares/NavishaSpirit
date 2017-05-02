Public Class ClsSearchSampleForm
    Inherits FrmSearchToAll

#Region "Local variables and Constants"

    Private Const lcSampleCode As String = "Sample Code"
    Private Const lcCustomerName As String = "Customer Name"
    'Private Const lcDoctorName As String = "Doctor Name"
    Private Const lcSampleDate As String = "Issued S. Date"
    'Private Const lcStatus As String = "Status"

    Dim lDoctors() As ClsDoctorMaster = Nothing
    Dim lCustomers() As ClsCustomerMaster = Nothing
    Dim lSelectedId As Long = cInvalidId

#End Region

#Region "Required functions to initialize the object"

    Private Sub ClsSearchSampleForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyBase.SetChildClassObj(Me)
        LoadDoctors()
        LoadCustomers()
    End Sub

#End Region

#Region "Protected Functions"

    Protected Overrides Sub GridRowDoubleClicked(ByRef row As System.Windows.Forms.DataGridViewRow)
        Try
            If row Is Nothing Then Exit Try

            Dim id As Long = row.Cells(cId).Value
            If id > 0 Then
                lSelectedId = id
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Protected Overrides Sub LoadGridValues()
        Try
            GrdItems.Rows.Clear()

            Dim samples() As ClsSampleMaster = Nothing
            Dim field As String = CmbSearchOnField.Text
            If field = lcSampleDate Then
                Dim str() As String = GetDateValues()
                Dim temp As String = str(0) + str(1) + str(2)
                If temp.Trim = "" Then
                    samples = GetAllSampleMaster(Me.Name)
                ElseIf field = lcSampleDate Then
                    samples = GetAllSampleMasterLikeSampleDate(Me.Name, str(0), str(1), str(2))
                End If
            Else
                Dim str As String = TxtSearchValue.Text.Trim
                If str = "" Then
                    samples = GetAllSampleMaster(Me.Name)
                ElseIf field = lcSampleCode Then
                    samples = GetAllSampleMasterSampleCodeLike(Me.Name, str)
                ElseIf field = lcCustomerName Then
                    samples = GetAllSampleMasterCustomerLike(Me.Name, str)
                    'ElseIf field = lcDoctorName Then
                    '    sample = GetAllSampleMasterDoctorLike(Me.Name, str)
                End If
            End If

            If samples Is Nothing Then Exit Try

            Dim sample As ClsSampleMaster
            For Each sample In samples
                InsertIntoGrid(sample)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Protected Overrides Sub SetGrid()
        With GrdItems
            Dim colCount As Integer = 7
            .RowHeadersVisible = False
            Dim colWidth As Integer = 150
            Dim x As Integer
            For x = 0 To colCount
                Select Case x
                    Case 0
                        Dim index As Integer = .Columns.Add(cId, cId)
                        .Columns(index).Visible = False

                    Case 1
                        Dim index As Integer = .Columns.Add(cSampleCode, "Sample Code")
                        .Columns(index).Width = colWidth

                    Case 2
                        Dim index As Integer = .Columns.Add(cSampleDate, "Sample Date")
                        .Columns(index).Width = colWidth
                        .Columns(index).DefaultCellStyle.Format = "dd/MM/yyyy"

                    Case 3
                        Dim index As Integer = .Columns.Add(cCustomerName, "Customer Name")
                        .Columns(index).Width = 300

                    Case 4
                        'Dim index As Integer = .Columns.Add(cDoctorId, cDoctorId)
                        '.Columns(index).Visible = False

                    Case 5
                        'Dim index As Integer = .Columns.Add(cDoctorName, "Doctor Name")
                        '.Columns(index).Width = 300

                    Case 6
                        Dim index As Integer = .Columns.Add(cMode, "Status")
                        '.Columns(index).Width = colWidth
                        .Columns(index).Visible = False

                    Case 7
                        Dim index As Integer = .Columns.Add(cCustomerId, cCustomerId)
                        .Columns(index).Visible = False

                End Select
            Next
        End With
    End Sub

    Protected Overrides Sub CloseObj()
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Protected Overrides Sub FillSearchValues()
        Try
            With CmbSearchOnField.Items
                .Clear()

                .Add(lcSampleCode)
                .Add(lcCustomerName)
                '.Add(lcDoctorName)
                .Add(lcSampleDate)
            End With

            CmbSearchOnField.SelectedIndex = 0

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Protected Overrides Sub CmbSearchOnFieldIndexChanged()
        Try
            If CmbSearchOnField.Text = lcSampleDate Then
                PnlDate.Visible = True
                TxtSearchValue.Visible = False
            Else
                TxtSearchValue.Visible = True
                PnlDate.Visible = False
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

#End Region

#Region "Public Functions"

    Public Function GetSelectedId() As Long
        Return lSelectedId
    End Function

#End Region

#Region "Private Functions"

    Private Sub InsertIntoGrid(ByRef sampleObj As ClsSampleMaster)
        Try
            If sampleObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdItems.Rows.Add
            With GrdItems.Rows(rowIndex)
                .Cells(cId).Value = sampleObj.Id
                .Cells(cSampleCode).Value = sampleObj.SampleCode
                .Cells(cSampleDate).Value = sampleObj.SampleDate
                '.Cells(cDoctorId).Value = sampleObj.DoctorId
                .Cells(cMode).Value = sampleObj.Mode
                .Cells(cCustomerId).Value = sampleObj.CustomerId
                .Cells(cCustomerName).Value = GetCustomerName(.Cells(cCustomerId).Value)
                '.Cells(cDoctorName).Value = GetDoctorName(.Cells(cDoctorId).Value)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadDoctors()
        lDoctors = GetAllDoctorMaster(Me.Name)
    End Sub

    Private Sub LoadCustomers()
        lCustomers = GetAllCustomerMaster(Me.Name)
    End Sub

    Private Function GetCustomerName(ByVal id As Integer) As String
        Dim result As String = ""
        Try
            If lCustomers Is Nothing Then Exit Try

            Dim customer As ClsCustomerMaster
            For Each customer In lCustomers
                If customer.Id = id Then
                    result = customer.Name
                    Exit Try
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    Private Function GetDoctorName(ByVal id As Integer) As String
        Dim result As String = ""
        Try
            If lDoctors Is Nothing Then Exit Try

            Dim doctor As ClsDoctorMaster
            For Each doctor In lDoctors
                If doctor.Id = id Then
                    result = doctor.Name
                    Exit Try
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

#End Region

End Class
