Public Interface IMKT_HUYDV
    Function SelectAllTable(ByVal tungay As DateTime, ByVal dengay As DateTime) As System.Data.DataTable

    Function SelectKHHuyDV(ByVal tungay As DateTime, ByVal dengay As DateTime) As System.Data.DataTable

    Function SelectKHHuyDV_Search(ByVal keyword As String) As System.Data.DataTable

    Function SelectByIdKH(ByVal uId_Khachhang As String) As System.Data.DataTable

    Function Insert(ByVal obj As CM.MKT_HUYDV) As Boolean

    Function DeleteByID(ByVal uId_HuyDV As String) As Boolean

    Function Update(ByVal obj As CM.MKT_HUYDV) As Boolean
End Interface
