Public Class QLCN_CONGNO_THANHTOANEntity 
    Implements IQLCN_CONGNO_THANHTOANEntity

    Private _uId_Congno_Thanhtoan As String
    Private _uId_Khachhang As String
    Private _uId_Phieuthuchi As String
    Private _f_Sotien_Nolai As Double
    Private _uId_Phieuno As String
    Private _vTypeThanhToan As String

    Public Property uId_Congno_Thanhtoan() As String Implements IQLCN_CONGNO_THANHTOANEntity.uId_Congno_Thanhtoan
        Get
            Return _uId_Congno_Thanhtoan
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Congno_Thanhtoan = String.Empty
            Else
                _uId_Congno_Thanhtoan = value.Trim
            End If
        End Set
    End Property

    Public Property uId_Phieuno() As String Implements IQLCN_CONGNO_THANHTOANEntity.uId_Phieuno
        Get
            Return _uId_Phieuno
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Phieuno = String.Empty
            Else
                _uId_Phieuno = value.Trim
            End If
        End Set
    End Property

    Public Property uId_Khachhang() As String Implements IQLCN_CONGNO_THANHTOANEntity.uId_Khachhang
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

    Public Property uId_Phieuthuchi() As String Implements IQLCN_CONGNO_THANHTOANEntity.uId_Phieuthuchi
        Get
            Return _uId_Phieuthuchi
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Phieuthuchi = String.Empty
            Else
                _uId_Phieuthuchi = value.Trim
            End If
        End Set
    End Property

    Public Property f_Sotien_Nolai() As Double Implements IQLCN_CONGNO_THANHTOANEntity.f_Sotien_Nolai
        Get
            Return _f_Sotien_Nolai
        End Get
        Set(ByVal value As Double)
            _f_Sotien_Nolai = value
        End Set
    End Property

    Public Property vTypeThanhToan() As String Implements IQLCN_CONGNO_THANHTOANEntity.vTypeThanhToan
        Get
            Return _vTypeThanhToan
        End Get
        Set(value As String)
            _vTypeThanhToan = value
        End Set
    End Property
End Class
