Public Interface IMKT_SMSDA

    Function SelectAll() As List(Of CM.MKT_SMSEntity)

    Function SelectAllTable() As System.Data.DataTable

    Function SelectByID(ByVal uId_SMS As String) As CM.MKT_SMSEntity

    Function Insert(ByVal obj As CM.MKT_SMSEntity) As Boolean

    Function DeleteByID(ByVal uId_SMS As String) As Boolean

    Function Update(ByVal obj As CM.MKT_SMSEntity) As Boolean

End Interface