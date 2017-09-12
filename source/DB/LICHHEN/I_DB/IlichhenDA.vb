Public Interface IlichhenDA
    Function SelectAllTable(ByVal uId_Cuahang As String) As System.Data.DataTable

    Function SelectbyDateS(ByVal ngay As String, ByVal uId_Cuahang As String) As System.Data.DataTable

    Function SelectDate(ByVal strStartdate As String, ByVal strEnddate As String, ByVal uId_Cuahang As String) As System.Data.DataTable

    Function SelectDatePhong(ByVal strStartdate As String, ByVal strEnddate As String, ByVal uId_Cuahang As String) As System.Data.DataTable

    Function SelectThongke(ByVal strStartdate As String, ByVal strEnddate As String) As System.Data.DataTable
End Interface
