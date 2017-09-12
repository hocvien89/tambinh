Imports DevExpress.Web.ASPxTabControl
Imports DevExpress.Web.ASPxRoundPanel
Imports DevExpress.Web.ASPxDataView
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxCallbackPanel
Imports Microsoft.Office.Interop.Word

Public Class SetBed
    Inherits System.Web.UI.Page
#Region "var"
    Private objFcDMPhong As BO.QLP_DM_PHONGFacade
    Private objFcDMGiuong As BO.QLP_DM_GIUONGFacade
    Public seconds As Double
#End Region
    Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        'Kiem tra da dang nhap chua, neu chua bawt buoc phai dang nhap
        Dim sUid_Nhanvien_Dangnhap As String = ""
        Try
            sUid_Nhanvien_Dangnhap = Session("uId_Nhanvien_Dangnhap")
        Catch ex As Exception
        Finally
            If sUid_Nhanvien_Dangnhap = "" Then Response.Redirect("../../../../LoginSys.aspx")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            LoadPhong()
            seconds = 50
        End If

    End Sub

    Private Function loadGiuong(uId_Phong As String) As DataTable
        objFcDMGiuong = New BO.QLP_DM_GIUONGFacade
        Dim dtGiuong As DataTable
        dtGiuong = objFcDMGiuong.SelectGiuongtheophong(uId_Phong)
        If dtGiuong.Rows.Count = 0 Then
            dtGiuong = New DataTable
        End If
        Return dtGiuong
    End Function

    Private Sub LoadPhong()
        objFcDMPhong = New BO.QLP_DM_PHONGFacade
        Dim dtPhong As DataTable
        dtPhong = objFcDMPhong.SelectAllTable(Session("uId_Cuahang"))
        If dtPhong.Rows.Count > 0 Then
            DvPhong.DataSource = dtPhong
            DvPhong.DataBind()
        End If
        objFcDMPhong = Nothing
        dtPhong = Nothing
    End Sub

    Protected Sub DvGiuongDetail_DataBinding(sender As Object, e As EventArgs)
        Dim dw As ASPxDataView = DirectCast(sender, ASPxDataView)
        Dim item As DataViewItemTemplateContainer = TryCast(dw.Parent, DataViewItemTemplateContainer)
        Dim uIdPhong As String = DataBinder.Eval(item.DataItem, "uId_Phong").ToString()
        Dim dtGiuong As DataTable
        Dim dtcheck As DataTable
        objFcDMGiuong = New BO.QLP_DM_GIUONGFacade
        dtGiuong = objFcDMGiuong.SelectGiuongtheophong(uIdPhong)
        If dtGiuong.Rows.Count > 0 Then
            Dim col As New DataColumn
            col.DataType = GetType(String)
            col.DefaultValue = 0
            col.ColumnName = "Timer"
            dtGiuong.Columns.Add(col)
            For Each row As DataRow In dtGiuong.Rows
                If row("trangthai").ToString = "Đang sử dụng" Then
                    dtcheck = objFcDMGiuong.SelectInfoGiuong(row("uId_Giuong").ToString, Date.Now)
                    If dtcheck.Rows.Count > 0 Then
                        Dim time As DateTime
                        Dim time1 As Double = Convert.ToDouble(dtcheck.Rows(0)("f_Sophutthuchien").ToString)
                        Dim time2 As DateTime = Convert.ToDateTime(dtcheck.Rows(0)("dt_checkin"))
                        time = DateAdd(DateInterval.Minute, time1, time2)
                        Dim sophut As Double
                        sophut = DateDiff(DateInterval.Minute, Date.Now, time)
                        Dim gio As Integer = Int(sophut / 60)
                        Dim phut As Integer
                        If gio > 0 Then
                            phut = sophut Mod 60
                        Else
                            phut = sophut
                        End If
                        row("Timer") = gio.ToString + ":" + phut.ToString
                    End If
                Else
                    row("Timer") = "0:0"
                End If
            Next
            dw.DataSource = dtGiuong
        End If
        dw = Nothing
        item = Nothing
        uIdPhong = Nothing
        dtGiuong = Nothing
    End Sub
    Protected Sub DvPhong_CustomCallback(sender As Object, e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase)
        LoadPhong()
    End Sub
End Class