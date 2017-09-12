Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports DevExpress.Web.ASPxScheduler
Imports DevExpress.Web.ASPxScheduler.Internal
Imports DevExpress.XtraScheduler
Imports DevExpress.Web.ASPxEditors
#Region "#userappointmentformtemplatecontainer"
Public Class UserAppointmentFormTemplateContainer
    Inherits AppointmentFormTemplateContainer
    Public Sub New(ByVal control As ASPxScheduler)
        MyBase.New(control)
    End Sub
    Public ReadOnly Property Field1() As Double
        Get
            Dim val As Object = Appointment.CustomFields("Field1")
            If (val Is DBNull.Value) Then
                Return 0
            Else
                Return Convert.ToDouble(val)
            End If
        End Get
    End Property
    Public ReadOnly Property CustomField1() As String
        Get
            Return Convert.ToString(Appointment.CustomFields("CustomField1"))
        End Get
    End Property
    Public ReadOnly Property uId_Nhanvien() As String
        Get
            Return Convert.ToString(Appointment.CustomFields("uId_Nhanvien"))
        End Get
    End Property
    Public ReadOnly Property uId_Cuahang() As String
        Get
            Return Convert.ToString(Appointment.CustomFields("uId_Cuahang"))
        End Get
    End Property
    Public ReadOnly Property uId_Dichvu() As String
        Get
            Return Convert.ToString(Appointment.CustomFields("uId_Dichvu"))
        End Get
    End Property
    Public ReadOnly Property uId_Nhanvien_Kythuat() As String
        Get
            Return Convert.ToString(Appointment.CustomFields("uId_Nhanvien_Kythuat"))
        End Get
    End Property
End Class
#End Region ' #userappointmentformtemplatecontainer
#Region "#userappointmentformcontroller"
Public Class UserAppointmentFormController
    Inherits AppointmentFormController
    Public Sub New(ByVal control As ASPxScheduler, ByVal apt As Appointment)
        MyBase.New(control, apt)
    End Sub
    Public Property Field1() As Double
        Get
            Return CDbl(EditedAppointmentCopy.CustomFields("Field1"))
        End Get
        Set(ByVal value As Double)
            EditedAppointmentCopy.CustomFields("Field1") = value
        End Set
    End Property
    Public Property CustomField1() As String
        Get
            Return CStr(EditedAppointmentCopy.CustomFields("CustomField1"))
        End Get
        Set(ByVal value As String)
            EditedAppointmentCopy.CustomFields("CustomField1") = value
        End Set
    End Property
    Public Property uId_Nhanvien() As String
        Get
            Return CStr(EditedAppointmentCopy.CustomFields("uId_Nhanvien"))
        End Get
        Set(ByVal value As String)
            EditedAppointmentCopy.CustomFields("uId_Nhanvien") = value
        End Set
    End Property
    Public Property uId_Nhanvien_Kythuat() As String
        Get
            Return CStr(EditedAppointmentCopy.CustomFields("uId_Nhanvien_Kythuat"))
        End Get
        Set(ByVal value As String)
            EditedAppointmentCopy.CustomFields("uId_Nhanvien_Kythuat") = value
        End Set
    End Property
    Public Property uId_Cuahang() As String
        Get
            Return CStr(EditedAppointmentCopy.CustomFields("uId_Cuahang"))
        End Get
        Set(ByVal value As String)
            EditedAppointmentCopy.CustomFields("uId_Cuahang") = value
        End Set
    End Property
    Public Property uId_Dichvu() As String
        Get
            Return CStr(EditedAppointmentCopy.CustomFields("uId_Dichvu"))
        End Get
        Set(ByVal value As String)
            EditedAppointmentCopy.CustomFields("uId_Dichvu") = value
        End Set
    End Property

    Private Property SourceField1() As Double
        Get
            Return CDbl(SourceAppointment.CustomFields("Field1"))
        End Get
        Set(ByVal value As Double)
            SourceAppointment.CustomFields("Field1") = value
        End Set
    End Property
    Private Property SourceField2() As String
        Get
            Return CStr(SourceAppointment.CustomFields("CustomField1"))
        End Get
        Set(ByVal value As String)
            SourceAppointment.CustomFields("CustomField1") = value
        End Set
    End Property
    Private Property source_uId_Nhanvien() As String
        Get
            Return CStr(SourceAppointment.CustomFields("uId_Nhanvien"))
        End Get
        Set(ByVal value As String)
            SourceAppointment.CustomFields("uId_Nhanvien") = value
        End Set
    End Property
    Private Property source_uId_Cuahang() As String
        Get
            Return CStr(SourceAppointment.CustomFields("uId_Cuahang"))
        End Get
        Set(ByVal value As String)
            SourceAppointment.CustomFields("uId_Cuahang") = value
        End Set
    End Property
    Private Property source_ID_NV_Kythuat() As String
        Get
            Return CStr(SourceAppointment.CustomFields("uId_Nhanvien_Kythuat"))
        End Get
        Set(ByVal value As String)
            SourceAppointment.CustomFields("uId_Nhanvien_Kythuat") = value
        End Set
    End Property

    Public Overrides Function IsAppointmentChanged() As Boolean
        If MyBase.IsAppointmentChanged() Then
            Return True
        End If
        Return SourceField1 <> Field1 OrElse SourceField2 <> CustomField1
    End Function
    Protected Overrides Sub ApplyCustomFieldsValues()
        SourceField1 = Field1
        SourceField2 = CustomField1
        source_ID_NV_Kythuat = uId_Nhanvien_Kythuat
    End Sub
