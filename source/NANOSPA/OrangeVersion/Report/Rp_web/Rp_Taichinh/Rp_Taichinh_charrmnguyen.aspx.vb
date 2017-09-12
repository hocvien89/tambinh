Public Class Rp_Taichinh_charrmnguyen
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            loadTime()
        End If
        loadBaocao()
    End Sub

    Private Sub loadBaocao()
        Dim tungay As Date
        Dim denngay As Date
        tungay = Aspx_Tungay.Value
        denngay = Aspx_Denngay.Value
        Dim dt As DataTable
        Dim objFcBaocaoKH As New BO.clsB_BaoCao_Khachhang
        Try
            dt = objFcBaocaoKH.Baocao_taichinh_Dichvu(tungay, denngay, Session("uId_Cuahang"))
            If dt.Rows.Count > 0 Then
                Grv_Taichinh.DataSource = dt
            End If
            Grv_Taichinh.DataBind()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub loadTime()
        Aspx_Denngay.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
        Aspx_Tungay.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
    End Sub

    Protected Sub btnExport_Click(sender As Object, e As EventArgs)
        ASPxGridViewExporter1.WriteXlsToResponse()
    End Sub
End Class