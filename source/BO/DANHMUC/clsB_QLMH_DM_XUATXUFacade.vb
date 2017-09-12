Public Class QLMH_DM_XUATXUFacade

    Dim IQLMH_DM_XUATXU As DB.IQLMH_DM_XUATXUDA = New DB.QLMH_DM_XUATXUDA

    Public Function SelectAll() As List(Of CM.QLMH_DM_XUATXUEntity)
        Return IQLMH_DM_XUATXU.SelectAll()
    End Function

	Public Function SelectAllTable() As System.Data.DataTable
		Return IQLMH_DM_XUATXU.SelectAllTable()
	End Function

    Public Function Insert(ByVal obj As CM.QLMH_DM_XUATXUEntity) As Boolean
        Return IQLMH_DM_XUATXU.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.QLMH_DM_XUATXUEntity) As Boolean
        Return IQLMH_DM_XUATXU.Update(obj)
    End Function

	Public Function DeleteByID(ByVal uid_Xuatxu AS String) AS Boolean
		Return IQLMH_DM_XUATXU.DeleteByID(uid_Xuatxu)
	End Function

    Public Function SelectByID(ByVal uid_Xuatxu As String) As CM.QLMH_DM_XUATXUEntity
        Return IQLMH_DM_XUATXU.SelectByID(uid_Xuatxu)
    End Function

End Class