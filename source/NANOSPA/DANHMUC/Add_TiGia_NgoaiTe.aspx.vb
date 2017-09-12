Public Partial Class Add_TiGia_NgoaiTe
    Inherits System.Web.UI.Page
    Private objFCTigia As New BO.TNTP_NGOAITE_TYGIAFacade
    Private objEnTigia As New CM.TNTP_NGOAITE_TYGIAEntity
    Private objFCNgoaite As New BO.TNTP_DM_NGOAITEFacade
    Private objEnNgoaite As New CM.TNTP_DM_NGOAITEEntity

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            LoadDdlNgoaite()
        End If
    End Sub

    Private Sub LoadDdlNgoaite()
        ddlNgoaite.DataSource = objFCNgoaite.SelectAllTable
        ddlNgoaite.DataTextField = "v_Ma"
        ddlNgoaite.DataValueField = "uId_Ngoaite"
        ddlNgoaite.DataBind()
    End Sub


    Protected Sub btn_ok_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_ok.Click
        Dim sFormat As System.Globalization.DateTimeFormatInfo = New System.Globalization.DateTimeFormatInfo()
        sFormat.ShortDatePattern = "dd/MM/yyyy"
        With objEnTigia
            .uId_Ngoaite = CStr(Me.ddlNgoaite.SelectedValue)
            .d_Ngay = Convert.ToDateTime(txtNgaynhap.Text, sFormat)
            .f_Tygia_VND = CStr(Me.txtTigia.Text)
        End With
        objFCTigia.Insert(objEnTigia)
        Response.Redirect("~/DANHMUC/TiGia_NgoaiTe.aspx")
    End Sub

    Protected Sub btn_back_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_back.Click
        Response.Redirect("~/DANHMUC/TiGia_NgoaiTe.aspx")
    End Sub


End Class