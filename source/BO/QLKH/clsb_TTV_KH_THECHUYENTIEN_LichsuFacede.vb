Public Class clsb_TTV_KH_THECHUYENTIEN_LichsuFacede
    Dim TTV_KH_THECHUYENTIEN_Lichsu As DB.iclsD_TTV_THECHUYENTIEN_LICHSUDA = New DB.clsD_TTV_THECHUYENTIEN_LICHSUDA
    Public Function SelectAllTable(ByVal uId_Khachhang As String) As System.Data.DataTable
        Return TTV_KH_THECHUYENTIEN_Lichsu.SelectAllTable(uId_Khachhang)
    End Function
End Class
