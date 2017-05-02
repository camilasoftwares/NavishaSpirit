'Handles all Functionality related to ClsPurchaseOrderDetail
Module ModPurchaseOrderDetailDAL

    Private Function GetPurchaseOrderDetailObj(ByRef row As DataRow) As ClsPurchaseOrderDetail
        Dim purchaseOrderDetail As New ClsPurchaseOrderDetail
        Try
            With row
                purchaseOrderDetail.Id = .Item(cId)
                purchaseOrderDetail.OrderId = .Item(cOrderId)
                purchaseOrderDetail.ItemId = .Item(cItemId)
                purchaseOrderDetail.OrderQuantity = .Item(cOrderQuantity)
                purchaseOrderDetail.OrderPrice = .Item(cOrderPrice)
                purchaseOrderDetail.PricePurchasePrevious = .Item(cPricePurchasePrevious)
                purchaseOrderDetail.VendorId = .Item(cVendorId)
                purchaseOrderDetail.ManufacturerId = .Item(cManufacturerId)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return purchaseOrderDetail
    End Function

    Private Function GetPurchaseOrderDetail(ByRef rows As DataRowCollection) As ClsPurchaseOrderDetail()
        Dim purchaseOrderDetails(0) As ClsPurchaseOrderDetail
        purchaseOrderDetails = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer

                Array.Resize(purchaseOrderDetails, count)
                For x = 0 To count - 1
                    purchaseOrderDetails(x) = GetPurchaseOrderDetailObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return purchaseOrderDetails
    End Function

    ''' <summary>
    ''' This function will give records from Purchase Order Detail table for given purchaseOrder id.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="purchaseOrderId">PurchaseOrder Id for which the records are required</param>
    ''' <returns>Array of ClsPurchaseOrderDetail Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllPurchaseOrderDetailForPurchaseOrderId(ByVal calledBy As String, ByVal purchaseOrderId As Long) As ClsPurchaseOrderDetail()
        Dim purchaseOrderDetails(0) As ClsPurchaseOrderDetail
        purchaseOrderDetails = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllPurchaseOrderDetailForPurchaseOrderId(purchaseOrderId).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    purchaseOrderDetails = GetPurchaseOrderDetail(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return purchaseOrderDetails
    End Function

    ''' <summary>
    ''' This function will give record from Purchase Order Detail table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which record is required</param>
    ''' <returns>ClsPurchaseOrderDetail Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetPurchaseOrderDetail(ByVal calledBy As String, ByVal id As Long) As ClsPurchaseOrderDetail
        Dim purchaseOrderDetail As ClsPurchaseOrderDetail = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetPurchaseOrderDetail(id).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    purchaseOrderDetail = GetPurchaseOrderDetailObj(ds.Tables(0).Rows(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return purchaseOrderDetail
    End Function

    ''' <summary>
    ''' This function will give records from Purchase Detail table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>ClsPurchaseOrderDetail Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllPurchaseOrderDetail(ByVal calledBy As String) As ClsPurchaseOrderDetail()
        Dim purchaseOrderDetails(0) As ClsPurchaseOrderDetail
        purchaseOrderDetails = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllPurchaseOrderDetail().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    purchaseOrderDetails = GetPurchaseOrderDetail(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return purchaseOrderDetails
    End Function

    ''' <summary>
    ''' This function is used to insert Purchase Detail Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="purchaseOrderDetailObj">ClsPurchaseOrderDetail object to insert</param>
    ''' <returns>Id in Long or -1</returns>
    ''' <remarks></remarks>
    Public Function InsertIntoPurchaseOrderDetail(ByVal calledBy As String, ByRef purchaseOrderDetailObj As ClsPurchaseOrderDetail) As Long
        Dim result As Long = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoPurchaseOrderDetail(purchaseOrderDetailObj).Trim
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
    ''' <param name="purchaseOrderDetailObj">ClsPurchaseOrderDetail object to update</param>
    ''' <remarks></remarks>
    Public Function UpdatePurchaseOrderDetail(ByVal calledBy As String, ByRef purchaseOrderDetailObj As ClsPurchaseOrderDetail) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdatePurchaseOrderDetail(purchaseOrderDetailObj).Trim
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
    ''' This function is used to delete Purchase Order Detail Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which the deletion takes place</param>
    ''' <remarks></remarks>
    Public Function DeletePurchaseOrderDetail(ByVal calledBy As String, ByVal id As Long) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.DeletePurchaseOrderDetail(id).Trim
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