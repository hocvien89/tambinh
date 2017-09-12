Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView
Imports System.Drawing

Public Class ConsultService
    Inherits System.Web.UI.Page
    Dim objFcChoXyLy As BO.PQP_TRANGTHAIKHCHOXULYFacade
    Dim objFcDMTrangthai As BO.CRM_DM_TRANGTHAIFacade
    Dim objEnDMPhong As CM.QLP_DM_PHONGEntity
    Dim objFcDMPhong As BO.QLP_DM_PHONGFacade
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
    Private objFCBaocaoKhachhang As BO.clsB_BaoCao_Khachhang
    Dim pc As New Public_Class
    Dim uId_QT_Dieutri As String = ""
    Dim iOption As String = ""
    Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        iOption = Request.QueryString("Phong")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadGridDmDichvu()
        If Not IsPostBack Then
            objEnDMPhong = New CM.QLP_DM_PHONGEntity
            objFcDMPhong = New BO.QLP_DM_PHONGFacade
            Dat_Ngaychuyen.Date = DateTime.Now.ToString
            objEnDMPhong = objFcDMPhong.SelectByID(Session("uId_Phongban_NV_Current"))
            If Session("uId_Khachhang") <> Nothing Then
                LoadThongTinKhachHang(objEnDMPhong.nv_Tenphong_vn)
            End If
            ltrTitleHeader.Text = "<p class='p_header'><i class='fa fa-newspaper-o fa-fw fa-1x'></i>BỆNH NHÂN CHỜ ĐIỀU TRỊ- TẠI " & objEnDMPhong.nv_Tenphong_vn.ToUpper & "</p>"
            'End If
            If Session("uId_Phieudichvu") <> Nothing Then
                LoadThongTinPhieuDichVu(Session("uId_Phieudichvu"))
                dgvPhieuchitiet.DataBind()
            Else
                CreateSoPhieu()
                deNgaylap.Date = DateTime.Now.ToString
            End If
            If iOption = "Letan" Or objEnDMPhong.nv_Tenphong_en = "LETAN" Then
                btnRefresh.Text = "Làm mới"
                tabDSBenhnhan.TabPages(1).Visible = False
                tabDSBenhnhan.TabPages(0).Name = "Chờ Chuyển"
            Else
                btnRefresh.Text = "Điều trị"
                btnRefresh.Visible = False
                tabDSBenhnhan.TabPages(0).Name = "Chờ điều trị"
            End If
            Loadcombobox()
            LoadHistory()
            'LoadKetluan()
            LoadDSPhong()
        End If
        LoadHistory()
        LoadDSKhachHangTheoPhong()
        LoadDSBenhNhanDaDieuTri()
    End Sub
