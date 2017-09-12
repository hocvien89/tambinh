Public Class Rp_Dichvu_Khachhang
    Inherits System.Web.UI.Page
    Private BC As Xtr_Dichvu_Khachhang
    Private objFCKHQT As New BO.clsB_BaoCao_Khachhang

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            loadTime()
        End If
        loadData()
    End Sub

    Public Sub loadTime()
        Aspx_Thang.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
    End Sub

    Public Sub loadData()
        Dim sFormat As System.Globalization.DateTimeFormatInfo = New System.Globalization.DateTimeFormatInfo()
        sFormat.ShortDatePattern = "dd/MM/yyyy"
        BC = New Xtr_Dichvu_Khachhang
        Dim dt As DataTable
        dt = objFCKHQT.SelectThongkeKH_Dichvu_ByTime(Aspx_Thang.Date, ASPx_Tungay.Date)
        Dim chuoi As String
        chuoi = ""
        If ASPx_Tungay.Text <> "" Then
            chuoi = chuoi + " Từ ngày : " + Date.Parse(ASPx_Tungay.Value.ToString()).Day.ToString() + "/" + Date.Parse(ASPx_Tungay.Value.ToString()).Month.ToString()
        End If
        If Aspx_Thang.Text <> "" Then
            chuoi = chuoi + "  Đến ngày : " + Date.Parse(Aspx_Thang.Value.ToString()).Day.ToString() + "/" + Date.Parse(Aspx_Thang.Value.ToString()).Month.ToString()
        End If
        BC.lblThang.Text = chuoi
        BC.Binding(dt)
        ReportViewer1.Report = BC
        dt = Nothing
    End Sub

    Protected Sub btn_Baocao_Click(sender As Object, e As EventArgs) Handles btn_Baocao.Click
        loadData()
    End Sub
End Class