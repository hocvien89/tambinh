Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView

Public Class WareHousing
    Inherits System.Web.UI.Page
    Dim objFcDMKho As BO.QLMH_DM_KHOFacade
    Dim objFcDMNCC As BO.QLMH_DM_NHACUNGCAPFacade
    Dim objFcDmMathang As BO.QLMH_DM_MATHANGFacade
    Dim objFcPhieunhap As BO.clsB_Phieunhap
    Dim objEnPhieunhap As CM.cls_Phieunhap
    Dim objFCQuydoidv As BO.DMQuyDoiDonViFacade
    Private pc As New Public_Class
    Private objFCNhatKy As BO.NHATKYSUDUNGFacade
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            deNgaynhap.Date = DateTime.Now
            deTungay.Date = DateTime.Now
            deDenNgay.Date = DateTime.Now
            LoadDropDownlist()
            Session("uId_Phieuxuat") = Nothing
        End If
        If Session("uId_Phieunhap") <> Nothing Or Session("uId_Phieunhap") <> "" Then
            LoadDMMathang()
            Loadphieuchitiet()
            'LoadThongtinphieunhap()
        Else
            txtMaphieu.Text = pc.ReturnAutoString("PN")
        End If
        LoadDSPhieunhap()

    End Sub
#Region "Load Thong tin"
    Private Sub LoadDropDownlist()
        objFcDMKho = New BO.QLMH_DM_KHOFacade
        objFcDMNCC = New BO.QLMH_DM_NHACUNGCAPFacade
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
        dt = objFcDMNCC.SelectAllTable()
        ddlNhacungcap.DataSource = dt
        ddlNhacungcap.ValueField = "uId_Nhacungcap"
        ddlNhacungcap.TextField = "nv_Tennhacungcap_vn"
        ddlNhacungcap.DataBind()
        ddlNhacungcap.SelectedIndex = 0
    End Sub

    Private Sub LoadDMMathang()
        objFcDmMathang = New BO.QLMH_DM_MATHANGFacade
        objFcPhieunhap = New BO.clsB_Phieunhap
        objEnPhieunhap = New CM.cls_Phieunhap
        If Session("uId_Phieunhap") <> Nothing Then
            objEnPhieunhap = objFcPhieunhap.SelectByID(BO.Util.IsString(Session("uId_Phieunhap")))
            Dim dt As DataTable
            dt = objFcDmMathang.Bang_Tonghop_Ton(DateTime.Now, objEnPhieunhap.d_Ngaynhap, objEnPhieunhap.uId_Kho.ToString, Session("uId_Cuahang"))
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
        objFcPhieunhap = New BO.clsB_Phieunhap
        Dim dt As DataTable
        dt = objFcPhieunhap.SelectByID_PHIEUNHAP_CHITIET(Session("uId_Phieunhap"))
        If dt.Rows.Count > 0 Then
            dgvDevexpress.DataSource = dt
            dgvDevexpress.DataBind()
        Else
            dgvDevexpress.DataSource = Nothing
            dgvDevexpress.DataBind()
        End If
    End Sub

    '==Load Grid phieu nhap
    Private Sub LoadDSPhieunhap()
        objFcPhieunhap = New BO.clsB_Phieunhap
        Dim dt As DataTable
        dt = objFcPhieunhap.Timkiem(ddlDsKho.SelectedItem.Value.ToString, BO.Util.ConvertDateTime(deTungay.Text), BO.Util.ConvertDateTime(deDenNgay.Text))
        dgvDanhsachphieu.DataSource = dt
        dgvDanhsachphieu.DataBind()
    End Sub

    '==Load thong tin phieu nhap
    Private Sub LoadThongtinphieunhap()
        objEnPhieunhap = New CM.cls_Phieunhap
        objFcPhieunhap = New BO.clsB_Phieunhap
        objEnPhieunhap = objFcPhieunhap.SelectByID(Session("uId_Phieunhap"))
        ddlDMKho.Value = objEnPhieunhap.uId_Kho
        txtMaphieu.Text = objEnPhieunhap.v_Maphieunhap
        deNgaynhap.Date = objEnPhieunhap.d_Ngaynhap
        ddlNhacungcap.Value = objEnPhieunhap.uId_Nhacungcap
        txtGhichu.Text = objEnPhieunhap.nv_Noidung_vn
        lblTongtien.Text = String.Format("{0:#,##}", Val(objEnPhieunhap.f_Tongtien))
        If objEnPhieunhap.f_Tongthanhtoan = 0 Then
            txtSotientra.Text = "0"
        Else
            txtSotientra.Text = String.Format("{0:#,##}", Val(objEnPhieunhap.f_Tongthanhtoan))
        End If
        If objEnPhieunhap.f_Giamgia = 0 Then
            txtGiamgiaPhieu.Text = "0"
        Else
            txtGiamgiaPhieu.Text = String.Format("{0:#,##}", Val(objEnPhieunhap.f_Giamgia))
        End If
        If Val(objEnPhieunhap.f_Tongtien) - objEnPhieunhap.f_Giamgia - objEnPhieunhap.f_Tongthanhtoan < 0 Then
            lblTinhtien.Text = "Tiền thừa"
        Else
            lblTinhtien.Text = "Tiền thiếu"
        End If
        lblConlai.Text = String.Format("{0:#,##}", Val(objEnPhieunhap.f_Tongtien) - objEnPhieunhap.f_Giamgia)
        lblTienthieu.Text = String.Format("{0:#,##}", Val(objEnPhieunhap.f_Tongtien) - objEnPhieunhap.f_Giamgia - objEnPhieunhap.f_Tongthanhtoan)
    End Sub
