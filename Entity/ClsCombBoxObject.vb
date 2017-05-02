
'********* This class is used as combo box object. To remove any link between application controls and database 

Public Class ClsCombBoxObject
    Inherits ClsIdName

    Public Sub New(ByVal inText As String, ByVal inId As Integer)
        Name = inText
        Id = inId
    End Sub

    Public Property Text() As String
        Get
            Return Name
        End Get
        Set(ByVal value As String)
            Name = value
        End Set
    End Property

End Class
