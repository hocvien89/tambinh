Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView

Public Class ExportProduct
    Inherits System.Web.UI.Page
    Dim objFcDMKho As BO.QLMH_DM_KHOFacade
    Dim objFcDmMathang As BO.QLMH_DM_MATHANGFacade
    Dim objFcPhieuxuat As BO.QLMH_PHIEUXUATFacade
    Dim objEnPhieuxuat As CM.QLMH_PHIEUXUATEntity
    Dim objEnPhieuxuat_old As CM.QLMH_PHIEUXUATEntity
    Dim objFCQuydoidv As BO.DMQuyDoiDonViFacade
    Dim objFCPhanQuyen As BO.QT_PHANQUYENFacade
    Dim objFcKhachhang As BO.CRM_DM_KhachhangFacade
    Dim objFcNhanvien As BO.QT_DM_NHANVIENFacade
    Dim objFCLoaiTT As BO.QLTC_LoaiHinhTTFacade
    Dim objFCGoiDV As BO.TNTP_KHACHHANG_GOIDICHVUFacade
    Dim objEnGoiDV As CM.TNTP_KHACHHANG_GOIDICHVUEntity
    Private objFCNhatKy As BO.NHATKYSUDUNGFacade
    Dim objFcPhieuxuatLoaiTT As BO.QLMH_PHIEUXUAT_LOAITTFacade
    Dim objEnPhieuxuatLoaiTT As CM.QLMH_PHIEUXUAT_LOAITTEntity
    Dim objEnphieuxuatchitiet As CM.QLMH_PHIEUXUATEntity

    Dim objEnthetichdiem As CM.icls_TTV_DM_ThetichdiemEntity
    Dim objFcThetichdiem As BO.clsB_TTV_DM_THETICHDIEM
    Dim objEnTtdKh As CM.cls_TTV_KH_ThetichdiemEntity
    Dim objFcTtdKh As BO.clsB_TTV_KH_Thetichdiem
    Dim objEnTtdLichsu As CM.cls_TTV_KH_Thetichdiem_LichsuEntity
    Dim objFcTtdLichdu As BO.clsB_TTV_KH_Thetichdiem_Lichsu

    Dim oLibP As New Lib_SAT.cls_Pub_Functions
    Private pc As New Public_Class
    Dim f_Tienmathang As Double = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            deNgayxuat.Date = DateTime.Now
            deTungay.Date = DateTime.Now
            deDenNgay.Date = DateTime.Now
            LoadDropDownlist()
            txtMaphieu.Text = pc.ReturnAutoString("PX")
            Session("uId_Phieuxuat") = Nothing
            If Session("uId_Phieuxuat") <> Nothing Then
                LoadThongTinPhieuXuat()
            End If
            'ddlDMKho.Value = "18a906d7-e63c-459c-ba81-b85d1a01f2ea"
            'ddlDMKho.ReadOnly = True
        End If
        If Session("uId_Phieuxuat") <> Nothing Then
            LoadDMMathang()
            Loadphieuchitiet()
            'LoadThongTinPhieuXuat()
            LoadDSLoaiTT()
        End If
        LoadDropDown_Khachhang()
        If Session("uId_Khachhang") <> Nothing Then
            dgvDsTheTT.DataBind()
            ddlKhachhang.Value = Session("uId_Khachhang")
        End If
        LoadDSPhieu()
    End Sub

