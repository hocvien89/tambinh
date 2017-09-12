Partial Public Class Add_DM_Tinhthanh
    Inherits System.Web.UI.Page

    Private objFCQuocgia As New BO.CRM_DM_QUOCGIAFacade
    Private objEnQuocgia As New CM.CRM_DM_QUOCGIAEntity

    Private objFC As New BO.CRM_DM_TINHTHANHFacade
    Private objEn As New CM.CRM_DM_TINHTHANHEntity

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            LoadDropDownList()
        End If
    End Sub

    Private Sub LoadDropDownList()

        ddlQuocgia.DataSource = objFCQuocgia.SelectAllTable()
        ddlQuocgia.DataTextField = "nv_Tenquocgia"
        ddlQuocgia.DataValueField = "uId_Quocgia"
        ddlQuocgia.DataBind()
    End Sub

    Protected Sub btn_ok_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_ok.Click
        With objEn
            .uId_Quocgia = CStr(Me.ddlQuocgia.SelectedValue)
            .v_MaTinhthanh = CStr(Me.txtMa.Text.Trim)
            .nv_Tentinhthanh = CStr(Me.txtTen.Text.Trim)
        End With
        objFC.Insert(objEn)
        Response.Redirect("~/DANHMUC/DM_Tinhthanh.aspx")
    End Sub

    Protected Sub btn_Reset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Reset.Click
        Response.Redirect("~/DANHMUC/DM_Tinhthanh.aspx")
    End Sub


End Class