Public Class TNTP_PHIEUDICHVUEntity 
    Implements ITNTP_PHIEUDICHVUEntity

    Private _uId_Phieudichvu As String
    Private _uId_Cuahang As String
    Private _uId_Khachhang As String
    Private _v_Sophieu As String
    Private _d_Ngay As DateTime
    Private _d_NgayB As String
    Private _nv_Ghichu_vn As String
    Private _nv_Ghichu_en As String
    Private _f_Giamgia As String
    Private _f_Tongtienthuc As String
    Private _nv_Hoten_vn As String
    Private _uId_LoaiTT As String
    Private _d_Ngayketthuc As DateTime
    Private _uId_Nhanvien As String
    Private _HHPhieu As Double
    Private _Id_Nhomphieu As Integer
    Private _b_IsKhoa As Boolean
    Private _b_IsPayed As Boolean
    Private _f_Tuvan1 As Double
    Private _f_Tuvan2 As Double
    Private _f_Tuvan3 As Double
    Private _f_Hoahong As Double
    Private _uId_Tuvan1 As String
    Private _uId_Tuvan2 As String
    Private _uId_Tuvan3 As String
    Private _uId_Tuvan As String
    Private _uId_Dichvu1 As String
    Private _uId_Dichvu2 As String
    Private _uId_Dichvu3 As String
    Private _nv_Lydogiamgia As String
    Public Property uId_Phieudichvu() As String Implements ITNTP_PHIEUDICHVUEntity.uId_Phieudichvu
        Get
            Return _uId_Phieudichvu
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Phieudichvu = String.Empty
            Else
                _uId_Phieudichvu = value.Trim
            End If
        End Set
    End Property
    Public Property uId_LoaiTT() As String Implements ITNTP_PHIEUDICHVUEntity.uId_LoaiTT
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
    Public Property uId_Cuahang() As String Implements ITNTP_PHIEUDICHVUEntity.uId_Cuahang
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
    Public Property uId_Khachhang() As String Implements ITNTP_PHIEUDICHVUEntity.uId_Khachhang
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

    Public Property v_Sophieu() As String Implements ITNTP_PHIEUDICHVUEntity.v_Sophieu
        Get
            Return _v_Sophieu
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _v_Sophieu = String.Empty
            Else
                _v_Sophieu = value.Trim
            End If
        End Set
    End Property

    Public Property d_Ngay() As DateTime Implements ITNTP_PHIEUDICHVUEntity.d_Ngay
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
    Public Property d_Ngayketthuc() As DateTime Implements ITNTP_PHIEUDICHVUEntity.d_Ngayketthuc
        Get
            If (_d_Ngayketthuc = Nothing) Then
                Return Nothing
            Else
                Return Date.Parse(_d_Ngayketthuc).ToShortDateString
            End If
        End Get
        Set(ByVal value As DateTime)
            _d_Ngayketthuc = value
        End Set
    End Property

    Public Property nv_Ghichu_vn() As String Implements ITNTP_PHIEUDICHVUEntity.nv_Ghichu_vn
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

    Public Property nv_Ghichu_en() As String Implements ITNTP_PHIEUDICHVUEntity.nv_Ghichu_en
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

    Public Property f_Giamgia() As String Implements ITNTP_PHIEUDICHVUEntity.f_Giamgia
        Get
            Return _f_Giamgia
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _f_Giamgia = String.Empty
            Else
                _f_Giamgia = value.Trim
            End If
        End Set
    End Property

    Public Property f_Tongtienthuc() As String Implements ITNTP_PHIEUDICHVUEntity.f_Tongtienthuc
        Get
            Return _f_Tongtienthuc
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _f_Tongtienthuc = String.Empty
            Else
                _f_Tongtienthuc = value.Trim
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
    Public Property uId_Nhanvien() As String Implements ITNTP_PHIEUDICHVUEntity.uId_Nhanvien
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
    Public Property HHPhieu() As Double Implements ITNTP_PHIEUDICHVUEntity.HHPhieu
        Get
            Return _HHPhieu
        End Get
        Set(ByVal value As Double)
            _HHPhieu = value
        End Set
    End Property
    Public Property Id_Nhomphieu() As Integer Implements ITNTP_PHIEUDICHVUEntity.Id_Nhomphieu
        Get
            Return _Id_Nhomphieu
        End Get
        Set(ByVal value As Integer)
            If (value = Nothing) Then
                _Id_Nhomphieu = 1
            Else
                _Id_Nhomphieu = value
            End If
        End Set
    End Property

    Public Property b_IsKhoa() As Boolean Implements ITNTP_PHIEUDICHVUEntity.b_IsKhoa
        Get
            Return _b_IsKhoa
        End Get
        Set(ByVal value As Boolean)
            _b_IsKhoa = value
        End Set
    End Property

    Public Property b_IsPayed() As Boolean Implements ITNTP_PHIEUDICHVUEntity.b_IsPayed
        Get
            Return _b_IsPayed
        End Get
        Set(ByVal value As Boolean)
            _b_IsPayed = value
        End Set
    End Property

    Public Property f_Tuvan1 As Double Implements ITNTP_PHIEUDICHVUEntity.f_Tuvan1
        Get
            Return _f_Tuvan1
        End Get
        Set(ByVal value As Double)
            _f_Tuvan1 = value
        End Set
    End Property
    Public Property f_Tuvan2() As Double Implements ITNTP_PHIEUDICHVUEntity.f_Tuvan2
        Get
            Return _f_Tuvan2
        End Get
        Set(ByVal value As Double)
            _f_Tuvan2 = value
        End Set
    End Property
    Public Property f_Tuvan3 As Double Implements ITNTP_PHIEUDICHVUEntity.f_Tuvan3
        Get
            Return _f_Tuvan3
        End Get
        Set(ByVal value As Double)
            _f_Tuvan3 = value
        End Set
    End Property
    Public Property f_Hoahong() As Double Implements ITNTP_PHIEUDICHVUEntity.f_Hoahong
        Get
            Return _f_Hoahong
        End Get
        Set(ByVal value As Double)
            _f_Hoahong = value
        End Set
    End Property

    Public Property uId_Tuvan1() As String Implements ITNTP_PHIEUDICHVUEntity.uId_Tuvan1
        Get
            Return _uId_Tuvan1
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Tuvan1 = String.Empty
            Else
                _uId_Tuvan1 = value.Trim
            End If
        End Set
    End Property
    Public Property uId_Tuvan2() As String Implements ITNTP_PHIEUDICHVUEntity.uId_Tuvan2
        Get
            Return _uId_Tuvan2
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Tuvan2 = String.Empty
            Else
                _uId_Tuvan2 = value.Trim
            End If
        End Set
    End Property
    Public Property uId_Tuvan3 As String Implements ITNTP_PHIEUDICHVUEntity.uId_Tuvan3
        Get
            Return _uId_Tuvan3
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Tuvan3 = String.Empty
            Else
                _uId_Tuvan3 = value.Trim
            End If
        End Set
    End Property
    Public Property uId_Tuvan() As String Implements ITNTP_PHIEUDICHVUEntity.uId_Tuvan
        Get
            Return _uId_Tuvan
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Tuvan = String.Empty
            Else
                _uId_Tuvan = value.Trim
            End If
        End Set
    End Property
    Public Property uId_Dichvu1() As String Implements ITNTP_PHIEUDICHVUEntity.uId_Dichvu1
        Get
            Return _uId_Dichvu1
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Dichvu1 = String.Empty
            Else
                _uId_Dichvu1 = value.Trim
            End If
        End Set
    End Property
    Public Property uId_Dichvu2() As String Implements ITNTP_PHIEUDICHVUEntity.uId_Dichvu2
        Get
            Return _uId_Dichvu2
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Dichvu2 = String.Empty
            Else
                _uId_Dichvu2 = value.Trim
            End If
        End Set
    End Property
    Public Property uId_Dichvu3() As String Implements ITNTP_PHIEUDICHVUEntity.uId_Dichvu3
        Get
            Return _uId_Dichvu3
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Dichvu3 = String.Empty
            Else
                _uId_Dichvu3 = value.Trim
            End If
        End Set
    End Property

    Public Property nv_Lydogiamgia() As String Implements ITNTP_PHIEUDICHVUEntity.nv_Lydogiamgia
        Get
            Return _nv_Lydogiamgia
        End Get
        Set(value As String)
            If String.IsNullOrEmpty(value) Then
                _nv_Lydogiamgia = String.Empty
            Else
                _nv_Lydogiamgia = value.Trim
            End If
        End Set
    End Property
End Class
