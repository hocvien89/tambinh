Public Interface IMKT_MaCongviecDA

    Function SelectAll() As List(Of CM.MKT_MaCongviecEntity)

    Function SelectAllTable() As System.Data.DataTable

    Function SelectByID(ByVal uId_MaCongviec As String) As CM.MKT_MaCongviecEntity

    Function Insert(ByVal obj As CM.MKT_MaCongviecEntity) As Boolean

    Function DeleteByID(ByVal uId_MaCongviec As String) As Boolean

    Function Update(ByVal obj As CM.MKT_MaCongviecEntity) As Boolean

End Interface