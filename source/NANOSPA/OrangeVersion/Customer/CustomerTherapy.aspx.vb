Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports DevExpress.Web.ASPxEditors

Public Class CustomerTherapy
    Inherits System.Web.UI.Page
#Region "Variable"
    Dim objFCQTDieutri As BO.TNTP_QT_DieutriFacade
    Dim objEnQTDieutri As CM.TNTP_QT_DieutriEntity
    Dim objEnPhieudichvu As CM.ITNTP_PHIEUDICHVUEntity
    Dim objFcPhieudichvu As BO.TNTP_PHIEUDICHVUFacade
    Dim objEnPhieudichvu_chitiet As CM.TNTP_PHIEUDICHVU_CHITIETEntity
    Dim objFcPhieudichvu_chitiet As BO.TNTP_PHIEUDICHVU_CHITIETFacade
    Dim objFcDMKhachhang As BO.CRM_DM_KhachhangFacade
    Dim objEnCongNo As CM.QLCN_CONGNOEntity
    Dim objFCCongNo As BO.QLCN_CONGNOFacade
    Dim objFCDMDichvu As BO.TNTP_DM_DICHVUFacade
    Dim objFCNhanvien As BO.QT_DM_NHANVIENFacade
    Dim objEnNhanvienphu As CM.TNTP_QT_DIEUTRI_NHANVIENPHUEntity
    Dim objFCNhanvienPhu As BO.TNTP_QT_DIEUTRI_NHANVIENPHUFacade
    Dim objFCDV_Congdoan As BO.TNTP_DM_DICHVU_CONGDOANFacade
    Dim objFC_DM_Mathang As BO.QLMH_DM_MATHANGFacade
    Dim objEN_Mathang As CM.QLMH_DM_MATHANGEntity
    Dim objFC_DMKho As BO.QLMH_DM_KHOFacade
    Dim objFCVattu As BO.QLMH_VATTUTIEUHAOFacade
    Dim objENVattu_DT As CM.QLMH_VATTUTIEUHAO_QT_DIEUTRIEntity
    Dim objFCVattu_DT As BO.QLMH_VATTUTIEUHAO_QT_DIEUTRIFacade
    Dim objFCQuydoidv As BO.DMQuyDoiDonViFacade
    Dim objEnCheckin As CM.TNTP_CHECKINCHECKOUTEntity
    Dim objFcCheckin As BO.TNTP_CHECKINCHECKOUTFacade
    Dim objFcDMPhong As BO.QLP_DM_PHONGFacade
    Dim objFcDMGiuong As BO.QLP_DM_GIUONGFacade
    Private objFCNhatKy As BO.NHATKYSUDUNGFacade
    Dim oLibP As New Lib_SAT.cls_Pub_Functions
    Dim objFcHuyDV As BO.MKT_HUYDV
    Private objFcCongnoTT As BO.QLCN_CONGNO_THANHTOANFacade
#End Region
    'Ton tai cac session
    ' uId_Dichvu_Dieutri
    ' uId_Phieudichvu
    ' uId_Khachhang
    ' uId_QT_Dieutri
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("uId_Phieudichvu") <> Nothing Then
            If Not IsPostBack Then
                LoadDropdownList()
                objFCDMDichvu = New BO.TNTP_DM_DICHVUFacade
                'txtnv1.Text = objFCDMDichvu.SelectByID(Session("uId_Dichvu_Dieutri").ToString).f_PhantramHH_KTV
                'txtnv2.Text = 0
                'txtnv3.Text = 0
                'txtnv4.Text = 0
                If Session("uId_QT_Dieutri") = Nothing Then
                    LoadLieuTrinhTuDongThietLapMoi()
                    btnCheckIn.Enabled = False
                Else
                    LoadSuaLieuTrinh()
                    btnCheckIn.Enabled = True
                End If
                LoadDMKho()
                LoadDMPhong()
                loaddmphongdatlich()

            End If
            LoadPopupVTTH()
            LoadGridDieuTri()
            Loadgridnhanvienphu()
            LoadDSVTTH()
            loadImage()
            LoadThongtinphieu()
        End If
    End Sub
