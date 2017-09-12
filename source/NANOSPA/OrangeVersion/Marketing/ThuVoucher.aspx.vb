Public Class ThuVoucher
    Inherits System.Web.UI.Page
    Private objFCGioihanVoucher As BO.MKT_VOUCHER
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txt_MaVoucher.Focus()
            LoadDLgrid("TRUE")
        End If
    End Sub

    Protected Sub LoadDLgrid(ByVal b_Trangthai As String)
        If b_Trangthai = "TRUE" Then
            lbl_Alert.Text = "Danh sách Voucher chưa thu về"
        Else
            lbl_Alert.Text = "Danh sách Voucher đã thu về"
        End If
        Dim DT As DataTable
        objFCGioihanVoucher = New BO.MKT_VOUCHER
        DT = objFCGioihanVoucher.sp_CTKM_VOUCHER_SELECTALLTABLEbyTrangthai(b_Trangthai)
        dgvDevexpress.DataSource = DT
        dgvDevexpress.DataBind()
    End Sub

    Protected Sub btn_Tim_Click(sender As Object, e As EventArgs) Handles btn_Tim.Click
        If txt_MaVoucher.Text <> String.Empty Then
            objFCGioihanVoucher = New BO.MKT_VOUCHER
            Dim dt As DataTable
            dt = objFCGioihanVoucher.sp_CTKM_VOUCHER_SelectByMaVoucher(txt_MaVoucher.Text, "TRUE")
            Try
                If dt.Rows.Count > 0 Then
                    txt_MaKH.Text = dt(0)("v_Makhachang").ToString()
                    txt_Ngaybatdau.Date = Date.Parse(dt(0)("d_Ngaybatdau").ToString())
                    txt_Ngayketthuc.Date = Date.Parse(dt(0)("d_Ngayketthuc").ToString())
                    txt_TenKH.Text = dt(0)("nv_Hoten_vn").ToString()
                    txt_Tenchuongtrinh.Text = dt(0)("nv_Tenloaivoucher").ToString()
                    txt_Menhgia.Text = dt(0)("f_Menhgia").ToString()
                    txt_Ngayphat.Date = Date.Parse(dt(0)("d_Ngayphat").ToString())

                Else
                    Response.Write("<script>alert('Không tồn tại hoặc đã được sử dụng !')</script>")
                    txt_MaVoucher.Text = ""
                    txt_MaKH.Text = ""
                    txt_Menhgia.Text = ""
                    txt_Tenchuongtrinh.Text = ""
                    txt_TenKH.Text = ""
                    txt_Ngaybatdau.Text = ""
                    txt_Ngayketthuc.Text = ""
                    txt_Ngayphat.Text = ""
                    txt_MaVoucher.Text = ""
                    txt_MaVoucher.Focus()
                End If
            Catch ex As Exception

            End Try
        Else
            Response.Write("<script>alert('Điền mã voucher !')</script>")
            txt_MaVoucher.Focus()
        End If
    End Sub

    Protected Sub btn_Add_Click(sender As Object, e As EventArgs) Handles btn_Add.Click
        objFCGioihanVoucher = New BO.MKT_VOUCHER
        Dim dt As DataTable
        dt = objFCGioihanVoucher.sp_CTKM_VOUCHER_SelectByMaVoucher(txt_MaVoucher.Text, "TRUE")
        Try
            If dt.Rows.Count > 0 Then
                objFCGioihanVoucher.sp_CTKM_VOUCHER_Update(txt_MaVoucher.Text, Date.Now)
                txt_MaVoucher.Text = ""
                txt_MaKH.Text = ""
                txt_Menhgia.Text = ""
                txt_Tenchuongtrinh.Text = ""
                txt_TenKH.Text = ""
                txt_Ngaybatdau.Text = ""
                txt_Ngayketthuc.Text = ""
                txt_Ngayphat.Text = ""
                txt_MaVoucher.Focus()
                Response.Write("<script>alert('Thu hồi thành công !')</script>")


            Else
                Response.Write("<script>alert('Không tồn tại hoặc đã được sử dụng !')</script>")
                txt_MaVoucher.Text = ""
                txt_MaKH.Text = ""
                txt_Menhgia.Text = ""
                txt_Tenchuongtrinh.Text = ""
                txt_TenKH.Text = ""
                txt_Ngaybatdau.Text = ""
                txt_Ngayketthuc.Text = ""
                txt_Ngayphat.Text = ""
                txt_MaVoucher.Focus()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub btnQuaylai_Click(sender As Object, e As EventArgs) Handles btnback.Click
        Response.Redirect("AddCTKM.aspx")
    End Sub

    Protected Sub dgvDevexpress_CustomCallback(sender As Object, e As DevExpress.Web.ASPxGridView.ASPxGridViewCustomCallbackEventArgs) Handles dgvDevexpress.CustomCallback
        LoadDLgrid(e.Parameters)
    End Sub
End Class