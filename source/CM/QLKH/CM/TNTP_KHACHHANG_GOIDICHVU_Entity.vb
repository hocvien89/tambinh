Public Class TNTP_KHACHHANG_GOIDICHVU_Entity

    Implements ITNTP_KHACHHANG_GOIDICHVU_LICHSUEntity
    Private _uId_Khachhang_Goidichvu As String
    Private _d_Ngay As DateTime
    Private _f_Sotien As Double
    Private _uId_Phieudichvu As String
    Private _uId_Phieuxuat As String


    Public Property d_Ngay As Date Implements ITNTP_KHACHHANG_GOIDICHVU_LICHSUEntity.d_Ngay
        Get
            Return Date.Parse(_d_Ngay).ToShortDateString
        End Get
        Set(ByVal value As Date)
            _d_Ngay = value
        End Set
    End Property
    Public Property f_Sotien As Double Implements ITNTP_KHACHHANG_GOIDICHVU_LICHSUEntity.f_Sotien
        Get
            Return _f_Sotien
        End Get
        Set(ByVal value As Double)
            _f_Sotien = value
        End Set
    End Property

    Public Property uId_Khachhang_Goidichvu As String Implements ITNTP_KHACHHANG_GOIDICHVU_LICHSUEntity.uId_Khachhang_Goidichvu
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
    Public Property uId_Phieudichvu As String Implements ITNTP_KHACHHANG_GOIDICHVU_LICHSUEntity.uId_Phieudichvu
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
    Public Property uId_Phieuxuat As String Implements ITNTP_KHACHHANG_GOIDICHVU_LICHSUEntity.uId_Phieuxuat
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
End Class
