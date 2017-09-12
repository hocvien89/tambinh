Public Partial Class Add_DM_Loaimathang
    Inherits System.Web.UI.Page
    Private objFC As New BO.QLMH_DM_LOAIMATHANGFacade
    Private objEn As New CM.QLMH_DM_LOAIMATHANGEntity

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub


    Protected Sub btn_ok_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_ok.Click
        With objEn
            .nv_Tenloaimathang_vn = CStr(Me.txtName.Text.Trim)
        End With
        objFC.Insert(objEn)
        Response.Redirect("~/DANHMUC/DM_Loaimathang.aspx")
    End Sub

    Protected Sub btn_back_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_back.Click
        Response.Redirect("~/DANHMUC/DM_Loaimathang.aspx")
    End Sub
End Class