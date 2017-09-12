Public Interface ITNTP_KHACHHANG_GOIDICHVU_LICHSUDA

    Function Insert_Phieudv(ByVal obj As CM.ITNTP_KHACHHANG_GOIDICHVU_LICHSUEntity) As Boolean

    Function Insert_Phieuxuat(ByVal obj As CM.ITNTP_KHACHHANG_GOIDICHVU_LICHSUEntity) As Boolean

    Function SelectByID(ByVal uId_Khachhang_Goidichvu As String) As System.Data.DataTable
End Interface
