Public Class MKT_ChuyendoiFacade

    Dim IMKT_Chuyendoi As DB.IMKT_ChuyendoiDA = New DB.MKT_ChuyendoiDA

    Public Function SelectAll() As List(Of CM.MKT_ChuyendoiEntity)
        Return IMKT_Chuyendoi.SelectAll()
    End Function

	Public Function SelectAllTable() As System.Data.DataTable
		Return IMKT_Chuyendoi.SelectAllTable()
	End Function

    Public Function Insert(ByVal obj As CM.MKT_ChuyendoiEntity) As String
        Return IMKT_Chuyendoi.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.MKT_ChuyendoiEntity) As Boolean
        Return IMKT_Chuyendoi.Update(obj)
    End Function

	Public Function DeleteByID(ByVal uId_Chuyendoi AS String) AS Boolean
		Return IMKT_Chuyendoi.DeleteByID(uId_Chuyendoi)
	End Function

    Public Function SelectByID(ByVal uId_Chuyendoi As String) As CM.MKT_ChuyendoiEntity
        Return IMKT_Chuyendoi.SelectByID(uId_Chuyendoi)
    End Function
    Public Function SelectByID_KHtiemnang(ByVal uId_KH_tiemnang As String) As String
        Return IMKT_Chuyendoi.SelectByID_KHtiemnang(uId_KH_tiemnang)
    End Function
    Public Function SelectAllByKHTiemNang(ByVal uId_KH_tiemnang As String) As CM.MKT_ChuyendoiEntity
        Return IMKT_Chuyendoi.SelectAllByKHTiemNang(uId_KH_tiemnang)
    End Function
End Class