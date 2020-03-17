Public Class QLMH_PHIEUXUATFacade

    Dim IQLMH_PHIEUXUAT As DB.IQLMH_PHIEUXUATDA = New DB.QLMH_PHIEUXUATDA


#Region "Phieu xuat - Header"
    Public Function SelectAll() As List(Of CM.QLMH_PHIEUXUATEntity)
        Return IQLMH_PHIEUXUAT.SelectAll()
    End Function

    Public Function SelectAllTable(ByVal uId_Cuahang As String) As System.Data.DataTable
        Return IQLMH_PHIEUXUAT.SelectAllTable(uId_Cuahang)
    End Function

    Public Function SelectAllTablePXNo(ByVal uId_Khachhang As String) As System.Data.DataTable
        Return IQLMH_PHIEUXUAT.SelectAllTablePXNo(uId_Khachhang)
    End Function
    Public Function Timkiem(ByVal uId_Kho As String, ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal Type As String) As System.Data.DataTable
        Return IQLMH_PHIEUXUAT.TimKiem(uId_Kho, TuNgay, DenNgay, Type)
    End Function


    Public Function Insert(ByVal obj As CM.QLMH_PHIEUXUATEntity) As String
        Return IQLMH_PHIEUXUAT.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.QLMH_PHIEUXUATEntity) As Boolean
        Return IQLMH_PHIEUXUAT.Update(obj)
    End Function

    Public Function ThanhToan(ByVal obj As CM.QLMH_PHIEUXUATEntity) As Boolean
        Return IQLMH_PHIEUXUAT.ThanhToan(obj)
    End Function

    Public Function DeleteByID(ByVal uId_Phieuxuat As String) As Boolean
        Return IQLMH_PHIEUXUAT.DeleteByID(uId_Phieuxuat)
    End Function

    Public Function SelectByID(ByVal uId_Phieuxuat As String) As CM.QLMH_PHIEUXUATEntity
        Return IQLMH_PHIEUXUAT.SelectByID(uId_Phieuxuat)
    End Function

    Public Function SelectByIDDataTable(ByVal uId_Phieuxuat As String) As System.Data.DataTable
        Return IQLMH_PHIEUXUAT.SelectByIDDataTable(uId_Phieuxuat)
    End Function

    Public Function SelectByKH(ByVal uId_Khachhang As String, ByVal TuNgay As DateTime, ByVal DenNgay As DateTime) As System.Data.DataTable
        Return IQLMH_PHIEUXUAT.SelectByKH(uId_Khachhang, TuNgay, DenNgay)
    End Function

    Public Function BaoCaoDoanhThuTongHopSP(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal uId_Cuahang As String) As System.Data.DataTable
        Return IQLMH_PHIEUXUAT.BaoCaoDoanhThuTongHopSP(TuNgay, DenNgay, uId_Cuahang)
    End Function

    Public Function BaoCaoDoanhThuChiTietSP(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal uId_Cuahang As String) As System.Data.DataTable
        Return IQLMH_PHIEUXUAT.BaoCaoDoanhThuChiTietSP(TuNgay, DenNgay, uId_Cuahang)
    End Function

    Function SelectBySoPhieuXuat(ByVal v_Maphieuxuat As String) As System.Data.DataTable
        Return IQLMH_PHIEUXUAT.SelectBySoPhieuXuat(v_Maphieuxuat)
    End Function

    Public Function SelectByIDChuaThanhtoan(ByVal uId_Phieuxuat As String) As CM.QLMH_PHIEUXUATEntity
        Return IQLMH_PHIEUXUAT.SelectByIDChuaThanhtoan(uId_Phieuxuat)
    End Function
#End Region

