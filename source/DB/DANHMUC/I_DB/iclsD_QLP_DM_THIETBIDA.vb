Public Interface IQLP_DM_THIETBIDA

    Function SelectAll(ByVal uId_Cuahang As String) As System.Collections.Generic.List(Of CM.QLP_DM_THIETBIEntity)

	Function SelectAllTable(ByVal uId_Cuahang AS String) AS System.Data.DataTable

    Function SelectByID(ByVal uId_Thietbi As String) As CM.QLP_DM_THIETBIEntity

    Function Insert(ByVal obj As CM.QLP_DM_THIETBIEntity) As Boolean

	Function DeleteByID(ByVal uId_Thietbi AS String) AS Boolean

    Function Update(ByVal obj As CM.QLP_DM_THIETBIEntity) As Boolean

End Interface