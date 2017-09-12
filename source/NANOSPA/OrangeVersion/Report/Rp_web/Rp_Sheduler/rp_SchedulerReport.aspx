<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="rp_SchedulerReport.aspx.vb" Inherits="NANO_SPA.rp_SchedulerReport" %>

<%@ Register Src="~/OrangeVersion/Report/Rp_web/ReportViewerControl.ascx" TagPrefix="uc1" TagName="ReportViewerControl" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v12.2, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxClasses" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.XtraReports.v12.2.Web, Version=12.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            var param_dt = "{'uId_Chucnang':'F4B1D801-F3CD-47A1-8CD0-9F3BFEDD22DA'}";
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
        <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>BÁO CÁO LỊCH HẸN</p>
    </div>
    <fieldset class="field_tt">
        <legend><span style="font-weight: bold; color: green">Thông tin lọc</span></legend>
        <table class="info_table">
            <tbody>
                <tr>
                    <td class="info_table_td">Từ ngày:
                    </td>
                    <td class="info_table_td">
                        <dx:ASPxDateEdit ID="deTuNgay" ClientInstanceName="deTuNgay" Style="float: left; margin-right: 8px;" Width="85px" EditFormat="DateTime" EditFormatString="dd/MM/yyyy"
                            runat="server">
                        </dx:ASPxDateEdit>
                    </td>
                    <td class="info_table_td">Đến ngày:
                    </td>
                    <td class="info_table_td">
                        <dx:ASPxDateEdit ID="deDenNgay" ClientInstanceName="deDenNgay" Style="float: left; margin-right: 8px;" Width="85px" EditFormat="DateTime" EditFormatString="dd/MM/yyyy"
                            runat="server">
                        </dx:ASPxDateEdit>
                    </td>
                    <td class="info_table_td">Cửa hàng:
                    </td>
                    <td class="info_table_td">
                        <dx:ASPxComboBox ID="ddlCuahang" ClientInstanceName="ddlCuahang" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" Width="130px" runat="server" ValueType="System.String">
                        </dx:ASPxComboBox>
                    </td>
                    <td class="info_table_td">Trạng thái:
                    </td>
                    <td class="info_table_td">
                        <dx:ASPxComboBox ID="ddlTrangthai" ClientInstanceName="ddlTrangthai" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" Width="130px" runat="server" ValueType="System.String">
                            <Items>
                                <dx:ListEditItem Value="3" Text="Tất cả" Selected="true" />
                                <dx:ListEditItem Value="0" Text="Hẹn lịch" />
<%--                                <dx:ListEditItem Value="1" Text="Chuyển lịch" />--%>
                                <dx:ListEditItem Value="1" Text="Đã thực hiện" />
                                <dx:ListEditItem Value="2" Text="Lỡ hẹn" />
                            </Items>
                        </dx:ASPxComboBox>
                    </td>
                    <td class="info_table_td">
                        Phòng :
                    </td>
                    <td class="info_table_td">
                        <dx:ASPxComboBox ID="cb_Phong" ClientInstanceName="cb_Phong" DropDownStyle="DropDown" IncrementalFilteringMode="StartsWith" Width="130px" SelectedIndex="0" runat="server" ValueType="System.String">
                        </dx:ASPxComboBox>
                    </td>
                    <td class="info_table_td">Tên khách hàng: 
                    </td>
                    <td class="info_table_td">
                        <dx:ASPxTextBox ID="txtTenkhachhang" runat="server" ></dx:ASPxTextBox>
                    </td>
                    <td class="info_table_td">
                        <dx:ASPxButton ID="btnFilter" OnClick="btnFilter_Click" ClientInstanceName="btnFilter" Image-Url="~/images/16x16/filter.png" AutoPostBack="false" Style="float: left; margin-left: 10px" runat="server" Text="Lọc">
                            <Image Url="~/images/16x16/filter.png"></Image>
                        </dx:ASPxButton>
                    </td>
                </tr>
            </tbody>
        </table>
    </fieldset>
    <div style="clear: both"></div>
    <div style="width: 88%; margin: auto; text-align: center">
        <dx:ReportToolbar ID="ReportToolbar1" runat='server' ShowDefaultButtons='False'
            ReportViewerID="ReportViewer1" Width="99%" Theme="Default">
            <Items>
                <dx:ReportToolbarButton ItemKind='Search' />
                <dx:ReportToolbarSeparator />
                <dx:ReportToolbarButton ItemKind='PrintReport' />
                <dx:ReportToolbarButton ItemKind='PrintPage' />
                <dx:ReportToolbarSeparator />
                <dx:ReportToolbarButton Enabled='False' ItemKind='FirstPage' />
                <dx:ReportToolbarButton Enabled='False' ItemKind='PreviousPage' />
                <dx:ReportToolbarLabel ItemKind='PageLabel' />
                <dx:ReportToolbarComboBox ItemKind='PageNumber' Width='65px'>
                </dx:ReportToolbarComboBox>
                <dx:ReportToolbarLabel ItemKind='OfLabel' />
                <dx:ReportToolbarTextBox IsReadOnly='True' ItemKind='PageCount' />
                <dx:ReportToolbarButton ItemKind='NextPage' />
                <dx:ReportToolbarButton ItemKind='LastPage' />
                <dx:ReportToolbarSeparator />
                <dx:ReportToolbarButton ItemKind='SaveToDisk' />
                <dx:ReportToolbarButton ItemKind='SaveToWindow' />
                <dx:ReportToolbarComboBox ItemKind='SaveFormat' Width='70px'>
                    <Elements>
                        <dx:ListElement Value='pdf' />
                        <dx:ListElement Value='xls' />
                        <dx:ListElement Value='xlsx' />
                        <dx:ListElement Value='rtf' />
                        <dx:ListElement Value='mht' />
                        <dx:ListElement Value='html' />
                        <dx:ListElement Value='txt' />
                        <dx:ListElement Value='csv' />
                        <dx:ListElement Value='png' />
                    </Elements>
                </dx:ReportToolbarComboBox>
            </Items>
            <Styles>
                <LabelStyle>
                    <Margins MarginLeft='3px' MarginRight='3px' />
                </LabelStyle>
            </Styles>
        </dx:ReportToolbar>
        <dx:ReportViewer ID="ReportViewer1" runat="server">
        </dx:ReportViewer>
    </div>
</asp:Content>
