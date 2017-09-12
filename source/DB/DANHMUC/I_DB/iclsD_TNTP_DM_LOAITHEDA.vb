Public Interface ITNTP_DM_LOAITHEDA

    Function SelectAll() As List(Of CM.TNTP_DM_LOAITHEEntity)

	Function SelectAllTable() AS System.Data.DataTable

    Function SelectByID(ByVal uId_Loaithe As String) As CM.TNTP_DM_LOAITHEEntity

    Function Insert(ByVal obj As CM.TNTP_DM_LOAITHEEntity) As Boolean

	Function DeleteByID(ByVal uId_Loaithe AS String) AS Boolean

    Function Update(ByVal obj As CM.TNTP_DM_LOAITHEEntity) As Boolean

End Interface