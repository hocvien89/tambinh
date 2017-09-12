Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView
Imports System.Drawing
Imports DevExpress.XtraPrinting

Public Class AccountCard
    Inherits System.Web.UI.Page
    Dim objFcTheGoi As BO.TNTP_KHACHHANG_GOIDICHVUFacade
    Dim objEnTheGoi As CM.TNTP_KHACHHANG_GOIDICHVUEntity
    Dim objFcTrangthai As BO.CRM_DM_TRANGTHAIFacade
    Dim objFcKhachhang As BO.CRM_DM_KhachhangFacade
    Dim objFc_Phanquyen As BO.QT_PHANQUYENFacade
    Dim objEnPhanquyen As CM.QT_PHANQUYENEntity
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            deTuNgay.Date = DateTime.Now.ToString
            deDenNgay.Date = DateTime.Now.ToString
            deNgaycap.Date = DateTime.Now.ToString
            deNgayhethan.Date = DateAdd(DateInterval.Year, 1, DateTime.Now).ToString
            LoadDSKhachhang()
        End If
        LoadThongTinGrid()
    End Sub
#Region "Load thong tin"
    Private Sub LoadThongTinGrid()
        objFcTheGoi = New BO.TNTP_KHACHHANG_GOIDICHVUFacade
        Dim dt As DataTable
        Dim valueTT As String
        valueTT = cb_Trangthai.Value.ToString
        dt = objFcTheGoi.SelectByDate(BO.Util.ConvertDateTime(deTuNgay.Text), BO.Util.ConvertDateTime(deDenNgay.Text), Session("uId_Cuahang"), valueTT)
        If dt.Rows.Count > 0 Then
            dgvDevexpress.DataSource = dt
            dgvDevexpress.DataBind()
        Else
            dgvDevexpress.DataSource = Nothing
            dgvDevexpress.DataBind()
        End If
    End Sub
    Protected Sub LoadDSKhachhang()
        objFcKhachhang = New BO.CRM_DM_KhachhangFacade
        Dim dt As DataTable = objFcKhachhang.SelectAllTable(Session("uId_Cuahang"))
        cb_Khachhang.DataSource = dt
        cb_Khachhang.DataBind()
        cb_Khachhang.SelectedIndex = 0
    End Sub
    Protected Sub Image_Init(sender As Object, e As EventArgs)
        objFcTheGoi = New BO.TNTP_KHACHHANG_GOIDICHVUFacade
        objEnTheGoi = New CM.TNTP_KHACHHANG_GOIDICHVUEntity
        Dim xImg As ASPxImage = TryCast(sender, ASPxImage)
        Dim xCont As GridViewDataItemTemplateContainer = xImg.NamingContainer
        Dim Val As String = CStr(xCont.Grid.GetRowValuesByKeyValue(xCont.KeyValue, "uId_Khachhang_Goidichvu").ToString)
        objEnTheGoi = objFcTheGoi.SelectByID(Val)
        If objEnTheGoi.b_Kichhoat = False Then
            xImg.ImageUrl = "../../images/btn_Edit.png"
        Else
            xImg.ImageUrl = ""
        End If
    End Sub
