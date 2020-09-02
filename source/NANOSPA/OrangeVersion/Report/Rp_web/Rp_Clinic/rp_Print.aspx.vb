Public Class rp_Print
    Inherits System.Web.UI.Page
    Dim objFCThamso As New BO.clsB_QT_THAMSOHETHONG
    Dim Ngayhen
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim type As String
        type = Request.QueryString("type")
        Select Case type
            Case "phieukham"
                LoadPhieuKham()
            Case ""
                Ngayhen = Request.QueryString("Ngayhen")
                LoadDonThuoc()
            Case "donthuoc"
                LoadDieuTri()
            Case "phieuthudichvu"
                loadPhieuThuDichVu()
            Case "phieuthudonthuoc"
                loadPhieuThuDonThuoc()

        End Select
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
        rp.lblTencuahang.Text = Session("nv_Tencuahang_en")
        rp.lblDiachi.Html = Session("nv_DiachiCH_en")
        rp.lblSdt.Text = "SĐT: " + Session("nv_Dienthoai")
        rp.lblTenkhachhang.Text = objEnKhachhang.nv_Hoten_vn
        rp.lblDiachiKH.Text = objEnKhachhang.nv_Diachi_vn
        rp.lblChandoan.Text = objEnKhachhang.nv_Diachi_en
        rp.lblDienthoai.Text = objEnKhachhang.v_DienthoaiDD
        rp.lblMaKhachHang.Text = "Mã: " + objEnKhachhang.v_Makhachang
        rp.lblNamsinh.Text = public_class.GetTuoiByNamSinh(objEnKhachhang.d_Ngaysinh.Year).ToString() + " (" + objEnKhachhang.d_Ngaysinh.Year.ToString() + ")" + " (" + IIf(objEnKhachhang.b_Gioitinh = True, "Nam", "Nữ") + ")"
        rp.lblNgayThang.Text = "Ngày " + datenow.Day.ToString() + " Tháng " + datenow.Month.ToString() + " Năm " + datenow.Year.ToString()
        dt = objFcPhieuxuat.SelectByID_QLMH_PHIEUXUAT_CHITIET(Session("uId_Phieuxuat").ToString())
        Dim dateNgayhen = Ngayhen
        If dateNgayhen.ToString() <> "" Then
            'Dim dateNgayhen As Date = New Date(strNgayhen)
            rp.lblNgayhen.Text = "Ngày " + dateNgayhen.Substring(0, 2) + " Tháng " + dateNgayhen.Substring(3, 2) + " Năm " + dateNgayhen.Substring(6, 4)
        Else
            rp.lblNgayhen.Text = "Ngày   Tháng   Năm"
        End If
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
    Public Sub loadPhieuThuDichVu()
        Dim datenow As DateTime = Date.Now
        Dim uId_Khachang As String
        Dim objEnKhachhang As New CM.CRM_DM_KhachhangEntity
        Dim objFcKhachhang As New BO.CRM_DM_KhachhangFacade
        Dim objEnNhanvien As New CM.QT_DM_NHANVIENEntity
        Dim objFcNhanvien As New BO.QT_DM_NHANVIENFacade
        Dim objEnPhieuDichvu As New CM.TNTP_PHIEUDICHVUEntity
        Dim objFcPhieudichvu As New BO.TNTP_PHIEUDICHVUFacade
        Dim objEnPhieuDichVuChiTiet As New BO.TNTP_PHIEUDICHVU_CHITIETFacade
        Dim objFcLoaiThanhToan As New BO.QLTC_LoaiHinhTTFacade
        Dim rp As New rpt_phieuthu_scc
        uId_Khachang = Session("uId_Khachhang")
        objEnKhachhang = objFcKhachhang.SelectByID(uId_Khachang)
        rp.lblNgaythu.Text = "Ngày " + datenow.Day.ToString() + " Tháng " + datenow.Month.ToString() + " Năm " + datenow.Year.ToString()
        rp.lblTencuahang.Html = Session("nv_Tencuahang_en")
        rp.lblDiachi.Html = Session("nv_DiachiCH_en")
        rp.lblSdt.Text = Session("nv_Dienthoai")
        rp.lblHotenNguoiNop.Text = objEnKhachhang.nv_Hoten_vn
        rp.lblDienthoai.Text = "Điện thoại: " + objEnKhachhang.v_DienthoaiDD
        objEnNhanvien = objFcNhanvien.SelectByID(Session("uId_Nhanvien_Dangnhap"))
        objEnPhieuDichvu = objFcPhieudichvu.SelectByID(Session("uId_Phieudichvu"))
        Dim tblDataDichvu As DataTable
        tblDataDichvu = objEnPhieuDichVuChiTiet.SelectByID(Session("uId_Phieudichvu"))
        Dim strDichvu As String
        strDichvu = ""
        Dim i As Integer = 0
        If tblDataDichvu.Rows.Count > 0 Then
            For Each row As DataRow In tblDataDichvu.Rows
                If i = 0 Then
                    strDichvu += row("nv_Tendichvu_vn").ToString()
                Else
                    strDichvu = strDichvu + " + " + row("nv_Tendichvu_vn").ToString()
                End If
                i += 1
            Next
        End If
        rp.lblNoidung.Text = strDichvu
        rp.lblHinhthuc.Text = objFcLoaiThanhToan.SelectByID(objEnPhieuDichvu.uId_LoaiTT).nv_TenLoaiTT.ToString()
        rp.lblTongtien.Text = String.Format("{0:#,##0}", Val(objEnPhieuDichvu.nv_Ghichu_en)) + " VND"
        rp.lblTiendong.Text = String.Format("{0:#,##0}", Val(objEnPhieuDichvu.f_Tongtienthuc)) + " VND"
        rp.lblNguoithu.Text = objEnNhanvien.nv_Hoten_vn
        rp.XrPictureBox_logo.ImageUrl = "~" + objFCThamso.SelectTHAMSOHETHONGByID("vLogo").v_Giatri.ToString()
        ReportViewerControl.ReportViewer.Report = rp
    End Sub

    Public Sub loadPhieuThuDonThuoc()
        Dim datenow As DateTime = Date.Now
        Dim uId_Khachang As String
        Dim objEnKhachhang As New CM.CRM_DM_KhachhangEntity
        Dim objFcKhachhang As New BO.CRM_DM_KhachhangFacade
        Dim objEnNhanvien As New CM.QT_DM_NHANVIENEntity
        Dim objFcNhanvien As New BO.QT_DM_NHANVIENFacade
        Dim objEnPhieuXuat As New CM.QLMH_PHIEUXUATEntity
        Dim objFcPhieuXuat As New BO.QLMH_PHIEUXUATFacade
        Dim objFcLoaiThanhToan As New BO.QLTC_LoaiHinhTTFacade
        Dim rp As New rpt_phieuthu_scc
        uId_Khachang = Session("uId_Khachhang")
        objEnKhachhang = objFcKhachhang.SelectByID(uId_Khachang)
        rp.lblNgaythu.Text = "Ngày " + datenow.Day.ToString() + " Tháng " + datenow.Month.ToString() + " Năm " + datenow.Year.ToString()
        rp.lblTencuahang.Html = Session("nv_Tencuahang_en")
        rp.lblDiachi.Html = Session("nv_DiachiCH_en")
        rp.lblSdt.Text = Session("nv_Dienthoai")
        rp.lblHotenNguoiNop.Text = objEnKhachhang.nv_Hoten_vn
        rp.lblDienthoai.Text = "Điện thoại: " + objEnKhachhang.v_DienthoaiDD
        objEnNhanvien = objFcNhanvien.SelectByID(Session("uId_Nhanvien_Dangnhap"))
        objEnPhieuXuat = objFcPhieuXuat.SelectByID(Session("uId_Phieuxuat"))
        Dim tblDataDichvu As DataTable
        tblDataDichvu = objFcPhieuXuat.SelectByID_QLMH_PHIEUXUAT_CHITIET(Session("uId_Phieuxuat"))
        Dim strDichvu As String
        strDichvu = ""
        Dim i As Integer = 0
        If tblDataDichvu.Rows.Count > 0 Then
            For Each row As DataRow In tblDataDichvu.Rows
                If i = 0 Then
                    strDichvu += row("nv_TenMathang_vn").ToString()
                Else
                    strDichvu = strDichvu + " + " + row("nv_TenMathang_vn").ToString()
                End If
                i += 1
            Next
        End If
        rp.lblNoidung.Text = strDichvu
        rp.lblHinhthuc.Text = objFcLoaiThanhToan.SelectByID(objEnPhieuXuat.uId_LoaiTT).nv_TenLoaiTT.ToString()
        rp.lblTongtien.Text = String.Format("{0:#,##0}", Val(objEnPhieuXuat.nv_Noidungxuat_en)) + " VND"
        rp.lblTiendong.Text = String.Format("{0:#,##0}", Val(objEnPhieuXuat.f_Tongtienthuc)) + " VND"
        rp.lblNguoithu.Text = objEnNhanvien.nv_Hoten_vn
        rp.XrPictureBox_logo.ImageUrl = "~" + objFCThamso.SelectTHAMSOHETHONGByID("vLogo").v_Giatri.ToString()
        ReportViewerControl.ReportViewer.Report = rp
    End Sub

End Class