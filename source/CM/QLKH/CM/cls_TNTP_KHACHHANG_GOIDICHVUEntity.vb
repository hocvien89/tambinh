Public Class TNTP_KHACHHANG_GOIDICHVUEntity 
    Implements ITNTP_KHACHHANG_GOIDICHVUEntity

    Private _uId_Khachhang_Goidichvu As String
    Private _uId_Khachhang As String
    Private _uId_Goidichvu As String
    Private _uId_Cuahang As String
    Private _d_Ngaymua As DateTime
    Private _d_NgaymuaB As String
    Private _f_Sotien As Double
    Private _i_TongSolanthuchien As Int32
    Private _d_NgayBD As DateTime
    Private _d_NgayBDB As String
    Private _d_NgayKT As DateTime
    Private _d_NgayKTB As String
    Private _b_Tatca_Dichvu As Boolean
    Private _uId_Trangthai As String
    Private _nv_Hoten_vn As String
    Private _nv_Tentrangthai_vn As String
    Private _nv_Tengoi_vn As String
    Private _f_Giatrigoi As Double
    Private _vMaBarcode As String
    Private _uId_Khachhang_Kichhoat As String
    Private _b_Kichhoat As Boolean
    Private _uId_Phieudichvu As String


    Public Property uId_Khachhang_Goidichvu() As String Implements ITNTP_KHACHHANG_GOIDICHVUEntity.uId_Khachhang_Goidichvu
        Get
            Return _uId_Khachhang_Goidichvu
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Khachhang_Goidichvu = String.Empty
            Else
                _uId_Khachhang_Goidichvu = value.Trim
            End If
        End Set
    End Property

    Public Property uId_Khachhang() As String Implements ITNTP_KHACHHANG_GOIDICHVUEntity.uId_Khachhang
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

    Public Property uId_Goidichvu() As String Implements ITNTP_KHACHHANG_GOIDICHVUEntity.uId_Goidichvu
        Get
            Return _uId_Goidichvu
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Goidichvu = String.Empty
            Else
                _uId_Goidichvu = value.Trim
            End If
        End Set
    End Property

    Public Property uId_Cuahang() As String Implements ITNTP_KHACHHANG_GOIDICHVUEntity.uId_Cuahang
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

    Public Property d_Ngaymua() As DateTime Implements ITNTP_KHACHHANG_GOIDICHVUEntity.d_Ngaymua
        Get
            Return Date.Parse(_d_Ngaymua).ToShortDateString
        End Get
        Set(ByVal value As DateTime)
            _d_Ngaymua = value
        End Set
    End Property

    Public Property d_NgaymuaB() As String
        Get
            If (_d_Ngaymua = Nothing) Then
                Return String.Empty
            Else
                Return CStr(Format(_d_Ngaymua, "dd/MM/yyyy"))
            End If
        End Get
        Set(ByVal value As String)
            _d_Ngaymua = value
        End Set
    End Property

    Public Property f_Sotien() As Double Implements ITNTP_KHACHHANG_GOIDICHVUEntity.f_Sotien
        Get
            Return _f_Sotien
        End Get
        Set(ByVal value As Double)
            _f_Sotien = value
        End Set
    End Property

    Public Property f_Giatrigoi() As Double Implements ITNTP_KHACHHANG_GOIDICHVUEntity.f_Giatrigoi
        Get
            Return _f_Giatrigoi
        End Get
        Set(ByVal value As Double)
            _f_Giatrigoi = value
        End Set
    End Property

    Public Property i_TongSolanthuchien() As Int32 Implements ITNTP_KHACHHANG_GOIDICHVUEntity.i_TongSolanthuchien
        Get
            Return _i_TongSolanthuchien
        End Get
        Set(ByVal value As Int32)
            _i_TongSolanthuchien = value
        End Set
    End Property

    Public Property d_NgayBD() As DateTime Implements ITNTP_KHACHHANG_GOIDICHVUEntity.d_NgayBD
        Get
            Return Date.Parse(_d_NgayBD).ToShortDateString
        End Get
        Set(ByVal value As DateTime)
            _d_NgayBD = value
        End Set
    End Property

    Public Property d_NgayBDB() As String
        Get
            If (_d_NgayBD = Nothing) Then
                Return String.Empty
            Else
                Return CStr(Format(_d_NgayBD, "dd/MM/yyyy"))
            End If
        End Get
        Set(ByVal value As String)
            _d_NgayBD = value
        End Set
    End Property

    Public Property d_NgayKT() As DateTime Implements ITNTP_KHACHHANG_GOIDICHVUEntity.d_NgayKT
        Get
            Return Date.Parse(_d_NgayKT).ToShortDateString
        End Get
        Set(ByVal value As DateTime)
            _d_NgayKT = value
        End Set
    End Property

    Public Property d_NgayKTB() As String
        Get
            If (_d_NgayKT = Nothing) Then
                Return String.Empty
            Else
                Return CStr(Format(_d_NgayKT, "dd/MM/yyyy"))
            End If
        End Get
        Set(ByVal value As String)
            _d_NgayKT = value
        End Set
    End Property

    Public Property b_Tatca_Dichvu() As Boolean Implements ITNTP_KHACHHANG_GOIDICHVUEntity.b_Tatca_Dichvu
        Get
            Return _b_Tatca_Dichvu
        End Get
        Set(ByVal value As Boolean)
            _b_Tatca_Dichvu = value
        End Set
    End Property

    Public Property uId_Trangthai() As String Implements ITNTP_KHACHHANG_GOIDICHVUEntity.uId_Trangthai
        Get
            Return _uId_Trangthai
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Trangthai = String.Empty
            Else
                _uId_Trangthai = value.Trim
            End If
        End Set
    End Property

    Public Property nv_Hoten_vn() As String
        Get
            Return _nv_Hoten_vn
        End Get
        Set(ByVal value As String)
            _nv_Hoten_vn = value
        End Set
    End Property

    Public Property nv_Tentrangthai_vn() As String
        Get
            Return _nv_Tentrangthai_vn
        End Get
        Set(ByVal value As String)
            _nv_Tentrangthai_vn = value
        End Set
    End Property

    Public Property nv_Tengoi_vn() As String
        Get
            Return _nv_Tengoi_vn
        End Get
        Set(ByVal value As String)
            _nv_Tengoi_vn = value
        End Set
    End Property

    Public Property vMaBarcode() As String Implements ITNTP_KHACHHANG_GOIDICHVUEntity.vMaBarcode
        Get
            Return _vMaBarcode
        End Get
        Set(ByVal value As String)
            _vMaBarcode = value
        End Set
    End Property

    Public Property uId_Khachhang_Kichhoat() As String Implements ITNTP_KHACHHANG_GOIDICHVUEntity.uId_Khachhang_Kichhoat
        Get
            Return _uId_Khachhang_Kichhoat
        End Get
        Set(ByVal value As String)
            _uId_Khachhang_Kichhoat = value
        End Set
    End Property
    Public Property uId_Phieudichvu() As String Implements ITNTP_KHACHHANG_GOIDICHVUEntity.uId_Phieudichvu
        Get
            Return _uId_Phieudichvu
        End Get
        Set(ByVal value As String)
            _uId_Phieudichvu = value
        End Set
    End Property
    Public Property b_Kichhoat() As Boolean Implements ITNTP_KHACHHANG_GOIDICHVUEntity.b_Kichhoat
        Get
            Return _b_Kichhoat
        End Get
        Set(ByVal value As Boolean)
            _b_Kichhoat = value
        End Set
    End Property
End Class
