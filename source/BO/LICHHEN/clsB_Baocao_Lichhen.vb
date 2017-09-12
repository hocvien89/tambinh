Public Class clsB_Baocao_Lichhen

    Dim icls_Baocao_Lichhen As DB.iclsD_Baocao_Lichhen = New DB.clsD_Baocao_Lichhen

    Public Function SelectLichhenThongkeKH(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal DK As Int32, ByVal uId_Cuahang As String) As System.Data.DataTable
        Return icls_Baocao_Lichhen.SelectLichhenThongkeKH(TuNgay, DenNgay, DK, uId_Cuahang)
    End Function

End Class
