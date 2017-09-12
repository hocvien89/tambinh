Partial Public Class Add_DM_Quocgia
    Inherits System.Web.UI.Page

    Private objFC As New BO.CRM_DM_QUOCGIAFacade
    Private objEn As New CM.CRM_DM_QUOCGIAEntity

    Protected Sub btn_ok_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_ok.Click
        With objEn
            .v_MaQuocgia = CStr(Me.txtMa.Text.Trim)
            .nv_TenQuocgia = CStr(Me.txtTen.Text.Trim)
        End With
        objFC.Insert(objEn)
        Response.Redirect("~/DANHMUC/DM_Quocgia.aspx")
    End Sub

    Protected Sub btn_Reset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Reset.Click
        Response.Redirect("~/DANHMUC/DM_Quocgia.aspx")
    End Sub


End Class