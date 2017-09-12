Public Class QLL_QUATRINHLUONGEntity 
	Implements IQLL_QUATRINHLUONGEntity 

	Private _uId_QuatrinhLuong AS String
	Private _uId_Nhanvien AS String
	Private _d_Ngayquyetdinh AS DateTime
	Private _d_NgayquyetdinhB AS String
	Private _f_Mucluong_Ngay AS Double
	Private _f_Mucluong_Codinh AS Double
	Private _f_Mucluong_Ngoaigio AS Double
	Private _f_Mucluong_Trachnhiem AS Double
	Private _f_ThueTNCN AS Double
	Private _f_Antrua AS Double
	Private _nv_Ghichu_vn AS String
	Private _nv_Ghichu_en AS String
	Private _f_Songayphep AS Double
	Private _v_Manhanvien AS String
	Private _nv_Hoten_vn AS String
	Private _d_Ngaysinh AS DateTime
	Private _d_NgaysinhB AS String
	Private _nv_Chucvu_vn AS String
	Private _nv_Diachi_vn AS String
	Private _v_Dienthoai AS String
	Private _v_Email AS String

	Public Property uId_QuatrinhLuong() AS String Implements IQLL_QUATRINHLUONGEntity.uId_QuatrinhLuong
		Get 
			Return _uId_QuatrinhLuong
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_QuatrinhLuong=String.Empty
			Else 
				_uId_QuatrinhLuong=value.Trim
			End If
		End Set
	End Property

	Public Property uId_Nhanvien() AS String Implements IQLL_QUATRINHLUONGEntity.uId_Nhanvien
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

	Public Property d_Ngayquyetdinh() AS DateTime Implements IQLL_QUATRINHLUONGEntity.d_Ngayquyetdinh
		Get 
			Return Date.Parse(_d_Ngayquyetdinh).ToShortDateString
		End Get
		Set(ByVal value As DateTime)
			_d_Ngayquyetdinh=value
		End Set
	End Property

	Public Property d_NgayquyetdinhB() AS String
		Get 
			If(_d_Ngayquyetdinh=Nothing) Then
				Return String.Empty
			Else
				Return CStr(Format(_d_Ngayquyetdinh, "dd/MM/yyyy"))
			End If
		End Get
		Set(ByVal value As String)
			_d_Ngayquyetdinh=value
		End Set
	End Property

	Public Property f_Mucluong_Ngay() AS Double Implements IQLL_QUATRINHLUONGEntity.f_Mucluong_Ngay
		Get 
			Return _f_Mucluong_Ngay
		End Get
		Set(ByVal value As Double)
			_f_Mucluong_Ngay=value
		End Set
	End Property

	Public Property f_Mucluong_Codinh() AS Double Implements IQLL_QUATRINHLUONGEntity.f_Mucluong_Codinh
		Get 
			Return _f_Mucluong_Codinh
		End Get
		Set(ByVal value As Double)
			_f_Mucluong_Codinh=value
		End Set
	End Property

	Public Property f_Mucluong_Ngoaigio() AS Double Implements IQLL_QUATRINHLUONGEntity.f_Mucluong_Ngoaigio
		Get 
			Return _f_Mucluong_Ngoaigio
		End Get
		Set(ByVal value As Double)
			_f_Mucluong_Ngoaigio=value
		End Set
	End Property

	Public Property f_Mucluong_Trachnhiem() AS Double Implements IQLL_QUATRINHLUONGEntity.f_Mucluong_Trachnhiem
		Get 
			Return _f_Mucluong_Trachnhiem
		End Get
		Set(ByVal value As Double)
			_f_Mucluong_Trachnhiem=value
		End Set
	End Property

	Public Property f_ThueTNCN() AS Double Implements IQLL_QUATRINHLUONGEntity.f_ThueTNCN
		Get 
			Return _f_ThueTNCN
		End Get
		Set(ByVal value As Double)
			_f_ThueTNCN=value
		End Set
	End Property

	Public Property f_Antrua() AS Double Implements IQLL_QUATRINHLUONGEntity.f_Antrua
		Get 
			Return _f_Antrua
		End Get
		Set(ByVal value As Double)
			_f_Antrua=value
		End Set
	End Property

	Public Property nv_Ghichu_vn() AS String Implements IQLL_QUATRINHLUONGEntity.nv_Ghichu_vn
		Get 
			Return _nv_Ghichu_vn
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Ghichu_vn=String.Empty
			Else 
				_nv_Ghichu_vn=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Ghichu_en() AS String Implements IQLL_QUATRINHLUONGEntity.nv_Ghichu_en
		Get 
			Return _nv_Ghichu_en
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Ghichu_en=String.Empty
			Else 
				_nv_Ghichu_en=value.Trim
			End If
		End Set
	End Property

	Public Property f_Songayphep() AS Double Implements IQLL_QUATRINHLUONGEntity.f_Songayphep
		Get 
			Return _f_Songayphep
		End Get
		Set(ByVal value As Double)
			_f_Songayphep=value
		End Set
	End Property

	Public Property v_Manhanvien() AS String
		Get 
			Return _v_Manhanvien
		End Get
		Set(ByVal value As String)
			_v_Manhanvien=value
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

	Public Property d_Ngaysinh() AS DateTime
		Get 
			Return Date.Parse(_d_Ngaysinh).ToShortDateString
		End Get
		Set(ByVal value As DateTime)
			_d_Ngaysinh=value
		End Set
	End Property

	Public Property nv_Chucvu_vn() AS String
		Get 
			Return _nv_Chucvu_vn
		End Get
		Set(ByVal value As String)
			_nv_Chucvu_vn=value
		End Set
	End Property

	Public Property nv_Diachi_vn() AS String
		Get 
			Return _nv_Diachi_vn
		End Get
		Set(ByVal value As String)
			_nv_Diachi_vn=value
		End Set
	End Property

	Public Property v_Dienthoai() AS String
		Get 
			Return _v_Dienthoai
		End Get
		Set(ByVal value As String)
			_v_Dienthoai=value
		End Set
	End Property

	Public Property v_Email() AS String
		Get 
			Return _v_Email
		End Get
		Set(ByVal value As String)
			_v_Email=value
		End Set
	End Property

End Class
