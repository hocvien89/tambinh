Public Class TNTP_DM_DICHVUEntity 
    Implements ITNTP_DM_DICHVUEntity


    Private _uId_Dichvu As String
    Private _uId_Nhomdichvu As String
    Private _uId_Ngoaite As String
    Private _nv_Tendichvu_vn As String
    Private _nv_Tendichvu_en As String
    Private _f_Gia As Double
    Private _f_Phidichvu As Double
    Private _f_Sophutchuanbi As Double
    Private _f_Sophutthuchien As Double
    Private _b_Tinhthue As Boolean
    Private _b_TinhHoahong As Boolean
    Private _f_PhantramHH_KTV As Double
    Private _f_PhantramHH_TVV As Double
    Private _f_PhantramHH_CTV As Double
    Private _f_PhantramHH_NV As Double
    Private _i_Solan_Dieutri As Int32
    Private _b_Goidichvu As Boolean
    Private _f_Gia_Giam As Double
    Private _i_Ngay As Integer
    Private _i_Soluong As Integer
    Private _i_Songayquaylai As Integer
    Public Property uId_Dichvu() As String Implements ITNTP_DM_DICHVUEntity.uId_Dichvu
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

    Public Property uId_Nhomdichvu() As String Implements ITNTP_DM_DICHVUEntity.uId_Nhomdichvu
        Get
            Return _uId_Nhomdichvu
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Nhomdichvu = String.Empty
            Else
                _uId_Nhomdichvu = value.Trim
            End If
        End Set
    End Property

    Public Property uId_Ngoaite() As String Implements ITNTP_DM_DICHVUEntity.uId_Ngoaite
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

    Public Property nv_Tendichvu_vn() As String Implements ITNTP_DM_DICHVUEntity.nv_Tendichvu_vn
        Get
            Return _nv_Tendichvu_vn
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_Tendichvu_vn = String.Empty
            Else
                _nv_Tendichvu_vn = value.Trim
            End If
        End Set
    End Property

    Public Property nv_Tendichvu_en() As String Implements ITNTP_DM_DICHVUEntity.nv_Tendichvu_en
        Get
            Return _nv_Tendichvu_en
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_Tendichvu_en = String.Empty
            Else
                _nv_Tendichvu_en = value.Trim
            End If
        End Set
    End Property

    Public Property f_Gia() As Double Implements ITNTP_DM_DICHVUEntity.f_Gia
        Get
            Return _f_Gia
        End Get
        Set(ByVal value As Double)
            _f_Gia = value
        End Set
    End Property

    Public Property f_Phidichvu() As Double Implements ITNTP_DM_DICHVUEntity.f_Phidichvu
        Get
            Return _f_Phidichvu
        End Get
        Set(ByVal value As Double)
            _f_Phidichvu = value
        End Set
    End Property

    Public Property f_Sophutchuanbi() As Double Implements ITNTP_DM_DICHVUEntity.f_Sophutchuanbi
        Get
            Return _f_Sophutchuanbi
        End Get
        Set(ByVal value As Double)
            _f_Sophutchuanbi = value
        End Set
    End Property

    Public Property f_Sophutthuchien() As Double Implements ITNTP_DM_DICHVUEntity.f_Sophutthuchien
        Get
            Return _f_Sophutthuchien
        End Get
        Set(ByVal value As Double)
            _f_Sophutthuchien = value
        End Set
    End Property

    Public Property b_Tinhthue() As Boolean Implements ITNTP_DM_DICHVUEntity.b_Tinhthue
        Get
            Return _b_Tinhthue
        End Get
        Set(ByVal value As Boolean)
            _b_Tinhthue = value
        End Set
    End Property

    Public Property b_TinhHoahong() As Boolean Implements ITNTP_DM_DICHVUEntity.b_TinhHoahong
        Get
            Return _b_TinhHoahong
        End Get
        Set(ByVal value As Boolean)
            _b_TinhHoahong = value
        End Set
    End Property

    Public Property f_PhantramHH_KTV() As Double Implements ITNTP_DM_DICHVUEntity.f_PhantramHH_KTV
        Get
            Return _f_PhantramHH_KTV
        End Get
        Set(ByVal value As Double)
            _f_PhantramHH_KTV = value
        End Set
    End Property

    Public Property f_PhantramHH_TVV() As Double Implements ITNTP_DM_DICHVUEntity.f_PhantramHH_TVV
        Get
            Return _f_PhantramHH_TVV
        End Get
        Set(ByVal value As Double)
            _f_PhantramHH_TVV = value
        End Set
    End Property

    Public Property f_PhantramHH_CTV() As Double Implements ITNTP_DM_DICHVUEntity.f_PhantramHH_CTV
        Get
            Return _f_PhantramHH_CTV
        End Get
        Set(ByVal value As Double)
            _f_PhantramHH_CTV = value
        End Set
    End Property

    Public Property f_PhantramHH_NV() As Double Implements ITNTP_DM_DICHVUEntity.f_PhantramHH_NV
        Get
            Return _f_PhantramHH_NV
        End Get
        Set(ByVal value As Double)
            _f_PhantramHH_NV = value
        End Set
    End Property

    Public Property i_Solan_Dieutri() As Int32 Implements ITNTP_DM_DICHVUEntity.i_Solan_Dieutri
        Get
            Return _i_Solan_Dieutri
        End Get
        Set(ByVal value As Int32)
            _i_Solan_Dieutri = value
        End Set
    End Property

    Public Property b_Goidichvu() As Boolean Implements ITNTP_DM_DICHVUEntity.b_Goidichvu
        Get
            Return _b_Goidichvu
        End Get
        Set(ByVal value As Boolean)
            _b_Goidichvu = value
        End Set
    End Property

    Public Property f_Gia_Giam As Double Implements ITNTP_DM_DICHVUEntity.f_Gia_Giam
        Get
            Return _f_Gia_Giam
        End Get
        Set(ByVal value As Double)
            _f_Gia_Giam = value
        End Set
    End Property

    Public Property i_Ngay As Integer Implements ITNTP_DM_DICHVUEntity.i_Ngay
        Get
            Return _i_Ngay
        End Get
        Set(ByVal value As Integer)
            _i_Ngay = value
        End Set
    End Property

    Public Property i_Soluong As Integer Implements ITNTP_DM_DICHVUEntity.i_Soluong
        Get
            Return _i_Soluong
        End Get
        Set(ByVal value As Integer)
            _i_Soluong = value
        End Set
    End Property

    Public Property i_Songayquaylai As Integer Implements ITNTP_DM_DICHVUEntity.i_Songayquaylai
        Get
            Return _i_Songayquaylai
        End Get
        Set(ByVal value As Integer)
            _i_Songayquaylai = value
        End Set
    End Property
End Class
