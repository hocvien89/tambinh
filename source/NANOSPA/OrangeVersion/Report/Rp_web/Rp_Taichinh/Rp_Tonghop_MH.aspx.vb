Public Class Rp_Tonghop_MH
    Inherits System.Web.UI.Page
    Private BC As New Xtr_Tonghop_MH
    Private objFCQLMH As New BO.QLMH_PHIEUXUATFacade
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LoadTime()
        End If
        loaddata()
    End Sub

    Private Sub LoadTime()
        Aspx_Denngay.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
        Aspx_Tungay.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
    End Sub
    Private Sub loaddata()
        Dim TuNgay As DateTime
        Dim DenNgay As DateTime
        Dim uId_cuahang, tencuahang, diachi As String
        Dim sFormat As System.Globalization.DateTimeFormatInfo = New System.Globalization.DateTimeFormatInfo()
        sFormat.ShortDatePattern = "dd/MM/yyyy"
        uId_cuahang = Session("uId_Cuahang")
        tencuahang = Session("nv_Tencuahang_vn")
        diachi = Session("nv_DiachiCH_vn")
        BC.lbl_Tungay.Text = Aspx_Tungay.Text
        BC.lbl_Denngay.Text = Aspx_Denngay.Text
        BC.lbl_Tencuahang.Text = tencuahang
        BC.lbl_diachi.Text = diachi
        If Aspx_Tungay.Text <> "" And Aspx_Denngay.Text <> "" Then
            TuNgay = Aspx_Tungay.Value.ToString
            DenNgay = Aspx_Denngay.Value.ToString
        End If
        Dim dt As New DataTable
        dt = objFCQLMH.BaoCaoDoanhThuTongHopSP(TuNgay, DenNgay, uId_cuahang)
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1 Step 1
                If dt.Rows(i)("tienmat").ToString = "" Then
                    dt.Rows(i)("tienmat") = 0
                End If
                If dt.Rows(i)("chuyenkhoan").ToString = "" Then
                    dt.Rows(i)("chuyenkhoan") = 0
                End If
                If dt.Rows(i)("ttkhac").ToString = "" Then
                    dt.Rows(i)("ttkhac") = 0
                End If
            Next
        End If
        BC.binding(dt)
        ReportViewer1.Report = BC
        'Dispose
        dt = Nothing
    End Sub
    Private Sub Aspx_Baocao_Click(sender As Object, e As EventArgs) Handles Aspx_Baocao.Click
        loaddata()
    End Sub

    Private Sub btnback_Click(sender As Object, e As EventArgs) Handles btnback.Click
        Response.Redirect("../../../../OrangeVersion/Finance/ReportForm_Finance.aspx")
    End Sub
End Class