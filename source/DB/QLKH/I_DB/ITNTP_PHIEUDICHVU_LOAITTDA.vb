Public Interface ITNTP_PHIEUDICHVU_LOAITTDA


    Function SelectByPhieuDV(ByVal uId_Phieudichvu As String) As System.Data.DataTable
    
    Function Insert(ByVal obj As CM.TNTP_PHIEUDICHVU_LOAITTEntity) As Boolean

    Function DeleteByID(ByVal uId_Phieudichvu As String, ByVal uId_LoaiTT As String) As Boolean

    Function SelectTongtien(ByVal uId_Phieudichvu As String) As String

    Function QLTC_LoaiHinhTT_SelectByMa(ByVal v_MaLoaiTT As String) As String

    Function SelectAllByMaThe(ByVal vMaBarcode As String) As System.Data.DataTable

    Function updatesotien(uId_LoaiTT As String, uId_Phieudichvu As String, f_Sotien As Double) As Boolean

    Function LoaiTT_SelectByID(ByVal uId_Phieudichvu As String) As System.Data.DataTable
End Interface

