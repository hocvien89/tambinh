Public Interface ICRM_DM_NGUONDA

    Function SelectAll() As List(Of CM.CRM_DM_NGUONEntity)

    Function SelectAllTable() As System.Data.DataTable

    Function SelectAllTable_ByvType(ByVal vType As String) As System.Data.DataTable

    Function SelectAllTable_vType() As System.Data.DataTable

    Function SelectByID(ByVal uId_Nguon As String) As CM.CRM_DM_NGUONEntity

    Function Insert(ByVal obj As CM.CRM_DM_NGUONEntity) As Boolean

	Function DeleteByID(ByVal uId_Nguon AS String) AS Boolean

    Function Update(ByVal obj As CM.CRM_DM_NGUONEntity) As Boolean

End Interface