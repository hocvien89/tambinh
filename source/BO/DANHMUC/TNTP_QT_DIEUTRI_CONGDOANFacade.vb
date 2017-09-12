Public Class TNTP_QT_DIEUTRI_CONGDOANFacade

    Dim ITNTP_QT_DIEUTRI_CONGDOAN As DB.ITNTP_QT_DIEUTRI_CONGDOANDA = New DB.TNTP_QT_DIEUTRI_CONGDOANDA


    Public Function SelectAllTable() As System.Data.DataTable
        Return ITNTP_QT_DIEUTRI_CONGDOAN.SelectAllTable()
    End Function

    Public Function Insert(ByVal obj As CM.TNTP_QT_DIEUTRI_CONGDOANEntity) As String
        Return ITNTP_QT_DIEUTRI_CONGDOAN.Insert(obj)
    End Function

    Public Function DeleteByID(ByVal uId_Congdoan As String) As Boolean
        Return ITNTP_QT_DIEUTRI_CONGDOAN.DeleteByID(uId_Congdoan)
    End Function

    Public Function Update(obj As CM.TNTP_QT_DIEUTRI_CONGDOANEntity) As Boolean
        Return ITNTP_QT_DIEUTRI_CONGDOAN.Update(obj)
    End Function
End Class