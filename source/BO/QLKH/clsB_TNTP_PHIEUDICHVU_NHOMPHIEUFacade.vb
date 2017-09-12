Public Class clsB_TNTP_PHIEUDICHVU_NHOMPHIEUFacade
    Dim ITNTP_PHIEUDICHVU_NHOMPHIEU As DB.iclsD_TNTP_PHIEUDICHVU_NHOMPHIEUDA = New DB.clsD_TNTP_PHIEUDICHVU_NHOMPHIEUDA

    Public Function SelectAllTable() As System.Data.DataTable
        Return ITNTP_PHIEUDICHVU_NHOMPHIEU.SelectAllTable()
    End Function

    Public Function BAOCAO_DoanhThu_Nhomphieu(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String, ByVal Id_Nhomphieu As Integer, ByVal buoitang As Integer) As System.Data.DataTable
        Return ITNTP_PHIEUDICHVU_NHOMPHIEU.BAOCAO_DoanhThu_Nhomphieu(TuNgay, DenNgay, uId_Cuahang, Id_Nhomphieu, buoitang)
    End Function
End Class
