Public Class CTKM_MATHANG_CHITIETEntity 
	Implements ICTKM_MATHANG_CHITIETEntity 

	Private _uId_CTKM_Chitiet AS String
	Private _uId_Mathang AS String
	Private _uId_ChuongtrinhKhuyenmai AS String
	Private _f_phantramGiamgia AS Double
	Private _f_DonghangGia AS Double
	Private _uId_Dichvutang AS String
	Private _uId_Mathangtang AS String
	
	Public Property uId_CTKM_Chitiet() AS String Implements ICTKM_MATHANG_CHITIETEntity.uId_CTKM_Chitiet
		Get 
			Return _uId_CTKM_Chitiet
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_CTKM_Chitiet=String.Empty
			Else 
				_uId_CTKM_Chitiet=value.Trim
			End If
		End Set
	End Property

	Public Property uId_Mathang() AS String Implements ICTKM_MATHANG_CHITIETEntity.uId_Mathang
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

	Public Property uId_ChuongtrinhKhuyenmai() AS String Implements ICTKM_MATHANG_CHITIETEntity.uId_ChuongtrinhKhuyenmai
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

	Public Property f_phantramGiamgia() AS Double Implements ICTKM_MATHANG_CHITIETEntity.f_phantramGiamgia
		Get 
			Return _f_phantramGiamgia
		End Get
		Set(ByVal value As Double)
			_f_phantramGiamgia=value
		End Set
	End Property

	Public Property f_DonghangGia() AS Double Implements ICTKM_MATHANG_CHITIETEntity.f_DonghangGia
		Get 
			Return _f_DonghangGia
		End Get
		Set(ByVal value As Double)
			_f_DonghangGia=value
		End Set
	End Property

	Public Property uId_Dichvutang() AS String Implements ICTKM_MATHANG_CHITIETEntity.uId_Dichvutang
		Get 
			Return _uId_Dichvutang
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Dichvutang=String.Empty
			Else 
				_uId_Dichvutang=value.Trim
			End If
		End Set
	End Property

	Public Property uId_Mathangtang() AS String Implements ICTKM_MATHANG_CHITIETEntity.uId_Mathangtang
		Get 
			Return _uId_Mathangtang
		End Get
		Set(ByVal value As String)
			If(value = Nothing) Then
				_uId_Mathangtang=String.Empty
			Else 
				_uId_Mathangtang=value.Trim
			End If
		End Set
	End Property

End Class
