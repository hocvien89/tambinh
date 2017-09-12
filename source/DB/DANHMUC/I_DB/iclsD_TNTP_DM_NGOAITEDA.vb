Public Interface ITNTP_DM_NGOAITEDA

    Function SelectAll() As List(Of CM.TNTP_DM_NGOAITEEntity)

	Function SelectAllTable() AS System.Data.DataTable

    Function SelectByID(ByVal uId_Ngoaite As String) As CM.TNTP_DM_NGOAITEEntity

    Function Insert(ByVal obj As CM.TNTP_DM_NGOAITEEntity) As Boolean

	Function DeleteByID(ByVal uId_Ngoaite AS String) AS Boolean

    Function Update(ByVal obj As CM.TNTP_DM_NGOAITEEntity) As Boolean

End Interface