<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UserAppointmentForm.ascx.vb" Inherits="NANO_SPA.UserAppointmentForm" %>
<%@ Import Namespace="NANO_SPA" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxScheduler.Controls" TagPrefix="dxsc" %>
<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxScheduler" TagPrefix="dxwschs" %>
<script src="../../Js/jquery-1.4.1.min.js"></script>
<script src="../../Js/jquery-ui.min.js"></script>
<table class="dxscAppointmentForm" cellpadding="0" cellspacing="0" style="width: 100%; height: 230px;">
    <tr>
        <td class="dxscSingleCell" >
            <table class="dxscLabelControlPair" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="dxscLabelCell">
                        <dx:ASPxLabel ID="ASPxLabel1" runat="server" AssociatedControlID="tbSubject" Text="Chọn bệnh nhân">
                        </dx:ASPxLabel>
                    </td>
                    <td class="dxscControlCell">
                        <dx:ASPxComboBox ID="ddlKhachhang" DataSource='<%#LoadDropDown_Khachhang()%>' EnableCallbackMode="true" ClientInstanceName="ddlKhachhang" runat="server" CallbackPageSize="10"
                            IncrementalFilteringMode="Contains" ValueField="uId_Khachhang" ValueType="System.String" TextFormatString="{1} {3} {2} {0}"
                            Width="100%" DropDownStyle="DropDown" SelectedIndex="0">
                            <Columns>
                                <dx:ListBoxColumn FieldName="v_Makhachang" Caption="Mã" />
                                <dx:ListBoxColumn FieldName="nv_Hoten_vn" Caption="Họ tên" />
                                <dx:ListBoxColumn FieldName="nv_Diachi_vn" Caption="Địa chỉ" />
                                <dx:ListBoxColumn FieldName="v_DienthoaiDD" Caption="Điện thoại" />
                            </Columns>
                        </dx:ASPxComboBox>
                    </td>
                </tr>
            </table>
        </td>
        <td class="dxscSingleCell" style="padding-left: 25px;" >
            <table class="dxscLabelControlPair" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="dxscLabelCell">
                        <dx:ASPxLabel ID="ASPxLabel3" runat="server" AssociatedControlID="tbSubject" Text="Thuộc phòng khám">
                        </dx:ASPxLabel>
                    </td>
                    <td class="dxscControlCell">
                        <dx:ASPxComboBox ID="ddlCuahang" DataSource='<%#LoadDropDown_Cuahang()%>' EnableCallbackMode="true" ClientInstanceName="ddlCuahang" runat="server" CallbackPageSize="10"
                            IncrementalFilteringMode="Contains" ValueField="uId_Cuahang" SelectedIndex="0" TextField="nv_Tencuahang_vn" ValueType="System.String" TextFormatString="{0}"
                            Width="100%" DropDownStyle="DropDown">
                        </dx:ASPxComboBox>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="dxscDoubleCell" colspan="2">
            <table class="dxscLabelControlPair" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="dxscLabelCell">
                        <dx:ASPxLabel ID="lblSubject" runat="server" AssociatedControlID="tbSubject" Text="Ghi chú">
                        </dx:ASPxLabel>
                    </td>
                    <td class="dxscControlCell">
                        <dx:ASPxTextBox ClientInstanceName="_dx" ID="tbSubject" runat="server" Width="100%" Text='<%#(CType(Container, UserAppointmentFormTemplateContainer)).Appointment.Subject%>' />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="dxscSingleCell">
            <table class="dxscLabelControlPair" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="dxscLabelCell">
                        <dx:ASPxLabel ID="lblStartDate" runat="server" AssociatedControlID="edtStartDate" Text="Bắt đầu:" Wrap="false">
                        </dx:ASPxLabel>
                    </td>
                    <td class="dxscControlCell">
                              <dx:ASPxDateEdit ClientInstanceName="edtStartTimeAppointmentForm" ID="edtStartDate" runat="server" Width="100%" Date='<%#(CType(Container, UserAppointmentFormTemplateContainer)).Start%>' EditFormat="DateTime" DateOnError="Undo" AllowNull="false">
                              <ValidationSettings ErrorDisplayMode="ImageWithTooltip" EnableCustomValidation="True"
                                ValidationGroup="DateValidatoinGroup" Display="Dynamic">
                                <RequiredField ErrorText="The field cannot be blank." IsRequired="True" />
                             </ValidationSettings>
                              <ClientSideEvents  ValueChanged="function(s, e) { OnUpdateControlValue(s, e); }"  DateChanged="function(s, e) { edtStartDate_DateChanged(s, e); }"/>
                             
                        </dx:ASPxDateEdit>
                    </td>
                </tr>
            </table>
        </td>
        <td class="dxscSingleCell">
            <table class="dxscLabelControlPair" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="dxscLabelCell" style="padding-left: 25px;">
                        <dx:ASPxLabel runat="server" ID="lblEndDate" Text="Kết thúc:" Wrap="false" AssociatedControlID="edtEndDate" />
                    </td>
                    <td class="dxscControlCell">
                         <dx:ASPxDateEdit ID="edtEndDate" runat="server" Date='<%#(CType(Container, UserAppointmentFormTemplateContainer)).End%>'
                            EditFormat="DateTime" Width="100%" DateOnError="Undo" AllowNull="false" ClientInstanceName="edtEndTimeAppointmentForm">
                             <ClientSideEvents  ValueChanged="function(s, e) { OnUpdateControlValue(s, e); }" DateChanged="function(s, e) { edtEndDate_DateChanged(s, e); }"/>
                        <ValidationSettings EnableCustomValidation="True" ErrorDisplayMode="ImageWithTooltip"
                            ValidationGroup="DateValidatoinGroup" Display="Dynamic">
                            <RequiredField ErrorText="Cannot be empty" IsRequired="True" />
                        </ValidationSettings>
                        </dx:ASPxDateEdit>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td style="display: none" class="dxscSingleCell">
            <table class="dxscLabelControlPair" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="dxscLabelCell">
                        <dx:ASPxLabel ID="lblLocation" runat="server" AssociatedControlID="tbLocation" Text="Địa điểm:">
                        </dx:ASPxLabel>
                    </td>
                    <td class="dxscControlCell">
                        <dx:ASPxTextBox ClientInstanceName="_dx" ID="tbLocation" runat="server" Width="100%" Text='<%#(CType(Container, UserAppointmentFormTemplateContainer)).Appointment.Location%>' />
                    </td>
                </tr>
            </table>
        </td>
        <td class="dxscSingleCell">
            <table class="dxscLabelControlPair" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="dxscLabelCell" cellpadding="0" cellspacing="0">
                        <dx:ASPxLabel ID="lblLabel" runat="server" AssociatedControlID="edtLabel" Text="Trạng thái:">
                        </dx:ASPxLabel>
                    </td>
                    <td class="dxscControlCell">
                        <dx:ASPxComboBox ClientInstanceName="_dx" ID="edtLabel" runat="server" Width="100%" DataSource='<%#(CType(Container, UserAppointmentFormTemplateContainer)).LabelDataSource%>' />
                    </td>
                </tr>
            </table>
        </td>
        <td class="dxscSingleCell">
            <table class="dxscLabelControlPair" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="dxscLabelCell" style="padding-left: 25px;">
                        <dx:ASPxLabel ID="ASPxLabel2" Visible="True" runat="server" Text="NV Tư vấn:">
                        </dx:ASPxLabel>
                    </td>
                    <td class="dxscControlCell">
                        <dx:ASPxComboBox ID="ddlNhanvien" OnCallback="ddlNhanvien_Callback" EnableCallbackMode="false" ClientInstanceName="ddlNhanvien" runat="server" CallbackPageSize="10"
                            IncrementalFilteringMode="Contains" ValueField="uId_Nhanvien"  TextField="nv_Hoten_vn" ValueType="System.String" TextFormatString="{0}"
                            Width="100%" DropDownStyle="DropDown" Visible="True" SelectedIndex="0" >
                             <ClientSideEvents SelectedIndexChanged="function(s, e) { ddlNhanvien_SelectedIndexChanged(s, e); }" />
                        </dx:ASPxComboBox>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr style="display: none">
        <td class="dxscSingleCell" style="display: none">
            <table class="dxscLabelControlPair" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="dxscLabelCell">
                        <dx:ASPxLabel ID="lblStatus" runat="server" AssociatedControlID="edtStatus" Text="Show time as:" Wrap="false">
                        </dx:ASPxLabel>
                    </td>
                    <td class="dxscControlCell">
                        <dx:ASPxComboBox ClientInstanceName="_dx" ID="edtStatus" runat="server" Width="100%" DataSource='<%#(CType(Container, UserAppointmentFormTemplateContainer)).StatusDataSource%>' />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="dxscSingleCell">
             <table class="dxscLabelControlPair" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="dxscLabelCell">
                        <dx:ASPxLabel ID="lbl_Dichvu" Visible="True" runat="server" Text="Dịch vụ:">
                        </dx:ASPxLabel>
                    </td>
                    <td class="dxscControlCell">
                        <dx:ASPxComboBox ID="ddlDichvu" DataSource='<%#LoadDropDown_Dichvu()%>' EnableCallbackMode="True" ClientInstanceName="ddlDichvu" runat="server" CallbackPageSize="10"
                            IncrementalFilteringMode="Contains" ValueField="uId_Dichvu"  TextField="nv_Tendichvu_vn" ValueType="System.String" TextFormatString="{0}"
                            Width="100%" DropDownStyle="DropDown" Visible="True"  SelectedIndex="0">
                        </dx:ASPxComboBox>
                    </td>
                </tr>
            </table>
        </td>
        <td class="dxscSingleCell"  style="padding-left: 25px;">
              <table class="dxscLabelControlPair" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="dxscLabelCell">
                        <dx:ASPxLabel ID="lbl_Nhanvien_KT" Visible="True" runat="server" Text="NV Kỹ thuật:">
                        </dx:ASPxLabel>
                    </td>
                    <td class="dxscControlCell">
                        <dx:ASPxComboBox ID="ddl_Nhanvien_Kythuat" OnCallback="ddl_Nhanvien_Kythuat_Callback" EnableCallbackMode="false" ClientInstanceName="dll_Nhanvien_Kythuat" runat="server" CallbackPageSize="10"
                            IncrementalFilteringMode="Contains" ValueField="uId_Nhanvien_Kythuat"  TextField="nv_Hoten_vn" ValueType="System.String" TextFormatString="{0}"
                            Width="100%" DropDownStyle="DropDown" Visible="True"  SelectedIndex="0">
                              <ClientSideEvents SelectedIndexChanged="function(s, e) { ddl_Nhanvien_Kythuat_SelectedIndexChanged(s, e); }" />
                        </dx:ASPxComboBox>
                    </td>
                </tr>
            </table>
        </td>
    </tr>

    <tr style="display: block">
        <%
            If CanShowReminders Then
        %>
        <td class="dxscSingleCell" style="height: 68px">
            <%
            Else
            %>
        <td class="dxscDoubleCell" colspan="2" style="height: 68px">
            <%
            End If
            %>
            <table style="display: none" class="dxscLabelControlPair" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="dxscLabelCell">
                        <dx:ASPxLabel ID="lblResource" runat="server" AssociatedControlID="edtResource" Text="Resource:">
                        </dx:ASPxLabel>
                    </td>
                    <td class="dxscControlCell">
                        <%
                            If ResourceSharing Then
                        %>
                        <dx:ASPxDropDownEdit ID="ddResource" runat="server" Width="100%" ClientInstanceName="ddResource" Enabled='<%#(CType(Container, UserAppointmentFormTemplateContainer)).CanEditResource%>' AllowUserInput="false">
                            <DropDownWindowTemplate>
                                <dx:ASPxListBox ID="edtMultiResource" runat="server" Width="100%" SelectionMode="CheckColumn" DataSource='<%#ResourceDataSource%>' Border-BorderWidth="0">
                                    <ClientSideEvents SelectedIndexChanged="function(s, e) { OnEdtMultiResourceSelectedIndexChanged(s, e); }"></ClientSideEvents>
                                </dx:ASPxListBox>
                            </DropDownWindowTemplate>
                        </dx:ASPxDropDownEdit>
                        <%
                        Else
                        %>
                        <dx:ASPxComboBox ClientInstanceName="_dx" ID="edtResource" runat="server" Width="100%" DataSource='<%#ResourceDataSource%>' Enabled='<%#(CType(Container, UserAppointmentFormTemplateContainer)).CanEditResource%>' ValueType="System.String">
                        </dx:ASPxComboBox>
                        <%
                        End If
                        %>
                    </td>

                </tr>
            </table>
        </td>
        <%
            If CanShowReminders Then
        %>
        <td class="dxscSingleCell" style="height: 68px">
         
        </td>
        <%
        End If
        %>
    </tr>
    <tr>
        <td class="dxscDoubleCell" colspan="2" style="height: 90px; display:none;">Nhân viên:
            <dx:ASPxTextBox Visible="false" ID="tbField1" runat="server" Width="70px"
                Text='<%#(CType(Container, UserAppointmentFormTemplateContainer)).Field1%>'>
            </dx:ASPxTextBox>
            <dx:ASPxMemo Visible="false" ID="memField2" plachoder="Memo" runat="server" Height="71px" Width="227px"
                Text='<%#(CType(Container, UserAppointmentFormTemplateContainer)).CustomField1%>'>
            </dx:ASPxMemo>
              <dx:ASPxMemo Visible="false" ID="memField_KT" plachoder="Memo" runat="server" Height="71px" Width="227px"
                Text='<%#(CType(Container, UserAppointmentFormTemplateContainer)).uId_Nhanvien_Kythuat%>'>
            </dx:ASPxMemo>
            <dx:ASPxMemo ClientInstanceName="_dx" ID="tbDescription" runat="server" Width="100%" Text='<%#(CType(Container, UserAppointmentFormTemplateContainer)).Appointment.Description%>' Height="45px" />
        </td>
    </tr>
