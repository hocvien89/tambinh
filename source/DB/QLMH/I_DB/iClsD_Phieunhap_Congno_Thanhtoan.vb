Public Interface iClsD_Phieunhap_Congno_Thanhtoan
    Function Insert(objEnPhieunhapCnTt As CM.cls_Phieunhap_Congno_Thanhtoan) As Boolean

    Function SelectAllTable() As DataTable
    'nha cung cap
    Function SelectCongnoPhieu(uId_Nhacungcap As String) As DataTable
    'chi tiet phieu
    Function SelectChitietPhieu(uId_Phieunhap As String) As DataTable

End Interface
