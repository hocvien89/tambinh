Public Interface ITNTP_KHACHHANG_THEDA

    Function SelectAll() As System.Collections.Generic.List(Of CM.TNTP_KHACHHANG_THEEntity)

    Function SelectAllKH_KM(ByVal uId_Khachhang As String, ByVal v_MaKM As String) As System.Data.DataTable

    Function SelectTheKHTichluy(ByVal uId_Khachhang As String, ByVal v_MaKM As String) As System.Data.DataTable

    Function SelectAllTable(ByVal uId_Khachhang As String, ByVal DK As Int32) As System.Data.DataTable

    Function SelectAllTable(ByVal uId_Cuahang As String) As System.Data.DataTable

    Function SelectByID(ByVal uId_The As String) As CM.TNTP_KHACHHANG_THEEntity

    Function Insert(ByVal obj As CM.TNTP_KHACHHANG_THEEntity) As String

	Function DeleteByID(ByVal uId_The AS String) AS Boolean

    Function Update(ByVal obj As CM.TNTP_KHACHHANG_THEEntity) As Boolean

    Function ThanhToan(ByVal obj As CM.TNTP_KHACHHANG_THEEntity) As Boolean


    Function SelectAllTable_DS_TheHetHan(ByVal DK As Int32) As System.Data.DataTable
End Interface