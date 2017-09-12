Imports DevExpress.Web.ASPxEditors

Public Class Rp_Hoahong_Phieudichvu
    Inherits System.Web.UI.Page
    Private objFcNhanvien As BO.QT_DM_NHANVIENFacade
    Private objFcCuahang As BO.QT_DM_CUAHANGFacade
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            loadCuahang()
            cbo_Cuahang.Value = Session("uId_Cuahang")
            loadNhanvien()
            loadTime()
        End If
        loadhohong()
    End Sub
#Region "dịch vụ"
    Private Sub loadhohong()
        objFcNhanvien = New BO.QT_DM_NHANVIENFacade
        objFcCuahang = New BO.QT_DM_CUAHANGFacade
        Dim dt As New DataTable
        Dim tuNgay As DateTime
        Dim denngay As DateTime
        Dim uid_Nhanvien As String
        tuNgay = Aspx_Tungay.Value.ToString
        denngay = Aspx_Denngay.Value.ToString
        Try
            If cbo_Nhanvien.SelectedIndex = 0 Then
                uid_Nhanvien = "0"
            Else
                uid_Nhanvien = cbo_Nhanvien.Value.ToString
            End If
            dt = objFcNhanvien.HoaHong_PhieuDV(tuNgay, denngay, uid_Nhanvien)
            Dim j, k As Integer
            j = 0
            While j < dt.Rows.Count - 1
                k = j + 1
                While k < dt.Rows.Count
                    If dt.Rows(j)("v_Sophieu").ToString = dt.Rows(k)("v_Sophieu").ToString Then
                        dt.Rows(k)("f_HH") = 0
                    Else : dt.Rows(k - 1)("f_HH") = Val(dt.Rows(j)("f_HH").ToString)
                        If k - 1 > j Then
                            dt.Rows(j)("f_HH") = 0
                        End If
                        Exit While
                    End If
                    k += 1
                End While
                j = k
            End While
        Catch ex As Exception

        End Try
        Dim xtr As New Xtr_Hoahong_Phieudichvu
        xtr.bind(dt)
        ReportViewer1.Report = xtr
        xtr.lbl_Tungay.Text = Aspx_Tungay.Text
        xtr.lbl_Denngay.Text = Aspx_Denngay.Text
        If cbo_Cuahang.SelectedIndex = 0 Then
            xtr.lbl_Tencuahang.Text = "Tất cả"
            xtr.lbl_diachi.Text = ""
        Else
            xtr.lbl_Tencuahang.Text = objFcCuahang.SelectByID(cbo_Cuahang.Value.ToString).Rows(0)("nv_Tencuahang_vn").ToString
            xtr.lbl_diachi.Text = Session("nv_DiachiCH_vn")
        End If
    End Sub

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
            If dt.Rows.Count > 0 Then
                Dim item As New ListEditItem
                item.Value = ""
                item.Text = "Tất cả"
                cbo_Cuahang.Items.Add(item)
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
#End Region
#Region "buttom event"
    Private Sub btn_Baocao_Click(sender As Object, e As EventArgs) Handles btn_Baocao.Click
        loadhohong()
    End Sub
#End Region
 
    Private Sub cbo_Cuahang_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_Cuahang.SelectedIndexChanged
        loadNhanvien()
    End Sub

    Private Sub btnback_Click(sender As Object, e As EventArgs) Handles btnback.Click
        Response.Redirect("../../../../OrangeVersion/Finance/ReportForm_HH.aspx")
    End Sub
End Class