Public Class Rp_Congno_Khachhang
    Inherits System.Web.UI.Page
    Private objFckhachhang As BO.CRM_DM_KhachhangFacade

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LoadTime()
        End If
        loaddata()
    End Sub
    Private Sub loaddata()
        objFckhachhang = New BO.CRM_DM_KhachhangFacade
        Dim dt As DataTable
        Dim uId_Cuahang As String
        Dim nv_DiachiCuahang_vn As String
        Dim nv_Tencuahang_vn As String
        Dim Xtr As New Xtr_Congno_Khachhang
        nv_Tencuahang_vn = Session("nv_Tencuahang_vn")
        nv_DiachiCuahang_vn = Session("nv_DiachiCH_vn")
        uId_Cuahang = Session("uId_Cuahang")
        Dim TuNgay As DateTime
        Dim DenNgay As DateTime
        If Aspx_Tungay.Text <> "" And Aspx_Denngay.Text <> "" Then
            TuNgay = Aspx_Tungay.Value.ToString
            DenNgay = Aspx_Denngay.Value.ToString
        End If
        Try
            dt = objFckhachhang.SelectCognoBytime(TuNgay, DenNgay, uId_Cuahang)
            Xtr.bind(dt)
            Xtr.lb_Diachi.Text = nv_DiachiCuahang_vn
            Xtr.lbl_Tencuahang.Text = nv_Tencuahang_vn
            ReportViewer1.Report = Xtr
        Catch ex As Exception

        End Try
        dt = Nothing
    End Sub

    Private Sub LoadTime()
        Aspx_Denngay.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
        Aspx_Tungay.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
    End Sub
    Private Sub btnback_Click(sender As Object, e As EventArgs) Handles btnback.Click
        Response.Redirect("../../../../OrangeVersion/Finance/ReportForm_Finance.aspx")
    End Sub

    Protected Sub ASPxCallbackPanel1_Callback(sender As Object, e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase)
        loaddata()
    End Sub
End Class