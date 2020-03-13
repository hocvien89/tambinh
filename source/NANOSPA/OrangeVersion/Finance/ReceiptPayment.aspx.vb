Imports DevExpress.Web.ASPxEditors

Public Class ReceiptPayment
    Inherits System.Web.UI.Page
    Dim objEnPhieuthuhi As CM.QLTC_PhieuthuchiEntity
    Dim objFcPhieuthuchi As BO.QLTC_PhieuthuchiFacade
    Dim objFcDMThuchi As BO.QLTC_DM_THUCHIFacade
    Dim objFcNhanvien As BO.QT_DM_NHANVIENFacade
    Dim objFcKhachhang As BO.CRM_DM_KhachhangFacade
    Dim objEnCongnoTT As CM.QLCN_CONGNO_THANHTOANEntity
    Dim objFcCongnoTT As BO.QLCN_CONGNO_THANHTOANFacade
    Private objFCNhatKy As BO.NHATKYSUDUNGFacade
    Dim objFCPhanQuyen As BO.QT_PHANQUYENFacade
    Dim objFCThamsohethong As BO.clsB_QT_THAMSOHETHONG
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            deTuNgay.Date = DateTime.Now
            deDenNgay.Date = DateTime.Now
            LoadDropDown_Nhanvien()
            LoadDMChi()
            LoadDropDownListDanhmuc()
        End If
        LoadDropDown_Khachhang()
        LoadData()
    End Sub
#Region "Function"
    Private Sub LoadDropDownListDanhmuc()
        objFcDMThuchi = New BO.QLTC_DM_THUCHIFacade
        Dim dt As DataTable
        dt = objFcDMThuchi.SelectLoai(1)
        ddlDanhmuc.DataSource = dt
        ddlDanhmuc.ValueField = "uId_Thuchi"
        ddlDanhmuc.TextField = "nv_Tenthuchi_vn"
        ddlDanhmuc.DataBind()
        ddlDanhmuc.SelectedIndex = 0
    End Sub

    Private Sub LoadDMChi()
        objFcDMThuchi = New BO.QLTC_DM_THUCHIFacade
        Dim dt As DataTable
        dt = objFcDMThuchi.SelectLoai(0)
        cbo_Khoanchi.ValueField = "uId_Thuchi"
        cbo_Khoanchi.TextField = "nv_Tenthuchi_vn"
        cbo_Khoanchi.DataSource = dt
        cbo_Khoanchi.DataBind()
        cbo_Khoanchi.SelectedIndex = 0
    End Sub
    Private Sub LoadDropDown_Nhanvien()
        objFcNhanvien = New BO.QT_DM_NHANVIENFacade
        Dim dt As DataTable
        dt = objFcNhanvien.SelectAllTable(Session("uId_Cuahang"))
        ddlNguoilap.DataSource = dt
        ddlNguoilap.ValueField = "uId_Nhanvien"
        ddlNguoilap.TextField = "nv_Hoten_vn"
        ddlNguoilap.DataBind()
        cbo_Nguoilap.ValueField = "uId_Nhanvien"
        cbo_Nguoilap.TextField = "nv_Hoten_vn"
        cbo_Nguoilap.DataSource = dt
        cbo_Nguoilap.DataBind()
        cbo_Nguoilap.Value = Session("uId_Nhanvien_Dangnhap")
        ddlNguoilap.Value = Session("uId_Nhanvien_Dangnhap")
    End Sub

    Private Sub LoadDropDown_Khachhang()
        objFcKhachhang = New BO.CRM_DM_KhachhangFacade
        objFcNhanvien = New BO.QT_DM_NHANVIENFacade
        Dim dt As DataTable
        If chk_Khachhang.Checked Then
            dt = objFcNhanvien.SelectAllTable_Convert(Session("uId_Cuahang"))
        Else
            dt = objFcKhachhang.SelectAllTable(Session("uId_Cuahang"))
        End If
        ddlNguoinop.DataSource = dt
        ddlNguoinop.ValueField = "uId_Khachhang"
        ddlNguoinop.TextField = "nv_Hoten_vn"
        ddlNguoinop.DataBind()
    End Sub

    Private Sub LoadData()
        objFcPhieuthuchi = New BO.QLTC_PhieuthuchiFacade
        Dim dt As DataTable
        dt = objFcPhieuthuchi.SelectByDMThuchi(ddlLoaiDM.Value.ToString, BO.Util.ConvertDateTime(deTuNgay.Text), BO.Util.ConvertDateTime(deDenNgay.Text))
        dgvDevexpress.DataSource = dt
        dgvDevexpress.DataBind()
    End Sub

