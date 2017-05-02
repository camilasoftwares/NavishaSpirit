'Handles all Functionality related to ClsExpiryDetail
Module ModExpiryDetailDAL

    Private Function GetExpiryDetailObj(ByRef row As DataRow) As ClsExpiryDetail
        Dim expiryDetail As New ClsExpiryDetail
        Try
            With row
                expiryDetail.Id = .Item(cId)
                expiryDetail.ItemId = .Item(cItemId)
                expiryDetail.Batch = .Item(cBatch)
                expiryDetail.ExpiryDate = .Item(cExpiryDate)
                expiryDetail.PackQuantity = .Item(cPackQuantity)
                expiryDetail.Quantity = .Item(cQuantity)
                expiryDetail.PricePurchase = .Item(cPricePurchase)
                expiryDetail.PriceSale = .Item(cPriceSale)
                expiryDetail.TaxPercent = .Item(cTaxPercent)
                expiryDetail.DiscountPercent = .Item(cDiscountPercent)
                expiryDetail.TaxAmount = .Item(cTaxAmount)
                expiryDetail.DiscountAmount = .Item(cDiscountAmount)
                expiryDetail.DiscountAmount = .Item(cDiscountAmount)
                expiryDetail.StorageId = .Item(cStorageId)
                expiryDetail.Remark = .Item(cRemark)
                expiryDetail.UserId = .Item(cUserId)
                expiryDetail.DateOn = .Item(cDateOn)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return expiryDetail
    End Function

    Private Function GetExpiryDetail(ByRef rows As DataRowCollection) As ClsExpiryDetail()
        Dim expiryDetails(0) As ClsExpiryDetail
        expiryDetails = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer

                Array.Resize(expiryDetails, count)
                For x = 0 To count - 1
                    expiryDetails(x) = GetExpiryDetailObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return expiryDetails
    End Function

    ''' <summary>
    ''' This function will give records from Expiry Detail table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>ClsExpiryDetail Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllExpiryDetails(ByVal calledBy As String) As ClsExpiryDetail()
        Dim expiryDetails(0) As ClsExpiryDetail
        expiryDetails = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllExpiryDetail().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    expiryDetails = GetExpiryDetail(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return expiryDetails
    End Function

    ''' <summary>
    ''' This function will give records from Expiry Detail table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="dateFrom">Date from which records are required</param>
    ''' <param name="dateTo">Date upto which records are required</param>
    ''' <returns>Array of ClsExpiryDetail Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllExpiryDetailBetweenDates(ByVal calledBy As String, ByVal dateFrom As Date, ByVal dateTo As Date) As ClsExpiryDetail()
        Dim expiryDetails(0) As ClsExpiryDetail
        expiryDetails = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim fromDate As Date = dateFrom.Date
                Dim toDate As Date = dateTo.Date.AddDays(1).AddMilliseconds(-1)

                Dim sql As String = ClsScripts.GetInstance.GetAllExpiryDetailBetweenDates(fromDate, toDate).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    expiryDetails = GetExpiryDetail(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return expiryDetails
    End Function

    ''' <summary>
    ''' This function will give record from Expiry Detail table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which record is required</param>
    ''' <returns>ClsExpiryDetail Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetExpiryDetail(ByVal calledBy As String, ByVal id As Long) As ClsExpiryDetail
        Dim expiryDetail As ClsExpiryDetail = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetExpiryDetail(id).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    expiryDetail = GetExpiryDetailObj(ds.Tables(0).Rows(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return expiryDetail
    End Function

    ''' <summary>
    ''' This function is used to insert Expiry Detail Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="expiryDetailObj">ClsExpiryDetail object to insert</param>
    ''' <remarks></remarks>
    Public Function InsertIntoExpiryDetail(ByVal calledBy As String, ByRef expiryDetailObj As ClsExpiryDetail) As Long
        Dim result As Long = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoExpiryDetail(expiryDetailObj).Trim
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
    ''' This function is used to update Expiry Detail Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="expiryDetailObj">ClsExpiryDetail object to update</param>
    ''' <remarks></remarks>
    Public Function UpdateExpiryDetail(ByVal calledBy As String, ByRef expiryDetailObj As ClsExpiryDetail) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdateExpiryDetail(expiryDetailObj).Trim
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
    ''' This function is used to delete Expiry Detail Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which the deletion takes place</param>
    ''' <remarks></remarks>
    Public Function DeleteExpiryDetail(ByVal calledBy As String, ByVal id As Long) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.DeleteExpiryDetail(id).Trim
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
