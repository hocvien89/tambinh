Public Class Rp_Phieu_Thuchi
    Inherits System.Web.UI.Page
    Dim BC As Xtr_Phieu_Thuchi
    Private objFC_KHQT_User As New BO.KHQT_KHACHHANG_USERFacade

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LoadTime()
            cbo_Loaiphieu.SelectedIndex = 0
            cbo_Cuahang.SelectedIndex = 0
        End If
        LoadData()
    End Sub
    Private Sub LoadTime()
        Aspx_Denngay.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
        Aspx_Tungay.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
    End Sub
    Private Sub LoadData()
        Dim TuNgay As DateTime
        Dim DenNgay As DateTime
        Dim sFormat As System.Globalization.DateTimeFormatInfo = New System.Globalization.DateTimeFormatInfo()
        sFormat.ShortDatePattern = "dd/MM/yyyy"
        If Aspx_Tungay.Value.ToString <> "" And Aspx_Denngay.Value.ToString <> "" Then
            TuNgay = Aspx_Tungay.Value.ToString
            DenNgay = Aspx_Denngay.Value.ToString
        End If
        Dim uId_Cuahang As String
        uId_Cuahang = Session("uId_Cuahang")
        BC = New Xtr_Phieu_Thuchi
        Dim dt As New DataTable
        Dim cbo2 As String = cbo_Loaiphieu.Value.ToString
        dt = objFC_KHQT_User.BAOCAO_PHIEUTHUCHI(TuNgay, DenNgay, uId_Cuahang, cbo2)
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1 Step 1
                If dt.Rows(i)("f_TienChi").ToString = "" Then
                    dt.Rows(i)("f_TienChi") = 0
                End If
                If dt.Rows(i)("f_TienThu").ToString = "" Then
                    dt.Rows(i)("f_TienThu") = 0
                End If
            Next
        End If 
        BC.Bind(dt)
        If Session("uId_Cuahang") = Nothing Then
            BC.lbl_Tencuahang.Text = cbo_Cuahang.Value.ToString
        Else
            BC.lbl_Tencuahang.Text = Session("nv_Tencuahang_vn")
        End If
        BC.lbl_Diachi.Text = Session("nv_DiachiCH_vn")
        BC.lbl_Tungay.Text = Aspx_Tungay.Text
        BC.lbl_Denngay.Text = Aspx_Denngay.Text
        ReportViewer1.Report = BC
        'Dispose
        dt = Nothing
    End Sub

    Private Sub btn_Baocao_Click(sender As Object, e As EventArgs) Handles btn_Baocao.Click
        LoadData()
    End Sub

    Private Sub btnback_Click(sender As Object, e As EventArgs) Handles btnback.Click
        Response.Redirect("../../../../OrangeVersion/Finance/ReportForm_Finance.aspx")
    End Sub
End Class