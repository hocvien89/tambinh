Public Interface IQLMH_DM_NHOMMATHANGDA

    Function SelectAll() As List(Of CM.QLMH_DM_NHOMMATHANGEntity)

	Function SelectAllTable() AS System.Data.DataTable

    Function SelectByID(ByVal uId_Nhommathang As String) As CM.QLMH_DM_NHOMMATHANGEntity

    Function Insert(ByVal obj As CM.QLMH_DM_NHOMMATHANGEntity) As Boolean

	Function DeleteByID(ByVal uId_Nhommathang AS String) AS Boolean

    Function Update(ByVal obj As CM.QLMH_DM_NHOMMATHANGEntity) As Boolean
    'xuanhieu 31/10/2014 kiem tra ma nhom mat hang tu file exccel
    Function SelectcheckMa(manhom As String) As String
End Interface