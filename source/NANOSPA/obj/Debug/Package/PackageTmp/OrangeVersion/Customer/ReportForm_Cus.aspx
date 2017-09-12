<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/frmMain.Master" CodeBehind="ReportForm_Cus.aspx.vb" Inherits="NANO_SPA.ReportForm_Cus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Main" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            var param_dt = "{'uId_Chucnang':'61BA738B-D1E5-4B27-94C6-F2EBB0595164'}";
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
        <p class="p_header"><i class="fa fa-user fa-fw fa-1x"></i>Báo cáo dịch vụ</p>
    </div>
    <div style="clear: both"></div>
    <fieldset class="field_tt">
        <legend><span style="font-weight: bold; color: green">Báo cáo dịch vụ</span></legend>
        <table class="info_table" style="margin: 0 auto;">
            <tbody>
                <tr>
                    <td class="info_table_td_report">
                        <a href="CustomerStatistic.aspx" style="text-decoration: none">
                            <img class="img-login" src="../../images/orange/reporticon.png" /><br />
                            Báo cáo danh sách KH</a>
                    </td>
                    <td class="info_table_td_report">
                        <a href="../../../OrangeVersion/Customer/CustomerPotential.aspx" style="text-decoration: none">
                            <img class="img-login" src="../../images/orange/reporticon.png" /><br />
                            Báo cáo danh sách KH tiềm năng</a>
                    </td>
<%--                     <td class="info_table_td_report">
                        <a href="../../../OrangeVersion/Report/Rp_web/Rp_Customer/rp_Baocaothongketheonguon.aspx" style="text-decoration: none">
                            <img class="img-login" src="../../images/orange/reporticon.png" /><br />
                            Thông kê khách hàng theo nguồn</a>
                    </td>--%>
<%--                    <td class="info_table_td_report" >
                        <a href="../../../OrangeVersion/Customer/TherapyList.aspx" style="text-decoration: none">
                            <img class="img-login" src="../../images/orange/reporticon.png" /><br />
                            Báo cáo liệu trình</a>
                    </td>--%>
                    <td class="info_table_td_report">
                        <a href="../../../OrangeVersion/Category/DSKhachHangHuyDV.aspx" style="text-decoration: none">
                            <img class="img-login" src="../../images/orange/reporticon.png" /><br />
                            Báo cáo khách hàng hủy dịch vụ</a>
                    </td>
                    <td class="info_table_td_report">
                        <a href="../../../OrangeVersion/Customer/TherapyHistoryList.aspx" style="text-decoration: none">
                            <img class="img-login" src="../../images/orange/reporticon.png" /><br />
                            Báo cáo lịch sử liệu trình của KH</a>
                    </td>
<%--                    <td class="info_table_td_report">
                        <a href="../../../OrangeVersion/Report/Rp_web/Rp_Taichinh/rp_Baocao_Dichvu_Tonghop.aspx" style="text-decoration: none">
                            <img class="img-login" src="../../images/orange/reporticon.png" /><br />
                            Báo cáo dịch vụ tổng hợp</a>
                    </td>--%>
                </tr>
                <tr>
<%--                    <td class="info_table_td_report">
                    <a href="../../../OrangeVersion/Customer/CustomerHaveUsed.aspx" style="text-decoration:none">
                         <img class="img-login" src="../../images/orange/reporticon.png" /><br />
                            Báo cáo KH đã mua DV hoặc SP</a>
                    </td>
                    <td class="info_table_td_report">
                    <a href="../../../OrangeVersion/Customer/CustomerUnused.aspx" style="text-decoration:none">
                         <img class="img-login" src="../../images/orange/reporticon.png" /><br />
                            Báo cáo KH chưa mua DV hoặc SP</a>
                    </td>
                    <td class="info_table_td_report">
                    <a href="../../../OrangeVersion/Customer/CustomerByService.aspx" style="text-decoration:none">
                         <img class="img-login" src="../../images/orange/reporticon.png" /><br />
                            Báo cáo KH theo dịch vụ lẻ</a>
                    </td>
                    <td class="info_table_td_report">
                    <a href="../../../OrangeVersion/Customer/ChangeProductReturns.aspx" style="text-decoration:none">
                         <img class="img-login" src="../../images/orange/reporticon.png" /><br />
                            Báo cáo KH Đổi trả sản phẩm</a>
                    </td>--%>
                  <%--   <td class="info_table_td_report">
                    <a href="../../../OrangeVersion/Report/Rp_web/rp_Customer/rp_Baby.aspx" style="text-decoration:none">
                         <img class="img-login" src="../../images/orange/reporticon.png" /><br />
                            Báo cáo chăm sóc sau khi sinh</a>
                    </td>
                     <td class="info_table_td_report">
                    <a href="../../../OrangeVersion/Report/Rp_web/rp_Customer/rpt_Mother.aspx" style="text-decoration:none">
                         <img class="img-login" src="../../images/orange/reporticon.png" /><br />
                            Báo cáo chăm sóc bầu</a>
                    </td>--%>
                </tr>
                <tr>
                   

                </tr>
            </tbody>
        </table>
    </fieldset>
</asp:Content>
