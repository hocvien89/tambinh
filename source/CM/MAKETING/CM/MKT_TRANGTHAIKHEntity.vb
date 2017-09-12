Public Class MKT_TRANGTHAIKHEntity 
	Implements IMKT_TRANGTHAIKHEntity 

	Private _uId_TrangthaiKH AS String
	Private _nv_TenTrangthaiKH_vn AS String
	Private _nv_TenTrangthaiKH_en AS String
	Private _i_SoThuTu AS Int32
	
	Public Property uId_TrangthaiKH() AS String Implements IMKT_TRANGTHAIKHEntity.uId_TrangthaiKH
		Get 
			Return _uId_TrangthaiKH
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_TrangthaiKH=String.Empty
			Else 
				_uId_TrangthaiKH=value.Trim
			End If
		End Set
	End Property

	Public Property nv_TenTrangthaiKH_vn() AS String Implements IMKT_TRANGTHAIKHEntity.nv_TenTrangthaiKH_vn
		Get 
			Return _nv_TenTrangthaiKH_vn
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_TenTrangthaiKH_vn=String.Empty
			Else 
				_nv_TenTrangthaiKH_vn=value.Trim
			End If
		End Set
	End Property

	Public Property nv_TenTrangthaiKH_en() AS String Implements IMKT_TRANGTHAIKHEntity.nv_TenTrangthaiKH_en
		Get 
			Return _nv_TenTrangthaiKH_en
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_TenTrangthaiKH_en=String.Empty
			Else 
				_nv_TenTrangthaiKH_en=value.Trim
			End If
		End Set
	End Property

	Public Property i_SoThuTu() AS Int32 Implements IMKT_TRANGTHAIKHEntity.i_SoThuTu
		Get 
			Return _i_SoThuTu
		End Get
		Set(ByVal value As Int32)
			_i_SoThuTu=value
		End Set
	End Property

End Class
