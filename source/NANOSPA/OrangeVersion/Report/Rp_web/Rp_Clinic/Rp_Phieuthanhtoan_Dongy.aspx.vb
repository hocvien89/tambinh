Public Class Rp_Phieuthanhtoan_Dongy
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Loadrp()
    End Sub
    Private Sub Loadrp()
        Dim rp As New Xtr_Inhoadon_Dongy
        Dim datenow As DateTime = Date.Now
        Dim objEnPhieuxuat As New CM.QLMH_PHIEUXUATEntity
        Dim objFcPhieuxuat As New BO.QLMH_PHIEUXUATFacade
        objEnPhieuxuat = objFcPhieuxuat.SelectByID(Session("uId_Phieuxuat"))
        Dim objEnKhachhang As New CM.CRM_DM_KhachhangEntity
        Dim objFcKhachhang As New BO.CRM_DM_KhachhangFacade
        Dim objFcPhong As New BO.QLP_DM_PHONGFacade
        Dim objFCthamsohethong As New BO.clsB_QT_THAMSOHETHONG
        objEnKhachhang = objFcKhachhang.SelectByID(objEnPhieuxuat.uId_Khachhang)
        rp.lblbenhnhan.Text = objEnKhachhang.nv_Hoten_vn
        rp.lblTuoi.Text = DateDiff(DateInterval.Year, objEnKhachhang.d_Ngaysinh, Date.Now).ToString
        rp.lblDiachiKD.Text = objEnKhachhang.nv_Diachi_vn
        rp.lblDienthoai.Text = objEnKhachhang.v_DienthoaiDD
        rp.lblTencuahang.Html = Session("nv_Tencuahang_en")
        rp.lblDiachi.Html = Session("nv_DiachiCH_en")
        rp.lblSdt.Text = "SĐT: " + Session("nv_Dienthoai")
        rp.xtrlogo.ImageUrl = "~" + objFCthamsohethong.SelectTHAMSOHETHONGByID("vLogo").v_Giatri.ToString()
        rp.lblNgay.Text = "Ngày " + datenow.Day.ToString() + " Tháng " + datenow.Month.ToString() + " Năm " + datenow.Year.ToString()
        If objEnPhieuxuat.uId_Phieuxuat <> Nothing Then
            rp.lblSothang.Text = objEnPhieuxuat.i_Soluog.ToString + " " + "thang"
            rp.lblTongtien.Text = String.Format("{0:#,##0}", Val(objEnPhieuxuat.i_Soluog * objEnPhieuxuat.f_Gia)) + " đ"
        Else
            rp.lblTongtien.Text = ""
        End If
        ReportViewerControl.ReportViewer.Report = rp
        objEnPhieuxuat = Nothing
        objEnKhachhang = Nothing
        objFcKhachhang = Nothing
        objFcPhieuxuat = Nothing
    End Sub
End Class