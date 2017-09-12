Public Class QLP_DM_THIETBIEntity 
	Implements IQLP_DM_THIETBIEntity 

	Private _uId_Thietbi AS String
	Private _uId_Cuahang AS String
	Private _v_Mathietbi AS String
	Private _nv_Tenthietbi_vn AS String
	Private _nv_Tenthietbi_en AS String
	Private _nv_Ghichu_vn AS String
	Private _nv_Ghichu_en AS String
	Private _nv_Tencuahang_vn AS String

	Public Property uId_Thietbi() AS String Implements IQLP_DM_THIETBIEntity.uId_Thietbi
		Get 
			Return _uId_Thietbi
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Thietbi=String.Empty
			Else 
				_uId_Thietbi=value.Trim
			End If
		End Set
	End Property

	Public Property uId_Cuahang() AS String Implements IQLP_DM_THIETBIEntity.uId_Cuahang
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

	Public Property v_Mathietbi() AS String Implements IQLP_DM_THIETBIEntity.v_Mathietbi
		Get 
			Return _v_Mathietbi
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_v_Mathietbi=String.Empty
			Else 
				_v_Mathietbi=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Tenthietbi_vn() AS String Implements IQLP_DM_THIETBIEntity.nv_Tenthietbi_vn
		Get 
			Return _nv_Tenthietbi_vn
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Tenthietbi_vn=String.Empty
			Else 
				_nv_Tenthietbi_vn=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Tenthietbi_en() AS String Implements IQLP_DM_THIETBIEntity.nv_Tenthietbi_en
		Get 
			Return _nv_Tenthietbi_en
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Tenthietbi_en=String.Empty
			Else 
				_nv_Tenthietbi_en=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Ghichu_vn() AS String Implements IQLP_DM_THIETBIEntity.nv_Ghichu_vn
		Get 
			Return _nv_Ghichu_vn
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Ghichu_vn=String.Empty
			Else 
				_nv_Ghichu_vn=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Ghichu_en() AS String Implements IQLP_DM_THIETBIEntity.nv_Ghichu_en
		Get 
			Return _nv_Ghichu_en
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Ghichu_en=String.Empty
			Else 
				_nv_Ghichu_en=value.Trim
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
