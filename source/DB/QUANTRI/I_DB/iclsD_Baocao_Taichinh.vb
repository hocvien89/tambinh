Public Interface iclsD_Baocao_Taichinh

    Function Thanhtoantructiep(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As String

    Function Banthe(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As String

    Function Bangoidichvu(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As String

    Function Bansanpham(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As String

    Function Nhapsanpham(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As String

    Function Khachhangnolai(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As String

    Function Khachhangnosp(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As String

    Function Khachhangthanhtoanno(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As String

    Function Thukhac(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As String

    Function Chikhac(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As String

    Function BC_Tongthu_KH(ByVal uId_Cuahang As String, ByVal TuNgay As DateTime, ByVal DenNgay As DateTime) As System.Data.DataTable

    Function Doanhthu_Dichvu(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As System.Data.DataTable

    Function Theodoi_CongNo(ByVal uId_Khachhang As String, ByVal TuNgay As DateTime, ByVal DenNgay As DateTime) As System.Data.DataTable

    Function Doanhthu_Dichvu_Nhanvien(ByVal uId_Nhanvien As String, ByVal TuNgay As DateTime, ByVal DenNgay As DateTime) As System.Data.DataTable

    Function Doanhthu_Dichvu_Ngay_HP(ByVal Ngay As DateTime, ByVal uId_NhomDV As String, ByVal i As Integer) As System.Data.DataTable

    Function Doanhthu_Dichvu_Ngay(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_NhomDV As String, ByVal i As Integer) As System.Data.DataTable

    Function Doanhthu_Dichvu_KhoangTG_HP(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal i As Integer) As System.Data.DataTable

    Function Phantram_HoaHong_Dieutri(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As System.Data.DataTable

    Function Phantram_HoaHong_BanSP(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As System.Data.DataTable

    Function BaoCao_PDV_SoToTien(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As System.Data.DataTable

    Function BAOCAO_DoanhThuTongHop(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As System.Data.DataTable

    Function ThongKeDoanhThuTheoThoiGian(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As String

    Function TChinhTonghop(Tungay As DateTime, Denngay As DateTime, uId_Cuahang As String) As String

    Function BaocaoTonghop_Luong(Ngay As DateTime, nam As DateTime) As DataTable

    Function Baocaotonghop_Tieuhao(Tungay As DateTime, Denngay As DateTime) As DataTable

    Function BaocaoSL_Mathang(Tungay As DateTime, Denngay As DateTime) As DataTable

    Function DoanhthuTV(ByVal uId_Nhanvien As String, ByVal Tungay As DateTime, ByVal Denngay As DateTime) As DataTable
End Interface

