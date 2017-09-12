Public Interface ICRM_DM_TINHTHANHDA

    Function SelectAll() As List(Of CM.CRM_DM_TINHTHANHEntity)

    Function SelectAllTable(ByVal uId_Quocgia As String) As System.Data.DataTable

    Function SelectByID(ByVal uId_Tinhthanh As String) As CM.CRM_DM_TINHTHANHEntity

    Function Insert(ByVal obj As CM.CRM_DM_TINHTHANHEntity) As Boolean

    Function DeleteByID(ByVal uId_Tinhthanh As String) As Boolean

    Function Update(ByVal obj As CM.CRM_DM_TINHTHANHEntity) As Boolean

End Interface