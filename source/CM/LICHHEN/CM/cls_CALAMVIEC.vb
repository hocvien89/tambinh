Public Class cls_CALAMVIEC
    Implements icls_DM_CALAMVIEC
    Private _d_Dengio As String
    Private _d_Tugio As String
    Private _uId_Nhanvien As String
    Private _uId_Nhanvien_Ca As String
    Private _v_Calamviec As String
    Private _d_Ngay As DateTime
    Private _nv_Ghichu_vn As String
    Public Property d_Dengio() As String Implements icls_DM_CALAMVIEC.d_Dengio
        Get
            Return _d_Dengio
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _d_Dengio = String.Empty
            Else
                _d_Dengio = value.Trim
            End If
        End Set
    End Property
    Public Property d_Tugio() As String Implements icls_DM_CALAMVIEC.d_Tugio
        Get
            Return _d_Tugio
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _d_Tugio = String.Empty
            Else
                _d_Tugio = value.Trim
            End If
        End Set
    End Property
    Public Property uId_Nhanvien() As String Implements icls_DM_CALAMVIEC.uId_Nhanvien
        Get
            Return _uId_Nhanvien
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Nhanvien = String.Empty
            Else
                _uId_Nhanvien = value.Trim
            End If
        End Set
    End Property
    Public Property uId_Nhanvien_Ca() As String Implements icls_DM_CALAMVIEC.uId_Nhanvien_Ca
        Get
            Return _uId_Nhanvien_Ca
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Nhanvien_Ca = String.Empty
            Else
                _uId_Nhanvien_Ca = value.Trim
            End If
        End Set
    End Property
    Public Property v_Calamviec() As String Implements icls_DM_CALAMVIEC.v_Calamviec
        Get
            Return _v_Calamviec
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _v_Calamviec = String.Empty
            Else
                _v_Calamviec = value.Trim
            End If
        End Set
    End Property
    Public Property nv_Ghichu_vn() As String Implements icls_DM_CALAMVIEC.nv_Ghichu_vn
        Get
            Return _nv_Ghichu_vn
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_Ghichu_vn = String.Empty
            Else
                _nv_Ghichu_vn = value.Trim
            End If
        End Set
    End Property
    Public Property d_Ngay() As DateTime Implements icls_DM_CALAMVIEC.d_Ngay
              Get
            Return Date.Parse(_d_Ngay).ToShortDateString
        End Get
        Set(ByVal value As DateTime)
            _d_Ngay = value
        End Set
    End Property
End Class
