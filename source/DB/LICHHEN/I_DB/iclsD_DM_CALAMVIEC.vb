Public Interface iclsD_DM_CALAMVIEC

    Function Insert(obj As CM.cls_CALAMVIEC) As Boolean

    Function Select_Nhanvien_ByCa(d_Ngay As DateTime, uId_Ca As String) As DataTable

    Function Delete_ByID(uId_Nhanvien_Ca As String) As Boolean

    Function Check_Trungcalamviec(d_Ngay As Date, uId_Nhanvien As String) As DataTable

End Interface
