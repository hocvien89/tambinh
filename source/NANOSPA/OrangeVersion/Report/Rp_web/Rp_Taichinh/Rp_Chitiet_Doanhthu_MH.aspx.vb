Public Class Rp_Chitiet_Doanhthu_MH
    Inherits System.Web.UI.Page
    Private objFCQLMH As New BO.QLMH_PHIEUXUATFacade
    Private BC As Xtr_Chitiet_Doanhthu_MH
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LoadTime()
        End If
        LoadData()
    End Sub
    Private Sub LoadData()
        Try
            Dim TuNgay As DateTime
            Dim DenNgay As DateTime
            Dim objFCThamsohethong As New BO.clsB_QT_THAMSOHETHONG
            Dim sFormat As System.Globalization.DateTimeFormatInfo = New System.Globalization.DateTimeFormatInfo()
            sFormat.ShortDatePattern = "dd/MM/yyyy"
            If Aspx_Tungay.Text <> "" And Aspx_Denngay.Text <> "" Then
                TuNgay = Aspx_Tungay.Value.ToString
                DenNgay = Aspx_Denngay.Value.ToString
            End If
            Dim uId_Cuahang As String
            uId_Cuahang = Session("uId_Cuahang")
            BC = New Xtr_Chitiet_Doanhthu_MH
            Dim dt As New DataTable
            dt = objFCQLMH.BaoCaoDoanhThuChiTietSP(TuNgay, DenNgay, uId_Cuahang)
            Dim j, k As Integer
            j = 0
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
                        'End If
                    Else
                        Exit While
                    End If
                    k += 1
                End While
                j = k
            End While
            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i)("v_Sophieu") = "- " + dt.Rows(i)("nv_Hoten_vn").ToString + "/ Nguồn:" + dt.Rows(i)("nv_Nguon_vn").ToString + " - " + dt.Rows(i)("v_Sophieu").ToString + " / Ghi chú:" + dt.Rows(i)("nv_Ghichu_vn").ToString
            Next
            BC.bind(dt)
            ReportViewer1.Report = BC
            'Dispose\
            Dim objEnCuahang As New CM.QT_DM_CUAHANGEntity
            Dim objFcCuahang As New BO.QT_DM_CUAHANGFacade
            objEnCuahang = objFcCuahang.SelectByIDCuahang(Session("uId_Cuahang"))
            BC.lblPKName.Html = objEnCuahang.nv_Tencuahang_en
            BC.lblDiachi.Text = objEnCuahang.nv_Diachi_en
            BC.lblSdt.Text = "SĐT: "+ objEnCuahang.nv_Dienthoai
            BC.XrPictureBox_logo.ImageUrl = objFCThamsohethong.SelectTHAMSOHETHONGByID("vLogo").v_Giatri.ToString()

            BC.lbl_Tungay.Text = Aspx_Tungay.Text
            BC.lbl_Denngay.Text = Aspx_Denngay.Text
            dt = Nothing
        Catch ex As Exception

        End Try
    End Sub
    Private Sub LoadTime()
        Aspx_Denngay.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
        Aspx_Tungay.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
    End Sub

    Private Sub btn_Baocao_Click(sender As Object, e As EventArgs) Handles btn_Baocao.Click
        LoadData()
    End Sub

    Private Sub btnback_Click(sender As Object, e As EventArgs) Handles btnback.Click
        Response.Redirect("../../../../OrangeVersion/Finance/ReportForm_Finance.aspx")
    End Sub
End Class