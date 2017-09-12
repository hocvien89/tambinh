Public Interface IPQP_TRANGTHAI_PHONGDA

    Function SelectAll() As List(Of CM.PQP_TRANGTHAI_PHONGEntity)

    Function SelectAllTable() As System.Data.DataTable

    Function SelectByID(ByVal uId_TrangthaiPhong As String) As CM.PQP_TRANGTHAI_PHONGEntity

    Function Insert(ByVal obj As CM.PQP_TRANGTHAI_PHONGEntity) As Boolean

    Function DeleteByID(ByVal uId_TrangthaiPhong As String) As Boolean

    Function Update(ByVal obj As CM.PQP_TRANGTHAI_PHONGEntity) As Boolean

End Interface