Public Class TNTP_KHACHHANG_GOIDICHVU_LICHSUFacade
    Dim iclsBaoCao_Khachhang As DB.ITNTP_KHACHHANG_GOIDICHVU_LICHSUDA = New DB.TNTP_KHACHHANG_GOIDICHVU_LICHSUDA

    Public Function Insert_Phieudichvu(ByVal obj As CM.ITNTP_KHACHHANG_GOIDICHVU_LICHSUEntity) As Boolean
        Return iclsBaoCao_Khachhang.Insert_Phieudv(obj)
    End Function

    Public Function Insert_Phieuxxuat(ByVal obj As CM.ITNTP_KHACHHANG_GOIDICHVU_LICHSUEntity) As Boolean
        Return iclsBaoCao_Khachhang.Insert_Phieuxuat(obj)
    End Function

    Public Function In_Phieu(ByVal uId_Khachhang_Goidichvu As String) As DataTable
        Return iclsBaoCao_Khachhang.SelectByID(uId_Khachhang_Goidichvu)
    End Function
End Class
