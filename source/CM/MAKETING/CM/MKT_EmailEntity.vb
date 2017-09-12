Public Class MKT_EmailEntity 
	Implements IMKT_EmailEntity 

	Private _uId_Email AS String
	Private _d_Ngay AS DateTime
	Private _d_NgayB AS String
	Private _nv_Noidung AS String
    Private _uId_KH_Tiemnang As String
    Private _nv_Tieude As String
	
	Public Property uId_Email() AS String Implements IMKT_EmailEntity.uId_Email
		Get 
			Return _uId_Email
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Email=String.Empty
			Else 
				_uId_Email=value.Trim
			End If
		End Set
	End Property

	Public Property d_Ngay() AS DateTime Implements IMKT_EmailEntity.d_Ngay
		Get 
			Return Date.Parse(_d_Ngay).ToShortDateString
		End Get
		Set(ByVal value As DateTime)
			_d_Ngay=value
		End Set
	End Property

	Public Property d_NgayB() AS String
		Get 
			If(_d_Ngay=Nothing) Then
				Return String.Empty
			Else
				Return CStr(Format(_d_Ngay, "dd/MM/yyyy"))
			End If
		End Get
		Set(ByVal value As String)
			_d_Ngay=value
		End Set
	End Property

	Public Property nv_Noidung() AS String Implements IMKT_EmailEntity.nv_Noidung
		Get 
			Return _nv_Noidung
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Noidung=String.Empty
			Else 
				_nv_Noidung=value.Trim
			End If
		End Set
	End Property

	Public Property uId_KH_Tiemnang() AS String Implements IMKT_EmailEntity.uId_KH_Tiemnang
		Get 
			Return _uId_KH_Tiemnang
		End Get
		Set(ByVal value As String)
			If(value = Nothing) Then
				_uId_KH_Tiemnang=String.Empty
			Else 
				_uId_KH_Tiemnang=value.Trim
			End If
		End Set
	End Property


    Public Property nv_Tieude() As String Implements IMKT_EmailEntity.nv_Tieude
        Get
            Return _nv_Tieude
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_Tieude = String.Empty
            Else
                _nv_Tieude = value.Trim
            End If
        End Set
    End Property

End Class
