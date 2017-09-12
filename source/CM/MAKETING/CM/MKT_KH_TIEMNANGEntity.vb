Public Class MKT_KH_TIEMNANGEntity
    Implements IMKT_KH_TIEMNANGEntity

    Private _uId_KH_Tiemnang As String
    Private _uId_Khachhang As String
    Private _v_Makhachhang As String
    Private _nv_Hoten_vn As String
    Private _nv_Hoten_en As String
    Private _d_Ngaysinh As DateTime
    Private _d_NgaysinhB As String
    Private _b_Gioitinh As Boolean
    Private _nv_Diachi_vn As String
    Private _nv_Diachi_en As String
    Private _v_DienthoaiDD As String
    Private _v_Dienthoaikhac As String
    Private _v_Email As String
    Private _d_Ngaynhap As DateTime
    Private _d_NgaynhapB As String
    Private _Ghichu As String
    Private _uId_Cuahang As String
    Private _uId_Xaphuong As String
    Private _uId_Nghenghiep As String

    Public Property uId_KH_Tiemnang() As String Implements IMKT_KH_TIEMNANGEntity.uId_KH_Tiemnang
        Get
            Return _uId_KH_Tiemnang
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_KH_Tiemnang = String.Empty
            Else
                _uId_KH_Tiemnang = value.Trim
            End If
        End Set
    End Property

    Public Property uId_Khachhang() As String Implements IMKT_KH_TIEMNANGEntity.uId_Khachhang
        Get
            Return _uId_Khachhang
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Khachhang = String.Empty
            Else
                _uId_Khachhang = value.Trim
            End If
        End Set
    End Property

    Public Property v_Makhachhang() As String Implements IMKT_KH_TIEMNANGEntity.v_Makhachhang
        Get
            Return _v_Makhachhang
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _v_Makhachhang = String.Empty
            Else
                _v_Makhachhang = value.Trim
            End If
        End Set
    End Property

    Public Property nv_Hoten_vn() As String Implements IMKT_KH_TIEMNANGEntity.nv_Hoten_vn
        Get
            Return _nv_Hoten_vn
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_Hoten_vn = String.Empty
            Else
                _nv_Hoten_vn = value.Trim
            End If
        End Set
    End Property

    Public Property nv_Hoten_en() As String Implements IMKT_KH_TIEMNANGEntity.nv_Hoten_en
        Get
            Return _nv_Hoten_en
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_Hoten_en = String.Empty
            Else
                _nv_Hoten_en = value.Trim
            End If
        End Set
    End Property

    Public Property d_Ngaysinh() As DateTime Implements IMKT_KH_TIEMNANGEntity.d_Ngaysinh
        Get
            Return Date.Parse(_d_Ngaysinh).ToShortDateString
        End Get
        Set(ByVal value As DateTime)
            _d_Ngaysinh = value
        End Set
    End Property

    Public Property d_NgaysinhB() As String
        Get
            If (_d_Ngaysinh = Nothing) Then
                Return String.Empty
            Else
                Return CStr(Format(_d_Ngaysinh, "dd/MM/yyyy"))
            End If
        End Get
        Set(ByVal value As String)
            _d_Ngaysinh = value
        End Set
    End Property

    Public Property b_Gioitinh() As Boolean Implements IMKT_KH_TIEMNANGEntity.b_Gioitinh
        Get
            Return _b_Gioitinh
        End Get
        Set(ByVal value As Boolean)
            _b_Gioitinh = value
        End Set
    End Property

    Public Property nv_Diachi_vn() As String Implements IMKT_KH_TIEMNANGEntity.nv_Diachi_vn
        Get
            Return _nv_Diachi_vn
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_Diachi_vn = String.Empty
            Else
                _nv_Diachi_vn = value.Trim
            End If
        End Set
    End Property

    Public Property nv_Diachi_en() As String Implements IMKT_KH_TIEMNANGEntity.nv_Diachi_en
        Get
            Return _nv_Diachi_en
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_Diachi_en = String.Empty
            Else
                _nv_Diachi_en = value.Trim
            End If
        End Set
    End Property

    Public Property v_DienthoaiDD() As String Implements IMKT_KH_TIEMNANGEntity.v_DienthoaiDD
        Get
            Return _v_DienthoaiDD
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _v_DienthoaiDD = String.Empty
            Else
                _v_DienthoaiDD = value.Trim
            End If
        End Set
    End Property

    Public Property v_Dienthoaikhac() As String Implements IMKT_KH_TIEMNANGEntity.v_Dienthoaikhac
        Get
            Return _v_Dienthoaikhac
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _v_Dienthoaikhac = String.Empty
            Else
                _v_Dienthoaikhac = value.Trim
            End If
        End Set
    End Property

    Public Property v_Email() As String Implements IMKT_KH_TIEMNANGEntity.v_Email
        Get
            Return _v_Email
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _v_Email = String.Empty
            Else
                _v_Email = value.Trim
            End If
        End Set
    End Property

    Public Property d_Ngaynhap() As DateTime Implements IMKT_KH_TIEMNANGEntity.d_Ngaynhap
        Get
            Return Date.Parse(_d_Ngaynhap).ToShortDateString
        End Get
        Set(ByVal value As DateTime)
            _d_Ngaynhap = value
        End Set
    End Property

    Public Property d_NgaynhapB() As String
        Get
            If (_d_Ngaynhap = Nothing) Then
                Return String.Empty
            Else
                Return CStr(Format(_d_Ngaynhap, "dd/MM/yyyy"))
            End If
        End Get
        Set(ByVal value As String)
            _d_Ngaynhap = value
        End Set
    End Property

    Public Property Ghichu() As String Implements IMKT_KH_TIEMNANGEntity.Ghichu
        Get
            Return _Ghichu
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _Ghichu = String.Empty
            Else
                _Ghichu = value.Trim
            End If
        End Set
    End Property

    Public Property uId_Cuahang() As String Implements IMKT_KH_TIEMNANGEntity.uId_Cuahang
        Get
            Return _uId_Cuahang
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Cuahang = String.Empty
            Else
                _uId_Cuahang = value.Trim
            End If
        End Set
    End Property

    Public Property uId_Xaphuong() As String Implements IMKT_KH_TIEMNANGEntity.uId_Xaphuong
        Get
            Return _uId_Xaphuong
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Xaphuong = String.Empty
            Else
                _uId_Xaphuong = value.Trim
            End If
        End Set
    End Property
    Public Property uId_Nghenghiep() As String Implements IMKT_KH_TIEMNANGEntity.uId_Nghenghiep
        Get
            Return _uId_Nghenghiep
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Nghenghiep = String.Empty
            Else
                _uId_Nghenghiep = value.Trim
            End If
        End Set
    End Property
End Class
