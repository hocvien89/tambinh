Public Class CRM_DM_QUANHUYENFacade

    Dim ICRM_DM_QUANHUYEN As DB.ICRM_DM_QUANHUYENDA = New DB.CRM_DM_QUANHUYENDA

    Public Function SelectAll() As List(Of CM.CRM_DM_QUANHUYENEntity)
        Return ICRM_DM_QUANHUYEN.SelectAll()
    End Function

    Public Function SelectAllTable(ByVal uId_Tinhthanh As String) As System.Data.DataTable
        Return ICRM_DM_QUANHUYEN.SelectAllTable(uId_Tinhthanh)
    End Function

    Public Function Insert(ByVal obj As CM.CRM_DM_QUANHUYENEntity) As Boolean
        Return ICRM_DM_QUANHUYEN.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.CRM_DM_QUANHUYENEntity) As Boolean
        Return ICRM_DM_QUANHUYEN.Update(obj)
    End Function

    Public Function DeleteByID(ByVal uId_Quanhuyen As String) As Boolean
        Return ICRM_DM_QUANHUYEN.DeleteByID(uId_Quanhuyen)
    End Function

    Public Function SelectByID(ByVal uId_Quanhuyen As String) As CM.CRM_DM_QUANHUYENEntity
        Return ICRM_DM_QUANHUYEN.SelectByID(uId_Quanhuyen)
    End Function

End Class