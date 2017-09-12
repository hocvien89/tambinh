Public Class QLP_CAFacade

    Dim IQLP_CA As DB.IQLP_CADA = New DB.QLP_CADA

    Public Function SelectAll(ByVal d_Ngay As DateTime) As List(Of CM.QLP_CAEntity)
        Return IQLP_CA.SelectAll(d_Ngay)
    End Function

	Public Function SelectAllTable(ByVal d_Ngay AS DateTime) AS System.Data.DataTable
		Return IQLP_CA.SelectAllTable(d_Ngay)
	End Function
    Public Function SelectAllBuffer(ByVal uId_Cuahang As String) As System.Data.DataTable
        Return IQLP_CA.SelectAllBuffer(uId_Cuahang)
    End Function
    Public Function Insert(ByVal obj As CM.QLP_CAEntity) As String
        Return IQLP_CA.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.QLP_CAEntity) As Boolean
        Return IQLP_CA.Update(obj)
    End Function

	Public Function DeleteByID(ByVal uId_Ca AS String) AS Boolean
		Return IQLP_CA.DeleteByID(uId_Ca)
	End Function

    Public Function SelectByID(ByVal uId_Ca As String) As CM.QLP_CAEntity
        Return IQLP_CA.SelectByID(uId_Ca)
    End Function

    Public Function SelectByDate(ByVal uId_Phong As String, ByVal d_Ngay As DateTime) As System.Data.DataTable
        Return IQLP_CA.SelectByDate(uId_Phong, d_Ngay)
    End Function
    Public Function SelectPhongByDate(ByVal d_Ngay As DateTime, ByVal uId_Cuahang As String) As System.Data.DataTable
        Return IQLP_CA.SelectPhongByDate(d_Ngay, uId_Cuahang)
    End Function
    Public Function SelectByPhong(ByVal d_Ngay As DateTime) As System.Data.DataTable
        Return IQLP_CA.SelectByPhong(d_Ngay)
    End Function

    Public Function SelectAllByNgay(ByVal d_Ngay As DateTime) As System.Data.DataTable
        Return IQLP_CA.SelectAllByNgay(d_Ngay)
    End Function

    Public Function SelectAllByThoigian(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As System.Data.DataTable
        Return IQLP_CA.SelectAllByThoigian(TuNgay, DenNgay, uId_Cuahang)
    End Function
End Class