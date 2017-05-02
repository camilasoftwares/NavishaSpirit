Module ModPurchaseReturnMasterDAL

    Private Function GetPurchaseReturnMasterObj(ByRef row As DataRow) As ClsPurchaseReturnMaster
        Dim purchaseReturnMasterObj As New ClsPurchaseReturnMaster
        Try
            With row
                purchaseReturnMasterObj.Id = .Item(cId)
                purchaseReturnMasterObj.PurchaseReturnCode = .Item(cPurchaseReturnCode)
                purchaseReturnMasterObj.VendorId = .Item(cVendorId)
                purchaseReturnMasterObj.Mode = .Item(cMode)
                purchaseReturnMasterObj.PurchaseId = .Item(cPurchaseId)
                purchaseReturnMasterObj.Remark = .Item(cRemark)
                purchaseReturnMasterObj.UserId = .Item(cUserId)
                purchaseReturnMasterObj.DateOn = .Item(cDateOn)
                purchaseReturnMasterObj.ReturnDate = .Item(cReturnDate)
                purchaseReturnMasterObj.NotClosed = .Item(cNotClosed)
                purchaseReturnMasterObj.DiscountAmount = .Item(cDiscountAmount)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return purchaseReturnMasterObj
    End Function

    Private Function GetPurchaseReturnMaster(ByRef rows As DataRowCollection) As ClsPurchaseReturnMaster()
        Dim purchaseReturnMasterObjs(0) As ClsPurchaseReturnMaster
        purchaseReturnMasterObjs = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer
                Array.Resize(purchaseReturnMasterObjs, count)
                For x = 0 To count - 1
                    purchaseReturnMasterObjs(x) = GetPurchaseReturnMasterObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return purchaseReturnMasterObjs
    End Function

    ''' <summary>
    ''' This function will give records from PurchaseReturnMaster table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>ClsPurchaseReturnMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllPurchaseReturnMasters(ByVal calledBy As String) As ClsPurchaseReturnMaster()
        Dim purchaseReturnMasterObjs(0) As ClsPurchaseReturnMaster
        purchaseReturnMasterObjs = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllPurchaseReturnMaster().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    purchaseReturnMasterObjs = GetPurchaseReturnMaster(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return purchaseReturnMasterObjs
    End Function

    ''' <summary>
    ''' This function will give records from PurchaseReturnMaster table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="forField">Field Name in which search takes place</param>
    ''' <param name="value">Field Value for which search takes place</param>
    ''' <returns>ClsPurchaseReturnMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Private Function GetAllPurchaseReturnMasterValuesLike(ByVal calledBy As String, ByVal forField As String, ByVal value As String) As ClsPurchaseReturnMaster()
        Dim purchaseReturnMasterObjs(0) As ClsPurchaseReturnMaster
        purchaseReturnMasterObjs = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllPurchaseReturnMasterValuesLike(forField, value).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    purchaseReturnMasterObjs = GetPurchaseReturnMaster(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return purchaseReturnMasterObjs
    End Function

    ''' <summary>
    ''' This function will give records from PurchaseReturnMaster table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="value">Field Value for which search takes place</param>
    ''' <returns>ClsPurchaseReturnMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllPurchaseReturnMasterReturnCodeLike(ByVal calledBy As String, ByVal value As String) As ClsPurchaseReturnMaster()
        Return GetAllPurchaseReturnMasterValuesLike(calledBy, cPurchaseReturnCode, value)
    End Function

    ''' <summary>
    ''' This function will give records from PurchaseReturnMaster table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="value">Field Value for which search takes place</param>
    ''' <returns>ClsPurchaseReturnMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllPurchaseReturnMasterPurchaseCodeLike(ByVal calledBy As String, ByVal value As String) As ClsPurchaseReturnMaster()
        Return GetAllPurchaseReturnMasterValuesLike(calledBy, cPurchaseId, value)
    End Function

    ''' <summary>
    ''' This function will give records from PurchaseReturnMaster table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="value">Field Value for which search takes place</param>
    ''' <returns>ClsPurchaseReturnMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllPurchaseReturnMasterVendorLike(ByVal calledBy As String, ByVal value As String) As ClsPurchaseReturnMaster()
        Return GetAllPurchaseReturnMasterValuesLike(calledBy, cVendorId, value)
    End Function

    ''' <summary>
    ''' This function will give records from Purchase Return Master table for given values.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="day">Day for which search takes place</param>
    ''' <param name="month">Month for which search takes place</param>
    ''' <param name="year">Year for which search takes place</param>
    ''' <returns>Array of ClsPurchaseReturnMaster Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllPurchaseReturnMasterLikeReturnDate(ByVal calledBy As String, Optional ByVal day As String = "", Optional ByVal month As String = "", Optional ByVal year As String = "") As ClsPurchaseReturnMaster()
        Dim purchaseReturnMasters(0) As ClsPurchaseReturnMaster
        purchaseReturnMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllPurchaseReturnMasterLikeReturnDate(day, month, year).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    purchaseReturnMasters = GetPurchaseReturnMaster(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return purchaseReturnMasters
    End Function

    ''' <summary>
    ''' This function will give records from PurchaseReturnMaster table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="value">Field for which record is required</param>
    ''' <returns>ClsPurchaseReturnMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetPurchaseReturnMasterById(ByVal calledBy As String, ByVal value As Integer) As ClsPurchaseReturnMaster
        Dim purchaseReturnMasterObj As ClsPurchaseReturnMaster = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetPurchaseReturnMasterById(value).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    purchaseReturnMasterObj = GetPurchaseReturnMasterObj(ds.Tables(0).Rows(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return purchaseReturnMasterObj
    End Function

    ''' <summary>
    ''' This function will give discount Amount from Purchase Return Master table for given id.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which amount is required</param>
    ''' <returns>Amount in Double</returns>
    ''' <remarks></remarks>
    Public Function GetPurchaseReturnMasterDiscountAmount(ByVal calledBy As String, ByVal id As Long) As Double
        Dim result As Double = 0

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetPurchaseReturnMasterDiscountAmount(id).Trim
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
    ''' This function will give records from PurchaseReturnMaster table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="loginName">Login for which record is required</param>
    ''' <returns>ClsPurchaseReturnMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetPurchaseReturnMasterNotClosedForLogin(ByVal calledBy As String, ByVal loginName As String) As ClsPurchaseReturnMaster
        Dim purchaseReturnMasterObj As ClsPurchaseReturnMaster = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetPurchaseReturnMasterNotClosedForLogin(loginName).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    purchaseReturnMasterObj = GetPurchaseReturnMasterObj(ds.Tables(0).Rows(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return purchaseReturnMasterObj
    End Function

    ''' <summary>
    ''' This function is used to insert PurchaseReturnMaster Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="purchaseReturnMasterObj">ClsPurchaseReturnMaster object to insert</param>
    ''' <returns>Auto generated Id</returns>
    ''' <remarks></remarks>
    Public Function InsertPurchaseReturnMaster(ByVal calledBy As String, ByRef purchaseReturnMasterObj As ClsPurchaseReturnMaster) As Long
        Dim result As Long = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertPurchaseReturnMaster(purchaseReturnMasterObj).Trim
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
    ''' This function is used to update PurchaseReturnMaster Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="purchaseReturnMasterObj">ClsPurchaseReturnMaster object to update</param>
    ''' <remarks></remarks>
    Public Function UpdatePurchaseReturnMaster(ByVal calledBy As String, ByRef purchaseReturnMasterObj As ClsPurchaseReturnMaster) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdatePurchaseReturnMaster(purchaseReturnMasterObj).Trim
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