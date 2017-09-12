Public Class DM_Calamviec
    Inherits System.Web.UI.Page
    Dim objFc_Calamviec As BO.clsB_DM_CALAMVIEC
    Dim objFc_Nhanvien As BO.QT_DM_NHANVIENFacade
    Dim objEn_Calamviec As CM.cls_CALAMVIEC
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            d_Tungay.Date = Now.Date
            Calendar.Value = Now.Date
        End If
        Load_Nhanvien_Ca()
        Load_Nhanvien()
    End Sub
    Protected Sub Grid_Ca_RowDeleting(sender As Object, e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
        objFc_Calamviec = New BO.clsB_DM_CALAMVIEC
        Dim uId_Nhanvien_Ca = e.Keys(0).ToString
        objFc_Calamviec.Delete_ById(uId_Nhanvien_Ca)
        Load_Nhanvien_Ca()
        e.Cancel = True
    End Sub
    Protected Sub Load_Nhanvien()
        objFc_Nhanvien = New BO.QT_DM_NHANVIENFacade
        Dim d_Ngay As DateTime = d_Tungay.Date
        Dim dt As DataTable = objFc_Nhanvien.SelectAllTable_Calamviec(d_Ngay)
        cb_Nhanvien.DataSource = dt
        cb_Nhanvien.ValueField = "uId_Nhanvien"
        cb_Nhanvien.TextField = "nv_Hoten_vn"
        cb_Nhanvien.DataBind()
    End Sub
    Protected Sub btnAdd_Click(sender As Object, e As EventArgs)
        objFc_Calamviec = New BO.clsB_DM_CALAMVIEC
        objEn_Calamviec = New CM.cls_CALAMVIEC
        Dim dt As DataTable = objFc_Calamviec.Check_Trungcalamviec(d_Tungay.Value, cb_Nhanvien.Value.ToString)
        With objEn_Calamviec
            .d_Ngay = d_Tungay.Value
            .nv_Ghichu_vn = txt_Ghichu.Text
            .v_Calamviec = cb_Calamviec.Value.ToString
            .uId_Nhanvien = cb_Nhanvien.Value.ToString
        End With
        If cb_Calamviec.Value.ToString = "All" Then
            MessageBoxShow("Ca làm việc không hợp lý !")
        ElseIf cb_Nhanvien.Value.ToString = "" Or cb_Nhanvien.Value.ToString = Nothing Then
            MessageBoxShow("Nhân viên đã được phân ca hết !")
        Else
            If dt.Rows.Count > 0 Then
                MessageBoxShow("Nhân viên đã phân ca làm việc!")
                Exit Sub
            Else
                If objFc_Calamviec.Insert(objEn_Calamviec) Then
                    MessageBoxShow("Thêm mới thành công !")
                    txt_Ghichu.Text = ""
                End If
            End If
         
        End If
        Load_Nhanvien_Ca()
    End Sub
    Protected Sub Load_Nhanvien_Ca()
        objFc_Calamviec = New BO.clsB_DM_CALAMVIEC
        Dim uId_Ca = cb_Calamviec.Value.ToString
        Dim d_Ngay As DateTime = Calendar.Value
        Dim dt As DataTable = objFc_Calamviec.Select_Nhanvien_ByCa(d_Ngay, uId_Ca)
        Grid_Ca.DataSource = dt
        Grid_Ca.DataBind()
    End Sub

    Protected Sub cb_Nhanvien_Callback(sender As Object, e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase)
        Load_Nhanvien()
    End Sub
End Class