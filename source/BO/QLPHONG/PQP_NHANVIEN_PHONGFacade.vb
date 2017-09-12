Public Class PQP_NHANVIEN_PHONGFacade

    Dim IPQP_NHANVIEN_PHONG As DB.IPQP_NHANVIEN_PHONGDA = New DB.PQP_NHANVIEN_PHONGDA

    Public Function SelectAll() As List(Of CM.PQP_NHANVIEN_PHONGEntity)
        Return IPQP_NHANVIEN_PHONG.SelectAll()
    End Function

    Public Function SelectAllTable() As System.Data.DataTable
        Return IPQP_NHANVIEN_PHONG.SelectAllTable()
    End Function

    Public Function Insert(ByVal obj As CM.PQP_NHANVIEN_PHONGEntity) As Boolean
        Return IPQP_NHANVIEN_PHONG.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.PQP_NHANVIEN_PHONGEntity) As Boolean
        Return IPQP_NHANVIEN_PHONG.Update(obj)
    End Function

    Public Function DeleteByID(ByVal uId_Nhanvien_Phong As String) As Boolean
        Return IPQP_NHANVIEN_PHONG.DeleteByID(uId_Nhanvien_Phong)
    End Function

    Public Function SelectByID(ByVal uId_Nhanvien_Phong As String) As CM.PQP_NHANVIEN_PHONGEntity
        Return IPQP_NHANVIEN_PHONG.SelectByID(uId_Nhanvien_Phong)
    End Function

    Public Function SelectPhongByMaNV(ByVal uId_Nhanvien As String) As CM.PQP_NHANVIEN_PHONGEntity
        Return IPQP_NHANVIEN_PHONG.SelectPhongByMaNV(uId_Nhanvien)
    End Function

    Function Update_Table(objEnPQP_NV_Phong As CM.PQP_NHANVIEN_PHONGEntity) As Boolean
        Return IPQP_NHANVIEN_PHONG.Update_Table(objEnPQP_NV_Phong)
    End Function

End Class