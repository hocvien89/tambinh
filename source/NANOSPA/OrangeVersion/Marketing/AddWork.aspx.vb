Imports DevExpress.Web.ASPxEditors

Public Class AddWork
    Inherits System.Web.UI.Page
    Private uId_KH_Tiemnang As String = ""
    Private uId_Khachhang As String = ""
#Region "Khai bao"
    Dim objFCKHtiemnang As BO.MKT_KH_TIEMNANGFacade
    Dim objEnKHtiemnang As CM.MKT_KH_TIEMNANGEntity
    Dim objFCCuaHang As BO.QT_DM_CUAHANGFacade
    Dim objFcTrangthai As BO.MKT_TRANGTHAIKHFacade
    Dim objEnChuyendoi As CM.MKT_ChuyendoiEntity
    Dim objFCChuyendoi As BO.MKT_ChuyendoiFacade
    Dim objFcTag As BO.MKT_Tags
    Dim objFcCongviec As BO.MKT_CongviecFacade
    Dim objEnCongviec As CM.MKT_CongviecEntity
#End Region
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            uId_KH_Tiemnang = Request.QueryString("uId_KH_Tiemnang").ToString
            uId_Khachhang = Request.QueryString("uId_Khachhang").ToString
            deNgaylam.Date = DateTime.Now.ToString
            deNgaylam.TimeSectionProperties.Visible = True
            deNgaylam.UseMaskBehavior = True
            deNgaylam.EditFormatString = "dd/MM/yyyy hh:mm tt"
            deNgaylam.DisplayFormatString = "dd/MM/yyyy hh:mm tt"
            LoadDropDownList()
            If (uId_KH_Tiemnang) <> Nothing Then
                LoadThongTinKH(uId_KH_Tiemnang)
            End If
        End If
        uId_KH_Tiemnang = Request.QueryString("uId_KH_Tiemnang").ToString
        uId_Khachhang = Request.QueryString("uId_Khachhang").ToString
        If (uId_KH_Tiemnang) <> Nothing Then
            LoadDSCongViec(uId_KH_Tiemnang)
        End If
        If (Session("tags") <> Nothing) Then
            LoadGridTag(Session("tags"))
        End If
    End Sub
#Region "Load thong tin"
    Private Sub LoadThongTinKH(ByVal uId_KH_Tiemnang As String)
        objEnKHtiemnang = New CM.MKT_KH_TIEMNANGEntity
        objFCKHtiemnang = New BO.MKT_KH_TIEMNANGFacade
        objEnKHtiemnang = objFCKHtiemnang.SelectByID(uId_KH_Tiemnang)
        txtHotenKH.Text = objEnKHtiemnang.nv_Hoten_vn
        ltrTitleHeader.Text = "<p class='p_header'><i class='fa fa-newspaper-o fa-fw fa-1x'></i>THÊM CÔNG VIỆC MARKETING CHO KHÁCH HÀNG <span style='color:red;text-transform:uppercase;font-size:16px'>" & objEnKHtiemnang.nv_Hoten_vn & "</span></p>"
    End Sub
    Private Sub LoadDropDownList()
        objFcTag = New BO.MKT_Tags
        Dim dt As DataTable
        dt = New DataTable
        dt = objFcTag.SelectAllTable("")
        ddlTukhoa.DataSource = dt
        ddlTukhoa.ValueField = "uId_Tags"
        ddlTukhoa.TextField = "nv_TagName_vn"
        ddlTukhoa.DataBind()
        Dim item As New ListEditItem
        item.Value = "0"
        item.Text = ""
        ddlTukhoa.Items.Insert(0, item)
        ddlTukhoa.SelectedIndex = 0
    End Sub
    Private Sub LoadDSCongViec(ByVal uId_Khachhangtiemnang As String)
        objFcCongviec = New BO.MKT_CongviecFacade
        Dim dt As DataTable
        dt = objFcCongviec.SelectByIDKhachhang(uId_Khachhangtiemnang)
        If dt.Rows.Count > 0 Then
            dgvCongviec.DataSource = dt
        Else
            dgvCongviec.DataSource = Nothing
        End If
        dgvCongviec.DataBind()
    End Sub
    Private Sub LoadGridTag(ByVal tags As String)
        If tags <> "" Then
            objFcTag = New BO.MKT_Tags
            Dim dt As New DataTable
            Dim column As DataColumn
            column = New DataColumn()
            column.DataType = System.Type.GetType("System.String")
            column.ColumnName = "uId_Tags"
            dt.Columns.Add(column)
            column = New DataColumn()
            column.DataType = Type.GetType("System.String")
            column.ColumnName = "nv_TagName_vn"
            dt.Columns.Add(column)
            Dim arr As Array = tags.Split("$").ToArray()
            For index As Integer = 0 To arr.Length - 1
                If (arr(index) <> "null") Then
                    Dim tagsItem As New CM.MKT_TAGS
                    tagsItem = objFcTag.SelectByID(arr(index))
                    If tagsItem.nv_TagName_vn <> "" Then
                        Dim row As DataRow
                        row = dt.NewRow()
                        row("uId_Tags") = arr(index)
                        row("nv_TagName_vn") = tagsItem.nv_TagName_vn
                        dt.Rows.Add(row)
                    End If
                End If
            Next
            dgvTukhoa.DataSource = dt
            dgvTukhoa.DataBind()
        Else
            dgvTukhoa.DataSource = Nothing
            dgvTukhoa.DataBind()
        End If
    End Sub
    Public Function SplitTags(ByVal tags As String) As String
        Dim rs As String = ""
        objFcTag = New BO.MKT_Tags
        If tags <> Nothing Then
            Dim arr As Array = tags.Split(";").ToArray()
            For index As Integer = 0 To arr.Length - 1
                Dim tagsItem As New CM.MKT_TAGS
                tagsItem = objFcTag.SelectByIDAndMaloai(arr(index), "0")
                If tagsItem.nv_TagName_vn <> "" Then
                    rs += "- " + tagsItem.nv_TagName_vn + "</br>"
                End If
            Next
        End If
        Return rs
    End Function

    Public Function SplitTags_DV(ByVal tags As String) As String
        Dim rs As String = ""
        objFcTag = New BO.MKT_Tags
        If tags <> Nothing Then
            Dim arr As Array = tags.Split(";").ToArray()
            For index As Integer = 0 To arr.Length - 1
                Dim tagsItem As New CM.MKT_TAGS
                tagsItem = objFcTag.SelectByIDAndMaloai(arr(index), "1")
                If tagsItem.nv_TagName_vn <> "" Then
                    rs += "- " + tagsItem.nv_TagName_vn + "</br>"
                End If
            Next
        End If
        Return rs
    End Function
