Public Interface IMKT_KH_TIEMNANGDA

    Function SelectAll() As List(Of CM.MKT_KH_TIEMNANGEntity)

    Function SelectAllTable() As System.Data.DataTable

    Function SelectByID(ByVal uId_KH_Tiemnang As String) As CM.MKT_KH_TIEMNANGEntity

    Function Insert(ByVal obj As CM.MKT_KH_TIEMNANGEntity) As Boolean

    Function DeleteByID(ByVal uId_KH_Tiemnang As String) As Boolean

    Function Update(ByVal obj As CM.MKT_KH_TIEMNANGEntity) As Boolean

End Interface