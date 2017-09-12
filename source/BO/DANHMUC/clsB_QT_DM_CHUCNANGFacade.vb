Public Class QT_DM_CHUCNANGFacade

    Dim IQT_DM_CHUCNANG As DB.IQT_DM_CHUCNANGDA = New DB.QT_DM_CHUCNANGDA

    Public Function SelectAll(ByVal uId_Phanhe As String) As List(Of CM.QT_DM_CHUCNANGEntity)
        Return IQT_DM_CHUCNANG.SelectAll(uId_Phanhe)
    End Function

	Public Function SelectAllTable(ByVal uId_Phanhe AS String) AS System.Data.DataTable
		Return IQT_DM_CHUCNANG.SelectAllTable(uId_Phanhe)
	End Function

    Public Function Insert(ByVal obj As CM.QT_DM_CHUCNANGEntity) As Boolean
        Return IQT_DM_CHUCNANG.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.QT_DM_CHUCNANGEntity) As Boolean
        Return IQT_DM_CHUCNANG.Update(obj)
    End Function

	Public Function DeleteByID(ByVal uId_Chucnang AS String) AS Boolean
		Return IQT_DM_CHUCNANG.DeleteByID(uId_Chucnang)
	End Function

    Public Function SelectByID(ByVal uId_Chucnang As String) As CM.QT_DM_CHUCNANGEntity
        Return IQT_DM_CHUCNANG.SelectByID(uId_Chucnang)
    End Function
    '14/11/2014
    Public Function Selectquyenhan() As DataTable
        Return IQT_DM_CHUCNANG.Selectquyenhan()
    End Function
End Class