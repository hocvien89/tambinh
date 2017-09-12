Public Partial Class Add_Nhommathang
    Inherits System.Web.UI.Page
    Private objFC As New BO.QLMH_DM_NHOMMATHANGFacade
    Private objEn As New CM.QLMH_DM_NHOMMATHANGEntity

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btn_ok_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_ok.Click
        With objEn
            .nv_Tennhommathang_vn = CStr(Me.txtName.Text.Trim)
        End With
        objFC.Insert(objEn)
        Response.Redirect("~/DANHMUC/DM_Nhommathang.aspx")
    End Sub

    Protected Sub btn_back_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_back.Click
        Response.Redirect("~/DANHMUC/DM_Nhommathang.aspx")
    End Sub

End Class