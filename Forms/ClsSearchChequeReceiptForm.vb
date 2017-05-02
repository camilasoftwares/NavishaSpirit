Public Class ClsSearchChequeReceiptForm
    Inherits FrmSearchToAll

#Region "Local variables and Constants"

    Private Const lcChequeReceiptCode As String = "C.R. Code"
    Private Const lcReceiptFrom As String = "Receipt From"
    Private Const lcInvoiceNo As String = "Invoice No"
    Private Const lcChequeReceiptDate As String = "C.R. Date"
    Private Const lcChequeDate As String = "Cheque Date"
    Private Const lcBankName As String = "Bank Name"

    Private Const lcTo As String = "To"
    Private Const lcFrom As String = "From"

    Dim lAccountHeads() As ClsAccountHead = Nothing
    Dim lSelectedId As Long = cInvalidId

#End Region

#Region "Required functions to initialize the object"

    Private Sub ClsSearchChequeReceiptForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

            Dim chequeReceipts() As ClsChequeReceipt = Nothing
            Dim field As String = CmbSearchOnField.Text
            If field = lcChequeReceiptDate Or field = lcChequeDate Then
                Dim str() As String = GetDateValues()
                Dim temp As String = str(0) + str(1) + str(2)
                If temp.Trim = "" Then
                    chequeReceipts = GetAllChequeReceipts(Me.Name)
                ElseIf field = lcChequeReceiptDate Then
                    chequeReceipts = GetAllChequeReceiptLikeReceiptDate(Me.Name, str(0), str(1), str(2))
                ElseIf field = lcChequeDate Then
                    chequeReceipts = GetAllChequeReceiptLikeChequeDate(Me.Name, str(0), str(1), str(2))
                End If
            Else
                Dim str As String = TxtSearchValue.Text.Trim
                If str = "" Then
                    chequeReceipts = GetAllChequeReceipts(Me.Name)
                ElseIf field = lcChequeReceiptCode Then
                    chequeReceipts = GetAllChequeReceiptCodeLike(Me.Name, str)
                ElseIf field = lcInvoiceNo Then
                    chequeReceipts = GetAllChequeReceiptInvoiceNoLike(Me.Name, str)
                ElseIf field = lcReceiptFrom Then
                    chequeReceipts = GetAllChequeReceiptReceiptFromLike(Me.Name, str)
                ElseIf field = lcBankName Then
                    chequeReceipts = GetAllChequeReceiptBankNameLike(Me.Name, str)
                End If
            End If

            If chequeReceipts Is Nothing Then Exit Try

            Dim chequeReceipt As ClsChequeReceipt
            For Each chequeReceipt In chequeReceipts
                InsertIntoGrid(chequeReceipt)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Protected Overrides Sub SetGrid()
        With GrdItems
            Dim colCount As Integer = 12
            .RowHeadersVisible = False
            Dim colWidth As Integer = 91
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
                        Dim index As Integer = .Columns.Add(cReceiptDate, "C.R. Date")
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
                        Dim index As Integer = .Columns.Add(cChequeNo, "Cheque No")
                        .Columns(index).Width = colWidth

                    Case 8
                        Dim index As Integer = .Columns.Add(cChequeDate, "Ch. Date")
                        .Columns(index).Width = colWidth
                        .Columns(index).DefaultCellStyle.Format = "dd/MM/yyyy"

                    Case 9
                        Dim index As Integer = .Columns.Add(cBankName, "Bank")
                        .Columns(index).Width = colWidth

                    Case 10
                        Dim index As Integer = .Columns.Add(cInvoiceNo, "Invoice No")
                        .Columns(index).Width = colWidth

                    Case 11
                        Dim index As Integer = .Columns.Add(cRemark, cRemark)
                        .Columns(index).Width = colWidth

                    Case 12
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

                .Add(lcChequeReceiptCode)
                .Add(lcInvoiceNo)
                .Add(lcReceiptFrom)
                .Add(lcChequeReceiptDate)
                .Add(lcChequeDate)
                .Add(lcBankName)
            End With

            CmbSearchOnField.SelectedIndex = 0

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Protected Overrides Sub CmbSearchOnFieldIndexChanged()
        Try
            If CmbSearchOnField.Text = lcChequeReceiptDate Or CmbSearchOnField.Text = lcChequeDate Then
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

    Private Sub InsertIntoGrid(ByRef chequeReceiptObj As ClsChequeReceipt)
        Try
            If chequeReceiptObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdItems.Rows.Add
            With GrdItems.Rows(rowIndex)
                .Cells(cId).Value = chequeReceiptObj.Id
                .Cells(cCode).Value = cCHR + CStr(chequeReceiptObj.Id)
                .Cells(cReceiptDate).Value = chequeReceiptObj.ReceiptDate
                .Cells(cAmount).Value = chequeReceiptObj.Amount
                .Cells(cRemark).Value = chequeReceiptObj.Remark
                .Cells(cChequeNo).Value = chequeReceiptObj.ChequeNo
                .Cells(cChequeDate).Value = chequeReceiptObj.ChequeDate
                .Cells(cBankName).Value = chequeReceiptObj.BankName
                .Cells(cInvoiceNo).Value = chequeReceiptObj.InvoiceNo
                .Cells(cFromHeadId).Value = chequeReceiptObj.FromHeadId
                .Cells(cToHeadId).Value = chequeReceiptObj.ToHeadId
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
