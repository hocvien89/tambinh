Public Interface IPQP_NHANVIEN_PHONGDA

    Function SelectAll() As List(Of CM.PQP_NHANVIEN_PHONGEntity)

    Function SelectAllTable() As System.Data.DataTable

    Function SelectByID(ByVal uId_Nhanvien_Phong As String) As CM.PQP_NHANVIEN_PHONGEntity

    Function SelectPhongByMaNV(ByVal uId_Nhanvien As String) As CM.PQP_NHANVIEN_PHONGEntity

    Function Insert(ByVal obj As CM.PQP_NHANVIEN_PHONGEntity) As Boolean

    Function DeleteByID(ByVal uId_Nhanvien_Phong As String) As Boolean

    Function Update(ByVal obj As CM.PQP_NHANVIEN_PHONGEntity) As Boolean

    Function Update_Table(objEnPQP_NV_Phong As CM.PQP_NHANVIEN_PHONGEntity) As Boolean

End Interface