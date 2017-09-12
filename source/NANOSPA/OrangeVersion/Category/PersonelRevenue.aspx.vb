Imports DevExpress.Web.ASPxGridView
Imports DevExpress.Web.ASPxEditors

Public Class PersonelRevenue
    Inherits System.Web.UI.Page
    Private objFcNhanvien As BO.QT_DM_NHANVIENFacade
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            loadTime()
            LoadNhanvien()
            cboNhanvien.SelectedIndex = 0
        End If
        GridNV()
    End Sub
#Region "Load data"
    Private Function GetNhanvienDT() As DataTable
        Dim dt As New DataTable
        Dim uId_Nhanvien As String
        objFcNhanvien = New BO.QT_DM_NHANVIENFacade
        Dim tungay As DateTime
        Dim denngay As DateTime
        tungay = Aspx_Tungay.Value
        denngay = Aspx_Denngay.Value
        If cboNhanvien.SelectedIndex = 0 Then
            uId_Nhanvien = ""
        Else
            uId_Nhanvien = cboNhanvien.Value
        End If
        Try
            dt = objFcNhanvien.BcDoanhthuTong(tungay, denngay, uId_Nhanvien)
            If dt.Rows.Count = 0 Then
                dt.Rows.Add(dt.NewRow)
            End If
        Catch ex As Exception

        End Try
        Return dt
    End Function

    Private Sub GridNV()
        Dim dt As DataTable
        dt = GetNhanvienDT()
        Grid_Doanhthunhanvien.DataSource = dt
        Grid_Doanhthunhanvien.DataBind()
        dt = Nothing
    End Sub

    Private Function GetHHPhieudv(uId_Nhanvien As String) As DataTable
        Dim dt As New DataTable
        objFcNhanvien = New BO.QT_DM_NHANVIENFacade
        Dim tungay As DateTime
        Dim denngay As DateTime
        tungay = Aspx_Tungay.Value
        denngay = Aspx_Denngay.Value
        Try
            dt = objFcNhanvien.HHPhieudv(tungay, denngay, uId_Nhanvien)
        Catch ex As Exception

        End Try
        Return dt
    End Function

    Private Function GetHHphieuthuchi(uId_Nhanvien As String) As DataTable
        Dim dt As New DataTable
        objFcNhanvien = New BO.QT_DM_NHANVIENFacade
        Dim tungay As DateTime
        Dim denngay As DateTime
        tungay = Aspx_Tungay.Value
        denngay = Aspx_Denngay.Value
        Try
            dt = objFcNhanvien.HHPhieuthuchi(tungay, denngay, uId_Nhanvien)
        Catch ex As Exception

        End Try
        Return dt
    End Function
    Private Function GetHHPhieuxuat(uId_Nhanvien As String) As DataTable
        Dim dt As New DataTable
        objFcNhanvien = New BO.QT_DM_NHANVIENFacade
        Dim tungay As DateTime
        Dim denngay As DateTime
        tungay = Aspx_Tungay.Value
        denngay = Aspx_Denngay.Value
        Try
            dt = objFcNhanvien.HHPhieuxuat(tungay, denngay, uId_Nhanvien)
        Catch ex As Exception

        End Try
        Return dt
    End Function

    Private Sub loadTime()
        Aspx_Tungay.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
        Aspx_Denngay.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
    End Sub

    Private Sub LoadNhanvien()
        Dim dt As DataTable
        objFcNhanvien = New BO.QT_DM_NHANVIENFacade
        dt = objFcNhanvien.SelectAllTable(Session("uId_Cuahang").ToString)
        Dim item As New ListEditItem
        item.Text = "Tất cả"
        item.Value = "Tatca"
        cboNhanvien.Items.Add(item)
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                Dim items As New ListEditItem
                items.Value = row("uId_Nhanvien").ToString
                items.Text = row("nv_Hoten_vn").ToString
                cboNhanvien.Items.Add(items)
            Next
        End If
        dt = Nothing
    End Sub
#End Region
#Region "buttom Event"
    Private Sub btn_Baocao_Click(sender As Object, e As EventArgs) Handles btn_Baocao.Click
        GridNV()
    End Sub

#End Region
#Region "Grid Event"
    Protected Sub Grid_Phieuthuchi_BeforePerformDataSelect(sender As Object, e As EventArgs)
        Dim Grid_phieuthuchi As ASPxGridView
        Grid_phieuthuchi = DirectCast(sender, ASPxGridView)
        Dim uId_Nhanvien As String
        Dim dt As DataTable
        Try
            uId_Nhanvien = Grid_phieuthuchi.GetMasterRowKeyValue().ToString
            dt = GetHHphieuthuchi(uId_Nhanvien)
            Grid_phieuthuchi.DataSource = dt
            dt = Nothing
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Grid_Phieuxuat_BeforePerformDataSelect(sender As Object, e As EventArgs)
        Dim Grid_phieuxuat As ASPxGridView
        Grid_phieuxuat = DirectCast(sender, ASPxGridView)
        Dim uId_Nhanvien As String
        Dim dt As DataTable
        Try
            uId_Nhanvien = Grid_phieuxuat.GetMasterRowKeyValue().ToString
            dt = GetHHPhieuxuat(uId_Nhanvien)
            Grid_phieuxuat.DataSource = dt
            dt = Nothing
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Grid_Phieudichvu_BeforePerformDataSelect(sender As Object, e As EventArgs)
        Dim Grid_phieudv As ASPxGridView
        Grid_phieudv = DirectCast(sender, ASPxGridView)
        Dim uId_Nhanvien As String
        Dim dt As DataTable
        Try
            uId_Nhanvien = Grid_phieudv.GetMasterRowKeyValue().ToString
            dt = GetHHPhieudv(uId_Nhanvien)
            Grid_phieudv.DataSource = dt
            dt = Nothing
        Catch ex As Exception

        End Try
    End Sub
#End Region
    Private Sub btnback_Click(sender As Object, e As EventArgs) Handles btnback.Click
        Response.Redirect("~/OrangeVersion/Finance/ReportForm_HH.aspx")
    End Sub
End Class