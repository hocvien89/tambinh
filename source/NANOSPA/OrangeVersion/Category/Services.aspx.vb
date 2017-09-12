Imports DevExpress.Web.ASPxEditors
Imports System.Data.OleDb
Imports System.IO

Public Class Services
    Inherits System.Web.UI.Page
    Private objBoNhomdv As BO.TNTP_DM_NHOMDICHVUFacade
    Private objCmNhomdv As CM.TNTP_DM_NHOMDICHVUEntity
    Private objBoDichvu As BO.TNTP_DM_DICHVUFacade
    Private objCmDichvu As CM.TNTP_DM_DICHVUEntity
    Private objCmGoidv As CM.TNTP_DM_GOIDICHVUEntity
    Private objBoGoidv As BO.TNTP_DM_GOIDICHVUFacade
    Private objBoNgoaite As BO.TNTP_DM_NGOAITEFacade
    Private objBoCongdoan_Dv As BO.TNTP_DM_DICHVU_CONGDOANFacade
    Private objCmCongdoan_Dv As CM.TNTP_DM_DICHVU_CONGDOANEntity
    Private objBoCongdoan As BO.TNTP_QT_DIEUTRI_CONGDOANFacade
    Private objCmCongdoan As CM.TNTP_QT_DIEUTRI_CONGDOANEntity
    Private objEnMathang As CM.QLMH_DM_MATHANGEntity
    Private objFcMathang As BO.QLMH_DM_MATHANGFacade
    Private objFcGoidvDichvu As BO.TNTP_GOIDICHVU_DICHVUFacade
    Private objEnGoidvDichvu As CM.TNTP_GOIDICHVU_DICHVUEntity
    Private pc As New Public_Class
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Load_NhomDV()
            loadpupop()
            loadKho()
            loadCongdoan()
            loadMathang()
            chkKho.Checked = True
            cboKho.SelectedIndex = 0
            cboCongdoan.SelectedIndex = 0
            dateTungay.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
            dateDenngay.Text = Strings.Format(DateAndTime.Now, "dd/MM/yyyy")
            LoadDichvugoi()
        End If
        If cmb_Nhomdichvu.SelectedIndex = 0 Then
            Load_Dichvu("", Session("uId_Cuahang"))
        Else
            Load_Dichvu(cmb_Nhomdichvu.Value.ToString, Session("uId_Cuahang"))
        End If
        loadpCongdoan()
        Loadlist_Dichvuuathich(dateTungay.Value, dateDenngay.Value)
        If hdfuIdDichvu.Value <> Nothing Then
            LoadGrvDichvugoi()
        End If
    End Sub
#Region "kiểm tra dữ liệu vào"
    Private Function CheckInData(datain As String)
        Dim dataout As Double
        Try
            If datain <> "" Then
                dataout = Convert.ToDouble(datain)
            Else
                dataout = Nothing
            End If
        Catch ex As Exception

        End Try
        Return dataout
    End Function
    'kiem tra phan tram hoa hong 
    Private Function CheckHoahong(hoahong As String, gia As String) As String
        Dim Phantram, Giadv As Double
        Try
            If hoahong <> "" Then
                Giadv = Convert.ToDouble(gia)
                Phantram = Convert.ToDouble(hoahong)
            Else
                Phantram = 0
            End If
            If Phantram < 100 Then
                Phantram = Giadv * Phantram / 100
            End If
        Catch ex As Exception

        End Try
        Return Phantram
    End Function
    'xoa du lieu sau khi them moi thanh cong
    Private Sub cleartext()
        txt_Tendichvu.Text = ""
        txt_GiaDV.Text = ""
        txt_Giamgia.Text = ""
        txt_Tgchuanbi.Text = ""
        txt_Tgthuchien.Text = ""
        txt_Solandieutri.Text = ""
        txt_HHCongtac.Text = ""
        txt_HHNhanvienchinh.Text = ""
        txt_HHNhanvienphu.Text = ""
        txt_HHTuvan.Text = ""
        txt_Tendichvu.Focus()
    End Sub

