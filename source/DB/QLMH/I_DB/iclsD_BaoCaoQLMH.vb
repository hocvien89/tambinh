Public Interface iclsD_BaocaoQLMH

    Function SelectTonghopNhap(ByVal uId_Kho As String, ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As System.Data.DataTable

    Function SelectTonghopXuat(ByVal uId_Kho As String, ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As System.Data.DataTable

    Function TheKho(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Mathang As String, ByVal uId_Kho As String) As System.Data.DataTable

    Function BaoCaoVTTH(ByVal uId_Kho As String, ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Phongban As String) As System.Data.DataTable
    'xuanhieu190115
    Function BaocaoHansudung(uid_Cuahang As String, uId_Kho As String) As DataTable
End Interface
