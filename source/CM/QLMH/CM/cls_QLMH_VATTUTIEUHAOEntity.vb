Public Class QLMH_VATTUTIEUHAOEntity 
	Implements IQLMH_VATTUTIEUHAOEntity 

	Private _uId_Vattutieuhao AS String
	Private _uId_Dichvu AS String
	Private _uId_Mathang AS String
    Private _f_SLTieuhao As Double
    Private _uId_Kho As String

	
	Public Property uId_Vattutieuhao() AS String Implements IQLMH_VATTUTIEUHAOEntity.uId_Vattutieuhao
		Get 
			Return _uId_Vattutieuhao
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Vattutieuhao=String.Empty
			Else 
				_uId_Vattutieuhao=value.Trim
			End If
		End Set
	End Property

	Public Property uId_Dichvu() AS String Implements IQLMH_VATTUTIEUHAOEntity.uId_Dichvu
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

	Public Property uId_Mathang() AS String Implements IQLMH_VATTUTIEUHAOEntity.uId_Mathang
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

	Public Property f_SLTieuhao() AS Double Implements IQLMH_VATTUTIEUHAOEntity.f_SLTieuhao
		Get 
			Return _f_SLTieuhao
		End Get
		Set(ByVal value As Double)
			_f_SLTieuhao=value
		End Set
	End Property
    Public Property uId_Kho() As String Implements IQLMH_VATTUTIEUHAOEntity.uId_Kho
        Get
            Return _uId_Kho
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Kho = String.Empty
            Else
                _uId_Kho = value.Trim
            End If
        End Set
    End Property
End Class
