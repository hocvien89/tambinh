Public Class MKT_Chitiet_ChiendichMKTFacade

    Dim IMKT_Chitiet_ChiendichMKT As DB.IMKT_Chitiet_ChiendichMKTDA = New DB.MKT_Chitiet_ChiendichMKTDA

    Public Function SelectAll() As List(Of CM.MKT_Chitiet_ChiendichMKTEntity)
        Return IMKT_Chitiet_ChiendichMKT.SelectAll()
    End Function

	Public Function SelectAllTable() As System.Data.DataTable
		Return IMKT_Chitiet_ChiendichMKT.SelectAllTable()
	End Function

    Public Function Insert(ByVal obj As CM.MKT_Chitiet_ChiendichMKTEntity) As Boolean
        Return IMKT_Chitiet_ChiendichMKT.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.MKT_Chitiet_ChiendichMKTEntity) As Boolean
        Return IMKT_Chitiet_ChiendichMKT.Update(obj)
    End Function

    Public Function DeleteByID(ByVal uId_ChiendichMKT As String, ByVal uId_KH_Tiemnang As String) As Boolean
        Return IMKT_Chitiet_ChiendichMKT.DeleteByID(uId_ChiendichMKT, uId_KH_Tiemnang)
    End Function

    Public Function SelectByID(ByVal uId_Chitiet_Chiendich As String) As CM.MKT_Chitiet_ChiendichMKTEntity
        Return IMKT_Chitiet_ChiendichMKT.SelectByID(uId_Chitiet_Chiendich)
    End Function

End Class