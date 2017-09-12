Public Class clsB_TTV_KH_THECHUYENTIENFacade
    Dim TTV_KH_THECHUYENTIEN As DB.iclsD_TTV_KH_THECHUYENTIENDA = New DB.clsD_TTV_KH_THECHUYENTIENDA
   

    Public Function Update(ByVal obj As CM.icls_TTV_KH_THECHUYENTIENEntity, ByVal uId_Phieuchitiet As String, ByVal uId_Khachhang As String) As Boolean
        Return TTV_KH_THECHUYENTIEN.Update(obj, uId_Phieuchitiet, uId_Khachhang)
    End Function

    Public Function SelectAllTable() As System.Data.DataTable
        Return TTV_KH_THECHUYENTIEN.SelectAllTable()
    End Function
    Public Function Update_NT(ByVal obj As CM.icls_TTV_KH_THECHUYENTIENEntity, ByVal uId_Thechuyentien As String) As Boolean
        Return TTV_KH_THECHUYENTIEN.Update_NT(obj, uId_Thechuyentien)
    End Function
    Public Function Update_TT(ByVal obj As CM.icls_TTV_KH_THECHUYENTIENEntity, ByVal uId_Khachhang As String, ByVal Gioihan As Integer) As Boolean
        Return TTV_KH_THECHUYENTIEN.Update_TT(obj, uId_Khachhang, Gioihan)
    End Function

    Public Function SelectByID(uId_Khachhang As String) As CM.icls_TTV_KH_THECHUYENTIENEntity
        Return TTV_KH_THECHUYENTIEN.SelectByID(uId_Khachhang)
    End Function

    Public Function Update_Loai_TT(ByVal uId_Khachhang As String, ByVal uId_Phieudichvu As String) As Boolean
        Return TTV_KH_THECHUYENTIEN.Update_LoaiTT(uId_Khachhang, uId_Phieudichvu)
    End Function

    Public Function SelectByID_TB(ByVal uId_Khachhang As String) As System.Data.DataTable
        Return TTV_KH_THECHUYENTIEN.SelectByID_TB(uId_Khachhang)
    End Function

    Public Function Update_Loai_TT_Phieuxuat(ByVal uId_Khachhang As String, ByVal uId_Phieuxuat As String) As Boolean
        Return TTV_KH_THECHUYENTIEN.Update_Loai_TT_Phieuxuat(uId_Khachhang, uId_Phieuxuat)
    End Function
End Class
