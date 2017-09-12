Public Class TNTP_DM_GOIDICHVUEntity 
	Implements ITNTP_DM_GOIDICHVUEntity 

	Private _uId_Goidichvu AS String
	Private _nv_Tengoi_vn AS String
	Private _nv_Tengoi_en AS String
	
	Public Property uId_Goidichvu() AS String Implements ITNTP_DM_GOIDICHVUEntity.uId_Goidichvu
		Get 
			Return _uId_Goidichvu
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Goidichvu=String.Empty
			Else 
				_uId_Goidichvu=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Tengoi_vn() AS String Implements ITNTP_DM_GOIDICHVUEntity.nv_Tengoi_vn
		Get 
			Return _nv_Tengoi_vn
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Tengoi_vn=String.Empty
			Else 
				_nv_Tengoi_vn=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Tengoi_en() AS String Implements ITNTP_DM_GOIDICHVUEntity.nv_Tengoi_en
		Get 
			Return _nv_Tengoi_en
		End Get
		Set(ByVal value As String)
			If(value = Nothing) Then
				_nv_Tengoi_en=String.Empty
			Else 
				_nv_Tengoi_en=value.Trim
			End If
		End Set
	End Property

End Class
