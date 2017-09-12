Public Class TNTP_CHECKINCHECKOUTEntity
    Implements ITNTP_CHECKINCHECKOUTEntity

    Private _uId_Check As String
    Private _uId_Giuong As String
    Private _uId_QT_Dieutri As String
    Private _dt_checkin As DateTime
    Private _dt_checkinB As String
    Private _dt_checkout As DateTime
    Private _dt_checkoutB As String

    Public Property uId_Check() As String Implements ITNTP_CHECKINCHECKOUTEntity.uId_Check
        Get
            Return _uId_Check
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Check = String.Empty
            Else
                _uId_Check = value.Trim
            End If
        End Set
    End Property

    Public Property uId_Giuong() As String Implements ITNTP_CHECKINCHECKOUTEntity.uId_Giuong
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

    Public Property uId_QT_Dieutri() As String Implements ITNTP_CHECKINCHECKOUTEntity.uId_QT_Dieutri
        Get
            Return _uId_QT_Dieutri
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_QT_Dieutri = String.Empty
            Else
                _uId_QT_Dieutri = value.Trim
            End If
        End Set
    End Property

    Public Property dt_checkin() As DateTime Implements ITNTP_CHECKINCHECKOUTEntity.dt_checkin
        Get
            Return _dt_checkin
        End Get
        Set(ByVal value As DateTime)
            _dt_checkin = value
        End Set
    End Property

    Public Property dt_checkinB() As String
        Get
            If (_dt_checkin = Nothing) Then
                Return String.Empty
            Else
                Return CStr(Format(_dt_checkin, "dd/MM/yyyy"))
            End If
        End Get
        Set(ByVal value As String)
            _dt_checkin = value
        End Set
    End Property

    Public Property dt_checkout() As DateTime Implements ITNTP_CHECKINCHECKOUTEntity.dt_checkout
        Get
            Return _dt_checkout
        End Get
        Set(ByVal value As DateTime)
            _dt_checkout = value
        End Set
    End Property

    Public Property dt_checkoutB() As String
        Get
            If (_dt_checkout = Nothing) Then
                Return String.Empty
            Else
                Return CStr(Format(_dt_checkout, "dd/MM/yyyy"))
            End If
        End Get
        Set(ByVal value As String)
            _dt_checkout = value
        End Set
    End Property

End Class
