Public Interface ICRM_LICHHENDA

    Function SelectAll() As System.Collections.Generic.List(Of CM.CRM_LICHHENEntity)

    Function SelectAllTable(ByVal uId_Cuahang As String, ByVal TuNgay As DateTime, ByVal DenNgay As DateTime) As System.Data.DataTable

    Function CheckCanhbao(ByVal strTime As String, ByVal uId_Cuahang As String) As System.Data.DataTable

    Function CheckTrungLichhen(ByVal uID_Nhanvien As String, ByVal d_Ngay As DateTime, ByVal v_Tugio As String, ByVal v_Dengio As String, ByVal uId_Cuahang As String, ByVal uId_Lichhen As String) As System.Data.DataTable

    Function SelectByID(ByVal uId_Lichhen As String) As CM.CRM_LICHHENEntity

    Function Insert(ByVal obj As CM.CRM_LICHHENEntity) As Boolean

	Function DeleteByID(ByVal uId_Lichhen AS String) AS Boolean

    Function Update(ByVal obj As CM.CRM_LICHHENEntity) As Boolean

    Function SelectByKH(ByVal uID_Khachhang As String, ByVal TuNgay As DateTime, ByVal DenNgay As DateTime) As System.Data.DataTable

    Function SelectByNhanvien(ByVal uID_Nhanvien As String, ByVal TuNgay As DateTime, ByVal DenNgay As DateTime) As System.Data.DataTable

    Function SelectTrangthaiAllTable(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uID_Trangthai As String) As System.Data.DataTable

    Function SelectTrangthaiByNhanvien(ByVal uID_Nhanvien As String, ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uID_Trangthai As String) As System.Data.DataTable

End Interface