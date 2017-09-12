Public Class KHQT_KHACHHANG_USEREntity 
	Implements IKHQT_KHACHHANG_USEREntity 

	Private _uId_Khachhang AS String
	Private _v_Tendangnhap AS String
	Private _v_Matkhau AS String
	Private _b_Kichhoat AS Boolean

	Public Property uId_Khachhang() AS String Implements IKHQT_KHACHHANG_USEREntity.uId_Khachhang
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

	Public Property v_Tendangnhap() AS String Implements IKHQT_KHACHHANG_USEREntity.v_Tendangnhap
		Get 
			Return _v_Tendangnhap
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_v_Tendangnhap=String.Empty
			Else 
				_v_Tendangnhap=value.Trim
			End If
		End Set
	End Property

	Public Property v_Matkhau() AS String Implements IKHQT_KHACHHANG_USEREntity.v_Matkhau
		Get 
			Return _v_Matkhau
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_v_Matkhau=String.Empty
			Else 
				_v_Matkhau=value.Trim
			End If
		End Set
	End Property

	Public Property b_Kichhoat() AS Boolean Implements IKHQT_KHACHHANG_USEREntity.b_Kichhoat
		Get 
			Return _b_Kichhoat
		End Get
		Set(ByVal value As Boolean)
			_b_Kichhoat=value
		End Set
	End Property

End Class
