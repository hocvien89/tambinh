Public Class clsB_Menu
    Dim iclsD_Menu As DB.iclsD_menu = New DB.clsD_Menu
    Public Function SelectAllByIdPhong(uId_Phongban As String, ParentId As String) As DataTable
        Return iclsD_Menu.SelectAllByIdPhong(uId_Phongban, ParentId)
    End Function

End Class
