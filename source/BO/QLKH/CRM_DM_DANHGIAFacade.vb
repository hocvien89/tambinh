Public Class CRM_DM_DANHGIAFacade

    Dim ICRM_DM_DANHGIA As DB.ICRM_DM_DANHGIADA = New DB.CRM_DM_DANHGIADA

    Public Function SelectAll() As List(Of CM.CRM_DM_DANHGIAEntity)
        Return ICRM_DM_DANHGIA.SelectAll()
    End Function

    Public Function SelectAllTable() As System.Data.DataTable
        Return ICRM_DM_DANHGIA.SelectAllTable()
    End Function

    Public Function Insert(ByVal obj As CM.CRM_DM_DANHGIAEntity) As Boolean
        Return ICRM_DM_DANHGIA.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.CRM_DM_DANHGIAEntity) As Boolean
        Return ICRM_DM_DANHGIA.Update(obj)
    End Function

    Public Function DeleteByID(ByVal uId_Danhgia As String) As Boolean
        Return ICRM_DM_DANHGIA.DeleteByID(uId_Danhgia)
    End Function

    Public Function SelectByID(ByVal uId_Danhgia As String) As CM.CRM_DM_DANHGIAEntity
        Return ICRM_DM_DANHGIA.SelectByID(uId_Danhgia)
    End Function

End Class