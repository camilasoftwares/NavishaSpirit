'Handles all Functionality related to ClsDestructionSlipDetail
Module ModDestructionSlipDetailDAL

    Private Function GetDestructionSlipDetailObj(ByRef row As DataRow) As ClsDestructionSlipDetail
        Dim destructionSlipDetail As New ClsDestructionSlipDetail
        Try
            With row
                destructionSlipDetail.Id = .Item(cId)
                destructionSlipDetail.DestructionSlipId = .Item(cDestructionSlipId)
                destructionSlipDetail.ItemId = .Item(cItemId)
                destructionSlipDetail.Batch = .Item(cBatch)
                destructionSlipDetail.ExpiryDate = .Item(cExpiryDate)
                destructionSlipDetail.PackQuantity = .Item(cPackQuantity)
                destructionSlipDetail.DestructionQuantity = .Item(cDestructionQuantity)
                destructionSlipDetail.PricePurchase = .Item(cPricePurchase)
                destructionSlipDetail.PriceSale = .Item(cPriceSale)
                destructionSlipDetail.TaxPercent = .Item(cTaxPercent)
                destructionSlipDetail.DiscountPercent = .Item(cDiscountPercent)
                destructionSlipDetail.TaxAmount = .Item(cTaxAmount)
                destructionSlipDetail.DiscountAmount = .Item(cDiscountAmount)
                destructionSlipDetail.DiscountAmount = .Item(cDiscountAmount)
                destructionSlipDetail.StorageId = .Item(cStorageId)
                destructionSlipDetail.Remark = .Item(cRemark)
                destructionSlipDetail.UserId = .Item(cUserId)
                destructionSlipDetail.DateOn = .Item(cDateOn)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return destructionSlipDetail
    End Function

    Private Function GetDestructionSlipDetail(ByRef rows As DataRowCollection) As ClsDestructionSlipDetail()
        Dim destructionSlipDetails(0) As ClsDestructionSlipDetail
        destructionSlipDetails = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer

                Array.Resize(destructionSlipDetails, count)
                For x = 0 To count - 1
                    destructionSlipDetails(x) = GetDestructionSlipDetailObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return destructionSlipDetails
    End Function

    ''' <summary>
    ''' This function will give records from Destruction Slip Detail table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>ClsDestructionSlipDetail Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllDestructionSlipDetails(ByVal calledBy As String) As ClsDestructionSlipDetail()
        Dim destructionSlipDetails(0) As ClsDestructionSlipDetail
        destructionSlipDetails = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllDestructionSlipDetail().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    destructionSlipDetails = GetDestructionSlipDetail(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return destructionSlipDetails
    End Function

    ''' <summary>
    ''' This function will give records from Destruction Slip Detail table for given destructionSlip id.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="destructionSlipId">DestructionSlip Id for which the records are required</param>
    ''' <returns>ClsDestructionSlipDetail Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllDestructionSlipDetailForDestructionSlipId(ByVal calledBy As String, ByVal destructionSlipId As Long) As ClsDestructionSlipDetail()
        Dim destructionSlipDetails(0) As ClsDestructionSlipDetail
        destructionSlipDetails = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllDestructionSlipDetailForDestructionSlipId(destructionSlipId).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    destructionSlipDetails = GetDestructionSlipDetail(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return destructionSlipDetails
    End Function

    ''' <summary>
    ''' This function will give records from Destruction Slip Detail table for given destructionSlip code.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="destructionSlipCode">DestructionSlip code for which the records are required</param>
    ''' <returns>ClsDestructionSlipDetail Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllDestructionSlipDetailForDestructionSlipCode(ByVal calledBy As String, ByVal destructionSlipCode As String) As ClsDestructionSlipDetail()
        Dim destructionSlipDetails(0) As ClsDestructionSlipDetail
        destructionSlipDetails = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllDestructionSlipDetailForDestructionSlipCode(destructionSlipCode).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    destructionSlipDetails = GetDestructionSlipDetail(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return destructionSlipDetails
    End Function

    ''' <summary>
    ''' This function will give record from Destruction Slip Detail table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which record is required</param>
    ''' <returns>ClsDestructionSlipDetail Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetDestructionSlipDetail(ByVal calledBy As String, ByVal id As Long) As ClsDestructionSlipDetail
        Dim destructionSlipDetail As ClsDestructionSlipDetail = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetDestructionSlipDetail(id).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    destructionSlipDetail = GetDestructionSlipDetailObj(ds.Tables(0).Rows(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return destructionSlipDetail
    End Function

    ''' <summary>
    ''' This function is used to insert Destruction Slip Detail Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="destructionSlipDetailObj">ClsDestructionSlipDetail object to insert</param>
    ''' <remarks></remarks>
    Public Function InsertIntoDestructionSlipDetail(ByVal calledBy As String, ByRef destructionSlipDetailObj As ClsDestructionSlipDetail) As Long
        Dim result As Long = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoDestructionSlipDetail(destructionSlipDetailObj).Trim
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
    ''' This function is used to update Destruction Slip Detail Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="destructionSlipDetailObj">ClsDestructionSlipDetail object to update</param>
    ''' <remarks></remarks>
    Public Function UpdateDestructionSlipDetail(ByVal calledBy As String, ByRef destructionSlipDetailObj As ClsDestructionSlipDetail) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdateDestructionSlipDetail(destructionSlipDetailObj).Trim
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
    ''' This function is used to delete Destruction Slip Detail Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which the deletion takes place</param>
    ''' <remarks></remarks>
    Public Function DeleteDestructionSlipDetail(ByVal calledBy As String, ByVal id As Long) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.DeleteDestructionSlipDetail(id).Trim
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
