Module ModTrackLogDAL

    Private Function GetTrackLogObj(ByRef row As DataRow) As ClsTrackLog
        Dim trackLog As New ClsTrackLog
        Try
            With row
                trackLog.BillNo = .Item(cBillNo)
                trackLog.DateOn = .Item(cDateOn)
                trackLog.Diff = .Item(cDiff)
                trackLog.UserId = .Item(cUserId)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return trackLog
    End Function

    Private Function GetTrackLog(ByRef rows As DataRowCollection) As ClsTrackLog()
        Dim trackLogs(0) As ClsTrackLog
        trackLogs = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer

                Array.Resize(trackLogs, count)
                For x = 0 To count - 1
                    trackLogs(x) = GetTrackLogObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return trackLogs
    End Function

    ''' <summary>
    ''' This function will give records from Sales Master and Sales Detail table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="dateFrom">Date from which the records are to trace. It is detail record date</param>
    ''' <returns>Array of ClsTrackLog Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllTrackLogForSales(ByVal calledBy As String, ByVal dateFrom As Date) As ClsTrackLog()
        Dim trackLogs(0) As ClsTrackLog
        trackLogs = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllTrackLogForSales(dateFrom).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    trackLogs = GetTrackLog(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return trackLogs
    End Function

    ''' <summary>
    ''' This function will give records from Purchase Master and Purchase Detail table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="dateFrom">Date from which the records are to trace. It is detail record date</param>
    ''' <returns>Array of ClsTrackLog Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllTrackLogForPurchase(ByVal calledBy As String, ByVal dateFrom As Date) As ClsTrackLog()
        Dim trackLogs(0) As ClsTrackLog
        trackLogs = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllTrackLogForPurchase(dateFrom).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    trackLogs = GetTrackLog(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return trackLogs
    End Function

    ''' <summary>
    ''' This function will give records from Destruction Slip Master and Destruction Slip Detail table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="dateFrom">Date from which the records are to trace. It is detail record date</param>
    ''' <returns>Array of ClsTrackLog Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllTrackLogForDestructionSlip(ByVal calledBy As String, ByVal dateFrom As Date) As ClsTrackLog()
        Dim trackLogs(0) As ClsTrackLog
        trackLogs = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllTrackLogForDestructionSlip(dateFrom).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    trackLogs = GetTrackLog(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return trackLogs
    End Function

End Module
