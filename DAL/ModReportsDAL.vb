Module ModReportsDAL

    ''' <summary>
    ''' This function will give dataset for Ledger
    ''' </summary>
    ''' <param name="calledBy">Used for Log Purpose</param>
    ''' <param name="headId">HeadId for which ds is required</param>
    ''' <returns>DataSet or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetLedgerForHeadId(ByVal calledBy As String, ByVal headId As Integer, ByVal dateFrom As Date, ByVal dateTo As Date) As DataSet
        Dim ds As DataSet = Nothing
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.GetLedgerForHeadId(headId, dateFrom, dateTo).Trim

                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function

    ''' <summary>
    ''' This function will give dataset for Bank Book
    ''' </summary>
    ''' <param name="calledBy">Used for Log Purpose</param>
    ''' <param name="headId">HeadId for which ds is required</param>
    ''' <returns>DataSet or nothing</returns>
    ''' <remarks></remarks>
    Public Function GetBankBookForHeadId(ByVal calledBy As String, ByVal headId As Integer, ByVal dateFrom As Date, ByVal dateTo As Date) As DataSet
        Dim ds As DataSet = Nothing
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.GetBankBookForHeadId(headId, dateFrom, dateTo).Trim

                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function

    ''' <summary>
    ''' This will give Cr, Dr and Opening balance for given date and head Id
    ''' </summary>
    ''' <param name="calledBy">Used for Log purpose</param>
    ''' <param name="headId">Head Id for which records are required</param>
    ''' <param name="dateBefore">Date before which records are required</param>
    ''' <returns>Dataset Or Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetCrDrOpeningBalance(ByVal calledBy As String, ByVal headId As Integer, ByVal dateBefore As Date) As DataSet
        Dim ds As DataSet = Nothing
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.GetCrDrOpeningBalance(headId, dateBefore).Trim

                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count = 0 Then ds = Nothing
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function

    ''' <summary>
    ''' This will give Id and a/c Name for given head Id from Cheque Payment and Account Head
    ''' </summary>
    ''' <param name="calledBy">Used for Log purpose</param>
    ''' <param name="headId">Head Id for which records are required</param>
    ''' <returns>Dataset Or Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetIdNameFromChequePaymentForHeadId(ByVal calledBy As String, ByVal headId As Integer) As DataSet
        Dim ds As DataSet = Nothing
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.GetIdNameFromChequePaymentForHeadId(headId).Trim

                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count = 0 Then ds = Nothing
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function

    ''' <summary>
    ''' This will give Id and a/c Name for given head Id from Cheque Receipt and Account Head
    ''' </summary>
    ''' <param name="calledBy">Used for Log purpose</param>
    ''' <param name="headId">Head Id for which records are required</param>
    ''' <returns>Dataset Or Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetIdNameFromChequeReceiptForHeadId(ByVal calledBy As String, ByVal headId As Integer) As DataSet
        Dim ds As DataSet = Nothing
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.GetIdNameFromChequeReceiptForHeadId(headId).Trim

                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count = 0 Then ds = Nothing
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function

    ''' <summary>
    ''' This will give Id and a/c Name for given head Id from Cash Payment and Account Head
    ''' </summary>
    ''' <param name="calledBy">Used for Log purpose</param>
    ''' <param name="headId">Head Id for which records are required</param>
    ''' <returns>Dataset Or Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetIdNameFromCashPaymentForHeadId(ByVal calledBy As String, ByVal headId As Integer) As DataSet
        Dim ds As DataSet = Nothing
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.GetIdNameFromCashPaymentForHeadId(headId).Trim

                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count = 0 Then ds = Nothing
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function

    ''' <summary>
    ''' This will give Id and a/c Name for given head Id from Cash Receipt and Account Head
    ''' </summary>
    ''' <param name="calledBy">Used for Log purpose</param>
    ''' <param name="headId">Head Id for which records are required</param>
    ''' <returns>Dataset Or Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetIdNameFromCashReceiptForHeadId(ByVal calledBy As String, ByVal headId As Integer) As DataSet
        Dim ds As DataSet = Nothing
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.GetIdNameFromCashReceiptForHeadId(headId).Trim

                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
                If ds.Tables(0).Rows.Count = 0 Then ds = Nothing
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function

    ''' <summary>
    ''' This will give Stock Ledger Dataset for given item id
    ''' </summary>
    ''' <param name="calledBy">Used for Log purpose</param>
    ''' <param name="itemId">Item Id for which records are required</param>
    ''' <returns>Dataset Or Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetStockLedgerForItemId(ByVal calledBy As String, ByVal itemId As Integer) As DataSet
        Dim ds As DataSet = Nothing
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.GetStockLedgerForItemId(itemId).Trim

                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function

    ''' <summary>
    ''' This will give Gross Sale Dataset for given values
    ''' </summary>
    ''' <param name="calledBy">Used for Log purpose</param>
    ''' <param name="dateFrom">Optional: Date from which data is required</param>
    ''' <param name="dateTo">Optional: Date upto which data is required</param>
    ''' <param name="userId">Optional: User id for which data is required</param>
    ''' <returns>Dataset Or Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetGrossSales(ByVal calledBy As String, Optional ByVal dateFrom As Date = Nothing, Optional ByVal dateTo As Date = Nothing, Optional ByVal userId As String = "") As DataSet
        Dim ds As DataSet = Nothing
        If dateFrom = Nothing Then dateFrom = DateDefault
        If dateTo = Nothing Then dateTo = Now

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.GetGrossSales(dateFrom, dateTo, userId).Trim

                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function

    ''' <summary>
    ''' This will give Itemwise Sale Dataset for given values
    ''' </summary>
    ''' <param name="calledBy">Used for Log purpose</param>
    ''' <param name="dateFrom">Optional: Date from which data is required</param>
    ''' <param name="dateTo">Optional: Date upto which data is required</param>
    ''' <param name="itemId" >Optioanl : Item id for which data is required</param>
    ''' <returns>Dataset Or Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetItemWiseSale(ByVal calledBy As String, Optional ByVal dateFrom As Date = Nothing, Optional ByVal dateTo As Date = Nothing, Optional ByVal itemId As Integer = cInvalidId) As DataSet
        Dim ds As DataSet = Nothing
        If dateFrom = Nothing Then dateFrom = DateDefault
        If dateTo = Nothing Then dateTo = Now

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.GetItemWiseSale(dateFrom, dateTo, itemId).Trim

                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function
    Public Function GetItemCatWiseSale(ByVal calledBy As String, Optional ByVal dateFrom As Date = Nothing, Optional ByVal dateTo As Date = Nothing, Optional ByVal itemId As Integer = cInvalidId) As DataSet
        Dim ds As DataSet = Nothing
        If dateFrom = Nothing Then dateFrom = DateDefault
        If dateTo = Nothing Then dateTo = Now

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.GetItemCatWiseSale(dateFrom, dateTo, itemId).Trim

                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function


    Public Function GetTaxRpt(Optional ByVal dateFrom As Date = Nothing, Optional ByVal dateTo As Date = Nothing) As DataSet
        Dim ds As DataSet = Nothing
        If dateFrom = Nothing Then dateFrom = DateDefault
        If dateTo = Nothing Then dateTo = Now

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.Gettax(dateFrom, dateTo).Trim

                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, "")
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function
    Public Function GetBunchRpt(ByVal calledBy As String, Optional ByVal dateFrom As Date = Nothing, Optional ByVal dateTo As Date = Nothing) As DataSet
        Dim ds As DataSet = Nothing
        If dateFrom = Nothing Then dateFrom = DateDefault
        If dateTo = Nothing Then dateTo = Now

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.GetBunchSale(dateFrom, dateTo).Trim

                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function





    ''' <summary>
    ''' This will give Itemwise Sale Dataset for given values
    ''' </summary>
    ''' <param name="calledBy">Used for Log purpose</param>
    ''' <param name="dateFrom">Optional: Date from which data is required</param>
    ''' <param name="dateTo">Optional: Date upto which data is required</param>
    ''' <param name="itemId" >Optioanl : Item id for which data is required</param>
    ''' <returns>Dataset Or Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetItemWisePartywiseSale(ByVal calledBy As String, Optional ByVal dateFrom As Date = Nothing, Optional ByVal dateTo As Date = Nothing, Optional ByVal itemId As Integer = cInvalidId, Optional ByVal customerId As Integer = cInvalidId) As DataSet
        Dim ds As DataSet = Nothing
        If dateFrom = Nothing Then dateFrom = DateDefault
        If dateTo = Nothing Then dateTo = Now

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.GetItemWisePartywiseSale(dateFrom, dateTo, itemId, customerId).Trim

                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function

    ''' <summary>
    ''' This will give Credit Sale Dataset for given values
    ''' </summary>
    ''' <param name="calledBy">Used for Log purpose</param>
    ''' <param name="dateFrom">Optional: Date from which data is required</param>
    ''' <param name="dateTo">Optional: Date upto which data is required</param>
    ''' <returns>Dataset Or Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetCreditSale(ByVal calledBy As String, Optional ByVal dateFrom As Date = Nothing, Optional ByVal dateTo As Date = Nothing) As DataSet
        Dim ds As DataSet = Nothing
        If dateFrom = Nothing Then dateFrom = DateDefault
        If dateTo = Nothing Then dateTo = Now

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.GetCreditSale(dateFrom, dateTo, cStatusCredit).Trim

                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function

    ''' <summary>
    ''' This will give PatientWise Sale Dataset for given values
    ''' </summary>
    ''' <param name="calledBy">Used for Log purpose</param>
    ''' <param name="dateFrom">Optional: Date from which data is required</param>
    ''' <param name="dateTo">Optional: Date upto which data is required</param>
    ''' <param name="customerId " >Optioanl : Customer id for which data is required</param>
    ''' <returns>Dataset Or Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetPatientWiseSale(ByVal calledBy As String, Optional ByVal dateFrom As Date = Nothing, Optional ByVal dateTo As Date = Nothing, Optional ByVal customerId As Integer = cInvalidId, Optional ByVal taxId As Integer = cInvalidId) As DataSet
        Dim ds As DataSet = Nothing
        If dateFrom = Nothing Then dateFrom = DateDefault
        If dateTo = Nothing Then dateTo = Now

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.GetPatientWiseSale(dateFrom, dateTo, customerId, taxId).Trim

                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function

    ''' <summary>
    ''' This will give Head Quarter Sale Dataset for given values
    ''' </summary>
    ''' <param name="calledBy">Used for Log purpose</param>
    ''' <param name="dateFrom">Optional: Date from which data is required</param>
    ''' <param name="dateTo">Optional: Date upto which data is required</param>
    ''' <param name="hqId" >Optioanl : Head Quarter id for which data is required</param>
    ''' <param name="taxId" > Optional : Tax Id for Which Data is Required </param>
    ''' <returns>Dataset Or Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetHQWiseSale(ByVal calledBy As String, Optional ByVal dateFrom As Date = Nothing, Optional ByVal dateTo As Date = Nothing, Optional ByVal hqId As Integer = cInvalidId, Optional ByVal taxId As Integer = cInvalidId) As DataSet
        Dim ds As DataSet = Nothing
        If dateFrom = Nothing Then dateFrom = DateDefault
        If dateTo = Nothing Then dateTo = Now

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.GetHQWiseSale(dateFrom, dateTo, hqId, taxId).Trim

                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function

    ''' <summary>
    ''' This will give Itemwise Purchase Dataset for given values
    ''' </summary>
    ''' <param name="calledBy">Used for Log purpose</param>
    ''' <param name="dateFrom">Optional: Date from which data is required</param>
    ''' <param name="dateTo">Optional: Date upto which data is required</param>
    ''' <param name="vendorId">Optional: vendor id for which data is required</param>
    ''' <returns>Dataset Or Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetVendorWisePurchase(ByVal calledBy As String, Optional ByVal dateFrom As Date = Nothing, Optional ByVal dateTo As Date = Nothing, Optional ByVal vendorId As Integer = cInvalidId) As DataSet
        Dim ds As DataSet = Nothing
        If dateFrom = Nothing Then dateFrom = DateDefault
        If dateTo = Nothing Then dateTo = Now

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.GetVendorWisePurchase(dateFrom, dateTo, vendorId).Trim

                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function

    ''' <summary>
    ''' This will give Journals Dataset for given values
    ''' </summary>
    ''' <param name="calledBy">Used for Log purpose</param>
    ''' <param name="dateFrom">Optional: Date from which data is required</param>
    ''' <param name="dateTo">Optional: Date upto which data is required</param>
    ''' <returns>Dataset Or Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetJournals(ByVal calledBy As String, Optional ByVal dateFrom As Date = Nothing, Optional ByVal dateTo As Date = Nothing) As DataSet
        Dim ds As DataSet = Nothing
        If dateFrom = Nothing Then dateFrom = DateDefault
        If dateTo = Nothing Then dateTo = Now

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.GetJournals(dateFrom, dateTo).Trim

                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function

    ''' <summary>
    ''' This will give Stock Dataset for given values. Gives first valid id data
    ''' </summary>
    ''' <param name="calledBy">Used for Log purpose</param>
    ''' <param name="stockInDemand">Optional: True, if wants data for Stock In Demand</param>
    ''' <param name="categoryId">Optional: Id for which data is required</param>
    ''' <param name="itemId">Optional: Id for which data is required</param>
    ''' <param name="manufacturerId">Optional: Id for which data is required</param>
    ''' <param name="scheduleId">Optional: Id for which data is required</param>
    ''' <param name="storageId">Optional: Id for which data is required</param>
    ''' <returns>Dataset Or Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetStock(ByVal calledBy As String, Optional ByVal stockInDemand As Boolean = False, Optional ByVal categoryId As Integer = cInvalidId, Optional ByVal itemId As Integer = cInvalidId, Optional ByVal manufacturerId As Integer = cInvalidId, Optional ByVal storageId As Integer = cInvalidId, Optional ByVal scheduleId As Integer = cInvalidId) As DataSet
        Dim ds As DataSet = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ""
                If stockInDemand = False Then
                    sql = ClsScriptsReport.GetInstance.GetStockInHand(categoryId, itemId, manufacturerId, storageId, scheduleId).Trim
                Else
                    sql = ClsScriptsReport.GetInstance.GetStockInDemand(categoryId, itemId, manufacturerId, storageId, scheduleId).Trim
                End If

                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function

    ''' <summary>
    ''' This will give items Availability Dataset for given values. Gives first valid id data
    ''' </summary>
    ''' <param name="calledBy">Used for Log purpose</param>
    ''' <param name="flagExceptZeroQuantity">True to exclude 0 quantity records</param>
    ''' <param name="genericId1">Optional: Id for which data is required</param>
    ''' <param name="genericId2">Optional: Id for which data is required</param>
    ''' <param name="genericId3">Optional: Id for which data is required</param>
    ''' <param name="manufacturerId">Optional: Id for which data is required</param>
    ''' <param name="categoryId">Optional: Id for which data is required</param>
    ''' <param name="scheduleId">Optional: Id for which data is required</param>
    ''' <returns>Dataset Or Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetItemsAvailability(ByVal calledBy As String, Optional ByVal flagExceptZeroQuantity As Boolean = False, Optional ByVal genericId1 As Integer = cInvalidId, Optional ByVal genericId2 As Integer = cInvalidId, Optional ByVal genericId3 As Integer = cInvalidId, Optional ByVal manufacturerId As Integer = cInvalidId, Optional ByVal categoryId As Integer = cInvalidId, Optional ByVal scheduleId As Integer = cInvalidId) As DataSet
        Dim ds As DataSet = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.GetItemsAvailability(flagExceptZeroQuantity, genericId1, genericId2, genericId3, manufacturerId, categoryId, scheduleId).Trim

                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function

    ''' <summary>
    ''' This will give Gross Purchase Dataset for given values
    ''' </summary>
    ''' <param name="calledBy">Used for Log purpose</param>
    ''' <param name="dateFrom">Optional: Date from which data is required</param>
    ''' <param name="dateTo">Optional: Date upto which data is required</param>
    ''' <param name="vendorId">Optional: vendor id for which data is required</param>
    ''' <returns>Dataset Or Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetGrossPurchase(ByVal calledBy As String, Optional ByVal dateFrom As Date = Nothing, Optional ByVal dateTo As Date = Nothing, Optional ByVal vendorId As Integer = cInvalidId) As DataSet
        Dim ds As DataSet = Nothing
        If dateFrom = Nothing Then dateFrom = DateDefault
        If dateTo = Nothing Then dateTo = Now

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.GetGrossPurchase(dateFrom, dateTo, vendorId).Trim

                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function

    ''' <summary>
    ''' This will give  Purchase Dataset for given values
    ''' </summary>
    ''' <param name="calledBy">Used for Log purpose</param>
    ''' <param name="dateFrom">Optional: Date from which data is required</param>
    ''' <param name="dateTo">Optional: Date upto which data is required</param>
    ''' <returns>Dataset Or Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetPurchase(ByVal calledBy As String, Optional ByVal dateFrom As Date = Nothing, Optional ByVal dateTo As Date = Nothing) As DataSet
        Dim ds As DataSet = Nothing
        If dateFrom = Nothing Then dateFrom = DateDefault
        If dateTo = Nothing Then dateTo = Now

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.GetPurchase(dateFrom, dateTo).Trim

                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function

    ''' <summary>
    ''' This will give Itemwise Purchase Dataset for given values
    ''' </summary>
    ''' <param name="calledBy">Used for Log purpose</param>
    ''' <param name="dateFrom">Optional: Date from which data is required</param>
    ''' <param name="dateTo">Optional: Date upto which data is required</param>
    ''' <param name="itemId ">Optional: Item id for which data is required</param>
    ''' <returns>Dataset Or Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetItemWisePurchase(ByVal calledBy As String, Optional ByVal dateFrom As Date = Nothing, Optional ByVal dateTo As Date = Nothing, Optional ByVal itemId As Integer = cInvalidId) As DataSet
        Dim ds As DataSet = Nothing
        If dateFrom = Nothing Then dateFrom = DateDefault
        If dateTo = Nothing Then dateTo = Now

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.GetItemWisePurchase(dateFrom, dateTo, itemId).Trim

                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function

    ''' <summary>
    ''' This will give Tax for Sales Dataset for given values
    ''' </summary>
    ''' <param name="calledBy">Used for Log purpose</param>
    ''' <param name="dateFrom">Optional: Date from which data is required</param>
    ''' <param name="dateTo">Optional: Date upto which data is required</param>
    ''' <returns>Dataset Or Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetTaxForSales(ByVal calledBy As String, Optional ByVal dateFrom As Date = Nothing, Optional ByVal dateTo As Date = Nothing) As DataSet
        Dim ds As DataSet = Nothing
        If dateFrom = Nothing Then dateFrom = DateDefault
        If dateTo = Nothing Then dateTo = Now

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.GetTaxForSales(dateFrom, dateTo).Trim

                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function

    ''' <summary>
    ''' This will give Company Dataset
    ''' </summary>
    ''' <param name="calledBy">Used for Log purpose</param>
    ''' <returns>Dataset Or Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetCompany(ByVal calledBy As String) As DataSet
        Dim ds As DataSet = Nothing
        
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.GetCompany().Trim
                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function

    ''' <summary>
    ''' This will give Company logo Dataset
    ''' </summary>
    ''' <param name="calledBy">Used for Log purpose</param>
    ''' <returns>Dataset Or Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetCompanyLogo(ByVal calledBy As String) As DataSet
        Dim ds As DataSet = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.GetCompanyLogo().Trim
                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function

    ''' <summary>
    ''' This will give Sales Dataset
    ''' </summary>
    ''' <param name="calledBy">Used for Log purpose</param>
    ''' <param name="saleId">Sale Id for which record is required</param>
    ''' <returns>Dataset Or Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetSales(ByVal calledBy As String, ByVal saleId As Long) As DataSet
        Dim ds As DataSet = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.GetSales(saleId).Trim
                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function

    ''' <summary>
    ''' This will give Sample Dataset
    ''' </summary>
    ''' <param name="calledBy">Used for Log purpose</param>
    ''' <param name="sampleId">Sample Id for which record is required</param>
    ''' <returns>Dataset Or Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetSample(ByVal calledBy As String, ByVal sampleId As Long) As DataSet
        Dim ds As DataSet = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.GetSample(sampleId).Trim
                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function

    ''' <summary>
    ''' This will give Purchase Order Dataset
    ''' </summary>
    ''' <param name="calledBy">Used for Log purpose</param>
    ''' <param name="purchaseOrderId">Purchase Order Id for which record is required</param>
    ''' <returns>Dataset Or Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetPurchaseOrder(ByVal calledBy As String, ByVal purchaseOrderId As Long) As DataSet
        Dim ds As DataSet = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.GetPurchaseOrder(purchaseOrderId).Trim
                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function

    ''' <summary>
    ''' This will give Destruction Dataset
    ''' </summary>
    ''' <param name="calledBy">Used for Log purpose</param>
    ''' <param name="destructionId">Destruction Id for which record is required</param>
    ''' <returns>Dataset Or Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetDestructionSlip(ByVal calledBy As String, ByVal destructionId As Long) As DataSet
        Dim ds As DataSet = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.GetDestructionSlip(destructionId).Trim
                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function

    ''' <summary>
    ''' This will give Purchase Dataset
    ''' </summary>
    ''' <param name="calledBy">Used for Log purpose</param>
    ''' <param name="purchaseId">Purchase Id for which record is required</param>
    ''' <returns>Dataset Or Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetPurchase(ByVal calledBy As String, ByVal purchaseId As Long) As DataSet
        Dim ds As DataSet = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.GetPurchase(purchaseId).Trim
                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function

    ''' <summary>
    ''' This will give Purchase Return Dataset
    ''' </summary>
    ''' <param name="calledBy">Used for Log purpose</param>
    ''' <param name="purchaseReturnId">PurchaseReturn Id for which record is required</param>
    ''' <returns>Dataset Or Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetPurchaseReturn(ByVal calledBy As String, ByVal purchaseReturnId As Integer) As DataSet
        Dim ds As DataSet = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.GetPurchaseReturn(purchaseReturnId).Trim
                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function

    ''' <summary>
    ''' This will give  Purchase Return Dataset for given values
    ''' </summary>
    ''' <param name="calledBy">Used for Log purpose</param>
    ''' <param name="dateFrom">Optional: Date from which data is required</param>
    ''' <param name="dateTo">Optional: Date upto which data is required</param>
    ''' <returns>Dataset Or Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetPurchaseReturn(ByVal calledBy As String, Optional ByVal dateFrom As Date = Nothing, Optional ByVal dateTo As Date = Nothing) As DataSet
        Dim ds As DataSet = Nothing
        If dateFrom = Nothing Then dateFrom = DateDefault
        If dateTo = Nothing Then dateTo = Now

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.GetPurchaseReturn(dateFrom, dateTo).Trim

                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function

    ''' <summary>
    ''' This will give Sales Return Dataset
    ''' </summary>
    ''' <param name="calledBy">Used for Log purpose</param>
    ''' <param name="salesReturnId">SalesReturn Id for which record is required</param>
    ''' <returns>Dataset Or Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetSalesReturn(ByVal calledBy As String, ByVal salesReturnId As Long) As DataSet
        Dim ds As DataSet = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.GetSalesReturn(salesReturnId).Trim
                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function

    ''' <summary>
    ''' This will give Expiry Details Dataset
    ''' </summary>
    ''' <param name="calledBy">Used for Log purpose</param>
    ''' <param name="fromDate">From date from which record is required</param>
    ''' <param name="toDate">To date upto which record is required</param>
    ''' <returns>Dataset Or Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetExpiryDetails(ByVal calledBy As String, ByVal fromDate As Date, ByVal toDate As Date) As DataSet
        Dim ds As DataSet = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.GetExpiryDetails(fromDate, toDate).Trim
                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function

    ''' <summary>
    ''' This will give Current Stock Expiring Details Dataset
    ''' </summary>
    ''' <param name="calledBy">Used for Log purpose</param>
    ''' <param name="fromDate">From date from which record is required</param>
    ''' <param name="toDate">To date upto which record is required</param>
    ''' <returns>Dataset Or Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetCurrentStockExpiringBetweenDates(ByVal calledBy As String, ByVal fromDate As Date, ByVal toDate As Date) As DataSet
        Dim ds As DataSet = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.GetCurrentStockExpiringBetweenDates(fromDate, toDate).Trim
                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function

    ''' <summary>
    ''' This will give Free Stock TransactionDataset
    ''' </summary>
    ''' <param name="calledBy">Used for Log purpose</param>
    ''' <param name="saleId">Sale Id for which record is required</param>
    ''' <returns>Dataset Or Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetFreeStockTransactionForSaleId(ByVal calledBy As String, ByVal saleId As Long) As DataSet
        Dim ds As DataSet = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.GetFreeStockTransactionForSaleId(saleId).Trim
                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function

    ''' <summary>
    ''' This will give Legal Terms Dataset
    ''' </summary>
    ''' <param name="calledBy">Used for Log purpose</param>
    ''' <returns>Dataset Or Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetLegalTermsForReport(ByVal calledBy As String) As DataSet
        Dim ds As DataSet = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.GetLegalTermsForReport().Trim
                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function

