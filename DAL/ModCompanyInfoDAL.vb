'Handles all Functionality related to ClsCompanyInfo
Module ModCompanyInfoDAL

    Private Function GetCompanyInfoObj(ByRef row As DataRow) As ClsCompanyInfo
        Dim companyInfo As New ClsCompanyInfo
        Try
            With row
                companyInfo.Id = .Item(cId)
                companyInfo.Name = .Item(cName)
                companyInfo.Address = .Item(cAddress)
                companyInfo.ContactPerson = .Item(cContactPerson)
                companyInfo.Phone = .Item(cPhone)
                companyInfo.Fax = .Item(cFax)
                companyInfo.EMail = .Item(cEmail)
                companyInfo.City = .Item(cCity)
                companyInfo.State = .Item(cState)
                companyInfo.Pin = .Item(cPin)
                companyInfo.UpTtNo = .Item(cUpTtNo)
                companyInfo.CstNo = .Item(cCstNo)
                companyInfo.DlNo = .Item(cDlNo)
                companyInfo.TinNo = .Item(cTinNo)
                companyInfo.Logo = StringToImage(.Item(cLogo))
                companyInfo.SubTitle = .Item(cSubTitle)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return companyInfo
    End Function

    Private Function GetCompanyInfo(ByRef rows As DataRowCollection) As ClsCompanyInfo()
        Dim companyInfos(0) As ClsCompanyInfo
        companyInfos = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer

                Array.Resize(companyInfos, count)
                For x = 0 To count - 1
                    companyInfos(x) = GetCompanyInfoObj(rows(x))

                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return companyInfos
    End Function

    ''' <summary>
    ''' This function will give record from Company Info table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>ClsCompanyInfo Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetCompanyInfo(ByVal calledBy As String) As ClsCompanyInfo
        Dim companyInfos As ClsCompanyInfo
        companyInfos = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0

                Dim sql As String = ClsScripts.GetInstance.GetCompanyInfo().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    companyInfos = GetCompanyInfoObj(ds.Tables(0).Rows(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return companyInfos
    End Function

    ''' <summary>
    ''' This function is used to update Company Info Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="companyInfoObj">ClsCompanyInfo object to update</param>
    ''' <remarks></remarks>
    Public Function UpdateCompanyInfo(ByVal calledBy As String, ByRef companyInfoObj As ClsCompanyInfo) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdateCompanyInfo(companyInfoObj).Trim
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