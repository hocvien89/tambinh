Public Class CRM_DM_KhachhangEntity 
    Implements ICRM_DM_KhachhangEntity

    Private _uId_Khachhang As String
    Private _v_Makhachang As String
    Private _v_BarCode As String
    Private _nv_Hoten_vn As String
    Private _nv_Hoten_en As String
    Private _d_Ngaysinh As DateTime
    Private _d_NgaysinhB As String
    Private _b_Gioitinh As Boolean
    Private _nv_Diachi_vn As String
    Private _nv_Diachi_en As String
    Private _nv_Nguyenquan_vn As String
    Private _nv_Nguyenquan_en As String
    Private _v_DienthoaiDD As String
    Private _v_Dienthoaikhac As String
    Private _v_Email As String
    Private _i_SoCMT As String
    Private _d_NgaycapCMT As String
    Private _nv_Noicap_vn As String
    Private _nv_Noicap_en As String
    Private _d_Ngayden As DateTime
    Private _d_NgaydenB As String
    Private _uId_Nguonden As String
    Private _nv_Ghichu_vn As String
    Private _nv_Ghichu_en As String
    Private _uId_Xaphuong As String
    Private _nv_Hinhanh As String
    Private _uId_Cuahang As String
    Private _uId_Nghenghiep As String
    Private _uId_Nguoigioithieu As String
    Private _Thang As Int16
    Private _Soluong As Int16
    Public Property uId_Khachhang() As String Implements ICRM_DM_KhachhangEntity.uId_Khachhang
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

    Public Property v_Makhachang() As String Implements ICRM_DM_KhachhangEntity.v_Makhachang
        Get
            Return _v_Makhachang
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _v_Makhachang = String.Empty
            Else
                _v_Makhachang = value.Trim
            End If
        End Set
    End Property

    Public Property v_BarCode() As String Implements ICRM_DM_KhachhangEntity.v_BarCode
        Get
            Return _v_BarCode
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _v_BarCode = String.Empty
            Else
                _v_BarCode = value.Trim
            End If
        End Set
    End Property

    Public Property nv_Hoten_vn() As String Implements ICRM_DM_KhachhangEntity.nv_Hoten_vn
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

    Public Property nv_Hoten_en() As String Implements ICRM_DM_KhachhangEntity.nv_Hoten_en
        Get
            Return _nv_Hoten_en
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_Hoten_en = String.Empty
            Else
                _nv_Hoten_en = value.Trim
            End If
        End Set
    End Property

    Public Property d_Ngaysinh() As DateTime Implements ICRM_DM_KhachhangEntity.d_Ngaysinh
        Get
            Return Date.Parse(_d_Ngaysinh).ToShortDateString
        End Get
        Set(ByVal value As DateTime)
            _d_Ngaysinh = value
        End Set
    End Property

    Public Property d_NgaysinhB() As String
        Get
            If (_d_Ngaysinh = Nothing) Then
                Return String.Empty
            Else
                Return CStr(Format(_d_Ngaysinh, "dd/MM/yyyy"))
            End If
        End Get
        Set(ByVal value As String)
            _d_Ngaysinh = value
        End Set
    End Property

    Public Property b_Gioitinh() As Boolean Implements ICRM_DM_KhachhangEntity.b_Gioitinh
        Get
            Return _b_Gioitinh
        End Get
        Set(ByVal value As Boolean)
            _b_Gioitinh = value
        End Set
    End Property

    Public Property nv_Diachi_vn() As String Implements ICRM_DM_KhachhangEntity.nv_Diachi_vn
        Get
            Return _nv_Diachi_vn
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_Diachi_vn = String.Empty
            Else
                _nv_Diachi_vn = value.Trim
            End If
        End Set
    End Property

    Public Property nv_Diachi_en() As String Implements ICRM_DM_KhachhangEntity.nv_Diachi_en
        Get
            Return _nv_Diachi_en
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_Diachi_en = String.Empty
            Else
                _nv_Diachi_en = value.Trim
            End If
        End Set
    End Property

    Public Property nv_Nguyenquan_vn() As String Implements ICRM_DM_KhachhangEntity.nv_Nguyenquan_vn
        Get
            Return _nv_Nguyenquan_vn
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_Nguyenquan_vn = String.Empty
            Else
                _nv_Nguyenquan_vn = value.Trim
            End If
        End Set
    End Property

    Public Property nv_Nguyenquan_en() As String Implements ICRM_DM_KhachhangEntity.nv_Nguyenquan_en
        Get
            Return _nv_Nguyenquan_en
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_Nguyenquan_en = String.Empty
            Else
                _nv_Nguyenquan_en = value.Trim
            End If
        End Set
    End Property

    Public Property v_DienthoaiDD() As String Implements ICRM_DM_KhachhangEntity.v_DienthoaiDD
        Get
            Return _v_DienthoaiDD
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _v_DienthoaiDD = String.Empty
            Else
                _v_DienthoaiDD = value.Trim
            End If
        End Set
    End Property

    Public Property v_Dienthoaikhac() As String Implements ICRM_DM_KhachhangEntity.v_Dienthoaikhac
        Get
            Return _v_Dienthoaikhac
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _v_Dienthoaikhac = String.Empty
            Else
                _v_Dienthoaikhac = value.Trim
            End If
        End Set
    End Property

    Public Property v_Email() As String Implements ICRM_DM_KhachhangEntity.v_Email
        Get
            Return _v_Email
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _v_Email = String.Empty
            Else
                _v_Email = value.Trim
            End If
        End Set
    End Property

    Public Property i_SoCMT() As String Implements ICRM_DM_KhachhangEntity.i_SoCMT
        Get
            Return _i_SoCMT
        End Get
        Set(ByVal value As String)
            _i_SoCMT = value
        End Set
    End Property

    Public Property d_NgaycapCMT() As String Implements ICRM_DM_KhachhangEntity.d_NgaycapCMT
        Get
            Return _d_NgaycapCMT
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _d_NgaycapCMT = String.Empty
            Else
                _d_NgaycapCMT = value.Trim
            End If
        End Set
    End Property

    Public Property nv_Noicap_vn() As String Implements ICRM_DM_KhachhangEntity.nv_Noicap_vn
        Get
            Return _nv_Noicap_vn
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_Noicap_vn = String.Empty
            Else
                _nv_Noicap_vn = value.Trim
            End If
        End Set
    End Property

    Public Property nv_Noicap_en() As String Implements ICRM_DM_KhachhangEntity.nv_Noicap_en
        Get
            Return _nv_Noicap_en
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_Noicap_en = String.Empty
            Else
                _nv_Noicap_en = value.Trim
            End If
        End Set
    End Property

    Public Property d_Ngayden() As DateTime Implements ICRM_DM_KhachhangEntity.d_Ngayden
        Get
            Return Date.Parse(_d_Ngayden).ToShortDateString
        End Get
        Set(ByVal value As DateTime)
            _d_Ngayden = value
        End Set
    End Property

    Public Property d_NgaydenB() As String
        Get
            If (_d_Ngayden = Nothing) Then
                Return String.Empty
            Else
                Return CStr(Format(_d_Ngayden, "dd/MM/yyyy"))
            End If
        End Get
        Set(ByVal value As String)
            _d_Ngayden = value
        End Set
    End Property

    Public Property uId_Nguonden() As String Implements ICRM_DM_KhachhangEntity.uId_Nguonden
        Get
            Return _uId_Nguonden
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Nguonden = String.Empty
            Else
                _uId_Nguonden = value.Trim
            End If
        End Set
    End Property

    Public Property uId_Nghenghiep() As String Implements ICRM_DM_KhachhangEntity.uId_Nghenghiep
        Get
            Return _uId_Nghenghiep
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Nghenghiep = String.Empty
            Else
                _uId_Nghenghiep = value.Trim
            End If
        End Set
    End Property

    Public Property nv_Ghichu_vn() As String Implements ICRM_DM_KhachhangEntity.nv_Ghichu_vn
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

    Public Property nv_Ghichu_en() As String Implements ICRM_DM_KhachhangEntity.nv_Ghichu_en
        Get
            Return _nv_Ghichu_en
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_Ghichu_en = String.Empty
            Else
                _nv_Ghichu_en = value.Trim
            End If
        End Set
    End Property

    Public Property uId_Xaphuong() As String Implements ICRM_DM_KhachhangEntity.uId_Xaphuong
        Get
            Return _uId_Xaphuong
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Xaphuong = String.Empty
            Else
                _uId_Xaphuong = value.Trim
            End If
        End Set
    End Property

    Public Property nv_Hinhanh() As String Implements ICRM_DM_KhachhangEntity.nv_Hinhanh
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

    Public Property uId_Cuahang() As String Implements ICRM_DM_KhachhangEntity.uId_Cuahang
        Get
            Return _uId_Cuahang
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Cuahang = Nothing
            Else
                _uId_Cuahang = value.Trim
            End If
        End Set
    End Property

    Public Property uId_Nguoigioithieu() As String Implements ICRM_DM_KhachhangEntity.uId_Nguoigioithieu
        Get
            Return _uId_Nguoigioithieu
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Nguoigioithieu = Nothing
            Else
                _uId_Nguoigioithieu = value.Trim
            End If
        End Set
    End Property

    Public Property Soluong As Short Implements ICRM_DM_KhachhangEntity.Soluong
        Get
            Return _Soluong
        End Get
        Set(ByVal value As Short)
            _Soluong = value
        End Set
    End Property
    Public Property Thang As Short Implements ICRM_DM_KhachhangEntity.Thang
        Get
            Return _Thang
        End Get
        Set(ByVal value As Short)
            _Thang = value
        End Set
    End Property
End Class
