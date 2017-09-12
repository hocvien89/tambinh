Imports DevExpress.Web.ASPxEditors

Public Class Rp_Hoahong_Bandichvu
    Inherits System.Web.UI.Page
    Private objFcCuahang As BO.QT_DM_CUAHANGFacade
    Private objFcNhanvien As BO.QT_DM_NHANVIENFacade
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            loadCuahang()
            cbo_Cuahang.Value = Session("uId_Cuahang")
            loadNhanvien()
            loadTime()
        End If
        loadHohong()
    End Sub
#Region "thông tin"
    Private Sub loadTime()
        Aspx_Denngay.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
        Aspx_Tungay.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
    End Sub

    Private Sub loadCuahang()
        'Dim uid_cuahang As String
        objFcCuahang = New BO.QT_DM_CUAHANGFacade
        Dim dt As DataTable
        dt = objFcCuahang.SelectAllTable()
        Try
            If dt.Rows.Count > 2 Then
                Dim item As New ListEditItem
                item.Value = ""
                item.Text = "Tất cả"
                cbo_Cuahang.Items.Add(item)
            ElseIf dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    Dim items As New ListEditItem
                    items.Value = row("uId_Cuahang")
                    items.Text = row("nv_Tencuahang_vn")
                    cbo_Cuahang.Items.Add(items)
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub loadNhanvien()
        Dim uid_Cuahang As String
        objFcNhanvien = New BO.QT_DM_NHANVIENFacade
        Dim dt As DataTable
        Try
            If cbo_Cuahang.SelectedIndex = 0 Then
                uid_Cuahang = Nothing
            Else
                uid_Cuahang = cbo_Cuahang.Value.ToString
            End If
            dt = objFcNhanvien.SelectAllTable(uid_Cuahang)
            If dt.Rows.Count > 0 Then
                Dim item As New ListEditItem
                item.Value = ""
                item.Text = "Tất cả"
                cbo_Nhanvien.Items.Add(item)
                For Each row As DataRow In dt.Rows
                    Dim items As New ListEditItem
                    items.Value = row("uId_Nhanvien")
                    items.Text = row("nv_Hoten_vn")
                    cbo_Nhanvien.Items.Add(items)
                Next
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub loadHohong()
        objFcNhanvien = New BO.QT_DM_NHANVIENFacade
        objFcCuahang = New BO.QT_DM_CUAHANGFacade
        Dim dt As DataTable
        Dim uid_nhanvien As String
        Dim tungay As DateTime
        Dim denngay As DateTime
        If cbo_Nhanvien.SelectedIndex = 0 Then
            uid_nhanvien = "0"
        Else
            uid_nhanvien = cbo_Nhanvien.Value.ToString
        End If
        tungay = Aspx_Tungay.Value.ToString
        denngay = Aspx_Denngay.Value.ToString
        Try
            dt = objFcNhanvien.DoanhThuBanHang(tungay, denngay, uid_nhanvien)
            Dim Xtr As New Xtr_Hoahong_Bandichvu
            Xtr.bind(dt)
            ReportViewer1.Report = Xtr
            Xtr.lbl_Tungay.Text = Aspx_Tungay.Text
            Xtr.lbl_Denngay.Text = Aspx_Denngay.Text
            If cbo_Cuahang.SelectedIndex = 0 Then
                Xtr.lbl_Tencuahang.Text = "Tất cả"
                Xtr.lbl_Diachi.Text = ""
            Else
                Xtr.lbl_Tencuahang.Text = objFcCuahang.SelectByID(cbo_Cuahang.Value.ToString).Rows(0)("nv_Tencuahang_vn").ToString
                Xtr.lbl_Diachi.Text = Session("nv_DiachiCH_vn")
            End If
        Catch ex As Exception

        End Try
    End Sub
#End Region
#Region "button"
    Private Sub btn_Baocao_Click(sender As Object, e As EventArgs) Handles btn_Baocao.Click
        loadHohong()
    End Sub
#End Region
#Region "combobox cua hang event"
    Private Sub cbo_Cuahang_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_Cuahang.SelectedIndexChanged
        loadNhanvien()
    End Sub
#End Region

    Private Sub btnback_Click(sender As Object, e As EventArgs) Handles btnback.Click
        Response.Redirect("../../../../OrangeVersion/Finance/ReportForm_HH.aspx")
    End Sub
End Class