Public Class CRM_DM_QUOCGIAEntity 
	Implements ICRM_DM_QUOCGIAEntity 

	Private _uId_Quocgia AS String
	Private _v_MaQuocgia AS String
	Private _nv_TenQuocgia AS String
	
	Public Property uId_Quocgia() AS String Implements ICRM_DM_QUOCGIAEntity.uId_Quocgia
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

	Public Property v_MaQuocgia() AS String Implements ICRM_DM_QUOCGIAEntity.v_MaQuocgia
		Get 
			Return _v_MaQuocgia
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_v_MaQuocgia=String.Empty
			Else 
				_v_MaQuocgia=value.Trim
			End If
		End Set
	End Property

	Public Property nv_TenQuocgia() AS String Implements ICRM_DM_QUOCGIAEntity.nv_TenQuocgia
		Get 
			Return _nv_TenQuocgia
		End Get
		Set(ByVal value As String)
			If(value = Nothing) Then
				_nv_TenQuocgia=String.Empty
			Else 
				_nv_TenQuocgia=value.Trim
			End If
		End Set
	End Property

End Class
