Imports DevExpress.Web.ASPxEditors

Public Class AddCTKM
    Inherits System.Web.UI.Page
    Private objFCGioihanVoucher As BO.MKT_VOUCHER

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadDL()
        LoadDLgrid(cb_Trangthai.SelectedItem.Value.ToString())
    End Sub

    Protected Sub LoadDL()
        Dim DT As DataTable
        objFCGioihanVoucher = New BO.MKT_VOUCHER
        DT = objFCGioihanVoucher.SelectAllTable()
        txt_Gioihan.DataSource = DT
        txt_Gioihan.ValueField = "uId_GioihanVOUCHER"
        txt_Gioihan.TextField = "nv_GioihanVOUCHER"
        txt_Gioihan.DataBind()
        txt_Gioihan.SelectedIndex = 0
    End Sub

    Protected Sub LoadDLgrid(ByVal s_Trangthai As String)
        Dim DT As DataTable
        objFCGioihanVoucher = New BO.MKT_VOUCHER
        DT = objFCGioihanVoucher.sp_CTKM_DM_LoaiVOUCHER_SelectAll(s_Trangthai)
        dgvDevexpress.DataSource = DT
        dgvDevexpress.DataBind()
    End Sub

    Protected Sub btn_Refresh_Click(sender As Object, e As EventArgs) Handles btn_Refresh.Click
        txt_Gia.Text = txt_Mota2.Text = txt_SL.Text = txt_Tenchuongtrinh.Text = ""
        txt_Tenchuongtrinh.Focus()
    End Sub


    Protected Sub btn_Add_Click(sender As Object, e As EventArgs) Handles btn_Add.Click
        If Session("uId_uId_Loaivoucher_Update") = Nothing Then
            Dim a As Boolean = True
            If txt_Gia.Text = String.Empty Then
                a = False
            ElseIf txt_SL.Text = String.Empty Then
                a = False
            ElseIf txt_Tenchuongtrinh.Text = String.Empty Then
                a = False
            End If

            If a = True Then
                objFCGioihanVoucher = New BO.MKT_VOUCHER
                objFCGioihanVoucher.sp_CTKM_DM_LoaiVOUCHER_Insert(txt_Tenchuongtrinh.Text, txt_Mota2.Text, de_Ngaybatdau.Date, de_Ngayketthuc.Date, False, Double.Parse(txt_Gia.Text), Double.Parse(txt_SL.Text), txt_Gioihan.SelectedItem.Value.ToString())
                txt_Gia.Text = ""
                txt_Mota2.Text = ""
                txt_SL.Text = ""
                txt_Tenchuongtrinh.Text = ""
                txt_Gioihan.SelectedIndex = 0
                txt_Tenchuongtrinh.Focus()
            Else
                Response.Write("<script>alert('Điền đủ thông tin !')</script>")
            End If
        Else
            Dim a As Boolean = True
            If txt_Gia.Text = String.Empty Then
                a = False
            ElseIf txt_SL.Text = String.Empty Then
                a = False
            ElseIf txt_Tenchuongtrinh.Text = String.Empty Then
                a = False
            End If

            If a = True Then
                objFCGioihanVoucher = New BO.MKT_VOUCHER
                objFCGioihanVoucher.sp_CTKM_DM_LoaiVOUCHER_Update(Session("uId_uId_Loaivoucher_Update"), txt_Tenchuongtrinh.Text, txt_Mota2.Text, de_Ngaybatdau.Date, de_Ngayketthuc.Date, Double.Parse(txt_Gia.Text), Integer.Parse(txt_SL.Text), txt_Gioihan.SelectedItem.Value.ToString())
                Response.Write("<script>alert('Cập nhật thành công !')</script>")
                txt_Gia.Text = ""
                btn_Add.Text = "Nhập mới"
                txt_Mota2.Text = ""
                txt_SL.Text = ""
                txt_Tenchuongtrinh.Text = ""
                txt_Gioihan.SelectedIndex = 0
                txt_Tenchuongtrinh.Focus()
                Session("uId_uId_Loaivoucher_Update") = Nothing
            Else
                Response.Write("<script>alert('Điền đủ thông tin !')</script>")
            End If
        End If

        LoadDLgrid(cb_Trangthai.SelectedItem.Value.ToString())

    End Sub

    Protected Sub de_Ngayketthuc_DateChanged(sender As Object, e As EventArgs) Handles de_Ngayketthuc.DateChanged

    End Sub

    Protected Sub cb_Trangthai_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_Trangthai.SelectedIndexChanged
        LoadDLgrid(cb_Trangthai.SelectedItem.Value.ToString())
    End Sub

    Protected Sub dgvDevexpress_CustomCallback(sender As Object, e As DevExpress.Web.ASPxGridView.ASPxGridViewCustomCallbackEventArgs) Handles dgvDevexpress.CustomCallback
        Session("uId_uId_Loaivoucher_Update") = e.Parameters
    End Sub

    Protected Sub dgvDevexpress_SelectionChanged(sender As Object, e As EventArgs) Handles dgvDevexpress.SelectionChanged

    End Sub

    Protected Sub btn_Phat_Click(sender As Object, e As EventArgs) Handles btn_Phat.Click
        Response.Redirect("AddVoucher.aspx")
    End Sub

    Protected Sub btn_Thu_Click(sender As Object, e As EventArgs) Handles btn_Thu.Click
        Response.Redirect("ThuVoucher.aspx")
    End Sub

    Protected Sub dgvDevexpress_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles dgvDevexpress.RowDeleting
        objFCGioihanVoucher = New BO.MKT_VOUCHER
        objFCGioihanVoucher.sp_CTKM_DM_LoaiVOUCHER_Delete(e.Keys(0).ToString())
        e.Cancel = True
        LoadDLgrid(cb_Trangthai.SelectedItem.Value.ToString())
    End Sub

End Class