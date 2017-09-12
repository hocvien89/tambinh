Public Class QLTC_PhieuthuchiFacade

    Dim IQLTC_Phieuthuchi As DB.iclsD_QLTC_PhieuthuchiDA = New DB.clsD_QLTC_PhieuthuchiDA

    Public Function SelectAll() As List(Of CM.QLTC_PhieuthuchiEntity)
        Return IQLTC_Phieuthuchi.SelectAll()
    End Function
    Public Function SelectByDMThuchi(ByVal uId_Thuchi As String, ByVal strTungay As String, ByVal strDenngay As String) As System.Data.DataTable
        Return IQLTC_Phieuthuchi.SelectByDMThuchi(uId_Thuchi, strTungay, strDenngay)
    End Function
    Public Function SelectAllTable(ByVal uId_Thuchi As String, ByVal v_NguonThanhtoan As String) As System.Data.DataTable
        Return IQLTC_Phieuthuchi.SelectAllTable(uId_Thuchi, v_NguonThanhtoan)
    End Function

    Public Function SelectAllCongno(ByVal strTungay As DateTime, ByVal strDenngay As DateTime) As System.Data.DataTable
        Return IQLTC_Phieuthuchi.SelectAllCongno(strTungay, strDenngay)
    End Function

    Public Function Insert(ByVal obj As CM.QLTC_PhieuthuchiEntity) As String
        Return IQLTC_Phieuthuchi.Insert(obj)
    End Function

    Public Function Update(ByVal obj As CM.QLTC_PhieuthuchiEntity) As Boolean
        Return IQLTC_Phieuthuchi.Update(obj)
    End Function

    Public Function DeleteByID(ByVal uId_Phieuthuchi As String) As Boolean
        Return IQLTC_Phieuthuchi.DeleteByID(uId_Phieuthuchi)
    End Function

    Public Function SelectByID(ByVal uId_Phieuthuchi As String) As CM.QLTC_PhieuthuchiEntity
        Return IQLTC_Phieuthuchi.SelectByID(uId_Phieuthuchi)
    End Function

    Public Function ThuChiKH(ByVal uId_Khachhang As String) As String
        Return IQLTC_Phieuthuchi.ThuChiKH(uId_Khachhang)
    End Function

    Public Function GetMaMaxBydate(uId_Cuahang As String, ddate As Date, sLoai As String) As String
        Return IQLTC_Phieuthuchi.GetMaMaxBydate(uId_Cuahang, ddate, sLoai)
    End Function

    Public Function InHoadonTonghop(uId_Khachhang As String, uId_Phieuxuat As String, uId_Phieudichvu As String) As DataTable
        Return IQLTC_Phieuthuchi.InHoadonTonghop(uId_Khachhang, uId_Phieuxuat, uId_Phieudichvu)
    End Function
End Class