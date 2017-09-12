Public Class QLCN_CONGNOEntity 
    Implements IQLCN_CONGNOEntity

    Private _uId_Congno_Thanhtoan As String
    Private _uId_Phieudichvu As String
	Private _f_Sotien AS Double
	Public Property uId_Phieudichvu() AS String Implements IQLCN_CONGNOEntity.uId_Phieudichvu
		Get 
			Return _uId_Phieudichvu
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Phieudichvu=String.Empty
			Else 
				_uId_Phieudichvu=value.Trim
			End If
		End Set
	End Property

	Public Property f_Sotien() AS Double Implements IQLCN_CONGNOEntity.f_Sotien
		Get 
			Return _f_Sotien
		End Get
		Set(ByVal value As Double)
			_f_Sotien=value
		End Set
	End Property
    Public Property uId_Congno_Thanhtoan() As String Implements IQLCN_CONGNOEntity.uId_Congno_Thanhtoan
        Get
            Return _uId_Congno_Thanhtoan
        End Get
        Set(ByVal value As String)
            If (value = Nothing) Then
                _uId_Congno_Thanhtoan = String.Empty
            Else
                _uId_Congno_Thanhtoan = value.Trim
            End If
        End Set
    End Property

End Class
