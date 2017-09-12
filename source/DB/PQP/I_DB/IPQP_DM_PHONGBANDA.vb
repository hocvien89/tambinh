Public Interface IPQP_DM_PHONGBANDA

    Function SelectAll() As List(Of CM.PQP_DM_PHONGBANEntity)

    Function SelectAllTable() As System.Data.DataTable

    Function SelectByID(ByVal uId_Phongban As String) As CM.PQP_DM_PHONGBANEntity

    Function Insert(ByVal obj As CM.PQP_DM_PHONGBANEntity) As Boolean

    Function DeleteByID(ByVal uId_Phongban As String) As Boolean

    Function Update(ByVal obj As CM.PQP_DM_PHONGBANEntity) As Boolean

End Interface