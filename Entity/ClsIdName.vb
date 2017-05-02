Public Class ClsIdName

    Private sId As Integer = cInvalidId
    Private sName As String = ""

    Public Property Id() As Integer
        Get
            Return sId
        End Get
        Set(ByVal value As Integer)
            sId = value
        End Set
    End Property

    Public Property Name() As String
        Get
            Return sName
        End Get
        Set(ByVal value As String)
            sName = value.Trim
        End Set
    End Property

    Public Shadows Sub CopyDataToObject(ByRef idNameObj As ClsIdName)
        If Not (TypeOf idNameObj Is ClsIdName) Then Exit Sub

        With idNameObj
            .Id = sId
            .Name = sName
        End With
    End Sub

    Public Sub New()
    End Sub

    Public Sub New(ByVal iName As String, ByVal iId As Integer)
        sName = iName.Trim
        sId = iId
    End Sub

End Class
