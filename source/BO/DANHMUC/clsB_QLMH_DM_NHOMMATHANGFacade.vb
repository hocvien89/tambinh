Public Class QLMH_DM_NHOMMATHANGFacade

    Dim IQLMH_DM_NHOMMATHANG As DB.IQLMH_DM_NHOMMATHANGDA = New DB.QLMH_DM_NHOMMATHANGDA

    Public Function SelectAll() As List(Of CM.QLMH_DM_NHOMMATHANGEntity)
        Return IQLMH_DM_NHOMMATHANG.SelectAll()
    End Function

	Public Function SelectAllTable() As System.Data.DataTable
		Return IQLMH_DM_NHOMMATHANG.SelectAllTable()
	End Function

    Public Function Insert(ByVal obj As CM.QLMH_DM_NHOMMATHANGEntity) As Boolean
        Return IQLMH_DM_NHOMMATHANG.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.QLMH_DM_NHOMMATHANGEntity) As Boolean
        Return IQLMH_DM_NHOMMATHANG.Update(obj)
    End Function

	Public Function DeleteByID(ByVal uId_Nhommathang AS String) AS Boolean
		Return IQLMH_DM_NHOMMATHANG.DeleteByID(uId_Nhommathang)
	End Function

    Public Function SelectByID(ByVal uId_Nhommathang As String) As CM.QLMH_DM_NHOMMATHANGEntity
        Return IQLMH_DM_NHOMMATHANG.SelectByID(uId_Nhommathang)
    End Function
    'xuanhieu 31/10/2014
    Public Function SelectcheckMa(manhom As String) As String
        Return IQLMH_DM_NHOMMATHANG.SelectcheckMa(manhom)
    End Function
End Class