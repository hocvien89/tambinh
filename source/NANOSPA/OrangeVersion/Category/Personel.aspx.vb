Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView
Imports DevExpress.Web.ASPxGridView.Export

Public Class Personel
    Inherits System.Web.UI.Page
    Private objEnNhanvien As CM.QT_DM_NHANVIENEntity
    Private objFcNhanvien As BO.QT_DM_NHANVIENFacade
    Private objFCPhanQuyen As BO.QT_PHANQUYENFacade
    Private objEnPhanQuyen As CM.QT_PHANQUYENEntity
    Private objEnCuahangNv As CM.CUAHANG_NHANVIENEntity
    Private objFcCuahangNv As BO.CUAHANG_NHANVIENFacade
    Private objFcResource As BO.ResourcesFacade
    Private objEnResource As CM.ResourcesEntity
    Dim oLibP As Lib_SAT.cls_Pub_Functions
    Dim oLog As LogError.ShowError
    Dim objFcPhong As BO.QLP_DM_PHONGFacade
    Dim objFcPQP_NV_Phong As BO.PQP_NHANVIEN_PHONGFacade
    Dim objEnPQP_NV_Phong As CM.PQP_NHANVIEN_PHONGEntity

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            loadTinhtrang()
            loadChucvu()
            loadNhanvien()
            cboNhanvien.Value = Session("uId_Nhanvien_Dangnhap")
            LoadcomboLoai()
            Load_DM_Phong()
        End If
        loadNhanvien()
        LoadPhanquyen()
    End Sub
#Region "Load dữ liệu"
    Private Sub loadNhanvien()
        objEnNhanvien = New CM.QT_DM_NHANVIENEntity
        objFcNhanvien = New BO.QT_DM_NHANVIENFacade
        Dim dt As DataTable
        Try
            dt = objFcNhanvien.SelectAllTable(Session("uId_Cuahang"))
            Grid_Nhanvien.DataSource = dt
            Grid_Nhanvien.DataBind()
            cboNhanvien.DataSource = dt
            cboNhanvien.TextField = "nv_Hoten_vn"
            cboNhanvien.ValueField = "uId_Nhanvien"
            cboNhanvien.DataBind()

        Catch ex As Exception

        End Try
        
    End Sub
    Private Sub Load_DM_Phong()
        objFcPhong = New BO.QLP_DM_PHONGFacade
        Dim dt As DataTable = objFcPhong.SelectAllTable(Session("uId_Cuahang"))
            cb_Bophan.DataSource = dt
            cb_Bophan.ValueField = "uId_Phong"
            cb_Bophan.TextField = "nv_Tenphong_vn"
            cb_Bophan.DataBind()
    End Sub

    Private Sub LoadcomboLoai()
        Dim item0 As New ListEditItem
        Dim item As New ListEditItem
        Dim item2 As New ListEditItem
        item.Value = 1
        item.Text = "Nhân viên làm dịch vụ"
        item2.Value = 0
        item2.Text = "Nhân viên khác"
        cbo_Loai.Items.Add(item2)
        cbo_Loai.Items.Add(item)
        cbo_Loai.SelectedIndex = 0
    End Sub


    Private Sub loadTinhtrang()
        Dim item1 As New ListEditItem
        Dim item2 As New ListEditItem
        item1.Value = "0"
        item1.Text = "Đã nghỉ việc"
        item2.Value = "1"
        item2.Text = "Đang làm việc"
        pcbo_Tinhtrang.Items.Add(item1)
        pcbo_Tinhtrang.Items.Add(item2)
    End Sub

    Private Sub loadChucvu()
        Try
            Dim item1 As New ListEditItem
            Dim item2 As New ListEditItem
            Dim item3 As New ListEditItem
            Dim item4 As New ListEditItem
            item1.Value = "0"
            item1.Text = "Giám đốc"
            item2.Value = "1"
            item2.Text = "Nhân viên"
            item3.Value = "2"
            item3.Text = "Lễ tân"
            item4.Value = "3"
            item4.Text = "Kế toán"
            pcbo_Chucvu.Items.Add(item1)
            pcbo_Chucvu.Items.Add(item2)
            pcbo_Chucvu.Items.Add(item3)
            pcbo_Chucvu.Items.Add(item4)
        Catch ex As Exception
        End Try
    End Sub
