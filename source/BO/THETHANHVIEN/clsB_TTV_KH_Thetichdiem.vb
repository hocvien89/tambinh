Public Class clsB_TTV_KH_Thetichdiem
    Dim icls_TTV_KH_THETICHDIEM As DB.iclsD_TTV_KH_THETICHDIEMDA = New DB.clsD_TTV_KH_THETICHDIEMDA
    Public Function SelectAllTable() As DataTable
        Return icls_TTV_KH_THETICHDIEM.SelectAllTable()
    End Function

    Public Function Insert(objEnKHThe As CM.icls_TTV_KH_ThetichdiemEntity) As String
        Return icls_TTV_KH_THETICHDIEM.Insert(objEnKHThe)
    End Function

    Public Function Update(objEnKHThe As CM.icls_TTV_KH_ThetichdiemEntity) As Boolean
        Return icls_TTV_KH_THETICHDIEM.Update(objEnKHThe)
    End Function

    Public Function DeleteById(uId_KH_The As String) As Boolean
        Return icls_TTV_KH_THETICHDIEM.DeleteById(uId_KH_The)
    End Function

    Public Function SelectKHthe(uId_Cuahang As String) As DataTable
        Return icls_TTV_KH_THETICHDIEM.SelectKHThe(uId_Cuahang)
    End Function

    Public Function CheckKH(uId_Khachhang As String) As DataTable
        Return icls_TTV_KH_THETICHDIEM.CheckKH(uId_Khachhang)
    End Function

    Public Function UpdatePoint(f_Tongtichluy As Double, f_Diemhientai As Double, uid_KHThe As String) As Boolean
        Return icls_TTV_KH_THETICHDIEM.UpdatePoint(f_Tongtichluy, f_Diemhientai, uid_KHThe)
    End Function

    Public Function CheckMathe() As DataTable
        Return icls_TTV_KH_THETICHDIEM.CheckMathe()
    End Function

    Public Function SelectPointById(uid_KH_The As String) As DataTable
        Return icls_TTV_KH_THETICHDIEM.SelectPointById(uid_KH_The)
    End Function

    Public Function Khoathe(uid_kh_the As String, b_trangthai As Boolean) As Boolean
        Return icls_TTV_KH_THETICHDIEM.Khoathe(uid_kh_the, b_trangthai)
    End Function

    Public Function Huythe(uid_kh_the As String, b_isdelete As Boolean) As Boolean
        Return icls_TTV_KH_THETICHDIEM.Huythe(uid_kh_the, b_isdelete)
    End Function

    Public Function SelectByIdKH(uId_Khachhang As String) As DataTable
        Return icls_TTV_KH_THETICHDIEM.SelectByIdKH(uId_Khachhang)
    End Function

    Public Function SelectName(uId_Khachhang As String) As DataTable
        Return icls_TTV_KH_THETICHDIEM.SelectName(uId_Khachhang)
    End Function
End Class
