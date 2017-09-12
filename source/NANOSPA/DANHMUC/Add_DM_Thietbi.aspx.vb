Public Partial Class Add_DM_Thietbi
    Inherits System.Web.UI.Page
    Private objFCCuaHang As New BO.QT_DM_CUAHANGFacade
    Private objEnCuaHang As New CM.QT_DM_CUAHANGEntity
    Private objFC As New BO.QLP_DM_THIETBIFacade
    Private objEn As New CM.QLP_DM_THIETBIEntity

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadDropDownList()
    End Sub
    Protected Sub btn_ok_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_ok.Click
        With objEn
            .uId_Cuahang = CStr(Me.ddlCuaHang.SelectedValue)
            .v_Mathietbi = CStr(Me.txtMaThietbi.Text.Trim)
            .nv_Tenthietbi_vn = CStr(Me.txtTenThietbi.Text.Trim)
            .nv_Ghichu_vn = CStr(Me.txtGhichu.Text.Trim)
        End With
        objFC.Insert(objEn)
        Response.Redirect("~/DANHMUC/DM_Thietbi.aspx")
    End Sub

    Protected Sub btn_Reset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Reset.Click
        Response.Redirect("~/DANHMUC/DM_Thietbi.aspx")
    End Sub
    Private Sub LoadDropDownList()

        ddlCuaHang.DataSource = objFCCuaHang.SelectAllTable()
        ddlCuaHang.DataTextField = "nv_Tencuahang_vn"
        ddlCuaHang.DataValueField = "uId_Cuahang"
        ddlCuaHang.DataBind()
    End Sub
End Class