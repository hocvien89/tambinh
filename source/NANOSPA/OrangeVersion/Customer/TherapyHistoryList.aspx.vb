Imports DevExpress.Web.ASPxEditors
Imports System.Data.OleDb
Imports System.IO
Imports DevExpress.Web.ASPxGridView
Public Class TherapyHistoryLis
    Inherits System.Web.UI.Page
    Private objFckhachhang As New BO.CRM_DM_KhachhangFacade
    Private objFcDichvu As New BO.TNTP_DM_DICHVUFacade
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Loadcombodichvu()
            loadTime()
            Loadcombokhachhang()

        End If
        LoadGrid()
        LoadGridByID()
    End Sub
    Private Sub loadTime()
        Aspx_Tungay.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
        Aspx_Denngay.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
    End Sub
#Region "Loaddata"
    Private Sub LoadGrid()
        Dim dt As DataTable   
        objFckhachhang = New BO.CRM_DM_KhachhangFacade
        dt = objFckhachhang.SelectAllTable_Trilieu(DateTime.Now, DateTime.Now)
        Grid_Lieutrinh.DataSource = dt
        Grid_Lieutrinh.DataBind()

    End Sub
   
    Private Sub LoadGridByID()
        Dim dt As DataTable
        Dim TuNgay As DateTime
        Dim DenNgay As DateTime
        Dim uId_Khachhang As String = cbo_Khachhang.SelectedItem.Value.ToString
        Dim uId_Dichvu As String = cbo_Dichvu.SelectedItem.Value.ToString
        TuNgay = Aspx_Tungay.Value.ToString
        DenNgay = Aspx_Denngay.Value.ToString
        If chk_Dichvu.Checked = False And chk_Khachhang.Checked = False Then
            dt = objFckhachhang.SelectByID_Trilieu(TuNgay, DenNgay, uId_Khachhang, uId_Dichvu, 0)
            Grid_Lieutrinh.DataSource = dt
            Grid_Lieutrinh.DataBind()
        ElseIf chk_Khachhang.Checked = True And chk_Dichvu.Checked = False Then
            dt = objFckhachhang.SelectByID_Trilieu(TuNgay, DenNgay, uId_Khachhang, uId_Dichvu, 1)
            Grid_Lieutrinh.DataSource = dt
            Grid_Lieutrinh.DataBind()

        ElseIf chk_Khachhang.Checked = False And chk_Dichvu.Checked = True Then
            dt = objFckhachhang.SelectByID_Trilieu(TuNgay, DenNgay, uId_Khachhang, uId_Dichvu, 2)
            Grid_Lieutrinh.DataSource = dt
            Grid_Lieutrinh.DataBind()

        ElseIf chk_Dichvu.Checked = True And chk_Khachhang.Checked = True Then
            dt = objFckhachhang.SelectByID_Trilieu(TuNgay, DenNgay, uId_Khachhang, uId_Dichvu, 3)
            Grid_Lieutrinh.DataSource = dt
            Grid_Lieutrinh.DataBind()
        End If

    End Sub
    Private Sub Loadcombokhachhang()
        objFckhachhang = New BO.CRM_DM_KhachhangFacade
        Dim dt As DataTable
        dt = objFckhachhang.SelectAllTable_DMKhachhang()
        Try

            Dim item As New ListEditItem
            item.Value = ""
            item.Text = "Tất cả"
            cbo_Khachhang.Items.Add(item)
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    Dim newitem As New ListEditItem
                    newitem.Value = row("uId_Khachhang")
                    newitem.Text = row("nv_Hoten_vn")
                    cbo_Khachhang.Items.Add(newitem)
                Next
            End If
            cbo_Khachhang.SelectedIndex = 0
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Loadcombodichvu()
        objFcDichvu = New BO.TNTP_DM_DICHVUFacade
        Dim dt As DataTable
        dt = objFcDichvu.SelectAllDMDichvu()
        Try

            Dim item As New ListEditItem
            item.Value = ""
            item.Text = "Tất cả"
            cbo_Dichvu.Items.Add(item)
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows

                    Dim newitem As New ListEditItem
                    newitem.Value = row("uId_Dichvu")
                    newitem.Text = row("nv_Tendichvu_vn")
                    cbo_Dichvu.Items.Add(newitem)
                Next
            End If
            cbo_Dichvu.SelectedIndex = 0
        Catch ex As Exception

        End Try
    End Sub
#End Region
#Region "Buttom"
    Protected Sub btn_Baocao_Click(sender As Object, e As EventArgs) Handles btn_Baocao.Click
        LoadGridByID()
    End Sub
  
#End Region

    
    Protected Sub btn_ExportExcel_Click(sender As Object, e As EventArgs) Handles btn_ExportExcel.Click
        ASPxGridViewExporter_Data.WriteXlsToResponse()
    End Sub
    Private Sub btnback_Click(sender As Object, e As EventArgs) Handles btnback.Click
        Response.Redirect("~/OrangeVersion/Customer/ReportForm_Cus.aspx")
    End Sub
End Class