Public Class CRM_DM_TRANGTHAIEntity 
	Implements ICRM_DM_TRANGTHAIEntity 

	Private _uId_Trangthai AS String
	Private _v_Matrangthai AS String
	Private _nv_Tentrangthai_vn AS String
	Private _nv_Tentrangthai_en AS String
	Private _v_Mau_Chu AS String
	Private _v_Mau_Nen AS String
	Private _i_Type AS Int32
	
	Public Property uId_Trangthai() AS String Implements ICRM_DM_TRANGTHAIEntity.uId_Trangthai
		Get 
			Return _uId_Trangthai
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Trangthai=String.Empty
			Else 
				_uId_Trangthai=value.Trim
			End If
		End Set
	End Property

	Public Property v_Matrangthai() AS String Implements ICRM_DM_TRANGTHAIEntity.v_Matrangthai
		Get 
			Return _v_Matrangthai
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_v_Matrangthai=String.Empty
			Else 
				_v_Matrangthai=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Tentrangthai_vn() AS String Implements ICRM_DM_TRANGTHAIEntity.nv_Tentrangthai_vn
		Get 
			Return _nv_Tentrangthai_vn
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Tentrangthai_vn=String.Empty
			Else 
				_nv_Tentrangthai_vn=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Tentrangthai_en() AS String Implements ICRM_DM_TRANGTHAIEntity.nv_Tentrangthai_en
		Get 
			Return _nv_Tentrangthai_en
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Tentrangthai_en=String.Empty
			Else 
				_nv_Tentrangthai_en=value.Trim
			End If
		End Set
	End Property

	Public Property v_Mau_Chu() AS String Implements ICRM_DM_TRANGTHAIEntity.v_Mau_Chu
		Get 
			Return _v_Mau_Chu
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_v_Mau_Chu=String.Empty
			Else 
				_v_Mau_Chu=value.Trim
			End If
		End Set
	End Property

	Public Property v_Mau_Nen() AS String Implements ICRM_DM_TRANGTHAIEntity.v_Mau_Nen
		Get 
			Return _v_Mau_Nen
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_v_Mau_Nen=String.Empty
			Else 
				_v_Mau_Nen=value.Trim
			End If
		End Set
	End Property

	Public Property i_Type() AS Int32 Implements ICRM_DM_TRANGTHAIEntity.i_Type
		Get 
			Return _i_Type
		End Get
		Set(ByVal value As Int32)
			_i_Type=value
		End Set
	End Property

End Class
