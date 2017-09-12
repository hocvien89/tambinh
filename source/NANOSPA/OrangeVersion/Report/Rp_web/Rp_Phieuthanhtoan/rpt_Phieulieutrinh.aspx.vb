Public Class rpt_Phieulieutrinh
    Inherits System.Web.UI.Page
    Private objFcDieutri As BO.TNTP_QT_DieutriFacade
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

        End If
        Loaddata()
    End Sub
    Private Sub Loaddata()
        objFcDieutri = New BO.TNTP_QT_DieutriFacade
        Dim dt As DataTable = objFcDieutri.Inphieulieutrinh(Session("uId_QT_Dieutri"))
        Dim BC As New Xtr_Lieutrinh
        BC.BindingSource1.DataSource = dt
        BC.lbcuahang.Text = Session("nv_Tencuahang_vn").ToString
        BC.lbdiachi.Text = Session("nv_DiachiCH_vn").ToString
        BC.lbngayin.Text = Now.Date
        ReportViewerControl.ReportViewer.Report = BC
    End Sub
End Class