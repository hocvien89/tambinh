Public Class QLL_QUATRINHLUONGFacade

    Dim IQLL_QUATRINHLUONG As DB.IQLL_QUATRINHLUONGDA = New DB.QLL_QUATRINHLUONGDA

    Public Function SelectAll(ByVal uId_Nhanvien As String) As List(Of CM.QLL_QUATRINHLUONGEntity)
        Return IQLL_QUATRINHLUONG.SelectAll(uId_Nhanvien)
    End Function

	Public Function SelectAllTable(ByVal uId_Nhanvien AS String) AS System.Data.DataTable
		Return IQLL_QUATRINHLUONG.SelectAllTable(uId_Nhanvien)
	End Function

    Public Function Insert(ByVal obj As CM.QLL_QUATRINHLUONGEntity) As Boolean
        Return IQLL_QUATRINHLUONG.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.QLL_QUATRINHLUONGEntity) As Boolean
        Return IQLL_QUATRINHLUONG.Update(obj)
    End Function

	Public Function DeleteByID(ByVal uId_QuatrinhLuong AS String) AS Boolean
		Return IQLL_QUATRINHLUONG.DeleteByID(uId_QuatrinhLuong)
	End Function

    Public Function SelectByID(ByVal uId_QuatrinhLuong As String) As CM.QLL_QUATRINHLUONGEntity
        Return IQLL_QUATRINHLUONG.SelectByID(uId_QuatrinhLuong)
    End Function

End Class