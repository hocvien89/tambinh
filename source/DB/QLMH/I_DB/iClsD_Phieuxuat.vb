Public Interface IQLMH_PHIEUXUATDA

#Region "Phieu Xuat - header"

    Function SelectAll() As List(Of CM.QLMH_PHIEUXUATEntity)

    Function SelectAllTablePXNo(ByVal uId_Khachhang As String) As System.Data.DataTable

    Function SelectAllTable(ByVal uId_Cuahang As String) As System.Data.DataTable

    Function TimKiem(ByVal uId_Kho As String, ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal Type As String) As System.Data.DataTable

    Function SelectByID(ByVal uId_Phieuxuat As String) As CM.QLMH_PHIEUXUATEntity

    Function SelectByIDDataTable(ByVal uId_Phieuxuat As String) As System.Data.DataTable

    Function Insert(ByVal obj As CM.QLMH_PHIEUXUATEntity) As String

    Function DeleteByID(ByVal uId_Phieuxuat As String) As Boolean

    Function Update(ByVal obj As CM.QLMH_PHIEUXUATEntity) As Boolean

    Function SelectByKH(ByVal uId_Khachhang As String, ByVal TuNgay As DateTime, ByVal DenNgay As DateTime) As System.Data.DataTable

    Function ThanhToan(ByVal obj As CM.QLMH_PHIEUXUATEntity) As Boolean

    Function BaoCaoDoanhThuTongHopSP(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As System.Data.DataTable

    Function BaoCaoDoanhThuChiTietSP(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As System.Data.DataTable

    Function SelectBySoPhieuXuat(ByVal v_Maphieuxuat As String) As System.Data.DataTable

    Function SelectTonghopXuat_Update(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As System.Data.DataTable

    Function SelectByIDChuaThanhtoan(ByVal uId_Phieuxuat As String) As CM.QLMH_PHIEUXUATEntity
#End Region
#Region "Phieu Xuat - detail"

    Function SelectAll_QLMH_PHIEUXUAT_CHITIET() As List(Of CM.QLMH_PHIEUXUATEntity)

    Function SelectAllTable_QLMH_PHIEUXUAT_CHITIET() As System.Data.DataTable

    Function SelectQLMH_PHIEUXUAT_CHITIET_ByID(ByVal uId_Phieuxuat_Chitiet As String) As CM.QLMH_PHIEUXUATEntity

    Function SelectByID_QLMH_PHIEUXUAT_CHITIET(ByVal uId_Phieuxuat_Chitiet As String) As System.Data.DataTable

    Function SelectByID_QLMH_PHIEUXUAT_CHITIET_BC(ByVal uId_Phieuxuat As String) As System.Data.DataTable

    Function Select_PHIEUXUAT_CHITIET_ByMaPX(ByVal v_Maphieuxuat As String) As System.Data.DataTable

    Function Insert_QLMH_PHIEUXUAT_CHITIET(ByVal obj As CM.QLMH_PHIEUXUATEntity) As Boolean

    Function DeleteByID_QLMH_PHIEUXUAT_CHITIET(ByVal uId_Phieuxuat_Chitiet As String) As Boolean

    Function Update_QLMH_PHIEUXUAT_CHITIET(ByVal obj As CM.QLMH_PHIEUXUATEntity) As Boolean

    Function updateHoanThuoc(ByVal uid_Phieuxuat_Chitiet As String, ByVal uid_Nhanvien As String) As Boolean
#End Region

    Function MaPhieuxuatMax(ByVal ngaynhap As Date) As String
    'xuanhieu 241214 bao cao tong hop xuat
    Function BCtonghopxuat(uId_Kho As String, d_Tungay As DateTime, d_Denngay As DateTime) As DataTable

    Function SelectDonthuoc(uId_Phieuxuat As String) As DataTable

End Interface