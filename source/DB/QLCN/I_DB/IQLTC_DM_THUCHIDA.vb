Public Interface IQLTC_DM_THUCHIDA

    Function SelectAll() As List(Of CM.QLTC_DM_THUCHIEntity)

    Function SelectAllTable() As System.Data.DataTable

    Function SelectByID(ByVal uId_Thuchi As String) As CM.QLTC_DM_THUCHIEntity

    Function SelectByTen(ByVal Tenthuchi As String) As CM.QLTC_DM_THUCHIEntity

    Function Insert(ByVal obj As CM.QLTC_DM_THUCHIEntity) As Boolean

    Function DeleteByID(ByVal uId_Thuchi As String) As Boolean

    Function Update(ByVal obj As CM.QLTC_DM_THUCHIEntity) As Boolean

    Function SelectLoai(ByVal loai As Boolean) As System.Data.DataTable

End Interface