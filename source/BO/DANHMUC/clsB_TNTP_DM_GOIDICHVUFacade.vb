Public Class TNTP_DM_GOIDICHVUFacade

    Dim ITNTP_DM_GOIDICHVU As DB.ITNTP_DM_GOIDICHVUDA = New DB.TNTP_DM_GOIDICHVUDA

    Public Function SelectAll() As List(Of CM.TNTP_DM_GOIDICHVUEntity)
        Return ITNTP_DM_GOIDICHVU.SelectAll()
    End Function

	Public Function SelectAllTable() As System.Data.DataTable
		Return ITNTP_DM_GOIDICHVU.SelectAllTable()
	End Function

    Public Function Insert(ByVal obj As CM.TNTP_DM_GOIDICHVUEntity) As Boolean
        Return ITNTP_DM_GOIDICHVU.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.TNTP_DM_GOIDICHVUEntity) As Boolean
        Return ITNTP_DM_GOIDICHVU.Update(obj)
    End Function

	Public Function DeleteByID(ByVal uId_Goidichvu AS String) AS Boolean
		Return ITNTP_DM_GOIDICHVU.DeleteByID(uId_Goidichvu)
	End Function

    Public Function SelectByID(ByVal uId_Goidichvu As String) As CM.TNTP_DM_GOIDICHVUEntity
        Return ITNTP_DM_GOIDICHVU.SelectByID(uId_Goidichvu)
    End Function
    Public Function SelectAllTable_List_Goi_The_Dichvu(ByVal vType As String, ByVal uId_Nhomdichvu As String) As System.Data.DataTable
        Return ITNTP_DM_GOIDICHVU.SelectAllTable_List_Goi_The_Dichvu(vType, uId_Nhomdichvu)
    End Function
    Public Function SelectAllTable_ListLoai_Goi_The_Dichvu(ByVal vType As String) As System.Data.DataTable
        Return ITNTP_DM_GOIDICHVU.SelectAllTable_ListLoai_Goi_The_Dichvu(vType)
    End Function
End Class