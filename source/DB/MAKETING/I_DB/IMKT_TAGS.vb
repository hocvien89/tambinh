Public Interface IMKT_TAGS

    Function SelectAllTable(ByVal key As String) As System.Data.DataTable

    Function SelectAllTableByMaLoai(ByVal MaLoai As Integer) As System.Data.DataTable

    Function SelectByID(ByVal uId_Tags As String) As CM.MKT_TAGS

    Function SelectByTen(ByVal nv_TenTag As String) As CM.MKT_TAGS

    Function TimKiem(ByVal keyword As String) As System.Data.DataTable

    Function Insert(ByVal obj As CM.MKT_TAGS) As Boolean

    Function DeleteByID(ByVal uId_Tags As String) As Boolean

    Function Update(ByVal obj As CM.MKT_TAGS) As Boolean

    Function SelectByIDAndMaloai(ByVal uId_Tags As String, ByVal MaLoai As Integer) As CM.MKT_TAGS

    Function SelectAllTable_Nokey() As System.Data.DataTable
    Function SelectAllTable_LoaiTag() As System.Data.DataTable

End Interface
