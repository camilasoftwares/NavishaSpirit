'Handles all Functionality related to ClsCurrentFreeStock
Module ModCurrentFreeStockDAL

    Private Function GetCurrentFreeStockObj(ByRef row As DataRow) As ClsCurrentFreeStock
        Dim currentFreeStock As New ClsCurrentFreeStock
        Try
            With row
                currentFreeStock.Id = .Item(cId)
                currentFreeStock.ItemId = .Item(cItemId)
                currentFreeStock.Batch = .Item(cBatch)
                currentFreeStock.PackQuantity = .Item(cPackQuantity)
                currentFreeStock.CurrentQuantity = .Item(cCurrentQuantity)
                currentFreeStock.Remark = .Item(cRemark)
                currentFreeStock.UserId = .Item(cUserId)
                currentFreeStock.DateOn = .Item(cDateOn)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return currentFreeStock
    End Function

    Private Function GetCurrentFreeStock(ByRef rows As DataRowCollection) As ClsCurrentFreeStock()
        Dim currentFreeStocks(0) As ClsCurrentFreeStock
        CurrentFreeStocks = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer
                Array.Resize(CurrentFreeStocks, count)
                For x = 0 To count - 1
                    CurrentFreeStocks(x) = GetCurrentFreeStockObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return CurrentFreeStocks
    End Function

    ''' <summary>
    ''' This function will give records from Current Free Stock table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="excludeZeroQuantity">True if want to exclude zero quantity data</param>
    ''' <returns>Array of ClsCategoryMaster Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllCurrentFreeStock(ByVal calledBy As String, Optional ByVal excludeZeroQuantity As Boolean = False) As ClsCurrentFreeStock()
        Dim currentFreeStocks(0) As ClsCurrentFreeStock
        currentFreeStocks = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllCurrentFreeStock(excludeZeroQuantity).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    currentFreeStocks = GetCurrentFreeStock(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return currentFreeStocks
    End Function

    ''' <summary>
    ''' This function will give records from Current Free Stock table for given item id.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="itemId">Item Id for which records are required</param>
    ''' <param name="includeZeroQuantity">True for zero quantity records</param>
    ''' <returns>Array of ClsCategoryMaster Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllCurrentFreeStockForItemId(ByVal calledBy As String, ByVal itemId As Integer, Optional ByVal includeZeroQuantity As Boolean = False) As ClsCurrentFreeStock()
        Dim currentFreeStocks(0) As ClsCurrentFreeStock
        currentFreeStocks = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllCurrentFreeStockForItemId(itemId, includeZeroQuantity).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    currentFreeStocks = GetCurrentFreeStock(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return currentFreeStocks
    End Function

    ''' <summary>
    ''' This function will give record from Current Free Stock table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="itemId">Item Id for which record is required</param>
    ''' <param name="batch">Batch for which record is required</param>
    ''' <returns>ClsCurrentFreeStock Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetCurrentFreeStockForItemIdAndBatch(ByVal calledBy As String, ByVal itemId As Integer, ByVal batch As String) As ClsCurrentFreeStock
        Dim currentFreeStock As ClsCurrentFreeStock = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetCurrentFreeStockForItemIdAndBatch(itemId, batch).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    currentFreeStock = GetCurrentFreeStockObj(ds.Tables(0).Rows(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return currentFreeStock
    End Function

    ''' <summary>
    ''' This function will give records from Current Free Stock table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which record is required</param>
    ''' <returns>ClsCurrentFreeStock Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetCurrentFreeStock(ByVal calledBy As String, ByVal id As Long) As ClsCurrentFreeStock
        Dim currentFreeStock As ClsCurrentFreeStock = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetCurrentFreeStock(id).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    currentFreeStock = GetCurrentFreeStockObj(ds.Tables(0).Rows(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return currentFreeStock
    End Function

    ''' <summary>
    ''' This function is used to insert Current Free Stock Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="currentFreeStocksObj">ClsCurrentFreeStocks object to insert</param>
    ''' <remarks></remarks>
    Public Function InsertIntoCurrentFreeStock(ByVal calledBy As String, ByRef currentFreeStocksObj As ClsCurrentFreeStock) As Long
        Dim result As Long = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoCurrentFreeStock(CurrentFreeStocksObj).Trim
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
    ''' This function is used to update Current Free Stock Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="currentFreeStocksObj">ClsCurrentFreeStocks object to update</param>
    ''' <remarks></remarks>
    Public Function UpdateCurrentFreeStock(ByVal calledBy As String, ByRef currentFreeStocksObj As ClsCurrentFreeStock) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdateCurrentFreeStock(currentFreeStocksObj).Trim
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