#Region "Load thong tin"
    Private Sub LoadDropDownlist()
        objFcDMKho = New BO.QLMH_DM_KHOFacade
        objFcNhanvien = New BO.QT_DM_NHANVIENFacade
        Dim dt As DataTable
        dt = objFcDMKho.SelectAllTable(Session("uId_Cuahang"))
        ddlDMKho.DataSource = dt
        ddlDMKho.ValueField = "uId_Kho"
        ddlDMKho.TextField = "nv_Tenkho_vn"
        ddlDMKho.DataBind()
        ddlDMKho.SelectedIndex = 1

        Dim listItem0 As New ListEditItem
        listItem0.Value = "0"
        listItem0.Text = "Tất cả"
        ddlDsKho.Items.Add(listItem0)
        For Each row As DataRow In dt.Rows
            Dim listItem As New ListEditItem
            listItem.Value = row("uId_Kho")
            listItem.Text = row("nv_Tenkho_vn")
            ddlDsKho.Items.Add(listItem)
        Next
        ddlDsKho.Value = "0"

        dt = New DataTable
        dt = objFcNhanvien.SelectAllTable(Session("uId_Cuahang"))
        ddlNhanvien.DataSource = dt
        ddlNhanvien.ValueField = "uId_Nhanvien"
        ddlNhanvien.TextField = "nv_Hoten_vn"
        ddlNhanvien.DataBind()
        ddlNhanvien.Value = Session("uId_Nhanvien_Dangnhap")

        dt = New DataTable
        objFCLoaiTT = New BO.QLTC_LoaiHinhTTFacade
        dt = objFCLoaiTT.SelectAllTable()
        For Each row As DataRow In dt.Rows
            Dim item As New ListEditItem
            item.Value = row("uId_LoaiTT")
            item.Text = row("nv_TenLoaiTT")
            ddlLoaithanhtoan.Items.Add(item)
        Next
        ddlLoaithanhtoan.DataSource = objFCLoaiTT.SelectAllTable()
        ddlLoaithanhtoan.TextField = "nv_TenLoaiTT"
        ddlLoaithanhtoan.ValueField = "uId_LoaiTT"
        ddlLoaithanhtoan.DataBind()
        ddlLoaithanhtoan.Value = "43915768-694a-49b8-8db2-6332718db194"

        'For Each row As DataRow In dt.Rows
        '    If row("v_MaLoaiTT") <> "MUTIL" Then
        '        Dim item As New ListEditItem
        '        item.Value = row("uId_LoaiTT")
        '        item.Text = row("nv_TenLoaiTT")
        '        ddlHinhthucTT_Pop.Items.Add(item)
        '    End If
        'Next
        ddlHinhthucTT_Pop.DataSource = objFCLoaiTT.SelectAllTable()
        ddlHinhthucTT_Pop.TextField = "nv_TenLoaiTT"
        ddlHinhthucTT_Pop.ValueField = "uId_LoaiTT"
        ddlHinhthucTT_Pop.DataBind()
    End Sub

    Private Sub LoadDMMathang()
        objFcDmMathang = New BO.QLMH_DM_MATHANGFacade
        objEnPhieuxuat = New CM.QLMH_PHIEUXUATEntity
        objFcPhieuxuat = New BO.QLMH_PHIEUXUATFacade
        If Session("uId_Phieuxuat") <> Nothing Then
            objEnPhieuxuat = objFcPhieuxuat.SelectByID(BO.Util.IsString(Session("uId_Phieuxuat")))
            Dim dt As DataTable
            dt = objFcDmMathang.Bang_Tonghop_Ton(DateTime.Now, objEnPhieuxuat.d_Ngayxuat, objEnPhieuxuat.uId_Kho.ToString, Session("uId_Cuahang"))
            If dt.Rows.Count > 0 Then
                ddlMathang.DataSource = dt
                ddlMathang.ValueField = "uId_Mathang"
                ddlMathang.TextField = "nv_TenMathang_vn"
                ddlMathang.DataBind()
            End If
        Else
            ddlMathang.DataSource = Nothing
            ddlMathang.DataBind()
        End If
    End Sub

    '==Load danh sach don vi theo ma vat tu
    Private Sub LoadDonViTheoMa()
        objFCQuydoidv = New BO.DMQuyDoiDonViFacade
        Dim dt As DataTable
        dt = objFCQuydoidv.LoadDSDonViTheoVatTu(ddlMathang.Value.ToString)
        If dt.Rows.Count > 0 Then
            ddlDonvi.DataSource = dt
            ddlDonvi.ValueField = "MaDonVi"
            ddlDonvi.TextField = "TenDonVi"
            ddlDonvi.DataBind()
        Else
            ddlDonvi.Items.Clear()
            ddlDonvi.Text = ""
        End If
        ddlDonvi.SelectedIndex = 0
    End Sub

    '==Load Grid chi tiet
    Private Sub Loadphieuchitiet()
        objFcPhieuxuat = New BO.QLMH_PHIEUXUATFacade
        Dim dt As DataTable
        dt = objFcPhieuxuat.SelectByID_QLMH_PHIEUXUAT_CHITIET(Session("uId_Phieuxuat"))
        If dt.Rows.Count > 0 Then
            dgvDevexpress.DataSource = dt
            dgvDevexpress.DataBind()
        Else
            dgvDevexpress.DataSource = Nothing
            dgvDevexpress.DataBind()
        End If
    End Sub

    Private Sub LoadDropDown_Khachhang()
        objFcKhachhang = New BO.CRM_DM_KhachhangFacade
        Dim dt As DataTable
        dt = objFcKhachhang.SelectAllTable(Session("uId_Cuahang"))
        ddlKhachhang.DataSource = dt
        ddlKhachhang.ValueField = "uId_Khachhang"
        ddlKhachhang.TextField = "nv_Hoten_vn"
        ddlKhachhang.DataBind()
    End Sub

    '==Load danh sach the thanh toan
    Private Sub LoadDSTheTT()
        objFCGoiDV = New BO.TNTP_KHACHHANG_GOIDICHVUFacade
        Dim dt As DataTable
        dt = objFCGoiDV.SelectAllTable_ByKH(Session("uId_Khachhang"), 1)
        dgvDsTheTT.DataSource = dt
    End Sub

    '==Load danh sach phieu xuat
    Private Sub LoadDSPhieu()
        objFcPhieuxuat = New BO.QLMH_PHIEUXUATFacade
        Dim dt As DataTable
        dt = objFcPhieuxuat.Timkiem(ddlDsKho.SelectedItem.Value.ToString, BO.Util.ConvertDateTime(deTungay.Text), BO.Util.ConvertDateTime(deDenNgay.Text), "PX")
        dgvDanhsachphieu.DataSource = dt
        dgvDanhsachphieu.DataBind()
    End Sub

    '==Load thong tin phieu xuat
    Private Sub LoadThongTinPhieuXuat()
        objEnPhieuxuat = New CM.QLMH_PHIEUXUATEntity
        objFcPhieuxuat = New BO.QLMH_PHIEUXUATFacade
        objEnPhieuxuat = objFcPhieuxuat.SelectByID(Session("uId_Phieuxuat"))
        ddlDMKho.Value = objEnPhieuxuat.uId_Kho
        txtMaphieu.Text = objEnPhieuxuat.v_Maphieuxuat
        ddlKhachhang.Value = objEnPhieuxuat.uId_Khachhang
        deNgayxuat.Date = objEnPhieuxuat.d_Ngayxuat
        txtGhichu.Text = objEnPhieuxuat.nv_Noidungxuat_vn
        txtGiamgiaPhieu.Text = String.Format("{0:#,##0}", BO.Util.IsDouble(objEnPhieuxuat.f_Giamgia_Tong))
        lblTongtien.Text = String.Format("{0:#,##0}", Val(objEnPhieuxuat.nv_Noidungxuat_en))
        lblConlai.Text = String.Format("{0:#,##0}", Val(objEnPhieuxuat.nv_Noidungxuat_en) - objEnPhieuxuat.f_Giamgia_Tong)
        txtSothang.Text = objEnPhieuxuat.i_Soluog
        chkChike.Checked = objEnPhieuxuat.b_Dathanhtoan
        txtDongiathang.Text = String.Format("{0:#,##0}", BO.Util.IsDouble(objEnPhieuxuat.f_Gia))
        Dim tiennhan As Integer
        tiennhan = Integer.Parse(BO.Util.IsDouble(objEnPhieuxuat.f_Tongtienthuc))
        If tiennhan > 0 Then
            txtSotiennhan.Text = String.Format("{0:#,##0}", tiennhan)
        Else
            txtSotiennhan.Text = "0"
        End If
        lblTienthua.Text = String.Format("{0:#,##0}", Val(lblConlai.Text.Replace(",", "")) - Val(txtSotiennhan.Text.Replace(",", "")))
        If objEnPhieuxuat.uId_LoaiTT <> "" And objEnPhieuxuat.uId_LoaiTT <> Nothing Then
            ddlLoaithanhtoan.Value = objEnPhieuxuat.uId_LoaiTT
        Else
            ddlLoaithanhtoan.Value = "43915768-694a-49b8-8db2-6332718db194"
        End If
        If objEnPhieuxuat.uId_Nhanvien <> "" And objEnPhieuxuat.uId_Nhanvien <> Nothing Then
            ddlNhanvien.Value = objEnPhieuxuat.uId_Nhanvien
        Else
            ddlNhanvien.Value = Session("uId_Nhanvien_Dangnhap")
        End If
    End Sub

    '==Load thong tin loai thanh toan cua phieu xuat
    Private Sub LoadDSLoaiTT()
        objFcPhieuxuatLoaiTT = New BO.QLMH_PHIEUXUAT_LOAITTFacade
        Dim dt As DataTable
        dt = objFcPhieuxuatLoaiTT.SelectByPhieuDV(Session("uId_Phieuxuat").ToString)
        If dt.Rows.Count > 0 Then
            dgvLoaiTT.DataSource = dt
            dgvLoaiTT.DataBind()
        Else
            dgvLoaiTT.DataSource = Nothing
            dgvLoaiTT.DataBind()
        End If
        objFCLoaiTT = Nothing
    End Sub
