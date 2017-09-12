Public Class clsB_BaoCao_Khachhang
    Dim iclsBaoCao_Khachhang As DB.iclsD_BaoCao_Khachhang = New DB.clsD_BaoCao_Khachhang

    Public Function SelectGoiDV_KhachhangNo() As System.Data.DataTable
        Return iclsBaoCao_Khachhang.SelectGoiDV_KhachhangNo()
    End Function

    Public Function SelectTheDV_KhachhangNo() As System.Data.DataTable
        Return iclsBaoCao_Khachhang.SelectTheDV_KhachhangNo()
    End Function

    Public Function SelectThongkeKH_Nguon(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Nguonden As String, ByVal uId_Cuahang As String) As System.Data.DataTable
        Return iclsBaoCao_Khachhang.SelectThongkeKH_Nguon(TuNgay, DenNgay, uId_Nguonden, uId_Cuahang)
    End Function

    Public Function SelectThongkeKH_Gioitinh(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal b_Gioitinh As Byte, ByVal uId_Cuahang As String) As System.Data.DataTable
        Return iclsBaoCao_Khachhang.SelectThongkeKH_Gioitinh(TuNgay, DenNgay, b_Gioitinh, uId_Cuahang)
    End Function

    Public Function SelectThongkeKH_Dotuoi(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal TuoiTu As Int32, ByVal TuoiDen As Int32, ByVal uId_Cuahang As String) As System.Data.DataTable
        Return iclsBaoCao_Khachhang.SelectThongkeKH_Dotuoi(TuNgay, DenNgay, TuoiTu, TuoiDen, uId_Cuahang)
    End Function

    Public Function SelectThongkeKH_Tatca(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As System.Data.DataTable
        Return iclsBaoCao_Khachhang.SelectThongkeKH_Tatca(TuNgay, DenNgay, uId_Cuahang)
    End Function

    Public Function SelectAll_DS_KH_BoDT(ByVal i_Sothang As Int32, ByVal uId_Cuahang As String) As System.Data.DataTable
        Return iclsBaoCao_Khachhang.SelectAll_DS_KH_BoDT(i_Sothang, uId_Cuahang)
    End Function

    Public Function SelectThongkeKH_ByTime(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As System.Data.DataTable
        Return iclsBaoCao_Khachhang.SelectThongkeKH_ByTime(TuNgay, DenNgay, uId_Cuahang)
    End Function

    Public Function Baocao_taichinh_Dichvu(tungay As Date, denngay As Date, uId_Cuahang As String) As DataTable
        Return iclsBaoCao_Khachhang.Baocao_taichinh_Dichvu(tungay, denngay, uId_Cuahang)
    End Function
    'Long them
    Public Function SelectThongkeKH_Dichvu_ByTime(ByVal Thang As DateTime, ByVal tungay As DateTime) As System.Data.DataTable
        Return iclsBaoCao_Khachhang.SelectThongkeKH_Dichvu_ByTime(Thang, tungay)
    End Function
    'Long them
    Public Function spCRM_DM_TINHTHANH_SelectAll() As System.Data.DataTable
        Return iclsBaoCao_Khachhang.spCRM_DM_TINHTHANH_SelectAll()
    End Function
    'Long them
    Public Function spCRM_DM_QUANHUYEN_SelectAllByID(ByVal uId_Tinhthanh As String) As System.Data.DataTable
        Return iclsBaoCao_Khachhang.spCRM_DM_QUANHUYEN_SelectAllByID(uId_Tinhthanh)
    End Function

    'Long them
    Public Function spBAOCAO_LuongKH(i_DenTuoi As Integer, i_TuTuoi As Integer, b_Gioitinh As String, uId_Quanhuyen As String) As System.Data.DataTable
        Return iclsBaoCao_Khachhang.spBAOCAO_LuongKH(i_DenTuoi, i_TuTuoi, b_Gioitinh, uId_Quanhuyen)
    End Function
    'Phuongdv báo cáo thông kê khách hàng đã mua và chưa mua sản phẩm hay dịch vụ
    Public Function SelectThongkeKH_Damua_Sanpham() As System.Data.DataTable
        Return iclsBaoCao_Khachhang.SelectThongkeKH_Damua_Sanpham()
    End Function
    Public Function SelectThongkeKH_Chuamua_Sanpham() As System.Data.DataTable
        Return iclsBaoCao_Khachhang.SelectThongkeKH_chuamua_Sanpham()
    End Function
    Public Function SelectThongkeKHByDichvu(ByVal uId_Dichvu As String) As System.Data.DataTable
        Return iclsBaoCao_Khachhang.SelectThongkeKHByDichvu(uId_Dichvu)
    End Function
    Public Function SelectThongkeKHAll() As System.Data.DataTable
        Return iclsBaoCao_Khachhang.SelectThongkeKHAll()
    End Function
    'Phuongdv Bao cao me va be
    Public Function BaocaoHopDong_MevaBe(ByVal uId_Khachhang As String, ByVal uId_Phieudichvu_chitiet As String) As System.Data.DataTable
        Return iclsBaoCao_Khachhang.BaocaoHopDong_MevaBe(uId_Khachhang, uId_Phieudichvu_chitiet)
    End Function

    Public Function CongnoKH_ByID(ByVal Tungay As DateTime, ByVal Denngay As DateTime, ByVal uId_Cuahang As String, ByVal uId_Khachhang As String) As System.Data.DataTable
        Return iclsBaoCao_Khachhang.ConnoKH_ByID(Tungay, Denngay, uId_Cuahang, uId_Khachhang)
    End Function
#Region "Thống kê"
    Public Function ThongkeKH_Tatca(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal uId_Cuahang As String) As System.Data.DataTable
        Return iclsBaoCao_Khachhang.ThongkeKH_Tatca(TuNgay, DenNgay, uId_Cuahang)
    End Function

    Public Function ThongkeKH_Gioitinh(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal b_Gioitinh As Byte, ByVal uId_Cuahang As String) As System.Data.DataTable
        Return iclsBaoCao_Khachhang.ThongkeKH_Gioitinh(TuNgay, DenNgay, b_Gioitinh, uId_Cuahang)
    End Function

    Public Function ThongkeKH_Dotuoi(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal TuoiTu As Integer, ByVal TuoiDen As Integer, ByVal uId_Cuahang As String) As System.Data.DataTable
        Return iclsBaoCao_Khachhang.ThongkeKH_Dotuoi(TuNgay, DenNgay, TuoiTu, TuoiDen, uId_Cuahang)
    End Function

    Public Function ThongkeKH_Nguon(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal uId_Nguonden As String, ByVal uId_Cuahang As String) As System.Data.DataTable
        Return iclsBaoCao_Khachhang.ThongkeKH_Nguon(TuNgay, DenNgay, uId_Nguonden, uId_Cuahang)
    End Function

    Public Function BaocaothongkeByNguon(ByVal uId_Nguon As String, Tungay As Date, Denngay As Date)
        Return iclsBaoCao_Khachhang.Baocaothongkenguon(uId_Nguon, Tungay, Denngay)
    End Function
#End Region

    Function Baocao_DoanhThu_Tonghop(d_Tungay As Date, d_Denngay As Date) As DataTable
        Return iclsBaoCao_Khachhang.Baocao_DoanhThu_Tonghop(d_Tungay, d_Denngay)
    End Function

    Function Baocao_Dichvu_Tonghop(d_Tungay As Date, d_Denngay As Date) As DataTable
        Return iclsBaoCao_Khachhang.Baocao_Dichvu_Tonghop(d_Tungay, d_Denngay)
    End Function

End Class
