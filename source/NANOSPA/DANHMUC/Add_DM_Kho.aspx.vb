Public Partial Class Add_DM_Kho
    Inherits System.Web.UI.Page
    Private objFCCuaHang As New BO.QT_DM_CUAHANGFacade
    Private objEnCuaHang As New CM.QT_DM_CUAHANGEntity
    Private objFC As New BO.QLMH_DM_KHOFacade
    Private objEn As New CM.QLMH_DM_KHOEntity

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadDropDownList()
    End Sub

    Private Sub LoadDropDownList()
        If Session("uId_Cuahang") <> Nothing Then
            ddlCuaHang.DataSource = objFCCuaHang.SelectByID(Session("uId_Cuahang"))
        Else : ddlCuaHang.DataSource = objFCCuaHang.SelectAllTable()
        End If
        ddlCuaHang.DataTextField = "nv_Tencuahang_vn"
        ddlCuaHang.DataValueField = "uId_Cuahang"
        ddlCuaHang.DataBind()
    End Sub

    Protected Sub btn_ok_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_ok.Click
        With objEn
            .uId_Cuahang = CStr(Me.ddlCuaHang.SelectedValue)
            .v_Makho = CStr(Me.txtMa.Text.Trim)
            .nv_Tenkho_vn = CStr(Me.txtTenKho.Text.Trim)
        End With
        objFC.Insert(objEn)
        Response.Redirect("~/DANHMUC/DM_Kho.aspx")
    End Sub

    Protected Sub btn_Reset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Reset.Click
        Response.Redirect("~/DANHMUC/DM_Kho.aspx")
    End Sub


End Class