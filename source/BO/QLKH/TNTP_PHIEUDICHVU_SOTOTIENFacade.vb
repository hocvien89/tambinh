Public Class TNTP_PHIEUDICHVU_SOTOTIENFacade

    Dim ITNTP_PHIEUDICHVU_SOTOTIEN As DB.ITNTP_PHIEUDICHVU_SOTOTIENDA = New DB.TNTP_PHIEUDICHVU_SOTOTIENDA

    Public Function SelectAll() As List(Of CM.TNTP_PHIEUDICHVU_SOTOTIENEntity)
        Return ITNTP_PHIEUDICHVU_SOTOTIEN.SelectAll()
    End Function

    Public Function SelectAllTable(ByVal uId_Phieudichvu As String) As System.Data.DataTable
        Return ITNTP_PHIEUDICHVU_SOTOTIEN.SelectAllTable(uId_Phieudichvu)
    End Function

    Public Function Insert(ByVal obj As CM.TNTP_PHIEUDICHVU_SOTOTIENEntity) As Boolean
        Return ITNTP_PHIEUDICHVU_SOTOTIEN.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.TNTP_PHIEUDICHVU_SOTOTIENEntity) As Boolean
        Return ITNTP_PHIEUDICHVU_SOTOTIEN.Update(obj)
    End Function

    Public Function DeleteByID(ByVal uId_Phieudichvu As String, ByVal uId_Menhgiatien As String) As Boolean
        Return ITNTP_PHIEUDICHVU_SOTOTIEN.DeleteByID(uId_Phieudichvu, uId_Menhgiatien)
    End Function

    Public Function SelectByID(ByVal uId_Phieudichvu As String, ByVal uId_Menhgiatien As String) As CM.TNTP_PHIEUDICHVU_SOTOTIENEntity
        Return ITNTP_PHIEUDICHVU_SOTOTIEN.SelectByID(uId_Phieudichvu, uId_Menhgiatien)
    End Function

End Class