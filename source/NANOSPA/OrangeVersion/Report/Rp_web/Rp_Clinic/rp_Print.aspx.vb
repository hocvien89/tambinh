Public Class rp_Print
    Inherits System.Web.UI.Page
    Dim objFCThamso As New BO.clsB_QT_THAMSOHETHONG
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim type As String
        type = Request.QueryString("type")
        If type = "phieukham" Then
            LoadPhieuKham()
        ElseIf type = "donthuoc" Then
            LoadDonThuoc()
        ElseIf type = "dieutri" Then
            LoadDieuTri()
        End If
    End Sub

    Private Sub LoadPhieuKham()
        Dim uId_Khachang, uId_Phieudichvu As String
        Dim public_class As New Public_Class
        Dim rp As New Xtr_PhieuKhamBenh
        Dim objEnKhachhang As New CM.CRM_DM_KhachhangEntity
        Dim objFcKhachhang As New BO.CRM_DM_KhachhangFacade
        Dim objFCPhieudichvu As New BO.TNTP_PHIEUDICHVUFacade
        Dim objEnPhieudichvu As New CM.TNTP_PHIEUDICHVUEntity
        Dim datenow As DateTime = Date.Now
        uId_Khachang = Session("uId_Khachhang")
        uId_Phieudichvu = Session("uId_PhieuDichVu")
        objEnKhachhang = objFcKhachhang.SelectByID(uId_Khachang)
        rp.lblTencuahang.Html = Session("nv_Tencuahang_en")
        rp.lblDiachi.Html = Session("nv_DiachiCH_en")
        rp.lblSdt.Text = "SĐT: " + Session("nv_Dienthoai")
        rp.cellHoten.Text = objEnKhachhang.nv_Hoten_vn
        rp.cellDiaChi.Text = objEnKhachhang.nv_Diachi_vn
        rp.cellDienThoai.Text = objEnKhachhang.v_DienthoaiDD
        rp.cellGioiTinh.Text = IIf(objEnKhachhang.b_Gioitinh = True, "Nam", "Nữ")
        rp.cellTuoi.Text = public_class.GetTuoiByNamSinh(objEnKhachhang.d_Ngaysinh.Year)
        If (String.IsNullOrEmpty(uId_Phieudichvu) = False) Then
            objEnPhieudichvu = objFCPhieudichvu.SelectByID(uId_Phieudichvu)
            rp.cellLyDoKham.Text = objEnPhieudichvu.nv_Ghichu_vn
            rp.lblPhikham.Text = String.Format("{0:#,##0}", Val(objEnPhieudichvu.f_Tongtienthuc)) + " đ"
        End If
        rp.lblNgayThang.Text = "Ngày " + datenow.Day.ToString() + " Tháng " + datenow.Month.ToString() + " Năm " + datenow.Year.ToString()
        rp.XrPictureBox_logo.ImageUrl = "~" + objFCThamso.SelectTHAMSOHETHONGByID("vLogo").v_Giatri.ToString()
        ReportViewerControl.ReportViewer.Report = rp
    End Sub
    Private Sub LoadDonThuoc()
        Dim uId_Khachang As String
        Dim public_class As New Public_Class
        Dim rp As New Xtr_DonThuoc
        Dim objEnKhachhang As New CM.CRM_DM_KhachhangEntity
        Dim objFcKhachhang As New BO.CRM_DM_KhachhangFacade
        Dim objFcPhieuxuat As New BO.QLMH_PHIEUXUATFacade
        Dim dt As New DataTable
        Dim datenow As DateTime = Date.Now
        uId_Khachang = Session("uId_Khachhang")
        objEnKhachhang = objFcKhachhang.SelectByID(uId_Khachang)
        rp.lblTencuahang.Html = Session("nv_Tencuahang_en")
        rp.lblDiachi.Html = Session("nv_DiachiCH_en")
        rp.lblSdt.Text = "SĐT: " + Session("nv_Dienthoai")
        rp.cellHoten.Text = objEnKhachhang.nv_Hoten_vn
        rp.cellDiachi.Text = objEnKhachhang.nv_Diachi_vn
        rp.cellDienthoai.Text = objEnKhachhang.v_DienthoaiDD
        rp.cellGioiTinh.Text = IIf(objEnKhachhang.b_Gioitinh = True, "Nam", "Nữ")
        rp.cellTuoi.Text = public_class.GetTuoiByNamSinh(objEnKhachhang.d_Ngaysinh.Year)
        rp.lblNgayThang.Text = "Ngày " + datenow.Day.ToString() + " Tháng " + datenow.Month.ToString() + " Năm " + datenow.Year.ToString()
        dt = objFcPhieuxuat.SelectByID_QLMH_PHIEUXUAT_CHITIET(Session("uId_Phieuxuat").ToString())
        rp.xtrlogo.ImageUrl = "~" + objFCThamso.SelectTHAMSOHETHONGByID("vLogo").v_Giatri.ToString()
        rp.BindingSource1.DataSource = dt
        ReportViewerControl.ReportViewer.Report = rp
    End Sub
    Private Sub LoadDieuTri()
        Dim uId_Khachang As String
        Dim public_class As New Public_Class
        Dim rp As New Xtr_PhieuDieuTri
        Dim objEnKhachhang As New CM.CRM_DM_KhachhangEntity
        Dim objFcKhachhang As New BO.CRM_DM_KhachhangFacade
        Dim datenow As DateTime = Date.Now
        uId_Khachang = Session("uId_Khachhang")
        objEnKhachhang = objFcKhachhang.SelectByID(uId_Khachang)
        rp.lblTencuahang.Html = Session("nv_Tencuahang_en")
        rp.lblDiachi.Html = Session("nv_DiachiCH_en")
        rp.lblSdt.Text = "SĐT: " + Session("nv_Dienthoai")
        rp.cellHoten.Text = objEnKhachhang.nv_Hoten_vn
        rp.cellDiaChi.Text = objEnKhachhang.nv_Diachi_vn
        rp.cellDienThoai.Text = objEnKhachhang.v_DienthoaiDD
        rp.cellGioiTinh.Text = IIf(objEnKhachhang.b_Gioitinh = True, "Nam", "Nữ")
        rp.cellTuoi.Text = public_class.GetTuoiByNamSinh(objEnKhachhang.d_Ngaysinh.Year)
        rp.xtrlogo.ImageUrl = "~" + objFCThamso.SelectTHAMSOHETHONGByID("vLogo").v_Giatri.ToString()
        rp.lblNgayThang.Text = "Ngày " + datenow.Day.ToString() + " Tháng " + datenow.Month.ToString() + " Năm " + datenow.Year.ToString()
        ReportViewerControl.ReportViewer.Report = rp
    End Sub

End Class