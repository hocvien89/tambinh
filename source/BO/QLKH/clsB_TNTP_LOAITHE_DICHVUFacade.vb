Public Class TNTP_LOAITHE_DICHVUFacade

    Dim ITNTP_LOAITHE_DICHVU As DB.ITNTP_LOAITHE_DICHVUDA = New DB.TNTP_LOAITHE_DICHVUDA

    Public Function SelectAll(ByVal uId_Loaithe As String) As List(Of CM.TNTP_LOAITHE_DICHVUEntity)
        Return ITNTP_LOAITHE_DICHVU.SelectAll(uId_Loaithe)
    End Function

	Public Function SelectAllTable(ByVal uId_Loaithe AS String) AS System.Data.DataTable
		Return ITNTP_LOAITHE_DICHVU.SelectAllTable(uId_Loaithe)
	End Function

    Public Function Insert(ByVal obj As CM.TNTP_LOAITHE_DICHVUEntity) As Boolean
        Return ITNTP_LOAITHE_DICHVU.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.TNTP_LOAITHE_DICHVUEntity) As Boolean
        Return ITNTP_LOAITHE_DICHVU.Update(obj)
    End Function

	Public Function DeleteByID(ByVal uId_Loaithe AS String,ByVal uId_Dichvu AS String) AS Boolean
		Return ITNTP_LOAITHE_DICHVU.DeleteByID(uId_Loaithe,uId_Dichvu)
	End Function

    Public Function SelectByID(ByVal uId_Loaithe As String, ByVal uId_Dichvu As String) As CM.TNTP_LOAITHE_DICHVUEntity
        Return ITNTP_LOAITHE_DICHVU.SelectByID(uId_Loaithe, uId_Dichvu)
    End Function

End Class