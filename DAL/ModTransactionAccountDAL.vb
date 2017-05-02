'Handles all Functionality related to ClsTransactionAccount
Module ModTransactionAccountDAL

    Private Function GetTransactionAccountObj(ByRef row As DataRow) As ClsTransactionAccount
        Dim transactionAccount As New ClsTransactionAccount
        Try
            With row
                'transactionAccount.Id = .Item(cId)
                transactionAccount.VoucherNo = .Item(cVoucherNo)
                transactionAccount.TransactionDate = .Item(cTransactionDate)
                transactionAccount.HeadId = .Item(cHeadId)
                transactionAccount.DrAmount = .Item(cDrAmount)
                transactionAccount.CrAmount = .Item(cCrAmount)
                transactionAccount.Narration = .Item(cNarration)
                transactionAccount.Source = .Item(cSource)
                transactionAccount.Remark = .Item(cRemark)
                transactionAccount.UserId = .Item(cUserId)
                transactionAccount.DateOn = .Item(cDateOn)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return transactionAccount
    End Function

    Private Function GetTransactionAccount(ByRef rows As DataRowCollection) As ClsTransactionAccount()
        Dim transactionAccounts(0) As ClsTransactionAccount
        transactionAccounts = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer

                Array.Resize(TransactionAccounts, count)
                For x = 0 To count - 1
                    transactionAccounts(x) = GetTransactionAccountObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return transactionAccounts
    End Function

    ''' <summary>
    ''' This function will give records from Transaction Account table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>ClsTransactionAccount Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllTransactionAccounts(ByVal calledBy As String) As ClsTransactionAccount()
        Dim transactionAccounts(0) As ClsTransactionAccount
        transactionAccounts = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllTransactionAccount().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    transactionAccounts = GetTransactionAccount(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return transactionAccounts
    End Function

    '''' <summary>
    '''' This function will give records from Transaction Account table.
    '''' </summary>
    '''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    '''' <param name="id">Id for which record is required</param>
    '''' <returns>ClsTransactionAccount Object or nothing</returns>
    '''' <remarks></remarks>
    'Public Function GetTransactionAccount(ByVal calledBy As String, ByVal id As Long) As ClsTransactionAccount
    '    Dim transactionAccount As ClsTransactionAccount = Nothing

    '    Try
    '        Dim temp As Integer
    '        For temp = 0 To 0
    '            Dim sql As String = ClsScripts.GetInstance.GetTransactionAccount(id).Trim
    '            If sql = "" Then Exit For

    '            Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
    '            If ds.Tables(0).Rows.Count > 0 Then
    '                transactionAccount = GetTransactionAccountObj(ds.Tables(0).Rows(0))
    '            End If
    '        Next

    '    Catch ex As Exception
    '        AddToLog(ex)
    '    End Try

    '    Return transactionAccount
    'End Function

    ''' <summary>
    ''' This function will give balance from Transaction Account table for given voucher no.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="voucherNo">Voucher No for which balance is required</param>
    ''' <returns>Balance in Double</returns>
    ''' <remarks></remarks>
    Public Function GetTransactionAccountBalanceForVoucherNo(ByVal calledBy As String, ByVal voucherNo As String) As Double
        Dim result As Double = 0

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetTransactionAccountBalanceForVoucherNo(voucherNo).Trim
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
    ''' This function will give balance from Transaction Account table for given voucher no and head id.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="voucherNo">Voucher No for which balance is required</param>
    ''' <param name="headId">Head Id for which account balance is required</param>
    ''' <returns>Balance in Double</returns>
    ''' <remarks></remarks>
    Private Function GetTransactionAccountBalanceForVoucherNo(ByVal calledBy As String, ByVal voucherNo As String, ByVal headId As Integer) As Double
        Dim result As Double = 0

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetTransactionAccountBalanceForVoucherNo(voucherNo, headId).Trim
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
    ''' This function will give round off amount from Transaction Account table for given voucher no.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="voucherNo">Voucher No for which amount is required</param>
    ''' <returns>Balance in Double</returns>
    ''' <remarks></remarks>
    Public Function GetTransactionAccountRoundOffForVoucherNo(ByVal calledBy As String, ByVal voucherNo As String) As Double
        Return GetTransactionAccountBalanceForVoucherNo(calledBy, voucherNo, cAccountHead_ROF)
    End Function

    ''' <summary>
    ''' This function is used to insert Transaction Account Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="transactionAccountsObj">ClsTransactionAccount object to insert</param>
    ''' <returns>Id in integer</returns>
    ''' <remarks></remarks>
    Public Function InsertIntoTransactionAccount(ByVal calledBy As String, ByRef transactionAccountsObj As ClsTransactionAccount) As Long
        Dim result As Long = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoTransactionAccount(transactionAccountsObj).Trim
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
    ''' This function is used to update Transaction Account Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="transactionAccountsObj">ClsTransactionAccounts object to update</param>
    ''' <remarks></remarks>
    Public Function UpdateTransactionAccount(ByVal calledBy As String, ByRef transactionAccountsObj As ClsTransactionAccount) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdateTransactionAccount(transactionAccountsObj).Trim
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

