Public Class MKT_KH_TIEMNANGFacade

    Dim IMKT_KH_TIEMNANG As DB.IMKT_KH_TIEMNANGDA = New DB.MKT_KH_TIEMNANGDA

    Public Function SelectAll() As List(Of CM.MKT_KH_TIEMNANGEntity)
        Return IMKT_KH_TIEMNANG.SelectAll()
    End Function

    Public Function SelectAllTable() As System.Data.DataTable
        Return IMKT_KH_TIEMNANG.SelectAllTable()
    End Function

    Public Function Insert(ByVal obj As CM.MKT_KH_TIEMNANGEntity) As Boolean
        Return IMKT_KH_TIEMNANG.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.MKT_KH_TIEMNANGEntity) As Boolean
        Return IMKT_KH_TIEMNANG.Update(obj)
    End Function

    Public Function DeleteByID(ByVal uId_KH_Tiemnang As String) As Boolean
        Return IMKT_KH_TIEMNANG.DeleteByID(uId_KH_Tiemnang)
    End Function

    Public Function SelectByID(ByVal uId_KH_Tiemnang As String) As CM.MKT_KH_TIEMNANGEntity
        Return IMKT_KH_TIEMNANG.SelectByID(uId_KH_Tiemnang)
    End Function

End Class