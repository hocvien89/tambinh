Public Class Rp_Sonhatky_Chung
    Inherits System.Web.UI.Page
    Private objFCKHQT As New BO.KHQT_KHACHHANG_USERFacade
    Dim BC As Xtr_Sonhatky_Chung
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LoadTime()
        End If
        LoadData()
    End Sub
    Private Sub LoadTime()
        Aspx_Denngay.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
        Aspx_Tungay.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
    End Sub
    Private Sub LoadData()
        Try


            Dim TuNgay As DateTime
            Dim DenNgay As DateTime
            Dim sFormat As System.Globalization.DateTimeFormatInfo = New System.Globalization.DateTimeFormatInfo()
            sFormat.ShortDatePattern = "dd/MM/yyyy"
            If Aspx_Tungay.Value.ToString <> "" And Aspx_Denngay.Value.ToString <> "" Then
                TuNgay = Aspx_Tungay.Value.ToString
                DenNgay = Aspx_Denngay.Value.ToString
            End If
            Dim uId_Cuahang As String
            BC = New Xtr_Sonhatky_Chung
            Dim dt As New DataTable
            uId_Cuahang = Session("uId_Cuahang")
            dt = objFCKHQT.SoNhatKyChung(TuNgay, DenNgay, "", uId_Cuahang)
            Dim j, k As Integer
            j = 0
            While j < dt.Rows.Count - 1
                k = j + 1
                While k < dt.Rows.Count
                    If dt.Rows(j)("v_Sophieu").ToString = dt.Rows(k)("v_Sophieu").ToString Then
                        dt.Rows(k)("nv_Tongthanhtoan") = 0
                        dt.Rows(k)("nv_NVBan") = ""
                        dt.Rows(k)("tienno") = 0
                        dt.Rows(k)("tonggiamgia") = 0
                    Else : dt.Rows(k - 1)("nv_Tongthanhtoan") = Val(dt.Rows(j)("nv_Tongthanhtoan").ToString)
                        dt.Rows(k - 1)("tienno") = Val(dt.Rows(j)("tienno").ToString)
                        dt.Rows(k - 1)("tonggiamgia") = Val(dt.Rows(j)("tonggiamgia").ToString)
                        If k - 1 > j Then
                            'dt.Rows(j)("nv_Tongthanhtoan") = 0
                            dt.Rows(k)("nv_NVBan") = ""
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
                dt.Rows(i)("v_Sophieu") = "- " + dt.Rows(i)("nv_Hoten_vn").ToString + "." + dt.Rows(i)("v_Sophieu").ToString + " / " + dt.Rows(i)("v_DienthoaiDD").ToString
            Next
            BC.Bind(dt)
            ReportViewer1.Report = BC
            BC.lbl_Tungay.Text = Aspx_Tungay.Text
            BC.lbl_Denngay.Text = Aspx_Denngay.Text
            BC.lbl_Diachi.Text = Session("nv_DiachiCH_vn")
            BC.lbl_Tencuahang.Text = Session("nv_Tencuahang_vn")
            'Dispose
            dt = Nothing
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_Baocao_Click(sender As Object, e As EventArgs) Handles btn_Baocao.Click
        LoadData()
    End Sub
End Class