#End Region
#Region "tải dữ liệu"
    Private Sub Load_NhomDV()
        objCmNhomdv = New CM.TNTP_DM_NHOMDICHVUEntity
        objBoNhomdv = New BO.TNTP_DM_NHOMDICHVUFacade
        Dim dt As DataTable
        dt = objBoNhomdv.SelectAllTable(Session("uId_Cuahang"))
        Try
            Dim item As New ListEditItem
            item.Value = ""
            item.Text = "Tất cả"
            cmb_Nhomdichvu.Items.Add(item)
            If dt.Rows.Count > 0 Then
                For Each row As DataRow In dt.Rows
                    Dim newitem As New ListEditItem
                    newitem.Value = row("uId_Nhomdichvu")
                    newitem.Text = row("nv_TennhomDichvu_vn")
                    cmb_Nhomdichvu.Items.Add(newitem)
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub loadpupop()
        objBoNhomdv = New BO.TNTP_DM_NHOMDICHVUFacade
        objBoGoidv = New BO.TNTP_DM_GOIDICHVUFacade
        objBoNgoaite = New BO.TNTP_DM_NGOAITEFacade
        Dim dtNhom As DataTable
        Dim dtgoi As DataTable
        Dim dtNgoai As DataTable
        dtNhom = objBoNhomdv.SelectAllTable(Session("uId_Cuahang"))
        dtgoi = objBoGoidv.SelectAllTable()
        dtNgoai = objBoNgoaite.SelectAllTable()
        Try
            If dtNhom.Rows.Count > 0 Then
                Dim items As New ListEditItem
                items.Value = "D5D55FFF-00E7-4669-9E05-00CCC435CA1A"
                items.Text = "---"
                pcmb_NhomDV.Items.Add(items)
                For Each row As DataRow In dtNhom.Rows
                    Dim item As New ListEditItem
                    item.Value = row("uId_Nhomdichvu")
                    item.Text = row("nv_TennhomDichvu_vn")
                    pcmb_NhomDV.Items.Add(item)
                Next
            End If
            If dtNgoai.Rows.Count > 0 Then
                Dim itemsNT As New ListEditItem
                itemsNT.Value = "0"
                itemsNT.Text = "---"
                pcmb_Ngoaite.Items.Add(itemsNT)
                For Each rowN As DataRow In dtNgoai.Rows
                    Dim itemng As New ListEditItem
                    itemng.Value = rowN("uId_Ngoaite")
                    itemng.Text = rowN("v_Ma")
                    pcmb_Ngoaite.Items.Add(itemng)
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub LoadDichvugoi()
        objBoDichvu = New BO.TNTP_DM_DICHVUFacade
        Dim dt As DataTable
        Try
            dt = objBoDichvu.SelectDvBYGDV("GDV")
            cboDichvuGoi.DataSource = dt
            cboDichvuGoi.TextField = "nv_Tendichvu_vn"
            cboDichvuGoi.ValueField = "uId_Dichvu"
            cboDichvuGoi.DataBind()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub LoadGrvDichvugoi()
        Dim dt As DataTable
        objFcGoidvDichvu = New BO.TNTP_GOIDICHVU_DICHVUFacade
        Try
            dt = objFcGoidvDichvu.SelectAllTable(Session("uId_Dichvu_Goidichvu"))
            If dt.Rows.Count > 0 Then
                GrvDichvugoi.DataSource = dt
            Else
                GrvDichvugoi.DataSource = New DataTable
            End If
            GrvDichvugoi.DataBind()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub loadpCongdoan()
        Dim dt As DataTable
        objBoCongdoan_Dv = New BO.TNTP_DM_DICHVU_CONGDOANFacade
        dt = objBoCongdoan_Dv.SelectAllTable(Session("uId_Dichvu_cd"))
        If dt.Rows.Count > 0 Then
            Grid_Congdoan.DataSource = dt
            Grid_Congdoan.DataBind()
        End If
    End Sub
    Private Sub Load_Dichvu(uId_Nhomdv As String, uId_Cuahang As String)
        objCmDichvu = New CM.TNTP_DM_DICHVUEntity
        objBoDichvu = New BO.TNTP_DM_DICHVUFacade
        Dim dt As DataTable
        Try
            dt = objBoDichvu.SelectAllTable(uId_Nhomdv, uId_Cuahang)
            If dt.Columns.Count = 0 Then
                dt.Rows.Add(dt.NewRow)
            End If
            Grid_Dichvu.DataSource = dt
            Grid_Dichvu.DataBind()
            dt.Dispose()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub loadKho()
        Dim dt As DataTable
        Dim objFckho As New BO.QLMH_DM_KHOFacade
        dt = objFckho.SelectAllTable(Session("uId_Kho"))
        cboKho.DataSource = dt
        If dt.Rows.Count > 0 Then
            cboKho.TextField = "nv_Tenkho_vn"
            cboKho.ValueField = "uId_Kho"
        End If
        cboKho.DataBind()
        cboKho.SelectedIndex = 1
        objFckho = Nothing
        dt = Nothing
    End Sub

    Private Sub loadCongdoan()
        Dim dt As DataTable
        Dim objFcCongdoan As New BO.TNTP_QT_DIEUTRI_CONGDOANFacade
        dt = objFcCongdoan.SelectAllTable()
        cboCongdoan.DataSource = dt
        If dt.Rows.Count > 0 Then
            cboCongdoan.TextField = "nv_Tencongdoan_vn"
            cboCongdoan.ValueField = "uId_Congdoan"
        End If
        cboCongdoan.DataBind()
        objFcCongdoan = Nothing
        dt = Nothing
    End Sub

    Private Sub loadMathang()
        Dim dt As DataTable
        Dim objFcMathang As New BO.QLMH_DM_MATHANGFacade
        dt = objFcMathang.SelectAllTable()
        cboMathang.DataSource = dt
        If dt.Rows.Count > 0 Then
            cboMathang.TextField = "nv_Tenmathang_vn"
            cboMathang.ValueField = "uId_Mathang"
        End If
        cboMathang.DataBind()
    End Sub

    Private Sub Loadlist_Dichvuuathich(tungay As Date, denngay As Date)
        Dim xtr As New Xtr_Dichvu_Uachuong
        xtr.lbl_Cuahang.Text = Session("nv_Tencuahang_vn")
        xtr.lbl_Diachi.Text = Session("nv_DiachiCH_vn")

        Dim dt As DataTable
        objBoDichvu = New BO.TNTP_DM_DICHVUFacade
        dt = objBoDichvu.SelectDichvuUathich(tungay, denngay, Session("uId_Cuahang"))
        If dt.Rows.Count > 0 Then
            xtr.bindata(dt)
        End If
        ReportViewer1.Report = xtr
        objBoDichvu = Nothing
        dt = Nothing
    End Sub
