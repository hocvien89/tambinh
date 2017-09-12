Public Class TNTP_PHIEUDICHVU_SOTOTIENEntity 
	Implements ITNTP_PHIEUDICHVU_SOTOTIENEntity 

	Private _uId_Phieudichvu AS String
	Private _uId_Menhgiatien AS String
	Private _f_Sototien AS Double
	
	Public Property uId_Phieudichvu() AS String Implements ITNTP_PHIEUDICHVU_SOTOTIENEntity.uId_Phieudichvu
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

	Public Property uId_Menhgiatien() AS String Implements ITNTP_PHIEUDICHVU_SOTOTIENEntity.uId_Menhgiatien
		Get 
			Return _uId_Menhgiatien
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Menhgiatien=String.Empty
			Else 
				_uId_Menhgiatien=value.Trim
			End If
		End Set
	End Property

	Public Property f_Sototien() AS Double Implements ITNTP_PHIEUDICHVU_SOTOTIENEntity.f_Sototien
		Get 
			Return _f_Sototien
		End Get
		Set(ByVal value As Double)
			_f_Sototien=value
		End Set
	End Property

End Class
