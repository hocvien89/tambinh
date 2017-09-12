Public Class TNTP_DM_NHOMDICHVUEntity 
    Implements ITNTP_DM_NHOMDICHVUEntity


    Private _uId_Nhomdichvu As String
    Private _uId_Cuahang As String
    Private _nv_TennhomDichvu_vn As String
    Private _nv_TennhomDichvu_en As String
    Private _nv_Tencuahang_vn As String
    Private _nv_Ghichu_vn As String
    Private _nv_Ghichu_en As String

    Private _vType As String


    Public Property uId_Nhomdichvu() As String Implements ITNTP_DM_NHOMDICHVUEntity.uId_Nhomdichvu
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

    Public Property uId_Cuahang() As String Implements ITNTP_DM_NHOMDICHVUEntity.uId_Cuahang
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

    Public Property nv_TennhomDichvu_vn() As String Implements ITNTP_DM_NHOMDICHVUEntity.nv_TennhomDichvu_vn
        Get
            Return _nv_TennhomDichvu_vn
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_TennhomDichvu_vn = String.Empty
            Else
                _nv_TennhomDichvu_vn = value.Trim
            End If
        End Set
    End Property

    Public Property nv_TennhomDichvu_en() As String Implements ITNTP_DM_NHOMDICHVUEntity.nv_TennhomDichvu_en
        Get
            Return _nv_TennhomDichvu_en
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_TennhomDichvu_en = String.Empty
            Else
                _nv_TennhomDichvu_en = value.Trim
            End If
        End Set
    End Property

    Public Property nv_Tencuahang_vn() As String
        Get
            Return _nv_Tencuahang_vn
        End Get
        Set(ByVal value As String)
            _nv_Tencuahang_vn = value
        End Set
    End Property

    Public Property nv_Ghichu_en() As String Implements ITNTP_DM_NHOMDICHVUEntity.nv_Ghichu_en
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

    Public Property nv_Ghichu_vn() As String Implements ITNTP_DM_NHOMDICHVUEntity.nv_Ghichu_vn
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

    Public Property vType() As String Implements ITNTP_DM_NHOMDICHVUEntity.vType
        Get
            Return _vType
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _vType = String.Empty
            Else
                _vType = value.Trim
            End If
        End Set
    End Property
End Class