#Region "Function"
    Private Sub LoadDMPhong()
        objFcDMPhong = New BO.QLP_DM_PHONGFacade
        objFcDMGiuong = New BO.QLP_DM_GIUONGFacade
        Dim dt As DataTable
        dt = objFcDMPhong.SelectPhongCoGiuongTrong()
        If dt.Rows.Count > 0 Then
            ddlPhong.DataSource = dt
            ddlPhong.TextField = "nv_Tenphong_vn"
            ddlPhong.ValueField = "uId_Phong"
            ddlPhong.DataBind()
            ddlPhong.SelectedIndex = 0
            Dim dt2 As DataTable
            dt2 = objFcDMGiuong.SelectGiuongtrongtheophong(ddlPhong.SelectedItem.Value)
            If dt2.Rows.Count > 0 Then
                ddlGiuong.DataSource = dt2
                ddlGiuong.TextField = "nv_TenGiuong_vn"
                ddlGiuong.ValueField = "uId_Giuong"
                ddlGiuong.DataBind()
                ddlGiuong.SelectedIndex = 0
            End If
        End If

    End Sub
    Private Sub loaddmphongdatlich()
        Dim objFcResource = New BO.ResourcesFacade
        Dim dt As DataTable
        dt = objFcResource.SelectAllTable()
        cboPhong.DataSource = dt
        cboPhong.ValueField = "ResourceID"
        cboPhong.TextField = "ResourceName"
        cboPhong.DataBind()
        cboPhong.SelectedIndex = 0
    End Sub
    Private Sub LoadDropdownList()
        objFcPhieudichvu_chitiet = New BO.TNTP_PHIEUDICHVU_CHITIETFacade
        objEnPhieudichvu_chitiet = New CM.TNTP_PHIEUDICHVU_CHITIETEntity
        objFCNhanvien = New BO.QT_DM_NHANVIENFacade
        objFCNhanvienPhu = New BO.TNTP_QT_DIEUTRI_NHANVIENPHUFacade
        objFCDV_Congdoan = New BO.TNTP_DM_DICHVU_CONGDOANFacade
        Dim dt As New DataTable
        deNgaydt.Date = DateTime.Now
        'Load danh muc dich vu
        dt = New DataTable
        dt = objFcPhieudichvu_chitiet.Select_Dichvu_Lieutrinh(Session("uId_Phieudichvu"))
        If dt.Rows.Count > 0 Then
            ddlDichvu.DataSource = dt
            ddlDichvu.TextField = "nv_Tendichvu_vn"
            ddlDichvu.ValueField = "uId_Dichvu"
            ddlDichvu.DataBind()
            If Session("uId_QT_Dieutri") = Nothing Then
                ddlDichvu.Value = Session("uId_Dichvu_Dieutri")
            End If
        End If
        'Load danh muc nhan vien
        dt = New DataTable
        dt = objFCNhanvien.Select_Nhanvien_By_Phong("53D2B838-DA94-4665-87A4-773EB941681C")
        If dt.Rows.Count > 0 Then
            ddlNhanvienchinh.DataSource = dt
            ddlNhanvienchinh.TextField = "nv_Hoten_vn"
            ddlNhanvienchinh.ValueField = "uId_Nhanvien"
            ddlNhanvienchinh.DataBind()
            cbo_Nhanvienphu.DataSource = dt
            cbo_Nhanvienphu.TextField = "nv_Hoten_vn"
            cbo_Nhanvienphu.ValueField = "uId_Nhanvien"
            cbo_Nhanvienphu.DataBind()
            'ddlnhanvien3.DataSource = dt
            'ddlnhanvien3.TextField = "nv_Hoten_vn"
            'ddlnhanvien3.ValueField = "uId_Nhanvien"
            'ddlnhanvien3.DataBind()
            'ddlnhanvien4.DataSource = dt
            'ddlnhanvien4.ValueField = "uId_Nhanvien"
            'ddlnhanvien4.TextField = "nv_Hoten_vn"
            'ddlnhanvien4.DataBind()

        End If
        cbo_Nhanvienphu.SelectedIndex = dt.Rows.Count
        ddlNhanvienchinh.SelectedIndex = dt.Rows.Count
        'ddlnhanvien3.Items.Add(items3)
        'ddlnhanvien4.Items.Add(items2)
        'ddlnhanvien3.SelectedIndex = dt.Rows.Count
        'ddlnhanvien4.SelectedIndex = dt.Rows.Count
        'Load cong doan
        'If Session("uId_Dichvu_Dieutri") <> Nothing Then
        '    Dim dt_cd As DataTable
        '    dt_cd = objFCDV_Congdoan.SelectAllTable(Session("uId_Dichvu_Dieutri").ToString)
        '    If dt_cd.Rows.Count > 0 Then
        '        ddlCongdoan.DataSource = dt_cd
        '        ddlCongdoan.TextField = "nv_Tencongdoan_vn"
        '        ddlCongdoan.ValueField = "uId_Congdoan"
        '        ddlCongdoan.DataBind()
        '        ddlCongdoan.SelectedIndex = 0
        '    End If
        'End If
    End Sub
    Private Sub LoadLieuTrinhTuDongThietLapMoi()
        objFcPhieudichvu_chitiet = New BO.TNTP_PHIEUDICHVU_CHITIETFacade
        objEnPhieudichvu_chitiet = New CM.TNTP_PHIEUDICHVU_CHITIETEntity
        'Load so lan dieu tri tu dong
        objEnPhieudichvu_chitiet = objFcPhieudichvu_chitiet.SelectByIDDichvu(Session("uId_Phieudichvu"), Session("uId_Dichvu_Dieutri"))
        Dim dt As DataTable
        dt = objFcPhieudichvu_chitiet.SelectByIDChitiet(objEnPhieudichvu_chitiet.uId_Phieudichvu_Chitiet)
        If dt.Rows.Count > 0 Then
            If objEnPhieudichvu_chitiet.b_BaoHanh = False Then
                txtSolanDT.Text = dt.Rows(0)("f_Solan")
                txtLanthu.Text = CStr(dt.Rows(0)("i_SL_daDieutri") + 1)
                Session("b_BaoHanh") = Nothing
                Dim objEnDMDichvu = New CM.TNTP_DM_DICHVUEntity
                objEnDMDichvu = objFCDMDichvu.SelectByID(Session("uId_Dichvu_Dieutri"))
                If (dt.Rows(0)("f_Dongia") * dt.Rows(0)("f_Soluong") = dt.Rows(0)("f_Tongtien") And Convert.ToDouble(dt.Rows(0).Item("f_Tongtien") > 0)) Then
                    txtDVbinh.Text = String.Format("{0:#,##0}", objEnDMDichvu.f_PhantramHH_KTV * 0.7)
                    txtdichvuphu.Text = String.Format("{0:#,##0}", objEnDMDichvu.f_PhantramHH_KTV * 0.3)
                    txttipchinh.Text = String.Format("{0:#,##0}", objEnDMDichvu.f_PhantramHH_NV * 0.5)
                    txttipphu.Text = String.Format("{0:#,##0}", objEnDMDichvu.f_PhantramHH_NV * 0.5)
                ElseIf dt.Rows(0)("f_Dongia") * dt.Rows(0)("f_Soluong") - dt.Rows(0)("f_Tongtien") > 0 Then
                    txtDVbinh.Text = String.Format("{0:#,##0}", objEnDMDichvu.f_PhantramHH_KTV * 0.7 * 0.7)
                    txtdichvuphu.Text = String.Format("{0:#,##0}", objEnDMDichvu.f_PhantramHH_KTV * 0.7 * 0.3)
                    txttipchinh.Text = String.Format("{0:#,##0}", objEnDMDichvu.f_PhantramHH_NV * 0.7 * 0.5)
                    txttipphu.Text = String.Format("{0:#,##0}", objEnDMDichvu.f_PhantramHH_NV * 0.7 * 0.5)
                ElseIf dt.Rows(0)("f_Tongtien") = 0 Then
                    txtDVbinh.Text = String.Format("{0:#,##0}", objEnDMDichvu.f_PhantramHH_KTV * 0.5 * 0.7)
                    txtdichvuphu.Text = String.Format("{0:#,##0}", objEnDMDichvu.f_PhantramHH_KTV * 0.5 * 0.3)
                    txttipchinh.Text = 0
                    txttipphu.Text = 0
                End If
            Else
                'Truong hop bao hanh vinh vien se khong tinh lieu trinh
                txtSolanDT.Text = "N/A"
                Session("b_BaoHanh") = "True"
            End If
        End If
    End Sub
    Private Sub LoadSuaLieuTrinh()
        objFCQTDieutri = New BO.TNTP_QT_DieutriFacade
        objEnQTDieutri = New CM.TNTP_QT_DieutriEntity
        objFcPhieudichvu_chitiet = New BO.TNTP_PHIEUDICHVU_CHITIETFacade
        objEnPhieudichvu_chitiet = New CM.TNTP_PHIEUDICHVU_CHITIETEntity
        'Load truong hop sua lieu trinh
        If (Session("uId_QT_Dieutri") <> Nothing) Then
            objEnQTDieutri = objFCQTDieutri.SelectByID(Session("uId_QT_Dieutri"))
            deNgaydt.Date = objEnQTDieutri.d_Ngaydieutri
            txtLanthu.Text = objEnQTDieutri.i_Lanthu
            'txtImgUrl.Text = objEnQTDieutri.nv_Hinhanh
            txtGHichu.Text = objEnQTDieutri.nv_Ghichu
            'If objEnQTDieutri.b_yeucau = True Then
            '    chkDuocyeucau.Checked = True
            'Else
            '    chkDuocyeucau.Checked = False
            'End If
            Dim dt As DataTable
            dt = objFcPhieudichvu_chitiet.SelectByIDChitiet(objEnQTDieutri.uId_Phieudichvu_Chitiet)
            Session("uId_Dichvu_Dieutri") = dt.Rows(0).Field(Of String)("uId_Dichvu").ToString
            ddlDichvu.Value = Session("uId_Dichvu_Dieutri")
            ddlNhanvienchinh.Value = objEnQTDieutri.uId_Nhanvien
            cbo_Nhanvienphu.Value = objEnQTDieutri.nv_Noidung
            txtDVbinh.Text = String.Format("{0:#,##0}", objEnQTDieutri.nv_Ghichu_vn)
            txtdichvuphu.Text = String.Format("{0:#,##0}", objEnQTDieutri.nv_Ghichu_cc_vn)
            txttipchinh.Text = String.Format("{0:#,##0}", objEnQTDieutri.f_HHNV3)
            txttipphu.Text = String.Format("{0:#,##0}", objEnQTDieutri.f_HHNV4)
            Dim dt_nvp As DataTable
            dt_nvp = objFCNhanvienPhu.SelectByQTDT(Session("uId_QT_Dieutri").ToString)
            'txtNhanvienphu.Text = ""
            'If dt_nvp.Rows.Count > 0 Then
            '    For Each row As DataRow In dt_nvp.Rows
            '        txtNhanvienphu.Text += row("nv_Hoten_vn") + ","
            '    Next
            'End If
        End If
    End Sub
    Private Sub LoadGridDieuTri()
        objFCQTDieutri = New BO.TNTP_QT_DieutriFacade
        objFcPhieudichvu_chitiet = New BO.TNTP_PHIEUDICHVU_CHITIETFacade
        objEnPhieudichvu_chitiet = New CM.TNTP_PHIEUDICHVU_CHITIETEntity
        Dim iSolan_Dadieutri As Integer
        'Load grid lieu trinh dieu tri
        Dim dt As DataTable
        dt = objFCQTDieutri.SelectAllByIdDV(Session("uId_Phieudichvu"), Session("uId_Dichvu_Dieutri"))
        dgvLieutrinh.DataSource = dt
        dgvLieutrinh.DataBind()
        iSolan_Dadieutri = dt.Rows.Count
        'Tinh số dịch vụ còn lại
        objEnPhieudichvu_chitiet = objFcPhieudichvu_chitiet.SelectByIDDichvu(Session("uId_Phieudichvu"), Session("uId_Dichvu_Dieutri"))
        dt = New DataTable
        dt = objFcPhieudichvu_chitiet.SelectByIDChitiet(objEnPhieudichvu_chitiet.uId_Phieudichvu_Chitiet)
        If dt.Rows.Count > 0 Then
            If objEnPhieudichvu_chitiet.b_BaoHanh = False Then
                txtSolanDT.Text = dt.Rows(0)("f_Solan")
            Else
                'Truong hop bao hanh vinh vien se khong tinh lieu trinh
                txtSolanDT.Text = "N/A"
            End If
            lblSoDVconlai.Text = "Còn lại: " & Str(CInt(dt.Rows(0)("f_Solan")) - iSolan_Dadieutri) & " lần điều trị"
        Else
            lblSoDVconlai.Text = "Còn lại 0 lần điều trị"
        End If
    End Sub
    Private Sub Loadgridnhanvienphu()
        objFCNhanvienPhu = New BO.TNTP_QT_DIEUTRI_NHANVIENPHUFacade
        'Load nhan vien phu
        Dim dt As DataTable
        If Session("uId_QT_Dieutri") <> Nothing Then
            dt = New DataTable
            dt = objFCNhanvienPhu.SelectByQTDT(Session("uId_QT_Dieutri").ToString)
            dgvNhanvienphu.DataSource = dt
            dgvNhanvienphu.DataBind()
        End If
    End Sub
    Private Sub LoadThongtinphieu()
        objFcPhieudichvu = New BO.TNTP_PHIEUDICHVUFacade
        objEnPhieudichvu = New CM.TNTP_PHIEUDICHVUEntity
        objEnCongNo = New CM.QLCN_CONGNOEntity
        objFCCongNo = New BO.QLCN_CONGNOFacade
        objFcDMKhachhang = New BO.CRM_DM_KhachhangFacade
        objFCDMDichvu = New BO.TNTP_DM_DICHVUFacade
        Dim f_Giamgia_Tong As Double = 0
        Dim f_Tongthanhtoan As Double = 0
        Dim dt As DataTable = objFcPhieudichvu.SelectByID_Table(Session("uId_Phieudichvu").ToString)
        If dt.Rows.Count > 0 Then
            f_Giamgia_Tong = Convert.ToDouble(dt.Rows(0).Item("f_Giamgia").ToString)
            f_Tongthanhtoan = Convert.ToDouble(dt.Rows(0).Item("f_Tongthanhtoan").ToString)
        End If
        ltrTitleHeader.Text = objFCDMDichvu.SelectByID(Session("uId_Dichvu_Dieutri")).nv_Tendichvu_vn
        objEnPhieudichvu = objFcPhieudichvu.SelectByID(Session("uId_Phieudichvu").ToString)
        lblHotenKH.Text = objFcDMKhachhang.SelectByID(objEnPhieudichvu.uId_Khachhang).nv_Hoten_vn
        lblSophieu.Text = objEnPhieudichvu.v_Sophieu
        txtTendichvu.Text = ltrTitleHeader.Text
        'Manhtt: Them gia tri phieu
        Dim GTPhieu As String = Format(CType((Val(TinhTong(oLibP.NullProNumber(Session("uId_Phieudichvu")))) - f_Giamgia_Tong), Double), "N0")
        lblDongia.Text = GTPhieu
        objEnCongNo = objFCCongNo.SelectByID(Session("uId_Phieudichvu"))
        Dim dblConno As Double = Format((Double.Parse(GTPhieu - f_Tongthanhtoan)), "N0").ToString()
        lblTienno.Text = Format(dblConno, "N0").ToString
        'Manhtt:Sua da thanh toan
        Dim dblDaThanhToan As Double = Format((Double.Parse(GTPhieu - dblConno)), "N0").ToString()
        Dim dblTong As Double = dblDaThanhToan
        lblTiendaTT.Text = Format(f_Tongthanhtoan, "N0").ToString
        Dim dblDaDT As Double = CDbl(objFcPhieudichvu.TongDaDT(Session("uId_Phieudichvu")))
        lblConlai.Text = Format((dblTong - dblDaDT), "N0").ToString
    End Sub
    'Manhtt:Function tinh tong gia tri phieu
    Public Function TinhTong(ByVal uId_Phieudichvu As String) As String
        Dim db As Database
        Dim sp As String = "[dbo].[spTNTP_PHIEUDICHVU_CHITIET_Thanhtoan]"
        Dim objCmd As DbCommand
        Try
            db = DatabaseFactory.CreateDatabase()
            objCmd = db.GetStoredProcCommand(sp)
            db.AddInParameter(objCmd, "@uId_Phieudichvu", DbType.String, uId_Phieudichvu)
            Return db.ExecuteDataSet(objCmd).Tables(0).Rows(0)(0).ToString
        Catch ex As Exception
            Return False
        End Try
        db = Nothing
        objCmd = Nothing
    End Function
    Private Function NAToDouble(ByVal value As String) As Double
        Dim rs As Double
        If value = "N/A" Or value = "" Then
            rs = 0
        Else
            rs = value
        End If
        Return rs
    End Function

    'Load vat tu tieu hao
    '==Load kho
    Private Sub LoadDMKho()
        objFC_DMKho = New BO.QLMH_DM_KHOFacade
        'Load kho
        Dim dt = New DataTable
        dt = objFC_DMKho.SelectAllTable(Session("uId_Cuahang"))
        cbKho.DataSource = dt
        cbKho.TextField = "nv_Tenkho_vn"
        cbKho.ValueField = "uId_Kho"
        cbKho.DataBind()
        cbKho.SelectedIndex = 1
    End Sub
    '==Load vat tu
    Private Sub LoadPopupVTTH()
        objFC_DM_Mathang = New BO.QLMH_DM_MATHANGFacade
        'Load Vat tu
        Dim dt = New DataTable
        dt = objFC_DM_Mathang.Bang_Tonghop_Ton(DateTime.Now, deNgaydt.Date, cbKho.SelectedItem.Value.ToString, Session("uId_Cuahang"))
        If dt.Rows.Count > 0 Then
            cbTenvattu.DataSource = dt
            cbTenvattu.TextField = "nv_TenMathang_vn"
            cbTenvattu.ValueField = "uId_Mathang"
            cbTenvattu.DataBind()
        Else
            cbTenvattu.DataSource = Nothing
            cbTenvattu.DataBind()
        End If
    End Sub
    '==Load ds vat tu tieu hao
    Private Sub LoadDSVTTH()
        objFCVattu = New BO.QLMH_VATTUTIEUHAOFacade
        If (Session("uId_QT_Dieutri") <> Nothing) Then
            Dim dt As New DataTable
            dt = objFCVattu.SelectAllByQTDT(Session("uId_QT_Dieutri"), cbKho.SelectedItem.Value.ToString)
            dgvVTTH.DataSource = dt
            dgvVTTH.DataBind()
        End If
    End Sub
    '==Load danh sach don vi theo ma vat tu
    Private Sub LoadDonViTheoMa()
        objFCQuydoidv = New BO.DMQuyDoiDonViFacade
        Dim dt As DataTable
        dt = objFCQuydoidv.LoadDSDonViTheoVatTu(Session("MaVatTu"))
        If dt.Rows.Count > 0 Then
            cbDonvi.DataSource = dt
            cbDonvi.ValueField = "MaDonVi"
            cbDonvi.TextField = "TenDonVi"
            cbDonvi.DataBind()
        Else
            cbDonvi.Items.Clear()
            cbDonvi.Text = ""
        End If
    End Sub

    Private Sub loadImage()
        Dim dt As DataTable
        Dim objFcDieutriHinhanh As New BO.clsB_TNTP_Dieutri_Hinhanh
        dt = objFcDieutriHinhanh.SelectByuId_Dieutri(Session("uId_QT_Dieutri"))
        dtv_DieutriHinhanh.DataSource = dt
        dtv_DieutriHinhanh.DataBind()
    End Sub
