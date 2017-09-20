Public Class QT_DM_CUAHANGFacade

    Dim IQT_DM_CUAHANG As DB.IQT_DM_CUAHANGDA = New DB.QT_DM_CUAHANGDA

    Public Function SelectAll() As List(Of CM.QT_DM_CUAHANGEntity)
        Return IQT_DM_CUAHANG.SelectAll()
    End Function

	Public Function SelectAllTable() As System.Data.DataTable
		Return IQT_DM_CUAHANG.SelectAllTable()
	End Function

    Public Function Insert(ByVal obj As CM.QT_DM_CUAHANGEntity) As String
        Return IQT_DM_CUAHANG.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.QT_DM_CUAHANGEntity) As Boolean
        Return IQT_DM_CUAHANG.Update(obj)
    End Function

	Public Function DeleteByID(ByVal uId_Cuahang AS String) AS Boolean
		Return IQT_DM_CUAHANG.DeleteByID(uId_Cuahang)
	End Function

    Public Function SelectByID(ByVal uId_Cuahang As String) As System.Data.DataTable
        Return IQT_DM_CUAHANG.SelectByID(uId_Cuahang)
    End Function



    Public Function SelectByMaCH(ByVal v_Macuahang As String) As System.Data.DataTable
        Return IQT_DM_CUAHANG.SelectByMaCH(v_Macuahang)
    End Function

    Public Function AddThongtinMail(ByVal obj As CM.QT_DM_CUAHANGEntity) As Boolean
        Return IQT_DM_CUAHANG.AddThongtinMail(obj)
    End Function

    Public Function SelectByIDCuahang(uId_Cuahang As String) As CM.QT_DM_CUAHANGEntity
        Return IQT_DM_CUAHANG.SelectByIDCuahang(uId_Cuahang)
    End Function
End Class