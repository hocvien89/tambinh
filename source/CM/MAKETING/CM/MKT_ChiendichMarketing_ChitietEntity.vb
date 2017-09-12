Public Class MKT_ChiendichMarketing_ChitietEntity
    Implements IMKT_Chiendichmarketing_Chitiet_Entity
    Private _b_Trangthai As Boolean
    Private _d_Ngaydungthu As Date
    Private _d_Ngayketthuc As Date
    Private _d_Ngaytang As Date
    Private _nv_Phanhoi As String
    Private _uId_ChiendichMarketing As String
    Private _uId_ChiendichMarketing_Chitiet As String
    Private _uId_Khachhang As String

    Public Property b_Trangthai As Boolean Implements IMKT_Chiendichmarketing_Chitiet_Entity.b_Trangthai
        Get
            Return _b_Trangthai
        End Get
        Set(ByVal value As Boolean)
            _b_Trangthai = value
        End Set
    End Property
    Public Property d_Ngaydungthu As Date Implements IMKT_Chiendichmarketing_Chitiet_Entity.d_Ngaydungthu
        Get
            Return Date.Parse(_d_Ngaydungthu).ToShortDateString
        End Get
        Set(ByVal value As Date)
            _d_Ngaydungthu = value
        End Set
    End Property

    Public Property d_Ngayketthuc As Date Implements IMKT_Chiendichmarketing_Chitiet_Entity.d_Ngayketthuc
        Get
            Return Date.Parse(_d_Ngayketthuc).ToShortDateString
        End Get
        Set(ByVal value As Date)
            _d_Ngayketthuc = value
        End Set
    End Property

    Public Property d_Ngaytang As Date Implements IMKT_Chiendichmarketing_Chitiet_Entity.d_Ngaytang
        Get
            Return Date.Parse(_d_Ngaytang).ToShortDateString
        End Get
        Set(ByVal value As Date)
            _d_Ngaytang = value
        End Set
    End Property

    Public Property nv_Phanhoi As String Implements IMKT_Chiendichmarketing_Chitiet_Entity.nv_Phanhoi
        Get
            Return _nv_Phanhoi
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_Phanhoi = String.Empty
            Else
                _nv_Phanhoi = value.Trim
            End If
        End Set
    End Property

    Public Property uId_ChiendichMarketing As String Implements IMKT_Chiendichmarketing_Chitiet_Entity.uId_ChiendichMarketing
        Get
            Return _uId_ChiendichMarketing
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_ChiendichMarketing = String.Empty
            Else
                _uId_ChiendichMarketing = value.Trim
            End If
        End Set
    End Property
    Public Property uId_ChiendichMarketing_Chitiet As String Implements IMKT_Chiendichmarketing_Chitiet_Entity.uId_ChiendichMarketing_Chitiet
        Get
            Return _uId_ChiendichMarketing_Chitiet
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_ChiendichMarketing_Chitiet = String.Empty
            Else
                _uId_ChiendichMarketing_Chitiet = value.Trim
            End If
        End Set
    End Property
    Public Property uId_Khachhang As String Implements IMKT_Chiendichmarketing_Chitiet_Entity.uId_Khachhang
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
End Class
