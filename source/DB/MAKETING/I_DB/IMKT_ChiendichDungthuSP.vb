Public Interface IMKT_ChiendichDungthuSP
    Function sp_CTKM_ChiendichMarketing_Insert(ByVal nv_Tenchiendich_vn As String, ByVal d_Ngaybatdau As Date, ByVal d_Ngayketthuc As Date, ByVal nv_Mota As String) As System.Data.DataTable

    Function CTKM_ChiendichMarketing_Dichvu_Insert(ByVal uId_ChiendichMarketing As String, ByVal uId_Dichvu As String) As Boolean

    Function spTNTP_DM_DICHVU_SelectAll_TimTheoTendichvu(ByVal nv_Tendichvu_vn As String) As System.Data.DataTable

    Function sp_CTKM_ChiendichMarketing_SelectByTrangthai(ByVal nv_Trangthai As String) As System.Data.DataTable

    Function sp_CTKM_ChiendichMarketing_Dichvu_ByID(ByVal uId_ChiendichMarketing As String) As System.Data.DataTable

    Function sp_CTKM_ChiendichMarketing_Chitiet_Insert(ByVal uId_ChiendichMarketing As String, ByVal uId_Khachhang As String, ByVal d_Ngaytang As Date, d_Ngayketthuc As Date) As System.Data.DataTable

    Function sp_CTKM_ChiendichMarketing_Chitiet_Dichvu_Insert(ByVal uId_ChiendichMarketing_Chitiet As String, ByVal uId_Dichvu As String) As Boolean

    Function sp_Check_KH_CTKM_DungthuSP(ByVal uId_ChiendichMarketing As String, ByVal uId_Khachhang As String) As System.Data.DataTable

    Function sp_CTKM_ChiendichMarketing_KH_SelectById(ByVal uId_ChiendichMarketing) As DataTable

    Function sp_CTKM_ChiendichMarketing_Chitiet_Phanhoi_Update(ByVal uId_ChiendichMarketing As String, ByVal uId_Khachhang As String, ByVal nv_Phanhoi As String, ByVal d_Ngaydungthu As Date) As Boolean

    Function sp_CTKM_ChiendichMarketing_Chitiet_Dichvu_ByID(ByVal uId_ChiendichMarketing As String, ByVal uId_Khachhang As String) As DataTable

    Function sp_CTKM_CiendichMarketing_Chitiet_Select_ALL(ByVal uId_ChiendichMarketing As String, ByVal s_Trangthai As String) As DataTable

    Function sp_CTKM_ChiendichMarketing_SelectByID(ByVal uId_ChiendichMarketing As String) As DataTable

    Function sp_CTKM_ChiendichMarketing_Dichvu_ALL_ByID(ByVal uId_ChiendichMarketing As String) As DataTable

    Function sp_CTKM_ChiendichMarketing_Dichvu_SelectByID(ByVal uId_ChiendichMarketing As String) As DataTable

    Function sp_CTKM_ChiendichMarketing_Update(ByVal uId_ChiendichMarjeting As String) As Boolean

    Function CTKM_ChiendichMarketing_Delete(ByVal uId_ChiendichMarketing As String) As Boolean

    Function sp_CTKM_ChiendichMarketing_update_Main(ByVal uId_ChiendichMarketing As String, ByVal nv_Tenchiendich_vn As String, ByVal d_Ngaybatdau As Date, ByVal d_Ngayketthuc As Date, ByVal nv_Mota As String) As Boolean

    'Phuongdv_Delete CTKM_ChiendichMarketing_DeleteByID
    Function DeleteByID(ByVal uId_ChiendichMarketing_Chitiet As String) As Boolean

    Function Update(ByVal obj As CM.IMKT_Chiendichmarketing_Chitiet_Entity) As Boolean

    Function TrangThaiKH(ByVal LoaiKH As String) As System.Data.DataTable

End Interface
