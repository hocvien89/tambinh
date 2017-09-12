Public Class QLTC_LoaiHinhTTEntity 
	Implements IQLTC_LoaiHinhTTEntity 

	Private _uId_LoaiTT AS String
	Private _nv_TenLoaiTT AS String
	
	Public Property uId_LoaiTT() AS String Implements IQLTC_LoaiHinhTTEntity.uId_LoaiTT
		Get 
			Return _uId_LoaiTT
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_LoaiTT=String.Empty
			Else 
				_uId_LoaiTT=value.Trim
			End If
		End Set
	End Property

	Public Property nv_TenLoaiTT() AS String Implements IQLTC_LoaiHinhTTEntity.nv_TenLoaiTT
		Get 
			Return _nv_TenLoaiTT
		End Get
		Set(ByVal value As String)
			If(value = Nothing) Then
				_nv_TenLoaiTT=String.Empty
			Else 
				_nv_TenLoaiTT=value.Trim
			End If
		End Set
	End Property

End Class
