Public Partial Class Add_DM_Loaithe
    Inherits System.Web.UI.Page

    Dim objFC As New BO.TNTP_DM_LOAITHEFacade
    Dim objEn As New CM.TNTP_DM_LOAITHEEntity

    Dim oLib As New Lib_SAT.cls_Pub_Functions


    Protected Sub btn_ok_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_ok.Click
        With objEn
            .nv_Tenloaithe_vn = CStr(Me.txtName.Text.Trim)
            .f_Sotiendinhmuc = oLib.NullProNumber(Me.txtSotien.Text)
            .f_Phantramchietkhau = oLib.NullProNumber(txtPhantram.Text)
        End With
        objFC.Insert(objEn)
        Response.Redirect("~/QUANTRI/Thietlap_TheDV.aspx")
    End Sub

    Protected Sub btn_back_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_back.Click
        Response.Redirect("~/QUANTRI/Thietlap_TheDV.aspx")
    End Sub

    Protected Sub txt_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtSotien.TextChanged
        If txtSotien.Text.Trim = "" Then
            txtSotien.Text = "0"
        Else
            txtSotien.Text = Format(CType(txtSotien.Text, Double), "N0")
        End If
    End Sub
End Class