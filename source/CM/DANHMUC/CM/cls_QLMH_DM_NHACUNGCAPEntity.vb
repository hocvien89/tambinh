
Public Class QLMH_DM_NHACUNGCAPEntity
    Implements IQLMH_DM_NHACUNGCAPEntity

    Private _uId_Nhacungcap As String
    Private _v_Manhacungcap As String
    Private _nv_Tennhacungcap_vn As String
    Private _nv_Tennhacungcap_en As String
    Private _nv_Diachi_vn As String
    Private _nv_Diachi_en As String

    Public Property uId_Nhacungcap() As String Implements IQLMH_DM_NHACUNGCAPEntity.uId_Nhacungcap
        Get
            Return _uId_Nhacungcap
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Nhacungcap = String.Empty
            Else
                _uId_Nhacungcap = value.Trim
            End If
        End Set
    End Property

    Public Property v_Manhacungcap() As String Implements IQLMH_DM_NHACUNGCAPEntity.v_Manhacungcap
        Get
            Return _v_Manhacungcap
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _v_Manhacungcap = String.Empty
            Else
                _v_Manhacungcap = value.Trim
            End If
        End Set
    End Property

    Public Property nv_Tennhacungcap_vn() As String Implements IQLMH_DM_NHACUNGCAPEntity.nv_Tennhacungcap_vn
        Get
            Return _nv_Tennhacungcap_vn
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_Tennhacungcap_vn = String.Empty
            Else
                _nv_Tennhacungcap_vn = value.Trim
            End If
        End Set
    End Property

    Public Property nv_Tennhacungcap_en() As String Implements IQLMH_DM_NHACUNGCAPEntity.nv_Tennhacungcap_en
        Get
            Return _nv_Tennhacungcap_en
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_Tennhacungcap_en = String.Empty
            Else
                _nv_Tennhacungcap_en = value.Trim
            End If
        End Set
    End Property

    Public Property nv_Diachi_vn() As String Implements IQLMH_DM_NHACUNGCAPEntity.nv_Diachi_vn
        Get
            Return _nv_Diachi_vn
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_Diachi_vn = String.Empty
            Else
                _nv_Diachi_vn = value.Trim
            End If
        End Set
    End Property

    Public Property nv_Diachi_en() As String Implements IQLMH_DM_NHACUNGCAPEntity.nv_Diachi_en
        Get
            Return _nv_Diachi_en
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_Diachi_en = String.Empty
            Else
                _nv_Diachi_en = value.Trim
            End If
        End Set
    End Property

End Class
