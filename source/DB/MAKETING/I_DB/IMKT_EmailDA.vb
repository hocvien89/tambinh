Public Interface IMKT_EmailDA

    Function SelectAll() As List(Of CM.MKT_EmailEntity)

    Function SelectAllTable() As System.Data.DataTable

    Function SelectByIDKhachhang(ByVal uId_KH_Tiemnang As String) As System.Data.DataTable

    Function SelectByID(ByVal uId_Email As String) As CM.MKT_EmailEntity

    Function Insert(ByVal obj As CM.MKT_EmailEntity) As Boolean

    Function DeleteByID(ByVal uId_Email As String) As Boolean

    Function Update(ByVal obj As CM.MKT_EmailEntity) As Boolean

End Interface