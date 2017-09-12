Imports DevExpress.Web.ASPxEditors

Public Class AddChiendich
    Inherits System.Web.UI.Page
    Private objFCChiendich As BO.MKT_ChiendichDungthuSP
    Private objFCMathang As BO.QLMH_DM_MATHANGFacade
    Private objEnMathang As CM.QLMH_DM_MATHANGEntity
    Private objFCNhatKy As New BO.NHATKYSUDUNGFacade
    Public dt As DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            loadChiendich()
            de_Ngaybatdau.Date = Date.Now
            de_Ngayketthuc.Date = Date.Now
            loadcb(cb_TagSP.Text)
            dt = New DataTable()
            dt.Columns.Add("uId_Mathang", Type.GetType("System.String"))
            dt.Columns.Add("nv_TenMathang_vn", Type.GetType("System.String"))
            Session("dt_grid") = dt
        End If
    End Sub

    Protected Sub btn_Refresh_Click(sender As Object, e As EventArgs)
        refresh()
    End Sub

    Protected Sub refresh()
        btn_Add.Text = "Nhập mới"
        txt_mota2.Text = ""
        txt_Tenchuongtrinh.Text = ""
        de_Ngaybatdau.Date = Date.Now
        de_Ngayketthuc.Date = Date.Now
        cb_TagSP.Items.Clear()
        cb_TagSP.Text = ""
        loadcb(cb_TagSP.Text)
        Session("dt_grid") = Nothing
        dgvDevexpress2.DataSource = New DataTable
        dgvDevexpress2.DataBind()
        dt = New DataTable()
        dt.Columns.Add("uId_Mathang", Type.GetType("System.String"))
        dt.Columns.Add("nv_TenMathang_vn", Type.GetType("System.String"))
        Session("dt_grid") = dt
    End Sub

    Protected Sub btn_Add_Click(sender As Object, e As EventArgs) Handles btn_Add.Click
        Dim t As DataTable = DirectCast(Session("dt_grid"), DataTable)
        objFCChiendich = New BO.MKT_ChiendichDungthuSP
        Dim rowcount As Int32 = t.Rows.Count
        If txt_Tenchuongtrinh.Text = String.Empty Then
            Response.Write("<script>alert('Chưa nhập tên chương trình !')</script>")
        ElseIf rowcount = 0 Then
            Response.Write("<script>alert('Chưa nhập sản phẩm !')</script>")
        ElseIf Session("uId_ChiendichMarketing_Update") <> "" Then
            objFCChiendich.sp_CTKM_ChiendichMarketing_update_Main(Session("uId_ChiendichMarketing_Update").ToString(), txt_Tenchuongtrinh.Text, de_Ngaybatdau.Date, de_Ngayketthuc.Date, txt_mota2.Text)
            objFCChiendich.sp_CTKM_ChiendichMarketing_Update(Session("uId_ChiendichMarketing_Update").ToString())
            For i As Int32 = 0 To rowcount - 1 Step 1
                objFCChiendich.CTKM_ChiendichMarketing_Dichvu_Insert(Session("uId_ChiendichMarketing_Update").ToString(), t(i)("uId_Mathang").ToString())
            Next
            Response.Write("<script>alert('Cập nhật thành công !')</script>")
            objFCNhatKy.Write(Session("sTendangnhap"), System.Environment.MachineName, "Tài khoản : " & Session("sTendangnhap") & " sửa chiến dịch dùng thử sản phẩm : " & txt_Tenchuongtrinh.Text)
            Session("uId_ChiendichMarketing_Update") = ""
            btn_Add.Text = "Nhập mới"
            refresh()
        Else
            Dim dt As DataTable = objFCChiendich.sp_CTKM_ChiendichMarketing_Insert(txt_Tenchuongtrinh.Text, de_Ngaybatdau.Date, de_Ngayketthuc.Date, txt_mota2.Text)
            Dim uId_ChiendichMarketing As String = dt(0)("uId_ChiendichMarketing").ToString()
            For i As Int32 = 0 To rowcount - 1 Step 1
                objFCChiendich.CTKM_ChiendichMarketing_Dichvu_Insert(uId_ChiendichMarketing, t(i)("uId_Mathang").ToString())
            Next
            Response.Write("<script>alert('Khởi tạo thành công !')</script>")
            objFCNhatKy.Write(Session("sTendangnhap"), System.Environment.MachineName, "Tài khoản : " & Session("sTendangnhap") & " thêm mới chiến dịch dùng thử sản phẩm : " & txt_Tenchuongtrinh.Text)
            refresh()
            loadChiendich()
        End If
    End Sub

    Protected Sub loadcb(ByVal nv_TenMathang_vn As String)
        objFCMathang = New BO.QLMH_DM_MATHANGFacade
        cb_TagSP.DataSource = objFCMathang.SelectTimKiem("0", "0", nv_TenMathang_vn)
        cb_TagSP.TextField = "nv_TenMathang_vn"
        cb_TagSP.ValueField = "uId_Mathang"
        cb_TagSP.DataBind()
        Dim item As New ListEditItem
        item.Value = "0"
        item.Text = ""
        cb_TagSP.Items.Insert(0, item)
        cb_TagSP.SelectedIndex = 0
    End Sub

    Protected Sub Load_DL_click()

    End Sub

    Protected Sub load_Grid_DV(ByVal uId_Mathang As String)
        Dim t As DataTable = DirectCast(Session("dt_grid"), DataTable)
        Dim kt As Boolean = True
        For i As Integer = 0 To t.Rows.Count - 1
            If t(i)("uId_Mathang").ToString() = uId_Mathang Then
                kt = False
            End If
        Next
        If cb_TagSP.Text <> "" And kt = True Then
            Dim row As DataRow = t.NewRow()
            objFCMathang = New BO.QLMH_DM_MATHANGFacade
            objEnMathang = New CM.QLMH_DM_MATHANGEntity
            objEnMathang = objFCMathang.SelectByID(uId_Mathang)
            row("uId_Mathang") = objEnMathang.uId_Mathang
            row("nv_TenMathang_vn") = objEnMathang.nv_TenMathang_vn
            t.Rows.Add(row)
            Session("dt_grid") = t
            dgvDevexpress2.DataSource = t
            dgvDevexpress2.DataBind()
        ElseIf kt = False Then
            Response.Write("<script>alert('Sản phẩm đã có !')</script>")
        End If
    End Sub

    Protected Sub loaddl()
        Dim t As DataTable = DirectCast(Session("dt_grid"), DataTable)
        If t.Rows.Count <> 0 Then
            dgvDevexpress2.DataSource = t
            dgvDevexpress2.DataBind()
        End If
    End Sub

    Protected Sub dgvDevexpress_CustomCallback(sender As Object, e As DevExpress.Web.ASPxGridView.ASPxGridViewCustomCallbackEventArgs) Handles dgvDevexpress2.CustomCallback
        Dim t As DataTable = DirectCast(Session("dt_grid"), DataTable)
        objFCChiendich = New BO.MKT_ChiendichDungthuSP
        Dim dt As DataTable = objFCChiendich.sp_CTKM_ChiendichMarketing_Dichvu_SelectByID(e.Parameters)
        If dt.Rows.Count > 0 Then
            dgvDevexpress2.DataSource = Nothing
            dgvDevexpress2.DataBind()
            dgvDevexpress2.DataSource = dt
            dgvDevexpress2.DataBind()
            Session("uId_ChiendichMarketing_Update") = e.Parameters
            Session("dt_grid") = dt
        Else
            Dim kt As Boolean = True
            If t.Rows.Count > 0 Then
                For i As Integer = 0 To t.Rows.Count - 1
                    If t(i)("uId_Mathang").ToString() = e.Parameters Then
                        kt = False
                    End If
                Next
            End If
            If kt = True Then
                load_Grid_DV(e.Parameters)
            End If
        End If
    End Sub

    Protected Sub dgvDevexpress_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles dgvDevexpress2.RowDeleting
        Dim t As DataTable = DirectCast(Session("dt_grid"), DataTable)
        Dim vt As Integer
        For i As Integer = 0 To t.Rows.Count - 1
            If t(i)("uId_Mathang").ToString() = e.Keys(0).ToString() Then
                vt = i
            End If
        Next
        t.Rows.RemoveAt(vt)
        Session("dt_grid") = t
        e.Cancel = True
        loaddl()
    End Sub

    Protected Sub loadChiendich()
        objFCChiendich = New BO.MKT_ChiendichDungthuSP
        Dim dt As DataTable = objFCChiendich.sp_CTKM_ChiendichMarketing_SelectByTrangthai(cb_Trangthai.SelectedItem.Value.ToString())
        dgv1.DataSource = dt
        dgv1.DataBind()
    End Sub

    Protected Sub dgv1_CustomCallback(sender As Object, e As DevExpress.Web.ASPxGridView.ASPxGridViewCustomCallbackEventArgs) Handles dgv1.CustomCallback
        loadChiendich()
    End Sub

    Protected Sub btn_Phat_Click(sender As Object, e As EventArgs) Handles btn_Phat.Click
        Response.Redirect("AddChiendich_Dungthu.aspx")
    End Sub

    Protected Sub btn_Thu_Click(sender As Object, e As EventArgs) Handles btn_Thu.Click
        Response.Redirect("AddChiendich_Phanhoi.aspx")
    End Sub

    Protected Sub dgv1_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles dgv1.RowDeleting
        objFCChiendich = New BO.MKT_ChiendichDungthuSP
        objFCChiendich.CTKM_ChiendichMarketing_Delete(e.Keys(0).ToString())
        e.Cancel = True
        Response.Write("alert('Xóa thành công !')")
        loadChiendich()
    End Sub
End Class