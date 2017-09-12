Public Interface IQLTC_TK_KHACHHANGDA

    Function SelectAll() As List(Of CM.QLTC_TK_KHACHHANGEntity)

    Function SelectAllTable() As System.Data.DataTable

    Function SelectByID(ByVal uId_TK_Khachhang As String) As CM.QLTC_TK_KHACHHANGEntity

    Function Insert(ByVal obj As CM.QLTC_TK_KHACHHANGEntity) As Boolean

    Function DeleteByID(ByVal uId_TK_Khachhang As String) As Boolean

    Function Update(ByVal obj As CM.QLTC_TK_KHACHHANGEntity) As Boolean

End Interface