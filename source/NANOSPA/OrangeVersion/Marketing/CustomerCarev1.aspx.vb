Imports DevExpress.Web.ASPxEditors
Imports System.Data.OleDb
Imports System.IO

Public Class CustomerCare
    Inherits System.Web.UI.Page
#Region "Khai bao"
    Dim objFCKHtiemnang As BO.MKT_KH_TIEMNANGFacade
    Dim objEnKHtiemnang As CM.MKT_KH_TIEMNANGEntity
    Dim objFCCuaHang As BO.QT_DM_CUAHANGFacade
    Dim objFcTrangthai As BO.MKT_TRANGTHAIKHFacade
    Dim objEnChuyendoi As CM.MKT_ChuyendoiEntity
    Dim objFCChuyendoi As BO.MKT_ChuyendoiFacade
    Private pc As Public_Class
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            dgvDevexpress.Visible = True
            ReportToolbar1.Visible = False
            ReportViewer1.Visible = False
            deTuNgay.Date = DateTime.Now.ToString
            deDenNgay.Date = DateTime.Now.ToString
            deNgaysinh.Date = DateTime.Now.ToString
            deNgayden.Date = DateTime.Now.ToString
            cboLoaikhachhang.SelectedIndex = 0
            LoadDropDownList()
        End If
        LoadReport()
        LoadDSKhachhang(BO.Util.ConvertDateTime(deTuNgay.Text), BO.Util.ConvertDateTime(deDenNgay.Text))
    End Sub
#Region "Load thong tin"
    Private Sub LoadDSKhachhang(ByVal TuNgay As DateTime, ByVal DenNgay As DateTime)
        objFCKHtiemnang = New BO.MKT_KH_TIEMNANGFacade
        Dim dt As DataTable
        Dim loaiKH As String
        loaiKH = cboLoaikhachhang.Value.ToString
        If chkViewAll.Checked Then
            dt = objFCKHtiemnang.ChamsocKH("01/01/2012", DateTime.Now, Session("uId_Cuahang"), loaiKH)
        Else
            dt = objFCKHtiemnang.ChamsocKH(TuNgay, DenNgay, Session("uId_Cuahang"), loaiKH)
        End If
        If dt.Rows.Count > 0 Then
            dgvDevexpress.DataSource = dt
        Else
            dgvDevexpress.DataSource = Nothing
        End If
        dgvDevexpress.DataBind()
        objFCKHtiemnang = Nothing
    End Sub
    Private Sub LoadDropDownList()
        objFCCuaHang = New BO.QT_DM_CUAHANGFacade
        objFcTrangthai = New BO.MKT_TRANGTHAIKHFacade
        Dim dt As DataTable
        dt = objFCCuaHang.SelectAllTable
        ddlCuahang.DataSource = dt
        ddlCuahang.ValueField = "uId_Cuahang"
        ddlCuahang.TextField = "nv_Tencuahang_vn"
        ddlCuahang.DataBind()
        ddlCuahang.Value = Session("uId_Cuahang")

        dt = New DataTable
        dt = objFcTrangthai.SelectAllTable
        ddlDanhgia.DataSource = dt
        ddlDanhgia.ValueField = "uId_TrangthaiKH"
        ddlDanhgia.TextField = "nv_TenTrangthaiKH_vn"
        ddlDanhgia.DataBind()
        ddlDanhgia.SelectedIndex = 0
    End Sub
#End Region
#Region "Checkbox Function"
    'Protected Sub chkViewAll_CheckedChange(ByVal sender As Object, ByVal e As EventArgs)
    '    If chkViewAll.Checked = True Then
    '        deTuNgay.Enabled = False
    '        deDenNgay.Enabled = False
    '        btnFilter.Enabled = False
    '        cboLoaikhachhang.Enabled = False
    '        LoadDSKhachhang("01/01/2012", DateTime.Now)
    '    Else
    '        deTuNgay.Enabled = True
    '        deDenNgay.Enabled = True
    '        btnFilter.Enabled = True
    '        cboLoaikhachhang.Enabled = True
    '        LoadDSKhachhang(BO.Util.ConvertDateTime(deTuNgay.Text), BO.Util.ConvertDateTime(deDenNgay.Text))
    '    End If
    'End Sub
