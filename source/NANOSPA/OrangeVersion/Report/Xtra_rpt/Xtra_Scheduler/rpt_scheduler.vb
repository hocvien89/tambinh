Public Class rpt_scheduler
    Dim objFcAppoint As BO.AppointmentsFacade
    Public Sub BindData(ByVal uId_Cuahang As String, ByVal TuNgay As String, ByVal DenNgay As String, ByVal nv_Tencuahang_vn As String, ByVal nv_Diachicuahang As String, ByVal Trangthai As Integer, nv_Tenkhachhang_vn As String, uId_Phong As String)
        objFcAppoint = New BO.AppointmentsFacade
        Dim dt As DataTable
        dt = objFcAppoint.SelectByDate(BO.Util.ConvertDateTime(TuNgay), BO.Util.ConvertDateTime(DenNgay), uId_Cuahang, Trangthai, nv_Tenkhachhang_vn, uId_Phong)
        For i As Integer = 0 To dt.Rows.Count - 1
            dt.Rows(i)("StartDate") = BO.Util.FormatDateTime(dt.Rows(i)("StartDate"))
            dt.Rows(i)("EndDate") = BO.Util.FormatDateTime(dt.Rows(i)("EndDate"))
        Next
        If dt.Rows.Count > 0 Then
            BindingSource1.DataSource = dt
            dt.Dispose()
        End If
        lblSpaName.Text = nv_Tencuahang_vn
        lblSpaAddress.Text = nv_Diachicuahang
        lblNgaylap.Text = "Ngày lập: " & DateTime.Now.ToString("dd/MM/yyyy")
        lblTungay.Text = TuNgay
        lblDenngay.Text = DenNgay
    End Sub
End Class