#Region "Sample Issue "

    ''' <summary>
    ''' This will give Customerwise Sale Dataset for given values
    ''' </summary>
    ''' <param name="calledBy">Used for Log purpose</param>
    ''' <param name="dateFrom">Optional: Date from which data is required</param>
    ''' <param name="dateTo">Optional: Date upto which data is required</param>
    ''' <param name="customerId " >Optioanl : Customer id for which data is required</param>
    ''' <returns>Dataset Or Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetCustomerWiseSampleIssue(ByVal calledBy As String, Optional ByVal dateFrom As Date = Nothing, Optional ByVal dateTo As Date = Nothing, Optional ByVal customerId As Integer = cInvalidId) As DataSet
        Dim ds As DataSet = Nothing
        If dateFrom = Nothing Then dateFrom = DateDefault
        If dateTo = Nothing Then dateTo = Now

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.GetCustomerWiseIssueSample(dateFrom, dateTo, customerId).Trim

                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function
#End Region

#Region "Sales Return"

    ''' <summary>
    ''' This will give  Sales Return Dataset for given values
    ''' </summary>
    ''' <param name="calledBy">Used for Log purpose</param>
    ''' <param name="dateFrom">Optional: Date from which data is required</param>
    ''' <param name="dateTo">Optional: Date upto which data is required</param>
    ''' <returns>Dataset Or Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetSalesReturn(ByVal calledBy As String, Optional ByVal dateFrom As Date = Nothing, Optional ByVal dateTo As Date = Nothing) As DataSet
        Dim ds As DataSet = Nothing
        If dateFrom = Nothing Then dateFrom = DateDefault
        If dateTo = Nothing Then dateTo = Now

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.GetSalesReturn(dateFrom, dateTo).Trim

                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function
#End Region

#Region "Party Wise Sale"
    ''' <summary>
    ''' This will give PatientWise Sale Dataset for given values
    ''' </summary>
    ''' <param name="calledBy">Used for Log purpose</param>
    ''' <param name="dateFrom">Optional: Date from which data is required</param>
    ''' <param name="dateTo">Optional: Date upto which data is required</param>
    ''' <param name="customerId " >Optioanl : Customer id for which data is required</param>
    ''' <returns>Dataset Or Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetPartyWiseSale(ByVal calledBy As String, Optional ByVal dateFrom As Date = Nothing, Optional ByVal dateTo As Date = Nothing, Optional ByVal customerId As Integer = cInvalidId) As DataSet
        Dim ds As DataSet = Nothing
        If dateFrom = Nothing Then dateFrom = DateDefault
        If dateTo = Nothing Then dateTo = Now

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.GetPartyWiseSale(dateFrom, dateTo, customerId).Trim

                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function

#End Region

#Region "Collection "

    ''' <summary>
    ''' This will give  Collection Dataset for given values
    ''' </summary>
    ''' <param name="calledBy">Used for Log purpose</param>
    ''' <param name="dateFrom">Optional: Date from which data is required</param>
    ''' <param name="dateTo">Optional: Date upto which data is required</param>
    ''' <returns>Dataset Or Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetCollection(ByVal calledBy As String, Optional ByVal dateFrom As Date = Nothing, Optional ByVal dateTo As Date = Nothing) As DataSet
        Dim ds As DataSet = Nothing
        If dateFrom = Nothing Then dateFrom = DateDefault
        If dateTo = Nothing Then dateTo = Now

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.GetCollection(dateFrom, dateTo).Trim

                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function

