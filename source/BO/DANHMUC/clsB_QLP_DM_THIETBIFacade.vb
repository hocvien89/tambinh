Public Class QLP_DM_THIETBIFacade

    Dim IQLP_DM_THIETBI As DB.IQLP_DM_THIETBIDA = New DB.QLP_DM_THIETBIDA

    Public Function SelectAll(ByVal uId_Cuahang As String) As List(Of CM.QLP_DM_THIETBIEntity)
        Return IQLP_DM_THIETBI.SelectAll(uId_Cuahang)
    End Function

	Public Function SelectAllTable(ByVal uId_Cuahang AS String) AS System.Data.DataTable
		Return IQLP_DM_THIETBI.SelectAllTable(uId_Cuahang)
	End Function

    Public Function Insert(ByVal obj As CM.QLP_DM_THIETBIEntity) As Boolean
        Return IQLP_DM_THIETBI.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.QLP_DM_THIETBIEntity) As Boolean
        Return IQLP_DM_THIETBI.Update(obj)
    End Function

	Public Function DeleteByID(ByVal uId_Thietbi AS String) AS Boolean
		Return IQLP_DM_THIETBI.DeleteByID(uId_Thietbi)
	End Function

    Public Function SelectByID(ByVal uId_Thietbi As String) As CM.QLP_DM_THIETBIEntity
        Return IQLP_DM_THIETBI.SelectByID(uId_Thietbi)
    End Function

End Class