#End Region
#Region "Button"
    'insert vao bang phieu nhap mot phieu moi
    Protected Sub btnLuu_Click(sender As Object, e As EventArgs)
        objEnPhieunhap = New CM.cls_Phieunhap
        objFcPhieunhap = New BO.clsB_Phieunhap
        objFCNhatKy = New BO.NHATKYSUDUNGFacade
        Dim sUid_Phieunhap As String = ""
        objEnPhieunhap.v_Maphieunhap = txtMaphieu.Text
        objEnPhieunhap.d_Ngaynhap = BO.Util.ConvertDateTime(deNgaynhap.Text)
        objEnPhieunhap.nv_Noidung_vn = txtGhichu.Text
        objEnPhieunhap.uId_Kho = ddlDMKho.Value.ToString
        objEnPhieunhap.uId_Nhacungcap = ddlNhacungcap.Value.ToString
        objEnPhieunhap.uId_Nhanvien = Session("uId_Nhanvien_Dangnhap")
        objEnPhieunhap.f_Giamgia = 0
        objEnPhieunhap.f_Tongthanhtoan = 0
        objEnPhieunhap.f_Tongtien = 0
        If Session("uId_Phieunhap") = Nothing Then
            sUid_Phieunhap = objFcPhieunhap.Insert(objEnPhieunhap)
            ShowMessage(Me, "Thêm mới thành công. Vui lòng chọn mặt hàng nhập vào phiếu")
            objFCNhatKy.Write(Session("sTendangnhap"), System.Environment.MachineName, "Thêm mới phiếu nhập mã " & txtMaphieu.Text)
            Session("uId_Phieunhap") = sUid_Phieunhap
            ddlMathang.Focus()
        Else
            objEnPhieunhap.uId_Phieunhap = Session("uId_Phieunhap").ToString
            objFcPhieunhap.Update(objEnPhieunhap)
            objFCNhatKy.Write(Session("sTendangnhap"), System.Environment.MachineName, "Sửa thông tin phiếu nhập mã " & txtMaphieu.Text)
            ShowMessage(Me, "Cập nhật thành công!")
        End If
        If Session("uId_Phieunhap") <> Nothing Then
            LoadDMMathang()
        End If
    End Sub

    Protected Sub btnClear_Click(sender As Object, e As EventArgs)
        txtMaphieu.Text = pc.ReturnAutoString("PN")
        txtGhichu.Text = ""
        Session("uId_Phieunhap") = Nothing
        LoadDMMathang()
        Loadphieuchitiet()
        txtSoluong.Text = "1"
        txtGiamgiaPhieu.Text = ""
        txtSotientra.Text = ""
        lblTongtien.Text = ""
        lblTienthieu.Text = ""
        lblConlai.Text = ""
        btnThanhtoan.Enabled = True
    End Sub

    Protected Sub btnFilter_Click(sender As Object, e As EventArgs)
        LoadDSPhieunhap()
    End Sub

    Protected Sub btnThanhtoan_Click(sender As Object, e As EventArgs)
        objEnPhieunhap = New CM.cls_Phieunhap
        objFcPhieunhap = New BO.clsB_Phieunhap
        With objEnPhieunhap
            .uId_Phieunhap = Session("uId_Phieunhap")
        End With
    End Sub
