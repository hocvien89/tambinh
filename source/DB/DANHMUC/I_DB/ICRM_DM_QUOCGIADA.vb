Public Interface ICRM_DM_QUOCGIADA

    Function SelectAll() As List(Of CM.CRM_DM_QUOCGIAEntity)

	Function SelectAllTable() AS System.Data.DataTable

    Function SelectByID(ByVal uId_Quocgia As String) As CM.CRM_DM_QUOCGIAEntity

    Function Insert(ByVal obj As CM.CRM_DM_QUOCGIAEntity) As Boolean

	Function DeleteByID(ByVal uId_Quocgia AS String) AS Boolean

    Function Update(ByVal obj As CM.CRM_DM_QUOCGIAEntity) As Boolean

End Interface