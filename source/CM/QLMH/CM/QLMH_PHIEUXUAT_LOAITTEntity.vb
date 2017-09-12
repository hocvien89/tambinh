Public Class QLMH_PHIEUXUAT_LOAITTEntity
    Implements IQLMH_PHIEUXUAT_LOAITTEntity

    Private _uId_LoaiTT As String
    Private _uId_Phieuxuat As String
    Private _f_Sotien As Double
    Private _v_Maso As String
    Private _nv_Ghichu_vn As String

    Public Property uId_LoaiTT() As String Implements IQLMH_PHIEUXUAT_LOAITTEntity.uId_LoaiTT
        Get
            Return _uId_LoaiTT
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_LoaiTT = String.Empty
            Else
                _uId_LoaiTT = value.Trim
            End If
        End Set
    End Property

    Public Property uId_Phieuxuat() As String Implements IQLMH_PHIEUXUAT_LOAITTEntity.uId_Phieuxuat
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

    Public Property f_Sotien() As Double Implements IQLMH_PHIEUXUAT_LOAITTEntity.f_Sotien
        Get
            Return _f_Sotien
        End Get
        Set(ByVal value As Double)
            _f_Sotien = value
        End Set
    End Property

    Public Property v_Maso() As String Implements IQLMH_PHIEUXUAT_LOAITTEntity.v_Maso
        Get
            Return _v_Maso
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _v_Maso = String.Empty
            Else
                _v_Maso = value.Trim
            End If
        End Set
    End Property

    Public Property nv_Ghichu_vn() As String Implements IQLMH_PHIEUXUAT_LOAITTEntity.nv_Ghichu_vn
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
