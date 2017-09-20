Public Class rp_Phieudichvu
    Inherits System.Web.UI.Page
    'Cau hinh 0 la may in nhiet
    'Cau hinh 1 la may in A5 ngang
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim luachon As String
        luachon = Request.QueryString("Luachon")
        If luachon <> Nothing Then
            If luachon = "Thanhtoan" Then
                loadxtraThanhtoan()
            ElseIf luachon = "Congno" Then
                LoadThongTinCongNoTT()
            Else
                loadCongdoandichvu()
            End If
        End If
    End Sub

    Public Sub loadxtraThanhtoan()
        Dim objFCThamsohethong As New BO.clsB_QT_THAMSOHETHONG
        Dim oThamsohethong As CM.cls_QT_THAMSOHETHONG = objFCThamsohethong.SelectTHAMSOHETHONGByID("vInPhieudichvu")
        If Not (oThamsohethong Is Nothing) Then
            If oThamsohethong.v_Giatri = "0" Then
                Dim rp_A6 As New rpt_Phieuthanhtoan_A6 'May in nhiet(Ko goi la A6)
                rp_A6.BindData(Session("uId_Phieudichvu"), Session("uId_Khachhang"), Session("nv_Tencuahang_vn"), Session("nv_DiachiCH_vn"))
                ReportViewerControl.ReportViewer.Report = rp_A6
            ElseIf oThamsohethong.v_Giatri = "1" Then

                Dim rp_A5 As New Xtr_Phieuthudichvu 'May in A5 doc
                Dim objEnCuahang As New CM.QT_DM_CUAHANGEntity
                Dim objFcCuahang As New BO.QT_DM_CUAHANGFacade
                objEnCuahang = objFcCuahang.SelectByIDCuahang(Session("uId_Cuahang"))
                rp_A5.lblPKName.Text = objEnCuahang.nv_Tencuahang_vn
                rp_A5.lblDiachi.Text = objEnCuahang.nv_Diachi_vn
                rp_A5.lblDienthoai.Text = objEnCuahang.nv_Dienthoai
                rp_A5.XrPictureBox_logo.ImageUrl = objEnCuahang.nv_Diachi_en
                rp_A5.Bindata(Session("uId_Phieudichvu"), Session("uId_Khachhang"), Session("nv_Tencuahang_vn"), Session("nv_DiachiCH_vn"))
                ReportViewerControl.ReportViewer.Report = rp_A5
            End If
        End If
    End Sub

    Public Sub loadCongdoandichvu()
        Dim objFcDVCT As New BO.TNTP_PHIEUDICHVU_CHITIETFacade
        Dim xtrCongdoan As New Xtra_PhieuDichVu_Congdoan
        Dim dt As DataTable
        Dim dtct As DataSet
        Dim dtcd As DataTable
        Dim dt0 As New DataTable
        Dim dt1 As New DataTable

        Dim objFckhachhang As New BO.CRM_DM_KhachhangFacade
        Dim objFcPhieudv As New BO.TNTP_PHIEUDICHVUFacade
        Dim objEnPhieudv As New CM.TNTP_PHIEUDICHVUEntity
        Dim objFcDVChitiet As New BO.TNTP_PHIEUDICHVU_CHITIETFacade
        Dim objEnDVChitiet As New CM.TNTP_PHIEUDICHVU_CHITIETEntity
        Dim objFcDMDichvu As New BO.TNTP_DM_DICHVUFacade
        Dim objFcDVCongdoan As New BO.TNTP_DM_DICHVU_CONGDOANFacade
        Dim objFcCheckin As New BO.TNTP_CHECKINCHECKOUTFacade
        xtrCongdoan.lbl_Cuahang.Text = Session("nv_Tencuahang_vn")
        xtrCongdoan.lbl_Diachi.Text = Session("nv_DiachiCH_vn")
        ReportViewerControl.ReportViewer.Report = xtrCongdoan
        dt = objFckhachhang.SelectByIDTable(Session("uId_Khachhang"))
        If dt.Rows.Count > 0 Then
            xtrCongdoan.Parameters("nv_Hoten_vn").Value = dt.Rows(0)("nv_Hoten_vn").ToString
            xtrCongdoan.Parameters("nv_Diachi_vn").Value = dt.Rows(0)("nv_Diachi_vn").ToString
            xtrCongdoan.Parameters("v_Email").Value = dt.Rows(0)("v_Email").ToString
            xtrCongdoan.Parameters("v_DienthoaiDD").Value = dt.Rows(0)("v_DienthoaiDD").ToString
            xtrCongdoan.Parameters("d_Ngaysinh").Value = dt.Rows(0)("d_Ngaysinh").ToString

        End If
        'Dim table As DataTable
        'table = objFcCheckin.SelectCheckinByIDQTDT(Session("uId_QT_Dieutri").ToString)
        'If table.Rows.Count > 0 Then
        '    xtrCongdoan.Parameters("i_Lanthu").Value = table.Rows(0)("i_Lanthu").ToString
        '    xtrCongdoan.Parameters("dt_checkin").Value = table.Rows(0)("dt_checkin").ToString
        '    xtrCongdoan.Parameters("dt_checkout").Value = table.Rows(0)("dt_checkout").ToString
        'End If
        'load du lieu phieu dv
        objEnPhieudv = objFcPhieudv.SelectByID(Session("uId_Phieudichvu"))
        'load dvct
        dtct = objFcDVChitiet.SelectCkinCkoutByIDChitiet(Session("uId_Dichvu_Chitiet"))

        If dtct IsNot Nothing AndAlso dtct.Tables.Count > 0 Then
            dt0 = dtct.Tables(0)
            dt1 = dtct.Tables(1)
        End If

        xtrCongdoan.Parameters("v_Sophieu").Value = objEnPhieudv.v_Sophieu
        xtrCongdoan.Parameters("d_Ngaymua").Value = objEnPhieudv.d_Ngay
        xtrCongdoan.Parameters("d_Ngayhethan").Value = objEnPhieudv.d_Ngayketthuc       
        Dim giovao As String
        Dim phutvao As String
        Dim giora As Double
        giovao = Now.Hour.ToString
        phutvao = Now.Minute.ToString
        xtrCongdoan.Parameters("Giovao").Value = giovao + ":" + phutvao
        Dim phutra As Double = Convert.ToDouble(phutvao) + objFcDMDichvu.SelectByID(dt0.Rows(0)("uId_Dichvu").ToString).f_Sophutthuchien
        If phutra - 60 > 0 Then
            giora = Convert.ToDouble(giovao) + Int((phutra + Convert.ToDouble(phutvao)) / 60)
            phutra = phutra Mod 60
        Else
            giora = Convert.ToDouble(giovao)
        End If
        xtrCongdoan.Parameters("Giora").Value = giora.ToString + ":" + phutra.ToString
        xtrCongdoan.Parameters("d_Ngayapdung").Value = Convert.ToDateTime(DateTime.Now.Date)
        xtrCongdoan.Parameters("f_PhutDV").Value = objFcDMDichvu.SelectByID(dt0.Rows(0)("uId_Dichvu").ToString).f_Sophutthuchien
        xtrCongdoan.Parameters("nv_Tendichvu_vn").Value = objFcDMDichvu.SelectByID(dt0.Rows(0)("uId_Dichvu").ToString).nv_Tendichvu_vn
        dtcd = objFcDVCongdoan.SelectCongdoan(dt0.Rows(0)("uId_Dichvu").ToString)
        xtrCongdoan.Parameters("i_Landasudung").Value = dt0.Rows(0)("i_Landasudung").ToString
        xtrCongdoan.Parameters("i_Lanconlai").Value = dt0.Rows(0)("i_Lanconlai").ToString
        If dt1.Rows.Count > 0 Then
            xtrCongdoan.Parameters("nv_Ghichu_vn").Value = dt1.Rows(0)("nv_Ghichu_vn").ToString
            xtrCongdoan.Parameters("nv_Ghichu_cc_vn").Value = dt1.Rows(0)("nv_Ghichu_cc_vn").ToString
            xtrCongdoan.Parameters("i_Lanthu").Value = dt1.Rows(0)("i_Lanthu").ToString
        Else
            xtrCongdoan.Parameters("nv_Ghichu_vn").Visible = False
            xtrCongdoan.Parameters("nv_Ghichu_cc_vn").Visible = False
            xtrCongdoan.Parameters("i_Lanthu").Visible = False
        End If
      
        If dtcd.Rows.Count > 0 Then
            xtrCongdoan.loadcongdoan(dtcd)
        End If
        objFcDVCT = Nothing
        objEnDVChitiet = Nothing
        objFcPhieudv = Nothing
        objFckhachhang = Nothing
        objEnPhieudv = Nothing
        objFcDVChitiet = Nothing
        objEnDVChitiet = Nothing
        objFcDMDichvu = Nothing
        objFcDVCongdoan = Nothing
    End Sub
    Private Sub LoadThongTinCongNoTT()
        Dim BC As New rpt_PhieuCongNoThanhToan
        Dim objFcPhieucongnoTT As New BO.QLCN_CONGNO_THANHTOANFacade
        Dim objEnPhieucongnoTT As New CM.QLCN_CONGNO_THANHTOANEntity
        objEnPhieucongnoTT = objFcPhieucongnoTT.SelectByID(Session("uIdConNoThanhToan"))
        Dim objFcKhachhang As New BO.CRM_DM_KhachhangFacade
        Dim objEnKhachhang As New CM.CRM_DM_KhachhangEntity
        objEnKhachhang = objFcKhachhang.SelectByID(objEnPhieucongnoTT.uId_Khachhang)
        If objEnPhieucongnoTT.vTypeThanhToan = "PX" Then
            Dim objFcPhieuxuat As New BO.QLMH_PHIEUXUATFacade
            Dim objEnPhieuxuat As New CM.QLMH_PHIEUXUATEntity
            Dim objFcPhieunosp As New BO.QLCN_CONGNO_SPFacade
            BC.xtrCellTienNo.Text = String.Format("{0:#,##0}", objFcPhieunosp.SelectByID(objEnPhieucongnoTT.uId_Phieuno).f_Sotien)
            objEnPhieuxuat = objFcPhieuxuat.SelectByID(objEnPhieucongnoTT.uId_Phieuno)
            BC.xtrCellPhieu.Text = "Phiếu xuất"
            BC.xtrCellMaPhieu.Text = objEnPhieuxuat.v_Maphieuxuat
        Else
            Dim objFcPhieunodv As New BO.QLCN_CONGNOFacade
            Dim objFcPhieudichvu As New BO.TNTP_PHIEUDICHVUFacade
            BC.xtrCellPhieu.Text = "Phiếu dịch vụ"
            BC.xtrCellMaPhieu.Text = objFcPhieudichvu.SelectByID(objEnPhieucongnoTT.uId_Phieuno).v_Sophieu
            BC.xtrCellTienNo.Text = String.Format("{0:#,##0}", objFcPhieunodv.SelectByID(objEnPhieucongnoTT.uId_Phieuno).f_Sotien)
        End If
        Dim objEnCuahang As New CM.QT_DM_CUAHANGEntity
        Dim objFcCuahang As New BO.QT_DM_CUAHANGFacade
        objEnCuahang = objFcCuahang.SelectByIDCuahang(Session("uId_Cuahang"))
        BC.lblPKName.Text = objEnCuahang.nv_Tencuahang_vn
        BC.lblDiachi.Text = objEnCuahang.nv_Diachi_vn
        BC.lblDienthoai.Text = objEnCuahang.nv_Dienthoai
        BC.XrPictureBox_logo.ImageUrl = objEnCuahang.nv_Diachi_en
        BC.lblNgay.Text = "Ngày:" + String.Format(Date.Now.ToString, "dd/MM/yyyy")
        BC.xtrCellTenKhachHang.Text = objEnKhachhang.nv_Hoten_vn
        BC.xtrCellDienthoai.Text = objEnKhachhang.v_DienthoaiDD
        BC.xtrCellDiaChi.Text = objEnKhachhang.nv_Diachi_vn
        BC.xtrTienThanhToan.Text = String.Format("{0:#,##0}", objEnPhieucongnoTT.f_Sotien_Nolai)
        ReportViewerControl.Report = BC
    End Sub
End Class