'Handles all Functionality related to ClsSalesDetail
Module ModSalesDetailDAL

    Dim dsSaleDetail As DataSet = Nothing

    Private Function GetSalesDetailObj(ByRef row As DataRow) As ClsSalesDetail
        Dim salesDetail As New ClsSalesDetail
        Try
            With row
                salesDetail.Id = .Item(cId)
                salesDetail.SaleId = .Item(cSaleId)
                salesDetail.ItemId = .Item(cItemId)
                salesDetail.Batch = .Item(cBatch)
                salesDetail.ExpiryDate = .Item(cExpiryDate)
                salesDetail.PackQuantity = .Item(cPackQuantity)
                salesDetail.SaleQuantity = .Item(cSaleQuantity)
                salesDetail.FreeQuantity = .Item(cFreeQuantity)
                salesDetail.PricePurchase = .Item(cPricePurchase)
                salesDetail.PriceSale = .Item(cPriceSale)
                salesDetail.TaxPercent = .Item(cTaxPercent)
                salesDetail.DiscountPercent = .Item(cDiscountPercent)
                salesDetail.DiscountAmount = .Item(cDiscountAmount)
                salesDetail.TaxAmount = .Item(cTaxAmount)
                salesDetail.StorageId = .Item(cStorageId)
                salesDetail.Remark = .Item(cRemark)
                salesDetail.ForCashOut = .Item(cForCashOut)
                salesDetail.UserId = .Item(cUserId)
                salesDetail.DateOn = .Item(cDateOn)
                salesDetail.ManufactureDate = .Item(cManufactureDate)
                salesDetail.MRP = .Item(cMRP)
                salesDetail.PTR = .Item(cPTR)
                salesDetail.PTS = .Item(cPTS)
                salesDetail.Rate1 = .Item(cRate1)
                salesDetail.Rate2 = .Item(cRate2)
                salesDetail.Rate3 = .Item(cRate3)
                salesDetail.ManufacturerId = .Item(cManufacturerId)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return salesDetail
    End Function

    Private Function GetSalesDetail(ByRef rows As DataRowCollection) As ClsSalesDetail()
        Dim salesDetails(0) As ClsSalesDetail
        salesDetails = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer

                Array.Resize(salesDetails, count)
                For x = 0 To count - 1
                    salesDetails(x) = GetSalesDetailObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return salesDetails
    End Function

    Private Function GetSalesDetail(ByRef rows() As DataRow) As ClsSalesDetail()
        Dim salesDetails(0) As ClsSalesDetail
        salesDetails = Nothing

        Try
            Dim count As Integer = rows.Length
            If count > 0 Then
                Dim x As Integer

                Array.Resize(salesDetails, count)
                For x = 0 To count - 1
                    salesDetails(x) = GetSalesDetailObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return salesDetails
    End Function

    ''' <summary>
    ''' This function will give records from Sales Detail table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>ClsSalesDetail Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllSalesDetail(ByVal calledBy As String) As ClsSalesDetail()
        Dim salesDetails(0) As ClsSalesDetail
        salesDetails = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllSalesDetail().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    salesDetails = GetSalesDetail(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return salesDetails
    End Function

    ''' <summary>
    ''' This function will give records from Sales Detail table for given sales id.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="salesId">Sales Id for which the records are required</param>
    ''' <returns>Array of ClsSalesDetail Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllSalesDetailForSalesId(ByVal calledBy As String, ByVal salesId As Long) As ClsSalesDetail()
        Dim salesDetails(0) As ClsSalesDetail
        salesDetails = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllSalesDetailForSalesId(salesId).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    salesDetails = GetSalesDetail(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return salesDetails
    End Function

    ''' <summary>
    ''' This function will give records given sale id from preserved dataset.
    ''' </summary>
    ''' <param name="saleId">Sale Id for which the records are required</param>
    ''' <returns>List of ClsSalesDetail Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllSalesDetailForSaleId(ByVal saleId As Long) As List(Of ClsSalesDetail)
        Dim salesDetailList As New List(Of ClsSalesDetail)

        Try
            Dim temp As Integer
            For temp = 0 To 0
                If dsSaleDetail Is Nothing Then Exit For

                If dsSaleDetail.Tables(0).Rows.Count > 0 Then
                    Dim str As String = cSaleId + " = " + CStr(saleId)
                    Dim dtRow() As DataRow = dsSaleDetail.Tables(0).Select(str)
                    If dtRow.Length <> 0 Then salesDetailList.AddRange(GetSalesDetail(dtRow))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return salesDetailList
    End Function

    ''' <summary>
    ''' This function will give records from Sales Detail table for given sale ids.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="saleIdList">List of Sale Ids for which the records are required</param>
    ''' <returns>List of ClsSalesDetail Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllSalesDetailForSaleIds(ByVal calledBy As String, ByVal saleIdList As List(Of Long)) As List(Of ClsSalesDetail)
        Dim saleDetailList As New List(Of ClsSalesDetail)

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim ids As String = ""
                For Each id As Long In saleIdList
                    If ids.Trim <> "" Then ids = ids + ","
                    ids = ids + CStr(id)
                Next

                If ids.Trim = "" Then Exit For

                Dim sql As String = ClsScripts.GetInstance.GetAllSalesDetailForSaleIds(ids).Trim
                If sql = "" Then Exit For

                dsSaleDetail = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If dsSaleDetail.Tables(0).Rows.Count > 0 Then
                    saleDetailList.AddRange(GetSalesDetail(dsSaleDetail.Tables(0).Rows))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return saleDetailList
    End Function

    ''' <summary>
    ''' This function will give records from Sales Detail table for given sales id.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="customerId">Customer Id for which the records are required</param>
    ''' <param name="batch">Batch for which the records are required</param>
    ''' <returns>Array of ClsSalesDetail Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllSalesDetailForCustomerIdAndBatch(ByVal calledBy As String, ByVal customerId As Integer, ByVal batch As String) As ClsSalesDetail()
        Dim salesDetails(0) As ClsSalesDetail
        salesDetails = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllSalesDetailForCustomerIdAndBatch(customerId, batch).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    salesDetails = GetSalesDetail(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return salesDetails
    End Function

    ''' <summary>
    ''' This function will give records from Sales Detail table for given sales id.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="salesCode">Sales Code for which the records are required</param>
    ''' <returns>Array of ClsSalesDetail Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllSalesDetailForSalesCode(ByVal calledBy As String, ByVal salesCode As String) As ClsSalesDetail()
        Dim salesDetails(0) As ClsSalesDetail
        salesDetails = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllSalesDetailForSalesCode(salesCode).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    salesDetails = GetSalesDetail(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return salesDetails
    End Function

    ''' <summary>
    ''' This function will give record from Sales Detail table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which record is required</param>
    ''' <returns>ClsSalesDetail Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetSalesDetail(ByVal calledBy As String, ByVal id As Long) As ClsSalesDetail
        Dim salesDetail As ClsSalesDetail = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetSalesDetail(id).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    salesDetail = GetSalesDetailObj(ds.Tables(0).Rows(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return salesDetail
    End Function

    ''' <summary>
    ''' This function is used to insert Sales Detail Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="salesDetailObj">ClsSalesDetail object to insert</param>
    ''' <remarks></remarks>
    Public Function InsertIntoSalesDetail(ByVal calledBy As String, ByRef salesDetailObj As ClsSalesDetail) As Integer
        Dim result As Integer = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoSalesDetail(salesDetailObj).Trim
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
    ''' This function is used to update Sales Detail Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="salesDetailObj">ClsSalesDetail object to update</param>
    ''' <remarks></remarks>
    Public Function UpdateSalesDetail(ByVal calledBy As String, ByRef salesDetailObj As ClsSalesDetail) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdateSalesDetail(salesDetailObj).Trim
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
    ''' This function is used to delete Sales Detail Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which the deletion takes place</param>
    ''' <remarks></remarks>
    Public Function DeleteSalesDetail(ByVal calledBy As String, ByVal id As Long) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.DeleteSalesDetail(id).Trim
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