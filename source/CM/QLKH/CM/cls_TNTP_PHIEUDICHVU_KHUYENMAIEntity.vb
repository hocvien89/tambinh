Public Class TNTP_PHIEUDICHVU_KHUYENMAIEntity 
	Implements ITNTP_PHIEUDICHVU_KHUYENMAIEntity 

	Private _uId_Phieudichvu AS String
	Private _uId_DM_Khuyenmai AS String
	
	Public Property uId_Phieudichvu() AS String Implements ITNTP_PHIEUDICHVU_KHUYENMAIEntity.uId_Phieudichvu
		Get 
			Return _uId_Phieudichvu
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Phieudichvu=String.Empty
			Else 
				_uId_Phieudichvu=value.Trim
			End If
		End Set
	End Property

	Public Property uId_DM_Khuyenmai() AS String Implements ITNTP_PHIEUDICHVU_KHUYENMAIEntity.uId_DM_Khuyenmai
		Get 
			Return _uId_DM_Khuyenmai
		End Get
		Set(ByVal value As String)
			If(value = Nothing) Then
				_uId_DM_Khuyenmai=String.Empty
			Else 
				_uId_DM_Khuyenmai=value.Trim
			End If
		End Set
	End Property

End Class
