'Handles all Functionality related to ClsAccountGroup
Module ModAccountGroupDAL

    Private Function GetAccountGroupObj(ByRef row As DataRow) As ClsAccountGroup
        Dim AccountGroup As New ClsAccountGroup
        Try
            With row
                AccountGroup.Id = .Item(cId)
                AccountGroup.GroupCode = .Item(cGroupCode)
                AccountGroup.Name = .Item(cName)
                AccountGroup.AvailableIn = .Item(cAvailableIn)
                AccountGroup.UserId = .Item(cUserId)
                AccountGroup.DateOn = .Item(cDateOn)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return AccountGroup
    End Function

    Private Function GetAccountGroup(ByRef rows As DataRowCollection) As ClsAccountGroup()
        Dim AccountGroups(0) As ClsAccountGroup
        AccountGroups = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer

                Array.Resize(AccountGroups, count)
                For x = 0 To count - 1
                    AccountGroups(x) = GetAccountGroupObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return AccountGroups
    End Function

    ''' <summary>
    ''' This function is used to check that given ClsAccountGroup Object is possible to update.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="cityMasterObj">ClsAccountGroup Object to check</param>
    ''' <returns>True if updatable otherwise False</returns>
    ''' <remarks></remarks>
    Public Function AccountGroupUpdatable(ByVal calledBy As String, ByRef cityMasterObj As ClsAccountGroup) As Boolean
        Dim updatable As Boolean = True

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.AccountGroupUpdatable(cityMasterObj).Trim
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
    ''' This function will give records from Account Group table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>Array of ClsAccountGroup Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllAccountGroups(ByVal calledBy As String) As ClsAccountGroup()
        Dim AccountGroups(0) As ClsAccountGroup
        AccountGroups = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllAccountGroup().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    AccountGroups = GetAccountGroup(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return AccountGroups
    End Function

    ''' <summary>
    ''' This function will give records from Account Group table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="fieldName">Field Name in which the search takes place</param>
    ''' <param name="likeValue">Value to search</param>
    ''' <returns>Array of ClsAccountGroup Objects or nothing</returns>
    ''' <remarks></remarks>
    Private Function GetAllAccountGroupLike(ByVal calledBy As String, ByVal fieldName As String, ByVal likeValue As String) As ClsAccountGroup()
        Dim accountGroups(0) As ClsAccountGroup
        accountGroups = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllAccountGroupLike(fieldName, likeValue).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    accountGroups = GetAccountGroup(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return accountGroups
    End Function

    ''' <summary>
    ''' This function will give records from Account Group table for given values.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="likeValue">Value to search</param>
    ''' <returns>Array of ClsAccountGroup Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllAccountGroupNameLike(ByVal calledBy As String, ByVal likeValue As String) As ClsAccountGroup()
        Return GetAllAccountGroupLike(calledBy, cName, likeValue)
    End Function

    ''' <summary>
    ''' This function will give records from Account Group table for given values.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="likeValue">Value to search</param>
    ''' <returns>Array of ClsAccountGroup Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllAccountGroupCodeLike(ByVal calledBy As String, ByVal likeValue As String) As ClsAccountGroup()
        Return GetAllAccountGroupLike(calledBy, cGroupCode, likeValue)
    End Function

    ''' <summary>
    ''' This function will give records from Account Group table for given values.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="likeValue">Value to search</param>
    ''' <returns>Array of ClsAccountGroup Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllAccountGroupCategoryLike(ByVal calledBy As String, ByVal likeValue As String) As ClsAccountGroup()
        Return GetAllAccountGroupLike(calledBy, cAvailableIn, likeValue)
    End Function

    ''' <summary>
    ''' This function will give records from Account Group table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which record is required</param>
    ''' <returns>ClsAccountGroup Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAccountGroup(ByVal calledBy As String, ByVal id As Integer) As ClsAccountGroup
        Dim accountGroup As ClsAccountGroup = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAccountGroup(id).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    accountGroup = GetAccountGroupObj(ds.Tables(0).Rows(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return accountGroup
    End Function

    ''' <summary>
    ''' This function is used to insert Account Group Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="accountGroupsObj">ClsAccountGroup object to insert</param>
    ''' <returns>Id in integer</returns>
    ''' <remarks></remarks>
    Public Function InsertIntoAccountGroup(ByVal calledBy As String, ByRef accountGroupsObj As ClsAccountGroup) As Integer
        Dim result As Integer = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoAccountGroup(accountGroupsObj).Trim
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
    ''' This function is used to update Account Group Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="accountGroupsObj">ClsAccountGroups object to update</param>
    ''' <remarks></remarks>
    Public Function UpdateAccountGroup(ByVal calledBy As String, ByRef accountGroupsObj As ClsAccountGroup) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdateAccountGroup(accountGroupsObj).Trim
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
