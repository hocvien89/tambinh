Public Class QLCN_CONGNO_SPFacade

    Dim IQLCN_CONGNO_SP As DB.IQLCN_CONGNO_SPDA = New DB.QLCN_CONGNO_SPDA

    Public Function SelectAll() As List(Of CM.QLCN_CONGNO_SPEntity)
        Return IQLCN_CONGNO_SP.SelectAll()
    End Function

	Public Function SelectAllTable() As System.Data.DataTable
		Return IQLCN_CONGNO_SP.SelectAllTable()
	End Function

    Public Function Insert(ByVal obj As CM.QLCN_CONGNO_SPEntity) As Boolean
        Return IQLCN_CONGNO_SP.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.QLCN_CONGNO_SPEntity) As Boolean
        Return IQLCN_CONGNO_SP.Update(obj)
    End Function

	Public Function DeleteByID(ByVal uId_Phieuxuat AS String) AS Boolean
		Return IQLCN_CONGNO_SP.DeleteByID(uId_Phieuxuat)
	End Function

    Public Function SelectByID(ByVal uId_Phieuxuat As String) As CM.QLCN_CONGNO_SPEntity
        Return IQLCN_CONGNO_SP.SelectByID(uId_Phieuxuat)
    End Function

    Public Function CongNoKH(ByVal uId_Khachhang As String) As String
        Return IQLCN_CONGNO_SP.CongNoKH(uId_Khachhang)
    End Function
End Class