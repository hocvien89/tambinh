Imports DevExpress.Web.ASPxEditors
Imports System.Data.OleDb
Imports System.IO
Imports DevExpress.Web.ASPxGridView

Public Class CustomerCare
    Inherits System.Web.UI.Page
#Region "Khai bao"
    Dim objFCKHtiemnang As BO.MKT_KH_TIEMNANGFacade
    Dim objEnKHtiemnang As CM.MKT_KH_TIEMNANGEntity
    Dim objFCCuaHang As BO.QT_DM_CUAHANGFacade
    Dim objFcTrangthai As BO.MKT_TRANGTHAIKHFacade
    Dim objEnChuyendoi As CM.MKT_ChuyendoiEntity
    Dim objFCChuyendoi As BO.MKT_ChuyendoiFacade
    Dim objEnKhachhang As CM.CRM_DM_KhachhangEntity
    Dim objFcKhachhang As BO.CRM_DM_KhachhangFacade

    Private objFCPhieuDV As BO.TNTP_PHIEUDICHVUFacade
    Dim objFCChitietDV As BO.TNTP_PHIEUDICHVU_CHITIETFacade
    Private objFCQTDieutri As BO.TNTP_QT_DieutriFacade
    Private objFCPhieuXuat As BO.QLMH_PHIEUXUATFacade
    Private objFcPhieuxuatChitiet As BO.QLMH_PHIEUXUAT_LOAITTFacade
    Private objFCBaoCaoTaiChinh As BO.clsB_Baocao_Taichinh
    Dim objFcKhachHang_GoiDichVuFacade As BO.TNTP_KHACHHANG_GOIDICHVUFacade
    Private objFcThamsohethong As BO.clsB_QT_THAMSOHETHONG
    Private pc As Public_Class
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            dgvDevexpress.Visible = True
            ReportToolbar1.Visible = False
            ReportViewer1.Visible = False
            deTuNgay.Date = DateTime.Now.ToString
            deDenNgay.Date = DateTime.Now.ToString
            deNgaysinh.Date = DateTime.Now.ToString
            deNgayden.Date = DateTime.Now.ToString
            rdb_Dichvu.Checked = True
            LoadDropDownList()
            If Session("uId_KH_Tiemnang") <> Nothing And Session("uId_Chuyendoi") <> Nothing Then
                LoadThongTinKH()
            End If
        End If
        LoadReport()
        LoadDSKhachhang(BO.Util.ConvertDateTime(deTuNgay.Text), BO.Util.ConvertDateTime(deDenNgay.Text))
        LoadDSKhachUutien()
    End Sub