#End Region
#Region "Button"
    Protected Sub btnLuu_Click(sender As Object, e As EventArgs)
        objEnPhieudichvu_chitiet = New CM.TNTP_PHIEUDICHVU_CHITIETEntity
        objFcPhieudichvu_chitiet = New BO.TNTP_PHIEUDICHVU_CHITIETFacade
        objEnQTDieutri = New CM.TNTP_QT_DieutriEntity
        objFCQTDieutri = New BO.TNTP_QT_DieutriFacade
        objFCNhatKy = New BO.NHATKYSUDUNGFacade
        objFcCheckin = New BO.TNTP_CHECKINCHECKOUTFacade
        objEnCheckin = New CM.TNTP_CHECKINCHECKOUTEntity
        'Phuongdv_ Sua thong bao khi het tien dieu tri
        objFcPhieudichvu = New BO.TNTP_PHIEUDICHVUFacade
        objEnPhieudichvu = New CM.TNTP_PHIEUDICHVUEntity
        objEnCongNo = New CM.QLCN_CONGNOEntity
        objFCCongNo = New BO.QLCN_CONGNOFacade
        objFcDMKhachhang = New BO.CRM_DM_KhachhangFacade
        objFCDMDichvu = New BO.TNTP_DM_DICHVUFacade
        objFcCongnoTT = New BO.QLCN_CONGNO_THANHTOANFacade
        ltrTitleHeader.Text = objFCDMDichvu.SelectByID(Session("uId_Dichvu_Dieutri")).nv_Tendichvu_vn
        objEnPhieudichvu = objFcPhieudichvu.SelectByID(Session("uId_Phieudichvu").ToString)
        lblHotenKH.Text = objFcDMKhachhang.SelectByID(objEnPhieudichvu.uId_Khachhang).nv_Hoten_vn
        lblSophieu.Text = objEnPhieudichvu.v_Sophieu
        txtTendichvu.Text = ltrTitleHeader.Text
        'Manhtt: Them gia tri phieu
        Dim GTPhieu As String = Format(CType((Val(TinhTong(oLibP.NullProNumber(Session("uId_Phieudichvu")))) - Val(objEnPhieudichvu.f_Giamgia)), Double), "N0")
        lblDongia.Text = GTPhieu
        objEnCongNo = objFCCongNo.SelectByID(Session("uId_Phieudichvu"))
        Dim dblConno As Double = CDbl(objEnCongNo.f_Sotien)
        lblTienno.Text = Format(dblConno, "N0").ToString
        'Manhtt:Sua da thanh toan
        Dim dblDaThanhToan As Double = Format((Double.Parse(GTPhieu - dblConno)), "N0").ToString()
        Dim dblTong As Double = dblDaThanhToan
        lblTiendaTT.Text = Format(dblTong, "N0").ToString
        Dim dblDaDT As Double = CDbl(objFcPhieudichvu.TongDaDT(Session("uId_Phieudichvu")))
        lblConlai.Text = Format((dblTong - dblDaDT), "N0").ToString
        ''
        Dim table As DataTable = objFcCongnoTT.SelectByID_PDV(Session("uId_Phieudichvu").ToString)
        Dim table2 As DataTable = objFCCongNo.SelectByID_TB(Session("uId_Phieudichvu").ToString)


        If Session("b_BaoHanh") = Nothing Then
            If Val(txtLanthu.Text.Trim) - Val(txtSolanDT.Text.Trim) > 0 Then
                ShowMessage(Me, "Đã hết lần thực hiện!")
                Exit Sub
            End If
        End If
        ' lay ve bang mat hang tieu hao cho dich vu
        objEnPhieudichvu_chitiet = objFcPhieudichvu_chitiet.SelectByIDDichvu(Session("uId_Phieudichvu"), ddlDichvu.SelectedItem.Value)
        Dim uId_Dichvu As String = ddlDichvu.SelectedItem.Value

        If ckthucong.Checked = False Then
            Dim dttieuhao As DataTable
            Dim objFcDVCongdoan As New BO.TNTP_DM_DICHVU_CONGDOANFacade
            dttieuhao = objFcDVCongdoan.SelectAllTable(uId_Dichvu)
            Dim check As Integer = 0
            If dttieuhao.Rows.Count > 0 Then
                For i As Integer = 0 To dttieuhao.Rows.Count - 1 Step 1
                    If dttieuhao.Rows(i)("uId_Mathang") <> Nothing Then
                        Dim objFCMathang As New BO.QLMH_DM_MATHANGFacade
                        Dim tonkho As Double
                        tonkho = objFCMathang.LaySLTonByTime(DateTime.Now, dttieuhao.Rows(i)("uId_Kho").ToString, Session("uId_Cuahang"), dttieuhao.Rows(i)("uId_Mathang").ToString)
                        If tonkho < Convert.ToDouble(dttieuhao.Rows(i)("f_Soluong").ToString) Then
                            check += 1
                        End If
                    End If
                Next
            End If



            Dim objenDMDichvu = New CM.TNTP_DM_DICHVUEntity
            objenDMDichvu = objFCDMDichvu.SelectByID(ddlDichvu.Value.ToString)
            With objEnQTDieutri
                .uId_Phieudichvu_Chitiet = objEnPhieudichvu_chitiet.uId_Phieudichvu_Chitiet
                .d_Ngaydieutri = deNgaydt.Date
                .i_Lanthu = Val(txtLanthu.Text)
                .uId_Nhanvien = ddlNhanvienchinh.SelectedItem.Value.ToString
                .nv_Ghichu = txtGHichu.Text
                'uid nhanvienphu luu vao cot noi dung
                '.nv_Hinhanh = txtImgUrl.Text
                .uId_Trangthai = "fb83dd87-caf8-427d-81fa-c683e8fec955"
                .f_Lephi_DT = 0
                .f_SuatDT = "0"
                .nv_Noidung = cbo_Nhanvienphu.Value.ToString()
                .b_yeucau = True
                '.nv_Ghichu_vn = Convert.ToDouble(txtnv1.Text)
                '.nv_Ghichu_cc_vn = Convert.ToDouble(txtnv2.Text)
                '.f_HHNV3 = Convert.ToDouble(txtnv3.Text)
                '.f_HHNV4 = Convert.ToDouble(txtnv4.Text)
                .b_Tieuhao = False
                '.uId_Nhanvien3 = ddlnhanvien3.Value.ToString()
                '.uId_Nhanvien4 = ddlnhanvien4.Value.ToString()
                .f_HHNV3 = Val(txttipchinh.Text.Replace(",", ""))
                .f_HHNV4 = txttipphu.Text.Replace(",", "")
                .nv_Ghichu_vn = txtDVbinh.Text.Replace(",", "")
                .nv_Ghichu_cc_vn = txtdichvuphu.Text.Replace(",", "")
            End With


            Dim checkhh As Double = objFCDMDichvu.SelectByID(ddlDichvu.Value.ToString()).f_PhantramHH_KTV
            'Dim sotien As Double = Convert.ToDouble(txtnv1.Text) + Convert.ToDouble(txtnv2.Text) + Convert.ToDouble(txtnv3.Text) + Convert.ToDouble(txtnv4.Text)
            'If checkhh < sotien Then
            '    ShowMessage(Me, "Bạn đã kê hoa hồng vượt quá mức cho phép!")
            '    Exit Sub
            'End If

            If check = 0 Then
                If Session("uId_QT_Dieutri") = Nothing Then
                    Session("uId_QT_Dieutri") = objFCQTDieutri.Insert(objEnQTDieutri)
                    objFCNhatKy.Write(Session("sTendangnhap"), System.Environment.MachineName, "Thiết lập điều trị dịch vụ " & ddlDichvu.SelectedItem.Text & " lần thứ " & txtLanthu.Text & " cho khách hàng " & lblHotenKH.Text)
                    ShowMessage(Me, "Thiết lập liệu trình thành công!")
                    Dim objFcAp = New BO.AppointmentsFacade
                    Dim objEnDMDichvus = New CM.TNTP_DM_DICHVUEntity
                    objFCDMDichvu = New BO.TNTP_DM_DICHVUFacade
                    Dim objEnAp = New CM.AppointmentsEntity
                    objEnQTDieutri = New CM.TNTP_QT_DieutriEntity
                    objFCQTDieutri = New BO.TNTP_QT_DieutriFacade
                    objEnQTDieutri = objFCQTDieutri.SelectByID(Session("uId_QT_Dieutri").ToString)
                    objEnPhieudichvu_chitiet = New CM.TNTP_PHIEUDICHVU_CHITIETEntity
                    objFcPhieudichvu_chitiet = New BO.TNTP_PHIEUDICHVU_CHITIETFacade
                    Dim dt As DataTable
                    If Session("uId_Phieudichvu_Chitiet") = Nothing Then
                        dt = objFcPhieudichvu_chitiet.SelectByIDChitiet(Session("uId_Dichvu_Chitiet").ToString)
                        objEnDMDichvus = objFCDMDichvu.SelectByID(Session("uId_Dichvu_Dieutri"))
                        If objEnDMDichvus.i_Songayquaylai > 0 Then
                            With objEnAp
                                .CustomField1 = Session("uId_Khachhang").ToString
                                .StartDate = deNgaydt.Date.AddDays(objenDMDichvu.i_Songayquaylai)
                                .EndDate = deNgaydt.Date.AddDays(objenDMDichvu.i_Songayquaylai).AddMinutes(objenDMDichvu.f_Sophutthuchien)
                                .uId_Nhanvien = ddlNhanvienchinh.Value.ToString
                                .Status = 2
                                .Label = 0
                                .Subject = ddlDichvu.Text
                                .Description = ddlDichvu.Text
                                .uId_Cuahang = Session("uId_Cuahang")

                                .ResourceID = Integer.Parse(cboPhong.Value)
                            End With
                            If dt.Rows(0)("f_Solan") - dt.Rows(0)("i_Landasudung") >= 0 Then
                                Try
                                    objFcAp.Insert(objEnAp)
                                    'ShowMessage(Me, "Đặt phòng thành công!")
                                Catch ex As Exception
                                    ShowMessage(Me, "Phòng đã được đặt, hãy chọn phòng khác!")
                                End Try

                            End If
                        End If
                    Else
                        dt = objFcPhieudichvu_chitiet.SelectByIDChitiet(Session("uId_Phieudichvu_Chitiet").ToString)
                        objEnDMDichvus = objFCDMDichvu.SelectByID(Session("uId_Dichvu_Dieutri"))
                        If objEnDMDichvus.i_Songayquaylai > 0 Then
                            With objEnAp
                                .CustomField1 = Session("uId_Khachhang").ToString
                                .StartDate = deNgaydt.Date.AddDays(objenDMDichvu.i_Songayquaylai)
                                .EndDate = deNgaydt.Date.AddDays(objenDMDichvu.i_Songayquaylai).AddMinutes(objenDMDichvu.f_Sophutthuchien)
                                .uId_Nhanvien = ddlNhanvienchinh.Value.ToString
                                .Status = 2
                                .Label = 0
                                .Subject = ddlDichvu.Text
                                .Description = ddlDichvu.Text
                                .uId_Cuahang = Session("uId_Cuahang")
                                .ResourceID = Integer.Parse(cboPhong.Value)
                            End With
                            If dt.Rows(0)("f_Solan") - dt.Rows(0)("i_Landasudung") >= 0 Then
                                Try
                                    objFcAp.Insert(objEnAp)
                                    '  ShowMessage(Me, "Đặt phòng thành công!")
                                Catch ex As Exception
                                    ShowMessage(Me, "Phòng đã được đặt, hãy chọn phòng khác!")
                                End Try

                            End If
                        End If
                    End If


                Else
                    objEnQTDieutri.uId_QT_Dieutri = Session("uId_QT_Dieutri")
                    objFCQTDieutri.Update(objEnQTDieutri)
                    objFCNhatKy.Write(Session("sTendangnhap"), System.Environment.MachineName, "Sửa điều trị dịch vụ " & ddlDichvu.SelectedItem.Text & " lần thứ " & txtLanthu.Text & " của khách hàng " & lblHotenKH.Text)
                    ShowMessage(Me, "Cập nhật liệu trình thành công!")
                End If
            Else
                ShowMessage(Me, "Hết mặt hàng sử dụng cho dịch vụ!")
            End If
        Else
            Dim objenDMDichvu = New CM.TNTP_DM_DICHVUEntity
            objenDMDichvu = objFCDMDichvu.SelectByID(ddlDichvu.Value.ToString)
            With objEnQTDieutri
                .uId_Phieudichvu_Chitiet = objEnPhieudichvu_chitiet.uId_Phieudichvu_Chitiet
                .d_Ngaydieutri = deNgaydt.Date
                .i_Lanthu = Val(txtLanthu.Text)
                .uId_Nhanvien = ddlNhanvienchinh.SelectedItem.Value.ToString
                .nv_Ghichu = txtGHichu.Text
                'uid nhanvienphu luu vao cot noi dung
                '.nv_Hinhanh = txtImgUrl.Text
                .uId_Trangthai = "fb83dd87-caf8-427d-81fa-c683e8fec955"
                .f_Lephi_DT = 0
                .f_SuatDT = "0"
                .nv_Noidung = cbo_Nhanvienphu.Value.ToString()
                .f_HHNV3 = Val(txttipchinh.Text.Replace(",", ""))
                .f_HHNV4 = txttipphu.Text.Replace(",", "")
                .nv_Ghichu_vn = txtDVbinh.Text.Replace(",", "")
                .nv_Ghichu_cc_vn = txtdichvuphu.Text.Replace(",", "")
                .b_Tieuhao = True
                '.uId_Nhanvien3 = ddlnhanvien3.Value.ToString()
                '.uId_Nhanvien4 = ddlnhanvien4.Value.ToString()
            End With



            'Dim checkhh As Double = objFCDMDichvu.SelectByID(ddlDichvu.Value.ToString()).f_PhantramHH_KTV
            'If checkhh < Convert.ToDouble(txtnv1.Text) + Convert.ToDouble(txtnv2.Text) + Convert.ToDouble(txtnv3.Text) + Convert.ToDouble(txtnv4.Text) Then
            '    ShowMessage(Me, "Bạn đã kê hoa hồng vượt quá mức cho phép!")
            '    Exit Sub
            'End If

            If Session("uId_QT_Dieutri") = Nothing Then
                Session("uId_QT_Dieutri") = objFCQTDieutri.Insert(objEnQTDieutri)
                objFCNhatKy.Write(Session("sTendangnhap"), System.Environment.MachineName, "Thiết lập điều trị dịch vụ " & ddlDichvu.SelectedItem.Text & " lần thứ " & txtLanthu.Text & " cho khách hàng " & lblHotenKH.Text)
                ShowMessage(Me, "Thiết lập liệu trình thành công!")
            Else
                objEnQTDieutri.uId_QT_Dieutri = Session("uId_QT_Dieutri")
                objFCQTDieutri.Update(objEnQTDieutri)
                objFCNhatKy.Write(Session("sTendangnhap"), System.Environment.MachineName, "Sửa điều trị dịch vụ " & ddlDichvu.SelectedItem.Text & " lần thứ " & txtLanthu.Text & " của khách hàng " & lblHotenKH.Text)
                ShowMessage(Me, "Cập nhật liệu trình thành công!")
            End If
        End If

        If Session("uId_QT_Dieutri") <> Nothing Then
            btnChonanh.Enabled = True
            btnCheckIn.Enabled = True
        Else
            btnCheckIn.Enabled = False
        End If
        LoadGridDieuTri()
        loadImage()
        LoadThongtinphieu()
    End Sub

    Protected Sub btnLuuCongdoan_Click(sender As Object, e As EventArgs)
        objEnNhanvienphu = New CM.TNTP_QT_DIEUTRI_NHANVIENPHUEntity
        objFCNhanvienPhu = New BO.TNTP_QT_DIEUTRI_NHANVIENPHUFacade
        If Session("uId_QT_Dieutri") <> Nothing Then
            With objEnNhanvienphu
                .uId_QT_Dieutri = Session("uId_QT_Dieutri").ToString
                .uId_Nhanvien_Phu = ddlNhanvienphu.SelectedItem.Value.ToString
                .uId_Congdoan = ddlCongdoan.SelectedItem.Value.ToString
            End With
            Try
                objFCNhanvienPhu.Insert(objEnNhanvienphu)
                Loadgridnhanvienphu()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Protected Sub btnLuuVTTH_Click(sender As Object, e As EventArgs)
        objENVattu_DT = New CM.QLMH_VATTUTIEUHAO_QT_DIEUTRIEntity
        objFCVattu_DT = New BO.QLMH_VATTUTIEUHAO_QT_DIEUTRIFacade
        objFC_DM_Mathang = New BO.QLMH_DM_MATHANGFacade
        objFCNhatKy = New BO.NHATKYSUDUNGFacade
        Dim SLTon As Integer
        Dim LaySLNhoNhat As Integer
        SLTon = objFC_DM_Mathang.LaySLTonByTime(deNgaydt.Date, cbKho.SelectedItem.Value.ToString, Session("uId_Cuahang").ToString(), cbTenvattu.Value.ToString)
        LaySLNhoNhat = objFC_DM_Mathang.QuyDoiVeDonViNhoNhat(cbTenvattu.Value.ToString, cbDonvi.Value.ToString, Val(txtSoluongTH.Text))
        If SLTon >= LaySLNhoNhat Then
            With objENVattu_DT
                .uId_QT_Dieutri = Session("uId_QT_Dieutri")
                .uId_Mathang = cbTenvattu.Value.ToString
                .f_SLTieuhao = Val(txtSoluongTH.Text)
                .uId_Kho = cbKho.Value.ToString
                .Madonvi = cbDonvi.Value.ToString
            End With
            Try
                objFCVattu_DT.Insert(objENVattu_DT)
                objFCNhatKy.Write(Session("sTendangnhap"), System.Environment.MachineName, "Thêm VTTH " & cbTenvattu.SelectedItem.Text & " vào điều trị dịch vụ " & ddlDichvu.SelectedItem.Text.ToString & " trong phiếu " & lblSophieu.Text)
                ltrError.Text = ""
                LoadDSVTTH()
                LoadPopupVTTH()
                cbTenvattu.Text = ""
                Session("MaVatTu") = Nothing
                LoadDonViTheoMa()
                cbTenvattu.Focus()
                txtSoluongTH.Text = ""
            Catch ex As Exception

            End Try
        Else
            ltrError.Text = "<span class='error'>Vật tư " + cbTenvattu.Text + " trong kho " + cbKho.Text + " không đủ số lượng để kê, vui lòng nhập thêm hàng</span>"
            txtSoluongTH.Focus()
        End If
    End Sub
    Protected Sub btnCheckin_Click(sender As Object, e As EventArgs)
        objEnCheckin = New CM.TNTP_CHECKINCHECKOUTEntity
        objFcCheckin = New BO.TNTP_CHECKINCHECKOUTFacade
        objFcDMGiuong = New BO.QLP_DM_GIUONGFacade
        objFcPhieudichvu_chitiet = New BO.TNTP_PHIEUDICHVU_CHITIETFacade
        objFCQTDieutri = New BO.TNTP_QT_DieutriFacade
        objEnQTDieutri = New CM.TNTP_QT_DieutriEntity
        objFCDMDichvu = New BO.TNTP_DM_DICHVUFacade
        If Session("uId_QT_Dieutri") <> Nothing Then
            objEnQTDieutri = objFCQTDieutri.SelectByID(Session("uId_QT_Dieutri"))
            Dim uId_Phieuichvu_Chitiet As String = objEnQTDieutri.uId_Phieudichvu_Chitiet
            Dim uId_Dichvu As String = objFcPhieudichvu_chitiet.SelectByIDChitiet(uId_Phieuichvu_Chitiet).Rows(0)("uId_Dichvu").ToString
            Dim timenow As DateTime = DateTime.Now
            objEnCheckin.uId_Giuong = ddlGiuong.SelectedItem.Value.ToString()
            objEnCheckin.uId_QT_Dieutri = Session("uId_QT_Dieutri")
            objEnCheckin.dt_checkin = timenow ' duoc ngay - thang - nam - gio - phut - giay - tich tac
            Try
                objFcCheckin.Insert(objEnCheckin)
                objFcDMGiuong.UpdateTrangThai(ddlGiuong.SelectedItem.Value.ToString(), True)
                ShowMessage(Me, "Checkin Successfully!")
                Response.Redirect(Request.RawUrl)
            Catch ex As Exception

            End Try
            ltrError1.Text = "<span class='error'>Hết mặt hàng trong kho</span>"
        Else
            ltrError1.Text = "<span class='error'>Không có liệu trình checkin</span>"
        End If
    End Sub
    Protected Sub btnCheckout_Click(sender As Object, e As EventArgs)

    End Sub