#End Region
#Region "Button"
    'Protected Sub btnFilter_Click(sender As Object, e As EventArgs)
    '    LoadDSKhachhang(BO.Util.ConvertDateTime(deTuNgay.Text), BO.Util.ConvertDateTime(deDenNgay.Text))
    'End Sub

    Protected Sub btOK_Click(sender As Object, e As EventArgs)
        objEnKHtiemnang = New CM.MKT_KH_TIEMNANGEntity
        objFCKHtiemnang = New BO.MKT_KH_TIEMNANGFacade
        objEnChuyendoi = New CM.MKT_ChuyendoiEntity
        objFCChuyendoi = New BO.MKT_ChuyendoiFacade
        With objEnKHtiemnang
            .v_Makhachhang = CStr(Me.txtMaKH.Text.Trim)
            .nv_Hoten_vn = CStr(Me.txtHoten.Text.Trim)
            .d_Ngaysinh = BO.Util.ConvertDateTime(deNgaysinh.Text)
            .v_DienthoaiDD = CStr(Me.txtDienthoai.Text.Trim)
            .nv_Diachi_vn = CStr(Me.txtDiachi.Text.Trim)
            .v_Email = CStr(Me.txtEmail.Text.Trim)
            .b_Gioitinh = CByte(Me.ddlGioitinh.SelectedItem.Value)
            .d_Ngaynhap = BO.Util.ConvertDateTime(deNgayden.Text)
            .Ghichu = txtGhichu.Text
            .uId_Cuahang = ddlCuahang.SelectedItem.Value.ToString
        End With
        If (Session("uId_KH_Tiemnang") <> Nothing) Then
            objEnKHtiemnang.uId_KH_Tiemnang = Session("uId_KH_Tiemnang")
            If Session("uId_Khachhang") <> Nothing Then
                objEnKHtiemnang.uId_Khachhang = Session("uId_Khachhang")
            End If
            If Session("uId_Chuyendoi") <> Nothing Then
                objEnChuyendoi = New CM.MKT_ChuyendoiEntity
                objEnChuyendoi = objFCChuyendoi.SelectByID(Session("uId_Chuyendoi"))
                If ddlDanhgia.SelectedItem.Value.ToString <> objEnChuyendoi.uId_TrangthaiKH Then
                    'Manhtt:Lay ngay nhap chuyen doi la ngay hien tai
                    With objEnChuyendoi
                        .d_Ngay = DateTime.Now
                        .uId_KH_Tiemnang = Session("uId_KH_Tiemnang").ToString
                        .uId_TrangthaiKH = ddlDanhgia.SelectedItem.Value.ToString
                    End With
                    Try
                        Dim str_chuyendoi As String = objFCChuyendoi.Insert(objEnChuyendoi)
                        Session("uId_Chuyendoi") = str_chuyendoi
                    Catch ex As Exception
                    End Try
                End If
                objEnChuyendoi = Nothing
            End If
            If (objFCKHtiemnang.Update(objEnKHtiemnang)) Then
                ltrSuccess.Text = "<span class='success' id='success'>Cập nhật thông tin khách hàng thành công!</span>"
                Exit Sub
            Else
                ltrError.Text = "<span class='error' id='error'>Cập nhật thông tin khách hàng lỗi!</span>"
                Exit Sub
            End If
        Else
            Dim str As String = objFCKHtiemnang.Insert(objEnKHtiemnang)
            Session("uId_KH_Tiemnang") = str
            'Manhtt:Lay ngay nhap chuyen doi la ngay hien tai
            With objEnChuyendoi
                .d_Ngay = DateTime.Now
                .uId_KH_Tiemnang = Session("uId_KH_Tiemnang").ToString
                .uId_TrangthaiKH = ddlDanhgia.SelectedItem.Value.ToString
            End With
            Try
                Dim str_chuyendoi As String = objFCChuyendoi.Insert(objEnChuyendoi)
                Session("uId_Chuyendoi") = str_chuyendoi
                ltrSuccess.Text = "<span class='success' id='success'>Thêm mới thông tin khách hàng thành công!</span>"
            Catch ex As Exception
                ltrError.Text = "<span class='error' id='error'>Thêm mới thông tin khách hàng lỗi!</span>"
            End Try
        End If
    End Sub

    Protected Sub btaddbill_Click(sender As Object, e As EventArgs)
        Session("tags") = Nothing
        Response.Redirect("~/OrangeVersion/Marketing/AddWork.aspx")
    End Sub

    Private Sub btn_Import_Click(sender As Object, e As EventArgs) Handles btn_Import.Click
        If UploadFileExcel.HasFile Then
            pc = New Public_Class
            Dim FileName As String = Path.GetFileNameWithoutExtension(UploadFileExcel.PostedFile.FileName)
            Dim Extension As String = Path.GetExtension(UploadFileExcel.PostedFile.FileName)
            Dim FolderPath As String = ConfigurationManager.AppSettings("FolderPath")
            FileName = pc.ReturnAutoString(FileName)
            Dim FilePath As String = Server.MapPath(FolderPath + FileName + Extension)
            UploadFileExcel.SaveAs(FilePath)
            Import_To_Grid(FilePath, Extension)
        End If
    End Sub

    Private Sub btn_Report_Click(sender As Object, e As EventArgs) Handles btn_Report.Click
        dgvDevexpress.Visible = False
        ReportToolbar1.Visible = True
        ReportViewer1.Visible = True
        LoadReport()
    End Sub

    Protected Sub link_Taiexcel_Mau_Click(sender As Object, e As EventArgs)
        Response.Redirect("../../Excel/Excel_Mau_KHTiemnang.xlsx")
    End Sub

    'Private Sub btnFilter_Click1(sender As Object, e As EventArgs) Handles btnFilter.Click
    '    dgvDevexpress.Visible = True
    '    ReportToolbar1.Visible = False
    '    ReportViewer1.Visible = False
    '    LoadDSKhachhang(BO.Util.ConvertDateTime(deTuNgay.Text), BO.Util.ConvertDateTime(deDenNgay.Text))
    'End Sub

    Private Sub btn_ExportExcel_Click(sender As Object, e As EventArgs) Handles btn_ExportExcel.Click
        ASPxGridViewExporter1.WriteXlsToResponse()
    End Sub
