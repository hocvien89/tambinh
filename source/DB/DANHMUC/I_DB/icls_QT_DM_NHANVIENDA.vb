Public Interface IQT_DM_NHANVIENDA

    Function SelectAll() As List(Of CM.QT_DM_NHANVIENEntity)

    Function SelectAllTable(ByVal uId_Cuahang As String) As System.Data.DataTable
    Function SelectAllAdminTable(ByVal uId_Cuahang As String) As System.Data.DataTable

    Function SelectByTenDangNhap(ByVal v_Tendangnhap As String) As System.Data.DataTable

    Function Get_DS_Nhanvien_To_Nguon() As System.Data.DataTable

    Function SelectByID(ByVal uId_Nhanvien As String) As CM.QT_DM_NHANVIENEntity

    Function SelectByUser(ByVal v_Tendangnhap As String) As CM.QT_DM_NHANVIENEntity

    Function Insert(ByVal obj As CM.QT_DM_NHANVIENEntity, ByVal Loai As Boolean) As String

	Function DeleteByID(ByVal uId_Nhanvien AS String) AS Boolean

    Function Update(ByVal obj As CM.QT_DM_NHANVIENEntity, ByVal Loai As Boolean) As Boolean

    Function DoiMatKhau(ByVal id As String, ByVal pass As String) As Boolean

    Function DoanhThu(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Nhanvien As String) As System.Data.DataTable

    Function DoanhThuBanDV_SP(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Nhanvien As String) As System.Data.DataTable

    Function TimKiem(ByVal key As String) As System.Data.DataTable

    Function DoanhThuThucHien(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Nhanvien As String) As System.Data.DataTable

    Function DoanhThuBanHang(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Nhanvien As String) As System.Data.DataTable

    Function HoaHong_PhieuDV(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Nhanvien As String) As System.Data.DataTable

    Function HoaHong_BanSP(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uIdCuahang As String, ByVal uId_Kho As String) As System.Data.DataTable
    'xuanhieu 251204 tong hop doanh thu nhan vien
    Function BcDoanhthuTong(Tungay As DateTime, Denngay As DateTime, uId_Nhanvien As String) As DataTable

    Function HHPhieudv(Tungay As DateTime, Dennnay As DateTime, uId_Nhanvien As String) As DataTable

    Function HHPhieuxuat(Tungay As DateTime, Denngay As DateTime, uId_Nhanvien As String) As DataTable

    Function HHPhieuthuchi(Tungay As DateTime, Denngay As DateTime, uId_Nhanvien As String) As DataTable

    Function SelectByActive() As System.Data.DataTable

    'hieutx kiem tra trang thai dat lich hen cua nhan vien
    Function SelectnhanvienByLichhen(uId_Cuahang As String, dateStart As DateTime, dateEnd As DateTime, uId_Nhanvien As String) As DataTable

    Function Select_Nhanvien_By_Phong(uId_Phong As String) As DataTable

    Function SelectAllTable_Calamviec(d_Ngay As DateTime) As DataTable

    Function Select_Nhanvien_By_Time() As DataTable

    Function Select_Nhanvien_Phong_Baocao(uId_Phong As String) As DataTable

    Function Baocao_Nhanvien_Kythuat(d_Tungay As Date, d_Denngay As Date, uId_Nhanvien As String) As DataTable

    Function Load_Nhanvien_Kythuat_AuTo(d_Ngay As Date) As DataTable

    Function Load_Nhanvien_Tuvan_AuTo(d_Ngay As Date) As DataTable

    Function SelectAllTable_Convert(uId_Cuahang As String) As DataTable

End Interface