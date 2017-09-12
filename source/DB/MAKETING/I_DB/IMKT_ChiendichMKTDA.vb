Public Interface IMKT_ChiendichMKTDA

    Function SelectAll() As List(Of CM.MKT_ChiendichMKTEntity)

	Function SelectAllTable() AS System.Data.DataTable

    Function SelectByID(ByVal uId_ChiendichMKT As String) As CM.MKT_ChiendichMKTEntity

    Function Insert(ByVal obj As CM.MKT_ChiendichMKTEntity) As String

	Function DeleteByID(ByVal uId_ChiendichMKT AS String) AS Boolean

    Function Update(ByVal obj As CM.MKT_ChiendichMKTEntity) As Boolean

    Function Timkiem(ByVal obj As CM.MKT_ChiendichMKTEntity) As System.Data.DataTable

    Function SelectAll_KH(ByVal uId_ChiendichMKT As String) As System.Data.DataTable

    Function BaocaoDoanhthu(ByVal Tungay As DateTime, ByVal Denngay As DateTime) As System.Data.DataTable

    Function BaocaoTrangthai(ByVal Tungay As DateTime, ByVal Denngay As DateTime) As System.Data.DataTable
End Interface