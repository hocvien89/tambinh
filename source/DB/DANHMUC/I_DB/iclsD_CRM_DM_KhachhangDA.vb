Public Interface ICRM_DM_KhachhangDA

    Function SelectAll() As List(Of CM.CRM_DM_KhachhangEntity)

    Function SelectAllTable(ByVal uId_Cuahang As String) As System.Data.DataTable
  
    Function TimKiemKH(ByVal obj As CM.CRM_DM_KhachhangEntity) As System.Data.DataTable
    Function TimKiemKHChuan(ByVal obj As CM.CRM_DM_KhachhangEntity) As System.Data.DataTable
    Function MaKH(ByVal uId_Cuahang As String) As String

    Function TimKiemByMaKH(ByVal v_Makhachang As String) As System.Data.DataTable


    Function TimKiemByMaVach(ByVal v_MaVach As String) As System.Data.DataTable

    Function TimKiemKH_No(ByVal obj As CM.CRM_DM_KhachhangEntity) As System.Data.DataTable

    Function SelectByID(ByVal uId_Khachhang As String) As CM.CRM_DM_KhachhangEntity

    Function SelectByIDTable(ByVal uId_Khachhang As String) As System.Data.DataTable

    Function Insert(ByVal obj As CM.CRM_DM_KhachhangEntity) As String

	Function DeleteByID(ByVal uId_Khachhang AS String) AS Boolean

    Function Update(ByVal obj As CM.CRM_DM_KhachhangEntity) As Boolean

    Function SelectKhachhangNo(ByVal uId_Cuahang As String) As System.Data.DataTable

    Function SelectAll_DS_Sinhnhat_By_NgayTuanThang(ByVal uId_Cuahang As String, ByVal iType As Int16) As System.Data.DataTable

    Function SelectAll_DS_Sinhnhat_By_NgayTuanThang_Nguoithan(ByVal uId_Cuahang As String, ByVal iType As Int16) As System.Data.DataTable


    Function Baocao_Doanhthu_Diadanh(ByVal sTungay As String, ByVal sDenngay As String, ByVal uId_Cuahang As String, ByVal uId_Tinhthanh As String, ByVal uId_Quanhuyen As String) As System.Data.DataTable

    Function CheckMaVach(ByVal MaVach As String) As CM.CRM_DM_KhachhangEntity

    Function BaocaoTheTV(ByVal nv_Hoten_vn As String, ByVal uId_Cuahang As String, ByVal uId_Loaithe As String, ByVal f_Tichluytu As Double, ByVal f_Tichluyden As Double, ByVal d_Tungay As String, ByVal d_Denngay As String) As System.Data.DataTable

    Function InTheTVKH(ByVal uId_Khachhang As String) As System.Data.DataTable

    Function InTheTTKH(ByVal uId_Khachhang_Goidichvu As String) As System.Data.DataTable

    Function SelectByTenAndSDT(ByVal TenKH As String, ByVal SDT As String) As CM.CRM_DM_KhachhangEntity

    Function SearchByKey(ByVal key As String) As System.Data.DataTable

    Function NhacNhoKHLamLieuTrinh(ByVal i_SoNgay As Integer) As System.Data.DataTable

    Function BaoCao_KH_LieuTrinh(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As System.Data.DataTable

    Function SelectByBirthday(ngay As Integer, thang As Integer, nam As Integer, uid_cuahang As String, itype As Integer) As DataTable
    'xuanhieu 08/12/04
    Function InsertTabl(TableTemp As DataTable) As Boolean
    'Phuongdv_Baocaotrilieu 13/05/2015
    Function SelectAllTable_Trilieu(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime) As System.Data.DataTable
    Function SelectByID_Trilieu(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Khachhang As String, ByVal uId_Dichvu As String, Chon As Integer) As System.Data.DataTable
    Function SelectAllTable_DMKhachhang() As DataTable
    'hieutx 240615 select congno theo thoi gian
    Function SelectCognoBytime(tungay As Date, denngay As Date, uId_Cuahang As String) As DataTable
    'Phuongdv
    Function SelectKhachhangByIDTable(ByVal uId_Khachhang As String) As System.Data.DataTable

    Function Thongketheonam() As List(Of CM.CRM_DM_KhachhangEntity)

    Function SelectNggioithieu(ByVal uId_Cuahang As String, ontions As Integer) As DataTable

    Function SelectByIDTable_PDV(uId_Phieudichvu As String) As DataTable

End Interface