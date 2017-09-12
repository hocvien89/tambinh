Public Class DMQuyDoiDonViEntity
    Implements IDMQuyDoiDonViEntity

    Private _MaVatTu As String
    Private _MaDonVi1 As String
    Private _MaDonVi21 As String
    Private _MaDonVi32 As String
    Private _SoLuong21 As Double
    Private _SoLuong32 As Double
    Private _DonGiaDV11 As Double
    Private _DonGiaDV21 As Double
    Private _DonGiaDV32 As Double

    Public Property MaVatTu() As String Implements IDMQuyDoiDonViEntity.MaVatTu
        Get
            Return _MaVatTu
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _MaVatTu = String.Empty
            Else
                _MaVatTu = value.Trim
            End If
        End Set
    End Property

    Public Property MaDonVi1() As String Implements IDMQuyDoiDonViEntity.MaDonVi1
        Get
            Return _MaDonVi1
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _MaDonVi1 = String.Empty
            Else
                _MaDonVi1 = value.Trim
            End If
        End Set
    End Property

    Public Property MaDonVi21() As String Implements IDMQuyDoiDonViEntity.MaDonVi21
        Get
            Return _MaDonVi21
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _MaDonVi21 = String.Empty
            Else
                _MaDonVi21 = value.Trim
            End If
        End Set
    End Property

    Public Property MaDonVi32() As String Implements IDMQuyDoiDonViEntity.MaDonVi32
        Get
            Return _MaDonVi32
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _MaDonVi32 = String.Empty
            Else
                _MaDonVi32 = value.Trim
            End If
        End Set
    End Property

    Public Property SoLuong21() As Double Implements IDMQuyDoiDonViEntity.SoLuong21
        Get
            Return _SoLuong21
        End Get
        Set(ByVal value As Double)
            _SoLuong21 = value
        End Set
    End Property

    Public Property SoLuong32() As Double Implements IDMQuyDoiDonViEntity.SoLuong32
        Get
            Return _SoLuong32
        End Get
        Set(ByVal value As Double)
            _SoLuong32 = value
        End Set
    End Property

    Public Property DonGiaDV11() As Double Implements IDMQuyDoiDonViEntity.DonGiaDV11
        Get
            Return _DonGiaDV11
        End Get
        Set(ByVal value As Double)
            _DonGiaDV11 = value
        End Set
    End Property

    Public Property DonGiaDV21() As Double Implements IDMQuyDoiDonViEntity.DonGiaDV21
        Get
            Return _DonGiaDV21
        End Get
        Set(ByVal value As Double)
            _DonGiaDV21 = value
        End Set
    End Property

    Public Property DonGiaDV32() As Double Implements IDMQuyDoiDonViEntity.DonGiaDV32
        Get
            Return _DonGiaDV32
        End Get
        Set(ByVal value As Double)
            _DonGiaDV32 = value
        End Set
    End Property

End Class
