Public Interface IMKT_KHACHHANGPHANANH

    Function SelectAllTable(ByVal Tungay As DateTime, ByVal Denngay As DateTime) As System.Data.DataTable

    Function SelectByMaPhongChuaXuLy(ByVal uId_Phong As String) As System.Data.DataTable

    Function SelectChoXyLy() As System.Data.DataTable

    Function SelectByMaKH(ByVal uId_Khachhang As String) As System.Data.DataTable

    Function SelectByID(ByVal uId_Phananh As String) As CM.CM_CRM_PHANANHKHACHHANG

    Function Insert(ByVal obj As CM.CM_CRM_PHANANHKHACHHANG) As Boolean

    Function DeleteByID(ByVal uId_Phananh As String) As Boolean

    Function Update(ByVal obj As CM.CM_CRM_PHANANHKHACHHANG) As Boolean
End Interface
