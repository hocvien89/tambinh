Public Class MKT_ChuyendoiEntity 
	Implements IMKT_ChuyendoiEntity 

	Private _uId_Chuyendoi AS String
	Private _d_Ngay AS DateTime
	Private _d_NgayB AS String
	Private _uId_KH_Tiemnang AS String
	Private _uId_TrangthaiKH AS String
	
	Public Property uId_Chuyendoi() AS String Implements IMKT_ChuyendoiEntity.uId_Chuyendoi
		Get 
			Return _uId_Chuyendoi
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Chuyendoi=String.Empty
			Else 
				_uId_Chuyendoi=value.Trim
			End If
		End Set
	End Property

	Public Property d_Ngay() AS DateTime Implements IMKT_ChuyendoiEntity.d_Ngay
		Get 
            Return _d_Ngay
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

	Public Property uId_KH_Tiemnang() AS String Implements IMKT_ChuyendoiEntity.uId_KH_Tiemnang
		Get 
			Return _uId_KH_Tiemnang
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_KH_Tiemnang=String.Empty
			Else 
				_uId_KH_Tiemnang=value.Trim
			End If
		End Set
	End Property

	Public Property uId_TrangthaiKH() AS String Implements IMKT_ChuyendoiEntity.uId_TrangthaiKH
		Get 
			Return _uId_TrangthaiKH
		End Get
		Set(ByVal value As String)
			If(value = Nothing) Then
				_uId_TrangthaiKH=String.Empty
			Else 
				_uId_TrangthaiKH=value.Trim
			End If
		End Set
	End Property

End Class
