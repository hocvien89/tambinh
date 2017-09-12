Public Class QLMH_DM_NHOMMATHANGEntity 
	Implements IQLMH_DM_NHOMMATHANGEntity 

	Private _uId_Nhommathang AS String
	Private _nv_Tennhommathang_vn AS String
	Private _nv_Tennhommathang_en AS String
	
	Public Property uId_Nhommathang() AS String Implements IQLMH_DM_NHOMMATHANGEntity.uId_Nhommathang
		Get 
			Return _uId_Nhommathang
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Nhommathang=String.Empty
			Else 
				_uId_Nhommathang=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Tennhommathang_vn() AS String Implements IQLMH_DM_NHOMMATHANGEntity.nv_Tennhommathang_vn
		Get 
			Return _nv_Tennhommathang_vn
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Tennhommathang_vn=String.Empty
			Else 
				_nv_Tennhommathang_vn=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Tennhommathang_en() AS String Implements IQLMH_DM_NHOMMATHANGEntity.nv_Tennhommathang_en
		Get 
			Return _nv_Tennhommathang_en
		End Get
		Set(ByVal value As String)
			If(value = Nothing) Then
				_nv_Tennhommathang_en=String.Empty
			Else 
				_nv_Tennhommathang_en=value.Trim
			End If
		End Set
	End Property

End Class
