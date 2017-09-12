Public Interface iClsD_Phieunhap_Congno
    Function Insert(objEnPhieunhapCn As CM.cls_Phieunhap_Congno) As String
    Function UpdateTienno(uId_Phieunhap As String, f_Tienno As Double) As Double
    Function SelectByuIdPhieunhap(uId_Phieunhap As String) As DataTable
End Interface
