Public Class CRM_DM_XAPHUONGEntity 
	Implements ICRM_DM_XAPHUONGEntity 

	Private _uId_Xaphuong AS String
	Private _uId_Quanhuyen AS String
	Private _v_MaXaphuong AS String
	Private _nv_TenXaphuong AS String
	
	Public Property uId_Xaphuong() AS String Implements ICRM_DM_XAPHUONGEntity.uId_Xaphuong
		Get 
			Return _uId_Xaphuong
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Xaphuong=String.Empty
			Else 
				_uId_Xaphuong=value.Trim
			End If
		End Set
	End Property

	Public Property uId_Quanhuyen() AS String Implements ICRM_DM_XAPHUONGEntity.uId_Quanhuyen
		Get 
			Return _uId_Quanhuyen
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Quanhuyen=String.Empty
			Else 
				_uId_Quanhuyen=value.Trim
			End If
		End Set
	End Property

	Public Property v_MaXaphuong() AS String Implements ICRM_DM_XAPHUONGEntity.v_MaXaphuong
		Get 
			Return _v_MaXaphuong
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_v_MaXaphuong=String.Empty
			Else 
				_v_MaXaphuong=value.Trim
			End If
		End Set
	End Property

	Public Property nv_TenXaphuong() AS String Implements ICRM_DM_XAPHUONGEntity.nv_TenXaphuong
		Get 
			Return _nv_TenXaphuong
		End Get
		Set(ByVal value As String)
			If(value = Nothing) Then
				_nv_TenXaphuong=String.Empty
			Else 
				_nv_TenXaphuong=value.Trim
			End If
		End Set
	End Property

End Class
