Public Class PQP_DICHVU_PHONGFacade

    Dim IPQP_DICHVU_PHONG As DB.IPQP_DICHVU_PHONGDA = New DB.PQP_DICHVU_PHONGDA

    Public Function SelectAll() As List(Of CM.PQP_DICHVU_PHONGEntity)
        Return IPQP_DICHVU_PHONG.SelectAll()
    End Function

	Public Function SelectAllTable() As System.Data.DataTable
		Return IPQP_DICHVU_PHONG.SelectAllTable()
	End Function

    Public Function Insert(ByVal obj As CM.PQP_DICHVU_PHONGEntity) As Boolean
        Return IPQP_DICHVU_PHONG.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.PQP_DICHVU_PHONGEntity) As Boolean
        Return IPQP_DICHVU_PHONG.Update(obj)
    End Function

	Public Function DeleteByID(ByVal uId_Dichvu_Phong AS String) AS Boolean
		Return IPQP_DICHVU_PHONG.DeleteByID(uId_Dichvu_Phong)
	End Function

    Public Function SelectByID(ByVal uId_Dichvu_Phong As String) As CM.PQP_DICHVU_PHONGEntity
        Return IPQP_DICHVU_PHONG.SelectByID(uId_Dichvu_Phong)
    End Function

End Class