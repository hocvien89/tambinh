Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView
Imports DevExpress.Web.ASPxGridView.Export
Imports System.IO
Imports System.Data.OleDb
Imports System.Drawing
Imports iTextSharp.text.pdf
Imports DevExpress.XtraReports.UI
Imports System.Drawing.Imaging
Imports DevExpress.XtraPrinting.BarCode

Public Class Product
    Inherits System.Web.UI.Page
    Private objFcMathang As BO.QLMH_DM_MATHANGFacade
    Private objEnMathang As CM.QLMH_DM_MATHANGEntity
    Private objFcDinhmuc As BO.QLMH_DINHMUC_GIAMATHANGFacade
    Private objEnDinhmuc As CM.QLMH_DINHMUC_GIAMATHANGEntity
    Private objFcNhomMh As BO.QLMH_DM_NHOMMATHANGFacade
    Private objEnNhomMh As CM.QLMH_DM_NHOMMATHANGEntity
    Private objFcLoaiMh As BO.QLMH_DM_LOAIMATHANGFacade
    Private objEnLoaiMh As CM.QLMH_DM_LOAIMATHANGEntity
    Private objFcKho As BO.QLMH_DM_KHOFacade
    Private objEnKho As CM.QLMH_DM_KHOEntity
    Private objFcXuatxu As BO.QLMH_DM_XUATXUFacade
    Private objEnXuatxu As CM.QLMH_DM_XUATXUEntity
    Private objFcDonvi As BO.DMDonviFacade
    Private objEnDonvi As CM.DMDonviEntity
    Private objFcQuydoiDonvi As BO.DMQuyDoiDonViFacade
    Private objEnQuydoiDonvi As CM.DMQuyDoiDonViEntity
    Dim uId_mathang_dinhmuc As String
    Dim Grid_Dinhmuc As ASPxGridView
    Dim uid_Mathang As String
    Private pc As New Public_Class
    Private objFcThamsohethong As New BO.clsB_QT_THAMSOHETHONG
    Private Slist As String = ""
    Private ReadOnly Property ComandColumn() As GridViewCommandColumn
        Get
            Return CType(GrvInMavach.Columns(0), GridViewCommandColumn)
        End Get
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            loadDM()
            cboLoaimavach.Value = objFcThamsohethong.SelectTHAMSOHETHONGByID("v_Barcode").v_Giatri.ToString
        End If
        LoadMathang()
        loadMHBarcode()
        loadReport()
        'LoadCrystal()
    End Sub
#Region "load du lieu"
    ' load thong tin mat hang dua len gridview chinh
    Private Sub LoadMathang()
        Dim uid_loai As String
        Dim uId_Nhom As String
        objFcMathang = New BO.QLMH_DM_MATHANGFacade
        If cbo_Loaimathang.SelectedIndex = 0 Then
            uid_loai = 0
        Else
            uid_loai = cbo_Loaimathang.Value.ToString
        End If
        If cbo_Nhommathang.SelectedIndex = 0 Then
            uId_Nhom = 0
        Else
            uId_Nhom = cbo_Nhommathang.Value.ToString
        End If
        Dim dt As DataTable
        Try
            dt = objFcMathang.SelectTimKiem(uid_loai, uId_Nhom, "")
            Grid_Mathang.DataSource = dt
            Grid_Mathang.DataBind()
            'GrvInMavach.DataSource = dt
            'GrvInMavach.DataBind()
            'Grid_Mathang.DetailRows.ExpandRow(0)
            dt = Nothing
        Catch ex As Exception
        End Try
    End Sub
    'load thong tin nhom mat hang va loai mat hang dua vao combobox
    Private Sub loadDM()
        objFcLoaiMh = New BO.QLMH_DM_LOAIMATHANGFacade
        objFcNhomMh = New BO.QLMH_DM_NHOMMATHANGFacade
        objFcXuatxu = New BO.QLMH_DM_XUATXUFacade
        objFcDonvi = New BO.DMDonviFacade
        Dim dt As DataTable
        Dim dtn As DataTable
        Dim dtxuatxu As DataTable
        Dim dtdonvi As DataTable
        Try
            dt = objFcLoaiMh.SelectAllTable()
            Dim item As New ListEditItem
            item.Value = ""
            item.Text = "Tất cả"
            cbo_Loaimathang.Items.Add(item)
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    Dim newitem As New ListEditItem
                    newitem.Value = row("uId_Loaimathang")
                    newitem.Text = row("nv_Tenloaimathang_vn")
                    cbo_Loaimathang.Items.Add(newitem)
                Next
                Pcbo_Loaimathang.DataSource = dt
                Pcbo_Loaimathang.DataBind()
            End If
            dtn = objFcNhomMh.SelectAllTable()
            Dim nhomItem As New ListEditItem
            nhomItem.Value = ""
            nhomItem.Text = "Tất cả"
            cbo_Nhommathang.Items.Add(nhomItem)
            'load danh muc nhom mat hang va loai mat hang
            If dtn.Rows.Count > 0 Then
                For Each rown As DataRow In dtn.Rows
                    Dim nhomnewItem As New ListEditItem
                    nhomnewItem.Value = rown("uId_Nhommathang")
                    nhomnewItem.Text = rown("nv_Tennhommathang_vn")
                    cbo_Nhommathang.Items.Add(nhomnewItem)
                Next
                Pcbo_Nhommathang.DataSource = dtn
                Pcbo_Nhommathang.DataBind()
            End If
            'load danh muc xuat xu
            dtxuatxu = objFcXuatxu.SelectAllTable()
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dtxuatxu.Rows
                    Dim itemX As New ListEditItem
                    itemX.Value = row("uId_Xuatxu")
                    itemX.Text = row("nv_Tenxuatxu_vn")
                    Pcbo_Xuatxu.Items.Add(itemX)
                Next
            End If
            'load danh muc don vi tinh
            dtdonvi = objFcDonvi.SelectAllTable()
            If dtdonvi.Rows.Count > 0 Then
                Dim newrow As DataRow = dtdonvi.NewRow()
                newrow("madonvi") = "0"
                newrow("tendonvi") = "---"
                dtdonvi.Rows.Add(newrow)
                Pcbo_Donvi1.DataSource = dtdonvi
                Pcbo_Donvi2.DataSource = dtdonvi
                Pcbo_Donvi3.DataSource = dtdonvi
                Pcbo_Donvi1.DataBind()
                Pcbo_Donvi2.DataBind()
                Pcbo_Donvi3.DataBind()
            End If
        Catch ex As Exception

        End Try
    End Sub


