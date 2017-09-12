Public Class MKT_HUYDV
    Dim IMKT_HuyDV As DB.IMKT_HUYDV = New DB.MKT_HUYDV

    Public Function SelectAllTable(ByVal tungay As DateTime, ByVal denngay As DateTime) As System.Data.DataTable
        Return IMKT_HuyDV.SelectAllTable(tungay, denngay)
    End Function

    Public Function SelectKHHuyDV(ByVal tungay As DateTime, ByVal denngay As DateTime) As System.Data.DataTable
        Return IMKT_HuyDV.SelectKHHuyDV(tungay, denngay)
    End Function

    Public Function SelectKHHuyDV_Search(ByVal keyword As String) As System.Data.DataTable
        Return IMKT_HuyDV.SelectKHHuyDV_Search(keyword)
    End Function

    Public Function SelectByIdKH(ByVal uId_Khachhang As String) As System.Data.DataTable
        Return IMKT_HuyDV.SelectByIdKH(uId_Khachhang)
    End Function

    Public Function Insert(ByVal obj As CM.MKT_HUYDV) As Boolean
        Return IMKT_HuyDV.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.MKT_HUYDV) As Boolean
        Return IMKT_HuyDV.Update(obj)
    End Function

    Public Function DeleteByID(ByVal uId_HuyDV As String) As Boolean
        Return IMKT_HuyDV.DeleteByID(uId_HuyDV)
    End Function
End Class
