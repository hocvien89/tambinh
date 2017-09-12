Public Partial Class Add_DM_Cuahang
    Inherits System.Web.UI.Page

    Private objFC As New BO.QT_DM_CUAHANGFacade
    Private objEn As New CM.QT_DM_CUAHANGEntity
    Private objFCNhanvien As New BO.QT_DM_NHANVIENFacade
    Private objEnNhanvien As New CM.QT_DM_NHANVIENEntity
    Private objFCPhanQuyen As New BO.QT_PHANQUYENFacade
    Private objEnPhanQuyen As New CM.QT_PHANQUYENEntity
    Private objEnCuahang_Nhanvien As New CM.CUAHANG_NHANVIENEntity
    Private objFCCuahang_Nhanvien As New BO.CUAHANG_NHANVIENFacade


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            LoadData()
        End If
    End Sub
    Private Sub LoadData()
        If Session("uId_CuahangMoi") <> Nothing Then
            Dim dt As DataTable
            dt = objFC.SelectByID(Session("uId_CuahangMoi"))
            If dt.Rows.Count > 0 Then
                txtMaCuahang.Text = dt.Rows(0)("v_Macuahang").ToString
                txtTenCuahang.Text = dt.Rows(0)("nv_Tencuahang_vn").ToString
                txtDiaChi.Text = dt.Rows(0)("nv_Diachi_vn").ToString
                txtMaCuahang.ReadOnly = True
            End If
        End If
    End Sub
    Protected Sub btn_OK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_OK.Click
        If txtMaCuahang.Text.Trim.Length <> 2 Then
            ShowMessage(Me, "Mã cửa hàng không hợp lệ!")
            Exit Sub
        Else
            Dim dtMaCh As DataTable
            dtMaCh = objFC.SelectByMaCH(txtMaCuahang.Text.Trim.ToUpper)
            If dtMaCh.Rows.Count > 0 Then
                ShowMessage(Me, "Mã cửa hàng này đã tồn tại!")
                Exit Sub
            End If
        End If
        With objEn
            .v_Macuahang = CStr(Me.txtMaCuahang.Text.Trim.ToUpper)
            .nv_Tencuahang_vn = CStr(Me.txtTenCuahang.Text.Trim)
            .nv_Diachi_vn = CStr(Me.txtDiaChi.Text.Trim)
            .b_Active = CByte(Me.ddlTrangthai.SelectedValue.ToString.Trim)
        End With
        Session("uId_CuahangMoi") = objFC.Insert(objEn)
    End Sub
    Protected Sub btnThemAdmin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnThemAdmin.Click
        If Session("uId_CuahangMoi") <> Nothing Then
            divTkAdmin.Visible = True
            txtTenadmin.Text = "admin" + txtMaCuahang.Text.Trim
        End If
    End Sub
    Protected Sub btnLuuAdmin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLuu.Click
        If txtTenadmin.Text.Trim <> "" Then
            Dim dtTK As DataTable
            dtTK = objFCNhanvien.SelectByTenDangNhap(txtTenadmin.Text.Trim)
            If dtTK.Rows.Count > 0 Then
                ShowMessage(Me, "Tên đăng nhập này đã có!")
                Exit Sub
            End If
        End If
        With objEnNhanvien
            .v_Manhanvien = CStr(txtTenadmin.Text.Trim)
            .nv_Hoten_vn = txtTenadmin.Text.Trim
            .nv_Chucvu_vn = "Admin"
            .v_Tendangnhap = CStr(txtTenadmin.Text.Trim)
            .v_Matkhau = CStr(Me.txtMatkhau.Text.Trim)
            .b_ActiveLogin = True
        End With
        Dim struId_admin As String = objFCNhanvien.Insert(objEnNhanvien)
        With objEnCuahang_Nhanvien
            .uId_Cuahang = Session("uId_CuahangMoi")
            .uId_Nhanvien = struId_admin
        End With
        objFCCuahang_Nhanvien.Insert(objEnCuahang_Nhanvien)
        If objFCPhanQuyen.InsertAdmin(struId_admin) Then
            ShowMessage(Me, "Tạo tài khoản Admin thành công!")
        End If

    End Sub
    Protected Sub btn_Cancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Reset.Click
        Response.Redirect("~/DANHMUC/DM_Cuahang.aspx")
    End Sub
End Class