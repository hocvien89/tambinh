Public Class QLP_DM_PHONGFacade

    Dim IQLP_DM_PHONG As DB.IQLP_DM_PHONGDA = New DB.QLP_DM_PHONGDA

    Public Function SelectAll(ByVal uId_Cuahang As String) As List(Of CM.QLP_DM_PHONGEntity)
        Return IQLP_DM_PHONG.SelectAll(uId_Cuahang)
    End Function

	Public Function SelectAllTable(ByVal uId_Cuahang AS String) AS System.Data.DataTable
		Return IQLP_DM_PHONG.SelectAllTable(uId_Cuahang)
	End Function

    Public Function Insert(ByVal obj As CM.QLP_DM_PHONGEntity) As Boolean
        Return IQLP_DM_PHONG.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.QLP_DM_PHONGEntity) As Boolean
        Return IQLP_DM_PHONG.Update(obj)
    End Function

	Public Function DeleteByID(ByVal uId_Phong AS String) AS Boolean
		Return IQLP_DM_PHONG.DeleteByID(uId_Phong)
	End Function

    Public Function SelectByID(ByVal uId_Phong As String) As CM.QLP_DM_PHONGEntity
        Return IQLP_DM_PHONG.SelectByID(uId_Phong)
    End Function

    Public Function SelectPhongCoGiuongTrong() As System.Data.DataTable
        Return IQLP_DM_PHONG.SelectPhongCoGiuongTrong()
    End Function


End Class