#End Region
#Region "Button"
    'Protected Sub btnLuu_Click(sender As Object, e As EventArgs)
    '    If Session("uId_Khachhang") <> Nothing Then
    '        objFCPhanQuyen = New BO.QT_PHANQUYENFacade
    '        objEnPhieuxuat = New CM.QLMH_PHIEUXUATEntity
    '        objFcPhieuxuat = New BO.QLMH_PHIEUXUATFacade
    '        objFCNhatKy = New BO.NHATKYSUDUNGFacade
    '        Dim checkKhoaPhieu As Boolean
    '        checkKhoaPhieu = objFcPhieuxuat.SelectByID(Session("uId_Phieuxuat")).b_IsKhoa
    '        Dim dt_KP As New DataTable
    '        dt_KP = objFCPhanQuyen.SelectAllTable(Session("uId_Nhanvien_Dangnhap"), "67e68aea-9dbd-43d5-b316-e5ad9c0e6fd3")
    '        If checkKhoaPhieu = False Or dt_KP.Rows.Count > 0 Then
    '            Dim sUid_Phieuxuat As String = ""
    '            objEnPhieuxuat.uId_Khachhang = Session("uId_Khachhang")
    '            objEnPhieuxuat.uId_Kho = ddlDMKho.SelectedItem.Value.ToString
    '            objEnPhieuxuat.uId_Nhanvien = ddlNhanvien.SelectedItem.Value.ToString
    '            objEnPhieuxuat.v_Maphieuxuat = txtMaphieu.Text
    '            objEnPhieuxuat.d_Ngayxuat = BO.Util.ConvertDateTime(deNgayxuat.Text)
    '            objEnPhieuxuat.nv_Noidungxuat_vn = txtGhichu.Text
    '            objEnPhieuxuat.f_Giamgia_Tong = 0
    '            objEnPhieuxuat.f_Tongtienthuc = 0
    '            If Session("uId_Phieuxuat") = Nothing Then
    '                Dim dt_Test As DataTable
    '                dt_Test = objFcPhieuxuat.SelectBySoPhieuXuat(txtMaphieu.Text)
    '                If dt_Test.Rows.Count > 0 Then
    '                    ShowMessage(Me, "Trùng mã phiếu!!")
    '                Else
    '                    sUid_Phieuxuat = objFcPhieuxuat.Insert(objEnPhieuxuat)
    '                    objFCNhatKy.Write(Session("sTendangnhap"), System.Environment.MachineName, "Thêm mới phiếu xuất mã " & txtMaphieu.Text)
    '                    ShowMessage(Me, "Thêm mới thành công!")
    '                    Session("uId_Phieuxuat") = sUid_Phieuxuat
    '                End If
    '            Else
    '                objEnPhieuxuat.uId_Phieuxuat = Session("uId_Phieuxuat").ToString
    '                objFcPhieuxuat.Update(objEnPhieuxuat)
    '                objFCNhatKy.Write(Session("sTendangnhap"), System.Environment.MachineName, "Sửa thông tin phiếu xuất mã " & txtMaphieu.Text)
    '                ShowMessage(Me, "Cập nhật thành công!")
    '            End If
    '            If Session("uId_Phieuxuat") <> Nothing Then
    '                LoadDMMathang()
    '            End If
    '            ddlMathang.Focus()
    '        Else
    '            ShowMessage(Me, "Phiếu đã khóa!")
    '        End If
    '    End If
    'End Sub

    'Protected Sub btnClear_Click(sender As Object, e As EventArgs)
    '    txtMaphieu.Text = pc.ReturnAutoString("PX")
    '    txtGhichu.Text = ""
    '    Session("uId_Phieuxuat") = Nothing
    '    Session("uId_Khachhang") = Nothing
    '    LoadDMMathang()
    '    Loadphieuchitiet()
    '    txtSoluong.Text = "1"
    '    txtSotiennhan.Text = "0"
    '    lblTongtien.Text = "0"
    '    txtGiamgiaPhieu.Text = "0"
    '    lblConlai.Text = "0"
    '    lblTienthua.Text = "0"
    '    ddlKhachhang.Text = ""
    'End Sub

    Protected Sub btnFilter_Click(sender As Object, e As EventArgs)
        LoadDSPhieu()
    End Sub
    'Protected Sub Luu_KeKhai_Click(sender As Object, e As EventArgs)
    '    If Session("uId_Phieuxuat") <> Nothing Then
    '        Dim f_Giatrigoi As Double
    '        objEnPhieuxuatLoaiTT = New CM.QLMH_PHIEUXUAT_LOAITTEntity
    '        objFcPhieuxuatLoaiTT = New BO.QLMH_PHIEUXUAT_LOAITTFacade
    '        objFCGoiDV = New BO.TNTP_KHACHHANG_GOIDICHVUFacade
    '        objEnGoiDV = New CM.TNTP_KHACHHANG_GOIDICHVUEntity
    '        Dim Tongtien As String = ""
    '        Tongtien = objFcPhieuxuatLoaiTT.SelectTongtien(Session("uId_Phieuxuat"))
    '        'sum = Convert.ToDouble(IsDouble(Tongtien))
    '        'sums = sum + Convert.ToDouble(IsDouble(txtSotienTT_Pop.Text.Replace(",", "")))
    '        'If sums > Convert.ToDouble(IsDouble(txtSotiennhanTT.Text.Replace(",", ""))) Then
    '        '    lblError.Text = "<span style='color:red; font-style:italic'>Tổng kê khai phải nhỏ hơn số tiền nhận</span>"
    '        'Else
    '        '    lblError.Text = ""

    '        'End If
    '        objEnPhieuxuatLoaiTT.uId_LoaiTT = ddlHinhthucTT_Pop.Value
    '        objEnPhieuxuatLoaiTT.uId_Phieuxuat = Session("uId_Phieuxuat").ToString
    '        objEnPhieuxuatLoaiTT.f_Sotien = txtSotienTT_Pop.Text.Replace(",", "")
    '        objEnPhieuxuatLoaiTT.v_Maso = txtMaSoTT_Pop.Text
    '        objEnPhieuxuatLoaiTT.nv_Ghichu_vn = txtGhichu.Text
    '        Try
    '            objFcPhieuxuatLoaiTT.Insert(objEnPhieuxuatLoaiTT)
    '            'Lay ra gia tri goi the tai khoan cua khach hang hien tai
    '            objEnGoiDV = objFCGoiDV.SelectByvMaBarcode(txtMaSoTT_Pop.Text)
    '            f_Giatrigoi = objEnGoiDV.f_Giatrigoi

    '            objEnGoiDV = New CM.TNTP_KHACHHANG_GOIDICHVUEntity
    '            If (f_Giatrigoi > CDbl(txtSotienTT_Pop.Text.Replace(",", ""))) Then
    '                objEnGoiDV.f_Sotien = f_Giatrigoi - CDbl(txtSotienTT_Pop.Text.Replace(",", ""))
    '            Else
    '                objEnGoiDV.f_Sotien = 0
    '            End If
    '            objEnGoiDV.uId_Khachhang_Goidichvu = oLibP.NullProString(Session("uId_Khachhang_Goidichvu_TT"))
    '            objFCGoiDV.ThanhToan(objEnGoiDV)
    '            txtMaSoTT_Pop.Text = ""
    '            txtGhichu.Text = ""
    '            txtSotienTT_Pop.Text = ""
    '            Session("uId_Khachhang_Goidichvu_TT") = Nothing
    '            txtSotienTT_Pop.Focus()
    '            LoadDSLoaiTT()
    '        Catch ex As Exception

    '        End Try
    '        objEnPhieuxuatLoaiTT = Nothing
    '        objFcPhieuxuatLoaiTT = Nothing
    '    End If
    'End Sub
