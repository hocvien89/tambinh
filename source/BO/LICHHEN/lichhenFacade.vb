Public Class lichhenFacade
    Dim Ilichhen As DB.IlichhenDA = New DB.lichhenDA

    Public Function SelectDate(ByVal strStartdate As String, ByVal strEnddate As String, ByVal uId_Cuahang As String) As System.Data.DataTable
        Return Ilichhen.SelectDate(strStartdate, strEnddate, uId_Cuahang)
    End Function

    Public Function SelectDatePhong(ByVal strStartdate As String, ByVal strEnddate As String, ByVal uId_Cuahang As String) As System.Data.DataTable
        Return Ilichhen.SelectDatePhong(strStartdate, strEnddate, uId_Cuahang)
    End Function
    Public Function SelectAllTable(ByVal uId_Cuahang As String) As System.Data.DataTable
        Return Ilichhen.SelectAllTable(uId_Cuahang)
    End Function
    Public Function SelectbyDateS(ByVal ngay As String, ByVal uId_Cuahang As String) As System.Data.DataTable
        Return Ilichhen.SelectbyDateS(ngay, uId_Cuahang)
    End Function
    Public Function SelectThongke(ByVal strStartdate As String, ByVal strEnddate As String) As System.Data.DataTable
        Return Ilichhen.SelectThongke(strStartdate, strEnddate)
    End Function
End Class
