Public Class TNTP_QT_DIEUTRI_HPEntity 
	Implements ITNTP_QT_DIEUTRI_HPEntity 

	Private _uId_QT_Dieutri_HP AS String
	Private _uId_Khachhang AS String
	Private _uId_Nhanvien AS String
	Private _uId_Dichvu AS String
	Private _i_Lanthu AS Int32
	Private _d_NgayDT AS DateTime
	Private _d_NgayDTB AS String
	Private _nv_GiatriDT_vn AS String
	Private _nv_GiatriDT_en AS String
	Private _nv_Hinhanh AS String
	Private _nv_Ghichu_vn AS String
	Private _nv_Ghichu_en AS String
	Private _nv_Tendichvu_vn AS String
	Private _f_Gia AS Double
	Private _v_Manhanvien AS String
    Private _nv_Hoten_vn As String
    Private _f_Lephi_DT As Double

	Public Property uId_QT_Dieutri_HP() AS String Implements ITNTP_QT_DIEUTRI_HPEntity.uId_QT_Dieutri_HP
		Get 
			Return _uId_QT_Dieutri_HP
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_QT_Dieutri_HP=String.Empty
			Else 
				_uId_QT_Dieutri_HP=value.Trim
			End If
		End Set
	End Property

	Public Property uId_Khachhang() AS String Implements ITNTP_QT_DIEUTRI_HPEntity.uId_Khachhang
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

	Public Property uId_Nhanvien() AS String Implements ITNTP_QT_DIEUTRI_HPEntity.uId_Nhanvien
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

	Public Property uId_Dichvu() AS String Implements ITNTP_QT_DIEUTRI_HPEntity.uId_Dichvu
		Get 
			Return _uId_Dichvu
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Dichvu=String.Empty
			Else 
				_uId_Dichvu=value.Trim
			End If
		End Set
	End Property

	Public Property i_Lanthu() AS Int32 Implements ITNTP_QT_DIEUTRI_HPEntity.i_Lanthu
		Get 
			Return _i_Lanthu
		End Get
		Set(ByVal value As Int32)
			_i_Lanthu=value
		End Set
	End Property

	Public Property d_NgayDT() AS DateTime Implements ITNTP_QT_DIEUTRI_HPEntity.d_NgayDT
		Get 
			Return Date.Parse(_d_NgayDT).ToShortDateString
		End Get
		Set(ByVal value As DateTime)
			_d_NgayDT=value
		End Set
	End Property

	Public Property d_NgayDTB() AS String
		Get 
			If(_d_NgayDT=Nothing) Then
				Return String.Empty
			Else
				Return CStr(Format(_d_NgayDT, "dd/MM/yyyy"))
			End If
		End Get
		Set(ByVal value As String)
			_d_NgayDT=value
		End Set
	End Property

	Public Property nv_GiatriDT_vn() AS String Implements ITNTP_QT_DIEUTRI_HPEntity.nv_GiatriDT_vn
		Get 
			Return _nv_GiatriDT_vn
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_GiatriDT_vn=String.Empty
			Else 
				_nv_GiatriDT_vn=value.Trim
			End If
		End Set
	End Property

	Public Property nv_GiatriDT_en() AS String Implements ITNTP_QT_DIEUTRI_HPEntity.nv_GiatriDT_en
		Get 
			Return _nv_GiatriDT_en
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_GiatriDT_en=String.Empty
			Else 
				_nv_GiatriDT_en=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Hinhanh() AS String Implements ITNTP_QT_DIEUTRI_HPEntity.nv_Hinhanh
		Get 
			Return _nv_Hinhanh
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Hinhanh=String.Empty
			Else 
				_nv_Hinhanh=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Ghichu_vn() AS String Implements ITNTP_QT_DIEUTRI_HPEntity.nv_Ghichu_vn
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

	Public Property nv_Ghichu_en() AS String Implements ITNTP_QT_DIEUTRI_HPEntity.nv_Ghichu_en
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

    Public Property f_Lephi_DT() As Double Implements ITNTP_QT_DIEUTRI_HPEntity.f_Lephi_DT
        Get
            Return _f_Lephi_DT
        End Get
        Set(ByVal value As Double)
            _f_Lephi_DT = value
        End Set
    End Property


	Public Property nv_Tendichvu_vn() AS String
		Get 
			Return _nv_Tendichvu_vn
		End Get
		Set(ByVal value As String)
			_nv_Tendichvu_vn=value
		End Set
	End Property

	Public Property f_Gia() AS Double
		Get 
			Return _f_Gia
		End Get
		Set(ByVal value As Double)
			_f_Gia=value
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

End Class
