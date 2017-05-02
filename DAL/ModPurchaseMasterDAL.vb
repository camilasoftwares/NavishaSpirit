'Handles all Functionality related to ClsPurchaseMaster
Module ModPurchaseMasterDAL

    Private Function GetPurchaseMasterObj(ByRef row As DataRow) As ClsPurchaseMaster
        Dim purchaseMaster As New ClsPurchaseMaster
        Try
            With row
                purchaseMaster.Id = .Item(cId)
                purchaseMaster.PurchaseCode = .Item(cPurchaseCode)
                purchaseMaster.VendorId = .Item(cVendorId)
                purchaseMaster.Mode = .Item(cMode)
                purchaseMaster.VoucherNo = .Item(cVoucherNo)
                purchaseMaster.OrderId = .Item(cOrderId)
                purchaseMaster.Remark = .Item(cRemark)
                purchaseMaster.UserId = .Item(cUserId)
                purchaseMaster.DateOn = .Item(cDateOn)
                purchaseMaster.PurchaseDate = .Item(cPurchaseDate)
                purchaseMaster.NotClosed = .Item(cNotClosed)
                purchaseMaster.CreditAdjust = .Item(cCreditAdjust)
                purchaseMaster.DebitAdjust = .Item(cDebitAdjust)
                purchaseMaster.DiscountAmount = .Item(cDiscountAmount)
                purchaseMaster.TaxId = .Item(cTaxId)
                purchaseMaster.TaxPercent = .Item(cTaxPercent)
                purchaseMaster.PreExciseAmount = .Item(cPreExciseAmount)
                purchaseMaster.FreightCharge = .Item(cFreightCharge)
            End With

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return purchaseMaster
    End Function

    Private Function GetPurchaseMaster(ByRef rows As DataRowCollection) As ClsPurchaseMaster()
        Dim purchaseMasters(0) As ClsPurchaseMaster
        purchaseMasters = Nothing

        Try
            Dim count As Integer = rows.Count
            If count > 0 Then
                Dim x As Integer

                Array.Resize(purchaseMasters, count)
                For x = 0 To count - 1
                    purchaseMasters(x) = GetPurchaseMasterObj(rows(x))
                Next
            End If

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return purchaseMasters
    End Function

    ''' <summary>
    ''' This function will give records from Purchase Master table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <returns>ClsPurchaseMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllPurchaseMaster(ByVal calledBy As String) As ClsPurchaseMaster()
        Dim purchaseMasters(0) As ClsPurchaseMaster
        purchaseMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllPurchaseMaster().Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    purchaseMasters = GetPurchaseMaster(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return purchaseMasters
    End Function

    ''' <summary>
    ''' This function will give records from Purchase Master table for vendor code.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="vendorCode">Code for which records are required</param>
    ''' <returns>Array of ClsPurchaseMaster Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllPurchaseMasterForVendorCode(ByVal calledBy As String, ByVal vendorCode As String) As ClsPurchaseMaster()
        Dim purchaseMasters(0) As ClsPurchaseMaster
        purchaseMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllPurchaseMasterForVendorCode(vendorCode).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    purchaseMasters = GetPurchaseMaster(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return purchaseMasters
    End Function

    ''' <summary>
    ''' This function will give records from Purchase Master table for values like.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="forField">Field in which search takes place</param>
    ''' <param name="value">Value to search like</param>
    ''' <returns>Array of ClsPurchaseMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Private Function GetAllPurchaseMasterValuesLike(ByVal calledBy As String, ByVal forField As String, ByVal value As String) As ClsPurchaseMaster()
        Dim purchaseMasters(0) As ClsPurchaseMaster
        purchaseMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllPurchaseMasterValuesLike(forField, value).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    purchaseMasters = GetPurchaseMaster(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return purchaseMasters
    End Function

    ''' <summary>
    ''' This function will give records from Purchase Master table for given values.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="day">Day for which search takes place</param>
    ''' <param name="month">Month for which search takes place</param>
    ''' <param name="year">Year for which search takes place</param>
    ''' <returns>Array of ClsPurchaseMaster Objects or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllPurchaseMasterLikePurchaseDate(ByVal calledBy As String, Optional ByVal day As String = "", Optional ByVal month As String = "", Optional ByVal year As String = "") As ClsPurchaseMaster()
        Dim purchaseMasters(0) As ClsPurchaseMaster
        purchaseMasters = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetAllPurchaseMasterLikePurchaseDate(day, month, year).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    purchaseMasters = GetPurchaseMaster(ds.Tables(0).Rows)
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return purchaseMasters
    End Function

    ''' <summary>
    ''' This function will give records from Purchase Master table for values like.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="value">Value to search like</param>
    ''' <returns>Array of ClsPurchaseMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllPurchaseMasterPurchaseCodeLike(ByVal calledBy As String, ByVal value As String) As ClsPurchaseMaster()
        Return GetAllPurchaseMasterValuesLike(calledBy, cPurchaseCode, value)
    End Function

    ''' <summary>
    ''' This function will give records from Purchase Master table for values like.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="value">Value to search like</param>
    ''' <returns>Array of ClsPurchaseMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllPurchaseMasterVendorLike(ByVal calledBy As String, ByVal value As String) As ClsPurchaseMaster()
        Return GetAllPurchaseMasterValuesLike(calledBy, cVendorId, value)
    End Function

    ''' <summary>
    ''' This function will give records from Purchase Master table for values like.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="value">Value to search like</param>
    ''' <returns>Array of ClsPurchaseMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllPurchaseMasterVoucherNoLike(ByVal calledBy As String, ByVal value As String) As ClsPurchaseMaster()
        Return GetAllPurchaseMasterValuesLike(calledBy, cVoucherNo, value)
    End Function

    ''' <summary>
    ''' This function will give records from Purchase Master table for values like.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="value">Value to search like</param>
    ''' <returns>Array of ClsPurchaseMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetAllPurchaseMasterAgainstOrderLike(ByVal calledBy As String, ByVal value As String) As ClsPurchaseMaster()
        Return GetAllPurchaseMasterValuesLike(calledBy, cOrderId, value)
    End Function

    ''' <summary>
    ''' This function will give record from Purchase Master table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="loginName">Login Name for which the record is required</param>
    ''' <returns>ClsPurchaseMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetPurchaseMasterNotClosedForLogin(ByVal calledBy As String, ByVal loginName As String) As ClsPurchaseMaster
        Dim purchaseMaster As ClsPurchaseMaster = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetPurchaseMasterNotClosedForLogin(loginName).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    purchaseMaster = GetPurchaseMasterObj(ds.Tables(0).Rows(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return purchaseMaster
    End Function

    ''' <summary>
    ''' This function will give purchase id from Purchase Master table not closed.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="loginName">Login Name for which the record is required</param>
    ''' <returns>Id in int or cInvalidId</returns>
    ''' <remarks></remarks>
    Public Function GetPurchaseMasterIdNotClosedForLogin(ByVal calledBy As String, ByVal loginName As String) As Integer
        Dim result As Integer = cInvalidId

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetPurchaseMasterIdNotClosedForLogin(loginName).Trim
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
    ''' This function will give record from Purchase Master table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="id">Id for which record is required</param>
    ''' <returns>ClsPurchaseMaster Object or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetPurchaseMaster(ByVal calledBy As String, ByVal id As Integer) As ClsPurchaseMaster
        Dim purchaseMaster As ClsPurchaseMaster = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.GetPurchaseMaster(id).Trim
                If sql = "" Then Exit For

                Dim ds As DataSet = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count > 0 Then
                    purchaseMaster = GetPurchaseMasterObj(ds.Tables(0).Rows(0))
                End If
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return purchaseMaster
    End Function


    ''' <summary>
    ''' This function is used to insert Purchase Master Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="purchaseMasterObj">ClsPurchaseMaster object to insert</param>
    ''' <remarks></remarks>
    Public Function InsertIntoPurchaseMaster(ByVal calledBy As String, ByRef purchaseMasterObj As ClsPurchaseMaster) As Integer
        Dim result As Integer = cInvalidId
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.InsertIntoPurchaseMaster(purchaseMasterObj).Trim
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
    ''' This function is used to update Purchase Master Object in Table.
    ''' </summary>
    ''' <param name="calledBy">Called from class or function. Used for log purpose</param>
    ''' <param name="purchaseMasterObj">ClsPurchaseMaster object to update</param>
    ''' <remarks></remarks>
    Public Function UpdatePurchaseMaster(ByVal calledBy As String, ByRef purchaseMasterObj As ClsPurchaseMaster) As EnResult
        Dim result As EnResult = EnResult.NoChange
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScripts.GetInstance.UpdatePurchaseMaster(purchaseMasterObj).Trim
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