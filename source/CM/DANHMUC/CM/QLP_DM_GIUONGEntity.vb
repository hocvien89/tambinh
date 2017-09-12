Public Class QLP_DM_GIUONGEntity
    Implements IQLP_DM_GIUONGEntity

    Private _uId_Giuong As String
    Private _uId_Phong As String
    Private _nv_TenGiuong_vn As String

    Public Property uId_Giuong() As String Implements IQLP_DM_GIUONGEntity.uId_Giuong
        Get
            Return _uId_Giuong
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Giuong = String.Empty
            Else
                _uId_Giuong = value.Trim
            End If
        End Set
    End Property

    Public Property uId_Phong() As String Implements IQLP_DM_GIUONGEntity.uId_Phong
        Get
            Return _uId_Phong
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Phong = String.Empty
            Else
                _uId_Phong = value.Trim
            End If
        End Set
    End Property

    Public Property nv_TenGiuong_vn() As String Implements IQLP_DM_GIUONGEntity.nv_TenGiuong_vn
        Get
            Return _nv_TenGiuong_vn
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_TenGiuong_vn = String.Empty
            Else
                _nv_TenGiuong_vn = value.Trim
            End If
        End Set
    End Property

End Class
