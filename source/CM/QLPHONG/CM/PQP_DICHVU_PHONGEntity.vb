Public Class PQP_DICHVU_PHONGEntity 
	Implements IPQP_DICHVU_PHONGEntity 

	Private _uId_Dichvu_Phong AS String
	Private _uId_Phongban AS String
	Private _uId_Dichvu AS String
	Private _nv_Ghichu AS String
	
	Public Property uId_Dichvu_Phong() AS String Implements IPQP_DICHVU_PHONGEntity.uId_Dichvu_Phong
		Get 
			Return _uId_Dichvu_Phong
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Dichvu_Phong=String.Empty
			Else 
				_uId_Dichvu_Phong=value.Trim
			End If
		End Set
	End Property

	Public Property uId_Phongban() AS String Implements IPQP_DICHVU_PHONGEntity.uId_Phongban
		Get 
			Return _uId_Phongban
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Phongban=String.Empty
			Else 
				_uId_Phongban=value.Trim
			End If
		End Set
	End Property

	Public Property uId_Dichvu() AS String Implements IPQP_DICHVU_PHONGEntity.uId_Dichvu
		Get 
			Return _uId_Dichvu
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Dichvu=String.Empty
			Else 
				_uId_Dichvu=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Ghichu() AS String Implements IPQP_DICHVU_PHONGEntity.nv_Ghichu
		Get 
			Return _nv_Ghichu
		End Get
		Set(ByVal value As String)
			If(value = Nothing) Then
				_nv_Ghichu=String.Empty
			Else 
				_nv_Ghichu=value.Trim
			End If
		End Set
	End Property

End Class