#End Region
#Region "Suport"
    Private Sub ClearText()
        txt_Diachi.Text = ""
        txt_Dienthoai.Text = ""
        txt_Email.Text = ""
        txt_image.Text = ""
        img_NhanV.ImageUrl = ""
        txt_Login.Text = ""
        txt_Manhanvien.Text = ""
        txt_Pass.Text = ""
        txt_Tennhanvien.Text = ""
        pcbo_Tinhtrang.SelectedIndex = 0
    End Sub
    'kiem tra trung ma nhan vien khi insert
    Private Function CheckManhanvien(ma As String) As Integer
        objFcNhanvien = New BO.QT_DM_NHANVIENFacade
        Dim dt As DataTable
        Dim i As Integer = 0
        Try
            dt = objFcNhanvien.SelectAllTable(Session("uId_Cuahang"))
            If dt.Rows.Count <> 0 Then
                For Each row As DataRow In dt.Rows
                    If ma = row("v_Manhanvien").ToString Then
                        i += 1
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
        Return i
    End Function
    'kiem tra ma nhan vien khi update
    Private Function CheckUpdate(uid_nhanvien As String, manhanvien As String) As Integer
        objFcNhanvien = New BO.QT_DM_NHANVIENFacade
        Dim dt As DataTable
        Dim i As Integer = 0
        Dim k As Integer
        Dim l As Integer
        Try
            dt = objFcNhanvien.SelectAllTable(Session("uId_Cuahang"))
            If dt.Rows.Count <> 0 Then
                For Each row As DataRow In dt.Rows
                    If uid_nhanvien = row("uId_Nhanvien").ToString Then
                        If manhanvien = row("v_Manhanvien").ToString Then
                            i += 1
                        Else
                            For k = 0 To dt.Rows.Count Step 1
                                If dt.Rows(k)("v_Manhanvien").ToString <> manhanvien Then
                                    l += 1
                                End If
                                If l = dt.Rows.Count Then
                                    i += 1
                                End If
                            Next
                        End If
                    End If
                Next
            End If

        Catch ex As Exception

        End Try
        Return i
    End Function
    'kiem tra trung tai khoan
    Private Function CheckTaikhoan(taikhoan As String) As Integer
        objFcNhanvien = New BO.QT_DM_NHANVIENFacade
        Dim dt As DataTable
        Dim i As Integer = 0
        Try
            dt = objFcNhanvien.SelectAllTable(Session("uId_Cuahang"))
            If dt.Rows.Count <> 0 Then
                For Each row As DataRow In dt.Rows
                    If taikhoan = row("v_Tendangnhap").ToString Then
                        i += 1
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
        Return i
    End Function
    'kiem tra tai khoan tkhi update
    Private Function CheckUpdateTaikhoan(uid_nhanvien As String, taikhoan As String) As Integer
        objFcNhanvien = New BO.QT_DM_NHANVIENFacade
        Dim dt As DataTable
        Dim i As Integer = 0
        Dim k As Integer
        Dim l As Integer
        Try
            dt = objFcNhanvien.SelectAllTable(Session("uId_Cuahang"))
            If dt.Rows.Count <> 0 Then
                For Each row As DataRow In dt.Rows
                    If uid_nhanvien = row("uId_Nhanvien").ToString Then
                        If taikhoan = row("v_Tendangnhap").ToString Then
                            i += 1
                        Else
                            For k = 0 To dt.Rows.Count Step 1
                                If dt.Rows(k)("v_Tendangnhap").ToString <> taikhoan Then
                                    l += 1
                                End If
                                If l = dt.Rows.Count Then
                                    i += 1
                                End If
                            Next
                        End If
                    End If
                Next
            End If

        Catch ex As Exception

        End Try
        Return i
    End Function
    'export excel
    Protected Sub ExportExcel()
        Grid_Nhanvien.SettingsDetail.ExportMode = CType(System.Enum.Parse(GetType(GridViewDetailExportMode), GridViewDetailExportMode.None.ToString()), GridViewDetailExportMode)
    End Sub
