Public Partial Class Add_DM_Dichvu
    Inherits System.Web.UI.Page
    Private objFCNhomdichvu As New BO.TNTP_DM_NHOMDICHVUFacade
    Private objEnNhomdichvu As New CM.TNTP_DM_NHOMDICHVUEntity
    Private objFCNgoaite As New BO.TNTP_DM_NGOAITEFacade
    Private objEnNgoaite As New CM.TNTP_DM_NGOAITEEntity
    Private objFC As New BO.TNTP_DM_DICHVUFacade
    Private objEn As New CM.TNTP_DM_DICHVUEntity

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            LoadDropDownListNgoaite()
            LoadDropDownListNhomdichvu()
            LoadData()
        End If
        
    End Sub

    Private Sub LoadDropDownListNhomdichvu()
        ddlNhomdichvu.DataSource = objFCNhomdichvu.SelectAllTable(Session("uId_Cuahang"))
        ddlNhomdichvu.DataTextField = "nv_TennhomDichvu_vn"
        ddlNhomdichvu.DataValueField = "uId_Nhomdichvu"
        ddlNhomdichvu.DataBind()
    End Sub

    Private Sub LoadData()
        If Session("uId_Dichvu") <> Nothing Then
            objEn = objFC.SelectByID(Session("uId_Dichvu").ToString)
            ddlNhomdichvu.SelectedValue = objEn.uId_Nhomdichvu
            ddlMangoaite.SelectedValue = objEn.uId_Ngoaite
            txtTendichvu.Text = objEn.nv_Tendichvu_vn
            txtGia.Text = Format(CType(objEn.f_Gia, Double), "N0")
            txtPhidichvu.Text = Format(CType(objEn.f_Phidichvu, Double), "N0")
            txtChuanbi.Text = objEn.f_Sophutchuanbi.ToString
            txtThuchien.Text = objEn.f_Sophutthuchien.ToString
            txtHoahongCTV.Text = Format(objEn.f_PhantramHH_CTV, "N0")
            txtHoahongKTV.Text = Format(objEn.f_PhantramHH_KTV, "N0")
            txtHoahongNV.Text = Format(objEn.f_PhantramHH_NV, "N0")
            txtHoahongTVV.Text = Format(objEn.f_PhantramHH_TVV, "N0")
            txtSolandieutri.Text = objEn.i_Solan_Dieutri.ToString
            CkThue.Checked = objEn.b_Tinhthue
            CkHoahong.Checked = objEn.b_TinhHoahong
            txtSolandieutri.Text = objEn.i_Solan_Dieutri
            'chkGoiDV.Checked = objEn.b_Goidichvu
        End If
    End Sub

    Private Sub LoadDropDownListNgoaite()
        ddlMangoaite.DataSource = objFCNgoaite.SelectAllTable()
        ddlMangoaite.DataTextField = "v_Ma"
        ddlMangoaite.DataValueField = "uId_Ngoaite"
        ddlMangoaite.DataBind()
    End Sub
    Private Sub Lammoi()
        Session("uId_Dichvu") = Nothing
        txtTendichvu.Text = ""
        txtGia.Text = ""
        txtPhidichvu.Text = ""
        txtChuanbi.Text = ""
        txtThuchien.Text = ""
        txtHoahongCTV.Text = ""
        txtHoahongKTV.Text = ""
        txtHoahongNV.Text = ""
        txtHoahongTVV.Text = ""
        txtSolandieutri.Text = ""
    End Sub
    Protected Sub btn_ok_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_OK.Click
        With objEn
            .uId_Nhomdichvu = CStr(Me.ddlNhomdichvu.SelectedValue)
            .uId_Ngoaite = CStr(Me.ddlMangoaite.SelectedValue)
            .nv_Tendichvu_vn = CStr(Me.txtTendichvu.Text.Trim)
            .f_Gia = CInt(Val(Me.txtGia.Text.Replace(",", "")))
            .f_Phidichvu = CInt(Val(Me.txtPhidichvu.Text.Trim.Replace(",", "")))
            .f_Sophutchuanbi = CInt(Val(Me.txtChuanbi.Text.Trim))
            .f_Sophutthuchien = CInt(Val(Me.txtThuchien.Text.Trim))
            .f_PhantramHH_KTV = CInt(Val(Me.txtHoahongKTV.Text.Trim.Replace(",", "")))
            .f_PhantramHH_CTV = CInt(Val(Me.txtHoahongCTV.Text.Trim.Replace(",", "")))
            .f_PhantramHH_NV = CInt(Val(Me.txtHoahongNV.Text.Trim.Replace(",", "")))
            .f_PhantramHH_TVV = CInt(Val(Me.txtHoahongTVV.Text.Trim.Replace(",", "")))
            .i_Solan_Dieutri = CInt(Val(Me.txtSolandieutri.Text.Trim))
            .b_Tinhthue = CByte(Me.CkThue.Checked)
            .b_TinhHoahong = CByte(Me.CkHoahong.Checked)
            .b_Goidichvu = CBool(.i_Solan_Dieutri > 1)
            .i_Solan_Dieutri = txtSolandieutri.Text
        End With
        If Session("uId_Dichvu") <> Nothing Then
            objEn.uId_Dichvu = Session("uId_Dichvu")
            objFC.Update(objEn)
            Response.Redirect("~/DANHMUC/DM_Dichvu.aspx")
        Else
            If objFC.Insert(objEn) Then
                ShowMessage(Me, "Thêm dịch vụ thành công!")
                Lammoi()
            Else : ShowMessage(Me, "Có lỗi xảy ra!")
            End If
        End If

    End Sub

    Protected Sub btn_Reset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btn_Reset.Click
        Response.Redirect("~/DANHMUC/DM_Dichvu.aspx")
    End Sub

End Class