</table>
<table class="dxscLabelControlPair" cellpadding="0" title="Nhân viên" cellspacing="0">
    <tr>
        <td style="width: 20px; height: 20px;">
            <dx:ASPxCheckBox ClientInstanceName="_dx" ID="chkAllDay" runat="server" Checked='<%#(CType(Container, UserAppointmentFormTemplateContainer)).Appointment.AllDay%>'>
            </dx:ASPxCheckBox>
        </td>
        <td style="padding-left: 2px;">
            <dx:ASPxLabel ID="lblAllDay" runat="server" Text="All day event" AssociatedControlID="chkAllDay" />
        </td>
    </tr>
</table>
<table>
    <tr>
        <td>
            <dx:ASPxLabel runat="server" ID="lbl_Error" ClientInstanceName="lbl_Error" ForeColor="Red"></dx:ASPxLabel>
        </td>
    </tr>
</table>
<div style="display: none">
    <dxsc:AppointmentRecurrenceForm Visible="false" ID="AppointmentRecurrenceForm1" runat="server"
        IsRecurring='<%#(CType(Container, UserAppointmentFormTemplateContainer)).Appointment.IsRecurring%>'
        DayNumber='<%#(CType(Container, UserAppointmentFormTemplateContainer)).RecurrenceDayNumber%>'
        End='<%#(CType(Container, UserAppointmentFormTemplateContainer)).RecurrenceEnd%>'
        Month='<%#(CType(Container, UserAppointmentFormTemplateContainer)).RecurrenceMonth%>'
        OccurrenceCount='<%#(CType(Container, UserAppointmentFormTemplateContainer)).RecurrenceOccurrenceCount%>'
        Periodicity='<%#(CType(Container, UserAppointmentFormTemplateContainer)).RecurrencePeriodicity%>'
        RecurrenceRange='<%#(CType(Container, UserAppointmentFormTemplateContainer)).RecurrenceRange%>'
        Start='<%#(CType(Container, UserAppointmentFormTemplateContainer)).RecurrenceStart%>'
        WeekDays='<%#(CType(Container, UserAppointmentFormTemplateContainer)).RecurrenceWeekDays%>'
        WeekOfMonth='<%#(CType(Container, UserAppointmentFormTemplateContainer)).RecurrenceWeekOfMonth%>'
        RecurrenceType='<%#(CType(Container, UserAppointmentFormTemplateContainer)).RecurrenceType%>'
        IsFormRecreated='<%#(CType(Container, UserAppointmentFormTemplateContainer)).IsFormRecreated%>'>
    </dxsc:AppointmentRecurrenceForm>
