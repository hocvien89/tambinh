Imports DevExpress.Web.ASPxEditors

Public Class TermsOfUse
    Inherits System.Web.UI.Page
    Private objFcKho As BO.QLMH_DM_KHOFacade
    Private objFcCuahang As BO.QT_DM_CUAHANGFacade
    Private objFcBCQLMH As BO.clsb_BaoCaoQLMH
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            loadDSCuahang()
            loadDSKho()
        End If
        loadGrv()
    End Sub
#Region "load data"
    Private Sub loadDSCuahang()
        Dim dt As DataTable
        objFcCuahang = New BO.QT_DM_CUAHANGFacade
        dt = objFcCuahang.SelectAllTable()
        Dim item As New ListEditItem
        item.Value = ""
        item.Text = "---"
        ddlDsCuahang.Items.Add(item)
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                Dim items As New ListEditItem
                items.Value = row("uId_Cuahang").ToString
                items.Text = row("nv_Tencuahang_vn").ToString
                ddlDsCuahang.Items.Add(items)
            Next
        End If
        ddlDsCuahang.SelectedIndex = 0
    End Sub
    Private Sub loadDSKho()
        Dim dt As DataTable
        Dim uId_Cuahang As String
        If ddlDsCuahang.SelectedIndex = 0 Then
            uId_Cuahang = ""
        Else
            uId_Cuahang = ddlDsCuahang.Value
        End If
        objFcKho = New BO.QLMH_DM_KHOFacade
        dt = objFcKho.SelectAllTable(uId_Cuahang)
        Dim item As New ListEditItem
        item.Value = ""
        item.Text = "---"
        ddlDsKho.Items.Clear()
        ddlDsKho.Items.Add(item)
        If dt.Rows.Count > 0 Then
            For Each row As DataRow In dt.Rows
                Dim items As New ListEditItem
                items.Value = row("uId_Kho").ToString
                items.Text = row("nv_Tenkho_vn").ToString
                ddlDsKho.Items.Add(items)
            Next
        End If
        ddlDsKho.SelectedIndex = 0
    End Sub

    Private Sub loadGrv()
        Dim dt As DataTable
        Dim uId_Kho As String
        Dim uId_Cuahang As String
        If ddlDsCuahang.SelectedIndex = 0 Then
            uId_Cuahang = ""
        Else
            uId_Cuahang = ddlDsCuahang.Value
        End If
        If ddlDsKho.SelectedIndex = 0 Then
            uId_Kho = ""
        Else
            uId_Kho = ddlDsKho.Value
        End If
        objFcBCQLMH = New BO.clsb_BaoCaoQLMH
        dt = objFcBCQLMH.BaocaoHansudung(uId_Cuahang, uId_Kho)
        Try
            Grv_Hansudung.DataSource = dt
            Grv_Hansudung.DataBind()
        Catch ex As Exception

        End Try
    End Sub
#End Region

    Private Sub btnback_Click(sender As Object, e As EventArgs) Handles btnback.Click
        Response.Redirect("~/OrangeVersion/Product/ReportForm_Product.aspx")
    End Sub

    Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
        loadGrv()
    End Sub

    Private Sub btnExportXLS_Click(sender As Object, e As EventArgs) Handles btnExportXLS.Click
        ASPxGridViewExporter1.WriteXlsToResponse()
    End Sub

    Protected Sub ddlDsKho_Callback(sender As Object, e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase)
        loadDSKho()
    End Sub
End Class