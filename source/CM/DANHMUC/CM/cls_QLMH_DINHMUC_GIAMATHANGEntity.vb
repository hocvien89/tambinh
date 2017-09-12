Public Class QLMH_DINHMUC_GIAMATHANGEntity 
	Implements IQLMH_DINHMUC_GIAMATHANGEntity 

	Private _uId_Dinhmuc_Giamathang AS String
	Private _uId_Mathang AS String
	Private _d_Ngay AS DateTime
	Private _d_NgayB AS String
	Private _f_Gianhap AS Double
	Private _f_Biendo_Gianhap AS Double
	Private _f_Giaban AS Double
	Private _f_Biendo_Giaban AS Double
	Private _uId_Kho AS String
	
	Public Property uId_Dinhmuc_Giamathang() AS String Implements IQLMH_DINHMUC_GIAMATHANGEntity.uId_Dinhmuc_Giamathang
		Get 
			Return _uId_Dinhmuc_Giamathang
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Dinhmuc_Giamathang=String.Empty
			Else 
				_uId_Dinhmuc_Giamathang=value.Trim
			End If
		End Set
	End Property

	Public Property uId_Mathang() AS String Implements IQLMH_DINHMUC_GIAMATHANGEntity.uId_Mathang
		Get 
			Return _uId_Mathang
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Mathang=String.Empty
			Else 
				_uId_Mathang=value.Trim
			End If
		End Set
	End Property

	Public Property d_Ngay() AS DateTime Implements IQLMH_DINHMUC_GIAMATHANGEntity.d_Ngay
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

	Public Property f_Gianhap() AS Double Implements IQLMH_DINHMUC_GIAMATHANGEntity.f_Gianhap
		Get 
			Return _f_Gianhap
		End Get
		Set(ByVal value As Double)
			_f_Gianhap=value
		End Set
	End Property

	Public Property f_Biendo_Gianhap() AS Double Implements IQLMH_DINHMUC_GIAMATHANGEntity.f_Biendo_Gianhap
		Get 
			Return _f_Biendo_Gianhap
		End Get
		Set(ByVal value As Double)
			_f_Biendo_Gianhap=value
		End Set
	End Property

	Public Property f_Giaban() AS Double Implements IQLMH_DINHMUC_GIAMATHANGEntity.f_Giaban
		Get 
			Return _f_Giaban
		End Get
		Set(ByVal value As Double)
			_f_Giaban=value
		End Set
	End Property

	Public Property f_Biendo_Giaban() AS Double Implements IQLMH_DINHMUC_GIAMATHANGEntity.f_Biendo_Giaban
		Get 
			Return _f_Biendo_Giaban
		End Get
		Set(ByVal value As Double)
			_f_Biendo_Giaban=value
		End Set
	End Property

	Public Property uId_Kho() AS String Implements IQLMH_DINHMUC_GIAMATHANGEntity.uId_Kho
		Get 
			Return _uId_Kho
		End Get
		Set(ByVal value As String)
			If(value = Nothing) Then
				_uId_Kho=String.Empty
			Else 
				_uId_Kho=value.Trim
			End If
		End Set
	End Property

End Class
