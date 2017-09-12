Public Class QLMH_PHIEUXUAT_LOAITTFacade
    Dim IQLMH_PHIEUXUAT_LOAITT As DB.IQLMH_PHIEUXUAT_LOAITTDA = New DB.QLMH_PHIEUXUAT_LOAITTDA

    Public Function SelectByPhieuDV(ByVal uId_Phieuxuat As String) As System.Data.DataTable
        Return IQLMH_PHIEUXUAT_LOAITT.SelectByPhieuxuat(uId_Phieuxuat)
    End Function

    Public Function Insert(ByVal obj As CM.QLMH_PHIEUXUAT_LOAITTEntity) As Boolean
        Return IQLMH_PHIEUXUAT_LOAITT.Insert(obj)
    End Function

    Public Function DeleteByID(ByVal uId_Phieuxuat As String, ByVal uId_LoaiTT As String) As Boolean
        Return IQLMH_PHIEUXUAT_LOAITT.DeleteByID(uId_Phieuxuat, uId_LoaiTT)
    End Function

    Public Function SelectTongtien(ByVal uId_Phieuxuat As String) As String
        Return IQLMH_PHIEUXUAT_LOAITT.SelectTongtien(uId_Phieuxuat)
    End Function
End Class