#End Region
#Region "Gridview"
    'Protected Sub dgvDevexpress_CellEditorInitialize(sender As Object, e As DevExpress.Web.ASPxGridView.ASPxGridViewEditorEventArgs)
    '    If e.Column.FieldName = "nv_Trangthai_vn" Then
    '        objFcTrangthai = New BO.CRM_DM_TRANGTHAIFacade
    '        Dim dt As DataTable
    '        dt = objFcTrangthai.SelectAllTable()
    '        Dim cmb As ASPxComboBox = TryCast(e.Editor, ASPxComboBox)
    '        cmb.ClientInstanceName = "cmbTT"
    '        cmb.IncrementalFilteringMode = IncrementalFilteringMode.StartsWith
    '        cmb.DropDownStyle = DropDownStyle.DropDownList
    '        cmb.DataSource = dt
    '        cmb.ValueField = "uId_Trangthai"
    '        cmb.ValueType = GetType(String)
    '        cmb.TextField = "nv_Tentrangthai_vn"
    '        cmb.DataBindItems()
    '    End If
    'End Sub
    'Protected Sub dgvDevexpress_AutoFilterCellEditorInitialize(sender As Object, e As DevExpress.Web.ASPxGridView.ASPxGridViewEditorEventArgs)
    '    If e.Column.FieldName = "nv_Trangthai_vn" Then
    '        objFcTrangthai = New BO.CRM_DM_TRANGTHAIFacade
    '        Dim dt As DataTable
    '        dt = objFcTrangthai.SelectAllTable()
    '        Dim cmb As ASPxComboBox = TryCast(e.Editor, ASPxComboBox)
    '        cmb.ClientInstanceName = "cmbTT"
    '        cmb.IncrementalFilteringMode = IncrementalFilteringMode.StartsWith
    '        cmb.DropDownStyle = DropDownStyle.DropDownList
    '        cmb.ValueType = GetType(String)
    '        cmb.DataSource = dt
    '        cmb.ValueField = "uId_Trangthai"
    '        cmb.ValueType = GetType(String)
    '        cmb.TextField = "nv_Tentrangthai_vn"
    '        cmb.DataBindItems()
    '    End If
    'End Sub
    'Protected Sub dgvDevexpress_RowUpdating(sender As Object, e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
    '    objFcTheGoi = New BO.TNTP_KHACHHANG_GOIDICHVUFacade
    '    objEnTheGoi = New CM.TNTP_KHACHHANG_GOIDICHVUEntity
    '    Dim uId_Khachhang_Goidichvu As String
    '    uId_Khachhang_Goidichvu = e.Keys(0).ToString
    '    objEnTheGoi = objFcTheGoi.SelectByID(uId_Khachhang_Goidichvu)
    '    Dim uId_Trangthai As String
    '    uId_Trangthai = objEnTheGoi.uId_Trangthai
    '    objEnTheGoi = New CM.TNTP_KHACHHANG_GOIDICHVUEntity
    '    With objEnTheGoi
    '        .uId_Khachhang_Goidichvu = uId_Khachhang_Goidichvu
    '        .uId_Cuahang = Session("uId_Cuahang").ToString
    '        Dim uId_TrangthaiNew As String
    '        Dim uId_TrangthaiOld As String
    '        uId_TrangthaiNew = e.NewValues("nv_Trangthai_vn").ToString
    '        uId_TrangthaiOld = e.OldValues("nv_Trangthai_vn").ToString
    '        If uId_TrangthaiNew <> uId_TrangthaiOld Then
    '            .uId_Trangthai = e.NewValues("nv_Trangthai_vn").ToString
    '        Else
    '            .uId_Trangthai = uId_Trangthai
    '        End If
    '        .d_Ngaymua = BO.Util.ConvertDateTime(e.NewValues("d_Ngaymua").ToString)
    '        .d_NgayKT = BO.Util.ConvertDateTime(e.NewValues("d_NgayKT").ToString)
    '        .f_Giatrigoi = Val(e.NewValues("f_Giatrigoi").ToString)
    '    End With
    '    Try
    '        objFcTheGoi.Update(objEnTheGoi)
    '    Catch ex As Exception

    '    End Try
    '    dgvDevexpress.CancelEdit()
    '    e.Cancel = True
    '    LoadThongTinGrid()
    'End Sub
    Protected Sub dgvDevexpress_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        objFcTheGoi = New BO.TNTP_KHACHHANG_GOIDICHVUFacade
        objFc_Phanquyen = New BO.QT_PHANQUYENFacade
        objEnPhanquyen = New CM.QT_PHANQUYENEntity
        Dim dt As New DataTable
        objEnPhanquyen = objFc_Phanquyen.SelectByID(Session("uId_Nhanvien_Dangnhap"), "80634DCD-D199-428D-BC71-1A72021FA53D")
        If objEnPhanquyen.b_Visible = True Then
            Dim id As String
            id = e.Keys(0).ToString
            Try
                objFcTheGoi.DeleteByID(id)
            Catch ex As Exception

            End Try
        Else
            CType(sender, ASPxGridView).JSProperties("cpIsDelete_TheKH") = "NO_DELETE"
        End If
        e.Cancel = True
        LoadThongTinGrid()
    End Sub
    Protected Sub dgv_exporterThe_RenderBrick(sender As Object, e As DevExpress.Web.ASPxGridView.Export.ASPxGridViewExportRenderingEventArgs)
        Dim dataColumn As GridViewDataColumn = TryCast(e.Column, GridViewDataColumn)
        If e.RowType = GridViewRowType.Data AndAlso dataColumn IsNot Nothing AndAlso dataColumn.FieldName = "v_DienthoaiDD" Then
            'e.TextValueFormatString = "Text"
            e.BrickStyle.BackColor = Color.LightYellow
        End If
    End Sub
#End Region
#Region "Button"
    Protected Sub btnFilter_Click(sender As Object, e As EventArgs)
        LoadThongTinGrid()
    End Sub
    Protected Sub btn_ImportExcel_Click(sender As Object, e As EventArgs)
        dgvDevexpress.SettingsDetail.ExportMode = CType(System.Enum.Parse(GetType(GridViewDetailExportMode), GridViewDetailExportMode.None.ToString()), GridViewDetailExportMode)
        dgv_exporterThe.WriteXlsToResponse("DSTheKH", New XlsExportOptions(False))
    End Sub
#End Region
    Protected Sub btLuuthe_Click(sender As Object, e As EventArgs)
        objEnTheGoi = New CM.TNTP_KHACHHANG_GOIDICHVUEntity
        objFcTheGoi = New BO.TNTP_KHACHHANG_GOIDICHVUFacade
        'Tao mot the
        objEnTheGoi = objFcTheGoi.SelectByID(Session("uId_Khachhang_Goidichvu"))
        If objEnTheGoi.b_Kichhoat = True Then
            ltrError.Text = "<span class='error' id='error'>Thẻ đã kích hoạt !</span>"
            ltrSuccess.Text = ""
            Exit Sub
        End If
        With objEnTheGoi
            .uId_Khachhang_Goidichvu = Session("uId_Khachhang_Goidichvu")
            .f_Giatrigoi = Val(BO.Util.IsDouble(txt_Tongtien_The.Text.Replace(",", ""))) 'Dung ham nay
            .d_NgayBD = BO.Util.ConvertDateTime(deNgaycap.Text)
            .d_NgayKT = BO.Util.ConvertDateTime(deNgayhethan.Text)
            .b_Kichhoat = True
            .uId_Khachhang_Kichhoat = cb_Khachhang.Value.ToString
        End With
        Dim Check As Boolean = objFcTheGoi.UpdateTrangthai(objEnTheGoi)
        If (Check = True) Then
            ltrSuccess.Text = "<span class='success' id='success'> Kích hoạt thẻ thành công!</span>"
            ltrError.Text = ""
        Else
            ltrError.Text = "<span class='error' id='error'>Có lỗi xảy ra!</span>"
            ltrSuccess.Text = ""
        End If
        LoadThongTinGrid()
    End Sub

    Protected Sub cb_Khachhang_Callback(sender As Object, e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase)
        LoadDSKhachhang()
    End Sub
End Class