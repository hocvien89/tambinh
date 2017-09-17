Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView
Imports System.Data.OleDb
Imports System.IO

Partial Public Class CustomerList
    Inherits System.Web.UI.Page
#Region "Khai bao"
    Private objFCBaocaoKhachhang As BO.clsB_BaoCao_Khachhang
    Private objFCPhieuDV As BO.TNTP_PHIEUDICHVUFacade
    Dim objFCChitietDV As BO.TNTP_PHIEUDICHVU_CHITIETFacade
    Private objFCQTDieutri As BO.TNTP_QT_DieutriFacade
    Private objFCPhieuXuat As BO.QLMH_PHIEUXUATFacade
    Private objFCBaoCaoTaiChinh As BO.clsB_Baocao_Taichinh
    Private objFCCuaHang As BO.QT_DM_CUAHANGFacade
    Dim objFCKhachhang As BO.CRM_DM_KhachhangFacade
    Dim objEnKhachhang As CM.CRM_DM_KhachhangEntity
    Dim objFCNguon As BO.CRM_DM_NGUONFacade
    Dim objFcKhachHang_GoiDichVuFacade As BO.TNTP_KHACHHANG_GOIDICHVUFacade
    Dim oLibP As Lib_SAT.cls_Pub_Functions
    Dim oLog As LogError.ShowError
    Private objFCPhanQuyen As BO.QT_PHANQUYENFacade
    Private objEnPhanQuyen As CM.QT_PHANQUYENEntity
    Private objFCNhatKy As New BO.NHATKYSUDUNGFacade
    Private objFcPhieuxuatChitiet As BO.QLMH_PHIEUXUAT_LOAITTFacade
    Private objFcThetd As BO.clsB_TTV_DM_THETICHDIEM
    Private log As New LogError.ShowError
    Private pc As Public_Class
    Private objEnkhachhangtiemnang As CM.MKT_KH_TIEMNANGEntity
    Private objFckhachhangtiemnang As BO.MKT_KH_TIEMNANGFacade
    Private objEnChuyendoi As CM.MKT_ChuyendoiEntity
    Private objFcChuyendoi As BO.MKT_ChuyendoiFacade
    Private objFcThamsohethong As BO.clsB_QT_THAMSOHETHONG
#End Region
    Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        'Kiem tra da dang nhap chua, neu chua bawt buoc phai dang nhap
        Dim sUid_Nhanvien_Dangnhap As String = ""
        Try
            sUid_Nhanvien_Dangnhap = Session("uId_Nhanvien_Dangnhap")
        Catch ex As Exception
        Finally
            If sUid_Nhanvien_Dangnhap = "" Then Response.Redirect("~/LoginSys.aspx")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            deTuNgay.Date = DateTime.Now.ToString
            deDenNgay.Date = DateTime.Now.ToString
            deNgaysinh.Date = DateTime.Now.ToString
            deNgayden.Date = DateTime.Now.ToString
            'Load dropdownlist
            LoadDropdownlist()
            loadcbo_Nguoigioithieu()
            'LoadcomboMien()
            LoadcomboTinhthanh()
        End If
        LoadDSKhachhang(BO.Util.ConvertDateTime(deTuNgay.Text), BO.Util.ConvertDateTime(deDenNgay.Text))
        loadcbo_Nguoigioithieu()
        'LoadcomboTinhthanh()
        'LoadThetichdiem()
        loadKHbyTen()
        If Session("uId_Khachhang") <> Nothing Then
            Load_Danhsachthe_By_Khachhang()
        End If
    End Sub
#Region "Function User"
    Private Sub LoadcomboTinhthanh()
        Dim objFcNhanvien = New BO.QT_DM_NHANVIENFacade
        Dim dt As DataTable = objFcNhanvien.SelectAllTable(Session("uId_Cuahang").ToString)
        cbo_nhanvientuvan.DataSource = dt
        cbo_nhanvientuvan.ValueField = "uId_Nhanvien"
        cbo_nhanvientuvan.TextField = "nv_Hoten_vn"
        cbo_nhanvientuvan.DataBind()
        cbo_nhanvientuvan.SelectedIndex = 0
    End Sub
    Private Sub LoadDSKhachhang(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime)
        objFCBaocaoKhachhang = New BO.clsB_BaoCao_Khachhang
        objFcThamsohethong = New BO.clsB_QT_THAMSOHETHONG
        objFckhachhangtiemnang = New BO.MKT_KH_TIEMNANGFacade
        Dim dt As DataTable
        If chkViewAll.Checked Then
            dt = objFCBaocaoKhachhang.SelectThongkeKH_ByTime("01/01/2012", DateTime.Now, Session("uId_Cuahang").ToString)
        Else
            dt = objFCBaocaoKhachhang.SelectThongkeKH_ByTime(TuNgay, DenNgay, Session("uId_Cuahang").ToString)
        End If
        If dt.Rows.Count > 0 Then
            dgvDevexpress.DataSource = dt
        End If

        ' -----load khach hang theo tham so he thong
        dgvDevexpress.DataBind()
        objFCBaocaoKhachhang = Nothing
    End Sub
