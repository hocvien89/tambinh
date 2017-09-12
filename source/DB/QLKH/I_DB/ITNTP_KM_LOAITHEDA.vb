Public Interface ITNTP_KM_LOAITHEDA

    Function SelectAll() As List(Of CM.TNTP_KM_LOAITHEEntity)

	Function SelectAllTable() AS System.Data.DataTable

    Function SelectByID() As CM.TNTP_KM_LOAITHEEntity

    Function Insert(ByVal obj As CM.TNTP_KM_LOAITHEEntity) As Boolean

    Function DeleteByID(ByVal uId_KM_Loaithe As String) As Boolean

    Function Update(ByVal obj As CM.TNTP_KM_LOAITHEEntity) As Boolean

End Interface