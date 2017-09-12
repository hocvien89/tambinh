Public Interface IMKT_VOUCHER
    Function GioihanVoucher() As System.Data.DataTable

    Function sp_CTKM_DM_LoaiVOUCHER_Delete(ByVal uId_Loaivoucher As String) As Boolean

    Function sp_CTKM_DM_LoaiVOUCHER_Update(ByVal uId_Loaivoucher As String, ByVal nv_Tenloaivoucher As String, ByVal nv_mota As String, ByVal d_Ngaybatdau As Date, ByVal d_Ngayketthuc As Date, ByVal f_Menhgia As Double, ByVal i_sl As Integer, ByVal uId_GioihanVOUCHER As String) As Boolean

    Function sp_CTKM_DM_LoaiVOUCHER_Insert(ByVal nv_Tenloaivoucher As String, nv_Mota As String, d_Ngaybatdau As Date, d_Ngayketthuc As Date, b_Hoatdong As Boolean, f_Menhgia As Double, i_sl As Integer, uId_GioihanVOUCHER As String) As Boolean
    Function sp_CTKM_DM_LoaiVOUCHER_SelectAll(ByVal s_Trangthai As String) As System.Data.DataTable

    Function sp_CTKM_VOUCHER_Insert(ByVal uId_LoaiVoucher As String, ByVal v_Mavoucher As String, ByVal uId_Khachhang As String, ByVal d_Ngayphat As Date, d_Ngayketthuc As Date) As Boolean
    Function sp_CTKM_VOUCHER_Update(v_Mavoucher As String, ByVal ngaythu As Date) As Boolean

    Function sp_CTKM_VOUCHER_SelectByMaVoucher(ByVal v_Mavoucher As String, ByVal b_Trangthai As String) As System.Data.DataTable

    Function sp_CTKM_VOUCHER_SelectAll() As System.Data.DataTable

    Function sp_CTKM_VOUCHER_SELECTALLTABLE() As System.Data.DataTable

    Function sp_CTKM_VOUCHER_SELECTALLTABLEbyTrangthai(ByVal b_Trangthai As String) As System.Data.DataTable

    Function sp_CTKM_VOUCHER_SELECTALLTABLEbyTrangthaibyLoaiVoucher(ByVal b_Trangthai As String, ByVal uId_Loaivoucher As String) As System.Data.DataTable

    Function sp_CTKM_DM_LoaiVoucher_SelectByID(ByVal uId_Loaivoucher As String) As System.Data.DataTable

    Function DeleteByID(ByVal uId_voucher As String) As Boolean

    Function Update_Obj(ByVal obj As CM.MKT_VOUCHEREntity) As Boolean
End Interface
