Public Class UserDiary
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            loadTime()
            loaddata(Aspx_Denngay.Value.ToString, Aspx_Denngay.Value.ToString, Nothing)
        End If
        loaddata(Aspx_Tungay.Value.ToString, Aspx_Denngay.Value.ToString, txt_key.Text.ToString)
    End Sub
    Private Sub loaddata(tungay As DateTime, denngay As DateTime, key As String)
        Dim objFcNhatky As New BO.NHATKYSUDUNGFacade
        Dim dt As DataTable
        Try
            dt = objFcNhatky.SelectAllTable(tungay, denngay, key)
            If dt.Rows.Count = 0 Then
                dt.Rows.Add(dt.NewRow)
            End If
            ASPxGridView1.DataSource = dt
            ASPxGridView1.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub loadTime()
        Aspx_Denngay.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
        Aspx_Tungay.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
    End Sub

    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        loaddata(Aspx_Tungay.Value, Aspx_Denngay.Value, txt_key.Text.ToString)
    End Sub
End Class