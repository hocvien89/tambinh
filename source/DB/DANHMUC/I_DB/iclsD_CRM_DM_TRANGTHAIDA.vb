Public Interface ICRM_DM_TRANGTHAIDA

    Function SelectAll() As List(Of CM.CRM_DM_TRANGTHAIEntity)

	Function SelectAllTable() AS System.Data.DataTable

    Function SelectByID(ByVal uId_Trangthai As String) As CM.CRM_DM_TRANGTHAIEntity

    Function Insert(ByVal obj As CM.CRM_DM_TRANGTHAIEntity) As Boolean

	Function DeleteByID(ByVal uId_Trangthai AS String) AS Boolean

    Function Update(ByVal obj As CM.CRM_DM_TRANGTHAIEntity) As Boolean

End Interface