Public Class TNTP_QT_DIEUTRI_NHANVIENPHUEntity
    Implements ITNTP_QT_DIEUTRI_NHANVIENPHUEntity


    Private _uId_QT_Dieutri As String
    Private _uId_Nhanvien_Phu As String
    Private _uId_Congdoan As String

    Public Property uId_QT_Dieutri() As String Implements ITNTP_QT_DIEUTRI_NHANVIENPHUEntity.uId_QT_Dieutri
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

    Public Property uId_Nhanvien_Phu() As String Implements ITNTP_QT_DIEUTRI_NHANVIENPHUEntity.uId_Nhanvien_Phu
        Get
            Return _uId_Nhanvien_Phu
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Nhanvien_Phu = String.Empty
            Else
                _uId_Nhanvien_Phu = value.Trim
            End If
        End Set
    End Property

    Public Property uId_Congdoan() As String Implements ITNTP_QT_DIEUTRI_NHANVIENPHUEntity.uId_Congdoan
        Get
            Return _uId_Congdoan
        End Get
        Set(ByVal value As String)
            _uId_Congdoan = value
        End Set
    End Property
End Class