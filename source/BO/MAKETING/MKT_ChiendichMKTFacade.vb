Public Class MKT_ChiendichMKTFacade

    Dim IMKT_ChiendichMKT As DB.IMKT_ChiendichMKTDA = New DB.MKT_ChiendichMKTDA

    Public Function SelectAll() As List(Of CM.MKT_ChiendichMKTEntity)
        Return IMKT_ChiendichMKT.SelectAll()
    End Function

	Public Function SelectAllTable() As System.Data.DataTable
		Return IMKT_ChiendichMKT.SelectAllTable()
	End Function

    Public Function Insert(ByVal obj As CM.MKT_ChiendichMKTEntity) As String
        Return IMKT_ChiendichMKT.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.MKT_ChiendichMKTEntity) As Boolean
        Return IMKT_ChiendichMKT.Update(obj)
    End Function

	Public Function DeleteByID(ByVal uId_ChiendichMKT AS String) AS Boolean
		Return IMKT_ChiendichMKT.DeleteByID(uId_ChiendichMKT)
	End Function

    Public Function SelectByID(ByVal uId_ChiendichMKT As String) As CM.MKT_ChiendichMKTEntity
        Return IMKT_ChiendichMKT.SelectByID(uId_ChiendichMKT)
    End Function
    Public Function Timkiem(ByVal obj As CM.MKT_ChiendichMKTEntity) As System.Data.DataTable
        Return IMKT_ChiendichMKT.Timkiem(obj)
    End Function
    Public Function SelectAll_KH(ByVal uId_ChiendichMKT As String) As System.Data.DataTable
        Return IMKT_ChiendichMKT.SelectAll_KH(uId_ChiendichMKT)
    End Function
    Public Function BaocaoDoanhthu(ByVal Tungay As DateTime, ByVal Denngay As DateTime) As System.Data.DataTable
        Return IMKT_ChiendichMKT.BaocaoDoanhthu(Tungay, Denngay)
    End Function
    Public Function BaocaoTrangthai(ByVal Tungay As DateTime, ByVal Denngay As DateTime) As System.Data.DataTable
        Return IMKT_ChiendichMKT.BaocaoTrangthai(Tungay, Denngay)
    End Function
End Class