'Handles all Functionality related to ClsSalesReturnDetail
Module ModSalesReturnDetailDAL

    Private Function GetSalesReturnDetailObj(ByRef row As DataRow) As ClsSalesReturnDetail
        Dim salesReturnDetail As New ClsSalesReturnDetail
        Try
            With row
                salesReturnDetail.Id = .Item(cId)
                salesReturnDetail.SalesReturnId = .Item(cSalesReturnId)
                salesReturnDetail.ItemId = .Item(cItemId)
                salesReturnDetail.Batch = .Item(cBatch)
                salesReturnDetail.ExpiryDate = .Item(cExpiryDate)
                salesReturnDetail.PackQuantity = .Item(cPackQuantity)
                salesReturnDetail.ReturnQuantity = .Item(cReturnQuantity)
                salesReturnDetail.PricePurchase = .Item(cPricePurchase)
                salesReturnDetail.PriceSale = .Item(cPriceSale)
                salesReturnDetail.TaxPercent = .Item(cTaxPercent)
                salesReturnDetail.DiscountPercent = .Item(cDiscountPercent)
                salesReturnDetail.TaxAmount = .Item(cTaxAmount)
                salesReturnDetail.DiscountAmount = .Item(cDiscountAmount)
                salesReturnDetail.StorageId = .Item(cStorageId)
                salesReturnDetail.Remark = .Item(cRemark)
                salesReturnDetail.SaleId = .Item(cSaleId)
                salesReturnDetail.UserId = .Item(cUserId)
                salesReturnDetail.DateOn = .Item(cDateOn)
                salesReturnDetail.NonSaleable = .Item(cNonSaleable)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return salesReturnDetail
    End Function

    Private Function GetSalesReturnDetail(ByRef rows As DataRowCollection) As ClsSalesReturnDetail()
        Dim salesReturnDetails(0) As ClsSalesReturnDetail
        salesReturnDetails = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer
                Array.Resize(SalesReturnDetails, count)
                For x = 0 To count - 1
                    salesReturnDetails(x) = GetSalesReturnDetailObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return salesReturnDetails
    End Function

    ''' <summary>
    ''' This function will give records from Sales Return Detail table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>ClsSalesReturnDetail Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllSalesReturnDetail(ByVal calledBy As String) As ClsSalesReturnDetail()
        Dim salesReturnDetails(0) As ClsSalesReturnDetail
        salesReturnDetails = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllSalesReturnDetail().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    salesReturnDetails = GetSalesReturnDetail(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return salesReturnDetails
    End Function

    ''' <summary>
    ''' This function will give records from Sales Return Detail table for given salesReturn id.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="salesReturnId">SalesReturn Id for which the records are required</param>
    ''' <returns>Array of ClsSalesReturnDetail Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllSalesReturnDetailForSalesReturnId(ByVal calledBy As String, ByVal salesReturnId As Long) As ClsSalesReturnDetail()
        Dim salesReturnDetails(0) As ClsSalesReturnDetail
        salesReturnDetails = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllSalesReturnDetailForSalesReturnId(salesReturnId).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    salesReturnDetails = GetSalesReturnDetail(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return salesReturnDetails
    End Function

    ''' <summary>
    ''' This function will give record from Sales Return Detail table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>ClsSalesReturnDetail Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetSalesReturnDetail(ByVal calledBy As String, ByVal id As Long) As ClsSalesReturnDetail
        Dim salesReturnDetail As ClsSalesReturnDetail = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetSalesReturnDetail(id).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    salesReturnDetail = GetSalesReturnDetailObj(ds.Tables(0).Rows(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return salesReturnDetail
    End Function

    ''' <summary>
    ''' This function is used to insert Sales Return Detail Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="salesReturnDetailsObj">ClsSalesReturnDetails object to insert</param>
    ''' <returns>Id in long</returns>
    ''' <remarks></remarks>
    Public Function InsertIntoSalesReturnDetail(ByVal calledBy As String, ByRef salesReturnDetailsObj As ClsSalesReturnDetail) As Long
        Dim result As Long = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoSalesReturnDetail(salesReturnDetailsObj).Trim
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
    ''' This function is used to update Sales Return Detail Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="salesReturnDetailsObj">ClsSalesReturnDetails object to update</param>
    ''' <remarks></remarks>
    Public Function UpdateSalesReturnDetail(ByVal calledBy As String, ByRef salesReturnDetailsObj As ClsSalesReturnDetail) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdateSalesReturnDetail(salesReturnDetailsObj).Trim
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
    ''' This function is used to delete Sales Return Detail Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which the deletion takes place</param>
    ''' <remarks></remarks>
    Public Function DeleteSalesReturnDetail(ByVal calledBy As String, ByVal id As Long) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.DeleteSalesReturnDetail(id).Trim
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
