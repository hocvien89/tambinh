Public Partial Class Add_DM_Phong1
    Inherits System.Web.UI.Page
    Private objFCCuaHang As New BO.QT_DM_CUAHANGFacade
    Private objEnCuaHang As New CM.QT_DM_CUAHANGEntity
    Private objEn_ListCuaHang As List(Of CM.QT_DM_CUAHANGEntity) = Nothing
    Private objFC As New BO.QLP_DM_PHONGFacade
    Private objEn As New CM.QLP_DM_PHONGEntity


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadDropDownList()
    End Sub

    Private Sub LoadDropDownList()

        ddlCuaHang.DataSource = objFCCuaHang.SelectAllTable()
        ddlCuaHang.DataTextField = "nv_Tencuahang_vn"
        ddlCuaHang.DataValueField = "uId_Cuahang"
        ddlCuaHang.DataBind()
        If Session("uId_Cuahang") <> Nothing Then
            ddlCuaHang.SelectedValue = Session("uId_Cuahang").ToString
            ddlCuaHang.Enabled = False
        End If
    End Sub

    Protected Sub btn_ok_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_ok.Click
        With objEn
            .uId_Cuahang = CStr(Me.ddlCuaHang.SelectedValue)
            .nv_Tenphong_vn = CStr(Me.txtTenPhong.Text.Trim)
            .i_Thutu = CInt(Val(Me.txtStt.Text.Trim))
            .i_Sokhachtoida = CInt(Val(Me.txtSlKhach.Text.Trim))
            .v_Dienthoai = CStr(Me.txtDienThoai.Text.Trim)
            .v_Mauchu = CStr(Me.txtMauchu.Text.Trim)
            .v_Maunen = CStr(Me.txtMaunen.Text.Trim)
        End With
        objFC.Insert(objEn)
        Response.Redirect("~/DANHMUC/DM_Phong.aspx")
    End Sub

    Protected Sub btn_Reset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Reset.Click
        Response.Redirect("~/DANHMUC/DM_Phong.aspx")
    End Sub

End Class