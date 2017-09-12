Public Class PQP_TRANGTHAIKHCHOXULYEntity 
	Implements IPQP_TRANGTHAIKHCHOXULYEntity 

	Private _uId_TrangthaiKH AS String
	Private _uId_Khachhang AS String
	Private _uId_Trangthai AS String
	Private _d_ThoigianchuyenTT AS DateTime
	Private _d_ThoigianchuyenTTB AS String
    Private _uId_Phong As String
	
	Public Property uId_TrangthaiKH() AS String Implements IPQP_TRANGTHAIKHCHOXULYEntity.uId_TrangthaiKH
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

	Public Property uId_Khachhang() AS String Implements IPQP_TRANGTHAIKHCHOXULYEntity.uId_Khachhang
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

	Public Property uId_Trangthai() AS String Implements IPQP_TRANGTHAIKHCHOXULYEntity.uId_Trangthai
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

	Public Property d_ThoigianchuyenTT() AS DateTime Implements IPQP_TRANGTHAIKHCHOXULYEntity.d_ThoigianchuyenTT
		Get 
			Return Date.Parse(_d_ThoigianchuyenTT).ToShortDateString
		End Get
		Set(ByVal value As DateTime)
			_d_ThoigianchuyenTT=value
		End Set
	End Property

	Public Property d_ThoigianchuyenTTB() AS String
		Get 
			If(_d_ThoigianchuyenTT=Nothing) Then
				Return String.Empty
			Else
				Return CStr(Format(_d_ThoigianchuyenTT, "dd/MM/yyyy"))
			End If
		End Get
		Set(ByVal value As String)
			_d_ThoigianchuyenTT=value
		End Set
	End Property

    Public Property uId_Phong() As String Implements IPQP_TRANGTHAIKHCHOXULYEntity.uId_Phong
        Get
            Return _uId_Phong
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Phong = String.Empty
            Else
                _uId_Phong = value.Trim
            End If
        End Set
    End Property

End Class
