Public Class QLMH_DM_XUATXUEntity 
    Implements IQLMH_DM_XUATXUEntity

    Private _v_Maxuatxu As String
    Private _uid_Xuatxu As String
    Private _nv_Tenxuatxu_vn As String
    Private _nv_Tenxuatxu_en As String

    Public Property uId_Xuatxu() As String Implements IQLMH_DM_XUATXUEntity.uId_Xuatxu
        Get
            Return _uid_Xuatxu
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uid_Xuatxu = String.Empty
            Else
                _uid_Xuatxu = value.Trim
            End If
        End Set
    End Property

    Public Property nv_Tenxuatxu_vn() As String Implements IQLMH_DM_XUATXUEntity.nv_Tenxuatxu_vn
        Get
            Return _nv_Tenxuatxu_vn
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_Tenxuatxu_vn = String.Empty
            Else
                _nv_Tenxuatxu_vn = value.Trim
            End If
        End Set
    End Property

    Public Property nv_Tenxuatxu_en() As String Implements IQLMH_DM_XUATXUEntity.nv_Tenxuatxu_en
        Get
            Return _nv_Tenxuatxu_en
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_Tenxuatxu_en = String.Empty
            Else
                _nv_Tenxuatxu_en = value.Trim
            End If
        End Set
    End Property

    Public Property v_Maxuatxu As String Implements IQLMH_DM_XUATXUEntity.v_Maxuatxu
        Get
            Return _v_Maxuatxu
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _v_Maxuatxu = String.Empty
            Else
                _v_Maxuatxu = value.Trim
            End If
        End Set
    End Property
End Class