#Region "load data"
    Private Sub LoadDropdownlist()
        objFCNguon = New BO.CRM_DM_NGUONFacade
        ddlNghenghiep.DataSource = objFCNguon.SelectAllTable_ByvType("NGHENGHIEP")
        ddlNghenghiep.TextField = "nv_Nguon_vn"
        ddlNghenghiep.ValueField = "uId_Nguon"
        ddlNghenghiep.SelectedIndex = 0
        ddlNghenghiep.DataBind()
        ddlNguon.DataSource = objFCNguon.SelectAllTable_ByvType("NGUON")
        ddlNguon.TextField = "nv_Nguon_vn"
        ddlNguon.ValueField = "uId_Nguon"
        ddlNguon.SelectedIndex = 0
        ddlNguon.DataBind()
        objFCNguon = Nothing
    End Sub

    Private Sub loadcbo_Nguoigioithieu()
        objFCKhachhang = New BO.CRM_DM_KhachhangFacade
        Dim dt As DataTable
        Dim options As Integer
        If radkh.Checked = True Then
            options = 1
            dt = objFCKhachhang.SelectNggioithieu(Session("uId_Cuahang"), options)
            cbo_Nguoigioithhieu.DataSource = dt
            cbo_Nguoigioithhieu.ValueField = "uId_Khachhang"
            cbo_Nguoigioithhieu.TextField = "nv_Hoten_vn"
            cbo_Nguoigioithhieu.DataBind()
        ElseIf radnv.Checked = True Then
            options = 2
            dt = objFCKhachhang.SelectNggioithieu(Session("uId_Cuahang"), options)
            cbo_Nguoigioithhieu.DataSource = dt
            cbo_Nguoigioithhieu.ValueField = "uId_Nhanvien"
            cbo_Nguoigioithhieu.TextField = "nv_Hoten_vn"
            cbo_Nguoigioithhieu.DataBind()
        ElseIf radnguon.Checked = True Then
            options = 3
            dt = objFCKhachhang.SelectNggioithieu(Session("uId_Cuahang"), options)
            cbo_Nguoigioithhieu.DataSource = dt
            cbo_Nguoigioithhieu.ValueField = "uId_Nguon"
            cbo_Nguoigioithhieu.TextField = "nv_Nguon_vn"
            cbo_Nguoigioithhieu.DataBind()
        End If


       
    End Sub

    'Private Sub LoadThetichdiem()
    '    Dim dtThetd As DataTable
    '    Dim objFcThetd As New BO.clsB_TTV_DM_THETICHDIEM
    '    dtThetd = objFcThetd.SelectAllTable(Session("uId_Cuahang"))
    '    If dtThetd.Rows.Count > 0 Then
    '        cbo_Thetichdiem.ValueField = "uId_Thetichdiem"
    '        cbo_Thetichdiem.TextField = "nv_Tenthetichdiem"
    '        cbo_Thetichdiem.DataSource = dtThetd
    '        cbo_Thetichdiem.DataBind()
    '    End If
    'End Sub
    'Private Sub LoadcomboMien()
    '    Dim item As New ListEditItem
    '    Dim item1 As New ListEditItem
    '    Dim item2 As New ListEditItem
    '    Dim item3 As New ListEditItem
    '    item.Value = "0"
    '    item.Text = "Không xác định"
    '    item1.Value = "1"
    '    item1.Text = "Bắc"
    '    item2.Value = "2"
    '    item2.Text = "Trung"
    '    item3.Value = "3"
    '    item3.Text = "Nam"
    '    cbo_Mien.Items.Add(item)
    '    cbo_Mien.Items.Add(item1)
    '    cbo_Mien.Items.Add(item2)
    '    cbo_Mien.Items.Add(item3)
    '    cbo_Mien.SelectedIndex = 0
    'End Sub
