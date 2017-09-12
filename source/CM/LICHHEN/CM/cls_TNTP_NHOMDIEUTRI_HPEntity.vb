Public Class TNTP_NHOMDIEUTRI_HPEntity 
	Implements ITNTP_NHOMDIEUTRI_HPEntity 

	Private _uId_Nhomdieutri AS String
	Private _uId_Khachhang AS String
	Private _uId_Nhomdichvu AS String
	Private _f_LephiTong AS Double
	Private _nv_Chandoan_vn AS String
	Private _nv_Chandoan_en AS String

	Public Property uId_Nhomdieutri() AS String Implements ITNTP_NHOMDIEUTRI_HPEntity.uId_Nhomdieutri
		Get 
			Return _uId_Nhomdieutri
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Nhomdieutri=String.Empty
			Else 
				_uId_Nhomdieutri=value.Trim
			End If
		End Set
	End Property

	Public Property uId_Khachhang() AS String Implements ITNTP_NHOMDIEUTRI_HPEntity.uId_Khachhang
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

	Public Property uId_Nhomdichvu() AS String Implements ITNTP_NHOMDIEUTRI_HPEntity.uId_Nhomdichvu
		Get 
			Return _uId_Nhomdichvu
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Nhomdichvu=String.Empty
			Else 
				_uId_Nhomdichvu=value.Trim
			End If
		End Set
	End Property

	Public Property f_LephiTong() AS Double Implements ITNTP_NHOMDIEUTRI_HPEntity.f_LephiTong
		Get 
			Return _f_LephiTong
		End Get
		Set(ByVal value As Double)
			_f_LephiTong=value
		End Set
	End Property

	Public Property nv_Chandoan_vn() AS String Implements ITNTP_NHOMDIEUTRI_HPEntity.nv_Chandoan_vn
		Get 
			Return _nv_Chandoan_vn
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Chandoan_vn=String.Empty
			Else 
				_nv_Chandoan_vn=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Chandoan_en() AS String Implements ITNTP_NHOMDIEUTRI_HPEntity.nv_Chandoan_en
		Get 
			Return _nv_Chandoan_en
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Chandoan_en=String.Empty
			Else 
				_nv_Chandoan_en=value.Trim
			End If
		End Set
	End Property

End Class
