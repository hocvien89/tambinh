Public Class QLTC_PHIEUDICHVU_CHUYENKHOANEntity 
	Implements IQLTC_PHIEUDICHVU_CHUYENKHOANEntity 

	Private _uId_PDV_Chuyentien AS String
	Private _uId_Phieudichvu AS String
	Private _f_Sotien AS Double
	Private _d_Thoigian AS DateTime
	Private _d_ThoigianB AS String

	Public Property uId_PDV_Chuyentien() AS String Implements IQLTC_PHIEUDICHVU_CHUYENKHOANEntity.uId_PDV_Chuyentien
		Get 
			Return _uId_PDV_Chuyentien
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_PDV_Chuyentien=String.Empty
			Else 
				_uId_PDV_Chuyentien=value.Trim
			End If
		End Set
	End Property

	Public Property uId_Phieudichvu() AS String Implements IQLTC_PHIEUDICHVU_CHUYENKHOANEntity.uId_Phieudichvu
		Get 
			Return _uId_Phieudichvu
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Phieudichvu=String.Empty
			Else 
				_uId_Phieudichvu=value.Trim
			End If
		End Set
	End Property

	Public Property f_Sotien() AS Double Implements IQLTC_PHIEUDICHVU_CHUYENKHOANEntity.f_Sotien
		Get 
			Return _f_Sotien
		End Get
		Set(ByVal value As Double)
			_f_Sotien=value
		End Set
	End Property

	Public Property d_Thoigian() AS DateTime Implements IQLTC_PHIEUDICHVU_CHUYENKHOANEntity.d_Thoigian
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

End Class
