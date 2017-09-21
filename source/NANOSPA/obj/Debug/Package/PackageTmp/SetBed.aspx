<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="SetBed.aspx.vb" Inherits="NANO_SPA.SetBed" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxDocking" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxDataView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxFileManager" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxClasses" TagPrefix="dx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
    <script type="text/javascript">
        //var time = new Date().getTime();
        //$(document.body).bind("mousemove keypress", function (e) {
        //    time = new Date().getTime();
        //});

        //function refresh() {
        //    if (new Date().getTime() - time >= 5000)
        //        dvphong.PerformCallback();
        //    else
        //        setTimeout(refresh, 10000);
        //}

        //setTimeout(refresh, 10000);
        setInterval(function () { autoloadpage(); }, 30000);
        function autoloadpage() {
            dvphong.PerformCallback();
        }

        var leave;
        setInterval(function () { CounterTimer(); }, 1000);
        function CounterTimer()
        {

            var day= Math.floor(leave/ ( 60 * 60 * 24));
            var hour = Math.floor(leave / 3600) - (day * 24)
            var minute = Math.floor(leave / 60) - (day * 24 *60) - (hour * 60)
            var second = Math.floor(leave) - (day * 24 *60*60) - (hour * 60 * 60) - (minute*60)
            hour=hour<10 ? "0" + hour : hour;
            minute=minute<10 ? "0" + minute : minute;
            second=second<10 ? "0" + second : second;
            var remain = hour + ":" + minute + ":" + second;
            if (lblthuc.GetText() == "Quá giờ:") {
                leave = leave + 1;
            }
            else {
                leave = leave - 1;
            }
            lblthuchien.SetText(remain);
        }

        var focusedItemId = "";
        function onClick(event) {
            focusedItemId = event.currentTarget.id;
            var data = focusedItemId.split("$");
            uid_ = data[0];
        }

        function HoveMouse(event) {
            focusedItemId = event.currentTarget.id;
            var data = focusedItemId.split("$");
            uid_ = data[0];
            var param_dt = "{'uId_Giuong':'" + uid_ + "'}";
            var pageUrl = "../../../../Webservice/nano_websv_CheckInCheckOut.asmx/LoadInfoBed";

            $.ajax({
                type: "POST",
                url: pageUrl,
                data: param_dt,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: SetInfoDataBed,
                error: onFail
            });
            PcInfoBed.Show();
            return false
        };
        function timeRefresh(timeoutPeriod) {
            setTimeout("location.reload(true);", timeoutPeriod);
        }

        function SetInfoDataBed(msg) {
            if (msg.d != "") {
                var hdfuIdDieutri = document.getElementById("<%=hdfuId_Dieutri.ClientID%>")
                
                var defaultdata = msg.d.split("$");
                hdfuIdDieutri.value = defaultdata[10];
                PcInfoBed.SetHeaderText(defaultdata[1] + " - " + defaultdata[0]);
                lbltrangthai.SetText(defaultdata[8]);
                txtkhachhang.SetText(defaultdata[6]);
                txtdichvu.SetText(defaultdata[2]);
                txtnhanvien.SetText(defaultdata[7]);
                txtcheckin.SetText(defaultdata[9]);
                leave = defaultdata[11];
                if (leave < 0) {
                    leave = Math.abs(leave);
                    lblthuc.SetText("Quá giờ:");
                }
                else {
                    lblthuc.SetText("Còn lại:");
                }
            }
        }
        function checkoutClick(s, e) {
            var uId_Dieutri_ = document.getElementById("<%=hdfuId_Dieutri.ClientID%>").value
            var param_dt = "{'uId_Dieutri':'" + uId_Dieutri_ + "'}";
            var pageUrl = "../../../../Webservice/nano_websv_CheckInCheckOut.asmx/checkOut";
            $.ajax({
                type: "POST",
                url: pageUrl,
                data: param_dt,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                success: function () { PcInfoBed.Hide(); dvphong.PerformCallback(); },
                error: onFail
            });
            return false
        }
    </script>
    <style type="text/css">
        .divleft {
            float: left;
            height: 188px;
            margin-left: 20px;
            margin-right: 10px;
            margin-top: 32px;
            max-height: 700px;
            min-height: 500px;
            width: 18%;
        }
    </style>
<%--    <fieldset>
        <legend><span style="font-weight: bold; color: green">Tìm kiếm</span></legend>
    </fieldset>--%>
    <fieldset>
        <legend><span style="font-weight: bold; color: green">Danh sách giường</span></legend>
        <dx:ASPxCallbackPanel ID="CbpMain" runat="server" ClientInstanceName ="cbpmain">
            <PanelCollection>
                <dx:PanelContent>
                    <dx:ASPxDataView ID="DvPhong" runat="server" RowPerPage="10" ColumnCount="1" Width="100%" ItemStyle-Border-BorderStyle="Solid" ClientInstanceName="dvphong"
                        OnCustomCallback="DvPhong_CustomCallback">
                        <ItemStyle Border-BorderColor="Red" Height="80px" Paddings-Padding="10px" />
                        <ItemTemplate>
                            <table width="100%">
                                <tr style ="margin:auto">
                                    <td style="width: 12% ; margin:auto">
                                        <div style="height: 30px; width: 100%; margin: auto; text-align: center; border:solid" id='<%# Eval("uId_Phong").ToString()%>' onclick="onClick(event)">
                                            <div style="margin: auto; font-size: 18px; color:orangered; font-weight:bold"><%# Eval("nv_Tenphong_vn").ToString()%></div>
                                        </div>
                                    </td>
                                    <td style="width:100px"></td>
                                    <td style="padding-left:10px">
                                        <dx:ASPxDataView ID="DvGiuongDetail" runat="server" OnDataBinding="DvGiuongDetail_DataBinding" RowPerPage="2" ColumnCount="9" ItemStyle-Height="100px" ItemStyle-Width="120px" ClientInstanceName="grvDetail">
                                            <ItemStyle Paddings-Padding="1px" />
                                            <ItemTemplate>
                                                <div id='<%# Eval("uId_Giuong").ToString() +"$"+ Eval("nv_TenGiuong_vn").ToString()%>' style="height: 85px" 
                                                    onclick='<%#If(Eval("trangthai").ToString = "Phòng trống", "", "return HoveMouse(event)")%>'>
                                                    <table style="margin: 0 auto; text-align: center">
                                                        <tr>
                                                            <td>
                                                                <b><%# Eval("nv_TenGiuong_vn").ToString()%></b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
