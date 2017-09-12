Public Class CRM_LICHHEN_HPEntity 
	Implements ICRM_LICHHEN_HPEntity 

	Private _uId_Lichhen_HP AS String
	Private _d_Tungay AS DateTime
	Private _d_TungayB AS String
	Private _d_Denngay AS DateTime
	Private _d_DenngayB AS String
	Private _uId_Khachhang AS String
	Private _uId_Nhanvien AS String
	Private _nv_Ghichu_vn AS String
	Private _nv_Ghichu_en AS String
	Private _uId_Trangthai AS String
	Private _v_Makhachang AS String
	Private _v_DienthoaiDD AS String
	Private _v_Manhanvien AS String
    Private _nv_HotenKhachhang_vn As String
    Private _nv_HotenNhanvien_vn As String
	Private _nv_Tentrangthai_vn AS String

	Public Property uId_Lichhen_HP() AS String Implements ICRM_LICHHEN_HPEntity.uId_Lichhen_HP
		Get 
			Return _uId_Lichhen_HP
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Lichhen_HP=String.Empty
			Else 
				_uId_Lichhen_HP=value.Trim
			End If
		End Set
	End Property

	Public Property d_Tungay() AS DateTime Implements ICRM_LICHHEN_HPEntity.d_Tungay
		Get 
			Return Date.Parse(_d_Tungay).ToShortDateString
		End Get
		Set(ByVal value As DateTime)
			_d_Tungay=value
		End Set
	End Property

	Public Property d_TungayB() AS String
		Get 
			If(_d_Tungay=Nothing) Then
				Return String.Empty
			Else
				Return CStr(Format(_d_Tungay, "dd/MM/yyyy"))
			End If
		End Get
		Set(ByVal value As String)
			_d_Tungay=value
		End Set
	End Property

	Public Property d_Denngay() AS DateTime Implements ICRM_LICHHEN_HPEntity.d_Denngay
		Get 
			Return Date.Parse(_d_Denngay).ToShortDateString
		End Get
		Set(ByVal value As DateTime)
			_d_Denngay=value
		End Set
	End Property

	Public Property d_DenngayB() AS String
		Get 
			If(_d_Denngay=Nothing) Then
				Return String.Empty
			Else
				Return CStr(Format(_d_Denngay, "dd/MM/yyyy"))
			End If
		End Get
		Set(ByVal value As String)
			_d_Denngay=value
		End Set
	End Property

	Public Property uId_Khachhang() AS String Implements ICRM_LICHHEN_HPEntity.uId_Khachhang
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

	Public Property uId_Nhanvien() AS String Implements ICRM_LICHHEN_HPEntity.uId_Nhanvien
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

	Public Property nv_Ghichu_vn() AS String Implements ICRM_LICHHEN_HPEntity.nv_Ghichu_vn
		Get 
			Return _nv_Ghichu_vn
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Ghichu_vn=String.Empty
			Else 
				_nv_Ghichu_vn=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Ghichu_en() AS String Implements ICRM_LICHHEN_HPEntity.nv_Ghichu_en
		Get 
			Return _nv_Ghichu_en
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Ghichu_en=String.Empty
			Else 
				_nv_Ghichu_en=value.Trim
			End If
		End Set
	End Property

	Public Property uId_Trangthai() AS String Implements ICRM_LICHHEN_HPEntity.uId_Trangthai
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

	Public Property v_Makhachang() AS String
		Get 
			Return _v_Makhachang
		End Get
		Set(ByVal value As String)
			_v_Makhachang=value
		End Set
	End Property

    Public Property nv_HotenKhachhang_vn() As String
        Get
            Return _nv_HotenKhachhang_vn
        End Get
        Set(ByVal value As String)
            _nv_HotenKhachhang_vn = value
        End Set
    End Property

    Public Property nv_HotenNhanvien_vn() As String
        Get
            Return _nv_HotenNhanvien_vn
        End Get
        Set(ByVal value As String)
            _nv_HotenNhanvien_vn = value
        End Set
    End Property

	Public Property v_DienthoaiDD() AS String
		Get 
			Return _v_DienthoaiDD
		End Get
		Set(ByVal value As String)
			_v_DienthoaiDD=value
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


	Public Property nv_Tentrangthai_vn() AS String
		Get 
			Return _nv_Tentrangthai_vn
		End Get
		Set(ByVal value As String)
			_nv_Tentrangthai_vn=value
		End Set
	End Property

End Class