</div>
<table cellpadding="0" cellspacing="0" style="width: 100%; height: 35px;">
    <tr>
        <td style="width: 100%; height: 100%;" align="center">
            <table style="height: 100%;">
                <tr>
                    <td>
                          <dx:ASPxButton runat="server" ClientInstanceName="btnMyAppointmentFormOk" ID="btnOk" Text="OK" UseSubmitBehavior="false"
                            EnableViewState="false" AutoPostBack="false"
                            Width="91px" ValidationGroup="DateValidatoinGroup">
                            <ClientSideEvents Click="function(s, e) { Check_Error(s, e); }" />
                        </dx:ASPxButton>
                    </td>
                    <td>
                        <dx:ASPxButton runat="server" ClientInstanceName="_dx" ID="btnCancel" Text="Cancel" UseSubmitBehavior="false" AutoPostBack="false" EnableViewState="false"
                            Width="91px" CausesValidation="False" />
                    </td>
                    <td>
                        <dx:ASPxButton runat="server" ClientInstanceName="_dx" ID="btnDelete" Text="Delete" UseSubmitBehavior="false"
                            AutoPostBack="false" EnableViewState="false" Width="91px"
                            Enabled='<%#(CType(Container, UserAppointmentFormTemplateContainer)).CanDeleteAppointment%>'
                            CausesValidation="False" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<table>

