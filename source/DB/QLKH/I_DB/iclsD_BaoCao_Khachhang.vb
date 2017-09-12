Public Interface iclsD_BaoCao_Khachhang

    Function SelectGoiDV_KhachhangNo() As System.Data.DataTable

    Function SelectTheDV_KhachhangNo() As System.Data.DataTable

    Function SelectAll_DS_KH_BoDT(ByVal i_Sothang As Int32, ByVal uId_Cuahang As String) As System.Data.DataTable

    Function SelectThongkeKH_Nguon(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Nguonden As String, ByVal uId_Cuahang As String) As System.Data.DataTable

    Function SelectThongkeKH_Gioitinh(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal b_Gioitinh As Byte, ByVal uId_Cuahang As String) As System.Data.DataTable

    Function SelectThongkeKH_Dotuoi(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal TuoiTu As Int32, ByVal TuoiDen As Int32, ByVal uId_Cuahang As String) As System.Data.DataTable

    Function SelectThongkeKH_Tatca(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As System.Data.DataTable

    Function SelectThongkeKH_ByTime(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As System.Data.DataTable
    'xuanhieu 180415 charmnguyenspa bao cao tai chinh
    Function Baocao_taichinh_Dichvu(tungay As Date, denngay As Date, uId_Cuahang As String) As DataTable
    'long them
    Function SelectThongkeKH_Dichvu_ByTime(ByVal Thang As DateTime, ByVal Tungay As DateTime) As System.Data.DataTable
    'long them
    Function spCRM_DM_TINHTHANH_SelectAll() As System.Data.DataTable
    'long them
    Function spCRM_DM_QUANHUYEN_SelectAllByID(ByVal uId_Tinhthanh As String) As System.Data.DataTable
    'Long them
    Function spBAOCAO_LuongKH(i_DenTuoi As Integer, i_TuTuoi As Integer, b_Gioitinh As String, uId_Quanhuyen As String) As System.Data.DataTable
    'Phuongdv báo cáo thông kê khách hàng đã mua và chưa mua sản phẩm hay dịch vụ
    Function SelectThongkeKH_Damua_Sanpham() As System.Data.DataTable
    Function SelectThongkeKH_chuamua_Sanpham() As System.Data.DataTable
    Function SelectThongkeKHByDichvu(ByVal uId_Dichvu As String) As System.Data.DataTable
    Function SelectThongkeKHAll() As System.Data.DataTable
    'Phuongdv bao cao me va be
    Function BaocaoHopDong_MevaBe(ByVal uId_Khachhang As String, ByVal uId_Phieudichvu_Chitiet As String) As System.Data.DataTable

    'Phuongdv
    Function ConnoKH_ByID(ByVal Tungay As DateTime, ByVal Denngay As DateTime, ByVal uId_Cuahang As String, ByVal uId_Khachhang As String) As System.Data.DataTable

    Function Baocaothongkenguon(ByVal uId_Nguon As String, Tungay As Date, Denngay As Date) As DataTable
#Region "Thống kê"
    Function ThongkeKH_Tatca(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As System.Data.DataTable
    Function ThongkeKH_Nguon(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Nguonden As String, ByVal uId_Cuahang As String) As System.Data.DataTable
    Function ThongkeKH_Gioitinh(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal b_Gioitinh As Byte, ByVal uId_Cuahang As String) As System.Data.DataTable
    Function ThongkeKH_Dotuoi(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal TuoiTu As Int32, ByVal TuoiDen As Int32, ByVal uId_Cuahang As String) As System.Data.DataTable
#End Region

    Function Baocao_DoanhThu_Tonghop(d_Tungay As Date, d_Denngay As Date) As DataTable

    Function Baocao_Dichvu_Tonghop(d_Tungay As Date, d_Denngay As Date) As DataTable

End Interface
