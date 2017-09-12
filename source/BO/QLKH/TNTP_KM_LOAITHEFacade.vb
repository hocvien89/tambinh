Public Class TNTP_KM_LOAITHEFacade

    Dim ITNTP_KM_LOAITHE As DB.ITNTP_KM_LOAITHEDA = New DB.TNTP_KM_LOAITHEDA

    Public Function SelectAll() As List(Of CM.TNTP_KM_LOAITHEEntity)
        Return ITNTP_KM_LOAITHE.SelectAll()
    End Function

	Public Function SelectAllTable() As System.Data.DataTable
		Return ITNTP_KM_LOAITHE.SelectAllTable()
	End Function

    Public Function Insert(ByVal obj As CM.TNTP_KM_LOAITHEEntity) As Boolean
        Return ITNTP_KM_LOAITHE.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.TNTP_KM_LOAITHEEntity) As Boolean
        Return ITNTP_KM_LOAITHE.Update(obj)
    End Function

    Public Function DeleteByID(ByVal uId_KM_Loaithe As String) As Boolean
        Return ITNTP_KM_LOAITHE.DeleteByID(uId_KM_Loaithe)
    End Function

    Public Function SelectByID() As CM.TNTP_KM_LOAITHEEntity
        Return ITNTP_KM_LOAITHE.SelectByID
    End Function

End Class