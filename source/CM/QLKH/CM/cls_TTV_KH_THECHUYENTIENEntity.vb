Public Class cls_TTV_KH_THECHUYENTIENEntity
    Implements icls_TTV_KH_THECHUYENTIENEntity


    Private _d_Ngaychuyen As DateTime
    Private _f_Sotien As Double
    Private _uId_Khachhang As String
    Private _uId_Thechuyentien As String
    Private _v_Ghichu As String
    Private _uId_Phieudichvu_Chitiet As String



    Public Property f_Sotien As Double Implements icls_TTV_KH_THECHUYENTIENEntity.f_Sotien
        Get
            Return _f_Sotien
        End Get
        Set(ByVal value As Double)
            _f_Sotien = value
        End Set
    End Property

    Public Property uId_Khachhang As String Implements icls_TTV_KH_THECHUYENTIENEntity.uId_Khachhang
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

    Public Property uId_Thechuyentien As String Implements icls_TTV_KH_THECHUYENTIENEntity.uId_Thechuyentien
        Get
            Return _uId_Thechuyentien
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Thechuyentien = String.Empty
            Else
                _uId_Thechuyentien = value.Trim
            End If
        End Set
    End Property
    Public Property v_Ghichu As String Implements icls_TTV_KH_THECHUYENTIENEntity.v_Ghichu
        Get
            Return _v_Ghichu
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _v_Ghichu = String.Empty
            Else
                _v_Ghichu = value.Trim
            End If
        End Set
    End Property

    Public Property d_Ngaychuyen As Date Implements icls_TTV_KH_THECHUYENTIENEntity.d_Ngaychuyen
        Get
            Return Date.Parse(_d_Ngaychuyen).ToShortDateString
        End Get
        Set(ByVal value As Date)
            _d_Ngaychuyen = value
        End Set
    End Property

    Public Property uId_Phieudichvu_Chitiet As String Implements icls_TTV_KH_THECHUYENTIENEntity.uId_Phieudichvu_Chitiet
        Get
            Return _uId_Phieudichvu_Chitiet
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Phieudichvu_Chitiet = String.Empty
            Else
                _uId_Phieudichvu_Chitiet = value.Trim
            End If
        End Set
    End Property
End Class
