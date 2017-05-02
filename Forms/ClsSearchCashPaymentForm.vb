Public Class ClsSearchCashPaymentForm
    Inherits FrmSearchToAll

#Region "Local variables and Constants"

    Private Const lcCashPaymentCode As String = "C.P. Code"
    Private Const lcPaymentTo As String = "Paid To"
    Private Const lcBillNo As String = "Bill No"
    Private Const lcCashPaymentDate As String = "C.P. Date"

    Private Const lcTo As String = "To"
    Private Const lcFrom As String = "From"

    Dim lAccountHeads() As ClsAccountHead = Nothing
    Dim lSelectedId As Long = cInvalidId

#End Region

#Region "Required functions to initialize the object"

    Private Sub ClsSearchCashPaymentForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyBase.SetChildClassObj(Me)
        LoadAccountHead()
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

            Dim cashPayments() As ClsCashPayment = Nothing
            Dim field As String = CmbSearchOnField.Text
            If field = lcCashPaymentDate Then
                Dim str() As String = GetDateValues()
                Dim temp As String = str(0) + str(1) + str(2)
                If temp.Trim = "" Then
                    cashPayments = GetAllCashPayments(Me.Name)
                ElseIf field = lcCashPaymentDate Then
                    cashPayments = GetAllCashPaymentLikePaymentDate(Me.Name, str(0), str(1), str(2))
                End If
            Else
                Dim str As String = TxtSearchValue.Text.Trim
                If str = "" Then
                    cashPayments = GetAllCashPayments(Me.Name)
                ElseIf field = lcCashPaymentCode Then
                    cashPayments = GetAllCashPaymentCodeLike(Me.Name, str)
                ElseIf field = lcBillNo Then
                    cashPayments = GetAllCashPaymentBillNoLike(Me.Name, str)
                ElseIf field = lcPaymentTo Then
                    cashPayments = GetAllCashPaymentPaymentToLike(Me.Name, str)
                End If
            End If

            If cashPayments Is Nothing Then Exit Try

            Dim cashPayment As ClsCashPayment
            For Each cashPayment In cashPayments
                InsertIntoGrid(cashPayment)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Protected Overrides Sub SetGrid()
        With GrdItems
            Dim colCount As Integer = 9
            .RowHeadersVisible = False
            Dim colWidth As Integer = 130
            Dim x As Integer
            For x = 0 To colCount
                Select Case x
                    Case 0
                        Dim index As Integer = .Columns.Add(cId, cId)
                        .Columns(index).Visible = False

                    Case 1
                        Dim index As Integer = .Columns.Add(cCode, "Code")
                        .Columns(index).Width = colWidth

                    Case 2
                        Dim index As Integer = .Columns.Add(cPaymentDate, "C.P. Date")
                        .Columns(index).Width = colWidth
                        .Columns(index).DefaultCellStyle.Format = "dd/MM/yyyy"

                    Case 3
                        Dim index As Integer = .Columns.Add(cToHeadId, cToHeadId)
                        .Columns(index).Visible = False

                    Case 4
                        Dim index As Integer = .Columns.Add(cAmount, cAmount)
                        .Columns(index).Width = colWidth
                        .Columns(index).DefaultCellStyle.Format = "0.00"

                    Case 5
                        Dim index As Integer = .Columns.Add(lcTo, lcTo)
                        .Columns(index).Width = colWidth

                    Case 6
                        Dim index As Integer = .Columns.Add(lcFrom, lcFrom)
                        .Columns(index).Width = colWidth

                    Case 7
                        Dim index As Integer = .Columns.Add(cBillNo, "Bill No")
                        .Columns(index).Width = colWidth

                    Case 8
                        Dim index As Integer = .Columns.Add(cRemark, cRemark)
                        .Columns(index).Width = colWidth

                    Case 9
                        Dim index As Integer = .Columns.Add(cFromHeadId, cFromHeadId)
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

                .Add(lcCashPaymentCode)
                .Add(lcBillNo)
                .Add(lcPaymentTo)
                .Add(lcCashPaymentDate)
            End With

            CmbSearchOnField.SelectedIndex = 0

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Protected Overrides Sub CmbSearchOnFieldIndexChanged()
        Try
            If CmbSearchOnField.Text = lcCashPaymentDate Then
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

    Private Sub InsertIntoGrid(ByRef cashPaymentObj As ClsCashPayment)
        Try
            If cashPaymentObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdItems.Rows.Add
            With GrdItems.Rows(rowIndex)
                .Cells(cId).Value = cashPaymentObj.Id
                .Cells(cCode).Value = cCAP + CStr(cashPaymentObj.Id)
                .Cells(cPaymentDate).Value = cashPaymentObj.PaymentDate
                .Cells(cAmount).Value = cashPaymentObj.Amount
                .Cells(cBillNo).Value = cashPaymentObj.BillNo
                .Cells(cRemark).Value = cashPaymentObj.Remark
                .Cells(cFromHeadId).Value = cashPaymentObj.FromHeadId
                .Cells(cToHeadId).Value = cashPaymentObj.ToHeadId
                .Cells(lcTo).Value = GetAccountHeadName(.Cells(cToHeadId).Value)
                .Cells(lcFrom).Value = GetAccountHeadName(.Cells(cFromHeadId).Value)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadAccountHead()
        lAccountHeads = GetAllAccountHead(Me.Name)
    End Sub

    Private Function GetAccountHeadName(ByVal id As Long) As String
        Dim result As String = ""
        Try
            If id < 0 Then Exit Try
            If lAccountHeads Is Nothing Then Exit Try

            Dim accountHead As ClsAccountHead
            For Each accountHead In lAccountHeads
                If accountHead.Id = id Then
                    result = accountHead.Name
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
