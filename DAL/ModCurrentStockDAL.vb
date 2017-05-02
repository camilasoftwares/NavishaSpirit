'Handles all Functionality related to ClsCurrentStock
Module ModCurrentStockDAL

    Public dsCurrentStock As DataSet = Nothing

    Private Function GetCurrentStockObj(ByRef row As DataRow) As ClsCurrentStock
        Dim currentStock As New ClsCurrentStock
        Try
            With row
                currentStock.Id = .Item(cId)
                currentStock.ItemId = .Item(cItemId)
                currentStock.Batch = .Item(cBatch)
                currentStock.ExpiryDate = .Item(cExpiryDate)
                currentStock.PackQuantity = .Item(cPackQuantity)
                currentStock.CurrentQuantity = .Item(cCurrentQuantity)
                currentStock.PricePurchase = .Item(cPricePurchase)
                currentStock.StorageId = .Item(cStorageId)
                currentStock.Remark = .Item(cRemark)
                currentStock.UserId = .Item(cUserId)
                currentStock.DateOn = .Item(cDateOn)
                currentStock.ManufactureDate = .Item(cManufactureDate)
                currentStock.MRP = .Item(cMRP)
                currentStock.PTR = .Item(cPTR)
                currentStock.PTS = .Item(cPTS)
                currentStock.Rate1 = .Item(cRate1)
                currentStock.Rate2 = .Item(cRate2)
                currentStock.Rate3 = .Item(cRate3)
                currentStock.ManufacturerId = .Item(cManufacturerId)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return currentStock
    End Function

    Private Function GetCurrentStock(ByRef rows As DataRowCollection) As ClsCurrentStock()
        Dim currentStocks(0) As ClsCurrentStock
        currentStocks = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer
                Array.Resize(currentStocks, count)
                For x = 0 To count - 1
                    currentStocks(x) = GetCurrentStockObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return currentStocks
    End Function

    Private Function GetCurrentStock(ByRef rows() As DataRow) As ClsCurrentStock()
        Dim currentStocks(0) As ClsCurrentStock
        currentStocks = Nothing

        Try
            Dim count As Integer = rows.Length
            If count > 0 Then
                Dim x As Integer
                Array.Resize(currentStocks, count)
                For x = 0 To count - 1
                    currentStocks(x) = GetCurrentStockObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return currentStocks
    End Function

    ''' <summary>
    ''' This function will set records from Current Stock table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <remarks></remarks>
    Public Sub GetAllCurrentStock(ByVal calledBy As String)
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllCurrentStock(False).Trim
                If sql = "" Then Exit For

                dsCurrentStock = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try
    End Sub

    ''' <summary>
    ''' This function will give records from Current Stock table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="excludeZeroQuantity">True if want to exclude zero quantity data</param>
    ''' <returns>Array of ClsCategoryMaster Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllCurrentStock(ByVal calledBy As String, ByVal newDataSet As Boolean, Optional ByVal excludeZeroQuantity As Boolean = False) As ClsCurrentStock()
        Dim currentStocks(0) As ClsCurrentStock
        currentStocks = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                If newDataSet = True Then GetAllCurrentStock(calledBy)

                If dsCurrentStock IsNot Nothing Then
                    If dsCurrentStock.Tables(0).Rows.Count > 0 Then
                        If excludeZeroQuantity = True Then
                            Dim str As String = cCurrentQuantity + " > 0 "
                            Dim dtRow() As DataRow = dsCurrentStock.Tables(0).Select(str)
                            If dtRow.Length <> 0 Then currentStocks = GetCurrentStock(dtRow)
                        Else
                            currentStocks = GetCurrentStock(dsCurrentStock.Tables(0).Rows)
                        End If
                    End If
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return currentStocks
    End Function

    ''' <summary>
    ''' This function will give records from Current Stock table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="expiryDate">Date on or before which expiry takes place</param>
    ''' <returns>Array of ClsCategoryMaster Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllCurrentStockForExpiry(ByVal calledBy As String, ByVal expiryDate As Date) As ClsCurrentStock()
        Dim currentStocks(0) As ClsCurrentStock
        currentStocks = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllCurrentStockForExpiry(expiryDate).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    currentStocks = GetCurrentStock(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return currentStocks
    End Function

    ''' <summary>
    ''' This function will give records from Current Stock table for given item id.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="itemId">Item Id for which records are required</param>
    ''' <param name="newDataSet">New data set to load</param>
    ''' <param name="includeZeroQuantity">True for zero quantity records</param>
    ''' <param name="orderById">Flag for ordering stock by id</param>
    ''' <returns>Array of ClsCategoryMaster Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllCurrentStockForItemId(ByVal calledBy As String, ByVal itemId As Integer, ByVal newDataSet As Boolean, Optional ByVal includeZeroQuantity As Boolean = False, Optional ByVal orderById As Boolean = False) As ClsCurrentStock()
        Dim currentStocks(0) As ClsCurrentStock
        currentStocks = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                If newDataSet = True Then GetAllCurrentStock(calledBy)

                If dsCurrentStock IsNot Nothing Then
                    If dsCurrentStock.Tables(0).Rows.Count > 0 Then
                        Dim str As String = cItemId + "=" + CStr(itemId)
                        If includeZeroQuantity = False Then str = str + " and " + cCurrentQuantity + " > 0 "

                        Dim dtRow() As DataRow = Nothing
                        If orderById = True Then
                            dtRow = dsCurrentStock.Tables(0).Select(str, cId)
                        Else
                            dtRow = dsCurrentStock.Tables(0).Select(str)
                        End If
                        If dtRow.Length <> 0 Then currentStocks = GetCurrentStock(dtRow)
                    End If
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return currentStocks
    End Function

    ''' <summary>
    ''' This function will give record from Current Stock table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="itemId">Item Id for which record is required</param>
    ''' <param name="batch">Batch for which record is required</param>
    ''' <returns>ClsCurrentStock Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetCurrentStockForItemIdAndBatch(ByVal calledBy As String, ByVal itemId As Integer, ByVal batch As String, ByVal newDataSet As Boolean) As ClsCurrentStock
        Dim currentStock As ClsCurrentStock = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                If newDataSet = True Then GetAllCurrentStock(calledBy)

                If dsCurrentStock IsNot Nothing Then
                    If dsCurrentStock.Tables(0).Rows.Count > 0 Then
                        Dim str As String = cItemId + "=" + CStr(itemId) + " and " + cBatch + " = '" + batch.Trim + "'"
                        Dim dtRow() As DataRow = dsCurrentStock.Tables(0).Select(str)
                        If dtRow.Length <> 0 Then currentStock = GetCurrentStockObj(dtRow(0))
                    End If
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return currentStock
    End Function

    ''' <summary>
    ''' This function will give records from Current Stock table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which record is required</param>
    ''' <returns>ClsCurrentStock Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetCurrentStock(ByVal calledBy As String, ByVal id As Long) As ClsCurrentStock
        Dim currentStock As ClsCurrentStock = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetCurrentStock(id).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    currentStock = GetCurrentStockObj(ds.Tables(0).Rows(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return currentStock
    End Function

    ''' <summary>
    ''' This function is used to insert Current Stock Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="currentStocksObj">ClsCurrentStocks object to insert</param>
    ''' <remarks></remarks>
    Public Function InsertIntoCurrentStock(ByVal calledBy As String, ByRef currentStocksObj As ClsCurrentStock) As Long
        Dim result As Long = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoCurrentStock(currentStocksObj).Trim
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
    ''' This function is used to update Current Stock Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="currentStocksObj">ClsCurrentStocks object to update</param>
    ''' <remarks></remarks>
    Public Function UpdateCurrentStock(ByVal calledBy As String, ByRef currentStocksObj As ClsCurrentStock) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdateCurrentStock(currentStocksObj).Trim
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