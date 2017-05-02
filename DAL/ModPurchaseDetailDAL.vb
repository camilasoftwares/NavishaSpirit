'Handles all Functionality related to ClsPurchaseDetail
Module ModPurchaseDetailDAL

    Private Function GetPurchaseDetailObj(ByRef row As DataRow) As ClsPurchaseDetail
        Dim purchaseDetail As New ClsPurchaseDetail
        Try
            With row
                purchaseDetail.Id = .Item(cId)
                purchaseDetail.PurchaseId = .Item(cPurchaseId)
                purchaseDetail.ItemId = .Item(cItemId)
                purchaseDetail.ManufacturerId = .Item(cManufacturerId)
                purchaseDetail.Batch = .Item(cBatch)
                purchaseDetail.ExpiryDate = .Item(cExpiryDate)
                purchaseDetail.PricePurchase = .Item(cPricePurchase)
                purchaseDetail.PTS = .Item(cPTS)
                purchaseDetail.Rate1 = .Item(cRate1)
                purchaseDetail.Rate2 = .Item(cRate2)
                purchaseDetail.Rate3 = .Item(cRate3)
                purchaseDetail.TaxPercent = .Item(cTaxPercent)
                purchaseDetail.DiscountPercent = .Item(cDiscountPercent)
                purchaseDetail.PurchaseQuantity = .Item(cPurchaseQuantity)
                purchaseDetail.FreeQuantity = .Item(cFreeQuantity)
                purchaseDetail.StorageId = .Item(cStorageId)
                purchaseDetail.Remark = .Item(cRemark)
                purchaseDetail.UserId = .Item(cUserId)
                purchaseDetail.DateOn = .Item(cDateOn)
                purchaseDetail.TaxAmount = .Item(cTaxAmount)
                purchaseDetail.DiscountAmount = .Item(cDiscountAmount)
                purchaseDetail.PackQuantity = .Item(cPackQuantity)
                purchaseDetail.ManufactureDate = .Item(cManufactureDate)
                purchaseDetail.MRP = .Item(cMRP)
                purchaseDetail.PTR = .Item(cPTR)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return purchaseDetail
    End Function

    Private Function GetPurchaseDetail(ByRef rows As DataRowCollection) As ClsPurchaseDetail()
        Dim purchaseDetails(0) As ClsPurchaseDetail
        purchaseDetails = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer

                Array.Resize(purchaseDetails, count)
                For x = 0 To count - 1
                    purchaseDetails(x) = GetPurchaseDetailObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return purchaseDetails
    End Function

    ''' <summary>
    ''' This function will give records from Purchase Detail table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>ClsPurchaseDetail Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllPurchaseDetail(ByVal calledBy As String) As ClsPurchaseDetail()
        Dim purchaseDetails(0) As ClsPurchaseDetail
        purchaseDetails = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllPurchaseDetail().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    purchaseDetails = GetPurchaseDetail(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return purchaseDetails
    End Function

    ''' <summary>
    ''' This function will give records from Purchase Detail table for given purchase id.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="purchaseId">Purchase Id for which the records are required</param>
    ''' <returns>ClsPurchaseDetail Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllPurchaseDetailForPurchaseId(ByVal calledBy As String, ByVal purchaseId As Integer) As ClsPurchaseDetail()
        Dim purchaseDetails(0) As ClsPurchaseDetail
        purchaseDetails = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllPurchaseDetailForPurchaseId(purchaseId).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    purchaseDetails = GetPurchaseDetail(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return purchaseDetails
    End Function

    ''' <summary>
    ''' This function will give records from Purchase Detail table for given purchase code.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="purchaseCode">Purchase Code for which the records are required</param>
    ''' <returns>ClsPurchaseDetail Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllPurchaseDetailForPurchaseCode(ByVal calledBy As String, ByVal purchaseCode As String) As ClsPurchaseDetail()
        Dim purchaseDetails(0) As ClsPurchaseDetail
        purchaseDetails = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllPurchaseDetailForPurchaseCode(purchaseCode).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    purchaseDetails = GetPurchaseDetail(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return purchaseDetails
    End Function

    ''' <summary>
    ''' This function will give records from Purchase Detail table for given purchase id.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="vendorId">Vendor Id for which the records are required</param>
    ''' <param name="batch">Batch for which the records are required</param>
    ''' <returns>Array of ClsPurchaseDetail Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllPurchaseDetailForVendorIdAndBatch(ByVal calledBy As String, ByVal vendorId As Integer, ByVal batch As String) As ClsPurchaseDetail()
        Dim purchaseDetails(0) As ClsPurchaseDetail
        purchaseDetails = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllPurchaseDetailForVendorIdAndBatch(vendorId, batch).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    purchaseDetails = GetPurchaseDetail(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return purchaseDetails
    End Function

    ''' <summary>
    ''' This function will give last object from Purchase Detail table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="itemId">Item Id for which last purchase object required</param>
    ''' <param name="batch">Batch for which last purchase object required</param>
    ''' <returns>ClsPurchaseDetail pbject or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetPurchaseDetailLastForItemId(ByVal calledBy As String, ByVal itemId As Integer, ByVal batch As String) As ClsPurchaseDetail
        Dim purchaseDetail As ClsPurchaseDetail = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetPurchaseDetailLastForItemId(itemId, batch).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    purchaseDetail = GetPurchaseDetailObj(ds.Tables(0).Rows(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return purchaseDetail
    End Function

    ''' <summary>
    ''' This function will give last purchase price from Purchase Detail table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="itemId">Item Id for which last purchase price is required</param>
    ''' <returns>Price in Double or 0</returns>
    ''' <remarks></remarks>
    Public Function GetPurchaseDetailLastPriceForItemId(ByVal calledBy As String, ByVal itemId As Integer) As Double
        Dim result As Double = 0

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetPurchaseDetailLastPriceForItemId(itemId).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    If IsDBNull(ds.Tables(0).Rows(0).Item(0)) = True Then Exit Try

                    result = Val(ds.Tables(0).Rows(0).Item(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    ''' <summary>
    ''' This function is used to insert Purchase Detail Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="purchaseDetailObj">ClsPurchaseDetail object to insert</param>
    ''' <returns>Id in Long or -1</returns>
    ''' <remarks></remarks>
    Public Function InsertIntoPurchaseDetail(ByVal calledBy As String, ByRef purchaseDetailObj As ClsPurchaseDetail) As Long
        Dim result As Long = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoPurchaseDetail(purchaseDetailObj).Trim
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
    ''' This function is used to update Purchase Detail Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="purchaseDetailObj">ClsPurchaseDetail object to update</param>
    ''' <remarks></remarks>
    Public Function UpdatePurchaseDetail(ByVal calledBy As String, ByRef purchaseDetailObj As ClsPurchaseDetail) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdatePurchaseDetail(purchaseDetailObj).Trim
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
    ''' This function is used to delete Purchase Detail Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which the deletion takes place</param>
    ''' <remarks></remarks>
    Public Function DeletePurchaseDetail(ByVal calledBy As String, ByVal id As Long) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.DeletePurchaseDetail(id).Trim
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