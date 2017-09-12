Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxGridView

Public Class ManageSalaries
    Inherits System.Web.UI.Page
    Private objFcThamsohethong As New BO.clsB_QT_THAMSOHETHONG
    Private objFcnhanvien As BO.QT_DM_NHANVIENFacade
    Private objFcLuongcoban As BO.QLL_QUATRINHLUONGFacade
    Private objFcTinhluong As BO.QLL_THONGTINLUONGFacade
    Private objEnLuongcoban As CM.QLL_QUATRINHLUONGEntity
    Private Pl As Public_Class
    Private objFcPhanquyen As BO.QT_PHANQUYENFacade
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LoadTime()
            Loadnhanvien()
            Loadchucvu()
        End If
        LoadTTLuong()
    End Sub
#Region "Load data"
    Private Sub LoadTime()
        objFcThamsohethong = New BO.clsB_QT_THAMSOHETHONG
        For i As Integer = 1 To 12 Step 1
            Dim item As New ListEditItem
            item.Value = i
            item.Text = i.ToString
            cboThang.Items.Add(item)
        Next
        Dim nammin As Integer = Convert.ToInt32(objFcThamsohethong.SelectTHAMSOHETHONGByID("i_Nammin").v_Giatri)
        Dim nammax As Integer = Convert.ToInt32(objFcThamsohethong.SelectTHAMSOHETHONGByID("i_Nammax").v_Giatri)
        For j As Integer = nammin To nammax Step 1
            Dim items As New ListEditItem
            items.Value = j
            items.Text = items.ToString
            cboNam.Items.Add(items)
        Next
        Dim timenow As Date = Date.Now
        cboThang.Value = timenow.Month
        cboNam.Value = timenow.Year
        dateNgayapdung.Value = Date.Now
        Dim str As String = objFcThamsohethong.SelectTHAMSOHETHONGByID("v_Ngaycong").v_Giatri.ToString
        txtNgaycong.Text = str
        objFcThamsohethong = Nothing
    End Sub

    Private Sub Loadnhanvien()
        objFcnhanvien = New BO.QT_DM_NHANVIENFacade
        Dim dt As DataTable
       
            dt = objFcnhanvien.SelectAllTable(Session("uId_Cuahang"))

        If dt.Rows.Count > 0 Then
            cboNhanvien.DataSource = dt
            cboNhanvien.TextField = "nv_Hoten_vn"
            cboNhanvien.ValueField = "uId_Nhanvien"
            cboNhanvien.DataBind()
            cboNhanvien.Value = Session("uId_Nhanvien_Dangnhap")
            cboChucvu.Text = dt.Rows(0)("nv_Chucvu_vn").ToString
        Else
            cboNhanvien.DataSource = New DataTable
        End If

        objFcnhanvien = Nothing
    End Sub

    Private Sub Loadchucvu()
        Try
            Dim item1 As New ListEditItem
            Dim item2 As New ListEditItem
            Dim item3 As New ListEditItem
            Dim item4 As New ListEditItem
            item1.Value = "0"
            item1.Text = "Giám đốc"
            item2.Value = "1"
            item2.Text = "Nhân viên"
            item3.Value = "2"
            item3.Text = "Lễ tân"
            item4.Value = "3"
            item4.Text = "Kế toán"
            cboChucvu.Items.Add(item1)
            cboChucvu.Items.Add(item2)
            cboChucvu.Items.Add(item3)
            cboChucvu.Items.Add(item4)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LoadTTLuong()
        objFcTinhluong = New BO.QLL_THONGTINLUONGFacade
        Dim dt As DataTable
        If Session("sTendangnhap") = "admin" Then
            dt = objFcTinhluong.SelectAllTable(Convert.ToInt32(cboThang.Text), Convert.ToInt32(cboNam.Text), "")
        Else
            dt = objFcTinhluong.SelectAllTable(Convert.ToInt32(cboThang.Text), Convert.ToInt32(cboNam.Text), Session("uId_Cuahang"))
        End If
        If dt.Rows.Count > 0 Then
            GrvDsluong.DataSource = dt
            GrvDsluong.DataBind()
        End If
    End Sub
#End Region
    Protected Sub btnLuuLuongcoban_Click(sender As Object, e As EventArgs)
        objFcPhanquyen = New BO.QT_PHANQUYENFacade
        'kiem tra phan quyen cua nhan vien
        Pl = New Public_Class
        objFcLuongcoban = New BO.QLL_QUATRINHLUONGFacade
        objEnLuongcoban = New CM.QLL_QUATRINHLUONGEntity
        If objFcPhanquyen.SelectByID(Session("uId_Nhanvien_Dangnhap").ToString, "FE8B2BFA-9C5F-4A07-8EEA-49EFA4B0B58C").b_Enable = False Then
            ltrError.Text = "Bạn không có quyền thực hiện"
            ltrSuccess.Text = ""
            Exit Sub
        End If

        With objEnLuongcoban
            .uId_Nhanvien = cboNhanvien.Value
            .f_Mucluong_Codinh = Pl.Convertstringtodb(txtLuongcoban.Text)
            .f_Mucluong_Ngoaigio = Pl.Convertstringtodb(txtLuongngoaigio.Text)
            .d_Ngayquyetdinh = dateNgayapdung.Value
            .f_Mucluong_Trachnhiem = Pl.Convertstringtodb(txtLuongtrachnhiem.Text)
            .f_Antrua = Pl.Convertstringtodb(txtLuongtrachnhiem.Text)
            .nv_Ghichu_vn = txtGhichu.Text
        End With
        If hdfuIdluongcoban.Value <> "" Then
            objEnLuongcoban.uId_QuatrinhLuong = hdfuIdluongcoban.Value.ToString
            objFcLuongcoban.Update(objEnLuongcoban)
            ltrSuccess.Text = "Cập nhật thành công!"
            ltrError.Text = ""
        Else
            objFcLuongcoban.Insert(objEnLuongcoban)
            ltrSuccess.Text = "Thêm mới thành công!"
            ltrError.Text = ""
        End If
        LoadTTLuong()
    End Sub

    Protected Sub btnXuatExcel_Click(sender As Object, e As EventArgs)
        ExportLuong.WriteXlsToResponse()
    End Sub

    Protected Sub GrvDsluong_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        objFcTinhluong = New BO.QLL_THONGTINLUONGFacade
        objFcPhanquyen = New BO.QT_PHANQUYENFacade
        If objFcPhanquyen.SelectByID(Session("uId_Nhanvien_Dangnhap").ToString, "fed14a6d-b0cc-4b24-87f4-afee33480d39").b_Enable = False Then

            CType(sender, ASPxGridView).JSProperties("cpIsAccept") = "false"
        Else
            CType(sender, ASPxGridView).JSProperties("cpIsAccept") = "true"
            objFcTinhluong.DeleteByID(e.Keys(1).ToString)

           
        End If
        GrvDsluong.CancelEdit()
        e.Cancel = True
        LoadTTLuong()
    End Sub
End Class