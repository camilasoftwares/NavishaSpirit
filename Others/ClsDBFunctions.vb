Imports System.IO
Imports System.Data.SqlClient

Public Class ClsDBFunctions

#Const LogQuery = 0

#Region "Local variables and Constants"

    Shared sInstance As ClsDBFunctions
    Dim connStr As String = ""
    Dim lLastConnectionKey As String = ""

#End Region

#Region "Public Functions"

    ''' <summary>
    ''' This function is used to get Instance of this class
    ''' </summary>
    ''' <returns>Instance of this class</returns>
    ''' <remarks></remarks>
    Public Shared Function GetInstance() As ClsDBFunctions
        If sInstance Is Nothing Then
            sInstance = New ClsDBFunctions
        End If

        Return sInstance
    End Function

    Public Property ConnectionStringValue() As String
        Get
            Return connStr
        End Get
        Set(ByVal value As String)
            connStr = value
        End Set
    End Property

    Public Function ExecuteQuery_DataSet(ByVal sql As String, ByVal calledBy As String, Optional ByVal connectionStringKey As String = cConnectionStringKey) As DataSet
#If LogQuery = 1 Then
LogQueryDetail(sql , calledBy)
#End If

        Return ExecuteQueryDataSet(sql, connectionStringKey)
    End Function

    Public Function ExecuteQuery_NonQuery(ByVal sql As String, ByVal calledBy As String, Optional ByVal connectionStringKey As String = cConnectionStringKey) As Integer
#If LogQuery = 1 Then
LogQueryDetail(sql , calledBy)
#End If

        Return ExecuteNonQuery(sql, connectionStringKey)
    End Function

    Public Function ExecuteQuery_Scalar(ByVal sql As String, ByVal calledBy As String, Optional ByVal connectionStringKey As String = cConnectionStringKey) As Object
#If LogQuery = 1 Then
        LogQueryDetail(sql, calledBy)
#End If

        Return ExecuteScalar(sql, connectionStringKey)
    End Function

#End Region

#Region "Private Functions"

    Private Sub LogQueryDetail(ByVal sql As String, ByVal calledBy As String)
        Try
            'check the file
            Dim fs As FileStream = New FileStream(Application.StartupPath & "\queryLog.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite)
            Dim s As StreamWriter = New StreamWriter(fs)
            s.Close()
            fs.Close()

            'log it
            Dim fs1 As FileStream = New FileStream(Application.StartupPath & "\queryLog.txt", FileMode.Append, FileAccess.Write)
            Dim s1 As StreamWriter = New StreamWriter(fs1)

            Dim msg As String
            msg = "Date/Time: " + DateTime.Now.ToString
            msg = msg + " : " + calledBy
            msg = msg + vbCrLf + "QRY: " + sql
            msg = msg + vbCrLf
            s1.Write("================================================" & vbCrLf)
            s1.Write(msg)

            s1.Close()
            fs1.Close()

        Catch newEx As Exception
            MsgBox(newEx.Message)
        End Try
    End Sub

    Private Function GetConnectionString(ByVal connectionName As String) As String
        If lLastConnectionKey <> connectionName Then    'This will retrieve new connection string
            lLastConnectionKey = connectionName
            connStr = ""
        End If

        If connStr Is Nothing Or connStr.Trim = "" Then
            connStr = Configuration.ConfigurationManager.ConnectionStrings(connectionName).ConnectionString
            If connStr.Trim <> "" Then
                Dim b() As Byte = Convert.FromBase64String(connStr)
                connStr = System.Text.ASCIIEncoding.ASCII.GetString(b)
            End If
        End If

        Return connStr
    End Function

    Private Function GetSQLConnection(ByVal connectionName As String) As SqlConnection
        Dim conn As SqlConnection = Nothing
        conn = New SqlConnection(GetConnectionString(connectionName))

        Return conn
    End Function

    Private Function ExecuteNonQuery(ByVal sql As String, ByVal connectionName As String) As Integer
        Dim retVal As Integer = 0
        Dim cmd As New SqlCommand(sql, GetSQLConnection(connectionName))
        cmd.Connection.Open()
        retVal = cmd.ExecuteNonQuery()
        cmd.Connection.Close()

        Return retVal
    End Function

    Private Function ExecuteScalar(ByVal sql As String, ByVal connectionName As String) As Object
        Dim retVal As Object = 0
        Dim cmd As New SqlCommand(sql, GetSQLConnection(connectionName))
        cmd.Connection.Open()
        retVal = cmd.ExecuteScalar()
        cmd.Connection.Close()

        Return retVal
    End Function

    Private Function ExecuteQueryDataSet(ByVal sql As String, ByVal connectionName As String) As DataSet
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter()
        adapter.SelectCommand = New SqlCommand(sql, GetSQLConnection(connectionName))
        adapter.Fill(dataSet)

        Return dataSet
    End Function

#End Region

#Region "Check Connection"

    Public Function CheckConnection() As Boolean
        Dim result As Boolean = False
        Try
            Dim sql As String = "Select * from temp"
            Dim obj As Object = ExecuteQuery_Scalar(sql, Me.ToString)
            If obj IsNot Nothing Then result = True

        Catch ex As Exception
        End Try

        Return result
    End Function

#End Region

#Region "Remove Codes not exist in Connection Settings"

    Public Sub CheckAndSortConnectionStringKeys(ByRef connectionNameList As List(Of String))
        Dim tempConnectionNameList As New List(Of String)
        tempConnectionNameList.AddRange(connectionNameList.ToArray())

        For Each connectionName As String In tempConnectionNameList
            Dim str As String = ""
            Try
                str = Configuration.ConfigurationManager.ConnectionStrings(connectionName).ConnectionString

            Catch ex As Exception
            End Try

            If str.Trim <> "" Then
                Dim b() As Byte = Convert.FromBase64String(str)
                str = System.Text.ASCIIEncoding.ASCII.GetString(b)
            End If

            If str Is Nothing Or str.Trim = "" Then connectionNameList.Remove(connectionName)
        Next
    End Sub

#End Region

End Class
