Public Class TNTP_NGOAITE_TYGIAEntity 
	Implements ITNTP_NGOAITE_TYGIAEntity 

	Private _uId_Ngoaite AS String
	Private _d_Ngay AS DateTime
	Private _d_NgayB AS String
	Private _f_Tygia_VND AS Double
	Private _v_Ma AS String

	Public Property uId_Ngoaite() AS String Implements ITNTP_NGOAITE_TYGIAEntity.uId_Ngoaite
		Get 
			Return _uId_Ngoaite
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Ngoaite=String.Empty
			Else 
				_uId_Ngoaite=value.Trim
			End If
		End Set
	End Property

	Public Property d_Ngay() AS DateTime Implements ITNTP_NGOAITE_TYGIAEntity.d_Ngay
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

	Public Property f_Tygia_VND() AS Double Implements ITNTP_NGOAITE_TYGIAEntity.f_Tygia_VND
		Get 
			Return _f_Tygia_VND
		End Get
		Set(ByVal value As Double)
			_f_Tygia_VND=value
		End Set
	End Property

	Public Property v_Ma() AS String
		Get 
			Return _v_Ma
		End Get
		Set(ByVal value As String)
			_v_Ma=value
		End Set
	End Property

End Class
