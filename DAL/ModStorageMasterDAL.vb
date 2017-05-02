'Handles all Functionality related to ClsStorageMaster
Module ModStorageMasterDAL

    Private Function GetStorageMasterObj(ByRef row As DataRow) As ClsStorageMaster
        Dim storageMaster As New ClsStorageMaster
        Try
            With row
                storageMaster.Id = .Item(cId)
                storageMaster.Name = .Item(cName)
                storageMaster.UserId = .Item(cUserId)
                storageMaster.DateOn = .Item(cDateOn)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return storageMaster
    End Function

    Private Function GetStorageMaster(ByRef rows As DataRowCollection) As ClsStorageMaster()
        Dim storageMasters(0) As ClsStorageMaster
        storageMasters = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer

                Array.Resize(storageMasters, count)
                For x = 0 To count - 1
                    storageMasters(x) = GetStorageMasterObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return storageMasters
    End Function

    ''' <summary>
    ''' This function is used to check that given ClsStorageMaster Object is possible to update.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="storageMasterObj">ClsStorageMaster Object to check</param>
    ''' <returns>True if updatable otherwise False</returns>
    ''' <remarks></remarks>
    Public Function StorageMasterUpdatable(ByVal calledBy As String, ByRef storageMasterObj As ClsStorageMaster) As Boolean
        Dim updatable As Boolean = True

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.StorageMasterUpdatable(storageMasterObj).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    updatable = False
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return updatable
    End Function

    ''' <summary>
    ''' This function will give records from Storage Master table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>ClsStorageMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllStorageMaster(ByVal calledBy As String) As ClsStorageMaster()
        Dim storageMasters(0) As ClsStorageMaster
        storageMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllStorageMaster().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    storageMasters = GetStorageMaster(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return storageMasters
    End Function

    ''' <summary>
    ''' This function is used to insert Storage Master Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="storageMasterObj">ClsStorageMaster object to insert</param>
    ''' <remarks></remarks>
    Public Function InsertIntoStorageMaster(ByVal calledBy As String, ByRef storageMasterObj As ClsStorageMaster) As Integer
        Dim result As Integer = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoStorageMaster(storageMasterObj).Trim
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
    ''' This function is used to update Storage Master Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="storageMasterObj">ClsStorageMaster object to update</param>
    ''' <remarks></remarks>
    Public Function UpdateStorageMaster(ByVal calledBy As String, ByRef storageMasterObj As ClsStorageMaster) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdateStorageMaster(storageMasterObj).Trim
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