#End Region
#Region "Grid"
    Protected Sub dgvDevexpress_DataBinding(sender As Object, e As EventArgs)
        'LoadData()
    End Sub
    Protected Sub dgvDevexpress_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)

        hdfXoa.Value = e.Keys(0).ToString
        hdfMaphieu.Value = e.Keys(1).ToString
    End Sub
#End Region
#Region "Button"
    Protected Sub btnFilter_Click(sender As Object, e As EventArgs)
        LoadData()
    End Sub
    Protected Sub btOK_Click(sender As Object, e As EventArgs)
        objEnPhieuthuhi = New CM.QLTC_PhieuthuchiEntity
        objFcPhieuthuchi = New BO.QLTC_PhieuthuchiFacade
        objEnCongnoTT = New CM.QLCN_CONGNO_THANHTOANEntity
        objFcCongnoTT = New BO.QLCN_CONGNO_THANHTOANFacade
        objFcKhachhang = New BO.CRM_DM_KhachhangFacade
        objFCNhatKy = New BO.NHATKYSUDUNGFacade
        objFCPhanQuyen = New BO.QT_PHANQUYENFacade
        objFCThamsohethong = New BO.clsB_QT_THAMSOHETHONG
        Dim objEnPhieuthuchiOld = New CM.QLTC_PhieuthuchiEntity
        objFcNhanvien = New BO.QT_DM_NHANVIENFacade
        objFcDMThuchi = New BO.QLTC_DM_THUCHIFacade
        Dim checkKhoaPhieu As Boolean
        checkKhoaPhieu = objFcPhieuthuchi.SelectByID(Session("uId_Phieuthuchi")).b_IsKhoa
        Dim dt_KP As New DataTable
        dt_KP = objFCPhanQuyen.SelectAllTable(Session("uId_Nhanvien_Dangnhap"), "67e68aea-9dbd-43d5-b316-e5ad9c0e6fd3")
        If checkKhoaPhieu = False Or dt_KP.Rows.Count > 0 Then
            With objEnPhieuthuhi
                .uId_Thuchi = ddlDanhmuc.SelectedItem.Value
                .v_Maphieu = txtMaphieu.Text.Trim
                .d_Ngay = BO.Util.ConvertDateTime(deNgaylap.Text)
                .nv_Ghichu = ddlNguoinop.Value
                .nv_Lydo_vn = txtGhichu.Text
                .f_Sotien = Val(txtSotien.Text.Replace(",", ""))
                .uId_Nhanvien = ddlNguoilap.SelectedItem.Value

                Dim oThamsohethong As CM.cls_QT_THAMSOHETHONG = objFCThamsohethong.SelectTHAMSOHETHONGByID("vLockBill")
                If oThamsohethong.v_Giatri = "1" Then
                    .b_IsKhoa = True
                Else
                    .b_IsKhoa = False
                End If
            End With
            If Session("uId_Phieuthuchi") <> Nothing Then
                objEnPhieuthuhi.uId_Phieuthuchi = Session("uId_Phieuthuchi")
                If objFcPhieuthuchi.Update(objEnPhieuthuhi) Then
                    objEnPhieuthuchiOld = objFcPhieuthuchi.SelectByID(Session("uId_Phieuthuchi"))
                    Dim noidungnhatky As String = "Sửa phiếu thu " + objEnPhieuthuhi.v_Maphieu.ToString
                    If objFcPhieuthuchi.Update(objEnPhieuthuhi) Then
                        If objEnPhieuthuchiOld.f_Sotien <> objEnPhieuthuhi.f_Sotien Then
                            noidungnhatky += " (Số tiền): " + objEnPhieuthuchiOld.f_Sotien.ToString + " > " + objEnPhieuthuhi.f_Sotien.ToString
                        End If
                        If objEnPhieuthuchiOld.d_Ngay <> objEnPhieuthuhi.d_Ngay Then
                            noidungnhatky += " (Ngày): " + objEnPhieuthuchiOld.d_Ngay + " > " + objEnPhieuthuhi.d_Ngay
                        End If
                        If objEnPhieuthuchiOld.uId_Nhanvien <> objEnPhieuthuhi.uId_Nhanvien Then
                            noidungnhatky += " (Nhân viên lập): " + objFcNhanvien.SelectByID(objEnPhieuthuchiOld.uId_Nhanvien).nv_Hoten_vn + " > " + objFcNhanvien.SelectByID(objEnPhieuthuhi.uId_Nhanvien).nv_Hoten_vn
                        End If
                        If objEnPhieuthuchiOld.uId_Thuchi <> objEnPhieuthuhi.uId_Thuchi Then
                            noidungnhatky += " (Khoản): " + objFcDMThuchi.SelectByID(objEnPhieuthuchiOld.uId_Thuchi).nv_Tenthuchi_vn + " > " + objFcDMThuchi.SelectByID(objEnPhieuthuhi.uId_Thuchi).nv_Tenthuchi_vn
                        End If
                        objFCNhatKy.Write(Session("sTendangnhap"), System.Environment.MachineName, noidungnhatky)
                        ltrChisucess.Text = "<span class='success' id='success'>Lưu thông tin thành công!</span>"
                    End If
                    ltrSuccess.Text = "<span class='success' id='success'>Lưu thông tin thành công!</span>"
                End If
            Else
                Dim ddlNguoinopSelect As Integer
                ddlNguoinopSelect = ddlNguoinop.SelectedIndex
                If txtGhichu.Text = "" Then
                    objEnPhieuthuhi.nv_Lydo_vn = ddlDanhmuc.SelectedItem.Text + " mã phiếu " + txtMaphieu.Text
                End If
                objEnPhieuthuhi.uId_LoaiTT = "43915768-694A-49B8-8DB2-6332718DB194"
                objEnPhieuthuhi.uId_Cuahang = Session("uId_Cuahang")
                Session("uId_Phieuthuchi") = objFcPhieuthuchi.Insert(objEnPhieuthuhi)
                ltrSuccess.Text = "<span class='success' id='success'>Thêm thông tin thành công!</span>"
                objFCNhatKy.Write(Session("sTendangnhap"), System.Environment.MachineName, "Thêm phiếu thu " & txtMaphieu.Text & ". Lí do " & objEnPhieuthuhi.nv_Lydo_vn & ". Số tiền thu " & txtSotien.Text)
                With objEnCongnoTT
                    If ddlNguoinopSelect >= 0 Then
                        .uId_Khachhang = ddlNguoinop.SelectedItem.Value.ToString
                    Else
                        .uId_Khachhang = ""
                    End If
                    .uId_Phieuthuchi = Session("uId_Phieuthuchi")
                End With
                objFcCongnoTT.Insert(objEnCongnoTT)
            End If
        Else
            ltrSuccess.Text = "<span class='error' id='sucesss'>Phiếu đã khóa!</span>"
        End If
    End Sub

    Protected Sub btn_OKChi_Click(sender As Object, e As EventArgs)
        objEnPhieuthuhi = New CM.QLTC_PhieuthuchiEntity
        objFcPhieuthuchi = New BO.QLTC_PhieuthuchiFacade
        objEnCongnoTT = New CM.QLCN_CONGNO_THANHTOANEntity
        objFcCongnoTT = New BO.QLCN_CONGNO_THANHTOANFacade
        objFcKhachhang = New BO.CRM_DM_KhachhangFacade
        objFCNhatKy = New BO.NHATKYSUDUNGFacade
        objFCPhanQuyen = New BO.QT_PHANQUYENFacade
        objFCThamsohethong = New BO.clsB_QT_THAMSOHETHONG
        objFcNhanvien = New BO.QT_DM_NHANVIENFacade
        objFcDMThuchi = New BO.QLTC_DM_THUCHIFacade
        Dim checkKhoaPhieu As Boolean
        Dim objEnPhieuthuchiOld As New CM.QLTC_PhieuthuchiEntity
        checkKhoaPhieu = objFcPhieuthuchi.SelectByID(Session("uId_Phieuthuchi")).b_IsKhoa
        Dim dt_KP As New DataTable
        dt_KP = objFCPhanQuyen.SelectAllTable(Session("uId_Nhanvien_Dangnhap"), "67e68aea-9dbd-43d5-b316-e5ad9c0e6fd3")
        If checkKhoaPhieu = False Or dt_KP.Rows.Count > 0 Then
            With objEnPhieuthuhi
                .uId_Thuchi = cbo_Khoanchi.SelectedItem.Value
                .v_Maphieu = txt_Maphieuchi.Text.Trim
                .d_Ngay = BO.Util.ConvertDateTime(dte_Ngaychi.Text)
                .nv_Ghichu = txt_Nguoinhan.Text
                .nv_Lydo_vn = txt_Lydochi.Text
                .f_Sotien = Val(txt_Tienchi.Text.Replace(",", ""))
                .uId_Nhanvien = cbo_Nguoilap.SelectedItem.Value
                Dim oThamsohethong As CM.cls_QT_THAMSOHETHONG = objFCThamsohethong.SelectTHAMSOHETHONGByID("vLockBill")
                If oThamsohethong.v_Giatri = "1" Then
                    .b_IsKhoa = True
                Else
                    .b_IsKhoa = False
                End If
            End With
            If Session("uId_Phieuthuchi") <> Nothing Then
                objEnPhieuthuhi.uId_Phieuthuchi = Session("uId_Phieuthuchi")
                objEnPhieuthuchiOld = objFcPhieuthuchi.SelectByID(Session("uId_Phieuthuchi"))
                Dim noidungnhatky As String = "Sửa phiếu chi " + objEnPhieuthuhi.v_Maphieu.ToString
                If objFcPhieuthuchi.Update(objEnPhieuthuhi) Then
                    If objEnPhieuthuchiOld.f_Sotien <> objEnPhieuthuhi.f_Sotien Then
                        noidungnhatky += " (Số tiền): " + objEnPhieuthuchiOld.f_Sotien.ToString + " > " + objEnPhieuthuhi.f_Sotien.ToString
                    End If
                    If objEnPhieuthuchiOld.d_Ngay <> objEnPhieuthuhi.d_Ngay Then
                        noidungnhatky += " (Ngày): " + objEnPhieuthuchiOld.d_Ngay + " > " + objEnPhieuthuhi.d_Ngay
                    End If
                    If objEnPhieuthuchiOld.uId_Nhanvien <> objEnPhieuthuhi.uId_Nhanvien Then
                        noidungnhatky += " (Nhân viên lập): " + objFcNhanvien.SelectByID(objEnPhieuthuchiOld.uId_Nhanvien).nv_Hoten_vn + " > " + objFcNhanvien.SelectByID(objEnPhieuthuhi.uId_Nhanvien).nv_Hoten_vn
                    End If
                    If objEnPhieuthuchiOld.uId_Thuchi <> objEnPhieuthuhi.uId_Thuchi Then
                        noidungnhatky += " (Khoản): " + objFcDMThuchi.SelectByID(objEnPhieuthuchiOld.uId_Thuchi).nv_Tenthuchi_vn + " > " + objFcDMThuchi.SelectByID(objEnPhieuthuhi.uId_Thuchi).nv_Tenthuchi_vn
                    End If
                    objFCNhatKy.Write(Session("sTendangnhap"), System.Environment.MachineName, noidungnhatky)
                    ltrChisucess.Text = "<span class='success' id='success'>Lưu thông tin thành công!</span>"
                End If
            Else
                If txt_Lydochi.Text = "" Then
                    objEnPhieuthuhi.nv_Lydo_vn = cbo_Khoanchi.SelectedItem.Text + " mã phiếu " + txt_Maphieuchi.Text
                End If
                objEnPhieuthuhi.uId_LoaiTT = "43915768-694A-49B8-8DB2-6332718DB194"
                objEnPhieuthuhi.uId_Cuahang = Session("uId_Cuahang")
                Dim ddlNguoinopSelect As Integer
                ddlNguoinopSelect = ddlNguoinop.SelectedIndex
                Session("uId_Phieuthuchi") = objFcPhieuthuchi.Insert(objEnPhieuthuhi)
                ltrChisucess.Text = "<span class='success' id='success'>Thêm thông tin thành công!</span>"
                objFCNhatKy.Write(Session("sTendangnhap"), System.Environment.MachineName, "Thêm phiếu chi " & txt_Maphieuchi.Text & ". Lí do: " & objEnPhieuthuhi.nv_Lydo_vn & ". Số tiền chi: " & txt_Tienchi.Text)
                'With objEnCongnoTT
                '    If ddlNguoinopSelect >= 0 Then
                '        .uId_Khachhang = ddlNguoinop.SelectedItem.Value.ToString
                '    Else
                '        .uId_Khachhang = ""
                '    End If
                '    .uId_Phieuthuchi = Session("uId_Phieuthuchi")
                'End With
                'objFcCongnoTT.Insert(objEnCongnoTT)
            End If
        Else
            ltrChisucess.Text = "<span class='error' id='sucesss'>Phiếu đã khóa!</span>"
        End If
    End Sub
#End Region
#Region "DropDown Event"
    'Protected Sub ddlDanhmuc_Callback(sender As Object, e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase)
    '    LoadDropDownListDanhmuc()
    'End Sub
#End Region


    Protected Sub btn_Xoaphieu_Click(sender As Object, e As EventArgs)
        objFcPhieuthuchi = New BO.QLTC_PhieuthuchiFacade
        objFCNhatKy = New BO.NHATKYSUDUNGFacade
        Dim noidungnhatky As String = "Xóa phiếu thu/ chi "
        If hdfXoa.Value <> "" Then
            noidungnhatky += "mã : " + hdfMaphieu.Value + " lý do: " + txt_lydoxoa.Text
            If (objFcPhieuthuchi.DeleteByID(hdfXoa.Value)) Then
                objFCNhatKy.Write(Session("sTendangnhap"), System.Environment.MachineName, noidungnhatky)
                lbl_sucess.Text = "Xóa thành công!"
            End If
        End If
        LoadData()
    End Sub

    Protected Sub ddlNguoinop_Callback(sender As Object, e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase)
        LoadDropDown_Khachhang()
    End Sub
End Class