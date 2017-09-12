Public Interface IMKT_ChuyendoiDA

    Function SelectAll() As List(Of CM.MKT_ChuyendoiEntity)

	Function SelectAllTable() AS System.Data.DataTable

    Function SelectByID(ByVal uId_Chuyendoi As String) As CM.MKT_ChuyendoiEntity

    Function Insert(ByVal obj As CM.MKT_ChuyendoiEntity) As String

	Function DeleteByID(ByVal uId_Chuyendoi AS String) AS Boolean

    Function Update(ByVal obj As CM.MKT_ChuyendoiEntity) As Boolean

    Function SelectByID_KHtiemnang(ByVal uId_KH_tiemnang As String) As String

    Function SelectAllByKHTiemNang(ByVal uId_KH_tiemnang As String) As CM.MKT_ChuyendoiEntity
End Interface