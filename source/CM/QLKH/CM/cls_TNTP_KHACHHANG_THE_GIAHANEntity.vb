Public Class TNTP_KHACHHANG_THE_GIAHANEntity 
	Implements ITNTP_KHACHHANG_THE_GIAHANEntity 

	Private _uId_The AS String
	Private _d_Giahandenngay AS DateTime
	Private _d_GiahandenngayB AS String
	Private _f_Sotiendongthem AS Double
	Private _nv_Noidung_vn AS String
	Private _nv_Noidung_en AS String
	
	Public Property uId_The() AS String Implements ITNTP_KHACHHANG_THE_GIAHANEntity.uId_The
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

	Public Property d_Giahandenngay() AS DateTime Implements ITNTP_KHACHHANG_THE_GIAHANEntity.d_Giahandenngay
		Get 
			Return Date.Parse(_d_Giahandenngay).ToShortDateString
		End Get
		Set(ByVal value As DateTime)
			_d_Giahandenngay=value
		End Set
	End Property

	Public Property d_GiahandenngayB() AS String
		Get 
			If(_d_Giahandenngay=Nothing) Then
				Return String.Empty
			Else
				Return CStr(Format(_d_Giahandenngay, "dd/MM/yyyy"))
			End If
		End Get
		Set(ByVal value As String)
			_d_Giahandenngay=value
		End Set
	End Property

	Public Property f_Sotiendongthem() AS Double Implements ITNTP_KHACHHANG_THE_GIAHANEntity.f_Sotiendongthem
		Get 
			Return _f_Sotiendongthem
		End Get
		Set(ByVal value As Double)
			_f_Sotiendongthem=value
		End Set
	End Property

	Public Property nv_Noidung_vn() AS String Implements ITNTP_KHACHHANG_THE_GIAHANEntity.nv_Noidung_vn
		Get 
			Return _nv_Noidung_vn
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Noidung_vn=String.Empty
			Else 
				_nv_Noidung_vn=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Noidung_en() AS String Implements ITNTP_KHACHHANG_THE_GIAHANEntity.nv_Noidung_en
		Get 
			Return _nv_Noidung_en
		End Get
		Set(ByVal value As String)
			If(value = Nothing) Then
				_nv_Noidung_en=String.Empty
			Else 
				_nv_Noidung_en=value.Trim
			End If
		End Set
	End Property

End Class
