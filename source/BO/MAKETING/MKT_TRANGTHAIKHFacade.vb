Public Class MKT_TRANGTHAIKHFacade

    Dim IMKT_TRANGTHAIKH As DB.IMKT_TRANGTHAIKHDA = New DB.MKT_TRANGTHAIKHDA

    Public Function SelectAll() As List(Of CM.MKT_TRANGTHAIKHEntity)
        Return IMKT_TRANGTHAIKH.SelectAll()
    End Function

    Public Function SelectAllTable() As System.Data.DataTable
        Return IMKT_TRANGTHAIKH.SelectAllTable()
    End Function

    Public Function Insert(ByVal obj As CM.MKT_TRANGTHAIKHEntity) As Boolean
        Return IMKT_TRANGTHAIKH.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.MKT_TRANGTHAIKHEntity) As Boolean
        Return IMKT_TRANGTHAIKH.Update(obj)
    End Function

    Public Function DeleteByID(ByVal uId_TrangthaiKH As String) As Boolean
        Return IMKT_TRANGTHAIKH.DeleteByID(uId_TrangthaiKH)
    End Function

    Public Function SelectByID(ByVal uId_TrangthaiKH As String) As CM.MKT_TRANGTHAIKHEntity
        Return IMKT_TRANGTHAIKH.SelectByID(uId_TrangthaiKH)
    End Function

End Class