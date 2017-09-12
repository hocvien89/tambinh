Public Interface ICUAHANG_NHANVIENDA

    Function SelectAll() As List(Of CM.CUAHANG_NHANVIENEntity)

    Function SelectAllTable() As System.Data.DataTable

    Function SelectByID(ByVal uId_Cuahang_Nhanvien As String) As CM.CUAHANG_NHANVIENEntity

    Function Insert(ByVal obj As CM.CUAHANG_NHANVIENEntity) As Boolean

    Function DeleteByID(ByVal uId_Cuahang_Nhanvien As String) As Boolean

    Function Update(ByVal obj As CM.CUAHANG_NHANVIENEntity) As Boolean

End Interface