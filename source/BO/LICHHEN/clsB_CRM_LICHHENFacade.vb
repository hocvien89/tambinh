Public Class CRM_LICHHENFacade

    Dim ICRM_LICHHEN As DB.ICRM_LICHHENDA = New DB.CRM_LICHHENDA

    Public Function SelectAll() As List(Of CM.CRM_LICHHENEntity)
        Return ICRM_LICHHEN.SelectAll()
    End Function

    Public Function SelectAllTable(ByVal uId_Cuahang As String, ByVal TuNgay As DateTime, ByVal DenNgay As DateTime) As System.Data.DataTable
        Return ICRM_LICHHEN.SelectAllTable(uId_Cuahang, TuNgay, DenNgay)
    End Function

    Public Function CheckCanhbao(ByVal strTime As String, ByVal uId_Cuahang As String) As System.Data.DataTable
        Return ICRM_LICHHEN.CheckCanhbao(strTime, uId_Cuahang)
    End Function

    Public Function CheckTrungLichhen(ByVal uID_Nhanvien As String, ByVal d_Ngay As DateTime, ByVal v_Tugio As String, ByVal v_Dengio As String, ByVal uId_Cuahang As String, ByVal uId_Lichhen As String) As System.Data.DataTable
        Return ICRM_LICHHEN.CheckTrungLichhen(uID_Nhanvien, d_Ngay, v_Tugio, v_Dengio, uId_Cuahang, uId_Lichhen)
    End Function

    Public Function Insert(ByVal obj As CM.CRM_LICHHENEntity) As Boolean
        Return ICRM_LICHHEN.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.CRM_LICHHENEntity) As Boolean
        Return ICRM_LICHHEN.Update(obj)
    End Function

    Public Function DeleteByID(ByVal uId_Lichhen As String) As Boolean
        Return ICRM_LICHHEN.DeleteByID(uId_Lichhen)
    End Function

    Public Function SelectByID(ByVal uId_Lichhen As String) As CM.CRM_LICHHENEntity
        Return ICRM_LICHHEN.SelectByID(uId_Lichhen)
    End Function

    Public Function SelectByKH(ByVal uID_Khachhang As String, ByVal TuNgay As DateTime, ByVal DenNgay As DateTime) As System.Data.DataTable
        Return ICRM_LICHHEN.SelectByKH(uID_Khachhang, TuNgay, DenNgay)
    End Function

    Public Function SelectByNhanvien(ByVal uID_Nhanvien As String, ByVal TuNgay As DateTime, ByVal DenNgay As DateTime) As System.Data.DataTable
        Return ICRM_LICHHEN.SelectByNhanvien(uID_Nhanvien, TuNgay, DenNgay)
    End Function

    Public Function SelectTrangthaiAllTable(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uID_Trangthai As String) As System.Data.DataTable
        Return ICRM_LICHHEN.SelectTrangthaiAllTable(TuNgay, DenNgay, uID_Trangthai)
    End Function

    Public Function SelectTrangthaiByNhanvien(ByVal uID_Nhanvien As String, ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uID_Trangthai As String) As System.Data.DataTable
        Return ICRM_LICHHEN.SelectTrangthaiByNhanvien(uID_Nhanvien, TuNgay, DenNgay, uID_Trangthai)
    End Function
End Class