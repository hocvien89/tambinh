Public Class CRM_KHACHHANGDANHGIAFacade

    Dim ICRM_KHACHHANGDANHGIA As DB.ICRM_KHACHHANGDANHGIADA = New DB.CRM_KHACHHANGDANHGIADA

    Public Function SelectAll() As List(Of CM.CRM_KHACHHANGDANHGIAEntity)
        Return ICRM_KHACHHANGDANHGIA.SelectAll()
    End Function

    Public Function SelectAllTable() As System.Data.DataTable
        Return ICRM_KHACHHANGDANHGIA.SelectAllTable()
    End Function

    Public Function SelectByIDPDV(ByVal uId_Phieudichvu As String) As System.Data.DataTable
        Return ICRM_KHACHHANGDANHGIA.SelectByIDPDV(uId_Phieudichvu)
    End Function

    Public Function BaocaoKHdanhgia(ByVal uId_Cuahang As String, ByVal Tungay As DateTime, ByVal DenNgay As DateTime) As System.Data.DataTable
        Return ICRM_KHACHHANGDANHGIA.BaocaoKHdanhgia(uId_Cuahang, Tungay, DenNgay)
    End Function

    Public Function Insert(ByVal obj As CM.CRM_KHACHHANGDANHGIAEntity) As Boolean
        Return ICRM_KHACHHANGDANHGIA.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.CRM_KHACHHANGDANHGIAEntity) As Boolean
        Return ICRM_KHACHHANGDANHGIA.Update(obj)
    End Function

    Public Function DeleteByID(ByVal uId_KhachhangDanhgia As String) As Boolean
        Return ICRM_KHACHHANGDANHGIA.DeleteByID(uId_KhachhangDanhgia)
    End Function

    Public Function SelectByID(ByVal uId_KhachhangDanhgia As String) As CM.CRM_KHACHHANGDANHGIAEntity
        Return ICRM_KHACHHANGDANHGIA.SelectByID(uId_KhachhangDanhgia)
    End Function

End Class