Public Interface IQT_DM_PHANHEDA

    Function SelectAll() As List(Of CM.QT_DM_PHANHEEntity)

	Function SelectAllTable() AS System.Data.DataTable

    Function SelectByID(ByVal uId_Phanhe As String) As CM.QT_DM_PHANHEEntity

    Function Insert(ByVal obj As CM.QT_DM_PHANHEEntity) As Boolean

	Function DeleteByID(ByVal uId_Phanhe AS String) AS Boolean

    Function Update(ByVal obj As CM.QT_DM_PHANHEEntity) As Boolean

End Interface