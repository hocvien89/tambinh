Public Class clsB_TTV_DM_Thetichdiem_Chuyendoi
    Dim iclsD_TTV_DM_THETICHDIEM_CHUYENDOIDA As DB.iclsD_TTV_DM_THETICHDIEM_CHUYENDOIDA = New DB.clsD_TTV_DM_THETICHDIEM_CHUYENDOIDA
    Public Function Insert(objEnTTDChuyendoi As CM.icls_TTV_DM_Thetichdiem_ChuyendoiEntity) As String
        Return iclsD_TTV_DM_THETICHDIEM_CHUYENDOIDA.Insert(objEnTTDChuyendoi)
    End Function

    Public Function Update(objEnTTDChuyendoi As CM.icls_TTV_DM_Thetichdiem_ChuyendoiEntity) As Boolean
        Return iclsD_TTV_DM_THETICHDIEM_CHUYENDOIDA.Update(objEnTTDChuyendoi)
    End Function

    Public Function Delete(uId_TTDChuyendoi As String) As Boolean
        Return iclsD_TTV_DM_THETICHDIEM_CHUYENDOIDA.Delete(uId_TTDChuyendoi)
    End Function

    Public Function SelectByIdThe(uId_Thetichdiem As String) As DataTable
        Return iclsD_TTV_DM_THETICHDIEM_CHUYENDOIDA.SelectByIdThe(uId_Thetichdiem)
    End Function
End Class
