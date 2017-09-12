Public Class MKT_KH_TIEMNANGFacade

    Dim IMKT_KH_TIEMNANG As DB.IMKT_KH_TIEMNANGDA = New DB.MKT_KH_TIEMNANGDA

    Public Function SelectAll() As List(Of CM.MKT_KH_TIEMNANGEntity)
        Return IMKT_KH_TIEMNANG.SelectAll()
    End Function

    Public Function SelectAllTable(ByVal Tungay As DateTime, ByVal Denngay As DateTime, uid_Cuahang As String) As System.Data.DataTable
        Return IMKT_KH_TIEMNANG.SelectAllTable(Tungay, Denngay, uid_Cuahang)
    End Function

    Public Function Insert(ByVal obj As CM.MKT_KH_TIEMNANGEntity) As String
        Return IMKT_KH_TIEMNANG.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.MKT_KH_TIEMNANGEntity) As Boolean
        Return IMKT_KH_TIEMNANG.Update(obj)
    End Function

    Public Function DeleteByID(ByVal uId_KH_Tiemnang As String) As Boolean
        Return IMKT_KH_TIEMNANG.DeleteByID(uId_KH_Tiemnang)
    End Function

    Public Function SelectByID(ByVal uId_KH_Tiemnang As String) As CM.MKT_KH_TIEMNANGEntity
        Return IMKT_KH_TIEMNANG.SelectByID(uId_KH_Tiemnang)
    End Function

    Public Function MaKH() As String
        Return IMKT_KH_TIEMNANG.MaKH()
    End Function

    Public Function TimKiem(ByVal obj As CM.MKT_KH_TIEMNANGEntity) As System.Data.DataTable
        Return IMKT_KH_TIEMNANG.TimKiem(obj)
    End Function

    Public Function TimKiemNangCao(ByVal keyword As String) As System.Data.DataTable
        Return IMKT_KH_TIEMNANG.TimKiemNangCao(keyword)
    End Function

    Public Function SelectCongviec(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_KH_Tiemnang As String, ByVal strLoai As String) As System.Data.DataTable
        Return IMKT_KH_TIEMNANG.SelectCongviec(TuNgay, DenNgay, uId_KH_Tiemnang, strLoai)
    End Function
    Public Function SelectLSchuyendoi(ByVal uId_KH_Tiemnang As String) As System.Data.DataTable
        Return IMKT_KH_TIEMNANG.SelectLSchuyendoi(uId_KH_Tiemnang)
    End Function

    Public Function SelectByCapChuyen(ByVal Tungay As Date, ByVal Denngay As Date, ByVal uId_Chuyendoi As String, ByVal TuoiTu As Integer, ByVal TuoiDen As Integer, ByVal b_Gioitinh As Boolean, ByVal Type As Integer) As System.Data.DataTable
        Return IMKT_KH_TIEMNANG.SelectByCapChuyen(Tungay, Denngay, uId_Chuyendoi, TuoiTu, TuoiDen, b_Gioitinh, Type)
    End Function

    Public Function SelectByDaCoHoSo(ByVal Tungay As DateTime, ByVal Denngay As DateTime, ByVal TuoiTu As Integer, ByVal TuoiDen As Integer, ByVal b_Gioitinh As Boolean, ByVal Type As Integer) As System.Data.DataTable
        Return IMKT_KH_TIEMNANG.SelectByDaCoHoSo(Tungay, Denngay, TuoiTu, TuoiDen, b_Gioitinh, Type)
    End Function

    Public Function SELECTBYMaKHHethong(ByVal uId_Khachhang As String) As CM.MKT_KH_TIEMNANGEntity
        Return IMKT_KH_TIEMNANG.SELECTBYMaKHHethong(uId_Khachhang)
    End Function

    Public Function KiemtraTontaiSDT(ByVal SDT As String, ByVal Email As String) As System.Data.DataTable
        Return IMKT_KH_TIEMNANG.KiemtraTontaiSDT(SDT, Email)
    End Function

    Public Function SelectAll_V1(ByVal Tungay As DateTime, ByVal Denngay As DateTime, uId_Phong As String) As System.Data.DataTable
        Return IMKT_KH_TIEMNANG.SelectAll_V1(Tungay, Denngay, uId_Phong)
    End Function

    Public Function SelectByIDCapChuyen(ByVal uId_KH_Tiemnang As String) As System.Data.DataTable
        Return IMKT_KH_TIEMNANG.SelectByIDCapChuyen(uId_KH_Tiemnang)
    End Function

    Public Function LichSuKhachHang(ByVal Tungay As DateTime, ByVal Denngay As DateTime, ByVal uId_KH_Tiemnang As String) As System.Data.DataTable
        Return IMKT_KH_TIEMNANG.LichSuKhachHang(Tungay, Denngay, uId_KH_Tiemnang)
    End Function

    Public Function SelectByMaKH(ByVal v_Makhachhang As String) As CM.MKT_KH_TIEMNANGEntity
        Return IMKT_KH_TIEMNANG.SelectByMaKH(v_Makhachhang)
    End Function

    Public Function TongHopKHTiemNang(ByVal Tungay As DateTime, ByVal Denngay As DateTime, ByVal uId_Cuahang As String) As System.Data.DataTable
        Return IMKT_KH_TIEMNANG.TongHopKHTiemNang(Tungay, Denngay, uId_Cuahang)
    End Function

    Public Function SelectKHUutienChamsoc(Tungay As Date, Denngay As Date, uId_Cuahang As String, Type As String) As DataTable
        Return IMKT_KH_TIEMNANG.SelectKHUutienChamsoc(TuNgay, DenNgay, uId_Cuahang, Type)
    End Function

    Function ChamsocKH(Tungay As String, Denngay As Date, uId_Cuahang As String, loaiKH As String, Thamso As String) As DataTable
        Return IMKT_KH_TIEMNANG.ChamsocKH(Tungay, Denngay, uId_Cuahang, loaiKH, Thamso)
    End Function

End Class