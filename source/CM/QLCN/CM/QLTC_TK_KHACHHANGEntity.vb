Public Class QLTC_TK_KHACHHANGEntity 
	Implements IQLTC_TK_KHACHHANGEntity 

	Private _uId_TK_Khachhang AS String
	Private _uId_Khachhang AS String
	Private _d_Thoigian AS DateTime
	Private _d_ThoigianB AS String
	Private _f_Sotien AS Double
	
	Public Property uId_TK_Khachhang() AS String Implements IQLTC_TK_KHACHHANGEntity.uId_TK_Khachhang
		Get 
			Return _uId_TK_Khachhang
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_TK_Khachhang=String.Empty
			Else 
				_uId_TK_Khachhang=value.Trim
			End If
		End Set
	End Property

	Public Property uId_Khachhang() AS String Implements IQLTC_TK_KHACHHANGEntity.uId_Khachhang
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

	Public Property d_Thoigian() AS DateTime Implements IQLTC_TK_KHACHHANGEntity.d_Thoigian
		Get 
			Return Date.Parse(_d_Thoigian).ToShortDateString
		End Get
		Set(ByVal value As DateTime)
			_d_Thoigian=value
		End Set
	End Property

	Public Property d_ThoigianB() AS String
		Get 
			If(_d_Thoigian=Nothing) Then
				Return String.Empty
			Else
				Return CStr(Format(_d_Thoigian, "dd/MM/yyyy"))
			End If
		End Get
		Set(ByVal value As String)
			_d_Thoigian=value
		End Set
	End Property

	Public Property f_Sotien() AS Double Implements IQLTC_TK_KHACHHANGEntity.f_Sotien
		Get 
			Return _f_Sotien
		End Get
		Set(ByVal value As Double)
			_f_Sotien=value
		End Set
	End Property

End Class
