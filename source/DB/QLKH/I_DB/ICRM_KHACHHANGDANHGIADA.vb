Public Interface ICRM_KHACHHANGDANHGIADA

    Function SelectAll() As List(Of CM.CRM_KHACHHANGDANHGIAEntity)

    Function SelectAllTable() As System.Data.DataTable

    Function SelectByIDPDV(ByVal uId_Phieudichvu As String) As System.Data.DataTable

    Function BaocaoKHdanhgia(ByVal uId_Cuahang As String, ByVal Tungay As DateTime, ByVal DenNgay As DateTime) As System.Data.DataTable

    Function SelectByID(ByVal uId_KhachhangDanhgia As String) As CM.CRM_KHACHHANGDANHGIAEntity

    Function Insert(ByVal obj As CM.CRM_KHACHHANGDANHGIAEntity) As Boolean

    Function DeleteByID(ByVal uId_KhachhangDanhgia As String) As Boolean

    Function Update(ByVal obj As CM.CRM_KHACHHANGDANHGIAEntity) As Boolean

End Interface