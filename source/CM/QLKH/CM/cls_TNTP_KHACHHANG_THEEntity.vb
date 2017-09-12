Public Class TNTP_KHACHHANG_THEEntity 
	Implements ITNTP_KHACHHANG_THEEntity 

	Private _uId_The AS String
	Private _uId_Khachhang AS String
	Private _uId_Loaithe AS String
	Private _uId_Cuahang AS String
	Private _v_Mathe AS String
	Private _d_Ngaymua AS DateTime
	Private _d_NgaymuaB AS String
	Private _f_Sotien AS Double
	Private _d_Ngaybatdau AS DateTime
	Private _d_NgaybatdauB AS String
	Private _d_Ngaykethuc AS DateTime
	Private _d_NgaykethucB AS String
	Private _uId_Trangthai AS String
	Private _nv_Tencuahang_vn AS String
	Private _nv_Hoten_vn AS String
	Private _nv_Tenloaithe_vn AS String
	Private _nv_Tentrangthai_vn AS String

	Public Property uId_The() AS String Implements ITNTP_KHACHHANG_THEEntity.uId_The
		Get 
			Return _uId_The
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_The=String.Empty
			Else 
				_uId_The=value.Trim
			End If
		End Set
	End Property

	Public Property uId_Khachhang() AS String Implements ITNTP_KHACHHANG_THEEntity.uId_Khachhang
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

	Public Property uId_Loaithe() AS String Implements ITNTP_KHACHHANG_THEEntity.uId_Loaithe
		Get 
			Return _uId_Loaithe
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Loaithe=String.Empty
			Else 
				_uId_Loaithe=value.Trim
			End If
		End Set
	End Property

	Public Property uId_Cuahang() AS String Implements ITNTP_KHACHHANG_THEEntity.uId_Cuahang
		Get 
			Return _uId_Cuahang
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Cuahang=String.Empty
			Else 
				_uId_Cuahang=value.Trim
			End If
		End Set
	End Property

	Public Property v_Mathe() AS String Implements ITNTP_KHACHHANG_THEEntity.v_Mathe
		Get 
			Return _v_Mathe
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_v_Mathe=String.Empty
			Else 
				_v_Mathe=value.Trim
			End If
		End Set
	End Property

	Public Property d_Ngaymua() AS DateTime Implements ITNTP_KHACHHANG_THEEntity.d_Ngaymua
		Get 
			Return Date.Parse(_d_Ngaymua).ToShortDateString
		End Get
		Set(ByVal value As DateTime)
			_d_Ngaymua=value
		End Set
	End Property

	Public Property d_NgaymuaB() AS String
		Get 
			If(_d_Ngaymua=Nothing) Then
				Return String.Empty
			Else
				Return CStr(Format(_d_Ngaymua, "dd/MM/yyyy"))
			End If
		End Get
		Set(ByVal value As String)
			_d_Ngaymua=value
		End Set
	End Property

	Public Property f_Sotien() AS Double Implements ITNTP_KHACHHANG_THEEntity.f_Sotien
		Get 
			Return _f_Sotien
		End Get
		Set(ByVal value As Double)
			_f_Sotien=value
		End Set
	End Property

	Public Property d_Ngaybatdau() AS DateTime Implements ITNTP_KHACHHANG_THEEntity.d_Ngaybatdau
		Get 
			Return Date.Parse(_d_Ngaybatdau).ToShortDateString
		End Get
		Set(ByVal value As DateTime)
			_d_Ngaybatdau=value
		End Set
	End Property

	Public Property d_NgaybatdauB() AS String
		Get 
			If(_d_Ngaybatdau=Nothing) Then
				Return String.Empty
			Else
				Return CStr(Format(_d_Ngaybatdau, "dd/MM/yyyy"))
			End If
		End Get
		Set(ByVal value As String)
			_d_Ngaybatdau=value
		End Set
	End Property

	Public Property d_Ngaykethuc() AS DateTime Implements ITNTP_KHACHHANG_THEEntity.d_Ngaykethuc
		Get 
			Return Date.Parse(_d_Ngaykethuc).ToShortDateString
		End Get
		Set(ByVal value As DateTime)
			_d_Ngaykethuc=value
		End Set
	End Property

	Public Property d_NgaykethucB() AS String
		Get 
			If(_d_Ngaykethuc=Nothing) Then
				Return String.Empty
			Else
				Return CStr(Format(_d_Ngaykethuc, "dd/MM/yyyy"))
			End If
		End Get
		Set(ByVal value As String)
			_d_Ngaykethuc=value
		End Set
	End Property

	Public Property uId_Trangthai() AS String Implements ITNTP_KHACHHANG_THEEntity.uId_Trangthai
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

	Public Property nv_Tencuahang_vn() AS String
		Get 
			Return _nv_Tencuahang_vn
		End Get
		Set(ByVal value As String)
			_nv_Tencuahang_vn=value
		End Set
	End Property

	Public Property nv_Hoten_vn() AS String
		Get 
			Return _nv_Hoten_vn
		End Get
		Set(ByVal value As String)
			_nv_Hoten_vn=value
		End Set
	End Property

	Public Property nv_Tenloaithe_vn() AS String
		Get 
			Return _nv_Tenloaithe_vn
		End Get
		Set(ByVal value As String)
			_nv_Tenloaithe_vn=value
		End Set
	End Property

	Public Property nv_Tentrangthai_vn() AS String
		Get 
			Return _nv_Tentrangthai_vn
		End Get
		Set(ByVal value As String)
			_nv_Tentrangthai_vn=value
		End Set
	End Property

End Class
