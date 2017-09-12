Public Class CTKM_LOAIGIAMGIAEntity 
	Implements ICTKM_LOAIGIAMGIAEntity 

	Private _uId_LoaiGiamgia AS String
	Private _nv_TenLoaiGiamgia_vn AS String
	Private _nv_TenLoaiGiamgia_en AS String
	
	Public Property uId_LoaiGiamgia() AS String Implements ICTKM_LOAIGIAMGIAEntity.uId_LoaiGiamgia
		Get 
			Return _uId_LoaiGiamgia
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_LoaiGiamgia=String.Empty
			Else 
				_uId_LoaiGiamgia=value.Trim
			End If
		End Set
	End Property

	Public Property nv_TenLoaiGiamgia_vn() AS String Implements ICTKM_LOAIGIAMGIAEntity.nv_TenLoaiGiamgia_vn
		Get 
			Return _nv_TenLoaiGiamgia_vn
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_TenLoaiGiamgia_vn=String.Empty
			Else 
				_nv_TenLoaiGiamgia_vn=value.Trim
			End If
		End Set
	End Property

	Public Property nv_TenLoaiGiamgia_en() AS String Implements ICTKM_LOAIGIAMGIAEntity.nv_TenLoaiGiamgia_en
		Get 
			Return _nv_TenLoaiGiamgia_en
		End Get
		Set(ByVal value As String)
			If(value = Nothing) Then
				_nv_TenLoaiGiamgia_en=String.Empty
			Else 
				_nv_TenLoaiGiamgia_en=value.Trim
			End If
		End Set
	End Property

End Class