#End Region
#Region "Grid Region"
    Protected Sub dgvLieutrinh_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        objFCQTDieutri = New BO.TNTP_QT_DieutriFacade
        objFCVattu_DT = New BO.QLMH_VATTUTIEUHAO_QT_DIEUTRIFacade
        objFCNhatKy = New BO.NHATKYSUDUNGFacade
        Dim uId_QT_Dieutri As String
        uId_QT_Dieutri = e.Keys(0).ToString
        objFCQTDieutri.DeleteByID(uId_QT_Dieutri)
        objFCVattu_DT.DeleteByID_QTDT(uId_QT_Dieutri)
        objFCNhatKy.Write(Session("sTendangnhap"), System.Environment.MachineName, "Xóa liệu trình của dịch vụ " & ddlDichvu.SelectedItem.Text.ToString & " lần thứ " & e.Keys(1).ToString & " trong phiếu " & lblSophieu.Text)
        Session("uId_QT_Dieutri") = Nothing
        LoadGridDieuTri()
        e.Cancel = True
    End Sub

    Protected Sub dgvNhanvienphu_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        objFCNhanvienPhu = New BO.TNTP_QT_DIEUTRI_NHANVIENPHUFacade
        Dim uId_Congdoan As String
        Dim uId_Nhanvienphu As String
        Dim uId_QT_Dieutri As String
        uId_Congdoan = e.Keys(0).ToString
        uId_Nhanvienphu = e.Keys(1).ToString
        uId_QT_Dieutri = e.Keys(2).ToString
        objFCNhanvienPhu.DeleteByAll(uId_QT_Dieutri, uId_Nhanvienphu, uId_Congdoan)
        Loadgridnhanvienphu()
        e.Cancel = True
    End Sub

    Protected Sub dgvVTTH_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        objENVattu_DT = New CM.QLMH_VATTUTIEUHAO_QT_DIEUTRIEntity
        objFCVattu_DT = New BO.QLMH_VATTUTIEUHAO_QT_DIEUTRIFacade
        objFCNhatKy = New BO.NHATKYSUDUNGFacade
        Dim uId_QT_Dieutri = e.Keys(0).ToString
        Dim uId_Mathang = e.Keys(1).ToString
        Dim uId_Kho = e.Keys(2).ToString
        With objENVattu_DT
            .uId_QT_Dieutri = uId_QT_Dieutri
            .uId_Mathang = uId_Mathang
            .uId_Kho = uId_Kho
        End With
        objFCVattu_DT.DeleteByID(objENVattu_DT)
        'objFCNhatKy.Write(Session("sTendangnhap"), System.Environment.MachineName, "Xóa VTTH " & cbTenvattu.SelectedItem.Text & " của dịch vụ " & ddlDichvu.SelectedItem.Text & "trong phiếu " & lblSophieu.Text)
        LoadDSVTTH()
        LoadPopupVTTH()
        e.Cancel = True
    End Sub
    Protected Sub dgvVTTH_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
        objENVattu_DT = New CM.QLMH_VATTUTIEUHAO_QT_DIEUTRIEntity
        objFCVattu_DT = New BO.QLMH_VATTUTIEUHAO_QT_DIEUTRIFacade
        Dim uId_QT_Dieutri = e.Keys(0).ToString
        Dim uId_Mathang = e.Keys(1).ToString
        Dim uId_Kho = e.Keys(2).ToString
        Dim madonvi = e.Keys(3).ToString
        With objENVattu_DT
            .uId_QT_Dieutri = uId_QT_Dieutri
            .uId_Mathang = uId_Mathang
            .uId_Kho = uId_Kho
            .f_SLTieuhao = Val(e.NewValues(2).ToString)
            .Madonvi = madonvi
        End With
        objFCVattu_DT.Update(objENVattu_DT)
        LoadDSVTTH()
        e.Cancel = True
    End Sub
