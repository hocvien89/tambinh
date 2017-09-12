Public Class TNTP_GOIDICHVU_DICHVUFacade

    Dim ITNTP_GOIDICHVU_DICHVU As DB.ITNTP_GOIDICHVU_DICHVUDA = New DB.TNTP_GOIDICHVU_DICHVUDA

    Public Function SelectAll(ByVal uId_Goidichvu As String) As List(Of CM.TNTP_GOIDICHVU_DICHVUEntity)
        Return ITNTP_GOIDICHVU_DICHVU.SelectAll(uId_Goidichvu)
    End Function

	Public Function SelectAllTable(ByVal uId_Goidichvu AS String) AS System.Data.DataTable
		Return ITNTP_GOIDICHVU_DICHVU.SelectAllTable(uId_Goidichvu)
	End Function

    Public Function Insert(ByVal obj As CM.TNTP_GOIDICHVU_DICHVUEntity) As Boolean
        Return ITNTP_GOIDICHVU_DICHVU.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.TNTP_GOIDICHVU_DICHVUEntity) As Boolean
        Return ITNTP_GOIDICHVU_DICHVU.Update(obj)
    End Function

	Public Function DeleteByID(ByVal uId_Goidichvu AS String,ByVal uId_Dichvu AS String) AS Boolean
		Return ITNTP_GOIDICHVU_DICHVU.DeleteByID(uId_Goidichvu,uId_Dichvu)
	End Function

    Public Function SelectByID(ByVal uId_Goidichvu As String, ByVal uId_Dichvu As String) As CM.TNTP_GOIDICHVU_DICHVUEntity
        Return ITNTP_GOIDICHVU_DICHVU.SelectByID(uId_Goidichvu, uId_Dichvu)
    End Function

End Class