#End Region

#End Region
#Region "Button"
    'Protected Sub btnFilter_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    LoadDSKhachhang(BO.Util.ConvertDateTime(deTuNgay.Text), BO.Util.ConvertDateTime(deDenNgay.Text))
    'End Sub
    Protected Sub btOK_Click(sender As Object, e As EventArgs)
        Try
            oLibP = New Lib_SAT.cls_Pub_Functions
            Dim dt As DataTable
            Dim dtThetd As DataTable
            'Kiem tra Quyen them KH
            objEnPhanQuyen = New CM.QT_PHANQUYENEntity
            objFCPhanQuyen = New BO.QT_PHANQUYENFacade
            Dim objEntheKH As New CM.cls_TTV_KH_ThetichdiemEntity
            Dim objFctheKH As New BO.clsB_TTV_KH_Thetichdiem
            objFcThetd = New BO.clsB_TTV_DM_THETICHDIEM
            objEnkhachhangtiemnang = New CM.MKT_KH_TIEMNANGEntity
            objFckhachhangtiemnang = New BO.MKT_KH_TIEMNANGFacade
            objEnChuyendoi = New CM.MKT_ChuyendoiEntity
            objFcChuyendoi = New BO.MKT_ChuyendoiFacade
            objEnPhanQuyen = objFCPhanQuyen.SelectByID(Session("uId_Nhanvien_Dangnhap").ToString, "D50AAD73-0FCA-45F5-BE58-95ADB0EF3F8B")
            If Not objEnPhanQuyen.b_Enable Then
                ltrError.Text = "<span class='error' id='error'>Bạn không có quyền thêm mới khách hàng!</span>"
                objEnPhanQuyen = Nothing
                objFCPhanQuyen = Nothing
                Exit Sub
            End If

            objEnPhanQuyen = objFCPhanQuyen.SelectByID(Session("uId_Nhanvien_Dangnhap").ToString, "A0C2F5FC-252D-4CC1-B076-BB6C59A7328D")
            If Not objEnPhanQuyen.b_Enable Then
                ltrError.Text = "<span class='error' id='error'>Bạn không có quyền sửa thông tin khách hàng!</span>"
                objEnPhanQuyen = Nothing
                objFCPhanQuyen = Nothing
                Exit Sub
            End If
            objEnPhanQuyen = Nothing
            objFCPhanQuyen = Nothing

            objEnKhachhang = New CM.CRM_DM_KhachhangEntity
            objFCKhachhang = New BO.CRM_DM_KhachhangFacade
            With objEnKhachhang
                .v_Makhachang = ""
                .nv_Hoten_vn = ""
                .v_DienthoaiDD = txtDienthoai.Text
                .v_Email = ""
                .nv_Diachi_vn = ""
                .uId_Cuahang = Session("uId_Cuahang")
            End With
            If Len(objEnKhachhang.v_DienthoaiDD) > 0 Then
                dt = objFCKhachhang.TimKiemKHChuan(objEnKhachhang)
                If dt.Rows.Count > 0 And hdfuIdKhachhang.Value = "" Then
                    ltrError.Text = "<span class='error' id='error'>Số điện thoại đã được đăng ký! </span>"
                    ltrSuccess.Text = ""
                    dt = Nothing
                    Exit Sub
                End If
            End If
            'Kiem tra Trung ma KH
            dt = objFCKhachhang.TimKiemByMaKH(Trim(txtMaKH.Text))
            If dt.Rows.Count > 0 And hdfuIdKhachhang.Value = "" Then
                ltrError.Text = "<span class='error' id='error'>Mã khách hàng đã tồn tại " & oLibP.NullProString(dt.Rows(0).Item("v_Makhachang")) & ":" & oLibP.NullProString(dt.Rows(0).Item("nv_Hoten_vn")) & " - " & oLibP.NullProString(dt.Rows(0).Item("nv_Diachi_vn")) & "</span>"
                dt = Nothing
                Exit Sub
            End If
            'Tao Mot doi tuong Khach hang
            With objEnKhachhang
                Dim op As Integer
                If radkh.Checked = True Then
                    op = 1
                ElseIf radnv.Checked = True Then
                    op = 2
                ElseIf radnguon.Checked = True Then
                    op = 3
                End If
                .uId_Cuahang = Session("uId_Cuahang").ToString
                .v_Makhachang = txtMaKH.Text
                .nv_Hoten_vn = CStr(Me.txtHoten.Text.Trim)
                .d_Ngaysinh = BO.Util.ConvertDateTime("1/1/" + txtNamsinh.Text)
                .nv_Hinhanh = txtImgUrl.Text.Trim
                .v_DienthoaiDD = CStr(Me.txtDienthoai.Text.Trim)
                '.nv_Diachi_vn = CStr(Me.txtDiachi.Text.Trim)
                .nv_Diachi_vn = txtDiachi.Text
                .v_Email = CStr(Me.txtEmail.Text.Trim)
                '-----------harumyspa
                .nv_Hoten_en = ""
                .nv_Diachi_en = txt_Danhgia.Text
                .nv_Nguyenquan_en = op
                .d_Ngayden = BO.Util.ConvertDateTime(deNgayden.Text)
                .uId_Nguonden = ddlNguon.SelectedItem.Value.ToString
                .uId_Nghenghiep = ddlNghenghiep.SelectedItem.Value.ToString
                'If ddlNguon.SelectedItem.Text = "Bạn bè" Or ddlNguon.SelectedItem.Text = "ban be" Then
                '    For Each item As RepeaterItem In rptTags.Items
                '        Dim hdfIndex As HiddenField = TryCast(item.FindControl("hdfIndex"), HiddenField)
                '        .uId_Nguoigioithieu = hdfIndex.Value.ToString()
                '    Next
                'Else
                '    rptTags.DataSource = Nothing
                '    rptTags.DataBind()
                'End If
                .uId_Nguoigioithieu = IIf(oLibP.NullProString(Session("uId_Khachhang_Gioithieu")) = "", "null", Session("uId_Khachhang_Gioithieu"))
                .nv_Nguyenquan_en = op
                .b_Gioitinh = CByte(Me.ddlGioitinh.SelectedItem.Value)
                '.nv_Ghichu_en = Session("sTendangnhap").ToString
                .uId_Xaphuong = "47014a0c-b3db-4470-91a2-c7fedd0d8953"
                .nv_Ghichu_vn = txtGhichu.Text
                'xuanhieu160415 charmnguyenspa thêm tinhda,sk của kh
                '.nv_Diachi_en = txtTinhtrangda.Text
                '.nv_Nguyenquan_en = txtSuckhoe.Text
                '.nv_Hoten_en = txt_Lichsuchamsocda.Text
                '.nv_Diachi_en = txt_Lichsuchamsocsuckhoe.Text
            End With
            'tao mot doi tuong khach hang tiem nang 
            With objEnkhachhangtiemnang
                .uId_Cuahang = Session("uId_Cuahang").ToString
                .v_Makhachhang = txtMaKH.Text
                .nv_Hoten_vn = CStr(Me.txtHoten.Text.Trim)
                .d_Ngaysinh = BO.Util.ConvertDateTime(deNgaysinh.Text)
                .v_DienthoaiDD = CStr(Me.txtDienthoai.Text.Trim)
                '.nv_Diachi_vn = CStr(Me.txtDiachi.Text.Trim)
                .nv_Diachi_vn = txtDiachi.Text
                .v_Email = CStr(Me.txtEmail.Text.Trim)
                .d_Ngaynhap = BO.Util.ConvertDateTime(deNgayden.Text)
                .uId_Nghenghiep = ddlNghenghiep.SelectedItem.Value.ToString
                .b_Gioitinh = CByte(Me.ddlGioitinh.SelectedItem.Value)
                .Ghichu = txtGhichu.Text
                '.nv_Diachi_en = Session("uId_Nhanvien_Dangnhap")
                '.nv_Hoten_en = txt_Lichsuchamsocda.Text
                '.nv_Diachi_en = txt_Lichsuchamsocsuckhoe.Text
            End With
            'Kiem tra xem la Sua thong tin KH, hay them moi khach hang
            If hdfKHGThieu.Value = "" Then
                objEnKhachhang.uId_Nguoigioithieu = ""
            Else
                objEnKhachhang.uId_Nguoigioithieu = hdfKHGThieu.Value
            End If
            If hdfuIdKhachhang.Value = "" Then 'Insert             
                Dim str As String = objFCKhachhang.Insert(objEnKhachhang)
                hdfuIdKhachhang.Value = str
                objEnkhachhangtiemnang.uId_Khachhang = str
                objEnChuyendoi.uId_KH_Tiemnang = (objFckhachhangtiemnang.Insert(objEnkhachhangtiemnang))
                objEnChuyendoi.d_Ngay = Date.Now
                objEnChuyendoi.uId_TrangthaiKH = "e7eb1051-54a3-4915-bb7c-0971be06be33"
                objFcChuyendoi.Insert(objEnChuyendoi)
                'luu vao nhat ky
                objFCNhatKy.Write(Session("sTendangnhap"), System.Environment.MachineName, "Thêm thông tin khách hàng " & txtHoten.Text)
                Session("uId_Khachhang") = str
                If str Is Nothing Then
                    ltrError.Text = "<span class='error' id='error'>Thêm mới thông tin khách hàng lỗi!</span>"
                    Exit Sub
                Else
                    ' tao moi the tich diem
                    pc = New Public_Class
                    dtThetd = objFcThetd.SelectAllTable(Session("uId_Cuahang"))
                    If dtThetd.Rows.Count > 0 Then
                        objEntheKH.uId_Thetichdiem = dtThetd.Rows(0)("uId_Thetichdiem").ToString
                    Else
                        objEntheKH.uId_Thetichdiem = Nothing
                    End If
                    'them the tich diem cho khach
                    With objEntheKH
                        .uId_Khachhang = str
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
                    loadcbo_Nguoigioithieu()
                    ltrSuccess.Text = "<span class='success' id='success'>Thêm mới thông tin khách hàng thành công!</span>"

                End If
            Else 'Update
                objEnKhachhang.uId_Khachhang = hdfuIdKhachhang.Value.ToString
                If Not (objFCKhachhang.Update(objEnKhachhang)) Then
                    ltrError.Text = "<span class='error' id='error'>Cập nhật thông tin khách hàng lỗi!</span>"
                    Exit Sub
                Else
                    objEnkhachhangtiemnang.uId_Khachhang = hdfuIdKhachhang.Value.ToString

                    objEnkhachhangtiemnang.uId_KH_Tiemnang = objFckhachhangtiemnang.SELECTBYMaKHHethong(hdfuIdKhachhang.Value.ToString).uId_KH_Tiemnang
                    If objEnkhachhangtiemnang.uId_KH_Tiemnang <> Nothing Then
                        objFckhachhangtiemnang.Update(objEnkhachhangtiemnang)
                    End If
                    ltrSuccess.Text = "<span class='success' id='success'>Cập nhật thông tin khách hàng thành công!</span>"
                    objFCNhatKy.Write(Session("sTendangnhap"), System.Environment.MachineName, "Sửa thông tin khách hàng " & txtHoten.Text)
                End If
            End If
            'If (Session("uId_Khachhang") <> Nothing) Then 'Update
            '    objEnKhachhang.uId_Khachhang = Session("uId_Khachhang")
            '    If Not (objFCKhachhang.Update(objEnKhachhang)) Then
            '        ltrError.Text = "<span class='error' id='error'>Cập nhật thông tin khách hàng lỗi!</span>"
            '    End If
            'Else ' Insert
            '    Dim str As String = objFCKhachhang.Insert(objEnKhachhang)
            '    Session("uId_Khachhang") = str
            '    If str Is Nothing Then
            '        ltrError.Text = "<span class='error' id='error'>Thêm mới thông tin khách hàng lỗi!</span>"
            '    End If
            'End If
            objEnKhachhang = Nothing
            objFCKhachhang = Nothing
            objEnChuyendoi = Nothing
            objFcChuyendoi = Nothing
            objFckhachhangtiemnang = Nothing
            objEnkhachhangtiemnang = Nothing
            oLibP = Nothing
            txtHoten.Focus()
            ltrError.Text = ""
            imgAnhdaidien.ImageUrl = txtImgUrl.Text
        Catch ex As Exception
            log.WriteLog("(CustomerList: Them / sua khach hang", ex.Message)
        End Try
    End Sub
    Protected Sub btaddbill_Click(sender As Object, e As EventArgs)
        If hdfuIdKhachhang.Value <> "" Then
            Session("uId_Khachhang") = hdfuIdKhachhang.Value.ToString
        End If
        Session("uId_Phieudichvu") = Nothing
        Response.Redirect("~/OrangeVersion/Customer/BillingServices.aspx")
    End Sub
    Protected Sub btnaddproductbill_Click(sender As Object, e As EventArgs)
        If hdfuIdKhachhang.Value <> "" Then
            Session("uId_Khachhang") = hdfuIdKhachhang.Value.ToString
        End If
        Session("uId_Phieudichvu") = Nothing
        Response.Redirect("~/OrangeVersion/Product/ExportProduct.aspx")
    End Sub
    'xuanhieu 5/12/04 import excel
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

    Protected Sub link_Taiexcl_Mau_Click1(sender As Object, e As EventArgs)
        Response.Redirect("../../Excel/Excel_Mau_Khachhang.xls")
    End Sub
