Imports DevExpress.Web.ASPxGridView
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxPopupControl

Public Class BillingServices
    Inherits System.Web.UI.Page
    Dim objFC_dmdichvu As BO.TNTP_DM_DICHVUFacade
    Dim objFcDMKhachhang As BO.CRM_DM_KhachhangFacade
    Dim objEnDMKhachhang As CM.CRM_DM_KhachhangEntity
    Dim objFCPhieuDV As BO.TNTP_PHIEUDICHVUFacade
    Dim objFCChitietDV As BO.TNTP_PHIEUDICHVU_CHITIETFacade
    Dim objEnChitietDV As CM.TNTP_PHIEUDICHVU_CHITIETEntity
    Dim objFCPhanQuyen As BO.QT_PHANQUYENFacade
    Dim objEnPhanQuyen As CM.QT_PHANQUYENEntity
    Dim objEnPhieuDV As CM.TNTP_PHIEUDICHVUEntity
    Dim objFC_Nhanvien As BO.QT_DM_NHANVIENFacade
    Dim objFCLoaiTT As BO.QLTC_LoaiHinhTTFacade
    Dim objFCGoiDV As BO.TNTP_KHACHHANG_GOIDICHVUFacade
    Dim objFCHuyDV As BO.MKT_HUYDV
    Dim objEnHuyDV As CM.MKT_HUYDV
    Dim oLibP As New Lib_SAT.cls_Pub_Functions
    Dim objFCNhatKy As BO.NHATKYSUDUNGFacade
    Dim objFCNhomphieu As BO.clsB_TNTP_PHIEUDICHVU_NHOMPHIEUFacade
    Dim objEnGoiKH As CM.TNTP_KHACHHANG_GOIDICHVUEntity
    Dim objFCGoiKH As BO.TNTP_KHACHHANG_GOIDICHVUFacade
    Dim objFCPhieuDVLoaiTT As BO.TNTP_PHIEUDICHVU_LOAITTFacade
    Dim objEnLoaiTT As CM.QLTC_LoaiHinhTTEntity
    Dim objEnPhieuDVLoaiTT As CM.TNTP_PHIEUDICHVU_LOAITTEntity
    Dim objFc_MKT_Sale As BO.clsB_MKT_SALES
    Dim tiendichvu As Double = 0
    Dim objFcPhong As BO.QLP_DM_PHONGFacade

#Region "the tich diem"
    Private objEnthetichdiemkh As CM.icls_TTV_KH_ThetichdiemEntity
    Private objFcthetichdiemkh As BO.clsB_TTV_KH_Thetichdiem
    Private objFcLsthetichdiem As BO.clsB_TTV_KH_Thetichdiem_Lichsu
    Private objEnLsthetichdiem As CM.iCls_TTV_KH_Thetichdiem_LichsuEntity
    Private objFcDmthe As BO.clsB_TTV_DM_THETICHDIEM
#End Region
#Region "Khai bao PX"
    Dim objFcDMKho As BO.QLMH_DM_KHOFacade
    Dim objFcDmMathang As BO.QLMH_DM_MATHANGFacade
    Dim objFcPhieuxuat As BO.QLMH_PHIEUXUATFacade
    Dim objEnPhieuxuat As CM.QLMH_PHIEUXUATEntity
    Dim objEnPhieuxuat_old As CM.QLMH_PHIEUXUATEntity
    Dim objFCQuydoidv As BO.DMQuyDoiDonViFacade
    Dim objFcKhachhang As BO.CRM_DM_KhachhangFacade
    Dim objFcNhanvien As BO.QT_DM_NHANVIENFacade
    Dim objEnGoiDV As CM.TNTP_KHACHHANG_GOIDICHVUEntity
    Dim objFcPhieuxuatLoaiTT As BO.QLMH_PHIEUXUAT_LOAITTFacade
    Dim objEnPhieuxuatLoaiTT As CM.QLMH_PHIEUXUAT_LOAITTEntity
#End Region
    Dim pc As New Public_Class
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadGridDmDichvu()
        If Not IsPostBack Then
            'Group by
            txt_Uudai.Text = 0
            ApplyLayoutDanhsachphieu()
            LoadDropDownList()
            deNgayxuat.Date = DateTime.Now
            deTungay.Date = DateTime.Now
            deDenNgay.Date = DateTime.Now
            txtMaphieu.Text = pc.ReturnAutoString("PX")
            If Session("uId_Khachhang") <> Nothing Then
                LoadThongTinKhachHang()
                LoadDropDown_Khachhang()
                dgvDanhsachphieu.DataBind()
                dgvDSPhieuno.DataBind()
                dgvDsTheTT.DataBind()
                loadttd()
            End If
            If Session("uId_Phieuxuat") <> Nothing Then
                LoadDMMathang()
                grid_Phieuxuat_Chitiet.DataBind()
                'LoadThongTinPhieuXuat()
            End If
            If Session("uId_Phieudichvu") <> Nothing Then
                LoadThongTinPhieuDV()
                dgvPhieuchitiet.DataBind()
                Load_Thongtin_The_Taikhoan()
            Else
                CreateSoPhieu()
                deNgaylap.Date = DateTime.Now.ToString
            End If
            dgvPhieuchitiet.JSProperties("cpIsUpdated") = ""
            deNgaycap.Date = DateTime.Now.ToString
            deNgayhethan.Date = DateTime.Now.AddYears(1)
        End If


        If Session("uId_Phieudichvu") <> Nothing Then
            LoadDSLoaiTT()
        End If
        LoadDropDown_PX()
        LoadDSPhieu()
    End Sub
    Private Sub LoadDropDown_PX()
        objFcDMKho = New BO.QLMH_DM_KHOFacade
        objFcNhanvien = New BO.QT_DM_NHANVIENFacade
        Dim dt As DataTable
        dt = objFcDMKho.SelectAllTable(Session("uId_Cuahang"))
        ddlDMKho.DataSource = dt
        ddlDMKho.ValueField = "uId_Kho"
        ddlDMKho.TextField = "nv_Tenkho_vn"
        ddlDMKho.DataBind()
        ddlDMKho.SelectedIndex = 1
        'load danh muc kho tren pupop danh sach phieu da tao
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

        listItem0.Value = "0"
        listItem0.Text = "Tất cả"
        dt = New DataTable
        dt = objFcNhanvien.SelectAllTable(Session("uId_Cuahang"))
        ddlNhanvien_PX.DataSource = dt
        ddlNhanvien_PX.ValueField = "uId_Nhanvien"
        ddlNhanvien_PX.TextField = "nv_Hoten_vn"
        ddlNhanvien_PX.DataBind()
        ddlNhanvien_PX.Value = Session("uId_Nhanvien_Dangnhap")

        dt = New DataTable
        objFCLoaiTT = New BO.QLTC_LoaiHinhTTFacade
        ddlLoaithanhtoan_PX.DataSource = objFCLoaiTT.SelectAllTable()
        ddlLoaithanhtoan_PX.TextField = "nv_TenLoaiTT"
        ddlLoaithanhtoan_PX.ValueField = "uId_LoaiTT"
        ddlLoaithanhtoan_PX.DataBind()
        ddlLoaithanhtoan_PX.Value = "43915768-694a-49b8-8db2-6332718db194"

        'For Each row As DataRow In dt.Rows
        '    If row("v_MaLoaiTT") <> "MUTIL" Then
        '        Dim item As New ListEditItem
        '        item.Value = row("uId_LoaiTT")
        '        item.Text = row("nv_TenLoaiTT")
        '        ddlHinhthucTT_Pop.Items.Add(item)
        '    End If
        'Next
    End Sub
    Private Sub loadttd()
        objFcthetichdiemkh = New BO.clsB_TTV_KH_Thetichdiem
        Dim dt As DataTable = objFcthetichdiemkh.SelectName(Session("uId_Khachhang").ToString)
        If (dt.Rows.Count > 0) Then
            lbthetichdiem.Text = dt.Rows(0)(0)
        Else
            lbthetichdiem.Text = "Nothing"
        End If

    End Sub
