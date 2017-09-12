Public Class TNTP_DM_NGOAITEEntity 
	Implements ITNTP_DM_NGOAITEEntity 

	Private _uId_Ngoaite AS String
	Private _v_Ma AS String
	Private _b_Macdinh AS Boolean
	
	Public Property uId_Ngoaite() AS String Implements ITNTP_DM_NGOAITEEntity.uId_Ngoaite
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

	Public Property v_Ma() AS String Implements ITNTP_DM_NGOAITEEntity.v_Ma
		Get 
			Return _v_Ma
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_v_Ma=String.Empty
			Else 
				_v_Ma=value.Trim
			End If
		End Set
	End Property

	Public Property b_Macdinh() AS Boolean Implements ITNTP_DM_NGOAITEEntity.b_Macdinh
		Get 
			Return _b_Macdinh
		End Get
		Set(ByVal value As Boolean)
			_b_Macdinh=value
		End Set
	End Property

End Class
