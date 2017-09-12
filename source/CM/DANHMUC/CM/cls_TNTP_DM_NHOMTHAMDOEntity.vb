Public Class TNTP_DM_NHOMTHAMDOEntity 
	Implements ITNTP_DM_NHOMTHAMDOEntity 

	Private _uId_NhomThamdo AS String
	Private _nv_TennhomThamdo_vn AS String
	Private _nv_TennhomThando_en AS String
	
	Public Property uId_NhomThamdo() AS String Implements ITNTP_DM_NHOMTHAMDOEntity.uId_NhomThamdo
		Get 
			Return _uId_NhomThamdo
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_NhomThamdo=String.Empty
			Else 
				_uId_NhomThamdo=value.Trim
			End If
		End Set
	End Property

	Public Property nv_TennhomThamdo_vn() AS String Implements ITNTP_DM_NHOMTHAMDOEntity.nv_TennhomThamdo_vn
		Get 
			Return _nv_TennhomThamdo_vn
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_TennhomThamdo_vn=String.Empty
			Else 
				_nv_TennhomThamdo_vn=value.Trim
			End If
		End Set
	End Property

	Public Property nv_TennhomThando_en() AS String Implements ITNTP_DM_NHOMTHAMDOEntity.nv_TennhomThando_en
		Get 
			Return _nv_TennhomThando_en
		End Get
		Set(ByVal value As String)
			If(value = Nothing) Then
				_nv_TennhomThando_en=String.Empty
			Else 
				_nv_TennhomThando_en=value.Trim
			End If
		End Set
	End Property

End Class
