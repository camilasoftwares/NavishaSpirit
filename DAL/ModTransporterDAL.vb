'Handles all Functionality related to ClsTransporter
Module ModTransporterDAL

    Private Function GetTransporterObj(ByRef row As DataRow) As ClsTransporter
        Dim transporter As New ClsTransporter
        Try
            With row
                transporter.Id = .Item(cId)
                transporter.Name = .Item(cName)
                transporter.Address = .Item(cAddress)
                transporter.City = .Item(cCity)
                transporter.Pin = .Item(cPin)
                transporter.EMail = .Item(cEmail)
                transporter.PhoneR = .Item(cPhoneR)
                transporter.PhoneO = .Item(cPhoneO)
                transporter.Mobile = .Item(cMobile)
                transporter.Representative = .Item(cRepresentative)
                transporter.PhoneRepresentative = .Item(cPhoneRepresentative)
                transporter.UserId = .Item(cUserId)
                transporter.DateOn = .Item(cDateOn)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return transporter
    End Function

    Private Function GetTransporter(ByRef rows As DataRowCollection) As ClsTransporter()
        Dim transporters(0) As ClsTransporter
        transporters = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer

                Array.Resize(transporters, count)
                For x = 0 To count - 1
                    transporters(x) = GetTransporterObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return transporters
    End Function

    ''' <summary>
    ''' This function will give records from Transporter table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>ClsTransporter Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllTransporter(ByVal calledBy As String) As ClsTransporter()
        Dim transporters(0) As ClsTransporter
        transporters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllTransporter().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    transporters = GetTransporter(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return transporters
    End Function

    ''' <summary>
    ''' This function will give records from Transporter table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="fieldName">Field Name from which records are required</param>
    ''' <param name="likeValue">Value like which records are required</param>
    ''' <returns>ClsTransporter Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllTransporterLike(ByVal calledBy As String, ByVal fieldName As String, ByVal likeValue As String) As ClsTransporter()
        Dim transporters(0) As ClsTransporter
        transporters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllTransporterLike(fieldName, likeValue).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    transporters = GetTransporter(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return transporters
    End Function

    ''' <summary>
    ''' This function is used to insert Transporter Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="transporterObj">ClsTransporter object to insert</param>
    ''' <remarks></remarks>
    Public Function InsertIntoTransporter(ByVal calledBy As String, ByRef transporterObj As ClsTransporter) As Integer
        Dim result As Integer = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoTransporter(transporterObj).Trim
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
    ''' This function is used to update Transporter Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="transporterObj">ClsTransporter object to update</param>
    ''' <remarks></remarks>
    Public Function UpdateTransporter(ByVal calledBy As String, ByRef transporterObj As ClsTransporter) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdateTransporter(transporterObj).Trim
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