#Region "Load thong tin"
    Private Sub LoadThongTinKH()
        objFCKHtiemnang = New BO.MKT_KH_TIEMNANGFacade
        objEnKHtiemnang = New CM.MKT_KH_TIEMNANGEntity
        objFCChuyendoi = New BO.MKT_ChuyendoiFacade
        Dim uId_TrangthaiKH As String
        uId_TrangthaiKH = objFCChuyendoi.SelectByID(Session("uId_Chuyendoi").ToString).uId_TrangthaiKH
        objEnKHtiemnang = objFCKHtiemnang.SelectByID(Session("uId_KH_Tiemnang").ToString)
        deNgayden.Date = objEnKHtiemnang.d_Ngaynhap
        ddlDanhgia.Value = uId_TrangthaiKH
        txtMaKH.Text = objEnKHtiemnang.v_Makhachhang
        txtHoten.Text = objEnKHtiemnang.nv_Hoten_vn
        deNgaysinh.Date = objEnKHtiemnang.d_Ngaysinh
        ddlGioitinh.Value = objEnKHtiemnang.b_Gioitinh
        txtDiachi.Text = objEnKHtiemnang.nv_Diachi_vn
        txtDienthoai.Text = objEnKHtiemnang.v_DienthoaiDD
        txtEmail.Text = objEnKHtiemnang.v_Email
        ddlCuahang.Value = objEnKHtiemnang.uId_Cuahang
        txtGhichu.Text = objEnKHtiemnang.Ghichu

    End Sub
    'load kh do mak nhap
    Private Sub LoadDSKhachhang(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime)
        objFCKHtiemnang = New BO.MKT_KH_TIEMNANGFacade
        objFcThamsohethong = New BO.clsB_QT_THAMSOHETHONG
        Dim dt As DataTable ' danh sach kh tiem nang mak nhap
        Dim dt2 As DataTable ' danh sach kh do letan nhap
        'tuy bien theo tham so he thong. tu phan hay ch phan loai
        '----tu phan kh mua dv se la kh he thong
        '----chpl kick hoat
        Dim thamso As String
        thamso = objFcThamsohethong.SelectTHAMSOHETHONGByID("v_CSKH").v_Giatri
        If chkViewAll.Checked Then
            dt = objFCKHtiemnang.ChamsocKH("01/01/2012", Date.Now, Session("uId_Cuahang"), "tiemnang", thamso)
            dt2 = objFCKHtiemnang.ChamsocKH("01/01/2012", Date.Now, Session("uId_Cuahang"), "hethong", thamso)
        Else
            dt = objFCKHtiemnang.ChamsocKH(TuNgay, DenNgay, Session("uId_Cuahang"), "tiemnang", thamso)
            dt2 = objFCKHtiemnang.ChamsocKH(TuNgay, DenNgay, Session("uId_Cuahang"), "hethong", thamso)
        End If
        'day len grv tiem nang
        If dt.Rows.Count > 0 Then
            dgvDevexpress.DataSource = dt
        Else
            dgvDevexpress.DataSource = Nothing
        End If
        dgvDevexpress.DataBind()
        'day len grv he thong
        If dt2.Rows.Count > 0 Then
            grv_KHHethong.DataSource = dt2
        Else
            grv_KHHethong.DataSource = Nothing
        End If
        grv_KHHethong.DataBind()
        objFCKHtiemnang = Nothing
    End Sub
    'load kh do le tan nhap
    'Private Sub LoadDSKhachhanghethong()
    '    Dim objFcBaocaokh As New BO.clsB_BaoCao_Khachhang
    '    Dim dt As DataTable
    '    Dim tungay As DateTime
    '    Dim denngay As DateTime
    '    tungay = deTuNgay.Value
    '    denngay = deDenNgay.Value
    '    dt = objFcBaocaokh.SelectThongkeKH_ByTime(tungay, denngay, Session("uId_Cuahang"))
    '    grv_KHHethong.DataSource = dt
    '    grv_KHHethong.DataBind()
    'End Sub

    'load kh uu tien cham soc
    Private Sub LoadDSKhachUutien()
        Dim dt As DataTable
        Dim type As String = ""
        objFCKHtiemnang = New BO.MKT_KH_TIEMNANGFacade
        If rdb_Dichvu.Checked = True Then
            type = "1"
        ElseIf rdb_Dieutri.Checked = True Then
            type = "0"
        End If
        dt = objFCKHtiemnang.SelectKHUutienChamsoc(BO.Util.ConvertDateTime(deTuNgay.Text), BO.Util.ConvertDateTime(deDenNgay.Text), Session("uId_Cuahang"), type)
        If dt.Rows.Count > 0 Then
            grv_Chamsoc.DataSource = dt
        End If
        grv_Chamsoc.DataBind()
    End Sub

    Private Sub LoadDropDownList()
        objFCCuaHang = New BO.QT_DM_CUAHANGFacade
        objFcTrangthai = New BO.MKT_TRANGTHAIKHFacade
        'Dim objFcDMPhong As New BO.PQP_DM_PHONGBANFacade
        'Dim objFcTrangthaiphong As New BO.CRM_DM_TRANGTHAIFacade
        Dim dt As DataTable
        dt = objFCCuaHang.SelectAllTable
        ddlCuahang.DataSource = dt
        ddlCuahang.ValueField = "uId_Cuahang"
        ddlCuahang.TextField = "nv_Tencuahang_vn"
        ddlCuahang.DataBind()
        ddlCuahang.Value = Session("uId_Cuahang")

        dt = New DataTable
        dt = objFcTrangthai.SelectAllTable
        ddlDanhgia.DataSource = dt
        ddlDanhgia.ValueField = "uId_TrangthaiKH"
        ddlDanhgia.TextField = "nv_TenTrangthaiKH_vn"
        ddlDanhgia.DataBind()
        ddlDanhgia.SelectedIndex = 0

        'dt = New DataTable
        'dt = objFcDMPhong.SelectByIdCuahang(Session("uId_Cuahang"))
        'cbo_Denphong.ValueField = "uId_Phong"
        'cbo_Denphong.TextField = "nv_Tenphong_vn"
        'cbo_Denphong.DataSource = dt
        'cbo_Denphong.DataBind()
        'cbo_Denphong.SelectedIndex = 0

        'dt = New DataTable
        'dt = objFcTrangthaiphong.SelectByIType("3")
        'cbo_Trangthai.ValueField = "uId_Trangthai"
        'cbo_Trangthai.TextField = "nv_Tentrangthai_vn"
        'cbo_Trangthai.DataSource = dt
        'cbo_Trangthai.DataBind()
        'cbo_Trangthai.SelectedIndex = 0
    End Sub
