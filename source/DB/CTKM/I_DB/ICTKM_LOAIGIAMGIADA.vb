Public Interface ICTKM_LOAIGIAMGIADA

    Function SelectAll() As List(Of CM.CTKM_LOAIGIAMGIAEntity)

    Function SelectAllTable() As System.Data.DataTable

    Function SelectByID(ByVal uId_LoaiGiamgia As String) As CM.CTKM_LOAIGIAMGIAEntity

    Function Insert(ByVal obj As CM.CTKM_LOAIGIAMGIAEntity) As Boolean

    Function DeleteByID(ByVal uId_LoaiGiamgia As String) As Boolean

    Function Update(ByVal obj As CM.CTKM_LOAIGIAMGIAEntity) As Boolean

End Interface