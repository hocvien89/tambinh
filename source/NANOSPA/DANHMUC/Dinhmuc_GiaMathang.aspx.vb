Public Partial Class Dinhmuc_GiaMathang
    Inherits System.Web.UI.Page
    Private objFC As New BO.QLMH_DINHMUC_GIAMATHANGFacade
    Private objEn As New CM.QLMH_DINHMUC_GIAMATHANGEntity
    Private oB_Kho As New BO.QLMH_DM_KHOFacade
    Private objEn_NhomMathang As New CM.QLMH_DM_NHOMMATHANGEntity
    Private objFC_NhomMathang As New BO.QLMH_DM_NHOMMATHANGFacade
    Private objFC_LoaiMathang As New BO.QLMH_DM_LOAIMATHANGFacade
    Private objFCPhanQuyen As New BO.QT_PHANQUYENFacade

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            CheckUser()
            Load_DropDownList_Kho()
            'LoadDDLNhommathang()
            LoadDDLLoaimathang()
            Me.LoadData()
        End If
    End Sub
    Private Sub CheckUser()
        Dim dt As New DataTable
        dt = objFCPhanQuyen.SelectAllTable(Session("uId_Nhanvien_Dangnhap"), "c80c9539-681c-458a-b6b0-930fdad7dc18")
        If dt.Rows.Count = 0 Then
            Response.Redirect("../ThongBaoQuyen.aspx")
        Else
            Public_Class.CheckUser(Me.Page, dt)
        End If
    End Sub
    Private Sub Load_DropDownList_Kho()
        ddlKho.DataSource = oB_Kho.SelectAllTable(Session("uId_Cuahang"))
        ddlKho.DataTextField = "nv_Tenkho_vn"
        ddlKho.DataValueField = "uId_Kho"
        ddlKho.DataBind()
    End Sub

    'Private Sub LoadDDLNhommathang()
    '    Dim dt As New DataTable
    '    dt = objFC_NhomMathang.SelectAllTable
    '    ddlNhommathang.DataSource = dt
    '    ddlNhommathang.DataTextField = "nv_Tennhommathang_vn"
    '    ddlNhommathang.DataValueField = "uId_Nhommathang"
    '    ddlNhommathang.DataBind()
    'End Sub

    Private Sub LoadDDLLoaimathang()
        ddlLoaiMathang.DataSource = objFC_LoaiMathang.SelectAllTable
        ddlLoaiMathang.DataTextField = "nv_Tenloaimathang_vn"
        ddlLoaiMathang.DataValueField = "uId_Loaimathang"
        ddlLoaiMathang.DataBind()
    End Sub

   

    Private Sub LoadData()
        Dim dt As New DataTable
        dt = objFC.SelectAllTable_ByuId_Loaimathang(ddlKho.SelectedValue.ToString, ddlLoaiMathang.SelectedValue)
        If dt.Rows.Count = 0 Then
            dt.Rows.Add(dt.NewRow())
        End If
        GvGiamathang.DataSource = dt
        GvGiamathang.DataBind()
    End Sub

    Protected Sub ddlKho_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlKho.SelectedIndexChanged
        LoadData()
    End Sub
    Protected Sub ddlNhom_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ddlLoaiMathang.SelectedIndexChanged
        LoadData()
    End Sub
    Protected Sub GvGiamathang_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GvGiamathang.PageIndexChanging
        GvGiamathang.PageIndex = e.NewPageIndex
        LoadData()
    End Sub

    Protected Sub GvGiamathang_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GvGiamathang.RowCancelingEdit
        GvGiamathang.EditIndex = -1
        LoadData()
    End Sub

    Protected Sub GvGiamathang_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GvGiamathang.RowDeleting
        Dim id As String
        If GvGiamathang.DataKeys.Count <> 0 Then
            id = GvGiamathang.DataKeys(e.RowIndex).Values("uId_Dinhmuc_Giamathang").ToString()
            objFC.DeleteByID(id)
        End If
        LoadData()
    End Sub

    Protected Sub GvGiamathang_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GvGiamathang.RowEditing
        GvGiamathang.EditIndex = e.NewEditIndex
        LoadData()
    End Sub

    Protected Sub GvGiamathang_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GvGiamathang.RowUpdating
        Dim grv As GridViewRow = GvGiamathang.Rows(e.RowIndex)
        Dim uId_Dinhmuc_Giamathang As String = Convert.ToString(GvGiamathang.DataKeys(e.RowIndex)("uId_Dinhmuc_Giamathang"))
        With objEn
            .uId_Dinhmuc_Giamathang = uId_Dinhmuc_Giamathang
            .f_Giaban = CInt(CType(grv.Cells(4).Controls(0), TextBox).Text.Trim)
            .f_Gianhap = CInt(CType(grv.Cells(2).Controls(0), TextBox).Text.Trim)
            .f_Biendo_Giaban = CInt(CType(grv.Cells(5).Controls(0), TextBox).Text.Trim)
            .f_Biendo_Gianhap = CInt(CType(grv.Cells(3).Controls(0), TextBox).Text.Trim)
        End With
        objFC.Update(objEn)
        GvGiamathang.EditIndex = -1
        LoadData()
    End Sub

    Protected Sub btn_Them_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Them.Click
        Session("nv_TenMathang_vn") = Nothing
        Session("uId_Mathang") = Nothing
        Response.Redirect("~/DANHMUC/Add_Dinhmuc_GiaMathang.aspx")
    End Sub

    Private Sub txtTim_Tensanpham_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTim_Tensanpham.TextChanged
        Try
            GvGiamathang.DataSource = objFC.SelectTim_ByTensanpham(ddlKho.SelectedValue.ToString, Trim(txtTim_Tensanpham.Text))
            GvGiamathang.DataBind()
        Catch ex As Exception

        End Try
    End Sub
End Class