Public Class CRM_DM_DANHGIAEntity 
	Implements ICRM_DM_DANHGIAEntity 

	Private _uId_Danhgia AS String
	Private _nv_Cauhoi_vn AS String
	
	Public Property uId_Danhgia() AS String Implements ICRM_DM_DANHGIAEntity.uId_Danhgia
		Get 
			Return _uId_Danhgia
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Danhgia=String.Empty
			Else 
				_uId_Danhgia=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Cauhoi_vn() AS String Implements ICRM_DM_DANHGIAEntity.nv_Cauhoi_vn
		Get 
			Return _nv_Cauhoi_vn
		End Get
		Set(ByVal value As String)
			If(value = Nothing) Then
				_nv_Cauhoi_vn=String.Empty
			Else 
				_nv_Cauhoi_vn=value.Trim
			End If
		End Set
	End Property

End Class
