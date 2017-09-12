Public Class rp_Baocao_Dichvu_Tonghop
    Inherits System.Web.UI.Page
    Dim objFcKhachhang As BO.clsB_BaoCao_Khachhang
    Dim BC As Xtr_Baocao_Dichvu_Tonghop

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            loadTime()
        End If
        loadData()
    End Sub
    Public Sub loadTime()
        Aspx_Denngay.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
        Aspx_Tungay.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
    End Sub
    Public Sub loadData()
        objFcKhachhang = New BO.clsB_BaoCao_Khachhang
        BC = New Xtr_Baocao_Dichvu_Tonghop
        BC.lbl_Tencuahang.Text = Session("nv_Tencuahang_vn")
        BC.lbl_Diachi.Text = Session("nv_DiachiCH_vn")
        BC.lbl_Tungay.Text = Aspx_Tungay.Text
        BC.lbl_Denngay.Text = Aspx_Denngay.Text
        Dim dt As DataTable
        Dim d_Tungay As Date = BO.Util.ConvertDateTime(Aspx_Tungay.Text)
        Dim d_Denngay As Date = BO.Util.ConvertDateTime(Aspx_Denngay.Text)
        dt = objFcKhachhang.Baocao_Dichvu_Tonghop(d_Tungay, d_Denngay)
        BC.Bindata(dt)
        ReportViewer_BC.Report = BC
    End Sub

    Private Sub btn_Baocao_Click(sender As Object, e As EventArgs) Handles btn_Baocao.Click
        loadData()
    End Sub

    Private Sub btnback_Click(sender As Object, e As EventArgs) Handles btnback.Click
        Response.Redirect("../../../../OrangeVersion/Product/ReportForm_Sevice.aspx")
    End Sub
End Class