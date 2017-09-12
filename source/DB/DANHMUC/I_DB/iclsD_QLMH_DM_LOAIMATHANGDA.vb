Public Interface IQLMH_DM_LOAIMATHANGDA

    Function SelectAll() As List(Of CM.QLMH_DM_LOAIMATHANGEntity)

	Function SelectAllTable() AS System.Data.DataTable

    Function SelectByID(ByVal uId_Loaimathang As String) As CM.QLMH_DM_LOAIMATHANGEntity

    Function Insert(ByVal obj As CM.QLMH_DM_LOAIMATHANGEntity) As Boolean

	Function DeleteByID(ByVal uId_Loaimathang AS String) AS Boolean

    Function Update(ByVal obj As CM.QLMH_DM_LOAIMATHANGEntity) As Boolean
    'xuanhieu 31/10/2014
    Function Selectcheckma(maloai As String) As String
End Interface