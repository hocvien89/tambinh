Public Interface IQLCN_CONGNO_SPDA

    Function SelectAll() As List(Of CM.QLCN_CONGNO_SPEntity)

	Function SelectAllTable() AS System.Data.DataTable

    Function SelectByID(ByVal uId_Phieuxuat As String) As CM.QLCN_CONGNO_SPEntity

    Function Insert(ByVal obj As CM.QLCN_CONGNO_SPEntity) As Boolean

	Function DeleteByID(ByVal uId_Phieuxuat AS String) AS Boolean

    Function Update(ByVal obj As CM.QLCN_CONGNO_SPEntity) As Boolean

    Function CongNoKH(ByVal uId_Khachhang As String) As String

End Interface