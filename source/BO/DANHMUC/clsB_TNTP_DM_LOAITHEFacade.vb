Public Class TNTP_DM_LOAITHEFacade

    Dim ITNTP_DM_LOAITHE As DB.ITNTP_DM_LOAITHEDA = New DB.TNTP_DM_LOAITHEDA

    Public Function SelectAll() As List(Of CM.TNTP_DM_LOAITHEEntity)
        Return ITNTP_DM_LOAITHE.SelectAll()
    End Function

	Public Function SelectAllTable() As System.Data.DataTable
		Return ITNTP_DM_LOAITHE.SelectAllTable()
	End Function

    Public Function Insert(ByVal obj As CM.TNTP_DM_LOAITHEEntity) As Boolean
        Return ITNTP_DM_LOAITHE.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.TNTP_DM_LOAITHEEntity) As Boolean
        Return ITNTP_DM_LOAITHE.Update(obj)
    End Function

	Public Function DeleteByID(ByVal uId_Loaithe AS String) AS Boolean
		Return ITNTP_DM_LOAITHE.DeleteByID(uId_Loaithe)
	End Function

    Public Function SelectByID(ByVal uId_Loaithe As String) As CM.TNTP_DM_LOAITHEEntity
        Return ITNTP_DM_LOAITHE.SelectByID(uId_Loaithe)
    End Function

End Class