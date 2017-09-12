Public Class TNTP_KM_LOAITHEEntity 
	Implements ITNTP_KM_LOAITHEEntity 

	Private _uId_KM_Loaithe AS String
	Private _uId_Loaithe AS String
	Private _v_MaKM AS String
	Private _nv_TenKM AS String
	Private _f_Chietkhau AS Double
	
	Public Property uId_KM_Loaithe() AS String Implements ITNTP_KM_LOAITHEEntity.uId_KM_Loaithe
		Get 
			Return _uId_KM_Loaithe
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_KM_Loaithe=String.Empty
			Else 
				_uId_KM_Loaithe=value.Trim
			End If
		End Set
	End Property

	Public Property uId_Loaithe() AS String Implements ITNTP_KM_LOAITHEEntity.uId_Loaithe
		Get 
			Return _uId_Loaithe
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Loaithe=String.Empty
			Else 
				_uId_Loaithe=value.Trim
			End If
		End Set
	End Property

	Public Property v_MaKM() AS String Implements ITNTP_KM_LOAITHEEntity.v_MaKM
		Get 
			Return _v_MaKM
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_v_MaKM=String.Empty
			Else 
				_v_MaKM=value.Trim
			End If
		End Set
	End Property

	Public Property nv_TenKM() AS String Implements ITNTP_KM_LOAITHEEntity.nv_TenKM
		Get 
			Return _nv_TenKM
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_TenKM=String.Empty
			Else 
				_nv_TenKM=value.Trim
			End If
		End Set
	End Property

	Public Property f_Chietkhau() AS Double Implements ITNTP_KM_LOAITHEEntity.f_Chietkhau
		Get 
			Return _f_Chietkhau
		End Get
		Set(ByVal value As Double)
			_f_Chietkhau=value
		End Set
	End Property

End Class
