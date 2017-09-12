Public Class QLMH_DM_KHOEntity 
	Implements IQLMH_DM_KHOEntity 

	Private _uId_Kho AS String
	Private _uId_Cuahang AS String
	Private _v_Makho AS String
	Private _nv_Tenkho_vn AS String
	Private _nv_Tenkho_en AS String
	Private _nv_Tencuahang_vn AS String

	Public Property uId_Kho() AS String Implements IQLMH_DM_KHOEntity.uId_Kho
		Get 
			Return _uId_Kho
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Kho=String.Empty
			Else 
				_uId_Kho=value.Trim
			End If
		End Set
	End Property

	Public Property uId_Cuahang() AS String Implements IQLMH_DM_KHOEntity.uId_Cuahang
		Get 
			Return _uId_Cuahang
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Cuahang=String.Empty
			Else 
				_uId_Cuahang=value.Trim
			End If
		End Set
	End Property

	Public Property v_Makho() AS String Implements IQLMH_DM_KHOEntity.v_Makho
		Get 
			Return _v_Makho
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_v_Makho=String.Empty
			Else 
				_v_Makho=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Tenkho_vn() AS String Implements IQLMH_DM_KHOEntity.nv_Tenkho_vn
		Get 
			Return _nv_Tenkho_vn
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Tenkho_vn=String.Empty
			Else 
				_nv_Tenkho_vn=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Tenkho_en() AS String Implements IQLMH_DM_KHOEntity.nv_Tenkho_en
		Get 
			Return _nv_Tenkho_en
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Tenkho_en=String.Empty
			Else 
				_nv_Tenkho_en=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Tencuahang_vn() AS String
		Get 
			Return _nv_Tencuahang_vn
		End Get
		Set(ByVal value As String)
			_nv_Tencuahang_vn=value
		End Set
	End Property

End Class
