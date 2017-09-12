
Public Class NHATKYSUDUNGFacade

    Dim INHATKYSUDUNG As DB.INHATKYSUDUNGDA = New DB.NHATKYSUDUNGDA
    Dim objEnNhatKySuDung As New CM.NHATKYSUDUNGEntity
    Public Function SelectAllTable(ByVal TuNgay As Date, ByVal DenNgay As Date, ByVal key As String) As System.Data.DataTable
        Return INHATKYSUDUNG.SelectAllTable(TuNgay, DenNgay, key)
    End Function

    Public Function Insert(ByVal obj As CM.NHATKYSUDUNGEntity) As Boolean
        Return INHATKYSUDUNG.Insert(obj)
    End Function

    Public Sub Write(ByVal TenDangNhap As String, ByVal IP As String, ByVal hanhdong As String)
        objEnNhatKySuDung.Tendangnhap = TenDangNhap
        objEnNhatKySuDung.IP = IP
        objEnNhatKySuDung.hanhdong = hanhdong
        Try
            Insert(objEnNhatKySuDung)
        Catch ex As Exception

        End Try
    End Sub
End Class