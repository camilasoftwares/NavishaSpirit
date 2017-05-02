'Handles all Functionality related to ClsVendorDetail
Module ModVendorDetailDAL

    Private Function GetVendorDetailObj(ByRef row As DataRow) As ClsVendorDetail
        Dim vendorDetail As New ClsVendorDetail
        Try
            With row
                vendorDetail.Id = .Item(cId)
                vendorDetail.ManufacturerId = .Item(cManufacturerId)
                vendorDetail.AccountId = .Item(cAccountId)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return vendorDetail
    End Function

    Private Function GetVendorDetail(ByRef rows As DataRowCollection) As ClsVendorDetail()
        Dim vendorDetails(0) As ClsVendorDetail
        vendorDetails = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer

                Array.Resize(vendorDetails, count)
                For x = 0 To count - 1
                    vendorDetails(x) = GetVendorDetailObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return vendorDetails
    End Function

    ''' <summary>
    ''' This function will give records from Vendor Detail table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>ClsVendorDetail Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllVendorDetail(ByVal calledBy As String) As ClsVendorDetail()
        Dim vendorDetails(0) As ClsVendorDetail
        vendorDetails = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllVendorDetail().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    vendorDetails = GetVendorDetail(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return vendorDetails
    End Function

    ''' <summary>
    ''' This function will give records from Vendor Detail table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="accountId">Account Id for which the records are required</param>
    ''' <returns>ClsVendorDetail Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllVendorDetailForAccountId(ByVal calledBy As String, ByVal accountId As String) As ClsVendorDetail()
        Dim vendorDetails(0) As ClsVendorDetail
        vendorDetails = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllVendorDetailForAccountId(accountId).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    vendorDetails = GetVendorDetail(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return vendorDetails
    End Function

    ''' <summary>
    ''' This function is used to insert Vendor Detail Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="vendorDetailObj">ClsVendorDetail object to insert</param>
    ''' <remarks></remarks>
    Public Function InsertIntoVendorDetail(ByVal calledBy As String, ByRef vendorDetailObj As ClsVendorDetail) As Integer
        Dim result As Integer = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoVendorDetail(vendorDetailObj).Trim
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
    ''' This function is used to update Vendor Detail Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="vendorDetailObj">ClsVendorDetail object to update</param>
    ''' <remarks></remarks>
    Public Function UpdateVendorDetail(ByVal calledBy As String, ByRef vendorDetailObj As ClsVendorDetail) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdateVendorDetail(vendorDetailObj).Trim
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
    ''' This function is used to delete Vendor Detail Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which value is to delete</param>
    ''' <remarks></remarks>
    Public Function DeleteVendorDetail(ByVal calledBy As String, ByVal id As Integer) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.DeleteVendorDetail(id).Trim
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