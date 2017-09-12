Public Interface IPQP_TRANGTHAIKHCHOXULYDA

    Function SelectAll() As List(Of CM.PQP_TRANGTHAIKHCHOXULYEntity)

    Function SelectAllTable() As System.Data.DataTable

    Function SelectByID(ByVal uId_TrangthaiKH As String) As CM.PQP_TRANGTHAIKHCHOXULYEntity

    Function Insert(ByVal obj As CM.PQP_TRANGTHAIKHCHOXULYEntity) As Boolean

    Function DeleteByID(ByVal uId_TrangthaiKH As String) As Boolean

    Function Update(ByVal obj As CM.PQP_TRANGTHAIKHCHOXULYEntity) As Boolean

End Interface