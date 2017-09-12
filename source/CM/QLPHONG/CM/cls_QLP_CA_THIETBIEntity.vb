Public Class QLP_CA_THIETBIEntity 
	Implements IQLP_CA_THIETBIEntity 

	Private _uId_Ca AS String
    Private _uId_Thietbi As String
    Private _d_Ngay As DateTime
	Private _v_Thoigian_BD AS String
	Private _v_Thoigian_KT AS String
	Private _i_Soluong AS Int32
	Private _uId_Trangthai AS String
	Private _nv_Tenthietbi_vn AS String

	Public Property uId_Ca() AS String Implements IQLP_CA_THIETBIEntity.uId_Ca
		Get 
			Return _uId_Ca
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Ca=String.Empty
			Else 
				_uId_Ca=value.Trim
			End If
		End Set
	End Property

	Public Property uId_Thietbi() AS String Implements IQLP_CA_THIETBIEntity.uId_Thietbi
		Get 
			Return _uId_Thietbi
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Thietbi=String.Empty
			Else 
				_uId_Thietbi=value.Trim
			End If
		End Set
    End Property

    Public Property d_Ngay() As DateTime Implements IQLP_CA_THIETBIEntity.d_Ngay
        Get
            Return Date.Parse(_d_Ngay).ToShortDateString
        End Get
        Set(ByVal value As DateTime)
            _d_Ngay = value
        End Set
    End Property

	Public Property v_Thoigian_BD() AS String Implements IQLP_CA_THIETBIEntity.v_Thoigian_BD
		Get 
			Return _v_Thoigian_BD
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_v_Thoigian_BD=String.Empty
			Else 
				_v_Thoigian_BD=value.Trim
			End If
		End Set
	End Property

	Public Property v_Thoigian_KT() AS String Implements IQLP_CA_THIETBIEntity.v_Thoigian_KT
		Get 
			Return _v_Thoigian_KT
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_v_Thoigian_KT=String.Empty
			Else 
				_v_Thoigian_KT=value.Trim
			End If
		End Set
	End Property

	Public Property i_Soluong() AS Int32 Implements IQLP_CA_THIETBIEntity.i_Soluong
		Get 
			Return _i_Soluong
		End Get
		Set(ByVal value As Int32)
			_i_Soluong=value
		End Set
	End Property

	Public Property uId_Trangthai() AS String Implements IQLP_CA_THIETBIEntity.uId_Trangthai
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

	Public Property nv_Tenthietbi_vn() AS String
		Get 
			Return _nv_Tenthietbi_vn
		End Get
		Set(ByVal value As String)
			_nv_Tenthietbi_vn=value
		End Set
	End Property

End Class
