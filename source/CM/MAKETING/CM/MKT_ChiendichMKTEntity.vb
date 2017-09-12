Public Class MKT_ChiendichMKTEntity 
	Implements IMKT_ChiendichMKTEntity 

	Private _uId_ChiendichMKT AS String
	Private _nv_TenChiendichMKT AS String
	Private _d_NgayBD AS DateTime
	Private _d_NgayBDB AS String
	Private _d_NgayKT AS DateTime
	Private _d_NgayKTB AS String
	Private _nv_Ghichu AS String
	Private _nv_Noidung AS String
	
	Public Property uId_ChiendichMKT() AS String Implements IMKT_ChiendichMKTEntity.uId_ChiendichMKT
		Get 
			Return _uId_ChiendichMKT
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_ChiendichMKT=String.Empty
			Else 
				_uId_ChiendichMKT=value.Trim
			End If
		End Set
	End Property

	Public Property nv_TenChiendichMKT() AS String Implements IMKT_ChiendichMKTEntity.nv_TenChiendichMKT
		Get 
			Return _nv_TenChiendichMKT
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_TenChiendichMKT=String.Empty
			Else 
				_nv_TenChiendichMKT=value.Trim
			End If
		End Set
	End Property

	Public Property d_NgayBD() AS DateTime Implements IMKT_ChiendichMKTEntity.d_NgayBD
		Get 
			Return Date.Parse(_d_NgayBD).ToShortDateString
		End Get
		Set(ByVal value As DateTime)
			_d_NgayBD=value
		End Set
	End Property

	Public Property d_NgayBDB() AS String
		Get 
			If(_d_NgayBD=Nothing) Then
				Return String.Empty
			Else
				Return CStr(Format(_d_NgayBD, "dd/MM/yyyy"))
			End If
		End Get
		Set(ByVal value As String)
			_d_NgayBD=value
		End Set
	End Property

	Public Property d_NgayKT() AS DateTime Implements IMKT_ChiendichMKTEntity.d_NgayKT
		Get 
			Return Date.Parse(_d_NgayKT).ToShortDateString
		End Get
		Set(ByVal value As DateTime)
			_d_NgayKT=value
		End Set
	End Property

	Public Property d_NgayKTB() AS String
		Get 
			If(_d_NgayKT=Nothing) Then
				Return String.Empty
			Else
				Return CStr(Format(_d_NgayKT, "dd/MM/yyyy"))
			End If
		End Get
		Set(ByVal value As String)
			_d_NgayKT=value
		End Set
	End Property

	Public Property nv_Ghichu() AS String Implements IMKT_ChiendichMKTEntity.nv_Ghichu
		Get 
			Return _nv_Ghichu
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Ghichu=String.Empty
			Else 
				_nv_Ghichu=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Noidung() AS String Implements IMKT_ChiendichMKTEntity.nv_Noidung
		Get 
			Return _nv_Noidung
		End Get
		Set(ByVal value As String)
			If(value = Nothing) Then
				_nv_Noidung=String.Empty
			Else 
				_nv_Noidung=value.Trim
			End If
		End Set
	End Property

End Class