#Region "Load Thong tin"
    Private Sub HidebtnTT()
        objFCPhieuDV = New BO.TNTP_PHIEUDICHVUFacade
        objFCPhieuDV.SelectByID(Session("uId_Phieudichvu").ToString)
        If objFCPhieuDV.SelectByID(Session("uId_Phieudichvu").ToString).b_IsKhoa = True Then
            btnThanhtoan.Enabled = False
        End If
    End Sub
    Private Sub LoadGridDmDichvu()
        Dim dt As New DataTable
        objFC_dmdichvu = New BO.TNTP_DM_DICHVUFacade
        dt = objFC_dmdichvu.SelectAllTable("", oLibP.NullProString(Session("uId_Cuahang")))
        If Not (dt Is Nothing) Then
            If dt.Rows.Count = 0 Then
                dt.Rows.Add(dt.NewRow())
            End If
        End If
        dgvDevexpress.DataSource = dt
        dgvDevexpress.DataBind()
        dt = Nothing
    End Sub

    Private Sub LoadThongTinPhieuDV()
        objFcDmthe = New BO.clsB_TTV_DM_THETICHDIEM
        objFCPhieuDV = New BO.TNTP_PHIEUDICHVUFacade
        objEnPhieuDV = New CM.TNTP_PHIEUDICHVUEntity
        Dim uutien As Double
        objEnPhieuDV = objFCPhieuDV.SelectByID(Session("uId_Phieudichvu").ToString)
        txtSoPhieu.Text = objEnPhieuDV.v_Sophieu
        deNgaylap.Date = objEnPhieuDV.d_Ngay
        If Session("uId_Nhanvien_Dangnhap").ToString <> "44e842b8-8bbb-47f1-a0d1-9f16c1e0899c" Then
            deNgaylap.Enabled = False
            txtSoPhieu.Enabled = False
        Else
            deNgaylap.Enabled = True
            txtSoPhieu.Enabled = True
        End If
        lblTongtien.Text = String.Format("{0:#,##0}", BO.Util.IsDouble(objEnPhieuDV.nv_Ghichu_en.Split("$")(0)))
        txtGiamgiaPhieu.Text = objEnPhieuDV.f_Giamgia
        If objEnPhieuDV.nv_Ghichu_en <> Nothing Then
            uutien = Convert.ToDouble(objEnPhieuDV.nv_Ghichu_en.Split("$")(1).ToString)
        Else
            uutien = 0
        End If
        If uutien < 100 Then
            lblUutien.Text = uutien.ToString + " %"
            uutien = Convert.ToDouble(objEnPhieuDV.nv_Ghichu_en.Split("$")(0).ToString) / 100 * uutien
        Else
            lblUutien.Text = String.Format("{0:#,##0}", uutien) + " VND"
        End If
        lblConlai.Text = String.Format("{0:#,##0}", Val(objEnPhieuDV.nv_Ghichu_en.Split("$")(0)) - Val(objEnPhieuDV.f_Giamgia) - uutien)
        Dim tiennhan As Integer
        tiennhan = Integer.Parse(BO.Util.IsDouble(objEnPhieuDV.f_Tongtienthuc))
        If tiennhan > 0 Then
            lblTongthanhtoan.Text = "Đã thanh toán: "
            txtSotiennhan.Text = String.Format("{0:#,##0}", tiennhan)
        Else

            txtSotiennhan.Text = String.Format("{0:#,##0}", Val(objEnPhieuDV.nv_Ghichu_en.Split("$")(0)) - Val(objEnPhieuDV.f_Giamgia) - uutien)
            lblTongthanhtoan.Text = "Cần thanh toán: "
        End If
        lblTienthua.Text = String.Format("{0:#,##0}", Val(lblConlai.Text.Replace(",", "")) - Val(txtSotiennhan.Text.Replace(",", "")))
        txtGhichu.Text = objEnPhieuDV.nv_Ghichu_vn
        lblUutien.Text = objEnPhieuDV.nv_Ghichu_en.Split("$")(1).ToString
        Dim f_Tongthanhtoan As Double = Convert.ToDouble(Val(objEnPhieuDV.nv_Ghichu_en.Split("$")(0)) - Val(objEnPhieuDV.f_Giamgia) - uutien)
        Dim f_Thucthu As Double = Convert.ToDouble(Math.Round(f_Tongthanhtoan / 3, 2))
        If objEnPhieuDV.uId_LoaiTT <> "" And objEnPhieuDV.uId_LoaiTT <> Nothing Then
            ddlLoaithanhtoan.Value = objEnPhieuDV.uId_LoaiTT
        Else
            ddlLoaithanhtoan.Value = "43915768-694a-49b8-8db2-6332718db194"
        End If
        If objEnPhieuDV.uId_Nhanvien <> "" And objEnPhieuDV.uId_Nhanvien <> Nothing Then
            ddlNhanvien.Value = objEnPhieuDV.uId_Nhanvien
        Else
            ddlNhanvien.Value = Session("uId_Nhanvien_Dangnhap")
        End If
        txtHH.Text = objEnPhieuDV.HHPhieu.ToString
        ddlNhomphieu.Value = objEnPhieuDV.Id_Nhomphieu.ToString
        'Load thong tin popup hinh thuc thanh toan
        lblSophieuTT.Text = objEnPhieuDV.v_Sophieu
        txtSotiennhanTT.Text = objEnPhieuDV.f_Tongtienthuc.ToString()
    End Sub
    Private Sub LoadPhieuDVChitiet()
        objFCChitietDV = New BO.TNTP_PHIEUDICHVU_CHITIETFacade
        Dim dt As DataTable = objFCChitietDV.SelectByID(Session("uId_Phieudichvu"))
        If dt.Rows.Count > 0 Then
            dgvPhieuchitiet.DataSource = dt
            For Each row As DataRow In dt.Rows
                If row("vType") = "TAIKHOAN" Then
                    btnCapthe.ClientVisible = True
                End If
            Next
        End If
    End Sub
    Private Sub LoadThongTinKhachHang()
        objFcDMKhachhang = New BO.CRM_DM_KhachhangFacade
        objEnDMKhachhang = New CM.CRM_DM_KhachhangEntity
        objEnDMKhachhang = objFcDMKhachhang.SelectByID(Session("uId_Khachhang"))
        txtHoten.Text = objEnDMKhachhang.nv_Hoten_vn
        ltrTitleHeader.Text = "<p class='p_header'><i class='fa fa-newspaper-o fa-fw fa-1x'></i>THÊM PHIẾU DỊCH VỤ CHO KHÁCH HÀNG <span style='color:red;text-transform:uppercase;font-size:16px'>" & objEnDMKhachhang.nv_Hoten_vn & "</span></p>"
        pcDanhsachphieu.HeaderText = "DANH SÁCH PHIẾU CỦA " & objEnDMKhachhang.nv_Hoten_vn
        'btnDSPhieu.Text = "Danh sách phiếu của " & objEnDMKhachhang.nv_Hoten_vn
        'btnDSNo.Text = "Danh sách nợ của " & objEnDMKhachhang.nv_Hoten_vn
        pcDanhsachno.HeaderText = "Danh sách phiếu nợ của " & objEnDMKhachhang.nv_Hoten_vn
        pcDsTheTT.HeaderText = "Danh sách thẻ của " & objEnDMKhachhang.nv_Hoten_vn
        lblKhachhangThe.Text = objEnDMKhachhang.nv_Hoten_vn
    End Sub

    Private Sub Loaddanhsachphieu()
        'Load Thong tin danh sach phieu
        objFCPhieuDV = New BO.TNTP_PHIEUDICHVUFacade
        Dim dt As New DataTable
        dt = objFCPhieuDV.SelectAllByGDV(Session("uId_Khachhang"), 2, 1)
        If dt.Rows.Count > 0 Then
            dgvDanhsachphieu.DataSource = dt
        End If
    End Sub

    Private Sub LoadDanhsachno()
        Dim dt As DataTable
        objFCPhieuDV = New BO.TNTP_PHIEUDICHVUFacade
        dt = objFCPhieuDV.SelectDVNo(Session("uId_Khachhang"))
        If dt.Rows.Count > 0 Then
            dgvDSPhieuno.DataSource = dt
        End If
    End Sub

    Private Sub LoadDSTheTT()
        objFCGoiDV = New BO.TNTP_KHACHHANG_GOIDICHVUFacade
        Dim dt As DataTable
        Dim uId_Khachhang = Session("uId_Khachhang")
        Dim Luachon As Integer = 2
        dt = objFCGoiDV.Select_TheTaiKhoan_By_Khachhang(uId_Khachhang, Luachon)
        dgvDsTheTT.DataSource = dt
        DSTHE2.DataSource = dt
    End Sub

    Private Sub LoadDSLoaiTT()
        objFCPhieuDVLoaiTT = New BO.TNTP_PHIEUDICHVU_LOAITTFacade
        Dim dt As DataTable
        dt = objFCPhieuDVLoaiTT.SelectByPhieuDV(Session("uId_Phieudichvu").ToString)
        If dt.Rows.Count > 0 Then
            dgvLoaiTT.DataSource = dt
            dgvLoaiTT.DataBind()
        Else
            dgvLoaiTT.DataSource = Nothing
            dgvLoaiTT.DataBind()
        End If
        objFCLoaiTT = Nothing
    End Sub
