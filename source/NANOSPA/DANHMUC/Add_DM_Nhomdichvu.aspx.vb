Public Partial Class Add_DM_Nhomdichvu
    Inherits System.Web.UI.Page
    Private objFCCuaHang As New BO.QT_DM_CUAHANGFacade
    Private objEnCuaHang As New CM.QT_DM_CUAHANGEntity
    Private objFC As New BO.TNTP_DM_NHOMDICHVUFacade
    Private objEn As New CM.TNTP_DM_NHOMDICHVUEntity

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            LoadDropDownList()

            LoadData()
        End If
    End Sub

    Private Sub LoadData()
        If Session("uId_Nhomdichvu") <> Nothing Then
            objEn = objFC.SelectByID(Session("uId_Nhomdichvu").ToString)
            txtTenNhomdichvu.Text = objEn.nv_TennhomDichvu_vn
            ddlCuaHang.SelectedValue = objEn.uId_Cuahang
            CKENoidung.Text = objEn.nv_Ghichu_vn
            CKENoidungPhu.Text = objEn.nv_Ghichu_en
        End If
    End Sub

    Private Sub LoadDropDownList()

        ddlCuaHang.DataSource = objFCCuaHang.SelectAllTable()
        ddlCuaHang.DataTextField = "nv_Tencuahang_vn"
        ddlCuaHang.DataValueField = "uId_Cuahang"
        ddlCuaHang.DataBind()
        If Session("uId_Cuahang") <> Nothing Then
            ddlCuaHang.SelectedValue = Session("uId_Cuahang")
            ddlCuaHang.Enabled = False
        End If
    End Sub

    Protected Sub btn_ok_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_ok.Click
        With objEn
            .uId_Cuahang = CStr(Me.ddlCuaHang.SelectedValue)
            .nv_TennhomDichvu_vn = CStr(Me.txtTenNhomdichvu.Text.Trim)
            '.nv_Ghichu_vn = CKENoidung.Text
            '.nv_Ghichu_en = CKENoidungPhu.Text
        End With
        If Session("uId_Nhomdichvu") <> Nothing Then
            objEn.uId_Nhomdichvu = Session("uId_Nhomdichvu").ToString
            objFC.Update(objEn)
        Else
            objFC.Insert(objEn)
        End If
        Session("uId_Nhomdichvu") = Nothing
        Response.Redirect("~/DANHMUC/DM_Nhomdichvu.aspx")
    End Sub

    Protected Sub btn_Reset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Reset.Click
        Response.Redirect("~/DANHMUC/DM_Nhomdichvu.aspx")
    End Sub


End Class