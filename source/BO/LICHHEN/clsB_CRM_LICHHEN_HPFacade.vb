Public Class CRM_LICHHEN_HPFacade

    Dim ICRM_LICHHEN_HP As DB.ICRM_LICHHEN_HPDA = New DB.CRM_LICHHEN_HPDA

    Public Function SelectAll(ByVal d_Tungay As DateTime, ByVal d_Denngay As DateTime) As List(Of CM.CRM_LICHHEN_HPEntity)
        Return ICRM_LICHHEN_HP.SelectAll(d_Tungay, d_Denngay)
    End Function

	Public Function SelectAllTable(ByVal d_Tungay AS DateTime,ByVal d_Denngay AS DateTime) AS System.Data.DataTable
		Return ICRM_LICHHEN_HP.SelectAllTable(d_Tungay,d_Denngay)
	End Function

    Public Function SelectAllKhachToihen(ByVal d_Tungay As DateTime) As System.Data.DataTable
        Return ICRM_LICHHEN_HP.SelectAllKhachToihen(d_Tungay)
    End Function

    Public Function Insert(ByVal obj As CM.CRM_LICHHEN_HPEntity) As Boolean
        Return ICRM_LICHHEN_HP.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.CRM_LICHHEN_HPEntity) As Boolean
        Return ICRM_LICHHEN_HP.Update(obj)
    End Function

	Public Function DeleteByID(ByVal uId_Lichhen_HP AS String) AS Boolean
		Return ICRM_LICHHEN_HP.DeleteByID(uId_Lichhen_HP)
	End Function

    Public Function SelectByID(ByVal uId_Lichhen_HP As String) As CM.CRM_LICHHEN_HPEntity
        Return ICRM_LICHHEN_HP.SelectByID(uId_Lichhen_HP)
    End Function

    Public Function SelectByKH(ByVal uID_Khachhang As String, ByVal TuNgay As DateTime, ByVal DenNgay As DateTime) As System.Data.DataTable
        Return ICRM_LICHHEN_HP.SelectByKH(uID_Khachhang, TuNgay, DenNgay)
    End Function

    Public Function SelectByNhanvien(ByVal uID_Nhanvien As String, ByVal TuNgay As DateTime, ByVal DenNgay As DateTime) As System.Data.DataTable
        Return ICRM_LICHHEN_HP.SelectByNhanvien(uID_Nhanvien, TuNgay, DenNgay)
    End Function

    Public Function SelectTrangthaiAllTable(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uID_Trangthai As String) As System.Data.DataTable
        Return ICRM_LICHHEN_HP.SelectTrangthaiAllTable(TuNgay, DenNgay, uID_Trangthai)
    End Function

    Public Function SelectTrangthaiByNhanvien(ByVal uID_Nhanvien As String, ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uID_Trangthai As String) As System.Data.DataTable
        Return ICRM_LICHHEN_HP.SelectTrangthaiByNhanvien(uID_Nhanvien, TuNgay, DenNgay, uID_Trangthai)
    End Function

End Class