Public Class CRM_DM_NGUONFacade

    Dim ICRM_DM_NGUON As DB.ICRM_DM_NGUONDA = New DB.CRM_DM_NGUONDA

    Public Function SelectAll() As List(Of CM.CRM_DM_NGUONEntity)
        Return ICRM_DM_NGUON.SelectAll()
    End Function

	Public Function SelectAllTable() As System.Data.DataTable
		Return ICRM_DM_NGUON.SelectAllTable()
	End Function

    Public Function SelectAllTable_ByvType(ByVal vType As String) As System.Data.DataTable
        Return ICRM_DM_NGUON.SelectAllTable_ByvType(vType)
    End Function


    Public Function SelectAllTable_vType() As System.Data.DataTable
        Return ICRM_DM_NGUON.SelectAllTable_vType()
    End Function


    Public Function Insert(ByVal obj As CM.CRM_DM_NGUONEntity) As Boolean
        Return ICRM_DM_NGUON.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.CRM_DM_NGUONEntity) As Boolean
        Return ICRM_DM_NGUON.Update(obj)
    End Function

	Public Function DeleteByID(ByVal uId_Nguon AS String) AS Boolean
		Return ICRM_DM_NGUON.DeleteByID(uId_Nguon)
	End Function

    Public Function SelectByID(ByVal uId_Nguon As String) As CM.CRM_DM_NGUONEntity
        Return ICRM_DM_NGUON.SelectByID(uId_Nguon)
    End Function

End Class