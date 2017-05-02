Module ModPurchaseReturnDetailDAL

    Private Function GetPurchaseReturnDetailObj(ByRef row As DataRow) As ClsPurchaseReturnDetail
        Dim purchaseReturnDetailObj As New ClsPurchaseReturnDetail
        Try
            With row
                purchaseReturnDetailObj.Id = .Item(cId)
                purchaseReturnDetailObj.PurchaseReturnId = .Item(cPurchaseReturnId)
                purchaseReturnDetailObj.ItemId = .Item(cItemId)
                purchaseReturnDetailObj.Batch = .Item(cBatch)
                purchaseReturnDetailObj.ExpiryDate = .Item(cExpiryDate)
                purchaseReturnDetailObj.PricePurchase = .Item(cPricePurchase)
                purchaseReturnDetailObj.PriceSale = .Item(cPriceSale)
                purchaseReturnDetailObj.TaxPercent = .Item(cTaxPercent)
                purchaseReturnDetailObj.DiscountPercent = .Item(cDiscountPercent)
                purchaseReturnDetailObj.TaxAmount = .Item(cTaxAmount)
                purchaseReturnDetailObj.DiscountAmount = .Item(cDiscountAmount)
                purchaseReturnDetailObj.ReturnQuantity = .Item(cReturnQuantity)
                purchaseReturnDetailObj.FreeQuantity = .Item(cFreeQuantity)
                purchaseReturnDetailObj.StorageId = .Item(cStorageId)
                purchaseReturnDetailObj.Remark = .Item(cRemark)
                purchaseReturnDetailObj.UserId = .Item(cUserId)
                purchaseReturnDetailObj.DateOn = .Item(cDateOn)
                purchaseReturnDetailObj.PackQuantity = .Item(cPackQuantity)
                purchaseReturnDetailObj.PurchaseId = .Item(cPurchaseId)
                purchaseReturnDetailObj.NonSaleable = .Item(cNonSaleable)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return purchaseReturnDetailObj
    End Function

    Private Function GetPurchaseReturnDetail(ByRef rows As DataRowCollection) As ClsPurchaseReturnDetail()
        Dim purchaseReturnDetailObjs(0) As ClsPurchaseReturnDetail
        purchaseReturnDetailObjs = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer
                Array.Resize(purchaseReturnDetailObjs, count)
                For x = 0 To count - 1
                    purchaseReturnDetailObjs(x) = GetPurchaseReturnDetailObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return purchaseReturnDetailObjs
    End Function

    ''' <summary>
    ''' This function will give records from PurchaseReturnDetail table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>ClsPurchaseReturnDetail Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllPurchaseReturnDetails(ByVal calledBy As String) As ClsPurchaseReturnDetail()
        Dim purchaseReturnDetailObjs(0) As ClsPurchaseReturnDetail
        purchaseReturnDetailObjs = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllPurchaseReturnDetail().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    purchaseReturnDetailObjs = GetPurchaseReturnDetail(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return purchaseReturnDetailObjs
    End Function

    ''' <summary>
    ''' This function will give records from PurchaseReturnDetail table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="Id">Puchase Return Id for which records are required</param>
    ''' <returns>ClsPurchaseReturnDetails Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllPurchaseReturnDetailForPurchaseReturnId(ByVal calledBy As String, ByVal id As Integer) As ClsPurchaseReturnDetail()
        Dim purchaseReturnDetailObjs(0) As ClsPurchaseReturnDetail
        purchaseReturnDetailObjs = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllPurchaseReturnDetailForPurchaseReturnId(id).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    purchaseReturnDetailObjs = GetPurchaseReturnDetail(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return purchaseReturnDetailObjs
    End Function

    ''' <summary>
    ''' This function will give records from PurchaseReturnDetail table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="value">Field for which record is required</param>
    ''' <returns>ClsPurchaseReturnDetail Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetPurchaseReturnDetailById(ByVal calledBy As String, ByVal value As Long) As ClsPurchaseReturnDetail
        Dim purchaseReturnDetailObj As ClsPurchaseReturnDetail = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetPurchaseReturnDetailById(value).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    purchaseReturnDetailObj = GetPurchaseReturnDetailObj(ds.Tables(0).Rows(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return purchaseReturnDetailObj
    End Function

    ''' <summary>
    ''' This function is used to insert PurchaseReturnDetail Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="purchaseReturnDetailObj">ClsPurchaseReturnDetail object to insert</param>
    ''' <returns>Auto generated Id</returns>
    ''' <remarks></remarks>
    Public Function InsertPurchaseReturnDetail(ByVal calledBy As String, ByRef purchaseReturnDetailObj As ClsPurchaseReturnDetail) As Integer
        Dim result As Integer = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertPurchaseReturnDetail(purchaseReturnDetailObj).Trim
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
    ''' This function is used to update PurchaseReturnDetail Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="purchaseReturnDetailObj">ClsPurchaseReturnDetail object to update</param>
    ''' <remarks></remarks>
    Public Function UpdatePurchaseReturnDetail(ByVal calledBy As String, ByRef purchaseReturnDetailObj As ClsPurchaseReturnDetail) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdatePurchaseReturnDetail(purchaseReturnDetailObj).Trim
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
    ''' This function is used to delete PurchaseReturnDetail Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="value">Value for which record is to delete</param>
    ''' <remarks></remarks>
    Public Function DeletePurchaseReturnDetail(ByVal calledBy As String, ByVal value As Long) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.DeletePurchaseReturnDetail(value).Trim
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