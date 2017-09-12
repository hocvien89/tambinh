Public Class QLTC_DM_THUCHIEntity 
	Implements IQLTC_DM_THUCHIEntity 

	Private _uId_Thuchi AS String
	Private _v_Mathuchi AS String
	Private _nv_Tenthuchi_vn AS String
	Private _nv_Tenthuchi_en AS String
	Private _b_ThuChi AS Boolean
	
	Public Property uId_Thuchi() AS String Implements IQLTC_DM_THUCHIEntity.uId_Thuchi
		Get 
			Return _uId_Thuchi
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_uId_Thuchi=String.Empty
			Else 
				_uId_Thuchi=value.Trim
			End If
		End Set
	End Property

	Public Property v_Mathuchi() AS String Implements IQLTC_DM_THUCHIEntity.v_Mathuchi
		Get 
			Return _v_Mathuchi
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_v_Mathuchi=String.Empty
			Else 
				_v_Mathuchi=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Tenthuchi_vn() AS String Implements IQLTC_DM_THUCHIEntity.nv_Tenthuchi_vn
		Get 
			Return _nv_Tenthuchi_vn
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Tenthuchi_vn=String.Empty
			Else 
				_nv_Tenthuchi_vn=value.Trim
			End If
		End Set
	End Property

	Public Property nv_Tenthuchi_en() AS String Implements IQLTC_DM_THUCHIEntity.nv_Tenthuchi_en
		Get 
			Return _nv_Tenthuchi_en
		End Get
		Set(ByVal value As String)
			If(value=Nothing) Then
				_nv_Tenthuchi_en=String.Empty
			Else 
				_nv_Tenthuchi_en=value.Trim
			End If
		End Set
	End Property

	Public Property b_ThuChi() AS Boolean Implements IQLTC_DM_THUCHIEntity.b_ThuChi
		Get 
			Return _b_ThuChi
		End Get
		Set(ByVal value As Boolean)
			_b_ThuChi=value
		End Set
	End Property

End Class
