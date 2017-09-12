Public Interface iclsD_TTV_KH_THECHUYENTIENDA


    Function SelectAllTable() As System.Data.DataTable

    Function SelectByID(uId_Khachhang As String) As CM.icls_TTV_KH_THECHUYENTIENEntity


    Function Update(ByVal obj As CM.icls_TTV_KH_THECHUYENTIENEntity, ByVal uId_phieuchitiet As String, ByVal uId_Khachhang As String) As Boolean
    Function Update_NT(ByVal obj As CM.icls_TTV_KH_THECHUYENTIENEntity, ByVal uId_Thechuyentien As String)
    Function Update_TT(ByVal obj As CM.icls_TTV_KH_THECHUYENTIENEntity, ByVal uId_Khachhang As String, ByVal Gioihan As Integer)

    Function Update_LoaiTT(ByVal uId_Khachhang As String, ByVal uId_Phieudichvu As String)

    Function SelectByID_TB(uId_Khachhang As String) As System.Data.DataTable

    Function Update_Loai_TT_Phieuxuat(ByVal uId_Khachhang As String, ByVal uId_Phieuxuat As String)
End Interface