#End Region
#Region "Checkbox Function"
    Protected Sub chkViewAll_CheckedChange(ByVal sender As Object, ByVal e As EventArgs)
        If chkViewAll.Checked = True Then
            deTuNgay.Enabled = False
            deDenNgay.Enabled = False
            btnFilter.Enabled = False
            LoadDSKhachhang("01/01/2012", DateTime.Now)
        Else
            deTuNgay.Enabled = True
            deDenNgay.Enabled = True
            btnFilter.Enabled = True
            LoadDSKhachhang(BO.Util.ConvertDateTime(deTuNgay.Text), BO.Util.ConvertDateTime(deDenNgay.Text))
        End If
    End Sub
#End Region
#Region "Button"
    Protected Sub btnFilter_Click(sender As Object, e As EventArgs)
        LoadDSKhachhang(BO.Util.ConvertDateTime(deTuNgay.Text), BO.Util.ConvertDateTime(deDenNgay.Text))
    End Sub

    Protected Sub btOK_Click(sender As Object, e As EventArgs)
        objEnKHtiemnang = New CM.MKT_KH_TIEMNANGEntity
        objFCKHtiemnang = New BO.MKT_KH_TIEMNANGFacade
        objEnChuyendoi = New CM.MKT_ChuyendoiEntity
        objFCChuyendoi = New BO.MKT_ChuyendoiFacade
        objEnKhachhang = New CM.CRM_DM_KhachhangEntity
        objFcKhachhang = New BO.CRM_DM_KhachhangFacade
        With objEnKHtiemnang
            .v_Makhachhang = CStr(Me.txtMaKH.Text.Trim)
            .nv_Hoten_vn = CStr(Me.txtHoten.Text.Trim)
            .d_Ngaysinh = BO.Util.ConvertDateTime(deNgaysinh.Text)
            .v_DienthoaiDD = CStr(Me.txtDienthoai.Text.Trim)
            .nv_Diachi_vn = CStr(Me.txtDiachi.Text.Trim)
            .v_Email = CStr(Me.txtEmail.Text.Trim)
            .b_Gioitinh = CByte(Me.ddlGioitinh.SelectedItem.Value)
            .d_Ngaynhap = BO.Util.ConvertDateTime(deNgayden.Text)
            .Ghichu = txtGhichu.Text
            .uId_Cuahang = ddlCuahang.SelectedItem.Value.ToString
            '.nv_Hoten_en = txt_Lichsuchamsocda.Text
            '.nv_Diachi_en = txt_Lichsuchamsocsuckhoe.Text
            '.nv_Diachi_en = Session("uId_Nhanvien_Dangnhap")
        End With
        With objEnKhachhang
            .v_Makhachang = CStr(Me.txtMaKH.Text.Trim)
            .nv_Hoten_vn = CStr(Me.txtHoten.Text.Trim)
            .d_Ngaysinh = BO.Util.ConvertDateTime(deNgaysinh.Text)
            .v_DienthoaiDD = CStr(Me.txtDienthoai.Text.Trim)
            .nv_Diachi_vn = CStr(Me.txtDiachi.Text.Trim)
            .v_Email = CStr(Me.txtEmail.Text.Trim)
            .b_Gioitinh = CByte(Me.ddlGioitinh.SelectedItem.Value)
            .d_Ngayden = BO.Util.ConvertDateTime(deNgayden.Text)
            .nv_Ghichu_vn = txtGhichu.Text
            .uId_Cuahang = ddlCuahang.SelectedItem.Value.ToString
            .uId_Xaphuong = "47014a0c-b3db-4470-91a2-c7fedd0d8953"
            .uId_Nghenghiep = "6EA10344-F342-4972-9B05-E2111C5C092E"
            .uId_Nguonden = "67B63FA5-975F-4AB6-B8CB-07ECA8FF7628"
            '.nv_Hoten_en = txt_Lichsuchamsocda.Text
            '.nv_Diachi_en = txt_Lichsuchamsocsuckhoe.Text
            '.nv_Diachi_en = Session("uId_Nhanvien_Dangnhap")
        End With
        'them vao bang khach hang
        'update
        If (Session("uId_KH_Tiemnang") <> Nothing) Then
            objEnKHtiemnang.uId_KH_Tiemnang = Session("uId_KH_Tiemnang")
            Dim uid As String = Session("uId_Khachhang")
            If uid <> "null" Then
                objEnKHtiemnang.uId_Khachhang = Session("uId_Khachhang")
                objEnKhachhang.uId_Khachhang = Session("uId_Khachhang")
            Else
                objEnKHtiemnang.uId_Khachhang = Nothing
            End If
            If Session("uId_Chuyendoi") <> Nothing Then
                objEnChuyendoi = New CM.MKT_ChuyendoiEntity
                objEnChuyendoi = objFCChuyendoi.SelectByID(Session("uId_Chuyendoi"))
                If ddlDanhgia.SelectedItem.Value.ToString <> objEnChuyendoi.uId_TrangthaiKH Then
                    'Manhtt:Lay ngay nhap chuyen doi la ngay hien tai
                    With objEnChuyendoi
                        .d_Ngay = DateTime.Now
                        .uId_KH_Tiemnang = Session("uId_KH_Tiemnang").ToString
                        .uId_TrangthaiKH = ddlDanhgia.SelectedItem.Value.ToString
                    End With
                    Try
                        Dim str_chuyendoi As String = objFCChuyendoi.Insert(objEnChuyendoi)
                        Session("uId_Chuyendoi") = str_chuyendoi
                    Catch ex As Exception
                    End Try
                End If
                objEnChuyendoi = Nothing
            End If
            If (objFCKHtiemnang.Update(objEnKHtiemnang)) Then
                If Session("uId_Khachhang") <> "null" Then
                    objFcKhachhang.Update(objEnKhachhang)
                End If
                ltrSuccess.Text = "<span class='success' id='success'>Cập nhật thông tin khách hàng thành công!</span>"
                Exit Sub
            Else
                ltrError.Text = "<span class='error' id='error'>Cập nhật thông tin khách hàng lỗi!</span>"
                Exit Sub
            End If
        Else
            Dim uId_Khachhang As String = objFcKhachhang.Insert(objEnKhachhang)
            objEnKHtiemnang.uId_Khachhang = uId_Khachhang
            Dim str As String = objFCKHtiemnang.Insert(objEnKHtiemnang)
            Session("uId_KH_Tiemnang") = str
            'Manhtt:Lay ngay nhap chuyen doi la ngay hien tai
            pc = New Public_Class
            Dim objFcThetd = New BO.clsB_TTV_DM_THETICHDIEM
            Dim dtThetd As DataTable
            Dim objEntheKH As New CM.cls_TTV_KH_ThetichdiemEntity
            Dim objFctheKH As New BO.clsB_TTV_KH_Thetichdiem
            dtThetd = objFcThetd.SelectAllTable(Session("uId_Cuahang"))
            If dtThetd.Rows.Count > 0 Then
                objEntheKH.uId_Thetichdiem = dtThetd.Rows(0)("uId_Thetichdiem").ToString
            Else
                objEntheKH.uId_Thetichdiem = Nothing
            End If
            'them the tich diem cho khach
            With objEntheKH
                .uId_Khachhang = uId_Khachhang
                .d_Ngaycap = DateAndTime.Now
                .d_Ngayhethan = DateAndTime.DateAdd(DateInterval.Year, +1, DateAndTime.Now)
                .b_Trangthai = True
                .b_Isdelete = False
                If objEntheKH.uId_Thetichdiem <> Nothing Then
                    .f_Diemhientai = dtThetd.Rows(0)("f_Diemkichhoat").ToString
                    .f_Tongtichluy = dtThetd.Rows(0)("f_Diemkichhoat").ToString
                Else
                    .f_Diemhientai = 0
                    .f_Tongtichluy = 0
                End If
                .v_Mathekhachhang = txtMaKH.Text
            End With
            objFctheKH.Insert(objEntheKH)
            With objEnChuyendoi
                .d_Ngay = DateTime.Now
                .uId_KH_Tiemnang = Session("uId_KH_Tiemnang").ToString
                .uId_TrangthaiKH = ddlDanhgia.SelectedItem.Value.ToString
            End With
            Try
                Dim str_chuyendoi As String = objFCChuyendoi.Insert(objEnChuyendoi)
                Session("uId_Chuyendoi") = str_chuyendoi
                ltrSuccess.Text = "<span class='success' id='success'>Thêm mới thông tin khách hàng thành công!</span>"
            Catch ex As Exception
                ltrError.Text = "<span class='error' id='error'>Thêm mới thông tin khách hàng lỗi!</span>"
            End Try
        End If
    End Sub

    Protected Sub btaddbill_Click(sender As Object, e As EventArgs)
        Session("tags") = Nothing
        Response.Redirect("~/OrangeVersion/Marketing/AddWork.aspx")
    End Sub

    Private Sub btn_Import_Click(sender As Object, e As EventArgs) Handles btn_Import.Click
        If UploadFileExcel.HasFile Then
            pc = New Public_Class
            Dim FileName As String = Path.GetFileNameWithoutExtension(UploadFileExcel.PostedFile.FileName)
            Dim Extension As String = Path.GetExtension(UploadFileExcel.PostedFile.FileName)
            Dim FolderPath As String = ConfigurationManager.AppSettings("FolderPath")
            FileName = pc.ReturnAutoString(FileName)
            Dim FilePath As String = Server.MapPath(FolderPath + FileName + Extension)
            UploadFileExcel.SaveAs(FilePath)
            Import_To_Grid(FilePath, Extension)
        End If
    End Sub

    Private Sub btn_Report_Click(sender As Object, e As EventArgs) Handles btn_Report.Click
        dgvDevexpress.Visible = False
        ReportToolbar1.Visible = True
        ReportViewer1.Visible = True
        LoadReport()
    End Sub

    Protected Sub link_Taiexcel_Mau_Click(sender As Object, e As EventArgs)
        Response.Redirect("../../Excel/Excel_Mau_KHTiemnang.xlsx")
    End Sub

    Private Sub btnFilter_Click1(sender As Object, e As EventArgs) Handles btnFilter.Click
        dgvDevexpress.Visible = True
        ReportToolbar1.Visible = False
        ReportViewer1.Visible = False
        LoadDSKhachhang(BO.Util.ConvertDateTime(deTuNgay.Text), BO.Util.ConvertDateTime(deDenNgay.Text))
    End Sub

    Private Sub btn_ExportExcel_Click(sender As Object, e As EventArgs) Handles btn_ExportExcel.Click
        ASPxGridViewExporter_KH.WriteXlsToResponse()
    End Sub
