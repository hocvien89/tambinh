Public Interface iclsD_TNTP_PHIEUDICHVU_NHOMPHIEUDA
    Function SelectAllTable() As System.Data.DataTable

    Function BAOCAO_DoanhThu_Nhomphieu(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String, ByVal Id_Nhomphieu As String, ByVal buoitang As Integer) As System.Data.DataTable
End Interface
