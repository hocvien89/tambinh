Public Class MKT_SMSFacade

    Dim IMKT_SMS As DB.IMKT_SMSDA = New DB.MKT_SMSDA

    Public Function SelectAll() As List(Of CM.MKT_SMSEntity)
        Return IMKT_SMS.SelectAll()
    End Function

    Public Function SelectAllTable() As System.Data.DataTable
        Return IMKT_SMS.SelectAllTable()
    End Function

    Public Function Insert(ByVal obj As CM.MKT_SMSEntity) As Boolean
        Return IMKT_SMS.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.MKT_SMSEntity) As Boolean
        Return IMKT_SMS.Update(obj)
    End Function

    Public Function DeleteByID(ByVal uId_SMS As String) As Boolean
        Return IMKT_SMS.DeleteByID(uId_SMS)
    End Function

    Public Function SelectByID(ByVal uId_SMS As String) As CM.MKT_SMSEntity
        Return IMKT_SMS.SelectByID(uId_SMS)
    End Function

End Class