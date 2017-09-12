Public Class QLTC_PhieuthuchiEntity
    Implements iQLTC_PhieuthuchiEntity

    Private _uId_Phieuthuchi As String
    Private _uId_Cuahang As String
    Private _uId_Nhanvien As String
    Private _uId_Thuchi As String
    Private _v_Maphieu As String
    Private _d_Ngay As DateTime
    Private _d_NgayB As String
    Private _f_Sotien As Double
    Private _nv_Lydo_vn As String
    Private _nv_Lydo_en As String
    Private _v_NguonThanhtoan As String
    Private _nv_Ghichu As String
    Private _uId_LoaiTT As String
    Private _b_IsKhoa As Boolean

    Public Property uId_Phieuthuchi() As String Implements iQLTC_PhieuthuchiEntity.uId_Phieuthuchi
        Get
            Return _uId_Phieuthuchi
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Phieuthuchi = String.Empty
            Else
                _uId_Phieuthuchi = value.Trim
            End If
        End Set
    End Property

    Public Property uId_Cuahang() As String Implements iQLTC_PhieuthuchiEntity.uId_Cuahang
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

    Public Property uId_Nhanvien() As String Implements iQLTC_PhieuthuchiEntity.uId_Nhanvien
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

    Public Property uId_Thuchi() As String Implements iQLTC_PhieuthuchiEntity.uId_Thuchi
        Get
            Return _uId_Thuchi
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Thuchi = String.Empty
            Else
                _uId_Thuchi = value.Trim
            End If
        End Set
    End Property

    Public Property v_Maphieu() As String Implements iQLTC_PhieuthuchiEntity.v_Maphieu
        Get
            Return _v_Maphieu
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _v_Maphieu = String.Empty
            Else
                _v_Maphieu = value.Trim
            End If
        End Set
    End Property

    Public Property d_Ngay() As DateTime Implements iQLTC_PhieuthuchiEntity.d_Ngay
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

    Public Property f_Sotien() As Double Implements iQLTC_PhieuthuchiEntity.f_Sotien
        Get
            Return _f_Sotien
        End Get
        Set(ByVal value As Double)
            _f_Sotien = value
        End Set
    End Property

    Public Property nv_Lydo_vn() As String Implements iQLTC_PhieuthuchiEntity.nv_Lydo_vn
        Get
            Return _nv_Lydo_vn
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_Lydo_vn = String.Empty
            Else
                _nv_Lydo_vn = value.Trim
            End If
        End Set
    End Property

    Public Property nv_Lydo_en() As String Implements iQLTC_PhieuthuchiEntity.nv_Lydo_en
        Get
            Return _nv_Lydo_en
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_Lydo_en = String.Empty
            Else
                _nv_Lydo_en = value.Trim
            End If
        End Set
    End Property

    Public Property v_NguonThanhtoan() As String Implements iQLTC_PhieuthuchiEntity.v_NguonThanhtoan
        Get
            Return _v_NguonThanhtoan
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _v_NguonThanhtoan = String.Empty
            Else
                _v_NguonThanhtoan = value.Trim
            End If
        End Set
    End Property

    Public Property nv_Ghichu() As String Implements iQLTC_PhieuthuchiEntity.nv_Ghichu
        Get
            Return _nv_Ghichu
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_Ghichu = String.Empty
            Else
                _nv_Ghichu = value.Trim
            End If
        End Set
    End Property


    Public Property uId_LoaiTT() As String Implements iQLTC_PhieuthuchiEntity.uId_LoaiTT
        Get
            Return _uId_LoaiTT
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_LoaiTT = String.Empty
            Else
                _uId_LoaiTT = value.Trim
            End If
        End Set
    End Property

    Public Property b_IsKhoa() As Boolean Implements iQLTC_PhieuthuchiEntity.b_IsKhoa
        Get
            Return _b_IsKhoa
        End Get
        Set(ByVal value As Boolean)
            _b_IsKhoa = value
        End Set
    End Property
End Class
