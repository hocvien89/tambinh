Public Class clsB_BC_ThuChi_Tienmat
    Dim iclsD_BC_ThuChi_Tienmat As DB.iclsD_BC_ThuChi_Tienmat = New DB.clsD_BC_ThuChi_Tienmat

    Public Function ThuChi_Tienmat(ByVal uID_cuahang As String, ByVal TuNgay As DateTime, ByVal DenNgay As DateTime) As System.Data.DataTable
        Return iclsD_BC_ThuChi_Tienmat.ThuChi_Tienmat(uID_cuahang, TuNgay, DenNgay)
    End Function
End Class