#Region "connect Javascrip"
    'Public Function callVb() As Boolean
    '    LoadDSTheTT()
    '    Return True
    'End Function
#End Region
    Private Sub LoadDropDownList()
        objFC_Nhanvien = New BO.QT_DM_NHANVIENFacade
        ddlNhanvien.DataSource = objFC_Nhanvien.SelectAllAdminTable(oLibP.NullProString(Session("uId_Cuahang")))
        ddlNhanvien.TextField = "nv_Hoten_vn"
        ddlNhanvien.ValueField = "uId_Nhanvien"
        ddlNhanvien.DataBind()
        Dim uId_Nhanvien_dangnhap As String = Session("uId_Nhanvien_Dangnhap")
        ddlNhanvien.Value = uId_Nhanvien_dangnhap
        'cbokythuatvien.DataSource = objFC_Nhanvien.SelectAllAdminTable(oLibP.NullProString(Session("uId_Cuahang")))
        'cbokythuatvien.ValueField = "uId_Nhanvien"
        'cbokythuatvien.TextField = "nv_Hoten_vn"
        'cbokythuatvien.DataBind()
        objFCLoaiTT = New BO.QLTC_LoaiHinhTTFacade
        Dim dt As DataTable
        dt = objFCLoaiTT.SelectAllTable()
        For Each row As DataRow In dt.Rows
            Dim item As New ListEditItem
            item.Value = row("uId_LoaiTT")
            item.Text = row("nv_TenLoaiTT")
            ddlLoaithanhtoan.Items.Add(item)
        Next
        'ddlLoaithanhtoan.DataSource = objFCLoaiTT.SelectAllTable()
        'ddlLoaithanhtoan.TextField = "nv_TenLoaiTT"
        'ddlLoaithanhtoan.ValueField = "uId_LoaiTT"
        'ddlLoaithanhtoan.DataBind()
        ddlLoaithanhtoan.Value = "43915768-694a-49b8-8db2-6332718db194"

        objFCNhomphieu = New BO.clsB_TNTP_PHIEUDICHVU_NHOMPHIEUFacade
        ddlNhomphieu.DataSource = objFCNhomphieu.SelectAllTable()
        ddlNhomphieu.TextField = "nv_Tennhomphieu_vn"
        ddlNhomphieu.ValueField = "Id_Nhomphieu"
        ddlNhomphieu.DataBind()
        ddlNhomphieu.SelectedIndex = 0

        objFCLoaiTT = New BO.QLTC_LoaiHinhTTFacade
        For Each row As DataRow In dt.Rows
            If row("v_MaLoaiTT") <> "MUTIL" Then
                Dim item As New ListEditItem
                item.Value = row("uId_LoaiTT")
                item.Text = row("nv_TenLoaiTT")
                ddlHinhthucTT_Pop.Items.Add(item)
            End If
        Next
        'ddlHinhthucTT_Pop.DataSource = objFCLoaiTT.SelectAllTable()
        'ddlHinhthucTT_Pop.TextField = "nv_TenLoaiTT"
        'ddlHinhthucTT_Pop.ValueField = "uId_LoaiTT"
        'ddlHinhthucTT_Pop.DataBind()
        objFCLoaiTT = Nothing
    End Sub
    Private Sub LoadDropDownlist_PX()
        objFcDMKho = New BO.QLMH_DM_KHOFacade
        objFcNhanvien = New BO.QT_DM_NHANVIENFacade
        Dim dt As DataTable
        dt = objFcDMKho.SelectAllTable(Session("uId_Cuahang"))
        ddlDMKho.DataSource = dt
        ddlDMKho.ValueField = "uId_Kho"
        ddlDMKho.TextField = "nv_Tenkho_vn"
        ddlDMKho.DataBind()
        ddlDMKho.SelectedIndex = 1
        dt = New DataTable
        dt = objFcNhanvien.SelectAllTable(Session("uId_Cuahang"))
        ddlNhanvien_PX.DataSource = dt
        ddlNhanvien_PX.ValueField = "uId_Nhanvien"
        ddlNhanvien_PX.TextField = "nv_Hoten_vn"
        ddlNhanvien_PX.DataBind()
        ddlNhanvien_PX.Value = Session("uId_Nhanvien_Dangnhap")
        dt = New DataTable
        objFCLoaiTT = New BO.QLTC_LoaiHinhTTFacade
        dt = objFCLoaiTT.SelectAllTable()
        For Each row As DataRow In dt.Rows
            Dim item As New ListEditItem
            item.Value = row("uId_LoaiTT")
            item.Text = row("nv_TenLoaiTT")
            ddlLoaithanhtoan.Items.Add(item)
        Next
        ddlLoaithanhtoan_PX.DataSource = objFCLoaiTT.SelectAllTable()
        ddlLoaithanhtoan_PX.TextField = "nv_TenLoaiTT"
        ddlLoaithanhtoan_PX.ValueField = "uId_LoaiTT"
        ddlLoaithanhtoan_PX.DataBind()
        ddlLoaithanhtoan_PX.Value = "43915768-694a-49b8-8db2-6332718db194"

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
    Private Sub CreateSoPhieu()
        objFCPhieuDV = New BO.TNTP_PHIEUDICHVUFacade
        Dim strMa As String = objFCPhieuDV.MaPDVMax(oLibP.NullProString(Session("uId_Cuahang")), DateTime.Now)
        If strMa.Length < 4 Then
            For m As Integer = strMa.Length To 3
                strMa = "0" + strMa
            Next
        End If
        txtSoPhieu.Text = ReturnStringByDate("P") + strMa
    End Sub
    Public Function ReturnStringByDate(ByVal ID As String) As String
        Dim yc As String = DateTime.Now.Year.ToString
        Dim mc As String = DateTime.Now.Month.ToString
        Dim dc As String = DateTime.Now.Day.ToString
        If (Val(mc) < 10) Then mc = mc.Replace("0", "")
        If (Val(dc) < 10) Then dc = dc.Replace("0", "")
        Return ID + dc + mc + yc + "."
    End Function

    Private Function CheckPhieuCuMoi()
        objEnPhieuDV = New CM.TNTP_PHIEUDICHVUEntity
        objFCPhieuDV = New BO.TNTP_PHIEUDICHVUFacade
        objEnPhieuDV = objFCPhieuDV.SelectByID(Session("uId_Phieudichvu"))
        If Val(objEnPhieuDV.f_Tongtienthuc) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function IsDouble(ByVal value As String) As Double
        If value = "" Or value = Nothing Then
            Return 0
        Else
            Return CDbl(value)
        End If
    End Function
