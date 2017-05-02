'Handles all Functionality related to ClsSampleDetail
Module ModSampleDetailDAL

    Dim dsSampleDetail As DataSet = Nothing

    Private Function GetSampleDetailObj(ByRef row As DataRow) As ClsSampleDetail
        Dim sampleDetail As New ClsSampleDetail
        Try
            With row
                sampleDetail.Id = .Item(cId)
                sampleDetail.SampleId = .Item(cSampleId)
                sampleDetail.ItemId = .Item(cItemId)
                sampleDetail.Batch = .Item(cBatch)
                sampleDetail.ExpiryDate = .Item(cExpiryDate)
                sampleDetail.PackQuantity = .Item(cPackQuantity)
                sampleDetail.SampleQuantity = .Item(cSampleQuantity)
                sampleDetail.FreeQuantity = .Item(cFreeQuantity)
                sampleDetail.PricePurchase = .Item(cPricePurchase)
                sampleDetail.PriceSample = .Item(cPriceSample)
                sampleDetail.TaxPercent = .Item(cTaxPercent)
                sampleDetail.DiscountPercent = .Item(cDiscountPercent)
                sampleDetail.DiscountAmount = .Item(cDiscountAmount)
                sampleDetail.TaxAmount = .Item(cTaxAmount)
                sampleDetail.StorageId = .Item(cStorageId)
                sampleDetail.Remark = .Item(cRemark)
                sampleDetail.ForCashOut = .Item(cForCashOut)
                sampleDetail.UserId = .Item(cUserId)
                sampleDetail.DateOn = .Item(cDateOn)
                sampleDetail.ManufactureDate = .Item(cManufactureDate)
                sampleDetail.MRP = .Item(cMRP)
                sampleDetail.PTR = .Item(cPTR)
                sampleDetail.PTS = .Item(cPTS)
                sampleDetail.Rate1 = .Item(cRate1)
                sampleDetail.Rate2 = .Item(cRate2)
                sampleDetail.Rate3 = .Item(cRate3)
                sampleDetail.ManufacturerId = .Item(cManufacturerId)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return sampleDetail
    End Function

    Private Function GetSampleDetail(ByRef rows As DataRowCollection) As ClsSampleDetail()
        Dim sampleDetails(0) As ClsSampleDetail
        sampleDetails = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer

                Array.Resize(sampleDetails, count)
                For x = 0 To count - 1
                    sampleDetails(x) = GetSampleDetailObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return sampleDetails
    End Function

    Private Function GetSampleDetail(ByRef rows() As DataRow) As ClsSampleDetail()
        Dim sampleDetails(0) As ClsSampleDetail
        sampleDetails = Nothing

        Try
            Dim count As Integer = rows.Length
            If count > 0 Then
                Dim x As Integer

                Array.Resize(sampleDetails, count)
                For x = 0 To count - 1
                    sampleDetails(x) = GetSampleDetailObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return sampleDetails
    End Function

    ''' <summary>
    ''' This function will give records from Sample Detail table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>ClsSampleDetail Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllSampleDetail(ByVal calledBy As String) As ClsSampleDetail()
        Dim sampleDetails(0) As ClsSampleDetail
        sampleDetails = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllSampleDetail().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    sampleDetails = GetSampleDetail(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return sampleDetails
    End Function

    ''' <summary>
    ''' This function will give records from Sample Detail table for given sample id.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="sampleId">Sample Id for which the records are required</param>
    ''' <returns>Array of ClsSampleDetail Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllSampleDetailForSampleId(ByVal calledBy As String, ByVal sampleId As Long) As ClsSampleDetail()
        Dim sampleDetails(0) As ClsSampleDetail
        sampleDetails = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllSampleDetailForSampleId(sampleId).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    sampleDetails = GetSampleDetail(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return sampleDetails
    End Function

    ''' <summary>
    ''' This function will give records from Sample Detail table for given sample id.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="sampleCode">Sample Code for which the records are required</param>
    ''' <returns>Array of ClsSampleDetail Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllSampleDetailForSampleCode(ByVal calledBy As String, ByVal sampleCode As String) As ClsSampleDetail()
        Dim sampleDetails(0) As ClsSampleDetail
        sampleDetails = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllSampleDetailForSampleCode(sampleCode).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    sampleDetails = GetSampleDetail(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return sampleDetails
    End Function

    ''' <summary>
    ''' This function will give records from Sample Detail table for given sample ids.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="sampleIdList">List of Sample Ids for which the records are required</param>
    ''' <returns>List of ClsSampleDetail Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllSampleDetailForSampleIds(ByVal calledBy As String, ByVal sampleIdList As List(Of Long)) As List(Of ClsSampleDetail)
        Dim sampleDetailList As New List(Of ClsSampleDetail)

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim ids As String = ""
                For Each id As Long In sampleIdList
                    If ids.Trim <> "" Then ids = ids + ","
                    ids = ids + CStr(id)
                Next

                If ids.Trim = "" Then Exit For

                Dim sql As String = ClsScripts.GetInstance.GetAllSampleDetailForSampleIds(ids).Trim
                If sql = "" Then Exit For

                dsSampleDetail = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If dsSampleDetail.Tables(0).Rows.Count > 0 Then
                    sampleDetailList.AddRange(GetSampleDetail(dsSampleDetail.Tables(0).Rows))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return sampleDetailList
    End Function

    ''' <summary>
    ''' This function will give records given sample id from preserved dataset.
    ''' </summary>
    ''' <param name="sampleId">Sample Id for which the records are required</param>
    ''' <returns>List of ClsSampleDetail Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllSampleDetailForSampleId(ByVal sampleId As Long) As List(Of ClsSampleDetail)
        Dim sampleDetailList As New List(Of ClsSampleDetail)

        Try
            Dim temp As Integer
            For temp = 0 To 0
                If dsSampleDetail Is Nothing Then Exit For

                If dsSampleDetail.Tables(0).Rows.Count > 0 Then
                    Dim str As String = cSampleId + " = " + CStr(sampleId)
                    Dim dtRow() As DataRow = dsSampleDetail.Tables(0).Select(str)
                    If dtRow.Length <> 0 Then sampleDetailList.AddRange(GetSampleDetail(dtRow))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return sampleDetailList
    End Function

    ''' <summary>
    ''' This function will give record from Sample Detail table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which record is required</param>
    ''' <returns>ClsSampleDetail Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetSampleDetail(ByVal calledBy As String, ByVal id As Long) As ClsSampleDetail
        Dim sampleDetail As ClsSampleDetail = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetSampleDetail(id).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    sampleDetail = GetSampleDetailObj(ds.Tables(0).Rows(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return sampleDetail
    End Function

    ''' <summary>
    ''' This function is used to insert Sample Detail Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="sampleDetailObj">ClsSampleDetail object to insert</param>
    ''' <remarks></remarks>
    Public Function InsertIntoSampleDetail(ByVal calledBy As String, ByRef sampleDetailObj As ClsSampleDetail) As Integer
        Dim result As Integer = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoSampleDetail(sampleDetailObj).Trim
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
    ''' This function is used to update Sample Detail Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="sampleDetailObj">ClsSampleDetail object to update</param>
    ''' <remarks></remarks>
    Public Function UpdateSampleDetail(ByVal calledBy As String, ByRef sampleDetailObj As ClsSampleDetail) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdateSampleDetail(sampleDetailObj).Trim
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
    ''' This function is used to delete Sample Detail Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which the deletion takes place</param>
    ''' <remarks></remarks>
    Public Function DeleteSampleDetail(ByVal calledBy As String, ByVal id As Long) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.DeleteSampleDetail(id).Trim
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