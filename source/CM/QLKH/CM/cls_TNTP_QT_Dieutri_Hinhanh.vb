Public Class cls_TNTP_QT_Dieutri_Hinhanh
    Implements iCls_TNTP_QT_Dieutri_Hinhanh
    Private _nv_Hinhanh_vn As String
    Private _uId_Hinhanh_Congdoan As String
    Private _uId_QT_Dieutri As String

    Public Property nv_Hinhanh_nv() As String Implements iCls_TNTP_QT_Dieutri_Hinhanh.nv_Hinhanh_nv
        Get
            Return _nv_Hinhanh_vn
        End Get
        Set(value As String)
            _nv_Hinhanh_vn = value
        End Set
    End Property
    Public Property uId_Hinhanh_Congdoan() As String Implements iCls_TNTP_QT_Dieutri_Hinhanh.uId_Hinhanh_Congdoan
        Get
            Return _uId_Hinhanh_Congdoan
        End Get
        Set(value As String)
            _uId_Hinhanh_Congdoan = value
        End Set
    End Property
    Public Property uId_QT_Dieutri() As String Implements iCls_TNTP_QT_Dieutri_Hinhanh.uId_QT_Dieutri
        Get
            Return _uId_QT_Dieutri
        End Get
        Set(value As String)
            _uId_QT_Dieutri = value
        End Set
    End Property
End Class
