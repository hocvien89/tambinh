Public Partial Class Add_DM_Trangthai
    Inherits System.Web.UI.Page
    Private objFC As New BO.CRM_DM_TRANGTHAIFacade
    Private objEn As New CM.CRM_DM_TRANGTHAIEntity

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btn_ok_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_ok.Click
        With objEn
            .v_Matrangthai = CStr(Me.txtMaTrangthai.Text.Trim)
            .nv_Tentrangthai_vn = CStr(Me.txtName.Text.Trim)
            .v_Mau_Chu = CStr(Me.txtMauChu.Text.Trim)
            .v_Mau_Nen = CStr(Me.txtMauNen.Text.Trim)
            .i_Type = CInt(Val(Me.txtLoai.Text))
        End With
        objFC.Insert(objEn)
        Response.Redirect("~/DANHMUC/DM_Trangthai.aspx")
    End Sub

    Protected Sub btn_back_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_back.Click
        Response.Redirect("~/DANHMUC/DM_Trangthai.aspx")
    End Sub
End Class