Public Class TNTP_KHACHHANG_THE_GIAHANFacade

    Dim ITNTP_KHACHHANG_THE_GIAHAN As DB.ITNTP_KHACHHANG_THE_GIAHANDA = New DB.TNTP_KHACHHANG_THE_GIAHANDA

    Public Function SelectAll() As List(Of CM.TNTP_KHACHHANG_THE_GIAHANEntity)
        Return ITNTP_KHACHHANG_THE_GIAHAN.SelectAll()
    End Function

	Public Function SelectAllTable() As System.Data.DataTable
		Return ITNTP_KHACHHANG_THE_GIAHAN.SelectAllTable()
	End Function

    Public Function Insert(ByVal obj As CM.TNTP_KHACHHANG_THE_GIAHANEntity) As Boolean
        Return ITNTP_KHACHHANG_THE_GIAHAN.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.TNTP_KHACHHANG_THE_GIAHANEntity) As Boolean
        Return ITNTP_KHACHHANG_THE_GIAHAN.Update(obj)
    End Function

	Public Function DeleteByID(ByVal uId_The AS String,ByVal d_Giahandenngay AS DateTime) AS Boolean
		Return ITNTP_KHACHHANG_THE_GIAHAN.DeleteByID(uId_The,d_Giahandenngay)
	End Function

    Public Function SelectByID(ByVal uId_The As String, ByVal d_Giahandenngay As DateTime) As CM.TNTP_KHACHHANG_THE_GIAHANEntity
        Return ITNTP_KHACHHANG_THE_GIAHAN.SelectByID(uId_The, d_Giahandenngay)
    End Function

End Class