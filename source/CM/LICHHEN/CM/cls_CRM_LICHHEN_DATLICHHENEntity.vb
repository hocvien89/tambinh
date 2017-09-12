Public Class CRM_LICHHEN_DATLICHHENEntity 
	Implements ICRM_LICHHEN_DATLICHHENEntity 

    Private _uId_DatLichhen As String
    Private _uId_Cuahang As String
	Private _nv_Hoten_vn AS String
	Private _nv_Diachi_vn AS String
	Private _v_Dienthoai AS String
	Private _d_Ngaysinh AS DateTime
	Private _d_NgaysinhB AS String
	Private _nv_Email_vn AS String
	Private _b_KH_Cu AS Boolean
	Private _d_NgayDathen AS DateTime
	Private _d_NgayDathenB AS String
	Private _nv_Tugio AS String
	Private _nv_Dengio AS String
	Private _nv_Ghichu AS String
	Private _b_Trangthai AS Boolean
	
	Public Property uId_DatLichhen() AS String Implements ICRM_LICHHEN_DATLICHHENEntity.uId_DatLichhen
		Get 
			Return _uId_DatLichhen
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_DatLichhen=String.Empty
			Else 
				_uId_DatLichhen=value.Trim
			End If
		End Set
	End Property

    Public Property uId_Cuahang() As String Implements ICRM_LICHHEN_DATLICHHENEntity.uId_Cuahang
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

    Public Property nv_Hoten_vn() As String Implements ICRM_LICHHEN_DATLICHHENEntity.nv_Hoten_vn
        Get
            Return _nv_Hoten_vn
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _nv_Hoten_vn = String.Empty
            Else
                _nv_Hoten_vn = value.Trim
            End If
        End Set
    End Property

	Public Property nv_Diachi_vn() AS String Implements ICRM_LICHHEN_DATLICHHENEntity.nv_Diachi_vn
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

	Public Property v_Dienthoai() AS String Implements ICRM_LICHHEN_DATLICHHENEntity.v_Dienthoai
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

	Public Property d_Ngaysinh() AS DateTime Implements ICRM_LICHHEN_DATLICHHENEntity.d_Ngaysinh
		Get 
			Return Date.Parse(_d_Ngaysinh).ToShortDateString
		End Get
		Set(ByVal value As DateTime)
			_d_Ngaysinh=value
		End Set
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

	Public Property nv_Email_vn() AS String Implements ICRM_LICHHEN_DATLICHHENEntity.nv_Email_vn
		Get 
			Return _nv_Email_vn
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Email_vn=String.Empty
			Else 
				_nv_Email_vn=value.Trim
			End If
		End Set
	End Property

	Public Property b_KH_Cu() AS Boolean Implements ICRM_LICHHEN_DATLICHHENEntity.b_KH_Cu
		Get 
			Return _b_KH_Cu
		End Get
		Set(ByVal value As Boolean)
			_b_KH_Cu=value
		End Set
	End Property

	Public Property d_NgayDathen() AS DateTime Implements ICRM_LICHHEN_DATLICHHENEntity.d_NgayDathen
		Get 
			Return Date.Parse(_d_NgayDathen).ToShortDateString
		End Get
		Set(ByVal value As DateTime)
			_d_NgayDathen=value
		End Set
	End Property

	Public Property d_NgayDathenB() AS String
		Get 
			If(_d_NgayDathen=Nothing) Then
				Return String.Empty
			Else
				Return CStr(Format(_d_NgayDathen, "dd/MM/yyyy"))
			End If
		End Get
		Set(ByVal value As String)
			_d_NgayDathen=value
		End Set
	End Property

	Public Property nv_Tugio() AS String Implements ICRM_LICHHEN_DATLICHHENEntity.nv_Tugio
		Get 
			Return _nv_Tugio
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Tugio=String.Empty
			Else 
				_nv_Tugio=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Dengio() AS String Implements ICRM_LICHHEN_DATLICHHENEntity.nv_Dengio
		Get 
			Return _nv_Dengio
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Dengio=String.Empty
			Else 
				_nv_Dengio=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Ghichu() AS String Implements ICRM_LICHHEN_DATLICHHENEntity.nv_Ghichu
		Get 
			Return _nv_Ghichu
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Ghichu=String.Empty
			Else 
				_nv_Ghichu=value.Trim
			End If
		End Set
	End Property

	Public Property b_Trangthai() AS Boolean Implements ICRM_LICHHEN_DATLICHHENEntity.b_Trangthai
		Get 
			Return _b_Trangthai
		End Get
		Set(ByVal value As Boolean)
			_b_Trangthai=value
		End Set
	End Property

End Class
