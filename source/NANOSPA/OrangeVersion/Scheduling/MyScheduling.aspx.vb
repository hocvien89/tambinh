Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data.Common
Imports DevExpress.XtraScheduler
Imports DevExpress.Web.ASPxScheduler
Imports System.Data.SqlClient
Imports DevExpress.Web.ASPxMenu
Public Class MyScheduling
    Inherits System.Web.UI.Page
    Dim objFcAppointment As BO.AppointmentsFacade
    Private lastInsertedAppointmentId As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
         
        End If
        scheduler1.ActiveViewType = SchedulerViewType.Timeline
        scheduler1.Start = System.DateTime.Today.AddHours(7)
    End Sub
    Protected Sub scheduler1_AppointmentFormShowing(sender As Object, e As AppointmentFormEventArgs) Handles scheduler1.AppointmentFormShowing
        e.Container = New UserAppointmentFormTemplateContainer(CType(sender, ASPxScheduler))
    End Sub

    Protected Sub scheduler1_BeforeExecuteCallbackCommand(sender As Object, e As SchedulerCallbackCommandEventArgs) Handles scheduler1.BeforeExecuteCallbackCommand
        If e.CommandId = SchedulerCallbackCommandId.AppointmentSave Then
            e.Command = New UserAppointmentSaveCallbackCommand(CType(sender, ASPxScheduler))
        End If
    End Sub
    
    Protected Sub scheduler1_PopupMenuShowing(sender As Object, e As PopupMenuShowingEventArgs) Handles scheduler1.PopupMenuShowing
        'Dim menu As ASPxSchedulerPopupMenu = e.Menu
        ' If menu.Id = SchedulerMenuItemId.AppointmentMenu Then
        '     menu.ClientSideEvents.ItemClick = String.Format("function(s, e) {{ DefaultViewMenuHandler({0}, s, e); }}", scheduler1.ClientInstanceName)
        '     Dim menuItems As MenuItemCollection = menu.Items
        '     Dim defaultItem As MenuItem = menuItems.FindByName("NewAppointment")
        '     defaultItem.Name = "MyNewAppointment"
        '     defaultItem.Text = "Instant Appointment"
        ' End If
        If scheduler1.ActiveViewType = SchedulerViewType.Timeline Or scheduler1.ActiveViewType = SchedulerViewType.WorkWeek Or scheduler1.ActiveViewType = SchedulerViewType.Day Then
            If e.Menu.Id = SchedulerMenuItemId.DefaultMenu Then
                e.Menu.Items(0).Text = "Đặt lịch"
                e.Menu.Items(1).Text = "Hẹn cả ngày"
                e.Menu.Items(2).Visible = False
                e.Menu.Items(3).Visible = False
                e.Menu.Items(4).Text = "Hôm nay"
                e.Menu.Items(5).Text = "Đến ngày"
                e.Menu.Items(6).Text = "Định dạng"
                e.Menu.Items(7).Text = "60 phút"
                e.Menu.Items(8).Text = "30 phút"
            End If
        End If
        'Khi kick vào ô đã có dữ liệu thì ra AppointmentMenu
        If e.Menu.Id = SchedulerMenuItemId.AppointmentMenu Then
            e.Menu.Items(0).Text = "Mở"
            e.Menu.Items(1).Visible = False
            e.Menu.Items(2).Visible = False
            e.Menu.Items(3).Visible = False
            e.Menu.Items(4).Text = "Cập nhật trạng thái"
            e.Menu.Items(5).Text = "Hủy"
        End If
    End Sub
    Private workTimes() As TimeOfDayInterval = {New TimeOfDayInterval(TimeSpan.FromHours(8), TimeSpan.FromHours(16)),
                                                New TimeOfDayInterval(TimeSpan.FromHours(10), TimeSpan.FromHours(20)),
                                                Nothing, New TimeOfDayInterval(TimeSpan.FromHours(7), TimeSpan.FromHours(15)),
                                                New TimeOfDayInterval(TimeSpan.FromHours(16), TimeSpan.FromHours(24))}
    Protected Sub scheduler1_QueryWorkTime(sender As Object, e As QueryWorkTimeEventArgs)
        If scheduler1.Storage.Resources Is Nothing Then
            Return
        End If

        Dim resourceIndex As Integer = scheduler1.Storage.Resources.Items.IndexOf(e.Resource)
        If resourceIndex >= 0 Then
            If resourceIndex = 0 Then
                If (e.Interval.Start.Date) = "8:00" Then
                    e.WorkTime = workTimes(resourceIndex Mod workTimes.Length)
                Else
                    e.WorkTime = TimeOfDayInterval.Empty
                End If
            Else
                If scheduler1.WorkDays.IsWorkDay(e.Interval.Start.Date) Then
                    e.WorkTime = workTimes(resourceIndex Mod workTimes.Length)
                End If
            End If
        End If
    End Sub

    Protected Sub scheduler1_InitAppointmentDisplayText(sender As Object, e As AppointmentDisplayTextEventArgs)
        Dim objFckhachhang As New BO.CRM_DM_KhachhangFacade
        Dim objFcNhanvien As New BO.QT_DM_NHANVIENFacade
        Dim Id As String = e.Appointment.Id
        objFcAppointment = New BO.AppointmentsFacade
        Dim nv_Hoten As String = ""
        Dim nv_Nhanvien_vn As String = ""
        Dim nv_Tendichvu_vn As String = ""
        Dim nv_Kythuat_vn As String = ""
        Dim dt As DataTable = objFcAppointment.SelectByID_Table(Id)
        If dt.Rows.Count > 0 Then
            nv_Hoten = dt.Rows(0).Item("nv_Hoten_vn").ToString
            nv_Nhanvien_vn = dt.Rows(0).Item("nv_Nhanvien_vn").ToString
            nv_Tendichvu_vn = dt.Rows(0).Item("nv_Tendichvu_vn").ToString
            nv_Kythuat_vn = dt.Rows(0).Item("nv_Kythuat_vn").ToString
        End If
        e.Text = String.Format("KH: {0} - Dịch vụ:{1} - Tư vấn: {2}- Kỹ thuật:{3}", nv_Hoten, nv_Tendichvu_vn, nv_Nhanvien_vn, nv_Kythuat_vn)
    End Sub

    'Protected Sub scheduler1_CustomErrorText(handler As Object, e As ASPxSchedulerCustomErrorTextEventArgs)
    '    e.ErrorText = String.Format("{0}", "Error")
    'End Sub
End Class