Public Class TNTP_QT_DieutriEntity 
    Implements ITNTP_QT_DieutriEntity

    Private _uId_QT_Dieutri As String
    Private _uId_Phieudichvu_Chitiet As String
    Private _d_Ngaydieutri As DateTime
    Private _d_NgaydieutriB As String
    Private _nv_Noidung As String
    Private _nv_Ghichu As String
    Private _uId_Trangthai As String
    Private _i_Lanthu As Int32
    Private _nv_Hinhanh As String
    Private _uId_Nhanvien As String
    Private _f_Lephi_DT As Double
    Private _f_SuatDT As Double
    Private _b_yeucau As Boolean
    Private _nv_Ghichu_vn As Double
    Private _nv_Ghichu_cc_vn As Double
    Private _b_Tieuhao As Boolean
    Private _f_HHNV3 As Double
    Private _f_HHNV4 As Double
    Private _uId_Nhanvien3 As String
    Private _uId_NHanvien4 As String
    Public Property uId_QT_Dieutri() As String Implements ITNTP_QT_DieutriEntity.uId_QT_Dieutri
        Get
            Return _uId_QT_Dieutri
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_QT_Dieutri = String.Empty
            Else
                _uId_QT_Dieutri = value.Trim
            End If
        End Set
    End Property
    Public Property b_yeucau() As Boolean Implements ITNTP_QT_DieutriEntity.b_yeucau
        Get
            Return _b_yeucau
        End Get
        Set(ByVal value As Boolean)
            If (value = Nothing) Then
                _b_yeucau = False
            Else
                _b_yeucau = value
            End If
        End Set
    End Property

    Public Property uId_Phieudichvu_Chitiet() As String Implements ITNTP_QT_DieutriEntity.uId_Phieudichvu_Chitiet
        Get
            Return _uId_Phieudichvu_Chitiet
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Phieudichvu_Chitiet = String.Empty
            Else
                _uId_Phieudichvu_Chitiet = value.Trim
            End If
        End Set
    End Property

    Public Property d_Ngaydieutri() As DateTime Implements ITNTP_QT_DieutriEntity.d_Ngaydieutri
        Get
            Return Date.Parse(_d_Ngaydieutri).ToShortDateString
        End Get
        Set(ByVal value As DateTime)
            _d_Ngaydieutri = value
        End Set
    End Property

    Public Property d_NgaydieutriB() As String
        Get
            If (_d_Ngaydieutri = Nothing) Then
                Return String.Empty
            Else
                Return CStr(Format(_d_Ngaydieutri, "dd/MM/yyyy"))
            End If
        End Get
        Set(ByVal value As String)
            _d_Ngaydieutri = value
        End Set
    End Property

    Public Property nv_Noidung() As String Implements ITNTP_QT_DieutriEntity.nv_Noidung
        Get
            Return _nv_Noidung
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_Noidung = String.Empty
            Else
                _nv_Noidung = value.Trim
            End If
        End Set
    End Property

    Public Property nv_Ghichu() As String Implements ITNTP_QT_DieutriEntity.nv_Ghichu
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

    Public Property uId_Trangthai() As String Implements ITNTP_QT_DieutriEntity.uId_Trangthai
        Get
            Return _uId_Trangthai
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Trangthai = String.Empty
            Else
                _uId_Trangthai = value.Trim
            End If
        End Set
    End Property

    Public Property i_Lanthu() As Int32 Implements ITNTP_QT_DieutriEntity.i_Lanthu
        Get
            Return _i_Lanthu
        End Get
        Set(ByVal value As Int32)
            _i_Lanthu = value
        End Set
    End Property

    Public Property nv_Hinhanh() As String Implements ITNTP_QT_DieutriEntity.nv_Hinhanh
        Get
            Return _nv_Hinhanh
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_Hinhanh = String.Empty
            Else
                _nv_Hinhanh = value.Trim
            End If
        End Set
    End Property

    Public Property uId_Nhanvien() As String Implements ITNTP_QT_DieutriEntity.uId_Nhanvien
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

    Public Property f_Lephi_DT() As Double Implements ITNTP_QT_DieutriEntity.f_Lephi_DT
        Get
            Return _f_Lephi_DT
        End Get
        Set(ByVal value As Double)
            _f_Lephi_DT = value
        End Set
    End Property

    Public Property f_SuatDT() As Double Implements ITNTP_QT_DieutriEntity.f_SuatDT
        Get
            Return _f_SuatDT
        End Get
        Set(ByVal value As Double)
            _f_SuatDT = value
        End Set
    End Property

    Public Property nv_Ghichu_cc_vn As Double Implements ITNTP_QT_DieutriEntity.nv_Ghichu_cc_vn
         Get
            Return _nv_Ghichu_cc_vn
        End Get
        Set(ByVal value As Double)
            _nv_Ghichu_cc_vn = value
        End Set
    End Property

    Public Property nv_Ghichu_vn As Double Implements ITNTP_QT_DieutriEntity.nv_Ghichu_vn
        Get
            Return _nv_Ghichu_vn
        End Get
        Set(ByVal value As Double)
            _nv_Ghichu_vn = value
        End Set
    End Property

    Public Property b_Tieuhao As Boolean Implements ITNTP_QT_DieutriEntity.b_Tieuhao
        Get
            Return _b_Tieuhao
        End Get
        Set(ByVal value As Boolean)
            If (value = Nothing) Then
                _b_Tieuhao = False
            Else
                _b_Tieuhao = value
            End If
        End Set
    End Property

    Public Property f_HHNV3 As Double Implements ITNTP_QT_DieutriEntity.f_HHNV3
        Get
            Return _f_HHNV3
        End Get
        Set(ByVal value As Double)
            _f_HHNV3 = value
        End Set
    End Property
    Public Property f_HHNV4 As Double Implements ITNTP_QT_DieutriEntity.f_HHNV4
        Get
            Return _f_HHNV4
        End Get
        Set(ByVal value As Double)
            _f_HHNV4 = value
        End Set
    End Property

    Public Property uId_Nhanvien3 As String Implements ITNTP_QT_DieutriEntity.uId_Nhanvien3
        Get
            Return _uId_Nhanvien3
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Nhanvien3 = String.Empty
            Else
                _uId_Nhanvien3 = value.Trim
            End If
        End Set
    End Property

    Public Property uId_Nhanvien4 As String Implements ITNTP_QT_DieutriEntity.uId_Nhanvien4
        Get
            Return _uId_NHanvien4
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_NHanvien4 = String.Empty
            Else
                _uId_NHanvien4 = value.Trim
            End If
        End Set
    End Property
End Class
