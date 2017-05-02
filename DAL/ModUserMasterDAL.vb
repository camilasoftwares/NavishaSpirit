'Handles all Functionality related to ClsUserMaster
Module ModUserMasterDAL

    Private Function GetUserMasterObj(ByRef row As DataRow) As ClsUserMaster
        Dim userMaster As New ClsUserMaster
        Try
            With row
                userMaster.Id = .Item(cId)
                userMaster.Name = .Item(cName)
                userMaster.AuthorizationNo = .Item(cAuthorizationNo)
                userMaster.LoginName = .Item(cLoginName)
                userMaster.Password = .Item(cPassword)
                userMaster.ProfileId = .Item(cProfileId)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return userMaster
    End Function

    Private Function GetUserMaster(ByRef rows As DataRowCollection) As ClsUserMaster()
        Dim userMasters(0) As ClsUserMaster
        userMasters = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer
                Array.Resize(userMasters, count)
                For x = 0 To count - 1
                    userMasters(x) = GetUserMasterObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return userMasters
    End Function

    ''' <summary>
    ''' This function will give all records in User Master Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>Array of ClsUserMaster Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllUserMaster(ByVal calledBy As String) As ClsUserMaster()
        Dim userMasters(0) As ClsUserMaster
        userMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllUserMaster().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    userMasters = GetUserMaster(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return userMasters
    End Function

    ''' <summary>
    ''' This function will give record from User Master Table for given login name and password.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="loginName">Login Name for User Master</param>
    ''' <param name="pass">Password for user master</param>
    ''' <returns>ClsUserMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetUserMaster(ByVal calledBy As String, ByVal loginName As String, ByVal pass As String) As ClsUserMaster
        Dim userMaster As ClsUserMaster
        userMaster = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetUserMaster(loginName, pass).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    userMaster = GetUserMasterObj(ds.Tables(0).Rows(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return userMaster
    End Function

    ''' <summary>
    ''' This function will check the existence of record in User Master Table for given id and password.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for User Master</param>
    ''' <param name="pass">Password for user master</param>
    ''' <returns>True if exist</returns>
    ''' <remarks></remarks>
    Public Function ValidateUserMaster(ByVal calledBy As String, ByVal id As Integer, ByVal pass As String) As Boolean
        Dim result As Boolean = False
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.ValidateUserMaster(id, pass).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    result = True
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return result
    End Function

    ''' <summary>
    ''' This function is used to insert object in User Master Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="userMasterObj">ClsUserMaster object to insert</param>
    ''' <returns>Id in integer or cinvalid(-1)</returns>
    ''' <remarks></remarks>
    Public Function InsertIntoUserMaster(ByVal calledBy As String, ByRef userMasterObj As ClsUserMaster) As Integer
        Dim result As Integer = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoUserMaster(userMasterObj).Trim
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
    ''' This function is used to update User Master Object in User.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="userMasterObj">ClsUserMaster object to update</param>
    ''' <param name="ignorePassword">This will not update password</param>
    ''' <remarks></remarks>
    Public Function UpdateUserMaster(ByVal calledBy As String, ByRef userMasterObj As ClsUserMaster, Optional ByVal ignorePassword As Boolean = False) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdateUserMaster(userMasterObj, ignorePassword).Trim
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
    ''' This function is used to update User Master Object in User.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which the updation takes place</param>
    ''' <param name="pass">Password to update</param>
    ''' <remarks></remarks>
    Public Function UpdateUserMasterPassword(ByVal calledBy As String, ByVal id As Integer, ByVal pass As String) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdateUserMasterPassword(id, pass).Trim
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
