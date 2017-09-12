Public Interface IQT_DM_CUAHANGDA

    Function SelectAll() As List(Of CM.QT_DM_CUAHANGEntity)

	Function SelectAllTable() AS System.Data.DataTable

    Function SelectByID(ByVal uId_Cuahang As String) As System.Data.DataTable

    Function SelectByMaCH(ByVal v_Macuahang As String) As System.Data.DataTable

    Function Insert(ByVal obj As CM.QT_DM_CUAHANGEntity) As String

	Function DeleteByID(ByVal uId_Cuahang AS String) AS Boolean

    Function Update(ByVal obj As CM.QT_DM_CUAHANGEntity) As Boolean

    Function AddThongtinMail(ByVal obj As CM.QT_DM_CUAHANGEntity) As Boolean

End Interface