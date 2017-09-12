Public Class MKT_Tags
    Dim IMKT_Tags As DB.IMKT_TAGS = New DB.MKT_TAGS

    Public Function SelectAllTable(ByVal key As String) As System.Data.DataTable
        Return IMKT_Tags.SelectAllTable(key)
    End Function

    Public Function SelectAllTableByMaLoai(ByVal Maloai As Integer) As System.Data.DataTable
        Return IMKT_Tags.SelectAllTableByMaLoai(Maloai)
    End Function


    Public Function TimKiem(ByVal keyword As String) As System.Data.DataTable
        Return IMKT_Tags.TimKiem(keyword)
    End Function

    Public Function Insert(ByVal obj As CM.MKT_TAGS) As Boolean
        Return IMKT_Tags.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.MKT_TAGS) As Boolean
        Return IMKT_Tags.Update(obj)
    End Function

    Public Function DeleteByID(ByVal uId_tags As String) As Boolean
        Return IMKT_Tags.DeleteByID(uId_tags)
    End Function

    Public Function SelectByID(ByVal uId_tags As String) As CM.MKT_TAGS
        Return IMKT_Tags.SelectByID(uId_tags)
    End Function

    Public Function SelectByTen(ByVal nv_TenTag As String) As CM.MKT_TAGS
        Return IMKT_Tags.SelectByTen(nv_TenTag)
    End Function

    Public Function SelectByIDAndMaloai(ByVal uId_tags As String, ByVal Maloai As Integer) As CM.MKT_TAGS
        Return IMKT_Tags.SelectByIDAndMaloai(uId_tags, Maloai)
    End Function

    Public Function SelectAlltable_Nokey() As System.Data.DataTable
        Return IMKT_Tags.SelectAllTable_Nokey()
    End Function
    Public Function SelectAllTable_LoaiTag() As System.Data.DataTable
        Return IMKT_Tags.SelectAllTable_LoaiTag()
    End Function
End Class
