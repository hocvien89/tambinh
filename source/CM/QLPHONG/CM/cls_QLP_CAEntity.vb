Public Class QLP_CAEntity 
	Implements IQLP_CAEntity 

	Private _uId_Ca AS String
	Private _uId_Khachhang AS String
	Private _uId_Phong AS String
	Private _uId_Dichvu AS String
	Private _uId_Nhanvien AS String
	Private _d_Ngay AS DateTime
	Private _d_NgayB AS String
	Private _v_Thoigian_BD AS String
	Private _v_Thoigian_KT AS String
	Private _uId_Trangthai AS String
    Private _nv_HotenKhachhang_vn As String
	Private _nv_Tenphong_vn AS String
	Private _nv_Tendichvu_vn AS String
    Private _nv_HotenNhanvien_vn As String

	Public Property uId_Ca() AS String Implements IQLP_CAEntity.uId_Ca
		Get 
			Return _uId_Ca
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Ca=String.Empty
			Else 
				_uId_Ca=value.Trim
			End If
		End Set
	End Property

	Public Property uId_Khachhang() AS String Implements IQLP_CAEntity.uId_Khachhang
		Get 
			Return _uId_Khachhang
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Khachhang=String.Empty
			Else 
				_uId_Khachhang=value.Trim
			End If
		End Set
	End Property

	Public Property uId_Phong() AS String Implements IQLP_CAEntity.uId_Phong
		Get 
			Return _uId_Phong
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Phong=String.Empty
			Else 
				_uId_Phong=value.Trim
			End If
		End Set
	End Property

	Public Property uId_Dichvu() AS String Implements IQLP_CAEntity.uId_Dichvu
		Get 
			Return _uId_Dichvu
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Dichvu=String.Empty
			Else 
				_uId_Dichvu=value.Trim
			End If
		End Set
	End Property

	Public Property uId_Nhanvien() AS String Implements IQLP_CAEntity.uId_Nhanvien
		Get 
			Return _uId_Nhanvien
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Nhanvien=String.Empty
			Else 
				_uId_Nhanvien=value.Trim
			End If
		End Set
	End Property

	Public Property d_Ngay() AS DateTime Implements IQLP_CAEntity.d_Ngay
		Get 
			Return Date.Parse(_d_Ngay).ToShortDateString
		End Get
		Set(ByVal value As DateTime)
			_d_Ngay=value
		End Set
	End Property

	Public Property d_NgayB() AS String
		Get 
			If(_d_Ngay=Nothing) Then
				Return String.Empty
			Else
				Return CStr(Format(_d_Ngay, "dd/MM/yyyy"))
			End If
		End Get
		Set(ByVal value As String)
			_d_Ngay=value
		End Set
	End Property

	Public Property v_Thoigian_BD() AS String Implements IQLP_CAEntity.v_Thoigian_BD
		Get 
			Return _v_Thoigian_BD
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_v_Thoigian_BD=String.Empty
			Else 
				_v_Thoigian_BD=value.Trim
			End If
		End Set
	End Property

	Public Property v_Thoigian_KT() AS String Implements IQLP_CAEntity.v_Thoigian_KT
		Get 
			Return _v_Thoigian_KT
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_v_Thoigian_KT=String.Empty
			Else 
				_v_Thoigian_KT=value.Trim
			End If
		End Set
	End Property

	Public Property uId_Trangthai() AS String Implements IQLP_CAEntity.uId_Trangthai
		Get 
			Return _uId_Trangthai
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Trangthai=String.Empty
			Else 
				_uId_Trangthai=value.Trim
			End If
		End Set
	End Property

    Public Property nv_HotenKhachhang_vn() As String
        Get
            Return _nv_HotenKhachhang_vn
        End Get
        Set(ByVal value As String)
            _nv_HotenKhachhang_vn = value
        End Set
    End Property

	Public Property nv_Tenphong_vn() AS String
		Get 
			Return _nv_Tenphong_vn
		End Get
		Set(ByVal value As String)
			_nv_Tenphong_vn=value
		End Set
	End Property

	Public Property nv_Tendichvu_vn() AS String
		Get 
			Return _nv_Tendichvu_vn
		End Get
		Set(ByVal value As String)
			_nv_Tendichvu_vn=value
		End Set
	End Property

    Public Property nv_HotenNhanvien_vn() As String
        Get
            Return _nv_HotenNhanvien_vn
        End Get
        Set(ByVal value As String)
            _nv_HotenNhanvien_vn = value
        End Set
    End Property

End Class
