Public Interface IQLTC_LoaiHinhTTDA

    Function SelectAll() As List(Of CM.QLTC_LoaiHinhTTEntity)

    Function SelectAllTable() As System.Data.DataTable

    Function SelectByID(ByVal uId_LoaiTT As String) As CM.QLTC_LoaiHinhTTEntity

    Function Insert(ByVal obj As CM.QLTC_LoaiHinhTTEntity) As Boolean

    Function DeleteByID(ByVal uId_LoaiTT As String) As Boolean

    Function Update(ByVal obj As CM.QLTC_LoaiHinhTTEntity) As Boolean

End Interface