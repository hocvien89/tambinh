Public Interface IMKT_CongviecDA

    Function SelectAll() As List(Of CM.MKT_CongviecEntity)

    Function SelectAllTable() As System.Data.DataTable

    Function SelectByTagsGanDung(ByVal keyword As String, ByVal tungay As DateTime, ByVal dengay As DateTime, ByVal uId_Trangthai_KH As String) As System.Data.DataTable

    Function SelectByTagsChinhxac(ByVal keyword As String, ByVal tungay As DateTime, ByVal dengay As DateTime, ByVal uId_Trangthai_KH As String, ByVal uId_Nhanvien As String, ByVal uId_Cuahang As String) As System.Data.DataTable

    Function SelectByIDKhachhang(ByVal uId_KH_Tiemnang As String) As System.Data.DataTable

    Function SelectByID(ByVal uId_Congviec As String) As CM.MKT_CongviecEntity

    Function Insert(ByVal obj As CM.MKT_CongviecEntity) As Boolean

    Function DeleteByID(ByVal uId_Congviec As String) As Boolean

    Function Update(ByVal obj As CM.MKT_CongviecEntity) As Boolean

    Function SelectTagByTime(ByVal tungay As DateTime, ByVal dengay As DateTime) As System.Data.DataTable

End Interface