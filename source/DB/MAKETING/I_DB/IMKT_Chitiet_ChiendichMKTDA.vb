Public Interface IMKT_Chitiet_ChiendichMKTDA

    Function SelectAll() As List(Of CM.MKT_Chitiet_ChiendichMKTEntity)

	Function SelectAllTable() AS System.Data.DataTable

    Function SelectByID(ByVal uId_Chitiet_Chiendich As String) As CM.MKT_Chitiet_ChiendichMKTEntity

    Function Insert(ByVal obj As CM.MKT_Chitiet_ChiendichMKTEntity) As Boolean

    Function DeleteByID(ByVal uId_ChiendichMKT As String, ByVal uId_KH_Tiemnang As String) As Boolean

    Function Update(ByVal obj As CM.MKT_Chitiet_ChiendichMKTEntity) As Boolean

End Interface