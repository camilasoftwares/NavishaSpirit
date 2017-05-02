'Handles all Functionality related to ClsCustomerTypePrice
Module ModCustomerTypePriceDAL

    Private Function GetCustomerTypePriceObj(ByRef row As DataRow) As ClsCustomerTypePrice
        Dim customerTypePrice As New ClsCustomerTypePrice
        Try
            With row
                customerTypePrice.Id = .Item(cId)
                customerTypePrice.CustomerTypeId = .Item(cCustomerTypeId)
                customerTypePrice.ItemId = .Item(cItemId)
                customerTypePrice.Price = .Item(cPrice)
                customerTypePrice.Batch = .Item(cBatch)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return customerTypePrice
    End Function

    Private Function GetCustomerTypePrice(ByRef rows As DataRowCollection) As ClsCustomerTypePrice()
        Dim customerTypePrices(0) As ClsCustomerTypePrice
        customerTypePrices = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer
                Array.Resize(customerTypePrices, count)
                For x = 0 To count - 1
                    customerTypePrices(x) = GetCustomerTypePriceObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return customerTypePrices
    End Function

    ''' <summary>
    ''' This function will give records from Customer Type Price table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>ClsCustomerTypePrice Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllCustomerTypePrices(ByVal calledBy As String) As ClsCustomerTypePrice()
        Dim customerTypePrices(0) As ClsCustomerTypePrice
        customerTypePrices = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllCustomerTypePrice().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    customerTypePrices = GetCustomerTypePrice(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return customerTypePrices
    End Function

    ''' <summary>
    ''' This function will give records from Customer Type Price table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="itemId">Item Id for which records are required</param>
    ''' <param name="batch">Batch  for which records are required</param>
    ''' <returns>ClsCustomerTypePrice Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllCustomerTypePrices(ByVal calledBy As String, ByVal itemId As Integer, ByVal batch As String) As ClsCustomerTypePrice()
        Dim customerTypePrices(0) As ClsCustomerTypePrice
        customerTypePrices = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllCustomerTypePrice(itemId, batch).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    customerTypePrices = GetCustomerTypePrice(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return customerTypePrices
    End Function

    ''' <summary>
    ''' This function will give price from Customer Type Price table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="itemId">Item Id for which price is required</param>
    ''' <param name="batch">Batch for which price is required</param>
    ''' <param name="customerId">Customer Id for which price is required</param>
    ''' <returns>Price in Double</returns>
    ''' <remarks></remarks>
    Public Function GetCustomerTypePrice(ByVal calledBy As String, ByVal itemId As Integer, ByVal batch As String, ByVal customerId As Integer) As Double
        Dim result As Double = 0

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetCustomerTypePrice(itemId, batch, customerId).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    Dim price As Double = 0
                    Try
                        price = Val(ds.Tables(0).Rows(0).Item(0))
                    Catch ex As Exception
                    End Try

                    result = price
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    ''' <summary>
    ''' This function will give records from Customer Type Price table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which record is required</param>
    ''' <returns>ClsCustomerTypePrice Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetCustomerTypePrice(ByVal calledBy As String, ByVal id As Long) As ClsCustomerTypePrice
        Dim customerTypePrice As ClsCustomerTypePrice = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetCustomerTypePrice(id).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    customerTypePrice = GetCustomerTypePriceObj(ds.Tables(0).Rows(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return customerTypePrice
    End Function

    ''' <summary>
    ''' This function is used to insert Customer Type Price Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="customerTypePricesObj">ClsCustomerTypePrices object to insert</param>
    ''' <returns>Id in long</returns>
    ''' <remarks></remarks>
    Public Function InsertIntoCustomerTypePrice(ByVal calledBy As String, ByRef customerTypePricesObj As ClsCustomerTypePrice) As Long
        Dim result As Long = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoCustomerTypePrice(customerTypePricesObj).Trim
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
    ''' This function is used to update Customer Type Price Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="customerTypePricesObj">ClsCustomerTypePrices object to update</param>
    ''' <remarks></remarks>
    Public Function UpdateCustomerTypePrice(ByVal calledBy As String, ByRef customerTypePricesObj As ClsCustomerTypePrice) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdateCustomerTypePrice(customerTypePricesObj).Trim
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
    ''' This function is used to insert/update Customer Type Price Object list in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="customerTypePricesList">List of ClsCustomerTypePrices to insert update</param>
    ''' <remarks></remarks>
    Public Function InsertUpdateCustomerTypePrice(ByVal calledBy As String, ByRef customerTypePricesList As List(Of ClsCustomerTypePrice)) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0

                Dim sql As String = ""
                For Each customerTypePricesObj As ClsCustomerTypePrice In customerTypePricesList
                    If customerTypePricesObj.Id <= 0 Then
                        sql = sql + ClsScripts.GetInstance.InsertIntoCustomerTypePrice(customerTypePricesObj).Trim
                    Else
                        sql = sql + ClsScripts.GetInstance.UpdateCustomerTypePrice(customerTypePricesObj).Trim
                    End If

                    sql = sql + vbCrLf
                Next

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
