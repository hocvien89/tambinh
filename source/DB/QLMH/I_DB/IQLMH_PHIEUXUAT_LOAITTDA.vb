Public Interface IQLMH_PHIEUXUAT_LOAITTDA
    Function SelectByPhieuxuat(ByVal uId_Phieuxuat As String) As System.Data.DataTable

    Function Insert(ByVal obj As CM.QLMH_PHIEUXUAT_LOAITTEntity) As Boolean

    Function DeleteByID(ByVal uId_Phieuxuat As String, ByVal uId_LoaiTT As String) As Boolean

    Function SelectTongtien(ByVal uId_Phieuxuat As String) As String
End Interface
