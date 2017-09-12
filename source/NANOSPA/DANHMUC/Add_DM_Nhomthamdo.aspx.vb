Public Partial Class Add_DM_Nhomthamdo
    Inherits System.Web.UI.Page
    Private objFC As New BO.TNTP_DM_NHOMTHAMDOFacade
    Private objEn As New CM.TNTP_DM_NHOMTHAMDOEntity

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btn_ok_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_ok.Click
        With objEn
            .nv_TennhomThamdo_vn = CStr(Me.txtName.Text.Trim)
        End With
        objFC.Insert(objEn)
        Response.Redirect("~/DANHMUC/DM_Nhomthamdo.aspx")
    End Sub

    Protected Sub btn_back_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_back.Click
        Response.Redirect("~/DANHMUC/DM_Nhomthamdo.aspx")
    End Sub
End Class