Public Class TNTP_KHACHHANG_GOIDICHVUFacade

    Dim ITNTP_KHACHHANG_GOIDICHVU As DB.ITNTP_KHACHHANG_GOIDICHVUDA = New DB.TNTP_KHACHHANG_GOIDICHVUDA

    Public Function SelectAll() As List(Of CM.TNTP_KHACHHANG_GOIDICHVUEntity)
        Return ITNTP_KHACHHANG_GOIDICHVU.SelectAll()
    End Function

    Public Function SelectAllTable_ByKH(ByVal uId_Khachhang As String, ByVal DK As Integer) As System.Data.DataTable
        Return ITNTP_KHACHHANG_GOIDICHVU.SelectAllTable_ByKH(uId_Khachhang, DK)
    End Function
    Public Function SelectAllTable(ByVal uId_Cuahang As String) As System.Data.DataTable
        Return ITNTP_KHACHHANG_GOIDICHVU.SelectAllTable(uId_Cuahang)
    End Function

    Public Function Insert(ByVal obj As CM.TNTP_KHACHHANG_GOIDICHVUEntity) As String
        Return ITNTP_KHACHHANG_GOIDICHVU.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.TNTP_KHACHHANG_GOIDICHVUEntity) As Boolean
        Return ITNTP_KHACHHANG_GOIDICHVU.Update(obj)
    End Function

	Public Function DeleteByID(ByVal uId_Khachhang_Goidichvu AS String) AS Boolean
		Return ITNTP_KHACHHANG_GOIDICHVU.DeleteByID(uId_Khachhang_Goidichvu)
	End Function

    Public Function SelectByvMaBarcode(ByVal vMaBarcode As String) As CM.TNTP_KHACHHANG_GOIDICHVUEntity
        Return ITNTP_KHACHHANG_GOIDICHVU.SelectByvBarcode(vMaBarcode)
    End Function

    Public Function SelectByID(ByVal uId_Khachhang_Goidichvu As String) As CM.TNTP_KHACHHANG_GOIDICHVUEntity
        Return ITNTP_KHACHHANG_GOIDICHVU.SelectByID(uId_Khachhang_Goidichvu)
    End Function

    Public Function ThanhToan(ByVal obj As CM.TNTP_KHACHHANG_GOIDICHVUEntity) As Boolean
        Return ITNTP_KHACHHANG_GOIDICHVU.ThanhToan(obj)
    End Function
    Public Function Hoantien(ByVal obj As CM.TNTP_KHACHHANG_GOIDICHVUEntity) As Boolean
        Return ITNTP_KHACHHANG_GOIDICHVU.Hoantien(obj)
    End Function
    Public Function UpdateTrangthai(ByVal obj As CM.TNTP_KHACHHANG_GOIDICHVUEntity) As Boolean
        Return ITNTP_KHACHHANG_GOIDICHVU.UpdateTrangthai(obj)
    End Function
    Public Function SelectAllTable_DSTHE_Daban(ByVal uId_Cuahang As String, ByVal vType As String) As System.Data.DataTable
        Return ITNTP_KHACHHANG_GOIDICHVU.SelectAllTable_DSTHE_Daban(uId_Cuahang, vType)
    End Function

    Public Function chkExist_MaTheThanhtoan(ByVal obj As CM.TNTP_KHACHHANG_GOIDICHVUEntity) As Boolean
        Return ITNTP_KHACHHANG_GOIDICHVU.chkExist_MaTheThanhtoan(obj)
    End Function

    Public Function BaoCao_DSTheKhachHang(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal uId_Cuahang As String, ByVal Keyword As String) As System.Data.DataTable
        Return ITNTP_KHACHHANG_GOIDICHVU.BaoCao_DSTheKhachHang(TuNgay, DenNgay, uId_Cuahang, Keyword)
    End Function

    Public Function LichSuThanhtoan(v_MaThe As String) As DataTable
        Return ITNTP_KHACHHANG_GOIDICHVU.LichSuThanhtoan(v_MaThe)
    End Function

    Function SelectByDate(ByVal TuNgay As DateTime, DenNgay As DateTime, uId_Cuahang As String, uId_Trangthai As String) As System.Data.DataTable
        Return ITNTP_KHACHHANG_GOIDICHVU.SelectByDate(TuNgay, DenNgay, uId_Cuahang, uId_Trangthai)
    End Function


    Public Function CreateMaCode()
        Return ITNTP_KHACHHANG_GOIDICHVU.CreateMaCode()
    End Function

    Function Check_Capthe_By_PDV(ByVal uId_Phieudichvu As String, ByVal uId_Dichvu As String) As DataTable
        Return ITNTP_KHACHHANG_GOIDICHVU.Check_Capthe_By_PDV(uId_Phieudichvu, uId_Dichvu)
    End Function

    Function Select_TheTaiKhoan_By_Khachhang(uId_Khachhang As String, Luachon As Integer) As DataTable
        Return ITNTP_KHACHHANG_GOIDICHVU.Select_TheTaiKhoan_By_Khachhang(uId_Khachhang, Luachon)
    End Function

    Function SelectBy_Mathe(v_Mathe As String) As DataTable
        Return ITNTP_KHACHHANG_GOIDICHVU.SelectBy_Mathe(v_Mathe)
    End Function

    Function Update_Khachhang_GoiDichvu(uId_Khachhang_Goidichvu As String) As Boolean
        Return ITNTP_KHACHHANG_GOIDICHVU.Update_Khachhang_GoiDichvu(uId_Khachhang_Goidichvu)
    End Function

End Class