#End Region
#Region "Chức năng"
    'sua du lieu
    Protected Sub btOK_Click1(sender As Object, e As EventArgs)
        lbl_.Text = ""
        lbl_error.Text = ""
        objEnCuahangNv = New CM.CUAHANG_NHANVIENEntity
        objFcCuahangNv = New BO.CUAHANG_NHANVIENFacade
        objEnNhanvien = New CM.QT_DM_NHANVIENEntity
        objFcNhanvien = New BO.QT_DM_NHANVIENFacade
        objFcResource = New BO.ResourcesFacade
        objEnResource = New CM.ResourcesEntity
        objEnPQP_NV_Phong = New CM.PQP_NHANVIEN_PHONGEntity
        objFcPQP_NV_Phong = New BO.PQP_NHANVIEN_PHONGFacade
        Dim uid_nhanvien As String
        Try
            oLibP = New Lib_SAT.cls_Pub_Functions
            Dim dt As DataTable
            'Kiem tra Quyen them KH
            objEnPhanQuyen = New CM.QT_PHANQUYENEntity
            objFCPhanQuyen = New BO.QT_PHANQUYENFacade
            objEnPhanQuyen = objFCPhanQuyen.SelectByID(Session("uId_Nhanvien_Dangnhap").ToString, "D50AAD73-0FCA-45F5-BE58-95ADB0EF3F8B")
            If Not objEnPhanQuyen.b_Enable Then
                lbl_error.Text = "<span class='error' id='error'>Bạn không có quyền chỉnh sửa thông tin !</span>"
                objEnPhanQuyen = Nothing
                objFCPhanQuyen = Nothing
                Exit Sub
            End If
            objEnPhanQuyen = objFCPhanQuyen.SelectByID(Session("uId_Nhanvien_Dangnhap").ToString, "A0C2F5FC-252D-4CC1-B076-BB6C59A7328D")
            If Not objEnPhanQuyen.b_Enable Then
                lbl_error.Text = "<span class='error' id='error'>Bạn không có quyền sửa thông tin !</span>"
                objEnPhanQuyen = Nothing
                objFCPhanQuyen = Nothing
                Exit Sub
            End If
            objEnPhanQuyen = Nothing
            objFCPhanQuyen = Nothing
            With objEnNhanvien
                .nv_Hoten_vn = txt_Tennhanvien.Text '4
                .nv_Diachi_vn = txt_Diachi.Text '9
                .v_Tendangnhap = txt_Login.Text '15
                .v_Email = txt_Email.Text '14
                .v_Dienthoai = txt_Dienthoai.Text '13
                .v_Barcode = "" '2
                .d_Ngaysinh = BO.Util.ConvertDateTime(date_Ngaysinh.Text) '6
                .d_Ngayvaolam = BO.Util.ConvertDateTime(date_Ngaylam.Text) '18
                .nv_Chucvu_vn = pcbo_Chucvu.SelectedItem.ToString '7
                .nv_Quequan_en = txt_image.Text.Trim '12
                .nv_Quequan_vn = "" '11
                .nv_Diachi_en = "" '10
                .nv_Chucvu_en = "" '8
                .nv_Hoten_en = "" '5

                If chk_Taikhoan.Checked = True Then
                    .b_ActiveLogin = True '17
                Else
                    .b_ActiveLogin = False
                End If
                If pcbo_Tinhtrang.SelectedIndex = 0 Then
                    .b_Danglamviec = False '19
                Else
                    .b_Danglamviec = True
                End If
            End With
            ''Phuongdv_ insert Nhan vien vao bang resuorce
            'With objEnResource
            '    .Color = ""
            '    .CustomField1 = Session("uId_Nhanvien").ToString
            'End With
            If hdfuIdNhanvien.Value <> "" Then
                If CheckUpdate(hdfuIdNhanvien.Value.ToString, txt_Manhanvien.Text.ToString) >= 1 Then
                    objEnNhanvien.uId_Nhanvien = hdfuIdNhanvien.Value '1
                    objEnNhanvien.v_Manhanvien = txt_Manhanvien.Text
                Else
                    lbl_error.Text = "Mã nhân viên bị trùng"
                    txt_Manhanvien.Focus()
                    Return
                End If
                'kiem tra nhan vien co duoc cap tai khoan dang nhap he thong ko
                If chk_Motaikhoan.Checked = True Then
                    'kiem tra tai khoan co bi trung nhau khong
                    If txt_Login.Text = "" Or txt_Pass.Text = "" Then
                        lbl_error.Text = "Tài khoản và mật khẩu không được để trống!"
                        Return
                    Else
                        If CheckUpdateTaikhoan(hdfuIdNhanvien.Value.ToString, txt_Login.Text.ToString) >= 1 Then
                            objEnNhanvien.v_Tendangnhap = txt_Login.Text
                            objEnNhanvien.v_Matkhau = txt_Pass.Text
                        Else
                            lbl_error.Text = "Tên đăng nhập đã tồn tại"
                            txt_Login.Focus()
                            Return
                        End If
                    End If
                Else
                    objEnNhanvien.v_Tendangnhap = Nothing
                    objEnNhanvien.v_Matkhau = Nothing
                    txt_Login.Text = ""
                    txt_Pass.Text = ""
                End If
                With objEnPQP_NV_Phong
                    .uId_Nhanvien = hdfuIdNhanvien.Value
                    .uId_Phongban = cb_Bophan.SelectedItem.Value.ToString
                    .nv_Ghichu = ""
                End With
                objFcPQP_NV_Phong.Update_Table(objEnPQP_NV_Phong)
                objFcNhanvien.Update(objEnNhanvien, cbo_Loai.Value.ToString)
                lbl_.Text = "Sửa thông tin thành công"
            Else 'them nhan vien
                If CheckManhanvien(txt_Manhanvien.Text.ToString) = 0 Then
                    objEnNhanvien.v_Manhanvien = txt_Manhanvien.Text '3
                Else
                    lbl_error.Text = "Mã nhân viên bị trùng"
                    txt_Manhanvien.Focus()
                    Return
                End If
                If chk_Motaikhoan.Checked = True Then
                    If txt_Login.Text.ToString <> "" Then
                        If CheckTaikhoan(txt_Login.Text.ToString) = 0 Then
                            objEnNhanvien.v_Tendangnhap = txt_Login.Text
                            objEnNhanvien.v_Matkhau = txt_Pass.Text
                        Else
                            lbl_error.Text = "Tên đăng nhập đã tồn tại"
                            txt_Login.Focus()
                            Return
                        End If
                    Else
                        objEnNhanvien.v_Tendangnhap = Nothing
                        objEnNhanvien.v_Matkhau = Nothing
                    End If
                Else
                End If
                uid_nhanvien = objFcNhanvien.Insert(objEnNhanvien, cbo_Loai.Value.ToString)
                ClearText()
                With objEnCuahangNv
                    .d_Ngay = DateAndTime.Now.ToString
                    .nv_Lydo_en = ""
                    .nv_Lydo_vn = "Bắt đầu làm việc"
                    .uId_Cuahang = Session("uId_Cuahang").ToString
                    .uId_Nhanvien = uid_nhanvien
                End With
                objFcCuahangNv.Insert(objEnCuahangNv)
                With objEnPQP_NV_Phong
                    .uId_Nhanvien = uid_nhanvien
                    .uId_Phongban = cb_Bophan.SelectedItem.Value.ToString
                    .nv_Ghichu = ""
                End With
                objFcPQP_NV_Phong.Insert(objEnPQP_NV_Phong)
                Dim divmo As New System.Web.UI.HtmlControls.HtmlGenericControl("divmotaikhoan")
                If chk_Motaikhoan.Checked = True Then
                    divmo.Style.Add(HtmlTextWriterStyle.Display, "block")
                Else
                    divmo.Style.Add(HtmlTextWriterStyle.Display, "none")
                End If
                lbl_.Text = "Thêm nhân viên thành công"
            End If
        Catch ex As Exception

        End Try
        img_NhanV.ImageUrl = txt_image.Text
        objEnNhanvien = Nothing
        objFcNhanvien = Nothing
    End Sub
    Protected Sub Grid_Nhanvien_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        Dim uId_Nhanvien As String
        uId_Nhanvien = e.Keys(0).ToString
        objFcNhanvien = New BO.QT_DM_NHANVIENFacade
        Try
            objFcNhanvien.DeleteByID(uId_Nhanvien)
            Grid_Nhanvien.CancelEdit()
            e.Cancel = True
            loadNhanvien()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnExportExcel_Click(sender As Object, e As EventArgs) Handles btnExportExcel.Click
        ExportExcel()
        Export_Pesonel.WriteXlsxToResponse()
    End Sub
#End Region

    Protected Sub pcAddNhanvien_WindowCallback(source As Object, e As DevExpress.Web.ASPxPopupControl.PopupWindowCallbackArgs)
        Dim divmo As New System.Web.UI.HtmlControls.HtmlGenericControl("divmotaikhoan")
        If chk_Motaikhoan.Checked = True Then
            divmo.Style.Add(HtmlTextWriterStyle.Display, "block")
        Else
            divmo.Style.Add(HtmlTextWriterStyle.Display, "none")
        End If
    End Sub

    Private Sub LoadPhanquyen()
        Dim objFcPhanquyen As New BO.QT_PHANQUYENFacade
        Dim dt As DataTable
        dt = objFcPhanquyen.SelectByuId_Nhanvien(cboNhanvien.Value)
        Grid_Chucnang.DataSource = dt
        Grid_Chucnang.DataBind()
    End Sub

End Class