Public Class CRM_DM_QUANHUYENEntity 
	Implements ICRM_DM_QUANHUYENEntity 

	Private _uId_Quanhuyen AS String
	Private _uId_Tinhthanh AS String
	Private _v_MaQuanhuyen AS String
	Private _nv_Tenquanhuyen AS String
	
	Public Property uId_Quanhuyen() AS String Implements ICRM_DM_QUANHUYENEntity.uId_Quanhuyen
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

	Public Property uId_Tinhthanh() AS String Implements ICRM_DM_QUANHUYENEntity.uId_Tinhthanh
		Get 
			Return _uId_Tinhthanh
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Tinhthanh=String.Empty
			Else 
				_uId_Tinhthanh=value.Trim
			End If
		End Set
	End Property

	Public Property v_MaQuanhuyen() AS String Implements ICRM_DM_QUANHUYENEntity.v_MaQuanhuyen
		Get 
			Return _v_MaQuanhuyen
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_v_MaQuanhuyen=String.Empty
			Else 
				_v_MaQuanhuyen=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Tenquanhuyen() AS String Implements ICRM_DM_QUANHUYENEntity.nv_Tenquanhuyen
		Get 
			Return _nv_Tenquanhuyen
		End Get
		Set(ByVal value As String)
			If(value = Nothing) Then
				_nv_Tenquanhuyen=String.Empty
			Else 
				_nv_Tenquanhuyen=value.Trim
			End If
		End Set
	End Property

End Class
