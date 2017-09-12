Imports DevExpress.Web.ASPxGridView

Partial Public Class _Default
    Inherits System.Web.UI.Page
    Dim objFcDmPhong As BO.QLP_DM_PHONGFacade
    Dim objFcGiuong As BO.QLP_DM_GIUONGFacade
    Dim objFCCheck As BO.TNTP_CHECKINCHECKOUTFacade
    Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        'Kiem tra da dang nhap chua, neu chua bawt buoc phai dang nhap
        Dim sUid_Nhanvien_Dangnhap As String = ""
        Try
            sUid_Nhanvien_Dangnhap = Session("uId_Nhanvien_Dangnhap")
        Catch ex As Exception
        Finally
            If sUid_Nhanvien_Dangnhap = "" Then Response.Redirect("LoginSys.aspx")
        End Try
    End Sub

    'Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
    '    'LoadDMPhong()
    'End Sub
    'Public Sub LoadDMPhong()
    '    objFcDmPhong = New BO.QLP_DM_PHONGFacade
    '    Dim dt As DataTable
    '    dt = objFcDmPhong.SelectAllTable(Session("uId_Cuahang"))
    '    If dt.Rows.Count > 0 Then
    '        dgvDevexpress.DataSource = dt
    '        dgvDevexpress.DataBind()
    '    End If
    'End Sub

    'Protected Sub dgvDevexpress_DataBound(sender As Object, e As EventArgs)
    '    TryCast(sender, ASPxGridView).DetailRows.ExpandAllRows()
    'End Sub

    'Protected Sub dgvDSGiuong_BeforePerformDataSelect(sender As Object, e As EventArgs)
    '    Dim detailGridView As ASPxGridView = DirectCast(sender, ASPxGridView)
    '    Dim uId_Phong As String
    '    uId_Phong = detailGridView.GetMasterRowKeyValue().ToString
    '    objFcGiuong = New BO.QLP_DM_GIUONGFacade
    '    Dim dt As DataTable = objFcGiuong.SelectGiuongtheophong(uId_Phong)
    '    If dt.Rows.Count > 0 Then
    '        detailGridView.DataSource = dt
    '    End If
    '    objFcGiuong = Nothing
    '    dt = Nothing
    'End Sub

    'Protected Sub dgvLieutrinh_BeforePerformDataSelect(sender As Object, e As EventArgs)
    '    Dim detailGridView As ASPxGridView = DirectCast(sender, ASPxGridView)
    '    Dim uId_Giuong As String
    '    uId_Giuong = detailGridView.GetMasterRowKeyValue().ToString
    '    objFCCheck = New BO.TNTP_CHECKINCHECKOUTFacade
    '    Dim dt As DataTable = objFCCheck.SelectLieuTrinhTheoPhong(uId_Giuong)
    '    If dt.Rows.Count > 0 Then
    '        detailGridView.DataSource = dt
    '    End If
    '    objFCCheck = Nothing
    '    dt = Nothing
    'End Sub
End Class