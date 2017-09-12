Public Interface ITNTP_DM_MENHGIATIENDA

    Function SelectAll() As List(Of CM.TNTP_DM_MENHGIATIENEntity)

    Function SelectAllTable(ByVal uId_Ngoaite As String) As System.Data.DataTable

    Function SelectByID(ByVal uId_Menhgiatien As String) As CM.TNTP_DM_MENHGIATIENEntity

    Function Insert(ByVal obj As CM.TNTP_DM_MENHGIATIENEntity) As Boolean

    Function DeleteByID(ByVal uId_Menhgiatien As String) As Boolean

    Function Update(ByVal obj As CM.TNTP_DM_MENHGIATIENEntity) As Boolean

End Interface