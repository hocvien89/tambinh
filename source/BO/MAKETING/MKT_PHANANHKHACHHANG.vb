Public Class MKT_PHANANHKHACHHANG
    Dim IDB_CRM_KHACHHANGPHANANH As DB.IMKT_KHACHHANGPHANANH = New DB.MKT_KHACHHANGPHANANH

    Public Function SelectAllTable(ByVal Tungay As DateTime, ByVal Denngay As DateTime) As System.Data.DataTable
        Return IDB_CRM_KHACHHANGPHANANH.SelectAllTable(Tungay, Denngay)
    End Function

    Public Function SelectByMaPhongChuaXuLy(ByVal uId_Phong As String) As System.Data.DataTable
        Return IDB_CRM_KHACHHANGPHANANH.SelectByMaPhongChuaXuLy(uId_Phong)
    End Function

    Public Function SelectChoXyLy() As System.Data.DataTable
        Return IDB_CRM_KHACHHANGPHANANH.SelectChoXyLy()
    End Function

    Public Function SelectByMaKH(ByVal uId_Khachhang As String) As System.Data.DataTable
        Return IDB_CRM_KHACHHANGPHANANH.SelectByMaKH(uId_Khachhang)
    End Function

    Public Function SelectByID(ByVal uId_Phananh As String) As CM.CM_CRM_PHANANHKHACHHANG
        Return IDB_CRM_KHACHHANGPHANANH.SelectByID(uId_Phananh)
    End Function

    Public Function Insert(ByVal obj As CM.CM_CRM_PHANANHKHACHHANG) As Boolean
        Return IDB_CRM_KHACHHANGPHANANH.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.CM_CRM_PHANANHKHACHHANG) As Boolean
        Return IDB_CRM_KHACHHANGPHANANH.Update(obj)
    End Function

    Public Function DeleteByID(ByVal uId_Phananh As String) As Boolean
        Return IDB_CRM_KHACHHANGPHANANH.DeleteByID(uId_Phananh)
    End Function
End Class
