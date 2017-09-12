Public Class QLCN_CONGNO_THANHTOANFacade

    Dim IQLCN_CONGNO_THANHTOAN As DB.IQLCN_CONGNO_THANHTOANDA = New DB.QLCN_CONGNO_THANHTOANDA

    Public Function SelectAll(ByVal uId_Khachhang As String) As List(Of CM.QLCN_CONGNO_THANHTOANEntity)
        Return IQLCN_CONGNO_THANHTOAN.SelectAll(uId_Khachhang)
    End Function

	Public Function SelectAllTable(ByVal uId_Khachhang AS String) AS System.Data.DataTable
		Return IQLCN_CONGNO_THANHTOAN.SelectAllTable(uId_Khachhang)
	End Function

    Public Function Insert(ByVal obj As CM.QLCN_CONGNO_THANHTOANEntity) As String
        Return IQLCN_CONGNO_THANHTOAN.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.QLCN_CONGNO_THANHTOANEntity) As Boolean
        Return IQLCN_CONGNO_THANHTOAN.Update(obj)
    End Function

	Public Function DeleteByID(ByVal uId_Congno_Thanhtoan AS String) AS Boolean
		Return IQLCN_CONGNO_THANHTOAN.DeleteByID(uId_Congno_Thanhtoan)
	End Function

    Public Function SelectByID(ByVal uId_Congno_Thanhtoan As String) As CM.QLCN_CONGNO_THANHTOANEntity
        Return IQLCN_CONGNO_THANHTOAN.SelectByID(uId_Congno_Thanhtoan)
    End Function
    Public Function SelectByIDPTC(ByVal uId_Phieuthuchi As String) As CM.QLCN_CONGNO_THANHTOANEntity
        Return IQLCN_CONGNO_THANHTOAN.SelectByIDPTC(uId_Phieuthuchi)
    End Function

    Public Function SelectByIDPDV(ByVal uId_Phieudichvu As String) As System.Data.DataTable
        Return IQLCN_CONGNO_THANHTOAN.SelectByIDPDV(uId_Phieudichvu)
    End Function

    Public Function SelectByID_PDV(ByVal uId_Phieudichvu As String) As System.Data.DataTable
        Return IQLCN_CONGNO_THANHTOAN.SelectByID_PDV(uId_Phieudichvu)
    End Function

    Public Function SelectCongnoTTByDate(ngay As Date) As DataTable
        Return IQLCN_CONGNO_THANHTOAN.SelectCongnoTTByDate(ngay)
    End Function
End Class