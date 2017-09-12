Public Class clsB_TTV_KH_Thetichdiem_Lichsu
    Dim iclsD_TTV_KH_THETICHDIEM_LICHSU As DB.iclsD_TTV_KH_THETICHDIEM_LICHSUDA = New DB.clsD_TTV_KH_THETICHDIEM_LICHSUDA
    Public Function Insert(obj As CM.iCls_TTV_KH_Thetichdiem_LichsuEntity) As Boolean
        Return iclsD_TTV_KH_THETICHDIEM_LICHSU.Insert(obj)
    End Function

    Public Function SelectAllTable(uid_KH_The As String) As DataTable
        Return iclsD_TTV_KH_THETICHDIEM_LICHSU.SelectAllTable(uid_KH_The)
    End Function
End Class
