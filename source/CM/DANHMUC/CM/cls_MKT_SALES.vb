Public Class cls_MKT_SALES
    Implements icls_MKT_SALES
    Private _uId_Sale As String
    Private _f_Giamgia_percent As Integer
    Private _f_Giagia_monney As Integer
    Private _d_Start As DateTime
    Private _d_End As DateTime
    Private _nv_Tenchuongtrinh_vn As String
    Public Property uId_Sale() As String Implements icls_MKT_SALES.uId_Sale
        Get
            Return _uId_Sale
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Sale = String.Empty
            Else
                _uId_Sale = value.Trim
            End If
        End Set
    End Property
    Public Property f_Giagia_percent() As Integer Implements icls_MKT_SALES.f_Giamgia_percent
        Get
            Return _f_Giamgia_percent
        End Get
        Set(ByVal value As Integer)
            If (value = Nothing) Then
                _f_Giamgia_percent = 0
            Else
                _f_Giamgia_percent = value
            End If
        End Set
    End Property
    Public Property f_Giamgia_money() As Integer Implements icls_MKT_SALES.f_Giamgia_money
        Get
            Return _f_Giagia_monney
        End Get
        Set(ByVal value As Integer)
            If (value = Nothing) Then
                _f_Giagia_monney = 0
            Else
                _f_Giagia_monney = value
            End If
        End Set
    End Property
    Public Property d_Start() As DateTime Implements icls_MKT_SALES.d_Start
        Get
            Return _d_Start
        End Get
        Set(ByVal value As DateTime)
            _d_Start = value
        End Set
    End Property
    Public Property d_End() As DateTime Implements icls_MKT_SALES.d_End
        Get
            Return _d_End
        End Get
        Set(ByVal value As DateTime)
            _d_End = value
        End Set
    End Property

    Public Property nv_Tenchuongtrinh_vn() As String Implements icls_MKT_SALES.nv_Tenchuongtrinh_vn
        Get
            Return _nv_Tenchuongtrinh_vn
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_Tenchuongtrinh_vn = String.Empty
            Else
                _nv_Tenchuongtrinh_vn = value.Trim
            End If
        End Set
    End Property
End Class
