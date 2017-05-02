'Handles all Functionality related to ClsDestructionSlipMaster
Module ModDestructionSlipMasterDAL

    Private Function GetDestructionSlipMasterObj(ByRef row As DataRow) As ClsDestructionSlipMaster
        Dim destructionSlipMaster As New ClsDestructionSlipMaster
        Try
            With row
                destructionSlipMaster.Id = .Item(cId)
                destructionSlipMaster.UserId = .Item(cUserId)
                destructionSlipMaster.Remark = .Item(cRemark)
                destructionSlipMaster.DateOn = .Item(cDateOn)
                destructionSlipMaster.DestructionSlipCode = .Item(cDestructionSlipCode)
                destructionSlipMaster.NotClosed = .Item(cNotClosed)
                destructionSlipMaster.DestructionSlipDate = .Item(cDestructionSlipDate)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return destructionSlipMaster
    End Function

    Private Function GetDestructionSlipMaster(ByRef rows As DataRowCollection) As ClsDestructionSlipMaster()
        Dim DestructionSlipMasters(0) As ClsDestructionSlipMaster
        DestructionSlipMasters = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer
                Array.Resize(DestructionSlipMasters, count)
                For x = 0 To count - 1
                    DestructionSlipMasters(x) = GetDestructionSlipMasterObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return DestructionSlipMasters
    End Function

    ''' <summary>
    ''' This function will give records from Destruction Slip Master table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>Array of ClsDestructionSlipMaster Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllDestructionSlipMaster(ByVal calledBy As String) As ClsDestructionSlipMaster()
        Dim DestructionSlipMasters(0) As ClsDestructionSlipMaster
        DestructionSlipMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllDestructionSlipMaster().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    DestructionSlipMasters = GetDestructionSlipMaster(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return DestructionSlipMasters
    End Function

    ''' <summary>
    ''' This function will give records from Destruction Slip Master table for given values.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="forField">Field in which search takes place</param>
    ''' <param name="value">Value to search like</param>
    ''' <returns>Array of ClsDestructionSlipMaster Objects or nothing</returns>
    ''' <remarks></remarks>
    Private Function GetAllDestructionSlipMasterValuesLike(ByVal calledBy As String, ByVal forField As String, ByVal value As String) As ClsDestructionSlipMaster()
        Dim DestructionSlipMasters(0) As ClsDestructionSlipMaster
        DestructionSlipMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllDestructionSlipMasterValuesLike(forField, value).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    DestructionSlipMasters = GetDestructionSlipMaster(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return DestructionSlipMasters
    End Function

    ''' <summary>
    ''' This function will give records from Destruction Slip Master table for given values.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="day">Day for which search takes place</param>
    ''' <param name="month">Month for which search takes place</param>
    ''' <param name="year">Year for which search takes place</param>
    ''' <returns>Array of ClsDestructionSlipMaster Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllDestructionSlipMasterLikeDestructionDate(ByVal calledBy As String, Optional ByVal day As String = "", Optional ByVal month As String = "", Optional ByVal year As String = "") As ClsDestructionSlipMaster()
        Dim destructionSlipMasters(0) As ClsDestructionSlipMaster
        destructionSlipMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllDestructionSlipMasterLikeDestructionDate(day, month, year).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    destructionSlipMasters = GetDestructionSlipMaster(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return destructionSlipMasters
    End Function

    ''' <summary>
    ''' This function will give records from Destruction Slip Master table for given values.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="value">Value to search like</param>
    ''' <returns>Array of ClsDestructionSlipMaster Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllDestructionSlipMasterDestructionSlipCodeLike(ByVal calledBy As String, ByVal value As String) As ClsDestructionSlipMaster()
        Return GetAllDestructionSlipMasterValuesLike(calledBy, cDestructionSlipCode, value)
    End Function

    ''' <summary>
    ''' This function will give record from Destruction Slip Master table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="loginName">Login Name for which the record is required</param>
    ''' <returns>ClsDestructionSlipMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetDestructionSlipMasterNotClosedForLogin(ByVal calledBy As String, ByVal loginName As String) As ClsDestructionSlipMaster
        Dim destructionSlipMaster As ClsDestructionSlipMaster = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetDestructionSlipMasterNotClosedForLogin(loginName).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    destructionSlipMaster = GetDestructionSlipMasterObj(ds.Tables(0).Rows(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return destructionSlipMaster
    End Function

    ''' <summary>
    ''' This function will give destructionSlip id from Destruction Slip Master table not closed.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="loginName">Login Name for which the record is required</param>
    ''' <returns>Id in Long or cInvalidId</returns>
    ''' <remarks></remarks>
    Public Function GetDestructionSlipMasterIdNotClosedForLogin(ByVal calledBy As String, ByVal loginName As String) As Long
        Dim result As Long = cInvalidId

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetDestructionSlipMasterIdNotClosedForLogin(loginName).Trim
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
    ''' This function will give record from Destruction Slip Master table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which record is required</param>
    ''' <returns>ClsDestructionSlipMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetDestructionSlipMaster(ByVal calledBy As String, ByVal id As Long) As ClsDestructionSlipMaster
        Dim destructionSlipMaster As ClsDestructionSlipMaster = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetDestructionSlipMaster(id).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    destructionSlipMaster = GetDestructionSlipMasterObj(ds.Tables(0).Rows(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return destructionSlipMaster
    End Function

    ''' <summary>
    ''' This function is used to insert Destruction Slip Masters Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="destructionSlipMastersObj">ClsDestructionSlipMasters object to insert</param>
    ''' <returns>Id in long</returns>
    ''' <remarks></remarks>
    Public Function InsertIntoDestructionSlipMaster(ByVal calledBy As String, ByRef destructionSlipMastersObj As ClsDestructionSlipMaster) As Long
        Dim result As Long = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoDestructionSlipMaster(destructionSlipMastersObj).Trim
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
    ''' This function is used to update Destruction Slip Masters Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="destructionSlipMastersObj">ClsDestructionSlipMasters object to update</param>
    ''' <remarks></remarks>
    Public Function UpdateDestructionSlipMaster(ByVal calledBy As String, ByRef destructionSlipMastersObj As ClsDestructionSlipMaster) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdateDestructionSlipMaster(destructionSlipMastersObj).Trim
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

