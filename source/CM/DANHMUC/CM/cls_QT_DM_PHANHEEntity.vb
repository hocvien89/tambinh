Public Class QT_DM_PHANHEEntity 
	Implements IQT_DM_PHANHEEntity 

	Private _uId_Phanhe AS String
	Private _nv_Tenphanhe_vn AS String
	Private _nv_Tenphanhe_en AS String
	Private _nv_Ghichu_vn AS String
	Private _nv_Ghichu_en AS String
	
	Public Property uId_Phanhe() AS String Implements IQT_DM_PHANHEEntity.uId_Phanhe
		Get 
			Return _uId_Phanhe
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Phanhe=String.Empty
			Else 
				_uId_Phanhe=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Tenphanhe_vn() AS String Implements IQT_DM_PHANHEEntity.nv_Tenphanhe_vn
		Get 
			Return _nv_Tenphanhe_vn
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Tenphanhe_vn=String.Empty
			Else 
				_nv_Tenphanhe_vn=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Tenphanhe_en() AS String Implements IQT_DM_PHANHEEntity.nv_Tenphanhe_en
		Get 
			Return _nv_Tenphanhe_en
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Tenphanhe_en=String.Empty
			Else 
				_nv_Tenphanhe_en=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Ghichu_vn() AS String Implements IQT_DM_PHANHEEntity.nv_Ghichu_vn
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

	Public Property nv_Ghichu_en() AS String Implements IQT_DM_PHANHEEntity.nv_Ghichu_en
		Get 
			Return _nv_Ghichu_en
		End Get
		Set(ByVal value As String)
			If(value = Nothing) Then
				_nv_Ghichu_en=String.Empty
			Else 
				_nv_Ghichu_en=value.Trim
			End If
		End Set
	End Property

End Class
