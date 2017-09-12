Public Class QLCN_CONGNOFacade

    Dim IQLCN_CONGNO As DB.IQLCN_CONGNODA = New DB.QLCN_CONGNODA

    Public Function SelectAll() As List(Of CM.QLCN_CONGNOEntity)
        Return IQLCN_CONGNO.SelectAll()
    End Function

	Public Function SelectAllTable() AS System.Data.DataTable
		Return IQLCN_CONGNO.SelectAllTable()
	End Function

    Public Function Insert(ByVal obj As CM.QLCN_CONGNOEntity) As Boolean
        Return IQLCN_CONGNO.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.QLCN_CONGNOEntity) As Boolean
        Return IQLCN_CONGNO.Update(obj)
    End Function
    Public Function Update_TT(ByVal obj As CM.QLCN_CONGNOEntity) As Boolean
        Return IQLCN_CONGNO.Update_TT(obj)
    End Function
	Public Function DeleteByID(ByVal uId_Phieudichvu AS String) AS Boolean
		Return IQLCN_CONGNO.DeleteByID(uId_Phieudichvu)
	End Function

    Public Function SelectByID(ByVal uId_Phieudichvu As String) As CM.QLCN_CONGNOEntity
        Return IQLCN_CONGNO.SelectByID(uId_Phieudichvu)
    End Function

    Public Function CongNoKH(ByVal uId_Khachhang As String) As String
        Return IQLCN_CONGNO.CongNoKH(uId_Khachhang)
    End Function

    Public Function SelectByID_TB(ByVal uId_Phieudichvu As String) As System.Data.DataTable
        Return IQLCN_CONGNO.SelectByID_TB(uId_Phieudichvu)
    End Function
End Class