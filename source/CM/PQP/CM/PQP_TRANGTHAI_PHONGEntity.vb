Public Class PQP_TRANGTHAI_PHONGEntity 
	Implements IPQP_TRANGTHAI_PHONGEntity 

	Private _uId_TrangthaiPhong AS String
	Private _uId_Trangthai AS String
	Private _uId_Phongban AS String
	
	Public Property uId_TrangthaiPhong() AS String Implements IPQP_TRANGTHAI_PHONGEntity.uId_TrangthaiPhong
		Get 
			Return _uId_TrangthaiPhong
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_TrangthaiPhong=String.Empty
			Else 
				_uId_TrangthaiPhong=value.Trim
			End If
		End Set
	End Property

	Public Property uId_Trangthai() AS String Implements IPQP_TRANGTHAI_PHONGEntity.uId_Trangthai
		Get 
			Return _uId_Trangthai
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Trangthai=String.Empty
			Else 
				_uId_Trangthai=value.Trim
			End If
		End Set
	End Property

	Public Property uId_Phongban() AS String Implements IPQP_TRANGTHAI_PHONGEntity.uId_Phongban
		Get 
			Return _uId_Phongban
		End Get
		Set(ByVal value As String)
			If(value = Nothing) Then
				_uId_Phongban=String.Empty
			Else 
				_uId_Phongban=value.Trim
			End If
		End Set
	End Property

End Class
