Public Interface IQLL_THONGTINLUONGDA

    Function SelectAll(ByVal i_Thang As Int32, ByVal i_Nam As Int32) As System.Collections.Generic.List(Of CM.QLL_THONGTINLUONGEntity)

    Function SelectAllTable(ByVal i_Thang As Int32, ByVal i_Nam As Int32, uIdCuahang As String) As System.Data.DataTable

    Function SelectByID(ByVal uId_Thongtinluong As String) As CM.QLL_THONGTINLUONGEntity

    Function Insert(ByVal obj As CM.QLL_THONGTINLUONGEntity) As Boolean

	Function DeleteByID(ByVal uId_Thongtinluong AS String) AS Boolean

    Function Update(ByVal obj As CM.QLL_THONGTINLUONGEntity) As Boolean

    Function SelectInfobyNV(i_thang As Int32, i_nam As Int32, uId_Nhanvien As String) As CM.QLL_THONGTINLUONGEntity
End Interface