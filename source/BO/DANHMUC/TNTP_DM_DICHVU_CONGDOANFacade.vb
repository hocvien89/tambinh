Public Class TNTP_DM_DICHVU_CONGDOANFacade

    Dim ITNTP_DM_DICHVU_CONGDOAN As DB.ITNTP_DM_DICHVU_CONGDOANDA = New DB.TNTP_DM_DICHVU_CONGDOANDA

    Public Function SelectAllTable(ByVal uId_Dichvu As String) As System.Data.DataTable
        Return ITNTP_DM_DICHVU_CONGDOAN.SelectAllTable(uId_Dichvu)
    End Function

    Public Function Insert(ByVal obj As CM.TNTP_DM_DICHVU_CONGDOANEntity) As Boolean
        Return ITNTP_DM_DICHVU_CONGDOAN.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.TNTP_DM_DICHVU_CONGDOANEntity) As Boolean
        Return ITNTP_DM_DICHVU_CONGDOAN.Update(obj)
    End Function

    Public Function DeleteByID(ByVal uId_Dichvu As String, ByVal uId_Congdoan As String) As Boolean
        Return ITNTP_DM_DICHVU_CONGDOAN.DeleteByID(uId_Dichvu, uId_Congdoan)
    End Function

    Public Function SelectCongdoan(uId_Dichvu As String) As DataTable
        Return ITNTP_DM_DICHVU_CONGDOAN.SelectCongdoan(uId_Dichvu)
    End Function
End Class