#Region "Load thong tin"
    Private Sub LoadGridDmDichvu()
        Dim dt As New DataTable
        objFC_dmdichvu = New BO.TNTP_DM_DICHVUFacade
        objFcDMPhong = New BO.QLP_DM_PHONGFacade
        Dim tenphong As String = objFcDMPhong.SelectByID(Session("uId_Phongban_NV_Current")).nv_Tenphong_en
        If tenphong = "LETAN" Then
            dt = objFC_dmdichvu.SelectAllTable("159483b3-cfea-4211-9265-d82699449540", oLibP.NullProString(Session("uId_Cuahang")))
        Else
            dt = objFC_dmdichvu.SelectAllTable("e2ca8299-6653-46fd-8a66-7484ec5c94b9", oLibP.NullProString(Session("uId_Cuahang")))
        End If
        If Not (dt Is Nothing) Then
            If dt.Rows.Count = 0 Then
                dt.Rows.Add(dt.NewRow())
            End If
        End If
        Dim col As New DataColumn
        dgvDevexpress.DataSource = dt
        dgvDevexpress.DataBind()
        dt = Nothing
    End Sub
    Private Sub LoadThongTinKhachHang(nv_TenPhong As String)
        objFcDMKhachhang = New BO.CRM_DM_KhachhangFacade
        objEnDMKhachhang = New CM.CRM_DM_KhachhangEntity
        objEnDMKhachhang = objFcDMKhachhang.SelectByID(Session("uId_Khachhang"))
        txtHoten.Text = objEnDMKhachhang.nv_Hoten_vn
        'ltrTitleHeader.Text = "<p class='p_header'><i class='fa fa-newspaper-o fa-fw fa-1x'></i>THÊM PHIẾU DỊCH VỤ CHO BỆNH NHÂN <span style='color:red;text-transform:uppercase;font-size:16px'>" & objEnDMKhachhang.nv_Hoten_vn & "</span> - TẠI " & nv_TenPhong.ToUpper & "</p>"
    End Sub
    Private Sub LoadThongTinPhieuDichVu(uId_Phieudichvu As String)
        objFCPhieuDV = New BO.TNTP_PHIEUDICHVUFacade
        objEnPhieuDV = New CM.TNTP_PHIEUDICHVUEntity
        objEnPhieuDV = objFCPhieuDV.SelectByID(uId_Phieudichvu)
        txtSoPhieu.Text = objEnPhieuDV.v_Sophieu
        deNgaylap.Date = objEnPhieuDV.d_Ngay
        txtSoPhieu.ReadOnly = True
        deNgaylap.ReadOnly = True
    End Sub
    Private Sub LoadDSKhachHangTheoPhong()
        Dim dt As New DataTable
        If Session("uId_Phongban_NV_Current") <> Nothing Then
            objFCBaocaoKhachhang = New BO.clsB_BaoCao_Khachhang
            dt = objFCBaocaoKhachhang.SelectThongkeKH_ByTimeAndByPhong(DateAndTime.DateAdd(DateInterval.Day, -365, DateAndTime.Now), DateAndTime.Now, Session("uId_Cuahang").ToString, Session("uId_Phongban_NV_Current").ToString(), "2", iOption)
            If dt.Rows.Count > 0 Then
                dgvDanhsachcho.DataSource = dt
                dgvDanhsachcho.DataBind()
                dt = Nothing
            Else
                dgvDanhsachcho.DataSource = Nothing
                dgvDanhsachcho.DataBind()
            End If
            objFCBaocaoKhachhang = Nothing
        End If
    End Sub
    Private Sub LoadDSBenhNhanDaDieuTri()
        Dim objFcDieutri As New BO.TNTP_QT_DieutriFacade
        Dim dt As DataTable
        dt = objFcDieutri.SelectListDaDieuTriByNhanvien(Session("uId_Nhanvien_Dangnhap"))
        If dt.Rows.Count > 0 Then
            GrvDadieutri.DataSource = dt
            GrvDadieutri.DataBind()
        End If
    End Sub
    Private Sub LoadPhieuDVChitiet()
        objFCChitietDV = New BO.TNTP_PHIEUDICHVU_CHITIETFacade
        Dim dt As DataTable = objFCChitietDV.SelectByID(Session("uId_Phieudichvu"))
        If dt.Rows.Count > 0 Then
            dgvPhieuchitiet.DataSource = dt
        End If
    End Sub
    Private Sub LoadDSPhong()
        LoadDMTrangThai()
        Dim dt As New DataTable
        If Session("uId_Cuahang") <> Nothing Then
            Dim giatriphong As String
            Dim giatritrangthai As String
            objFcDMPhong = New BO.QLP_DM_PHONGFacade
            dt = objFcDMPhong.SelectAllTable(Session("uId_Cuahang").ToString)
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    Dim item As New ListEditItem
                    item.Value = row("uId_Phong").ToString()
                    item.Text = row("nv_Tenphong_vn")
                    ddlDMPhong.Items.Add(item)
                Next
                If Session("uId_Phieudichvu") <> Nothing Then
                    objFCChitietDV = New BO.TNTP_PHIEUDICHVU_CHITIETFacade
                    Dim dt2 As DataTable
                    dt2 = objFCChitietDV.SelectByID(Session("uId_Phieudichvu"))
                    Dim objFcNhomdichvu As New BO.TNTP_DM_NHOMDICHVUFacade
                    Dim objFcDichvu As New BO.TNTP_DM_DICHVUFacade
                    Dim str As String
                    For Each row As DataRow In dt2.Rows
                        str = objFcNhomdichvu.SelectByID(objFcDichvu.SelectByID(row("uId_Dichvu")).uId_Nhomdichvu).nv_TennhomDichvu_en
                        If str = "KHAM" And objFcDMPhong.SelectByID(Session("uId_Phongban_NV_Current")).nv_Tenphong_en = "PHONGKHAM" Then
                            giatriphong = "4586b88c-794b-4277-a661-101b5a00ee43"
                            giatritrangthai = "633e14b6-e05e-4d13-8ef9-942c90b3c8a9"
                        Else
                            giatriphong = "98cab2b9-ff4c-4d25-ba8c-202aa0b854c2"
                            giatritrangthai = "c78d28b5-b837-48ea-b1f9-5c994de6b840"
                        End If
                    Next
                Else
                    giatriphong = "98cab2b9-ff4c-4d25-ba8c-202aa0b854c2"
                    giatritrangthai = "c78d28b5-b837-48ea-b1f9-5c994de6b840"
                End If
                ddlDMPhong.Value = giatriphong
                ddlTrangthai.Value = giatritrangthai
            Else

            End If
        End If
    End Sub
    Private Sub LoadDMTrangThai()
        Dim dt As New DataTable
        objFcDMTrangthai = New BO.CRM_DM_TRANGTHAIFacade
        dt = objFcDMTrangthai.SelectByIType("3")
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                Dim item As New ListEditItem
                item.Value = row("uId_Trangthai").ToString()
                item.Text = row("nv_Tentrangthai_vn")
                ddlTrangthai.Items.Add(item)
            Next
            ddlTrangthai.SelectedIndex = 0
        End If
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
#End Region
#Region "BUttoN"
    Protected Sub btnChuyen_Click(sender As Object, e As EventArgs)
        Dim trangthaiKHentity As New CM.PQP_TRANGTHAIKHCHOXULYEntity
        objEnPhieuDV = New CM.TNTP_PHIEUDICHVUEntity
        objFCPhieuDV = New BO.TNTP_PHIEUDICHVUFacade
        objFcDMPhong = New BO.QLP_DM_PHONGFacade
        objFcChoXyLy = New BO.PQP_TRANGTHAIKHCHOXULYFacade
        objFCNhatKy = New BO.NHATKYSUDUNGFacade
        trangthaiKHentity.uId_Trangthai = ddlTrangthai.Value
        trangthaiKHentity.uId_Phong = ddlDMPhong.Value
        trangthaiKHentity.d_Ngay = Dat_Ngaychuyen.Value
        trangthaiKHentity.uId_Phongchuyen = Session("uId_Phongban_NV_Current").ToString
        If Session("uId_Khachhang") <> Nothing Then
            Dim trangthaiKHUpdate As New CM.PQP_TRANGTHAIKHCHOXULYEntity
            If Session("uId_TrangthaiKH") <> Nothing Then
                trangthaiKHUpdate = objFcChoXyLy.SelectByID(Session("uId_TrangthaiKH"))
                If trangthaiKHUpdate.uId_Trangthai <> "d55b80ca-1001-49aa-80ae-9bb650c40a17" Then
                    trangthaiKHUpdate.uId_Trangthai = "fb83dd87-caf8-427d-81fa-c683e8fec955"
                    objFcChoXyLy.Update(trangthaiKHUpdate)
                End If
            End If
            If Session("uId_Phieudichvu") <> Nothing Then
                trangthaiKHentity.uId_Phieudichvu = Session("uId_Phieudichvu")
                trangthaiKHentity.nv_Ghichu = txtNote.Text
                Try
                    If objFcChoXyLy.Insert(trangthaiKHentity) = True Then
                        If Session("uId_Phongban_NV_Current") = "67be576f-54fe-43a3-bd33-27f42e88b3fe" Then
                            objEnPhieuDV = objFCPhieuDV.SelectByID(Session("uId_Phieudichvu1"))
                            objEnPhieuDV.b_IsKhoa = 1
                            objFCPhieuDV.Update(objEnPhieuDV)
                        End If
                    End If
                    Dim roomname As String = ""
                    If Session("uId_Phongban_NV_Current") <> Nothing Then
                        roomname = objFcDMPhong.SelectByID(Session("uId_Phongban_NV_Current")).nv_Tenphong_vn
                    End If
                    objFCNhatKy.Write(Session("sTendangnhap"), "", "Chuyển KH " & txtHoten.Text & " (" & txtSoPhieu.Text & ") từ " & roomname & " đến " & ddlDMPhong.SelectedItem.Text & ". Trạng thái " & ddlTrangthai.SelectedItem.Text)
                    Session.Remove("uId_Phieudichvu")
                    Session.Remove("uId_Khachhang")
                    Session.Remove("uId_TrangthaiKH")
                    Session.Remove("uId_Phieudichvu1")
                    'Response.Redirect(Request.RawUrl())
                    'ShowMessage(Me, "Chuyển thành công")
                    If objFcDMPhong.SelectByID(Session("uId_Phongban_NV_Current")).nv_Tenphong_en = "PHONGKHAM" Then
                        If Session("uId_Phieudichvu1") <> Nothing Or Session("uId_Phieudichvu1") <> "" Then

                        End If
                    End If
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "CallConfirmBox", "CallConfirmBox();", True)
                    LoadDSKhachHangTheoPhong()
                    txtHoten.Text = ""
                    txtSoPhieu.Text = ""
                Catch ex As Exception
                    'ShowMessage(Me, "Lỗi trong quá trình chuyển")
                End Try
            End If
        End If
    End Sub
    'Protected Sub btnRefresh_Click(sender As Object, e As EventArgs)
    '    Session.Remove("uId_Phieudichvu")
    '    Session.Remove("uId_Khachhang")
    '    Session.Remove("uId_TrangthaiKH")
    '    Response.Redirect(Request.RawUrl())
    'End Sub
    Protected Sub btnLidoxoa_Click(sender As Object, e As EventArgs)
        If txtLidoxoa.Text.Trim <> "" And Session("uId_Phieuchitiet") <> Nothing And Session("uId_Dichvu_huy") <> Nothing And Session("uId_Phieudichvu") <> Nothing Then
            objFCChitietDV = New BO.TNTP_PHIEUDICHVU_CHITIETFacade
            objFCChitietDV.DeleteByID(Session("uId_Phieuchitiet").ToString)
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
            objFCChitietDV = Nothing
            objFCHuyDV = Nothing
            Session("uId_Phieuchitiet") = Nothing
            Session("uId_Dichvu_huy") = Nothing
            Session("nv_Tendichvu_huy") = Nothing
            txtLidoxoa.Text = ""
            Response.Redirect("~/OrangeVersion/Customer/BillingServices.aspx")
        End If
    End Sub
