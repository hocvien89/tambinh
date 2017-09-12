Imports DevExpress.Web.ASPxGridView.Export
Imports DevExpress.Web.ASPxGridView
Imports DevExpress.XtraRichEdit.Layout
Imports DevExpress.XtraPrinting

Public Class DSKhachHangHuyDV
    Inherits System.Web.UI.Page
    Private objFcHuydv As BO.MKT_HUYDV
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Aspx_Denngay.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
            Aspx_Tungay.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
        End If
        LoadKHHuyDVDefault()
    End Sub
#Region "load Du lieu"
    Public Function LoadDVHuy(uId_Khachhang As String) As String
        Dim rs As String = ""
        Dim dt As DataTable
        objFcHuydv = New BO.MKT_HUYDV
        dt = objFcHuydv.SelectByIdKH(uId_Khachhang)
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                rs += "- " + row("nv_Tendichvu_vn") + " / " + Format(row("Date"), "dd-MM-yyyy") + " / " + row("nv_HoTen_nhanvien") + " / " + row("nv_Ghichu_vn") + " </br>"
            Next
        End If
        Return rs
    End Function

    Private Sub LoadKHHuyDV()
        objFcHuydv = New BO.MKT_HUYDV
        Grid_KHhuydv.DataSource = Nothing
        Grid_KHhuydv.DataBind()
        Dim dt As DataTable
        Dim Tungay, Denngay As DateTime
        If Aspx_Tungay.Text <> "" And Aspx_Denngay.Text <> "" Then
            Tungay = Aspx_Tungay.Value
            Denngay = Aspx_Denngay.Value
        Else
            Tungay = Aspx_Tungay.Value
            Denngay = Aspx_Denngay.Value
        End If
        dt = objFcHuydv.SelectKHHuyDV(Tungay, Denngay)
        If dt.Rows.Count > 0 Then
            Dim col As New DataColumn
            col.ColumnName = "Dichvu"
            col.DataType = GetType(System.String)
            dt.Columns.Add(col)
            For i As Integer = 0 To dt.Rows.Count - 1 Step 1
                Dim uid = dt.Rows(i)("uId_Khachhang").ToString
                dt.Rows(i)("Dichvu") = System.Web.HttpUtility.HtmlDecode(LoadDVHuy(uid).ToString)
            Next
        End If
        Grid_KHhuydv.DataSource = dt
        Grid_KHhuydv.DataBind()
        objFcHuydv = Nothing
    End Sub
    Private Sub LoadKHHuyDVDefault()
        objFcHuydv = New BO.MKT_HUYDV
        Grid_KHhuydv.DataSource = Nothing
        Grid_KHhuydv.DataBind()
        Dim dt As DataTable
        Dim Tungay, Denngay As DateTime
        If Aspx_Tungay.Text <> "" And Aspx_Denngay.Text <> "" Then
            Tungay = Aspx_Tungay.Value
            Denngay = Aspx_Denngay.Value
        Else
            Tungay = Aspx_Tungay.Value
            Denngay = Aspx_Denngay.Value
        End If
        dt = objFcHuydv.SelectKHHuyDV(Tungay, Denngay)

        Grid_KHhuydv.DataSource = dt
        Grid_KHhuydv.DataBind()
        objFcHuydv = Nothing
    End Sub
#End Region

    Private Sub btn_Baocao_Click(sender As Object, e As EventArgs) Handles btn_Baocao.Click
        LoadKHHuyDVDefault()
    End Sub

    Private Sub ExportExcel_Click(sender As Object, e As EventArgs) Handles ExportExcel.Click
        ASPxGridViewExporter1.WriteXlsxToResponse()
    End Sub

    Private Sub ExcelMode()
        Grid_KHhuydv.SettingsDetail.ExportMode = CType(System.Enum.Parse(GetType(GridViewDetailExportMode), GridViewDetailExportMode.Expanded.ToString()), GridViewDetailExportMode)
    End Sub

    'Protected Sub ASPxGridViewExporter1_RenderBrick(sender As Object, e As ASPxGridViewExportRenderingEventArgs)
    '    Dim datacolumn As GridViewDataTextColumn = TryCast(e.Column, GridViewDataTextColumn)
    '    If e.RowType = GridViewRowType.Data AndAlso datacolumn IsNot Nothing AndAlso datacolumn.Name = "Dichvu" Then
    '        e.Text = LoadDVHuy(e.KeyValue().ToString).ToString
    '        e.TextValue = LoadDVHuy(e.KeyValue().ToString).ToString
    '    End If
    'End Sub
    Protected Sub ASPxGridViewExporter1_RenderBrick(sender As Object, e As ASPxGridViewExportRenderingEventArgs)
        If e.RowType = GridViewRowType.Data Then
            Dim colums As GridViewDataColumn = e.Column
            If colums.FieldName = "nv_Chitiet" Or colums.Name = "Dichvu" Then
                e.Text = e.Text.Replace("</br>", Environment.NewLine)
            End If
        End If
    End Sub

    Private Sub btnback_Click(sender As Object, e As EventArgs) Handles btnback.Click
        Response.Redirect("~/OrangeVersion/Customer/ReportForm_Cus.aspx")
    End Sub
End Class