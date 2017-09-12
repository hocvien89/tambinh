Public Class TNTP_PHIEUDICHVU_LOAITTFacade

    Dim ITNTP_PHIEUDICHVU_LOAITT As DB.ITNTP_PHIEUDICHVU_LOAITTDA = New DB.TNTP_PHIEUDICHVU_LOAITTDA

    Public Function SelectByPhieuDV(ByVal uId_Phieudichvu As String) As System.Data.DataTable
        Return ITNTP_PHIEUDICHVU_LOAITT.SelectByPhieuDV(uId_Phieudichvu)
    End Function

    Public Function Insert(ByVal obj As CM.TNTP_PHIEUDICHVU_LOAITTEntity) As Boolean
        Return ITNTP_PHIEUDICHVU_LOAITT.Insert(obj)
    End Function

    Public Function DeleteByID(ByVal uId_Phieudichvu As String, ByVal uId_LoaiTT As String) As Boolean
        Return ITNTP_PHIEUDICHVU_LOAITT.DeleteByID(uId_Phieudichvu, uId_LoaiTT)
    End Function

    Public Function SelectTongtien(ByVal uId_Phieudichvu As String) As String
        Return ITNTP_PHIEUDICHVU_LOAITT.SelectTongtien(uId_Phieudichvu)
    End Function

    Public Function QLTC_LoaiHinhTT_SelectByMa(ByVal v_MaloaiTT As String) As String
        Return ITNTP_PHIEUDICHVU_LOAITT.QLTC_LoaiHinhTT_SelectByMa(v_MaloaiTT)
    End Function
    Public Function SelectAllByMaThe(ByVal vMaBarcode As String) As System.Data.DataTable
        Return ITNTP_PHIEUDICHVU_LOAITT.SelectAllByMaThe(vMaBarcode)
    End Function
    Public Function updatesotien(uId_LoaiTT As String, uId_Phieudichvu As String, f_Sotien As Double) As Boolean
        Return ITNTP_PHIEUDICHVU_LOAITT.updatesotien(uId_LoaiTT, uId_Phieudichvu, f_Sotien)
    End Function
    Public Function LoaiTT_SelectByID(ByVal uId_Phieudichvu As String)
        Return ITNTP_PHIEUDICHVU_LOAITT.LoaiTT_SelectByID(uId_Phieudichvu)
    End Function
End Class