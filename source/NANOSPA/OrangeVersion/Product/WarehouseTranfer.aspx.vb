Imports DevExpress.Web.ASPxEditors

Public Class WarehouseTranfer
    Inherits System.Web.UI.Page
    Dim objFcDMKho As BO.QLMH_DM_KHOFacade
    Dim objFcDmMathang As BO.QLMH_DM_MATHANGFacade
    Dim objFcPhieunhap As BO.clsB_Phieunhap
    Dim objEnPhieunhap As CM.cls_Phieunhap
    Dim objFCQuydoidv As BO.DMQuyDoiDonViFacade
    Dim objFcPhieuxuat As BO.QLMH_PHIEUXUATFacade
    Dim objEnPhieuxuat As CM.QLMH_PHIEUXUATEntity
    Dim objFcNhanvien As BO.QT_DM_NHANVIENFacade
    Private objFCNhatKy As BO.NHATKYSUDUNGFacade
    Private pc As New Public_Class
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            deNgaychuyen.Date = DateTime.Now
            deTungay.Date = DateTime.Now
            deDenNgay.Date = DateTime.Now
            LoadDropDownlist()
            txtMaphieu.Text = pc.ReturnAutoString("PCK")
            Session("uId_Phieunhap") = Nothing
            Session("uId_Phieuxuat") = Nothing
        End If
        If Session("uId_Phieuxuat") <> Nothing Or Session("uId_Phieuxuat") <> "" Then
            LoadDMMathang()
            Loadphieuchitiet()
        End If
        LoadDSPhieu()
    End Sub
#Region "Load Thong tin"
    Private Sub LoadDropDownlist()
        objFcDMKho = New BO.QLMH_DM_KHOFacade
        objFcNhanvien = New BO.QT_DM_NHANVIENFacade
        Dim dt As DataTable
        dt = objFcDMKho.SelectAllTable(Session("uId_Cuahang"))
        ddlDMTuKho.DataSource = dt
        ddlDMTuKho.ValueField = "uId_Kho"
        ddlDMTuKho.TextField = "nv_Tenkho_vn"
        ddlDMTuKho.DataBind()
        ddlDMTuKho.SelectedIndex = 0

        ddlDMDenKho.DataSource = dt
        ddlDMDenKho.ValueField = "uId_Kho"
        ddlDMDenKho.TextField = "nv_Tenkho_vn"
        ddlDMDenKho.DataBind()
        ddlDMDenKho.SelectedIndex = 0

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
        dt = objFCQuydoidv.LoadDSDonViTheoVatTu(Session("MaVatTu"))
        If dt.Rows.Count > 0 Then
            ddlDonvi.DataSource = dt
            ddlDonvi.ValueField = "MaDonVi"
            ddlDonvi.TextField = "TenDonVi"
            ddlDonvi.DataBind()
        Else
            ddlDonvi.Items.Clear()
            ddlDonvi.Text = ""
        End If
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

    '==Load danh sach phieu xuat
    Private Sub LoadDSPhieu()
        objFcPhieuxuat = New BO.QLMH_PHIEUXUATFacade
        Dim dt As DataTable
        dt = objFcPhieuxuat.Timkiem(ddlDsKho.SelectedItem.Value.ToString, BO.Util.ConvertDateTime(deTungay.Text), BO.Util.ConvertDateTime(deDenNgay.Text), "PCK")
        dgvDanhsachphieu.DataSource = dt
        dgvDanhsachphieu.DataBind()
    End Sub
#End Region
#Region "Dropdown event"
    Protected Sub ddlDonvi_Callback(sender As Object, e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase)
        LoadDonViTheoMa()
    End Sub
