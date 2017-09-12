Public Class TNTP_QT_DIEUTRI_NHANVIENPHUFacade
    Dim ITNTP_QT_DIEUTRI_NHANVIENPHU As DB.ITNTP_QT_DIEUTRI_NHANVIENPHUDA = New DB.TNTP_QT_DIEUTRI_NHANVIENPHUDA

    Public Function Insert(ByVal obj As CM.TNTP_QT_DIEUTRI_NHANVIENPHUEntity) As Boolean
        Return ITNTP_QT_DIEUTRI_NHANVIENPHU.Insert(obj)
    End Function

    Public Function DeleteByID(ByVal uId_QT_Dieutri As String) As Boolean
        Return ITNTP_QT_DIEUTRI_NHANVIENPHU.DeleteByID(uId_QT_Dieutri)
    End Function

    Public Function DeleteByAll(ByVal uId_QT_Dieutri As String, ByVal uId_Nhanvien_Phu As String, ByVal uId_Congdoan As String) As Boolean
        Return ITNTP_QT_DIEUTRI_NHANVIENPHU.DeleteByALl(uId_QT_Dieutri, uId_Nhanvien_Phu, uId_Congdoan)
    End Function

    Public Function SelectByQTDT(ByVal uId_QT_Dieutri As String) As System.Data.DataTable
        Return ITNTP_QT_DIEUTRI_NHANVIENPHU.SelectByQTDT(uId_QT_Dieutri)
    End Function
End Class