#Region "Phieu xuat - Detail"
    Public Function SelectAll_QLMH_PHIEUXUAT_CHITIET() As List(Of CM.QLMH_PHIEUXUATEntity)
        Return IQLMH_PHIEUXUAT.SelectAll_QLMH_PHIEUXUAT_CHITIET
    End Function

    Public Function SelectAllTable_QLMH_PHIEUXUAT_CHITIET() As System.Data.DataTable
        Return IQLMH_PHIEUXUAT.SelectAllTable_QLMH_PHIEUXUAT_CHITIET
    End Function

    Public Function Insert_QLMH_PHIEUXUAT_CHITIET(ByVal obj As CM.QLMH_PHIEUXUATEntity) As Boolean
        Return IQLMH_PHIEUXUAT.Insert_QLMH_PHIEUXUAT_CHITIET(obj)
    End Function

    Public Function Update_QLMH_PHIEUXUAT_CHITIET(ByVal obj As CM.QLMH_PHIEUXUATEntity) As Boolean
        Return IQLMH_PHIEUXUAT.Update_QLMH_PHIEUXUAT_CHITIET(obj)
    End Function

    Public Function DeleteByID_QLMH_PHIEUXUAT_CHITIET(ByVal uId_Phieuxuat_Chitiet As String) As Boolean
        Return IQLMH_PHIEUXUAT.DeleteByID_QLMH_PHIEUXUAT_CHITIET(uId_Phieuxuat_Chitiet)
    End Function

    Public Function SelectQLMH_PHIEUXUAT_CHITIET_ByID(ByVal uId_Phieuxuat_Chitiet As String) As CM.QLMH_PHIEUXUATEntity
        Return IQLMH_PHIEUXUAT.SelectQLMH_PHIEUXUAT_CHITIET_ByID(uId_Phieuxuat_Chitiet)
    End Function
    Public Function SelectByID_QLMH_PHIEUXUAT_CHITIET(ByVal uId_Phieuxuat As String) As System.Data.DataTable
        Return IQLMH_PHIEUXUAT.SelectByID_QLMH_PHIEUXUAT_CHITIET(uId_Phieuxuat)
    End Function

    Public Function SelectByID_QLMH_PHIEUXUAT_CHITIET_BC(ByVal uId_Phieuxuat As String) As System.Data.DataTable
        Return IQLMH_PHIEUXUAT.SelectByID_QLMH_PHIEUXUAT_CHITIET_BC(uId_Phieuxuat)
    End Function

    Public Function Select_PHIEUXUAT_CHITIET_ByMaPX(ByVal v_Maphieuxuat As String) As System.Data.DataTable
        Return IQLMH_PHIEUXUAT.Select_PHIEUXUAT_CHITIET_ByMaPX(v_Maphieuxuat)
    End Function

    ' huy thuoc
    Public Function updateHuyThuoc(ByVal uid_Phieuxuat_Chitiet As String, ByVal uid_Nhanvien As String) As Boolean
        Return IQLMH_PHIEUXUAT.updateHoanThuoc(uid_Phieuxuat_Chitiet, uid_Nhanvien)
    End Function
#End Region
    Public Function MaPhieuxuatMax(ByVal ngaynhap As Date) As String
        Return IQLMH_PHIEUXUAT.MaPhieuxuatMax(ngaynhap)
    End Function

    Public Function SelectTonghopXuat_Update(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal uId_Cuahang As String) As System.Data.DataTable
        Return IQLMH_PHIEUXUAT.SelectTonghopXuat_Update(TuNgay, DenNgay, uId_Cuahang)
    End Function
    'xuanhieu 241214 bao cao tong hop xuat
    Function BCtonghopxuat(uId_Kho As String, d_Tungay As Date, d_Denngay As Date) As DataTable
        Return IQLMH_PHIEUXUAT.BCtonghopxuat(uId_Kho, d_Tungay, d_Denngay)
    End Function

    Public Function SelectDonthuoc(uId_Phieuxuat As String) As DataTable
        Return IQLMH_PHIEUXUAT.SelectDonthuoc(uId_Phieuxuat)
    End Function


End Class