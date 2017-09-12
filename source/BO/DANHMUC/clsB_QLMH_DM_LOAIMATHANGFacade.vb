Public Class QLMH_DM_LOAIMATHANGFacade

    Dim IQLMH_DM_LOAIMATHANG As DB.IQLMH_DM_LOAIMATHANGDA = New DB.QLMH_DM_LOAIMATHANGDA

    Public Function SelectAll() As List(Of CM.QLMH_DM_LOAIMATHANGEntity)
        Return IQLMH_DM_LOAIMATHANG.SelectAll()
    End Function

	Public Function SelectAllTable() As System.Data.DataTable
		Return IQLMH_DM_LOAIMATHANG.SelectAllTable()
	End Function

    Public Function Insert(ByVal obj As CM.QLMH_DM_LOAIMATHANGEntity) As Boolean
        Return IQLMH_DM_LOAIMATHANG.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.QLMH_DM_LOAIMATHANGEntity) As Boolean
        Return IQLMH_DM_LOAIMATHANG.Update(obj)
    End Function

	Public Function DeleteByID(ByVal uId_Loaimathang AS String) AS Boolean
		Return IQLMH_DM_LOAIMATHANG.DeleteByID(uId_Loaimathang)
	End Function

    Public Function SelectByID(ByVal uId_Loaimathang As String) As CM.QLMH_DM_LOAIMATHANGEntity
        Return IQLMH_DM_LOAIMATHANG.SelectByID(uId_Loaimathang)
    End Function
    'xuanhieu 31/10/2014 kiem tra ma loai hang trong file excel
    Public Function SellectcheckMa(maloai As String) As String
        Return IQLMH_DM_LOAIMATHANG.Selectcheckma(maloai)
    End Function
End Class