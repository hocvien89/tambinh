Public Class TNTP_GOIDICHVU_DICHVUEntity 
    Implements ITNTP_GOIDICHVU_DICHVUEntity

    Private _uId_Goidichvu As String
    Private _uId_Dichvu As String
    Private _nv_Tendichvu_vn As String
    Private _f_Soluong As Double
    Private _f_Dongia As Double
    Private _f_Thanhtien As Double

    Public Property uId_Goidichvu() As String Implements ITNTP_GOIDICHVU_DICHVUEntity.uId_Goidichvu
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

    Public Property uId_Dichvu() As String Implements ITNTP_GOIDICHVU_DICHVUEntity.uId_Dichvu
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

    Public Property nv_Tendichvu_vn() As String
        Get
            Return _nv_Tendichvu_vn
        End Get
        Set(ByVal value As String)
            _nv_Tendichvu_vn = value
        End Set
    End Property

    Public Property f_Dongia() As Double Implements ITNTP_GOIDICHVU_DICHVUEntity.f_Dongia
        Get
            Return _f_Dongia
        End Get
        Set(value As Double)
            _f_Dongia = value
        End Set
    End Property
    Public Property f_Soluong() As Double Implements ITNTP_GOIDICHVU_DICHVUEntity.f_Soluong
        Get
            Return _f_Soluong
        End Get
        Set(value As Double)
            _f_Soluong = value
        End Set
    End Property
    Public Property f_Thanhtien() As Double Implements ITNTP_GOIDICHVU_DICHVUEntity.f_Thanhtien
        Get
            Return _f_Thanhtien
        End Get
        Set(value As Double)
            _f_Thanhtien = value
        End Set
    End Property
End Class
