Public Class QLL_THONGTINLUONGEntity 
	Implements IQLL_THONGTINLUONGEntity 

	Private _uId_Thongtinluong AS String
	Private _uId_Nhanvien AS String
	Private _i_Thang AS Int32
	Private _i_Nam AS Int32
	Private _f_Ngaycong AS Double
	Private _f_Ngaynghi AS Double
	Private _f_Tamung AS Double
	Private _f_Tientru AS Double
	Private _f_Tienthuong AS Double
	Private _b_Khoaso AS Boolean
	Private _v_Manhanvien AS String
	Private _nv_Hoten_vn AS String
	Private _nv_Chucvu_vn AS String
	Private _v_Dienthoai AS String

	Public Property uId_Thongtinluong() AS String Implements IQLL_THONGTINLUONGEntity.uId_Thongtinluong
		Get 
			Return _uId_Thongtinluong
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Thongtinluong=String.Empty
			Else 
				_uId_Thongtinluong=value.Trim
			End If
		End Set
	End Property

	Public Property uId_Nhanvien() AS String Implements IQLL_THONGTINLUONGEntity.uId_Nhanvien
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

	Public Property i_Thang() AS Int32 Implements IQLL_THONGTINLUONGEntity.i_Thang
		Get 
			Return _i_Thang
		End Get
		Set(ByVal value As Int32)
			_i_Thang=value
		End Set
	End Property

	Public Property i_Nam() AS Int32 Implements IQLL_THONGTINLUONGEntity.i_Nam
		Get 
			Return _i_Nam
		End Get
		Set(ByVal value As Int32)
			_i_Nam=value
		End Set
	End Property

	Public Property f_Ngaycong() AS Double Implements IQLL_THONGTINLUONGEntity.f_Ngaycong
		Get 
			Return _f_Ngaycong
		End Get
		Set(ByVal value As Double)
			_f_Ngaycong=value
		End Set
	End Property

	Public Property f_Ngaynghi() AS Double Implements IQLL_THONGTINLUONGEntity.f_Ngaynghi
		Get 
			Return _f_Ngaynghi
		End Get
		Set(ByVal value As Double)
			_f_Ngaynghi=value
		End Set
	End Property

	Public Property f_Tamung() AS Double Implements IQLL_THONGTINLUONGEntity.f_Tamung
		Get 
			Return _f_Tamung
		End Get
		Set(ByVal value As Double)
			_f_Tamung=value
		End Set
	End Property

	Public Property f_Tientru() AS Double Implements IQLL_THONGTINLUONGEntity.f_Tientru
		Get 
			Return _f_Tientru
		End Get
		Set(ByVal value As Double)
			_f_Tientru=value
		End Set
	End Property

	Public Property f_Tienthuong() AS Double Implements IQLL_THONGTINLUONGEntity.f_Tienthuong
		Get 
			Return _f_Tienthuong
		End Get
		Set(ByVal value As Double)
			_f_Tienthuong=value
		End Set
	End Property

	Public Property b_Khoaso() AS Boolean Implements IQLL_THONGTINLUONGEntity.b_Khoaso
		Get 
			Return _b_Khoaso
		End Get
		Set(ByVal value As Boolean)
			_b_Khoaso=value
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

	Public Property nv_Chucvu_vn() AS String
		Get 
			Return _nv_Chucvu_vn
		End Get
		Set(ByVal value As String)
			_nv_Chucvu_vn=value
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

End Class
