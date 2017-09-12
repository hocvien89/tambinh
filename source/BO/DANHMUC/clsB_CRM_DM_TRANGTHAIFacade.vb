Public Class CRM_DM_TRANGTHAIFacade

    Dim ICRM_DM_TRANGTHAI As DB.ICRM_DM_TRANGTHAIDA = New DB.CRM_DM_TRANGTHAIDA

    Public Function SelectAll() As List(Of CM.CRM_DM_TRANGTHAIEntity)
        Return ICRM_DM_TRANGTHAI.SelectAll()
    End Function

	Public Function SelectAllTable() As System.Data.DataTable
		Return ICRM_DM_TRANGTHAI.SelectAllTable()
	End Function

    Public Function Insert(ByVal obj As CM.CRM_DM_TRANGTHAIEntity) As Boolean
        Return ICRM_DM_TRANGTHAI.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.CRM_DM_TRANGTHAIEntity) As Boolean
        Return ICRM_DM_TRANGTHAI.Update(obj)
    End Function

	Public Function DeleteByID(ByVal uId_Trangthai AS String) AS Boolean
		Return ICRM_DM_TRANGTHAI.DeleteByID(uId_Trangthai)
	End Function

    Public Function SelectByID(ByVal uId_Trangthai As String) As CM.CRM_DM_TRANGTHAIEntity
        Return ICRM_DM_TRANGTHAI.SelectByID(uId_Trangthai)
    End Function

End Class