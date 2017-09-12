Public Class TNTP_DM_DICHVU_CONGDOANEntity
    Implements ITNTP_DM_DICHVU_CONGDOANEntity
    Private _uId_Dichvu As String
    Private _uId_Congdoan As String
    Private _f_TienHH As Double
    Private _nv_Ghichu As String
    Private _uId_Mathang As String
    Private _uId_Kho As String
    Private _f_Soluong As Double
    Private _f_Sophut As Double
    Private _uId_Dichvu_Congdoan As String

    Public Property uId_Dichvu() As String Implements ITNTP_DM_DICHVU_CONGDOANEntity.uId_Dichvu
        Get
            Return _uId_Dichvu
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Dichvu = String.Empty
            Else
                _uId_Dichvu = value.Trim
            End If
        End Set
    End Property

    Public Property uId_Congdoan() As String Implements ITNTP_DM_DICHVU_CONGDOANEntity.uId_Congdoan
        Get
            Return _uId_Congdoan
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Congdoan = String.Empty
            Else
                _uId_Congdoan = value.Trim
            End If
        End Set
    End Property

    Public Property f_TienHH() As Double Implements ITNTP_DM_DICHVU_CONGDOANEntity.f_TienHH
        Get
            Return _f_TienHH
        End Get
        Set(ByVal value As Double)
            _f_TienHH = value
        End Set
    End Property

    Public Property nv_Ghichu() As String Implements ITNTP_DM_DICHVU_CONGDOANEntity.nv_Ghichu
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

    Public Property f_Soluong() As Double Implements ITNTP_DM_DICHVU_CONGDOANEntity.f_Soluong
        Get
            Return _f_Soluong
        End Get
        Set(value As Double)
            _f_Soluong = value
        End Set
    End Property
    Public Property f_Sophut() As Double Implements ITNTP_DM_DICHVU_CONGDOANEntity.f_Sophut
        Get
            Return _f_Sophut
        End Get
        Set(value As Double)
            _f_Sophut = value
        End Set
    End Property
    Public Property uId_Mathang() As String Implements ITNTP_DM_DICHVU_CONGDOANEntity.uId_Mathang
        Get
            Return _uId_Mathang
        End Get
        Set(value As String)
            _uId_Mathang = value
        End Set
    End Property
    Public Property uIdKho() As String Implements ITNTP_DM_DICHVU_CONGDOANEntity.uIdKho
        Get
            Return _uId_Kho
        End Get
        Set(value As String)
            _uId_Kho = value
        End Set
    End Property

    Public Property uId_Dichvu_Congdoan() As String Implements ITNTP_DM_DICHVU_CONGDOANEntity.uId_Dichvu_Congdoan
        Get
            Return _uId_Dichvu_Congdoan
        End Get
        Set(value As String)
            _uId_Dichvu_Congdoan = value
        End Set
    End Property
End Class
