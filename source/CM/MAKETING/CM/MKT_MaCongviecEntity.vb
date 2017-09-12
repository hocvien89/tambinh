Public Class MKT_MaCongviecEntity 
	Implements IMKT_MaCongviecEntity 

	Private _uId_MaCongviec AS String
	Private _nv_TenMaCongviec AS String
	Private _nv_Ghichu AS String
	
	Public Property uId_MaCongviec() AS String Implements IMKT_MaCongviecEntity.uId_MaCongviec
		Get 
			Return _uId_MaCongviec
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_MaCongviec=String.Empty
			Else 
				_uId_MaCongviec=value.Trim
			End If
		End Set
	End Property

	Public Property nv_TenMaCongviec() AS String Implements IMKT_MaCongviecEntity.nv_TenMaCongviec
		Get 
			Return _nv_TenMaCongviec
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_TenMaCongviec=String.Empty
			Else 
				_nv_TenMaCongviec=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Ghichu() AS String Implements IMKT_MaCongviecEntity.nv_Ghichu
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