#End Region
#Region "Checkbox Function"
    'Protected Sub chkViewAll_CheckedChange(ByVal sender As Object, ByVal e As EventArgs)
    '    If chkViewAll.Checked = True Then
    '        deTuNgay.Enabled = False
    '        deDenNgay.Enabled = False
    '        btnFilter.Enabled = False
    '        LoadDSKhachhang("01/01/2012", DateTime.Now)
    '    Else
    '        deTuNgay.Enabled = True
    '        deDenNgay.Enabled = True
    '        btnFilter.Enabled = True
    '        LoadDSKhachhang(BO.Util.ConvertDateTime(deTuNgay.Text), BO.Util.ConvertDateTime(deDenNgay.Text))
    '    End If
    'End Sub
#End Region
#Region "Grid Event"
    Protected Sub dgvPhieudichvu_BeforePerformDataSelect(sender As Object, e As EventArgs)
        Dim detailGridView As ASPxGridView = DirectCast(sender, ASPxGridView)
        Dim uId_Khachhang As String
        uId_Khachhang = detailGridView.GetMasterRowKeyValue().ToString
        objFCPhieuDV = New BO.TNTP_PHIEUDICHVUFacade
        Dim dt As DataTable = objFCPhieuDV.SelectByDate(uId_Khachhang, "01/01/2012", DateTime.Now)
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
        uId_Khachhang = detailGridView.GetMasterRowKeyValue().ToString
        objFCPhieuXuat = New BO.QLMH_PHIEUXUATFacade
        Dim dt As DataTable = objFCPhieuXuat.SelectByKH(uId_Khachhang, "01/01/2012", DateTime.Now)
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
        uId_Khachhang = detailGridView.GetMasterRowKeyValue().ToString
        objFCBaoCaoTaiChinh = New BO.clsB_Baocao_Taichinh
        Dim dt As DataTable = objFCBaoCaoTaiChinh.Theodoi_CongNo(uId_Khachhang, "01/01/2012", DateTime.Now)
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
        uId_Khachhang = detailGridView.GetMasterRowKeyValue().ToString
        Dim dt As DataTable = objFcKhachHang_GoiDichVuFacade.SelectAllTable_ByKH(uId_Khachhang, 1)
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

    'xuanhieu 5/12/04 xoa hoan toan khach hang
    Protected Sub dgvDevexpress_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        objEnPhanQuyen = New CM.QT_PHANQUYENEntity
        objFCPhanQuyen = New BO.QT_PHANQUYENFacade
        objEnPhanQuyen = objFCPhanQuyen.SelectByID(Session("uId_Nhanvien_Dangnhap").ToString, "17a6247c-c13f-46ac-83ef-8ec58e8ce44d")
        If objEnPhanQuyen.b_Enable = False Then
            CType(sender, ASPxGridView).JSProperties("cpIsAccept") = "false"
        Else
            CType(sender, ASPxGridView).JSProperties("cpIsAccept") = "true"
            Dim uid As String
            uid = e.Keys(0).ToString
            objFCKhachhang = New BO.CRM_DM_KhachhangFacade
            Try
                objFCKhachhang.DeleteByID(uid)
                objFCNhatKy.Write(Session("sTendangnhap"), System.Environment.MachineName, "Xóa khách hàng " & e.Keys(1).ToString)
            Catch ex As Exception

            End Try
        End If
        dgvDevexpress.CancelEdit()
        e.Cancel = True
        LoadDSKhachhang(BO.Util.ConvertDateTime(deTuNgay.Text), BO.Util.ConvertDateTime(deDenNgay.Text))
    End Sub
