Public Interface ITNTP_PHIEUDICHVU_SOTOTIENDA

    Function SelectAll() As List(Of CM.TNTP_PHIEUDICHVU_SOTOTIENEntity)

    Function SelectAllTable(ByVal uId_Phieudichvu As String) As System.Data.DataTable

    Function SelectByID(ByVal uId_Phieudichvu As String, ByVal uId_Menhgiatien As String) As CM.TNTP_PHIEUDICHVU_SOTOTIENEntity

    Function Insert(ByVal obj As CM.TNTP_PHIEUDICHVU_SOTOTIENEntity) As Boolean

    Function DeleteByID(ByVal uId_Phieudichvu As String, ByVal uId_Menhgiatien As String) As Boolean

    Function Update(ByVal obj As CM.TNTP_PHIEUDICHVU_SOTOTIENEntity) As Boolean

End Interface