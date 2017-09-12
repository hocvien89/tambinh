Public Class MKT_LOAITAGSEntity
    Implements IMKT_LOAITAGSEntity
    Private _i_Thutu As Integer
    Private _Id_LoaiTag As Integer
    Private _nv_TenLoaiTag_vn As String
    Public Property i_Thutu() As Integer Implements IMKT_LOAITAGSEntity.i_Thutu
        Get
            Return _i_Thutu
        End Get
        Set(ByVal value As Integer)
            If (value = Nothing) Then
                _i_Thutu = 0
            Else
                _i_Thutu = value
            End If
        End Set
    End Property

    Public Property Id_LoaiTag() As Integer Implements IMKT_LOAITAGSEntity.Id_LoaiTag
        Get
            Return _Id_LoaiTag
        End Get
        Set(ByVal value As Integer)
            If (value = Nothing) Then
                _Id_LoaiTag = 0
            Else
                _Id_LoaiTag = value
            End If
        End Set
    End Property

    Public Property nv_TenLoaiTag_vn() As String Implements IMKT_LOAITAGSEntity.nv_TenLoaiTag_vn
        Get
            Return _nv_TenLoaiTag_vn
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_TenLoaiTag_vn = String.Empty
            Else
                _nv_TenLoaiTag_vn = value.Trim
            End If
        End Set
    End Property
End Class
