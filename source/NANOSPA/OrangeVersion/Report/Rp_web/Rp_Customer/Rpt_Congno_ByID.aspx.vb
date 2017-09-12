Public Class Rpt_Congno_ByID
    Inherits System.Web.UI.Page
    Private objFcBaocaoKH As BO.clsB_BaoCao_Khachhang
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

        End If
        Loaddata()
    End Sub

    Private Sub Loaddata()
        objFcBaocaoKH = New BO.clsB_BaoCao_Khachhang
        Dim dt As DataTable
        Dim BC = New Xtr_Incongno_ByID
        dt = objFcBaocaoKH.CongnoKH_ByID("8/8/1992", DateTime.Now, "", Session("uId_Khachhang").ToString)
        BC.Bindata(dt)
        ReportViewerControl.ReportViewer.Report = BC
        BC.txt_Ngaylap.Text = DateTime.Now
        BC.txt_Tennhanvien.Text = Session("sTendangnhap").ToString


    End Sub
End Class