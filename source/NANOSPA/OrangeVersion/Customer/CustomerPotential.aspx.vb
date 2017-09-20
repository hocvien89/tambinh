Imports DevExpress.Web.ASPxEditors
Imports System.Data.OleDb
Imports System.IO

Public Class CustomerPotential
    Inherits System.Web.UI.Page
    Private objFcKHTiemnang As BO.MKT_KH_TIEMNANGFacade
    Private objFcCuahang As BO.QT_DM_CUAHANGFacade
    Private objEnKHTiemnang As CM.MKT_KH_TIEMNANGEntity
    Private objEnChuyendoi As CM.MKT_ChuyendoiEntity
    Private objFcChuyendoi As BO.MKT_ChuyendoiFacade
    Private pc As Public_Class
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Grid_KH_Tiemnang.Visible = True
            ReportToolbar1.Visible = False
            ReportViewer1.Visible = False
            LoadTime()
            loadcboCuahang()
            cbo_Cuahang.SelectedIndex = 0
        End If
        GridLoadData()
        LoadReport()
    End Sub
#Region "load data"
    Private Function GetData() As DataTable
        objFcKHTiemnang = New BO.MKT_KH_TIEMNANGFacade
        Dim dt As New DataTable
        Dim tungay As Date
        Dim denngay As Date
        Dim uid_Cuahang As String
        tungay = Aspx_Tungay.Value
        denngay = Aspx_Denngay.Value
        Try
            If chk_Cuahang.Checked = True Then
                If cbo_Cuahang.SelectedIndex = 0 Then
                    uid_Cuahang = ""
                Else
                    uid_Cuahang = cbo_Cuahang.Value.ToString
                End If
            Else
                uid_Cuahang = ""
            End If
            dt = objFcKHTiemnang.SelectAllTable(tungay, denngay, uid_Cuahang)
        Catch ex As Exception

        End Try
        Return dt
        tungay = Nothing
        denngay = Nothing
        uid_Cuahang = Nothing
        objFcKHTiemnang = Nothing
    End Function

    Private Sub GridLoadData()
        Dim dt As DataTable
        dt = GetData()
        Grid_KH_Tiemnang.DataSource = dt
        Grid_KH_Tiemnang.DataBind()
    End Sub

    Private Sub loadcboCuahang()
        objFcCuahang = New BO.QT_DM_CUAHANGFacade
        Dim dt As DataTable
        Try
            dt = objFcCuahang.SelectAllTable()
            If dt.Rows.Count > 0 Then
                Dim item As New ListEditItem
                item.Text = "Tất cả"
                item.Value = "Tatca"
                cbo_Cuahang.Items.Add(item)
                For Each row As DataRow In dt.Rows
                    Dim items As New ListEditItem
                    items.Text = row("nv_Tencuahang_vn")
                    items.Value = row("uId_Cuahang")
                    cbo_Cuahang.Items.Add(items)
                Next
            End If
        Catch ex As Exception

        End Try
        dt = Nothing
        objFcCuahang = Nothing
    End Sub

    Private Sub LoadTime()
        Aspx_Denngay.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
        Aspx_Tungay.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
    End Sub

    Private Sub LoadReport()

        Dim dt As DataTable
        dt = GetData()
        Try
            Dim Bc As New Xtr_CustomerPotential
            Bc.bind(dt)
            ReportViewer1.Report = Bc
            Dim objEnCuahang As New CM.QT_DM_CUAHANGEntity
            Dim objFcCuahang As New BO.QT_DM_CUAHANGFacade
            objEnCuahang = objFcCuahang.SelectByIDCuahang(Session("uId_Cuahang"))
            Bc.lblPKName.Text = objEnCuahang.nv_Tencuahang_vn
            Bc.lblDiachi.Text = objEnCuahang.nv_Diachi_vn
            Bc.lblDienthoai.Text = objEnCuahang.nv_Dienthoai
            Bc.XrPictureBox_logo.ImageUrl = objEnCuahang.nv_Diachi_en
            'If cbo_Cuahang.SelectedIndex <> 0 Then
            '    If chk_Cuahang.Checked = True Then
            '        Bc.lbl_Diachi.Text = Session("nv_DiachiCH_vn").ToString
            '        Bc.lbl_Tencuahang.Text = "Cửa hàng: " + cbo_Cuahang.SelectedItem.ToString
            '    Else
            '        Bc.lbl_Tencuahang.Text = "Cửa hàng: Tất cả"
            '        Bc.lbl_Diachi.Text = ""
            '    End If
            'Else
            '    Bc.lbl_Diachi.Text = ""
            '    Bc.lbl_Tencuahang.Text = "Cửa hàng: Tất cả"
            'End If

            Bc.lbl_Tungay.Text = Aspx_Tungay.Text
            Bc.lbl_Denngay.Text = Aspx_Denngay.Text
        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "Import Excel Support"
    'doc file excel tai len tu client dua vao table
    Private Sub Import_To_Grid(ByVal FilePath As String, ByVal Extension As String)
        Dim conStr As String = ""
        Select Case Extension
            Case ".xls"
                'Excel 97-03
                conStr = ConfigurationManager.ConnectionStrings("Excel03ConString").ConnectionString()
                Exit Select
            Case ".xlsx"
                'Excel 07
                conStr = ConfigurationManager.ConnectionStrings("Excel07ConString").ConnectionString()
                Exit Select
        End Select

        conStr = String.Format(conStr, FilePath)
        Dim connExcel As New OleDbConnection(conStr)
        Dim cmdExcel As New OleDbCommand()
        Dim oda As New OleDbDataAdapter()
        Dim dt As New DataTable()
        cmdExcel.Connection = connExcel
        'Get the name of First Sheet
        connExcel.Open()
        Dim dtExcelSchema As DataTable
        dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
        'Dim SheetName As String = dtExcelSchema.Rows(1)("TABLE_NAME").ToString()
        Dim SheetName As String = "KHTiemnang$"
        connExcel.Close()
        'Read Data from First Sheet
        connExcel.Open()
        cmdExcel.CommandText = "SELECT * From [" & SheetName & "]"
        oda.SelectCommand = cmdExcel
        oda.Fill(dt)
        connExcel.Close()
        File.Delete(FilePath)
        ExcelInsert(dt)
    End Sub
    Private Sub ExcelInsert(dt As DataTable)
        Dim sFormat As System.Globalization.DateTimeFormatInfo = New System.Globalization.DateTimeFormatInfo()
        sFormat.ShortDatePattern = "yyyy/MM/dd"
        objFcKHTiemnang = New BO.MKT_KH_TIEMNANGFacade
        objEnKHTiemnang = New CM.MKT_KH_TIEMNANGEntity
        objFcChuyendoi = New BO.MKT_ChuyendoiFacade
        objEnChuyendoi = New CM.MKT_ChuyendoiEntity
        Dim lengthTb As Integer
        Dim i As Integer = 0
        Dim matiemnang As String = pc.ReturnAutoString("")
        If dt.Rows.Count > 500 Then
            lengthTb = 500
        Else
            lengthTb = dt.Rows.Count
        End If
        For Each row As DataRow In dt.Rows
            If row("Tên khách hàng").ToString = "" Then
                Continue For
            End If
            With objEnKHTiemnang
                .v_Makhachhang = "KHTN" + (Convert.ToDouble(matiemnang) + i).ToString
                .nv_Hoten_vn = row("Tên khách hàng").ToString
                If row("Giới tính") = "Nam" Or row("Giới tính") = "nam" Then
                    .b_Gioitinh = True
                Else
                    .b_Gioitinh = False
                End If
                Dim str As String = row("Ngày sinh").ToString
                .d_Ngaysinh = BO.Util.ConvertDateTime(row("Ngày sinh").ToString)
                .nv_Diachi_vn = row("Địa chỉ").ToString
                .v_DienthoaiDD = row("Số điện thoại")
                .d_Ngaynhap = BO.Util.ConvertDateTime(row("Ngày nhập").ToString)
                .uId_Cuahang = Session("uId_Cuahang").ToString
                .uId_Xaphuong = "47014a0c-b3db-4470-91a2-c7fedd0d8953"
                .uId_Nghenghiep = "30f92db6-58ea-4461-93e5-8d66c1b031a0"
            End With
            Dim uid As String = objFcKHTiemnang.Insert(objEnKHTiemnang)
            With objEnChuyendoi
                .d_Ngay = BO.Util.ConvertDateTime(row("Ngày nhập").ToString)
                .uId_KH_Tiemnang = uid
                .uId_TrangthaiKH = "e7eb1051-54a3-4915-bb7c-0971be06be33"
            End With
            objFcChuyendoi.Insert(objEnChuyendoi)
            i += 1
            If i >= lengthTb Then
                Return
            End If
        Next
        GridLoadData()
        btn_Import.Enabled = True
    End Sub
