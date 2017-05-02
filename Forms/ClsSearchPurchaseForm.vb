Public Class ClsSearchPurchaseForm
    Inherits FrmSearchToAll

#Region "Local variables and Constants"

    Private Const lcPurchaseCode As String = "Purchase Code"
    Private Const lcVendor As String = "Vendor"
    Private Const lcVoucherNo As String = "Voucher No"
    Private Const lcAgainstOrder As String = "Against Order"
    Private Const lcPurchaseDate As String = "Purchase Date"

    Dim lVendors() As ClsVendorMaster = Nothing
    Dim lSelectedId As Integer = cInvalidId

#End Region

#Region "Required functions to initialize the object"

    Private Sub ClsSearchPurchaseForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyBase.SetChildClassObj(Me)
        LoadVendors()
    End Sub

#End Region

#Region "Protected Functions"

    Protected Overrides Sub GridRowDoubleClicked(ByRef row As System.Windows.Forms.DataGridViewRow)
        Try
            If row Is Nothing Then Exit Try

            Dim id As Integer = row.Cells(cId).Value
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

            Dim purchases() As ClsPurchaseMaster = Nothing
            Dim field As String = CmbSearchOnField.Text
            If field = lcPurchaseDate Then
                Dim str() As String = GetDateValues()
                Dim temp As String = str(0) + str(1) + str(2)
                If temp.Trim = "" Then
                    purchases = GetAllPurchaseMaster(Me.Name)
                ElseIf field = lcPurchaseDate Then
                    purchases = GetAllPurchaseMasterLikePurchaseDate(Me.Name, str(0), str(1), str(2))
                End If
            Else
                Dim str As String = TxtSearchValue.Text.Trim
                If str = "" Then
                    purchases = GetAllPurchaseMaster(Me.Name)
                ElseIf field = lcPurchaseCode Then
                    purchases = GetAllPurchaseMasterPurchaseCodeLike(Me.Name, str)
                ElseIf field = lcVendor Then
                    purchases = GetAllPurchaseMasterVendorLike(Me.Name, str)
                ElseIf field = lcVoucherNo Then
                    purchases = GetAllPurchaseMasterVoucherNoLike(Me.Name, str)
                ElseIf field = lcAgainstOrder Then
                    purchases = GetAllPurchaseMasterAgainstOrderLike(Me.Name, str)
                End If
            End If
            
            If purchases Is Nothing Then Exit Try

            Dim purchase As ClsPurchaseMaster
            For Each purchase In purchases
                InsertIntoGrid(purchase)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Protected Overrides Sub SetGrid()
        With GrdItems
            Dim colCount As Integer = 7
            .RowHeadersVisible = False
            Dim colWidth As Integer = 120
            Dim x As Integer
            For x = 0 To colCount
                Select Case x
                    Case 0
                        Dim index As Integer = .Columns.Add(cId, cId)
                        .Columns(index).Visible = False

                    Case 1
                        Dim index As Integer = .Columns.Add(cPurchaseCode, "Purchase Code")
                        .Columns(index).Width = colWidth

                    Case 2
                        Dim index As Integer = .Columns.Add(cPurchaseDate, "Purchase Date")
                        .Columns(index).Width = colWidth
                        .Columns(index).DefaultCellStyle.Format = "dd/MM/yyyy"

                    Case 3
                        Dim index As Integer = .Columns.Add(cVendor, cVendor)
                        .Columns(index).Width = 300

                    Case 4
                        Dim index As Integer = .Columns.Add(cVoucherNo, "Voucher No")
                        .Columns(index).Width = colWidth

                    Case 5
                        Dim index As Integer = .Columns.Add(cOrderId, "Against Order")
                        .Columns(index).Width = colWidth

                    Case 6
                        Dim index As Integer = .Columns.Add(cMode, "Status")
                        .Columns(index).Width = colWidth

                    Case 7
                        Dim index As Integer = .Columns.Add(cVendorId, cVendorId)
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

                .Add(lcPurchaseCode)
                .Add(lcVendor)
                .Add(lcVoucherNo)
                .Add(lcAgainstOrder)
                .Add(lcPurchaseDate)
            End With

            CmbSearchOnField.SelectedIndex = 0

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Protected Overrides Sub CmbSearchOnFieldIndexChanged()
        Try
            If CmbSearchOnField.Text = lcPurchaseDate Then
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

    Public Function GetSelectedId() As Integer
        Return lSelectedId
    End Function

#End Region

#Region "Private Functions"

    Private Sub InsertIntoGrid(ByRef purchaseObj As ClsPurchaseMaster)
        Try
            If purchaseObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdItems.Rows.Add
            With GrdItems.Rows(rowIndex)
                .Cells(cId).Value = purchaseObj.Id
                .Cells(cPurchaseCode).Value = purchaseObj.PurchaseCode
                .Cells(cPurchaseDate).Value = purchaseObj.PurchaseDate
                .Cells(cVoucherNo).Value = purchaseObj.VoucherNo
                If purchaseObj.OrderId > 0 Then .Cells(cOrderId).Value = purchaseObj.OrderId
                .Cells(cMode).Value = purchaseObj.Mode
                .Cells(cVendorId).Value = purchaseObj.VendorId
                .Cells(cVendor).Value = GetVendorName(.Cells(cVendorId).Value)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadVendors()
        lVendors = GetAllVendorMaster(Me.Name)
    End Sub

    Private Function GetVendorName(ByVal id As Integer) As String
        Dim result As String = ""
        Try
            If lVendors Is Nothing Then Exit Try

            Dim vendor As ClsVendorMaster
            For Each vendor In lVendors
                If vendor.Id = id Then
                    result = vendor.Name
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