#End Region
#Region "Grid event"
    Protected Sub dgvDevexpress_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        Dim uId_Khachhang As String
        uId_Khachhang = e.Keys(0).ToString
        objFCKHtiemnang = New BO.MKT_KH_TIEMNANGFacade
        Try
            objFCKHtiemnang.DeleteByID(uId_Khachhang)
        Catch ex As Exception

        End Try
        LoadDSKhachhang(BO.Util.ConvertDateTime(deTuNgay.Text), BO.Util.ConvertDateTime(deDenNgay.Text))
        e.Cancel = True
    End Sub

    Protected Sub dgvPhieudichvu_BeforePerformDataSelect(sender As Object, e As EventArgs)
        objFCKHtiemnang = New BO.MKT_KH_TIEMNANGFacade
        Dim detailGridView As ASPxGridView = DirectCast(sender, ASPxGridView)
        Dim uId_Khachhang As String
        uId_Khachhang = detailGridView.GetMasterRowKeyValue().ToString
        objFCPhieuDV = New BO.TNTP_PHIEUDICHVUFacade
        Dim dt As DataTable = objFCPhieuDV.SelectByDate(objFCKHtiemnang.SelectByID(uId_Khachhang).uId_Khachhang, "01/01/2012", DateTime.Now)
        If dt.Rows.Count > 0 Then
            detailGridView.DataSource = dt
        End If
        objFCPhieuDV = Nothing
        dt = Nothing
    End Sub

    Protected Sub dgvPhieuchitiet_BeforePerformDataSelect(sender As Object, e As EventArgs)
        Dim detailGridView As ASPxGridView = DirectCast(sender, ASPxGridView)
        Dim uId_Phieudichvu As String
        uId_Phieudichvu = detailGridView.GetMasterRowKeyValue().ToString
        objFCChitietDV = New BO.TNTP_PHIEUDICHVU_CHITIETFacade
        Dim dt As DataTable = objFCChitietDV.SelectByID(uId_Phieudichvu)
        If dt.Rows.Count > 0 Then
            detailGridView.DataSource = dt
        End If
        objFCChitietDV = Nothing
    End Sub

    Protected Sub dgvQTdieutri_BeforePerformDataSelect(sender As Object, e As EventArgs)
        Dim detailGridView As ASPxGridView = DirectCast(sender, ASPxGridView)
        Dim uId_Phieudichvu As String
        Dim uId_Dichvu As String
        uId_Phieudichvu = detailGridView.GetMasterRowFieldValues("uId_Phieudichvu").ToString
        uId_Dichvu = detailGridView.GetMasterRowFieldValues("uId_Dichvu").ToString
        objFCQTDieutri = New BO.TNTP_QT_DieutriFacade
        Dim dt As DataTable = objFCQTDieutri.SelectAllByIdDV(uId_Phieudichvu, uId_Dichvu)
        If dt.Rows.Count > 0 Then
            detailGridView.DataSource = dt
        End If
        objFCQTDieutri = Nothing
    End Sub

    Protected Sub dgvPhieuxuat_BeforePerformDataSelect(sender As Object, e As EventArgs)
        Dim detailGridView As ASPxGridView = DirectCast(sender, ASPxGridView)
        Dim uId_Khachhang As String
        objFCKHtiemnang = New BO.MKT_KH_TIEMNANGFacade
        uId_Khachhang = detailGridView.GetMasterRowKeyValue().ToString
        objFCPhieuXuat = New BO.QLMH_PHIEUXUATFacade
        Dim dt As DataTable = objFCPhieuXuat.SelectByKH(objFCKHtiemnang.SelectByID(uId_Khachhang).uId_Khachhang, "01/01/2012", DateTime.Now)
        If dt.Rows.Count > 0 Then
            detailGridView.DataSource = dt
        End If
        objFCPhieuXuat = Nothing
        dt = Nothing
    End Sub

    Protected Sub dgvPhieuxuatchitiet_BeforePerformDataSelect(sender As Object, e As EventArgs)
        Dim detailGridView As ASPxGridView = DirectCast(sender, ASPxGridView)
        Dim uId_Phieuxuat As String
        uId_Phieuxuat = detailGridView.GetMasterRowKeyValue().ToString
        objFCPhieuXuat = New BO.QLMH_PHIEUXUATFacade
        Dim dt As DataTable = objFCPhieuXuat.SelectByID_QLMH_PHIEUXUAT_CHITIET(uId_Phieuxuat)
        If dt.Rows.Count > 0 Then
            detailGridView.DataSource = dt
        End If
        objFCPhieuXuat = Nothing
        dt = Nothing
    End Sub

    Protected Sub dgvCongno_BeforePerformDataSelect(sender As Object, e As EventArgs)
        Dim detailGridView As ASPxGridView = DirectCast(sender, ASPxGridView)
        Dim uId_Khachhang As String
        objFCKHtiemnang = New BO.MKT_KH_TIEMNANGFacade
        uId_Khachhang = detailGridView.GetMasterRowKeyValue().ToString
        objFCBaoCaoTaiChinh = New BO.clsB_Baocao_Taichinh
        Dim dt As DataTable = objFCBaoCaoTaiChinh.Theodoi_CongNo(objFCKHtiemnang.SelectByID(uId_Khachhang).uId_Khachhang, "01/01/2012", DateTime.Now)
        If dt.Rows.Count > 0 Then
            detailGridView.DataSource = dt
        End If
        objFCPhieuXuat = Nothing
        dt = Nothing
    End Sub

    Protected Sub dgvTheTT_BeforePerformDataSelect(sender As Object, e As EventArgs)
        objFcKhachHang_GoiDichVuFacade = New BO.TNTP_KHACHHANG_GOIDICHVUFacade
        Dim detailGridView As ASPxGridView = DirectCast(sender, ASPxGridView)
        Dim uId_Khachhang As String
        objFCKHtiemnang = New BO.MKT_KH_TIEMNANGFacade
        uId_Khachhang = detailGridView.GetMasterRowKeyValue().ToString
        Dim dt As DataTable = objFcKhachHang_GoiDichVuFacade.SelectAllTable_ByKH(objFCKHtiemnang.SelectByID(uId_Khachhang).uId_Khachhang, 1)
        If dt.Rows.Count > 0 Then
            detailGridView.DataSource = dt
        End If
        objFcKhachHang_GoiDichVuFacade = Nothing
        dt = Nothing
    End Sub

    Protected Sub dgvLichSuTheTT_BeforePerformDataSelect(sender As Object, e As EventArgs)
        objFcKhachHang_GoiDichVuFacade = New BO.TNTP_KHACHHANG_GOIDICHVUFacade
        Dim detailGridView As ASPxGridView = DirectCast(sender, ASPxGridView)
        Dim vMaBarcode As String
        vMaBarcode = detailGridView.GetMasterRowKeyValue().ToString
        'Dim dt As DataTable = objFcKhachHang_GoiDichVuFacade.LichSuThanhtoan(vMaBarcode)
        'If dt.Rows.Count > 0 Then
        '    detailGridView.DataSource = dt
        'End If
        'objFcKhachHang_GoiDichVuFacade = Nothing
        'dt = Nothing
    End Sub
