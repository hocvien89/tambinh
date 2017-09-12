Public Interface IQLCN_CONGNO_THANHTOANDA

    Function SelectAll(ByVal uId_Khachhang As String) As System.Collections.Generic.List(Of CM.QLCN_CONGNO_THANHTOANEntity)

	Function SelectAllTable(ByVal uId_Khachhang AS String) AS System.Data.DataTable

    Function SelectByID(ByVal uId_Congno_Thanhtoan As String) As CM.QLCN_CONGNO_THANHTOANEntity

    Function SelectByIDPTC(ByVal uId_Phieuthuchi As String) As CM.QLCN_CONGNO_THANHTOANEntity

    Function SelectByIDPDV(ByVal uId_Phieudichvu As String) As System.Data.DataTable

    Function Insert(ByVal obj As CM.QLCN_CONGNO_THANHTOANEntity) As String

	Function DeleteByID(ByVal uId_Congno_Thanhtoan AS String) AS Boolean

    Function Update(ByVal obj As CM.QLCN_CONGNO_THANHTOANEntity) As Boolean

    Function SelectByID_PDV(ByVal uId_Phieudichvu As String) As System.Data.DataTable

    Function SelectCongnoTTByDate(ngay As Date) As DataTable

End Interface