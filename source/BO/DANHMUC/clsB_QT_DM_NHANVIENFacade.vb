Public Class QT_DM_NHANVIENFacade

    Dim IQT_DM_NHANVIEN As DB.IQT_DM_NHANVIENDA = New DB.QT_DM_NHANVIENDA

    Public Function SelectAll() As List(Of CM.QT_DM_NHANVIENEntity)
        Return IQT_DM_NHANVIEN.SelectAll()
    End Function

    Public Function SelectAllTable(ByVal uId_Cuahang As String) As System.Data.DataTable
        Return IQT_DM_NHANVIEN.SelectAllTable(uId_Cuahang)
    End Function

    Public Function SelectAllAdminTable(ByVal uId_Cuahang As String) As System.Data.DataTable
        Return IQT_DM_NHANVIEN.SelectAllAdminTable(uId_Cuahang)
    End Function
    Public Function Get_DS_Nhanvien_To_Nguon() As System.Data.DataTable
        Return IQT_DM_NHANVIEN.Get_DS_Nhanvien_To_Nguon()
    End Function
    Public Function Insert(ByVal obj As CM.QT_DM_NHANVIENEntity, ByVal Loai As Boolean) As String
        Return IQT_DM_NHANVIEN.Insert(obj, Loai)
    End Function

    Public Function Update(ByVal obj As CM.QT_DM_NHANVIENEntity, ByVal Loai As Boolean) As Boolean
        Return IQT_DM_NHANVIEN.Update(obj, Loai)
    End Function

	Public Function DeleteByID(ByVal uId_Nhanvien AS String) AS Boolean
		Return IQT_DM_NHANVIEN.DeleteByID(uId_Nhanvien)
	End Function

    Public Function SelectByID(ByVal uId_Nhanvien As String) As CM.QT_DM_NHANVIENEntity
        Return IQT_DM_NHANVIEN.SelectByID(uId_Nhanvien)
    End Function
    Public Function SelectByTenDangNhap(ByVal v_Tendangnhap As String) As System.Data.DataTable
        Return IQT_DM_NHANVIEN.SelectByTenDangNhap(v_Tendangnhap)
    End Function
    Public Function DoanhThu(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Nhanvien As String) As System.Data.DataTable
        Return IQT_DM_NHANVIEN.DoanhThu(TuNgay, DenNgay, uId_Nhanvien)
    End Function
    Public Function DoanhThuBanDV_SP(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Nhanvien As String) As System.Data.DataTable
        Return IQT_DM_NHANVIEN.DoanhThuBanDV_SP(TuNgay, DenNgay, uId_Nhanvien)
    End Function
    Public Function SelectByUser(ByVal v_Tendangnhap As String) As CM.QT_DM_NHANVIENEntity
        Return IQT_DM_NHANVIEN.SelectByUser(v_Tendangnhap)
    End Function

    Public Function DoiMatKhau(ByVal id As String, ByVal pass As String) As Boolean
        Return IQT_DM_NHANVIEN.DoiMatKhau(id, pass)
    End Function
    Public Function TimKiem(ByVal key As String) As System.Data.DataTable
        Return IQT_DM_NHANVIEN.TimKiem(key)
    End Function
    Public Function DoanhThuThucHien(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Nhanvien As String) As System.Data.DataTable
        Return IQT_DM_NHANVIEN.DoanhThuThucHien(TuNgay, DenNgay, uId_Nhanvien)
    End Function
    Public Function DoanhThuBanHang(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Nhanvien As String) As System.Data.DataTable
        Return IQT_DM_NHANVIEN.DoanhThuBanHang(TuNgay, DenNgay, uId_Nhanvien)
    End Function
    Public Function HoaHong_PhieuDV(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Nhanvien As String) As System.Data.DataTable
        Return IQT_DM_NHANVIEN.HoaHong_PhieuDV(TuNgay, DenNgay, uId_Nhanvien)
    End Function
    Public Function HoaHong_BanSP(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String, ByVal uId_Kho As String) As System.Data.DataTable
        Return IQT_DM_NHANVIEN.HoaHong_BanSP(TuNgay, DenNgay, uId_Cuahang, uId_Kho)
    End Function
    'xuanhieu 251204 tong hop doanh thu nhan vien 
    Public Function BcDoanhthuTong(Tungay As DateTime, Denngay As DateTime, uId_nhanvien As String) As DataTable
        Return IQT_DM_NHANVIEN.BcDoanhthuTong(Tungay, Denngay, uId_nhanvien)
    End Function

    Public Function HHPhieudv(Tungay As DateTime, Denngay As DateTime, uId_Nhanvien As String) As DataTable
        Return IQT_DM_NHANVIEN.HHPhieudv(Tungay, Denngay, uId_nhanvien)
    End Function

    Public Function HHPhieuxuat(Tungay As DateTime, Denngay As DateTime, uId_Nhanvien As String) As DataTable
        Return IQT_DM_NHANVIEN.HHPhieuxuat(Tungay, Denngay, uId_Nhanvien)
    End Function

    Public Function HHPhieuthuchi(Tungay As DateTime, Denngay As DateTime, uId_Nhanvien As String) As DataTable
        Return IQT_DM_NHANVIEN.HHPhieuthuchi(Tungay, Denngay, uId_Nhanvien)
    End Function

    Public Function SelectByActive() As System.Data.DataTable
        Return IQT_DM_NHANVIEN.SelectByActive()
    End Function

    Public Function SelectnhanvienByLichhen(uId_Cuahang As String, dateStart As Date, dateEnd As Date, uId_Nhanvien As String) As DataTable
        Return IQT_DM_NHANVIEN.SelectnhanvienByLichhen(uId_Cuahang, dateStart, dateEnd, uId_Nhanvien)
    End Function

    Function Select_Nhanvien_By_Phong(uId_Phong As String) As DataTable
        Return IQT_DM_NHANVIEN.Select_Nhanvien_By_Phong(uId_Phong)
    End Function

    Function SelectAllTable_Calamviec(d_Ngay As DateTime) As DataTable
        Return IQT_DM_NHANVIEN.SelectAllTable_Calamviec(d_Ngay)
    End Function

    Function Select_Nhanvien_By_Time() As DataTable
        Return IQT_DM_NHANVIEN.Select_Nhanvien_By_Time()
    End Function

    Function Select_Nhanvien_Phong_Baocao(uId_Phong As String) As DataTable
        Return IQT_DM_NHANVIEN.Select_Nhanvien_Phong_Baocao(uId_Phong)
    End Function

    Function Baocao_Nhanvien_Kythuat(d_Tungay As Date, d_Denngay As Date, ByVal uId_Nhanvien As String) As DataTable
        Return IQT_DM_NHANVIEN.Baocao_Nhanvien_Kythuat(d_Tungay, d_Denngay, uId_Nhanvien)
    End Function

    Function Load_Nhanvien_Tuvan_AuTo(d_Ngay As DateTime) As DataTable
        Return IQT_DM_NHANVIEN.Load_Nhanvien_Tuvan_AuTo(d_Ngay)
    End Function

    Function Load_Nhanvien_Kythuat_AuTo(d_Ngay As DateTime) As DataTable
        Return IQT_DM_NHANVIEN.Load_Nhanvien_Kythuat_AuTo(d_Ngay)
    End Function

    Function SelectAllTable_Convert(uId_Cuahang As String) As DataTable
        Return IQT_DM_NHANVIEN.SelectAllTable_Convert(uId_Cuahang)
    End Function

End Class