#End Region
#Region "Dropdown event"
    Protected Sub ddlDonvi_Callback(sender As Object, e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase)
        LoadDonViTheoMa()
    End Sub
#End Region
#Region "Grid Event"
    Protected Sub dgvDevexpress_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        objFcPhieuxuat = New BO.QLMH_PHIEUXUATFacade
        objEnphieuxuatchitiet = New CM.QLMH_PHIEUXUATEntity
        Dim uId_Phieuxuatchitiet As String
        Dim sophieu As String
        objFcTtdKh = New BO.clsB_TTV_KH_Thetichdiem
        uId_Phieuxuatchitiet = e.Keys(0).ToString
        f_Tienmathang = Convert.ToDouble(e.Values("f_Tongtien"))
        sophieu = e.Values("v_Sophieu")
        Dim dtphieuchitiet As DataTable
        Dim dtthekh As DataTable
        Try
            'kiem tra phieu mh da thanh toan chua. neu thanh toan roi thi phải tru tien di. neu da thanh toan het
            'thi tru diem tich trong the di
            'kiem tra phieu xuat da thanh toan du chua f_Tongthanhtoan vs sum(i_Tongtien)
            'tru tien da thanh toan
            objEnphieuxuatchitiet = objFcPhieuxuat.SelectQLMH_PHIEUXUAT_CHITIET_ByID(uId_Phieuxuatchitiet)
            objEnPhieuxuat = objFcPhieuxuat.SelectByID(Session("uId_Phieuxuat").ToString)
            dtthekh = objFcTtdKh.SelectByIdKH(Session("uId_Khachhang").ToString) ' tong tin the cua kh mua mat hang


            'tru diem the ap dung voi nhung mh ma phieu mat hang do thanh toan het khi mua
            dtphieuchitiet = objFcPhieuxuat.SelectByID_QLMH_PHIEUXUAT_CHITIET(Session("uId_Phieuxuat").ToString)
            Dim tongchitiet As Double = 0
            If dtphieuchitiet.Rows.Count > 0 Then
                For i As Integer = 0 To dtphieuchitiet.Rows.Count - 1 Step 1
                    tongchitiet += Convert.ToDouble(dtphieuchitiet.Rows(i)("f_Tongtien").ToString)
                Next
            End If
            'tru diem nguoi mua
            If objEnPhieuxuat.f_Tongtienthuc >= 0 Then
                Tinhdiemtichluy(dtthekh, f_Tienmathang, "người mua", sophieu)
                ' tru diem nguoi gioi thieu
                'If objFcKhachhang.SelectByID(Session("uId_Khachhang").ToString).uId_Nguoigioithieu <> Nothing Then
                '    Dim dtnguoigioithieu As DataTable
                '    dtnguoigioithieu = objFcTtdKh.SelectByIdKH(objFcKhachhang.SelectByID(Session("uId_Khachhang").ToString).uId_Nguoigioithieu)
                '    Tinhdiemtichluy(dtnguoigioithieu, f_Tienmathang, "người giới thiệu", sophieu)
                'End If
            End If
            If objEnPhieuxuat.f_Tongtienthuc - objEnphieuxuatchitiet.f_Tongtien >= 0 Then ' duoc tru tien da thanh toan
                objEnPhieuxuat.f_Tongtienthuc -= objEnphieuxuatchitiet.f_Tongtien
                objFcPhieuxuat.Update(objEnPhieuxuat)
            End If
            objFcPhieuxuat.DeleteByID_QLMH_PHIEUXUAT_CHITIET(uId_Phieuxuatchitiet)
        Catch ex As Exception
        End Try
        e.Cancel = True
        Loadphieuchitiet()
    End Sub
    Protected Sub dgvDsTheTT_DataBinding(sender As Object, e As EventArgs)
        LoadDSTheTT()
    End Sub
    Protected Sub dgvDanhsachphieu_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        objFcPhieuxuat = New BO.QLMH_PHIEUXUATFacade
        objFCNhatKy = New BO.NHATKYSUDUNGFacade
        objFcTtdKh = New BO.clsB_TTV_KH_Thetichdiem
        Try
            Dim uId_Phieuxuat As String
            Dim v_sophieu As String
            Dim f_Tongthanhtoan As Double
            Dim uId_Khachhang As String
            uId_Phieuxuat = e.Keys(0).ToString
            v_sophieu = e.Values("v_Maphieuxuat").ToString
            f_Tongthanhtoan = e.Values("f_Tongtienthuc")
            uId_Khachhang = e.Values("uId_Khachhang").ToString
            If objFcTtdKh.SelectByIdKH(uId_Khachhang).Rows.Count > 0 Then
                Dim dt As DataTable
                Dim tongtien As Double = 0
                dt = objFcPhieuxuat.SelectByID_QLMH_PHIEUXUAT_CHITIET(uId_Phieuxuat)
                If dt.Rows.Count > 0 Then
                    For i As Integer = 0 To dt.Rows.Count - 1
                        tongtien += Convert.ToDouble(dt.Rows(i)("f_Tongtien").ToString)
                    Next
                End If
                If f_Tongthanhtoan - tongtien >= 0 Then
                    Tinhdiemtichluy(objFcTtdKh.SelectByIdKH(uId_Khachhang), f_Tongthanhtoan, "", v_sophieu)
                    If objFcKhachhang.SelectByID(uId_Khachhang).uId_Nguoigioithieu <> Nothing Then
                        If objFcTtdKh.SelectByIdKH(objFcKhachhang.SelectByID(uId_Khachhang).uId_Nguoigioithieu).Rows.Count > 0 Then
                            Tinhdiemtichluy(objFcTtdKh.SelectByIdKH(objFcKhachhang.SelectByID(uId_Khachhang).uId_Nguoigioithieu), f_Tongthanhtoan, "người giới thiệu", v_sophieu)
                        End If
                    End If
                End If
            End If
            objFcPhieuxuat.DeleteByID(uId_Phieuxuat)
            objFCNhatKy.Write(Session("sTendangnhap"), System.Environment.MachineName, "Xóa phiếu xuất mã " & e.Keys(1).ToString)
            LoadDSPhieu()
            Session("uId_Phieuxuat") = Nothing
            Session("uId_Khachhang") = Nothing
        Catch ex As Exception

        End Try
        e.Cancel = True
    End Sub
    Protected Sub dgvDevexpress_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
        objFCPhanQuyen = New BO.QT_PHANQUYENFacade
        objFcPhieuxuat = New BO.QLMH_PHIEUXUATFacade
        objEnPhieuxuat_old = New CM.QLMH_PHIEUXUATEntity
        CType(sender, ASPxGridView).JSProperties("cpIsUpdated") = "update"
        Dim checkKhoaPhieu As Boolean = False
        checkKhoaPhieu = objFcPhieuxuat.SelectByID(Session("uId_Phieudichvu")).b_IsKhoa
        Dim dt As New DataTable
        dt = objFCPhanQuyen.SelectAllTable(Session("uId_Nhanvien_Dangnhap"), "67e68aea-9dbd-43d5-b316-e5ad9c0e6fd3")
        If checkKhoaPhieu = False Or dt.Rows.Count > 0 Then
            Dim uId_Phieuxuat_Chitiet As String
            uId_Phieuxuat_Chitiet = e.Keys(0).ToString
            objEnPhieuxuat_old = objFcPhieuxuat.SelectQLMH_PHIEUXUAT_CHITIET_ByID(uId_Phieuxuat_Chitiet)
            With objEnPhieuxuat_old
                .f_Soluong = Val(e.NewValues(2))
                .nv_Ghichu = e.NewValues(5)
                'Dim strGiamgia As String = e.NewValues(4).ToString
                Dim strGiamgia As String = DirectCast(dgvDevexpress.FindEditRowCellTemplateControl(TryCast(dgvDevexpress.Columns("f_Giamgia"), GridViewDataColumn), "txtGiamgia"), TextBox).Text
                If InStr(strGiamgia, "%") > 0 Then
                    .f_Giamgia = .f_Soluong * .f_Dongia * CInt(strGiamgia.Replace("%", "")) / 100
                Else : .f_Giamgia = CInt(Val(strGiamgia.Replace(",", "")))
                End If
                .f_Tongtien = (Val(e.NewValues(3)) * Val(e.NewValues(2))) - objEnPhieuxuat_old.f_Giamgia
                .f_Dongia = Val(e.NewValues(3))
            End With
            'Quy doi ve so luong nho nhat theo ma don vi
            Dim LaySLNhoNhat As Integer
            Dim LaySLTon As Integer
            LaySLNhoNhat = objFcDmMathang.QuyDoiVeDonViNhoNhat(objEnPhieuxuat_old.uId_Mathang, objEnPhieuxuat_old.MaDonVi, Val(e.NewValues(2)))
            LaySLTon = objFcDmMathang.LaySLTonByTime(BO.Util.ConvertDateTime(deNgayxuat.Text), ddlDMKho.SelectedItem.Value, Session("uId_Cuahang").ToString(), objEnPhieuxuat_old.uId_Mathang)
            If ((LaySLNhoNhat - objEnPhieuxuat_old.f_Soluongnhonhat) <= LaySLTon) Then
                objFcPhieuxuat.Update_QLMH_PHIEUXUAT_CHITIET(objEnPhieuxuat_old)
            Else
                CType(sender, ASPxGridView).JSProperties("cpUpdateStatus") = "lackqt"
            End If
            dgvDevexpress.CancelEdit()
            Loadphieuchitiet()
            e.Cancel = True
        Else
            CType(sender, ASPxGridView).JSProperties("cpUpdateStatus") = "lock"
        End If
    End Sub
    Protected Sub dgvLoaiTT_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        Dim uId_Phieuxuat As String = Session("uId_Phieuxuat").ToString
        objFcPhieuxuatLoaiTT = New BO.QLMH_PHIEUXUAT_LOAITTFacade
        objFcPhieuxuatLoaiTT.DeleteByID(uId_Phieuxuat, e.Keys(0).ToString)
        LoadDSLoaiTT()
        e.Cancel = True
        objFcPhieuxuatLoaiTT = Nothing
    End Sub
