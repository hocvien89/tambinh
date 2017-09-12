Public Partial Class Add_DM_Dichvu_Congdoan
    Inherits System.Web.UI.Page
    Dim objFCDM_Dichvu As New BO.TNTP_DM_DICHVUFacade
    Dim objEnDM_Dichvu As New CM.TNTP_DM_DICHVUEntity
    Dim objFCCongdoan As New BO.TNTP_QT_DIEUTRI_CONGDOANFacade
    Dim objEnCongdoan As New CM.TNTP_QT_DIEUTRI_CONGDOANEntity
    Dim objEnDMDV_Congdoan As New CM.TNTP_DM_DICHVU_CONGDOANEntity
    Dim objFCDMDV_Congdoan As New BO.TNTP_DM_DICHVU_CONGDOANFacade
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LoadData()
            LoadGrid()
        End If
    End Sub
    Private Sub LoadData()
        If Session("uId_Dichvu") <> Nothing Then
            txtTendichvu.Text = objFCDM_Dichvu.SelectByID(Session("uId_Dichvu").ToString).nv_Tendichvu_vn
        End If
    End Sub
    Private Sub LoadGrid()
        If Session("uId_Dichvu") <> Nothing Then
            Dim dt As DataTable
            dt = objFCDMDV_Congdoan.SelectAllTable(Session("uId_Dichvu").ToString)
            If dt.Rows.Count > 0 Then
                GVCongdoan.DataSource = dt
                GVCongdoan.DataBind()
            Else
                GVCongdoan.DataSource = Nothing
                GVCongdoan.DataBind()
            End If
        End If

    End Sub
    Protected Sub btnLuu_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLuu.Click
        If Session("uId_Dichvu") <> Nothing Then
            Dim uId_Congdoan As String = ""
            With objEnCongdoan
                .nv_Tencongdoan_vn = txtTenCongdoan.Text
            End With
            Try
                uId_Congdoan = objFCCongdoan.Insert(objEnCongdoan)
                If uId_Congdoan <> "" Then
                    With objEnDMDV_Congdoan
                        .uId_Dichvu = Session("uId_Dichvu").ToString
                        .uId_Congdoan = uId_Congdoan
                        .f_TienHH = Convert.ToDouble(txtTienHH.Text.Replace(",", ""))
                        .nv_Ghichu = txtGhichu.Text
                    End With
                    objFCDMDV_Congdoan.Insert(objEnDMDV_Congdoan)
                    txtTenCongdoan.Text = ""
                    txtTienHH.Text = ""
                    txtGhichu.Text = ""
                    txtTenCongdoan.Focus()
                    LoadGrid()
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub
    Protected Sub btnLuuDong_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLuuDong.Click
        ClientScript.RegisterStartupScript(GetType(Page), "ClientScript", "<script>window.close();opener.location='Thietlap_Lieutrinh.aspx?event=refresh';</script>")
    End Sub
    Protected Sub gv_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVCongdoan.RowDeleting
        If GVCongdoan.DataKeys.Count <> 0 Then
            Dim uId_Dichvu As String = GVCongdoan.DataKeys(e.RowIndex).Values("uId_Dichvu").ToString()
            Dim uId_Congdoan As String = GVCongdoan.DataKeys(e.RowIndex).Values("uId_Congdoan").ToString()
            'objFCDMDV_Congdoan.DeleteByID(uId_Dichvu)
            LoadGrid()
        End If
    End Sub
    Protected Sub gv_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GVCongdoan.RowCancelingEdit
        GVCongdoan.EditIndex = -1
        LoadGrid()
    End Sub
    Protected Sub gv_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVCongdoan.RowEditing
        GVCongdoan.EditIndex = e.NewEditIndex
        LoadGrid()
    End Sub
    Protected Sub gv_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GVCongdoan.RowUpdating
        Dim grv As GridViewRow = GVCongdoan.Rows(e.RowIndex)
        Dim uId_Congdoan As String = Convert.ToString(GVCongdoan.DataKeys(e.RowIndex)("uId_Congdoan"))
        Dim uId_Dichvu As String = Convert.ToString(GVCongdoan.DataKeys(e.RowIndex)("uId_Dichvu"))
        With objEnDMDV_Congdoan
            .uId_Dichvu = uId_Dichvu
            .uId_Congdoan = uId_Congdoan
            .f_TienHH = CInt(Val(CType(grv.FindControl("txtTienHH"), TextBox).Text.Replace(",", "")))
            .nv_Ghichu = Val(CType(grv.FindControl("txtGhichu"), TextBox).Text)
        End With
        Try
            objFCDMDV_Congdoan.Update(objEnDMDV_Congdoan)
        Catch ex As Exception

        End Try
        GVCongdoan.EditIndex = -1
        LoadGrid()
        grv = Nothing
    End Sub
End Class