#End Region
#Region "Grid View"
    Protected Sub dgvPhieuchitiet_DataBinding(sender As Object, e As EventArgs)
        LoadPhieuDVChitiet()
    End Sub
    Protected Sub dgvDanhsachcho_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        Dim id = e.Keys(2).ToString()
        objFcChoXyLy = New BO.PQP_TRANGTHAIKHCHOXULYFacade
        Try
            objFcChoXyLy.DeleteByID(id)
            dgvDanhsachcho.CancelEdit()
            e.Cancel = True
            LoadDSKhachHangTheoPhong()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub dgvPhieuchitiet_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
        objFCPhanQuyen = New BO.QT_PHANQUYENFacade
        objFCPhieuDV = New BO.TNTP_PHIEUDICHVUFacade
        objFCChitietDV = New BO.TNTP_PHIEUDICHVU_CHITIETFacade
        objEnChitietDV = New CM.TNTP_PHIEUDICHVU_CHITIETEntity
        CType(sender, ASPxGridView).JSProperties("cpIsUpdated") = "update"
        Dim checkKhoaPhieu As Boolean = False
        checkKhoaPhieu = objFCPhieuDV.SelectByID(Session("uId_Phieudichvu")).b_IsKhoa
        Dim dt As New DataTable
        dt = objFCPhanQuyen.SelectAllTable(Session("uId_Nhanvien_Dangnhap"), "67e68aea-9dbd-43d5-b316-e5ad9c0e6fd3")
        If checkKhoaPhieu = False Or dt.Rows.Count > 0 Then
            Dim uId_Phieudichvu_Chitiet As String
            uId_Phieudichvu_Chitiet = e.Keys(0).ToString
            'Dim f_SoLan_interface As Integer = CInt(Val(e.NewValues()))
            Dim i_SoLan_Dieutri As Integer = CInt(objFCChitietDV.SelectByIDChitiet(uId_Phieudichvu_Chitiet)(0)("i_SoLan_Dieutri"))
            'Dim f_SoLuong_interface As Integer = CInt(Val(e.NewValues(4)))
            With objEnChitietDV
                .uId_Phieudichvu_Chitiet = uId_Phieudichvu_Chitiet
                'If f_SoLan_interface > (f_SoLuong_interface * i_SoLan_Dieutri) Then
                '    .f_Solan = f_SoLan_interface
                'Else
                '    .f_Solan = f_SoLuong_interface * i_SoLan_Dieutri
                'End If
                .f_Soluong = CInt(Val(e.NewValues("f_Soluong")))
                .f_Solan = CInt(Val(e.NewValues("f_Soluong"))) * i_SoLan_Dieutri
                '.f_Dongia = CInt(Val(e.NewValues(3)))
                .uId_Nhanvien = Session("uId_Nhanvien_Dangnhap")
                'Dim strGiamgia As String = e.NewValues(5).ToString
                'Dim strGiamgia As String = DirectCast(dgvPhieuchitiet.FindEditRowCellTemplateControl(TryCast(dgvPhieuchitiet.Columns("f_Giamgia"), GridViewDataColumn), "txtGiamgia"), TextBox).Text
                'If InStr(strGiamgia, "%") > 0 Then
                '    .f_Giamgia = .f_Soluong * .f_Dongia * CInt(strGiamgia.Replace("%", "")) / 100
                'Else : .f_Giamgia = CInt(Val(strGiamgia))
                'End If
                .b_BaoHanh = False
            End With

            objFCChitietDV.UpdateByPhongkham(objEnChitietDV)
        Else
            CType(sender, ASPxGridView).JSProperties("cpIsLocked") = "true"
        End If
        dgvPhieuchitiet.CancelEdit()
        e.Cancel = True
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
            Try
                If objEnPhieuDV.f_Tongtienthuc = "" Then
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
    End Sub
