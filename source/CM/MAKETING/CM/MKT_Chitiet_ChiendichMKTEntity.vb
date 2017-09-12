Public Class MKT_Chitiet_ChiendichMKTEntity 
	Implements IMKT_Chitiet_ChiendichMKTEntity 

	Private _uId_Chitiet_Chiendich AS String
	Private _uId_ChiendichMKT AS String
	Private _uId_KH_Tiemnang AS String
	
	Public Property uId_Chitiet_Chiendich() AS String Implements IMKT_Chitiet_ChiendichMKTEntity.uId_Chitiet_Chiendich
		Get 
			Return _uId_Chitiet_Chiendich
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Chitiet_Chiendich=String.Empty
			Else 
				_uId_Chitiet_Chiendich=value.Trim
			End If
		End Set
	End Property

	Public Property uId_ChiendichMKT() AS String Implements IMKT_Chitiet_ChiendichMKTEntity.uId_ChiendichMKT
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

	Public Property uId_KH_Tiemnang() AS String Implements IMKT_Chitiet_ChiendichMKTEntity.uId_KH_Tiemnang
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