#End Region
    Private Sub btn_ExportExcel_Click(sender As Object, e As EventArgs) Handles btn_ExportExcel.Click
        ASPxGridViewExporter1.WriteXlsToResponse()
    End Sub

    Private Sub btn_Baocao_Click(sender As Object, e As EventArgs) Handles btn_Baocao.Click
        Grid_KH_Tiemnang.Visible = True
        ReportToolbar1.Visible = False
        ReportViewer1.Visible = False
        GridLoadData()
    End Sub

    Private Sub btn_Report_Click(sender As Object, e As EventArgs) Handles btn_Report.Click
        Grid_KH_Tiemnang.Visible = False
        ReportToolbar1.Visible = True
        ReportViewer1.Visible = True
        LoadReport()
    End Sub

    'Private Sub btn_Import_Click(sender As Object, e As EventArgs) Handles btn_Import.Click
    '    If UploadFileExcel.HasFile Then
    '        btn_Import.Enabled = True
    '        pc = New Public_Class
    '        btn_Import.Enabled = False
    '        Dim FileName As String = Path.GetFileNameWithoutExtension(UploadFileExcel.PostedFile.FileName)
    '        Dim Extension As String = Path.GetExtension(UploadFileExcel.PostedFile.FileName)
    '        Dim FolderPath As String = ConfigurationManager.AppSettings("FolderPath")
    '        FileName = pc.ReturnAutoString(FileName)
    '        Dim FilePath As String = Server.MapPath(FolderPath + FileName + Extension)
    '        UploadFileExcel.SaveAs(FilePath)
    '        Import_To_Grid(FilePath, Extension)
    '        btn_Import.Enabled = False
    '    End If
    'End Sub

    Protected Sub link_Taiexcel_Mau_Click(sender As Object, e As EventArgs)
        Response.Redirect("../../Excel/Excel_Mau_KHTiemnang.xlsx")
    End Sub

    Private Sub btnback_Click(sender As Object, e As EventArgs) Handles btnback.Click
        Response.Redirect("~/OrangeVersion/Customer/ReportForm_Cus.aspx")
    End Sub
End Class