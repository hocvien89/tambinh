Public Partial Class Add_DM_Nguon
    Inherits System.Web.UI.Page
    Private objFC As New BO.CRM_DM_NGUONFacade
    Private objEn As New CM.CRM_DM_NGUONEntity

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            LoadDdlNguon()
        End If
    End Sub

#Region "Buttons"
    Protected Sub btn_ok_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_ok.Click
        With objEn
            .nv_Nguon_vn = CStr(Me.txtName.Text.Trim)
            .vType = ddl_LoaiDM.SelectedItem.Text
        End With
        objFC.Insert(objEn)
        Response.Redirect("~/DANHMUC/DM_Nguon.aspx")
    End Sub

    Protected Sub btn_back_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_back.Click
        Response.Redirect("~/DANHMUC/DM_Nguon.aspx")
    End Sub
#End Region

#Region "User Functions"
    Private Sub LoadDdlNguon()
        ddl_LoaiDM.DataSource = objFC.SelectAllTable_vType()
        ddl_LoaiDM.DataTextField = "vType"
        ddl_LoaiDM.DataValueField = "vType"
        ddl_LoaiDM.DataBind()
        ddl_LoaiDM = Nothing
    End Sub


#End Region

End Class