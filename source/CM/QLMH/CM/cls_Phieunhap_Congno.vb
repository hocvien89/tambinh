Public Class cls_Phieunhap_Congno
    Implements iCls_Phieunhap_Congno
    Private _uId_Phieunhap As String
    Private _f_Tienno As Double
    Private _uId_Thuchi As String
    Public Property f_Tienno() As Double Implements iCls_Phieunhap_Congno.f_Tienno
        Get
            Return _f_Tienno
        End Get
        Set(value As Double)
            _f_Tienno = value
        End Set
    End Property

    Public Property uId_Phieunhap() As String Implements iCls_Phieunhap_Congno.uId_Phieunhap
        Get
            Return _uId_Phieunhap
        End Get
        Set(value As String)
            _uId_Phieunhap = value
        End Set
    End Property

    Public Property uId_Thuchi() As String Implements iCls_Phieunhap_Congno.uId_Thuchi
        Get
            Return _uId_Thuchi
        End Get
        Set(value As String)
            _uId_Thuchi = value
        End Set
    End Property
End Class