#End Region

    Protected Sub dgvDevexpress_DataBound(sender As Object, e As EventArgs)
        objFcDMPhong = New BO.QLP_DM_PHONGFacade
        Dim tenphong As String = objFcDMPhong.SelectByID(Session("uId_Phongban_NV_Current")).nv_Tenphong_en.ToString
        If tenphong <> "KETOAN" Or tenphong <> "LETAN" Then
            'Me.dgvDevexpress.Columns("f_Gia").Visible = False
            'Me.dgvDevexpress.Columns("f_phantramGiamgia").Visible = False
            'Me.dgvDevexpress.Columns("chon").Visible = False
        End If
    End Sub

    Protected Sub dgvPhieuchitiet_DataBound(sender As Object, e As EventArgs)
        objFcDMPhong = New BO.QLP_DM_PHONGFacade
        Dim tenphong As String = objFcDMPhong.SelectByID(Session("uId_Phongban_NV_Current")).nv_Tenphong_en.ToString
        If tenphong <> "LETAN" Then
            Me.dgvPhieuchitiet.Columns("f_Dongia").Visible = False
            Me.dgvPhieuchitiet.Columns("f_Giamgia").Visible = False
            Me.dgvPhieuchitiet.Columns("f_Tongtien").Visible = False
        End If
    End Sub

    Private Sub Loadcombobox()
        Dim objFcNguon As New BO.CRM_DM_NGUONFacade
        cboAn.DataSource = objFcNguon.SelectAllTable_ByvType("AN")
        cboAn.DataBind()
        cboDa.DataSource = objFcNguon.SelectAllTable_ByvType("DA")
        cboDa.DataBind()
        cboDaitien.DataSource = objFcNguon.SelectAllTable_ByvType("DAITIEN")
        cboDaitien.DataBind()
        cboMohoi.DataSource = objFcNguon.SelectAllTable_ByvType("MOHOI")
        cboMohoi.DataBind()
        cboNgu.DataSource = objFcNguon.SelectAllTable_ByvType_OrDerBy("NGU")
        cboNgu.DataBind()
        cboTheluc.DataSource = objFcNguon.SelectAllTable_ByvType("THELUC")
        cboTheluc.DataBind()
        cboThetrang.DataSource = objFcNguon.SelectAllTable_ByvType("THETRANG")
        cboThetrang.DataBind()
        cboTinhthan.DataSource = objFcNguon.SelectAllTable_ByvType_OrDerBy("TINHTHAN")
        cboTinhthan.DataBind()
        cboTieutien.DataSource = objFcNguon.SelectAllTable_ByvType("TIEUTIEN")
        cboTieutien.DataBind()
        cb_Tinhtrangbenh.DataSource = objFcNguon.SelectAllTable_ByvType("TINHTRANG")
        cb_Tinhtrangbenh.DataBind()
        'cboKetluan.DataSource = objFcNguon.SelectAllTable_ByvType("BENH")
        'cboKetluan.DataBind()
    End Sub

    Protected Sub btnLuu_Click(sender As Object, e As EventArgs)
        Dim objFcDieutri As New BO.TNTP_QT_DieutriFacade
        Dim objEnDieutri As New CM.TNTP_QT_DieutriEntity
        Dim tinhtrangcothe As String
        Dim bieuhienchungbenh As String
        Dim sinhhoamau As String
        Dim ppdieutri As String
        tinhtrangcothe = txtMach.Text & "$" & txtHuyetap.Text & "$" & txtHuyetapGio.Text & "$" & txtLuoichat.Text & "$" & txtLuoireu.Text &
            "$" & cboDa.Text & "$" & cboMohoi.Text & "$" & cboAn.Text & "$" & cboNgu.Text
        tinhtrangcothe += "$" & txtLandaitien.Text & "/" & txtDaitienngay.Text & "$" & cboDaitien.Text
        tinhtrangcothe += "$" & txtlantieutien.Text & "/" & txttieutienngay.Text & "$" & cboTieutien.Text
        tinhtrangcothe += "$" & txtKg.Text & "/" & txtCm.Text & "$" & cboThetrang.Text
        tinhtrangcothe += "$" & cboTheluc.Text & "$" & cboTinhthan.Text & "$" & cboTheluc.Text
        sinhhoamau = txtSHMGOT.Text & "$" & txtSMHGPT.Text & "$" & txtSHMGGT.Text & "$" & txtBiltp.Text & "$" & txtBiltt.Text &
            "$" & txtChol.Text & "$" & txtTriG.Text & "$" & txtdhl.Text & "$" & txtLdl.Text & "$" & txtGluo.Text & "$" & txtAuric.Text & "$" & txtCreatinin.Text & "$" & txtUre.Text & "$" & memoBoxung.Text & "$" & memoChandoantuanh.Text
        bieuhienchungbenh = memoTrieuchung.Text & "$" & memoYeutotangbenh.Text & "$" & memoCodia.Text & "$" & memoBenhsu.Text &
        "$" & memodungtanduoc.Text & "$" & memoDungdongduoc.Text & "$" & memoGhichu.Text
        ppdieutri = memoPPDieutri.Text
        With objEnDieutri
            .uId_Nhanvien = Session("uId_Nhanvien_Dangnhap")
            .uId_Phieudichvu_Chitiet = Session("uId_Phieudichvu_Chitiet")
            .d_Ngaydieutri = Date.Now
            .nv_Bieuhienbenh = bieuhienchungbenh
            .nv_Sinhhoamau = sinhhoamau
            .nv_Tinhtrangcothe = tinhtrangcothe
            .nv_PhuongphapDT = ppdieutri
            .nv_Ghichu = cboKetluan.Text
            .uId_Trangthai = "fb83dd87-caf8-427d-81fa-c683e8fec955"
            .nv_Tinhtrangbenh = cb_Tinhtrangbenh.Value.ToString
        End With
        Dim dt As DataTable
        dt = objFcDieutri.SelectInfoDieutri(Session("uId_Phieudichvu_Chitiet"), "INFO")
        If dt.Rows.Count = 1 Then
            uId_QT_Dieutri = dt.Rows(0)("uId_QT_Dieutri").ToString
        End If
        'objFcDieutri.UpdateMabenh(Session("uId_Phieudichvu_Chitiet"), cboKetluan.Value)
        If uId_QT_Dieutri <> "" Then
            objEnDieutri.uId_QT_Dieutri = uId_QT_Dieutri
            objFcDieutri.Update(objEnDieutri)
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "CallConfirm", "CallConfirm();", True)
        Else
            uId_QT_Dieutri = objFcDieutri.Insert(objEnDieutri)
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "CallConfirm", "CallConfirm();", True)
        End If
        LoadHistory()
    End Sub

    Private Sub LoadHistory()
        Dim objFcDieutri As New BO.TNTP_QT_DieutriFacade
        Dim dt As DataTable
        dt = objFcDieutri.SelectHistoryByKHAndNV(Session("uId_Khachhang"), Session("uId_Nhanvien_Dangnhap"))
        If dt.Rows.Count > 0 Then
            GrvHistory.DataSource = dt
            GrvHistory.DataBind()
        End If
    End Sub


    Protected Sub GrvHistoryChitiet_BeforePerformDataSelect(sender As Object, e As EventArgs)
        Dim detailGridView As ASPxGridView = DirectCast(sender, ASPxGridView)
        Dim uId_Phieudichvu_chitiet As String
        uId_Phieudichvu_chitiet = detailGridView.GetMasterRowKeyValue().ToString
        Dim dt As DataTable
        Dim objFcDieutri As New BO.TNTP_QT_DieutriFacade
        dt = objFcDieutri.SelectInfoDieutri(uId_Phieudichvu_chitiet, "")
        If dt.Rows.Count > 0 Then
            detailGridView.DataSource = dt
        End If
    End Sub

    Private Sub LoadKetluan()
        Dim objFcNguon As New BO.CRM_DM_NGUONFacade
        Dim dt As DataTable
        dt = objFcNguon.SelectAllTable_ByvType("BENH")
        If dt.Rows.Count > 0 Then
            'cboKetluan.DataSource = dt
            'cboKetluan.DataBind()
        End If
    End Sub

    Protected Sub grvDonthuoc_BeforePerformDataSelect(sender As Object, e As EventArgs)
        Dim detailGridView As ASPxGridView = DirectCast(sender, ASPxGridView)
        Dim uId_Phieudichvu_chitiet As String
        uId_Phieudichvu_chitiet = detailGridView.GetMasterRowKeyValue().ToString
        Dim objFcPhieuxuat As New BO.QLMH_PHIEUXUATFacade
        Dim dt As DataTable
        dt = objFcPhieuxuat.Timkiem(uId_Phieudichvu_chitiet, Date.Now, Date.Now, "Donthuoc")
        If dt.Rows.Count > 0 Then
            detailGridView.DataSource = dt
        End If
    End Sub
    Protected Sub GrvHistory_HtmlRowPrepared(sender As Object, e As ASPxGridViewTableRowEventArgs)
        If e.RowType = GridViewRowType.Data Then
            Dim Trangthai As String = e.GetValue("b_Tinhtrangbenh")
            If Trangthai = "DO" Then
                e.Row.BackColor = System.Drawing.Color.Red
            ElseIf Trangthai = "CAM" Then
                e.Row.BackColor = System.Drawing.Color.Orange
            ElseIf Trangthai = "TIM" Then
                e.Row.BackColor = System.Drawing.Color.Violet
            ElseIf Trangthai = "TRANG" Then
                e.Row.BackColor = System.Drawing.Color.White
            Else
                e.Row.BackColor = System.Drawing.Color.ForestGreen
            End If

        End If
    End Sub
End Class