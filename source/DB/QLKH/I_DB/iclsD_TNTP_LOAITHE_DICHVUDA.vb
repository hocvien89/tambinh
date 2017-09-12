Public Interface ITNTP_LOAITHE_DICHVUDA

    Function SelectAll(ByVal uId_Loaithe As String) As System.Collections.Generic.List(Of CM.TNTP_LOAITHE_DICHVUEntity)

	Function SelectAllTable(ByVal uId_Loaithe AS String) AS System.Data.DataTable

    Function SelectByID(ByVal uId_Loaithe As String, ByVal uId_Dichvu As String) As CM.TNTP_LOAITHE_DICHVUEntity

    Function Insert(ByVal obj As CM.TNTP_LOAITHE_DICHVUEntity) As Boolean

	Function DeleteByID(ByVal uId_Loaithe AS String,ByVal uId_Dichvu AS String) AS Boolean

    Function Update(ByVal obj As CM.TNTP_LOAITHE_DICHVUEntity) As Boolean

End Interface