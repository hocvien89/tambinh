Public Class AddChiendich_Phanhoi
    Inherits System.Web.UI.Page
    Private objFCChiendich As BO.MKT_ChiendichDungthuSP
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        load_CT()
        load_CT_ALL()
        de_Ngayphat.Date = Date.Now
    End Sub

    Public Sub refresh()
        txt_Phanhoi.Text = ""
        txt_Tenchuongtrinh.SelectedIndex = -1
        cb_Khachhang.SelectedIndex = -1
        dgvDevexpress.DataSource = New DataTable
        dgvDevexpress.DataBind()
    End Sub

    Protected Sub load_CT_ALL()
        Dim dt As DataTable
        objFCChiendich = New BO.MKT_ChiendichDungthuSP
        dt = objFCChiendich.sp_CTKM_ChiendichMarketing_SelectByTrangthai("ALL")
        Try
            If dt.Rows.Count > 0 Then
                cb_TenCT_Load.DataSource = dt
                cb_TenCT_Load.DataBind()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub load_CT()
        Dim dt As DataTable
        objFCChiendich = New BO.MKT_ChiendichDungthuSP
        dt = objFCChiendich.sp_CTKM_ChiendichMarketing_SelectByTrangthai("TRUE")
        Try
            If dt.Rows.Count > 0 Then
                txt_Tenchuongtrinh.DataSource = dt
                txt_Tenchuongtrinh.DataBind()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btn_Add_Click(sender As Object, e As EventArgs) Handles btn_Add.Click
        objFCChiendich = New BO.MKT_ChiendichDungthuSP
        Dim dt As DataTable = dgvDevexpress.DataSource
        If txt_Tenchuongtrinh.SelectedIndex <> -1 And cb_Khachhang.SelectedIndex <> -1 Then
            objFCChiendich.sp_CTKM_ChiendichMarketing_Chitiet_Phanhoi_Update(txt_Tenchuongtrinh.SelectedItem.Value.ToString(), cb_Khachhang.SelectedItem.Value.ToString(), txt_Phanhoi.Text, Date.Now)
            Response.Write("<script>alert('Phản hồi thành công !')</script>")
            refresh()
        End If
    End Sub

    Protected Sub cb_Khachhang_Callback(sender As Object, e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase) Handles cb_Khachhang.Callback
        objFCChiendich = New BO.MKT_ChiendichDungthuSP
        Dim dt As DataTable = objFCChiendich.sp_CTKM_ChiendichMarketing_KH_SelectById(e.Parameter)
        cb_Khachhang.DataSource = dt
        cb_Khachhang.DataBind()
    End Sub

    Protected Sub dgvDevexpress_CustomCallback(sender As Object, e As DevExpress.Web.ASPxGridView.ASPxGridViewCustomCallbackEventArgs) Handles dgvDevexpress.CustomCallback
        objFCChiendich = New BO.MKT_ChiendichDungthuSP
        Dim dt As DataTable = objFCChiendich.sp_CTKM_ChiendichMarketing_Chitiet_Dichvu_ByID(txt_Tenchuongtrinh.SelectedItem.Value.ToString(), e.Parameters)
        dgvDevexpress.DataSource = dt
        dgvDevexpress.DataBind()
    End Sub

    Protected Sub btn_Refresh_Click(sender As Object, e As EventArgs) Handles btn_Refresh.Click
        refresh()
    End Sub

    Protected Sub dgv_Ds_CustomCallback(sender As Object, e As DevExpress.Web.ASPxGridView.ASPxGridViewCustomCallbackEventArgs) Handles dgv_Ds.CustomCallback
        objFCChiendich = New BO.MKT_ChiendichDungthuSP
        Dim dt As DataTable = objFCChiendich.sp_CTKM_CiendichMarketing_Chitiet_Select_ALL(e.Parameters, "FALSE")
        dgv_Ds.DataSource = dt
        dgv_Ds.DataBind()
    End Sub

    Protected Sub btnQuaylai_Click(sender As Object, e As EventArgs) Handles btnback.Click
        Response.Redirect("AddChiendich.aspx")
    End Sub
End Class