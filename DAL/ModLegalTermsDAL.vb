'Handles all Functionality related to ClsLegalTerms
Module ModLegalTermsDAL

    Private Function GetLegalTermsObj(ByRef row As DataRow) As ClsLegalTerms
        Dim legalTerm As New ClsLegalTerms
        Try
            With row
                legalTerm.Id = .Item(cId)
                legalTerm.Name = .Item(cName)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return legalTerm
    End Function

    Private Function GetLegalTerms(ByRef rows As DataRowCollection) As ClsLegalTerms()
        Dim legalTerms(0) As ClsLegalTerms
        legalTerms = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer
                Array.Resize(legalTerms, count)
                For x = 0 To count - 1
                    legalTerms(x) = GetLegalTermsObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return legalTerms
    End Function

    ''' <summary>
    ''' This function will give records from Legal Terms table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>ClsLegalTerms Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllLegalTerms(ByVal calledBy As String) As ClsLegalTerms()
        Dim legalTerms(0) As ClsLegalTerms
        legalTerms = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllLegalTerms().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    legalTerms = GetLegalTerms(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return legalTerms
    End Function

    ''' <summary>
    ''' This function will give records from Legal Terms table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which record is required</param>
    ''' <returns>ClsLegalTerms Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetLegalTerms(ByVal calledBy As String, ByVal id As Integer) As ClsLegalTerms
        Dim legalTerm As ClsLegalTerms = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetLegalTerms(id).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    legalTerm = GetLegalTermsObj(ds.Tables(0).Rows(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return legalTerm
    End Function

    ''' <summary>
    ''' This function is used to insert Legal Terms Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="legalTermsObj">ClsLegalTerms object to insert</param>
    ''' <returns>Id in integer</returns>
    ''' <remarks></remarks>
    Public Function InsertIntoLegalTerms(ByVal calledBy As String, ByRef legalTermsObj As ClsLegalTerms) As Integer
        Dim result As Integer = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoLegalTerms(legalTermsObj).Trim
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
    ''' This function is used to update Legal Terms Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="legalTermsObj">ClsLegalTerms object to update</param>
    ''' <remarks></remarks>
    Public Function UpdateLegalTerms(ByVal calledBy As String, ByRef legalTermsObj As ClsLegalTerms) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdateLegalTerms(legalTermsObj).Trim
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
    ''' This function is used to delete Legal Terms Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which record is to delete</param>
    ''' <remarks></remarks>
    Public Function DeleteLegalTerms(ByVal calledBy As String, ByVal id As Integer) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.DeleteLegalTerms(id).Trim
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
