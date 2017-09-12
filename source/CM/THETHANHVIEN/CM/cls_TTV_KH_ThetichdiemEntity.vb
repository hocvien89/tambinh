Public Class cls_TTV_KH_ThetichdiemEntity
    Implements icls_TTV_KH_ThetichdiemEntity
    Private _b_Trangthai As Boolean
    Private _f_Diemhientai As Double
    Private _f_Tongtichluy As Double
    Private _uId_KH_The As String
    Private _uId_Khachhang As String
    Private _uId_Thetichdiem As String
    Private _b_Isdelete As Boolean
    Private _v_Mathekhachhang As String
    Private _d_Ngaycap As DateTime
    Private _d_Ngayhethan As DateTime

    Public Property b_Trangthai() As Boolean Implements icls_TTV_KH_ThetichdiemEntity.b_Trangthai
        Get
            Return _b_Trangthai
        End Get
        Set(value As Boolean)
            _b_Trangthai = value
        End Set
    End Property
    Public Property f_Diemhientai() As Double Implements icls_TTV_KH_ThetichdiemEntity.f_Diemhientai
        Get
            Return _f_Diemhientai
        End Get
        Set(value As Double)
            _f_Diemhientai = value
        End Set
    End Property
    Public Property f_Tongtichluy() As Double Implements icls_TTV_KH_ThetichdiemEntity.f_Tongtichluy
        Get
            Return _f_Tongtichluy
        End Get
        Set(value As Double)
            _f_Tongtichluy = value
        End Set
    End Property
    Public Property uId_KH_The() As String Implements icls_TTV_KH_ThetichdiemEntity.uId_KH_The
        Get
            Return _uId_KH_The
        End Get
        Set(value As String)
            _uId_KH_The = value
        End Set
    End Property
    Public Property uId_Khachhang() As String Implements icls_TTV_KH_ThetichdiemEntity.uId_Khachhang
        Get
            Return _uId_Khachhang
        End Get
        Set(value As String)
            _uId_Khachhang = value
        End Set
    End Property

    Public Property uId_Thetichdiem() As String Implements icls_TTV_KH_ThetichdiemEntity.uId_Thetichdiem
        Get
            Return _uId_Thetichdiem
        End Get
        Set(value As String)
            _uId_Thetichdiem = value
        End Set
    End Property

    Public Property b_Isdelete() As Boolean Implements icls_TTV_KH_ThetichdiemEntity.b_Isdelete
        Get
            Return _b_Isdelete
        End Get
        Set(value As Boolean)
            _b_Isdelete = value
        End Set
    End Property
    Public Property v_Mathekhachhang() As String Implements icls_TTV_KH_ThetichdiemEntity.v_Mathekhachhang
        Get
            Return _v_Mathekhachhang
        End Get
        Set(value As String)
            _v_Mathekhachhang = value
        End Set
    End Property
    Public Property d_Ngaycap() As Date Implements icls_TTV_KH_ThetichdiemEntity.d_Ngaycap
        Get
            Return _d_Ngaycap
        End Get
        Set(value As Date)
            _d_Ngaycap = value
        End Set
    End Property
    Public Property d_Ngayhethan() As Date Implements icls_TTV_KH_ThetichdiemEntity.d_Ngayhethan
        Get
            Return _d_Ngayhethan
        End Get
        Set(value As Date)
            _d_Ngayhethan = value
        End Set
    End Property
End Class
