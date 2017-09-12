Public Class QLP_DM_GIUONGFacade

    Dim IQLP_DM_GIUONG As DB.IQLP_DM_GIUONGDA = New DB.QLP_DM_GIUONGDA

    Public Function SelectAll() As List(Of CM.QLP_DM_GIUONGEntity)
        Return IQLP_DM_GIUONG.SelectAll()
    End Function

    Public Function SelectAllTable() As System.Data.DataTable
        Return IQLP_DM_GIUONG.SelectAllTable()
    End Function

    Public Function Insert(ByVal obj As CM.QLP_DM_GIUONGEntity) As Boolean
        Return IQLP_DM_GIUONG.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.QLP_DM_GIUONGEntity) As Boolean
        Return IQLP_DM_GIUONG.Update(obj)
    End Function

    Public Function DeleteByID(ByVal uId_Giuong As String) As Boolean
        Return IQLP_DM_GIUONG.DeleteByID(uId_Giuong)
    End Function

    Public Function SelectByID(ByVal uId_Giuong As String) As CM.QLP_DM_GIUONGEntity
        Return IQLP_DM_GIUONG.SelectByID(uId_Giuong)
    End Function

    Public Function SelectGiuongtrongtheophong(uId_Phong As String) As System.Data.DataTable
        Return IQLP_DM_GIUONG.SelectGiuongtrongtheophong(uId_Phong)
    End Function
    Public Function SelectGiuongtheophong(uId_Phong As String) As System.Data.DataTable
        Return IQLP_DM_GIUONG.SelectGiuongtheophong(uId_Phong)
    End Function
    Public Function UpdateTrangThai(uId_Giuong As String, Status As Boolean) As Boolean
        Return IQLP_DM_GIUONG.UpdateTrangThai(uId_Giuong, Status)
    End Function

    Public Function SelectInfoGiuong(uId_Giuong As String, d_time As Date) As DataTable
        Return IQLP_DM_GIUONG.SelectInfoGiuong(uId_Giuong, d_time)
    End Function
End Class