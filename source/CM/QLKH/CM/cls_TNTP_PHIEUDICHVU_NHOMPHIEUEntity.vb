Public Class cls_TNTP_PHIEUDICHVU_NHOMPHIEUEntity
    Implements icls_TNTP_PHIEUDICHVU_NHOMPHIEUEntity
    Private _uId_Nhomphieu As String
    Private _nv_Tennhomphieu_vn As String
    Public Property nv_Tennhomphieu_vn() As String Implements icls_TNTP_PHIEUDICHVU_NHOMPHIEUEntity.nv_Tennhomphieu_vn
        Get
            Return _nv_Tennhomphieu_vn
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_Tennhomphieu_vn = String.Empty
            Else
                _nv_Tennhomphieu_vn = value.Trim
            End If
        End Set
    End Property

    Public Property uId_Nhomphieu() As String Implements icls_TNTP_PHIEUDICHVU_NHOMPHIEUEntity.uId_Nhomphieu
        Get
            Return _uId_Nhomphieu
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Nhomphieu = String.Empty
            Else
                _uId_Nhomphieu = value.Trim
            End If
        End Set
    End Property
End Class
