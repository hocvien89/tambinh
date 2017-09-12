Public Class TNTP_PHIEUDICHVU_CHITIETEntity 
    Implements ITNTP_PHIEUDICHVU_CHITIETEntity


    Private _uId_Phieudichvu_Chitiet As String
    Private _uId_Phieudichvu As String
    Private _uId_Dichvu As String
    Private _uId_Ngoaite As String
    Private _f_Solan As Double
    Private _f_Soluong As Double
    Private _f_Dongia As Double
    Private _f_Giamgia As Double
    Private _f_Tongtien As Double
    Private _nv_Tendichvu_vn As String
    Private _uId_Nhanvien As String
    Private _b_BaoHanh As Boolean
    Private _b_Trangthai As Boolean
    Private _uId_CTKM As String

    Public Property uId_Phieudichvu_Chitiet() As String Implements ITNTP_PHIEUDICHVU_CHITIETEntity.uId_Phieudichvu_Chitiet
        Get
            Return _uId_Phieudichvu_Chitiet
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Phieudichvu_Chitiet = String.Empty
            Else
                _uId_Phieudichvu_Chitiet = value.Trim
            End If
        End Set
    End Property

    Public Property uId_Phieudichvu() As String Implements ITNTP_PHIEUDICHVU_CHITIETEntity.uId_Phieudichvu
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

    Public Property uId_Dichvu() As String Implements ITNTP_PHIEUDICHVU_CHITIETEntity.uId_Dichvu
        Get
            Return _uId_Dichvu
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Dichvu = String.Empty
            Else
                _uId_Dichvu = value.Trim
            End If
        End Set
    End Property

    Public Property uId_Ngoaite() As String Implements ITNTP_PHIEUDICHVU_CHITIETEntity.uId_Ngoaite
        Get
            Return _uId_Ngoaite
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Ngoaite = String.Empty
            Else
                _uId_Ngoaite = value.Trim
            End If
        End Set
    End Property

    Public Property f_Soluong() As Double Implements ITNTP_PHIEUDICHVU_CHITIETEntity.f_Soluong
        Get
            Return _f_Soluong
        End Get
        Set(ByVal value As Double)
            _f_Soluong = value
        End Set
    End Property

    Public Property f_Dongia() As Double Implements ITNTP_PHIEUDICHVU_CHITIETEntity.f_Dongia
        Get
            Return _f_Dongia
        End Get
        Set(ByVal value As Double)
            _f_Dongia = value
        End Set
    End Property

    Public Property f_Giamgia() As Double Implements ITNTP_PHIEUDICHVU_CHITIETEntity.f_Giamgia
        Get
            Return _f_Giamgia
        End Get
        Set(ByVal value As Double)
            _f_Giamgia = value
        End Set
    End Property

    Public Property f_Tongtien() As Double Implements ITNTP_PHIEUDICHVU_CHITIETEntity.f_Tongtien
        Get
            Return _f_Tongtien
        End Get
        Set(ByVal value As Double)
            _f_Tongtien = value
        End Set
    End Property

    Public Property nv_Tendichvu_vn() As String
        Get
            Return _nv_Tendichvu_vn
        End Get
        Set(ByVal value As String)
            _nv_Tendichvu_vn = value
        End Set
    End Property

    Public Property uId_Nhanvien() As String Implements ITNTP_PHIEUDICHVU_CHITIETEntity.uId_Nhanvien
        Get
            Return _uId_Nhanvien
        End Get
        Set(ByVal value As String)
            _uId_Nhanvien = value
        End Set
    End Property

    Public Property f_Solan() As Double Implements ITNTP_PHIEUDICHVU_CHITIETEntity.f_Solan
        Get
            Return _f_Solan
        End Get
        Set(ByVal value As Double)
            _f_Solan = value
        End Set
    End Property

    Public Property b_BaoHanh() As Boolean Implements ITNTP_PHIEUDICHVU_CHITIETEntity.b_BaoHanh
        Get
            Return _b_BaoHanh
        End Get
        Set(ByVal value As Boolean)
            _b_BaoHanh = value
        End Set
    End Property

    Public Property b_Trangthai As Boolean Implements ITNTP_PHIEUDICHVU_CHITIETEntity.b_Trangthai
        Get
            Return _b_Trangthai
        End Get
        Set(ByVal value As Boolean)
            _b_Trangthai = value
        End Set
    End Property
    Public Property uId_CTKM() As String Implements ITNTP_PHIEUDICHVU_CHITIETEntity.uId_CTKM
        Get
            Return _uId_CTKM
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_CTKM = String.Empty
            Else
                _uId_CTKM = value.Trim
            End If
        End Set
    End Property
End Class
