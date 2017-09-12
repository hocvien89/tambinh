Public Class CRM_DM_QUOCGIAFacade

    Dim ICRM_DM_QUOCGIA As DB.ICRM_DM_QUOCGIADA = New DB.CRM_DM_QUOCGIADA

    Public Function SelectAll() As List(Of CM.CRM_DM_QUOCGIAEntity)
        Return ICRM_DM_QUOCGIA.SelectAll()
    End Function

	Public Function SelectAllTable() As System.Data.DataTable
		Return ICRM_DM_QUOCGIA.SelectAllTable()
	End Function

    Public Function Insert(ByVal obj As CM.CRM_DM_QUOCGIAEntity) As Boolean
        Return ICRM_DM_QUOCGIA.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.CRM_DM_QUOCGIAEntity) As Boolean
        Return ICRM_DM_QUOCGIA.Update(obj)
    End Function

	Public Function DeleteByID(ByVal uId_Quocgia AS String) AS Boolean
		Return ICRM_DM_QUOCGIA.DeleteByID(uId_Quocgia)
	End Function

    Public Function SelectByID(ByVal uId_Quocgia As String) As CM.CRM_DM_QUOCGIAEntity
        Return ICRM_DM_QUOCGIA.SelectByID(uId_Quocgia)
    End Function

End Class