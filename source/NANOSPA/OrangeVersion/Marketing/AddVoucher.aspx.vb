Public Class AddVoucher
    Inherits System.Web.UI.Page
    Private objFCGioihanVoucher As BO.MKT_VOUCHER
    Private objFcKhachhang As BO.CRM_DM_KhachhangFacade
    Private objEnGioihanvoucher As CM.IMKT_VOUCHER
    Private objFCChiendich As BO.MKT_ChiendichDungthuSP

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            LoadDLgrid()
            cbo_loadKH()
        End If
        Load_Loaivoucher()


    End Sub

    Protected Sub btn_Refresh_Click(sender As Object, e As EventArgs) Handles btn_Refresh.Click
        txt_MaVoucher.Text = ""
        txt_MaVoucher.Focus()
    End Sub

    Protected Sub LoadDLgrid()
        Dim DT As DataTable
        objFCGioihanVoucher = New BO.MKT_VOUCHER
        DT = objFCGioihanVoucher.sp_CTKM_VOUCHER_SELECTALLTABLE
        dgvDevexpress.DataSource = DT
        dgvDevexpress.DataBind()
    End Sub

    Private Sub cbo_loadKH()
        objFCChiendich = New BO.MKT_ChiendichDungthuSP
        txt_Khachhang.DataSource = objFCChiendich.TrangThaiKH("hethong")
        txt_Khachhang.DataBind()
    End Sub

    Protected Sub Load_Loaivoucher()
        Dim DT As DataTable
        objFCGioihanVoucher = New BO.MKT_VOUCHER
        DT = objFCGioihanVoucher.sp_CTKM_DM_LoaiVOUCHER_SelectAll("TRUE")
        Try
            If DT.Rows.Count > 0 Then
                txt_Tenchuongtrinh.DataSource = DT
                txt_Tenchuongtrinh.DataBind()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btn_Add_Click(sender As Object, e As EventArgs) Handles btn_Add.Click
        objFCGioihanVoucher = New BO.MKT_VOUCHER
        If txt_MaVoucher.Text = String.Empty Then
            Response.Write("<script>alert('Nhập mã voucher !')</script>")
            txt_MaVoucher.Focus()
        Else
            Dim ds1 As DataTable
            ds1 = objFCGioihanVoucher.sp_CTKM_VOUCHER_SelectByMaVoucher(txt_MaVoucher.Text, "TRUE")
            Dim ds2 As DataTable
            ds2 = objFCGioihanVoucher.sp_CTKM_VOUCHER_SelectByMaVoucher(txt_MaVoucher.Text, "FAULT")
            If ds1.Rows.Count <> 0 Or ds2.Rows.Count <> 0 Then
                Response.Write("<script>alert('Mã đã có hoặc đã sử dụng !')</script>")
                txt_MaVoucher.Text = ""
                txt_MaVoucher.Focus()
            Else
                Dim a As Boolean
                If txt_Khachhang.SelectedIndex <> -1 Then
                    objFCGioihanVoucher = New BO.MKT_VOUCHER
                    a = objFCGioihanVoucher.sp_CTKM_VOUCHER_Insert(txt_Tenchuongtrinh.SelectedItem.Value.ToString(), txt_MaVoucher.Text, txt_Khachhang.SelectedItem.Value.ToString(), de_Ngayphat.Value, de_Ngayketthuc.Value)
                    Response.Write("<script>alert('Thêm thành công !')</script>")
                    txt_MaVoucher.Text = ""
                Else
                    Response.Write("<script>alert('Chọn khách hàng muốn phát !')</script>")
                    txt_Khachhang.Focus()
                End If
            End If
        End If
        LoadDLgrid()
    End Sub

    Protected Sub btnQuaylai_Click(sender As Object, e As EventArgs) Handles btnback.Click
        Response.Redirect("AddCTKM.aspx")
    End Sub

    Protected Sub dgvDevexpress_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        objFCGioihanVoucher = New BO.MKT_VOUCHER
        Dim uId_voucher As String
        uId_voucher = e.Keys(0).ToString
        Try
            objFCGioihanVoucher.DeleteByID(uId_voucher)
            dgvDevexpress.CancelEdit()
            e.Cancel = True
            LoadDLgrid()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub dgvDevexpress_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
        objEnGioihanvoucher = New CM.MKT_VOUCHEREntity
        objFCGioihanVoucher = New BO.MKT_VOUCHER

        Dim uId_Nguon As String

        uId_Nguon = e.Keys(0).ToString
        Try
            With objEnGioihanvoucher
                .uId_voucher = uId_Nguon
                .d_Ngayphat = e.NewValues("d_Ngayphat").ToString
                .d_Ngaykethuc = e.NewValues("d_Ngayketthuc").ToString
                .v_Maloaivoucher = e.NewValues("v_Mavoucher").ToString
            End With
            objFCGioihanVoucher.Update_Obj(objEnGioihanvoucher)
            dgvDevexpress.CancelEdit()
            e.Cancel = True
            LoadDLgrid()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub txt_Khachhang_Callback(sender As Object, e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase)
        objFCChiendich = New BO.MKT_ChiendichDungthuSP
        If ck_Check.Checked = True Then
            txt_Khachhang.DataSource = objFCChiendich.TrangThaiKH("tiemnang")
            txt_Khachhang.DataBind()
        Else
            txt_Khachhang.DataSource = objFCChiendich.TrangThaiKH("hethong")
            txt_Khachhang.DataBind()
        End If
    End Sub
End Class