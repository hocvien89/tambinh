Public Interface IMKT_TRANGTHAIKHDA

    Function SelectAll() As List(Of CM.MKT_TRANGTHAIKHEntity)

    Function SelectAllTable() As System.Data.DataTable

    Function SelectByID(ByVal uId_TrangthaiKH As String) As CM.MKT_TRANGTHAIKHEntity

    Function Insert(ByVal obj As CM.MKT_TRANGTHAIKHEntity) As Boolean

    Function DeleteByID(ByVal uId_TrangthaiKH As String) As Boolean

    Function Update(ByVal obj As CM.MKT_TRANGTHAIKHEntity) As Boolean

End Interface