Public Class CRM_QUANHEGIADINHDAFacade
    Dim ICRM_QUANHEGIADINH As DB.ICRM_QUANHEGIADINHDA = New DB.CRM_QUANHEGIADINHDA
    Public Function Insert(ByVal obj As CM.CRM_QUANHEGIADINHEntity) As Boolean
        Return ICRM_QUANHEGIADINH.Insert(obj)
    End Function

    Public Function DeleteByID(ByVal uId_Quanhe As String) As Boolean
        Return ICRM_QUANHEGIADINH.DeleteByID(uId_Quanhe)
    End Function

    Public Function SelectByIdKH(ByVal uId_Khachhang As String) As System.Data.DataTable
        Return ICRM_QUANHEGIADINH.SelectByIdKH(uId_Khachhang)
    End Function
End Class
