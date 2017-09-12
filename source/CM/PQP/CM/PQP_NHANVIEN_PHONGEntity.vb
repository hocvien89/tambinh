Public Class PQP_NHANVIEN_PHONGEntity 
	Implements IPQP_NHANVIEN_PHONGEntity 

	Private _uId_Nhanvien_Phong AS String
	Private _uId_Phongban AS String
	Private _uId_Nhanvien AS String
	Private _nv_Ghichu AS String
	
	Public Property uId_Nhanvien_Phong() AS String Implements IPQP_NHANVIEN_PHONGEntity.uId_Nhanvien_Phong
		Get 
			Return _uId_Nhanvien_Phong
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Nhanvien_Phong=String.Empty
			Else 
				_uId_Nhanvien_Phong=value.Trim
			End If
		End Set
	End Property

	Public Property uId_Phongban() AS String Implements IPQP_NHANVIEN_PHONGEntity.uId_Phongban
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

	Public Property uId_Nhanvien() AS String Implements IPQP_NHANVIEN_PHONGEntity.uId_Nhanvien
		Get 
			Return _uId_Nhanvien
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Nhanvien=String.Empty
			Else 
				_uId_Nhanvien=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Ghichu() AS String Implements IPQP_NHANVIEN_PHONGEntity.nv_Ghichu
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
