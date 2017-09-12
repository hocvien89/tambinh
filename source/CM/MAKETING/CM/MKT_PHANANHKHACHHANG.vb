Public Class CM_CRM_PHANANHKHACHHANG
    Implements IMKT_PHANANHKHACHHANG
    Private _CreatedOn As Date
    Public Property CreatedOn() As Date Implements IMKT_PHANANHKHACHHANG.CreatedOn
        Get
            Return _CreatedOn
        End Get
        Set(ByVal value As Date)
            _CreatedOn = value
        End Set
    End Property
    Private _HuongXuLy As String
    Public Property HuongXuLy() As String Implements IMKT_PHANANHKHACHHANG.HuongXuLy
        Get
            Return _HuongXuLy
        End Get
        Set(ByVal value As String)
            _HuongXuLy = value
        End Set
    End Property
    Private _NoiDung As String
    Public Property NoiDung() As String Implements IMKT_PHANANHKHACHHANG.NoiDung
        Get
            Return _NoiDung
        End Get
        Set(ByVal value As String)
            _NoiDung = value
        End Set
    End Property
    Private _Status_phananh As String
    Public Property Status_phananh() As String Implements IMKT_PHANANHKHACHHANG.Status_phananh
        Get
            Return _Status_phananh
        End Get
        Set(ByVal value As String)
            _Status_phananh = value
        End Set
    End Property
    Private _Status_sauxuly As String
    Public Property Status_sauxuly() As String Implements IMKT_PHANANHKHACHHANG.Status_sauxuly
        Get
            Return _Status_sauxuly
        End Get
        Set(ByVal value As String)
            _Status_sauxuly = value
        End Set
    End Property
    Private _uId_Khachhang As String
    Public Property uId_Khachhang() As String Implements IMKT_PHANANHKHACHHANG.uId_Khachhang
        Get
            Return _uId_Khachhang
        End Get
        Set(ByVal value As String)
            _uId_Khachhang = value
        End Set
    End Property
    Private _uId_Phananh As String
    Public Property uId_Phananh() As String Implements IMKT_PHANANHKHACHHANG.uId_Phananh
        Get
            Return _uId_Phananh
        End Get
        Set(ByVal value As String)
            _uId_Phananh = value
        End Set
    End Property
    Private _uId_Phong As String
    Public Property uId_Phong() As String Implements IMKT_PHANANHKHACHHANG.uId_Phong
        Get
            Return _uId_Phong
        End Get
        Set(ByVal value As String)
            _uId_Phong = value
        End Set
    End Property
    Private _nv_Hoten_vn As String
    Public Property nv_Hoten_vn() As String Implements IMKT_PHANANHKHACHHANG.nv_Hoten_vn
        Get
            Return _nv_Hoten_vn
        End Get
        Set(ByVal value As String)
            _nv_Hoten_vn = value
        End Set
    End Property
    Private _nv_Tenphong_vn As String
    Public Property nv_Tenphong_vn() As String Implements IMKT_PHANANHKHACHHANG.nv_Tenphong_vn
        Get
            Return _nv_Tenphong_vn
        End Get
        Set(ByVal value As String)
            _nv_Tenphong_vn = value
        End Set
    End Property
End Class
