Public Class MKT_SMSEntity 
	Implements IMKT_SMSEntity 

	Private _uId_SMS AS String
	Private _d_Ngay AS DateTime
	Private _d_NgayB AS String
	Private _nv_Noidung AS String
	Private _uId_KH_Tiemnang AS String
	
	Public Property uId_SMS() AS String Implements IMKT_SMSEntity.uId_SMS
		Get 
			Return _uId_SMS
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_SMS=String.Empty
			Else 
				_uId_SMS=value.Trim
			End If
		End Set
	End Property

	Public Property d_Ngay() AS DateTime Implements IMKT_SMSEntity.d_Ngay
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

	Public Property nv_Noidung() AS String Implements IMKT_SMSEntity.nv_Noidung
		Get 
			Return _nv_Noidung
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Noidung=String.Empty
			Else 
				_nv_Noidung=value.Trim
			End If
		End Set
	End Property

	Public Property uId_KH_Tiemnang() AS String Implements IMKT_SMSEntity.uId_KH_Tiemnang
		Get 
			Return _uId_KH_Tiemnang
		End Get
		Set(ByVal value As String)
			If(value = Nothing) Then
				_uId_KH_Tiemnang=String.Empty
			Else 
				_uId_KH_Tiemnang=value.Trim
			End If
		End Set
	End Property

End Class
