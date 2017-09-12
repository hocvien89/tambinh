Public Class CRM_DM_TINHTHANHFacade

    Dim ICRM_DM_TINHTHANH As DB.ICRM_DM_TINHTHANHDA = New DB.CRM_DM_TINHTHANHDA

	Public Function SelectAll() As List(Of CM.CRM_DM_TINHTHANHEntity)
		Return ICRM_DM_TINHTHANH.SelectAll()
	End Function

    Public Function SelectAllTable(ByVal uId_Quocgia As String) As System.Data.DataTable
        Return ICRM_DM_TINHTHANH.SelectAllTable(uId_Quocgia)
    End Function

	Public Function Insert(ByVal obj As CM.CRM_DM_TINHTHANHEntity) AS Boolean
		Return ICRM_DM_TINHTHANH.Insert(obj)
	End Function

	Public Function Update(ByVal obj As CM.CRM_DM_TINHTHANHEntity) AS Boolean
		Return ICRM_DM_TINHTHANH.Update(obj)
	End Function

	Public Function DeleteByID(ByVal uId_Tinhthanh AS String) AS Boolean
		Return ICRM_DM_TINHTHANH.DeleteByID(uId_Tinhthanh)
	End Function

	Public Function SelectByID(ByVal uId_Tinhthanh AS String) As CM.CRM_DM_TINHTHANHEntity
		Return ICRM_DM_TINHTHANH.SelectByID(uId_Tinhthanh)
	End Function

End Class