#End Region   
#Region "Grid event"
    Protected Sub Grid_Congdoan_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles Grid_Congdoan.RowDeleting
        objBoCongdoan = New BO.TNTP_QT_DIEUTRI_CONGDOANFacade
        objBoCongdoan_Dv = New BO.TNTP_DM_DICHVU_CONGDOANFacade
        Dim uId_Dichvu As String = e.Keys(0).ToString
        Dim uId_Congdoan As String = e.Keys(2).ToString
        Try
            objBoCongdoan_Dv.DeleteByID(uId_Dichvu, uId_Congdoan)
        Catch ex As Exception
        End Try
        e.Cancel = True
        loadpCongdoan()
    End Sub

    Protected Sub Grid_Congdoan_RowUpdating1(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs) Handles Grid_Congdoan.RowUpdating
        objBoCongdoan = New BO.TNTP_QT_DIEUTRI_CONGDOANFacade
        objBoCongdoan_Dv = New BO.TNTP_DM_DICHVU_CONGDOANFacade
        objCmCongdoan_Dv = New CM.TNTP_DM_DICHVU_CONGDOANEntity
        objCmCongdoan = New CM.TNTP_QT_DIEUTRI_CONGDOANEntity
        Dim uId_Dichvu As String = e.Keys(0).ToString
        Dim uId_Congdoan As String = e.Keys(1).ToString
        Try
            objCmCongdoan_Dv.uId_Dichvu = uId_Dichvu
            objCmCongdoan_Dv.uId_Congdoan = uId_Congdoan
            objCmCongdoan_Dv.f_TienHH = e.NewValues("f_TienHH")
            objCmCongdoan_Dv.nv_Ghichu = e.NewValues("nv_Ghichu")
            objBoCongdoan_Dv.Update(objCmCongdoan_Dv)
            objCmCongdoan.uId_Congdoan = uId_Congdoan
            objCmCongdoan.nv_Tencongdoan_vn = e.NewValues("nv_Tencongdoan_vn").ToString
            objCmCongdoan.nv_Tencongdoan_en = ""
            objBoCongdoan.Update(objCmCongdoan)
        Catch ex As Exception
        End Try
        Grid_Congdoan.CancelEdit()
        e.Cancel = True
        loadpCongdoan()
    End Sub

    Protected Sub Grid_Dichvu_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs) Handles Grid_Dichvu.RowDeleting
        Try
            Dim uId_Dichvu As String = e.Keys(0).ToString
            objCmDichvu = New CM.TNTP_DM_DICHVUEntity
            objBoDichvu = New BO.TNTP_DM_DICHVUFacade
            objBoDichvu.DeleteByID(uId_Dichvu)
            e.Cancel = True
            If cmb_Nhomdichvu.SelectedIndex <> 0 Then
                Dim uId_Nhomdichvu As String = cmb_Nhomdichvu.Value.ToString
                Load_Dichvu(uId_Nhomdichvu, Session("uId_Cuahang"))
            Else
                Load_Dichvu("", Session("uId_Cuahang"))
            End If
        Catch ex As Exception

        End Try

    End Sub
