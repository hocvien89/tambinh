Public Class CTKM_DM_CHUONGTRINHKHUYENMAIEntity 
	Implements ICTKM_DM_CHUONGTRINHKHUYENMAIEntity 

	Private _uId_ChuongtrinhKhuyenmai AS String
	Private _nv_TenChuongtrinhKM_vn AS String
	Private _nv_TenChuongtrinhKM_en AS String
	Private _nv_Mota_vn AS String
	Private _nv_Mota_en AS String
	Private _d_ngaybatdau AS DateTime
	Private _d_ngaybatdauB AS String
	Private _d_ngayketthuc AS DateTime
	Private _d_ngayketthucB AS String
	Private _b_Hoatdong AS Boolean
    Private _uId_LoaiGiamgia As String
    Private _uId_Cuahang As String

	
	Public Property uId_ChuongtrinhKhuyenmai() AS String Implements ICTKM_DM_CHUONGTRINHKHUYENMAIEntity.uId_ChuongtrinhKhuyenmai
		Get 
			Return _uId_ChuongtrinhKhuyenmai
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_ChuongtrinhKhuyenmai=String.Empty
			Else 
				_uId_ChuongtrinhKhuyenmai=value.Trim
			End If
		End Set
	End Property

	Public Property nv_TenChuongtrinhKM_vn() AS String Implements ICTKM_DM_CHUONGTRINHKHUYENMAIEntity.nv_TenChuongtrinhKM_vn
		Get 
			Return _nv_TenChuongtrinhKM_vn
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_TenChuongtrinhKM_vn=String.Empty
			Else 
				_nv_TenChuongtrinhKM_vn=value.Trim
			End If
		End Set
	End Property

	Public Property nv_TenChuongtrinhKM_en() AS String Implements ICTKM_DM_CHUONGTRINHKHUYENMAIEntity.nv_TenChuongtrinhKM_en
		Get 
			Return _nv_TenChuongtrinhKM_en
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_TenChuongtrinhKM_en=String.Empty
			Else 
				_nv_TenChuongtrinhKM_en=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Mota_vn() AS String Implements ICTKM_DM_CHUONGTRINHKHUYENMAIEntity.nv_Mota_vn
		Get 
			Return _nv_Mota_vn
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Mota_vn=String.Empty
			Else 
				_nv_Mota_vn=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Mota_en() AS String Implements ICTKM_DM_CHUONGTRINHKHUYENMAIEntity.nv_Mota_en
		Get 
			Return _nv_Mota_en
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Mota_en=String.Empty
			Else 
				_nv_Mota_en=value.Trim
			End If
		End Set
	End Property

	Public Property d_ngaybatdau() AS DateTime Implements ICTKM_DM_CHUONGTRINHKHUYENMAIEntity.d_ngaybatdau
		Get 
			Return Date.Parse(_d_ngaybatdau).ToShortDateString
		End Get
		Set(ByVal value As DateTime)
			_d_ngaybatdau=value
		End Set
	End Property

	Public Property d_ngaybatdauB() AS String
		Get 
			If(_d_ngaybatdau=Nothing) Then
				Return String.Empty
			Else
				Return CStr(Format(_d_ngaybatdau, "dd/MM/yyyy"))
			End If
		End Get
		Set(ByVal value As String)
			_d_ngaybatdau=value
		End Set
	End Property

	Public Property d_ngayketthuc() AS DateTime Implements ICTKM_DM_CHUONGTRINHKHUYENMAIEntity.d_ngayketthuc
		Get 
			Return Date.Parse(_d_ngayketthuc).ToShortDateString
		End Get
		Set(ByVal value As DateTime)
			_d_ngayketthuc=value
		End Set
	End Property

	Public Property d_ngayketthucB() AS String
		Get 
			If(_d_ngayketthuc=Nothing) Then
				Return String.Empty
			Else
				Return CStr(Format(_d_ngayketthuc, "dd/MM/yyyy"))
			End If
		End Get
		Set(ByVal value As String)
			_d_ngayketthuc=value
		End Set
	End Property

	Public Property b_Hoatdong() AS Boolean Implements ICTKM_DM_CHUONGTRINHKHUYENMAIEntity.b_Hoatdong
		Get 
			Return _b_Hoatdong
		End Get
		Set(ByVal value As Boolean)
			_b_Hoatdong=value
		End Set
	End Property

	Public Property uId_LoaiGiamgia() AS String Implements ICTKM_DM_CHUONGTRINHKHUYENMAIEntity.uId_LoaiGiamgia
		Get 
			Return _uId_LoaiGiamgia
		End Get
		Set(ByVal value As String)
			If(value = Nothing) Then
				_uId_LoaiGiamgia=String.Empty
			Else 
				_uId_LoaiGiamgia=value.Trim
			End If
		End Set
	End Property
    Public Property uId_Cuahang() As String Implements ICTKM_DM_CHUONGTRINHKHUYENMAIEntity.uId_Cuahang
        Get
            Return _uId_Cuahang
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Cuahang = String.Empty
            Else
                _uId_Cuahang = value.Trim
            End If
        End Set
    End Property

End Class
