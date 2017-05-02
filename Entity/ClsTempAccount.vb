Public Class ClsTempAccount
    Inherits ClsIdName

    'This class is different from Table strucutre
    Private sDrAmount As Double = 0
    Private sCrAmount As Double = 0

    Public Property DrAmount() As Double
        Get
            Return sDrAmount
        End Get
        Set(ByVal value As Double)
            sDrAmount = value
        End Set
    End Property

    Public Property CrAmount() As Double
        Get
            Return sCrAmount
        End Get
        Set(ByVal value As Double)
            sCrAmount = value
        End Set
    End Property

    Public ReadOnly Property Total() As Double
        Get
            Return sDrAmount - sCrAmount
        End Get
    End Property

End Class