#End Region
#Region "Button Event"
    Protected Sub btOK_Click1(sender As Object, e As EventArgs)
        lbl_Error.InnerText = ""
        objCmDichvu = New CM.TNTP_DM_DICHVUEntity
        objBoDichvu = New BO.TNTP_DM_DICHVUFacade
        Dim uId_Dichvu As String = hdfuIdDichvu.Value.ToString
        Try
            objCmDichvu.uId_Dichvu = uId_Dichvu
            objCmDichvu.nv_Tendichvu_vn = txt_Tendichvu.Text

            objCmDichvu.uId_Nhomdichvu = pcmb_NhomDV.Value.ToString
            objCmDichvu.uId_Ngoaite = pcmb_Ngoaite.Value.ToString
            objCmDichvu.f_Gia = CheckInData(txt_GiaDV.Text)
            objCmDichvu.f_Phidichvu = CheckInData(txt_Giamgia.Text)
            objCmDichvu.i_Solan_Dieutri = CheckInData(txt_Solandieutri.Text)
            objCmDichvu.f_Sophutchuanbi = CheckInData(txt_Tgchuanbi.Text)
            objCmDichvu.f_Sophutthuchien = CheckInData(txt_Tgthuchien.Text)
            objCmDichvu.i_Songayquaylai = txtngay.Text
            If cbo_Goidv.Checked = True Then
                objCmDichvu.b_Goidichvu = True
            Else
                objCmDichvu.b_Goidichvu = False
            End If
            If cbo_Hoahong.Checked = True Then
                objCmDichvu.b_TinhHoahong = True
            Else
                objCmDichvu.b_TinhHoahong = False
            End If
            If cbo_Tinhthue.Checked = True Then
                objCmDichvu.b_Tinhthue = True
            Else
                objCmDichvu.b_Tinhthue = False
            End If
            objCmDichvu.f_PhantramHH_CTV = CheckHoahong(txt_HHCongtac.Text, txt_GiaDV.Text)
            objCmDichvu.f_PhantramHH_KTV = CheckHoahong(txt_HHNhanvienchinh.Text, txt_GiaDV.Text)
            objCmDichvu.f_PhantramHH_NV = CheckHoahong(txt_HHNhanvienphu.Text, txt_GiaDV.Text)
            objCmDichvu.f_PhantramHH_TVV = CheckHoahong(txt_HHTuvan.Text, txt_GiaDV.Text)
            objCmDichvu.f_Gia_Giam = txt_Giamgia.Text
            objCmDichvu.nv_Tendichvu_en = ""
            ' kiem tra la them moi hay la update
            If uId_Dichvu = "" Then
                objBoDichvu.Insert(objCmDichvu)
                lbl_Thongbao.Text = "Thêm dịch vụ thành công !"
                cleartext()
            Else
                objBoDichvu.Update(objCmDichvu)
                lbl_Thongbao.Text = "sửa dữ liệu thành công !"
            End If
            objCmDichvu = Nothing
            objBoDichvu = Nothing
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub btn_luu_Click(sender As Object, e As EventArgs)
        objCmCongdoan = New CM.TNTP_QT_DIEUTRI_CONGDOANEntity
        objCmCongdoan_Dv = New CM.TNTP_DM_DICHVU_CONGDOANEntity
        objBoCongdoan = New BO.TNTP_QT_DIEUTRI_CONGDOANFacade
        objBoCongdoan_Dv = New BO.TNTP_DM_DICHVU_CONGDOANFacade
        Dim objFcMathang As New BO.QLMH_DM_MATHANGFacade
        If hdfuIdDVCongdoan.Value = "" Then
            If hdfuIdDichvu.Value <> Nothing And hdfuIdDichvu.Value <> "" Then
                Dim uId_Congdoan As String = ""
                Try
                    uId_Congdoan = cboCongdoan.Value.ToString
                    If uId_Congdoan <> "" Then
                        With objCmCongdoan_Dv
                            .uId_Dichvu = hdfuIdDichvu.Value.ToString
                            .uId_Congdoan = uId_Congdoan

                        End With
                        If chkKho.Checked = True Then
                            objCmCongdoan_Dv.uIdKho = cboKho.Value.ToString
                            objCmCongdoan_Dv.uId_Mathang = cboMathang.Value.ToString
                            If txtSoluong.Text = "" Then
                                objCmCongdoan_Dv.f_Soluong = 0
                            Else
                                objCmCongdoan_Dv.f_Soluong = Convert.ToDouble(txtSoluong.Text)
                            End If
                            objCmCongdoan_Dv.nv_Ghichu = objFcMathang.SelectByID(cboMathang.Value.ToString).nv_TenMathang_vn
                        Else
                            objCmCongdoan_Dv.uIdKho = Nothing
                            objCmCongdoan_Dv.uId_Mathang = Nothing
                            objCmCongdoan_Dv.f_Soluong = Nothing
                        End If
                        If txtSophut.Text = "" Then
                            objCmCongdoan_Dv.f_Sophut = 0
                        Else
                            objCmCongdoan_Dv.f_Sophut = Convert.ToDouble(txtSophut.Text)
                        End If
                        objBoCongdoan_Dv.Insert(objCmCongdoan_Dv)
                        objCmCongdoan_Dv = Nothing
                        loadpCongdoan()
                    End If
                Catch ex As Exception

                End Try
            End If
        Else
            Try

                If cboCongdoan.Value.ToString <> "" Then
                    With objCmCongdoan_Dv
                        .uId_Dichvu = hdfuIdDichvu.Value.ToString
                        .uId_Congdoan = cboCongdoan.Value.ToString
                        .uId_Dichvu_Congdoan = hdfuIdDVCongdoan.Value.ToString
                    End With
                    If chkKho.Checked = True Then
                        objCmCongdoan_Dv.uIdKho = cboKho.Value.ToString
                        objCmCongdoan_Dv.uId_Mathang = cboMathang.Value.ToString
                        If txtSoluong.Text = "" Then
                            objCmCongdoan_Dv.f_Soluong = 0
                        Else
                            objCmCongdoan_Dv.f_Soluong = Convert.ToDouble(txtSoluong.Text)
                        End If
                        objCmCongdoan_Dv.nv_Ghichu = objFcMathang.SelectByID(cboMathang.Value.ToString).nv_TenMathang_vn
                    Else
                        objCmCongdoan_Dv.uIdKho = Nothing
                        objCmCongdoan_Dv.uId_Mathang = Nothing
                        objCmCongdoan_Dv.f_Soluong = Nothing
                    End If
                    If txtSophut.Text = "" Then
                        objCmCongdoan_Dv.f_Sophut = 0
                    Else
                        objCmCongdoan_Dv.f_Sophut = Convert.ToDouble(txtSophut.Text)
                    End If
                    objBoCongdoan_Dv.Update(objCmCongdoan_Dv)
                    objCmCongdoan_Dv = Nothing
                    loadpCongdoan()
                End If
            Catch ex As Exception

            End Try
        End If
        objCmCongdoan = Nothing
        objCmCongdoan_Dv = Nothing
        objBoCongdoan = Nothing
        objBoCongdoan_Dv = Nothing
    End Sub

    'Private Sub btnFilter_Click(sender As Object, e As EventArgs) Handles btnFilter.Click
    '    objCmDichvu = New CM.TNTP_DM_DICHVUEntity
    '    objBoDichvu = New BO.TNTP_DM_DICHVUFacade
    '    Try
    '        If cmb_Nhomdichvu.SelectedIndex <> 0 Then
    '            Dim uId_Nhomdichvu As String = cmb_Nhomdichvu.Value.ToString
    '            Load_Dichvu(uId_Nhomdichvu, Session("uId_Cuahang"))
    '        Else
    '            Load_Dichvu("", Session("uId_Cuahang"))
    '        End If

    '    Catch ex As Exception

    '    End Try
    'End Sub

    Protected Sub link_Taiexcl_Mau_Click(sender As Object, e As EventArgs)
        Response.Redirect("../../Excel/Excel_Mau_Dichvu.xlsx")
    End Sub

    Protected Sub btn_Import_Click(sender As Object, e As EventArgs)
        If UploadFileExcel.HasFile Then
            btn_Import.Enabled = False
            Dim FileName As String = Path.GetFileNameWithoutExtension(UploadFileExcel.PostedFile.FileName)
            Dim Extension As String = Path.GetExtension(UploadFileExcel.PostedFile.FileName)
            Dim FolderPath As String = ConfigurationManager.AppSettings("FolderPath")
            FileName = pc.ReturnAutoString(FileName)
            Dim FilePath As String = Server.MapPath(FolderPath + FileName + Extension)
            UploadFileExcel.SaveAs(FilePath)
            If radDichvu.Checked = True Then
                Import_To_Grid(FilePath, Extension, 1)
            ElseIf radCongdoan.Checked = True Then
                Import_To_Grid(FilePath, Extension, 0)
            Else
                Import_To_Grid(FilePath, Extension, 2)
            End If

        End If
    End Sub

    Protected Sub btnLocuathich_Click(sender As Object, e As EventArgs)
        Dim tungay As Date
        Dim denngay As Date
        tungay = dateTungay.Value
        denngay = dateDenngay.Value
        Loadlist_Dichvuuathich(tungay, denngay)
    End Sub