#End Region
#Region "Dropdown Event"
    Protected Sub ddlDonvi_Callback(sender As Object, e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase)
        LoadDonViTheoMa()
    End Sub

    Protected Sub ddlMathang_Callback(sender As Object, e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase)
        LoadDMMathang()
    End Sub
#End Region
#Region "Grid event"
    Protected Sub dgvDevexpress_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        objFcPhieunhap = New BO.clsB_Phieunhap
        Dim uId_Phieudichvu_chitiet As String
        uId_Phieudichvu_chitiet = e.Keys(0).ToString
        Try
            objFcPhieunhap.DeleteByID_PHIEUNHAP_CHITIET(uId_Phieudichvu_chitiet)
            e.Cancel = True
            Loadphieuchitiet()
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub dgvDanhsachphieu_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        objFcPhieunhap = New BO.clsB_Phieunhap
        objFCNhatKy = New BO.NHATKYSUDUNGFacade
        Dim uId_Phieunhap As String
        uId_Phieunhap = e.Keys(0).ToString
        Try
            objFcPhieunhap.DeleteByID(uId_Phieunhap)
            objFCNhatKy.Write(Session("sTendangnhap"), System.Environment.MachineName, "Xóa phiếu nhập mã " & e.Keys(1).ToString)
            e.Cancel = True
            LoadDSPhieunhap()
            Session("uId_Phieunhap") = Nothing
            Session("uId_Khachhang") = Nothing
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub dgvDevexpress_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
        objEnPhieunhap = New CM.cls_Phieunhap
        objFcPhieunhap = New BO.clsB_Phieunhap
        Dim uId_Phieunhap As String
        CType(sender, ASPxGridView).JSProperties("cpIsUpdated") = "update"
        uId_Phieunhap = Session("uId_Phieunhap")
        Try
            If objFcPhieunhap.SelectByID(Session("uId_Phieunhap").ToString).f_Tongthanhtoan = Nothing Then
                With objEnPhieunhap
                    .uId_Phieunhap_Chitiet = e.Keys(0).ToString
                    .f_Soluong = Val(e.NewValues("f_Soluong"))
                    .f_Donggia = Val(e.NewValues("f_Donggia"))
                    .f_Thanhtien = .f_Soluong * .f_Donggia
                    .MaDonVi = e.Keys("MADONVI").ToString
                    .uId_Mathang = e.Keys(1).ToString
                    .d_NgayhethanSD = BO.Util.ConvertDateTime(e.NewValues("d_NgayhethanSD"))
                End With
                objFcPhieunhap.Update_PHIEUNHAP_CHITIET(objEnPhieunhap)
                objFcPhieunhap.UpdateTongtien(Session("uId_Phieunhap"))
                'load lai data page
                dgvDevexpress.CancelEdit()
                e.Cancel = True
                Loadphieuchitiet()
                Response.Redirect("../../../../OrangeVersion/Product/WareHousing.aspx")
                Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "Getdata_Phieu", "<script language ='javascript'>Getdata_Phieu(" + Session("uId_Phieunhap").ToString + ")</script>")
            Else
                Return
            End If
        Catch ex As Exception
        End Try   
    End Sub
    Protected Sub dgvDevexpress_CustomErrorText(sender As Object, e As ASPxGridViewCustomErrorTextEventArgs)
        If TypeOf e.Exception Is NullReferenceException Then
            e.ErrorText = "Phiếu này không thể chỉnh sửa"
        End If
        If TypeOf e.Exception Is Exception Then
            e.ErrorText = "Phiếu này không thể chỉnh sửa"
        End If
    End Sub

    'Protected Sub dgvDevexpress_Unload(sender As Object, e As EventArgs)
    '    LoadThongtinphieunhap()
    'End Sub
#End Region
End Class