Imports DevExpress.XtraReports.UI
Imports DevExpress.Web.ASPxEditors

Public Class rp_SchedulerReport
    Inherits System.Web.UI.Page

    Dim objFcCuahang As New BO.QT_DM_CUAHANGFacade
    Dim objFcAppoint As New BO.AppointmentsFacade
    Dim objFcResources As New BO.ResourcesFacade
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            deTuNgay.Date = DateTime.Now
            deDenNgay.Date = DateTime.Now
            LoadDropDownList()
        End If
        LoadData()
    End Sub
    Private Sub LoadDropDownList()
        objFcCuahang = New BO.QT_DM_CUAHANGFacade
        Dim dt As DataTable
        Dim dt_Phong As DataTable
        dt_Phong = objFcResources.SelectAllTable()
        dt = objFcCuahang.SelectAllTable()
        Try
            If dt_Phong.Rows.Count > 0 Then
                    Dim item As New ListEditItem
                    item.Value = ""
                    item.Text = "Tất cả"
                    cb_Phong.Items.Add(item)
                    For Each row As DataRow In dt_Phong.Rows
                        Dim items As New ListEditItem
                        items.Value = row("ResourceID")
                        items.Text = row("ResourceName")
                        cb_Phong.Items.Add(items)
                    Next
            End If
        Catch ex As Exception
        End Try
        ddlCuahang.DataSource = dt
        ddlCuahang.TextField = "nv_Tencuahang_vn"
        ddlCuahang.ValueField = "uId_Cuahang"
        ddlCuahang.DataBind()
        ddlCuahang.Value = Session("uId_Cuahang")
    End Sub
    Private Sub LoadData()
        Dim nv_tenkhachhang_vn As String = ""
        If txtTenkhachhang.Text <> "" Then
            nv_tenkhachhang_vn = txtTenkhachhang.Text
        End If
        Dim rpt As rpt_scheduler = New rpt_scheduler
        rpt.BindData(ddlCuahang.SelectedItem.Value, deTuNgay.Text, deDenNgay.Text, Session("nv_Tencuahang_vn"), Session("nv_DiachiCH_vn"), Integer.Parse(ddlTrangthai.SelectedItem.Value), nv_tenkhachhang_vn, cb_Phong.SelectedItem.Value)
        ReportViewer1.Report = rpt
    End Sub

    Protected Sub btnFilter_Click(sender As Object, e As EventArgs)
        LoadData()
    End Sub
End Class