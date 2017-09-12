Public Class NHATKYSUDUNGEntity
    Implements INHATKYSUDUNGEntity

    Private _IDNhatky As Int64
    Private _Tendangnhap As String
    Private _ngaygio As DateTime
    Private _ngaygioB As String
    Private _hanhdong As String
    Private _IP As String

    Public Property IDNhatky() As Int64 Implements INHATKYSUDUNGEntity.IDNhatky
        Get
            Return _IDNhatky
        End Get
        Set(ByVal value As Int64)
            _IDNhatky = value
        End Set
    End Property

    Public Property Tendangnhap() As String Implements INHATKYSUDUNGEntity.Tendangnhap
        Get
            Return _Tendangnhap
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _Tendangnhap = String.Empty
            Else
                _Tendangnhap = value.Trim
            End If
        End Set
    End Property

    Public Property ngaygio() As DateTime Implements INHATKYSUDUNGEntity.ngaygio
        Get
            Return _ngaygio
        End Get
        Set(ByVal value As DateTime)
            _ngaygio = value
        End Set
    End Property

    Public Property ngaygioB() As String
        Get
            If (_ngaygio = Nothing) Then
                Return String.Empty
            Else
                Return CStr(Format(_ngaygio, "dd/MM/yyyy"))
            End If
        End Get
        Set(ByVal value As String)
            _ngaygio = value
        End Set
    End Property

    Public Property hanhdong() As String Implements INHATKYSUDUNGEntity.hanhdong
        Get
            Return _hanhdong
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _hanhdong = String.Empty
            Else
                _hanhdong = value.Trim
            End If
        End Set
    End Property

    Public Property IP() As String Implements INHATKYSUDUNGEntity.IP
        Get
            Return _IP
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _IP = String.Empty
            Else
                _IP = value.Trim
            End If
        End Set
    End Property

End Class