#End Region
#Region "Import"
    Private Sub Import_To_Grid(ByVal FilePath As String, ByVal Extension As String, sheet As Integer)
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
        Dim SheetName As String
        connExcel.Close()
        'Read Data from First Sheet
        connExcel.Open()
        If sheet = 1 Then
            SheetName = "Dichvu$"
            cmdExcel.CommandText = "SELECT * From [" & SheetName & "]"
            oda.SelectCommand = cmdExcel
            oda.Fill(dt)
            ExcelInsert(dt)
        ElseIf sheet = 0 Then
            SheetName = "Congdoan$"
            cmdExcel.CommandText = "SELECT * From [" & SheetName & "]"
            oda.SelectCommand = cmdExcel
            oda.Fill(dt)
            ExcelInsertCongdoan(dt)
        Else
            SheetName = "DMCongdoan$"
            cmdExcel.CommandText = "SELECT congdoan From [" & SheetName & "]"
            oda.SelectCommand = cmdExcel
            oda.Fill(dt)
            ExcelInsertDMCongdoan(dt)
        End If
        connExcel.Close()
        File.Delete(FilePath)

    End Sub
    Private Sub ExcelInsertDMCongdoan(dt As DataTable)
        objBoCongdoan = New BO.TNTP_QT_DIEUTRI_CONGDOANFacade
        objCmCongdoan = New CM.TNTP_QT_DIEUTRI_CONGDOANEntity
        For Each row As DataRow In dt.Rows
            With objCmCongdoan
                .nv_Tencongdoan_vn = row("congdoan").ToString
                .nv_Tencongdoan_en = ""
            End With
            objBoCongdoan.Insert(objCmCongdoan)
        Next
    End Sub
    Private Sub ExcelInsert(dt As DataTable)
        objBoDichvu = New BO.TNTP_DM_DICHVUFacade
        objCmDichvu = New CM.TNTP_DM_DICHVUEntity
        objBoNhomdv = New BO.TNTP_DM_NHOMDICHVUFacade
        Dim i As Integer = 0
        Try
            For Each row As DataRow In dt.Rows
                Dim dtnhomdv As DataTable
                dtnhomdv = objBoNhomdv.SelectAllTable(Session("uId_Cuahang"))
                If dtnhomdv.Rows.Count > 0 Then
                    For j As Integer = 0 To dtnhomdv.Rows.Count - 1 Step 1
                        If row("Tên nhóm dịch vụ").ToString = dtnhomdv.Rows(j)("nv_TennhomDichvu_vn").ToString Then
                            objCmDichvu.uId_Nhomdichvu = dtnhomdv.Rows(j)("uId_Nhomdichvu").ToString
                        End If
                    Next
                End If
                With objCmDichvu
                    .nv_Tendichvu_vn = row("Tên dịch vụ").ToString
                    .i_Solan_Dieutri = Convert.ToInt32(row("Số buổi").ToString)
                    .f_Gia = Convert.ToDouble(row("Giá").ToString)
                    .f_Sophutchuanbi = 0
                    .f_Sophutthuchien = Convert.ToDouble(row("Thời gian thực hiện").ToString)
                    .uId_Ngoaite = "964d9c2e-75fd-4c3e-84e0-2b6ed00cbce3"
                End With
                objBoDichvu.Insert(objCmDichvu)
                loadMathang()
                i += 1
            Next
        Catch ex As Exception
        End Try
        lbl_Import.Text = "Thêm thành công từ excel"
        dt = Nothing
        objCmDichvu = Nothing
        objBoDichvu = Nothing
        objBoNhomdv = Nothing
    End Sub

    Private Sub ExcelInsertCongdoan(dt As DataTable)
        objCmCongdoan = New CM.TNTP_QT_DIEUTRI_CONGDOANEntity
        objBoCongdoan = New BO.TNTP_QT_DIEUTRI_CONGDOANFacade
        objCmCongdoan_Dv = New CM.TNTP_DM_DICHVU_CONGDOANEntity
        objBoCongdoan_Dv = New BO.TNTP_DM_DICHVU_CONGDOANFacade
        objCmDichvu = New CM.TNTP_DM_DICHVUEntity
        objBoDichvu = New BO.TNTP_DM_DICHVUFacade
        objEnMathang = New CM.QLMH_DM_MATHANGEntity
        objFcMathang = New BO.QLMH_DM_MATHANGFacade
        objBoNhomdv = New BO.TNTP_DM_NHOMDICHVUFacade
        objCmNhomdv = New CM.TNTP_DM_NHOMDICHVUEntity
        Dim i As Integer = 0
        Try
            If dt.Rows.Count > 0 Then
                Dim dtdv As DataTable
                Dim dtmh As DataTable
                Dim dtnhomdv As DataTable
                Dim dtcongdoan As DataTable
                Dim uId_Dichvu As String
                Dim uId_Congdoan As String
                Dim uId_Mathang As String = ""
                dtnhomdv = objBoNhomdv.SelectAllTable(Session("uId_Cuahang"))
                dtcongdoan = objBoCongdoan.SelectAllTable()
                dtmh = objFcMathang.SelectAllTable()
                For Each row As DataRow In dt.Rows
                    If row("Nhóm dịch vụ") <> "" And row("Tên dịch vụ") <> "" And row("Tên công đoạn") <> "" Then
                        For inhom As Integer = 0 To dtnhomdv.Rows.Count - 1 Step 1
                            If row("Nhóm dịch vụ").ToString = dtnhomdv.Rows(inhom)("nv_TennhomDichvu_vn").ToString Then
                                dtdv = objBoDichvu.SelectAllTable(dtnhomdv.Rows(inhom)("uId_Nhomdichvu").ToString, Session("uId_Cuahang"))
                                If dtdv.Rows.Count > 0 And dtcongdoan.Rows.Count > 0 Then
                                    For idv As Integer = 0 To dtdv.Rows.Count - 1 Step 1
                                        If row("Tên dịch vụ").ToString = dtdv.Rows(idv)("nv_Tendichvu_vn").ToString Then
                                            uId_Dichvu = dtdv.Rows(idv)("uId_Dichvu").ToString
                                            For icd As Integer = 0 To dtcongdoan.Rows.Count - 1 Step 1
                                                If row("Tên công đoạn").ToString = dtcongdoan.Rows(icd)("nv_Tencongdoan_vn").ToString Then
                                                    uId_Congdoan = dtcongdoan.Rows(icd)("uId_Congdoan").ToString
                                                    If row("Tên mặt hàng").ToString <> "" Then
                                                        For imh As Integer = 0 To dtmh.Rows.Count - 1 Step 1
                                                            If row("tên mặt hàng").ToString = dtmh.Rows(imh)("nv_Tenmathang_vn").ToString Then
                                                                uId_Mathang = dtmh.Rows(imh)("uId_Mathang").ToString
                                                            End If
                                                        Next
                                                    End If
                                                    With objCmCongdoan_Dv
                                                        .uId_Congdoan = uId_Congdoan
                                                        .uId_Dichvu = uId_Dichvu
                                                        .uId_Mathang = uId_Mathang
                                                        If row("Số phút").ToString = "" Then
                                                            .f_Sophut = 0
                                                        Else
                                                            .f_Sophut = Convert.ToDouble(row("Số phút").ToString)
                                                        End If
                                                        If row("Số lượng").ToString = "" Then
                                                            .f_Soluong = 0
                                                        Else
                                                            .f_Soluong = Convert.ToDouble(row("Số lượng").ToString)
                                                        End If
                                                        .uIdKho = "CFEEC6D6-A798-4E39-8A36-11ABE3BABCA3"
                                                        .nv_Ghichu = row("Tên mặt hàng").ToString
                                                        .f_TienHH = 0
                                                    End With
                                                    objBoCongdoan_Dv.Insert(objCmCongdoan_Dv)
                                                End If
                                            Next
                                        End If
                                    Next
                                End If
                            End If
                        Next
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub
#End Region

    Protected Sub GrvDichvugoi_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        objFcGoidvDichvu = New BO.TNTP_GOIDICHVU_DICHVUFacade
        objFcGoidvDichvu.DeleteByID(e.Keys(0).ToString, e.Keys(1).ToString)
        GrvDichvugoi.CancelEdit()
        e.Cancel = True
        LoadGrvDichvugoi()

    End Sub
End Class