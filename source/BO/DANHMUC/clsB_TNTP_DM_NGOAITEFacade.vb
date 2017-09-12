Public Class TNTP_DM_NGOAITEFacade

    Dim ITNTP_DM_NGOAITE As DB.ITNTP_DM_NGOAITEDA = New DB.TNTP_DM_NGOAITEDA

    Public Function SelectAll() As List(Of CM.TNTP_DM_NGOAITEEntity)
        Return ITNTP_DM_NGOAITE.SelectAll()
    End Function

	Public Function SelectAllTable() As System.Data.DataTable
		Return ITNTP_DM_NGOAITE.SelectAllTable()
	End Function

    Public Function Insert(ByVal obj As CM.TNTP_DM_NGOAITEEntity) As Boolean
        Return ITNTP_DM_NGOAITE.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.TNTP_DM_NGOAITEEntity) As Boolean
        Return ITNTP_DM_NGOAITE.Update(obj)
    End Function

	Public Function DeleteByID(ByVal uId_Ngoaite AS String) AS Boolean
		Return ITNTP_DM_NGOAITE.DeleteByID(uId_Ngoaite)
	End Function

    Public Function SelectByID(ByVal uId_Ngoaite As String) As CM.TNTP_DM_NGOAITEEntity
        Return ITNTP_DM_NGOAITE.SelectByID(uId_Ngoaite)
    End Function

End Class