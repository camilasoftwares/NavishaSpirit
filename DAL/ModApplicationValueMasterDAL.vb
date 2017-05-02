'Handles all Functionality related to ClsApplicationValueMaster
Module ModApplicationValueMasterDAL

    Private Function GetApplicationValueMasterObj(ByRef row As DataRow) As ClsApplicationValueMaster
        Dim applicationValueMaster As New ClsApplicationValueMaster
        Try
            With row
                applicationValueMaster.Id = .Item(cId)
                applicationValueMaster.Name = .Item(cName)
                applicationValueMaster.IdValue = .Item(cIdValue)
            End With

        Catch ex As Exception
            AddToLog(ex)

        End Try

        Return applicationValueMaster
    End Function

    Private Function GetApplicationValueMaster(ByRef rows As DataRowCollection) As ClsApplicationValueMaster()
        Dim applicationValueMasters(0) As ClsApplicationValueMaster
        applicationValueMasters = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer

                Array.Resize(applicationValueMasters, count)
                For x = 0 To count - 1
                    applicationValueMasters(x) = GetApplicationValueMasterObj(rows(x))

                Next
            End If

        Catch ex As Exception
            AddToLog(ex)

        End Try

        Return applicationValueMasters
    End Function

    ''' <summary>
    ''' This function will give record from Application Value Master table for given name.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="name">Name against which record is required</param>
    ''' <returns>ClsApplicationValueMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetApplicationValueMaster(ByVal calledBy As String, ByVal name As String) As ClsApplicationValueMaster
        Dim applicationValueMasters As ClsApplicationValueMaster
        applicationValueMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0

                Dim sql As String = ClsScripts.GetInstance.GetApplicationValueMaster(name).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    applicationValueMasters = GetApplicationValueMasterObj(ds.Tables(0).Rows(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return applicationValueMasters
    End Function

    ''' <summary>
    ''' This function is used to insert Application Value Master Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="applicationValueMasterObj">ClsApplicationValueMaster object to insert</param>
    ''' <remarks></remarks>
    Public Function InsertIntoApplicationValueMaster(ByVal calledBy As String, ByRef applicationValueMasterObj As ClsApplicationValueMaster) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoApplicationValueMaster(applicationValueMasterObj).Trim
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
    ''' This function is used to update Application Value Master Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="applicationValueMasterObj">ClsApplicationValueMaster object to update</param>
    ''' <remarks></remarks>
    Public Function UpdateApplicationValueMaster(ByVal calledBy As String, ByRef applicationValueMasterObj As ClsApplicationValueMaster) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdateApplicationValueMaster(applicationValueMasterObj).Trim
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