'Handles all Functionality related to ClsAccountGroup
Module ModTransactionStockDAL

    Private Function GetTransactionStockObj(ByRef row As DataRow) As ClsTransactionStock
        Dim transactionStock As New ClsTransactionStock
        Try
            With row
                'transactionStock.Id = .Item(cId)
                transactionStock.TransactionNo = .Item(cTransactionNo)
                transactionStock.ItemId = .Item(cItemId)
                transactionStock.Batch = .Item(cBatch)
                transactionStock.ExpiryDate = .Item(cExpiryDate)
                transactionStock.PackQuantity = .Item(cPackQuantity)
                transactionStock.QuantityIn = .Item(cQuantityIn)
                transactionStock.QuantityOut = .Item(cQuantityOut)
                transactionStock.PricePurchase = .Item(cPricePurchase)
                transactionStock.PriceSale = .Item(cPriceSale)
                transactionStock.TaxPercent = .Item(cTaxPercent)
                transactionStock.DiscountPercent = .Item(cDiscountPercent)
                transactionStock.TaxAmount = .Item(cTaxAmount)
                transactionStock.DiscountAmount = .Item(cDiscountAmount)
                transactionStock.Source = .Item(cSource)
                transactionStock.Remark = .Item(cRemark)
                transactionStock.UserId = .Item(cUserId)
                transactionStock.DateOn = .Item(cDateOn)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return transactionStock
    End Function

    Private Function GetTransactionStock(ByRef rows As DataRowCollection) As ClsTransactionStock()
        Dim transactionStocks(0) As ClsTransactionStock
        transactionStocks = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer
                Array.Resize(transactionStocks, count)
                For x = 0 To count - 1
                    transactionStocks(x) = GetTransactionStockObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return transactionStocks
    End Function

    ''' <summary>
    ''' This function will give records from Transaction Stock table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>ClsTransactionStock Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllTransactionStock(ByVal calledBy As String) As ClsTransactionStock()
        Dim TransactionStocks(0) As ClsTransactionStock
        TransactionStocks = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllTransactionStock().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    TransactionStocks = GetTransactionStock(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return TransactionStocks
    End Function

    '''' <summary>
    '''' This function will give records from Transaction Stock table.
    '''' </summary>
    '''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    '''' <param name="id">Id for which record is required</param>
    '''' <returns>ClsTransactionStock Object or nothing</returns>
    '''' <remarks></remarks>
    'Public Function GetTransactionStock(ByVal calledBy As String, ByVal id As Long) As ClsTransactionStock
    '    Dim transactionStock As ClsTransactionStock = Nothing

    '    Try
    '        Dim temp As Integer
    '        For temp = 0 To 0
    '            Dim sql As String = ClsScripts.GetInstance.GetTransactionStock(id).Trim
    '            If sql = "" Then Exit For

    '            Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
    '            If ds.Tables(0).Rows.Count > 0 Then
    '                transactionStock = GetTransactionStockObj(ds.Tables(0).Rows(0))
    '            End If
    '        Next

    '    Catch ex As Exception
    '        AddToLog(ex)
    '    End Try

    '    Return transactionStock
    'End Function

    ''' <summary>
    ''' This function is used to insert Transaction Stock Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="transactionStocksObj">ClsTransactionStock object to insert</param>
    ''' <returns>Id in long</returns>
    ''' <remarks></remarks>
    Public Function InsertIntoTransactionStocks(ByVal calledBy As String, ByRef transactionStocksObj As ClsTransactionStock) As Long
        Dim result As Long = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoTransactionStock(TransactionStocksObj).Trim
                If sql = "" Then Exit For

                Dim id As Long = ClsDBFunctions.GetInstance.ExecuteQuery_Scalar(sql, calledBy)
                If id > 0 Then
                    result = id
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    ''' <summary>
    ''' This function is used to update Transaction Stock Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="TransactionStockObj">ClsTransactionStock object to update</param>
    ''' <remarks></remarks>
    Public Function UpdateTransactionStock(ByVal calledBy As String, ByRef TransactionStockObj As ClsTransactionStock) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdateTransactionStock(TransactionStockObj).Trim
                If sql = "" Then Exit For

                If ClsDBFunctions.GetInstance.ExecuteQuery_NonQuery(sql, calledBy) > 0 Then result = EnResult.Change
            Next

        Catch ex As Exception
            AddToLog(ex)
            result = EnResult.Err
        End Try

        Return result
    End Function

End Module
