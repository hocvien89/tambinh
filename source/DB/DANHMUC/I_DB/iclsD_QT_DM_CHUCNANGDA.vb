Public Interface IQT_DM_CHUCNANGDA

    Function SelectAll(ByVal uId_Phanhe As String) As System.Collections.Generic.List(Of CM.QT_DM_CHUCNANGEntity)

	Function SelectAllTable(ByVal uId_Phanhe AS String) AS System.Data.DataTable

    Function SelectByID(ByVal uId_Chucnang As String) As CM.QT_DM_CHUCNANGEntity

    Function Insert(ByVal obj As CM.QT_DM_CHUCNANGEntity) As Boolean

	Function DeleteByID(ByVal uId_Chucnang AS String) AS Boolean

    Function Update(ByVal obj As CM.QT_DM_CHUCNANGEntity) As Boolean
    '14/11
    Function Selectquyenhan() As DataTable
End Interface