Public Interface ICRM_LICHHEN_HPDA

    Function SelectAll(ByVal d_Tungay As DateTime, ByVal d_Denngay As DateTime) As System.Collections.Generic.List(Of CM.CRM_LICHHEN_HPEntity)

    Function SelectAllTable(ByVal d_Tungay As DateTime, ByVal d_Denngay As DateTime) As System.Data.DataTable

    Function SelectAllKhachToihen(ByVal d_Tungay As DateTime) As System.Data.DataTable

    Function SelectByID(ByVal uId_Lichhen_HP As String) As CM.CRM_LICHHEN_HPEntity

    Function Insert(ByVal obj As CM.CRM_LICHHEN_HPEntity) As Boolean

	Function DeleteByID(ByVal uId_Lichhen_HP AS String) AS Boolean

    Function Update(ByVal obj As CM.CRM_LICHHEN_HPEntity) As Boolean

    Function SelectByKH(ByVal uID_Khachhang As String, ByVal TuNgay As DateTime, ByVal DenNgay As DateTime) As System.Data.DataTable

    Function SelectByNhanvien(ByVal uID_Nhanvien As String, ByVal TuNgay As DateTime, ByVal DenNgay As DateTime) As System.Data.DataTable

    Function SelectTrangthaiAllTable(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uID_Trangthai As String) As System.Data.DataTable

    Function SelectTrangthaiByNhanvien(ByVal uID_Nhanvien As String, ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uID_Trangthai As String) As System.Data.DataTable

End Interface