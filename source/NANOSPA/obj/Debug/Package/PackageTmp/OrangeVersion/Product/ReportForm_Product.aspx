<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="ReportForm_Product.aspx.vb" Inherits="NANO_SPA.ReportForm_Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            var param_dt = "{'uId_Chucnang':'8cd796a5-b840-4fbc-8c79-7bcc43096f68'}";
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
        <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>Báo cáo mặt hàng</p>
    </div>
    <div style="clear: both"></div>
    <fieldset class="field_tt">
        <legend><span style="font-weight: bold; color: green">Báo cáo</span></legend>
        <table class="info_table" style="margin: 0 auto;">
            <tbody>
                <tr>
                    <td class="info_table_td_report">
                        <a href="../../OrangeVersion/Report/Rp_web/Rp_Taichinh/Rp_TonghopNhap.aspx" style="text-decoration: none">
                            <img class="img-login" src="../../images/orange/reporticon.png" /><br />
                            Tổng hợp nhập</a>
                    </td>
                    <td class="info_table_td_report">
                        <a href="../../OrangeVersion/Report/Rp_web/Rp_Taichinh/Rp_TonghopXuat.aspx" style="text-decoration: none">
                            <img class="img-login" src="../../images/orange/reporticon.png" /><br />
                            Tổng hợp xuất</a>
                    </td>
                    <td class="info_table_td_report">
                        <a href="../../OrangeVersion/Report/Rp_web/Rp_Taichinh/Rp_MH_Vattutieuhao.aspx" style="text-decoration: none">
                            <img class="img-login" src="../../images/orange/reporticon.png" /><br />
                            Vật tư tiêu hao</a>
                    </td>
                    <td class="info_table_td_report">
                        <a href="Inventory.aspx" style="text-decoration: none">
                            <img class="img-login" src="../../images/orange/reporticon.png" /><br />
                            Tổng hợp số lượng tồn</a>
                    </td>
<%--                    <td class="info_table_td_report">
                        <a href="TermsOfUse.aspx" style="text-decoration: none">
                            <img class="img-login" src="../../images/orange/reporticon.png" /><br />
                            Hạn sử dụng</a>
                    </td>--%>
                    <td class="info_table_td_report">
                        <a href="WarehouseCard.aspx" style="text-decoration: none">
                            <img class="img-login" src="../../images/orange/reporticon.png" /><br />
                            Thẻ kho</a>
                    </td>
         
                </tr>
            </tbody>
        </table>
    </fieldset>
</asp:Content>
