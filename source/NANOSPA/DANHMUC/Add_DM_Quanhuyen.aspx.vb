Partial Public Class Add_DM_Quanhuyen
    Inherits System.Web.UI.Page

    Private objFCTinhthanh As New BO.CRM_DM_TINHTHANHFacade
    Private objEnTinhthanh As New CM.CRM_DM_TINHTHANHEntity

    Private objFC As New BO.CRM_DM_QUANHUYENFacade
    Private objEn As New CM.CRM_DM_QUANHUYENEntity

    Dim oLib As New Lib_SAT.cls_Pub_Functions


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            LoadDropDownList()
        End If

    End Sub

    Private Sub LoadDropDownList()
        'Lay Uid_Quocgia, Tinh Thanh
        Dim suId_Quocgia As String = oLib.NullProString(Session("suId_Quocgia"))
        Dim suId_Tinhthanh As String = oLib.NullProString(Session("suId_Tinhthang"))

        ddlTinhthanh.DataSource = objFCTinhthanh.SelectAllTable(suId_Quocgia)
        ddlTinhthanh.DataTextField = "nv_TenTinhthanh"
        ddlTinhthanh.DataValueField = "uId_Tinhthanh"
        ddlTinhthanh.DataBind()
        ddlTinhthanh.SelectedValue = suId_Tinhthanh
    End Sub

    Protected Sub btn_ok_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_ok.Click
        With objEn
            .uId_Tinhthanh = CStr(Me.ddlTinhthanh.SelectedValue)
            .v_MaQuanhuyen = CStr(Me.txtMa.Text.Trim)
            .nv_Tenquanhuyen = CStr(Me.txtTen.Text.Trim)
        End With
        objFC.Insert(objEn)
        Response.Redirect("~/DANHMUC/DM_Quanhuyen.aspx")
    End Sub

    Protected Sub btn_Reset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Reset.Click
        Response.Redirect("~/DANHMUC/DM_Quanhuyen.aspx")
    End Sub


End Class