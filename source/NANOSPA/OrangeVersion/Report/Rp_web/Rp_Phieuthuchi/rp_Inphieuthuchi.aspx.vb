Public Class Rp_Inphieuthuchi
    Inherits System.Web.UI.Page
    Private Rp As Xtr_Inphieuthuchi
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        loadRp()
    End Sub
    Private Sub loadRp()
        Rp = New Xtr_Inphieuthuchi
        Rp.lblTencuahang.Html = Session("nv_Tencuahang_en")
        Rp.lblDiachi.Html = Session("nv_DiachiCH_en")
        Rp.lblSdt.Text = "SĐT: " + Session("nv_Dienthoai")
        Rp.Bindata(Session("uId_Phieuthuchi").ToString)
        ReportViewerControl.ReportViewer.Report = Rp
    End Sub
End Class