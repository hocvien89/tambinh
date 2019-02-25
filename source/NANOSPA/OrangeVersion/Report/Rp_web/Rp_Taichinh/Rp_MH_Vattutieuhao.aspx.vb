Imports DevExpress.Web.ASPxEditors

Public Class Rp_MH_Vattutieuhao
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Loadkho()
            loadTime()
            cboKho.SelectedIndex = 0
        End If
        loadReport()
    End Sub

#Region "lay du lieu"
    Private Function Getdata()
        Dim Tungay As DateTime
        Dim Denngay As DateTime
        Dim uId_Kho As String
        Dim objFcVattu As New BO.QLMH_VATTUTIEUHAOFacade
        Dim dt As DataTable
        Tungay = Aspx_Tungay.Value
        Denngay = Aspx_Denngay.Value
        If cboKho.SelectedIndex = 0 Then
            uId_Kho = ""
        Else
            uId_Kho = cboKho.Value
        End If
        dt = objFcVattu.BaocaoVattu(Tungay, Denngay, uId_Kho)
        Return dt
    End Function

    'load du lieu kho
    Private Sub Loadkho()
        Dim dt As DataTable
        Dim objFcKho As New BO.QLMH_DM_KHOFacade
        dt = objFcKho.SelectAllTable(Session("uId_Cuahang"))
        Dim item As New ListEditItem
        item.Value = ""
        item.Text = "Tất cả"
        cboKho.Items.Add(item)
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                Dim items As New ListEditItem
                items.Value = row("uId_Kho").ToString
                items.Text = row("nv_Tenkho_vn").ToString
                cboKho.Items.Add(items)
            Next
        End If
    End Sub
    'load thoi gian
    Public Sub loadTime()
        Aspx_Denngay.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
        Aspx_Tungay.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
    End Sub
#End Region
#Region "report"
    Private Sub loadReport()
        Dim dt As DataTable
        dt = Getdata()
    
        Dim rp As New Xtr_MH_Vattutieuhao
        rp.bind(dt)
        rp.lbl_Tungay.Text = Aspx_Tungay.Text
        rp.lbl_Denngay.Text = Aspx_Denngay.Text
        Dim objEnCuahang As New CM.QT_DM_CUAHANGEntity
        Dim objFcCuahang As New BO.QT_DM_CUAHANGFacade
        objEnCuahang = objFcCuahang.SelectByIDCuahang(Session("uId_Cuahang"))
        Dim objFCThamsohethong As New BO.clsB_QT_THAMSOHETHONG
        rp.lblPKName.Html = objEnCuahang.nv_Tencuahang_en
        rp.lblDiachi.Html = objEnCuahang.nv_Diachi_en
        rp.lblSdt.Text = "SĐT: "+ objEnCuahang.nv_Dienthoai
        rp.XrPictureBox_logo.ImageUrl = objFCThamsohethong.SelectTHAMSOHETHONGByID("vLogo").v_Giatri.ToString()
        ReportViewer1.Report = rp
    End Sub
#End Region

    Private Sub btn_Baocao_Click(sender As Object, e As EventArgs) Handles btn_Baocao.Click
        Dim dt As DataTable
        dt = Getdata()

        Dim rp As New Xtr_MH_Vattutieuhao
        rp.bind(dt)
        rp.lbl_Tungay.Text = Aspx_Tungay.Text
        rp.lbl_Denngay.Text = Aspx_Denngay.Text
        Dim objEnCuahang As New CM.QT_DM_CUAHANGEntity
        Dim objFcCuahang As New BO.QT_DM_CUAHANGFacade
        objEnCuahang = objFcCuahang.SelectByIDCuahang(Session("uId_Cuahang"))
        Dim objFCThamsohethong As New BO.clsB_QT_THAMSOHETHONG
        rp.lblPKName.Html = objEnCuahang.nv_Tencuahang_en
        rp.lblDiachi.Html = objEnCuahang.nv_Diachi_en
        rp.lblSdt.Text = "SĐT: "+ objEnCuahang.nv_Dienthoai
        rp.XrPictureBox_logo.ImageUrl = objFCThamsohethong.SelectTHAMSOHETHONGByID("vLogo").v_Giatri.ToString()
        ReportViewer1.Report = rp
    End Sub

    Private Sub btnback_Click(sender As Object, e As EventArgs) Handles btnback.Click
        Response.Redirect("../../../../OrangeVersion/Product/ReportForm_Product.aspx")
    End Sub
End Class