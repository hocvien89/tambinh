Public Class QLMH_DM_KHOFacade

    Dim IQLMH_DM_KHO As DB.IQLMH_DM_KHODA = New DB.QLMH_DM_KHODA

    Public Function SelectAll(ByVal uId_Cuahang As String) As List(Of CM.QLMH_DM_KHOEntity)
        Return IQLMH_DM_KHO.SelectAll(uId_Cuahang)
    End Function

	Public Function SelectAllTable(ByVal uId_Cuahang AS String) AS System.Data.DataTable
		Return IQLMH_DM_KHO.SelectAllTable(uId_Cuahang)
	End Function

    Public Function Insert(ByVal obj As CM.QLMH_DM_KHOEntity) As Boolean
        Return IQLMH_DM_KHO.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.QLMH_DM_KHOEntity) As Boolean
        Return IQLMH_DM_KHO.Update(obj)
    End Function

	Public Function DeleteByID(ByVal uId_Kho AS String) AS Boolean
		Return IQLMH_DM_KHO.DeleteByID(uId_Kho)
	End Function

    Public Function SelectByID(ByVal uId_Kho As String) As CM.QLMH_DM_KHOEntity
        Return IQLMH_DM_KHO.SelectByID(uId_Kho)
    End Function

End Class