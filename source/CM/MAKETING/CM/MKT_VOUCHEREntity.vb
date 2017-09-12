Public Class MKT_VOUCHEREntity
    Implements IMKT_VOUCHER
    Private _b_Trangthai As Boolean
    Private _d_Ngayketthuc As Date
    Private _d_Ngayphat As Date
    Private _d_Ngaythu As Date
    Private _nv_Hoten_vn As String
    Private _uId_Khachhang As String
    Private _uId_Loaivoucher As String

    Private _uId_voucher As String
    Private _v_Maloaivoucher As String

    Public Property b_Trangthai As Boolean Implements IMKT_VOUCHER.b_Trangthai
        Get
            Return _b_Trangthai
        End Get
        Set(ByVal value As Boolean)
            _b_Trangthai = value
        End Set
    End Property

    Public Property d_Ngaykethuc As Date Implements IMKT_VOUCHER.d_Ngaykethuc
        Get
            Return Date.Parse(_d_Ngayketthuc).ToShortDateString
        End Get
        Set(ByVal value As Date)
            _d_Ngayketthuc = value
        End Set
    End Property

    Public Property d_Ngayphat As Date Implements IMKT_VOUCHER.d_Ngayphat
        Get
            Return Date.Parse(_d_Ngayphat).ToShortDateString
        End Get
        Set(ByVal value As Date)
            _d_Ngayphat = value
        End Set
    End Property

    Public Property d_Ngaythu As Date Implements IMKT_VOUCHER.d_Ngaythu
        Get
            Return Date.Parse(_d_Ngaythu).ToShortDateString
        End Get
        Set(ByVal value As Date)
            _d_Ngaythu = value
        End Set
    End Property

    Public Property nv_Hoten_vn As String Implements IMKT_VOUCHER.nv_Hoten_vn
        Get
            Return _nv_Hoten_vn
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_Hoten_vn = String.Empty
            Else
                _nv_Hoten_vn = value.Trim
            End If
        End Set
    End Property

    Public Property uId_Khachhang As String Implements IMKT_VOUCHER.uId_Khachhang
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

    Public Property uId_Loaivoucher As String Implements IMKT_VOUCHER.uId_Loaivoucher
        Get
            Return _uId_Loaivoucher
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Loaivoucher = String.Empty
            Else
                _uId_Loaivoucher = value.Trim
            End If
        End Set
    End Property

    Public Property uId_voucher As String Implements IMKT_VOUCHER.uId_voucher
        Get
            Return _uId_voucher
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_voucher = String.Empty
            Else
                _uId_voucher = value.Trim
            End If
        End Set
    End Property

    Public Property v_Maloaivoucher As String Implements IMKT_VOUCHER.v_Maloaivoucher
        Get
            Return _v_Maloaivoucher
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _v_Maloaivoucher = String.Empty
            Else
                _v_Maloaivoucher = value.Trim
            End If
        End Set
    End Property
End Class
