Public Class QLMH_PHIEUXUATEntity
    Implements IQLMH_PHIEUXUATEntity
#Region "Pramaters of Phieu xuat - Header"

    Private _uId_Phieuxuat As String
    Private _uId_Khachhang As String
    Private _uId_Kho As String
    Private _uId_Nhanvien As String
    Private _v_Maphieuxuat As String
    Private _d_Ngayxuat As DateTime
    Private _d_NgayxuatB As DateTime
    Private _nv_Noidungxuat_vn As String
    Private _nv_Noidungxuat_en As String
    Private _f_Giamgia_Tong As Double
    Private _f_Tongtienthuc As Double
    Private _b_IsKhoa As Boolean
    Private _uId_LoaiTT As String
    Private _b_Dathanhtoan As Boolean
    Private _vTypeGia As String
    Private _f_Gia As Double
    Private _i_Soluong As Integer
    Private _b_Chike As Boolean
#End Region

#Region "Propertys of Phieu xuat - Header"

    Public Property uId_Phieuxuat() As String Implements IQLMH_PHIEUXUATEntity.uId_Phieuxuat
        Get
            Return _uId_Phieuxuat
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Phieuxuat = String.Empty
            Else
                _uId_Phieuxuat = value.Trim
            End If
        End Set
    End Property

    Public Property uId_Khachhang() As String Implements IQLMH_PHIEUXUATEntity.uId_Khachhang
        Get
            Return _uId_Khachhang
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Khachhang = Nothing
            Else
                _uId_Khachhang = value.Trim
            End If
        End Set
    End Property

    Public Property uId_Kho() As String Implements IQLMH_PHIEUXUATEntity.uId_Kho
        Get
            Return _uId_Kho
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Kho = String.Empty
            Else
                _uId_Kho = value.Trim
            End If
        End Set
    End Property

    Public Property uId_Nhanvien() As String Implements IQLMH_PHIEUXUATEntity.uId_Nhanvien
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

    Public Property v_Maphieuxuat() As String Implements IQLMH_PHIEUXUATEntity.v_Maphieuxuat
        Get
            Return _v_Maphieuxuat
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _v_Maphieuxuat = String.Empty
            Else
                _v_Maphieuxuat = value.Trim
            End If
        End Set
    End Property

    Public Property d_Ngayxuat() As DateTime Implements IQLMH_PHIEUXUATEntity.d_Ngayxuat
        Get
            Return Date.Parse(_d_Ngayxuat).ToShortDateString
        End Get
        Set(ByVal value As DateTime)
            _d_Ngayxuat = value
        End Set
    End Property

    Public Property d_NgayxuatB() As String
        Get
            If (_d_Ngayxuat = Nothing) Then
                Return String.Empty
            Else
                Return CStr(Format(_d_Ngayxuat, "dd/MM/yyyy"))
            End If
        End Get
        Set(ByVal value As String)
            _d_Ngayxuat = value
        End Set
    End Property

    Public Property nv_Noidungxuat_vn() As String Implements IQLMH_PHIEUXUATEntity.nv_Noidungxuat_vn
        Get
            Return _nv_Noidungxuat_vn
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_Noidungxuat_vn = String.Empty
            Else
                _nv_Noidungxuat_vn = value.Trim
            End If
        End Set
    End Property

    Public Property nv_Noidungxuat_en() As String Implements IQLMH_PHIEUXUATEntity.nv_Noidungxuat_en
        Get
            Return _nv_Noidungxuat_en
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_Noidungxuat_en = String.Empty
            Else
                _nv_Noidungxuat_en = value.Trim
            End If
        End Set
    End Property



    Public Property f_Giamgia_Tong() As Double Implements IQLMH_PHIEUXUATEntity.f_Giamgia_Tong
        Get
            Return _f_Giamgia_Tong
        End Get
        Set(ByVal value As Double)
            _f_Giamgia_Tong = value
        End Set
    End Property

    Public Property f_Tongtienthuc() As Double Implements IQLMH_PHIEUXUATEntity.f_Tongtienthuc
        Get
            Return _f_Tongtienthuc
        End Get
        Set(ByVal value As Double)
            _f_Tongtienthuc = value
        End Set
    End Property

    Public Property uId_LoaiTT() As String Implements IQLMH_PHIEUXUATEntity.uId_LoaiTT
        Get
            Return _uId_LoaiTT
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_LoaiTT = Nothing
            Else
                _uId_LoaiTT = value.Trim
            End If
        End Set
    End Property
    Public Property b_Dathanhtoan() As Boolean Implements IQLMH_PHIEUXUATEntity.b_Dathanhtoan
        Get
            Return _b_Dathanhtoan
        End Get
        Set(value As Boolean)
            _b_Dathanhtoan = value
        End Set
    End Property
    Public Property f_Gia() As Double Implements IQLMH_PHIEUXUATEntity.f_Gia
        Get
            Return _f_Gia
        End Get
        Set(value As Double)
            _f_Gia = value
        End Set
    End Property

    Public Property i_Soluog() As Integer Implements IQLMH_PHIEUXUATEntity.i_Soluog
        Get
            Return _i_Soluong
        End Get
        Set(value As Integer)
            _i_Soluong = value
        End Set
    End Property

    Public Property vTypeGia() As String Implements IQLMH_PHIEUXUATEntity.vTypeGia
        Get
            Return _vTypeGia
        End Get
        Set(value As String)
            _vTypeGia = value
        End Set
    End Property
    Public Property b_Chike() As Boolean Implements IQLMH_PHIEUXUATEntity.b_Chike
        Get
            Return _b_Chike
        End Get
        Set(value As Boolean)
            _b_Chike = value
        End Set
    End Property
