Public Class TNTP_DM_MENHGIATIENFacade

    Dim ITNTP_DM_MENHGIATIEN As DB.ITNTP_DM_MENHGIATIENDA = New DB.TNTP_DM_MENHGIATIENDA

    Public Function SelectAll() As List(Of CM.TNTP_DM_MENHGIATIENEntity)
        Return ITNTP_DM_MENHGIATIEN.SelectAll()
    End Function

    Public Function SelectAllTable(ByVal uId_Ngoaite As String) As System.Data.DataTable
        Return ITNTP_DM_MENHGIATIEN.SelectAllTable(uId_Ngoaite)
    End Function

    Public Function Insert(ByVal obj As CM.TNTP_DM_MENHGIATIENEntity) As Boolean
        Return ITNTP_DM_MENHGIATIEN.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.TNTP_DM_MENHGIATIENEntity) As Boolean
        Return ITNTP_DM_MENHGIATIEN.Update(obj)
    End Function

    Public Function DeleteByID(ByVal uId_Menhgiatien As String) As Boolean
        Return ITNTP_DM_MENHGIATIEN.DeleteByID(uId_Menhgiatien)
    End Function

    Public Function SelectByID(ByVal uId_Menhgiatien As String) As CM.TNTP_DM_MENHGIATIENEntity
        Return ITNTP_DM_MENHGIATIEN.SelectByID(uId_Menhgiatien)
    End Function

End Class