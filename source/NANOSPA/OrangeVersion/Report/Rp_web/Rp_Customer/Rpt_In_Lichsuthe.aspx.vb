Public Class Rpt_In_Lichsuthe
    Inherits System.Web.UI.Page
    Private objFcKH_GDV As BO.TNTP_KHACHHANG_GOIDICHVU_LICHSUFacade
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

        End If
        loaddata()
    End Sub
    Private Sub loaddata()
        objFcKH_GDV = New BO.TNTP_KHACHHANG_GOIDICHVU_LICHSUFacade
        Dim dt As DataTable
        Dim BC = New Xtr_InLichsu_TheTT
        dt = objFcKH_GDV.In_Phieu(Session("uId_Khachhang_Goidichvu").ToString)
        If dt.Rows.Count > 0 Then
            BC.binddata(dt)
        End If

        ReportViewerControl.ReportViewer.Report = BC
        BC.txt_cuahang.Text = Session("nv_Tencuahang_vn").ToString
        BC.txt_Ngaylap.Text = DateTime.Now
        BC.txt_nhanvien.Text = Session("sTendangnhap").ToString

    End Sub

End Class