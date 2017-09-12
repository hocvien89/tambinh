Public Class TNTP_KHACHHANG_CHITIEUTHAMDOEntity 
	Implements ITNTP_KHACHHANG_CHITIEUTHAMDOEntity 

	Private _uId_Khachhang AS String
	Private _uId_Chitieuthamdo AS String
	Private _d_Ngaythamdo AS DateTime
	Private _d_NgaythamdoB AS String
	Private _f_Giatri_So AS Double
	Private _nv_Giatri_Xau_vn AS String
	Private _nv_Giatri_Xau_en AS String
    Private _b_Giatri_Bit As Boolean
	Private _nv_Ghichu_vn AS String
	Private _nv_Ghichu_en AS String
	Private _nv_Tenchitieuthamdo_vn AS String
	Private _v_Makhachang AS String
	Private _nv_Hoten_vn AS String

	Public Property uId_Khachhang() AS String Implements ITNTP_KHACHHANG_CHITIEUTHAMDOEntity.uId_Khachhang
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

	Public Property uId_Chitieuthamdo() AS String Implements ITNTP_KHACHHANG_CHITIEUTHAMDOEntity.uId_Chitieuthamdo
		Get 
			Return _uId_Chitieuthamdo
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Chitieuthamdo=String.Empty
			Else 
				_uId_Chitieuthamdo=value.Trim
			End If
		End Set
	End Property

	Public Property d_Ngaythamdo() AS DateTime Implements ITNTP_KHACHHANG_CHITIEUTHAMDOEntity.d_Ngaythamdo
		Get 
			Return Date.Parse(_d_Ngaythamdo).ToShortDateString
		End Get
		Set(ByVal value As DateTime)
			_d_Ngaythamdo=value
		End Set
	End Property

	Public Property d_NgaythamdoB() AS String
		Get 
			If(_d_Ngaythamdo=Nothing) Then
				Return String.Empty
			Else
				Return CStr(Format(_d_Ngaythamdo, "dd/MM/yyyy"))
			End If
		End Get
		Set(ByVal value As String)
			_d_Ngaythamdo=value
		End Set
	End Property

	Public Property f_Giatri_So() AS Double Implements ITNTP_KHACHHANG_CHITIEUTHAMDOEntity.f_Giatri_So
		Get 
			Return _f_Giatri_So
		End Get
		Set(ByVal value As Double)
			_f_Giatri_So=value
		End Set
	End Property

	Public Property nv_Giatri_Xau_vn() AS String Implements ITNTP_KHACHHANG_CHITIEUTHAMDOEntity.nv_Giatri_Xau_vn
		Get 
			Return _nv_Giatri_Xau_vn
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Giatri_Xau_vn=String.Empty
			Else 
				_nv_Giatri_Xau_vn=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Giatri_Xau_en() AS String Implements ITNTP_KHACHHANG_CHITIEUTHAMDOEntity.nv_Giatri_Xau_en
		Get 
			Return _nv_Giatri_Xau_en
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Giatri_Xau_en=String.Empty
			Else 
				_nv_Giatri_Xau_en=value.Trim
			End If
		End Set
	End Property

    Public Property b_Giatri_Bit() As Boolean Implements ITNTP_KHACHHANG_CHITIEUTHAMDOEntity.b_Giatri_Bit
        Get
            Return _b_Giatri_Bit
        End Get
        Set(ByVal value As Boolean)
            _b_Giatri_Bit = value
        End Set
    End Property

	Public Property nv_Ghichu_vn() AS String Implements ITNTP_KHACHHANG_CHITIEUTHAMDOEntity.nv_Ghichu_vn
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

	Public Property nv_Ghichu_en() AS String Implements ITNTP_KHACHHANG_CHITIEUTHAMDOEntity.nv_Ghichu_en
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

	Public Property nv_Tenchitieuthamdo_vn() AS String
		Get 
			Return _nv_Tenchitieuthamdo_vn
		End Get
		Set(ByVal value As String)
			_nv_Tenchitieuthamdo_vn=value
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

	Public Property nv_Hoten_vn() AS String
		Get 
			Return _nv_Hoten_vn
		End Get
		Set(ByVal value As String)
			_nv_Hoten_vn=value
		End Set
	End Property

End Class
