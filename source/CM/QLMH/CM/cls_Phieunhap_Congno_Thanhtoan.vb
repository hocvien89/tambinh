Public Class cls_Phieunhap_Congno_Thanhtoan
    Implements iCls_Phieunhap_Congno_Thanhtoan

    Private _uId_Phieunhap_Congno As String
    Private _uId_Phieunhap_Congno_Thanhtoan As String
    Private _uId_Phieuthuchi As String

    Public Property uId_Phieunhap_Congno() As String Implements iCls_Phieunhap_Congno_Thanhtoan.uId_Phieunhap_Congno
        Get
            Return _uId_Phieunhap_Congno
        End Get
        Set(value As String)
            _uId_Phieunhap_Congno = value
        End Set
    End Property

    Public Property uId_Phhieuthuchi() As String Implements iCls_Phieunhap_Congno_Thanhtoan.uId_Phhieuthuchi
        Get
            Return _uId_Phieuthuchi
        End Get
        Set(value As String)
            _uId_Phieuthuchi = value
        End Set
    End Property
    Public Property uId_Phieunhap_Congno_Thanhtoan() As String Implements iCls_Phieunhap_Congno_Thanhtoan.uId_Phieunhap_Congno_Thanhtoan
        Get
            Return _uId_Phieunhap_Congno_Thanhtoan
        End Get
        Set(value As String)
            _uId_Phieunhap_Congno_Thanhtoan = value
        End Set
    End Property
End Class
