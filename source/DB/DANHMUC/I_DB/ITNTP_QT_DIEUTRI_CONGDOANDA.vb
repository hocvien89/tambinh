Public Interface ITNTP_QT_DIEUTRI_CONGDOANDA

    Function SelectAllTable() As System.Data.DataTable


    Function Insert(ByVal obj As CM.TNTP_QT_DIEUTRI_CONGDOANEntity) As String

    Function DeleteByID(ByVal uId_Congdoan As String) As Boolean

    Function Update(obj As CM.TNTP_QT_DIEUTRI_CONGDOANEntity) As Boolean
End Interface