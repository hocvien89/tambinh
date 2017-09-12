Public Partial Class Add_Dinhmuc_GiaMathang
    Inherits System.Web.UI.Page
    Private objFC As New BO.QLMH_DINHMUC_GIAMATHANGFacade
    Private objEn As New CM.QLMH_DINHMUC_GIAMATHANGEntity
    Private objFCMH As New BO.QLMH_DM_MATHANGFacade
    Private objEnMH As New CM.QLMH_DM_MATHANGEntity

    Private oB_Kho As New BO.QLMH_DM_KHOFacade

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Load_DropDownList_Kho()
            LoadMathang()
        End If
    End Sub


    Private Sub LoadMathang()
        If Session("uId_Mathang") <> Nothing Then
            objEnMH = objFCMH.SelectByID(Session("uId_Mathang"))
            txtMathang.Text = objEnMH.nv_TenMathang_vn
        End If
    End Sub
    Private Sub Load_DropDownList_Kho()
        ddlKho.DataSource = oB_Kho.SelectAllTable(Session("uId_Cuahang"))
        ddlKho.DataTextField = "nv_Tenkho_vn"
        ddlKho.DataValueField = "uId_Kho"
        ddlKho.DataBind()
    End Sub


    Protected Sub btn_DsMathang_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_DSMathang.Click

        Response.Write("<script language=javascript> window.open('DS_Mathang.aspx','Window1','menubar=no,width=900,height=500,toolbar=no')</script>")
    End Sub

    Protected Sub btn_ok_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_ok.Click
        Dim sFormat As System.Globalization.DateTimeFormatInfo = New System.Globalization.DateTimeFormatInfo()
        sFormat.ShortDatePattern = "dd/MM/yyyy"
        With objEn
            .uId_Mathang = Session("uId_Mathang")
            .uId_Kho = ddlKho.SelectedValue.ToString
            .d_Ngay = Convert.ToDateTime(txtNgaynhap.Text, sFormat)
            .f_Giaban = CInt(Val(Me.txtGiaxuat.Text.Replace(",", "")))
            .f_Biendo_Giaban = CInt(Val(Me.txtBiendoGiaxuat.Text))
            .f_Gianhap = CInt(Val(Me.txtGianhap.Text.Replace(",", "")))
            .f_Biendo_Gianhap = CInt(Val(Me.txtBiendoGianhap.Text))
        End With
        objFC.Insert(objEn)
        Response.Redirect("~/DANHMUC/Dinhmuc_GiaMathang.aspx")
    End Sub

    Protected Sub btn_Reset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_back.Click
        Response.Redirect("~/DANHMUC/Dinhmuc_GiaMathang.aspx")
    End Sub
End Class