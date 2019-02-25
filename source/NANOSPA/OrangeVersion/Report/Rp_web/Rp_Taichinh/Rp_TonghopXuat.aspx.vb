Imports DevExpress.Web.ASPxEditors

Public Class Rp_TonghopXuat
    Inherits System.Web.UI.Page
    Private objFcKho As BO.QLMH_DM_KHOFacade
    Private objFcPhieuxuat As BO.QLMH_PHIEUXUATFacade
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            loadTime()
            loadKho()
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
        objFcPhieuxuat = New BO.QLMH_PHIEUXUATFacade
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
            dt = objFcPhieuxuat.BCtonghopxuat(uId_Kho, tungay, denngay)
            Return dt
        Catch ex As Exception
            Return New DataTable
        End Try
    End Function

    Private Sub loadReport()
        Dim dt As DataTable
        dt = LoadData()
        Dim bc = New Xtra_TonghopXuat
        bc.Bindata(dt)
        ReportViewer1.Report = bc
        bc.lbl_Tungay.Text = Aspx_Tungay.Text
        bc.lbl_Denngay.Text = Aspx_Denngay.Text
        Dim objEnCuahang As New CM.QT_DM_CUAHANGEntity
        Dim objFcCuahang As New BO.QT_DM_CUAHANGFacade
        objEnCuahang = objFcCuahang.SelectByIDCuahang(Session("uId_Cuahang"))
        Dim objFCThamsohethong As New BO.clsB_QT_THAMSOHETHONG
        bc.lblPKName.Html = objEnCuahang.nv_Tencuahang_en
        bc.lblDiachi.Html = objEnCuahang.nv_Diachi_en
        bc.lblSdt.Text = "SĐT: " + objEnCuahang.nv_Dienthoai
        bc.XrPictureBox_logo.ImageUrl = objFCThamsohethong.SelectTHAMSOHETHONGByID("vLogo").v_Giatri.ToString()
        Dim datenow As DateTime = Date.Now
        bc.lblNgay.Text = "Ngày " & datenow.Day.ToString() & " tháng " & datenow.Month.ToString() & " năm " & datenow.Year.ToString

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