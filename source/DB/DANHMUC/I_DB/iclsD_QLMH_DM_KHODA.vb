Public Interface IQLMH_DM_KHODA

    Function SelectAll(ByVal uId_Cuahang As String) As System.Collections.Generic.List(Of CM.QLMH_DM_KHOEntity)

	Function SelectAllTable(ByVal uId_Cuahang AS String) AS System.Data.DataTable

    Function SelectByID(ByVal uId_Kho As String) As CM.QLMH_DM_KHOEntity

    Function Insert(ByVal obj As CM.QLMH_DM_KHOEntity) As Boolean

	Function DeleteByID(ByVal uId_Kho AS String) AS Boolean

    Function Update(ByVal obj As CM.QLMH_DM_KHOEntity) As Boolean

End Interface