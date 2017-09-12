Public Class DMDonviEntity
    Implements IDMDonviEntity

    Private _madonvi As String
    Private _tendonvi As String
    Private _ghichu As String

    Public Property madonvi() As String Implements IDMDonviEntity.madonvi
        Get
            Return _madonvi
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _madonvi = String.Empty
            Else
                _madonvi = value.Trim
            End If
        End Set
    End Property

    Public Property tendonvi() As String Implements IDMDonviEntity.tendonvi
        Get
            Return _tendonvi
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _tendonvi = String.Empty
            Else
                _tendonvi = value.Trim
            End If
        End Set
    End Property

    Public Property ghichu() As String Implements IDMDonviEntity.ghichu
        Get
            Return _ghichu
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _ghichu = String.Empty
            Else
                _ghichu = value.Trim
            End If
        End Set
    End Property

End Class
