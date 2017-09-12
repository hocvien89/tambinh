Public Class CRM_DM_KhachhangFacade

    Dim ICRM_DM_Khachhang As DB.ICRM_DM_KhachhangDA = New DB.CRM_DM_KhachhangDA

    Public Function SelectAll() As List(Of CM.CRM_DM_KhachhangEntity)
        Return ICRM_DM_Khachhang.SelectAll()
    End Function

    Public Function SelectAllTable(ByVal uId_Cuahang As String) As System.Data.DataTable
        Return ICRM_DM_Khachhang.SelectAllTable(uId_Cuahang)
    End Function
    
    Public Function TimKiemKH(ByVal obj As CM.CRM_DM_KhachhangEntity) As System.Data.DataTable
        Return ICRM_DM_Khachhang.TimKiemKH(obj)
    End Function
    Public Function TimKiemKHChuan(ByVal obj As CM.CRM_DM_KhachhangEntity) As System.Data.DataTable
        Return ICRM_DM_Khachhang.TimKiemKHChuan(obj)
    End Function

    Public Function TimKiemByMaVach(ByVal v_MaVach As String) As System.Data.DataTable
        Return ICRM_DM_Khachhang.TimKiemByMaVach(v_MaVach)
    End Function

    Public Function MaKH(ByVal uId_Cuahang As String) As String
        Return ICRM_DM_Khachhang.MaKH(uId_Cuahang)
    End Function

    Public Function TimKiemByMaKH(ByVal v_Makhachang As String) As System.Data.DataTable
        Return ICRM_DM_Khachhang.TimKiemByMaKH(v_Makhachang)
    End Function

    Public Function Insert(ByVal obj As CM.CRM_DM_KhachhangEntity) As String
        Return ICRM_DM_Khachhang.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.CRM_DM_KhachhangEntity) As Boolean
        Return ICRM_DM_Khachhang.Update(obj)
    End Function

	Public Function DeleteByID(ByVal uId_Khachhang AS String) AS Boolean
		Return ICRM_DM_Khachhang.DeleteByID(uId_Khachhang)
	End Function

    Public Function SelectByID(ByVal uId_Khachhang As String) As CM.CRM_DM_KhachhangEntity
        Return ICRM_DM_Khachhang.SelectByID(uId_Khachhang)
    End Function

    Public Function SelectByIDTable(ByVal uId_Khachhang As String) As System.Data.DataTable
        Return ICRM_DM_Khachhang.SelectByIDTable(uId_Khachhang)
    End Function

    Public Function SelectKhachhangNo(ByVal uId_Cuahang As String) As System.Data.DataTable
        Return ICRM_DM_Khachhang.SelectKhachhangNo(uId_Cuahang)
    End Function

    Public Function TimKiemKH_No(ByVal obj As CM.CRM_DM_KhachhangEntity) As System.Data.DataTable
        Return ICRM_DM_Khachhang.TimKiemKH_No(obj)
    End Function
    Public Function SelectAll_DS_Sinhnhat_By_NgayTuanThang(ByVal uId_Cuahang As String, ByVal iType As Short) As System.Data.DataTable
        Return ICRM_DM_Khachhang.SelectAll_DS_Sinhnhat_By_NgayTuanThang(uId_Cuahang, iType)
    End Function
    Public Function SelectAll_DS_Sinhnhat_By_NgayTuanThang_Nguoithan(ByVal uId_Cuahang As String, ByVal iType As Short) As System.Data.DataTable
        Return ICRM_DM_Khachhang.SelectAll_DS_Sinhnhat_By_NgayTuanThang_Nguoithan(uId_Cuahang, iType)
    End Function

    Public Function Baocao_Doanhthu_Diadanh(ByVal sTungay As String, ByVal sDenngay As String, ByVal uId_Cuahang As String, ByVal uId_Tinhthanh As String, ByVal uId_Quanhuyen As String) As System.Data.DataTable
        Return ICRM_DM_Khachhang.Baocao_Doanhthu_Diadanh(sTungay, sDenngay, uId_Cuahang, uId_Tinhthanh, uId_Quanhuyen)
    End Function
    Public Function CheckMaVach(ByVal v_BarCode As String) As CM.CRM_DM_KhachhangEntity
        Return ICRM_DM_Khachhang.CheckMaVach(v_BarCode)
    End Function

    Public Function BaocaoTheTV(ByVal nv_Hoten_vn As String, ByVal uId_Cuahang As String, ByVal uId_Loaithe As String, ByVal f_Tichluytu As Double, ByVal f_Tichluyden As Double, ByVal d_Tungay As String, ByVal d_Denngay As String) As System.Data.DataTable
        Return ICRM_DM_Khachhang.BaocaoTheTV(nv_Hoten_vn, uId_Cuahang, uId_Loaithe, f_Tichluytu, f_Tichluyden, d_Tungay, d_Denngay)
    End Function
    Public Function InTheTVKH(ByVal uId_Khachhang As String) As System.Data.DataTable
        Return ICRM_DM_Khachhang.InTheTVKH(uId_Khachhang)
    End Function

    Public Function InTheTTKH(ByVal uId_Khachhang_Goidichvu As String) As System.Data.DataTable
        Return ICRM_DM_Khachhang.InTheTTKH(uId_Khachhang_Goidichvu)
    End Function

    Public Function SearchByKey(ByVal key As String) As System.Data.DataTable
        Return ICRM_DM_Khachhang.SearchByKey(key)
    End Function
    Public Function SelectByTenVaSDT(ByVal TenKH As String, ByVal SDT As String) As CM.CRM_DM_KhachhangEntity
        Return ICRM_DM_Khachhang.SelectByTenAndSDT(TenKH, SDT)
    End Function
    Public Function NhacNhoKHLamLieuTrinh(ByVal i_SoNgay As Integer) As System.Data.DataTable
        Return ICRM_DM_Khachhang.NhacNhoKHLamLieuTrinh(i_SoNgay)
    End Function
    Public Function BaoCao_KH_LieuTrinh(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As System.Data.DataTable
        Return ICRM_DM_Khachhang.BaoCao_KH_LieuTrinh(TuNgay, DenNgay, uId_Cuahang)
    End Function

    Public Function SelectByBirthday(ngay As Integer, thang As Integer, nam As Integer, uid_cuahang As String, itype As Integer) As DataTable
        Return ICRM_DM_Khachhang.SelectByBirthday(ngay, thang, nam, uid_cuahang, itype)
    End Function
    'xuanhieu 08/12/04
    Function InsertTabl(TableTemp As DataTable) As Boolean
        Return ICRM_DM_Khachhang.InsertTabl(TableTemp)
    End Function
    'Phuongdv_Baocaotrilieu 13/05/2015
    Public Function SelectAllTable_Trilieu(TuNgay As DateTime, DenNgay As DateTime) As System.Data.DataTable
        Return ICRM_DM_Khachhang.SelectAllTable_Trilieu(TuNgay, DenNgay)
    End Function
    Public Function SelectByID_Trilieu(TuNgay As DateTime, DenNgay As DateTime, uId_Khachhang As String, uId_Dichvu As String, Chon As Integer) As System.Data.DataTable
        Return ICRM_DM_Khachhang.SelectByID_Trilieu(TuNgay, DenNgay, uId_Khachhang, uId_Dichvu, Chon)
    End Function
    Public Function SelectAllTable_DMKhachhang() As System.Data.DataTable
        Return ICRM_DM_Khachhang.SelectAllTable_DMKhachhang()
    End Function
    Public Function SelectCognoBytime(tungay As Date, denngay As Date, uId_Cuahang As String) As DataTable
        Return ICRM_DM_Khachhang.SelectCognoBytime(tungay, denngay, uId_Cuahang)
    End Function
    Public Function SelectByIDKhachhangTable(uId_Khachhang As String) As DataTable
        Return ICRM_DM_Khachhang.SelectByIDTable(uId_Khachhang)
    End Function

    Public Function Thongketheonam() As List(Of CM.CRM_DM_KhachhangEntity)
        Return ICRM_DM_Khachhang.Thongketheonam()
    End Function
    Public Function SelectNggioithieu(uId_Cuahang As String, ByVal options As Integer) As DataTable
        Return ICRM_DM_Khachhang.SelectNggioithieu(uId_Cuahang, options)
    End Function

    Function SelectByIDTable_PDV(uId_Phieudichvu As String) As DataTable
        Return ICRM_DM_Khachhang.SelectByIDTable_PDV(uId_Phieudichvu)
    End Function

End Class