#End Region
#Region "Kiểm tra"
    Public Function checkdata(str As String) As String
        Dim strdata As String
        If str <> "" Then
            strdata = str
        Else
            strdata = "0"
        End If
        Return strdata
    End Function
    Private Function CheckFloat(strfloat As String) As String
        Dim rDouble As Double
        Try
            If strfloat <> "" Then
                rDouble = Convert.ToDouble(strfloat)
            Else
                rDouble = 0
            End If
        Catch ex As Exception
        End Try
        Return rDouble
    End Function
#End Region
#Region "Grid event"
    Protected Sub Grid_GiaMathang_BeforePerformDataSelect(sender As Object, e As EventArgs)
        Grid_Dinhmuc = DirectCast(sender, ASPxGridView)
        Dim uId_Cuahang As String
        uId_mathang_dinhmuc = Nothing
        Dim dt As DataTable
        uId_mathang_dinhmuc = Grid_Dinhmuc.GetMasterRowKeyValue().ToString
        uId_Cuahang = Session("uId_Cuahang")
        objFcDinhmuc = New BO.QLMH_DINHMUC_GIAMATHANGFacade
        dt = objFcDinhmuc.SelectById_Mathang(uId_mathang_dinhmuc, uId_Cuahang)
        Grid_Dinhmuc.DataSource = dt
        dt = Nothing
    End Sub

    Protected Sub cbo_Loaimathang_SelectedIndexChanged(sender As Object, e As EventArgs)
        LoadMathang()
    End Sub
    Protected Sub cbo_Nhommathang_SelectedIndexChanged(sender As Object, e As EventArgs)
        LoadMathang()
    End Sub

    Protected Sub Grid_DinhMucGiaMathang_CellEditorInitialize1(sender As Object, e As ASPxGridViewEditorEventArgs)
        Try
            If e.Column.FieldName = "nv_Tenkho_vn" Then
                objFcKho = New BO.QLMH_DM_KHOFacade
                Dim cmb As ASPxComboBox = TryCast(e.Editor, ASPxComboBox)
                cmb.DataSource = objFcKho.SelectAllTable(Session("uId_Cuhang"))
                cmb.ValueField = "uId_Kho"
                cmb.ValueType = GetType(String)
                cmb.TextField = "nv_Tenkho_vn"
                cmb.DataBindItems()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub Grid_DinhMucGiaMathang_RowInserting(sender As Object, e As DevExpress.Web.Data.ASPxDataInsertingEventArgs)
        objEnDinhmuc = New CM.QLMH_DINHMUC_GIAMATHANGEntity
        objFcDinhmuc = New BO.QLMH_DINHMUC_GIAMATHANGFacade
        Dim uId_kho As String = e.NewValues("nv_Tenkho_vn").ToString
        Dim uId_Mathang As String = uId_mathang_dinhmuc
        Dim dt As DataTable
        dt = objFcDinhmuc.SelectCheck(uId_Mathang, uId_kho)
        Try
            If dt.Rows.Count = 0 Then
                With objEnDinhmuc
                    .uId_Kho = uId_kho
                    .d_Ngay = Date.Now.ToString
                    .f_Giaban = CheckFloat(e.NewValues("f_Giaban"))
                    .f_Gianhap = CheckFloat(e.NewValues("f_Gianhap"))
                    .f_Biendo_Giaban = CheckFloat(e.NewValues("f_Biendo_Giaban"))
                    .f_Biendo_Gianhap = CheckFloat(e.NewValues("f_Biendo_Gianhap"))
                    .uId_Mathang = uId_Mathang
                End With
                objFcDinhmuc.Insert(objEnDinhmuc)
                Grid_Dinhmuc.CancelEdit()
                Grid_Dinhmuc = Nothing
                e.Cancel = True
            Else
                Grid_Dinhmuc.CancelEdit()
                e.Cancel = True
                Return
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub Grid_DinhMucGiaMathang_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
        objEnDinhmuc = New CM.QLMH_DINHMUC_GIAMATHANGEntity
        objFcDinhmuc = New BO.QLMH_DINHMUC_GIAMATHANGFacade
        Try
            Dim uId_dinhmuc As String = e.Keys(0).ToString
            Dim uId_mahang As String = uId_mathang_dinhmuc
            Dim uId_kho As String = e.NewValues("nv_Tenkho_vn").ToString
            With objEnDinhmuc
                .uId_Kho = uId_kho
                .uId_Mathang = uId_mahang
                .uId_Dinhmuc_Giamathang = uId_dinhmuc
                .f_Giaban = CheckFloat(e.NewValues("f_Giaban"))
                .f_Gianhap = CheckFloat(e.NewValues("f_Gianhap"))
                .f_Biendo_Giaban = CheckFloat(e.NewValues("f_Biendo_Giaban"))
                .f_Biendo_Gianhap = CheckFloat(e.NewValues("f_Biendo_Gianhap"))
                objFcDinhmuc.Update(objEnDinhmuc)
                Grid_Dinhmuc.CancelEdit()
                Grid_Dinhmuc = Nothing
                e.Cancel = True
            End With
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub Grid_DinhMucGiaMathang_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        Dim uid_dinhmuc As String = e.Keys(0).ToString
        objFcDinhmuc = New BO.QLMH_DINHMUC_GIAMATHANGFacade
        Try
            objFcDinhmuc.DeleteByID(uid_dinhmuc)
            e.Cancel = True
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Grid_Mathang_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles Grid_Mathang.RowDeleting
        Dim uId_mathang As String = e.Keys(0).ToString
        objFcMathang = New BO.QLMH_DM_MATHANGFacade
        objFcMathang.DeleteByID(uId_mathang)
        e.Cancel = True
        LoadMathang()
    End Sub

