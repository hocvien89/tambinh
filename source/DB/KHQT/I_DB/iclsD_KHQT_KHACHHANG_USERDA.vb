Public Interface IKHQT_KHACHHANG_USERDA

    Function SelectAll() As System.Collections.Generic.List(Of CM.KHQT_KHACHHANG_USEREntity)

	Function SelectAllTable() AS System.Data.DataTable

    Function SelectByID(ByVal uId_Khachhang As String) As CM.KHQT_KHACHHANG_USEREntity

    Function Insert(ByVal obj As CM.KHQT_KHACHHANG_USEREntity) As Boolean

	Function DeleteByID(ByVal uId_Khachhang AS String) AS Boolean

    Function Update(ByVal obj As CM.KHQT_KHACHHANG_USEREntity) As Boolean

    Function Doimatkhau(ByVal obj As CM.KHQT_KHACHHANG_USEREntity) As Boolean

    Function BaoCaoDichVu(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal Uid_Khachhang As String, ByVal uId_Cuahang As String) As System.Data.DataTable

    Function BAOCAO_DoanhThuTongHop(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As System.Data.DataTable

    Function BAOCAO_PHIEUTHUCHI(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String, ByVal Type As String) As System.Data.DataTable

    Function SoNhatKyChung(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal Uid_Khachhang As String, ByVal uId_Cuahang As String) As System.Data.DataTable

    Function BAOCAO_TONGHOPTHUCHI(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String, ByVal Type As String) As System.Data.DataTable

End Interface