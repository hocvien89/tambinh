Public Interface IQLL_QUATRINHLUONGDA

    Function SelectAll(ByVal uId_Nhanvien As String) As System.Collections.Generic.List(Of CM.QLL_QUATRINHLUONGEntity)

	Function SelectAllTable(ByVal uId_Nhanvien AS String) AS System.Data.DataTable

    Function SelectByID(ByVal uId_QuatrinhLuong As String) As CM.QLL_QUATRINHLUONGEntity

    Function Insert(ByVal obj As CM.QLL_QUATRINHLUONGEntity) As Boolean

	Function DeleteByID(ByVal uId_QuatrinhLuong AS String) AS Boolean

    Function Update(ByVal obj As CM.QLL_QUATRINHLUONGEntity) As Boolean

End Interface