#End Region
#Region "buttom click"
    'luu du lieu khi them hoac sua
    Private Sub btOK_Click(sender As Object, e As EventArgs) Handles btOK.Click
        lbl_.Text = ""
        objEnDinhmuc = New CM.QLMH_DINHMUC_GIAMATHANGEntity
        objEnQuydoiDonvi = New CM.DMQuyDoiDonViEntity
        objEnMathang = New CM.QLMH_DM_MATHANGEntity
        objFcDinhmuc = New BO.QLMH_DINHMUC_GIAMATHANGFacade
        objFcQuydoiDonvi = New BO.DMQuyDoiDonViFacade
        objFcMathang = New BO.QLMH_DM_MATHANGFacade
        objFcKho = New BO.QLMH_DM_KHOFacade
        Dim dt As DataTable
        dt = objFcKho.SelectAllTable(Session("uId_Cuahang"))
        Try
            With objEnMathang
                .v_MaMathang = txt_Mamathang.Text
                .v_MaBarcode = txt_Mavach.Text
                .uId_Loaimathang = Pcbo_Loaimathang.Value
                .uId_Nhommathang = Pcbo_Nhommathang.Value
                .uId_Xuatxu = Pcbo_Xuatxu.Value
                .nv_TenMathang_vn = txt_Tenmathang.Text
                .nv_TenMathang_en = ""
                .f_PhantramHH_KTV = CheckFloat(txt_Banle.Text)
                .f_PhantramHH_TVV = CheckFloat(txt_Banlekhac.Text)
                .f_PhantramHH_NV = CheckFloat(txt_Banbuonkhac.Text)
                .f_PhamtramHH_CTV = CheckFloat(txt_Banbuon.Text)
                .f_Hanmuc_Ton = CheckFloat(txt_Hanmucton.Text)
                .i_Songaycanhbao_Ton = CheckFloat(txt_Canhbaoton.Text)
                .i_Songaycanhbao_HethanSD = CheckFloat(txt_CanhbaoHD.Text)
                .nv_Ghichu_vn = txt_Ghichu.Text
                .nv_Ghichu_en = ""
                .nv_DVT_en = ""
                .nv_DVT_vn = ""
            End With
            If hdfuIdMathang.Value = "" Then 'insert
                Dim dt_Check As DataTable = objFcMathang.Select_By_Mathang_Table(txt_Mamathang.Text.Trim)
                If dt_Check.Rows.Count > 0 Then
                    lbl_.Text = "Mã mặt hàng trùng !"
                    Exit Sub
                End If
                uid_Mathang = objFcMathang.Insert(objEnMathang)
                'insert vao bang dinh muc
                If txt_DMGianhap.Text <> "" Or txt_DMGiaxuat.Text <> "" Then
                    If dt.Rows.Count > 0 Then 'dt bang kho cua cua hang
                        For Each row As DataRow In dt.Rows
                            With objEnDinhmuc
                                .d_Ngay = Date.Now.ToString
                                .f_Giaban = CheckFloat(txt_DMGiaxuat.Text)
                                .f_Gianhap = CheckFloat(txt_DMGianhap.Text)
                                .f_Biendo_Giaban = 0
                                .f_Biendo_Gianhap = 0
                            End With
                            objEnDinhmuc.uId_Mathang = uid_Mathang
                            objEnDinhmuc.uId_Kho = row("uId_Kho").ToString
                            objFcDinhmuc.Insert(objEnDinhmuc)
                        Next
                    End If
                End If
                'insert bang quy doi don vi
                If Pcbo_Donvi3.Value.ToString = "0" Then
                    If Pcbo_Donvi2.Value.ToString <> "0" Then
                        objEnQuydoiDonvi.MaDonVi32 = Pcbo_Donvi2.Value
                        objEnQuydoiDonvi.SoLuong32 = 1
                        objEnQuydoiDonvi.MaDonVi21 = Pcbo_Donvi2.Value
                        objEnQuydoiDonvi.SoLuong21 = txt_tile21.Text
                    Else
                        objEnQuydoiDonvi.MaDonVi32 = Pcbo_Donvi1.Value
                        objEnQuydoiDonvi.MaDonVi21 = Pcbo_Donvi1.Value
                        objEnQuydoiDonvi.SoLuong32 = 1
                        objEnQuydoiDonvi.SoLuong21 = 1
                    End If
                Else
                    If Pcbo_Donvi2.Value.ToString = "0" Then
                        objEnQuydoiDonvi.MaDonVi32 = Pcbo_Donvi1.Value
                        objEnQuydoiDonvi.MaDonVi21 = Pcbo_Donvi1.Value
                        objEnQuydoiDonvi.SoLuong32 = 1
                        objEnQuydoiDonvi.SoLuong21 = 1
                    Else
                        objEnQuydoiDonvi.MaDonVi32 = Pcbo_Donvi3.Value
                        objEnQuydoiDonvi.SoLuong32 = txt_Tile32.Text
                        objEnQuydoiDonvi.MaDonVi21 = Pcbo_Donvi2.Value
                        objEnQuydoiDonvi.SoLuong21 = txt_tile21.Text
                    End If
                End If
                If Pcbo_Donvi1.Value.ToString = Pcbo_Donvi2.Value.ToString Then
                    objEnQuydoiDonvi.SoLuong21 = 1
                End If
                If Pcbo_Donvi3.Value.ToString = Pcbo_Donvi2.Value.ToString Then
                    objEnQuydoiDonvi.SoLuong32 = 1
                End If
                objEnQuydoiDonvi.MaVatTu = uid_Mathang
                objEnQuydoiDonvi.MaDonVi1 = Pcbo_Donvi1.Value
                objFcQuydoiDonvi.Insert(objEnQuydoiDonvi)
                lbl_.Text = "Thêm mới thành công"
                Cleartext()
            Else ' update mat hang
                objEnMathang.uId_Mathang = hdfuIdMathang.Value.ToString
                objFcMathang.Update(objEnMathang)
                'update dinh muc gia
                If txt_DMGianhap.Text <> "" Or txt_DMGiaxuat.Text <> "" Then
                    With objEnDinhmuc
                        .d_Ngay = Date.Now.ToString
                        .f_Giaban = CheckFloat(txt_DMGiaxuat.Text)
                        .f_Gianhap = CheckFloat(txt_DMGianhap.Text)
                        .f_Biendo_Giaban = 0
                        .f_Biendo_Gianhap = 0
                    End With
                    If dt.Rows.Count > 0 Then
                        For Each row As DataRow In dt.Rows
                            Dim dtdm As DataTable
                            dtdm = objFcDinhmuc.SelectCheck(hdfuIdMathang.Value, row("uId_Kho").ToString)
                            If dtdm.Rows.Count > 0 Then
                                For Each rows As DataRow In dtdm.Rows
                                    objEnDinhmuc.uId_Mathang = hdfuIdMathang.Value.ToString
                                    objEnDinhmuc.uId_Kho = row("uId_Kho").ToString
                                    objEnDinhmuc.uId_Dinhmuc_Giamathang = rows("uId_Dinhmuc_Giamathang").ToString
                                    objFcDinhmuc.Update(objEnDinhmuc)
                                Next
                            Else
                                objEnDinhmuc.uId_Kho = row("uId_Kho").ToString
                                objEnDinhmuc.uId_Mathang = hdfuIdMathang.Value.ToString
                                objFcDinhmuc.Insert(objEnDinhmuc)
                            End If
                        Next
                    End If
                End If
                'update quy doi don vi
                objEnQuydoiDonvi.MaVatTu = hdfuIdMathang.Value
                If Pcbo_Donvi3.Value.ToString = "0" Then
                    If Pcbo_Donvi2.Value.ToString <> "0" Then
                        objEnQuydoiDonvi.MaDonVi32 = Pcbo_Donvi2.Value
                        objEnQuydoiDonvi.SoLuong32 = 1
                        objEnQuydoiDonvi.MaDonVi21 = Pcbo_Donvi2.Value
                        objEnQuydoiDonvi.SoLuong21 = txt_tile21.Text
                    Else
                        objEnQuydoiDonvi.MaDonVi32 = Pcbo_Donvi1.Value
                        objEnQuydoiDonvi.MaDonVi21 = Pcbo_Donvi1.Value
                        objEnQuydoiDonvi.SoLuong32 = 1
                        objEnQuydoiDonvi.SoLuong21 = 1
                    End If
                Else
                    If Pcbo_Donvi2.Value.ToString = "0" Then
                        objEnQuydoiDonvi.MaDonVi32 = Pcbo_Donvi1.Value
                        objEnQuydoiDonvi.MaDonVi21 = Pcbo_Donvi1.Value
                        objEnQuydoiDonvi.SoLuong32 = 1
                        objEnQuydoiDonvi.SoLuong21 = 1
                    Else
                        objEnQuydoiDonvi.MaDonVi32 = Pcbo_Donvi3.Value
                        objEnQuydoiDonvi.SoLuong32 = txt_Tile32.Text
                        objEnQuydoiDonvi.MaDonVi21 = Pcbo_Donvi2.Value
                        objEnQuydoiDonvi.SoLuong21 = txt_tile21.Text
                    End If
                End If
                If Pcbo_Donvi1.Value.ToString = Pcbo_Donvi2.Value.ToString Then
                    objEnQuydoiDonvi.SoLuong21 = 1
                End If
                If Pcbo_Donvi3.Value.ToString = Pcbo_Donvi2.Value.ToString Then
                    objEnQuydoiDonvi.SoLuong32 = 1
                End If
                If objFcQuydoiDonvi.SelectCheck(hdfuIdMathang.Value.ToString) = True Then ' kiem tra mat hang da co trong bang quy doi don vi chưa
                    objEnQuydoiDonvi.MaDonVi1 = Pcbo_Donvi1.Value ' da co trong bang quy doi don vi thi update
                    objFcQuydoiDonvi.Update(objEnQuydoiDonvi)
                Else ' chua co thi insert
                    objEnQuydoiDonvi.MaDonVi1 = Pcbo_Donvi1.Value
                    objFcQuydoiDonvi.Insert(objEnQuydoiDonvi)
                End If
                lbl_.Text = "Chỉnh sửa thành công"
                imgBarecode.ImageUrl = "../../../../OrangeVersion/Product/MaVachSP.aspx?value=" + cboLoaimavach.Value.ToString + "$" + txt_Mavach.Text
                lblBarecode.Text = txt_Mavach.Text
            End If
        Catch ex As Exception
        End Try
    End Sub
    'tim kiem voi dieu kien khach hang dua vao
    'xuat excel
    Protected Sub btnExportExcel_Click(sender As Object, e As EventArgs)
        UpdatExportMode()
        Export_Mathang.WriteXlsxToResponse()
    End Sub
    Protected Sub link_Taiexcl_Mau_Click(sender As Object, e As EventArgs)
        Response.Redirect("../../Excel/Excel_Mau_Mathang.xls")
    End Sub
    'nhap tu excel
    Private Sub btn_Import_Click(sender As Object, e As EventArgs) Handles btn_Import.Click
        If UploadFileExcel.HasFile Then
            btn_Import.Enabled = False
            Dim FileName As String = Path.GetFileNameWithoutExtension(UploadFileExcel.PostedFile.FileName)
            Dim Extension As String = Path.GetExtension(UploadFileExcel.PostedFile.FileName)
            Dim FolderPath As String = ConfigurationManager.AppSettings("FolderPath")
            FileName = pc.ReturnAutoString(FileName)
            Dim FilePath As String = Server.MapPath(FolderPath + FileName + Extension)
            UploadFileExcel.SaveAs(FilePath)
            Import_To_Grid(FilePath, Extension)
        End If
    End Sub

