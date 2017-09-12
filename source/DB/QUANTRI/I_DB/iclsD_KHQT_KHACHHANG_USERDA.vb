Public Interface IKHQT_KHACHHANG_USERDA

	Function SelectAll() AS List(Of Common.KHQT_KHACHHANG_USEREntity)

	Function SelectAllTable() AS System.Data.DataTable

	Function SelectByID(ByVal uId_Khachhang AS String) AS Common.KHQT_KHACHHANG_USEREntity

	Function Insert(ByVal obj AS Common.KHQT_KHACHHANG_USEREntity) AS Boolean

	Function DeleteByID(ByVal uId_Khachhang AS String) AS Boolean

	Function Update(ByVal obj AS Common.KHQT_KHACHHANG_USEREntity) AS Boolean

End Interface