</table>
<table cellpadding="0" cellspacing="0" style="width: 100%;">
    <tr>
        <td style="width: 100%;" align="left">
            <dxsc:ASPxSchedulerStatusInfo runat="server" ID="schedulerStatusInfo" Priority="1" MasterControlID='<%#(CType(Container, UserAppointmentFormTemplateContainer)).ControlId%>' />
        </td>
    </tr>
</table>
<script id="dxss_ASPxSchedulerAppoinmentForm" type="text/javascript">
   $(document).ready(function () {
        if ('<%#(CType(Container, UserAppointmentFormTemplateContainer)).Appointment.CustomFields("uId_Nhanvien")%>'=="") {
            var uidNhanvien = '<%#(CType(Container, UserAppointmentFormTemplateContainer)).Appointment.ResourceId%>'
            var Startdate = '<%#(CType(Container, UserAppointmentFormTemplateContainer)).Start%>'
            var Endate = '<%#(CType(Container, UserAppointmentFormTemplateContainer)).End%>'
            var param_dt = "{'uidNhanvien':'" + 1 + "','dStart':'" + Startdate + "','dEnd':'" + Endate + "'}";
            console.log(param_dt)
            var pageUrl = "../../../../Webservice/nano_websv.asmx/LoadThongTinResource";

            $.ajax({
                type: "POST",
                url: pageUrl,
                data: param_dt,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (msg) {
                    if (msg.d == "No") {
                        alert("Nhân viên không thể đặt lịch");
                        window.location.href = "../../OrangeVersion/Scheduling/MyScheduling.aspx";
                    }
                },
                error: onFail
            });
        }
    });
    function OnEdtMultiResourceSelectedIndexChanged(s, e) {
        var resourceNames = new Array();
        var items = s.GetSelectedItems();
        var count = items.length;
        if (count > 0) {
            for (var i = 0; i < count; i++)
                _aspxArrayPush(resourceNames, items[i].text);
        }
        else
            _aspxArrayPush(resourceNames, ddResource.cp_Caption_ResourceNone);
        ddResource.SetValue(resourceNames.join(', '));
    }
    function OnChkReminderCheckedChanged(s, e) {
        var isReminderEnabled = s.GetValue();
        if (isReminderEnabled)
            _dxAppointmentForm_cbReminder.SetSelectedIndex(3);
        else
            _dxAppointmentForm_cbReminder.SetSelectedIndex(-1);

        _dxAppointmentForm_cbReminder.SetEnabled(isReminderEnabled);
    }
    // Check loi chon thoi gian bat dau 
    function OnStartTimeValidate(s, e) {
        if (!e.isValid)
            return;
        var startDate = edtStartTimeAppointmentForm.GetDate();
        var endDate = edtEndTimeAppointmentForm.GetDate();
        e.isValid = startDate == null || endDate == null || startDate < endDate;
        if (startDate == null || endDate == null || startDate > endDate) {
            lbl_Error.SetText("Thời gian bắt đầu phải trước thời gian kết thúc.");
        }
        else {
            lbl_Error.SetText("");
        }
        //e.isValid = startDate == null || endDate == null || startDate < endDate;

    }
    // Check loi chon thoi gian ket thuc
    function OnEndTimeValidate(s, e) {
        if (!e.isValid)
            return;
        var startDate = edtStartTimeAppointmentForm.GetDate();
        var endDate = edtEndTimeAppointmentForm.GetDate();
        e.isValid = startDate == null || endDate == null || startDate < endDate;
        if (startDate == null || endDate == null || startDate > endDate) {
            lbl_Error.SetText("Thời gian bắt đầu phải trước thời gian kết thúc.");
        }
        else {
            lbl_Error.SetText("");
        }
    }
    function OnUpdateControlValue(s, e) {
        var isValid = ASPxClientEdit.ValidateEditorsInContainer(null);
        btnMyAppointmentFormOk.SetEnabled(isValid)
    }
    window.setTimeout("ASPxClientEdit.ValidateEditorsInContainer(null)", 0);
    function CreateAppointment(scheduler) {
        var apt = new ASPxClientAppointment();
        var selectedInterval = scheduler.GetSelectedInterval();
        apt.SetStart(selectedInterval.GetStart());
        apt.SetEnd(selectedInterval.GetEnd());
        apt.AddResource(scheduler.GetSelectedResource());
        apt.SetLabelId(0);
        apt.SetStatusId(0);
        return apt;
    }
    function ddlDichvu_SelectedIndexChanged(s, e) {
        txt_Ngaynhacnho.SetText(ddlDichvu.GetSelectedItem().GetColumnText("i_Songayquaylai"));
    }
    function ddlNhanvien_SelectedIndexChanged(s, e) {
        var uId_Nhanvien = ddlNhanvien.GetValue();
        //var startDate = edtStartTimeAppointmentForm.GetDate();
        //var endDate = edtEndTimeAppointmentForm.GetDate();
        var startDate = '<%#(CType(Container, UserAppointmentFormTemplateContainer)).Start%>'
        var endDate = '<%#(CType(Container, UserAppointmentFormTemplateContainer)).End%>'
        var resourceid = '<%#(CType(Container, UserAppointmentFormTemplateContainer)).Appointment.ResourceId%>'
        var param_dt = "{'Resource':'" + resourceid + "','dStart':'" + startDate + "','dEnd':'" + endDate + "','uId_Nhanvien':'" + uId_Nhanvien + "'}";
        var pageUrl = "../../../../Webservice/nano_websv.asmx/Kiemtralichhentrung";

        $.ajax({
            type: "POST",
            url: pageUrl,
            data: param_dt,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (msg) {
                if (msg.d == "YES") {
                    lbl_Error.SetText("Nhân viên lễ tân trùng lịch");
                    btnMyAppointmentFormOk.SetEnabled(false);
                }
                else if (msg.d == "ALL") {
                    lbl_Error.SetText("Bác sỹ đang bận");
                    btnMyAppointmentFormOk.SetEnabled(false);
                }
                else {
                    ddl_Nhanvien_Kythuat_SelectedIndexChanged(s, e);
                    //lbl_Error.SetText("");
                    //btnMyAppointmentFormOk.SetEnabled(true);
                }
            },
            error: onFail
        });
    }
    function ddl_Nhanvien_Kythuat_SelectedIndexChanged(s, e) {
        var uId_Nhanvien = dll_Nhanvien_Kythuat.GetValue();
        //var startDate = edtStartTimeAppointmentForm.GetDate();
        //var endDate = edtEndTimeAppointmentForm.GetDate();
         var startDate = '<%#(CType(Container, UserAppointmentFormTemplateContainer)).Start%>'
         var endDate = '<%#(CType(Container, UserAppointmentFormTemplateContainer)).End%>'
         var resourceid = '<%#(CType(Container, UserAppointmentFormTemplateContainer)).Appointment.ResourceId%>'
         var param_dt = "{'Resource':'" + resourceid + "','dStart':'" + startDate + "','dEnd':'" + endDate + "','uId_Nhanvien':'" + uId_Nhanvien + "'}";
         var pageUrl = "../../../../Webservice/nano_websv.asmx/Kiemtralichhentrung_Kythuat";

         $.ajax({
             type: "POST",
             url: pageUrl,
             data: param_dt,
             contentType: "application/json; charset=utf-8",
             dataType: "json",
             async: false,
             success: function (msg) {
                 if (msg.d == "YES") {
                     lbl_Error.SetText("Nhân viên kỹ thuật trùng lịch");
                     btnMyAppointmentFormOk.SetEnabled(false);
                 }
                 else if (msg.d == "ALL")
                 {
                     lbl_Error.SetText("Phòng đang bận");
                     btnMyAppointmentFormOk.SetEnabled(false);
                 }
                 else {
                     Check_Error(s,e);
                 }

             },
             error: onFail
         });
     }
    function Check_Error(s, e) {
        console.log("begin insert")
        var uId_Nhanvien = ddlNhanvien.GetValue();
        //var startDate = edtStartTimeAppointmentForm.GetDate();
        //var endDate = edtEndTimeAppointmentForm.GetDate();
        var startDate = '<%#(CType(Container, UserAppointmentFormTemplateContainer)).Start%>'
        var endDate = '<%#(CType(Container, UserAppointmentFormTemplateContainer)).End%>'
        var resourceid = '<%#(CType(Container, UserAppointmentFormTemplateContainer)).Appointment.ResourceId%>'
        var param_dt = "{'Resource':'" + resourceid + "','dStart':'" + startDate + "','dEnd':'" + endDate + "','uId_Nhanvien':'" + uId_Nhanvien + "'}";
        var pageUrl = "../../../../Webservice/nano_websv.asmx/Kiemtralichhentrung";

        $.ajax({
            type: "POST",
            url: pageUrl,
            data: param_dt,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (msg) {
                if (msg.d == "YES") {
                    lbl_Error.SetText("Nhân viên lễ tân trùng lịch");
                    btnMyAppointmentFormOk.SetEnabled(false);
                }
                else {
                    lbl_Error.SetText("");
                    btnMyAppointmentFormOk.SetEnabled(true);
                }

            },
            error: onFail
        });
    }
    $(document).ready(function () {
        var resourceid = '<%#(CType(Container, UserAppointmentFormTemplateContainer)).Appointment.ResourceId%>'
        var Startdate = '<%#(CType(Container, UserAppointmentFormTemplateContainer)).Start%>'
        var Endate = '<%#(CType(Container, UserAppointmentFormTemplateContainer)).End%>'
        var param_dt = "{'Resource':'" + resourceid + "','dStart':'" + Startdate + "','dEnd':'" + Endate + "'}";
        var pageUrl = "../../../../Webservice/nano_websv.asmx/Kiemtratrungphongdichvu";

        $.ajax({
            type: "POST",
            url: pageUrl,
            data: param_dt,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (msg) {
                if (msg.d == "YES") {
                    btnMyAppointmentFormOk.SetEnabled(false);
                }
            },
            error: onFail
        });
    });
    $(document).ready(function () {
        var uId_Nhanvien = ddlNhanvien.GetValue();
        //var startDate = edtStartTimeAppointmentForm.GetDate();
        //var endDate = edtEndTimeAppointmentForm.GetDate();
        var startDate = '<%#(CType(Container, UserAppointmentFormTemplateContainer)).Start%>'
        var endDate = '<%#(CType(Container, UserAppointmentFormTemplateContainer)).End%>'
        var resourceid = '<%#(CType(Container, UserAppointmentFormTemplateContainer)).Appointment.ResourceId%>'
        var param_dt = "{'Resource':'" + resourceid + "','dStart':'" + startDate + "','dEnd':'" + endDate + "','uId_Nhanvien':'" + uId_Nhanvien + "'}";
        var pageUrl = "../../../../Webservice/nano_websv.asmx/Kiemtralichhentrung";

        $.ajax({
            type: "POST",
            url: pageUrl,
            data: param_dt,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (msg) {
                if (msg.d == "YES") {
                    btnMyAppointmentFormOk.SetEnabled(false);
                }
            },
            error: onFail
        });
    });
    function edtEndDate_DateChanged(s,e) {
        var startDate = edtStartTimeAppointmentForm.GetDate();
        var endDate = edtEndTimeAppointmentForm.GetDate();
        var date = new Date(endDate.getFullYear(), endDate.getMonth(), endDate.getDate(), endDate.getHours()-1);
        edtStartTimeAppointmentForm.SetDate(date);
    }
    function edtStartDate_DateChanged(s, e) {
        var startDate = edtStartTimeAppointmentForm.GetDate();
        var endDate = edtEndTimeAppointmentForm.GetDate();
        var date = new Date(startDate.getFullYear(), startDate.getMonth(), startDate.getDate(), startDate.getHours() + 1);
        edtEndTimeAppointmentForm.SetDate(date);
        dll_Nhanvien_Kythuat.PerformCallback();
        ddlNhanvien.PerformCallback();
    }
</script>
