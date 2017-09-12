Public Class QT_DM_NHANVIENEntity 
	Implements IQT_DM_NHANVIENEntity 

	Private _uId_Nhanvien AS String
	Private _v_Barcode AS String
	Private _v_Manhanvien AS String
	Private _nv_Hoten_vn AS String
	Private _nv_Hoten_en AS String
	Private _d_Ngaysinh AS DateTime
	Private _d_NgaysinhB AS String
	Private _nv_Chucvu_vn AS String
	Private _nv_Chucvu_en AS String
	Private _nv_Diachi_vn AS String
	Private _nv_Diachi_en AS String
	Private _nv_Quequan_vn AS String
	Private _nv_Quequan_en AS String
	Private _v_Dienthoai AS String
	Private _v_Email AS String
	Private _v_Tendangnhap AS String
	Private _v_Matkhau AS String
    Private _b_ActiveLogin As Boolean
	Private _d_Ngayvaolam AS DateTime
	Private _d_NgayvaolamB AS String
    Private _b_Danglamviec As Boolean
	
	Public Property uId_Nhanvien() AS String Implements IQT_DM_NHANVIENEntity.uId_Nhanvien
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

	Public Property v_Barcode() AS String Implements IQT_DM_NHANVIENEntity.v_Barcode
		Get 
			Return _v_Barcode
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_v_Barcode=String.Empty
			Else 
				_v_Barcode=value.Trim
			End If
		End Set
	End Property

	Public Property v_Manhanvien() AS String Implements IQT_DM_NHANVIENEntity.v_Manhanvien
		Get 
			Return _v_Manhanvien
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_v_Manhanvien=String.Empty
			Else 
				_v_Manhanvien=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Hoten_vn() AS String Implements IQT_DM_NHANVIENEntity.nv_Hoten_vn
		Get 
			Return _nv_Hoten_vn
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Hoten_vn=String.Empty
			Else 
				_nv_Hoten_vn=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Hoten_en() AS String Implements IQT_DM_NHANVIENEntity.nv_Hoten_en
		Get 
			Return _nv_Hoten_en
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Hoten_en=String.Empty
			Else 
				_nv_Hoten_en=value.Trim
			End If
		End Set
	End Property

	Public Property d_Ngaysinh() AS DateTime Implements IQT_DM_NHANVIENEntity.d_Ngaysinh
		Get 
			Return Date.Parse(_d_Ngaysinh).ToShortDateString
		End Get
		Set(ByVal value As DateTime)
			_d_Ngaysinh=value
		End Set
	End Property
    Public ReadOnly Property d_NgaySinhText() As String
        Get
            If (_d_Ngaysinh = Nothing) Then
                Return String.Empty
            Else
                Return CStr(Format(_d_Ngaysinh, "dd/MM/yyyy"))
            End If
        End Get
    End Property
	Public Property d_NgaysinhB() AS String
		Get 
			If(_d_Ngaysinh=Nothing) Then
				Return String.Empty
			Else
				Return CStr(Format(_d_Ngaysinh, "dd/MM/yyyy"))
			End If
		End Get
		Set(ByVal value As String)
			_d_Ngaysinh=value
		End Set
	End Property

	Public Property nv_Chucvu_vn() AS String Implements IQT_DM_NHANVIENEntity.nv_Chucvu_vn
		Get 
			Return _nv_Chucvu_vn
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Chucvu_vn=String.Empty
			Else 
				_nv_Chucvu_vn=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Chucvu_en() AS String Implements IQT_DM_NHANVIENEntity.nv_Chucvu_en
		Get 
			Return _nv_Chucvu_en
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Chucvu_en=String.Empty
			Else 
				_nv_Chucvu_en=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Diachi_vn() AS String Implements IQT_DM_NHANVIENEntity.nv_Diachi_vn
		Get 
			Return _nv_Diachi_vn
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Diachi_vn=String.Empty
			Else 
				_nv_Diachi_vn=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Diachi_en() AS String Implements IQT_DM_NHANVIENEntity.nv_Diachi_en
		Get 
			Return _nv_Diachi_en
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Diachi_en=String.Empty
			Else 
				_nv_Diachi_en=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Quequan_vn() AS String Implements IQT_DM_NHANVIENEntity.nv_Quequan_vn
		Get 
			Return _nv_Quequan_vn
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Quequan_vn=String.Empty
			Else 
				_nv_Quequan_vn=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Quequan_en() AS String Implements IQT_DM_NHANVIENEntity.nv_Quequan_en
		Get 
			Return _nv_Quequan_en
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Quequan_en=String.Empty
			Else 
				_nv_Quequan_en=value.Trim
			End If
		End Set
	End Property

	Public Property v_Dienthoai() AS String Implements IQT_DM_NHANVIENEntity.v_Dienthoai
		Get 
			Return _v_Dienthoai
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_v_Dienthoai=String.Empty
			Else 
				_v_Dienthoai=value.Trim
			End If
		End Set
	End Property

	Public Property v_Email() AS String Implements IQT_DM_NHANVIENEntity.v_Email
		Get 
			Return _v_Email
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_v_Email=String.Empty
			Else 
				_v_Email=value.Trim
			End If
		End Set
	End Property

	Public Property v_Tendangnhap() AS String Implements IQT_DM_NHANVIENEntity.v_Tendangnhap
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

	Public Property v_Matkhau() AS String Implements IQT_DM_NHANVIENEntity.v_Matkhau
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

    Public Property b_ActiveLogin() As Boolean Implements IQT_DM_NHANVIENEntity.b_ActiveLogin
        Get
            Return _b_ActiveLogin
        End Get
        Set(ByVal value As Boolean)
            _b_ActiveLogin = value
        End Set
    End Property

	Public Property d_Ngayvaolam() AS DateTime Implements IQT_DM_NHANVIENEntity.d_Ngayvaolam
		Get 
			Return Date.Parse(_d_Ngayvaolam).ToShortDateString
		End Get
		Set(ByVal value As DateTime)
			_d_Ngayvaolam=value
		End Set
	End Property

	Public Property d_NgayvaolamB() AS String
		Get 
			If(_d_Ngayvaolam=Nothing) Then
				Return String.Empty
			Else
				Return CStr(Format(_d_Ngayvaolam, "dd/MM/yyyy"))
			End If
		End Get
		Set(ByVal value As String)
			_d_Ngayvaolam=value
		End Set
	End Property

    Public Property b_Danglamviec() As Boolean Implements IQT_DM_NHANVIENEntity.b_Danglamviec
        Get
            Return _b_Danglamviec
        End Get
        Set(ByVal value As Boolean)
            _b_Danglamviec = value
        End Set
    End Property

End Class
