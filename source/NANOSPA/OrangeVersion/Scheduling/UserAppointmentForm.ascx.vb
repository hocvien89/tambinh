

Imports Microsoft.VisualBasic
#Region "#usings_form_aspxcs"
Imports DevExpress.XtraScheduler
Imports DevExpress.Web.ASPxEditors
Imports DevExpress.Web.ASPxScheduler
Imports DevExpress.Web.ASPxScheduler.Internal
Imports System.Collections.Generic
Imports DevExpress.XtraScheduler.Localization
Imports System.Collections
Imports System
#End Region ' #usings_form_aspxcs

Partial Public Class UserAppointmentForm
    Inherits SchedulerFormControl
    Dim objFcKhachhang As BO.CRM_DM_KhachhangFacade
    Dim objEnKhachhang As CM.CRM_DM_KhachhangEntity
    Dim objFcNhanvien As BO.QT_DM_NHANVIENFacade
    Dim objEnNhanvien As CM.QT_DM_NHANVIENEntity
    Dim objEnDichvu As CM.TNTP_DM_DICHVUEntity
    Dim objFcDichvu As BO.TNTP_DM_DICHVUFacade
    Dim objEnCuahang As CM.QT_DM_CUAHANGEntity
    Dim objFcCuahang As BO.QT_DM_CUAHANGFacade
    Dim objFcResources As BO.ResourcesFacade

    Public ReadOnly Property CanShowReminders() As Boolean
        Get
            Return (CType(Parent, AppointmentFormTemplateContainer)).Control.Storage.EnableReminders
        End Get
    End Property
    Public ReadOnly Property ResourceSharing() As Boolean
        Get
            Return (CType(Parent, AppointmentFormTemplateContainer)).Control.Storage.ResourceSharing
        End Get
    End Property
    Public ReadOnly Property ResourceDataSource() As IEnumerable
        Get
            Return (CType(Parent, AppointmentFormTemplateContainer)).ResourceDataSource
        End Get
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        'PrepareChildControls();
        tbSubject.Focus()
    End Sub
    Private Sub CheckTime()

    End Sub
    'Protected Overrides Sub OnDataBinding(e As EventArgs)
    '    MyBase.OnDataBinding(e)
    '    If IsPostBack Then
    '        edtStartDate.Date = Now.Date
    '        LoadDropDown_Nhanvien()
    '        LoadDropDown_Nhanvien_KT()
    '    End If

    'End Sub
    Public Overrides Sub DataBind()
        objFcCuahang = New BO.QT_DM_CUAHANGFacade
        objFcDichvu = New BO.TNTP_DM_DICHVUFacade
        objFcKhachhang = New BO.CRM_DM_KhachhangFacade
        objFcNhanvien = New BO.QT_DM_NHANVIENFacade
        objEnCuahang = New CM.QT_DM_CUAHANGEntity
        objEnDichvu = New CM.TNTP_DM_DICHVUEntity
        objEnKhachhang = New CM.CRM_DM_KhachhangEntity
        objEnNhanvien = New CM.QT_DM_NHANVIENEntity
        Dim dt As New DataTable
        Try
            objFcResources = New BO.ResourcesFacade
            MyBase.DataBind()
            LoadDropDown_Nhanvien()
            LoadDropDown_Nhanvien_KT()
            Dim container As UserAppointmentFormTemplateContainer = CType(Parent, UserAppointmentFormTemplateContainer)
            Dim apt As Appointment = container.Appointment
            edtLabel.SelectedIndex = apt.LabelId
            edtStatus.SelectedIndex = apt.StatusId
            Dim id As String = apt.Id
            If id <> "" And id <> Nothing Then
                dt = objFcResources.Select_Thongtin_ByID(id)
                Dim dt_Cuahang As New DataTable
                dt_Cuahang = objFcCuahang.SelectByID(dt.Rows(0).Item("uId_Cuahang").ToString)
                ddlCuahang.Value = dt_Cuahang.Rows(0).Item("uId_Cuahang").ToString
                ddlCuahang.Text = dt_Cuahang.Rows(0).Item("nv_Tencuahang_vn").ToString
                objEnKhachhang = objFcKhachhang.SelectByID(dt.Rows(0).Item("CustomField1").ToString)
                objEnDichvu = objFcDichvu.SelectByID(dt.Rows(0).Item("uId_Dichvu").ToString)
                objEnNhanvien = objFcNhanvien.SelectByID(dt.Rows(0).Item("uId_Nhanvien").ToString)
                ddlKhachhang.Value = objEnKhachhang.uId_Khachhang
                ddlKhachhang.Text = objEnKhachhang.nv_Hoten_vn
                ddlNhanvien.Value = objEnNhanvien.uId_Nhanvien
                ddlNhanvien.Text = objEnNhanvien.nv_Hoten_vn
                ddlDichvu.Value = objEnDichvu.uId_Dichvu
                ddlDichvu.Text = objEnDichvu.nv_Tendichvu_vn
                objEnNhanvien = New CM.QT_DM_NHANVIENEntity
                objEnNhanvien = objFcNhanvien.SelectByID(dt.Rows(0).Item("uId_Nhanvien_Kythuat").ToString)
                ddl_Nhanvien_Kythuat.Value = objEnNhanvien.uId_Nhanvien
                ddl_Nhanvien_Kythuat.Text = objEnNhanvien.nv_Hoten_vn
            End If
            'ddlKhachhang.Text = apt.CustomFields("CustomField1")
            'ddlNhanvien.Value = apt.CustomFields("uId_Nhanvien")
            'ddlDichvu.Value = apt.CustomFields("uId_Dichvu")
            ''ddlNhanvien.Text = objFcResources.SelectByResourceId(apt.ResourceId).ToString
            'ddlCuahang.Value = apt.CustomFields("uId_Cuahang")
            PopulateResourceEditors(apt, container)
            AppointmentRecurrenceForm1.Visible = container.ShouldShowRecurrence
            Dim d_Start As DateTime = edtStartDate.Value
            Dim d_End As DateTime = edtEndDate.Value
            If DateDiff(DateInterval.Day, d_Start, d_End) >= 0 Then
                btnOk.ClientSideEvents.Click = container.SaveHandler
            Else
                If DateDiff(DateInterval.Hour, d_Start, d_End) >= 0 Then
                    btnOk.ClientSideEvents.Click = container.SaveHandler
                Else
                    lbl_Error.Text = "Thời gian kết thúc không được sau thời gian bắt đầu"
                End If
            End If

            btnCancel.ClientSideEvents.Click = container.CancelHandler
            btnDelete.ClientSideEvents.Click = container.DeleteHandler
        Catch ex As Exception
            MessageBoxShow("Không thể đặt lịch hẹn cho nhân viên này!")
        End Try
        'btnDelete.Enabled = !container.IsNewAppointment;
    End Sub
    Private Sub PopulateResourceEditors(ByVal apt As Appointment, ByVal container As AppointmentFormTemplateContainer)
        If ResourceSharing Then
            Dim edtMultiResource As ASPxListBox = TryCast(ddResource.FindControl("edtMultiResource"), ASPxListBox)
            If edtMultiResource Is Nothing Then
                Return
            End If
            SetListBoxSelectedValues(edtMultiResource, apt.ResourceIds)
            Dim multiResourceString As List(Of String) = GetListBoxSeletedItemsText(edtMultiResource)
            Dim stringResourceNone As String = SchedulerLocalizer.GetString(SchedulerStringId.Caption_ResourceNone)
            ddResource.Value = stringResourceNone
            If multiResourceString.Count > 0 Then
                ddResource.Value = String.Join(", ", multiResourceString.ToArray())
            End If
            ddResource.JSProperties.Add("cp_Caption_ResourceNone", stringResourceNone)
        Else
            If (Not Object.Equals(apt.ResourceId, Resource.Empty.Id)) Then
                edtResource.Value = apt.ResourceId.ToString()
            Else
                edtResource.Value = SchedulerIdHelper.EmptyResourceId
            End If
        End If
    End Sub
    Private Function GetListBoxSeletedItemsText(ByVal listBox As ASPxListBox) As List(Of String)
        Dim result As New List(Of String)()
        For Each editItem As ListEditItem In listBox.Items
            If editItem.Selected Then
                result.Add(editItem.Text)
            End If
        Next editItem
        Return result
    End Function
    Private Sub SetListBoxSelectedValues(ByVal listBox As ASPxListBox, ByVal values As IEnumerable)
        listBox.Value = Nothing
        For Each value As Object In values
            Dim item As ListEditItem = listBox.Items.FindByValue(value.ToString())
            If item IsNot Nothing Then
                item.Selected = True
            End If
        Next value
    End Sub
    Protected Overrides Sub PrepareChildControls()
        Dim container As UserAppointmentFormTemplateContainer = CType(Parent, UserAppointmentFormTemplateContainer)
        Dim control As ASPxScheduler = container.Control

        AppointmentRecurrenceForm1.EditorsInfo = New EditorsInfo(control, control.Styles.FormEditors, control.Images.FormEditors, control.Styles.Buttons)
        MyBase.PrepareChildControls()
    End Sub
