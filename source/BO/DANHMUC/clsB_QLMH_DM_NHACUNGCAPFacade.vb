Public Class QLMH_DM_NHACUNGCAPFacade

    Dim IQLMH_DM_NHACUNGCAP As DB.IQLMH_DM_NHACUNGCAPDA = New DB.QLMH_DM_NHACUNGCAPDA

    Public Function SelectAll() As List(Of CM.QLMH_DM_NHACUNGCAPEntity)
        Return IQLMH_DM_NHACUNGCAP.SelectAll()
    End Function

	Public Function SelectAllTable() As System.Data.DataTable
		Return IQLMH_DM_NHACUNGCAP.SelectAllTable()
	End Function

    Public Function Insert(ByVal obj As CM.QLMH_DM_NHACUNGCAPEntity) As Boolean
        Return IQLMH_DM_NHACUNGCAP.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.QLMH_DM_NHACUNGCAPEntity) As Boolean
        Return IQLMH_DM_NHACUNGCAP.Update(obj)
    End Function

	Public Function DeleteByID(ByVal uId_Nhacungcap AS String) AS Boolean
		Return IQLMH_DM_NHACUNGCAP.DeleteByID(uId_Nhacungcap)
	End Function

    Public Function SelectByID(ByVal uId_Nhacungcap As String) As CM.QLMH_DM_NHACUNGCAPEntity
        Return IQLMH_DM_NHACUNGCAP.SelectByID(uId_Nhacungcap)
    End Function

End Class