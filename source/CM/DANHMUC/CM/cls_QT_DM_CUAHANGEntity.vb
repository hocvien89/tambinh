Public Class QT_DM_CUAHANGEntity 
	Implements IQT_DM_CUAHANGEntity 

	Private _uId_Cuahang AS String
	Private _v_Macuahang AS String
	Private _nv_Tencuahang_vn AS String
	Private _nv_Tencuahang_en AS String
	Private _nv_Diachi_vn AS String
	Private _nv_Diachi_en AS String
    Private _b_Active As Boolean
    Private _v_Email As String
    Private _v_passEmail As String
	
	Public Property uId_Cuahang() AS String Implements IQT_DM_CUAHANGEntity.uId_Cuahang
		Get 
			Return _uId_Cuahang
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Cuahang=String.Empty
			Else 
				_uId_Cuahang=value.Trim
			End If
		End Set
	End Property

	Public Property v_Macuahang() AS String Implements IQT_DM_CUAHANGEntity.v_Macuahang
		Get 
			Return _v_Macuahang
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_v_Macuahang=String.Empty
			Else 
				_v_Macuahang=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Tencuahang_vn() AS String Implements IQT_DM_CUAHANGEntity.nv_Tencuahang_vn
		Get 
			Return _nv_Tencuahang_vn
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Tencuahang_vn=String.Empty
			Else 
				_nv_Tencuahang_vn=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Tencuahang_en() AS String Implements IQT_DM_CUAHANGEntity.nv_Tencuahang_en
		Get 
			Return _nv_Tencuahang_en
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Tencuahang_en=String.Empty
			Else 
				_nv_Tencuahang_en=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Diachi_vn() AS String Implements IQT_DM_CUAHANGEntity.nv_Diachi_vn
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

	Public Property nv_Diachi_en() AS String Implements IQT_DM_CUAHANGEntity.nv_Diachi_en
		Get 
			Return _nv_Diachi_en
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Diachi_en=String.Empty
			Else 
				_nv_Diachi_en=value.Trim
			End If
		End Set
	End Property

	Public Property b_Active() AS Boolean Implements IQT_DM_CUAHANGEntity.b_Active
		Get 
			Return _b_Active
		End Get
		Set(ByVal value As Boolean)
			_b_Active=value
		End Set
	End Property

    Public Property v_Email() As String Implements IQT_DM_CUAHANGEntity.v_Email
        Get
            Return _v_Email
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _v_Email = String.Empty
            Else
                _v_Email = value.Trim
            End If
        End Set
    End Property

    Public Property v_passEmail() As String Implements IQT_DM_CUAHANGEntity.v_passEmail
        Get
            Return _v_passEmail
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _v_passEmail = String.Empty
            Else
                _v_passEmail = value.Trim
            End If
        End Set
    End Property

End Class