#End Region
#Region "Button"
    Protected Sub btnLidoxoa_Click(sender As Object, e As EventArgs)
        If txtLidoxoa.Text.Trim <> "" And Session("uId_Phieuchitiet") <> Nothing And Session("uId_Dichvu_huy") <> Nothing And Session("uId_Phieudichvu") <> Nothing Then
            objFCChitietDV = New BO.TNTP_PHIEUDICHVU_CHITIETFacade
            objEnPhieuDV = New CM.TNTP_PHIEUDICHVUEntity
            objFCPhieuDV = New BO.TNTP_PHIEUDICHVUFacade
            Dim sophieu As String = txtSoPhieu.Text
            objFcDMKhachhang = New BO.CRM_DM_KhachhangFacade
            Dim dt As DataTable
            objEnChitietDV = New CM.TNTP_PHIEUDICHVU_CHITIETEntity
            objFcthetichdiemkh = New BO.clsB_TTV_KH_Thetichdiem
            Dim dtthenguoimua As DataTable
            Dim dtthenguoidioithieu As DataTable
            dtthenguoimua = objFcthetichdiemkh.SelectByIdKH(Session("uId_Khachhang"))
            'tru tien da thanh toan neu so tien da thanh toan nhieu hon don gia cua dich vu muon huy
            objEnPhieuDV = objFCPhieuDV.SelectByID(Session("uId_Phieudichvu").ToString)

            dt = objFCChitietDV.SelectByIDChitiet(Session("uId_Phieuchitiet").ToString)
            tiendichvu = Convert.ToDouble(dt.Rows(0)("f_Tongtien").ToString)
            Dim f_Tongchitiet As Double = Convert.ToDouble(dt.Rows(0)("f_Tongtien").ToString) ' tien cua dich vu can xoa
            'tru diem da thanh toan chi ap dung voi nhung phieu da duoc thanh toan hoan toan
            Dim dtpdv As DataTable
            dtpdv = objFCChitietDV.SelectByID(Session("uId_Phieudichvu"))
            Dim i_tongtien As Double = 0 'tien don gia cua tat ca cac dich vu cua phieu dich vu 
            If dtpdv.Rows.Count > 0 Then
                For j As Integer = 0 To dtpdv.Rows.Count - 1 Step 1
                    i_tongtien += Convert.ToDouble(dtpdv.Rows(j)("f_Tongtien").ToString)
                Next
            End If
            'neu pdv khong thanh toan tu "the thanh toan"
            If objEnPhieuDV.uId_LoaiTT <> "01d16c43-7a03-49dc-afd2-39e79a1439f1" Then
                If objEnPhieuDV.f_Tongtienthuc - i_tongtien >= 0 Then ' tru diem khi phieu dv da thanh toan du
                    TinhdiemHuyDv(dtthenguoimua, tiendichvu, "hủy dịch vụ", sophieu) ' tru the tich diem nguoi mua dv
                End If
                'update lai tong thanh toan trong phieu dv
                If objEnPhieuDV.f_Tongtienthuc - f_Tongchitiet >= 0 Then
                    objEnPhieuDV.f_Tongtienthuc = objEnPhieuDV.f_Tongtienthuc - f_Tongchitiet
                    objFCPhieuDV.Update_TTT(objEnPhieuDV)
                End If
                objFCHuyDV = New BO.MKT_HUYDV
                objEnHuyDV = New CM.MKT_HUYDV
                objFCNhatKy = New BO.NHATKYSUDUNGFacade
                objEnHuyDV.uId_Dichvu = Session("uId_Dichvu_huy").ToString
                objEnHuyDV.uId_Phieudichvu = Session("uId_Phieudichvu")
                objEnHuyDV.uId_Khachhang = Session("uId_Khachhang").ToString
                objEnHuyDV.uId_Nhanvien = Session("uId_Nhanvien_Dangnhap").ToString
                objEnHuyDV.Date = DateTime.Now
                objEnHuyDV.nv_Ghichu_vn = txtLidoxoa.Text
                Try
                    objFCHuyDV.Insert(objEnHuyDV)
                    objFCNhatKy.Write(Session("sTendangnhap"), System.Environment.MachineName, "Xóa dịch vụ " & Session("nv_Tendichvu_huy") & " sau thanh toán trong phiếu " & txtSoPhieu.Text)
                    ShowMessage(Me, "Đã xóa thành công")
                Catch ex As Exception
                End Try
                objFCHuyDV = Nothing
                Session("uId_Dichvu_huy") = Nothing
                Session("nv_Tendichvu_huy") = Nothing
                'tru diem nguoi gioi thieu
                'lay ve uid nguoi gioi thieu
                If tiendichvu > 0 Then
                    If objFcDMKhachhang.SelectByID(Session("uId_Khachhang").ToString).uId_Nguoigioithieu <> Nothing Then
                        dtthenguoidioithieu = objFcthetichdiemkh.SelectByIdKH(objFcDMKhachhang.SelectByID(Session("uId_Khachhang").ToString).uId_Nguoigioithieu)
                        TinhdiemHuyDv(dtthenguoidioithieu, tiendichvu, "người giới thiệu", sophieu)
                    End If
                End If
                objFCChitietDV.DeleteByID(Session("uId_Phieuchitiet").ToString) ' huy dich vu trong bang phieudichvu chi tiet
            Else
                If objEnPhieuDV.f_Tongtienthuc - f_Tongchitiet >= 0 Then
                    objEnPhieuDV.f_Tongtienthuc = objEnPhieuDV.f_Tongtienthuc - f_Tongchitiet
                    objFCPhieuDV.Update_TTT(objEnPhieuDV)
                    'neu thanh toan tu the thi cong lai tien
                    Dim objFcDVLoaiTT As New BO.TNTP_PHIEUDICHVU_LOAITTFacade
                    Dim objEnDVLoaiTT As New CM.TNTP_PHIEUDICHVU_LOAITTEntity
                    Dim objEnKHGoidichvu As New CM.TNTP_KHACHHANG_GOIDICHVUEntity
                    Dim objFcKHGoidichvu As New BO.TNTP_KHACHHANG_GOIDICHVUFacade
                    Dim dtgoidv As DataTable
                    Dim dtdvloaitt As DataTable
                    Dim uId_KH_Goidichvu As String
                    dtgoidv = objFcKHGoidichvu.SelectAllTable_ByKH(Session("uId_Khachhang"), 2)
                    For i As Integer = 0 To dtgoidv.Rows.Count - 1 Step 1
                        If f_Tongchitiet + Convert.ToDouble(dtgoidv.Rows(i)("f_Giatrigoi").ToString) <= Convert.ToDouble(dtgoidv.Rows(i)("f_Sotien").ToString) Then
                            uId_KH_Goidichvu = dtgoidv.Rows(i)("uId_Khachhang_Goidichvu").ToString
                            objEnKHGoidichvu = objFcKHGoidichvu.SelectByID(uId_KH_Goidichvu)
                            objEnKHGoidichvu.f_Giatrigoi = objEnKHGoidichvu.f_Giatrigoi + f_Tongchitiet
                            objFcKHGoidichvu.Update(objEnKHGoidichvu)
                            'tru tien trong dich vu loai tt
                            dtdvloaitt = objFcDVLoaiTT.SelectByPhieuDV(Session("uId_Phieudichvu"))
                            If dtdvloaitt.Rows.Count > 0 Then
                                For j As Integer = 0 To dtdvloaitt.Rows.Count - 1 Step 1
                                    If Convert.ToDouble(dtdvloaitt.Rows(j)("f_Sotien").ToString) - f_Tongchitiet >= 0 And dtdvloaitt.Rows(j)("uId_LoaiTT").ToString = "01d16c43-7a03-49dc-afd2-39e79a1439f1" Then
                                        Dim f_Sotien As Double = Convert.ToDouble(dtdvloaitt.Rows(j)("f_Sotien").ToString)
                                        objFcDVLoaiTT.updatesotien("01d16c43-7a03-49dc-afd2-39e79a1439f1", Session("uId_Phieudichvu"), f_Sotien)
                                        Continue For
                                    End If
                                Next
                            End If
                            Continue For
                        End If
                    Next
                    objFCChitietDV.DeleteByID(Session("uId_Phieuchitiet").ToString) ' huy dich vu trong bang phieudichvu chi tiet
                    objEnKHGoidichvu = Nothing
                    objFcKHGoidichvu = Nothing
                End If
            End If

            txtLidoxoa.Text = ""
            Response.Redirect("~/OrangeVersion/Customer/BillingServices.aspx")
        End If
    End Sub

    Protected Sub btLuuthe_Click(sender As Object, e As EventArgs)
        objEnGoiKH = New CM.TNTP_KHACHHANG_GOIDICHVUEntity
        objFCGoiKH = New BO.TNTP_KHACHHANG_GOIDICHVUFacade
        'Tao mot the
        Dim dt As DataTable
        With objEnGoiKH
            .uId_Cuahang = Session("uId_Cuahang")
            .uId_Khachhang = Session("uId_Khachhang")
            .uId_Goidichvu = Session("uId_Dichvu_The")
            .uId_Trangthai = "fb83dd87-caf8-427d-81fa-c683e8fec955"
            .f_Sotien = Val(BO.Util.IsDouble(hdfDongiathe.Value.Replace(",", "")))
            .f_Giatrigoi = Val(BO.Util.IsDouble(txt_Tongtien_The.Text.Replace(",", ""))) 'Dung ham nay
            .i_TongSolanthuchien = 1
            .d_Ngaymua = BO.Util.ConvertDateTime(deNgaycap.Text)
            .d_NgayKT = BO.Util.ConvertDateTime(deNgayhethan.Text)
            .b_Kichhoat = False
            .uId_Phieudichvu = Session("uId_Phieudichvu")
            .uId_Khachhang_Kichhoat = Nothing
            If txtMavach.Text = "" Then
                ltrError.Text = "<span class='error' id='error'>Mã thẻ không được để trống!</span>"
                Exit Sub
            Else
                .vMaBarcode = Trim(txtMavach.Text)
            End If
        End With
        'Kiem tra MaThe co trung ko?
        If objFCGoiKH.chkExist_MaTheThanhtoan(objEnGoiKH) Then
            ltrError.Text = "<span class='error' id='error'>Trùng mã thẻ!</span>"
            ltrSuccess.Text = ""
            txtMavach.Focus()
            Exit Sub
        End If
        'Kiem tra the da cap cho khach hang'
        dt = objFCGoiKH.Check_Capthe_By_PDV(Session("uId_Phieudichvu"), Session("uId_Dichvu_The"))
        Dim f_Soluong As Integer = Convert.ToInt16(dt.Rows(0).Item("f_Check").ToString)
        If f_Soluong = 0 Then
            ltrError.Text = "<span class='error' id='error'>Thẻ đã được cấp!</span>"
            ltrSuccess.Text = ""
            Exit Sub
        End If
        Dim str As String = objFCGoiKH.Insert(objEnGoiKH)
        If (str = "") Then
            ltrError.Text = "<span class='error' id='error'>Có lỗi xảy ra!</span>"
            ltrSuccess.Text = ""
        Else
            ltrSuccess.Text = "<span class='success' id='success'>Cấp thẻ mã số " & txtMavach.Text & " thành công!</span>"
            ltrError.Text = ""
        End If
    End Sub

    Protected Sub btnLuuHinhthuc_Click(sender As Object, e As EventArgs)
        If Session("uId_Phieudichvu") <> Nothing Then
            Dim f_Giatrigoi As Double
            objEnPhieuDVLoaiTT = New CM.TNTP_PHIEUDICHVU_LOAITTEntity
            objFCPhieuDVLoaiTT = New BO.TNTP_PHIEUDICHVU_LOAITTFacade
            objFCGoiKH = New BO.TNTP_KHACHHANG_GOIDICHVUFacade
            objEnGoiKH = New CM.TNTP_KHACHHANG_GOIDICHVUEntity
            Dim Tongtien As String = ""
            Tongtien = objFCPhieuDVLoaiTT.SelectTongtien(Session("uId_Phieudichvu"))
            'sum = Convert.ToDouble(IsDouble(Tongtien))
            'sums = sum + Convert.ToDouble(IsDouble(txtSotienTT_Pop.Text.Replace(",", "")))
            'If sums > Convert.ToDouble(IsDouble(txtSotiennhanTT.Text.Replace(",", ""))) Then
            '    lblError.Text = "<span style='color:red; font-style:italic'>Tổng kê khai phải nhỏ hơn số tiền nhận</span>"
            'Else
            '    lblError.Text = ""

            'End If
            objEnPhieuDVLoaiTT.uId_LoaiTT = ddlHinhthucTT_Pop.SelectedItem.Value.ToString
            objEnPhieuDVLoaiTT.uId_Phieudichvu = Session("uId_Phieudichvu").ToString
            objEnPhieuDVLoaiTT.f_Sotien = txtSotienTT_Pop.Text.Replace(",", "")
            objEnPhieuDVLoaiTT.v_Maso = txtMaSoTT_Pop.Text
            objEnPhieuDVLoaiTT.nv_Ghichu_vn = txtGhichu.Text
            Try
                objFCPhieuDVLoaiTT.Insert(objEnPhieuDVLoaiTT)
                'Lay ra gia tri goi the tai khoan cua khach hang hien tai
                objEnGoiKH = objFCGoiKH.SelectByvMaBarcode(txtMaSoTT_Pop.Text)
                f_Giatrigoi = objEnGoiKH.f_Giatrigoi

                objEnGoiKH = New CM.TNTP_KHACHHANG_GOIDICHVUEntity
                If (f_Giatrigoi > CDbl(txtSotienTT_Pop.Text.Replace(",", ""))) Then
                    objEnGoiKH.f_Sotien = f_Giatrigoi - CDbl(txtSotienTT_Pop.Text.Replace(",", ""))
                Else
                    objEnGoiKH.f_Sotien = 0
                End If
                objEnGoiKH.uId_Khachhang_Goidichvu = oLibP.NullProString(Session("uId_Khachhang_Goidichvu_TT"))
                objFCGoiKH.ThanhToan(objEnGoiKH)
                Session("uId_Khachhang_Goidichvu_TT") = Nothing
                txtMaSoTT_Pop.Text = ""
                txtGhichu.Text = ""
                txtSotienTT_Pop.Text = ""
                txtSotienTT_Pop.Focus()
                LoadDSLoaiTT()
            Catch ex As Exception

            End Try
            objEnPhieuDVLoaiTT = Nothing
            objFCPhieuDVLoaiTT = Nothing
        End If
    End Sub
