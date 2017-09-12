Public Class clsB_Phieunhap_Congno_Thanhtoan
    Dim iCls_PhieunhapCnTt As DB.iClsD_Phieunhap_Congno_Thanhtoan = New DB.clsD_Phieunhap_Congno_Thanhtoan
    Function Insert(objEnPhieunhapCnTt As CM.cls_Phieunhap_Congno_Thanhtoan) As Boolean
        Return iCls_PhieunhapCnTt.Insert(objEnPhieunhapCnTt)
    End Function
    Function SelectAllTable() As DataTable
        Return iCls_PhieunhapCnTt.SelectAllTable()
    End Function
    Function SelectChitietPhieu(uId_Phieunhap As String) As DataTable
        Return iCls_PhieunhapCnTt.SelectChitietPhieu(uId_Phieunhap)
    End Function
    Function SelectCongnoPhieu(uId_Nhacungcap As String) As DataTable
        Return iCls_PhieunhapCnTt.SelectCongnoPhieu(uId_Nhacungcap)
    End Function
End Class