#Region "#getchildeditors"
    Protected Overrides Function GetChildEditors() As ASPxEditBase()
        ' Required to implement client-side functionality
        Dim edits() As ASPxEditBase = {lblSubject, tbSubject, lblLocation, tbLocation, lblLabel, edtLabel, lblStartDate, edtStartDate, lblEndDate, edtEndDate, lblStatus, edtStatus, lblAllDay, chkAllDay, lblResource, edtResource, tbDescription, ddResource, tbField1, memField2, ddlKhachhang, memField_KT}
        Return edits
    End Function
#End Region ' #getchildeditors
    Protected Overrides Function GetChildButtons() As ASPxButton()
        Dim buttons() As ASPxButton = {btnOk, btnCancel, btnDelete}
        Return buttons
    End Function

    'Custom
    Public Function LoadDropDown_Khachhang() As DataTable
        objFcKhachhang = New BO.CRM_DM_KhachhangFacade
        Dim dt As DataTable
        dt = objFcKhachhang.SelectAllTable(Session("uId_Cuahang"))
        Return dt
    End Function
    Public Sub LoadDropDown_Nhanvien()
        objFcNhanvien = New BO.QT_DM_NHANVIENFacade
        Dim uid As String = UniqueID
        Dim dt As DataTable
        Dim d_Ngay As DateTime
        If edtStartDate.Text = "" Then
            d_Ngay = Now.Date
        Else
            d_Ngay = edtStartDate.Text
        End If
        dt = objFcNhanvien.Load_Nhanvien_Tuvan_AuTo(d_Ngay)
        ddlNhanvien.DataSource = dt
        ddlNhanvien.DataBind()
    End Sub
    Public Sub LoadDropDown_Nhanvien_KT()
        objFcNhanvien = New BO.QT_DM_NHANVIENFacade
        Dim uid As String = UniqueID
        Dim dt As DataTable
        Dim d_Ngay As DateTime
        If edtStartDate.Text = "" Then
            d_Ngay = Now.Date
        Else
            d_Ngay = edtStartDate.Text
        End If

        dt = objFcNhanvien.Load_Nhanvien_Kythuat_AuTo(d_Ngay)
        ddl_Nhanvien_Kythuat.DataSource = dt
        ddl_Nhanvien_Kythuat.DataBind()
    End Sub
    Public Function LoadDropDown_Cuahang() As DataTable
        objFcCuahang = New BO.QT_DM_CUAHANGFacade
        Dim dt As DataTable
        dt = objFcCuahang.SelectAllTable()
        Return dt
    End Function
    Public Function LoadDropDown_Dichvu() As DataTable
        objFcDichvu = New BO.TNTP_DM_DICHVUFacade
        Dim dt As DataTable
        dt = objFcDichvu.SelectAll_By_Cuahang()
        Return dt
    End Function
    Public Function LoadDropDown_NhanvienByTime(uid_nhanvien As String) As DataTable
        objFcNhanvien = New BO.QT_DM_NHANVIENFacade
        objFcResources = New BO.ResourcesFacade
        Dim uId As String
        If uid_nhanvien <> "" Then
            uId = objFcResources.SelectByResourceId(Convert.ToInt32(uid_nhanvien)).ToString
        Else
            uId = ""
        End If
        Dim dt As DataTable
        dt = objFcNhanvien.SelectnhanvienByLichhen(Session("uId_Cuahang"), edtStartDate.Value, edtEndDate.Value, uId)
        Return dt
    End Function
    Public Function selectNhanvien(resourceid) As String
        objFcResources = New BO.ResourcesFacade
        objFcNhanvien = New BO.QT_DM_NHANVIENFacade
        Dim str As String = objFcResources.SelectByResourceId(resourceid)
        Return objFcNhanvien.SelectByID(str).nv_Hoten_vn.ToString
    End Function

    Protected Sub ddlNhanvien_Callback(sender As Object, e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase)
        LoadDropDown_Nhanvien()
    End Sub

    Protected Sub ddl_Nhanvien_Kythuat_Callback(sender As Object, e As DevExpress.Web.ASPxClasses.CallbackEventArgsBase)
        LoadDropDown_Nhanvien_KT()
    End Sub
End Class