Public Class MKT_ChiendichDungthuSP
    Dim IMKT_ChiendichDungthuSP As DB.IMKT_ChiendichDungthuSP = New DB.MKT_ChiendichDungthuSP

    Public Function sp_CTKM_ChiendichMarketing_Insert(nv_Tenchiendich_vn As String, d_Ngaybatdau As Date, d_Ngayketthuc As Date, nv_Mota As String) As DataTable
        Return IMKT_ChiendichDungthuSP.sp_CTKM_ChiendichMarketing_Insert(nv_Tenchiendich_vn, d_Ngaybatdau, d_Ngayketthuc, nv_Mota)
    End Function

    Public Function CTKM_ChiendichMarketing_Dichvu_Insert(ByVal uId_ChiendichMarketing As String, ByVal uId_Dichvu As String) As Boolean
        Return IMKT_ChiendichDungthuSP.CTKM_ChiendichMarketing_Dichvu_Insert(uId_ChiendichMarketing, uId_Dichvu)
    End Function

    Public Function CTKM_ChiendichMarketing_Delete(ByVal uId_ChiendichMarketing As String) As Boolean
        Return IMKT_ChiendichDungthuSP.CTKM_ChiendichMarketing_Delete(uId_ChiendichMarketing)
    End Function
    Public Function spTNTP_DM_DICHVU_SelectAll_TimTheoTendichvu(ByVal nv_Tendichvu_vn As String) As System.Data.DataTable
        Return IMKT_ChiendichDungthuSP.spTNTP_DM_DICHVU_SelectAll_TimTheoTendichvu(nv_Tendichvu_vn)
    End Function
    Public Function sp_CTKM_ChiendichMarketing_update_Main(ByVal uId_ChiendichMarketing As String, ByVal nv_Tenchiendich_vn As String, ByVal d_Ngaybatdau As Date, ByVal d_Ngayketthuc As Date, ByVal nv_Mota As String) As Boolean
        Return IMKT_ChiendichDungthuSP.sp_CTKM_ChiendichMarketing_update_Main(uId_ChiendichMarketing, nv_Tenchiendich_vn, d_Ngaybatdau, d_Ngayketthuc, nv_Mota)
    End Function
    Public Function sp_CTKM_ChiendichMarketing_SelectByID(ByVal uId_ChiendichMarketing As String) As DataTable
        Return IMKT_ChiendichDungthuSP.sp_CTKM_ChiendichMarketing_SelectByID(uId_ChiendichMarketing)
    End Function

    Public Function sp_CTKM_ChiendichMarketing_SelectByTrangthai(ByVal nv_Trangthai As String) As System.Data.DataTable
        Return IMKT_ChiendichDungthuSP.sp_CTKM_ChiendichMarketing_SelectByTrangthai(nv_Trangthai)
    End Function

    Public Function sp_CTKM_ChiendichMarketing_Dichvu_ByID(ByVal uId_ChiendichMarketing As String) As System.Data.DataTable
        Return IMKT_ChiendichDungthuSP.sp_CTKM_ChiendichMarketing_Dichvu_ByID(uId_ChiendichMarketing)
    End Function

    Public Function sp_CTKM_ChiendichMarketing_Chitiet_Insert(ByVal uId_ChiendichMarketing As String, ByVal uId_Khachhang As String, ByVal d_Ngaytang As Date, ByVal d_Ngayketthuc As Date) As System.Data.DataTable
        Return IMKT_ChiendichDungthuSP.sp_CTKM_ChiendichMarketing_Chitiet_Insert(uId_ChiendichMarketing, uId_Khachhang, d_Ngaytang, d_Ngayketthuc)
    End Function

    Public Function sp_CTKM_ChiendichMarketing_Chitiet_Dichvu_Insert(ByVal uId_ChiendichMarketing_Chitiet As String, ByVal uId_Dichvu As String) As Boolean
        Return IMKT_ChiendichDungthuSP.sp_CTKM_ChiendichMarketing_Chitiet_Dichvu_Insert(uId_ChiendichMarketing_Chitiet, uId_Dichvu)
    End Function

    Public Function sp_Check_KH_CTKM_DungthuSP(ByVal uId_ChiendichMarketing As String, ByVal uId_Khachhang As String) As System.Data.DataTable
        Return IMKT_ChiendichDungthuSP.sp_Check_KH_CTKM_DungthuSP(uId_ChiendichMarketing, uId_Khachhang)
    End Function

    Public Function sp_CTKM_ChiendichMarketing_Chitiet_Phanhoi_Update(ByVal uId_ChiendichMarketing As String, ByVal uId_Khachhang As String, ByVal nv_Phanhoi As String, ByVal d_Ngaydungthu As Date) As Boolean
        Return IMKT_ChiendichDungthuSP.sp_CTKM_ChiendichMarketing_Chitiet_Phanhoi_Update(uId_ChiendichMarketing, uId_Khachhang, nv_Phanhoi, d_Ngaydungthu)
    End Function

    Public Function sp_CTKM_CiendichMarketing_Chitiet_Select_ALL(ByVal uId_ChiendichMarketing As String, ByVal s_Trangthai As String) As DataTable
        Return IMKT_ChiendichDungthuSP.sp_CTKM_CiendichMarketing_Chitiet_Select_ALL(uId_ChiendichMarketing, s_Trangthai)
    End Function

    Public Function sp_CTKM_ChiendichMarketing_KH_SelectById(ByVal uId_ChiendichMarketing) As DataTable
        Return IMKT_ChiendichDungthuSP.sp_CTKM_ChiendichMarketing_KH_SelectById(uId_ChiendichMarketing)
    End Function

    Public Function sp_CTKM_ChiendichMarketing_Chitiet_Dichvu_ByID(ByVal uId_ChiendichMarketing As String, ByVal uId_Khachhang As String) As DataTable
        Return IMKT_ChiendichDungthuSP.sp_CTKM_ChiendichMarketing_Chitiet_Dichvu_ByID(uId_ChiendichMarketing, uId_Khachhang)
    End Function

    Public Function sp_CTKM_ChiendichMarketing_Dichvu_ALL_ByID(ByVal uId_ChiendichMarketing As String) As DataTable
        Return IMKT_ChiendichDungthuSP.sp_CTKM_ChiendichMarketing_Dichvu_ALL_ByID(uId_ChiendichMarketing)
    End Function

    Public Function sp_CTKM_ChiendichMarketing_Dichvu_SelectByID(ByVal uId_ChiendichMarketing As String) As DataTable
        Return IMKT_ChiendichDungthuSP.sp_CTKM_ChiendichMarketing_Dichvu_SelectByID(uId_ChiendichMarketing)
    End Function
    Public Function sp_CTKM_ChiendichMarketing_Update(ByVal uId_ChiendichMarjeting As String) As Boolean
        Return IMKT_ChiendichDungthuSP.sp_CTKM_ChiendichMarketing_Update(uId_ChiendichMarjeting)
    End Function
    'Phuongdv
    Public Function DeleteByID(ByVal uId_ChiendichMarketing As String) As Boolean
        Return IMKT_ChiendichDungthuSP.DeleteByID(uId_ChiendichMarketing)
    End Function

    Public Function Update(ByVal obj As CM.IMKT_Chiendichmarketing_Chitiet_Entity) As Boolean
        Return IMKT_ChiendichDungthuSP.Update(obj)
    End Function

    Public Function TrangThaiKH(ByVal LoaiKH As String) As System.Data.DataTable
        Return IMKT_ChiendichDungthuSP.TrangThaiKH(LoaiKH)
    End Function
End Class
