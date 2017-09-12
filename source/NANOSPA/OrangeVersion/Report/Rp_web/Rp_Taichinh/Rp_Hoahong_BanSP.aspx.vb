Imports DevExpress.Web.ASPxEditors

Public Class Rp_Hoahong_BanSP
    Inherits System.Web.UI.Page
    Private objFcCuahang As BO.QT_DM_CUAHANGFacade
    Private objFcKho As BO.QLMH_DM_KHOFacade
    Private objFcNhanvien As BO.QT_DM_NHANVIENFacade
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            loadCuahang()
            cbo_Cuahang.Value = Session("uId_Cuahang")
            loadKho()
            loadTime()
        End If
        loadHohong()
    End Sub
#Region "dữ liệu"

    Private Sub loadCuahang()
        'Dim uid_cuahang As String
        objFcCuahang = New BO.QT_DM_CUAHANGFacade
        Dim dt As DataTable
        dt = objFcCuahang.SelectAllTable()
        Try
            If dt.Rows.Count > 0 Then
                If dt.Rows.Count > 1 Then
                    Dim item As New ListEditItem
                    item.Value = ""
                    item.Text = "Tất cả"
                    cbo_Cuahang.Items.Add(item)
                Else
                    For Each row As DataRow In dt.Rows
                        Dim items As New ListEditItem
                        items.Value = row("uId_Cuahang")
                        items.Text = row("nv_Tencuahang_vn")
                        cbo_Cuahang.Items.Add(items)
                    Next
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub loadKho()
        Dim dt As DataTable
        objFcKho = New BO.QLMH_DM_KHOFacade
        Dim uid_Cuahang As String
        If cbo_Cuahang.SelectedIndex = 0 Then
            uid_Cuahang = Nothing
        Else
            uid_Cuahang = cbo_Cuahang.Value.ToString
        End If
        dt = objFcKho.SelectAllTable(uid_Cuahang)
        Try
            If dt.Rows.Count > 0 Then
                If dt.Rows.Count > 1 Then
                    Dim item As New ListEditItem
                    item.Value = ""
                    item.Text = "Tất cả"
                    cbo_Kho.Items.Add(item)
                    For Each row As DataRow In dt.Rows
                        Dim items As New ListEditItem
                        items.Value = row("uId_Kho")
                        items.Text = row("nv_Tenkho_vn")
                        cbo_Kho.Items.Add(items)
                    Next
                Else
                    For Each row As DataRow In dt.Rows
                        Dim items As New ListEditItem
                        items.Value = row("uId_Kho")
                        items.Text = row("nv_Tenkho_vn")
                        cbo_Kho.Items.Add(items)
                    Next
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub loadTime()
        Aspx_Denngay.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
        Aspx_Tungay.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
    End Sub

    Private Sub loadHohong()
        objFcKho = New BO.QLMH_DM_KHOFacade
        objFcCuahang = New BO.QT_DM_CUAHANGFacade
        objFcNhanvien = New BO.QT_DM_NHANVIENFacade
        Dim dt As DataTable
        Dim uid_kho As String
        Dim uid_Cuahang As String
        Dim tungay As DateTime
        Dim denngay As DateTime
        If cbo_Kho.SelectedIndex = 0 Then
            uid_kho = ""
        Else
            uid_kho = cbo_Kho.Value.ToString
        End If
        If cbo_Cuahang.Items.Count > 1 Then
            If cbo_Cuahang.SelectedIndex = 0 Then
                uid_Cuahang = Nothing
            Else
                uid_Cuahang = cbo_Cuahang.Value
            End If
        Else
            uid_Cuahang = cbo_Cuahang.Value
        End If
        tungay = Aspx_Tungay.Value.ToString
        denngay = Aspx_Denngay.Value.ToString
        Try
            dt = objFcNhanvien.HoaHong_BanSP(tungay, denngay, uid_Cuahang, uid_kho)
            Dim Xtr As New Xtr_Hoahong_BanSP
            Xtr.bind(dt)
            ReportViewer1.Report = Xtr
            Xtr.lbl_Tungay.Text = Aspx_Tungay.Text
            Xtr.lbl_Denngay.Text = Aspx_Denngay.Text
            If cbo_Cuahang.Items.Count > 1 Then
                If cbo_Cuahang.SelectedIndex = 0 Then
                    Xtr.lbl_Tencuahang.Text = "Tất cả"
                    Xtr.lbl_Diachi.Text = ""
                End If

            Else
                Xtr.lbl_Tencuahang.Text = objFcCuahang.SelectByID(cbo_Cuahang.Value.ToString).Rows(0)("nv_Tencuahang_vn").ToString
                Xtr.lbl_Diachi.Text = Session("nv_DiachiCH_vn")
            End If
        Catch ex As Exception

        End Try
    End Sub
#End Region
#Region "button event"
    Private Sub btn_Baocao_Click(sender As Object, e As EventArgs) Handles btn_Baocao.Click
        loadHohong()
    End Sub
#End Region
#Region "Combobox event"
    Private Sub cbo_Cuahang_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_Cuahang.SelectedIndexChanged
        loadKho()
    End Sub
#End Region

    Private Sub btnback_Click(sender As Object, e As EventArgs) Handles btnback.Click
        Response.Redirect("../../../../OrangeVersion/Finance/ReportForm_HH.aspx")
    End Sub
End Class