End Class
#End Region ' #userappointmentformcontroller
#Region "#userappointmentsavecallbackcommand"
Public Class UserAppointmentSaveCallbackCommand
    Inherits AppointmentFormSaveCallbackCommand
    Public Sub New(ByVal control As ASPxScheduler)
        MyBase.New(control)
    End Sub
    Protected Friend Shadows ReadOnly Property Controller() As UserAppointmentFormController
        Get
            Return CType(MyBase.Controller, UserAppointmentFormController)
        End Get
    End Property

    Protected Overrides Sub AssignControllerValues()
        Dim tbField1 As ASPxTextBox = CType(FindControlByID("tbField1"), ASPxTextBox)
        Dim memField2 As ASPxMemo = CType(FindControlByID("memField2"), ASPxMemo)
        Dim ddlKhachhang As ASPxComboBox = CType(FindControl("ddlKhachhang"), ASPxComboBox)
        Dim ddlNhanvien As ASPxComboBox = CType(FindControl("ddlNhanvien"), ASPxComboBox)
        Dim ddlCuahang As ASPxComboBox = CType(FindControl("ddlCuahang"), ASPxComboBox)
        Dim ddlDichvu As ASPxComboBox = CType(FindControl("ddlDichvu"), ASPxComboBox)
        Dim ddl_Nhanvien_Kythuat As ASPxComboBox = CType(FindControl("ddl_Nhanvien_Kythuat"), ASPxComboBox)
        Controller.Field1 = Convert.ToDouble(tbField1.Text)
        Dim ddlKHSelect As Integer
        Dim ddlNVSelect As Integer
        Dim ddlCuahangSelect As Integer
        Dim ddlDichvuSelect As Integer
        Dim ddlKTSelect As Integer
        ddlKHSelect = ddlKhachhang.SelectedIndex
        ddlNVSelect = ddlNhanvien.SelectedIndex
        ddlCuahangSelect = ddlCuahang.SelectedIndex
        ddlDichvuSelect = ddlDichvu.SelectedIndex
        ddlKTSelect = ddl_Nhanvien_Kythuat.SelectedIndex
        If ddlKHSelect >= 0 Then
            Controller.CustomField1 = BO.Util.IsString(ddlKhachhang.SelectedItem.Value)
        Else
            Controller.CustomField1 = ""
        End If
        If ddlNVSelect >= 0 Then
            Controller.uId_Nhanvien = BO.Util.IsString(ddlNhanvien.SelectedItem.Value)
        Else
            Controller.uId_Nhanvien = System.Web.HttpContext.Current.Session("uId_Nhanvien_Dangnhap")
        End If
        If ddlKTSelect >= 0 Then
            Controller.uId_Nhanvien_Kythuat = BO.Util.IsString(ddl_Nhanvien_Kythuat.SelectedItem.Value)
        Else
            Controller.uId_Nhanvien_Kythuat = ""
        End If
        If ddlCuahangSelect >= 0 Then
            Controller.uId_Cuahang = BO.Util.IsString(ddlCuahang.SelectedItem.Value)
        Else
            Controller.uId_Cuahang = System.Web.HttpContext.Current.Session("uId_Cuahang")
        End If
        If ddlDichvuSelect >= 0 Then
            Controller.uId_Dichvu = BO.Util.IsString(ddlDichvu.SelectedItem.Value)
        Else
            Controller.uId_Dichvu = ""
        End If
        ' them dk kiem tra cbo nhan vien kt

            MyBase.AssignControllerValues()
    End Sub
    Protected Overrides Function CreateAppointmentFormController(ByVal apt As Appointment) As AppointmentFormController
        Return New UserAppointmentFormController(Control, apt)
    End Function
End Class
#End Region ' #userappointmentsavecallbackcommand  