#End Region
#Region "Import Excel Support"
    'doc file excel tai len tu client dua vao table
    Private Sub Import_To_Grid(ByVal FilePath As String, ByVal Extension As String)
        Dim conStr As String = ""
        Select Case Extension
            Case ".xls"
                'Excel 97-03
                conStr = ConfigurationManager.ConnectionStrings("Excel03ConString").ConnectionString()
                Exit Select
            Case ".xlsx"
                'Excel 07
                conStr = ConfigurationManager.ConnectionStrings("Excel07ConString").ConnectionString()
                Exit Select
        End Select

        conStr = String.Format(conStr, FilePath)
        Dim connExcel As New OleDbConnection(conStr)
        Dim cmdExcel As New OleDbCommand()
        Dim oda As New OleDbDataAdapter()
        Dim dt As New DataTable()
        cmdExcel.Connection = connExcel
        'Get the name of First Sheet
        connExcel.Open()
        Dim dtExcelSchema As DataTable
        dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
        'Dim SheetName As String = dtExcelSchema.Rows(1)("TABLE_NAME").ToString()
        Dim SheetName As String = "KHTiemnang$"
        connExcel.Close()
        'Read Data from First Sheet
        connExcel.Open()
        cmdExcel.CommandText = "SELECT * From [" & SheetName & "]"
        oda.SelectCommand = cmdExcel
        oda.Fill(dt)
        connExcel.Close()
        File.Delete(FilePath)
        ExcelInsert(dt)
    End Sub

    Private Sub ExcelInsert(dt As DataTable)
        Dim sFormat As System.Globalization.DateTimeFormatInfo = New System.Globalization.DateTimeFormatInfo()
        sFormat.ShortDatePattern = "dd/MM/yyyy"
        objFCKHtiemnang = New BO.MKT_KH_TIEMNANGFacade
        objEnKHtiemnang = New CM.MKT_KH_TIEMNANGEntity
        objFCChuyendoi = New BO.MKT_ChuyendoiFacade
        objEnChuyendoi = New CM.MKT_ChuyendoiEntity
        Dim lengthTb As Integer
        Dim i As Integer = 0
        Dim matiemnang As String = pc.ReturnAutoString("")
        If dt.Rows.Count > 500 Then
            lengthTb = 500 - 1
        Else
            lengthTb = dt.Rows.Count - 1
        End If
        If dt.Rows.Count >= 1 Then
            For Each row As DataRow In dt.Rows
                If row("Tên khách hàng").ToString = "" Then
                    Continue For
                End If
                With objEnKHtiemnang
                    .v_Makhachhang = "KHTN" + (Convert.ToDouble(matiemnang) + i).ToString
                    .nv_Hoten_vn = row("Tên khách hàng").ToString
                    If row("Giới tính").ToString = "Nam" Or row("Giới tính").ToString = "nam" Then
                        .b_Gioitinh = True
                    Else
                        .b_Gioitinh = False
                    End If
                    Dim datesinh As String = row("Ngày sinh").ToString
                    .d_Ngaysinh = Convert.ToDateTime(datesinh, sFormat)
                    .nv_Diachi_vn = row("Địa chỉ").ToString
                    .v_DienthoaiDD = row("Số điện thoại")
                    .d_Ngaynhap = Convert.ToDateTime(row("Ngày nhập").ToString, sFormat)
                    .uId_Cuahang = Session("uId_Cuahang").ToString
                    .uId_Xaphuong = "47014a0c-b3db-4470-91a2-c7fedd0d8953"
                    .uId_Nghenghiep = "30f92db6-58ea-4461-93e5-8d66c1b031a0"
                End With
                Dim uid As String = objFCKHtiemnang.Insert(objEnKHtiemnang)
                With objEnChuyendoi
                    .d_Ngay = Convert.ToDateTime(row("Ngày nhập").ToString, sFormat)
                    .uId_KH_Tiemnang = uid
                    .uId_TrangthaiKH = "e7eb1051-54a3-4915-bb7c-0971be06be33"
                End With
                objFCChuyendoi.Insert(objEnChuyendoi)
                i += 1
                If i >= lengthTb Then
                    Return
                End If
            Next
        End If

        LoadDSKhachhang(BO.Util.ConvertDateTime(deTuNgay.Text), BO.Util.ConvertDateTime(deDenNgay.Text))
        btn_Import.Enabled = True
    End Sub
    Private Sub LoadReport()
        Dim dt As DataTable
        dt = GetData()
        Try
            Dim Bc As New Xtr_CustomerPotential
            Bc.bind(dt)
            ReportViewer1.Report = Bc
            Dim objEnCuahang As New CM.QT_DM_CUAHANGEntity
            Dim objFcCuahang As New BO.QT_DM_CUAHANGFacade
            objEnCuahang = objFcCuahang.SelectByIDCuahang(Session("uId_Cuahang"))
            Bc.lblPKName.Text = objEnCuahang.nv_Tencuahang_vn
            Bc.lblDiachi.Text = objEnCuahang.nv_Diachi_vn
            Bc.lblDienthoai.Text = objEnCuahang.nv_Dienthoai
            Bc.XrPictureBox_logo.ImageUrl = objEnCuahang.nv_Diachi_en
            'Bc.lbl_Diachi.Text = Session("nv_DiachiCH_vn").ToString
            'Bc.lbl_Tencuahang.Text = "Cửa hàng: " + Session("uId_Cuahang").ToString
            'Bc.lbl_Tencuahang.Text = "Cửa hàng: Tất cả"
            'Bc.lbl_Diachi.Text = ""
            'Bc.lbl_Diachi.Text = ""
            'Bc.lbl_Tencuahang.Text = "Cửa hàng: Tất cả"
            Bc.lbl_Tungay.Text = deTuNgay.Text
            Bc.lbl_Denngay.Text = deDenNgay.Text
        Catch ex As Exception

        End Try
    End Sub
    Private Function GetData() As DataTable
        objFCKHtiemnang = New BO.MKT_KH_TIEMNANGFacade
        Dim dt As New DataTable
        Dim tungay As Date
        Dim denngay As Date
        Dim uid_Cuahang As String
        tungay = deTuNgay.Value
        denngay = deDenNgay.Value
        Try
            uid_Cuahang = Session("uId_Cuahang")
            dt = objFCKHtiemnang.SelectAllTable(tungay, denngay, uid_Cuahang)
        Catch ex As Exception
        End Try
        Return dt
        tungay = Nothing
        denngay = Nothing
        uid_Cuahang = Nothing
        objFCKHtiemnang = Nothing
    End Function

#End Region
End Class