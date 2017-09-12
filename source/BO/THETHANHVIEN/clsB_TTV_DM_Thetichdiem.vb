Public Class clsB_TTV_DM_THETICHDIEM
    Dim iclsD_TTV_DM_THETICHDIEM As DB.iclsD_TTV_DM_THETICHDIEMDA = New DB.clsD_TTV_DM_THETICHDIEMDA
    Public Function SelectAllTable(uId_Cuahang As String) As DataTable
        Return iclsD_TTV_DM_THETICHDIEM.SelectAllTable(uId_Cuahang)
    End Function

    Public Function Insert(objEnThetichdiem As CM.icls_TTV_DM_ThetichdiemEntity) As Boolean
        Return iclsD_TTV_DM_THETICHDIEM.Insert(objEnThetichdiem)
    End Function

    Public Function Update(objEnThetichdiem As CM.icls_TTV_DM_ThetichdiemEntity) As Boolean
        Return iclsD_TTV_DM_THETICHDIEM.Update(objEnThetichdiem)
    End Function

    Public Function Delete(uId_The As String) As Boolean
        Return iclsD_TTV_DM_THETICHDIEM.DeleteById(uId_The)
    End Function

    Public Function SelectUutienByKH(uId_Khachhang As String) As String
        Return iclsD_TTV_DM_THETICHDIEM.SelectUutienByKH(uId_Khachhang)
    End Function

    Public Function SelectById(uId_Khachhang As String) As CM.cls_DM_ThetichdiemEntity
        Return iclsD_TTV_DM_THETICHDIEM.SelectByID(uId_Khachhang)
    End Function

    Function SelectById_Thetichdiem(uid_Thetichdiem As String) As DataTable
        Return iclsD_TTV_DM_THETICHDIEM.SelectById_Thetichdiem(uid_Thetichdiem)
    End Function

End Class
