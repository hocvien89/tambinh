Public Class cls_TTV_KH_Thetichdiem_LichsuEntity
    Implements iCls_TTV_KH_Thetichdiem_LichsuEntity

    Private _uId_Lichsutichdiem As String
    Private _uId_KH_The As String
    Private _uId_Sukien As String
    Private _d_Ngaythuhien As Date
    Private _b_Luachon As Boolean
    Private _nv_Noidung As String
    Private _f_Diem As Double
    Private _uId_Nhanvien As String

    Public Property b_Luachon() As Boolean Implements iCls_TTV_KH_Thetichdiem_LichsuEntity.b_Luachon
        Get
            Return _b_Luachon
        End Get
        Set(value As Boolean)
            _b_Luachon = value
        End Set
    End Property
    Public Property d_Ngaythuchien() As Date Implements iCls_TTV_KH_Thetichdiem_LichsuEntity.d_Ngaythuchien
        Get
            Return _d_Ngaythuhien
        End Get
        Set(value As Date)
            _d_Ngaythuhien = value
        End Set
    End Property
    Public Property nv_Noidung() As String Implements iCls_TTV_KH_Thetichdiem_LichsuEntity.nv_Noidung
        Get
            Return _nv_Noidung
        End Get
        Set(value As String)
            _nv_Noidung = value
        End Set
    End Property

    Public Property uId_KH_The() As String Implements iCls_TTV_KH_Thetichdiem_LichsuEntity.uId_KH_The
        Get
            Return _uId_KH_The
        End Get
        Set(value As String)
            _uId_KH_The = value
        End Set
    End Property
    Public Property uId_Lichsutichdiem() As String Implements iCls_TTV_KH_Thetichdiem_LichsuEntity.uId_Lichsutichdiem
        Get
            Return _uId_Lichsutichdiem
        End Get
        Set(value As String)
            _uId_Lichsutichdiem = value
        End Set
    End Property
    Public Property uId_Sukien() As String Implements iCls_TTV_KH_Thetichdiem_LichsuEntity.uId_Sukien
        Get
            Return _uId_Sukien
        End Get
        Set(value As String)
            _uId_Sukien = value
        End Set
    End Property

    Public Property f_Diem() As Double Implements iCls_TTV_KH_Thetichdiem_LichsuEntity.f_Diem
        Get
            Return _f_Diem
        End Get
        Set(value As Double)
            _f_Diem = value
        End Set
    End Property

    Public Property uId_Nhanvien() As String Implements iCls_TTV_KH_Thetichdiem_LichsuEntity.uId_Nhanvien
        Get
            Return _uId_Nhanvien
        End Get
        Set(value As String)
            _uId_Nhanvien = value
        End Set
    End Property

End Class