#End Region
#Region "GridView Event"
    Private Sub ApplyLayoutDanhsachphieu()
        dgvDevexpress.BeginUpdate()
        Try
            dgvDevexpress.ClearSort()
            dgvDevexpress.GroupBy(dgvDevexpress.Columns("nv_TennhomDichvu_vn"))
        Finally
            dgvDevexpress.EndUpdate()
        End Try
        dgvDevexpress.ExpandRow(0)
    End Sub

    Protected Sub dgvPhieuchitiet_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        objFCPhanQuyen = New BO.QT_PHANQUYENFacade
        objEnPhanQuyen = New CM.QT_PHANQUYENEntity
        objFCPhieuDV = New BO.TNTP_PHIEUDICHVUFacade
        objEnPhieuDV = New CM.TNTP_PHIEUDICHVUEntity
        objFCChitietDV = New BO.TNTP_PHIEUDICHVU_CHITIETFacade
        objEnHuyDV = New CM.MKT_HUYDV
        objFCHuyDV = New BO.MKT_HUYDV
        objFCNhatKy = New BO.NHATKYSUDUNGFacade
        Dim uId_Phieuchitiet As String
        uId_Phieuchitiet = e.Keys(0).ToString
        Session("uId_Phieuchitiet") = uId_Phieuchitiet
        Session("uId_Dichvu_huy") = e.Keys(1).ToString
        Session("nv_Tendichvu_huy") = e.Keys(2).ToString()
        objEnPhieuDV = objFCPhieuDV.SelectByID(Session("uId_Phieudichvu"))
        Dim dt As New DataTable
        dt = objFCPhanQuyen.SelectAllTable(Session("uId_Nhanvien_Dangnhap"), "67e68aea-9dbd-43d5-b316-e5ad9c0e6fd3")
        If objEnPhieuDV.b_IsKhoa = False Or dt.Rows.Count > 0 Then
            If CheckPhieuCuMoi() Then
                objEnPhanQuyen = objFCPhanQuyen.SelectByID(Session("uId_Nhanvien_Dangnhap").ToString, "73D3F2E2-9B4D-46CF-AB34-469044887578")
                If Not objEnPhanQuyen.b_Enable Then
                    ShowMessage(Me, "Bạn không có quyền xóa DV trong phiếu cũ!")
                    Exit Sub
                End If
            Else
                objEnPhanQuyen = objFCPhanQuyen.SelectByID(Session("uId_Nhanvien_Dangnhap").ToString, "FB558160-D9D0-4D88-A908-FA1B13515D49")
                If Not objEnPhanQuyen.b_Enable Then
                    ShowMessage(Me, "Bạn không có quyền xóa DV trong phiếu mới!")
                    Exit Sub
                End If
            End If
            Try
                If objEnPhieuDV.f_Tongtienthuc = 0 Then
                    objFCChitietDV.DeleteByID(uId_Phieuchitiet)
                    'Phuong thuc nay de goi o client sau khi call back grid
                    CType(sender, ASPxGridView).JSProperties("cpIsHuyDV") = "before"
                    objEnHuyDV.uId_Dichvu = e.Keys(1).ToString
                    objEnHuyDV.uId_Phieudichvu = Session("uId_Phieudichvu")
                    objEnHuyDV.Date = DateTime.Now
                    objEnHuyDV.uId_Khachhang = Session("uId_Khachhang").ToString
                    objEnHuyDV.uId_Nhanvien = Session("uId_Nhanvien_Dangnhap").ToString
                    objEnHuyDV.nv_Ghichu_vn = "Hủy trước thanh toán"
                    Try
                        objFCHuyDV.Insert(objEnHuyDV)
                        objFCNhatKy.Write(Session("sTendangnhap"), System.Web.HttpContext.Current.Request.UserHostAddress, "Xóa dịch vụ " & e.Keys(2).ToString() & " trước thanh toán trong phiếu " & objEnPhieuDV.v_Sophieu)
                    Catch ex As Exception

                    End Try
                Else
                    CType(sender, ASPxGridView).JSProperties("cpIsHuyDV") = "after"
                    Session("dv_Tendv") = e.Keys(2).ToString()
                End If
            Catch ex As Exception

            End Try
        Else
            ShowMessage(Me, "Phiếu đã khóa!")
        End If
        e.Cancel = True
        LoadPhieuDVChitiet()
    End Sub

    Protected Sub dgvPhieuchitiet_DataBinding(sender As Object, e As EventArgs)
        LoadPhieuDVChitiet()
    End Sub
    Protected Sub dgvPhieuchitiet_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
        objFCPhanQuyen = New BO.QT_PHANQUYENFacade
        objFCPhieuDV = New BO.TNTP_PHIEUDICHVUFacade
        objFCChitietDV = New BO.TNTP_PHIEUDICHVU_CHITIETFacade
        objEnChitietDV = New CM.TNTP_PHIEUDICHVU_CHITIETEntity
        objFc_MKT_Sale = New BO.clsB_MKT_SALES
        Dim dt_Sale As DataTable = objFc_MKT_Sale.Select_Khuyenmai_Defualt()
        CType(sender, ASPxGridView).JSProperties("cpf_Dongia_new") = e.NewValues(3)
        CType(sender, ASPxGridView).JSProperties("cpf_Dongia_old") = e.OldValues(3)
        Dim checkKhoaPhieu As Boolean = False
        checkKhoaPhieu = objFCPhieuDV.SelectByID(Session("uId_Phieudichvu")).b_IsKhoa
        Dim dt As New DataTable
        dt = objFCPhanQuyen.SelectAllTable(Session("uId_Nhanvien_Dangnhap"), "67e68aea-9dbd-43d5-b316-e5ad9c0e6fd3")
        'chi duoc update phieuchitiet khi pdv chua khoa va nhan vien dang nhap co quyen sua
        Dim gridView As ASPxGridView = DirectCast(sender, ASPxGridView)
        Dim comboBox As ASPxComboBox = gridView.FindEditRowCellTemplateControl(DirectCast(gridView.Columns("nv_Tenchuongtrinh_vn"), GridViewDataColumn), "uId_Sale")
        Dim uId_nhanvien As String = Session("uId_Nhanvien_Dangnhap")
        Dim uId_Sale As String
        If comboBox.Value <> "" And comboBox.Value <> Nothing Then
            uId_Sale = comboBox.Value
        Else
            uId_Sale = dt_Sale.Rows(0).Item("uId_Sale").ToString
        End If
        Try
            If checkKhoaPhieu = False And dt.Rows.Count > 0 Then
                Dim uId_Phieudichvu_Chitiet As String
                uId_Phieudichvu_Chitiet = e.Keys(0).ToString
                Dim f_SoLan_interface As Integer = CInt(Val(e.NewValues("f_Solan")))
                Dim i_SoLan_Dieutri As Integer = CInt(objFCChitietDV.SelectByIDChitiet(uId_Phieudichvu_Chitiet)(0)("i_SoLan_Dieutri"))
                Dim f_SoLuong_interface As Integer = CInt(Val(e.NewValues("f_Soluong")))
                Dim f_Sobuoitang As Integer = CInt(Val(e.NewValues("f_Sobuoitang")))
                With objEnChitietDV
                    .uId_Phieudichvu_Chitiet = uId_Phieudichvu_Chitiet
                    If f_SoLan_interface > (f_SoLuong_interface * i_SoLan_Dieutri) Then
                        .f_Solan = f_SoLan_interface + f_Sobuoitang
                    Else
                        .f_Solan = f_SoLuong_interface * i_SoLan_Dieutri + f_Sobuoitang
                    End If
                    .f_Soluong = CInt(Val(e.NewValues("f_Soluong")))
                    .f_Dongia = CInt(Val(e.NewValues("f_Dongia")))
                    .uId_Nhanvien = Session("uId_Nhanvien_Dangnhap")
                    'Dim strGiamgia As String = e.NewValues(5).ToString
                    'Dim strGiamgia As String = DirectCast(dgvPhieuchitiet.FindEditRowCellTemplateControl(TryCast(dgvPhieuchitiet.Columns("f_Giamgia"), GridViewDataColumn), "txtGiamgia"), TextBox).Text
                    'If InStr(strGiamgia, "%") > 0 Then
                    '    .f_Giamgia = .f_Soluong * .f_Dongia * CInt(strGiamgia.Replace("%", "")) / 100
                    'Else : .f_Giamgia = CInt(Val(strGiamgia))
                    'End If
                    .f_Tongtien = 0
                    .uId_CTKM = uId_Sale
                    .b_BaoHanh = False
                End With
                objFCChitietDV.Update(objEnChitietDV)
                CType(sender, ASPxGridView).JSProperties("cpIsUpdated") = "update"
            Else
                CType(sender, ASPxGridView).JSProperties("cpIsUpdated") = "No_Update"
            End If
        Catch ex As Exception

        End Try
        dgvPhieuchitiet.CancelEdit()
        LoadThongTinPhieuDV()
        e.Cancel = True
    End Sub

    Protected Sub dgvDanhsachphieu_DataBinding(sender As Object, e As EventArgs)
        Loaddanhsachphieu()
    End Sub

    Protected Sub dgvDevexpress_DataBound(sender As Object, e As EventArgs)
        'objFCChitietDV = New BO.TNTP_PHIEUDICHVU_CHITIETFacade
        'Dim grid As ASPxGridView = TryCast(sender, ASPxGridView)
        'Dim dt As DataTable = objFCChitietDV.SelectByID(Session("uId_Phieudichvu"))
        'Dim check As Boolean = False
        'For i As Int32 = 0 To grid.VisibleRowCount - 1
        '    check = False
        '    For ii As Integer = 0 To dt.Rows.Count - 1
        '        If dt.Rows(ii)("uId_Dichvu").ToString = grid.GetRowValues(i, "uId_Dichvu").ToString Then
        '            check = True
        '        End If
        '    Next
        '    If check = True Then
        '        grid.Selection.SetSelection(i, True)
        '    Else
        '        grid.Selection.SetSelection(i, False)
        '    End If
        'Next i
    End Sub

    Protected Sub dgvDSPhieuno_DataBinding(sender As Object, e As EventArgs)
        LoadDanhsachno()
    End Sub
    'xoa phieu dich vu
    Protected Sub dgvDanhsachphieu_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        objEnPhanQuyen = New CM.QT_PHANQUYENEntity
        objFCPhanQuyen = New BO.QT_PHANQUYENFacade
        objFCPhieuDV = New BO.TNTP_PHIEUDICHVUFacade
        objEnPhieuDV = New CM.TNTP_PHIEUDICHVUEntity
        objFCChitietDV = New BO.TNTP_PHIEUDICHVU_CHITIETFacade
        objFcthetichdiemkh = New BO.clsB_TTV_KH_Thetichdiem
        objFcDMKhachhang = New BO.CRM_DM_KhachhangFacade
        objEnPhanQuyen = objFCPhanQuyen.SelectByID(Session("uId_Nhanvien_Dangnhap").ToString, "FB558160-D9D0-4D88-A908-FA1B13515D49")
        If Not objEnPhanQuyen.b_Enable Then
            ltrErrorPuPhieu.Text = "Bạn không có quyền xóa phiếu dịch vụ!"
            e.Cancel = True
            Exit Sub
        End If
        Dim uId_Phieudichvu As String
        Dim sophieu As String
        Dim dt As DataTable
        Dim tongchitiet As Double
        uId_Phieudichvu = e.Keys(0).ToString
        sophieu = e.Values("v_Sophieu").ToString
        objEnPhieuDV = objFCPhieuDV.SelectByID(uId_Phieudichvu)
        dt = objFCChitietDV.SelectByID(uId_Phieudichvu)
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                tongchitiet += Convert.ToDouble(dt.Rows(0)("f_Tongtien").ToString)
            Next
        End If
        If objEnPhieuDV.f_Tongtienthuc >= 0 Then
            Dim uId_Khachhang As String = Session("uId_Khachhang")
            Dim f_Tongthanhtoan As Double = Convert.ToDouble(objEnPhieuDV.f_Tongtienthuc)
            Dim dt_Tichdiem As DataTable = objFcthetichdiemkh.SelectByIdKH(uId_Khachhang)
            TinhdiemHuyDv(dt_Tichdiem, f_Tongthanhtoan, "người mua", sophieu)
            'If objFcDMKhachhang.SelectByID(Session("uId_Khachhang").ToString).uId_Nguoigioithieu <> Nothing Then
            '    TinhdiemHuyDv(objFcthetichdiemkh.SelectByIdKH(objFcDMKhachhang.SelectByID(Session("uId_Khachhang").ToString).uId_Nguoigioithieu), objEnPhieuDV.f_Tongtienthuc, "người giới thiệu", sophieu)
            'End If
        End If
        objFCPhieuDV.DeleteByID(uId_Phieudichvu)
        dgvDanhsachphieu.DataBind()
        e.Cancel = True
    End Sub

    Protected Sub dgvDsTheTT_DataBinding(sender As Object, e As EventArgs)
        Dim gridView As ASPxGridView = CType(sender, ASPxGridView)
        objFCGoiDV = New BO.TNTP_KHACHHANG_GOIDICHVUFacade
        Dim dt As DataTable
        Dim uId_Khachhang = Session("uId_Khachhang")
        Dim Luachon As Integer = 2
        dt = objFCGoiDV.SelectAllTable_ByKH(uId_Khachhang, Luachon)
        gridView.DataSource = dt
    End Sub

    Protected Sub dgvDsTheTT_DataBinding_DSTHE2(sender As Object, e As EventArgs)
        LoadDSTheTT()
    End Sub

    Protected Sub dgvLoaiTT_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        Dim uId_Phieudichvu As String = Session("uId_Phieudichvu").ToString
        objFCPhieuDVLoaiTT = New BO.TNTP_PHIEUDICHVU_LOAITTFacade
        objFCPhieuDVLoaiTT.DeleteByID(uId_Phieudichvu, e.Keys(0).ToString)
        LoadDSLoaiTT()
        e.Cancel = True
        objFCPhieuDVLoaiTT = Nothing
    End Sub