#End Region

#Region "the tich diem "
    Public Sub Tinhdiemtichluy(dtTheKh As DataTable, tienmathang As Double, str As String, sophieu As String)
        objFcTtdKh = New BO.clsB_TTV_KH_Thetichdiem
        objFcTtdLichdu = New BO.clsB_TTV_KH_Thetichdiem_Lichsu
        objEnTtdLichsu = New CM.cls_TTV_KH_Thetichdiem_LichsuEntity
        objFcThetichdiem = New BO.clsB_TTV_DM_THETICHDIEM
        Dim dtDmthe As DataTable
        dtDmthe = objFcThetichdiem.SelectAllTable(Session("uId_Cuahang").ToString)
        If dtTheKh.Rows.Count > 0 Then
            If dtDmthe.Rows.Count > 0 Then
                For j As Integer = 0 To dtDmthe.Rows.Count - 1 Step 1
                    If dtDmthe.Rows(j)("uId_Thetichdiem").ToString = dtTheKh.Rows(0)("uId_Thetichdiem").ToString Then
                        Dim f_diemhientai As Integer = dtTheKh.Rows(0)("f_Diemhientai")
                        Dim f_Tongtichluy As Integer = dtTheKh.Rows(0)("f_Tongtichluy")
                        'Dim sodiemdoi As Double = Convert.ToDouble(dtDmthe.Rows(j)("i_Sodiemdoi").ToString)
                        'Dim sotiendoi As Double = Convert.ToDouble(dtDmthe.Rows(j)("f_Sotiendoi").ToString)
                        'Dim diemtru = tienmathang * sodiemdoi / sotiendoi
                        Dim diemtru = tienmathang
                        If f_diemhientai >= diemtru And f_Tongtichluy >= diemtru Then
                            f_diemhientai -= diemtru
                            f_Tongtichluy -= diemtru
                            objFcTtdKh.UpdatePoint(f_Tongtichluy, f_diemhientai, dtTheKh.Rows(0)("uId_KH_The").ToString)
                            objEnTtdLichsu = New CM.cls_TTV_KH_Thetichdiem_LichsuEntity
                            objFcTtdLichdu = New BO.clsB_TTV_KH_Thetichdiem_Lichsu
                            With objEnTtdLichsu
                                .b_Luachon = False
                                .d_Ngaythuchien = DateAndTime.Now
                                .f_Diem = diemtru
                                .uId_KH_The = dtTheKh.Rows(0)("uId_KH_The").ToString
                                .uId_Nhanvien = Session("uId_Nhanvien_Dangnhap").ToString
                                .uId_Sukien = Nothing
                                .nv_Noidung = "Trừ điểm " + str + " của phiếu mặt hàng mã: " + sophieu
                            End With
                            objFcTtdLichdu.Insert(objEnTtdLichsu)
                        End If
                    End If
                Next
            End If
        End If
    End Sub
#End Region
    Protected Sub ddlMathang_Callback(sender As Object, e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase)
        LoadDMMathang()
    End Sub
End Class