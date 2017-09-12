Public Class QLP_CA_THIETBIFacade

    Dim IQLP_CA_THIETBI As DB.IQLP_CA_THIETBIDA = New DB.QLP_CA_THIETBIDA

    Public Function SelectAll() As List(Of CM.QLP_CA_THIETBIEntity)
        Return IQLP_CA_THIETBI.SelectAll()
    End Function

	Public Function SelectAllTable() AS System.Data.DataTable
		Return IQLP_CA_THIETBI.SelectAllTable()
	End Function

    Public Function Insert(ByVal obj As CM.QLP_CA_THIETBIEntity) As Boolean
        Return IQLP_CA_THIETBI.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.QLP_CA_THIETBIEntity) As Boolean
        Return IQLP_CA_THIETBI.Update(obj)
    End Function

    Public Function DeleteByID(ByVal uId_Ca As String, ByVal uId_Thietbi As String) As Boolean
        Return IQLP_CA_THIETBI.DeleteByID(uId_Ca, uId_Thietbi)
    End Function

    Public Function SelectByID(ByVal uId_Ca As String) As System.Data.DataTable
        Return IQLP_CA_THIETBI.SelectByID(uId_Ca)
    End Function

End Class