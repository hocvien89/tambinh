Public Class MKT_MaCongviecFacade

    Dim IMKT_MaCongviec As DB.IMKT_MaCongviecDA = New DB.MKT_MaCongviecDA

    Public Function SelectAll() As List(Of CM.MKT_MaCongviecEntity)
        Return IMKT_MaCongviec.SelectAll()
    End Function

    Public Function SelectAllTable() As System.Data.DataTable
        Return IMKT_MaCongviec.SelectAllTable()
    End Function

    Public Function Insert(ByVal obj As CM.MKT_MaCongviecEntity) As Boolean
        Return IMKT_MaCongviec.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.MKT_MaCongviecEntity) As Boolean
        Return IMKT_MaCongviec.Update(obj)
    End Function

    Public Function DeleteByID(ByVal uId_MaCongviec As String) As Boolean
        Return IMKT_MaCongviec.DeleteByID(uId_MaCongviec)
    End Function

    Public Function SelectByID(ByVal uId_MaCongviec As String) As CM.MKT_MaCongviecEntity
        Return IMKT_MaCongviec.SelectByID(uId_MaCongviec)
    End Function

End Class