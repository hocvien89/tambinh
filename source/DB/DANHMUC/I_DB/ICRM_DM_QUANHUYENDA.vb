Public Interface ICRM_DM_QUANHUYENDA

    Function SelectAll() As List(Of CM.CRM_DM_QUANHUYENEntity)

    Function SelectAllTable(ByVal uId_Tinhthanh As String) As System.Data.DataTable

    Function SelectByID(ByVal uId_Quanhuyen As String) As CM.CRM_DM_QUANHUYENEntity

    Function Insert(ByVal obj As CM.CRM_DM_QUANHUYENEntity) As Boolean

    Function DeleteByID(ByVal uId_Quanhuyen As String) As Boolean

    Function Update(ByVal obj As CM.CRM_DM_QUANHUYENEntity) As Boolean

End Interface