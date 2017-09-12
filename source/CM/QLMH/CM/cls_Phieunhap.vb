Public Class cls_Phieunhap
    Implements iCls_Phieunhap

#Region "Pramaters of Phieunhap_Header"

    Private _uId_Phieunhap As String
    Private _uId_Nhacungcap As String
    Private _uId_Kho As String
    Private _uId_Nhanvien As String
    Private _v_Maphieunhap As String
    Private _d_Ngaynhap As DateTime
    Private _nv_Noidung_vn As String
    Private _nv_Noidung_en As String
    Private _f_Giamgia As Double
    Private _f_Tongthanhtoan As Double
    Private _f_Tongtien As Double
#End Region

#Region "Pramaters of Phieunhap_Detail"

    Private _uId_Phieunhap_Chitiet As String
    Private _uId_Mathang As String
    Private _f_Soluong As Double
    Private _f_Donggia As Double
    Private _f_Thanhtien As Double
    Private _d_NgayhethanSD As String
    Private _d_NgayhethanSDB As String
    Private _MaDonVi As String
    Private _f_Soluongnhonhat As Double
#End Region
#Region "Propertys of Phieunhap_Header"

    Public Property uId_Phieunhap() As String Implements iCls_Phieunhap.uId_Phieunhap
        Get
            Return _uId_Phieunhap
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Phieunhap = String.Empty
            Else
                _uId_Phieunhap = value.Trim
            End If
        End Set
    End Property

    Public Property uId_Nhacungcap() As String Implements iCls_Phieunhap.uId_Nhacungcap
        Get
            Return _uId_Nhacungcap
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Nhacungcap = Nothing
            Else
                _uId_Nhacungcap = value.Trim
            End If
        End Set
    End Property

    Public Property uId_Kho() As String Implements iCls_Phieunhap.uId_Kho
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

    Public Property uId_Nhanvien() As String Implements iCls_Phieunhap.uId_Nhanvien
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

    Public Property v_Maphieunhap() As String Implements iCls_Phieunhap.v_Maphieunhap
        Get
            Return _v_Maphieunhap
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _v_Maphieunhap = String.Empty
            Else
                _v_Maphieunhap = value.Trim
            End If
        End Set
    End Property

    Public Property d_Ngaynhap() As DateTime Implements iCls_Phieunhap.d_Ngaynhap
        Get
            Return Date.Parse(_d_Ngaynhap).ToShortDateString
        End Get
        Set(ByVal value As DateTime)
            _d_Ngaynhap = value
        End Set
    End Property


    Public Property nv_Noidung_vn() As String Implements iCls_Phieunhap.nv_Noidung_vn
        Get
            Return _nv_Noidung_vn
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_Noidung_vn = String.Empty
            Else
                _nv_Noidung_vn = value.Trim
            End If
        End Set
    End Property

    Public Property nv_Noidung_en() As String Implements iCls_Phieunhap.nv_Noidung_en
        Get
            Return _nv_Noidung_en
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_Noidung_en = String.Empty
            Else
                _nv_Noidung_en = value.Trim
            End If
        End Set
    End Property
    'xuanhieu 121214
    Public Property f_Giamgia() As Double Implements iCls_Phieunhap.f_Giamgia
        Set(value As Double)
            _f_Giamgia = value
        End Set
        Get
            Return _f_Giamgia
        End Get
    End Property
    Public Property f_Tongthanhtoan() As Double Implements iCls_Phieunhap.f_Tongthanhtoan
        Get
            Return _f_Tongthanhtoan
        End Get
        Set(value As Double)
            _f_Tongthanhtoan = value
        End Set
    End Property
#End Region
#Region "Propertys of Phieunhap_Detail"

    Public Property uId_Phieunhap_Chitiet() As String Implements iCls_Phieunhap.uId_Phieunhap_Chitiet
        Get
            Return _uId_Phieunhap_Chitiet
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Mathang = String.Empty
            Else
                _uId_Phieunhap_Chitiet = value.Trim
            End If
        End Set
    End Property

    Public Property uId_Mathang() As String Implements iCls_Phieunhap.uId_Mathang
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

    Public Property f_Soluong() As Double Implements iCls_Phieunhap.f_Soluong
        Get
            Return _f_Soluong
        End Get
        Set(ByVal value As Double)
            _f_Soluong = value
        End Set
    End Property

    Public Property f_Donggia() As Double Implements iCls_Phieunhap.f_Donggia
        Get
            Return _f_Donggia
        End Get
        Set(ByVal value As Double)
            _f_Donggia = value
        End Set
    End Property

    Public Property f_Thanhtien() As Double Implements iCls_Phieunhap.f_Thanhtien
        Get
            Return _f_Thanhtien
        End Get
        Set(ByVal value As Double)
            _f_Thanhtien = value
        End Set
    End Property

    Public Property d_NgayhethanSD() As String Implements iCls_Phieunhap.d_NgayhethanSD
        Get
            Return _d_NgayhethanSDB
        End Get
        Set(ByVal value As String)
            _d_NgayhethanSDB = value
        End Set
    End Property

    Public Property f_Soluongnhonhat() As Double Implements iCls_Phieunhap.f_Soluongnhonhat
        Get
            Return _f_Soluongnhonhat
        End Get
        Set(ByVal value As Double)
            _f_Soluongnhonhat = value
        End Set
    End Property

    Public Property MaDonVi() As String Implements iCls_Phieunhap.MaDonVi
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

    Public Property f_Tongtien() As Double Implements iCls_Phieunhap.f_Tongtien
        Get
            Return _f_Tongtien
        End Get
        Set(value As Double)
            _f_Tongtien = value
        End Set
    End Property
End Class
