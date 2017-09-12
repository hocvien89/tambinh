Public Class CRM_KhachHang_DoangThuNguonFacade

    Dim ICRM_KhachHang_DoangThuNguon As DB.ICRM_KhachHang_DoangThuNguonDA = New DB.CRM_KhachHang_DoangThuNguonDA

    Public Function SelectAllTable(ByVal uId_Cuahang As String, ByVal uId_NguonKH As String, ByVal TuNgay As DateTime, ByVal DenNgay As DateTime) As System.Data.DataTable
        Return ICRM_KhachHang_DoangThuNguon.SelectAllTable(uId_Cuahang, uId_NguonKH, TuNgay, DenNgay)
    End Function
End Class
