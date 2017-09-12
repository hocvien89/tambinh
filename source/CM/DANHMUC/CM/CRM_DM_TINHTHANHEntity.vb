Public Class CRM_DM_TINHTHANHEntity 
	Implements ICRM_DM_TINHTHANHEntity 

	Private _uId_Tinhthanh AS String
	Private _uId_Quocgia AS String
	Private _v_MaTinhthanh AS String
	Private _nv_Tentinhthanh AS String
	
	Public Property uId_Tinhthanh() AS String Implements ICRM_DM_TINHTHANHEntity.uId_Tinhthanh
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

	Public Property uId_Quocgia() AS String Implements ICRM_DM_TINHTHANHEntity.uId_Quocgia
		Get 
			Return _uId_Quocgia
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Quocgia=String.Empty
			Else 
				_uId_Quocgia=value.Trim
			End If
		End Set
	End Property

	Public Property v_MaTinhthanh() AS String Implements ICRM_DM_TINHTHANHEntity.v_MaTinhthanh
		Get 
			Return _v_MaTinhthanh
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_v_MaTinhthanh=String.Empty
			Else 
				_v_MaTinhthanh=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Tentinhthanh() AS String Implements ICRM_DM_TINHTHANHEntity.nv_Tentinhthanh
		Get 
			Return _nv_Tentinhthanh
		End Get
		Set(ByVal value As String)
			If(value = Nothing) Then
				_nv_Tentinhthanh=String.Empty
			Else 
				_nv_Tentinhthanh=value.Trim
			End If
		End Set
	End Property

End Class
