Imports DevExpress.Web.ASPxEditors

Public Class rp_Hopdongchamsosausinh
    Inherits System.Web.UI.Page

    Private objFcKhachhang As BO.CRM_DM_KhachhangFacade
    Private objEnKhachhang As CM.CRM_DM_KhachhangEntity

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Loadcombokhachhang()

        End If
        LoadkhachhangbiID()


    End Sub
    Private Sub Loadcombokhachhang()
        Dim objFcKhachhang = New BO.CRM_DM_KhachhangFacade
        Dim dt As DataTable
        Dim item As New ListEditItem
        dt = objFcKhachhang.SelectAllTable_DMKhachhang()
        If dt.Rows.Count > 0 Then
            cbo_khachhang.DataSource = dt
            cbo_khachhang.ValueField = "uId_Khachhang"
            cbo_khachhang.TextField = "nv_Hoten_vn"
            cbo_khachhang.DataBind()
        End If

    End Sub
    Private Sub LoadkhachhangbiID()
        Dim objFcKhachhang = New BO.CRM_DM_KhachhangFacade
        Dim bc As New rpt_Hopdongchamsocsausinh
        Dim dt As DataTable
        If cbo_khachhang.SelectedIndex <> -1 Then
            dt = objFcKhachhang.SelectByIDKhachhangTable(cbo_khachhang.Value.ToString)
            bc.Binddata(dt)
            ReportViewer1.Report = bc
        End If

    End Sub




    Protected Sub btnback_Click(sender As Object, e As EventArgs)
        Response.Redirect("~/OrangeVersion/Customer/Contract_Print.aspx")
    End Sub
End Class