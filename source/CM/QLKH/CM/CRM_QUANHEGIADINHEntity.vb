Public Class CRM_QUANHEGIADINHEntity
    Implements ICRM_QUANHEGIADINHEntity

    Private _uId_Quanhe As String
    Private _uId_Khachhang As String
    Private _v_MaQuanhe As String
    Private _nv_Hoten As String
    Private _d_Ngaysinh As DateTime
    Private _d_NgaysinhB As String
    Private _nv_Ghichu As String

    Public Property uId_Quanhe() As String Implements ICRM_QUANHEGIADINHEntity.uId_Quanhe
        Get
            Return _uId_Quanhe
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Quanhe = String.Empty
            Else
                _uId_Quanhe = value.Trim
            End If
        End Set
    End Property

    Public Property uId_Khachhang() As String Implements ICRM_QUANHEGIADINHEntity.uId_Khachhang
        Get
            Return _uId_Khachhang
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Khachhang = String.Empty
            Else
                _uId_Khachhang = value.Trim
            End If
        End Set
    End Property

    Public Property v_MaQuanhe() As String Implements ICRM_QUANHEGIADINHEntity.v_MaQuanhe
        Get
            Return _v_MaQuanhe
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _v_MaQuanhe = String.Empty
            Else
                _v_MaQuanhe = value.Trim
            End If
        End Set
    End Property

    Public Property nv_Hoten() As String Implements ICRM_QUANHEGIADINHEntity.nv_Hoten
        Get
            Return _nv_Hoten
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_Hoten = String.Empty
            Else
                _nv_Hoten = value.Trim
            End If
        End Set
    End Property

    Public Property d_Ngaysinh() As DateTime Implements ICRM_QUANHEGIADINHEntity.d_Ngaysinh
        Get
            Return _d_Ngaysinh
        End Get
        Set(ByVal value As DateTime)
            _d_Ngaysinh = value
        End Set
    End Property

    Public Property d_NgaysinhB() As String
        Get
            If (_d_Ngaysinh = Nothing) Then
                Return String.Empty
            Else
                Return CStr(Format(_d_Ngaysinh, "dd/MM/yyyy"))
            End If
        End Get
        Set(ByVal value As String)
            _d_Ngaysinh = value
        End Set
    End Property

    Public Property nv_Ghichu() As String Implements ICRM_QUANHEGIADINHEntity.nv_Ghichu
        Get
            Return _nv_Ghichu
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_Ghichu = String.Empty
            Else
                _nv_Ghichu = value.Trim
            End If
        End Set
    End Property

End Class