#End Region

#Region "Payment "

    ''' <summary>
    ''' This will give  Payment Dataset for given values
    ''' </summary>
    ''' <param name="calledBy">Used for Log purpose</param>
    ''' <param name="dateFrom">Optional: Date from which data is required</param>
    ''' <param name="dateTo">Optional: Date upto which data is required</param>
    ''' <returns>Dataset Or Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetPayment(ByVal calledBy As String, Optional ByVal dateFrom As Date = Nothing, Optional ByVal dateTo As Date = Nothing) As DataSet
        Dim ds As DataSet = Nothing
        If dateFrom = Nothing Then dateFrom = DateDefault
        If dateTo = Nothing Then dateTo = Now

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.GetPayment(dateFrom, dateTo).Trim

                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function

#End Region

#Region "Stock And Sale "

    ''' <summary>
    ''' This will give Stock and Sale Dataset for given values
    ''' </summary>
    ''' <param name="calledBy">Used for Log purpose</param>
    ''' <param name="dateFrom">Optional: Date from which data is required</param>
    ''' <param name="dateTo">Optional: Date upto which data is required</param>
    ''' <returns>Dataset Or Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetStockAndSale(ByVal calledBy As String, Optional ByVal dateFrom As Date = Nothing, Optional ByVal dateTo As Date = Nothing, Optional ByVal flagII As Boolean = False) As DataSet
        Dim ds As DataSet = Nothing
        If dateFrom = Nothing Then dateFrom = DateDefault
        If dateTo = Nothing Then dateTo = Now

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ""
                If flagII = False Then
                    sql = ClsScriptsReport.GetInstance.GetStockAndSale(dateFrom, dateTo).Trim
                Else
                    sql = ClsScriptsReport.GetInstance.GetStockAndSaleII(dateFrom, dateTo).Trim
                End If

                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function

