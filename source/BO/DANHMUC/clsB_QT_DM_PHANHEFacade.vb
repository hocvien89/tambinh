Public Class QT_DM_PHANHEFacade

    Dim IQT_DM_PHANHE As DB.IQT_DM_PHANHEDA = New DB.QT_DM_PHANHEDA

    Public Function SelectAll() As List(Of CM.QT_DM_PHANHEEntity)
        Return IQT_DM_PHANHE.SelectAll()
    End Function

	Public Function SelectAllTable() As System.Data.DataTable
		Return IQT_DM_PHANHE.SelectAllTable()
	End Function

    Public Function Insert(ByVal obj As CM.QT_DM_PHANHEEntity) As Boolean
        Return IQT_DM_PHANHE.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.QT_DM_PHANHEEntity) As Boolean
        Return IQT_DM_PHANHE.Update(obj)
    End Function

	Public Function DeleteByID(ByVal uId_Phanhe AS String) AS Boolean
		Return IQT_DM_PHANHE.DeleteByID(uId_Phanhe)
	End Function

    Public Function SelectByID(ByVal uId_Phanhe As String) As CM.QT_DM_PHANHEEntity
        Return IQT_DM_PHANHE.SelectByID(uId_Phanhe)
    End Function

End Class