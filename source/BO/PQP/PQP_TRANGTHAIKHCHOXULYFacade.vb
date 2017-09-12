Public Class PQP_TRANGTHAIKHCHOXULYFacade

    Dim IPQP_TRANGTHAIKHCHOXULY As DB.IPQP_TRANGTHAIKHCHOXULYDA = New DB.PQP_TRANGTHAIKHCHOXULYDA

    Public Function SelectAll() As List(Of CM.PQP_TRANGTHAIKHCHOXULYEntity)
        Return IPQP_TRANGTHAIKHCHOXULY.SelectAll()
    End Function

    Public Function SelectAllTable() As System.Data.DataTable
        Return IPQP_TRANGTHAIKHCHOXULY.SelectAllTable()
    End Function

    Public Function Insert(ByVal obj As CM.PQP_TRANGTHAIKHCHOXULYEntity) As Boolean
        Return IPQP_TRANGTHAIKHCHOXULY.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.PQP_TRANGTHAIKHCHOXULYEntity) As Boolean
        Return IPQP_TRANGTHAIKHCHOXULY.Update(obj)
    End Function

    Public Function DeleteByID(ByVal uId_TrangthaiKH As String) As Boolean
        Return IPQP_TRANGTHAIKHCHOXULY.DeleteByID(uId_TrangthaiKH)
    End Function

    Public Function SelectByID(ByVal uId_TrangthaiKH As String) As CM.PQP_TRANGTHAIKHCHOXULYEntity
        Return IPQP_TRANGTHAIKHCHOXULY.SelectByID(uId_TrangthaiKH)
    End Function

End Class