#End Region

#Region "Credit Note"

    ''' <summary>
    ''' This will give Credit Note Dataset
    ''' </summary>
    ''' <param name="calledBy">Used for Log purpose</param>
    ''' <param name="creditNoteId">Credit Note Id for which record is required</param>
    ''' <returns>Dataset Or Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetCreditNoteForReport(ByVal calledBy As String, ByVal creditNoteId As Long) As DataSet
        Dim ds As DataSet = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.GetCreditNote(creditNoteId).Trim
                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function

#End Region

#Region "Debit Note"

    ''' <summary>
    ''' This will give Debit Note Dataset
    ''' </summary>
    ''' <param name="calledBy">Used for Log purpose</param>
    ''' <param name="debitNoteId">Debit Note Id for which record is required</param>
    ''' <returns>Dataset Or Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetDebitNoteForReport(ByVal calledBy As String, ByVal debitNoteId As Long) As DataSet
        Dim ds As DataSet = Nothing

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.GetDebitNote(debitNoteId).Trim
                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function

#End Region

#Region "Sale Register"

    ''' <summary>
    ''' This will give Sale Register Dataset for given values
    ''' </summary>
    ''' <param name="calledBy">Used for Log purpose</param>
    ''' <param name="dateFrom">Optional: Date from which data is required</param>
    ''' <param name="dateTo">Optional: Date upto which data is required</param>
    ''' <returns>Dataset Or Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetSaleRegister(ByVal calledBy As String, Optional ByVal dateFrom As Date = Nothing, Optional ByVal dateTo As Date = Nothing) As DataSet
        Dim ds As DataSet = Nothing
        If dateFrom = Nothing Then dateFrom = DateDefault
        If dateTo = Nothing Then dateTo = Now

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.GetSaleRegister(dateFrom, dateTo).Trim

                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function

#End Region

#Region "Outstanding Report "

    ''' <summary>
    ''' This will give OutStanding Dataset for given values
    ''' </summary>
    ''' <param name="calledBy">Used for Log purpose</param>
    ''' <param name="dateFrom">Optional: Date from which data is required</param>
    ''' <param name="dateTo">Optional: Date upto which data is required</param>
    ''' <returns>Dataset Or Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetOutStanding(ByVal calledBy As String, Optional ByVal dateFrom As Date = Nothing, Optional ByVal dateTo As Date = Nothing) As DataSet
        Dim ds As DataSet = Nothing
        If dateFrom = Nothing Then dateFrom = DateDefault
        If dateTo = Nothing Then dateTo = Now

        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.GetOutStanding(dateFrom, dateTo).Trim

                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function

