Public Class TNTP_DM_NHOMDICHVUFacade

    Dim ITNTP_DM_NHOMDICHVU As DB.ITNTP_DM_NHOMDICHVUDA = New DB.TNTP_DM_NHOMDICHVUDA

    Public Function SelectAll(ByVal uId_Cuahang As String) As List(Of CM.TNTP_DM_NHOMDICHVUEntity)
        Return ITNTP_DM_NHOMDICHVU.SelectAll(uId_Cuahang)
    End Function

	Public Function SelectAllTable(ByVal uId_Cuahang AS String) AS System.Data.DataTable
		Return ITNTP_DM_NHOMDICHVU.SelectAllTable(uId_Cuahang)
	End Function

    Public Function Insert(ByVal obj As CM.TNTP_DM_NHOMDICHVUEntity) As Boolean
        Return ITNTP_DM_NHOMDICHVU.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.TNTP_DM_NHOMDICHVUEntity) As Boolean
        Return ITNTP_DM_NHOMDICHVU.Update(obj)
    End Function

	Public Function DeleteByID(ByVal uId_Nhomdichvu AS String) AS Boolean
		Return ITNTP_DM_NHOMDICHVU.DeleteByID(uId_Nhomdichvu)
	End Function

    Public Function SelectByID(ByVal uId_Nhomdichvu As String) As CM.TNTP_DM_NHOMDICHVUEntity
        Return ITNTP_DM_NHOMDICHVU.SelectByID(uId_Nhomdichvu)
    End Function

    '2/10/2014
    Public Function SelectByName(Tencuahang As String) As String
        Return ITNTP_DM_NHOMDICHVU.SelectByname(Tencuahang)
    End Function

End Class