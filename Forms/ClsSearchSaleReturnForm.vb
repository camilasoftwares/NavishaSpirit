Public Class ClsSearchSaleReturnForm
    Inherits FrmSearchToAll

#Region "Local variables and Constants"

    Private Const lcSaleReturnCode As String = "Sale Return Code"
    'Private Const lcSaleCode As String = "Sale Code"
    Private Const lcCustomerName As String = "Customer Name"
    'Private Const lcDoctorName As String = "Doctor Name"
    Private Const lcSaleReturnDate As String = "Sale Return Date"

    Dim lDoctors() As ClsDoctorMaster = Nothing
    Dim lCustomers() As ClsCustomerMaster = Nothing
    Dim lSales() As ClsSalesMaster = Nothing
    Dim lSelectedId As Long = cInvalidId

#End Region

#Region "Required functions to initialize the object"

    Private Sub ClsSearchSaleReturnForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyBase.SetChildClassObj(Me)
        LoadDoctors()
        LoadCustomers()
        LoadSales()
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

            Dim saleReturns() As ClsSalesReturnMaster = Nothing
            Dim field As String = CmbSearchOnField.Text
            If field = lcSaleReturnDate Then
                Dim str() As String = GetDateValues()
                Dim temp As String = str(0) + str(1) + str(2)
                If temp.Trim = "" Then
                    saleReturns = GetAllSalesReturnMaster(Me.Name)
                ElseIf field = lcSaleReturnDate Then
                    saleReturns = GetAllSalesReturnMasterLikeReturnDate(Me.Name, str(0), str(1), str(2))
                End If
            Else
                Dim str As String = TxtSearchValue.Text.Trim
                If str = "" Then
                    saleReturns = GetAllSalesReturnMaster(Me.Name)
                ElseIf field = lcSaleReturnCode Then
                    saleReturns = GetAllSalesReturnMasterReturnCodeLike(Me.Name, str)
                ElseIf field = lcCustomerName Then
                    saleReturns = GetAllSalesReturnMasterCustomerLike(Me.Name, str)
                    'ElseIf field = lcDoctorName Then
                    '    saleReturns = GetAllSalesReturnMasterDoctorLike(Me.Name, str)
                    'ElseIf field = lcSaleCode Then
                    '    saleReturns = GetAllSalesReturnMasterSaleCodeLike(Me.Name, str)
                End If
            End If

            If saleReturns Is Nothing Then Exit Try

            Dim saleReturn As ClsSalesReturnMaster
            For Each saleReturn In saleReturns
                InsertIntoGrid(saleReturn)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Protected Overrides Sub SetGrid()
        With GrdItems
            Dim colCount As Integer = 9
            .RowHeadersVisible = False
            Dim colWidth As Integer = 120
            Dim x As Integer
            For x = 0 To colCount
                Select Case x
                    Case 0
                        Dim index As Integer = .Columns.Add(cSalesReturnCode, "Sale Return Code")
                        .Columns(index).Width = colWidth

                    Case 1
                        Dim index As Integer = .Columns.Add(cSaleCode, "Sale Code")
                        .Columns(index).Width = colWidth
                        .Columns(index).Visible = False

                    Case 2
                        Dim index As Integer = .Columns.Add(cReturnDate, "Return Date")
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
                        '.Columns(index).Width = 210

                    Case 6
                        Dim index As Integer = .Columns.Add(cStatus, "Status")
                        .Columns(index).Width = colWidth
                        .Columns(index).Visible = False

                    Case 7
                        Dim index As Integer = .Columns.Add(cCustomerId, cCustomerId)
                        .Columns(index).Visible = False

                    Case 8
                        Dim index As Integer = .Columns.Add(cId, cId)
                        .Columns(index).Visible = False

                    Case 9
                        Dim index As Integer = .Columns.Add(cSaleId, cSaleId)
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

                .Add(lcSaleReturnCode)
                .Add(lcCustomerName)
                '.Add(lcDoctorName)
                '.Add(lcSaleCode)
                .Add(lcSaleReturnDate)
            End With

            CmbSearchOnField.SelectedIndex = 0

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Protected Overrides Sub CmbSearchOnFieldIndexChanged()
        Try
            If CmbSearchOnField.Text = lcSaleReturnDate Then
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

    Private Sub InsertIntoGrid(ByRef saleReturnObj As ClsSalesReturnMaster)
        Try
            If saleReturnObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdItems.Rows.Add
            With GrdItems.Rows(rowIndex)
                .Cells(cId).Value = saleReturnObj.Id
                .Cells(cSalesReturnCode).Value = saleReturnObj.SalesReturnCode
                .Cells(cReturnDate).Value = saleReturnObj.ReturnDate
                '.Cells(cDoctorId).Value = saleReturnObj.DoctorId
                .Cells(cStatus).Value = saleReturnObj.Status
                .Cells(cCustomerId).Value = saleReturnObj.CustomerId
                .Cells(cCustomerName).Value = GetCustomerName(.Cells(cCustomerId).Value)
                '.Cells(cDoctorName).Value = GetDoctorName(.Cells(cDoctorId).Value)
                .Cells(cSaleId).Value = saleReturnObj.SaleId
                .Cells(cSaleCode).Value = GetSaleCode(.Cells(cSaleId).Value)
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

    Private Sub LoadSales()
        lSales = GetAllSalesMaster(Me.Name)
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

    Private Function GetSaleCode(ByVal id As Long) As String
        Dim result As String = ""
        Try
            If lSales Is Nothing Then Exit Try

            Dim sale As ClsSalesMaster
            For Each sale In lSales
                If sale.Id = id Then
                    result = sale.SaleCode
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
