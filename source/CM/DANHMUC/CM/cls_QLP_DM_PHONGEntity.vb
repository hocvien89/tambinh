Public Class QLP_DM_PHONGEntity 
	Implements IQLP_DM_PHONGEntity 

	Private _uId_Phong AS String
	Private _uId_Cuahang AS String
	Private _nv_Tenphong_vn AS String
	Private _nv_Tenphong_en AS String
	Private _i_Thutu AS Int16
	Private _i_Sokhachtoida AS Int16
	Private _v_Dienthoai AS String
	Private _v_Maunen AS String
	Private _v_Mauchu AS String
	Private _nv_Tencuahang_vn AS String

	Public Property uId_Phong() AS String Implements IQLP_DM_PHONGEntity.uId_Phong
		Get 
			Return _uId_Phong
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Phong=String.Empty
			Else 
				_uId_Phong=value.Trim
			End If
		End Set
	End Property

	Public Property uId_Cuahang() AS String Implements IQLP_DM_PHONGEntity.uId_Cuahang
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

	Public Property nv_Tenphong_vn() AS String Implements IQLP_DM_PHONGEntity.nv_Tenphong_vn
		Get 
			Return _nv_Tenphong_vn
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Tenphong_vn=String.Empty
			Else 
				_nv_Tenphong_vn=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Tenphong_en() AS String Implements IQLP_DM_PHONGEntity.nv_Tenphong_en
		Get 
			Return _nv_Tenphong_en
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Tenphong_en=String.Empty
			Else 
				_nv_Tenphong_en=value.Trim
			End If
		End Set
	End Property

	Public Property i_Thutu() AS Int16 Implements IQLP_DM_PHONGEntity.i_Thutu
		Get 
			Return _i_Thutu
		End Get
		Set(ByVal value As Int16)
			_i_Thutu=value
		End Set
	End Property

	Public Property i_Sokhachtoida() AS Int16 Implements IQLP_DM_PHONGEntity.i_Sokhachtoida
		Get 
			Return _i_Sokhachtoida
		End Get
		Set(ByVal value As Int16)
			_i_Sokhachtoida=value
		End Set
	End Property

	Public Property v_Dienthoai() AS String Implements IQLP_DM_PHONGEntity.v_Dienthoai
		Get 
			Return _v_Dienthoai
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_v_Dienthoai=String.Empty
			Else 
				_v_Dienthoai=value.Trim
			End If
		End Set
	End Property

	Public Property v_Maunen() AS String Implements IQLP_DM_PHONGEntity.v_Maunen
		Get 
			Return _v_Maunen
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_v_Maunen=String.Empty
			Else 
				_v_Maunen=value.Trim
			End If
		End Set
	End Property

	Public Property v_Mauchu() AS String Implements IQLP_DM_PHONGEntity.v_Mauchu
		Get 
			Return _v_Mauchu
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_v_Mauchu=String.Empty
			Else 
				_v_Mauchu=value.Trim
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
