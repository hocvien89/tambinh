Public Class QT_PHANQUYENEntity 
	Implements IQT_PHANQUYENEntity 

	Private _uId_Nhanvien AS String
	Private _uId_Chucnang AS String
	Private _b_Enable AS Boolean
	Private _b_Visible AS Boolean
	Private _nv_Tenchucnang_vn AS String
	Private _v_Manhanvien AS String
	Private _nv_Hoten_vn AS String
	Private _d_Ngaysinh AS DateTime
	Private _d_NgaysinhB AS String
	Private _nv_Chucvu_vn AS String

	Public Property uId_Nhanvien() AS String Implements IQT_PHANQUYENEntity.uId_Nhanvien
		Get 
			Return _uId_Nhanvien
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Nhanvien=String.Empty
			Else 
				_uId_Nhanvien=value.Trim
			End If
		End Set
	End Property

	Public Property uId_Chucnang() AS String Implements IQT_PHANQUYENEntity.uId_Chucnang
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

	Public Property b_Enable() AS Boolean Implements IQT_PHANQUYENEntity.b_Enable
		Get 
			Return _b_Enable
		End Get
		Set(ByVal value As Boolean)
			_b_Enable=value
		End Set
	End Property

	Public Property b_Visible() AS Boolean Implements IQT_PHANQUYENEntity.b_Visible
		Get 
			Return _b_Visible
		End Get
		Set(ByVal value As Boolean)
			_b_Visible=value
		End Set
	End Property

	Public Property nv_Tenchucnang_vn() AS String
		Get 
			Return _nv_Tenchucnang_vn
		End Get
		Set(ByVal value As String)
			_nv_Tenchucnang_vn=value
		End Set
	End Property

	Public Property v_Manhanvien() AS String
		Get 
			Return _v_Manhanvien
		End Get
		Set(ByVal value As String)
			_v_Manhanvien=value
		End Set
	End Property

	Public Property nv_Hoten_vn() AS String
		Get 
			Return _nv_Hoten_vn
		End Get
		Set(ByVal value As String)
			_nv_Hoten_vn=value
		End Set
	End Property

	Public Property d_Ngaysinh() AS DateTime
		Get 
			Return Date.Parse(_d_Ngaysinh).ToShortDateString
		End Get
		Set(ByVal value As DateTime)
			_d_Ngaysinh=value
		End Set
	End Property

	Public Property nv_Chucvu_vn() AS String
		Get 
			Return _nv_Chucvu_vn
		End Get
		Set(ByVal value As String)
			_nv_Chucvu_vn=value
		End Set
	End Property

End Class
