Public Class cls_DM_ThetichdiemEntity
    Implements icls_TTV_DM_ThetichdiemEntity
    Private _f_Diemkichhoat As Double
    Private _nv_Tenthetichdiem As String
    Private _uId_Cuahang As String
    Private _uId_Thetichdiem As String
    Private _v_Mathetichdiem As String
    Private _f_Sotiendoi As Double
    Private _i_Sotiendoi As Integer
    Private _f_Uutien As Double

    Public Property f_Diemkichhoat() As Double Implements icls_TTV_DM_ThetichdiemEntity.f_Diemkichhoat
        Get
            Return _f_Diemkichhoat
        End Get
        Set(value As Double)
            _f_Diemkichhoat = value
        End Set
    End Property
    Public Property nv_Tenthetichdiem() As String Implements icls_TTV_DM_ThetichdiemEntity.nv_Tenthetichdiem
        Get
            Return _nv_Tenthetichdiem
        End Get
        Set(value As String)
            _nv_Tenthetichdiem = value
        End Set
    End Property
    Public Property uId_Cuahang() As String Implements icls_TTV_DM_ThetichdiemEntity.uId_Cuahang
        Get
            Return _uId_Cuahang
        End Get
        Set(value As String)
            _uId_Cuahang = value
        End Set
    End Property
    Public Property uId_Thetichdiem() As String Implements icls_TTV_DM_ThetichdiemEntity.uId_Thetichdiem
        Get
            Return _uId_Thetichdiem
        End Get
        Set(value As String)
            _uId_Thetichdiem = value
        End Set
    End Property
    Public Property v_Mathetichdiem() As String Implements icls_TTV_DM_ThetichdiemEntity.v_Mathetichdiem
        Get
            Return _v_Mathetichdiem
        End Get
        Set(value As String)
            _v_Mathetichdiem = value
        End Set
    End Property

    Public Property i_Sodiemdoi() As Integer Implements icls_TTV_DM_ThetichdiemEntity.i_Sodiemdoi
        Get
            Return _i_Sotiendoi
        End Get
        Set(value As Integer)
            _i_Sotiendoi = value
        End Set
    End Property

    Public Property f_Sotiendoi() As Double Implements icls_TTV_DM_ThetichdiemEntity.f_Sotiendoi
        Get
            Return _f_Sotiendoi
        End Get
        Set(value As Double)
            _f_Sotiendoi = value
        End Set
    End Property

    Public Property f_Uutien() As Double Implements icls_TTV_DM_ThetichdiemEntity.f_Uutien
        Get
            Return _f_Uutien
        End Get
        Set(value As Double)
            _f_Uutien = value
        End Set
    End Property
End Class
