Public Class CRM_LICHHENEntity 
    Implements ICRM_LICHHENEntity
    Private _uId_Lichhen As String
    Private _v_Tugio As String
    Private _v_Dengio As String
    Private _d_Ngay As DateTime
    Private _d_NgayB As String
    Private _uId_Khachhang As String
    Private _uId_Nhanvien As String
    Private _nv_Ghichu_vn As String
    Private _nv_Ghichu_en As String
    Private _uId_Trangthai As String
    Private _nv_HotenKhachhang_vn As String
    Private _nv_HotenNhanvien_vn As String
    Private _nv_Tentrangthai_vn As String

    Public Property uId_Lichhen() As String Implements ICRM_LICHHENEntity.uId_Lichhen
        Get
            Return _uId_Lichhen
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Lichhen = String.Empty
            Else
                _uId_Lichhen = value.Trim
            End If
        End Set
    End Property

    Public Property v_Tugio() As String Implements ICRM_LICHHENEntity.v_Tugio
        Get
            Return _v_Tugio
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _v_Tugio = String.Empty
            Else
                _v_Tugio = value.Trim
            End If
        End Set
    End Property

    Public Property v_Dengio() As String Implements ICRM_LICHHENEntity.v_Dengio
        Get
            Return _v_Dengio
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _v_Dengio = String.Empty
            Else
                _v_Dengio = value.Trim
            End If
        End Set
    End Property

    Public Property d_Ngay() As DateTime Implements ICRM_LICHHENEntity.d_Ngay
        Get
            Return Date.Parse(_d_Ngay).ToShortDateString
        End Get
        Set(ByVal value As DateTime)
            _d_Ngay = value
        End Set
    End Property

    Public Property d_NgayB() As String
        Get
            If (_d_Ngay = Nothing) Then
                Return String.Empty
            Else
                Return CStr(Format(_d_Ngay, "dd/MM/yyyy"))
            End If
        End Get
        Set(ByVal value As String)
            _d_Ngay = value
        End Set
    End Property

    Public Property uId_Khachhang() As String Implements ICRM_LICHHENEntity.uId_Khachhang
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

    Public Property uId_Nhanvien() As String Implements ICRM_LICHHENEntity.uId_Nhanvien
        Get
            Return _uId_Nhanvien
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Nhanvien = String.Empty
            Else
                _uId_Nhanvien = value.Trim
            End If
        End Set
    End Property

    Public Property nv_Ghichu_vn() As String Implements ICRM_LICHHENEntity.nv_Ghichu_vn
        Get
            Return _nv_Ghichu_vn
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_Ghichu_vn = String.Empty
            Else
                _nv_Ghichu_vn = value.Trim
            End If
        End Set
    End Property

    Public Property nv_Ghichu_en() As String Implements ICRM_LICHHENEntity.nv_Ghichu_en
        Get
            Return _nv_Ghichu_en
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_Ghichu_en = String.Empty
            Else
                _nv_Ghichu_en = value.Trim
            End If
        End Set
    End Property

    Public Property uId_Trangthai() As String Implements ICRM_LICHHENEntity.uId_Trangthai
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

    Public Property nv_HotenKhachhang_vn() As String
        Get
            Return _nv_HotenKhachhang_vn
        End Get
        Set(ByVal value As String)
            _nv_HotenKhachhang_vn = value
        End Set
    End Property

    Public Property nv_HotenNhanvien_vn() As String
        Get
            Return _nv_HotenNhanvien_vn
        End Get
        Set(ByVal value As String)
            _nv_HotenNhanvien_vn = value
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
    Private _uId_NVTuvanhen As String
    Public Property uId_NVTuvanhen() As String Implements ICRM_LICHHENEntity.uId_NVTuvanhen
        Get
            Return _uId_NVTuvanhen
        End Get
        Set(ByVal value As String)
            _uId_NVTuvanhen = value
        End Set
    End Property
End Class
