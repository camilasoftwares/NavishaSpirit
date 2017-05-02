'Handles all Functionality related to ClsOpeningStock
Module ModOpeningStockDAL

    Public dsOpeningStock As DataSet = Nothing

    Private Function GetOpeningStockObj(ByRef row As DataRow) As ClsOpeningStock
        Dim openingStock As New ClsOpeningStock
        Try
            With row
                openingStock.Id = .Item(cId)
                openingStock.ItemId = .Item(cItemId)
                openingStock.Batch = .Item(cBatch)
                openingStock.PackQuantity = .Item(cPackQuantity)
                openingStock.Quantity = .Item(cQuantity)
                openingStock.FreeQuantity = .Item(cFreeQuantity)
                openingStock.PricePurchase = .Item(cPricePurchase)
                openingStock.MRP = .Item(cMRP)
                openingStock.PTS = .Item(cPTS)
                openingStock.PTR = .Item(cPTR)
                openingStock.PTD = .Item(cPTD)
                openingStock.Rate1 = .Item(cRate1)
                openingStock.Rate2 = .Item(cRate2)
                openingStock.StorageId = .Item(cStorageId)
                openingStock.Remark = .Item(cRemark)
                openingStock.UserId = .Item(cUserId)
                openingStock.DateOn = .Item(cDateOn)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return openingStock
    End Function

    Private Function GetOpeningStock(ByRef rows As DataRowCollection) As ClsOpeningStock()
        Dim openingStocks(0) As ClsOpeningStock
        openingStocks = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer
                Array.Resize(openingStocks, count)
                For x = 0 To count - 1
                    openingStocks(x) = GetOpeningStockObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return openingStocks
    End Function

    Private Function GetOpeningStock(ByRef rows() As DataRow) As ClsOpeningStock()
        Dim openingStocks(0) As ClsOpeningStock
        openingStocks = Nothing

        Try
            Dim count As Integer = rows.Length
            If count > 0 Then
                Dim x As Integer
                Array.Resize(openingStocks, count)
                For x = 0 To count - 1
                    openingStocks(x) = GetOpeningStockObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return openingStocks
    End Function

    ''' <summary>
    ''' This function will set records from Current Stock table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <remarks></remarks>
    Public Function GetAllOpeningStock(ByVal calledBy As String) As ClsOpeningStock()
        Dim openingStock() As ClsOpeningStock = Nothing
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllOpeningStock().Trim
                If sql = "" Then Exit For

                dsOpeningStock = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If dsOpeningStock.Tables(0).Rows.Count > 0 Then
                    openingStock = GetOpeningStock(dsOpeningStock.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return openingStock
    End Function

    ''' <summary>
    ''' This function will give records from Current Stock table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="excludeZeroQuantity">True if want to exclude zero quantity data</param>
    ''' <returns>Array of ClsCategoryMaster Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllOpeningStock(ByVal calledBy As String, ByVal newDataSet As Boolean, Optional ByVal excludeZeroQuantity As Boolean = False) As ClsOpeningStock()
        Dim openingStocks(0) As ClsOpeningStock
        openingStocks = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                If newDataSet = True Then GetAllOpeningStock(calledBy)

                If dsOpeningStock IsNot Nothing Then
                    If dsOpeningStock.Tables(0).Rows.Count > 0 Then
                        If excludeZeroQuantity = True Then
                            Dim str As String = cCurrentQuantity + " > 0 "
                            Dim dtRow() As DataRow = dsOpeningStock.Tables(0).Select(str)
                            If dtRow.Length <> 0 Then openingStocks = GetOpeningStock(dtRow)
                        Else
                            openingStocks = GetOpeningStock(dsOpeningStock.Tables(0).Rows)
                        End If
                    End If
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return openingStocks
    End Function

    ''' <summary>
    ''' This function will give records from Current Stock table for given item id.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="itemId">Item Id for which records are required</param>
    ''' <param name="includeZeroQuantity">True for zero quantity records</param>
    ''' <returns>Array of ClsCategoryMaster Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllOpeningStockForItemId(ByVal calledBy As String, ByVal itemId As Integer, ByVal newDataSet As Boolean, Optional ByVal includeZeroQuantity As Boolean = False) As ClsOpeningStock()
        Dim openingStocks(0) As ClsOpeningStock
        openingStocks = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                If newDataSet = True Then GetAllOpeningStock(calledBy)

                If dsOpeningStock IsNot Nothing Then
                    If dsOpeningStock.Tables(0).Rows.Count > 0 Then
                        If includeZeroQuantity = False Then
                            Dim str As String = cItemId + "=" + CStr(itemId) + " and " + cCurrentQuantity + " > 0 "
                            Dim dtRow() As DataRow = dsOpeningStock.Tables(0).Select(str)
                            If dtRow.Length <> 0 Then openingStocks = GetOpeningStock(dtRow)
                        Else
                            Dim str As String = cItemId + "=" + CStr(itemId)
                            Dim dtRow() As DataRow = dsOpeningStock.Tables(0).Select(str)
                            If dtRow.Length <> 0 Then openingStocks = GetOpeningStock(dtRow)
                        End If
                    End If
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return openingStocks
    End Function

    ''' <summary>
    ''' This function will give record from Current Stock table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="itemId">Item Id for which record is required</param>
    ''' <param name="batch">Batch for which record is required</param>
    ''' <returns>ClsOpeningStock Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetOpeningStockForItemIdAndBatch(ByVal calledBy As String, ByVal itemId As Integer, ByVal batch As String, ByVal newDataSet As Boolean) As ClsOpeningStock
        Dim openingStock As ClsOpeningStock = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                If newDataSet = True Then GetAllOpeningStock(calledBy)

                If dsOpeningStock IsNot Nothing Then
                    If dsOpeningStock.Tables(0).Rows.Count > 0 Then
                        Dim str As String = cItemId + "=" + CStr(itemId) + " and " + cBatch + " = '" + batch.Trim + "'"
                        Dim dtRow() As DataRow = dsOpeningStock.Tables(0).Select(str)
                        If dtRow.Length <> 0 Then openingStock = GetOpeningStockObj(dtRow(0))
                    End If
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return openingStock
    End Function

    ''' <summary>
    ''' This function will give records from Current Stock table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which record is required</param>
    ''' <returns>ClsOpeningStock Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetOpeningStock(ByVal calledBy As String, ByVal id As Long) As ClsOpeningStock
        Dim openingStock As ClsOpeningStock = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetOpeningStock(id).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    openingStock = GetOpeningStockObj(ds.Tables(0).Rows(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return openingStock
    End Function

    ''' <summary>
    ''' This function is used to insert Current Stock Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="openingStocksObj">ClsOpeningStocks object to insert</param>
    ''' <remarks></remarks>
    Public Function InsertIntoOpeningStock(ByVal calledBy As String, ByRef openingStocksObj As ClsOpeningStock) As Long
        Dim result As Long = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoOpeningStock(openingStocksObj).Trim
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
    ''' <param name="openingStocksObj">ClsOpeningStocks object to update</param>
    ''' <remarks></remarks>
    Public Function UpdateOpeningStock(ByVal calledBy As String, ByRef openingStocksObj As ClsOpeningStock) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdateOpeningStock(openingStocksObj).Trim
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
    ''' This function is used to update Current Stock Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id to delete</param>
    ''' <remarks></remarks>
    Public Function DeleteOpeningStock(ByVal calledBy As String, ByVal id As Long) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.DeleteOpeningStock(id).Trim
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