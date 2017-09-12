Public Partial Class Add_DM_Nhacungcap
    Inherits System.Web.UI.Page
    Private objFC As New BO.QLMH_DM_NHACUNGCAPFacade
    Private objEn As New CM.QLMH_DM_NHACUNGCAPEntity

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btn_ok_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_ok.Click
        With objEn
            .v_Manhacungcap = CStr(Me.txtMa.Text.Trim)
            .nv_Tennhacungcap_vn = CStr(Me.txtName.Text.Trim)
            .nv_Diachi_vn = CStr(Me.txtDiachi.Text.Trim)
        End With
        objFC.Insert(objEn)
        Response.Redirect("~/DANHMUC/DM_Nhacungcap.aspx")
    End Sub

    Protected Sub btn_back_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_back.Click
        Response.Redirect("~/DANHMUC/DM_Nhacungcap.aspx")
    End Sub

End Class