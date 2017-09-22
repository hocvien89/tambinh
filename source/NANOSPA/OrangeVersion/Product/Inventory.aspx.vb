Imports DevExpress.Web.ASPxEditors
Imports Microsoft.VisualBasic
Imports System.Web.UI
Public Class Inventory
    Inherits System.Web.UI.Page
    Dim objFcDMKho As BO.QLMH_DM_KHOFacade
    Dim objFcDMMathang As BO.QLMH_DM_MATHANGFacade
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            deDenNgay.Date = DateTime.Now
            LoadDropDownlist()
        End If
        LoadDataGrid()
        LoadLayout()
    End Sub
#Region "Load thong tin"
    Private Sub LoadDropDownlist()
        objFcDMKho = New BO.QLMH_DM_KHOFacade
        Dim dt As DataTable
        dt = objFcDMKho.SelectAllTable(Session("uId_Cuahang"))
        'Dim listItem0 As New ListEditItem
        'listItem0.Value = ""
        ''listItem0.Text = "Chọn kho"
        'ddlDsKho.Items.Add(listItem0)
        For Each row As DataRow In dt.Rows
            Dim listItem As New ListEditItem
            listItem.Value = row("uId_Kho")
            listItem.Text = row("nv_Tenkho_vn")
            ddlDsKho.Items.Add(listItem)
        Next
        ddlDsKho.SelectedIndex = 0
    End Sub
    Private Sub LoadDataGrid()
        objFcDMMathang = New BO.QLMH_DM_MATHANGFacade
        Dim dt As DataTable
        dt = objFcDMMathang.Bang_Tonghop_Ton(DateTime.Now, BO.Util.ConvertDateTime(deDenNgay.Text), ddlDsKho.SelectedItem.Value.ToString, Session("uId_Cuahang"))
        dgvDevexpress.DataSource = dt
        dgvDevexpress.DataBind()
        If ddlDsKho.SelectedItem.Text <> "Chọn kho" Then
            dgvDevexpress.Columns(0).Caption = "Tồn số lượng trong kho " & ddlDsKho.SelectedItem.Text & " đến ngày " & deDenNgay.Text
        End If
    End Sub
#End Region
#Region "Button"
    Protected Sub btnFilter_Click(sender As Object, e As EventArgs)
        LoadDataGrid()
    End Sub
    Protected Sub btnExportXLS_Click(sender As Object, e As EventArgs)
        dgvexport.WriteXlsToResponse()
    End Sub
    Private Sub btnback_Click(sender As Object, e As EventArgs) Handles btnback.Click
        Response.Redirect("~/OrangeVersion/Product/ReportForm_Product.aspx")
    End Sub
#End Region
#Region "set layout"
    Private Sub LoadLayout()
        Dim objFcNhanvien As New BO.QT_DM_NHANVIENFacade
        Dim username As String
        username = objFcNhanvien.SelectByID(Session("uId_Nhanvien_Dangnhap")).v_Tendangnhap
        If username.ToLower() = "admin" Then
            dgvDevexpress.Columns("f_GT_Nhap").Visible = True
        Else
            dgvDevexpress.Columns("f_GT_Nhap").Visible = False
        End If
    End Sub
#End Region
End Class