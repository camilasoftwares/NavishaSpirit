Public Class ClsSearchPurchaseReturnForm
    Inherits FrmSearchToAll

#Region "Local variables and Constants"

    Private Const lcPurchaseReturnCode As String = "Purchase Return Code"
    'Private Const lcPurchaseCode As String = "Purchase Code"
    Private Const lcVendorName As String = "Vendor Name"
    Private Const lcPurchaseReturnDate As String = "Purchase Return Date"

    Dim lVendors() As ClsVendorMaster = Nothing
    Dim lPurchase() As ClsPurchaseMaster = Nothing
    Dim lSelectedId As Long = cInvalidId

#End Region

#Region "Required functions to initialize the object"

    Private Sub ClsSearchPurchaseReturnForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyBase.SetChildClassObj(Me)
        LoadVendors()
        LoadPurchase()
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

            Dim purchaseReturns() As ClsPurchaseReturnMaster = Nothing
            Dim field As String = CmbSearchOnField.Text
            If field = lcPurchaseReturnDate Then
                Dim str() As String = GetDateValues()
                Dim temp As String = str(0) + str(1) + str(2)
                If temp.Trim = "" Then
                    purchaseReturns = GetAllPurchaseReturnMasters(Me.Name)
                ElseIf field = lcPurchaseReturnDate Then
                    purchaseReturns = GetAllPurchaseReturnMasterLikeReturnDate(Me.Name, str(0), str(1), str(2))
                End If
            Else
                Dim str As String = TxtSearchValue.Text.Trim
                If str = "" Then
                    purchaseReturns = GetAllPurchaseReturnMasters(Me.Name)
                ElseIf field = lcPurchaseReturnCode Then
                    purchaseReturns = GetAllPurchaseReturnMasterReturnCodeLike(Me.Name, str)
                ElseIf field = lcVendorName Then
                    purchaseReturns = GetAllPurchaseReturnMasterVendorLike(Me.Name, str)
                    'ElseIf field = lcPurchaseCode Then
                    '    purchaseReturns = GetAllPurchaseReturnMasterPurchaseCodeLike(Me.Name, str)
                End If
            End If

            If purchaseReturns Is Nothing Then Exit Try

            Dim purchaseReturn As ClsPurchaseReturnMaster
            For Each purchaseReturn In purchaseReturns
                InsertIntoGrid(purchaseReturn)
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
                        Dim index As Integer = .Columns.Add(cPurchaseReturnCode, "Purchase Return Code")
                        .Columns(index).Width = colWidth

                    Case 1
                        Dim index As Integer = .Columns.Add(cPurchaseCode, "Purchase Code")
                        .Columns(index).Width = colWidth
                        .Columns(index).Visible = False

                    Case 2
                        Dim index As Integer = .Columns.Add(cReturnDate, "Return Date")
                        .Columns(index).Width = colWidth
                        .Columns(index).DefaultCellStyle.Format = "dd/MM/yyyy"

                    Case 3
                        Dim index As Integer = .Columns.Add(cVendor, "Vendor")
                        .Columns(index).Width = 310

                    Case 4
                        Dim index As Integer = .Columns.Add(cId, cId)
                        .Columns(index).Visible = False

                    Case 5
                        Dim index As Integer = .Columns.Add(cPurchaseId, cPurchaseId)
                        .Columns(index).Visible = False

                    Case 6
                        Dim index As Integer = .Columns.Add(cMode, cMode)
                        .Columns(index).Width = colWidth
                        .Columns(index).Visible = False

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

                .Add(lcPurchaseReturnCode)
                .Add(lcVendorName)
                '.Add(lcPurchaseCode)
                .Add(lcPurchaseReturnDate)
            End With

            CmbSearchOnField.SelectedIndex = 0

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Protected Overrides Sub CmbSearchOnFieldIndexChanged()
        Try
            If CmbSearchOnField.Text = lcPurchaseReturnDate Then
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

    Private Sub InsertIntoGrid(ByRef purchaseReturnObj As ClsPurchaseReturnMaster)
        Try
            If purchaseReturnObj Is Nothing Then Exit Try

            Dim rowIndex As Integer = GrdItems.Rows.Add
            With GrdItems.Rows(rowIndex)
                .Cells(cId).Value = purchaseReturnObj.Id
                .Cells(cPurchaseReturnCode).Value = purchaseReturnObj.PurchaseReturnCode
                .Cells(cReturnDate).Value = purchaseReturnObj.ReturnDate
                .Cells(cMode).Value = purchaseReturnObj.Mode
                .Cells(cVendorId).Value = purchaseReturnObj.VendorId
                .Cells(cVendor).Value = GetVendorName(.Cells(cVendorId).Value)
                .Cells(cPurchaseId).Value = purchaseReturnObj.PurchaseId
                .Cells(cPurchaseCode).Value = GetPurchaseCode(.Cells(cPurchaseId).Value)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    Private Sub LoadVendors()
        lVendors = GetAllVendorMaster(Me.Name)
    End Sub

    Private Sub LoadPurchase()
        lPurchase = GetAllPurchaseMaster(Me.Name)
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

    Private Function GetPurchaseCode(ByVal id As Long) As String
        Dim result As String = ""
        Try
            If lPurchase Is Nothing Then Exit Try

            Dim purchase As ClsPurchaseMaster
            For Each purchase In lPurchase
                If purchase.Id = id Then
                    result = purchase.PurchaseCode
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
