Public Class Rp_Chitiet_Doanhthu_DV
    Inherits System.Web.UI.Page
    Private BC As Xtr_Chitiet_Doanhthu_Dv
    Private objFCKHQT As New BO.KHQT_KHACHHANG_USERFacade
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            loadTime()
        End If
        loadData()
    End Sub
    Public Sub loadTime()
        Aspx_Denngay.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
        Aspx_Tungay.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
    End Sub
    Public Sub loadData()
        Dim tungay As DateTime
        Dim denngay As DateTime
        Dim objFCThamsohethong As New BO.clsB_QT_THAMSOHETHONG
        Dim sFormat As System.Globalization.DateTimeFormatInfo = New System.Globalization.DateTimeFormatInfo()
        sFormat.ShortDatePattern = "dd/MM/yyyy"
        If Aspx_Tungay.Text <> "" And Aspx_Denngay.Text <> "" Then
            tungay = Aspx_Tungay.Value.ToString
            denngay = Aspx_Denngay.Value.ToString
        End If
        Dim uId_Cuahang As String
        BC = New Xtr_Chitiet_Doanhthu_Dv
        Dim dt As New DataTable
        uId_Cuahang = Session("uId_Cuahang")
        dt = objFCKHQT.BaoCaoDichVu(tungay, denngay, "", uId_Cuahang)
        Dim j, k As Integer
        j = 0
        BC.lblPKName.Html = Session("nv_Tencuahang_en")
        BC.lblDiachi.Html = Session("nv_DiachiCH_en")
        BC.lblSdt.Text = "SĐT: " + Session("nv_Dienthoai")
        BC.XrPictureBox_logo.ImageUrl = "~" + objFCThamsohethong.SelectTHAMSOHETHONGByID("vLogo").v_Giatri
        BC.lbl_Tungay.Text = Aspx_Tungay.Text
        BC.lbl_Denngay.Text = Aspx_Denngay.Text
        Try
            While j < dt.Rows.Count - 1
                k = j + 1
                While k < dt.Rows.Count
                    If dt.Rows(j)("v_Sophieu").ToString = dt.Rows(k)("v_Sophieu").ToString Then
                        dt.Rows(k)("f_Tongtienthuc") = 0
                        dt.Rows(k)("tienno") = 0
                        dt.Rows(k)("tonggiamgia") = 0
                        'Else : dt.Rows(k - 1)("f_Tongtienthuc") = Val(dt.Rows(j)("f_Tongtienthuc").ToString)
                        '    dt.Rows(k - 1)("tienno") = Val(dt.Rows(j)("tienno").ToString)
                        '    dt.Rows(k - 1)("tonggiamgia") = Val(dt.Rows(j)("tonggiamgia").ToString)
                        '    If k - 1 > j Then
                        '        dt.Rows(j)("f_Tongtienthuc") = 0
                        '        dt.Rows(j)("tienno") = 0
                        '        dt.Rows(j)("tonggiamgia") = 0
                        '    End If
                        '    Exit While
                    Else
                        Exit While
                    End If
                    k += 1
                End While
                j = k
            End While
            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i)("v_Sophieu") = "- " + dt.Rows(i)("nv_Hoten_vn").ToString + "/ Nguồn:" + dt.Rows(i)("nv_Nguon_vn").ToString + " - " + dt.Rows(i)("v_Sophieu").ToString + " / Ghi chú:" + dt.Rows(i)("nv_Ghichu_vn").ToString + " /Ngày:" + dt.Rows(i)("d_Ngay").ToString
            Next
            BC.Binding(dt)
            ReportViewer1.Report = BC
            'Dispose
            dt = Nothing

        Catch ex As Exception

        End Try
    End Sub

    Private Function Editdata(dt As DataTable) As DataTable
        Dim i As Integer = 0
        Dim k As Integer
        While i < dt.Rows.Count - 1
            k = +1
            If dt.Rows(i)("v_Sophieu").ToString = dt.Rows(k)("v_Sophieu").ToString Then

            End If
        End While
    End Function

    Private Sub btn_Baocao_Click(sender As Object, e As EventArgs) Handles btn_Baocao.Click
        loadData()
    End Sub

    Private Sub btnback_Click(sender As Object, e As EventArgs) Handles btnback.Click
        Response.Redirect("../../../../OrangeVersion/Finance/ReportForm_Finance.aspx")
    End Sub
End Class