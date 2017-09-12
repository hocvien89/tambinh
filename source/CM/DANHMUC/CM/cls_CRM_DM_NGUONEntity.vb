Public Class CRM_DM_NGUONEntity 
    Implements ICRM_DM_NGUONEntity

    Private _uId_Nguon As String
    Private _nv_Nguon_vn As String
    Private _nv_Nguon_en As String
    Private _vType As String

    Public Property uId_Nguon() As String Implements ICRM_DM_NGUONEntity.uId_Nguon
        Get
            Return _uId_Nguon
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Nguon = String.Empty
            Else
                _uId_Nguon = value.Trim
            End If
        End Set
    End Property

    Public Property nv_Nguon_vn() As String Implements ICRM_DM_NGUONEntity.nv_Nguon_vn
        Get
            Return _nv_Nguon_vn
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_Nguon_vn = String.Empty
            Else
                _nv_Nguon_vn = value.Trim
            End If
        End Set
    End Property

    Public Property nv_Nguon_en() As String Implements ICRM_DM_NGUONEntity.nv_Nguon_en
        Get
            Return _nv_Nguon_en
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_Nguon_en = String.Empty
            Else
                _nv_Nguon_en = value.Trim
            End If
        End Set
    End Property

    Public Property vType() As String Implements ICRM_DM_NGUONEntity.vType
        Get
            Return _vType
        End Get
        Set(ByVal value As String)
            _vType = value
        End Set
    End Property
End Class
