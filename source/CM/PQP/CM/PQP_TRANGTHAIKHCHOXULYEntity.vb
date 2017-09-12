Public Class PQP_TRANGTHAIKHCHOXULYEntity 
    Implements IPQP_TRANGTHAIKHCHOXULYEntity
    Private _uId_TrangthaiKH As String
    Private _uId_Khachhang As String
    Private _uId_Trangthai As String
    Private _d_Ngay As DateTime
    Private _d_ThoigianchuyenTTB As String
    Private _uId_Phong As String
    Private _uId_Phieudichvu As String

    Public Property uId_TrangthaiKH() As String Implements IPQP_TRANGTHAIKHCHOXULYEntity.uId_TrangthaiKH
        Get
            Return _uId_TrangthaiKH
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_TrangthaiKH = String.Empty
            Else
                _uId_TrangthaiKH = value.Trim
            End If
        End Set
    End Property

    Public Property uId_Trangthai() As String Implements IPQP_TRANGTHAIKHCHOXULYEntity.uId_Trangthai
        Get
            Return _uId_Trangthai
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Trangthai = String.Empty
            Else
                _uId_Trangthai = value.Trim
            End If
        End Set
    End Property

    Public Property d_Ngay() As DateTime Implements IPQP_TRANGTHAIKHCHOXULYEntity.d_Ngay
        Get
            Return _d_Ngay
        End Get
        Set(ByVal value As DateTime)
            _d_Ngay = value
        End Set
    End Property

    Public Property d_ThoigianchuyenTTB() As String
        Get
            If (_d_Ngay = Nothing) Then
                Return String.Empty
            Else
                Return CStr(Format(_d_Ngay, "dd/MM/yyyy"))
            End If
        End Get
        Set(ByVal value As String)
            _d_Ngay = value
        End Set
    End Property

    Public Property uId_Phong() As String Implements IPQP_TRANGTHAIKHCHOXULYEntity.uId_Phong
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

    Public Property uId_Phieudichvu() As String Implements IPQP_TRANGTHAIKHCHOXULYEntity.uId_Phieudichvu
        Get
            Return _uId_Phieudichvu
        End Get
        Set(ByVal value As String)
            _uId_Phieudichvu = value
        End Set
    End Property
End Class