#End Region
#Region "Support the tich diem"
    Public Sub TinhdiemHuyDv(dtthe As DataTable, tientinh As Double, noidung As String, sophieu As String)
        objFcDmthe = New BO.clsB_TTV_DM_THETICHDIEM
        Dim dtdmthe As DataTable
        dtdmthe = objFcDmthe.SelectAllTable(Session("uId_Cuahang").ToString)
        If dtthe.Rows.Count > 0 Then
            If dtdmthe.Rows.Count > 0 Then
                For j As Integer = 0 To dtdmthe.Rows.Count - 1 Step 1
                    If dtdmthe.Rows(j)("uId_Thetichdiem").ToString = dtthe.Rows(0)("uId_Thetichdiem").ToString Then
                        Dim f_diemhientai As Integer = dtthe.Rows(0)("f_Diemhientai")
                        Dim f_Tongtichluy As Integer = dtthe.Rows(0)("f_Tongtichluy")
                        'Dim sodiemdoi As Double = Convert.ToDouble(dtdmthe.Rows(j)("i_Sodiemdoi").ToString)
                        'Dim sotiendoi As Double = Convert.ToDouble(dtdmthe.Rows(j)("f_Sotiendoi").ToString)
                        'Dim diemtru = tientinh * sodiemdoi / sotiendoi
                        Dim diemtru = tientinh
                        If f_diemhientai >= diemtru And f_Tongtichluy >= diemtru Then
                            f_diemhientai -= diemtru
                            f_Tongtichluy -= diemtru
                            objFcthetichdiemkh.UpdatePoint(f_Tongtichluy, f_diemhientai, dtthe.Rows(0)("uId_KH_The").ToString)
                            objEnLsthetichdiem = New CM.cls_TTV_KH_Thetichdiem_LichsuEntity
                            objFcLsthetichdiem = New BO.clsB_TTV_KH_Thetichdiem_Lichsu
                            With objEnLsthetichdiem
                                .b_Luachon = False
                                .d_Ngaythuchien = DateAndTime.Now
                                .f_Diem = diemtru
                                .uId_KH_The = dtthe.Rows(0)("uId_KH_The").ToString
                                .uId_Nhanvien = Session("uId_Nhanvien_Dangnhap").ToString
                                .uId_Sukien = Nothing
                                .nv_Noidung = "Trừ điểm " + noidung + " của phiếu dịch vụ mã: " + sophieu
                            End With
                            objFcLsthetichdiem.Insert(objEnLsthetichdiem)
                        End If
                    End If
                Next
            End If

        End If
    End Sub
