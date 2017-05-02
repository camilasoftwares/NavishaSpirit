'Handles all Functionality related to ClsFreeStockTransaction
Module ModFreeStockTransactionDAL

    Private Function GetFreeStockTransactionObj(ByRef row As DataRow) As ClsFreeStockTransaction
        Dim freeStockTransaction As New ClsFreeStockTransaction
        Try
            With row
                freeStockTransaction.Id = .Item(cId)
                freeStockTransaction.SaleId = .Item(cSaleId)
                freeStockTransaction.ItemId = .Item(cItemId)
                freeStockTransaction.Batch = .Item(cBatch)
                freeStockTransaction.PackQuantity = .Item(cPackQuantity)
                freeStockTransaction.FreeQuantity = .Item(cFreeQuantity)
                freeStockTransaction.Remark = .Item(cRemark)
                freeStockTransaction.UserId = .Item(cUserId)
                freeStockTransaction.DateOn = .Item(cDateOn)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return freeStockTransaction
    End Function

    Private Function GetFreeStockTransaction(ByRef rows As DataRowCollection) As ClsFreeStockTransaction()
        Dim freeStockTransactions(0) As ClsFreeStockTransaction
        freeStockTransactions = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer

                Array.Resize(freeStockTransactions, count)
                For x = 0 To count - 1
                    freeStockTransactions(x) = GetFreeStockTransactionObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return freeStockTransactions
    End Function

    ''' <summary>
    ''' This function will give records from Free Stock Transaction table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>ClsFreeStockTransaction Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllFreeStockTransaction(ByVal calledBy As String) As ClsFreeStockTransaction()
        Dim freeStockTransactions(0) As ClsFreeStockTransaction
        freeStockTransactions = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllFreeStockTransaction().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    freeStockTransactions = GetFreeStockTransaction(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return freeStockTransactions
    End Function

    ''' <summary>
    ''' This function will give records from Free Stock Transaction table for given sales id.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="salesId">Sales Id for which the records are required</param>
    ''' <returns>Array of ClsFreeStockTransaction Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllFreeStockTransactionForSalesId(ByVal calledBy As String, ByVal salesId As Long) As ClsFreeStockTransaction()
        Dim freeStockTransactions(0) As ClsFreeStockTransaction
        freeStockTransactions = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllFreeStockTransactionForSalesId(salesId).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    freeStockTransactions = GetFreeStockTransaction(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return freeStockTransactions
    End Function

    ''' <summary>
    ''' This function will give record from Free Stock Transaction table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which record is required</param>
    ''' <returns>ClsFreeStockTransaction Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetFreeStockTransaction(ByVal calledBy As String, ByVal id As Long) As ClsFreeStockTransaction
        Dim freeStockTransaction As ClsFreeStockTransaction = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetFreeStockTransaction(id).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    freeStockTransaction = GetFreeStockTransactionObj(ds.Tables(0).Rows(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return freeStockTransaction
    End Function

    ''' <summary>
    ''' This function is used to insert Free Stock Transaction Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="freeStockTransactionObj">ClsFreeStockTransaction object to insert</param>
    ''' <remarks></remarks>
    Public Function InsertIntoFreeStockTransaction(ByVal calledBy As String, ByRef freeStockTransactionObj As ClsFreeStockTransaction) As Integer
        Dim result As Integer = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoFreeStockTransaction(freeStockTransactionObj).Trim
                If sql = "" Then Exit For

                Dim id As Integer = ClsDBFunctions.GetInstance.ExecuteQuery_Scalar(sql, calledBy)
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
    ''' This function is used to update Free Stock Transaction Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="freeStockTransactionObj">ClsFreeStockTransaction object to update</param>
    ''' <remarks></remarks>
    Public Function UpdateFreeStockTransaction(ByVal calledBy As String, ByRef freeStockTransactionObj As ClsFreeStockTransaction) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdateFreeStockTransaction(freeStockTransactionObj).Trim
                If sql = "" Then Exit For

                If ClsDBFunctions.GetInstance.ExecuteQuery_NonQuery(sql, calledBy) > 0 Then result = EnResult.Change
            Next

        Catch ex As Exception
            AddToLog(ex)
            result = EnResult.Err
        End Try

        Return result
    End Function

    ''' <summary>
    ''' This function is used to delete Free Stock Transaction Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which the deletion takes place</param>
    ''' <remarks></remarks>
    Public Function DeleteFreeStockTransaction(ByVal calledBy As String, ByVal id As Long) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.DeleteFreeStockTransaction(id).Trim
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