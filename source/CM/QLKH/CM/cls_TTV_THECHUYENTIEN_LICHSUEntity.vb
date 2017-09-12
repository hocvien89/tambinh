Public Class cls_TTV_THECHUYENTIEN_LICHSUEntity
    Implements icls_TTV_THECHUYENTIEN_LICHSUEntity
    Private _d_Ngaychuyen As DateTime
    Private _uId_Lichsuchuyentien As String
    Private _uId_Thechuyentien As String
    Private _v_ghichu As String

    Public Property d_Ngaychuyen As Date Implements icls_TTV_THECHUYENTIEN_LICHSUEntity.d_Ngaychuyen
        Get
            Return Date.Parse(_d_Ngaychuyen).ToShortDateString
        End Get
        Set(ByVal value As Date)
            _d_Ngaychuyen = value
        End Set
    End Property

    Public Property uId_Lichsuchuyentien As String Implements icls_TTV_THECHUYENTIEN_LICHSUEntity.uId_Lichsuchuyentien
        Get
            Return _uId_Lichsuchuyentien
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Lichsuchuyentien = String.Empty
            Else
                _uId_Lichsuchuyentien = value.Trim
            End If
        End Set
    End Property

    Public Property uId_Thechuyentien As String Implements icls_TTV_THECHUYENTIEN_LICHSUEntity.uId_Thechuyentien
        Get
            Return _uId_Thechuyentien
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Lichsuchuyentien = String.Empty
            Else
                _uId_Thechuyentien = value.Trim
            End If
        End Set
    End Property
    Public Property v_Ghichu As String Implements icls_TTV_THECHUYENTIEN_LICHSUEntity.v_Ghichu
        Get
            Return _v_ghichu
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _v_ghichu = String.Empty
            Else
                _v_ghichu = value.Trim
            End If
        End Set
    End Property
End Class
