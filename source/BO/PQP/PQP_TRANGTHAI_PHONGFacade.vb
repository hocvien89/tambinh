Public Class PQP_TRANGTHAI_PHONGFacade

    Dim IPQP_TRANGTHAI_PHONG As DB.IPQP_TRANGTHAI_PHONGDA = New DB.PQP_TRANGTHAI_PHONGDA

    Public Function SelectAll() As List(Of CM.PQP_TRANGTHAI_PHONGEntity)
        Return IPQP_TRANGTHAI_PHONG.SelectAll()
    End Function

    Public Function SelectAllTable() As System.Data.DataTable
        Return IPQP_TRANGTHAI_PHONG.SelectAllTable()
    End Function

    Public Function Insert(ByVal obj As CM.PQP_TRANGTHAI_PHONGEntity) As Boolean
        Return IPQP_TRANGTHAI_PHONG.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.PQP_TRANGTHAI_PHONGEntity) As Boolean
        Return IPQP_TRANGTHAI_PHONG.Update(obj)
    End Function

    Public Function DeleteByID(ByVal uId_TrangthaiPhong As String) As Boolean
        Return IPQP_TRANGTHAI_PHONG.DeleteByID(uId_TrangthaiPhong)
    End Function

    Public Function SelectByID(ByVal uId_TrangthaiPhong As String) As CM.PQP_TRANGTHAI_PHONGEntity
        Return IPQP_TRANGTHAI_PHONG.SelectByID(uId_TrangthaiPhong)
    End Function

End Class