Public Class TNTP_DM_KHUYENMAIEntity 
	Implements ITNTP_DM_KHUYENMAIEntity 

	Private _uId_DM_Khuyenmai AS String
	Private _v_MaKhuyenMai AS String
	Private _nv_TenKhuyenMai AS String
	Private _nv_Ghichu AS String
	
	Public Property uId_DM_Khuyenmai() AS String Implements ITNTP_DM_KHUYENMAIEntity.uId_DM_Khuyenmai
		Get 
			Return _uId_DM_Khuyenmai
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_DM_Khuyenmai=String.Empty
			Else 
				_uId_DM_Khuyenmai=value.Trim
			End If
		End Set
	End Property

	Public Property v_MaKhuyenMai() AS String Implements ITNTP_DM_KHUYENMAIEntity.v_MaKhuyenMai
		Get 
			Return _v_MaKhuyenMai
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_v_MaKhuyenMai=String.Empty
			Else 
				_v_MaKhuyenMai=value.Trim
			End If
		End Set
	End Property

	Public Property nv_TenKhuyenMai() AS String Implements ITNTP_DM_KHUYENMAIEntity.nv_TenKhuyenMai
		Get 
			Return _nv_TenKhuyenMai
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_TenKhuyenMai=String.Empty
			Else 
				_nv_TenKhuyenMai=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Ghichu() AS String Implements ITNTP_DM_KHUYENMAIEntity.nv_Ghichu
		Get 
			Return _nv_Ghichu
		End Get
		Set(ByVal value As String)
			If(value = Nothing) Then
				_nv_Ghichu=String.Empty
			Else 
				_nv_Ghichu=value.Trim
			End If
		End Set
	End Property

End Class
