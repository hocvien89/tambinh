Public Interface IPQP_DICHVU_PHONGDA

    Function SelectAll() As List(Of CM.PQP_DICHVU_PHONGEntity)

    Function SelectAllTable() As System.Data.DataTable

    Function SelectByID(ByVal uId_Dichvu_Phong As String) As CM.PQP_DICHVU_PHONGEntity

    Function Insert(ByVal obj As CM.PQP_DICHVU_PHONGEntity) As Boolean

    Function DeleteByID(ByVal uId_Dichvu_Phong As String) As Boolean

    Function Update(ByVal obj As CM.PQP_DICHVU_PHONGEntity) As Boolean

End Interface