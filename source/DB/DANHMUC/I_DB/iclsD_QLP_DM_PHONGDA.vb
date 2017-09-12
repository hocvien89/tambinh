Public Interface IQLP_DM_PHONGDA

    Function SelectAll(ByVal uId_Cuahang As String) As System.Collections.Generic.List(Of CM.QLP_DM_PHONGEntity)

	Function SelectAllTable(ByVal uId_Cuahang AS String) AS System.Data.DataTable

    Function SelectByID(ByVal uId_Phong As String) As CM.QLP_DM_PHONGEntity

    Function Insert(ByVal obj As CM.QLP_DM_PHONGEntity) As Boolean

	Function DeleteByID(ByVal uId_Phong AS String) AS Boolean

    Function Update(ByVal obj As CM.QLP_DM_PHONGEntity) As Boolean

    Function SelectPhongCoGiuongTrong() As System.Data.DataTable


End Interface