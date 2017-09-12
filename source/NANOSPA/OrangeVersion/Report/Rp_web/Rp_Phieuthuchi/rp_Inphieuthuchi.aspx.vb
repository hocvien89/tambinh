Public Class Rp_Inphieuthuchi
    Inherits System.Web.UI.Page
    Private Rp As Xtr_Inphieuthuchi
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        loadRp()
    End Sub
    Private Sub loadRp()
        Rp = New Xtr_Inphieuthuchi
        Rp.Bindata(Session("uId_Phieuthuchi").ToString, Session("nv_Tencuahang_vn"), Session("nv_DiachiCH_vn"))
        ReportViewerControl.ReportViewer.Report = Rp
    End Sub
End Class