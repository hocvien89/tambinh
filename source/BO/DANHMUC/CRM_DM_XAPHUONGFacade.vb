Public Class CRM_DM_XAPHUONGFacade

    Dim ICRM_DM_XAPHUONG As DB.ICRM_DM_XAPHUONGDA = New DB.CRM_DM_XAPHUONGDA

	Public Function SelectAll() As List(Of CM.CRM_DM_XAPHUONGEntity)
		Return ICRM_DM_XAPHUONG.SelectAll()
	End Function

    Public Function SelectAllTable(ByVal uId_Quanhuyen As String) As System.Data.DataTable
        Return ICRM_DM_XAPHUONG.SelectAllTable(uId_Quanhuyen)
    End Function

	Public Function Insert(ByVal obj As CM.CRM_DM_XAPHUONGEntity) AS Boolean
		Return ICRM_DM_XAPHUONG.Insert(obj)
	End Function

	Public Function Update(ByVal obj As CM.CRM_DM_XAPHUONGEntity) AS Boolean
		Return ICRM_DM_XAPHUONG.Update(obj)
	End Function

	Public Function DeleteByID(ByVal uId_Xaphuong AS String) AS Boolean
		Return ICRM_DM_XAPHUONG.DeleteByID(uId_Xaphuong)
	End Function

	Public Function SelectByID(ByVal uId_Xaphuong AS String) As CM.CRM_DM_XAPHUONGEntity
		Return ICRM_DM_XAPHUONG.SelectByID(uId_Xaphuong)
	End Function
    Public Function SelectDiaDanhByID(ByVal uId_Xaphuong As String) As System.Data.DataTable
        Return ICRM_DM_XAPHUONG.SelectDiaDanhByID(uId_Xaphuong)
    End Function
End Class