Public Class clsB_DM_CALAMVIEC
    Dim DM_CALAMVIEC As DB.iclsD_DM_CALAMVIEC = New DB.clsD_DM_CALAMVIEC

    Function Insert(obj As CM.cls_CALAMVIEC) As Boolean
        Return DM_CALAMVIEC.Insert(obj)
    End Function

    Function Select_Nhanvien_ByCa(d_Ngay As DateTime, uId_Ca As String) As DataTable
        Return DM_CALAMVIEC.Select_Nhanvien_ByCa(d_Ngay, uId_Ca)
    End Function

    Function Delete_ById(uId_Nhanvien_Ca As String) As Boolean
        Return DM_CALAMVIEC.Delete_ByID(uId_Nhanvien_Ca)
    End Function

    Function Check_Trungcalamviec(d_Ngay As DateTime, uId_Nhanvien As String) As DataTable
        Return DM_CALAMVIEC.Check_Trungcalamviec(d_Ngay, uId_Nhanvien)
    End Function

End Class
