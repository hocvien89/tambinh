Public Interface iclsD_TTV_DM_THETICHDIEMDA
    Function SelectAllTable(uId_Cuahang As String) As DataTable

    Function Insert(objEnThetichdiem As CM.icls_TTV_DM_ThetichdiemEntity) As Boolean

    Function DeleteById(uId_Thetichdiem As String) As Boolean

    Function Update(objEnKHThe As CM.icls_TTV_DM_ThetichdiemEntity) As Boolean

    Function SelectUutienByKH(uId_Khachhang As String) As String

    Function SelectByID(uId_Khachhang As String) As CM.cls_DM_ThetichdiemEntity

    Function SelectById_Thetichdiem(uid_Thetichdiem As String) As DataTable

End Interface
