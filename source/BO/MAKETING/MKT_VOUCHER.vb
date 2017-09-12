Public Class MKT_VOUCHER
    Dim IMKT_VOUCHER As DB.IMKT_VOUCHER = New DB.MKT_VOUCHER

    Public Function sp_CTKM_DM_LoaiVOUCHER_Delete(ByVal uId_Loaivoucher As String) As Boolean
        Return IMKT_VOUCHER.sp_CTKM_DM_LoaiVOUCHER_Delete(uId_Loaivoucher)
    End Function
    Public Function sp_CTKM_DM_LoaiVOUCHER_Update(ByVal uId_Loaivoucher As String, ByVal nv_Tenloaivoucher As String, ByVal nv_mota As String, ByVal d_Ngaybatdau As Date, ByVal d_Ngayketthuc As Date, ByVal f_Menhgia As Double, ByVal i_sl As Integer, ByVal uId_GioihanVOUCHER As String) As Boolean
        Return IMKT_VOUCHER.sp_CTKM_DM_LoaiVOUCHER_Update(uId_Loaivoucher, nv_Tenloaivoucher, nv_mota, d_Ngaybatdau, d_Ngayketthuc, f_Menhgia, i_sl, uId_GioihanVOUCHER)
    End Function
    Public Function SelectAllTable() As System.Data.DataTable
        Return IMKT_VOUCHER.GioihanVoucher()
    End Function

    Public Function sp_CTKM_DM_LoaiVOUCHER_Insert(ByVal nv_Tenloaivoucher As String, nv_Mota As String, d_Ngaybatdau As Date, d_Ngayketthuc As Date, b_Hoatdong As Boolean, f_Menhgia As Double, i_sl As Integer, uId_GioihanVOUCHER As String) As Boolean
        Return IMKT_VOUCHER.sp_CTKM_DM_LoaiVOUCHER_Insert(nv_Tenloaivoucher, nv_Mota, d_Ngaybatdau, d_Ngayketthuc, b_Hoatdong, f_Menhgia, i_sl, uId_GioihanVOUCHER)
    End Function

    Public Function sp_CTKM_DM_LoaiVOUCHER_SelectAll(ByVal s_Trangthai As String) As System.Data.DataTable
        Return IMKT_VOUCHER.sp_CTKM_DM_LoaiVOUCHER_SelectAll(s_Trangthai)
    End Function

    Public Function sp_CTKM_VOUCHER_Insert(ByVal uId_LoaiVoucher As String, ByVal v_Mavoucher As String, ByVal uId_Khachhang As String, ByVal d_Ngayphat As Date, ByVal d_Ngayketthuc As Date) As Boolean
        Return IMKT_VOUCHER.sp_CTKM_VOUCHER_Insert(uId_LoaiVoucher, v_Mavoucher, uId_Khachhang, d_Ngayphat, d_Ngayketthuc)
    End Function

    Public Function sp_CTKM_VOUCHER_Update(ByVal v_Mavoucher As String, ByVal d_ngaythu As Date) As Boolean
        Return IMKT_VOUCHER.sp_CTKM_VOUCHER_Update(v_Mavoucher, d_ngaythu)
    End Function

    Public Function sp_CTKM_VOUCHER_SelectByMaVoucher(ByVal v_Mavoucher As String, ByVal b_Trangthai As String) As System.Data.DataTable
        Return IMKT_VOUCHER.sp_CTKM_VOUCHER_SelectByMaVoucher(v_Mavoucher, b_Trangthai)
    End Function

    Public Function sp_CTKM_VOUCHER_SelectAll() As System.Data.DataTable
        Return IMKT_VOUCHER.sp_CTKM_VOUCHER_SelectAll()
    End Function

    Public Function sp_CTKM_VOUCHER_SELECTALLTABLE() As System.Data.DataTable
        Return IMKT_VOUCHER.sp_CTKM_VOUCHER_SELECTALLTABLE()
    End Function

    Public Function sp_CTKM_VOUCHER_SELECTALLTABLEbyTrangthai(ByVal b_Trangthai As String) As System.Data.DataTable
        Return IMKT_VOUCHER.sp_CTKM_VOUCHER_SELECTALLTABLEbyTrangthai(b_Trangthai)
    End Function

    Public Function sp_CTKM_VOUCHER_SELECTALLTABLEbyTrangthaibyLoaiVoucher(ByVal b_Trangthai As String, ByVal uId_Loaivoucher As String) As System.Data.DataTable
        Return IMKT_VOUCHER.sp_CTKM_VOUCHER_SELECTALLTABLEbyTrangthaibyLoaiVoucher(b_Trangthai, uId_Loaivoucher)
    End Function

    Public Function sp_CTKM_DM_LoaiVoucher_SelectByID(ByVal uId_Loaivoucher As String)
        Return IMKT_VOUCHER.sp_CTKM_DM_LoaiVoucher_SelectByID(uId_Loaivoucher)
    End Function

    Public Function DeleteByID(ByVal uId_voucher As String) As Boolean
        Return IMKT_VOUCHER.DeleteByID(uId_voucher)
    End Function

    Public Function Update_Obj(ByVal obj As CM.MKT_VOUCHEREntity) As Boolean
        Return IMKT_VOUCHER.Update_Obj(obj)
    End Function

End Class
