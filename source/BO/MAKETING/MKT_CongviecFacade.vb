Public Class MKT_CongviecFacade

    Dim IMKT_Congviec As DB.IMKT_CongviecDA = New DB.MKT_CongviecDA

    Public Function SelectAll() As List(Of CM.MKT_CongviecEntity)
        Return IMKT_Congviec.SelectAll()
    End Function

    Public Function SelectAllTable() As System.Data.DataTable
        Return IMKT_Congviec.SelectAllTable()
    End Function

    Public Function SelectByTagsGanDung(ByVal keyword As String, ByVal tungay As Date, ByVal dengay As Date, ByVal uId_Trangthai_KH As String) As System.Data.DataTable
        Return IMKT_Congviec.SelectByTagsGanDung(keyword, tungay, dengay, uId_Trangthai_KH)
    End Function

    Public Function SelectByTagsChinhxac(ByVal keyword As String, ByVal tungay As Date, ByVal dengay As Date, ByVal uId_Trangthai_KH As String, ByVal uId_Nhanvien As String, uId_Cuahang As String) As System.Data.DataTable
        Return IMKT_Congviec.SelectByTagsChinhxac(keyword, tungay, dengay, uId_Trangthai_KH, uId_Nhanvien, uId_Cuahang)
    End Function

    Public Function SelectByIDKhachhang(ByVal uId_KH_Tiemnang As String) As System.Data.DataTable
        Return IMKT_Congviec.SelectByIDKhachhang(uId_KH_Tiemnang)
    End Function

    Public Function Insert(ByVal obj As CM.MKT_CongviecEntity) As Boolean
        Return IMKT_Congviec.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.MKT_CongviecEntity) As Boolean
        Return IMKT_Congviec.Update(obj)
    End Function

    Public Function DeleteByID(ByVal uId_Congviec As String) As Boolean
        Return IMKT_Congviec.DeleteByID(uId_Congviec)
    End Function

    Public Function SelectByID(ByVal uId_Congviec As String) As CM.MKT_CongviecEntity
        Return IMKT_Congviec.SelectByID(uId_Congviec)
    End Function

    Public Function SelectTagByTime(ByVal tungay As Date, ByVal dengay As Date) As System.Data.DataTable
        Return IMKT_Congviec.SelectTagByTime(tungay, dengay)
    End Function


End Class