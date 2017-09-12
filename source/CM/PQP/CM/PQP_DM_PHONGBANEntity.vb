Public Class PQP_DM_PHONGBANEntity 
	Implements IPQP_DM_PHONGBANEntity 

	Private _uId_Phongban AS String
	Private _uId_Cuahang AS String
	Private _nv_Tenphongban_vn AS String
	Private _nv_Tenphongban_en AS String
	Private _v_Dienthoai AS String
	
	Public Property uId_Phongban() AS String Implements IPQP_DM_PHONGBANEntity.uId_Phongban
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

	Public Property uId_Cuahang() AS String Implements IPQP_DM_PHONGBANEntity.uId_Cuahang
		Get 
			Return _uId_Cuahang
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Cuahang=String.Empty
			Else 
				_uId_Cuahang=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Tenphongban_vn() AS String Implements IPQP_DM_PHONGBANEntity.nv_Tenphongban_vn
		Get 
			Return _nv_Tenphongban_vn
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Tenphongban_vn=String.Empty
			Else 
				_nv_Tenphongban_vn=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Tenphongban_en() AS String Implements IPQP_DM_PHONGBANEntity.nv_Tenphongban_en
		Get 
			Return _nv_Tenphongban_en
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Tenphongban_en=String.Empty
			Else 
				_nv_Tenphongban_en=value.Trim
			End If
		End Set
	End Property

	Public Property v_Dienthoai() AS String Implements IPQP_DM_PHONGBANEntity.v_Dienthoai
		Get 
			Return _v_Dienthoai
		End Get
		Set(ByVal value As String)
			If(value = Nothing) Then
				_v_Dienthoai=String.Empty
			Else 
				_v_Dienthoai=value.Trim
			End If
		End Set
	End Property

End Class
