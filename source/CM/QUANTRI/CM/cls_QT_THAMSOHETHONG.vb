Public Class cls_QT_THAMSOHETHONG
    Implements iCls_QT_THAMSOHETHONG


    Private _uId_Thamsohethong As String
    Private _v_Tenbien As String
    Private _v_Giatri As String
    Private _f_Giatri As Double
    Private _nv_Mota_vn As String
    Private _i_STT As Integer
    Private _b_Hoatdong As Boolean


    Public Property uId_Thamsohethong() As String Implements iCls_QT_THAMSOHETHONG.uId_Thamsohethong
        Get
            Return _uId_Thamsohethong
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Thamsohethong = String.Empty
            Else
                _uId_Thamsohethong = value.Trim
            End If
        End Set
    End Property
    Public Property v_Giatri() As String Implements iCls_QT_THAMSOHETHONG.v_Giatri
        Get
            Return _v_Giatri
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _v_Giatri = String.Empty
            Else
                _v_Giatri = value.Trim
            End If
        End Set
    End Property

    Public Property f_Giatri() As Double Implements iCls_QT_THAMSOHETHONG.f_Giatri
        Get
            Return _f_Giatri
        End Get
        Set(ByVal value As Double)
            If (value = Nothing) Then
                _f_Giatri = 0
            Else
                _f_Giatri = value
            End If
        End Set
    End Property

    Public Property v_Tenbien() As String Implements iCls_QT_THAMSOHETHONG.v_Tenbien
        Get
            Return _v_Tenbien
        End Get
        Set(ByVal value As String)
            _v_Tenbien = value
        End Set
    End Property

    Public Property i_STT() As Integer Implements iCls_QT_THAMSOHETHONG.i_STT
        Get
            Return _i_STT
        End Get
        Set(value As Integer)
            _i_STT = value
        End Set
    End Property
    Public Property nv_Mota_vn() As String Implements iCls_QT_THAMSOHETHONG.nv_Mota_vn
        Get
            Return _nv_Mota_vn
        End Get
        Set(value As String)
            _nv_Mota_vn = value
        End Set
    End Property

    Public Property b_Hoatdong() As Boolean Implements iCls_QT_THAMSOHETHONG.b_Hoatdong
        Get
            Return _b_Hoatdong
        End Get
        Set(value As Boolean)
            _b_Hoatdong = value
        End Set
    End Property
End Class
