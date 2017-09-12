Public Class clsB_Baocao_Taichinh
    Dim iclsD_Baocao_Taichinh As DB.iclsD_Baocao_Taichinh = New DB.clsD_Baocao_Taichinh

    Public Function Thanhtoantructiep(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As String
        Return iclsD_Baocao_Taichinh.Thanhtoantructiep(TuNgay, DenNgay, uId_Cuahang)
    End Function

    Public Function Banthe(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As String
        Return iclsD_Baocao_Taichinh.Banthe(TuNgay, DenNgay, uId_Cuahang)
    End Function

    Public Function Bangoidichvu(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As String
        Return iclsD_Baocao_Taichinh.Bangoidichvu(TuNgay, DenNgay, uId_Cuahang)
    End Function

    Public Function Bansanpham(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As String
        Return iclsD_Baocao_Taichinh.Bansanpham(TuNgay, DenNgay, uId_Cuahang)
    End Function

    Public Function Nhapsanpham(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As String
        Return iclsD_Baocao_Taichinh.Nhapsanpham(TuNgay, DenNgay, uId_Cuahang)
    End Function

    Public Function Khachhangnolai(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As String
        Return iclsD_Baocao_Taichinh.Khachhangnolai(TuNgay, DenNgay, uId_Cuahang)
    End Function
    Public Function Khachhangnosp(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As String
        Return iclsD_Baocao_Taichinh.Khachhangnosp(TuNgay, DenNgay, uId_Cuahang)
    End Function
    Public Function Khachhangthanhtoanno(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As String
        Return iclsD_Baocao_Taichinh.Khachhangthanhtoanno(TuNgay, DenNgay, uId_Cuahang)
    End Function

    Public Function Doanhthu_Dichvu(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As System.Data.DataTable
        Return iclsD_Baocao_Taichinh.Doanhthu_Dichvu(TuNgay, DenNgay, uId_Cuahang)
    End Function

    Public Function Theodoi_CongNo(ByVal uId_Khachhang As String, ByVal TuNgay As DateTime, ByVal DenNgay As DateTime) As System.Data.DataTable
        Return iclsD_Baocao_Taichinh.Theodoi_CongNo(uId_Khachhang, TuNgay, DenNgay)
    End Function

    Function Doanhthu_Dichvu_Ngay_HP(ByVal Ngay As DateTime, ByVal uId_NhomDV As String, ByVal i As Integer) As System.Data.DataTable
        Return iclsD_Baocao_Taichinh.Doanhthu_Dichvu_Ngay_HP(Ngay, uId_NhomDV, i)
    End Function
    Function Doanhthu_Dichvu_Ngay(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_NhomDV As String, ByVal i As Integer) As System.Data.DataTable
        Return iclsD_Baocao_Taichinh.Doanhthu_Dichvu_Ngay(TuNgay, DenNgay, uId_NhomDV, i)
    End Function
    Function Doanhthu_Dichvu_KhoangTG_HP(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal i As Integer) As System.Data.DataTable
        Return iclsD_Baocao_Taichinh.Doanhthu_Dichvu_KhoangTG_HP(TuNgay, DenNgay, i)
    End Function

    Public Function Doanhthu_Dichvu_Nhanvien(ByVal uId_Nhanvien As String, ByVal TuNgay As DateTime, ByVal DenNgay As DateTime) As System.Data.DataTable
        Return iclsD_Baocao_Taichinh.Doanhthu_Dichvu_Nhanvien(uId_Nhanvien, TuNgay, DenNgay)
    End Function
    Public Function Thukhac(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As String
        Return iclsD_Baocao_Taichinh.Thukhac(TuNgay, DenNgay, uId_Cuahang)
    End Function
    Public Function Chikhac(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As String
        Return iclsD_Baocao_Taichinh.Chikhac(TuNgay, DenNgay, uId_Cuahang)
    End Function
    Public Function BC_TongThu_KH(ByVal uId_Cuahang As String, ByVal TuNgay As DateTime, ByVal DenNgay As DateTime) As System.Data.DataTable
        Return iclsD_Baocao_Taichinh.BC_Tongthu_KH(uId_Cuahang, TuNgay, DenNgay)
    End Function

    Public Function Phantram_Hoahong_Dieutri(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As System.Data.DataTable
        Return iclsD_Baocao_Taichinh.Phantram_HoaHong_Dieutri(TuNgay, DenNgay, uId_Cuahang)
    End Function

    Public Function Phantram_Hoahong_BanSP(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As System.Data.DataTable
        Return iclsD_Baocao_Taichinh.Phantram_HoaHong_BanSP(TuNgay, DenNgay, uId_Cuahang)
    End Function
    Public Function BaoCao_PDV_SoToTien(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As System.Data.DataTable
        Return iclsD_Baocao_Taichinh.BaoCao_PDV_SoToTien(TuNgay, DenNgay, uId_Cuahang)
    End Function

    Public Function BAOCAO_DoanhThuTongHop(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As System.Data.DataTable
        Return iclsD_Baocao_Taichinh.BAOCAO_DoanhThuTongHop(TuNgay, DenNgay, uId_Cuahang)
    End Function

    Public Function ThongKeDoanhThuTheoThoiGian(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As String
        Return iclsD_Baocao_Taichinh.ThongKeDoanhThuTheoThoiGian(TuNgay, DenNgay, uId_Cuahang)
    End Function

    Public Function TChinhTonghop(Tungay As DateTime, Denngay As DateTime, uId_Cuahang As String) As String
        Return iclsD_Baocao_Taichinh.TChinhTonghop(Tungay, Denngay, uId_Cuahang)
    End Function

    Public Function BaocaoTonghop_Luong(Thang As DateTime, Nam As DateTime) As DataTable
        Return iclsD_Baocao_Taichinh.BaocaoTonghop_Luong(Thang, Nam)
    End Function

    Public Function Baocaotonghop_Tieuhao(Tungay As DateTime, Denngay As DateTime) As DataTable
        Return iclsD_Baocao_Taichinh.Baocaotonghop_Tieuhao(Tungay, Denngay)
    End Function

    Public Function BaocaoSL_Mathang(Tungay As DateTime, Denngay As DateTime) As DataTable
        Return iclsD_Baocao_Taichinh.BaocaoSL_Mathang(Tungay, Denngay)
    End Function
    Public Function DoanhthuTV(ByVal uId_Nhanvien As String, ByVal Tungay As DateTime, ByVal Denngay As DateTime) As DataTable
        Return iclsD_Baocao_Taichinh.DoanhthuTV(uId_Nhanvien, Tungay, Denngay)
    End Function
End Class