#End Region
#Region "Support"
    Private Sub Cleartext()
        Dim strmamathang As String
        strmamathang = pc.ReturnAutoString("H")
        txt_Tenmathang.Text = ""
        txt_Hanmucton.Text = ""
        txt_Mavach.Text = ""
        txt_CanhbaoHD.Text = ""
        txt_Canhbaoton.Text = ""
        txt_DMGianhap.Text = ""
        txt_Mamathang.Text = strmamathang
        txt_Ghichu.Text = ""
        txt_Tenmathang.Focus()
    End Sub
    Protected Sub UpdatExportMode()
        Grid_Mathang.SettingsDetail.ExportMode = CType(System.Enum.Parse(GetType(GridViewDetailExportMode), GridViewDetailExportMode.None.ToString()), GridViewDetailExportMode)
    End Sub
    'doc file excel tai len tu client dua vao table
    Private Sub Import_To_Grid(ByVal FilePath As String, ByVal Extension As String)
        objFcMathang = New BO.QLMH_DM_MATHANGFacade
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
        Dim SheetName As String = "MatHang$"
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
    'doc table tu excel va insert vao database
    Private Sub ExcelInsert(dt As DataTable)
        objEnMathang = New CM.QLMH_DM_MATHANGEntity
        objFcMathang = New BO.QLMH_DM_MATHANGFacade
        objFcLoaiMh = New BO.QLMH_DM_LOAIMATHANGFacade
        objFcNhomMh = New BO.QLMH_DM_NHOMMATHANGFacade
        objFcQuydoiDonvi = New BO.DMQuyDoiDonViFacade
        objEnQuydoiDonvi = New CM.DMQuyDoiDonViEntity
        objFcKho = New BO.QLMH_DM_KHOFacade
        objEnDinhmuc = New CM.QLMH_DINHMUC_GIAMATHANGEntity
        objFcDinhmuc = New BO.QLMH_DINHMUC_GIAMATHANGFacade
        Dim i As Integer = 0
        Dim dtkho As DataTable
        dtkho = objFcKho.SelectAllTable(Session("uId_Cuahang"))
        Dim mamathang As String = pc.ReturnAutoString("")
        Try
            For Each row As DataRow In dt.Rows
                With objEnMathang
                    .uId_Loaimathang = objFcLoaiMh.SellectcheckMa(row("Mã loại mặt hàng").ToString) 'kiem tra ma loai mat hang co uid la gi
                    .uId_Nhommathang = objFcNhomMh.SelectcheckMa(row("Mã nhóm mặt hàng").ToString)
                    .nv_TenMathang_vn = row("Tên mặt hàng").ToString
                    .f_Hanmuc_Ton = row("Hạn mức tồn").ToString
                    If row("Mã mặt hàng").ToString <> "" Then
                        .v_MaMathang = row("Mã mặt hàng").ToString
                    Else
                        .v_MaMathang = "H" + (Convert.ToDouble(mamathang) + i).ToString
                    End If
                    .v_MaBarcode = ""
                    .uId_Xuatxu = "4680f3db-ea45-4225-b8b0-f7cbecc7b20c"
                    .nv_TenMathang_en = ""
                    .f_PhantramHH_KTV = 0
                    .f_PhantramHH_TVV = 0
                    .f_PhantramHH_NV = 0
                    .f_PhamtramHH_CTV = 0
                    .i_Songaycanhbao_Ton = Nothing
                    .i_Songaycanhbao_HethanSD = Nothing
                    .nv_Ghichu_vn = ""
                    .nv_Ghichu_en = ""
                    .nv_DVT_en = ""
                    .nv_DVT_vn = ""
                End With
                uid_Mathang = objFcMathang.Insert(objEnMathang)
                If row("Định mức giá nhập").ToString <> "" Or row("Định mức giá xuất").ToString <> "" Then
                    If dtkho.Rows.Count > 0 Then 'dt bang kho cua cua hang
                        For Each rows As DataRow In dtkho.Rows
                            With objEnDinhmuc
                                .d_Ngay = Date.Now.ToString
                                .f_Gianhap = CheckFloat(row("Định mức giá nhập").ToString)
                                .f_Giaban = CheckFloat(row("Định mức giá xuất").ToString)
                                .f_Biendo_Giaban = 0
                                .f_Biendo_Gianhap = 0
                            End With
                            objEnDinhmuc.uId_Mathang = uid_Mathang
                            objEnDinhmuc.uId_Kho = rows("uId_Kho").ToString
                            objFcDinhmuc.Insert(objEnDinhmuc)
                        Next
                    End If
                End If
                With objEnQuydoiDonvi
                    .MaVatTu = uid_Mathang
                    .MaDonVi1 = row("Mã đơn vị").ToString
                    .MaDonVi21 = row("Mã đơn vị").ToString
                    .MaDonVi32 = row("Mã đơn vị").ToString
                    .SoLuong21 = 1
                    .SoLuong32 = 1
                    .DonGiaDV11 = Nothing
                    .DonGiaDV21 = Nothing
                    .DonGiaDV32 = Nothing
                End With
                objFcQuydoiDonvi.Insert(objEnQuydoiDonvi)
                LoadMathang()
                i += 1
            Next
        Catch ex As Exception
        End Try
        lbl_Import.Text = "Thêm thành công từ excel: " + i.ToString + "Ma"
        dt = Nothing
        btn_Import.Enabled = True
    End Sub
