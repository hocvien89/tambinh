Public Class clsB_Phieunhap_Congno
    Dim iCls_PhieunhapCongno As DB.iClsD_Phieunhap_Congno = New DB.clsD_Phieunhap_Congno
    Function Insert(objEnPhieunhapCn As CM.cls_Phieunhap_Congno) As String
        Return iCls_PhieunhapCongno.Insert(objEnPhieunhapCn)
    End Function

    Function UpdateTienno(uId_Phieunhap As String, f_Tienno As Double) As Double
        Return iCls_PhieunhapCongno.UpdateTienno(uId_Phieunhap, f_Tienno)
    End Function

    Function SelectByuIdPhieunhap(uId_Phieunhap As String) As DataTable
        Return iCls_PhieunhapCongno.SelectByuIdPhieunhap(uId_Phieunhap)
    End Function
End Class
