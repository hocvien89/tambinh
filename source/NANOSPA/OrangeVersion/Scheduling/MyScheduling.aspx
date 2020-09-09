<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="MyScheduling.aspx.vb" Inherits="NANO_SPA.MyScheduling" %>

<%@ Register Assembly="DevExpress.Web.ASPxScheduler.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxScheduler" TagPrefix="dxwschs" %>
<%@ Register Assembly="DevExpress.XtraScheduler.v12.2.Core, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraScheduler" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
    <%--    <script src="ext/dhtmlxscheduler_timeline.js,ext/dhtmlxscheduler_treetimeline.js,ext/dhtmlxscheduler_daytimeline.js  " type="text/javascript"> 
         
     
</script>--%>
    <script type="text/javascript">
        $(document).ready(function () {
            var param_dt = "{'uId_Chucnang':'630EBD69-FC73-4362-AA41-614A521CB327'}";
            var pageUrl = "../../../../Webservice/nano_websv.asmx/CheckRole";
            $.ajax({
                type: "POST",
                url: pageUrl,
                data: param_dt,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function (msg) {
                    if (msg.d == "false") {
                        window.location.href = "../../OrangeVersion/Util/DeclineRole.aspx";
                    }
                },
                error: onFail
            });
        });
    </script>
    <div class="brest_crum">
        <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>THIẾT LẬP LỊCH HẸN</p>
    </div>
    <div style="clear: both"></div>
    <div class="div-flex">
        <div class="box_ghichu hiddenipad" style="float: left; min-width: 239px">
            <fieldset class="field_tt">
                <legend><span style="font-weight: bold; color: green">Ghi chú</span></legend>
                <table class="info_table">
                    <tbody>
                        <%--<tr>
                        <td class="info_table_td">
                            <div style="width: 30px; height: 30px; background-color: white"></div>
                        </td>
                        <td>Trống
                        </td>
                    </tr>--%>
                        <tr>
                            <td class="info_table_td">
                                <div style="width: 30px; height: 30px; background-color: #F23A62"></div>
                            </td>
                            <td>Hẹn lịch
                            </td>
                        </tr>
                        <%-- <tr>
                        <td class="info_table_td">
                            <div style="width: 30px; height: 30px; background-color: #A8D5FF"></div>
                        </td>
                        <td>Chuyển lịch
                        </td>
                    </tr>--%>
                        <tr>
                            <td class="info_table_td">
                                <div style="width: 30px; height: 30px; background-color: #C1F49C"></div>
                            </td>
                            <td>Đã thực hiện
                            </td>
                        </tr>
                        <tr>
                            <td class="info_table_td">
                                <div style="width: 30px; height: 30px; background-color: #F3E4C7"></div>
                            </td>
                            <td>Lỡ hẹn
                            </td>
                        </tr>
                    </tbody>
                </table>
            </fieldset>
            <dxwschs:ASPxDateNavigator Width="240px" ID="ASPxDateNavigator1" MasterControlID="scheduler1" runat="server" Theme="Youthful">
                <Properties DayNameFormat="FirstLetter" />
            </dxwschs:ASPxDateNavigator>
        </div>
        <div class="box_lichhen">
            <dxwschs:ASPxScheduler ID="scheduler1" runat="server" ActiveViewType="Day" Width="100%" AppointmentDataSourceID="SqlDataSource1"
                ResourceDataSourceID="SqlDataSource2" OnInitAppointmentDisplayText="scheduler1_InitAppointmentDisplayText" OnQueryWorkTime="scheduler1_QueryWorkTime" GroupType="Resource" ClientInstanceName="schedule">
                <Views>
                    <DayView Enabled="true">
                        <TimeSlots ></TimeSlots>
                        <WorkTime Start="7:00:00" End="22:00:00" />
                        <TimeRulers>
                            <cc1:TimeRuler ShowMinutes="true" />
                        </TimeRulers>
                        <DayViewStyles ScrollAreaHeight="480px">
                            <TimeCellBody Height="100px"></TimeCellBody>
                        </DayViewStyles>
                      <%--  <Templates>
                            <ToolbarViewVisibleIntervalTemplate>
                                <%# Container.Scheduler.ActiveView.GetVisibleIntervals().Start.ToString("dd/MM/yyyy") + " - " + Container.Scheduler.ActiveView.GetVisibleIntervals().End.ToString("dd/MM/yyyy")%>
                            </ToolbarViewVisibleIntervalTemplate>
                            <DateHeaderTemplate>
                                <%--Thứ <%# Container.Interval.Start.DayOfWeek +1%>-- <%# Container.Interval.Start.DayOfWeek.ToString() %>  (<%# Container.Interval.Start.Date.ToString("dd/MM/yyyy")%>)
                            </DateHeaderTemplate>
                        </Templates>--%>
                        <AppointmentDisplayOptions AppointmentHeight="70" StartTimeVisibility="Auto" ShowRecurrence="true" />
                    </DayView>
                    <WorkWeekView Enabled="false" ShowFullWeek="true" DisplayName="Lịch hẹn" AppointmentDisplayOptions-AllDayAppointmentsStatusDisplayType="Bounds" ShowAllAppointmentsAtTimeCells="true">
                        <AppointmentDisplayOptions AppointmentHeight="30" ColumnPadding-Right="10" />
                        <TimeRulers>
                            <cc1:TimeRuler></cc1:TimeRuler>
                        </TimeRulers>
                        <WorkWeekViewStyles ScrollAreaHeight="480px" Appointment-ForeColor="Yellow" />
                        <Templates>
                            <ToolbarViewVisibleIntervalTemplate>
                                <%# Container.Scheduler.ActiveView.GetVisibleIntervals().Start.ToString("dd/MM/yyyy") + " - " + Container.Scheduler.ActiveView.GetVisibleIntervals().End.ToString("dd/MM/yyyy")%>
                            </ToolbarViewVisibleIntervalTemplate>
                            <DateHeaderTemplate>
                                Thứ <%# Container.Interval.Start.DayOfWeek + 1%> (<%# Container.Interval.Start.Date.ToString("dd/MM/yyyy") %>)
                            </DateHeaderTemplate>
                        </Templates>
                    </WorkWeekView>
                    <WeekView MenuCaption="&amp;WeekView " Enabled="false">
                        <Templates>
                            <ToolbarViewVisibleIntervalTemplate>
                                <%# Container.Scheduler.ActiveView.GetVisibleIntervals().Start.ToString("dd/MM/yyyy") + " - " + Container.Scheduler.ActiveView.GetVisibleIntervals().End.ToString("dd/MM/yyyy")%>
                            </ToolbarViewVisibleIntervalTemplate>
                        </Templates>
                    </WeekView>
                    <TimelineView ResourcesPerPage="5" IntervalCount="16" WorkTime-End="22:00:00" WorkTime-Start="7:00:00" Enabled="false">
                        <%-- <Templates>
                        <ToolbarViewVisibleIntervalTemplate>
                            <%# Container.Scheduler.ActiveView.GetVisibleIntervals().Start.ToString("hh:mm:ss") + " - " + Container.Scheduler.ActiveView.GetVisibleIntervals().End.ToString("hh:mm:ss")%>
                        </ToolbarViewVisibleIntervalTemplate>
                    </Templates>--%>
                        <%--<WorkTime Start="8:00"/>
                    <WorkTime End="21:00" />--%>
                        <AppointmentDisplayOptions AppointmentHeight="70" StartTimeVisibility="Auto" ShowRecurrence="true" />
                        <TimelineViewStyles>

                            <TimelineCellBody Height="100px"></TimelineCellBody>

                        </TimelineViewStyles>

                        <Scales>
                            <cc1:TimeScaleYear Enabled="false" />
                            <cc1:TimeScaleQuarter Enabled="false" />
                            <cc1:TimeScaleMonth Enabled="true" />
                            <cc1:TimeScaleWeek Enabled="false" />
                            <cc1:TimeScaleDay />
                            <cc1:TimeScaleHour Enabled="true" />
                            <cc1:TimeScaleFixedInterval Enabled="false" />
                            <cc1:TimeScale15Minutes Enabled="true" />
                        </Scales>
                    </TimelineView>
                </Views>
                <OptionsForms AppointmentFormTemplateUrl="~/OrangeVersion/Scheduling/UserAppointmentForm.ascx" />
                <OptionsBehavior ShowViewSelector="True" />
                <Storage EnableReminders="true">
                    <Appointments CommitIdToDataSource="false" AutoRetrieveId="true">
                        <Mappings
                            AppointmentId="UniqueID"
                            End="EndDate"
                            Start="StartDate"
                            Subject="Subject"
                            Description="Description"
                            Location="Location"
                            AllDay="AllDay"
                            Type="Type"
                            RecurrenceInfo="RecurrenceInfo"
                            ReminderInfo="ReminderInfo"
                            Label="Label"
                            Status="Status"
                            ResourceId="ResourceID" />
                        <CustomFieldMappings>
                            <dxwschs:ASPxAppointmentCustomFieldMapping Member="CustomField1" Name="CustomField1" />
                            <dxwschs:ASPxAppointmentCustomFieldMapping Member="uId_Nhanvien" Name="uId_Nhanvien" />
                            <dxwschs:ASPxAppointmentCustomFieldMapping Member="uId_Cuahang" Name="uId_Cuahang" />
                            <dxwschs:ASPxAppointmentCustomFieldMapping Member="uId_Dichvu" Name="uId_Dichvu" />
                            <dxwschs:ASPxAppointmentCustomFieldMapping Member="uId_Nhanvien_Kythuat" Name="uId_Nhanvien_Kythuat" />
                        </CustomFieldMappings>
                        <labels>
                    <dxwschs:AppointmentLabel Color="#F23A62" DisplayName="Hẹn lịch" MenuCaption="&amp;Hẹn lịch" />
                    <dxwschs:AppointmentLabel Color="193, 244, 156" DisplayName="Đã thực hiện" MenuCaption="&amp;Đã thực hiện" />
                    <dxwschs:AppointmentLabel Color="243, 228, 199" DisplayName="Lỡ hẹn" MenuCaption="&amp;Lỡ hẹn" />
                </labels>
                    </Appointments>

                    <Resources>
                        <Mappings ResourceId="ResourceID" Caption="ResourceName" Color="Color" Image="Image" />
                        <CustomFieldMappings>
                            <dxwschs:ASPxResourceCustomFieldMapping Member="ResourceID" Name="ResourceID" />
                        </CustomFieldMappings>
                    </Resources>
                </Storage>
                <OptionsView FirstDayOfWeek="Monday" />
            </dxwschs:ASPxScheduler>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:NANO_SPA.My.MySettings.sConnect %>"
                SelectCommand="SELECT qdn.ResourceID, r.ResourceName FROM dbo.Resources r	INNER JOIN	dbo.QT_DM_NHANVIEN qdn	ON	r.CustomField1	= qdn.uId_Nhanvien
                            INNER JOIN dbo.PQP_NHANVIEN_PHONG pnp	ON qdn.uId_Nhanvien=pnp.uId_Nhanvien
                            WHERE pnp.uId_Phongban='0685C720-892F-4474-930B-237289DE09EF'">
                <DeleteParameters>
                    <asp:Parameter Name="UniqueID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="ResourceID" Type="Int32" />
                    <asp:Parameter Name="ResourceName" Type="String" />
                    <asp:Parameter Name="Color" Type="Int32" />
                    <asp:Parameter Name="Image" Type="Object" />
                    <asp:Parameter Name="CustomField1" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="ResourceID" Type="Int32" />
                    <asp:Parameter Name="ResourceName" Type="String" />
                    <asp:Parameter Name="Color" Type="Int32" />
                    <asp:Parameter Name="Image" Type="Object" />
                    <asp:Parameter Name="CustomField1" Type="String" />
                    <asp:Parameter Name="UniqueID" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                ConnectionString="<%$ ConnectionStrings:NANO_SPA.My.MySettings.sConnect %>"
                DeleteCommand="DELETE FROM [Appointments] WHERE [UniqueID] = @UniqueID"
                InsertCommand="INSERT INTO [Appointments] ([Type], [StartDate], [EndDate], [AllDay], [Subject], [Location], [Description], [Status], [Label], [ResourceID], [ResourceIDs], [ReminderInfo], [RecurrenceInfo], [CustomField1], [uId_Nhanvien], [uId_Cuahang],[uId_Dichvu],[uId_Nhanvien_Kythuat]) 
                                                      VALUES (@Type, @StartDate, @EndDate, @AllDay, @Subject, @Location, @Description, @Status, @Label, @ResourceID, @ResourceIDs, @ReminderInfo, @RecurrenceInfo, @CustomField1, @uId_Nhanvien, @uId_Cuahang,@uId_Dichvu,@uId_Nhanvien_Kythuat)"
                SelectCommand="SELECT * FROM [Appointments]" UpdateCommand="UPDATE [Appointments] SET [Type] = @Type, [StartDate] = @StartDate, [EndDate] = @EndDate, [AllDay] = @AllDay, [Subject] = @Subject, [Location] = @Location, [Description] = @Description, [Status] = @Status, [Label] = @Label, [ResourceID] = @ResourceID, [ResourceIDs] = @ResourceIDs, [ReminderInfo] = @ReminderInfo, [RecurrenceInfo] =  @RecurrenceInfo, [CustomField1] = @CustomField1, [uId_Nhanvien] = @uId_Nhanvien, [uId_Cuahang] = @uId_Cuahang, [uId_Dichvu]= @uId_Dichvu,[uId_Nhanvien_Kythuat]=@uId_Nhanvien_Kythuat WHERE [UniqueID] = @UniqueID">
                <DeleteParameters>
                    <asp:Parameter Name="UniqueID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="Type" Type="Int32" />
                    <asp:Parameter Name="StartDate" Type="DateTime" />
                    <asp:Parameter Name="EndDate" Type="DateTime" />
                    <asp:Parameter Name="AllDay" Type="Boolean" />
                    <asp:Parameter Name="Subject" Type="String" />
                    <asp:Parameter Name="Location" Type="String" />
                    <asp:Parameter Name="Description" Type="String" />
                    <asp:Parameter Name="Status" Type="Int32" />
                    <asp:Parameter Name="Label" Type="Int32" />
                    <asp:Parameter Name="ResourceID" Type="Int32" />
                    <asp:Parameter Name="ResourceIDs" Type="String" />
                    <asp:Parameter Name="ReminderInfo" Type="String" />
                    <asp:Parameter Name="RecurrenceInfo" Type="String" />
                    <asp:Parameter Name="CustomField1" Type="String" />
                    <asp:Parameter Name="uId_Nhanvien" Type="String" />
                    <asp:Parameter Name="uId_Cuahang" Type="String" />
                    <asp:Parameter Name="uId_Dichvu" Type="String" />
                    <asp:Parameter Name="uId_Nhanvien_Kythuat" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Type" Type="Int32" />
                    <asp:Parameter Name="StartDate" Type="DateTime" />
                    <asp:Parameter Name="EndDate" Type="DateTime" />
                    <asp:Parameter Name="AllDay" Type="Boolean" />
                    <asp:Parameter Name="Subject" Type="String" />
                    <asp:Parameter Name="Location" Type="String" />
                    <asp:Parameter Name="Description" Type="String" />
                    <asp:Parameter Name="Status" Type="Int32" />
                    <asp:Parameter Name="Label" Type="Int32" />
                    <asp:Parameter Name="ResourceID" Type="Int32" />
                    <asp:Parameter Name="ResourceIDs" Type="String" />
                    <asp:Parameter Name="ReminderInfo" Type="String" />
                    <asp:Parameter Name="RecurrenceInfo" Type="String" />
                    <asp:Parameter Name="CustomField1" Type="String" />
                    <asp:Parameter Name="uId_Nhanvien" Type="String" />
                    <asp:Parameter Name="uId_Cuahang" Type="String" />
                    <%--              <asp:Parameter Name="uId_Nhanvien_Kythuat" Type="String" />--%>
                    <%--                <asp:Parameter Name="uId_Dichvu" Type="String" />--%>
                    <asp:Parameter Name="UniqueID" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
    </div>
    <div style="clear: both"></div>
</asp:Content>
