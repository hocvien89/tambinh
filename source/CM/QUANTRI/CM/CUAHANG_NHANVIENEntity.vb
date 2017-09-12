Public Class CUAHANG_NHANVIENEntity 
	Implements ICUAHANG_NHANVIENEntity 

	Private _uId_Cuahang_Nhanvien AS String
	Private _uId_Cuahang AS String
	Private _uId_Nhanvien AS String
	Private _d_Ngay AS DateTime
	Private _d_NgayB AS String
	Private _nv_Lydo_vn AS String
	Private _nv_Lydo_en AS String
	
	Public Property uId_Cuahang_Nhanvien() AS String Implements ICUAHANG_NHANVIENEntity.uId_Cuahang_Nhanvien
		Get 
			Return _uId_Cuahang_Nhanvien
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Cuahang_Nhanvien=String.Empty
			Else 
				_uId_Cuahang_Nhanvien=value.Trim
			End If
		End Set
	End Property

	Public Property uId_Cuahang() AS String Implements ICUAHANG_NHANVIENEntity.uId_Cuahang
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

	Public Property uId_Nhanvien() AS String Implements ICUAHANG_NHANVIENEntity.uId_Nhanvien
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

	Public Property d_Ngay() AS DateTime Implements ICUAHANG_NHANVIENEntity.d_Ngay
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

	Public Property nv_Lydo_vn() AS String Implements ICUAHANG_NHANVIENEntity.nv_Lydo_vn
		Get 
			Return _nv_Lydo_vn
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Lydo_vn=String.Empty
			Else 
				_nv_Lydo_vn=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Lydo_en() AS String Implements ICUAHANG_NHANVIENEntity.nv_Lydo_en
		Get 
			Return _nv_Lydo_en
		End Get
		Set(ByVal value As String)
			If(value = Nothing) Then
				_nv_Lydo_en=String.Empty
			Else 
				_nv_Lydo_en=value.Trim
			End If
		End Set
	End Property

End Class
