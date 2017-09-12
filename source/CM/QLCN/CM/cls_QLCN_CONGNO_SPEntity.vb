Public Class QLCN_CONGNO_SPEntity 
	Implements IQLCN_CONGNO_SPEntity 

	Private _uId_Phieuxuat AS String
	Private _f_Sotien AS Double
	
	Public Property uId_Phieuxuat() AS String Implements IQLCN_CONGNO_SPEntity.uId_Phieuxuat
		Get 
			Return _uId_Phieuxuat
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Phieuxuat=String.Empty
			Else 
				_uId_Phieuxuat=value.Trim
			End If
		End Set
	End Property

	Public Property f_Sotien() AS Double Implements IQLCN_CONGNO_SPEntity.f_Sotien
		Get 
			Return _f_Sotien
		End Get
		Set(ByVal value As Double)
			_f_Sotien=value
		End Set
	End Property

End Class
