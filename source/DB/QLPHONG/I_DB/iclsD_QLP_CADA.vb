Public Interface IQLP_CADA

    Function SelectAll(ByVal d_Ngay As DateTime) As System.Collections.Generic.List(Of CM.QLP_CAEntity)

    Function SelectAllTable(ByVal d_Ngay As DateTime) As System.Data.DataTable

    Function SelectAllBuffer(ByVal uId_Cuahang As String) As System.Data.DataTable

    Function SelectByID(ByVal uId_Ca As String) As CM.QLP_CAEntity

    Function SelectByDate(ByVal uId_Phong As String, ByVal d_Ngay As DateTime) As System.Data.DataTable

    Function SelectPhongByDate(ByVal d_Ngay As DateTime, ByVal uId_Cuahang As String) As System.Data.DataTable

    Function Insert(ByVal obj As CM.QLP_CAEntity) As String

	Function DeleteByID(ByVal uId_Ca AS String) AS Boolean

    Function Update(ByVal obj As CM.QLP_CAEntity) As Boolean

    Function SelectByPhong(ByVal d_Ngay As DateTime) As System.Data.DataTable

    Function SelectAllByNgay(ByVal d_Ngay As DateTime) As System.Data.DataTable

    Function SelectAllByThoigian(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As System.Data.DataTable

End Interface