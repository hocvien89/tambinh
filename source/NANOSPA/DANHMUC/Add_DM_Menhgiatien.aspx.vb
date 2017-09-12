Public Partial Class Add_DM_Menhgiatien
    Inherits System.Web.UI.Page
    Private objFCNgoaite As New BO.TNTP_DM_NGOAITEFacade
    Private objEnNgoaite As New CM.TNTP_DM_NGOAITEEntity
    Private objEnMenhGia As New CM.TNTP_DM_MENHGIATIENEntity
    Private objFCMenhgia As New BO.TNTP_DM_MENHGIATIENFacade

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            LoadddlNgoaite()
            If Session("uId_Menhgiatien") <> Nothing Then
                objEnMenhGia = objFCMenhgia.SelectByID(Session("uId_Menhgiatien"))
                ddlNgoaite.SelectedValue = objEnMenhGia.uId_Ngoaite
                txtMenhgia.Text = objEnMenhGia.f_Menhgia
            End If
        End If
    End Sub
    Private Sub LoadddlNgoaite()
        Dim dt As New DataTable
        dt = objFCNgoaite.SelectAllTable()
        If dt.Rows.Count = 0 Then
            dt.Rows.Add(dt.NewRow())
        End If
        ddlNgoaite.DataSource = dt
        ddlNgoaite.DataValueField = "uId_Ngoaite"
        ddlNgoaite.DataTextField = "v_Ma"
        ddlNgoaite.DataBind()
    End Sub
    Protected Sub btn_Them_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_ok.Click
        With objEnMenhGia
            .f_Menhgia = CDbl(txtMenhgia.Text.Replace(",", ""))
            .uId_Ngoaite = ddlNgoaite.SelectedValue
        End With
        If Session("uId_Menhgiatien") <> Nothing Then
            objEnMenhGia.uId_Menhgiatien = Session("uId_Menhgiatien")
            If objFCMenhgia.Update(objEnMenhGia) Then
                ShowMessage(Me, "Cập nhật thành công!")
                txtMenhgia.Text = ""
                Session("uId_Menhgiatien") = Nothing
            Else : ShowMessage(Me, "Có lỗi xảy ra!")
            End If
        Else : If objFCMenhgia.Insert(objEnMenhGia) Then
                ShowMessage(Me, "Thêm mới thành công!")
                txtMenhgia.Text = ""
                Session("uId_Menhgiatien") = Nothing
            Else : ShowMessage(Me, "Có lỗi xảy ra!")
            End If
        End If
    End Sub
    Protected Sub btn_Back_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_back.Click
        Response.Redirect("DM_Menhgiatien.aspx")
    End Sub
End Class