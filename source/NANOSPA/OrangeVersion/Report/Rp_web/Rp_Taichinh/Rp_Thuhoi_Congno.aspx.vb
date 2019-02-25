Public Class Rp_Thuhoi_Congno
    Inherits System.Web.UI.Page
    Private objEnPhieuthuchi As CM.QLTC_PhieuthuchiEntity
    Private objFcPhieuthuchi As BO.QLTC_PhieuthuchiFacade
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            loadTime()
        End If
        loaddata()
    End Sub
#Region " dữ liệu"
    Private Sub loaddata()
        objFcPhieuthuchi = New BO.QLTC_PhieuthuchiFacade
        Dim objFCThamsohethong As New BO.clsB_QT_THAMSOHETHONG
        Dim dt As DataTable
        Dim tungay As DateTime
        Dim denngay As DateTime
        If Aspx_Tungay.Text <> "" And Aspx_Denngay.Text <> "" Then
            tungay = Aspx_Tungay.Value.ToString
            denngay = Aspx_Denngay.Value.ToString
        End If
        dt = objFcPhieuthuchi.SelectAllCongno(tungay, denngay)
        Dim xtra As New Xtr_Thuhoi_Congno
            xtra.Bind(dt)
            ReportViewer1.Report = xtra
        xtra.lbl_Tungay.Text = Aspx_Tungay.Text
        xtra.lbl_Denngay.Text = Aspx_Denngay.Text
        Dim objEnCuahang As New CM.QT_DM_CUAHANGEntity
        Dim objFcCuahang As New BO.QT_DM_CUAHANGFacade
        objEnCuahang = objFcCuahang.SelectByIDCuahang(Session("uId_Cuahang"))
        xtra.lblPKName.Html = objEnCuahang.nv_Tencuahang_en
        xtra.lblDiachi.Html = objEnCuahang.nv_Diachi_en
        xtra.lblSdt.Text = "SĐT: "+ objEnCuahang.nv_Dienthoai
        xtra.XrPictureBox_logo.ImageUrl = objFCThamsohethong.SelectTHAMSOHETHONGByID("vLogo").v_Giatri.ToString()
        Dim datenow As DateTime = Date.Now
        xtra.lblNgay.Text = "Ngày " & datenow.Day.ToString() & " tháng " & datenow.Month.ToString() & " năm " & datenow.Year.ToString
    End Sub

    Private Sub loadTime()
        Aspx_Denngay.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
        Aspx_Tungay.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
    End Sub
#End Region

    Private Sub btn_Baocao_Click(sender As Object, e As EventArgs) Handles btn_Baocao.Click
        loaddata()
    End Sub

    Private Sub btnback_Click(sender As Object, e As EventArgs) Handles btnback.Click
        Response.Redirect("../../../../OrangeVersion/Finance/ReportForm_Finance.aspx")
    End Sub
End Class