Public Interface iclsD_TTV_DM_THETICHDIEM_CHUYENDOIDA
    Function Insert(objEnTTDChuyendoi As CM.icls_TTV_DM_Thetichdiem_ChuyendoiEntity) As String

    Function Update(objEnTTDChuyendoi As CM.icls_TTV_DM_Thetichdiem_ChuyendoiEntity) As Boolean

    Function Delete(uId_TTDChuyendoi As String) As Boolean

    Function SelectByIdThe(uId_Thetichdiem As String) As DataTable
End Interface
