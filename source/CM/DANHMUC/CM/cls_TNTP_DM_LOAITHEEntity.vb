Public Class TNTP_DM_LOAITHEEntity 
    Implements ITNTP_DM_LOAITHEEntity


    Private _uId_Loaithe As String
    Private _nv_Tenloaithe_vn As String
    Private _nv_Tenloaithe_en As String
    Private _f_Sotiendinhmuc As Double
    Private _f_Phantramchietkhau As Double

    Public Property uId_Loaithe() As String Implements ITNTP_DM_LOAITHEEntity.uId_Loaithe
        Get
            Return _uId_Loaithe
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Loaithe = String.Empty
            Else
                _uId_Loaithe = value.Trim
            End If
        End Set
    End Property

    Public Property nv_Tenloaithe_vn() As String Implements ITNTP_DM_LOAITHEEntity.nv_Tenloaithe_vn
        Get
            Return _nv_Tenloaithe_vn
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_Tenloaithe_vn = String.Empty
            Else
                _nv_Tenloaithe_vn = value.Trim
            End If
        End Set
    End Property

    Public Property nv_Tenloaithe_en() As String Implements ITNTP_DM_LOAITHEEntity.nv_Tenloaithe_en
        Get
            Return _nv_Tenloaithe_en
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_Tenloaithe_en = String.Empty
            Else
                _nv_Tenloaithe_en = value.Trim
            End If
        End Set
    End Property

    Public Property f_Sotiendinhmuc() As Double Implements ITNTP_DM_LOAITHEEntity.f_Sotiendinhmuc
        Get
            Return _f_Sotiendinhmuc
        End Get
        Set(ByVal value As Double)
            _f_Sotiendinhmuc = value
        End Set
    End Property

    Public Property f_Phantramchietkhau() As Double Implements ITNTP_DM_LOAITHEEntity.f_Phantramchietkhau
        Get
            Return _f_Phantramchietkhau
        End Get
        Set(ByVal value As Double)
            _f_Phantramchietkhau = value
        End Set
    End Property
End Class
