Public Class MKT_EmailFacade

    Dim IMKT_Email As DB.IMKT_EmailDA = New DB.MKT_EmailDA

    Public Function SelectAll() As List(Of CM.MKT_EmailEntity)
        Return IMKT_Email.SelectAll()
    End Function

    Public Function SelectAllTable() As System.Data.DataTable
        Return IMKT_Email.SelectAllTable()
    End Function

    Public Function SelectByIDKhachhang(ByVal uId_KH_Tiemnang As String) As System.Data.DataTable
        Return IMKT_Email.SelectByIDKhachhang(uId_KH_Tiemnang)
    End Function

    Public Function Insert(ByVal obj As CM.MKT_EmailEntity) As Boolean
        Return IMKT_Email.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.MKT_EmailEntity) As Boolean
        Return IMKT_Email.Update(obj)
    End Function

    Public Function DeleteByID(ByVal uId_Email As String) As Boolean
        Return IMKT_Email.DeleteByID(uId_Email)
    End Function

    Public Function SelectByID(ByVal uId_Email As String) As CM.MKT_EmailEntity
        Return IMKT_Email.SelectByID(uId_Email)
    End Function

End Class