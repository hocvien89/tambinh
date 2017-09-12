Public Partial Class DS_Mathang
    Inherits System.Web.UI.Page
    Private objFC As New BO.QLMH_DM_MATHANGFacade
    Private objEn As New CM.QLMH_DM_MATHANGEntity
    Private objEn_LoaiMathang As New CM.QLMH_DM_LOAIMATHANGEntity
    Private objFC_LoaiMathang As New BO.QLMH_DM_LOAIMATHANGFacade
    Private objEn_NhomMathang As New CM.QLMH_DM_NHOMMATHANGEntity
    Private objFC_NhomMathang As New BO.QLMH_DM_NHOMMATHANGFacade

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            LoadDDLLoaimathang()
            LoadDDLNhommathang()
            Me.LoadData()
        End If
    End Sub

    Private Sub LoadData()
        Dim dt As New DataTable
        dt = objFC.SelectTimKiem(ddlLoaimathang.SelectedValue, ddlNhommathang.SelectedValue, txtTenMH.Text.Trim)
        If dt.Rows.Count = 0 Then
            dt.Rows.Add(dt.NewRow())
        End If
        Gv_Mathang.DataSource = dt
        Gv_Mathang.DataBind()
    End Sub
    Private Sub LoadDDLLoaimathang()
        Dim dt As New DataTable
        dt = objFC_LoaiMathang.SelectAllTable
        ddlLoaimathang.DataSource = dt
        ddlLoaimathang.DataTextField = "nv_Tenloaimathang_vn"
        ddlLoaimathang.DataValueField = "uId_Loaimathang"
        ddlLoaimathang.DataBind()
    End Sub

    Private Sub LoadDDLNhommathang()
        Dim dt As New DataTable
        dt = objFC_NhomMathang.SelectAllTable
        ddlNhommathang.DataSource = dt
        ddlNhommathang.DataTextField = "nv_Tennhommathang_vn"
        ddlNhommathang.DataValueField = "uId_Nhommathang"
        ddlNhommathang.DataBind()
    End Sub
    Protected Sub Gv_Mathang_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Gv_Mathang.SelectedIndexChanged

        Dim grv As GridViewRow = Gv_Mathang.Rows(Gv_Mathang.SelectedIndex)
        Dim uId_Mathang As String = Convert.ToString(Gv_Mathang.DataKeys(Gv_Mathang.SelectedIndex)("uId_Mathang")).Trim

        If uId_Mathang <> "" Then
            Session("uId_Mathang") = uId_Mathang
            ClientScript.RegisterStartupScript(GetType(Page), "ClientScript", "<script>window.close();opener.location='Add_Dinhmuc_GiaMathang.aspx?event=refresh';</script>")
        End If
    End Sub

    Protected Sub Gv_Mathang_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles Gv_Mathang.PageIndexChanging
        Gv_Mathang.PageIndex = e.NewPageIndex
        LoadData()
    End Sub
    Protected Sub btnTimKiem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTimKiem.Click
        LoadData()
    End Sub
End Class