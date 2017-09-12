Public Class QLMH_DM_LOAIMATHANGEntity 
	Implements IQLMH_DM_LOAIMATHANGEntity 

	Private _uId_Loaimathang AS String
	Private _nv_Tenloaimathang_en AS String
	Private _nv_Tenloaimathang_vn AS String
	
	Public Property uId_Loaimathang() AS String Implements IQLMH_DM_LOAIMATHANGEntity.uId_Loaimathang
		Get 
			Return _uId_Loaimathang
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Loaimathang=String.Empty
			Else 
				_uId_Loaimathang=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Tenloaimathang_en() AS String Implements IQLMH_DM_LOAIMATHANGEntity.nv_Tenloaimathang_en
		Get 
			Return _nv_Tenloaimathang_en
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Tenloaimathang_en=String.Empty
			Else 
				_nv_Tenloaimathang_en=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Tenloaimathang_vn() AS String Implements IQLMH_DM_LOAIMATHANGEntity.nv_Tenloaimathang_vn
		Get 
			Return _nv_Tenloaimathang_vn
		End Get
		Set(ByVal value As String)
			If(value = Nothing) Then
				_nv_Tenloaimathang_vn=String.Empty
			Else 
				_nv_Tenloaimathang_vn=value.Trim
			End If
		End Set
	End Property

End Class
