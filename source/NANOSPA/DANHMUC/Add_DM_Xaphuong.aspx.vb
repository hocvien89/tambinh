Partial Public Class Add_DM_Xaphuong
    Inherits System.Web.UI.Page

    Private objFCQuanhuyen As New BO.CRM_DM_QUANHUYENFacade
    Private objEnQuanhuyen As New CM.CRM_DM_QUANHUYENEntity

    Private objFC As New BO.CRM_DM_XAPHUONGFacade
    Private objEn As New CM.CRM_DM_XAPHUONGEntity

    Dim oLib As New Lib_SAT.cls_Pub_Functions


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            LoadDropDownList()
        End If

    End Sub

    Private Sub LoadDropDownList()
        'Lay Tinh Thanh
        Dim suId_Tinhthanh As String = oLib.NullProString(Session("suId_Tinhthanh"))
        ddlQuanhuyen.DataSource = objFCQuanhuyen.SelectAllTable(suId_Tinhthanh)
        ddlQuanhuyen.DataTextField = "nv_TenQuanhuyen"
        ddlQuanhuyen.DataValueField = "uId_Quanhuyen"
        ddlQuanhuyen.DataBind()
        ddlQuanhuyen.SelectedValue = suId_Tinhthanh
    End Sub

    Protected Sub btn_ok_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_ok.Click
        With objEn
            .uId_Quanhuyen = CStr(Me.ddlQuanhuyen.SelectedValue)
            .v_MaXaphuong = CStr(Me.txtMa.Text.Trim)
            .nv_TenXaphuong = CStr(Me.txtTen.Text.Trim)
        End With
        objFC.Insert(objEn)
        Response.Redirect("~/DANHMUC/DM_Xaphuong.aspx")
    End Sub

    Protected Sub btn_Reset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Reset.Click
        Response.Redirect("~/DANHMUC/DM_Xaphuong.aspx")
    End Sub


End Class