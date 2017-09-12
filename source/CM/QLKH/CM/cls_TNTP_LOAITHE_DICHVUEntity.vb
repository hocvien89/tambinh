Public Class TNTP_LOAITHE_DICHVUEntity 
	Implements ITNTP_LOAITHE_DICHVUEntity 

	Private _uId_Loaithe AS String
	Private _uId_Dichvu AS String
	Private _nv_Tendichvu_vn AS String

	Public Property uId_Loaithe() AS String Implements ITNTP_LOAITHE_DICHVUEntity.uId_Loaithe
		Get 
			Return _uId_Loaithe
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Loaithe=String.Empty
			Else 
				_uId_Loaithe=value.Trim
			End If
		End Set
	End Property

	Public Property uId_Dichvu() AS String Implements ITNTP_LOAITHE_DICHVUEntity.uId_Dichvu
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

	Public Property nv_Tendichvu_vn() AS String
		Get 
			Return _nv_Tendichvu_vn
		End Get
		Set(ByVal value As String)
			_nv_Tendichvu_vn=value
		End Set
	End Property

End Class
