Public Class MKT_HUYDV
    Implements CM.IMKT_HUYDV
    Private _Date As DateTime
    Private _uId_HuyDV As String
    Private _uId_Dichvu As String
    Private _uId_Phieudichvu As String
    Private _uId_Nhanvien As String
    Private _uId_Khachhang As String
    Private _nv_Ghichu_vn As String

    Public Property [Date]() As Date Implements IMKT_HUYDV.Date
        Get
            Return _Date
        End Get
        Set(ByVal value As Date)
            _Date = value
        End Set
    End Property

    Public Property uId_Dichvu() As String Implements IMKT_HUYDV.uId_Dichvu
        Get
            Return _uId_Dichvu
        End Get
        Set(ByVal value As String)
            _uId_Dichvu = value
        End Set
    End Property

    Public Property uId_HuyDV() As String Implements IMKT_HUYDV.uId_HuyDV
        Get
            Return _uId_HuyDV
        End Get
        Set(ByVal value As String)
            _uId_HuyDV = value
        End Set
    End Property

    Public Property uId_Khachhang() As String Implements IMKT_HUYDV.uId_Khachhang
        Get
            Return _uId_Khachhang
        End Get
        Set(ByVal value As String)
            _uId_Khachhang = value
        End Set
    End Property

    Public Property uId_Nhanvien() As String Implements IMKT_HUYDV.uId_Nhanvien
        Get
            Return _uId_Nhanvien
        End Get
        Set(ByVal value As String)
            _uId_Nhanvien = value
        End Set
    End Property

    Public Property uId_Phieudichvu() As String Implements IMKT_HUYDV.uId_Phieudichvu
        Get
            Return _uId_Phieudichvu
        End Get
        Set(ByVal value As String)
            _uId_Phieudichvu = value
        End Set
    End Property

    Public Property nv_Ghichu_vn() As String Implements IMKT_HUYDV.nv_Ghichu_vn
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
End Class