<%--                                                                <dx:ASPxImage ID="img_Congdoan" runat="server" ShowLoadingImage="true" Width="60px" Height="80px" BackColor="Blue"
                                                                    ImageUrl='<%#If(Eval("trangthai").ToString = "Giường trống", "/images/16x16/door_in.png", "/images/16x16/door_out.png")%>'
                                                                    ClientInstanceName="img_Congdoan">
                                                                </dx:ASPxImage>--%>
                                                                <div style='width:100px; height:80px;<%#If(Eval("trangthai").ToString = "Phòng trống", "background:green", If(Convert.ToInt32(Eval("Timer").ToString().Split(":")(1)) > 15, "background:#F7d25d", "background:red"))%>'>
                                                                    <dx:ASPxLabel ID="lblTimer" ClientInstanceName="lbltimer" Text='<%#If(Eval("Timer").ToString() = "0:0", "", If(Convert.ToInt32(Eval("Timer").ToString().Split(":")(1)) > 0 Or Convert.ToInt32(Eval("Timer").ToString().Split(":")(0)) > 0, Eval("Timer").ToString(), "Hết giờ"))%>' runat="server" Font-Bold="true"
                                                                      Font-Size="24px"></dx:ASPxLabel>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <%--<i style='<%#If(Eval("trangthai").ToString = "Giường trống", "color:green", "color:red")%>'><%# Eval("trangthai").ToString()%></i>--%>
                                                                <dx:ASPxLabel ID="timelave" runat="server" ClientInstanceName="timelave" Text=""></dx:ASPxLabel>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </ItemTemplate>
                                        </dx:ASPxDataView>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </dx:ASPxDataView>
                </dx:PanelContent>
            </PanelCollection>
        </dx:ASPxCallbackPanel>
    </fieldset>
    <asp:HiddenField ID="hdfuId_Dieutri" runat="server" />
    <dx:ASPxPopupControl ID="PcInfoBed" runat="server" CloseAction="OuterMouseClick" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="TopSides" ClientInstanceName="PcInfoBed"
        ShowHeader="true" AllowDragging="True" PopupAnimationType="None" Font-Size="18px">
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl3" runat="server">
                <dx:ASPxPanel ID="ASPxPanel2" runat="server" Width="320px" >
                    <PanelCollection>
                        <dx:PanelContent ID="PanelContent3" runat="server">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <fieldset >
                                        <legend><dx:ASPxLabel ID="lblTrangthai" runat ="server" ClientInstanceName="lbltrangthai"></dx:ASPxLabel></legend>
                                        <table class="info_table">
                                            <tr>
                                                <td class ="info_table_td" style="width:100px">Khách hàng :</td>
                                                <td class ="info_table_td" colspan="3">
                                                    <dx:ASPxTextBox ID="txtKhachhang" ClientInstanceName="txtkhachhang" runat="server" Width="200px"></dx:ASPxTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="info_table_td">Dịch vụ:</td>
                                                <td class="info_table_td" colspan="3">
                                                    <dx:ASPxTextBox ID="txtDichvu" ClientInstanceName="txtdichvu" runat="server" Width="200px"></dx:ASPxTextBox>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td class="info_table_td">Nhân viên:</td>
                                                <td class="info_table_td" colspan="3">
                                                    <dx:ASPxTextBox ID="txtNhanvien" ClientInstanceName="txtnhanvien" runat="server" Width="200px"></dx:ASPxTextBox>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td class="info_table_td">Check in:</td>
                                                <td class="info_table_td">
                                                    <dx:ASPxTextBox ID="txtCheckin" ClientInstanceName="txtcheckin" runat="server" Width="50" EnableViewState="false" ></dx:ASPxTextBox>
                                                </td>
                                                 <td class="info_table_td">
                                                     <dx:ASPxLabel ID="lblth" ClientInstanceName="lblthuc" runat="server" ></dx:ASPxLabel></td>
                                                 <td class="info_table_td">
                                                     <dx:ASPxLabel ID="lblThuchien" runat="server" ClientInstanceName="lblthuchien" Text=""></dx:ASPxLabel>
                                                 </td>
                                            </tr>
                                            <tr>
                                                <td class="info_table_td" colspan="2">
                                                    <dx:ASPxButton ID="btnCheckOut" ClientInstanceName=" chkcheckout" runat="server" Text="Check Out" Font-Bold="true">
                                                        <ClientSideEvents Click="checkoutClick" />
                                                    </dx:ASPxButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxPanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <ContentStyle>
            <Paddings PaddingBottom="5px" />
        </ContentStyle>
    </dx:ASPxPopupControl>
</asp:Content>