#End Region
#Region "Combobox event"
    Protected Sub cbDonvi_Callback(sender As Object, e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase)
        LoadDonViTheoMa()
    End Sub
    Protected Sub cbTenvattu_Callback(sender As Object, e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase)
        LoadPopupVTTH()
    End Sub
    Protected Sub ddlPhong_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlPhong.SelectedIndexChanged
        objFcDMGiuong = New BO.QLP_DM_GIUONGFacade
        Dim dt As DataTable
        dt = objFcDMGiuong.SelectGiuongtrongtheophong(ddlPhong.SelectedItem.Value)
        ddlGiuong.Items.Clear()
        If dt.Rows.Count > 0 Then
            ddlGiuong.DataSource = dt
            ddlGiuong.TextField = "nv_TenGiuong_vn"
            ddlGiuong.ValueField = "uId_Giuong"
            ddlGiuong.DataBind()
            ddlGiuong.SelectedIndex = 0
        End If
    End Sub
#End Region
    Protected Sub btnHuyDV_Click(sender As Object, e As EventArgs)
        Dim dt3 As DataTable
        Dim dt As DataTable
        Dim objEnThechuyentien = New CM.cls_TTV_KH_THECHUYENTIENEntity
        Dim objEnDMKhachhang = New CM.CRM_DM_KhachhangEntity
        Dim objFcThechuyentien = New BO.clsB_TTV_KH_THECHUYENTIENFacade
        Dim objEnPhieudichvuchitiet = New CM.TNTP_PHIEUDICHVU_CHITIETEntity
        Dim objFcPhieudichvu_chitiet = New BO.TNTP_PHIEUDICHVU_CHITIETFacade
        Dim objEnHuyDV As New CM.MKT_HUYDV
        objFcHuyDV = New BO.MKT_HUYDV
        Dim dt_Check As Boolean = False
        Dim str As String = Session("uId_Dichvu_Chitiet")
        dt = objFcPhieudichvu_chitiet.SelectByIDChitiet(str)
        If dt.Rows.Count > 0 Then
            dt3 = objFcPhieudichvu_chitiet.SelectByID(Session("uId_Phieudichvu"))
            If dt3.Rows.Count > 0 Then
                If dt3.Rows(0)("f_Tongtienthuc") < dt3.Rows(0)("f_Dongia") Then
                    ShowMessage(Me, "Phiếu không thể chuyển tiền!")
                    Exit Sub
                End If
            End If
        End If
        objEnPhieudichvuchitiet.uId_Phieudichvu_Chitiet = Session("uId_Dichvu_Chitiet").ToString
        If objEnPhieudichvuchitiet.uId_Phieudichvu_Chitiet = Session("uId_Dichvu_Chitiet").ToString <> Nothing Then
            dt_Check = objFcPhieudichvu_chitiet.Check_HuyDV(Session("uId_Dichvu_Chitiet").ToString)
            If (dt_Check) Then
                ShowMessage(Me, "Dịch vụ đã điều trị hết số lần không thể hủy!")
            Else
                With objEnHuyDV
                    .uId_Phieudichvu = Session("uId_Phieudichvu")
                    .uId_Nhanvien = Session("uId_Nhanvien_Dangnhap")
                    .uId_Khachhang = Session("uId_Khachhang")
                    .Date = DateTime.Now
                    .nv_Ghichu_vn = "Hủy liệu trình"
                    .uId_Dichvu = ddlDichvu.SelectedItem.Value
                End With
                If objFcHuyDV.Insert(objEnHuyDV) Then
                    objEnDMKhachhang.uId_Khachhang = Session("uId_Khachhang").ToString
                    objFcThechuyentien.Update(objEnThechuyentien, objEnPhieudichvuchitiet.uId_Phieudichvu_Chitiet, objEnDMKhachhang.uId_Khachhang)
                    Load_DM_Dieutri()
                    ShowMessage(Me, "Phiếu hủy thành công, số tiền còn lại đã được chuyển vào thẻ tài khoản!")
                End If
            End If

        End If
        LoadThongtinphieu()

    End Sub
    Protected Sub Load_DM_Dieutri()
        objFcPhieudichvu_chitiet = New BO.TNTP_PHIEUDICHVU_CHITIETFacade
        Dim dt = New DataTable
        dt = objFcPhieudichvu_chitiet.Select_Dichvu_Lieutrinh(Session("uId_Phieudichvu"))
        ddlDichvu.DataSource = dt
        ddlDichvu.TextField = "nv_Tendichvu_vn"
        ddlDichvu.ValueField = "uId_Dichvu"
        ddlDichvu.DataBind()
    End Sub
    'Protected Sub loadphieuhuy()
    '    Dim dt As DataTable
    '    Dim objFcPhieudichvu_chitiet = New BO.TNTP_PHIEUDICHVU_CHITIETFacade
    '    Dim objEnPhieudichvu_chitiet = New CM.TNTP_PHIEUDICHVU_CHITIETEntity
    '    Dim str As String = Session("uId_Dichvu_Chitiet")
    '    dt = objFcPhieudichvu_chitiet.SelectByIDChitiet(str)
    '    If dt.Rows.Count > 0 Then
    '        Dim trangthai As Boolean
    '        trangthai = dt.Rows(0)("b_Trangthai")
    '        If trangthai = True Then
    '            btnLuu.Enabled = False
    '            btnChonanh.Enabled = False
    '            btnCheckIn.Enabled = False
    '            btnVTTH.Enabled = False
    '            btnHuyDV.Enabled = False
    '            btnPhieumoi.Enabled = False
    '            txtGHichu.Enabled = False
    '            btnHuyDV.Enabled = False
    '            ddlNhanvienchinh.Enabled = False
    '            cbo_Nhanvienphu.Enabled = False
    '            deNgaydt.Enabled = False
    '            txtSolanDT.Enabled = False
    '            txtLanthu.Enabled = False
    '            txtTendichvu.Enabled = False
    '            'ddlDichvu.Enabled = False
    '            lblSoDVconlai.Enabled = False
    '            chkDuocyeucau.Enabled = False
    '            btnIncongdoan.Enabled = False

    '        End If
    '    End If

    'End Sub

    Protected Sub ddlDichvu_SelectedIndexChanged(sender As Object, e As EventArgs)
        objFcPhieudichvu_chitiet = New BO.TNTP_PHIEUDICHVU_CHITIETFacade
        objEnPhieudichvu_chitiet = New CM.TNTP_PHIEUDICHVU_CHITIETEntity
        objEnPhieudichvu_chitiet = objFcPhieudichvu_chitiet.SelectByIDDichvu(Session("uId_Phieudichvu"), ddlDichvu.Value.ToString)
        Session("uId_Dichvu_Chitiet") = objEnPhieudichvu_chitiet.uId_Phieudichvu_Chitiet
    End Sub
End Class