Public Class QT_DM_CHUCNANGEntity 
	Implements IQT_DM_CHUCNANGEntity 

	Private _uId_Chucnang AS String
	Private _uId_Phanhe AS String
	Private _nv_Tenbien AS String
	Private _nv_Tenchucnang_vn AS String
	Private _nv_Tenchucnang_en AS String
	Private _nv_Tenphanhe_vn AS String

	Public Property uId_Chucnang() AS String Implements IQT_DM_CHUCNANGEntity.uId_Chucnang
		Get 
			Return _uId_Chucnang
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Chucnang=String.Empty
			Else 
				_uId_Chucnang=value.Trim
			End If
		End Set
	End Property

	Public Property uId_Phanhe() AS String Implements IQT_DM_CHUCNANGEntity.uId_Phanhe
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

	Public Property nv_Tenbien() AS String Implements IQT_DM_CHUCNANGEntity.nv_Tenbien
		Get 
			Return _nv_Tenbien
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Tenbien=String.Empty
			Else 
				_nv_Tenbien=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Tenchucnang_vn() AS String Implements IQT_DM_CHUCNANGEntity.nv_Tenchucnang_vn
		Get 
			Return _nv_Tenchucnang_vn
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Tenchucnang_vn=String.Empty
			Else 
				_nv_Tenchucnang_vn=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Tenchucnang_en() AS String Implements IQT_DM_CHUCNANGEntity.nv_Tenchucnang_en
		Get 
			Return _nv_Tenchucnang_en
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Tenchucnang_en=String.Empty
			Else 
				_nv_Tenchucnang_en=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Tenphanhe_vn() AS String
		Get 
			Return _nv_Tenphanhe_vn
		End Get
		Set(ByVal value As String)
			_nv_Tenphanhe_vn=value
		End Set
	End Property

End Class
