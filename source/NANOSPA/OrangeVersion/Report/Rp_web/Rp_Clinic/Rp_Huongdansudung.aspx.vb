Public Class Rp_Huongdansudung
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim rp As New Xtr_Huongdansudung
        ReportViewerControl.ReportViewer.Report = rp
    End Sub
End Class