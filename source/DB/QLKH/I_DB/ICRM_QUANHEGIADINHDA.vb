Public Interface ICRM_QUANHEGIADINHDA

    Function Insert(ByVal obj As CM.CRM_QUANHEGIADINHEntity) As Boolean

    Function DeleteByID(ByVal uId_Quanhe As String) As Boolean

    Function SelectByIdKH(ByVal uId_Khachhang As String) As System.Data.DataTable

End Interface