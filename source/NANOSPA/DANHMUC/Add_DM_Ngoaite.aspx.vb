Public Partial Class Add_DM_Ngoaite
    Inherits System.Web.UI.Page
    Private objFC As New BO.TNTP_DM_NGOAITEFacade
    Private objEn As New CM.TNTP_DM_NGOAITEEntity

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btn_ok_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_ok.Click
        With objEn
            .v_Ma = CStr(Me.txtMaNgoaite.Text.Trim)
            .b_Macdinh = CByte(Me.ddlMacdinh.SelectedValue.ToString.Trim)
        End With
        objFC.Insert(objEn)
        Response.Redirect("~/DANHMUC/DM_Ngoaite.aspx")
    End Sub

    Protected Sub btn_back_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_back.Click
        Response.Redirect("~/DANHMUC/DM_Ngoaite.aspx")
    End Sub

End Class