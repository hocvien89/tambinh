Public Class CRM_KHACHHANGDANHGIAEntity 
	Implements ICRM_KHACHHANGDANHGIAEntity 

	Private _uId_KhachhangDanhgia AS String
	Private _uId_Khachhang AS String
	Private _uId_Danhgia AS String
    Private _f_Mucdanhgia As Int16
	
	Public Property uId_KhachhangDanhgia() AS String Implements ICRM_KHACHHANGDANHGIAEntity.uId_KhachhangDanhgia
		Get 
			Return _uId_KhachhangDanhgia
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_KhachhangDanhgia=String.Empty
			Else 
				_uId_KhachhangDanhgia=value.Trim
			End If
		End Set
	End Property

	Public Property uId_Khachhang() AS String Implements ICRM_KHACHHANGDANHGIAEntity.uId_Khachhang
		Get 
			Return _uId_Khachhang
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Khachhang=String.Empty
			Else 
				_uId_Khachhang=value.Trim
			End If
		End Set
	End Property

	Public Property uId_Danhgia() AS String Implements ICRM_KHACHHANGDANHGIAEntity.uId_Danhgia
		Get 
			Return _uId_Danhgia
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Danhgia=String.Empty
			Else 
				_uId_Danhgia=value.Trim
			End If
		End Set
	End Property

    Public Property f_Mucdanhgia() As Int16 Implements ICRM_KHACHHANGDANHGIAEntity.f_Mucdanhgia
        Get
            Return _f_Mucdanhgia
        End Get
        Set(ByVal value As Int16)
            _f_Mucdanhgia = value
        End Set
    End Property

End Class
