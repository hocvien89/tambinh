Public Interface ITNTP_QT_DIEUTRI_NHANVIENPHUDA


    Function Insert(ByVal obj As CM.TNTP_QT_DIEUTRI_NHANVIENPHUEntity) As Boolean

    Function DeleteByID(ByVal uId_QT_Dieutri As String) As Boolean

    Function DeleteByALl(ByVal uId_QT_Dieutri As String, ByVal uId_Nhanvien_Phu As String, ByVal uId_Congdoan As String) As Boolean

    Function SelectByQTDT(ByVal uId_QT_Dieutri As String) As System.Data.DataTable

End Interface
