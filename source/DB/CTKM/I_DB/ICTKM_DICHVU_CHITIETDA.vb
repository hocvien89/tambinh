Public Interface ICTKM_DICHVU_CHITIETDA

    Function SelectAll() As List(Of CM.CTKM_DICHVU_CHITIETEntity)

    Function SelectAllTable(ByVal uId_ChuongtrinhKhuyenmai As String, ByVal strTukhoa As String) As System.Data.DataTable

    Function SelectByID(ByVal uId_CTKM_Chitiet As String) As CM.CTKM_DICHVU_CHITIETEntity

    Function Insert(ByVal obj As CM.CTKM_DICHVU_CHITIETEntity) As Boolean

    Function DeleteByID(ByVal uId_CTKM_Chitiet As String) As Boolean

    Function Update(ByVal obj As CM.CTKM_DICHVU_CHITIETEntity) As Boolean

End Interface