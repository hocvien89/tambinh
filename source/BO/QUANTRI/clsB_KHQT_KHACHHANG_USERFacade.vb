Public Class KHQT_KHACHHANG_USERFacade

	Dim IKHQT_KHACHHANG_USER As DataAccess.IKHQT_KHACHHANG_USERDA = New DataAccess.KHQT_KHACHHANG_USERDA

	Public Function SelectAll() As List(Of Common.KHQT_KHACHHANG_USEREntity)
		Return IKHQT_KHACHHANG_USER.SelectAll()
	End Function

	Public Function SelectAllTable() As System.Data.DataTable
		Return IKHQT_KHACHHANG_USER.SelectAllTable()
	End Function

	Public Function Insert(ByVal obj As Common.KHQT_KHACHHANG_USEREntity) AS Boolean
		Return IKHQT_KHACHHANG_USER.Insert(obj)
	End Function

	Public Function Update(ByVal obj As Common.KHQT_KHACHHANG_USEREntity) AS Boolean
		Return IKHQT_KHACHHANG_USER.Update(obj)
	End Function

	Public Function DeleteByID(ByVal uId_Khachhang AS String) AS Boolean
		Return IKHQT_KHACHHANG_USER.DeleteByID(uId_Khachhang)
	End Function

	Public Function SelectByID(ByVal uId_Khachhang AS String) As Common.KHQT_KHACHHANG_USEREntity
		Return IKHQT_KHACHHANG_USER.SelectByID(uId_Khachhang)
	End Function

End Class