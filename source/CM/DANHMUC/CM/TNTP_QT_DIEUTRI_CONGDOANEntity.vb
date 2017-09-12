Public Class TNTP_QT_DIEUTRI_CONGDOANEntity
    Implements ITNTP_QT_DIEUTRI_CONGDOANEntity

    Private _v_Macongdoan As String
    Private _uId_Congdoan As String
    Private _nv_Tencongdoan_vn As String
    Private _nv_Tencongdoan_en As String

    Public Property uId_Congdoan() As String Implements ITNTP_QT_DIEUTRI_CONGDOANEntity.uId_Congdoan
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

    Public Property nv_Tencongdoan_vn() As String Implements ITNTP_QT_DIEUTRI_CONGDOANEntity.nv_Tencongdoan_vn
        Get
            Return _nv_Tencongdoan_vn
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_Tencongdoan_vn = String.Empty
            Else
                _nv_Tencongdoan_vn = value.Trim
            End If
        End Set
    End Property

    Public Property nv_Tencongdoan_en() As String Implements ITNTP_QT_DIEUTRI_CONGDOANEntity.nv_Tencongdoan_en
        Get
            Return _nv_Tencongdoan_en
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_Tencongdoan_en = String.Empty
            Else
                _nv_Tencongdoan_en = value.Trim
            End If
        End Set
    End Property

    Public Property v_Macongdoan As String Implements ITNTP_QT_DIEUTRI_CONGDOANEntity.v_Macongdoan
        Get
            Return _v_Macongdoan
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _v_Macongdoan = String.Empty
            Else
                _v_Macongdoan = value.Trim
            End If
        End Set
    End Property
End Class
