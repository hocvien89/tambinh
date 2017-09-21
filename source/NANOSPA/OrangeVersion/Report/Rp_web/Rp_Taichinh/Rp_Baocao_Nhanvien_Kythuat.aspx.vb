Public Class Rp_Baocao_Nhanvien_Kythuat
    Inherits System.Web.UI.Page
    Dim objFc_Nhanvien As BO.QT_DM_NHANVIENFacade
    Dim BC As Xtr_Baocao_Nhanvien_Kythuat
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            loadTime()
            Load_Nhanvien()
        End If
        loadData()
    End Sub
    Public Sub loadTime()
        Aspx_Denngay.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
        Aspx_Tungay.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
    End Sub
    Protected Sub Load_Nhanvien()
        objFc_Nhanvien = New BO.QT_DM_NHANVIENFacade
        Dim dt As DataTable
        Dim uId_Phong As String = "53D2B838-DA94-4665-87A4-773EB941681C"
        dt = objFc_Nhanvien.Select_Nhanvien_Phong_Baocao(uId_Phong)
        cb_Nhanvien.DataSource = dt
        cb_Nhanvien.ValueField = "uId_Nhanvien"
        cb_Nhanvien.TextField = "nv_Hoten_vn"
        cb_Nhanvien.DataBind()
    End Sub
    Public Sub loadData()
        objFc_Nhanvien = New BO.QT_DM_NHANVIENFacade
        BC = New Xtr_Baocao_Nhanvien_Kythuat
        Dim dt As DataTable
        Dim d_Tungay As Date = BO.Util.ConvertDateTime(Aspx_Tungay.Text)
        Dim d_Denngay As Date = BO.Util.ConvertDateTime(Aspx_Denngay.Text)
        Dim uId_Nhanvien As String = cb_Nhanvien.Value.ToString
        dt = objFc_Nhanvien.Baocao_Nhanvien_Kythuat(d_Tungay, d_Denngay, uId_Nhanvien)
        Dim objEnCuahang As New CM.QT_DM_CUAHANGEntity
        Dim objFcCuahang As New BO.QT_DM_CUAHANGFacade
        objEnCuahang = objFcCuahang.SelectByIDCuahang(Session("uId_Cuahang"))
        BC.lblPKName.Text = objEnCuahang.nv_Tencuahang_vn
        BC.lblDiachi.Text = objEnCuahang.nv_Diachi_vn
        BC.lblDienthoai.Text = objEnCuahang.nv_Dienthoai
        BC.XrPictureBox_logo.ImageUrl = objEnCuahang.nv_Diachi_en
        Dim datenow As DateTime = Date.Now
        BC.lblNgay.Text = "Ngày " & datenow.Day.ToString() & " tháng " & datenow.Month.ToString() & " năm " & datenow.Year.ToString
        BC.Bindata(dt)
        ReportViewer_BC.Report = BC
    End Sub

    Private Sub btn_Baocao_Click(sender As Object, e As EventArgs) Handles btn_Baocao.Click
        loadData()
    End Sub
End Class