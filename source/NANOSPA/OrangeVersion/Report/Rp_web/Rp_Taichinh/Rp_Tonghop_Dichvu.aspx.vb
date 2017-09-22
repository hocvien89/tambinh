Public Class Rp_Tonghop_Dichvu
    Inherits System.Web.UI.Page
    Private BC As Xtr_Tonghop_Dichvu
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
        Dim xtr As New Xtr_Tonghop_dichvu
        Dim sFormat As System.Globalization.DateTimeFormatInfo = New System.Globalization.DateTimeFormatInfo()
        sFormat.ShortDatePattern = "dd/MM/yyyy"
        If Aspx_Tungay.Text <> "" And Aspx_Denngay.Text <> "" Then
            tungay = Aspx_Tungay.Value.ToString
            denngay = Aspx_Denngay.Value.ToString
        End If
        Dim dt As DataTable
        Dim objBoDichvu = New BO.TNTP_DM_DICHVUFacade
        dt = objBoDichvu.SelectDichvuUathich(tungay, denngay, Session("uId_Cuahang"))
        If dt.Rows.Count > 0 Then
            xtr.bindata(dt)
        End If
        Dim objEnCuahang As New CM.QT_DM_CUAHANGEntity
        Dim objFcCuahang As New BO.QT_DM_CUAHANGFacade
        objEnCuahang = objFcCuahang.SelectByIDCuahang(Session("uId_Cuahang"))
        xtr.lblPKName.Text = objEnCuahang.nv_Tencuahang_vn
        xtr.lblDiachi.Text = objEnCuahang.nv_Diachi_vn
        xtr.lblDienthoai.Text = objEnCuahang.nv_Dienthoai
        xtr.XrPictureBox_logo.ImageUrl = objEnCuahang.nv_Diachi_en
        Dim datenow As DateTime = Date.Now
        xtr.lblNgay.Text = "Ngày " & datenow.Day.ToString() & " tháng " & datenow.Month.ToString() & " năm " & datenow.Year.ToString
        ReportViewer1.Report = xtr
        dt = Nothing

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