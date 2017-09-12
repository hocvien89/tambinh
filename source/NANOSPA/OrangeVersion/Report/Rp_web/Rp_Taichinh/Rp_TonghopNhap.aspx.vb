Imports DevExpress.Web.ASPxEditors

Public Class Rp_TonghopNhap
    Inherits System.Web.UI.Page
    Dim objFcPhieunhap As BO.clsB_Phieunhap
    Private objFcKho As BO.QLMH_DM_KHOFacade
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            loadKho()
            loadTime()
        End If
        loadReport()
    End Sub
#Region "load data"
    Private Sub loadKho()
        Dim dt As DataTable
        objFcKho = New BO.QLMH_DM_KHOFacade
        dt = objFcKho.SelectAllTable(Session("uId_Cuahang"))
        Try
            Dim item As New ListEditItem
            item.Value = ""
            item.Text = "Tất cả"
            cbo_Kho.Items.Add(item)
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    Dim items As New ListEditItem
                    items.Value = row("uId_Kho").ToString
                    items.Text = row("nv_Tenkho_vn").ToString
                    cbo_Kho.Items.Add(items)
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function LoadData() As DataTable
        Dim dt As DataTable
        objFcPhieunhap = New BO.clsB_Phieunhap
        Dim tungay As DateTime
        Dim denngay As DateTime
        Dim uId_Kho As String
        tungay = Aspx_Tungay.Value
        denngay = Aspx_Denngay.Value
        If cbo_Kho.SelectedIndex = 0 Then
            uId_Kho = ""
        Else
            uId_Kho = cbo_Kho.Value.ToString
        End If
        Try
            dt = objFcPhieunhap.BCTonghopnhap(uId_Kho, tungay, denngay)
            Return dt
        Catch ex As Exception
            Return New DataTable
        End Try
    End Function

    Private Sub loadReport()
        Dim dt As DataTable
        dt = LoadData()
        For i As Integer = 0 To dt.Rows.Count - 1 Step 1
            dt.Rows(i)("v_Maphieunhap") = " - " + dt.Rows(i)("v_Maphieunhap").ToString + " / NCC: " + dt.Rows(i)("nv_Tennhacungcap_vn").ToString + " / " + dt.Rows(i)("d_Ngaynhap").ToString
        Next
        Dim bc = New Xtr_TonghopNhap
        bc.Bindata(dt)
        ReportViewer1.Report = bc
        bc.lbl_Tungay.Text = Aspx_Tungay.Text
        bc.lbl_Denngay.Text = Aspx_Denngay.Text
        bc.lbl_Tencuahang.Text = Session("nv_Tencuahang_vn").ToString
        bc.lbl_diachi.Text = Session("nv_DiachiCH_vn").ToString
    End Sub

    Private Sub loadTime()
        Aspx_Tungay.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
        Aspx_Denngay.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
    End Sub
#End Region

    Private Sub btn_Baocao_Click(sender As Object, e As EventArgs) Handles btn_Baocao.Click
        loadReport()
    End Sub

    Private Sub btnback_Click(sender As Object, e As EventArgs) Handles btnback.Click
        Response.Redirect("../../../../OrangeVersion/Product/ReportForm_Product.aspx")
    End Sub
End Class