Public Interface iclsD_QLTC_PhieuthuchiDA

    Function SelectAll() As List(Of CM.QLTC_PhieuthuchiEntity)

    Function SelectAllTable(ByVal uId_Thuchi As String, ByVal v_NguonThanhtoan As String) As System.Data.DataTable

    Function ThuChiKH(ByVal uId_Khachhang As String) As String

    Function SelectByDMThuchi(ByVal uId_Thuchi As String, ByVal strTungay As String, ByVal strDenngay As String) As System.Data.DataTable

    Function SelectAllCongno(ByVal strTungay As DateTime, ByVal strDenngay As DateTime) As System.Data.DataTable

    Function SelectByID(ByVal uId_Phieuthuchi As String) As CM.QLTC_PhieuthuchiEntity

    Function Insert(ByVal obj As CM.QLTC_PhieuthuchiEntity) As String

    Function DeleteByID(ByVal uId_Phieuthuchi As String) As Boolean

    Function Update(ByVal obj As CM.QLTC_PhieuthuchiEntity) As Boolean
    'hieutx using create code
    Function GetMaMaxBydate(uId_Cuahang As String, ddate As Date, sLoai As String) As String
    'hieutx using in hoa don tong hop
    Function InHoadonTonghop(uId_Khachhang As String, uId_Phieuxuat As String, uId_Phieudichvu As String) As DataTable
End Interface