#End Region

#Region "Pramaters of Phieu xuat - Detail"
    Private _uId_Phieuxuat_Chitiet As String
    Private _uId_Mathang As String
    Private _f_Soluong As Double
    Private _f_Dongia As Double
    Private _f_Giamgia As Double
    Private _f_Tongtien As Double
    Private _nv_Ghichu As String
    Private _MaDonVi As String
    Private _f_Soluongnhonhat As Double

#End Region

#Region "Propertys of Phieu xuat - Detail"
    Public Property uId_Phieuxuat_Chitiet() As String Implements IQLMH_PHIEUXUATEntity.uId_Phieuxuat_Chitiet
        Get
            Return _uId_Phieuxuat_Chitiet
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Phieuxuat_Chitiet = String.Empty
            Else
                _uId_Phieuxuat_Chitiet = value.Trim
            End If
        End Set
    End Property


    Public Property uId_Mathang() As String Implements IQLMH_PHIEUXUATEntity.uId_Mathang
        Get
            Return _uId_Mathang
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Mathang = String.Empty
            Else
                _uId_Mathang = value.Trim
            End If
        End Set
    End Property

    Public Property f_Soluong() As Double Implements IQLMH_PHIEUXUATEntity.f_Soluong
        Get
            Return _f_Soluong
        End Get
        Set(ByVal value As Double)
            _f_Soluong = value
        End Set
    End Property

    Public Property f_Dongia() As Double Implements IQLMH_PHIEUXUATEntity.f_Dongia
        Get
            Return _f_Dongia
        End Get
        Set(ByVal value As Double)
            _f_Dongia = value
        End Set
    End Property
    Public Property f_Giamgia() As Double Implements IQLMH_PHIEUXUATEntity.f_Giamgia
        Get
            Return _f_Giamgia
        End Get
        Set(ByVal value As Double)
            _f_Giamgia = value
        End Set
    End Property

    Public Property f_Tongtien() As Double Implements IQLMH_PHIEUXUATEntity.f_Tongtien
        Get
            Return _f_Tongtien
        End Get
        Set(ByVal value As Double)
            _f_Tongtien = value
        End Set
    End Property

    Public Property nv_Ghichu() As String Implements IQLMH_PHIEUXUATEntity.nv_Ghichu
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

    Public Property f_Soluongnhonhat() As Double Implements IQLMH_PHIEUXUATEntity.f_Soluongnhonhat
        Get
            Return _f_Soluongnhonhat
        End Get
        Set(ByVal value As Double)
            _f_Soluongnhonhat = value
        End Set
    End Property

    Public Property MaDonVi() As String Implements IQLMH_PHIEUXUATEntity.MaDonVi
        Get
            Return _MaDonVi
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _MaDonVi = String.Empty
            Else
                _MaDonVi = value.Trim
            End If
        End Set
    End Property

#End Region


    Public Property b_IsKhoa() As Boolean Implements IQLMH_PHIEUXUATEntity.b_IsKhoa
        Get
            Return _b_IsKhoa
        End Get
        Set(ByVal value As Boolean)
            _b_IsKhoa = value
        End Set
    End Property

End Class