#End Region
#Region "Button"
    Protected Sub btnOkCV_Click(sender As Object, e As EventArgs)
        objEnCongviec = New CM.MKT_CongviecEntity
        Dim tags As String = ""
        With objEnCongviec
            .uId_MaCongviec = "72527087-44af-41eb-8c78-bd1fad730924"
            .uId_KH_Tiemnang = uId_KH_Tiemnang.ToString
            .nv_Noidung = txtGhichuCV.Text
            '.d_Ngay = BO.Util.ConvertDateTimeWithHour(deNgaylam.Text)
            .d_Ngay = deNgaylam.Date
            .DVKHQuantam = ""
            .LoaiCuocGoi = ""
            .uId_Nhanvien = Session("uId_Nhanvien_Dangnhap").ToString
            For i As Integer = 0 To dgvTukhoa.VisibleRowCount - 1
                Dim row As DataRow
                row = dgvTukhoa.GetDataRow(i)
                tags = tags & ";" & row("uId_Tags")
            Next i
            .Tags = tags
        End With
        If Session("uId_Congviec") <> Nothing Then
            objEnCongviec.uId_Congviec = Session("uId_Congviec")
            If objFcCongviec.Update(objEnCongviec) Then
                ltrSuccessCV.Text = "<span class='success' id='success'>Cập nhật công việc thành công!</span>"
            Else : ltrErrorCV.Text = "<span class='error' id='error'>Có lỗi xảy ra! Xin vui lòng thử lại</span>"
            End If
        Else
            If objFcCongviec.Insert(objEnCongviec) Then
                ltrSuccessCV.Text = "<span class='success' id='success'>Thêm mới công việc thành công!</span>"
            Else
                ltrErrorCV.Text = "<span class='error' id='error'>Có lỗi xảy ra! Xin vui lòng thử lại</span>"
            End If
        End If
        LoadDSCongViec(uId_KH_Tiemnang.ToString)
        Session("tags") = ""
        LoadGridTag("")
    End Sub
#End Region
#Region "Grid event"
    Protected Sub dgvTukhoa_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        Dim dt As New DataTable
        Dim rs As String = ""
        Dim index As Integer
        dt = CType(dgvTukhoa.DataSource, DataTable)
        For i As Integer = 0 To dt.Rows.Count - 1
            If dt.Rows(i)("uId_Tags") = e.Keys(0).ToString Then
                index = i
            Else
                rs = rs & "$" & dt.Rows(i)("uId_Tags")
            End If
        Next
        dt.Rows.RemoveAt(index)
        Session("tags") = rs
        dgvTukhoa.DataSource = dt
        dgvTukhoa.DataBind()
        e.Cancel = True
    End Sub
    Protected Sub dgvCongviec_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        objFcCongviec = New BO.MKT_CongviecFacade
        objFcCongviec.DeleteByID(e.Keys(0).ToString)
        LoadDSCongViec(uId_KH_Tiemnang.ToString)
        e.Cancel = True
    End Sub
#End Region
End Class