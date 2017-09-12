Public Class Rp_Indonthuoc
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Loadrp()
    End Sub

    Private Sub Loadrp()
        Dim rp As New Xtr_Indonthuoc
        Dim objEnPhieuxuat As New CM.QLMH_PHIEUXUATEntity
        Dim objFcthamso As New BO.clsB_QT_THAMSOHETHONG
        Dim objFcPhieuxuat As New BO.QLMH_PHIEUXUATFacade
        objEnPhieuxuat = objFcPhieuxuat.SelectByID(Session("uId_Phieuxuat"))
        Dim objEnKhachhang As New CM.CRM_DM_KhachhangEntity
        Dim objFcKhachhang As New BO.CRM_DM_KhachhangFacade
        Dim objFcNghe As New BO.CRM_DM_NGUONFacade
        Dim objFcNhanvien As New BO.QT_DM_NHANVIENFacade
        Dim objFcPhong As New BO.QLP_DM_PHONGFacade
        objEnKhachhang = objFcKhachhang.SelectByID(objEnPhieuxuat.uId_Khachhang)
        rp.tblCelTen.Text = objEnKhachhang.nv_Hoten_vn
        rp.tblCelTuoi.Text = DateDiff(DateInterval.Year, objEnKhachhang.d_Ngaysinh, Date.Now).ToString
        rp.tblCelDiachi.Text = objEnKhachhang.nv_Diachi_vn
        rp.tblCelNghenghiep.Text = objFcNghe.SelectByID(objEnKhachhang.uId_Nghenghiep).nv_Nguon_vn.ToString
        rp.lblCuahang.Text = Session("nv_Tencuahang_vn").ToString
        rp.lblDiachicuahang.Text = Session("nv_DiachiCH_vn").ToString
        rp.lblNgay.Text = "Ngày " + Date.Now.Day.ToString + " tháng " + Date.Now.Month.ToString + " năm " + Date.Now.Year.ToString
        rp.lblThaythuoc.Text = objFcNhanvien.SelectByID(Session("uId_Nhanvien_Dangnhap")).nv_Hoten_vn
        rp.XrPictureBox_logo.ImageUrl = objFcthamso.SelectTHAMSOHETHONGByID("vLogo").v_Giatri
        rp.lblMaphieu.Text = "Số: " + objEnPhieuxuat.v_Maphieuxuat
        If objEnPhieuxuat.uId_Phieuxuat <> Nothing Then
            rp.lbltien.Text = "Đơn giá 1 thang: " + String.Format("{0:#,##0}", objEnPhieuxuat.f_Gia.ToString) + "- Số thang: " + objEnPhieuxuat.i_Soluog.ToString + "VNĐ - Thành tiền: " + String.Format("{0:#,##0}", (objEnPhieuxuat.i_Soluog * objEnPhieuxuat.f_Gia).ToString) + "VNĐ"
        Else
            rp.lbltien.Text = ""
        End If
        rp.lblNguoilap.Text = "Kế toán"
        rp.lblhuongdan.Visible = False
        rp.tblhuongdan.Visible = False
        Dim dt As DataTable
        dt = objFcPhieuxuat.SelectDonthuoc(Session("uId_Phieuxuat"))
        rp.Loaddata(dt)
        ReportViewerControl.ReportViewer.Report = rp
        objEnPhieuxuat = Nothing
        objEnKhachhang = Nothing
        objFcKhachhang = Nothing
        objFcPhieuxuat = Nothing
        objFcNghe = Nothing
        objFcNhanvien = Nothing
        objFcPhong = Nothing
        objFcthamso = Nothing
    End Sub
End Class