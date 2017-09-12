Public Class QLL_THONGTINLUONGFacade

    Dim IQLL_THONGTINLUONG As DB.IQLL_THONGTINLUONGDA = New DB.QLL_THONGTINLUONGDA

    Public Function SelectAll(ByVal i_Thang As Int32, ByVal i_Nam As Int32) As List(Of CM.QLL_THONGTINLUONGEntity)
        Return IQLL_THONGTINLUONG.SelectAll(i_Thang, i_Nam)
    End Function

    Public Function SelectAllTable(ByVal i_Thang As Int32, ByVal i_Nam As Int32, uIdCuahang As String) As System.Data.DataTable
        Return IQLL_THONGTINLUONG.SelectAllTable(i_Thang, i_Nam, uIdCuahang)
    End Function

    Public Function Insert(ByVal obj As CM.QLL_THONGTINLUONGEntity) As Boolean
        Return IQLL_THONGTINLUONG.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.QLL_THONGTINLUONGEntity) As Boolean
        Return IQLL_THONGTINLUONG.Update(obj)
    End Function

	Public Function DeleteByID(ByVal uId_Thongtinluong AS String) AS Boolean
		Return IQLL_THONGTINLUONG.DeleteByID(uId_Thongtinluong)
	End Function

    Public Function SelectByID(ByVal uId_Thongtinluong As String) As CM.QLL_THONGTINLUONGEntity
        Return IQLL_THONGTINLUONG.SelectByID(uId_Thongtinluong)
    End Function


    Public Function chk_CheckTTLuong(ByVal i_Thang As Int32, ByVal i_Nam As Int32, ByVal uId_Nhanvien As String)
        Dim bKT As Boolean = False
        Dim DR() As DataRow = SelectAllTable(i_Thang, i_Nam, "").Select("uId_Nhanvien='" & uId_Nhanvien & "'")
        If DR.Length > 0 Then bKT = True
        Return bKT

    End Function

    Public Function SelectInfobyNV(i_thang As Int32, i_nam As Int32, uId_Nhanvien As String) As CM.QLL_THONGTINLUONGEntity
        Return IQLL_THONGTINLUONG.SelectInfobyNV(i_thang, i_nam, uId_Nhanvien)
    End Function
End Class