#End Region

#Region "Cash Receipt"

    ''' <summary>
    ''' This will give Cash Receipt Dataset for given values
    ''' </summary>
    ''' <param name="calledBy">Used for Log purpose</param>
    ''' <param name="id ">Id for which data is required</param>
    ''' <returns>Dataset Or Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetCashReceiptDataset(ByVal calledBy As String, ByVal id As Long) As DataSet
        Dim ds As DataSet = Nothing
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.GetCashReceipt(id).Trim

                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function

#End Region

#Region "Cheque Receipt"

    ''' <summary>
    ''' This will give Cheque Receipt Dataset for given values
    ''' </summary>
    ''' <param name="calledBy">Used for Log purpose</param>
    ''' <param name="id ">Id for which data is required</param>
    ''' <returns>Dataset Or Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetChequeReceiptDataset(ByVal calledBy As String, ByVal id As Long) As DataSet
        Dim ds As DataSet = Nothing
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.GetChequeReceipt(id).Trim

                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function

#End Region

#Region "Cash Payment"

    ''' <summary>
    ''' This will give Cash Payment Dataset for given values
    ''' </summary>
    ''' <param name="calledBy">Used for Log purpose</param>
    ''' <param name="id ">Id for which data is required</param>
    ''' <returns>Dataset Or Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetCashPaymentDataset(ByVal calledBy As String, ByVal id As Long) As DataSet
        Dim ds As DataSet = Nothing
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.GetCashPayment(id).Trim

                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function

#End Region

#Region "Cheque Payment"

    ''' <summary>
    ''' This will give Cheque Payment Dataset for given values
    ''' </summary>
    ''' <param name="calledBy">Used for Log purpose</param>
    ''' <param name="id ">Id for which data is required</param>
    ''' <returns>Dataset Or Nothing</returns>
    ''' <remarks></remarks>
    Public Function GetChequePaymentDataset(ByVal calledBy As String, ByVal id As Long) As DataSet
        Dim ds As DataSet = Nothing
        Try
            Dim temp As Integer
            For temp = 0 To 0
                Dim sql As String = ClsScriptsReport.GetInstance.GetChequePayment(id).Trim

                If sql = "" Then Exit For

                ds = ClsDBFunctions.GetInstance.ExecuteQuery_DataSet(sql, calledBy)
            Next

        Catch ex As Exception
            AddToLog(ex)
        End Try

        Return ds
    End Function

#End Region

End Module
