'Handles all Functionality related to ClsAccountHead
Module ModAccountHeadDAL

    Private Function GetAccountHeadObj(ByRef row As DataRow) As ClsAccountHead
        Dim accountHead As New ClsAccountHead
        Try
            With row
                accountHead.Id = .Item(cId)
                accountHead.HeadCode = .Item(cHeadCode)
                accountHead.Name = .Item(cName)
                accountHead.GroupId = .Item(cGroupId)
                accountHead.OpeningBalance = .Item(cOpeningBalance)
                accountHead.CrDr = .Item(cCrDr)
                accountHead.UserId = .Item(cUserId)
                AccountHead.DateOn = .Item(cDateOn)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return AccountHead
    End Function

    Private Function GetAccountHead(ByRef rows As DataRowCollection) As ClsAccountHead()
        Dim accountHeads(0) As ClsAccountHead
        accountHeads = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer

                Array.Resize(accountHeads, count)
                For x = 0 To count - 1
                    accountHeads(x) = GetAccountHeadObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return accountHeads
    End Function

    ''' <summary>
    ''' This function is used to check that given ClsAccountHead Object is possible to update.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="cityMasterObj">ClsAccountHead Object to check</param>
    ''' <returns>True if updatable otherwise False</returns>
    ''' <remarks></remarks>
    Public Function AccountHeadUpdatable(ByVal calledBy As String, ByRef cityMasterObj As ClsAccountHead) As Boolean
        Dim updatable As Boolean = True

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.AccountHeadUpdatable(cityMasterObj).Trim
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
    ''' This function will give records from Account Head table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>ClsAccountHead Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllAccountHead(ByVal calledBy As String) As ClsAccountHead()
        Dim accountHeads(0) As ClsAccountHead
        accountHeads = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllAccountHead().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    accountHeads = GetAccountHead(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return accountHeads
    End Function

    ''' <summary>
    ''' This function will give records from Account Head table for given group id.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="groupId">Group Id for which the records are required</param>
    ''' <returns>ClsAccountHead Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllAccountHeadForGroupId(ByVal calledBy As String, ByVal groupId As Integer) As ClsAccountHead()
        Dim accountHeads(0) As ClsAccountHead
        accountHeads = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllAccountHeadForGroupId(groupId).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    accountHeads = GetAccountHead(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return accountHeads
    End Function

    ''' <summary>
    ''' This function will give records from Account Head table for given values.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="fieldName">Field in which the search takes place</param>
    ''' <param name="likeValue">Value to search like</param>
    ''' <returns>Array of ClsAccountHead Objects or nothing</returns>
    ''' <remarks></remarks>
    Private Function GetAllAccountHeadLike(ByVal calledBy As String, ByVal fieldName As String, ByVal likeValue As String) As ClsAccountHead()
        Dim accountHeads(0) As ClsAccountHead
        accountHeads = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllAccountHeadLike(fieldName, likeValue).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    accountHeads = GetAccountHead(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return accountHeads
    End Function

    ''' <summary>
    ''' This function will give records from Account Head table for given values.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="likeValue">Value to search like</param>
    ''' <returns>Array of ClsAccountHead Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllAccountHeadCodeLike(ByVal calledBy As String, ByVal likeValue As String) As ClsAccountHead()
        Return GetAllAccountHeadLike(calledBy, cHeadCode, likeValue)
    End Function

    ''' <summary>
    ''' This function will give records from Account Head table for given values.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="likeValue">Value to search like</param>
    ''' <returns>Array of ClsAccountHead Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllAccountHeadNameLike(ByVal calledBy As String, ByVal likeValue As String) As ClsAccountHead()
        Return GetAllAccountHeadLike(calledBy, cName, likeValue)
    End Function

    ''' <summary>
    ''' This function will give records from Account Head table for given values.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="likeValue">Value to search like</param>
    ''' <returns>Array of ClsAccountHead Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllAccountHeadGroupNameLike(ByVal calledBy As String, ByVal likeValue As String) As ClsAccountHead()
        Return GetAllAccountHeadLike(calledBy, cGroupId, likeValue)
    End Function

    ''' <summary>
    ''' This function will give records from Account Head table for given values.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="groupCode">Group code for which records are required</param>
    ''' <returns>Array of ClsAccountHead Objects or nothing</returns>
    ''' <remarks></remarks>
    Private Function GetAllAccountHeadForGroupCode(ByVal calledBy As String, ByVal groupCode As String) As ClsAccountHead()
        Dim accountHeads(0) As ClsAccountHead
        accountHeads = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllAccountHeadForGroupCode(groupCode).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    accountHeads = GetAccountHead(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return accountHeads
    End Function

    ''' <summary>
    ''' This function will give records from Account Head table for Cash In Hand.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>Array of ClsAccountHead Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllAccountHeadForCashInHand(ByVal calledBy As String) As ClsAccountHead()
        Return GetAllAccountHeadForGroupCode(calledBy, "AG5")
    End Function

    ''' <summary>
    ''' This function will give records from Account Head table for Bank Account.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>Array of ClsAccountHead Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllAccountHeadForBankAccount(ByVal calledBy As String) As ClsAccountHead()
        Return GetAllAccountHeadForGroupCode(calledBy, "AG1")
    End Function

    ''' <summary>
    ''' This function will give record from Account Head table for given id.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>ClsAccountHead Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAccountHead(ByVal calledBy As String, ByVal id As Integer) As ClsAccountHead
        Dim accountHead As ClsAccountHead = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAccountHead(id).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    accountHead = GetAccountHeadObj(ds.Tables(0).Rows(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return accountHead
    End Function

    ''' <summary>
    ''' This function is used to insert Account Head Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="accountHeadObj">ClsAccountHeads object to insert</param>
    ''' <returns>Id in int</returns>
    ''' <remarks></remarks>
    Public Function InsertIntoAccountHead(ByVal calledBy As String, ByRef accountHeadObj As ClsAccountHead) As Integer
        Dim result As Integer = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoAccountHead(accountHeadObj).Trim
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
    ''' This function is used to update Account Head Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="accountHeadObj">ClsAccountHeads object to update</param>
    ''' <remarks></remarks>
    Public Function UpdateAccountHead(ByVal calledBy As String, ByRef accountHeadObj As ClsAccountHead) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdateAccountHead(accountHeadObj).Trim
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