#End Region
#Region "Grid event"
    Protected Sub dgvDevexpress_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        Dim uId_Khachhang As String
        uId_Khachhang = e.Keys(0).ToString
        objFCKHtiemnang = New BO.MKT_KH_TIEMNANGFacade
        Try
            objFCKHtiemnang.DeleteByID(uId_Khachhang)
        Catch ex As Exception

        End Try
        LoadDSKhachhang(BO.Util.ConvertDateTime(deTuNgay.Text), BO.Util.ConvertDateTime(deDenNgay.Text))
        e.Cancel = True
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
        sFormat.ShortDatePattern = "dd/MM/yyyy"
        objFCKHtiemnang = New BO.MKT_KH_TIEMNANGFacade
        objEnKHtiemnang = New CM.MKT_KH_TIEMNANGEntity
        objFCChuyendoi = New BO.MKT_ChuyendoiFacade
        objEnChuyendoi = New CM.MKT_ChuyendoiEntity
        Dim lengthTb As Integer
        Dim i As Integer = 0
        Dim matiemnang As String = pc.ReturnAutoString("")
        If dt.Rows.Count > 500 Then
            lengthTb = 500 - 1
        Else
            lengthTb = dt.Rows.Count - 1
        End If
        If dt.Rows.Count >= 1 Then
            For Each row As DataRow In dt.Rows
                If row("Tên khách hàng").ToString = "" Then
                    Continue For
                End If
                With objEnKHtiemnang
                    .v_Makhachhang = "KHTN" + (Convert.ToDouble(matiemnang) + i).ToString
                    .nv_Hoten_vn = row("Tên khách hàng").ToString
                    If row("Giới tính").ToString = "Nam" Or row("Giới tính").ToString = "nam" Then
                        .b_Gioitinh = True
                    Else
                        .b_Gioitinh = False
                    End If
                    Dim datesinh As String = row("Ngày sinh").ToString
                    .d_Ngaysinh = Convert.ToDateTime(datesinh, sFormat)
                    .nv_Diachi_vn = row("Địa chỉ").ToString
                    .v_DienthoaiDD = row("Số điện thoại")
                    .d_Ngaynhap = Convert.ToDateTime(row("Ngày nhập").ToString, sFormat)
                    .uId_Cuahang = Session("uId_Cuahang").ToString
                    .uId_Xaphuong = "47014a0c-b3db-4470-91a2-c7fedd0d8953"
                    .uId_Nghenghiep = "30f92db6-58ea-4461-93e5-8d66c1b031a0"
                End With
                Dim uid As String = objFCKHtiemnang.Insert(objEnKHtiemnang)
                With objEnChuyendoi
                    .d_Ngay = Convert.ToDateTime(row("Ngày nhập").ToString, sFormat)
                    .uId_KH_Tiemnang = uid
                    .uId_TrangthaiKH = "e7eb1051-54a3-4915-bb7c-0971be06be33"
                End With
                objFCChuyendoi.Insert(objEnChuyendoi)
                i += 1
                If i >= lengthTb Then
                    Return
                End If
            Next
        End If

        LoadDSKhachhang(BO.Util.ConvertDateTime(deTuNgay.Text), BO.Util.ConvertDateTime(deDenNgay.Text))
        btn_Import.Enabled = True
    End Sub
    Private Sub LoadReport()
        Dim dt As DataTable
        dt = GetData()
        Try
            Dim Bc As New Xtr_CustomerPotential
            Bc.bind(dt)
            ReportViewer1.Report = Bc
            Bc.lbl_Diachi.Text = Session("nv_DiachiCH_vn").ToString
            Bc.lbl_Tencuahang.Text = "Cửa hàng: " + Session("uId_Cuahang").ToString
            Bc.lbl_Tencuahang.Text = "Cửa hàng: Tất cả"
            Bc.lbl_Diachi.Text = ""
            Bc.lbl_Diachi.Text = ""
            Bc.lbl_Tencuahang.Text = "Cửa hàng: Tất cả"
            Bc.lbl_Tungay.Text = deTuNgay.Text
            Bc.lbl_Denngay.Text = deDenNgay.Text
        Catch ex As Exception

        End Try
    End Sub
    Private Function GetData() As DataTable
        objFcKHTiemnang = New BO.MKT_KH_TIEMNANGFacade
        Dim dt As New DataTable
        Dim tungay As Date
        Dim denngay As Date
        Dim loaikh As String
        Dim uid_Cuahang As String
        tungay = deTuNgay.Value
        denngay = deDenNgay.Value
        loaikh = cboLoaikhachhang.Value
        Try
            uid_Cuahang = Session("uId_Cuahang")
            dt = objFCKHtiemnang.ChamsocKH(tungay, denngay, uid_Cuahang, loaikh)
        Catch ex As Exception
        End Try
        Return dt
        tungay = Nothing
        denngay = Nothing
        uid_Cuahang = Nothing
        objFcKHTiemnang = Nothing
    End Function

#End Region
End Class