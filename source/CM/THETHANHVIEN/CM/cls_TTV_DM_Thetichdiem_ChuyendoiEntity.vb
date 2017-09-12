Public Class cls_TTV_DM_Thetichdiem_ChuyendoiEntity
    Implements icls_TTV_DM_Thetichdiem_ChuyendoiEntity

    Private _uId_TTDChuyendoi As String
    Private _v_Machuyendoi As String
    Private _f_Giatri As Double
    Private _i_Diem As Integer
    Private _uId_Thetichdiem As String
    Private _nv_Tenchuyendoi As String
    Private _b_Trangthai As Boolean

    Public Property f_Giatri() As Double Implements icls_TTV_DM_Thetichdiem_ChuyendoiEntity.f_Giatri
        Get
            Return _f_Giatri
        End Get
        Set(value As Double)
            _f_Giatri = value
        End Set
    End Property
    Public Property i_Diem() As Integer Implements icls_TTV_DM_Thetichdiem_ChuyendoiEntity.i_Diem
        Get
            Return _i_Diem
        End Get
        Set(value As Integer)
            _i_Diem = value
        End Set
    End Property
    Public Property uId_Thetichdiem() As String Implements icls_TTV_DM_Thetichdiem_ChuyendoiEntity.uId_Thetichdiem
        Get
            Return _uId_Thetichdiem
        End Get
        Set(value As String)
            _uId_Thetichdiem = value
        End Set
    End Property
    Public Property uId_TTDChuyendoi() As String Implements icls_TTV_DM_Thetichdiem_ChuyendoiEntity.uId_TTDChuyendoi
        Get
            Return _uId_TTDChuyendoi
        End Get
        Set(value As String)
            _uId_TTDChuyendoi = value
        End Set
    End Property
    Public Property v_Machuyendoi() As String Implements icls_TTV_DM_Thetichdiem_ChuyendoiEntity.v_Machuyendoi
        Get
            Return _v_Machuyendoi
        End Get
        Set(value As String)
            _v_Machuyendoi = value
        End Set
    End Property

    Public Property nv_Tenchuyendoi() As String Implements icls_TTV_DM_Thetichdiem_ChuyendoiEntity.nv_Tenchuyendoi
        Get
            Return _nv_Tenchuyendoi
        End Get
        Set(value As String)
            _nv_Tenchuyendoi = value
        End Set
    End Property

    Public Property b_Trangthai() As Boolean Implements icls_TTV_DM_Thetichdiem_ChuyendoiEntity.b_Trangthai
        Get
            Return _b_Trangthai
        End Get
        Set(value As Boolean)
            _b_Trangthai = value
        End Set
    End Property
End Class
