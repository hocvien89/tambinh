Public Class AddChiendich_Dungthu
    Inherits System.Web.UI.Page
    Private objFCMathang As BO.QLMH_DM_MATHANGFacade
    Private objEnMathang As CM.QLMH_DM_MATHANGEntity
    Private objFCChiendich As BO.MKT_ChiendichDungthuSP
    Private objFcKhachhang As BO.CRM_DM_KhachhangFacade
    Private objEnChiendich As CM.IMKT_Chiendichmarketing_Chitiet_Entity
    Public dt As DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        load_KH()
        load_CT()
        load_CT_ALL()
        If Not IsPostBack Then
            dt = New DataTable()
            dt.Columns.Add("uId_Mathang", Type.GetType("System.String"))
            dt.Columns.Add("nv_TenMathang_vn", Type.GetType("System.String"))
            Session("dt_grid") = dt
            de_Ngayphat.Date = Date.Now
        End If
    End Sub

    Protected Sub load_KH()
        objFCChiendich = New BO.MKT_ChiendichDungthuSP
        cb_Khachhang.DataSource = objFCChiendich.TrangThaiKH("hethong")
        cb_Khachhang.DataBind()

    End Sub

    Protected Sub load_DV()
        If txt_Tenchuongtrinh.SelectedIndex <> -1 Then
            Dim dt As DataTable
            objFCChiendich = New BO.MKT_ChiendichDungthuSP
            dt = objFCChiendich.sp_CTKM_ChiendichMarketing_Dichvu_ByID(txt_Tenchuongtrinh.SelectedItem.Value.ToString())
            Try
                If dt.Rows.Count > 0 Then
                    cb_Sanpham.DataSource = dt
                    cb_Sanpham.DataBind()
                End If
            Catch ex As Exception

            End Try
        End If
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

    Protected Sub dgvDevexpress_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles dgvDevexpress.RowDeleting
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

    Protected Sub dgvDevexpress_CustomCallback(sender As Object, e As DevExpress.Web.ASPxGridView.ASPxGridViewCustomCallbackEventArgs) Handles dgvDevexpress.CustomCallback
        Dim t As DataTable = DirectCast(Session("dt_grid"), DataTable)
        Dim kt As Boolean = True
        For i As Integer = 0 To t.Rows.Count - 1
            If t(i)("uId_Mathang").ToString() = e.Parameters Then
                kt = False
            End If
        Next
        If kt = True Then
            load_Grid_DV(e.Parameters)
        End If
    End Sub

    Protected Sub load_Grid_DV(ByVal uId_Mathang As String)
        Dim t As DataTable = DirectCast(Session("dt_grid"), DataTable)
        Dim kt As Boolean = True
        For i As Integer = 0 To t.Rows.Count - 1
            If t(i)("uId_Mathang").ToString() = uId_Mathang Then
                kt = False
            End If
        Next
        If cb_Sanpham.Text <> "" And kt = True Then
            Dim row As DataRow = t.NewRow()
            objFCMathang = New BO.QLMH_DM_MATHANGFacade
            objEnMathang = New CM.QLMH_DM_MATHANGEntity
            objEnMathang = objFCMathang.SelectByID(uId_Mathang)
            row("uId_Mathang") = objEnMathang.uId_Mathang
            row("nv_TenMathang_vn") = objEnMathang.nv_TenMathang_vn
            t.Rows.Add(row)
            Session("dt_grid") = t
            dgvDevexpress.DataSource = t
            dgvDevexpress.DataBind()
        ElseIf kt = False Then
            Response.Write("<script>alert('Sản phẩm đã có !')</script>")
        End If
    End Sub

    Protected Sub loaddl()
        Dim t As DataTable = DirectCast(Session("dt_grid"), DataTable)
        If t.Rows.Count <> 0 Then
            dgvDevexpress.DataSource = t
            dgvDevexpress.DataBind()
        End If
    End Sub

    Protected Sub btn_Refresh_Click(sender As Object, e As EventArgs) Handles btn_Refresh.Click
        refresh()
    End Sub

    Protected Sub refresh()
        txt_Tenchuongtrinh.SelectedIndex = -1
        cb_Sanpham.Items.Clear()
        cb_Sanpham.Text = ""
        Session("dt_grid") = Nothing
        dt = New DataTable()
        dt.Columns.Add("uId_Mathang", Type.GetType("System.String"))
        dt.Columns.Add("nv_TenMathang_vn", Type.GetType("System.String"))
        Session("dt_grid") = dt
        dgvDevexpress.DataSource = New DataTable
        dgvDevexpress.DataBind()
    End Sub

    Protected Sub cb_Sanpham_Callback(sender As Object, e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase) Handles cb_Sanpham.Callback
        Dim dt As DataTable
        objFCChiendich = New BO.MKT_ChiendichDungthuSP
        dt = objFCChiendich.sp_CTKM_ChiendichMarketing_Dichvu_ByID(e.Parameter)
        Try
            If dt.Rows.Count > 0 Then
                cb_Sanpham.DataSource = dt
                cb_Sanpham.DataBind()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btn_Add_Click(sender As Object, e As EventArgs) Handles btn_Add.Click
        objFCChiendich = New BO.MKT_ChiendichDungthuSP
        Dim test As DataTable = objFCChiendich.sp_Check_KH_CTKM_DungthuSP(txt_Tenchuongtrinh.SelectedItem.Value.ToString(), cb_Khachhang.SelectedItem.Value.ToString())

        Dim t As DataTable = DirectCast(Session("dt_grid"), DataTable)
        If test.Rows.Count <> 0 Then
            Response.Write("<script>alert('Khách hàng đã tham gia chương trình này !')</script>")
            refresh()
        ElseIf t.Rows.Count = 0 Then
            Response.Write("<script>alert('Chưa nhập sản phẩm')</script>")
            refresh()
        Else
            Dim dt As DataTable
            dt = objFCChiendich.sp_CTKM_ChiendichMarketing_Chitiet_Insert(txt_Tenchuongtrinh.SelectedItem.Value.ToString(), cb_Khachhang.SelectedItem.Value.ToString(), de_Ngayphat.Date, de_Ngayketthuc.Value)
            For i As Integer = 0 To t.Rows.Count - 1
                objFCChiendich.sp_CTKM_ChiendichMarketing_Chitiet_Dichvu_Insert(dt(0)("uId_ChiendichMarketing_Chitiet").ToString(), t(i)("uId_Mathang").ToString())
            Next
            refresh()
            Response.Write("<script>alert('Nhập thành công ! ')</script>")
        End If
    End Sub

    Protected Sub dgv_Ds_CustomCallback(sender As Object, e As DevExpress.Web.ASPxGridView.ASPxGridViewCustomCallbackEventArgs) Handles dgv_Ds.CustomCallback
        objFCChiendich = New BO.MKT_ChiendichDungthuSP
        Dim dt As DataTable = objFCChiendich.sp_CTKM_CiendichMarketing_Chitiet_Select_ALL(e.Parameters, "TRUE")
        dgv_Ds.DataSource = dt
        dgv_Ds.DataBind()
    End Sub

    Protected Sub btnQuaylai_Click(sender As Object, e As EventArgs) Handles btnback.Click
        Response.Redirect("AddChiendich.aspx")
    End Sub

    Protected Sub dgv_Ds_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        objFCChiendich = New BO.MKT_ChiendichDungthuSP
        Dim uId_Nguon As String
        uId_Nguon = e.Keys(0).ToString
        Try
            objFCChiendich.DeleteByID(uId_Nguon)
            dgv_Ds.CancelEdit()
            e.Cancel = True
            Dim dt As DataTable = objFCChiendich.sp_CTKM_CiendichMarketing_Chitiet_Select_ALL(cb_TenCT_Load.SelectedItem.Value, "TRUE")
            dgv_Ds.DataSource = dt
            dgv_Ds.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub dgv_Ds_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
        objEnChiendich = New CM.MKT_ChiendichMarketing_ChitietEntity
        objFCChiendich = New BO.MKT_ChiendichDungthuSP
        Dim uId_Nguon As String
        uId_Nguon = e.Keys(0).ToString
        Try
            With objEnChiendich
                .uId_ChiendichMarketing_Chitiet = uId_Nguon
                .d_Ngaytang = e.NewValues("d_Ngaytang").ToString
                .d_Ngayketthuc = e.NewValues("d_Ngayketthuc").ToString
            End With
            objFCChiendich.Update(objEnChiendich)
            dgv_Ds.CancelEdit()
            e.Cancel = True
            Dim dt As DataTable = objFCChiendich.sp_CTKM_CiendichMarketing_Chitiet_Select_ALL(cb_TenCT_Load.SelectedItem.Value, "TRUE")
            dgv_Ds.DataSource = dt
            dgv_Ds.DataBind()
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub cb_Khachhang_Callback(sender As Object, e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase)
        objFCChiendich = New BO.MKT_ChiendichDungthuSP
        If ck_Trangthai.Checked = True Then
            cb_Khachhang.DataSource = objFCChiendich.TrangThaiKH("tiemnang")
            cb_Khachhang.DataBind()
        Else
            cb_Khachhang.DataSource = objFCChiendich.TrangThaiKH("hethong")
            cb_Khachhang.DataBind()
        End If
    End Sub
End Class