#End Region
#Region "Import Excel Support"
    'doc file excel tai len tu client dua vao table
    Private Sub Import_To_Grid(ByVal FilePath As String, ByVal Extension As String)
        objFCKhachhang = New BO.CRM_DM_KhachhangFacade
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
        Dim SheetName As String = "Khachhang$"
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
    'tao moi ma khach hang
    Public Function CreateNewCustomerCode() As String
        Dim strMaCH As String
        Dim strMaKH As String
        Dim strMa As String = ""
        objFCCuaHang = New BO.QT_DM_CUAHANGFacade
        objFCKhachhang = New BO.CRM_DM_KhachhangFacade
        If Session("uId_Cuahang") <> Nothing Then
            Dim dt As DataTable = objFCCuaHang.SelectByID(Session("uId_Cuahang").ToString)
            strMaCH = dt.Rows(0)("v_Macuahang").ToString
            strMaKH = objFCKhachhang.MaKH(Session("uId_Cuahang").ToString)
            If strMaKH.Length < 6 Then
                For i As Integer = strMaKH.Length To 5
                    strMaKH = "0" + strMaKH
                Next
            End If
            strMa = strMaCH + strMaKH
            objFCCuaHang = Nothing
            objFCKhachhang = Nothing
            dt = Nothing
        End If
        Return strMa
    End Function
    'doc table tu excel va insert vao database
    Private Sub ExcelInsert(dt As DataTable)
        Dim sFormat As System.Globalization.DateTimeFormatInfo = New System.Globalization.DateTimeFormatInfo()
        sFormat.ShortDatePattern = "dd/MM/yyyy"
        objEnKhachhang = New CM.CRM_DM_KhachhangEntity
        objFckhachhangtiemnang = New BO.MKT_KH_TIEMNANGFacade
        objEnkhachhangtiemnang = New CM.MKT_KH_TIEMNANGEntity
        objEnChuyendoi = New CM.MKT_ChuyendoiEntity
        objFcChuyendoi = New BO.MKT_ChuyendoiFacade
        Dim uid_Khachhang As String
        'Dim da As OleDbDataAdapter = New OleDbDataAdapter()
        'Dim dt2 As DataTable
        'dt2 = objFCKhachhang.SelectAllTable(Session("uId_Cuahang"))
        'For Each row1 As DataRow In dt.Rows
        'Dim Expression As String
        'Expression = CType(row1.Item(0), String).ToString
        'Dim drs() As DataRow = dt2.Select(Expression)
        'If drs.Length > 0 Then
        '    For i As Integer = 0 To dt2.Rows.Count - 1
        '        drs(0).Item(i) = row1.Item(i)
        '    Next
        'Else
        '    Dim drnew As DataRow = dt2.NewRow
        '    For i As Integer = 1 To dt2.Rows.Count - 1
        '        drnew.Item(i) = row1.Item(i)
        '    Next
        '    dt2.Rows.Add(drnew)
        '    'End If
        'Next
        'objFCKhachhang.InsertTabl(dt)
        'da.Update(dt2)

        Dim i As Integer = 0
        Dim lengthDt As Integer
        If dt.Rows.Count < 3000 Then
            lengthDt = dt.Rows.Count - 1
        Else
            lengthDt = 3000 - 1
        End If
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                Dim makhachhang As String = CreateNewCustomerCode()
                If row("Họ và tên").ToString = "" Then
                    Continue For
                End If
                With objEnKhachhang
                    .v_Makhachang = makhachhang
                    .nv_Hoten_vn = row("Họ và tên").ToString
                    .d_Ngaysinh = row("Ngày sinh").ToString
                    If row("Địa chỉ").ToString = "" Then
                        .nv_Diachi_vn = ""
                    Else
                        .nv_Diachi_vn = row("Địa chỉ").ToString
                    End If
                    .v_DienthoaiDD = IIf(row("Điện thoại").ToString = "", "", row("Điện thoại"))
                    .v_Email = IIf(row("Email").ToString = "", "", row("Email").ToString)
                    If row("Ngày đến").ToString = "" Then
                        .d_Ngayden = DateTime.Now
                    Else
                        .d_Ngayden = row("Ngày đến").ToString
                    End If
                    .nv_Ghichu_en = Nothing
                    .nv_Ghichu_vn = Session("sTendangnhap").ToString
                    If row("Giới tính").ToString = "Nam" Or row("Giới tính").ToString = "nam" Then
                        .b_Gioitinh = True
                    Else
                        .b_Gioitinh = False
                    End If
                    .nv_Nguyenquan_vn = Nothing
                    .uId_Cuahang = Session("uId_Cuahang").ToString
                    .uId_Xaphuong = "47014a0c-b3db-4470-91a2-c7fedd0d8953"
                    .uId_Nghenghiep = "6ea10344-f342-4972-9b05-e2111c5c092e"
                    .uId_Nguonden = "67b63fa5-975f-4ab6-b8cb-07eca8ff7628"
                    '.nv_Hoten_en = txt_Lichsuchamsocda.Text
                    '.nv_Diachi_en = txt_Lichsuchamsocsuckhoe.Text
                End With
                objFCKhachhang = New BO.CRM_DM_KhachhangFacade
                uid_Khachhang = objFCKhachhang.Insert(objEnKhachhang)
                With objEnkhachhangtiemnang
                    .uId_Cuahang = Session("uId_Cuahang").ToString
                    .v_Makhachhang = makhachhang
                    .nv_Hoten_vn = row("Họ và tên").ToString
                    .d_Ngaysinh = row("Ngày sinh").ToString
                    .v_DienthoaiDD = IIf(row("Điện thoại").ToString = "", "", row("Điện thoại"))
                    If row("Địa chỉ").ToString = "" Then
                        .nv_Diachi_vn = ""
                    Else
                        .nv_Diachi_vn = row("Địa chỉ").ToString
                    End If
                    .v_Email = IIf(row("Email").ToString = "", "", row("Email").ToString)
                    If row("Ngày đến").ToString = "" Then
                        .d_Ngaynhap = DateTime.Now
                    Else
                        .d_Ngaynhap = row("Ngày đến").ToString
                    End If
                    .uId_Khachhang = uid_Khachhang
                    .uId_Nghenghiep = "6ea10344-f342-4972-9b05-e2111c5c092e"
                    If row("Giới tính").ToString = "Nam" Or row("Giới tính").ToString = "nam" Then
                        .b_Gioitinh = True
                    Else
                        .b_Gioitinh = False
                    End If
                    .Ghichu = txtGhichu.Text
                    .nv_Diachi_en = Session("uId_Nhanvien_Dangnhap")
                    '.nv_Diachi_en = txt_Lichsuchamsocsuckhoe.Text
                    '.nv_Hoten_en = txt_Lichsuchamsocda.Text
                End With
                objEnChuyendoi.uId_KH_Tiemnang = objFckhachhangtiemnang.Insert(objEnkhachhangtiemnang)
                objEnChuyendoi.d_Ngay = Date.Now
                objEnChuyendoi.uId_TrangthaiKH = "B78F8A7A-EBC0-4E95-9F16-D8E715CD950F"
                objFcChuyendoi.Insert(objEnChuyendoi)
                i += 1
                If i > lengthDt Then
                    Return
                End If
            Next
        End If
        objEnKhachhang = Nothing
        objFCKhachhang = Nothing
        objEnChuyendoi = Nothing
        objFcChuyendoi = Nothing
        objFckhachhangtiemnang = Nothing
        objEnkhachhangtiemnang = Nothing
        LoadDSKhachhang(BO.Util.ConvertDateTime(deTuNgay.Text), BO.Util.ConvertDateTime(deDenNgay.Text))
    End Sub
