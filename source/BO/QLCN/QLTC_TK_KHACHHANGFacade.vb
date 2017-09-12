Public Class QLTC_TK_KHACHHANGFacade

    Dim IQLTC_TK_KHACHHANG As DB.IQLTC_TK_KHACHHANGDA = New DB.QLTC_TK_KHACHHANGDA

    Public Function SelectAll() As List(Of CM.QLTC_TK_KHACHHANGEntity)
        Return IQLTC_TK_KHACHHANG.SelectAll()
    End Function

    Public Function SelectAllTable() As System.Data.DataTable
        Return IQLTC_TK_KHACHHANG.SelectAllTable()
    End Function

    Public Function Insert(ByVal obj As CM.QLTC_TK_KHACHHANGEntity) As Boolean
        Return IQLTC_TK_KHACHHANG.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.QLTC_TK_KHACHHANGEntity) As Boolean
        Return IQLTC_TK_KHACHHANG.Update(obj)
    End Function

    Public Function DeleteByID(ByVal uId_TK_Khachhang As String) As Boolean
        Return IQLTC_TK_KHACHHANG.DeleteByID(uId_TK_Khachhang)
    End Function

    Public Function SelectByID(ByVal uId_TK_Khachhang As String) As CM.QLTC_TK_KHACHHANGEntity
        Return IQLTC_TK_KHACHHANG.SelectByID(uId_TK_Khachhang)
    End Function

End Class