#End Region
#Region "Button"
    Protected Sub btnLuu_Click(sender As Object, e As EventArgs)
        objEnPhieuxuat = New CM.QLMH_PHIEUXUATEntity
        objFcPhieuxuat = New BO.QLMH_PHIEUXUATFacade
        objEnPhieunhap = New CM.cls_Phieunhap
        objFcPhieunhap = New BO.clsB_Phieunhap
        objFCNhatKy = New BO.NHATKYSUDUNGFacade
        Dim check As String = ""
        Dim sUid_Phieuxuat As String = ""
        objEnPhieuxuat.uId_Khachhang = Nothing
        objEnPhieuxuat.uId_Kho = ddlDMTuKho.SelectedItem.Value.ToString
        objEnPhieuxuat.uId_Nhanvien = ddlNhanvien.SelectedItem.Value.ToString
        objEnPhieuxuat.v_Maphieuxuat = txtMaphieu.Text
        objEnPhieuxuat.d_Ngayxuat = BO.Util.ConvertDateTime(deNgaychuyen.Text)
        objEnPhieuxuat.nv_Noidungxuat_vn = "Xuất chuyển đến kho " & ddlDMDenKho.SelectedItem.Text.ToString
        objEnPhieuxuat.f_Giamgia_Tong = 0
        objEnPhieuxuat.f_Tongtienthuc = 0
        If Session("uId_Phieuxuat") = Nothing Then
            sUid_Phieuxuat = objFcPhieuxuat.Insert(objEnPhieuxuat)
            Session("uId_Phieuxuat") = sUid_Phieuxuat
            check = "INS"
        Else
            objEnPhieuxuat.uId_Phieuxuat = Session("uId_Phieuxuat")
            objFcPhieuxuat.Update(objEnPhieuxuat)
            check = "UPD"
        End If

        Dim sUid_Phieunhap As String = ""
        objEnPhieunhap.v_Maphieunhap = txtMaphieu.Text
        objEnPhieunhap.d_Ngaynhap = BO.Util.ConvertDateTime(deNgaychuyen.Text)
        objEnPhieunhap.nv_Noidung_vn = "Nhập từ kho " & ddlDMTuKho.SelectedItem.Text.ToString
        objEnPhieunhap.uId_Kho = ddlDMDenKho.SelectedItem.Value
        objEnPhieunhap.uId_Nhacungcap = Nothing
        objEnPhieunhap.uId_Nhanvien = ddlNhanvien.SelectedItem.Value.ToString
        If Session("uId_Phieunhap") = Nothing Then
            sUid_Phieunhap = objFcPhieunhap.Insert(objEnPhieunhap)
            Session("uId_Phieunhap") = sUid_Phieunhap
            check = "INS"
        Else
            objEnPhieunhap.uId_Phieunhap = Session("uId_Phieunhap")
            objFcPhieunhap.Update(objEnPhieunhap)
            check = "UPD"
        End If
        If check = "INS" Then
            ShowMessage(Me, "Thêm mới thành công")
            objFCNhatKy.Write(Session("sTendangnhap"), System.Environment.MachineName, "Thêm mới phiếu chuyển kho mã " & txtMaphieu.Text)
        End If
        If check = "UPD" Then
            ShowMessage(Me, "Cập nhật thành công")
            objFCNhatKy.Write(Session("sTendangnhap"), System.Environment.MachineName, "Sửa thông tin phiếu chuyển kho mã " & txtMaphieu.Text)
        End If
        If Session("uId_Phieuxuat") <> Nothing Then
            LoadDMMathang()
        End If
    End Sub

    Protected Sub btnClear_Click(sender As Object, e As EventArgs)
        txtMaphieu.Text = pc.ReturnAutoString("PCK")
        Session("uId_Phieunhap") = Nothing
        Session("uId_Phieuxuat") = Nothing
        LoadDMMathang()
        Loadphieuchitiet()
        txtSoluong.Text = "1"
    End Sub

    Protected Sub btnFilter_Click(sender As Object, e As EventArgs)
        LoadDSPhieu()
    End Sub
#End Region
#Region "Grid event"
    Protected Sub dgvDevexpress_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        objFcPhieuxuat = New BO.QLMH_PHIEUXUATFacade
        objEnPhieuxuat = New CM.QLMH_PHIEUXUATEntity
        objFcPhieunhap = New BO.clsB_Phieunhap
        Dim uId_Phieuxuat_chitiet As String
        uId_Phieuxuat_chitiet = e.Keys(0).ToString
        Dim uId_Phieunhap_chitiet As String
        objEnPhieuxuat = objFcPhieuxuat.SelectQLMH_PHIEUXUAT_CHITIET_ByID(uId_Phieuxuat_chitiet)
        uId_Phieunhap_chitiet = objFcPhieunhap.SelectPNChitiet_ByIDSP(txtMaphieu.Text, objEnPhieuxuat.uId_Mathang)

        objFcPhieuxuat.DeleteByID_QLMH_PHIEUXUAT_CHITIET(uId_Phieuxuat_chitiet)
        objFcPhieunhap.DeleteByID_PHIEUNHAP_CHITIET(uId_Phieunhap_chitiet)
        Loadphieuchitiet()
        e.Cancel = True
    End Sub

    Protected Sub dgvDanhsachphieu_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        objFcPhieuxuat = New BO.QLMH_PHIEUXUATFacade
        objFcPhieunhap = New BO.clsB_Phieunhap
        objEnPhieunhap = New CM.cls_Phieunhap
        objFCNhatKy = New BO.NHATKYSUDUNGFacade
        Try
            Dim uId_Phieuxuat As String
            uId_Phieuxuat = e.Keys(0).ToString
            objEnPhieunhap = objFcPhieunhap.SelectByMa(objFcPhieuxuat.SelectByID(uId_Phieuxuat).v_Maphieuxuat)
            objFcPhieuxuat.DeleteByID(uId_Phieuxuat)
            objFcPhieunhap.DeleteByID(objEnPhieunhap.uId_Phieunhap)
            objFCNhatKy.Write(Session("sTendangnhap"), System.Environment.MachineName, "Xóa thông tin phiếu xuất mã " & e.Keys(1).ToString)
            LoadDSPhieu()
            Session("uId_Phieuxuat") = Nothing
            Session("uId_Khachhang") = Nothing
            Session("uId_Phieunhap") = Nothing
        Catch ex As Exception

        End Try
        e.Cancel = True
    End Sub
#End Region
End Class