Public Partial Class Detail_DM_Mathang
    Inherits System.Web.UI.Page
    Private objFCNhommathang As New BO.QLMH_DM_NHOMMATHANGFacade
    Private objEnNhommathang As New CM.QLMH_DM_NHOMMATHANGEntity
    Private objFCLoaimathang As New BO.QLMH_DM_LOAIMATHANGFacade
    Private objEnLoaimathang As New CM.QLMH_DM_LOAIMATHANGEntity
    Private objFCXuatxu As New BO.QLMH_DM_XUATXUFacade
    Private objEnXuatxu As New CM.QLMH_DM_XUATXUEntity
    Private objFC As New BO.QLMH_DM_MATHANGFacade
    Private objEn As New CM.QLMH_DM_MATHANGEntity

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.LoadData()
        End If
        LoadDropDownListLoaimathang()
        LoadDropDownListNhommathang()
        LoadDropDownListXuatxu()
    End Sub

    Private Sub LoadData()
        If Session("uId_Mathang") <> "" Then
            Dim objNew As New CM.QLMH_DM_MATHANGEntity
            objNew = objFC.SelectByID(Session("uId_Mathang"))
            txtDVT.Text = objNew.nv_DVT_vn
            txtGhichu.Text = objNew.nv_Ghichu_vn
            txtHanmucTon.Text = objNew.f_Hanmuc_Ton
            txtHoahongCTV.Text = objNew.f_PhamtramHH_CTV
            txtHoahongKTV.Text = objNew.f_PhantramHH_KTV
            txtHoahongNV.Text = objNew.f_PhantramHH_NV
            txtHoahongTVV.Text = objNew.f_PhantramHH_TVV
            txtHSD.Text = objNew.i_Songaycanhbao_HethanSD
            txtMaMH.Text = objNew.v_MaMathang
            txtTenMH.Text = objNew.nv_TenMathang_vn
            txtTon.Text = objNew.i_Songaycanhbao_Ton
            ddlLoaimathang.SelectedValue = objNew.uId_Loaimathang
            ddlNhommathang.SelectedValue = objNew.uId_Nhommathang
            ddlXuatXu.SelectedValue = objNew.uId_Xuatxu
        End If
    End Sub

    Private Sub LoadDropDownListNhommathang()

        ddlNhommathang.DataSource = objFCNhommathang.SelectAllTable()
        ddlNhommathang.DataTextField = "nv_Tennhommathang_vn"
        ddlNhommathang.DataValueField = "uId_Nhommathang"
        ddlNhommathang.DataBind()
    End Sub


    Private Sub LoadDropDownListLoaimathang()

        ddlLoaimathang.DataSource = objFCLoaimathang.SelectAllTable()
        ddlLoaimathang.DataTextField = "nv_Tenloaimathang_vn"
        ddlLoaimathang.DataValueField = "uId_Loaimathang"
        ddlLoaimathang.DataBind()
    End Sub

    Private Sub LoadDropDownListXuatxu()

        ddlXuatXu.DataSource = objFCXuatxu.SelectAllTable()
        ddlXuatXu.DataTextField = "nv_Tenxuatxu_vn"
        ddlXuatXu.DataValueField = "uid_Xuatxu"
        ddlXuatXu.DataBind()
    End Sub

    Protected Sub btn_ok_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_OK.Click
        Dim objen As New CM.QLMH_DM_MATHANGEntity
        With objen
            .uId_Mathang = Session("uId_Mathang")
            .uId_Loaimathang = CStr(Me.ddlLoaimathang.SelectedValue)
            .uId_Nhommathang = CStr(Me.ddlNhommathang.SelectedValue)
            .uId_Xuatxu = CStr(Me.ddlXuatXu.SelectedValue)
            .v_MaMathang = CStr(Me.txtMaMH.Text.Trim)
            .nv_TenMathang_vn = CStr(Me.txtTenMH.Text.Trim)
            .nv_DVT_vn = CStr(Me.txtDVT.Text.Trim)
            .nv_Ghichu_vn = CStr(Val(Me.txtGhichu.Text.Trim))
            .f_Hanmuc_Ton = CInt(Val(Me.txtHanmucTon.Text.Trim))
            .i_Songaycanhbao_HethanSD = CInt(Val(Me.txtHSD.Text.Trim))
            .i_Songaycanhbao_Ton = CInt(Val(Me.txtTon.Text.Trim))
            .f_PhantramHH_KTV = CInt(Val(Me.txtHoahongKTV.Text.Trim))
            .f_PhamtramHH_CTV = CInt(Val(Me.txtHoahongCTV.Text.Trim))
            .f_PhantramHH_NV = CInt(Val(Me.txtHoahongNV.Text.Trim))
            .f_PhantramHH_TVV = CInt(Val(Me.txtHoahongTVV.Text.Trim))
        End With
        objFC.Update(objen)
        Response.Redirect("~/DANHMUC/DM_Mathang.aspx")
    End Sub

    Protected Sub btn_Reset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Reset.Click
        Response.Redirect("~/DANHMUC/DM_Mathang.aspx")
    End Sub

End Class