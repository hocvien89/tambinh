Public Class TNTP_CHITIEUTHAMDOEntity 
	Implements ITNTP_CHITIEUTHAMDOEntity 

	Private _uId_Chitieuthamdo AS String
	Private _nv_Tenchitieuthamdo_vn AS String
	Private _nv_Tenchitieuthamdo_en AS String
	Private _i_Kieugiatri AS String
	Private _uId_NhomThamdo AS String

	Public Property uId_Chitieuthamdo() AS String Implements ITNTP_CHITIEUTHAMDOEntity.uId_Chitieuthamdo
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

	Public Property nv_Tenchitieuthamdo_vn() AS String Implements ITNTP_CHITIEUTHAMDOEntity.nv_Tenchitieuthamdo_vn
		Get 
			Return _nv_Tenchitieuthamdo_vn
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Tenchitieuthamdo_vn=String.Empty
			Else 
				_nv_Tenchitieuthamdo_vn=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Tenchitieuthamdo_en() AS String Implements ITNTP_CHITIEUTHAMDOEntity.nv_Tenchitieuthamdo_en
		Get 
			Return _nv_Tenchitieuthamdo_en
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Tenchitieuthamdo_en=String.Empty
			Else 
				_nv_Tenchitieuthamdo_en=value.Trim
			End If
		End Set
	End Property

	Public Property i_Kieugiatri() AS String Implements ITNTP_CHITIEUTHAMDOEntity.i_Kieugiatri
		Get 
			Return _i_Kieugiatri
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_i_Kieugiatri=String.Empty
			Else 
				_i_Kieugiatri=value.Trim
			End If
		End Set
	End Property

	Public Property uId_NhomThamdo() AS String Implements ITNTP_CHITIEUTHAMDOEntity.uId_NhomThamdo
		Get 
			Return _uId_NhomThamdo
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_NhomThamdo=String.Empty
			Else 
				_uId_NhomThamdo=value.Trim
			End If
		End Set
	End Property

End Class
