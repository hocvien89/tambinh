Public Partial Class RP_Tonghop_DV
    Inherits System.Web.UI.Page
    Dim obj As New BO.KHQT_KHACHHANG_USERFacade

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            loadTime()
        End If
        loaddata()
    End Sub
    Private Sub loaddata()
        Dim dt As DataTable
        Dim tungay, denngay As DateTime
        Dim objFCThamsohethong As New BO.clsB_QT_THAMSOHETHONG
        Dim tencuahang, diachi, uid_Cuahang As String
        Dim sFormat As System.Globalization.DateTimeFormatInfo = New System.Globalization.DateTimeFormatInfo()
        sFormat.ShortDatePattern = "dd/MM/yyyy"
        If Aspx_Tungay.Value.ToString <> "" And Aspx_Denngay.Value.ToString <> "" Then
            tungay = Aspx_Tungay.Value.ToString
            denngay = Aspx_Denngay.Value.ToString
        End If
        tencuahang = Session("nv_Tencuahang_en")
        diachi = Session("nv_DiachiCH_en")
        uid_Cuahang = Session("uId_Cuahang")

        dt = obj.BAOCAO_DoanhThuTongHop(tungay, denngay, uid_Cuahang)
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
        Dim rpt As New Xtr_Tonghop_DV
        rpt.binddata(dt)
        ReportViewer1.Report = rpt
        rpt.lblPKName.Html = tencuahang
        rpt.lblDiachi.Html = diachi
        rpt.lblSdt.Text = Session("nv_Dienthoai")
        rpt.XrPictureBox_logo.ImageUrl = "~" + objFCThamsohethong.SelectTHAMSOHETHONGByID("vLogo").v_Giatri.ToString()
        rpt.lbl_Tungay.Text = Aspx_Tungay.Text
        rpt.lbl_Denngay.Text = Aspx_Denngay.Text
        Dim Arplit() As String = Split(Strings.Format(DateAndTime.Now, "dd/MM/yyyy"))
        
    End Sub
    Private Sub loadTime()
        Aspx_Tungay.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
        Aspx_Denngay.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
    End Sub

    Private Sub btnback_Click(sender As Object, e As EventArgs) Handles btnback.Click
        Response.Redirect("../../../../OrangeVersion/Finance/ReportForm_Finance.aspx")
    End Sub

    Protected Sub ASPxCallbackPanel1_Callback(sender As Object, e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase)
        loaddata()
    End Sub
End Class