#End Region
    Private Sub loadKHbyTen()
        objFCKhachhang = New BO.CRM_DM_KhachhangFacade
        Dim dt As DataTable
        If txtHoten.Text <> "" Then
            dt = objFCKhachhang.SearchByKey(txtHoten.Text)
            If dt.Rows.Count > 0 Then
                GrvDanhsachsearch.DataSource = dt
                GrvDanhsachsearch.DataBind()
            End If
        End If
    End Sub

    Protected Sub cbo_Nguoigioithhieu_Callback(sender As Object, e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase)
        loadcbo_Nguoigioithieu()
    End Sub
    Protected Sub Load_Danhsachthe_By_Khachhang()
        Dim objFCGoiDV As New BO.TNTP_KHACHHANG_GOIDICHVUFacade
        Dim uId_Khachhang As String = Session("uId_Khachhang")
        Dim dt As DataTable = objFCGoiDV.SelectAllTable_ByKH(uId_Khachhang, 1)
        dgvDsTheTT.DataSource = dt
        dgvDsTheTT.DataBind()
    End Sub
    Protected Sub btn_Search_The_Click(sender As Object, e As EventArgs)
        Dim objFCGoiDV As New BO.TNTP_KHACHHANG_GOIDICHVUFacade
        Dim dt As DataTable
        Dim v_Mathe As String = txt_Mathe.Text
        dt = objFCGoiDV.SelectBy_Mathe(v_Mathe)
        dgvDsTheTT.DataSource = dt
        dgvDsTheTT.DataBind()
    End Sub

    Protected Sub bnt_ExportExcel_Click(sender As Object, e As EventArgs)
       dgvexport.WriteXlsToResponse()
    End Sub
End Class