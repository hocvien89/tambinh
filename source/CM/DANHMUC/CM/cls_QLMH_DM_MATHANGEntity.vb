Public Class QLMH_DM_MATHANGEntity 
	Implements IQLMH_DM_MATHANGEntity 

	Private _uId_Mathang AS String
	Private _uId_Nhommathang AS String
	Private _uId_Loaimathang AS String
	Private _uId_Xuatxu AS String
    Private _v_MaMathang As String
    Private _v_MaBarcode As String
	Private _nv_TenMathang_vn AS String
	Private _nv_TenMathang_en AS String
	Private _nv_DVT_vn AS String
	Private _nv_DVT_en AS String
	Private _f_PhantramHH_KTV AS Double
	Private _f_PhantramHH_TVV AS Double
	Private _f_PhamtramHH_CTV AS Double
	Private _f_PhantramHH_NV AS Double
	Private _f_Hanmuc_Ton AS Double
	Private _i_Songaycanhbao_Ton AS Int32
	Private _i_Songaycanhbao_HethanSD AS Int32
	Private _nv_Ghichu_vn AS String
	Private _nv_Ghichu_en AS String
	Private _d_Ngay AS DateTime
	Private _d_NgayB AS String
	Private _f_Gianhap AS Double
	Private _f_Biendo_Gianhap AS Double
	Private _f_Giaban AS Double
	Private _f_Biendo_Giaban AS Double

	Public Property uId_Mathang() AS String Implements IQLMH_DM_MATHANGEntity.uId_Mathang
		Get 
			Return _uId_Mathang
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Mathang=String.Empty
			Else 
				_uId_Mathang=value.Trim
			End If
		End Set
	End Property

	Public Property uId_Nhommathang() AS String Implements IQLMH_DM_MATHANGEntity.uId_Nhommathang
		Get 
			Return _uId_Nhommathang
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Nhommathang=String.Empty
			Else 
				_uId_Nhommathang=value.Trim
			End If
		End Set
	End Property

	Public Property uId_Loaimathang() AS String Implements IQLMH_DM_MATHANGEntity.uId_Loaimathang
		Get 
			Return _uId_Loaimathang
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Loaimathang=String.Empty
			Else 
				_uId_Loaimathang=value.Trim
			End If
		End Set
	End Property

	Public Property uId_Xuatxu() AS String Implements IQLMH_DM_MATHANGEntity.uId_Xuatxu
		Get 
			Return _uId_Xuatxu
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Xuatxu=String.Empty
			Else 
				_uId_Xuatxu=value.Trim
			End If
		End Set
	End Property

	Public Property v_MaMathang() AS String Implements IQLMH_DM_MATHANGEntity.v_MaMathang
		Get 
			Return _v_MaMathang
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_v_MaMathang=String.Empty
			Else 
				_v_MaMathang=value.Trim
			End If
		End Set
	End Property
    Public Property v_MaBarcode() As String Implements IQLMH_DM_MATHANGEntity.v_MaBarcode
        Get
            Return _v_MaBarcode
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _v_MaBarcode = String.Empty
            Else
                _v_MaBarcode = value.Trim
            End If
        End Set
    End Property

	Public Property nv_TenMathang_vn() AS String Implements IQLMH_DM_MATHANGEntity.nv_TenMathang_vn
		Get 
			Return _nv_TenMathang_vn
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_TenMathang_vn=String.Empty
			Else 
				_nv_TenMathang_vn=value.Trim
			End If
		End Set
	End Property

	Public Property nv_TenMathang_en() AS String Implements IQLMH_DM_MATHANGEntity.nv_TenMathang_en
		Get 
			Return _nv_TenMathang_en
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_TenMathang_en=String.Empty
			Else 
				_nv_TenMathang_en=value.Trim
			End If
		End Set
	End Property

	Public Property nv_DVT_vn() AS String Implements IQLMH_DM_MATHANGEntity.nv_DVT_vn
		Get 
			Return _nv_DVT_vn
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_DVT_vn=String.Empty
			Else 
				_nv_DVT_vn=value.Trim
			End If
		End Set
	End Property

	Public Property nv_DVT_en() AS String Implements IQLMH_DM_MATHANGEntity.nv_DVT_en
		Get 
			Return _nv_DVT_en
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_DVT_en=String.Empty
			Else 
				_nv_DVT_en=value.Trim
			End If
		End Set
	End Property

	Public Property f_PhantramHH_KTV() AS Double Implements IQLMH_DM_MATHANGEntity.f_PhantramHH_KTV
		Get 
			Return _f_PhantramHH_KTV
		End Get
		Set(ByVal value As Double)
			_f_PhantramHH_KTV=value
		End Set
	End Property

	Public Property f_PhantramHH_TVV() AS Double Implements IQLMH_DM_MATHANGEntity.f_PhantramHH_TVV
		Get 
			Return _f_PhantramHH_TVV
		End Get
		Set(ByVal value As Double)
			_f_PhantramHH_TVV=value
		End Set
	End Property

	Public Property f_PhamtramHH_CTV() AS Double Implements IQLMH_DM_MATHANGEntity.f_PhamtramHH_CTV
		Get 
			Return _f_PhamtramHH_CTV
		End Get
		Set(ByVal value As Double)
			_f_PhamtramHH_CTV=value
		End Set
	End Property

	Public Property f_PhantramHH_NV() AS Double Implements IQLMH_DM_MATHANGEntity.f_PhantramHH_NV
		Get 
			Return _f_PhantramHH_NV
		End Get
		Set(ByVal value As Double)
			_f_PhantramHH_NV=value
		End Set
	End Property

	Public Property f_Hanmuc_Ton() AS Double Implements IQLMH_DM_MATHANGEntity.f_Hanmuc_Ton
		Get 
			Return _f_Hanmuc_Ton
		End Get
		Set(ByVal value As Double)
			_f_Hanmuc_Ton=value
		End Set
	End Property

	Public Property i_Songaycanhbao_Ton() AS Int32 Implements IQLMH_DM_MATHANGEntity.i_Songaycanhbao_Ton
		Get 
			Return _i_Songaycanhbao_Ton
		End Get
		Set(ByVal value As Int32)
			_i_Songaycanhbao_Ton=value
		End Set
	End Property

	Public Property i_Songaycanhbao_HethanSD() AS Int32 Implements IQLMH_DM_MATHANGEntity.i_Songaycanhbao_HethanSD
		Get 
			Return _i_Songaycanhbao_HethanSD
		End Get
		Set(ByVal value As Int32)
			_i_Songaycanhbao_HethanSD=value
		End Set
	End Property

	Public Property nv_Ghichu_vn() AS String Implements IQLMH_DM_MATHANGEntity.nv_Ghichu_vn
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

	Public Property nv_Ghichu_en() AS String Implements IQLMH_DM_MATHANGEntity.nv_Ghichu_en
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


	Public Property d_Ngay() AS DateTime
		Get 
			Return Date.Parse(_d_Ngay).ToShortDateString
		End Get
		Set(ByVal value As DateTime)
			_d_Ngay=value
		End Set
	End Property

	Public Property f_Gianhap() AS Double
		Get 
			Return _f_Gianhap
		End Get
		Set(ByVal value As Double)
			_f_Gianhap=value
		End Set
	End Property

	Public Property f_Biendo_Gianhap() AS Double
		Get 
			Return _f_Biendo_Gianhap
		End Get
		Set(ByVal value As Double)
			_f_Biendo_Gianhap=value
		End Set
	End Property

	Public Property f_Giaban() AS Double
		Get 
			Return _f_Giaban
		End Get
		Set(ByVal value As Double)
			_f_Giaban=value
		End Set
	End Property

	Public Property f_Biendo_Giaban() AS Double
		Get 
			Return _f_Biendo_Giaban
		End Get
		Set(ByVal value As Double)
			_f_Biendo_Giaban=value
		End Set
	End Property

End Class
