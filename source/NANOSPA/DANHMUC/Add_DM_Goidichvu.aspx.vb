Public Partial Class Add_DM_Goidichvu
    Inherits System.Web.UI.Page
    Private objFC As New BO.TNTP_DM_GOIDICHVUFacade
    Private objEn As New CM.TNTP_DM_GOIDICHVUEntity

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btn_ok_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_ok.Click
        With objEn
            .nv_Tengoi_vn = CStr(Me.txtName.Text.Trim)
        End With
        objFC.Insert(objEn)
        Response.Redirect("~/QUANTRI/Thietlap_GoiDV.aspx")
    End Sub

    Protected Sub btn_back_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_back.Click
        Response.Redirect("~/QUANTRI/Thietlap_GoiDV.aspx")
    End Sub
End Class