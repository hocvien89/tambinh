Public Interface ICRM_DM_DANHGIADA

    Function SelectAll() As List(Of CM.CRM_DM_DANHGIAEntity)

    Function SelectAllTable() As System.Data.DataTable

    Function SelectByID(ByVal uId_Danhgia As String) As CM.CRM_DM_DANHGIAEntity

    Function Insert(ByVal obj As CM.CRM_DM_DANHGIAEntity) As Boolean

    Function DeleteByID(ByVal uId_Danhgia As String) As Boolean

    Function Update(ByVal obj As CM.CRM_DM_DANHGIAEntity) As Boolean

End Interface