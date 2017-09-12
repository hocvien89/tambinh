Public Class clsb_BaoCaoQLMH

    Dim iclsD_BaocaoQLMH As DB.iclsD_BaocaoQLMH = New DB.BaoCaoQLMH

    Public Function SelectTonghopNhap(ByVal uId_Kho As String, ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As System.Data.DataTable
        Return iclsD_BaocaoQLMH.SelectTonghopNhap(uId_Kho, TuNgay, DenNgay, uId_Cuahang)
    End Function

    Public Function SelectTonghopXuat(ByVal uId_Kho As String, ByVal TuNgay As DateTime, ByVal DenNgay As DateTime, ByVal uId_Cuahang As String) As System.Data.DataTable
        Return iclsD_BaocaoQLMH.SelectTonghopXuat(uId_Kho, TuNgay, DenNgay, uId_Cuahang)
    End Function
    Public Function TheKho(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal uId_Mathang As String, ByVal uId_Kho As String) As System.Data.DataTable
        Return iclsD_BaocaoQLMH.TheKho(TuNgay, DenNgay, uId_Mathang, uId_Kho)
    End Function

    Public Function BaoCaoVTTH(ByVal uId_Kho As String, ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal uId_Phongban As String) As System.Data.DataTable
        Return iclsD_BaocaoQLMH.BaoCaoVTTH(uId_Kho, TuNgay, DenNgay, uId_Phongban)
    End Function
    'xuanhieu190115
    Public Function BaocaoHansudung(uid_Cuahang As String, uId_Kho As String) As DataTable
        Return iclsD_BaocaoQLMH.BaocaoHansudung(uid_Cuahang, uId_Kho)
    End Function
End Class
