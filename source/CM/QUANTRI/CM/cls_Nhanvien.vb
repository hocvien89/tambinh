
Public Class cls_Nhanvien
    Implements iCls_Nhanvien

    Private _uId_Nhanvien As String = ""
    Private _uId_Cuahang As String = ""
    Private _v_Barcode As String = ""
    Private _v_Manhanvien As String = ""
    Private _nv_Hoten_vn As String = ""
    Private _nv_Hoten_en As String = ""
    Private _d_Ngaysinh As String = "01/01/1900"
    Private _nv_Chucvu_vn As String = ""
    Private _nv_Chucvu_en As String = ""
    Private _nv_Diachi_vn As String = ""
    Private _nv_Diachi_en As String = ""
    Private _nv_Quequan_vn As String = ""
    Private _nv_Quequan_en As String = ""
    Private _v_Dienthoai As String = ""
    Private _v_Email As String = ""
    Private _v_Tendangnhap As String = ""
    Private _v_Matkhau As String = ""
    Private _b_ActiveLogin As String = ""
    Private _d_Ngayvaolam As String = "01/01/1900"
    Private _b_Danglamviec As String = ""

    Public Property uId_Nhanvien() As String Implements iCls_Nhanvien.uId_Nhanvien
        Get
            Return _uId_Nhanvien
        End Get
        Set(ByVal value As String)
            _uId_Nhanvien = value
        End Set
    End Property

    Public Property uId_Cuahang() As String Implements iCls_Nhanvien.uId_Cuahang
        Get
            Return _uId_Cuahang
        End Get
        Set(ByVal value As String)
            _uId_Cuahang = value
        End Set
    End Property

    Public Property v_Barcode() As String Implements iCls_Nhanvien.v_Barcode
        Get
            Return _v_Barcode
        End Get
        Set(ByVal value As String)
            _v_Barcode = value
        End Set
    End Property

    Public Property v_Manhanvien() As String Implements iCls_Nhanvien.v_Manhanvien
        Get
            Return _v_Manhanvien
        End Get
        Set(ByVal value As String)
            _v_Manhanvien = value
        End Set
    End Property

    Public Property nv_Hoten_vn() As String Implements iCls_Nhanvien.nv_Hoten_vn
        Get
            Return _nv_Hoten_vn
        End Get
        Set(ByVal value As String)
            _nv_Hoten_vn = value
        End Set
    End Property

    Public Property nv_Hoten_en() As String Implements iCls_Nhanvien.nv_Hoten_en
        Get
            Return _nv_Hoten_en
        End Get
        Set(ByVal value As String)
            _nv_Hoten_en = value
        End Set
    End Property

    Public Property d_Ngaysinh() As String Implements iCls_Nhanvien.d_Ngaysinh
        Get
            Return _d_Ngaysinh
        End Get
        Set(ByVal value As String)
            _d_Ngaysinh = IIf(value <> "", value, _d_Ngaysinh)
        End Set
    End Property

    Public Property nv_Chucvu_vn() As String Implements iCls_Nhanvien.nv_Chucvu_vn
        Get
            Return _nv_Chucvu_vn
        End Get
        Set(ByVal value As String)
            _nv_Chucvu_vn = value
        End Set
    End Property

    Public Property nv_Chucvu_en() As String Implements iCls_Nhanvien.nv_Chucvu_en
        Get
            Return _nv_Chucvu_en
        End Get
        Set(ByVal value As String)
            _nv_Chucvu_en = value
        End Set
    End Property

    Public Property nv_Diachi_vn() As String Implements iCls_Nhanvien.nv_Diachi_vn
        Get
            Return _nv_Diachi_vn
        End Get
        Set(ByVal value As String)
            _nv_Diachi_vn = value
        End Set
    End Property

    Public Property nv_Diachi_en() As String Implements iCls_Nhanvien.nv_Diachi_en
        Get
            Return _nv_Diachi_en
        End Get
        Set(ByVal value As String)
            _nv_Diachi_en = value
        End Set
    End Property

    Public Property nv_Quequan_vn() As String Implements iCls_Nhanvien.nv_Quequan_vn
        Get
            Return _nv_Quequan_vn
        End Get
        Set(ByVal value As String)
            _nv_Quequan_vn = value
        End Set
    End Property

    Public Property nv_Quequan_en() As String Implements iCls_Nhanvien.nv_Quequan_en
        Get
            Return _nv_Quequan_en
        End Get
        Set(ByVal value As String)
            _nv_Quequan_en = value
        End Set
    End Property

    Public Property v_Dienthoai() As String Implements iCls_Nhanvien.v_Dienthoai
        Get
            Return _v_Dienthoai
        End Get
        Set(ByVal value As String)
            _v_Dienthoai = value
        End Set
    End Property

    Public Property v_Email() As String Implements iCls_Nhanvien.v_Email
        Get
            Return _v_Email
        End Get
        Set(ByVal value As String)
            _v_Email = value
        End Set
    End Property

    Public Property v_Tendangnhap() As String Implements iCls_Nhanvien.v_Tendangnhap
        Get
            Return _v_Tendangnhap
        End Get
        Set(ByVal value As String)
            _v_Tendangnhap = value
        End Set
    End Property

    Public Property v_Matkhau() As String Implements iCls_Nhanvien.v_Matkhau
        Get
            Return _v_Matkhau
        End Get
        Set(ByVal value As String)
            _v_Matkhau = value
        End Set
    End Property

    Public Property b_ActiveLogin() As String Implements iCls_Nhanvien.b_ActiveLogin
        Get
            Return _b_ActiveLogin
        End Get
        Set(ByVal value As String)
            _b_ActiveLogin = value
        End Set
    End Property

    Public Property d_Ngayvaolam() As String Implements iCls_Nhanvien.d_Ngayvaolam
        Get
            Return _d_Ngayvaolam
        End Get
        Set(ByVal value As String)
            _d_Ngayvaolam = IIf(value <> "", value, _d_Ngayvaolam)
        End Set
    End Property

    Public Property b_Danglamviec() As String Implements iCls_Nhanvien.b_Danglamviec
        Get
            Return _b_Danglamviec
        End Get
        Set(ByVal value As String)
            _b_Danglamviec = value
        End Set
    End Property

End Class
