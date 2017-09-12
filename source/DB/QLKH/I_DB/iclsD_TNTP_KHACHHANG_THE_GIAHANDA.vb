Public Interface ITNTP_KHACHHANG_THE_GIAHANDA

    Function SelectAll() As List(Of CM.TNTP_KHACHHANG_THE_GIAHANEntity)

	Function SelectAllTable() AS System.Data.DataTable

    Function SelectByID(ByVal uId_The As String, ByVal d_Giahandenngay As DateTime) As CM.TNTP_KHACHHANG_THE_GIAHANEntity

    Function Insert(ByVal obj As CM.TNTP_KHACHHANG_THE_GIAHANEntity) As Boolean

	Function DeleteByID(ByVal uId_The AS String,ByVal d_Giahandenngay AS DateTime) AS Boolean

    Function Update(ByVal obj As CM.TNTP_KHACHHANG_THE_GIAHANEntity) As Boolean

End Interface