#End Region

    Protected Sub ASPxCallbackPanel1_Callback(sender As Object, e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase)
        imgBarecode.ImageUrl = "../../../../OrangeVersion/Product/MaVachSP.aspx?value=" + cboLoaimavach.Value.ToString + "$" + txt_Mavach.Text
        lblBarecode.Text = txt_Mavach.Text
    End Sub


#Region "In ma barcode"
    Public Function CreateCode128BarCode(ByVal BarCodeText As String, Type As String) As XRBarCode
        Dim barCode As New XRBarCode()
        If Type = "128" Then
            barCode.Symbology = New Code128Generator()
            'CType(barCode.Symbology, Code128Generator).CharacterSet = Code128Charset.CharsetC
        Else
            barCode.Symbology = New EAN13Generator
            'CType(barCode.Symbology, EAN128Generator).CharacterSet = Code128Charset.CharsetC
        End If
        barCode.Text = BarCodeText
        barCode.Width = Convert.ToInt32(objFcThamsohethong.SelectTHAMSOHETHONGByID("BcodeW").v_Giatri.ToString)
        barCode.Height = Convert.ToInt32(objFcThamsohethong.SelectTHAMSOHETHONGByID("BcodeH").v_Giatri.ToString) - 10
        barCode.AutoModule = True
        barCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter
        Return barCode
    End Function

    'Private Sub LoadCrystal()
    '    Dim BC As New Xtra_Product_InBarcode
    '    BC.Detail.Controls.Add(CreateCode128BarCode("12345678", "128"))
    '    ReportViewer1.Report = BC
    'End Sub
    Public Shared Function ImageToByte(ByVal img As Image) As Byte()
        Dim imgStream As MemoryStream = New MemoryStream()
        img.Save(imgStream, System.Drawing.Imaging.ImageFormat.Png)
        imgStream.Close()
        Dim byteArray As Byte() = imgStream.ToArray()
        imgStream.Dispose()

        Return byteArray
    End Function

    Private Sub loadMHBarcode()
        Dim dt As DataTable
        If cbo_Nhommathang.SelectedIndex = 0 Then
            dt = objFcMathang.SelectAllBarcode("")
        Else
            dt = objFcMathang.SelectAllBarcode(cbo_Nhommathang.Value)
        End If
        If dt.Rows.Count = 0 Then
            dt.Rows.Add(dt.NewRow)
        End If
        GrvInMavach.DataSource = dt
        GrvInMavach.DataBind()
        'Dim checkboxIdsList As New List(Of String)
        'For i As Integer = 0 To GrvInMavach.VisibleRowCount - 1
        '    If GrvInMavach.Selection.IsRowSelected(i) Then
        '        checkboxIdsList.Add(GrvInMavach.GetRowValues(i, "v_MaBarcode"))
        '    End If
        'Next
        'For Each rowItem As ASPxGridView In Grid_Mathang.VisibleRowCount
        '    chk = CType(rowItem.Cells(0).FindControl("ChkChon"), CheckBox)
        '    checkboxIdsList.Add(chk.ClientID)
        'Next

        'Dim checkboxIds As String = String.Join("|", checkboxIdsList.ToArray())
        'CType(Grid_Mathang.HeaderRow.Cells(0).FindControl("chkSelectAll"), CheckBox).Attributes.Add("onclick", "selectAll('" & checkboxIds & "',this)")
        'If Session("DS_SPBarcode").ToString <> "" Then
        '    Dim strDS_SP As String = Session("DS_SPBarcode").ToString
        '    For i As Integer = 0 To GvSPBarcode.Rows.Count - 1
        '        If (InStr(strDS_SP, GvSPBarcode.Rows(i).Cells(3).Text) > 0) Then
        '            CType(GvSPBarcode.Rows(i).Cells(0).FindControl("ChkChon"), CheckBox).Checked = True
        '        End If
        '    Next
        'End If
    End Sub

    Private Sub SaveDS_SP()
        For i As Integer = 0 To GrvInMavach.VisibleRowCount - 1
            If GrvInMavach.Selection.IsRowSelected(i) Then
                Dim op As String = GrvInMavach.GetRowValues(i, "v_MaBarcode").ToString
                If InStr(Slist, op) = 0 And op.Length > 9 Then
                    If Slist = "" Then
                        Slist += op
                    Else
                        Slist = Slist + ";" + op
                    End If
                End If
            End If
            'Dim chk As CheckBox = Grid_Mathang.FindRowTemplateControl(i, "chkChon")
            'If chk.Checked = True Then
            '    If InStr(strDS_Sp, Grid_Mathang.GetRowValues(i, "v_MaBarcode")) = 0 And Grid_Mathang.GetRowValues(i, "v_MaBarcode").ToString.Length > 9 Then
            '        strDS_Sp = strDS_Sp + ";" + Grid_Mathang.GetRowValues(i, "v_MaBarcode")
            '    End If
            'Else

            'End If
        Next
    End Sub
    Private Sub loadReport()
        objFcThamsohethong = New BO.clsB_QT_THAMSOHETHONG
        SaveDS_SP()
        Dim BC As New Xtra_Product_InBarcode
        Dim dtbarcode As XRTable = New XRTable()
        dtbarcode.BeginInit()
        Dim cellsInRow As Integer = 4
        Dim rowHeight As Single = 60
        Dim k As Integer = 0
        Dim j As Integer = cellsInRow - 1    
        dtbarcode.Width = (BC.PageWidth - (BC.Margins.Left + BC.Margins.Right))   
        For ii As Integer = 0 To BC.PageHeight / rowHeight Step 1
            Dim detailRow As XRTableRow = New XRTableRow()
            detailRow.Width = dtbarcode.Width
            detailRow.Height = rowHeight
            detailRow.Padding = 20
            dtbarcode.Rows.Add(detailRow)
            Dim type As String
            Dim strcode As String
            Dim strDS_SP() As String
            If Slist <> "" Then
                strDS_SP = Slist.Split(";")
            Else
                strDS_SP = Nothing
            End If
            For i As Integer = k To j
                Dim bol As Boolean = False
                If strDS_SP IsNot Nothing Then
                    If strDS_SP.Length - 1 >= i Then
                        If strDS_SP(i) <> "" Then
                            If IsNumeric(strDS_SP(i)) Then
                                strcode = strDS_SP(i)
                                type = "EAN"
                            Else
                                strcode = strDS_SP(i)
                                type = "128"
                            End If
                            bol = True

                        Else
                            bol = False
                            strcode = ""
                            type = ""
                        End If
                    Else
                        bol = False
                        strcode = ""
                        type = ""
                    End If
                Else
                    bol = False
                    strcode = ""
                    type = ""
                End If
                Dim detailCell As XRTableCell = New XRTableCell()
                detailCell.Width = Convert.ToInt32(objFcThamsohethong.SelectTHAMSOHETHONGByID("BcodeW").v_Giatri.ToString)
                If bol = True Then
                    detailCell.Controls.Add(CreateCode128BarCode(strcode, type))
                    detailCell.Padding = 20
                End If
                'If i = 0 Then
                '    detailCell.Borders = DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Bottom
                'Else
                '    detailCell.Borders = DevExpress.XtraPrinting.BorderSide.All
                'End If
                ' Place the cells into the corresponding tables
                detailRow.Cells.Add(detailCell)
            Next i
            k = j + 1
            j = j + 4
        Next
        'new
        dtbarcode.EndInit()

        ' Place the table onto a report's Detail band
        BC.Bands(BandKind.Detail).Controls.Add(dtbarcode)
        'If strDS_SP.Length >= 1 Then
        '    For i As Integer = 0 To strDS_SP.Length - 1
        '        If strDS_SP(i) <> "" Then
        '            If IsNumeric(strDS_SP(i)) Then
        '                strcode = strDS_SP(i)
        '            Else
        '                strcode = strDS_SP(i)
        '            End If
        '            If k = 1 Then
        '                Dim cell As New XRTableCell()
        '                'cell.Controls.Add(CreateCode128BarCode(strcode, "128"))
        '                row.Cells.Add(cell)
        '            ElseIf k = 2 Then
        '                Dim cell As New XRTableCell()
        '                'cell.Controls.Add(CreateCode128BarCode(strcode, "128"))
        '                row.Cells.Add(cell)
        '            ElseIf k = 3 Then
        '                Dim cell As New XRTableCell()
        '                'cell.Controls.Add(CreateCode128BarCode(strcode, "128"))
        '                row.Cells.Add(cell)
        '            ElseIf k = 4 Then
        '                Dim cell As New XRTableCell()
        '                'cell.Controls.Add(CreateCode128BarCode(strcode, "128"))
        '                row.Cells.Add(cell)
        '            End If
        '            If k = 4 Then
        '                k = 1
        '                j += 1
        '            Else : k += 1
        '            End If
        '        End If
        '    Next
        'End If
        BC.Detail.Controls.Add(dtbarcode)
        'BC.Setdata(dtbarcode)
        ReportViewer1.Report = BC
    End Sub
    'Private Sub LoadCrystal()
    '    Dim BC = New Xtra_Product_InBarcode
    '    Dim dtbarcode As New DataTable
    '    dtbarcode.Columns.Add(New DataColumn("BarcodeImg1", System.Type.GetType("System.Byte[]")))
    '    dtbarcode.Columns.Add(New DataColumn("BarcodeImg2", System.Type.GetType("System.Byte[]")))
    '    dtbarcode.Columns.Add(New DataColumn("BarcodeImg3", System.Type.GetType("System.Byte[]")))
    '    dtbarcode.Columns.Add(New DataColumn("BarcodeImg4", System.Type.GetType("System.Byte[]")))
    '    dtbarcode.Columns.Add(New DataColumn("BarcodeText1", System.Type.GetType("System.String")))
    '    dtbarcode.Columns.Add(New DataColumn("BarcodeText2", System.Type.GetType("System.String")))
    '    dtbarcode.Columns.Add(New DataColumn("BarcodeText3", System.Type.GetType("System.String")))
    '    dtbarcode.Columns.Add(New DataColumn("BarcodeText4", System.Type.GetType("System.String")))
    '    Dim k As Integer = 1
    '    Dim j As Integer = 0
    '    Dim strcode As String
    '    Dim strDS_SP() As String = "8931234001285;8931234000127".Split(";")
    '    Dim i As Integer = 0
    '    Dim barcode As Barcode
    '    While i < strDS_SP.Length
    '        If IsNumeric(strDS_SP(i)) Then
    '            'strcode = Mid(strDS_SP, i, 13)
    '            strcode = strDS_SP(i)
    '            'i += 14
    '            barcode = New BarcodeEAN
    '        Else
    '            'strcode = Mid(strDS_SP, i, 10)
    '            'i += 11
    '            strcode = strDS_SP(i)
    '            barcode = New Barcode128
    '        End If
    '        barcode.BarHeight = 50
    '        If k = 1 Then
    '            dtbarcode.Rows.Add(dtbarcode.NewRow)
    '            dtbarcode.Rows(j)("BarcodeText1") = strcode
    '            barcode.Code = strcode
    '            dtbarcode.Rows(j)("BarcodeImg1") = ImageToByte(barcode.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White))
    '        End If
    '        If k = 2 Then
    '            dtbarcode.Rows(j)("BarcodeText2") = strcode
    '            barcode.Code = strcode
    '            dtbarcode.Rows(j)("BarcodeImg2") = ImageToByte(barcode.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White))
    '        End If
    '        If k = 3 Then
    '            dtbarcode.Rows(j)("BarcodeText3") = strcode
    '            barcode.Code = strcode
    '            dtbarcode.Rows(j)("BarcodeImg3") = ImageToByte(barcode.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White))
    '        End If
    '        If k = 4 Then
    '            dtbarcode.Rows(j)("BarcodeText4") = strcode
    '            barcode.Code = strcode
    '            dtbarcode.Rows(j)("BarcodeImg4") = ImageToByte(barcode.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White))
    '        End If
    '        If k = 4 Then
    '            k = 1
    '            j += 1
    '        Else : k += 1
    '        End If
    '    End While
    '    BC.BindingSource1.DataSource = dtbarcode
    '    ReportViewer1.Report = BC
    'End Sub
#End Region

    Protected Sub btnTaoMavach_Click(sender As Object, e As EventArgs)
        loadReport()
    End Sub

    Protected Sub GrvInMavach_CustomJSProperties(sender As Object, e As ASPxGridViewClientJSPropertiesEventArgs)

    End Sub
End Class