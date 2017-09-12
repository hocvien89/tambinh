Public Class rpt_Phieunhapsp
    Inherits System.Web.UI.Page
    Private objFcPhieunhap As BO.clsB_Phieunhap
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

        End If
        loaddata()
    End Sub
    Private Sub loaddata()
        objFcPhieunhap = New BO.clsB_Phieunhap
        Dim BC = New Xtr_InphieunhapByID
        Dim dt As DataTable
        dt = objFcPhieunhap.InPhieunhap_ByID(Session("uId_Phieunhap").ToString)
        If dt.Rows.Count > 0 Then
            BC.Binddata(dt)
        End If

        ReportViewerControl.ReportViewer.Report = BC
        BC.txtcuahang.Text = Session("nv_Tencuahang_vn").ToString
        BC.txtmaphieu.Text = dt.Rows(0)("v_Maphieunhap").ToString
        BC.txtngaylap.Text = DateTime.Now
    End Sub
End Class