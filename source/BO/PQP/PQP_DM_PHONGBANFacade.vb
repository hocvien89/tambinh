Public Class PQP_DM_PHONGBANFacade

    Dim IPQP_DM_PHONGBAN As DB.IPQP_DM_PHONGBANDA = New DB.PQP_DM_PHONGBANDA

    Public Function SelectAll() As List(Of CM.PQP_DM_PHONGBANEntity)
        Return IPQP_DM_PHONGBAN.SelectAll()
    End Function

    Public Function SelectAllTable() As System.Data.DataTable
        Return IPQP_DM_PHONGBAN.SelectAllTable()
    End Function

    Public Function Insert(ByVal obj As CM.PQP_DM_PHONGBANEntity) As Boolean
        Return IPQP_DM_PHONGBAN.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.PQP_DM_PHONGBANEntity) As Boolean
        Return IPQP_DM_PHONGBAN.Update(obj)
    End Function

    Public Function DeleteByID(ByVal uId_Phongban As String) As Boolean
        Return IPQP_DM_PHONGBAN.DeleteByID(uId_Phongban)
    End Function

    Public Function SelectByID(ByVal uId_Phongban As String) As CM.PQP_DM_PHONGBANEntity
        Return IPQP_DM_PHONGBAN.SelectByID(uId_Phongban)
    End Function

End Class