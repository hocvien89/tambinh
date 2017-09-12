Public Class QLMH_VATTUTIEUHAO_QT_DIEUTRIEntity 
    Implements IQLMH_VATTUTIEUHAO_QT_DIEUTRIEntity
    Private _uId_QT_Dieutri As String
    Private _uId_Mathang As String
    Private _f_SLTieuhao As Double
    Private _uId_Kho As String
    Private _Madonvi As String
    Private _f_Soluongnhonhat As Double

    Public Property uId_QT_Dieutri() As String Implements IQLMH_VATTUTIEUHAO_QT_DIEUTRIEntity.uId_QT_Dieutri
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

    Public Property uId_Mathang() As String Implements IQLMH_VATTUTIEUHAO_QT_DIEUTRIEntity.uId_Mathang
        Get
            Return _uId_Mathang
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Mathang = String.Empty
            Else
                _uId_Mathang = value.Trim
            End If
        End Set
    End Property

    Public Property f_SLTieuhao() As Double Implements IQLMH_VATTUTIEUHAO_QT_DIEUTRIEntity.f_SLTieuhao
        Get
            Return _f_SLTieuhao
        End Get
        Set(ByVal value As Double)
            _f_SLTieuhao = value
        End Set
    End Property

    Public Property uId_Kho() As String Implements IQLMH_VATTUTIEUHAO_QT_DIEUTRIEntity.uId_Kho
        Get
            Return _uId_Kho
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Kho = String.Empty
            Else
                _uId_Kho = value.Trim
            End If
        End Set
    End Property

    Public Property Madonvi() As String Implements IQLMH_VATTUTIEUHAO_QT_DIEUTRIEntity.Madonvi
        Get
            Return _Madonvi
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _Madonvi = String.Empty
            Else
                _Madonvi = value.Trim
            End If
        End Set
    End Property

    Public Property f_Soluongnhonhat() As Double Implements IQLMH_VATTUTIEUHAO_QT_DIEUTRIEntity.f_Soluongnhonhat
        Get
            Return _f_Soluongnhonhat
        End Get
        Set(ByVal value As Double)
            _f_Soluongnhonhat = value
        End Set
    End Property
End Class
