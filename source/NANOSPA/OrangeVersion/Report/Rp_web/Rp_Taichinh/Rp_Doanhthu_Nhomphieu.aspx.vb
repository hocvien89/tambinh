Public Class Rp_Doanhthu_Nhomphieu
    Inherits System.Web.UI.Page
    Private objFcDoanhthuNhomphieu As BO.clsB_TNTP_PHIEUDICHVU_NHOMPHIEUFacade
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            loadTime()
            cbo_Nhomphieu.SelectedIndex = 0
        End If
        loadData()
    End Sub
#Region "load data"
    Private Sub loadData()
        objFcDoanhthuNhomphieu = New BO.clsB_TNTP_PHIEUDICHVU_NHOMPHIEUFacade
        Dim BC As New Xtr_Doanhthu_Nhomphieu
        Dim dt As DataTable
        Try
            dt = objFcDoanhthuNhomphieu.BAOCAO_DoanhThu_Nhomphieu(Aspx_Tungay.Value, Aspx_Denngay.Value, Session("uId_Cuahang"), cbo_Nhomphieu.SelectedIndex, 0)
            Dim j, k As Integer
            j = 0
            While j < dt.Rows.Count - 1
                k = j + 1
                While k < dt.Rows.Count
                    If dt.Rows(j)("v_Sophieu").ToString = dt.Rows(k)("v_Sophieu").ToString Then
                        dt.Rows(k)("f_Tongtienthuc") = 0
                        dt.Rows(k)("tienno") = 0
                        dt.Rows(k)("tonggiamgia") = 0
                    Else : dt.Rows(k - 1)("f_Tongtienthuc") = Val(dt.Rows(j)("f_Tongtienthuc").ToString)
                        dt.Rows(k - 1)("tienno") = Val(dt.Rows(j)("tienno").ToString)
                        dt.Rows(k - 1)("tonggiamgia") = Val(dt.Rows(j)("tonggiamgia").ToString)
                        If k - 1 > j Then
                            dt.Rows(j)("f_Tongtienthuc") = 0
                            dt.Rows(j)("tienno") = 0
                            dt.Rows(j)("tonggiamgia") = 0
                        End If
                        Exit While
                    End If
                    k += 1
                End While
                j = k

            End While
            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i)("v_Sophieu") = "- " + dt.Rows(i)("nv_Hoten_vn").ToString + " - " + dt.Rows(i)("v_Sophieu").ToString + " / Nhóm phiếu: " + dt.Rows(i)("nv_Tennhomphieu_vn").ToString
            Next
            BC.bind(dt)
            ReportViewer1.Report = BC
            BC.lbl_Tungay.Text = Aspx_Tungay.Text
            BC.lbl_Denngay.Text = Aspx_Denngay.Text
            BC.lbl_Tencuahang.Text = Session("nv_Tencuahang_vn")
            BC.lbl_Diachi.Text = Session("nv_DiachiCH_vn")
            BC.lbl_Nhomphieu.Text = cbo_Nhomphieu.SelectedItem.ToString
        Catch ex As Exception

        End Try
    End Sub
    Public Sub loadTime()
        Aspx_Denngay.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
        Aspx_Tungay.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
    End Sub

#End Region

    Private Sub btn_Baocao_Click(sender As Object, e As EventArgs) Handles btn_Baocao.Click
        loadData()
    End Sub

    Private Sub btnback_Click(sender As Object, e As EventArgs) Handles btnback.Click
        Response.Redirect("../../../../OrangeVersion/Finance/ReportForm_Finance.aspx")
    End Sub
End Class