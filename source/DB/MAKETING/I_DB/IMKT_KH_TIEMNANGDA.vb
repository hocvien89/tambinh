Public Interface IMKT_KH_TIEMNANGDA

    Function SelectAll() As List(Of CM.MKT_KH_TIEMNANGEntity)

    Function SelectAllTable(ByVal Tungay As DateTime, ByVal Denngay As DateTime, uid_Cuahang As String) As System.Data.DataTable

    Function SelectByID(ByVal uId_KH_Tiemnang As String) As CM.MKT_KH_TIEMNANGEntity

    Function Insert(ByVal obj As CM.MKT_KH_TIEMNANGEntity) As String

    Function DeleteByID(ByVal uId_KH_Tiemnang As String) As Boolean

    Function Update(ByVal obj As CM.MKT_KH_TIEMNANGEntity) As Boolean

    Function MaKH() As String

    Function TimKiem(ByVal obj As CM.MKT_KH_TIEMNANGEntity) As System.Data.DataTable

    Function TimKiemNangCao(ByVal keyword As String) As System.Data.DataTable

    Function SelectCongviec(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_KH_Tiemnang As String, ByVal strLoai As String) As System.Data.DataTable

    Function SelectLSchuyendoi(ByVal uId_KH_Tiemnang As String) As System.Data.DataTable

    Function SelectByCapChuyen(ByVal Tungay As DateTime, ByVal Denngay As DateTime, ByVal uId_Chuyendoi As String, ByVal TuoiTu As Integer, ByVal TuoiDen As Integer, ByVal b_Gioitinh As Boolean, ByVal Type As Integer) As System.Data.DataTable

    Function SelectByDaCoHoSo(ByVal Tungay As DateTime, ByVal Denngay As DateTime, ByVal TuoiTu As Integer, ByVal TuoiDen As Integer, ByVal b_Gioitinh As Boolean, ByVal Type As Integer) As System.Data.DataTable

    Function SELECTBYMaKHHethong(ByVal uId_Khachhang As String) As CM.MKT_KH_TIEMNANGEntity

    Function KiemtraTontaiSDT(ByVal SDT As String, ByVal Email As String) As System.Data.DataTable

    Function SelectAll_V1(ByVal Tungay As DateTime, ByVal Denngay As DateTime, uId_Phong As String) As System.Data.DataTable

    Function SelectByIDCapChuyen(ByVal uId_KH_Tiemnang As String) As System.Data.DataTable

    Function LichSuKhachHang(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_KH_Tiemnang As String) As System.Data.DataTable

    Function SelectByMaKH(ByVal v_Makhachhang As String) As CM.MKT_KH_TIEMNANGEntity

    Function TongHopKHTiemNang(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As System.Data.DataTable

    Function SelectKHUutienChamsoc(Tungay As DateTime, Denngay As DateTime, uId_Cuahang As String, Type As String) As DataTable

    Function ChamsocKH(Tungay As String, Denngay As Date, uId_Cuahang As String, loaiKH As String, Thamso As String) As DataTable

End Interface