#End Region

    'Protected Sub dgvPhieuchitiet_CellEditorInitialize(sender As Object, e As ASPxGridViewEditorEventArgs)
    '    objFc_MKT_Sale = New BO.clsB_MKT_SALES
    '    Dim dt_Sale As DataTable = objFc_MKT_Sale.Select_All_Table()
    '    If e.Column.FieldName = "nv_Tenchuongtrinh_vn" Then
    '        Dim cbo_CTKM As ASPxComboBox = TryCast(e.Editor, ASPxComboBox)
    '        cbo_CTKM.DataSource = dt_Sale
    '        cbo_CTKM.DataBind()
    '    End If
    'End Sub
    Protected Function Load_Nhanvien_By_Phong(uId_Phong As String) As DataTable
        objFC_Nhanvien = New BO.QT_DM_NHANVIENFacade
        Dim dt As DataTable
        dt = objFC_Nhanvien.Select_Nhanvien_By_Phong(uId_Phong)
        Return dt
    End Function
    Protected Sub uId_Sale_Init(sender As Object, e As EventArgs)
        objFc_MKT_Sale = New BO.clsB_MKT_SALES
        Dim dt_Sale As DataTable = objFc_MKT_Sale.Select_All_Table()
        Dim cbo_CTKM As ASPxComboBox = TryCast(sender, ASPxComboBox)
        cbo_CTKM.DataSource = dt_Sale
        cbo_CTKM.DataBind()
    End Sub
    Protected Sub Load_Thongtin_The_Taikhoan()
        objFCPhieuDV = New BO.TNTP_PHIEUDICHVUFacade
        Dim uId_Phieudichvu As String = Session("uId_Phieudichvu")
        Dim dt As DataTable = objFCPhieuDV.Select_The_Taikhoan_By_PDV(uId_Phieudichvu)
        If dt.Rows.Count > 0 Then
            cb_Loaithe.DataSource = dt
            cb_Loaithe.DataBind()
            cb_Loaithe.SelectedIndex = 0
        End If
    End Sub

    Protected Sub cb_Loaithe_Callback(sender As Object, e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase)
        Load_Thongtin_The_Taikhoan()
    End Sub
    Private Sub LoadDMMathang()
        objFcDmMathang = New BO.QLMH_DM_MATHANGFacade
        objEnPhieuxuat = New CM.QLMH_PHIEUXUATEntity
        objFcPhieuxuat = New BO.QLMH_PHIEUXUATFacade
        If Session("uId_Phieuxuat") <> Nothing Then
            objEnPhieuxuat = objFcPhieuxuat.SelectByID(BO.Util.IsString(Session("uId_Phieuxuat")))

            Dim dt As DataTable
            If String.IsNullOrEmpty(objEnPhieuxuat.uId_Phieuxuat) = False Then
                dt = objFcDmMathang.Bang_Tonghop_Ton(DateTime.Now, objEnPhieuxuat.d_Ngayxuat, objEnPhieuxuat.uId_Kho.ToString, Session("uId_Cuahang"))
            Else
                dt = objFcDmMathang.Bang_Tonghop_Ton(DateTime.Now, DateTime.Now, ddlDMKho.Value, Session("uId_Cuahang"))

            End If
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
            grid_Phieuxuat_Chitiet.DataSource = dt
            'grid_Phieuxuat_Chitiet.DataBind()
        Else
            grid_Phieuxuat_Chitiet.DataSource = Nothing
            'grid_Phieuxuat_Chitiet.DataBind()
        End If
    End Sub
    Private Sub LoadThongTinPhieuXuat()
        objEnPhieuxuat = New CM.QLMH_PHIEUXUATEntity
        objFcPhieuxuat = New BO.QLMH_PHIEUXUATFacade
        objEnPhieuxuat = objFcPhieuxuat.SelectByID(Session("uId_Phieuxuat"))
        ddlDMKho.ValueField = objEnPhieuxuat.uId_Kho
        txtMaphieu.Text = objEnPhieuxuat.v_Maphieuxuat
        ddlKhachhang.Value = objEnPhieuxuat.uId_Khachhang
        deNgayxuat.Date = objEnPhieuxuat.d_Ngayxuat
        txtGhichu.Text = objEnPhieuxuat.nv_Noidungxuat_vn
        txtGiamgiaPhieu.Text = String.Format("{0:#,##0}", BO.Util.IsDouble(objEnPhieuxuat.f_Giamgia_Tong))
        lblTongtien.Text = String.Format("{0:#,##0}", Val(objEnPhieuxuat.nv_Noidungxuat_en))
        lblConlai.Text = String.Format("{0:#,##0}", Val(objEnPhieuxuat.nv_Noidungxuat_en) - objEnPhieuxuat.f_Giamgia_Tong)
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
    Private Sub LoadDSPhieu()
        objFcPhieuxuat = New BO.QLMH_PHIEUXUATFacade
        Dim dt As DataTable
        dt = objFcPhieuxuat.Timkiem(ddlDsKho.SelectedItem.Value.ToString, BO.Util.ConvertDateTime(deTungay.Text), BO.Util.ConvertDateTime(deDenNgay.Text), "PX")
        ASPxGridView1.DataSource = dt
        ASPxGridView1.DataBind()
    End Sub
    Protected Sub btnLuu_Click(sender As Object, e As EventArgs)
        If Session("uId_Khachhang") <> Nothing Then
            objFCPhanQuyen = New BO.QT_PHANQUYENFacade
            objEnPhieuxuat = New CM.QLMH_PHIEUXUATEntity
            objFcPhieuxuat = New BO.QLMH_PHIEUXUATFacade
            objFCNhatKy = New BO.NHATKYSUDUNGFacade
            Dim checkKhoaPhieu As Boolean
            checkKhoaPhieu = objFcPhieuxuat.SelectByID(Session("uId_Phieuxuat")).b_IsKhoa
            Dim dt_KP As New DataTable
            dt_KP = objFCPhanQuyen.SelectAllTable(Session("uId_Nhanvien_Dangnhap"), "67e68aea-9dbd-43d5-b316-e5ad9c0e6fd3")
            If checkKhoaPhieu = False Or dt_KP.Rows.Count > 0 Then
                Dim sUid_Phieuxuat As String = ""
                objEnPhieuxuat.uId_Khachhang = Session("uId_Khachhang")
                objEnPhieuxuat.uId_Kho = ddlDMKho.SelectedItem.Value.ToString
                objEnPhieuxuat.uId_Nhanvien = ddlNhanvien.SelectedItem.Value.ToString
                objEnPhieuxuat.v_Maphieuxuat = txtMaphieu.Text
                objEnPhieuxuat.d_Ngayxuat = BO.Util.ConvertDateTime(deNgayxuat.Text)
                objEnPhieuxuat.nv_Noidungxuat_vn = txtGhichu.Text
                objEnPhieuxuat.f_Giamgia_Tong = 0
                objEnPhieuxuat.f_Tongtienthuc = 0
                If Session("uId_Phieuxuat") = Nothing Then
                    Dim dt_Test As DataTable
                    dt_Test = objFcPhieuxuat.SelectBySoPhieuXuat(txtMaphieu.Text)
                    If dt_Test.Rows.Count > 0 Then
                        ShowMessage(Me, "Trùng mã phiếu!!")
                    Else
                        sUid_Phieuxuat = objFcPhieuxuat.Insert(objEnPhieuxuat)
                        objFCNhatKy.Write(Session("sTendangnhap"), System.Environment.MachineName, "Thêm mới phiếu xuất mã " & txtMaphieu.Text)
                        ShowMessage(Me, "Thêm mới thành công!")
                        Session("uId_Phieuxuat") = sUid_Phieuxuat
                    End If
                Else
                    objEnPhieuxuat.uId_Phieuxuat = Session("uId_Phieuxuat").ToString
                    objFcPhieuxuat.Update(objEnPhieuxuat)
                    objFCNhatKy.Write(Session("sTendangnhap"), System.Environment.MachineName, "Sửa thông tin phiếu xuất mã " & txtMaphieu.Text)
                    ShowMessage(Me, "Cập nhật thành công!")
                End If
                If Session("uId_Phieuxuat") <> Nothing Then
                    LoadDMMathang()
                End If
                ddlMathang.Focus()
            Else
                ShowMessage(Me, "Phiếu đã khóa!")
            End If
        End If
    End Sub
    Protected Sub ddlDonvi_Callback(sender As Object, e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase)
        LoadDonViTheoMa()
    End Sub
    Protected Sub dgvDevexpress_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        objFcPhieuxuat = New BO.QLMH_PHIEUXUATFacade
        Dim uId_Phieuxuatchitiet As String
        uId_Phieuxuatchitiet = e.Keys(0).ToString
        Try
            objFcPhieuxuat.DeleteByID_QLMH_PHIEUXUAT_CHITIET(uId_Phieuxuatchitiet)
        Catch ex As Exception

        End Try
        e.Cancel = True
        Loadphieuchitiet()
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
    Private Sub LoadDropDown_Khachhang()
        objFcKhachhang = New BO.CRM_DM_KhachhangFacade
        Dim dt As DataTable
        dt = objFcKhachhang.SelectByIDTable(Session("uId_Khachhang"))
        ddlKhachhang.DataSource = dt
        ddlKhachhang.ValueField = "uId_Khachhang"
        ddlKhachhang.TextField = "nv_Hoten_vn"
        ddlKhachhang.DataBind()
        ddlKhachhang.SelectedIndex = 0
    End Sub
    Protected Sub ddlMathang_Callback(sender As Object, e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase)
        LoadDMMathang()
    End Sub
    Protected Sub grid_Phieuxuat_Chitiet_DataBinding(sender As Object, e As EventArgs)
        Loadphieuchitiet()
    End Sub

    Protected Sub btnFilter_Click(sender As Object, e As EventArgs)
        LoadDSPhieu()
    End Sub

    Protected Sub ASPxGridView1_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        objFcPhieuxuat = New BO.QLMH_PHIEUXUATFacade
        objFCNhatKy = New BO.NHATKYSUDUNGFacade
        Dim objFcTtdKh = New BO.clsB_TTV_KH_Thetichdiem
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
#Region "the tich diem "
    Public Sub Tinhdiemtichluy(dtTheKh As DataTable, tienmathang As Double, str As String, sophieu As String)
        Dim objFcTtdKh = New BO.clsB_TTV_KH_Thetichdiem
        Dim objFcTtdLichdu = New BO.clsB_TTV_KH_Thetichdiem_Lichsu
        Dim objEnTtdLichsu = New CM.cls_TTV_KH_Thetichdiem_LichsuEntity
        Dim objFcThetichdiem = New BO.clsB_TTV_DM_THETICHDIEM
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
End Class