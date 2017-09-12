Public Interface ITNTP_DM_DICHVU_CONGDOANDA

    Function SelectAllTable(ByVal uId_Dichvu As String) As System.Data.DataTable

    Function Insert(ByVal obj As CM.TNTP_DM_DICHVU_CONGDOANEntity) As Boolean

    Function DeleteByID(ByVal uId_Dichvu As String, ByVal uId_Congdoan As String) As Boolean

    Function Update(ByVal obj As CM.TNTP_DM_DICHVU_CONGDOANEntity) As Boolean

    'xuanhieu13/04/15 trarmnguyenspa cong doan dv
    Function SelectCongdoan(uId_Dichvu As String) As DataTable
End Interface