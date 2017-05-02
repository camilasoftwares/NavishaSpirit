'Handles all Functionality related to ClsGenericMaster
Module ModGenericMasterDAL

    Private Function GetGenericMasterObj(ByRef row As DataRow) As ClsGenericMaster
        Dim genericMaster As New ClsGenericMaster
        Try
            With row
                genericMaster.Id = .Item(cId)
                genericMaster.Name = .Item(cName)
                genericMaster.Status = .Item(cStatus)
                genericMaster.UserId = .Item(cUserId)
                genericMaster.DateOn = .Item(cDateOn)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return genericMaster
    End Function

    Private Function GetGenericMaster(ByRef rows As DataRowCollection) As ClsGenericMaster()
        Dim genericMasters(0) As ClsGenericMaster
        genericMasters = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer

                Array.Resize(genericMasters, count)
                For x = 0 To count - 1
                    genericMasters(x) = GetGenericMasterObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return genericMasters
    End Function

    ''' <summary>
    ''' This function is used to check that given ClsGenericMaster Object is possible to update.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="genericMasterObj">ClsGenericMaster Object to check</param>
    ''' <returns>True if updatable otherwise False</returns>
    ''' <remarks></remarks>
    Public Function GenericMasterUpdatable(ByVal calledBy As String, ByRef genericMasterObj As ClsGenericMaster) As Boolean
        Dim updatable As Boolean = True

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GenericMasterUpdatable(genericMasterObj).Trim
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
    ''' This function will give records from Generic Master table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>ClsGenericMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllGenericMaster(ByVal calledBy As String) As ClsGenericMaster()
        Dim genericMasters(0) As ClsGenericMaster
        genericMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllGenericMaster().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    genericMasters = GetGenericMaster(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return genericMasters
    End Function

    ''' <summary>
    ''' This function is used to insert Generic Master Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="genericMasterObj">ClsGenericMaster object to insert</param>
    ''' <remarks></remarks>
    Public Function InsertIntoGenericMaster(ByVal calledBy As String, ByRef genericMasterObj As ClsGenericMaster) As Integer
        Dim result As Integer = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoGenericMaster(genericMasterObj).Trim
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
    ''' This function is used to update Generic Master Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="genericMasterObj">ClsGenericMaster object to update</param>
    ''' <remarks></remarks>
    Public Function UpdateGenericMaster(ByVal calledBy As String, ByRef genericMasterObj As ClsGenericMaster) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdateGenericMaster(genericMasterObj).Trim
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