Public Class TNTP_DM_MENHGIATIENEntity 
	Implements ITNTP_DM_MENHGIATIENEntity 

	Private _uId_Menhgiatien AS String
	Private _uId_Ngoaite AS String
	Private _f_Menhgia AS Double
	
	Public Property uId_Menhgiatien() AS String Implements ITNTP_DM_MENHGIATIENEntity.uId_Menhgiatien
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

	Public Property uId_Ngoaite() AS String Implements ITNTP_DM_MENHGIATIENEntity.uId_Ngoaite
		Get 
			Return _uId_Ngoaite
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Ngoaite=String.Empty
			Else 
				_uId_Ngoaite=value.Trim
			End If
		End Set
	End Property

	Public Property f_Menhgia() AS Double Implements ITNTP_DM_MENHGIATIENEntity.f_Menhgia
		Get 
			Return _f_Menhgia
		End Get
		Set(ByVal value As Double)
			_f_Menhgia=value
		End Set
	End Property

End Class
