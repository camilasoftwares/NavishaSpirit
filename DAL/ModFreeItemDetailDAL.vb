'Handles all Functionality related to ClsFreeItemDetail
Module ModFreeItemDetailDAL

    Private Function GetFreeItemDetailObj(ByRef row As DataRow) As ClsFreeItemDetail
        Dim freeItemDetail As New ClsFreeItemDetail
        Try
            With row
                freeItemDetail.Id = .Item(cId)
                freeItemDetail.PurchaseId = .Item(cPurchaseId)
                freeItemDetail.ItemId = .Item(cItemId)
                freeItemDetail.Batch = .Item(cBatch)
                freeItemDetail.FreeQuantity = .Item(cFreeQuantity)
                freeItemDetail.Remark = .Item(cRemark)
                freeItemDetail.UserId = .Item(cUserId)
                freeItemDetail.DateOn = .Item(cDateOn)
                freeItemDetail.PackQuantity = .Item(cPackQuantity)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return freeItemDetail
    End Function

    Private Function GetFreeItemDetail(ByRef rows As DataRowCollection) As ClsFreeItemDetail()
        Dim freeItemDetails(0) As ClsFreeItemDetail
        freeItemDetails = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer

                Array.Resize(freeItemDetails, count)
                For x = 0 To count - 1
                    freeItemDetails(x) = GetFreeItemDetailObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return freeItemDetails
    End Function

    ''' <summary>
    ''' This function will give records from Free Item Detail table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>ClsFreeItemDetail Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllFreeItemDetail(ByVal calledBy As String) As ClsFreeItemDetail()
        Dim freeItemDetails(0) As ClsFreeItemDetail
        freeItemDetails = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllFreeItemDetail().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    freeItemDetails = GetFreeItemDetail(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return freeItemDetails
    End Function

    ''' <summary>
    ''' This function will give records from Free Item Detail table for given purchase id.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="purchaseId">Purchase Id for which the records are required</param>
    ''' <returns>ClsFreeItemDetail Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllFreeItemDetailForPurchaseId(ByVal calledBy As String, ByVal purchaseId As Integer) As ClsFreeItemDetail()
        Dim freeItemDetails(0) As ClsFreeItemDetail
        freeItemDetails = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllFreeItemDetailForPurchaseId(purchaseId).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    freeItemDetails = GetFreeItemDetail(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return freeItemDetails
    End Function

    ''' <summary>
    ''' This function will give last object from Free Item Detail table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="itemId">Item Id for which last purchase object required</param>
    ''' <param name="batch">Batch for which last purchase object required</param>
    ''' <returns>ClsFreeItemDetail pbject or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetFreeItemDetailLastForItemId(ByVal calledBy As String, ByVal itemId As Integer, ByVal batch As String) As ClsFreeItemDetail
        Dim freeItemDetail As ClsFreeItemDetail = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetFreeItemDetailLastForItemId(itemId, batch).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    freeItemDetail = GetFreeItemDetailObj(ds.Tables(0).Rows(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return freeItemDetail
    End Function

    ''' <summary>
    ''' This function will give last purchase price from Free Item Detail table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="itemId">Item Id for which last purchase price is required</param>
    ''' <returns>Price in Double or 0</returns>
    ''' <remarks></remarks>
    Public Function GetFreeItemDetailLastPriceForItemId(ByVal calledBy As String, ByVal itemId As Integer) As Double
        Dim result As Double = 0

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetFreeItemDetailLastPriceForItemId(itemId).Trim
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
    ''' This function is used to insert Free Item Detail Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="freeItemDetailObj">ClsFreeItemDetail object to insert</param>
    ''' <returns>Id in Long or -1</returns>
    ''' <remarks></remarks>
    Public Function InsertIntoFreeItemDetail(ByVal calledBy As String, ByRef freeItemDetailObj As ClsFreeItemDetail) As Long
        Dim result As Long = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoFreeItemDetail(freeItemDetailObj).Trim
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
    ''' This function is used to update Free Item Detail Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="freeItemDetailObj">ClsFreeItemDetail object to update</param>
    ''' <remarks></remarks>
    Public Function UpdateFreeItemDetail(ByVal calledBy As String, ByRef freeItemDetailObj As ClsFreeItemDetail) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdateFreeItemDetail(freeItemDetailObj).Trim
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
    ''' This function is used to delete Free Item Detail Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which the deletion takes place</param>
    ''' <remarks></remarks>
    Public Function DeleteFreeItemDetail(ByVal calledBy As String, ByVal id As Long) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.DeleteFreeItemDetail(id).Trim
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