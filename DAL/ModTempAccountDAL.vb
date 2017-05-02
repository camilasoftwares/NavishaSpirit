'Handles all Functionality related to ClsTempAccount
Module ModTempAccountDAL

    Private Function GetTempAccountObj(ByRef row As DataRow) As ClsTempAccount
        Dim tempAccount As New ClsTempAccount
        Try
            With row
                tempAccount.Id = .Item(cId)
                tempAccount.Name = .Item(cName)
                tempAccount.DrAmount = .Item(cDrAmount)
                tempAccount.CrAmount = .Item(cCrAmount)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return tempAccount
    End Function

    Private Function GetTempAccount(ByRef rows As DataRowCollection) As ClsTempAccount()
        Dim tempAccounts(0) As ClsTempAccount
        tempAccounts = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer

                Array.Resize(tempAccounts, count)
                For x = 0 To count - 1
                    tempAccounts(x) = GetTempAccountObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return tempAccounts
    End Function

    ''' <summary>
    ''' This function will give records from Temp Account table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>Array of ClsTempAccount Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllTempAccount(ByVal calledBy As String) As ClsTempAccount()
        Dim tempAccounts(0) As ClsTempAccount
        tempAccounts = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllTempAccount().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    tempAccounts = GetTempAccount(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return tempAccounts
    End Function

    ''' <summary>
    ''' This function will give records from Temp Account table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>Array of ClsTempAccount Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllTempAccountForTrialBalanceInDetail(ByVal calledBy As String) As ClsTempAccount()
        Dim tempAccounts(0) As ClsTempAccount
        tempAccounts = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllTempAccountForTrialBalanceInDetail().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    tempAccounts = GetTempAccount(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return tempAccounts
    End Function

    ''' <summary>
    ''' This function will give records from Temp Account table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>Array of ClsTempAccount Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllTempAccountForTrialBalanceInCondensed(ByVal calledBy As String) As ClsTempAccount()
        Dim tempAccounts(0) As ClsTempAccount
        tempAccounts = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllTempAccountForTrialBalanceInCondensed().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    tempAccounts = GetTempAccount(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return tempAccounts
    End Function

    ''' <summary>
    ''' This function will give records from Temp Account table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="forGroupId">Group Id for which records are required</param>
    ''' <returns>Array of ClsTempAccount Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllTempAccountForTrialBalanceInDetail(ByVal calledBy As String, ByVal forGroupId As Integer) As ClsTempAccount()
        Dim tempAccounts(0) As ClsTempAccount
        tempAccounts = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllTempAccountForTrialBalanceInDetail(forGroupId).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    tempAccounts = GetTempAccount(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return tempAccounts
    End Function

    ''' <summary>
    ''' This function will give records from Temp Account table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="forGroupId">Group Id for which records are required</param>
    ''' <returns>Array of ClsTempAccount Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllTempAccountForTrialBalanceInCondensed(ByVal calledBy As String, ByVal forGroupId As Integer) As ClsTempAccount()
        Dim tempAccounts(0) As ClsTempAccount
        tempAccounts = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllTempAccountForTrialBalanceInCondensed(forGroupId).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    tempAccounts = GetTempAccount(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return tempAccounts
    End Function

    ''' <summary>
    ''' This function will fill records in Temp Account table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="dateTo">Date upto which records are to fill</param>
    ''' <remarks></remarks>
    Public Function FillTempAccountForDate(ByVal calledBy As String, ByVal dateTo As Date) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.FillTempAccountForDate(dateTo).Trim
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